---
title: Sesuaikan Tabel Data Bagan dalam Presentasi di .NET
linktitle: Tabel Data
type: docs
url: /id/net/chart-data-table/
keywords:
- data bagan
- tabel data
- properti font
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Sesuaikan font, batas, dan kunci legenda tabel data bagan dalam presentasi PowerPoint menggunakan Aspose.Slides untuk .NET dan C#."
---
## **Ikhtisar**

Aspose.Slides for .NET memungkinkan Anda menampilkan tabel data bagan dan menyesuaikan pemformatan teksnya, batas, serta kunci legenda. Artikel ini menjelaskan cara mengaktifkan tabel, memformat teksnya, mengontrol setiap jenis batas, dan menampilkan atau menyembunyikan kunci legenda. Contoh-contoh menyimpan bagan yang dikonfigurasi dalam file PPTX.

## **Atur Properti Font**

Untuk menampilkan tabel data bagan, atur [HasDataTable](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chart/hasdatatable/) ke `true`. Gunakan [ChartDataTable](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chart/chartdatatable/) untuk mengakses tabel dan mengonfigurasi pemformatan teksnya.

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
1. Tambahkan bagan kolom berkelompok ke slide pertama.
1. Aktifkan tabel data bagan.
1. Aktifkan teks tebal dengan [FontBold](https://reference.aspose.com/slides/id/net/aspose.slides/baseportionformat/fontbold/) dan atur [FontHeight](https://reference.aspose.com/slides/id/net/aspose.slides/baseportionformat/fontheight/) ke `20` untuk teks 20 poin.
1. Simpan presentasi yang dimodifikasi.

Contoh berikut memerlukan `test.pptx` di direktori kerja dengan setidaknya satu slide. Contoh ini menambahkan bagan dengan data default pada posisi (50, 50), dengan lebar 600 poin dan tinggi 400 poin. `output.pptx` yang disimpan berisi bagan dengan tabel data diaktifkan dan pengaturan font yang ditentukan diterapkan.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Sesuaikan Batas Tabel Data**

Aktifkan tabel dengan [IChart.HasDataTable](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichart/hasdatatable/) dan akses melalui [IChart.ChartDataTable](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichart/chartdatatable/). Anda dapat mengontrol tiga jenis batas secara independen:

- [HasBorderHorizontal](https://reference.aspose.com/slides/id/net/aspose.slides.charts/idatatable/hasborderhorizontal/) mengontrol batas sel horizontal.
- [HasBorderVertical](https://reference.aspose.com/slides/id/net/aspose.slides.charts/idatatable/hasbordervertical/) mengontrol batas sel vertikal.
- [HasBorderOutline](https://reference.aspose.com/slides/id/net/aspose.slides.charts/idatatable/hasborderoutline/) mengontrol batas luar tabel.

Atur masing‑masing properti ke `true` untuk menampilkan batasnya atau `false` untuk menyembunyikannya. Contoh berikut membuat bagan kolom berkelompok dengan data default, menampilkan batas horizontal dan batas luar, serta menyembunyikan batas vertikal. Tidak memerlukan file input. Posisi dan ukuran bagan ditentukan dalam poin.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

Perbandingan di bawah ini menggunakan data bagan dan pengaturan kunci legenda yang sama dalam keempat kasus. Dimulai dengan semua batas diaktifkan, setiap varian yang tersisa menonaktifkan satu properti batas saja. Variannya di kiri‑bawah cocok dengan pengaturan batas pada contoh.

![Tabel data bagan dengan semua batas diaktifkan, tanpa batas horizontal, tanpa batas vertikal, dan tanpa batas luar](data-table-borders.png)

## **Tampilkan atau Sembunyikan Kunci Legenda**

Kunci legenda adalah penanda berwarna kecil di sebelah nama seri dalam tabel data. Mereka membantu pembaca mencocokkan setiap baris tabel dengan seri pada bagan. Atur [ShowLegendKey](https://reference.aspose.com/slides/id/net/aspose.slides.charts/idatatable/showlegendkey/) ke `true` untuk menampilkan penanda ini atau `false` untuk menyembunyikannya.

Legenda terpisah pada bagan dikontrol oleh [IChart.HasLegend](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichart/haslegend/). Pengaturan ini bersifat independen: menyembunyikan legenda terpisah tidak menyembunyikan kunci di dalam tabel data, dan menyembunyikan kunci tabel tidak menyembunyikan legenda terpisah.

Contoh berikut membuat bagan dengan data default, mengaktifkan tabel datanya, dan menampilkan kunci legenda di dalamnya sambil menyembunyikan legenda terpisah. Semua batas tabel secara eksplisit diaktifkan. Tidak memerlukan presentasi input. Untuk menyembunyikan hanya kunci tabel, ubah `dataTable.ShowLegendKey` menjadi `false`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

Perbandingan di bawah ini menunjukkan tabel yang sama dengan kunci legenda diaktifkan dan dinonaktifkan. Semua batas tetap diaktifkan, dan legenda bagan terpisah disembunyikan pada kedua kasus.

![Tabel data bagan dengan kunci legenda ditampilkan di kiri dan disembunyikan di kanan](data-table-legend-keys.png)

## **FAQ**

**Apakah saya dapat menampilkan kunci legenda di tabel data bagan?**

Ya. Atur [ShowLegendKey](https://reference.aspose.com/slides/id/net/aspose.slides.charts/datatable/showlegendkey/) ke `true` untuk menampilkan kunci legenda atau ke `false` untuk menyembunyikannya.

**Apakah tabel data akan dipertahankan saat mengekspor presentasi ke PDF, HTML, atau gambar?**

Ya. Aspose.Slides merender bagan dan tabel data yang ditampilkan sebagai bagian dari slide saat mengekspor ke [PDF](/slides/id/net/convert-powerpoint-to-pdf/), [HTML](/slides/id/net/convert-powerpoint-to-html/), atau [images](/slides/id/net/convert-powerpoint-to-png/).

**Apakah saya dapat bekerja dengan tabel data dalam bagan yang dimuat dari templat?**

Ya. Untuk bagan yang dimuat dari presentasi atau templat yang ada, gunakan [HasDataTable](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chart/hasdatatable/) untuk memeriksa atau mengubah apakah tabel datanya ditampilkan.

**Bagaimana cara menemukan bagan yang memiliki tabel data diaktifkan?**

Iterasi melalui shape pada setiap slide, identifikasi bagan‑bagan, dan periksa properti [HasDataTable](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chart/hasdatatable/) mereka. Nilai `true` menunjukkan bahwa tabel data diaktifkan.