---
title: Personalizar gráficos 3D en presentaciones en .NET
linktitle: Gráfico 3D
type: docs
url: /es/net/3d-chart/
keywords:
- gráfico 3D
- rotación
- profundidad
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Crear gráficos 3D en presentaciones PowerPoint con Aspose.Slides para .NET. Ajuste la rotación, las proporciones de altura, la profundidad del gráfico y el espaciado entre series con ejemplos en C#."
---
## **Visión general**

Aspose.Slides for .NET le permite personalizar la vista de un gráfico 3D mediante la propiedad [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/). Este artículo muestra cómo ajustar la rotación, las proporciones de altura, la profundidad, los ejes en ángulo recto y el espaciado entre series, y luego guardar la presentación en formato PPTX.

## **Establecer la rotación y la profundidad de un gráfico 3D**

El ejemplo a continuación crea una [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) y utiliza [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) para añadir un gráfico de columnas apiladas 3D a su primera diapositiva. Reemplaza las series y categorías predeterminadas por dos series que contienen tres valores cada una. El índice de hoja de cálculo `0` identifica la primera hoja de datos del gráfico; la fila `0` contiene los nombres de las series y la columna `0` contiene las etiquetas de categoría.

Las propiedades [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) y [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) establecen la rotación del gráfico en 40 y 270 grados, respectivamente. [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) define su profundidad al 150 % de su ancho, mientras que [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) habilita ejes en ángulo recto en lugar de perspectiva. La presentación resultante contiene el gráfico poblado con estos ajustes de vista 3D.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

var values = new double[,] { { 20, 50, 30 }, { 30, 10, 60 } };

for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, 0, $"Category {categoryIndex + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

for (var seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, seriesIndex + 1, $"Series {seriesIndex + 1}");
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

    for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }
}

chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **Aplicar un relleno de imagen a la superficie de un gráfico 3D**

Un gráfico 3D tiene tres superficies que pueden rellenarse de forma independiente: la [side wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/sidewall/), la [back wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) y el [floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/). Establezca el [fill type](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) de la superficie seleccionada a `Picture` y asigne una imagen. Configure tanto el [picture fill mode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) como el [picture type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartwall/picturetype/) de la superficie a `Stretch` para que una copia de la imagen se ajuste a toda la superficie.

Guarde [arrow.png](arrow.png) en el directorio de trabajo. El ejemplo rota el gráfico y eleva el valor máximo del eje vertical para que el suelo sea visible entre las columnas. Luego clona la diapositiva dos veces antes de aplicar la flecha a una superficie diferente en cada diapositiva. Los tres gráficos conservan los mismos datos, ángulo de visión y fondo.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 20, 30, 680, 480);
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 30;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 24;

var backSlide = presentation.Slides.AddClone(slide);
var floorSlide = presentation.Slides.AddClone(slide);
var backChart = (IChart)backSlide.Shapes[0];
var floorChart = (IChart)floorSlide.Shapes[0];

var imageBytes = File.ReadAllBytes("arrow.png");
var arrow = presentation.Images.AddImage(imageBytes);

foreach (var surface in new[] { chart.SideWall, backChart.BackWall, floorChart.Floor })
{
    var fill = surface.Format.Fill;
    fill.FillType = FillType.Picture;
    fill.PictureFillFormat.Picture.Image = arrow;
    fill.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    surface.PictureType = PictureType.Stretch;
}

presentation.Save("chart-surfaces.pptx", SaveFormat.Pptx);
```

Microsoft PowerPoint muestra las tres diapositivas de la siguiente forma.

| Pared lateral | Pared trasera | Suelo |
| --- | --- | --- |
| ![Flecha apuntando al gráfico a lo largo de la pared lateral](side-wall.png) | ![Flecha apuntando a la derecha a través de la pared trasera](back-wall.png) | ![Flecha apuntando a la derecha a través del suelo entre las columnas](floor.png) |

## **Ajustar las proporciones de altura de un gráfico 3D**

Utilice [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) para establecer la altura de un gráfico 3D como porcentaje de su ancho. Esto cambia las proporciones de la escena 3D sin redimensionar el objeto del gráfico en la diapositiva.

El siguiente ejemplo crea un gráfico [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) con los datos predeterminados: tres series y cuatro categorías. Guarda tres presentaciones con proporciones de altura del 50 %, 100 % y 200 %. La posición, ancho y altura del gráfico permanecen fijos. Los datos, la rotación, la profundidad, el espaciado de series y el formato son idénticos en los tres archivos; sólo cambia el porcentaje de altura.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 460);
chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.DepthPercents = 100;
chart.ChartData.Series[0].ParentSeriesGroup.GapDepth = 150;

foreach (ushort heightPercent in new ushort[] { 50, 100, 200 })
{
    chart.Rotation3D.HeightPercents = heightPercent;
    presentation.Save($"chart_height_{heightPercent}.pptx", SaveFormat.Pptx);
}
```

Las siguientes imágenes se exportaron de las presentaciones generadas mediante Microsoft PowerPoint. Un porcentaje menor produce una escena más plana, mientras que un porcentaje mayor produce una escena más alta dentro del mismo objeto del gráfico. PowerPoint también puede ajustar los intervalos de marcas del eje y la colocación de etiquetas para adaptarse a la escena.

| Altura: 50 % | Altura: 100 % | Altura: 200 % |
| --- | --- | --- |
| ![Gráfico de columnas 3D con altura establecida al 50 % de su ancho](height_percent_50.png) | ![Gráfico de columnas 3D con altura establecida al 100 % de su ancho](height_percent_100.png) | ![Gráfico de columnas 3D con altura establecida al 200 % de su ancho](height_percent_200.png) |

Estas propiedades controlan diferentes aspectos del gráfico:

| Property | Effect |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | Altura de la escena 3D como porcentaje de su ancho. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | Altura del objeto gráfico en la diapositiva, en puntos. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Profundidad de la escena 3D como porcentaje de su ancho. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Espaciado entre series a lo largo del eje de profundidad, como porcentaje del ancho del marcador. |

El ajuste de altura afecta a los gráficos de columnas y barras 3D, incluidas sus variantes cilindro, cono y pirámide, así como a los gráficos de líneas, áreas, sectores y superficies 3D. La comparación anterior utiliza el tipo verificado `Column3D`. El ajuste no modifica la apariencia de un gráfico 2D `ClusteredColumn` ni de un gráfico `BubbleWith3D`; estos nombres son miembros de la enumeración [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Para otros ajustes de apariencia del gráfico, consulte [Chart Formatting](/slides/es/net/chart-formatting/).

## **Ajustar el espacio entre series**

Utilice [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) para controlar la distancia entre series de datos a lo largo del eje de profundidad de un gráfico 3D, expresada como porcentaje del ancho del marcador. Utilice valores desde **0 hasta 500**, inclusive: `0` elimina el espacio, mientras que valores mayores aumentan el espaciado. Con una profundidad de gráfico fija, aumentar el espacio hace que los marcadores sean más delgados a lo largo del eje de profundidad.

Acceda al grupo mediante [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). El ajuste se aplica a todas las series de ese grupo, no solo a la serie utilizada para acceder a él. [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) es de solo lectura y refleja el ajuste del grupo padre.

Este ajuste afecta a los gráficos de columnas y barras 3D, incluidas sus variantes cilindro, cono y pirámide, así como a los gráficos de líneas y áreas 3D. La apariencia depende de si las series están dispuestas en profundidad, agrupadas o apiladas. Para una comparación clara de los espacios entre series separadas, utilice `ChartType.Column3D` de la enumeración [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

Estas propiedades controlan diferentes aspectos del gráfico:

| Property | Effect |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Espaciado entre series a lo largo del eje de profundidad, como porcentaje del ancho del marcador. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | Espaciado entre grupos adyacentes de barras o columnas, como porcentaje del ancho de la barra o columna. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Profundidad total del gráfico, como porcentaje del ancho del gráfico. |

El siguiente ejemplo autocontenido utiliza los datos predeterminados del gráfico, que contienen tres series y cuatro categorías. Guarda dos presentaciones con datos idénticos, rotación, ancho de espacio y profundidad del gráfico; solo cambia la profundidad del espacio.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 230);

chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.DepthPercents = 100;

var series = chart.ChartData.Series[0];
var group = series.ParentSeriesGroup;
group.GapWidth = 150;

foreach (ushort gapDepth in new ushort[] { 0, 500 })
{
    group.GapDepth = gapDepth;

    var fileName = $"series_gap_depth_{gapDepth}.pptx";
    presentation.Save(fileName, SaveFormat.Pptx);

}
```

Las siguientes imágenes se exportaron de las presentaciones generadas mediante Microsoft PowerPoint.

| Espacio de profundidad: 0 % | Espacio de profundidad: 500 % |
| --- | --- |
| ![Gráfico de columnas 3D sin espacio entre series a lo largo del eje de profundidad](gap_depth_0.png) | ![Gráfico de columnas 3D con un espacio del 500 % entre series a lo largo del eje de profundidad](gap_depth_500.png) |

## **Cambiar el tipo de serie 3D y la forma de la barra**

En un gráfico de cilindro agrupado, la primera serie comienza con una forma de barra cilíndrica. El ejemplo lee [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) y [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) antes y después de cada cambio.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Type = ChartType.ClusteredCone;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Bar3DShape = ChartShapeType.Box;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

presentation.Save("series_shape.pptx", SaveFormat.Pptx);
```

| Cambiar a la primera serie | `Type` | `Bar3DShape` |
| --- | --- | --- |
| Crear el gráfico | `ClusteredCylinder` | `Cylinder` |
| Establecer `Type` a `ClusteredCone` | `ClusteredCone` | `Cone` |
| Establecer `Bar3DShape` a `Box` | `ClusteredColumn3D` | `Box` |

Establecer la forma a `Box` también cambia el tipo de serie a `ClusteredColumn3D`. Si su código ramifica según el tipo de serie, lea `series.Type` después de cambiar la forma. Un valor almacenado en caché antes de la asignación seguiría seleccionando la rama `ClusteredCone`.

![Comparación en PowerPoint que muestra la primera serie como cilindros, conos y columnas rectangulares de izquierda a derecha](series-shapes.png)

## **Preguntas frecuentes**

**¿Qué tipos de gráfico admiten el modo 3D en Aspose.Slides?**

Aspose.Slides admite variantes 3D de gráficos de columnas, incluidas Column 3D, Clustered Column 3D, Stacked Column 3D y 100 % Stacked Column 3D, junto con tipos 3D relacionados expuestos mediante la enumeración [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Para obtener una lista exacta y actualizada, consulte los miembros de [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) en la referencia de API de la versión que tenga instalada.

**¿Puedo obtener una imagen rasterizada de un gráfico 3D para un informe o la web?**

Sí. Puede exportar un gráfico a una imagen con [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) o [renderizar toda la diapositiva](/slides/es/net/convert-powerpoint-to-png/) a formatos como PNG o JPEG. Esto es útil cuando necesita una vista previa rasterizada o quiere incrustar el gráfico en documentos, paneles de control o páginas web sin requerir PowerPoint.

**¿Qué rendimiento tiene la creación y renderizado de gráficos 3D grandes?**

El rendimiento depende del volumen de datos y la complejidad visual. Para obtener los mejores resultados, mantenga los efectos 3D al mínimo, evite texturas pesadas en paredes y áreas de trazado, limite la cantidad de puntos de datos por serie cuando sea posible y renderice a un tamaño de salida adecuado (resolución y dimensiones) que coincida con la pantalla o las necesidades de impresión.