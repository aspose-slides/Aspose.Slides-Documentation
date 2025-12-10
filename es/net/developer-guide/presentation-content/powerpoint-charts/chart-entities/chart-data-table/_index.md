---
title: Personalizar tablas de datos de gráficos en presentaciones en .NET
linktitle: Tabla de datos
type: docs
url: /es/net/chart-data-table/
keywords:
- datos de gráfico
- tabla de datos
- propiedades de fuente
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Personaliza tablas de datos de gráficos en .NET para PPT y PPTX con Aspose.Slides para aumentar la eficiencia y el atractivo en las presentaciones."
---

## **Establecer propiedades de fuente para una tabla de datos de gráfico**
Aspose.Slides for .NET ofrece soporte para cambiar el color de las categorías en un color de serie.

1. Instanciar el objeto de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Agregar un gráfico en la diapositiva.
1. Establecer la tabla del gráfico.
1. Establecer la altura de la fuente.
1. Guardar la presentación modificada.

A continuación se muestra un ejemplo.

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


## **Preguntas frecuentes**

**¿Puedo mostrar pequeñas claves de leyenda junto a los valores en la tabla de datos del gráfico?**

Sí. La tabla de datos admite [legend keys](https://reference.aspose.com/slides/net/aspose.slides.charts/datatable/showlegendkey/), y puedes activarlas o desactivarlas.

**¿Se conservará la tabla de datos al exportar la presentación a PDF, HTML o imágenes?**

Sí. Aspose.Slides renderiza el gráfico como parte de la diapositiva, por lo que el [PDF](/slides/es/net/convert-powerpoint-to-pdf/)/[HTML](/slides/es/net/convert-powerpoint-to-html/)/[image](/slides/es/net/convert-powerpoint-to-png/) exportado incluye el gráfico con su tabla de datos.

**¿Se admiten tablas de datos para gráficos que provienen de un archivo de plantilla?**

Sí. Para cualquier gráfico cargado desde una presentación o plantilla existente, puedes comprobar y cambiar si una tabla de datos [se muestra](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/) usando las propiedades del gráfico.

**¿Cómo puedo encontrar rápidamente qué gráficos en un archivo tienen la tabla de datos habilitada?**

Inspecciona la propiedad de cada gráfico que indica si la tabla de datos [se muestra](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/) y recorre las diapositivas para identificar los gráficos donde está habilitada.