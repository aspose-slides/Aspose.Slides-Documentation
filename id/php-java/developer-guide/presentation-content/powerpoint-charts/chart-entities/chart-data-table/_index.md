---
title: Sesuaikan Tabel Data Diagram dalam Presentasi Menggunakan PHP
linktitle: Tabel Data
type: docs
url: /id/php-java/chart-data-table/
keywords:
- data diagram
- tabel data
- properti font
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Sesuaikan font, batas, dan kunci legenda tabel data diagram dalam presentasi PowerPoint menggunakan Aspose.Slides untuk PHP via Java."
---
## **Ikhtisar**

Aspose.Slides for PHP via Java memungkinkan Anda menampilkan tabel data diagram dan menyesuaikan pemformatan teks, batas, dan kunci legenda. Artikel ini menjelaskan cara mengaktifkan tabel, memformat teksnya, mengontrol setiap jenis batas, dan menampilkan atau menyembunyikan kunci legenda. Contoh-contoh menyimpan diagram yang telah dikonfigurasi dalam file PPTX.

## **Mengatur Properti Font**

Untuk menampilkan tabel data diagram, berikan `true` ke [setDataTable](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/setdatatable/). Gunakan [getChartDataTable](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/getchartdatatable/) untuk mengakses tabel dan mengonfigurasi pemformatan teksnya.

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Tambahkan diagram kolom berkelompok ke slide pertama.
1. Aktifkan tabel data diagram.
1. Aktifkan teks tebal dengan [setFontBold](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setFontBold) dan berikan `20` ke [setFontHeight](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setFontHeight) untuk teks berukuran 20 poin.
1. Simpan presentasi yang telah dimodifikasi.

Contoh berikut memerlukan `test.pptx` di direktori kerja dengan setidaknya satu slide. Contoh ini menambahkan diagram dengan data default pada posisi (50, 50), dengan lebar 600 poin dan tinggi 400 poin. File `output.pptx` yang disimpan berisi diagram dengan tabel datanya diaktifkan dan pengaturan font yang ditentukan diterapkan.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $portionFormat = $chart->getChartDataTable()->getTextFormat()->getPortionFormat();
    $portionFormat->setFontBold(NullableBool::True);
    $portionFormat->setFontHeight(20);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Sesuaikan Batas Tabel Data**

Aktifkan tabel dengan [Chart::setDataTable](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/setdatatable/) dan akses melalui [Chart::getChartDataTable](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/getchartdatatable/). Anda dapat mengontrol tiga jenis batas secara independen:

- [setBorderHorizontal](https://reference.aspose.com/slides/id/php-java/aspose.slides/datatable/setborderhorizontal/) mengontrol batas sel horizontal.
- [setBorderVertical](https://reference.aspose.com/slides/id/php-java/aspose.slides/datatable/setbordervertical/) mengontrol batas sel vertikal.
- [setBorderOutline](https://reference.aspose.com/slides/id/php-java/aspose.slides/datatable/setborderoutline/) mengontrol batas luar tabel.

Berikan `true` ke setiap metode untuk menampilkan batasnya atau `false` untuk menyembunyikannya. Contoh berikut membuat diagram kolom berkelompok dengan data default, menampilkan batas horizontal dan batas luar, serta menyembunyikan batas vertikal. Tidak memerlukan file masukan. Posisi dan ukuran diagram ditentukan dalam poin.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(false);
    $dataTable->setBorderOutline(true);

    $presentation->save("data-table-borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Perbandingan di bawah ini menggunakan data diagram yang sama dan pengaturan kunci legenda dalam keempat kasus. Dimulai dengan semua batas diaktifkan, setiap varian yang tersisa menonaktifkan hanya satu pengaturan batas. Varian kiri bawah cocok dengan pengaturan batas pada contoh.

![Tabel data diagram dengan semua batas diaktifkan, tanpa batas horizontal, tanpa batas vertikal, dan tanpa batas luar](data-table-borders.png)

## **Tampilkan atau Sembunyikan Kunci Legenda**

Kunci legenda adalah penanda berwarna kecil di samping nama seri dalam tabel data. Mereka membantu pembaca mencocokkan setiap baris tabel dengan seri diagram. Berikan `true` ke [setShowLegendKey](https://reference.aspose.com/slides/id/php-java/aspose.slides/datatable/setshowlegendkey/) untuk menampilkan penanda ini atau `false` untuk menyembunyikannya.

Legenda terpisah diagram dikontrol oleh [Chart::setLegend](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/setlegend/). Pengaturan ini bersifat independen: menyembunyikan legenda terpisah tidak menyembunyikan kunci di dalam tabel data, dan menyembunyikan kunci tabel tidak menyembunyikan legenda terpisah.

Contoh berikut membuat diagram dengan data default, mengaktifkan tabel datanya, dan menampilkan kunci legenda di dalamnya sekaligus menyembunyikan legenda terpisah. Semua batas tabel secara eksplisit diaktifkan. Tidak diperlukan presentasi masukan. Untuk menyembunyikan hanya kunci tabel, berikan `false` ke [setShowLegendKey](https://reference.aspose.com/slides/id/php-java/aspose.slides/datatable/setshowlegendkey/).

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->setLegend(false);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(true);
    $dataTable->setBorderOutline(true);
    $dataTable->setShowLegendKey(true);

    $presentation->save("data-table-legend-keys.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Perbandingan di bawah ini menampilkan tabel yang sama dengan kunci legenda diaktifkan dan dinonaktifkan. Semua batas tetap diaktifkan, dan legenda diagram terpisah disembunyikan pada kedua kasus.

![Tabel data diagram dengan kunci legenda ditampilkan di kiri dan disembunyikan di kanan](data-table-legend-keys.png)

## **FAQ**

**Apakah saya dapat menampilkan kunci legenda di tabel data diagram?**

Ya. Berikan `true` ke [setShowLegendKey](https://reference.aspose.com/slides/id/php-java/aspose.slides/datatable/setshowlegendkey/) untuk menampilkan kunci legenda atau `false` untuk menyembunyikannya.

**Apakah tabel data akan dipertahankan saat mengekspor presentasi ke PDF, HTML, atau gambar?**

Ya. Aspose.Slides merender diagram dan tabel data yang ditampilkan sebagai bagian dari slide saat mengekspor ke [PDF](/slides/id/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/id/php-java/convert-powerpoint-to-html/), atau [gambar](/slides/id/php-java/convert-powerpoint-to-png/).

**Apakah saya dapat bekerja dengan tabel data pada diagram yang dimuat dari templat?**

Ya. Untuk diagram yang dimuat dari presentasi atau templat yang ada, gunakan [hasDataTable](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/hasdatatable/) dan [setDataTable](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/setdatatable/) untuk memeriksa atau mengubah apakah tabel datanya ditampilkan.

**Bagaimana cara menemukan diagram yang memiliki tabel data diaktifkan?**

Iterasikan melalui bentuk-bentuk pada setiap slide, identifikasi diagram, dan panggil metode [hasDataTable](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/hasdatatable/) mereka. Nilai `true` menunjukkan bahwa tabel data diaktifkan.