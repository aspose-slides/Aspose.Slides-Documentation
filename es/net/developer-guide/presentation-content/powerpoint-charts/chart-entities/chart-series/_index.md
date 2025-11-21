---
title: Administrar series de datos de gráficos en presentaciones en .NET
linktitle: Series de datos
type: docs
url: /es/net/chart-series/
keywords:
- series de gráfico
- solapamiento de series
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
description: "Aprenda a gestionar series de gráficos en C# para PowerPoint (PPT/PPTX) con ejemplos de código prácticos y buenas prácticas para mejorar sus presentaciones de datos."
---

## **Resumen**

Este artículo describe el papel de [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) en Aspose.Slides para .NET, centrándose en cómo se estructuran y visualizan los datos dentro de las presentaciones. Estos objetos proporcionan los elementos fundamentales que definen conjuntos individuales de puntos de datos, categorías y parámetros de apariencia en un gráfico. Al trabajar con [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/), los desarrolladores pueden integrar sin problemas fuentes de datos subyacentes y mantener un control total sobre cómo se muestra la información, lo que resulta en presentaciones dinámicas impulsadas por datos que transmiten claramente ideas y análisis.

Una serie es una fila o columna de números trazados en un gráfico.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Establecer solapamiento de series de gráfico**

La propiedad [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) controla cómo se solapan las barras y columnas en un gráfico 2D especificando un rango de -100 a 100. Dado que esta propiedad está asociada al grupo de series más que a series de gráfico individuales, es de solo lectura a nivel de serie. Para configurar los valores de solapamiento, use la propiedad de lectura/escritura `ParentSeriesGroup.Overlap`, que aplica el solapamiento especificado a todas las series de ese grupo.

Abajo se muestra un ejemplo en C# que demuestra cómo crear una presentación, agregar un gráfico de columnas agrupadas, acceder a la primera serie del gráfico, configurar la opción de solapamiento y luego guardar el resultado como un archivo PPTX:
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
        // Establecer el solapamiento de la serie.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // Guardar el archivo de la presentación en disco.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```


El resultado:

![El solapamiento de la serie](series_overlap.png)

## **Cambiar color de relleno de la serie**

Aspose.Slides simplifica la personalización de los colores de relleno de las series de gráfico, permitiéndole resaltar puntos de datos específicos y crear gráficos visualmente atractivos. Esto se logra a través del objeto [IFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/), que admite varios tipos de relleno, configuraciones de color y otras opciones avanzadas de estilo. Después de agregar un gráfico a una diapositiva y acceder a la serie deseada, simplemente obtenga la serie y aplique el color de relleno apropiado. Además de los rellenos sólidos, también puede aprovechar los rellenos de degradado o patrón para una mayor flexibilidad de diseño. Una vez que haya establecido los colores según sus requisitos, guarde la presentación para finalizar el aspecto actualizado.

El siguiente ejemplo de código en C# muestra cómo cambiar el color de la primera serie:
```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Agregar un gráfico de columnas agrupadas con datos predeterminados.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Establecer el color de la primera serie.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // Guardar el archivo de la presentación en disco.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```


El resultado:

![El color de la serie](series_color.png)

## **Cambiar nombre de la serie**

Aspose.Slides ofrece una manera sencilla de modificar los nombres de las series de gráfico, facilitando el etiquetado de los datos de forma clara y significativa. Al acceder a la celda correspondiente de la hoja de cálculo en los datos del gráfico, los desarrolladores pueden personalizar cómo se presenta la información. Esta modificación es particularmente útil cuando los nombres de las series deben actualizarse o aclararse según el contexto de los datos. Después de renombrar la serie, la presentación puede guardarse para preservar los cambios.

Abajo se muestra un fragmento de código C# que demuestra este proceso en acción.
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Agregar un gráfico de columnas agrupadas con datos predeterminados.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Establecer el nombre de la primera serie.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // Guardar el archivo de la presentación en disco.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


El siguiente código C# muestra una forma alternativa de cambiar el nombre de la serie:
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Agregar un gráfico de columnas agrupadas con datos predeterminados.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Establecer el nombre de la primera serie.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // Guardar el archivo de la presentación en disco.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


El resultado:

![El nombre de la serie](series_name.png)

## **Obtener color de relleno automático de la serie**

Aspose.Slides for .NET permite obtener el color de relleno automático para series de gráfico dentro de un área de trazado. Después de crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), puede obtener una referencia a la diapositiva deseada por índice, luego agregar un gráfico usando el tipo que prefiera (como `ChartType.ClusteredColumn`). Al acceder a las series en el gráfico, puede obtener el color de relleno automático.

El código C# a continuación muestra este proceso con detalle.
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Agregar un gráfico de columnas agrupadas con datos predeterminados.
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


## **Establecer color de relleno invertido para series de gráfico**

Cuando su serie de datos contiene valores tanto positivos como negativos, asignar el mismo color a cada columna o barra puede dificultar la lectura del gráfico. Aspose.Slides para .NET le permite asignar un color de relleno invertido—un relleno separado que se aplica automáticamente a los puntos de datos que caen por debajo de cero—de modo que los valores negativos sobresalgan de un vistazo. En esta sección aprenderá cómo habilitar esa opción, elegir un color apropiado y guardar la presentación actualizada.

El siguiente ejemplo de código muestra la operación:
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

    // Rellenar los datos de la serie.
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

![El color de relleno sólido invertido](inverted_solid_fill_color.png)

Puede invertir el color de relleno para un solo punto de datos en lugar de toda la serie. Simplemente acceda al `IChartDataPoint` deseado y establezca su propiedad `InvertIfNegative` a true.

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

A veces un gráfico contiene valores de prueba, valores atípicos o entradas obsoletas que necesita eliminar sin reconstruir toda la serie. Aspose.Slides para .NET le permite dirigirse a cualquier punto de datos por índice, borrar su contenido y actualizar instantáneamente el trazado para que los puntos restantes se desplacen y los ejes se reescalen automáticamente.

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


## **Establecer ancho de espacio de la serie**

El ancho del espacio controla la cantidad de espacio vacío entre columnas o barras adyacentes—espacios más anchos enfatizan categorías individuales, mientras que espacios más estrechos crean una apariencia más densa y compacta. A través de Aspose.Slides para .NET puede ajustar finamente este parámetro para una serie completa, logrando el equilibrio visual exacto que su presentación requiere sin alterar los datos subyacentes.

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

![El ancho del espacio](gap_width.png)

## **Preguntas frecuentes**

**¿Existe un límite en la cantidad de series que puede contener un solo gráfico?**

Aspose.Slides no impone un límite fijo al número de series que añada. El techo práctico está determinado por la legibilidad del gráfico y por la memoria disponible para su aplicación.

**¿Qué pasa si las columnas dentro de un clúster están demasiado juntas o demasiado separadas?**

Ajuste la configuración `GapWidth` para esa serie (o su grupo de series padre). Incrementar el valor aumenta el espacio entre columnas, mientras que disminuirlo las acerca más.