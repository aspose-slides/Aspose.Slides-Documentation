---
title: Personalizar leyendas de gráficos en presentaciones en .NET
linktitle: Leyenda de gráfico
type: docs
url: /es/net/chart-legend/
keywords:
- leyenda de gráfico
- posición de la leyenda
- tamaño de fuente
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Personalice las leyendas de gráficos con Aspose.Slides para .NET para optimizar presentaciones de PowerPoint con un formato de leyenda a medida."
---

## **Posicionamiento de la leyenda**
Para establecer las propiedades de la leyenda, siga los pasos a continuación:

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtener la referencia de la diapositiva.
- Agregar un gráfico en la diapositiva.
- Establecer las propiedades de la leyenda.
- Guardar la presentación como archivo PPTX.

En el ejemplo a continuación, hemos configurado la posición y el tamaño de la leyenda del gráfico.
```c#
// Crear una instancia de la clase Presentation
Presentation presentation = new Presentation();

// Obtener la referencia de la diapositiva
ISlide slide = presentation.Slides[0];

// Agregar un gráfico de columnas agrupadas en la diapositiva
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Establecer propiedades de la leyenda
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Guardar la presentación en disco
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```


## **Establecer el tamaño de fuente de una leyenda**
Aspose.Slides for .NET permite a los desarrolladores establecer el tamaño de fuente de la leyenda. Por favor, siga los pasos a continuación:

- Instanciar la clase `Presentation`.
- Crear el gráfico predeterminado.
- Establecer el tamaño de fuente.
- Establecer el valor mínimo del eje.
- Establecer el valor máximo del eje.
- Guardar la presentación en disco.
```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Establecer el tamaño de fuente de una leyenda individual**
Aspose.Slides for .NET permite a los desarrolladores establecer el tamaño de fuente de entradas individuales de la leyenda. Por favor, siga los pasos a continuación:

- Instanciar la clase `Presentation`.
- Crear el gráfico predeterminado.
- Acceder a la entrada de la leyenda.
- Establecer el tamaño de fuente.
- Establecer el valor mínimo del eje.
- Establecer el valor máximo del eje.
- Guardar la presentación en disco.
```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Puedo habilitar la leyenda para que el gráfico asigne automáticamente espacio para ella en lugar de superponerse?**

Sí. Use el modo sin superposición (Overlay = `false`); en este caso, el área del gráfico se reducirá para acomodar la leyenda.

**¿Puedo crear etiquetas de leyenda de varias líneas?**

Sí. Las etiquetas largas se ajustan automáticamente cuando el espacio es insuficiente; los saltos de línea forzados se admiten mediante caracteres de nueva línea en el nombre de la serie.

**¿Cómo hago que la leyenda siga el esquema de colores del tema de la presentación?**

No establezca colores/rellenos/fuentes explícitos para la leyenda ni su texto. Entonces heredarán del tema y se actualizarán correctamente cuando el diseño cambie.