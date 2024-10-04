---
title: Puntos de Datos del Gráfico de Treemap y Sunburst
type: docs
url: /es/net/data-points-of-treemap-and-sunburst-chart/
keywords: "Gráfico de Sunburst, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Agregar gráfico de sunburst en presentación de PowerPoint en C# o .NET"
---

Entre otros tipos de gráficos de PowerPoint, hay dos tipos "jerárquicos" - **Treemap** y **Sunburst** (también conocido como Gráfico de Sunburst, Diagrama de Sunburst, Gráfico Radial o Gráfico de Pastel Multi Nivel). Estos gráficos muestran datos jerárquicos organizados como un árbol - desde las hojas hasta la parte superior de la rama. Las hojas se definen por los puntos de datos de la serie, y cada nivel de agrupamiento anidado subsiguiente se define por la categoría correspondiente. Aspose.Slides para .NET permite formatear los puntos de datos del Gráfico de Sunburst y Treemap en C#.

Aquí hay un Gráfico de Sunburst, donde los datos en la columna Series1 definen los nodos hoja, mientras que otras columnas definen los puntos de datos jerárquicos:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Comencemos añadiendo un nuevo gráfico de Sunburst a la presentación:



```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="Ver también" %}} 
- [**Creando Gráfico de Sunburst**](/slides/es/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}


Si hay necesidad de formatear los puntos de datos del gráfico, debemos usar lo siguiente:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager),  
[IChartDataPointLevel](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel) clases  
y la propiedad [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels)  
proporcionan acceso para formatear los puntos de datos de los gráficos de Treemap y Sunburst.  
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager)  
se utiliza para acceder a categorías de múltiples niveles - representa el contenedor de  
[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) objetos.  
Básicamente, es un contenedor para  
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartCategoryLevelsManager) con  
las propiedades añadidas específicas para los puntos de datos.  
La clase [**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) tiene  
dos propiedades: [**Format**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/format) y  
[**DataLabel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/label) que  
proporcionan acceso a los ajustes correspondientes.
## **Mostrar Valor del Punto de Datos**
Mostrar el valor del punto de datos "Hoja 4":



```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **Establecer Etiqueta y Color del Punto de Datos**
Establecer la etiqueta de datos de "Rama 1" para mostrar el nombre de la serie ("Serie1") en lugar del nombre de la categoría. Luego establecer el color del texto a amarillo:



```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **Establecer Color de Rama del Punto de Datos**

Cambiar el color de la rama "Tallo 4":

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
