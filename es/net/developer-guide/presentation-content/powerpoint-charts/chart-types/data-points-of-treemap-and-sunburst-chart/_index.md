---
title: Personalizar puntos de datos en gráficos Treemap y Sunburst en .NET
linktitle: Puntos de datos en gráficos Treemap y Sunburst
type: docs
url: /es/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- gráfico Treemap
- gráfico Sunburst
- punto de datos
- color de etiqueta
- color de rama
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a gestionar los puntos de datos en gráficos Treemap y Sunburst con Aspose.Slides para .NET, compatible con los formatos de PowerPoint."
---

Entre otros tipos de gráficos de PowerPoint, existen dos tipos “jerárquicos”: los gráficos **Treemap** y **Sunburst** (también conocidos como Gráfico Sunburst, Diagrama Sunburst, Gráfico radial, Gráfico radial o Gráfico de pastel multinivel). Estos gráficos muestran datos jerárquicos organizados como un árbol, desde las hojas hasta la parte superior de la rama. Las hojas se definen mediante los puntos de datos de la serie, y cada nivel de agrupación anidado posterior se define mediante la categoría correspondiente. Aspose.Slides for .NET permite formatear los puntos de datos del gráfico Sunburst y del Treemap en C#.

Aquí hay un gráfico Sunburst, donde los datos en la columna Series1 definen los nodos hoja, mientras que las demás columnas definen los puntos de datos jerárquicos:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Comencemos añadiendo un nuevo gráfico Sunburst a la presentación:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```


{{% alert color="primary" title="Ver también" %}} 
- [**Creación de gráfico Sunburst**](/slides/es/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Si es necesario formatear los puntos de datos del gráfico, debemos usar lo siguiente:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel) clases 
y [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) propiedad 
proporcionan acceso para formatear los puntos de datos de los gráficos Treemap y Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager) 
se utiliza para acceder a categorías multinivel; representa el contenedor de 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) objetos. 
Básicamente es un contenedor para 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartCategoryLevelsManager) con 
las propiedades añadidas específicas para los puntos de datos. 
La clase [**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) tiene 
dos propiedades: [**Format**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/format) y 
[**DataLabel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/label) que 
proporcionan acceso a la configuración correspondiente.

## **Mostrar el valor de un punto de datos**
Mostrar el valor del punto de datos "Leaf 4":
```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Establecer la etiqueta y el color de un punto de datos**
Establecer la etiqueta del punto de datos "Branch 1" para que muestre el nombre de la serie ("Series1") en lugar del nombre de la categoría. Luego establecer el color del texto a amarillo:
```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Establecer el color de la rama de un punto de datos**

Cambiar el color de la rama "Stem 4":
```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**¿Puedo cambiar el orden (clasificación) de los segmentos en Sunburst/Treemap?**

No. PowerPoint ordena los segmentos automáticamente (normalmente por valores descendentes, en sentido horario). Aspose.Slides refleja este comportamiento: no puedes cambiar el orden directamente; lo logras preprocesando los datos.

**¿Cómo afecta el tema de la presentación a los colores de los segmentos y las etiquetas?**

Los colores del gráfico heredan el [tema/paleta](/slides/es/net/presentation-theme/) de la presentación, a menos que establezcas explícitamente rellenos o fuentes. Para obtener resultados coherentes, fija rellenos sólidos y el formato de texto en los niveles requeridos.

**¿La exportación a PDF/PNG preservará los colores personalizados de las ramas y la configuración de las etiquetas?**

Sí. Al exportar la presentación, la configuración del gráfico (rellenos, etiquetas) se conserva en los formatos de salida porque Aspose.Slides renderiza con el formato del gráfico aplicado.

**¿Puedo calcular las coordenadas reales de una etiqueta/elemento para colocar una superposición personalizada sobre el gráfico?**

Sí. Después de que se valida el diseño del gráfico, `ActualX`/`ActualY` están disponibles para los elementos (por ejemplo, un [DataLabel](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabel/)), lo que ayuda a posicionar con precisión las superposiciones.