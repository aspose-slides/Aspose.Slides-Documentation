---
title: Format Grafik Presentasi dalam .NET
linktitle: Pemformatan Grafik
type: docs
weight: 60
url: /id/net/chart-formatting/
keywords:
- format grafik
- pemformatan grafik
- entitas grafik
- properti grafik
- pengaturan grafik
- opsi grafik
- properti font
- bingkai melengkung
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari pemformatan grafik di Aspose.Slides untuk .NET dan tingkatkan presentasi PowerPoint Anda dengan sumbu khusus, font, format angka, serta border grafik yang melengkung."
---
## **Ringkasan**

Artikel ini menjelaskan cara memformat grafik dalam presentasi PowerPoint dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara menyesuaikan elemen utama grafik seperti sumbu, garis kisi, judul, legenda, area plot, dan isian dinding untuk meningkatkan tampilan dan keterbacaan data grafik. Artikel ini juga memperlihatkan cara mengatur properti font untuk teks grafik, menerapkan format numerik bawaan pada data grafik, dan mengaktifkan sudut melengkung untuk area grafik. Bersama-sama, contoh-contoh ini menunjukkan cara mengendalikan baik gaya visual maupun penyajian data grafik dalam sebuah presentasi. Untuk isian dan garis luar terpisah pada interval naik dan turun, lihat [contoh grafik saham](/slides/id/net/create-chart/#create-stock-charts).

## **Memformat Entitas Grafik**

Gunakan [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) untuk memformat judul grafik, sumbu, garis kisi, legenda, dan area plot. Contoh ini membuat grafik garis dengan penanda dan data default, kemudian menerapkan gaya teks dan garis terpisah pada sumbu nilai dan kategori. Ukuran font dan lebar garis ditentukan dalam poin; label kategori diputar 45 derajat. Sumbu nilai menggunakan [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) secara terpisah dari sel sumber. Skala sumbu berjalan dari -2 hingga 15, dengan interval utama 2 dan interval minor 0,5. Contoh ini juga menggabungkan pemformatan persentase dengan [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) yang disetel ke ribuan, sehingga sesuaikan pengaturan ini dengan makna dan besaran data Anda. Legenda tetap berada di luar area plot karena [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) dinonaktifkan. Isian back-wall dan floor dikonfigurasi melalui [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) dan [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/), tetapi permukaan ini hanya terlihat pada grafik 3D.
```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
var chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

var valueAxisText = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
valueAxisText.FontBold = NullableBool.True;
valueAxisText.FontHeight = 16;
valueAxisText.FontItalic = NullableBool.True;
valueAxisText.FillFormat.FillType = FillType.Solid;
valueAxisText.FillFormat.SolidFillColor.Color = Color.DarkGreen;
valueAxisText.LatinFont = new FontData("Times New Roman");

chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
var valueAxisTitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valueAxisTitle.Text = "Primary Axis";
valueAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valueAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valueAxisTitle.PortionFormat.FontHeight = 20;
valueAxisTitle.PortionFormat.FontBold = NullableBool.True;
valueAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

var categoryAxisText = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
categoryAxisText.FontBold = NullableBool.True;
categoryAxisText.FontHeight = 16;
categoryAxisText.FontItalic = NullableBool.True;
categoryAxisText.FillFormat.FillType = FillType.Solid;
categoryAxisText.FillFormat.SolidFillColor.Color = Color.Blue;
categoryAxisText.LatinFont = new FontData("Arial");

chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

var categoryAxisTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
categoryAxisTitle.Text = "Sample Category";
categoryAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
categoryAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
categoryAxisTitle.PortionFormat.FontHeight = 20;
categoryAxisTitle.PortionFormat.FontBold = NullableBool.True;
categoryAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

var legendText = chart.Legend.TextFormat.PortionFormat;
legendText.FontBold = NullableBool.True;
legendText.FontHeight = 16;
legendText.FontItalic = NullableBool.True;
legendText.FillFormat.FillType = FillType.Solid;
legendText.FillFormat.SolidFillColor.Color = Color.DarkRed;

chart.Legend.Overlay = false;

chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;

chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

presentation.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **Mengatur Properti Font untuk Grafik**

Atur ukuran font default untuk teks grafik melalui [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/). Contoh ini membuat grafik kolom berkelompok dengan font 20 poin dan mengaktifkan label nilai untuk seri pertama melalui [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Elemen teks dengan pengaturan font eksplisitnya sendiri dapat menggantikan nilai default grafik.
```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
chart.TextFormat.PortionFormat.FontHeight = 20;
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
```

## **Menggunakan Ulang Pemformatan Bingkai Teks untuk Legenda Grafik**

Untuk menyesuaikan legenda dengan judul slide, atur font pada [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) paragraf pertama. Panggil [CopyFrom](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyfrom/) pada [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformattedtextcontainer/textformat/) legenda. Metode ini membaca pengaturan bingkai teks, format paragraf pertama, dan properti font default paragraf tersebut. Pemformatan yang diterapkan langsung pada bagian individual atau pada paragraf berikutnya tetap lokal pada sumber. Contoh ini menggunakan judul Calibri tebal 26 poin dengan warna navy sebagai templat. Setelah menata legenda, contoh ini menggunakan [CopyTo](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyto/) untuk menerapkan pemformatan yang sama pada keterangan terpisah.
```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var heading = shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
var sourceTextFrame = heading.AddTextFrame("Quarterly sales");
var font = sourceTextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
font.LatinFont = new FontData("Calibri");
font.FontHeight = 26;
font.FontBold = NullableBool.True;
font.FillFormat.FillType = FillType.Solid;
font.FillFormat.SolidFillColor.Color = Color.FromArgb(32, 64, 96);

var chart = shapes.AddChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
chart.Style = StyleType.Style3;
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.GetCell(0, 0, 1).Value = "Retail";
workbook.GetCell(0, 0, 2).Value = "Online";
workbook.GetCell(0, 0, 3).Value = "Wholesale";
for (var quarter = 1; quarter <= 4; quarter++)
    workbook.GetCell(0, quarter, 0).Value = $"Q{quarter}";

chart.HasLegend = true;
chart.Legend.Position = LegendPositionType.Bottom;
chart.Legend.TextFormat.CopyFrom(sourceTextFrame);

var caption = shapes.AddAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
var captionTextFrame = caption.AddTextFrame("Sales in millions of dollars");
chart.Legend.TextFormat.CopyTo(captionTextFrame);

presentation.Save("legend-formatting.pptx", SaveFormat.Pptx);
```

Dalam presentasi yang disimpan, legenda dan keterangan cocok dengan judul dalam ukuran, ketebalan, dan warna. Legenda masih menampilkan nama seri, dan keterangan mempertahankan teksnya sendiri. Jika sebuah bagian dalam keterangan sudah memiliki ukuran font eksplisit, ukuran tersebut memiliki prioritas lebih tinggi dibandingkan default paragraf yang disalin.

| Sebelum menyalin | Setelah menyalin |
| --- | --- |
| ![Grafik penjualan kuartalan dengan label legenda hitam biasa dan keterangan hitam](legend-formatting-before.png) | ![Grafik yang sama dengan label legenda navy lebih besar dan tebal serta keterangan yang cocok](legend-formatting.png) |

## **Mengatur Format Numerik**

Gunakan [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) untuk menerapkan format angka bawaan pada sel buku kerja grafik. Contoh ini membuat grafik kolom berkelompok dengan data default berbasis sel dan menerapkan indeks format 10 (`0.00%`) pada setiap sel nilai seri. Ini mengubah cara nilai ditampilkan di buku kerja tanpa mengubah angka dasarnya; misalnya, 0,25 ditampilkan sebagai 25,00%. Format sumbu dan label data dapat dikonfigurasi secara terpisah.
```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
var series = chart.ChartData.Series;

foreach (var chartSeries in series)
{
    foreach (var dataPoint in chartSeries.DataPoints)
    {
        dataPoint.Value.AsCell.PresetNumberFormat = 10; //0,00%
    }
}

presentation.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

Tabel berikut mencantumkan indeks format angka bawaan dengan contoh format Excel untuk locale Bahasa Inggris (Amerika Serikat). String format yang tepat dan tampilan mereka dapat bervariasi tergantung aplikasi dan locale, terutama untuk mata uang dan tanggal. Beberapa format Excel juga berbeda dari default dalam standar OOXML, seperti yang dijelaskan dalam [catatan implementasi format angka Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Indeks | Format |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Mengatur Bingkai Membulat pada Area Grafik**

Aktifkan [IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) untuk membulatkan sudut area grafik. Contoh ini membuat grafik kolom berkelompok dan menggunakan [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) untuk memberi garis tepi warna abu-abu solid dan gaya satu garis sebelum menyimpan presentasi.
```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
chart.LineFormat.FillFormat.FillType = FillType.Solid;
chart.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chart.LineFormat.Style = LineStyle.Single;
chart.HasRoundedCorners = true;

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **Menyunting Anotasi Grafik yang Ada**

Sebuah grafik dapat berisi bentuk khusus, seperti anotasi teks yang menjelaskan status laporan. Akses bentuk-bentuk ini melalui [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/), juga terdaftar di bawah [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) dalam Referensi API Grafik. Koleksi [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/)‑nya berisi bentuk yang dimiliki grafik. Sebuah kotak teks biasa yang ditempatkan di atas grafik menjadi milik slide, meskipun tampak seperti bagian grafik. Mengiterasi melalui [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) menemukan grafik dan bentuk slide biasa, tetapi tidak mengenumerasi bentuk individual di dalam grafik. Judul grafik dan label data adalah elemen grafik terpisah, bukan anotasi khusus dalam koleksi ini. Unduh [chart-annotations.pptx](chart-annotations.pptx) dan letakkan di direktori kerja aplikasi. Slide pertama berisi grafik dengan anotasi tak berkelompok yang berisi "Preliminary results", sebuah garis milik grafik, dan sebuah kotak teks slide biasa yang berisi "Slide overlay". Contoh ini menemukan grafik pertama pada slide tersebut dan mengubah anotasi menjadi "Final results" ketika laporan siap dipublikasikan. Ia memeriksa apakah koleksi kosong dan hanya menyunting sebuah [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) dengan [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) tidak null serta teks yang diharapkan.
```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-annotations.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.OfType<IChart>().FirstOrDefault();

if (chart == null || chart.UserShapes.Shapes.Count == 0)
{
    Console.WriteLine("No chart or chart-owned shapes found.");
    return;
}

var updated = false;
foreach (var shape in chart.UserShapes.Shapes)
{
    if (shape is IAutoShape annotation && 
        annotation.TextFrame != null && 
        annotation.TextFrame.Text == "Preliminary results")
    {
        annotation.TextFrame.Text = "Final results";
        updated = true;
        break;
    }
}

if (updated)
{
    presentation.Save("chart-annotations-updated.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No matching text annotation found.");
}
```

Garis dan kotak teks slide tetap tidak berubah. Gambar berikut menunjukkan input dan hasil yang disimpan serta dibuka kembali:

| Sebelum mengedit | Setelah mengedit |
| --- | --- |
| ![Anotasi grafik berisi Preliminary results](chart-annotations-before.png) | ![Anotasi grafik berisi Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Contoh ini memeriksa hanya bentuk tingkat atas yang dimiliki grafik. Jika sebuah anotasi berada di dalam [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), periksa koleksi [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) grup tersebut juga. Ulangi secara rekursif untuk grup bersarang, menerapkan pemeriksaan teks yang sama pada bentuk anaknya. Sebuah grup sendiri adalah wadah; jangan memperlakukan sebagai kotak teks.
{{% /alert %}}

## **Tanya Jawab**

**Apakah saya dapat mengatur isian semi-transparan untuk kolom/area sambil menjaga batas tetap tidak tembus pandang?**

Ya. Transparansi isian dan garis tepi dikonfigurasi secara terpisah. Ini berguna untuk meningkatkan keterbacaan kisi dan data pada visualisasi yang padat.

**Bagaimana saya dapat menangani label data ketika mereka saling tumpang tindih?**

Kurangi ukuran font, nonaktifkan komponen label yang tidak penting (misalnya, kategori), sesuaikan posisi label, tampilkan label hanya untuk poin terpilih jika diperlukan, atau ubah format menjadi "nilai + legenda".

**Apakah saya dapat menerapkan isian gradien atau pola pada seri?**

Ya. Seri mendukung isian solid, gradien, dan pola. Dalam praktiknya, gunakan gradien secara hemat dan hindari kombinasi yang mengurangi kontras dengan kisi dan teks.