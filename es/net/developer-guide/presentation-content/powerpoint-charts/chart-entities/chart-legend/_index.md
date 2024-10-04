---
title: Leyenda del Gráfico
type: docs
url: /net/chart-legend/
keywords: "Leyenda del gráfico, tamaño de fuente de la leyenda, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Establecer la posición y el tamaño de fuente para la leyenda del gráfico en presentaciones de PowerPoint en C# o .NET"
---

## **Posicionamiento de la Leyenda**
Para establecer las propiedades de la leyenda. Por favor, siga los pasos a continuación:

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtener referencia de la diapositiva.
- Agregar un gráfico en la diapositiva.
- Configurar las propiedades de la leyenda.
- Escribir la presentación como un archivo PPTX.

En el ejemplo dado a continuación, hemos establecido la posición y el tamaño para la leyenda del gráfico.

```c#
// Crear una instancia de la clase Presentation
Presentation presentation = new Presentation();

// Obtener referencia de la diapositiva
ISlide slide = presentation.Slides[0];

// Agregar un gráfico de columnas agrupadas en la diapositiva
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Establecer las propiedades de la leyenda
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Escribir la presentación en disco
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```



## **Establecer el Tamaño de Fuente de la Leyenda**
Aspose.Slides para .NET permite a los desarrolladores establecer el tamaño de fuente de la leyenda. Por favor, siga los pasos a continuación:

- Instanciar la clase `Presentation`.
- Crear el gráfico predeterminado.
- Establecer el tamaño de fuente.
- Establecer el valor mínimo del eje.
- Establecer el valor máximo del eje.
- Escribir la presentación en disco.

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


## **Establecer el Tamaño de Fuente de la Leyenda Individual**
Aspose.Slides para .NET permite a los desarrolladores establecer el tamaño de fuente de las entradas individuales de la leyenda. Por favor, siga los pasos a continuación:

- Instanciar la clase `Presentation`.
- Crear el gráfico predeterminado.
- Acceder a la entrada de la leyenda.
- Establecer el tamaño de fuente.
- Establecer el valor mínimo del eje.
- Establecer el valor máximo del eje.
- Escribir la presentación en disco.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```