---
title: Administrar series de datos de gráficos en presentaciones en .NET
linktitle: Series de datos
type: docs
url: /es/net/chart-series/
keywords:
- series de gráficos
- superposición de series
- color de series
- color de categoría
- nombre de serie
- punto de datos
- espacio entre series
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a administrar series de gráficos en C# para PowerPoint (PPT/PPTX) con ejemplos de código prácticos y buenas prácticas para mejorar sus presentaciones de datos."
---

## **Descripción general**

Este artículo describe el papel de [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) en Aspose.Slides for .NET, centrándose en cómo se estructuran y visualizan los datos dentro de las presentaciones. Estos objetos proporcionan los elementos fundamentales que definen conjuntos individuales de puntos de datos, categorías y parámetros de apariencia en un gráfico. Al trabajar con [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/), los desarrolladores pueden integrar sin problemas fuentes de datos subyacentes y mantener un control total sobre cómo se muestra la información, lo que resulta en presentaciones dinámicas y basadas en datos que transmiten claramente ideas y análisis.

Una serie es una fila o columna de números representados en un gráfico.

![serie-de-gráfica-powerpoint](chart-series-powerpoint.png)

## **Establecer la superposición de series del gráfico**

La propiedad [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) controla cómo se superponen las barras y columnas en un gráfico 2D especificando un rango de -100 a 100. Dado que esta propiedad está asociada al grupo de series y no a una serie individual, es de solo lectura a nivel de serie. Para configurar los valores de superposición, utilice la propiedad de lectura/escritura `ParentSeriesGroup.Overlap`, que aplica la superposición especificada a todas las series del grupo.

A continuación se muestra un ejemplo en C# que demuestra cómo crear una presentación, añadir un gráfico de columnas agrupadas, acceder a la primera serie del gráfico, configurar la superposición y guardar el resultado como archivo PPTX:
```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Agregar un gráfico de columnas agrupadas con datos predeterminados.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // Establecer la superposición de la serie.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // Guardar el archivo de presentación en disco.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```


El resultado:

![Superposición de series](series_overlap.png)

## **Cambiar el color de relleno de la serie**

Aspose.Slides facilita la personalización de los colores de relleno de las series del gráfico, lo que le permite resaltar puntos de datos específicos y crear gráficos visualmente atractivos. Esto se logra a través del objeto [IFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/), que admite varios tipos de relleno, configuraciones de color y otras opciones avanzadas de estilo. Después de añadir un gráfico a una diapositiva y acceder a la serie deseada, simplemente obtenga la serie y aplique el color de relleno apropiado. Más allá de los rellenos sólidos, también puede aprovechar los rellenos degradados o de patrón para una mayor flexibilidad de diseño. Una vez que haya establecido los colores según sus requisitos, guarde la presentación para finalizar el aspecto actualizado.

El siguiente ejemplo en C# muestra cómo cambiar el color de la primera serie:
```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Añadir un gráfico de columnas agrupadas con datos predeterminados.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Establecer el color de la primera serie.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // Guardar el archivo de presentación en disco.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```


El resultado:

![Color de la serie](series_color.png)

## **Cambiar el nombre de la serie**

Aspose.Slides ofrece una manera sencilla de modificar los nombres de las series del gráfico, facilitando el etiquetado de datos de forma clara y significativa. Al acceder a la celda de hoja de cálculo correspondiente en los datos del gráfico, los desarrolladores pueden personalizar la forma en que se presentan los datos. Esta modificación es particularmente útil cuando los nombres de las series deben actualizarse o aclararse según el contexto de los datos. Después de cambiar el nombre de la serie, la presentación puede guardarse para preservar los cambios.

A continuación se muestra un fragmento de código C# que demuestra este proceso en acción.
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Añadir un gráfico de columnas agrupadas con datos predeterminados.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Establecer el nombre de la primera serie.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // Guardar el archivo de presentación en disco.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


El siguiente fragmento de código C# muestra una forma alternativa de cambiar el nombre de la serie:
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Añadir un gráfico de columnas agrupadas con datos predeterminados.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Establecer el nombre de la primera serie.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // Guardar el archivo de presentación en disco.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


El resultado:

![Nombre de la serie](series_name.png)

## **Obtener el color de relleno automático de la serie**

Aspose.Slides for .NET le permite obtener el color de relleno automático para series del gráfico dentro del área de trazado. Después de crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), puede obtener una referencia a la diapositiva deseada por índice y, a continuación, añadir un gráfico usando el tipo que prefiera (como `ChartType.ClusteredColumn`). Al acceder a las series del gráfico, puede obtener el color de relleno automático.

El código C# a continuación demuestra este proceso en detalle.
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Añadir un gráfico de columnas agrupadas con datos predeterminados.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // Obtener el color de relleno de la serie.
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```


Salida:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```


## **Establecer color de relleno invertido para una serie del gráfico**

Cuando su serie de datos contiene valores positivos y negativos, colorear todas las columnas o barras de la misma forma puede dificultar la lectura del gráfico. Aspose.Slides for .NET le permite asignar un color de relleno invertido, un relleno separado que se aplica automáticamente a los puntos de datos que están por debajo de cero, de modo que los valores negativos se destaquen de un vistazo. En esta sección aprenderá a habilitar esa opción, elegir un color adecuado y guardar la presentación actualizada.

El siguiente ejemplo de código demuestra la operación:
```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Agregar nuevas categorías.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // Agregar una nueva serie.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Poblar los datos de la serie.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // Establecer la configuración de color para la serie.
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```


El resultado:

![Color de relleno sólido invertido](inverted_solid_fill_color.png)

Puede invertir el color de relleno para un solo punto de datos en lugar de toda la serie. Simplemente acceda al `IChartDataPoint` deseado y establezca su propiedad `InvertIfNegative` en true.

El siguiente ejemplo de código muestra cómo hacerlo:
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // Invertir el color si el punto de datos en el índice 2 es negativo.
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```


## **Borrar valores específicos de puntos de datos**

A veces un gráfico contiene valores de prueba, valores atípicos o entradas obsoletas que necesita eliminar sin volver a crear toda la serie. Aspose.Slides for .NET le permite apuntar a cualquier punto de datos por índice, borrar su contenido y refrescar instantáneamente el trazado para que los puntos restantes se desplacen y los ejes se reescalen automáticamente.

El siguiente ejemplo de código demuestra la operación:
```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```


## **Establecer el ancho del espacio entre series**

El ancho del espacio controla la cantidad de espacio vacío entre columnas o barras adyacentes: los espacios más amplios enfatizan categorías individuales, mientras que los espacios más estrechos crean un aspecto más denso y compacto. A través de Aspose.Slides for .NET puede ajustar finamente este parámetro para una serie completa, logrando el equilibrio visual exacto que su presentación requiere sin alterar los datos subyacentes.

El siguiente ejemplo de código muestra cómo establecer el ancho del espacio para una serie:
```cs
ushort gapWidth = 30;

// Crear una presentación vacía.
using (Presentation presentation = new Presentation())
{
    // Acceder a la primera diapositiva.
    ISlide slide = presentation.Slides[0];

    // Agregar un gráfico con datos predeterminados.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // Guardar la presentación en disco.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // Establecer el valor de GapWidth.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // Guardar la presentación en disco.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```


El resultado:

![Ancho del espacio](gap_width.png)

## **Preguntas frecuentes**

**¿Existe un límite en la cantidad de series que puede contener un gráfico único?**

Aspose.Slides no impone una capa fija al número de series que añada. El techo práctico está determinado por la legibilidad del gráfico y por la memoria disponible para su aplicación.

**¿Qué pasa si las columnas dentro de un clúster están demasiado juntas o demasiado separadas?**

Ajuste la configuración `GapWidth` para esa serie (o su grupo de series padre). Incrementar el valor amplía el espacio entre columnas, mientras que disminuirlo las acerca más.