---
title: Etiqueta de datos del gráfico
type: docs
url: /es/net/chart-data-label/
keywords: "Etiqueta de datos del gráfico,distancia de etiqueta, C#, Csharp, Aspose.Slides for .NET"
description: "Establecer etiqueta de datos del gráfico de PowerPoint y distancia en C# o .NET"
---

Las etiquetas de datos en un gráfico muestran detalles sobre las series de datos del gráfico o puntos de datos individuales. Permiten a los lectores identificar rápidamente las series de datos y también hacen que los gráficos sean más fáciles de entender.

## **Establecer la precisión de los datos en las etiquetas de datos del gráfico**

Este código C# le muestra cómo establecer la precisión de los datos en una etiqueta de datos del gráfico:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```


## **Mostrar porcentaje como etiquetas**

Aspose.Slides for .NET le permite establecer etiquetas de porcentaje en los gráficos mostrados. Este código C# demuestra la operación:
```c#
// Crea una instancia de la clase Presentation
Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);
IChartSeries series = chart.ChartData.Series[0];
IChartCategory cat;
double[] total_for_Cat = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    cat = chart.ChartData.Categories[k];

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        total_for_Cat[k] = total_for_Cat[k] + Convert.ToDouble(chart.ChartData.Series[i].DataPoints[k].Value.Data);
    }
}

double dataPontPercent = 0f;

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        IDataLabel lbl = series.DataPoints[j].Label;
        dataPontPercent = (Convert.ToDouble(series.DataPoints[j].Value.Data) / total_for_Cat[j]) * 100;

        IPortion port = new Portion();
        port.Text = String.Format("{0:F2} %", dataPontPercent);
        port.PortionFormat.FontHeight = 8f;
        lbl.TextFrameForOverriding.Text = "";
        IParagraph para = lbl.TextFrameForOverriding.Paragraphs[0];
        para.Portions.Add(port);

        lbl.DataLabelFormat.ShowSeriesName = false;
        lbl.DataLabelFormat.ShowPercentage = false;
        lbl.DataLabelFormat.ShowLegendKey = false;
        lbl.DataLabelFormat.ShowCategoryName = false;
        lbl.DataLabelFormat.ShowBubbleSize = false;
    }
}

// Guarda la presentación que contiene el gráfico
presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```


## **Establecer el signo de porcentaje en las etiquetas de datos del gráfico**

Este código C# le muestra cómo establecer el signo de porcentaje para una etiqueta de datos del gráfico:
```c#
// Crea una instancia de la clase Presentation
Presentation presentation = new Presentation();

// Obtiene la referencia de una diapositiva a través de su índice
ISlide slide = presentation.Slides[0];

// Crea el gráfico PercentsStackedColumn en una diapositiva
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// Establece NumberFormatLinkedToSource a false
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// Obtiene la hoja de cálculo de datos del gráfico
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// Agrega una nueva serie
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// Establece el color de relleno de la serie
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// Establece las propiedades de LabelFormat
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// Agrega una nueva serie
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// Establece el tipo de relleno y el color
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// Escribe la presentación en disco
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```


## **Establecer la distancia de la etiqueta desde el eje**

Este código C# le muestra cómo establecer la distancia de la etiqueta desde un eje de categorías cuando se trabaja con un gráfico trazado a partir de ejes:
```c#
// Crea una instancia de la clase Presentation
Presentation presentation = new Presentation();

// Obtiene la referencia de una diapositiva
ISlide sld = presentation.Slides[0];

// Crea un gráfico en la diapositiva
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// Establece la distancia de la etiqueta desde un eje
ch.Axes.HorizontalAxis.LabelOffset = 500;

// Guarda la presentación en disco
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```


## **Ajustar la ubicación de la etiqueta**

Cuando crea un gráfico que no depende de ningún eje, como un gráfico de pastel, las etiquetas de datos del gráfico pueden quedar demasiado cerca de su borde. En tal caso, debe ajustar la ubicación de la etiqueta de datos para que las líneas de guía se muestren claramente.

Este código C# le muestra cómo ajustar la ubicación de la etiqueta en un gráfico de pastel: 
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.ChartData.Series;
    IDataLabel label = series[0].Labels[0];

    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
    label.X = 0.71f;
    label.Y = 0.04f;

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


![gráfico-de-pastel-etiqueta-ajustada](pie-chart-adjusted-label.png)

## **Preguntas frecuentes**

**¿Cómo puedo evitar que las etiquetas de datos se superpongan en gráficos densos?**

Combine la colocación automática de etiquetas, líneas de guía y un tamaño de fuente reducido; si es necesario, oculte algunos campos (por ejemplo, la categoría) o muestre etiquetas solo para los puntos extremos/clave.

**¿Cómo puedo desactivar las etiquetas solo para valores cero, negativos o vacíos?**

Filtre los puntos de datos antes de habilitar las etiquetas y desactive la visualización para valores de 0, valores negativos o valores ausentes según una regla definida.

**¿Cómo puedo asegurar un estilo de etiqueta consistente al exportar a PDF/imagenes?**

Establezca explícitamente las fuentes (familia, tamaño) y verifique que la fuente esté disponible en el lado de renderizado para evitar sustituciones.