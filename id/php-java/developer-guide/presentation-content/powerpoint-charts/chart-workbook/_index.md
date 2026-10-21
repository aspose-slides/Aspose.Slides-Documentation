---
title: Kelola Buku Kerja Grafik dalam Presentasi Menggunakan PHP
linktitle: Buku Kerja Grafik
type: docs
weight: 70
url: /id/php-java/chart-workbook/
keywords:
- buku kerja grafik
- data grafik
- sel buku kerja
- label data
- lembar kerja
- sumber data
- buku kerja eksternal
- data eksternal
- cache grafik
- pemulihan buku kerja
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Temukan Aspose.Slides untuk PHP via Java: kelola buku kerja grafik dengan mudah dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan buku kerja grafik di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data grafik melalui aliran buku kerja, menggunakan sel buku kerja sebagai label data grafik, mengakses koleksi lembar kerja, dan menentukan tipe sumber data untuk nilai grafik.

Artikel ini juga mencakup penggunaan buku kerja eksternal sebagai sumber data grafik. Contoh-contoh memperlihatkan cara membuat dan menetapkan buku kerja eksternal, mengambil jalur buku kerja eksternal yang terhubung ke grafik, serta mengedit data grafik ketika buku kerja tersedia.

Untuk sel buku kerja yang mewakili data yang hilang, lihat [Kontrol Tampilan Sel Kosong](/slides/id/php-java/chart-series/) untuk perbedaan antara sel kosong dan nol, serta perbandingan grafik garis dari mode tampilan yang tersedia.

## **Sertakan Data dari Baris dan Kolom Tersembunyi**

Gunakan [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) untuk mengontrol apakah grafik memplot data dari baris dan kolom lembar kerja yang tersembunyi. Atur ke `true` untuk memplot hanya sel yang terlihat, atau `false` untuk menyertakan sel yang terlihat dan tersembunyi. Pengaturan ini mengontrol pemetaan grafik; tidak menyembunyikan atau menampilkan kembali baris atau kolom lembar kerja.

[Presentasi contoh](hidden-source-data.pptx) berisi grafik kolom sebagai bentuk pertama pada slide pertama. Lembar kerja terbenam, `Sheet1`, berisi rentang sumber berikut, `A1:C4`. Baris 3 dan kolom C tersembunyi, tetapi sel‑selnya tetap berisi nilai.

| Baris Lembar Kerja | A: Bulan | B: Retail | C: Wholesale (kolom tersembunyi) |
| --- | --- | --- | --- |
| 2 | Januari | 10 | 30 |
| 3 (baris tersembunyi) | Februari | 40 | 60 |
| 4 | Maret | 20 | 50 |

Akses sel sumber melalui [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) dan baca [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) untuk memeriksa status tersembunyi mereka. Metode ini melaporkan status tersembunyi tanpa mengubahnya. Pada file ini, B2 terlihat, B3 termasuk dalam baris tersembunyi, dan C2 termasuk dalam kolom tersembunyi; contoh mencetak `false`, `true`, dan `true` secara berurutan.

Untuk contoh ini, segarkan data grafik setelah mengubah pengaturan pemetaan: pertahankan buku kerja terbenam dengan [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) dan muat ulang dengan [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/). Saat menyertakan semua sel, juga gunakan [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) untuk memulihkan rentang lengkap, termasuk kategori Februari yang tersembunyi. Mengubah flag saja tidak cukup untuk memperbarui data grafik dan label kategori yang di‑cache pada contoh ini.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hidden-source-data.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $workbook = $chart->getChartData()->getChartDataWorkbook();
        echo "B2 hidden: " . (java_values($workbook->getCell(0, "B2")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "B3 hidden: " . (java_values($workbook->getCell(0, "B3")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "C2 hidden: " . (java_values($workbook->getCell(0, "C2")->isHidden()) ? "true" : "false"), PHP_EOL;

        $workbookData = $chart->getChartData()->readWorkbookStream();
        foreach ([true, false] as $visibleOnly) {
            $chart->setPlotVisibleCellsOnly($visibleOnly);

            // Segarkan data grafik dari buku kerja yang terbenam.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // Pulihkan rentang sumber lengkap, termasuk kategori tersembunyi.
                $chart->getChartData()->setRange('Sheet1!$A$1:$C$4');
            }

            $presentation->save("hidden_cells_" . ($visibleOnly ? "true" : "false") . ".pptx", SaveFormat::Pptx);
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Contoh menyimpan dua versi presentasi: satu dengan hanya nilai Retail yang terlihat (10 dan 20), dan satu lagi dengan semua enam nilai. Gambar di bawah menggambarkan dua mode pemetaan. Baris 3 dan kolom C tetap tersembunyi pada kedua buku kerja terbenam.

| Hanya sel terlihat (`true`) | Semua sel (`false`) |
| --- | --- |
| ![Hanya sel terlihat: nilai Retail 10 dan 20 untuk Januari dan Maret.](hidden_cells_True.png) | ![Semua sel: nilai Retail dan Wholesale untuk Januari, Februari, dan Maret.](hidden_cells_False.png) |

Sel tersembunyi yang berisi nilai berbeda dari sel kosong. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) mengontrol bagaimana nilai yang hilang ditampilkan; tidak menambah atau mengeluarkan data sumber yang tersembunyi. Lihat [Kontrol Tampilan Sel Kosong](/slides/id/php-java/chart-series/#control-the-display-of-empty-cells) untuk contoh.

## **Ambil Rentang Data Grafik**

Sebelum memperbarui data buku kerja dalam presentasi yang ada, periksa rentang sumber untuk mengidentifikasi sel lembar kerja mana yang digunakan setiap grafik. Metode [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) mengembalikan rentang data saat ini sebagai formula yang memenuhi kualifikasi lembar kerja, misalnya `Sheet1!$A$1:$D$5`. Di sini, `Sheet1` adalah nama lembar kerja, `!` memisahkannya dari rentang sel, dan `$A$1:$D$5` menandai sel A1 sampai D5, inklusif. Tanda dolar menunjukkan referensi baris dan kolom absolut.

Metode ini membaca rentang saat ini tanpa mengubah grafik atau buku kerjanya. Jika grafik tidak menggunakan buku kerja sebagai sumber data, metode ini akan melemparkan pengecualian. Untuk informasi lebih lanjut, lihat [Referensi API ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).

Contoh ini membuka presentasi dan memeriksa bentuk‑bentuk langsung pada setiap slide untuk grafik. Ia mencetak nama setiap grafik dan rentang sumbernya. Jika suatu grafik tidak menggunakan buku kerja, ia mencetak pesan dan melanjutkan ke grafik berikutnya.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
                $chart = $shape;
                try {
                    $range = $chart->getChartData()->getRange();
                    echo $chart->getName() . ": " . $range, PHP_EOL;
                } catch (JavaException $exception) {
                    if (java_instanceof($exception, new JavaClass("com.aspose.slides.exceptions.InvalidOperationException"))) {
                        echo $chart->getName() . ": The chart does not use a workbook as its data source.", PHP_EOL;
                    } else {
                        echo $chart->getName() . ": " . $exception->getMessage(), PHP_EOL;
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Baca dan Tulis Data Grafik dari Buku Kerja**

Aspose.Slides for PHP via Java menyediakan metode [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) dan [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) yang memungkinkan Anda membaca dan menulis buku kerja data grafik (yang berisi data grafik yang disunting dengan Aspose.Cells). **Catatan** bahwa data grafik harus diatur dengan cara yang sama atau harus memiliki struktur yang mirip dengan sumbernya.

Contoh ini menggunakan presentasi dengan grafik sebagai bentuk pertama pada slide pertama. Ia membaca buku kerja terbenam ke dalam larik byte, menghapus seri dan kategori yang ada, dan menulis kembali buku kerja yang sama. Perubahan tetap berada di memori; contoh ini tidak menyimpan presentasi.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Validasi Tata Letak Grafik Setelah Modifikasi Buku Kerja**

Ketika Anda mengganti buku kerja terbenam dengan yang telah dimodifikasi, grafik tetap mempertahankan koleksi seri dan kategori aslinya. Ketidaksesuaian ini dapat menyebabkan [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) gagal dengan kesalahan indeks di luar jangkauan. Bersihkan seri dan kategori yang ada sebelum menulis kembali buku kerja yang diperbarui ke grafik. Contoh ini menggunakan grafik yang merupakan bentuk pertama pada slide pertama. Komentar menandai tempat penyuntingan buku kerja akan terjadi; contoh yang dapat dijalankan menulis kembali buku kerja asli dan memvalidasi tata letak di memori.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        // Ubah byte buku kerja di sini, misalnya, menggunakan Aspose.Cells.

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
        $chart->validateChartLayout();
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Membersihkan koleksi menghapus referensi data usang sebelum buku kerja ditulis kembali. Bangun kembali pemetaan seri dan kategori yang diperlukan untuk buku kerja yang diperbarui sebelum menggunakan grafik.

## **Tetapkan Format Angka Kustom untuk Sel Buku Kerja**

Gunakan [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) untuk mengontrol bagaimana nilai numerik ditampilkan dalam buku kerja terbenam grafik. Misalnya, laporan mungkin memerlukan tingkat konversi yang ditampilkan sebagai persentase dengan empat tempat desimal dan koefisien yang ditampilkan dengan lima tempat desimal. Pertahankan kedua nilai sebagai numerik agar tetap tersedia untuk perhitungan dan pemetaan grafik.

Format angka mengubah tampilan, bukan nilai yang disimpan. Format `0.0000%` menampilkan `0.125` sebagai `12.5000%`; tidak menggantikan angka yang disimpan dengan `12.5`. Demikian pula, `0.00000` menampilkan `0.1234567` sebagai `0.12346` tanpa membulatkan nilai yang disimpan. Jika format kustom adalah string kosong (`""`), format yang dikembalikan oleh [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/) akan digunakan.

Contoh berikut membuat grafik kolom dan mengakses sel‑nya melalui [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/). Pada lembar kerja 0, B2 berisi tingkat konversi dan C2 berisi koefisien. Kedua sel tersebut menyediakan nilai grafik. Contoh juga mengaktifkan label nilai yang ditautkan ke format sumber.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 270, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
    $chart->setTitle(false);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00");
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(0);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A2", "Sample");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $percentageCell = $workbook->getCell(0, "B2", 0.125);
    $percentageCell->setCustomNumberFormat("0.0000%");
    $percentageName = $workbook->getCell(0, "B1", "Conversion rate");
    $percentageSeries = $chart->getChartData()->getSeries()->add($percentageName, $chart->getType());
    $percentageSeries->getDataPoints()->addDataPointForBarSeries($percentageCell);

    $precisionCell = $workbook->getCell(0, "C2", 0.1234567);
    $precisionCell->setCustomNumberFormat("0.00000");
    $precisionName = $workbook->getCell(0, "C1", "Coefficient");
    $precisionSeries = $chart->getChartData()->getSeries()->add($precisionName, $chart->getType());
    $precisionSeries->getDataPoints()->addDataPointForBarSeries($precisionCell);

    for ($seriesIndex = 0; $seriesIndex < java_values($chart->getChartData()->getSeries()->size()); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $labelFormat = $series->getDataPoints()->get_Item(0)->getLabel()->getDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(true);
    }

    $presentation->save("CustomCellFormats.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Format sel buku kerja terpisah dari format yang diterapkan langsung pada sumbu grafik atau label data. Pada contoh ini, setiap label menampilkan nilai sel sumbernya karena [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) diatur ke `true`, dan mengikuti format angka sumber karena [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) diatur ke `true`. Setelah menyimpan dan membuka kembali presentasi, label menampilkan `12.5000%` dan `0.12346`, seperti yang ditunjukkan di bawah. Sumbu vertikal menggunakan format angkanya sendiri, ditetapkan dengan [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) sebagai `0.00`, dengan [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) diatur ke `false`.

Untuk memformat label data secara independen, setel flag tautan ke sumber menjadi `false` dan tetapkan format dengan [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/). Ini tidak mengubah format sel buku kerja. Misalnya, format label independen `0.00` menampilkan nilai pertama sebagai `0.13`, sementara B2 tetap menampilkan `12.5000%`. Lihat [Label Data Grafik](/slides/id/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) untuk format label secara langsung.

Gambar di bawah dihasilkan dari presentasi yang disimpan setelah dibuka kembali:

![Grafik kolom dengan label yang ditautkan ke sumber menampilkan 12.5000% dan 0.12346 serta sumbu numerik yang diformat secara independen.](custom-cell-formats.png)

## **Tetapkan Sel Buku Kerja sebagai Label Data Grafik**

Anda dapat menggunakan teks dari sel buku kerja sebagai label data grafik.

Contoh ini menambahkan grafik gelembung dengan data default ke slide pertama presentasi yang ada. Ia menggunakan sel A10:A12 pada lembar kerja 0 untuk tiga label pertama pada seri pertama, mengaktifkan label dari sel, dan menyimpan presentasi yang diperbarui.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $series->getLabels()->get_Item(0)->setValueFromCell($workbook->getCell(0, "A10", "Label 0 cell value"));
    $series->getLabels()->get_Item(1)->setValueFromCell($workbook->getCell(0, "A11", "Label 1 cell value"));
    $series->getLabels()->get_Item(2)->setValueFromCell($workbook->getCell(0, "A12", "Label 2 cell value"));

    $presentation->save("resultchart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kelola Lembar Kerja**

Metode [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) memberikan akses ke lembar kerja dalam buku kerja grafik. Contoh ini membuat grafik pai dengan data default dan mencetak nama setiap lembar kerja ke konsol.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    for ($i = 0; $i < java_values($workbook->getWorksheets()->size()); $i++) {
        echo $workbook->getWorksheets()->get_Item($i)->getName(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Tentukan Tipe Sumber Data**

Contoh ini membuat grafik kolom 3D dengan data default dan menetapkan dua nama seri menggunakan sumber data yang berbeda. Nama pertama menggunakan literal string; nama kedua menggunakan sel C1 pada lembar kerja 0. Enumerasi [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) memilih sumber untuk setiap nama. Contoh menyimpan presentasi dengan nama seri yang diperbarui.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;
use aspose\slides\DataSourceType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $literalName = $chart->getChartData()->getSeries()->get_Item(0)->getName();

    $literalName->setDataSourceType(DataSourceType::StringLiterals);
    $literalName->setData("LiteralString");

    $cellName = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $nameCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, "C1", "NewCell");
    $cellName->setDataSourceType(DataSourceType::Worksheet);
    $cellName->setData($nameCell);

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Deteksi Format Buku Kerja Terbenam yang Tidak Didukung**

Aspose.Slides tidak mendukung format buku kerja Excel biner (.xlsb) yang dapat terbenam pada beberapa grafik. Anda dapat menggunakan metode `getEmbeddedWorkbookType` pada [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewati grafik‑grafik tersebut. Contoh ini memeriksa bentuk‑bentuk pada slide pertama presentasi yang ada, melewati bentuk yang bukan grafik, dan mencetak pesan diagnostik untuk setiap grafik dengan buku kerja .xlsb yang terbenam.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartDataSourceType;
use aspose\slides\WorkbookType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
            continue;
        }

        $chart = $shape;
        $chartData = $chart->getChartData();
        $isInternalWorkbook = java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook;
        $isBinaryMacro = java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro;

        if ($isInternalWorkbook && $isBinaryMacro) {
            echo "Skipping a chart with an unsupported .xlsb workbook.", PHP_EOL;
            continue;
        }

        // Baca atau ubah data buku kerja grafik yang didukung di sini.
    }
} finally {
    $presentation->dispose();
}
```

## **Buku Kerja Eksternal**

Aspose.Slides mendukung penggunaan buku kerja eksternal sebagai sumber data untuk grafik.

### **Buat Buku Kerja Eksternal**

Gunakan [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) dan [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) untuk mengekspor buku kerja grafik yang terbenam ke file dan menautkan grafik ke buku kerja eksternal tersebut.

Contoh ini membuat grafik pai dengan data default dan mengekspor buku kerjanya. Ia menyelesaikan penulisan file sebelum menetapkan buku kerja eksternal sebagai sumber data grafik, lalu menyimpan presentasi yang ditautkan.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $workbookPath = new Java("java.io.File", "externalWorkbook1.xlsx");
    $workbookData = $chart->getChartData()->readWorkbookStream();
    try {
        $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
        try {
            $fileStream->write($workbookData);
        } finally {
            $fileStream->close();
        }
        $chart->getChartData()->setExternalWorkbook($workbookPath->getAbsolutePath());
        
        $presentation->save("externalWorkbook.pptx", SaveFormat::Pptx);
    } catch (JavaException $exception) {
        echo "Could not write the external workbook: " . $exception->getMessage(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Tetapkan Buku Kerja Eksternal**

Dengan metode [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/), Anda dapat menetapkan buku kerja eksternal ke grafik sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke buku kerja eksternal (jika buku kerja tersebut dipindahkan).

Meskipun Anda tidak dapat menyunting data dalam buku kerja yang disimpan di lokasi atau sumber daya jarak jauh, Anda tetap dapat menggunakan buku kerja tersebut sebagai sumber data eksternal. Jika jalur relatif untuk buku kerja eksternal diberikan, jalur tersebut akan secara otomatis diubah menjadi jalur penuh.

Contoh ini menggunakan buku kerja eksternal yang lembar kerjanya bernama `Sheet1` berisi nama seri di B1, nama kategori di A2:A4, dan nilai numerik di B2:B4. Contoh membuat grafik pai, menautkan buku kerja, dan menggunakan [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) untuk memetakan A1:B4 ke satu seri dan tiga kategori. Ia menyimpan presentasi dengan grafik yang ditautkan.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $workbookFile = new Java("java.io.File", "externalWorkbook.xlsx");
    $workbookPath = $workbookFile->getAbsolutePath();

    $chartData->setExternalWorkbook($workbookPath);
    $chartData->setRange('Sheet1!$A$1:$B$4');

    $presentation->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Parameter `updateChartData` pada metode [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) mengontrol apakah buku kerja dimuat.

* Ketika `updateChartData` bernilai `false`, hanya jalur buku kerja yang diperbarui. Data grafik tidak dimuat atau diperbarui dari buku kerja target, sehingga buku kerja dapat tidak tersedia.
* Ketika `updateChartData` bernilai `true`, data grafik diperbarui dari buku kerja target.

Contoh berikut menetapkan URL placeholder dengan `updateChartData` diset ke `false`. Ia mempertahankan data default grafik pai dan menyimpan presentasi tanpa memuat buku kerja yang tidak tersedia.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chart->getChartData()->setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    $presentation->save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Dapatkan Jalur Buku Kerja Sumber Data Eksternal dari Grafik**

Untuk mengidentifikasi buku kerja yang ditautkan ke grafik, periksa apakah grafik menggunakan sumber data eksternal dan ambil jalur bukunya.

Contoh ini memeriksa bentuk pertama pada slide pertama presentasi dengan buku kerja eksternal yang ditautkan. Jika bentuk tersebut adalah grafik yang ditautkan ke buku kerja eksternal, contoh mencetak [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) ke konsol. Kemudian ia menyimpan salinan presentasi.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ChartDataSourceType;

$presentation = new Presentation("externalWorkbook.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::ExternalWorkbook) {
            echo $chartData->getExternalWorkbookPath(), PHP_EOL;
        } else {
            echo "The chart does not use an external workbook.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Sunting Data Grafik**

Anda dapat menyunting data dalam buku kerja eksternal dengan cara yang sama seperti mengubah konten buku kerja internal. Ketika buku kerja eksternal tidak dapat dimuat, sebuah pengecualian akan dilemparkan.

Contoh ini menggunakan grafik yang merupakan bentuk pertama pada slide pertama dan ditautkan ke buku kerja eksternal yang dapat diakses. Ia menetapkan nilai berbasis sel dari titik data pertama pada seri pertama menjadi 100 dan menyimpan presentasi yang diperbarui. Menyunting nilai sel dapat memperbarui file XLSX eksternal yang ditautkan, jadi gunakan salinan jika Anda harus mempertahankan buku kerja asli.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $series = $chart->getChartData()->getSeries();
        if (java_values($series->size()) > 0 && java_values($series->get_Item(0)->getDataPoints()->size()) > 0) {
            $valueCell = $series->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell();
            if (!java_is_null($valueCell)) {
                $valueCell->setValue(100);
                $presentation->save("presentation_out.pptx", SaveFormat::Pptx);
            } else {
                echo "The first data point is not linked to a workbook cell.", PHP_EOL;
            }
        } else {
            echo "The chart has no data points to edit.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Pulihkan Buku Kerja dari Cache Grafik**

Jika sebuah grafik menggunakan buku kerja eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat merekonstruksi buku kerja grafik dari data yang di‑cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/), panggil [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/), dan setel [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) ke `true` sebelum membuka presentasi.

Contoh PHP berikut memulihkan data buku kerja untuk grafik yang merupakan bentuk pertama pada slide pertama dan merujuk ke buku kerja eksternal yang tidak tersedia. Ia mengakses data yang dipulihkan melalui [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) dan [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

```php
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;
use aspose\slides\LoadOptions;

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

        // Baca atau ubah data buku kerja yang dipulihkan di sini.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Jika buku kerja eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melemparkan pengecualian. Aktifkan pemulihan hanya ketika penggunaan data grafik yang di‑cache merupakan fallback yang dapat diterima, karena cache mungkin tidak berisi perubahan yang dibuat pada buku kerja eksternal setelah presentasi terakhir diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah grafik tertentu ditautkan ke buku kerja eksternal atau terbenam?**

Ya. Sebuah grafik memiliki [tipe sumber data](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) dan [jalur ke buku kerja eksternal](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); jika sumbernya adalah buku kerja eksternal, Anda dapat membaca jalur penuh untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke buku kerja eksternal didukung, dan bagaimana cara penyimpannya?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis diubah menjadi jalur absolut. Presentasi menyimpan jalur absolut dalam file PPTX, sehingga memindahkan buku kerja mungkin memerlukan pembaruan tautan.

**Bisakah saya menggunakan buku kerja yang berada di sumber daya/jaringan bersama?**

Ya, buku kerja tersebut dapat digunakan sebagai sumber data eksternal. Namun, penyuntingan buku kerja jarak jauh secara langsung dari Aspose.Slides tidak didukung — mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa XLSX eksternal saat menyimpan presentasi?**

Presentasi menyimpan [tautan ke file eksternal](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Menyunting data grafik berbasis sel juga dapat memperbarui file XLSX lokal yang ditautkan. Gunakan salinan buku kerja jika file asli harus tetap tidak berubah.

**Bagaimana jika file eksternal dilindungi kata sandi?**

Aspose.Slides tidak menerima kata sandi saat menautkan. Pendekatan umum adalah menghapus perlindungan terlebih dahulu atau menyiapkan salinan yang didekripsi (misalnya, menggunakan [Aspose.Cells](https://reference.aspose.com/cells/java/)) dan menautkan ke salinan tersebut.

**Dapatkah beberapa grafik merujuk ke buku kerja eksternal yang sama?**

Ya. Setiap grafik menyimpan tautannya masing‑masing. Jika semuanya menunjuk ke file yang sama, memperbarui file tersebut akan tercermin pada setiap grafik pada saat data dimuat berikutnya.