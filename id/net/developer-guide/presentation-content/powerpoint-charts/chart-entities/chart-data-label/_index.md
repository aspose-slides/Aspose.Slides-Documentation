---
title: Kelola Label Data Grafik dalam Presentasi di .NET
linktitle: Label Data
type: docs
url: /id/net/chart-data-label/
keywords:
- grafik
- label data
- presisi data
- persentase
- jarak label
- lokasi label
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara menambahkan dan memformat label data grafik dalam presentasi PowerPoint menggunakan Aspose.Slides untuk .NET agar slide lebih menarik."
---
## **Introduction**

Label data pada grafik menampilkan detail tentang seri data grafik atau titik data individual. Mereka memungkinkan pembaca dengan cepat mengidentifikasi seri data dan juga membuat grafik lebih mudah dipahami.

## **Set Data Precision in Chart Data Labels**

Kode C# ini menunjukkan cara menetapkan presisi data pada label data grafik:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```

## **Display Percentage as Labels**
Aspose.Slides for .NET memungkinkan Anda menetapkan label persentase pada grafik yang ditampilkan. Kode C# ini mendemonstrasikan operasinya:

```c#
// Membuat instance dari kelas Presentation
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

// Menyimpan presentasi yang berisi grafik
presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **Set Percentage Sign with Chart Data Labels**
Kode C# ini menunjukkan cara menetapkan tanda persentase untuk label data grafik:

```c#
// Membuat instance dari kelas Presentation
Presentation presentation = new Presentation();

// Mendapatkan referensi slide melalui indeksnya
ISlide slide = presentation.Slides[0];

// Membuat grafik PercentsStackedColumn pada slide
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// Mengatur NumberFormatLinkedToSource menjadi false
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// Mendapatkan worksheet data grafik
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// Menambahkan seri baru
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// Mengatur warna isi seri
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// Mengatur properti LabelFormat
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// Menambahkan seri baru
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// Mengatur tipe dan warna isi
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// Menulis presentasi ke disk
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **Set Label Distance from an Axis**
Kode C# ini menunjukkan cara menetapkan jarak label dari sumbu kategori ketika Anda bekerja dengan grafik yang dipetakan dari sumbu:

```c#
// Membuat instance dari kelas Presentation
Presentation presentation = new Presentation();

// Mendapatkan referensi slide
ISlide sld = presentation.Slides[0];

// Membuat grafik pada slide
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// Mengatur jarak label dari sumbu
ch.Axes.HorizontalAxis.LabelOffset = 500;

// Menulis presentasi ke disk
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **Adjust Label Location**

Saat Anda membuat grafik yang tidak bergantung pada sumbu apa pun seperti diagram lingkaran, label data grafik dapat berakhir terlalu dekat dengan tepinya. Dalam kasus seperti itu, Anda harus menyesuaikan lokasi label data agar garis penghubung ditampilkan dengan jelas.

Kode C# ini menunjukkan cara menyesuaikan lokasi label pada diagram lingkaran: 

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

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **FAQ**

**How can I prevent data labels from overlapping on dense charts?**

Gabungkan penempatan label otomatis, garis penghubung, dan ukuran font yang lebih kecil; jika diperlukan, sembunyikan beberapa bidang (misalnya kategori) atau tampilkan label hanya untuk titik ekstrem/kunci.

**How can I disable labels only for zero, negative, or empty values?**

Saring titik data sebelum mengaktifkan label dan matikan tampilan untuk nilai 0, nilai negatif, atau nilai yang hilang sesuai dengan aturan yang ditetapkan.

**How can I ensure a consistent label style when exporting to PDF/images?**

Tetapkan font (keluarga, ukuran) secara eksplisit dan pastikan font tersedia di sisi rendering untuk menghindari fallback.