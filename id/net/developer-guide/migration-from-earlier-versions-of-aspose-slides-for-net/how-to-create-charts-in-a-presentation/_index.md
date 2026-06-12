---
title: Cara Membuat Diagram dalam Presentasi di .NET
linktitle: Buat Diagram
type: docs
weight: 30
url: /id/net/how-to-create-charts-in-a-presentation/
keywords:
- migrasi
- buat diagram
- kode warisan
- kode modern
- pendekatan warisan
- pendekatan modern
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara membuat diagram dalam presentasi PowerPoint PPT, PPTX, dan ODP di .NET dengan Aspose.Slides menggunakan API diagram warisan dan modern."
---
{{% alert color="primary" %}} 

Sebuah [Aspose.Slides for .NET API](/slides/id/net/) baru telah dirilis dan kini produk tunggal ini mendukung kemampuan untuk membuat dokumen PowerPoint dari awal serta mengedit yang sudah ada.

{{% /alert %}} 
## **Dukungan untuk Kode Warisan**
Untuk menggunakan kode warisan yang dikembangkan dengan versi Aspose.Slides for .NET sebelum 13.x, Anda perlu melakukan beberapa perubahan kecil pada kode Anda sehingga kode tersebut akan berfungsi seperti sebelumnya. Semua kelas yang ada di Aspose.Slides for .NET lama di dalam namespace Aspose.Slide dan Aspose.Slides.Pptx kini digabungkan menjadi satu namespace Aspose.Slides. Silakan lihat contoh kode sederhana berikut untuk membuat grafik biasa dari awal dalam presentasi menggunakan API Aspose.Slides warisan dan ikuti langkah-langkah yang menjelaskan cara migrasi ke API yang baru digabungkan.
## **Legacy Aspose.Slides for .NET Approach**
```c#
//Instansiasi PresentationEx class yang mewakili file PPTX
using (PresentationEx pres = new PresentationEx())
{
	//Akses slide pertama
	SlideEx sld = pres.Slides[0];

	// Tambahkan diagram dengan data default
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//Mengatur chart Title
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//Set first series to Show Values
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//Mengatur indeks lembar data chart 
	int defaultWorksheetIndex = 0;

	//Mendapatkan chart data worksheet
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//Hapus default generated series and categories
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//Menambahkan seri baru
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//Menambahkan kategori baru
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//Ambil chart series pertama
	ChartSeriesEx series = chart.ChartData.Series[0];

	//Sekarang mengisi data series
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//Mengatur warna isi untuk series
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//Ambil chart series kedua
	series = chart.ChartData.Series[1];

	//Sekarang mengisi data series
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//Mengatur warna isi untuk series
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//Buat custom labels untuk setiap kategori pada series baru

	//Label pertama akan menampilkan nama Category
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//Tampilkan nama series untuk label kedua
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//Tampilkan nilai untuk label ketiga
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//Tampilkan nilai dan teks khusus
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//Simpan presentation dengan chart
	pres.Write(@"D:\AsposeChart.pptx");
}
```



## **New Aspose.Slides for .NET 13.x Approach**
``` csharp
//Instansiasi kelas Presentation yang mewakili file PPTX//Instansiasi kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();

//Akses slide pertama
ISlide sld = pres.Slides[0];

// Tambahkan diagram dengan data default
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Mengatur judul diagram
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Set seri pertama untuk Menampilkan Nilai
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Mengatur indeks lembar data diagram
int defaultWorksheetIndex = 0;

//Mendapatkan lembar kerja data diagram
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Hapus seri dan kategori yang dihasilkan secara default
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Menambahkan seri baru
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Menambahkan kategori baru
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Ambil seri diagram pertama
IChartSeries series = chart.ChartData.Series[0];

//Sekarang mengisi data seri

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Mengatur warna isi untuk seri
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Ambil seri diagram kedua
series = chart.ChartData.Series[1];

//Sekarang mengisi data seri
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Mengatur warna isi untuk seri
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//Buat label khusus untuk setiap kategori pada seri baru

//label pertama akan menampilkan nama Kategori
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Tampilkan nilai untuk label ketiga
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Simpan presentasi dengan diagram
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Silakan lihat contoh kode sederhana berikut untuk membuat grafik scatter dari awal dalam presentasi menggunakan API Aspose.Slides warisan dan cara mencapainya dengan API yang baru digabungkan.

## **Legacy Aspose.Slides for .NET Approach**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Membuat diagram default
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Mendapatkan indeks lembar kerja data diagram default
    int defaultWorksheetIndex = 0;

    //Mengakses lembar kerja data diagram
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Hapus seri demo
    chart.ChartData.Series.Clear();

    //Tambahkan seri baru
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //Ambil seri diagram pertama
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Tambahkan titik baru (1:3) di sana.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Tambahkan titik baru (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Edit tipe seri
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Mengubah marker seri diagram
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Ambil seri diagram kedua
    series = chart.ChartData.Series[1];

    //Tambahkan titik baru (5:2) di sana.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //Tambahkan titik baru (3:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //Tambahkan titik baru (2:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //Tambahkan titik baru (5:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //Mengubah marker seri diagram
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **New Aspose.Slides for .NET 13.x Approach**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Membuat diagram default
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Mendapatkan indeks lembar kerja data diagram default
int defaultWorksheetIndex = 0;

//Mengakses lembar kerja data diagram
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Hapus seri demo
chart.ChartData.Series.Clear();

//Tambahkan seri baru
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//Ambil seri diagram pertama
IChartSeries series = chart.ChartData.Series[0];

//Tambahkan titik baru (1:3) di sana.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Tambahkan titik baru (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Edit tipe seri
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Mengubah marker seri diagram
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//Ambil seri diagram kedua
series = chart.ChartData.Series[1];

//Tambahkan titik baru (5:2) di sana.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Tambahkan titik baru (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Tambahkan titik baru (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Tambahkan titik baru (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Mengubah marker seri diagram
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```