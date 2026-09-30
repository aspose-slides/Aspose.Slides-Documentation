---
title: Sesuaikan legenda diagram dalam presentasi di .NET
linktitle: Legenda Diagram
type: docs
url: /id/net/chart-legend/
keywords:
- legenda diagram
- posisi legenda
- ukuran font
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Sesuaikan legenda diagram dengan Aspose.Slides untuk .NET guna mengoptimalkan presentasi PowerPoint dengan pemformatan legenda yang disesuaikan."
---
## **Gambaran Umum**

Aspose.Slides for .NET menyediakan opsi untuk menyesuaikan legenda diagram dalam presentasi PowerPoint. Artikel ini menunjukkan cara memposisikan dan mengubah ukuran legenda, mengatur ukuran font untuk seluruh legenda, memformat entri legenda individu, serta menyembunyikan atau mengembalikan entri yang dipilih.

FAQ mencakup perilaku terkait, termasuk memesan ruang untuk legenda, menampilkan label multiline, dan mewarisi format dari tema presentasi.

## **Posisi Legenda**

Gunakan properti [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/), dan [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) pada legenda untuk menentukan posisi dan ukuran sebagai pecahan dari dimensi diagram.

Contoh ini membuat presentasi dan menambahkan diagram kolom berkelompok dengan data default ke slide pertama. Membagi offset dan dimensi legenda yang diinginkan dengan lebar dan tinggi diagram mengubahnya menjadi nilai relatif: legenda dipindahkan 50 poin dari sudut kiri‑atas diagram dan berukuran 100×100 poin.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Express the legend's position and size relative to the chart.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **Atur Ukuran Font Legenda**

Gunakan [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) pada legenda untuk mengakses pemformatan teksnya dan atur [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) dalam poin.

Contoh ini membuat diagram dengan data default dan mengatur teks legenda menjadi 20 poin. Ini juga menonaktifkan batas otomatis untuk sumbu vertikal dan mengatur jangkauannya dari -5 hingga 10.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **Atur Ukuran Font Entri Legenda Individu**

Gunakan koleksi [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) pada legenda untuk mengakses pemformatan entri tertentu. Indeks entri dimulai dari nol, sehingga indeks `1` mengacu pada entri kedua.

Contoh ini membuat diagram kolom berkelompok yang data defaultnya mencakup setidaknya dua seri. Ini memformat entri legenda kedua dengan teks tebal, miring, berwarna biru, dan ukuran 20 poin.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **Sembunyikan Entri Legenda Individu**

Untuk mengecualikan seri tambahan dari legenda sementara data tetap terlihat, atur [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) menjadi `true` melalui [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/). Ini menyembunyikan hanya entri legenda yang dipilih; tidak menghapus seri atau titik data. Sebaliknya, mengatur [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) menjadi `false` menyembunyikan seluruh legenda.

Contoh di bawah ini membuat diagram kolom berkelompok dengan beberapa seri menggunakan data default. Itu menyembunyikan entri legenda seri kedua (indeks `1`) dan menyimpan presentasi. Kemudian entri tersebut dipulihkan dengan mengatur `Hide` menjadi `false` dan menyimpan salinan kedua. Kolom tetap terlihat di kedua file.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// Pulihkan entri yang sama tanpa mengubah data diagram.
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

Perbandingan di bawah ini menunjukkan diagram yang sama dengan semua entri terlihat dan dengan entri kedua disembunyikan. Kolom seri kedua tetap tidak berubah.

![Perbandingan diagram dengan semua entri legenda terlihat dan dengan Seri 2 disembunyikan dari legenda; semua kolom tetap terlihat.](hide-legend-entry.png)

Pada diagram kolom, batang, dan garis, entri legenda mengidentifikasi seri. Pada diagram pai, mereka mengidentifikasi titik data individual (irisan), jadi gunakan [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) pada irisan yang dipilih. API mendokumentasikan properti titik data ini untuk tipe diagram `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, dan `BarOfPie`. Jangan mengasumsikan bahwa ini berlaku untuk diagram donat, yang tidak termasuk dalam daftar tersebut.

## **FAQ**

**Can I make the chart allocate space for the legend instead of overlaying it?**

Ya. Atur [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) menjadi `false` untuk memesan ruang bagi legenda alih-alih membiarkannya menimpa area plot.

**Can I make multiline legend labels?**

Ya. Label yang panjang dapat membungkus ketika lebar yang tersedia tidak cukup. Anda juga dapat menggunakan karakter baris baru dalam nama seri untuk meminta pemisahan baris.

**How do I make the legend follow the presentation theme's color scheme?**

Biarkan warna, isian, dan font legenda tidak diatur sehingga dapat mewarisi format tema. Pemformatan eksplisit akan menimpa pengaturan tema yang bersangkutan.