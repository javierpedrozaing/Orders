using System;
using Microsoft.AspNetCore.Components;

namespace Orders.Frontend.Shared
{
	public partial class GenericList<Titem>
	{
		[Parameter] public RenderFragment? Loading { get; set; }

        [Parameter] public RenderFragment? NoRecords { get; set; }

        [EditorRequired, Parameter] public RenderFragment? Body { get; set; } // EditorRequired para especificar parametros obligatorios

        [EditorRequired, Parameter] public List<Titem> MyList { get; set; } = null;
    }
}

