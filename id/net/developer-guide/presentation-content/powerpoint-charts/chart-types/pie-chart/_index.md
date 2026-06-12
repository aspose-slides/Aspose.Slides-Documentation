---
title: Sesuaikan Diagram Lingkaran dalam Presentasi di .NET
linktitle: Diagram Lingkaran
type: docs
url: /id/net/pie-chart/
keywords:
- diagram lingkaran
- kelola diagram
- sesuaikan diagram
- opsi diagram
- pengaturan diagram
- opsi plot
- warna irisan
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara membuat dan menyesuaikan diagram lingkaran di .NET dengan Aspose.Slides, dapat diekspor ke PowerPoint, meningkatkan cara Anda menceritakan data dalam hitungan detik."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan diagram lingkaran di Aspose.Slides. Artikel ini menunjukkan cara mengonfigurasi opsi plot sekunder untuk diagram Pie of Pie dan Bar of Pie, serta cara mengaktifkan pewarnaan irisan otomatis untuk diagram lingkaran standar.

Contoh-contoh berfokus pada langkah-langkah penyesuaian diagram yang praktis seperti menambahkan diagram ke slide, menyesuaikan pengaturan seri dan label, mengganti data diagram default dengan kategori dan nilai khusus, serta menyimpan presentasi yang telah diperbarui.

## **Opsi Plot Sekunder untuk Diagram Pie of Pie dan Bar of Pie**

Aspose.Slides untuk .NET kini mendukung opsi plot sekunder untuk diagram Pie of Pie atau Bar of Pie. Dalam topik ini, kita akan melihat contoh cara menentukan opsi ini menggunakan Aspose.Slides. Ikuti langkah-langkah berikut:

1. Membuat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Tambahkan diagram pada slide.
1. Tentukan opsi plot sekunder untuk diagram.
1. Simpan presentasi ke disk.

Dalam contoh di bawah ini, kami telah mengatur berbagai properti diagram Pie of Pie.

```c#
// Buat instance kelas Presentation
Presentation presentation = new Presentation();

// Tambahkan diagram pada slide
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// Atur properti yang berbeda
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// Simpan presentasi ke disk
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```


## **Atur Warna Irisan Diagram Lingkaran Otomatis**

Aspose.Slides untuk .NET menyediakan API sederhana untuk mengatur warna irisan diagram lingkaran secara otomatis. Kode contoh menerapkan pengaturan properti yang disebutkan di atas.

1. Buat instance kelas Presentation.
2. Akses slide pertama.
3. Tambahkan diagram dengan data default.
4. Atur Judul diagram.
5. Atur seri pertama untuk Menampilkan Nilai.
6. Atur indeks lembar data diagram.
7. Dapatkan lembar kerja data diagram.
8. Hapus seri dan kategori yang dihasilkan secara default.
9. Tambahkan kategori baru.
10. Tambahkan seri baru.

Simpan presentasi yang dimodifikasi ke file PPTX.

```c#
// Instansiasi kelas Presentation yang mewakili file PPTX
using (Presentation presentation = new Presentation())
{
	// Instansiasi kelas Presentation yang mewakili file PPTX
	Presentation presentation = new Presentation();

	// Akses slide pertama
	ISlide slides = presentation.Slides[0];

	// Tambahkan diagram dengan data default
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// Mengatur Judul diagram
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// Atur seri pertama untuk Menampilkan Nilai
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Mengatur indeks lembar data diagram
	int defaultWorksheetIndex = 0;

	// Mendapatkan lembar kerja data diagram
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Hapus seri dan kategori yang dihasilkan secara default
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Menambahkan kategori baru
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// Menambahkan seri baru
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// Sekarang mengisi data seri
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**Apakah variasi 'Pie of Pie' dan 'Bar of Pie' didukung?**

Ya, pustaka [mendukung](https://reference.aspose.com/slides/id/net/aspose.slides.charts/charttype/) plot sekunder untuk diagram lingkaran, termasuk tipe 'Pie of Pie' dan 'Bar of Pie'.

**Apakah saya dapat mengekspor hanya diagram sebagai gambar (misalnya, PNG)?**

Ya, Anda dapat [mengekspor diagram itu sendiri sebagai gambar](https://reference.aspose.com/slides/id/net/aspose.slides/shape/getimage/) (seperti PNG) tanpa seluruh presentasi.