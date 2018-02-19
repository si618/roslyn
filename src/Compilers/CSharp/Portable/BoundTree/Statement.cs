﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using Microsoft.CodeAnalysis.Operations;

namespace Microsoft.CodeAnalysis.CSharp
{
    internal partial class BoundNode : IBoundNodeWithIOperationChildren
    {
        ImmutableArray<BoundNode> IBoundNodeWithIOperationChildren.Children => this.Children;

        /// <summary>
        /// Override this property to return the child bound nodes if the IOperation API corresponding to this bound node is not yet designed or implemented.
        /// </summary>
        /// <remarks>Note that any of the child bound nodes may be null.</remarks>
        protected virtual ImmutableArray<BoundNode> Children => ImmutableArray<BoundNode>.Empty;
    }

    internal partial class BoundBadStatement
    {
        protected override ImmutableArray<BoundNode> Children => this.ChildBoundNodes;
    }

    partial class BoundLocalFunctionStatement
    {
        protected override ImmutableArray<BoundNode> Children => ImmutableArray.Create<BoundNode>(this.Body);
    }

    partial class BoundFixedStatement
    {
        protected override ImmutableArray<BoundNode> Children => ImmutableArray.Create<BoundNode>(this.Declarations, this.Body);
    }

    partial class BoundPointerIndirectionOperator
    {
        protected override ImmutableArray<BoundNode> Children => ImmutableArray.Create<BoundNode>(this.Operand);
    }

    partial class BoundConstructorMethodBody
    {
        // PROTOTYPE(ExpressionVariables): Remove this override once we have support for this node in IOperation
        protected override ImmutableArray<BoundNode> Children => ImmutableArray.Create<BoundNode>(this.Initializer, this.BlockBody, this.ExpressionBody);
    }

    partial class BoundNonConstructorMethodBody
    {
        // PROTOTYPE(ExpressionVariables): Remove this override once we have support for this node in IOperation
        protected override ImmutableArray<BoundNode> Children => ImmutableArray.Create<BoundNode>(this.BlockBody, this.ExpressionBody);
    }
}
