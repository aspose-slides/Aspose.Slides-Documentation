---
title: Tabla de Datos del Gráfico
type: docs
url: /net/chart-data-table/
keywords: "Propiedades de fuente, tabla de datos del gráfico, presentación de PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Establecer propiedades de fuente para la tabla de datos del gráfico en presentaciones de PowerPoint en C# o .NET"
---

## **Establecer Propiedades de Fuente para la Tabla de Datos del Gráfico**
Aspose.Slides for .NET proporciona soporte para cambiar el color de las categorías en el color de una serie.

1. Instanciar un objeto de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Agregar un gráfico en la diapositiva.
1. Establecer la tabla del gráfico.
1. Establecer la altura de la fuente.
1. Guardar la presentación modificada.

 A continuación se presenta un ejemplo de muestra.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```