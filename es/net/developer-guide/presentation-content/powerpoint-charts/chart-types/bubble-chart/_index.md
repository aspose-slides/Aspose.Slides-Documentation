---
title: Gráfico de burbujas
type: docs
url: /es/net/bubble-chart/
keywords: "Gráfico de burbujas, tamaño de gráfico, presentación de PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Tamaño del gráfico de burbujas en presentaciones de PowerPoint en C# o .NET"
---

## **Escala de tamaño del gráfico de burbujas**
Aspose.Slides for .NET ofrece soporte para la escala de tamaño de los gráficos de burbujas. En Aspose.Slides for .NET se han añadido las propiedades **IChartSeries.BubbleSizeScale** y **IChartSeriesGroup.BubbleSizeScale**. A continuación se muestra un ejemplo.
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Representar datos como tamaños de gráfico de burbujas**
Se ha añadido la propiedad **BubbleSizeRepresentation** a las interfaces IChartSeries e IChartSeriesGroup, y a las clases relacionadas. **BubbleSizeRepresentation** especifica cómo se representan los valores de tamaño de burbuja en el gráfico de burbujas. Los valores posibles son: **BubbleSizeRepresentationType.Area** y **BubbleSizeRepresentationType.Width**. En consecuencia, se ha añadido el enumerado **BubbleSizeRepresentationType** para indicar las formas posibles de representar datos como tamaños de gráfico de burbujas. A continuación se muestra código de ejemplo.
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Se admite un “gráfico de burbujas con efecto 3‑D” y en qué se diferencia de uno normal?**

Sí. Existe un tipo de gráfico separado, “Bubble with 3‑D”. Aplica estilo 3‑D a las burbujas pero no añade un eje adicional; los datos siguen siendo X‑Y‑S (tamaño). El tipo está disponible en la enumeración [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

**¿Hay algún límite en la cantidad de series y puntos en un gráfico de burbujas?**

No hay un límite estricto a nivel de API; las restricciones dependen del rendimiento y de la versión de PowerPoint de destino. Se recomienda mantener un número razonable de puntos para garantizar la legibilidad y la velocidad de renderizado.

**¿Cómo afecta la exportación al aspecto de un gráfico de burbujas (PDF, imágenes)?**

La exportación a los formatos compatibles conserva la apariencia del gráfico; el renderizado lo realiza el motor de Aspose.Slides. Para formatos raster o vector, se aplican las reglas generales de renderizado de gráficos (resolución, anti‑aliasing), por lo que se debe elegir un DPI suficiente para la impresión.