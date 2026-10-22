---
title: Format Diagram Presentasi di PHP
linktitle: Pemformatan Diagram
type: docs
weight: 60
url: /id/php-java/chart-formatting/
keywords:
- format diagram
- pemformatan diagram
- entitas diagram
- properti diagram
- pengaturan diagram
- opsi diagram
- properti font
- border bulat
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari pemformatan diagram di Aspose.Slides untuk PHP melalui Java dan tingkatkan presentasi PowerPoint Anda dengan sumbu khusus, font, format angka, dan batas diagram yang bulat."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara memformat diagram dalam presentasi PowerPoint dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara menyesuaikan elemen diagram utama seperti sumbu, garis kisi, judul, legenda, area plot, dan isi dinding untuk meningkatkan tampilan dan keterbacaan data diagram.

Artikel ini juga mendemonstrasikan cara mengatur properti font untuk teks diagram, menerapkan format numerik bawaan pada data diagram, dan mengaktifkan sudut bulat untuk area diagram. Bersama-sama, contoh-contoh ini menunjukkan cara mengontrol baik gaya visual maupun penyajian data diagram dalam sebuah presentasi.

## **Format Entitas Diagram**

Gunakan [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) untuk memformat judul diagram, sumbu, garis kisi, legenda, dan area plot. Contoh ini membuat diagram garis dengan penanda dan data default, kemudian menerapkan gaya teks dan garis terpisah pada sumbu nilai dan kategori. Ukuran font dan lebar garis ditentukan dalam poin; label kategori diputar 45 derajat.

Sumbu nilai menggunakan [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) secara independen dari sel sumber. Skala sumbu berjalan dari -2 hingga 15, dengan interval utama 2 dan interval minor 0,5. Contoh ini juga menggabungkan pemformatan persentase dengan [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) yang diatur ke ribuan, jadi sesuaikan pengaturan ini dengan makna dan besaran data Anda. Legenda tetap berada di luar area plot karena [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) dipanggil dengan `false`. Pengisian dinding belakang dan lantai dikonfigurasi melalui [getBackWall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/) dan [getFloor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/), namun permukaan ini hanya terlihat pada diagram 3D.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\LineDashStyle;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\TickLabelPositionType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);

    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle::DashDot);

    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");

    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);

    $chart->getAxes()->getVerticalAxis()->setMaxValue(15);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);

    $valueAxisText = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $valueAxisText->setFontBold(NullableBool::True);
    $valueAxisText->setFontHeight(16);
    $valueAxisText->setFontItalic(NullableBool::True);
    $valueAxisText->getFillFormat()->setFillType(FillType::Solid);
    $valueAxisText->getFillFormat()->getSolidFillColor()->setPresetColor(PresetColor::DarkGreen);
    $valueAxisText->setLatinFont(new FontData("Times New Roman"));

    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valueAxisTitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valueAxisTitle->setText("Primary Axis");
    $valueAxisTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valueAxisTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valueAxisTitle->getPortionFormat()->setFontHeight(20);
    $valueAxisTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valueAxisTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 128, 0));
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);

    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);

    $categoryAxisText = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $categoryAxisText->setFontBold(NullableBool::True);
    $categoryAxisText->setFontHeight(16);
    $categoryAxisText->setFontItalic(NullableBool::True);
    $categoryAxisText->getFillFormat()->setFillType(FillType::Solid);
    $categoryAxisText->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $categoryAxisText->setLatinFont(new FontData("Arial"));

    $chart->getAxes()->getHorizontalAxis()->setTitle(true);
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");

    $categoryAxisTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $categoryAxisTitle->setText("Sample Category");
    $categoryAxisTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $categoryAxisTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $categoryAxisTitle->getPortionFormat()->setFontHeight(20);
    $categoryAxisTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $categoryAxisTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);

    $legendText = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $legendText->setFontBold(NullableBool::True);
    $legendText->setFontHeight(16);
    $legendText->setFontItalic(NullableBool::True);
    $legendText->getFillFormat()->setFillType(FillType::Solid);
    $legendText->getFillFormat()->getSolidFillColor()->setPresetColor(PresetColor::DarkRed);

    $chart->getLegend()->setOverlay(false);

    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setPresetColor(PresetColor::LightCyan);

    $presentation->save("FormattedChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Atur Properti Font untuk Diagram**

Atur ukuran font default untuk teks diagram melalui [Chart::getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chart/gettextformat/). Contoh ini membuat diagram kolom berkelompok dengan font 20 poin dan mengaktifkan label nilai untuk seri pertama melalui [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/). Elemen teks dengan pengaturan font eksplisitnya sendiri dapat menimpa nilai default diagram.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Atur Format Numerik**

Gunakan [ChartDataCell::setPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setpresetnumberformat/) untuk menerapkan format angka bawaan pada sel workbook diagram. Contoh ini membuat diagram kolom berkelompok dengan data default yang didukung sel dan menerapkan indeks format 10 (`0.00%`) pada setiap sel nilai seri. Ini mengubah cara nilai ditampilkan dalam workbook tanpa mengubah angka dasarnya; misalnya, 0,25 ditampilkan sebagai 25,00%. Format sumbu dan label data dapat dikonfigurasi secara terpisah.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries();

    for ($i = 0; $i < java_values($series->size()); $i++) {
        $chartSeries = $series->get_Item($i);
        $dataPoints = $chartSeries->getDataPoints();
        for ($j = 0; $j < java_values($dataPoints->size()); $j++) {
            $dataPoint = $dataPoints->get_Item($j);
            $dataPoint->getValue()->getAsCell()->setPresetNumberFormat(10); // 0.00%
        }
    }

    $presentation->save("PresetNumberFormat_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Tabel berikut mencantumkan indeks format angka bawaan dengan format Excel representatif untuk locale Inggris (Amerika Serikat). String format tepat dan tampilannya dapat bervariasi menurut aplikasi dan locale, khususnya untuk mata uang dan tanggal. Beberapa format Excel juga berbeda dari default dalam standar OOXML, seperti dijelaskan dalam [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

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

## **Atur Sudut Bulat Area Diagram**

Panggil [Chart::setRoundedCorners](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setroundedcorners/) dengan `true` untuk membuat sudut area diagram menjadi bulat. Contoh ini membuat diagram kolom berkelompok dan menggunakan [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/) untuk memberi garis luar warna abu-abu solid dan gaya garis tunggal sebelum menyimpan presentasi.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chart->getLineFormat()->setStyle(LineStyle::Single);
    $chart->setRoundedCorners(true);

    $presentation->save("out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Sunting Anotasi Diagram yang Ada**

Diagram dapat berisi bentuk khusus, seperti anotasi teks yang menjelaskan status laporan. Akses bentuk-bentuk ini melalui [Chart::getUserShapes](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getusershapes/). Koleksi yang dikembalikan oleh [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/getshapes/) berisi bentuk-bentuk yang dimiliki diagram.

Kotak teks biasa yang ditempatkan di atas diagram merupakan milik slide, meskipun tampak seperti bagian diagram. Iterasi melalui [Slide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) menemukan diagram dan bentuk slide biasa, tetapi tidak mencantumkan bentuk individual di dalam diagram. Judul diagram dan label data adalah elemen diagram terpisah, bukan anotasi khusus dalam koleksi ini.

Unduh [chart-annotations.pptx](chart-annotations.pptx) dan letakkan di direktori kerja aplikasi. Slide pertamanya berisi diagram dengan anotasi tidak berkelompok yang berisi "Preliminary results", sebuah garis yang dimiliki diagram, dan kotak teks slide biasa yang berisi "Slide overlay". Contoh ini menemukan diagram pertama pada slide tersebut dan mengubah anotasi menjadi "Final results" ketika laporan siap dipublikasikan. Ia memeriksa apakah koleksi kosong dan hanya menyunting sebuah [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) dengan bingkai teks tidak null yang dikembalikan oleh [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/gettextframe/) dan teks yang diharapkan.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-annotations.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chartType = new JavaClass("com.aspose.slides.IChart");
    $autoShapeType = new JavaClass("com.aspose.slides.IAutoShape");
    $chart = null;
    for ($i = 0; $i < java_values($slide->getShapes()->size()); $i++) {
        $shape = $slide->getShapes()->get_Item($i);
        if (java_instanceof($shape, $chartType)) {
            $chart = $shape;
            break;
        }
    }

    if ($chart === null || java_values($chart->getUserShapes()->getShapes()->size()) == 0) {
        echo "No chart or chart-owned shapes found." . PHP_EOL;
        return;
    }

    $updated = false;
    $userShapes = $chart->getUserShapes()->getShapes();
    for ($i = 0; $i < java_values($userShapes->size()); $i++) {
        $shape = $userShapes->get_Item($i);
        if (java_instanceof($shape, $autoShapeType)) {
            $annotation = $shape;
            if (!java_is_null($annotation->getTextFrame()) && java_values($annotation->getTextFrame()->getText()) === "Preliminary results") {
                $annotation->getTextFrame()->setText("Final results");
                $updated = true;
                break;
            }
        }
    }

    if ($updated) {
        $presentation->save("chart-annotations-updated.pptx", SaveFormat::Pptx);
    } else {
        echo "No matching text annotation found." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Garis dan kotak teks slide tetap tidak berubah. Gambar berikut menunjukkan input dan hasil yang disimpan serta dibuka kembali:

| Sebelum penyuntingan | Setelah penyuntingan |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}

Contoh ini memeriksa hanya bentuk-bentuk tingkat atas yang dimiliki diagram. Jika sebuah anotasi berada di dalam [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), periksa koleksi [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/getshapes/) grup tersebut juga. Ulangi secara rekursif untuk grup bersarang, menerapkan pemeriksaan teks yang sama pada bentuk anaknya. Sebuah grup sendiri adalah wadah; jangan perlakukan sebagai kotak teks.

{{% /alert %}}

## **Tanya Jawab**

**Apakah saya dapat mengatur isian semi-transparan untuk kolom/area sambil mempertahankan batas tetap tidak transparan?**

Ya. Transparansi isian dan garis luar dikonfigurasi secara terpisah. Hal ini berguna untuk meningkatkan keterbacaan kisi dan data dalam visualisasi yang padat.

**Bagaimana saya dapat menangani label data ketika mereka saling tumpang tindih?**

Kurangi ukuran font, nonaktifkan komponen label yang tidak penting (misalnya, kategori), sesuaikan posisi label, tampilkan label hanya untuk titik yang dipilih bila perlu, atau ubah format menjadi "nilai + legenda".

**Apakah saya dapat menerapkan isian gradasi atau pola pada seri?**

Ya. Seri mendukung isian padat, gradasi, dan pola. Dalam praktiknya, gunakan gradasi secara hemat dan hindari kombinasi yang mengurangi kontras dengan kisi dan teks.