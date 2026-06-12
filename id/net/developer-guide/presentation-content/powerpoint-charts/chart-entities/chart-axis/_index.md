---
title: Sesuaikan Sumbu Diagram dalam Presentasi di .NET
linktitle: Sumbu Diagram
type: docs
url: /id/net/chart-axis/
keywords:
- sumbu diagram
- sumbu vertikal
- sumbu horizontal
- sesuaikan sumbu
- manipulasi sumbu
- kelola sumbu
- properti sumbu
- nilai maksimum
- nilai minimum
- garis sumbu
- format tanggal
- judul sumbu
- posisi sumbu
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Temukan cara menggunakan Aspose.Slides untuk .NET dalam menyesuaikan sumbu diagram pada presentasi PowerPoint untuk laporan dan visualisasi."
---
## **Ikhtisar**

Artikel ini menjelaskan cara menyesuaikan sumbu diagram di Aspose.Slides. Artikel ini menunjukkan cara memperoleh nilai sumbu yang sebenarnya, menukar data antara sumbu, menyembunyikan sumbu vertikal atau horizontal untuk diagram garis, mengubah tipe sumbu kategori, mengatur format tanggal untuk nilai sumbu kategori, memutar judul sumbu, mengatur posisi sumbu, dan menampilkan label unit pada sumbu nilai.

## **Mendapatkan Nilai Maksimum pada Sumbu Vertikal pada Diagram**
Aspose.Slides untuk .NET memungkinkan Anda memperoleh nilai minimum dan maksimum pada sumbu vertikal. Ikuti langkah-langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Akses slide pertama.
3. Tambahkan diagram dengan data default.
4. Dapatkan nilai maksimum aktual pada sumbu.
5. Dapatkan nilai minimum aktual pada sumbu.
6. Dapatkan satuan utama aktual dari sumbu.
7. Dapatkan satuan minor aktual dari sumbu.
8. Dapatkan skala satuan utama aktual dari sumbu.
9. Dapatkan skala satuan minor aktual dari sumbu.

Kode contoh ini—implementasi dari langkah-langkah di atas—menunjukkan cara memperoleh nilai yang diperlukan dalam C#:

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// Simpan presentasi
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **Menukar Data antara Sumbu**
Aspose.Slides memungkinkan Anda dengan cepat menukar data antara sumbu—data yang ditampilkan pada sumbu vertikal (y-axis) pindah ke sumbu horizontal (x-axis) dan sebaliknya.

Kode C# ini menunjukkan cara melakukan tugas penukaran data antara sumbu pada diagram:

```c#
// Membuat presentasi kosong
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// Menukar baris dan kolom
	chart.ChartData.SwitchRowColumn();
		   
	// Simpan presentasi
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```

## **Nonaktifkan Sumbu Vertikal untuk Diagram Garis**
Kode C# ini menunjukkan cara menyembunyikan sumbu vertikal untuk diagram garis:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Nonaktifkan Sumbu Horizontal untuk Diagram Garis**
Kode ini menunjukkan cara menyembunyikan sumbu horizontal untuk diagram garis:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Mengubah Sumbu Kategori**
Dengan menggunakan properti **CategoryAxisType**, Anda dapat menentukan tipe sumbu kategori yang diinginkan (**date** atau **text**). Kode ini dalam C# mendemonstrasikan operasi tersebut: 

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
    presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
}
```

## **Mengatur Format Tanggal untuk Nilai Sumbu Kategori**
Aspose.Slides untuk .NET memungkinkan Anda mengatur format tanggal untuk nilai sumbu kategori. Operasi ini ditunjukkan dalam kode C# berikut:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50, 50, 450, 300);

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Add(wb.GetCell(0, "A2", new DateTime(2015, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A3", new DateTime(2016, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A4", new DateTime(2017, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A5", new DateTime(2018, 1, 1).ToOADate()));

	IChartSeries series = chart.ChartData.Series.Add(ChartType.Line);
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 1));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 2));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 3));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 4));
	chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
	chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
	chart.Axes.HorizontalAxis.NumberFormat = "yyyy";
	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Mengatur Sudut Rotasi untuk Judul Sumbu Diagram**
Aspose.Slides untuk .NET memungkinkan Anda mengatur sudut rotasi untuk judul sumbu diagram. Kode C# ini mendemonstrasikan operasi tersebut:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Mengatur Posisi Sumbu pada Sumbu Kategori atau Nilai**
Aspose.Slides untuk .NET memungkinkan Anda mengatur posisi sumbu pada sumbu kategori atau nilai. Kode C# ini menunjukkan cara melakukan tugas tersebut:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **Mengaktifkan Tampilan Label Unit pada Sumbu Nilai Diagram**
Aspose.Slides untuk .NET memungkinkan Anda mengkonfigurasi diagram untuk menampilkan label unit pada sumbu nilai diagramnya. Kode C# ini mendemonstrasikan operasi tersebut:

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Bagaimana cara saya mengatur nilai di mana satu sumbu memotong sumbu lainnya (penyilangan sumbu)?**

Sumbu menyediakan [pengaturan penyilangan](https://reference.aspose.com/slides/id/net/aspose.slides.charts/axis/crosstype/): Anda dapat memilih untuk menyilang di nol, pada kategori/nilai maksimum, atau pada nilai numerik tertentu. Ini berguna untuk menggeser sumbu X ke atas atau ke bawah atau untuk menekankan garis dasar.

**Bagaimana saya dapat memposisikan label tick relatif terhadap sumbu (sebelah, di luar, di dalam)?**

Atur [posisi label](https://reference.aspose.com/slides/id/net/aspose.slides.charts/axis/majortickmark/) menjadi "cross", "outside", atau "inside". Hal ini memengaruhi keterbacaan dan membantu menghemat ruang, terutama pada diagram kecil.