---
title: Sesuaikan Legenda Diagram dalam Presentasi Menggunakan PHP
linktitle: Legenda Diagram
type: docs
url: /id/php-java/chart-legend/
keywords:
- legenda diagram
- posisi legenda
- ukuran font
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Sesuaikan legenda diagram dengan Aspose.Slides for PHP via Java untuk mengoptimalkan presentasi PowerPoint dengan pemformatan legenda yang disesuaikan."
---
## **Gambaran Umum**

Aspose.Slides for PHP via Java menyediakan opsi untuk menyesuaikan legenda diagram dalam presentasi PowerPoint. Artikel ini menunjukkan cara memposisikan dan mengubah ukuran legenda, mengatur ukuran font untuk seluruh legenda, memformat entri legenda tertentu, serta menyembunyikan atau mengembalikan entri yang dipilih.

FAQ mencakup perilaku terkait, termasuk memesan ruang untuk legenda, menampilkan label multiline, dan mewarisi pemformatan dari tema presentasi.

## **Penempatan Legenda**

Gunakan metode legend [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/), dan [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/) untuk menentukan posisi dan ukuran legenda sebagai pecahan dimensi diagram.

Contoh ini membuat sebuah presentasi dan menambahkan diagram kolom berkelompok dengan data default ke slide pertama. Membagi offset dan dimensi legenda yang diinginkan dengan lebar dan tinggi diagram mengubahnya menjadi nilai relatif: legenda bergeser 50 poin dari sudut kiri‑atas diagram dan berukuran 100 × 100 poin. Contoh ini menggunakan java_values untuk mengonversi dimensi diagram yang dikembalikan oleh PHP/Java Bridge menjadi angka PHP sebelum pembagian.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

    $chartWidth = java_values($chart->getWidth());
    $chartHeight = java_values($chart->getHeight());

    // Ekspresikan posisi dan ukuran legenda relatif terhadap diagram.
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Atur Ukuran Font Legenda**

Gunakan legend [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/) untuk mengakses pemformatan teksnya dan gunakan [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) untuk mengatur ukuran font dalam poin.

Contoh ini membuat diagram dengan data default dan mengatur teks legenda menjadi 20 poin. Ia juga menonaktifkan batas otomatis untuk sumbu vertikal dan mengatur rentangnya dari –5 hingga 10.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $presentation->save("legend_font_size.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Atur Ukuran Font Entri Legenda Individu**

Gunakan koleksi yang dikembalikan oleh metode legend [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/) untuk mengakses pemformatan entri tertentu. Indeks entri dihitung dari nol, sehingga indeks `1` mengacu pada entri kedua.

Contoh ini membuat diagram kolom berkelompok yang data defaultnya mencakup setidaknya dua seri. Ia memformat entri legenda kedua dengan teks tebal, miring, berwarna biru, dan ukuran 20 poin.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $textFormat = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $textFormat->getPortionFormat()->setFontBold(NullableBool::True);
    $textFormat->getPortionFormat()->setFontHeight(20);
    $textFormat->getPortionFormat()->setFontItalic(NullableBool::True);
    $textFormat->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $textFormat->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("legend_entry_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Sembunyikan Entri Legenda Individu**

Untuk mengecualikan serinya tambahan dari legenda sementara tetap menampilkan datanya, panggil [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) dengan `true` melalui [ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/). Ini menyembunyikan hanya entri legenda yang dipilih; tidak menghapus seri atau titik datanya. Memanggil [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/) dengan `false`, sebaliknya, menyembunyikan seluruh legenda.

Contoh di bawah membuat diagram kolom berkelompok dengan beberapa seri menggunakan data default. Ia menyembunyikan entri legenda seri kedua (indeks `1`) dan menyimpan presentasi. Kemudian entri tersebut dipulihkan dengan memanggil [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) dengan `false` dan menyimpan salinan kedua. Kolom tetap terlihat di kedua file.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(true);

    $legendEntry = $chart->getChartData()->getSeries()->get_Item(1)->getRelatedLegendEntry();

    $legendEntry->setHide(true);
    $presentation->save("hidden_legend_entry.pptx", SaveFormat::Pptx);

    // Pulihkan entri yang sama tanpa mengubah data diagram.
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Perbandingan di bawah memperlihatkan diagram yang sama dengan semua entri terlihat dan dengan entri kedua disembunyikan. Kolom seri kedua tetap tidak berubah.

![Perbandingan diagram dengan semua entri legenda terlihat dan dengan Seri 2 disembunyikan dari legenda; semua kolom tetap terlihat.](hide-legend-entry.png)

Pada diagram kolom, batang, dan garis, entri legenda mengidentifikasi seri. Pada diagram pai, mereka mengidentifikasi titik data individu (iris), jadi gunakan [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) pada iris yang dipilih. API mendokumentasikan metode titik‑data ini untuk tipe diagram `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, dan `BarOfPie`. Jangan menganggap metode ini berlaku untuk diagram donat, yang tidak termasuk dalam daftar tersebut.

## **FAQ**

**Apakah saya dapat membuat diagram memesan ruang untuk legenda alih‑alih menimpanya?**

Ya. Panggil [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) dengan `false` untuk memesan ruang bagi legenda alih‑alih membiarkannya menimpit area plot.

**Apakah saya dapat membuat label legenda multiline?**

Ya. Label panjang dapat membungkus ketika lebar yang tersedia tidak cukup. Anda juga dapat menggunakan karakter baris baru dalam nama seri untuk meminta pemisahan baris.

**Bagaimana cara membuat legenda mengikuti skema warna tema presentasi?**

Biarkan warna, isian, dan font legenda tidak diatur sehingga dapat mewarisi pemformatan tema. Pemformatan eksplisit akan menimpa pengaturan tema yang bersangkutan.