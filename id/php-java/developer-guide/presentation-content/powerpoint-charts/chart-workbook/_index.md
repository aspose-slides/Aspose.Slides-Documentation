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

Artikel ini juga mencakup kerja dengan buku kerja eksternal sebagai sumber data grafik. Contoh-contoh menunjukkan cara membuat dan menetapkan buku kerja eksternal, mendapatkan jalur buku kerja eksternal yang terhubung ke sebuah grafik, dan mengedit data grafik ketika buku kerja tersedia.

Untuk sel buku kerja yang mewakili data yang hilang, lihat [Kontrol Penampilan Sel Kosong](/slides/id/php-java/chart-series/) untuk perbedaan antara sel kosong dan nol, serta perbandingan grafik garis dari mode tampilan yang tersedia.

## **Sertakan Data dari Baris dan Kolom Tersembunyi**

Gunakan [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/setplotvisiblecellsonly/) untuk mengontrol apakah sebuah grafik memplot data dari baris dan kolom lembar kerja yang tersembunyi. Atur ke `true` untuk memplot hanya sel yang terlihat, atau `false` untuk menyertakan sel yang terlihat dan tersembunyi. Pengaturan ini mengontrol pemplotan grafik; tidak menyembunyikan atau menampilkan kembali baris atau kolom lembar kerja.

Unduh [hidden-source-data.pptx](hidden-source-data.pptx) dan letakkan di direktori kerja. Slide pertama berisi grafik kolom sebagai bentuk pertama. Lembar kerja yang tertanam, `Sheet1`, berisi rentang sumber berikut, `A1:C4`. Baris 3 dan kolom C tersembunyi, tetapi selnya masih berisi nilai.

| Baris lembar kerja | A: Bulan | B: Retail | C: Wholesale (kolom tersembunyi) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Akses sel sumber melalui [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/getchartdataworkbook/) dan baca [ChartDataCell::isHidden](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatacell/ishidden/) untuk memeriksa status tersembunyi mereka. Metode ini melaporkan status tersembunyi tanpa mengubahnya. Dalam file ini, B2 terlihat, B3 berada di baris tersembunyi, dan C2 berada di kolom tersembunyi; contoh mencetak `false`, `true`, dan `true` secara berurutan.

Untuk contoh ini, segarkan data grafik setelah mengubah pengaturan pemplotan: pertahankan buku kerja tertanam dengan [readWorkbookStream](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/readworkbookstream/) dan muat ulang dengan [writeWorkbookStream](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/writeworkbookstream/). Saat menyertakan semua sel, juga gunakan [setRange](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/setrange/) untuk memulihkan rentang lengkap, termasuk kategori Februari yang tersembunyi. Mengubah flag saja tidak cukup untuk menyegarkan data grafik yang di‑cache serta label kategori pada contoh ini.

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

            // Segarkan data grafik dari buku kerja yang tertanam.
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

Contoh menyimpan `hidden_cells_true.pptx` dengan hanya nilai Retail yang terlihat (10 dan 20), dan `hidden_cells_false.pptx` dengan semua enam nilai. Gambar di bawah mengilustrasikan dua mode pemplotan. Baris 3 dan kolom C tetap tersembunyi di kedua buku kerja yang tertanam.

| Hanya sel yang terlihat (`true`) | Semua sel (`false`) |
| --- | --- |
| ![Hanya sel yang terlihat: nilai Retail 10 dan 20 untuk Januari dan Maret.](hidden_cells_True.png) | ![Semua sel: nilai Retail dan Wholesale untuk Januari, Februari, dan Maret.](hidden_cells_False.png) |

Sebuah sel tersembunyi yang berisi nilai berbeda dari sel kosong. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/setdisplayblanksas/) mengontrol cara nilai yang hilang ditampilkan; tidak menyertakan atau mengecualikan data sumber yang tersembunyi. Lihat [Kontrol Penampilan Sel Kosong](/slides/id/php-java/chart-series/#control-the-display-of-empty-cells) untuk contoh.

## **Baca dan Tulis Data Grafik dari Buku Kerja**

Aspose.Slides for PHP via Java menyediakan metode [readWorkbookStream](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/readworkbookstream/) dan [writeWorkbookStream](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/writeworkbookstream/) yang memungkinkan Anda membaca dan menulis buku kerja data grafik (yang berisi data grafik yang diedit dengan Aspose.Cells). **Catatan** bahwa data grafik harus diatur dengan cara yang sama atau harus memiliki struktur serupa dengan sumbernya.

Contoh ini membuka `chart.pptx`, yang harus berisi sebuah grafik sebagai bentuk pertama pada slide pertama. Ia membaca buku kerja tertanam ke dalam array byte, menghapus seri dan kategori yang ada, dan menulis kembali buku kerja yang sama. Perubahan tetap di memori; contoh tidak menyimpan presentasi.

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

Ketika Anda mengganti buku kerja tertanam dengan buku kerja yang telah dimodifikasi, grafik tetap mempertahankan koleksi seri dan kategori aslinya. Ketidaksesuaian ini dapat menyebabkan [Chart::validateChartLayout](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/validatechartlayout/) gagal dengan kesalahan indeks di luar jangkauan. Hapus seri dan kategori yang ada sebelum menulis kembali buku kerja yang diperbarui ke grafik. Contoh ini memerlukan `chart.pptx` dengan grafik sebagai bentuk pertama pada slide pertama. Komentar menandai tempat pengeditan buku kerja; contoh yang dapat dijalankan menulis kembali buku kerja asli dan memvalidasi tata letak di memori.

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

Menghapus koleksi menghilangkan referensi data usang sebelum buku kerja ditulis kembali. Bangun kembali mapping seri dan kategori yang diperlukan untuk buku kerja yang diperbarui sebelum menggunakan grafik.

## **Setel Sel Buku Kerja sebagai Label Data Grafik**

Anda dapat menggunakan teks dari sel buku kerja sebagai label data grafik. Langkah‑langkah berikut menunjukkan cara menautkan label pada grafik gelembung ke sel dalam buku kerja datanya.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2. Akses slide pertama berdasarkan indeks berbasis nol.
3. Tambahkan grafik gelembung dengan data default.
4. Akses seri grafik.
5. Setel sel buku kerja sebagai label data.
6. Simpan presentasi.

Contoh ini membuka `chart2.pptx`, yang harus berisi setidaknya satu slide, dan menambahkan grafik gelembung dengan data default. Ia menggunakan sel A10:A12 pada lembar kerja 0 untuk tiga label pertama dalam seri pertama, mengaktifkan label dari sel, dan menyimpan hasil ke `resultchart.pptx`.

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

Metode [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdataworkbook/getworksheets/) menyediakan akses ke lembar kerja dalam sebuah buku kerja grafik. Contoh ini membuat grafik pai dengan data default dan mencetak setiap nama lembar kerja ke konsol.

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

Contoh ini membuat grafik kolom 3D dengan data default dan menetapkan dua nama seri menggunakan sumber data yang berbeda. Nama pertama menggunakan literal string; nama kedua menggunakan sel C1 pada lembar kerja 0. Enumerasi [DataSourceType](https://reference.aspose.com/slides/id/php-java/aspose.slides/datasourcetype/) memilih sumber untuk setiap nama. Hasil disimpan ke `pres.pptx`.

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

## **Deteksi Format Buku Kerja Tertanam yang Tidak Didukung**

Aspose.Slides tidak mendukung format buku kerja Excel biner (.xlsb) yang dapat tertanam dalam beberapa grafik. Anda dapat menggunakan metode `getEmbeddedWorkbookType` pada [ChartData](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/) bersama enumerasi [WorkbookType](https://reference.aspose.com/slides/id/php-java/aspose.slides/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewatkan grafik tersebut. Contoh ini memeriksa bentuk pada slide pertama `sample.pptx`, melewatkan bentuk yang bukan grafik, dan mencetak pesan diagnostik untuk setiap grafik dengan buku kerja .xlsb yang tertanam.

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

Gunakan [readWorkbookStream](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/readworkbookstream/) dan [setExternalWorkbook](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/setexternalworkbook/) untuk mengekspor buku kerja grafik yang tertanam ke sebuah file dan menautkan grafik ke buku kerja eksternal tersebut.

Contoh ini membuat grafik pai dengan data default, menulis buku kerjanya ke `externalWorkbook1.xlsx`, dan menyelesaikan penulisan file sebelum menetapkan file tersebut sebagai sumber data grafik. Ia menyimpan presentasi yang ditautkan ke `externalWorkbook.pptx`.

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

Dengan menggunakan metode [setExternalWorkbook](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/setexternalworkbook/), Anda dapat menetapkan buku kerja eksternal ke sebuah grafik sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke buku kerja eksternal (jika buku kerja tersebut telah dipindahkan).

Meskipun Anda tidak dapat mengedit data dalam buku kerja yang disimpan di lokasi atau sumber daya remote, Anda tetap dapat menggunakan buku kerja tersebut sebagai sumber data eksternal. Jika jalur relatif untuk buku kerja eksternal diberikan, jalur tersebut secara otomatis diubah menjadi jalur lengkap.

Contoh ini memerlukan `externalWorkbook.xlsx` di direktori kerja. Lembar kerja bernama `Sheet1` harus berisi nama seri di B1, nama kategori di A2:A4, dan nilai numerik di B2:B4. Contoh membuat grafik pai, menautkan buku kerja, dan menggunakan [setRange](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/setrange/) untuk memetakan A1:B4 ke satu seri dan tiga kategori. Hasil disimpan ke `Presentation_with_externalWorkbook.pptx`.

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

Parameter `updateChartData` pada metode [setExternalWorkbook](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/setexternalworkbook/) mengontrol apakah buku kerja dimuat.

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

### **Dapatkan Jalur Buku Kerja Sumber Data Eksternal dari Sebuah Grafik**

Untuk mengidentifikasi buku kerja yang ditautkan ke sebuah grafik, pertama periksa apakah grafik menggunakan sumber data eksternal. Jika ya, Anda dapat mengambil jalur buku kerja dengan mengikuti langkah‑langkah berikut.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2. Akses slide pertama berdasarkan indeks berbasis nol.
3. Periksa bahwa bentuk pertama adalah grafik.
4. Baca tipe sumber data grafik.
5. Jika sumbernya adalah buku kerja eksternal, baca jalurnya.

Contoh ini membuka `externalWorkbook.pptx`, yang dibuat pada contoh sebelumnya, dan memeriksa bentuk pertama pada slide pertama. Jika itu adalah grafik yang ditautkan ke buku kerja eksternal, contoh mencetak [getExternalWorkbookPath](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/getexternalworkbookpath/) ke konsol. Kemudian ia menyimpan salinan presentasi ke `Result.pptx`.

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

### **Edit Data Grafik**

Anda dapat mengedit data dalam buku kerja eksternal dengan cara yang sama seperti mengubah isi buku kerja internal. Ketika sebuah buku kerja eksternal tidak dapat dimuat, sebuah pengecualian akan dilempar.

Contoh ini memerlukan `presentation.pptx` dengan sebuah grafik sebagai bentuk pertama pada slide pertama dan buku kerja eksternal yang dapat diakses. Ia menetapkan nilai sel‑berbasis untuk titik data pertama dalam seri pertama menjadi 100 dan menyimpan presentasi ke `presentation_out.pptx`. Mengedit nilai sel dapat memperbarui file XLSX eksternal yang ditautkan, jadi gunakan salinan jika Anda perlu mempertahankan buku kerja asli.

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

Jika sebuah grafik menggunakan buku kerja eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat merekonstruksi buku kerja grafik dari data yang di‑cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/), panggil [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/setspreadsheetoptions/), dan setel [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/id/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) ke `true` sebelum membuka presentasi.

Contoh PHP berikut membuka `presentation.pptx`, yang bentuk pertama pada slide pertamanya harus berupa grafik yang merujuk ke buku kerja eksternal yang tidak tersedia, dan mengakses data yang dipulihkan melalui [Chart::getChartData](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/getchartdata/) dan [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/getchartdataworkbook/) :

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

Jika buku kerja eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melempar pengecualian. Aktifkan pemulihan hanya ketika penggunaan data grafik yang di‑cache merupakan alternatif yang dapat diterima, karena cache mungkin tidak berisi perubahan yang dibuat pada buku kerja eksternal setelah presentasi terakhir diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah sebuah grafik tertentu ditautkan ke buku kerja eksternal atau tertanam?**

Ya. Grafik memiliki [tipe sumber data](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/getdatasourcetype/) dan [jalur ke buku kerja eksternal](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/getexternalworkbookpath/); jika sumbernya adalah buku kerja eksternal, Anda dapat membaca jalur lengkap untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke buku kerja eksternal didukung, dan bagaimana cara penyimpanannya?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis diubah menjadi jalur absolut. Presentasi menyimpan jalur absolut dalam file PPTX, sehingga memindahkan buku kerja mungkin memerlukan pembaruan tautan.

**Bisakah saya menggunakan buku kerja yang berada di sumber daya/jaringan bersama?**

Ya, buku kerja tersebut dapat digunakan sebagai sumber data eksternal. Namun, mengedit buku kerja remote secara langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**

Presentasi menyimpan [tautan ke file eksternal](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Mengedit data grafik yang didasarkan pada sel juga dapat memperbarui file XLSX lokal yang ditautkan. Gunakan salinan buku kerja jika yang asli harus tetap tidak berubah.

**Bagaimana jika file eksternal dilindungi sandi?**

Aspose.Slides tidak menerima sandi saat menautkan. Pendekatan umum adalah menghapus proteksi terlebih dahulu atau menyiapkan salinan yang telah didekripsi (misalnya, menggunakan [Aspose.Cells](https://reference.aspose.com/cells/java/)) dan menautkan ke salinan tersebut.

**Dapatkah beberapa grafik merujuk ke buku kerja eksternal yang sama?**

Ya. Setiap grafik menyimpan tautannya masing‑masing. Jika semuanya menunjuk ke file yang sama, memperbarui file tersebut akan tercermin pada setiap grafik saat data dimuat berikutnya.