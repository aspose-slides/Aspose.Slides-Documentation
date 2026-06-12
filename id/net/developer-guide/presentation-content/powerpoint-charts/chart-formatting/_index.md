---
title: Format Diagram Presentasi di .NET
linktitle: Pemformatan Diagram
type: docs
weight: 60
url: /id/net/chart-formatting/
keywords:
- format diagram
- pemformatan diagram
- entitas diagram
- properti diagram
- pengaturan diagram
- opsi diagram
- properti font
- garis tepi bulat
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari pemformatan diagram di Aspose.Slides untuk .NET dan tingkatkan presentasi PowerPoint Anda dengan gaya profesional yang menarik."
---
## **Ikhtisar**

Artikel ini menjelaskan cara memformat diagram dalam presentasi PowerPoint menggunakan Aspose.Slides. Menunjukkan cara menyesuaikan elemen diagram utama seperti sumbu, garis kisi, judul, legenda, area plot, dan isian dinding untuk meningkatkan tampilan dan keterbacaan data diagram.

Artikel ini juga mendemonstrasikan cara mengatur properti font untuk teks diagram, menerapkan format numerik preset dan kustom pada data diagram, serta mengaktifkan sudut bulat untuk area diagram. Bersama-sama, contoh-contoh ini menunjukkan cara mengontrol gaya visual dan presentasi data diagram dalam sebuah presentasi.

## **Format Entitas Diagram**
Aspose.Slides untuk .NET memungkinkan pengembang menambahkan diagram kustom ke slide mereka dari awal. Artikel ini menjelaskan cara memformat berbagai entitas diagram termasuk sumbu kategori dan nilai diagram.

Aspose.Slides untuk .NET menyediakan API sederhana untuk mengelola berbagai entitas diagram dan memformatnya menggunakan nilai kustom:

1. Buat instance dari kelas **Presentation** .
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Tambahkan diagram dengan data default bersama jenis yang diinginkan (pada contoh ini kita akan menggunakan ChartType.LineWithMarkers).
1. Akses sumbu Nilai diagram dan atur properti berikut:
   1. Mengatur **Line format** untuk garis Kisi Utama pada Sumbu Nilai
   1. Mengatur **Line format** untuk garis Kisi Minor pada Sumbu Nilai
   1. Mengatur **Number Format** untuk Sumbu Nilai
   1. Mengatur **Min, Max, Major and Minor units** untuk Sumbu Nilai
   1. Mengatur **Text Properties** untuk data Sumbu Nilai
   1. Mengatur **Title** untuk Sumbu Nilai
   1. Mengatur **Line Format** untuk Sumbu Nilai
1. Akses sumbu Kategori diagram dan atur properti berikut:
   1. Mengatur **Line format** untuk garis Kisi Utama pada Sumbu Kategori
   1. Mengatur **Line format** untuk garis Kisi Minor pada Sumbu Kategori
   1. Mengatur **Text Properties** untuk data Sumbu Kategori
   1. Mengatur **Title** untuk Sumbu Kategori
   1. Mengatur **Label Positioning** untuk Sumbu Kategori
   1. Mengatur **Rotation Angle** untuk label Sumbu Kategori
1. Akses Legenda diagram dan atur **Text Properties** untuknya
1. Atur tampilan Legenda diagram tanpa menumpuk diagram
1. Akses **Secondary Value Axis** diagram dan atur properti berikut:
   1. Aktifkan **Value Axis** Sekunder
   1. Mengatur **Line Format** untuk **Value Axis** Sekunder
   1. Mengatur **Number Format** untuk **Value Axis** Sekunder
   1. Mengatur **Min, Max, Major and Minor units** untuk **Value Axis** Sekunder
1. Sekarang plot seri diagram pertama pada **Secondary Value Axis**
1. Atur warna isian dinding belakang diagram
1. Atur warna isian area plot diagram
1. Tuliskan presentasi yang dimodifikasi ke file PPTX

```c#
// Membuat presentasi// Membuat presentasi
Presentation pres = new Presentation();

// Accessing the first slide
ISlide slide = pres.Slides[0];

// Adding the sample chart
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Mengatur Judul Diagram
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Mengatur format garis kisi utama untuk sumbu nilai
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Mengatur format garis kisi minor untuk sumbu nilai
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Mengatur format angka sumbu nilai
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Mengatur nilai maksimum, minimum diagram
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Mengatur Properti Teks Sumbu Nilai
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Mengatur judul sumbu nilai
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Mengatur format garis sumbu nilai : Sekarang Usang
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Mengatur format garis kisi utama untuk sumbu Kategori
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Mengatur format garis kisi minor untuk sumbu Kategori
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Mengatur Properti Teks Sumbu Kategori
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Mengatur Judul Kategori
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Mengatur posisi label sumbu kategori
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Mengatur sudut rotasi label sumbu kategori
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Mengatur Properti Teks Legenda
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Mengatur tampilan legenda diagram tanpa menumpuk diagram

chart.Legend.Overlay = true;
            
// Mem-plot seri pertama pada sumbu nilai sekunder
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Mengatur warna dinding belakang diagram
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Mengatur warna area plot
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Menyimpan Presentasi
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **Atur Properti Font untuk Diagram**
Aspose.Slides untuk .NET menyediakan dukungan untuk mengatur properti terkait font untuk diagram. Ikuti langkah-langkah berikut untuk mengatur properti font diagram.

- Instansiasi objek kelas Presentation.
- Tambahkan diagram pada slide.
- Atur tinggi font.
- Simpan presentasi yang dimodifikasi.

Contoh sampel di bawah diberikan.

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```

## **Atur Format Numerik**
Aspose.Slides untuk .NET menyediakan API sederhana untuk mengelola format data diagram:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Tambahkan diagram dengan data default bersama jenis yang diinginkan (contoh ini menggunakan **ChartType.ClusteredColumn**).
1. Atur format angka preset dari nilai preset yang tersedia.
1. Iterasi sel data diagram pada setiap seri diagram dan atur format angka data diagram.
1. Simpan presentasi.
1. Atur format angka kustom.
1. Iterasi sel data diagram dalam setiap seri diagram dan atur format angka data diagram yang berbeda.
1. Simpan presentasi.

```c#
// Instansiasi presentasi// Instansiasi presentasi
Presentation pres = new Presentation();

// Akses slide presentasi pertama
ISlide slide = pres.Slides[0];

// Menambahkan diagram kolom terkelompok default
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Mengakses koleksi seri diagram
IChartSeriesCollection series = chart.ChartData.Series;

// Mengatur format nomor preset
// Menelusuri setiap seri diagram
foreach (ChartSeries ser in series)
{
    // Menelusuri setiap sel data dalam seri
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Mengatur format nomor
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Menyimpan presentasi
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

Nilai format angka preset yang mungkin beserta indeks presetnya dan yang dapat digunakan diberikan di bawah ini:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Atur Sudut Bulat Area Diagram**
Aspose.Slides untuk .NET menyediakan dukungan untuk mengatur area diagram. Properti **IChart.HasRoundedCorners** dan **Chart.HasRoundedCorners** telah ditambahkan di Aspose.Slides.

1. Instansiasi objek kelas `Presentation`.
1. Tambahkan diagram pada slide.
1. Atur jenis isian dan warna isian diagram
1. Atur properti sudut bulat menjadi True.
1. Simpan presentasi yang dimodifikasi.

Contoh sampel di bawah diberikan.

```c#
using (Presentation presentation = new Presentation())
{
	ISlide slide = presentation.Slides[0];
	IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
	chart.LineFormat.FillFormat.FillType = FillType.Solid;
	chart.LineFormat.Style = LineStyle.Single;
	chart.HasRoundedCorners = true;

	presentation.Save("out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**Apakah saya dapat mengatur isian semi-transparan untuk kolom/area sambil mempertahankan batas tidak tembus pandang?**

Ya. Transparansi isian dan garis tepi diatur secara terpisah. Hal ini berguna untuk meningkatkan keterbacaan kisi dan data pada visualisasi yang padat.

**Bagaimana cara menangani label data saat mereka tumpang tindih?**

Kurangi ukuran font, nonaktifkan komponen label yang tidak penting (misalnya, kategori), atur offset/posisi label, tampilkan label hanya untuk titik yang dipilih bila perlu, atau ubah format menjadi "value + legend".

**Apakah saya dapat menerapkan isian gradien atau pola pada seri?**

Ya. Baik isian padat maupun gradien/pola biasanya tersedia. Dalam praktik, gunakan gradien secara terbatas dan hindari kombinasi yang mengurangi kontras dengan kisi dan teks.