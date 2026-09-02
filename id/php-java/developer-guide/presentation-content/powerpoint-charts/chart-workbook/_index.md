---
title: Kelola Workbook Diagram dalam Presentasi Menggunakan PHP
linktitle: Workbook Diagram
type: docs
weight: 70
url: /id/php-java/chart-workbook/
keywords:
- workbook diagram
- data diagram
- sel buku kerja
- label data
- lembar kerja
- sumber data
- buku kerja eksternal
- data eksternal
- cache diagram
- pemulihan buku kerja
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Temukan Aspose.Slides untuk PHP via Java: kelola workbook diagram dengan mudah dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Ringkasan**

Artikel ini menjelaskan cara bekerja dengan workbook diagram di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data diagram melalui aliran workbook, menggunakan sel workbook sebagai label data diagram, mengakses koleksi worksheet, dan menentukan tipe sumber data untuk nilai diagram.

Artikel ini juga mencakup cara bekerja dengan workbook eksternal sebagai sumber data diagram. Contoh‑contoh menunjukkan cara membuat dan menetapkan workbook eksternal, mengambil jalur workbook eksternal yang terhubung ke diagram, serta mengedit data diagram ketika workbook tersedia.

## **Baca dan Tulis Data Diagram dari Workbook**
Aspose.Slides menyediakan metode [readWorkbookStream](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/#readWorkbookStream) dan [writeWorkbookStream](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/#writeWorkbookStream) yang memungkinkan Anda membaca dan menulis workbook data diagram (yang berisi data diagram yang diedit dengan Aspose.Cells). **Catatan** bahwa data diagram harus diatur dengan cara yang sama atau memiliki struktur yang mirip dengan sumbernya.

Kode PHP berikut menunjukkan contoh operasi:

```php
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $data = $chart->getChartData();
    $stream = $data->readWorkbookStream();
    $data->getSeries()->clear();
    $data->getCategories()->clear();
    $data->writeWorkbookStream($stream);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Set Sel WorkBook sebagai Label Data Diagram**

1. Buat sebuah instance dari kelas [Presentation](https://apireference.aspose.com/slides/id/php-java/aspose.slides/presentation).
1. Dapatkan referensi slide melalui indeksnya.
1. Tambahkan diagram Bubble dengan beberapa data.
1. Akses seri diagram.
1. Tetapkan sel workbook sebagai label data.
1. Simpan presentasi.

Kode PHP berikut menunjukkan cara menetapkan sel workbook sebagai label data diagram:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Menginstansiasi kelas presentasi yang mewakili file presentasi
  $pres = new Presentation("chart2.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $dataLabelCollection = $series->get_Item(0)->getLabels();
    $dataLabelCollection->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $dataLabelCollection->get_Item(0)->setValueFromCell($wb->getCell(0, "A10", $lbl0));
    $dataLabelCollection->get_Item(1)->setValueFromCell($wb->getCell(0, "A11", $lbl1));
    $dataLabelCollection->get_Item(2)->setValueFromCell($wb->getCell(0, "A12", $lbl2));
    $pres->save("resultchart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Kelola Worksheet**

Kode PHP berikut mendemonstrasikan operasi dimana metode [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdataworkbook/#getWorksheets) digunakan untuk mengakses koleksi worksheet:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    for($i = 0; $i < java_values($wb->getWorksheets()->size()) ; $i++) {
      echo($wb->getWorksheets()->get_Item($i)->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tentukan Tipe Sumber Data**

Kode PHP berikut menunjukkan cara menentukan tipe untuk sebuah sumber data:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $val = $chart->getChartData()->getSeries()->get_Item(0)->getName();
    $val->setDataSourceType(DataSourceType::StringLiterals);
    $val->setData("LiteralString");
    $val = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $val->setData($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1", "NewCell"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Deteksi Format Workbook Tersemat yang Tidak Didukung**

Aspose.Slides tidak mendukung format workbook biner Excel (.xlsb) yang dapat disematkan dalam beberapa diagram. Anda dapat menggunakan metode `getEmbeddedWorkbookType` pada [ChartData](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/id/php-java/aspose.slides/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewati diagram‑diagram tersebut.

```php
$presentation = new Presentation("sample.pptx");
try {
  $slide = $presentation->getSlides()->get_Item(0);
  $shapes = $slide->getShapes();

  for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
    $shape = $shapes->get_Item($shapeIndex);

    if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
      continue;
    }

    $chart = $shape;
    $chartData = $chart->getChartData();

    if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook &&
        java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro) {
      # Workbook tersemat berada dalam format .xlsb, yang tidak didukung.
      continue;
    }

    # Baca atau ubah data workbook diagram di sini.
  }
} finally {
  $presentation->dispose();
}
```

## **Workbook Eksternal**

Aspose.Slides mendukung workbook eksternal sebagai sumber data untuk diagram.

### **Buat Workbook Eksternal**

Dengan menggunakan metode **`readWorkbookStream`** dan **`setExternalWorkbook`**, Anda dapat membuat workbook eksternal dari awal atau menjadikan workbook internal menjadi eksternal.

Kode PHP berikut mendemonstrasikan proses pembuatan workbook eksternal:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $workbookPath = "externalWorkbook1.xlsx";
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
    $Array = new java_class("java.lang.reflect.Array");
    try {
      $workbookData = $chart->getChartData()->readWorkbookStream();
      $fileStream->write($workbookData, 0, $Array->getLength($workbookData));
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
    $chart->getChartData()->setExternalWorkbook($workbookPath);
    $pres->save("externalWorkbook.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Set Workbook Eksternal**

Dengan menggunakan metode **`setExternalWorkbook`**, Anda dapat menetapkan workbook eksternal ke sebuah diagram sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke workbook eksternal (jika workbook tersebut telah dipindahkan).

Meskipun Anda tidak dapat mengedit data dalam workbook yang disimpan di lokasi atau sumber daya remote, Anda masih dapat menggunakan workbook tersebut sebagai sumber data eksternal. Jika jalur relatif untuk workbook eksternal diberikan, jalur tersebut akan otomatis dikonversi menjadi jalur penuh.

Kode PHP berikut menunjukkan cara menetapkan workbook eksternal:

```php
  # Membuat instance dari kelas Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, false);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("externalWorkbook.xlsx");
    $chartData->getSeries()->add($chartData->getChartDataWorkbook()->getCell(0, "B1"), ChartType::Pie);
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B2"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B3"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B4"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A2"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A3"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A4"));
    $pres->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Parameter `ChartData` (di bawah metode `setExternalWorkbook`) digunakan untuk menentukan apakah workbook Excel akan dimuat atau tidak. 

* Ketika nilai `ChartData` diset ke `false`, hanya jalur workbook yang diperbarui—data diagram tidak akan dimuat atau diperbarui dari workbook target. Anda dapat menggunakan pengaturan ini ketika workbook target tidak ada atau tidak tersedia. 
* Ketika nilai `ChartData` diset ke `true`, data diagram akan diperbarui dari workbook target.

```php
  # Membuat instance dari kelas Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("http://path/doesnt/exists", false);
    $pres->save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Dapatkan Jalur Workbook Sumber Data Eksternal dari Diagram**

1. Buat sebuah instance dari kelas [Presentation](https://apireference.aspose.com/slides/id/php-java/aspose.slides/presentation).
1. Dapatkan referensi slide melalui indeksnya.
1. Buat objek untuk bentuk diagram.
1. Buat objek untuk tipe sumber (`ChartDataSourceType`) yang merepresentasikan sumber data diagram.
1. Tentukan kondisi yang relevan berdasarkan tipe sumber yang sama dengan tipe sumber data workbook eksternal.

Kode PHP berikut mendemonstrasikan operasi tersebut:

```php
  # Membuat instance dari kelas Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # Menyimpan presentasi
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Edit Data Diagram**

Anda dapat mengedit data dalam workbook eksternal dengan cara yang sama seperti mengubah isi workbook internal. Ketika workbook eksternal tidak dapat dimuat, sebuah eksepsi akan dilempar.

Kode PHP berikut merupakan implementasi proses yang dijelaskan:

```php
  # Membuat instance dari kelas Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chartData = $chart->getChartData();
    $chartData->getSeries()->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell()->setValue(100);
    $pres->save("presentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Pulihkan Workbook dari Cache Diagram**

Jika sebuah diagram menggunakan workbook eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat merekonstruksi workbook diagram dari data yang di‑cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/), konfigurasikan dengan [SpreadsheetOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/spreadsheetoptions/), dan panggil [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/id/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) dengan `true` sebelum membuka presentasi.

Contoh PHP berikut membuka presentasi yang referensi diagramnya mengarah ke workbook eksternal yang tidak tersedia dan mengakses data yang dipulihkan melalui [Chart::getChartData](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/#getChartData) serta [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/#getChartDataWorkbook):

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # Baca atau ubah data workbook yang dipulihkan di sini.
} finally {
    $presentation->dispose();
}
```

Jika workbook eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melempar eksepsi. Aktifkan pemulihan hanya ketika menggunakan data diagram yang di‑cache merupakan solusi yang dapat diterima, karena cache mungkin tidak berisi perubahan yang dilakukan pada workbook eksternal setelah presentasi terakhir diperbarui.

## **Tanya Jawab**

**Apakah saya dapat menentukan apakah sebuah diagram tertentu terhubung ke workbook eksternal atau tersemat?**

Ya. Diagram memiliki [tipe sumber data](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/getdatasourcetype/) dan [jalur ke workbook eksternal](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/getexternalworkbookpath/); jika sumbernya adalah workbook eksternal, Anda dapat membaca jalur lengkap untuk memastikan bahwa file eksternal sedang digunakan.

**Apakah jalur relatif ke workbook eksternal didukung, dan bagaimana cara penyimpanannya?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis dikonversi menjadi jalur absolut. Ini memudahkan portabilitas proyek; namun, perlu diketahui bahwa presentasi akan menyimpan jalur absolut di dalam file PPTX.

**Apakah saya dapat menggunakan workbook yang berada di sumber daya jaringan/berbagi?**

Ya, workbook tersebut dapat digunakan sebagai sumber data eksternal. Namun, pengeditan workbook remote secara langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa XLSX eksternal saat menyimpan presentasi?**

Tidak. Presentasi menyimpan sebuah [tautan ke file eksternal](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/getexternalworkbookpath/) dan menggunakannya untuk membaca data. File eksternal itu sendiri tidak diubah saat presentasi disimpan.

**Apa yang harus saya lakukan jika file eksternal dilindungi password?**

Aspose.Slides tidak menerima password saat membuat tautan. Pendekatan umum adalah menghapus perlindungan terlebih dahulu atau menyiapkan salinan yang telah didekripsi (misalnya menggunakan [Aspose.Cells](/cells/php-java/)) dan menautkan ke salinan tersebut.

**Dapatkah beberapa diagram merujuk ke workbook eksternal yang sama?**

Ya. Setiap diagram menyimpan tautannya masing‑masing. Jika semuanya menunjuk ke file yang sama, memperbarui file tersebut akan tercermin pada setiap diagram pada saat data dimuat berikutnya.