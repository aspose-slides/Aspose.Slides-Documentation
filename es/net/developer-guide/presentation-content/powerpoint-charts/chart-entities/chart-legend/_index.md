---
title: Personalizar leyendas de gráficos en presentaciones en .NET
linktitle: Leyenda del gráfico
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
description: "Personalice las leyendas de los gráficos con Aspose.Slides para .NET para optimizar presentaciones de PowerPoint con formato de leyenda a medida."
---

## **Posición de la leyenda**
Para establecer las propiedades de la leyenda, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenga una referencia de la diapositiva.
- Agregue un gráfico a la diapositiva.
- Establezca las propiedades de la leyenda.
- Guarde la presentación como un archivo PPTX.

En el ejemplo siguiente, hemos configurado la posición y el tamaño de la leyenda del gráfico.
```c#
// Crear una instancia de la clase Presentation
Presentation presentation = new Presentation();

// Obtener referencia de la diapositiva
ISlide slide = presentation.Slides[0];

// Añadir un gráfico de columnas agrupadas en la diapositiva
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Establecer propiedades de la leyenda
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Guardar la presentación en disco
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```


## **Establecer tamaño de fuente de la leyenda**
Aspose.Slides para .NET permite a los desarrolladores establecer el tamaño de fuente de la leyenda. Por favor, siga los pasos a continuación:

- Instancie la clase `Presentation`.
- Cree el gráfico predeterminado.
- Establezca el tamaño de fuente.
- Establezca el valor mínimo del eje.
- Establezca el valor máximo del eje.
- Guarde la presentación en disco.
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


## **Establecer tamaño de fuente de la leyenda individual**
Aspose.Slides para .NET permite a los desarrolladores establecer el tamaño de fuente de las entradas individuales de la leyenda. Por favor, siga los pasos a continuación:

- Instancie la clase `Presentation`.
- Cree el gráfico predeterminado.
- Acceda a la entrada de la leyenda.
- Establezca el tamaño de fuente.
- Establezca el valor mínimo del eje.
- Establezca el valor máximo del eje.
- Guarde la presentación en disco.
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

Sí. Use el modo sin superposición ([Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/)=`false`); en este caso, el área del gráfico se reducirá para acomodar la leyenda.

**¿Puedo crear etiquetas de leyenda multilínea?**

Sí. Las etiquetas largas se ajustan automáticamente cuando el espacio es insuficiente; los saltos de línea forzados se admiten mediante caracteres de nueva línea en el nombre de la serie.

**¿Cómo hago que la leyenda siga el esquema de color del tema de la presentación?**

No establezca colores, rellenos o fuentes explícitos para la leyenda o su texto. Entonces heredarán del tema y se actualizarán correctamente cuando cambie el diseño.