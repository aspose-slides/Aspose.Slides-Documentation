---
title: Kelola Buku Kerja Diagram dalam Presentasi Menggunakan PHP
linktitle: Buku Kerja Diagram
type: docs
weight: 70
url: /id/php-java/chart-workbook/
keywords:
- buku kerja diagram
- data diagram
- sel buku kerja
- label data
- lembar kerja
- sumber data
- buku kerja eksternal
- data eksternal
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Temukan Aspose.Slides untuk PHP via Java: kelola buku kerja diagram secara mudah dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan buku kerja diagram di Aspose.Slides. Ini menunjukkan cara membaca dan menulis data diagram melalui aliran buku kerja, menggunakan sel buku kerja sebagai label data diagram, mengakses koleksi lembar kerja, dan menentukan tipe sumber data untuk nilai diagram.

Ini juga mencakup penggunaan buku kerja eksternal sebagai sumber data diagram. Contoh-contoh menunjukkan cara membuat dan menetapkan buku kerja eksternal, mengambil jalur buku kerja eksternal yang terhubung ke diagram, serta mengedit data diagram ketika buku kerja tersedia.

## **Baca dan Tulis Data Diagram dari Buku Kerja**

Aspose.Slides menyediakan metode [readWorkbookStream](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/#readWorkbookStream) dan [writeWorkbookStream](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/#writeWorkbookStream) yang memungkinkan Anda membaca dan menulis buku kerja data diagram (yang berisi data diagram yang diedit dengan Aspose.Cells). **Catatan** bahwa data diagram harus diatur dengan cara yang sama atau memiliki struktur yang mirip dengan sumbernya.

Kode PHP ini menunjukkan operasi contoh:

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

## **Menetapkan Sel Buku Kerja sebagai Label Data Diagram**

1. Buat instance dari kelas [Presentation](https://apireference.aspose.com/slides/id/php-java/aspose.slides/presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram Bubble dengan beberapa data.
4. Akses seri diagram.
5. Tetapkan sel buku kerja sebagai label data.
6. Simpan presentasi.

Kode PHP ini menunjukkan cara menetapkan sel buku kerja sebagai label data diagram:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Membuat instance kelas presentasi yang mewakili file presentasi
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

## **Mengelola Lembar Kerja**

Kode PHP ini menunjukkan operasi di mana metode [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdataworkbook/#getWorksheets) digunakan untuk mengakses koleksi lembar kerja:

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

## **Menentukan Tipe Sumber Data**

Kode PHP ini menunjukkan cara menentukan tipe untuk sumber data:

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

## **Mendeteksi Format Buku Kerja Tersemat yang Tidak Didukung**

Aspose.Slides tidak mendukung format buku kerja Excel biner (.xlsb) yang dapat tersemat dalam beberapa diagram. Anda dapat menggunakan metode `getEmbeddedWorkbookType` pada [ChartData](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/id/php-java/aspose.slides/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewati diagram tersebut.

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
      # Buku kerja tersemat berformat .xlsb, yang tidak didukung.
      continue;
    }

    # Baca atau ubah data buku kerja diagram di sini.
  }
} finally {
  $presentation->dispose();
}
```

## **Buku Kerja Eksternal**

Aspose.Slides mendukung buku kerja eksternal sebagai sumber data untuk diagram.

### **Membuat Buku Kerja Eksternal**

Menggunakan metode **`readWorkbookStream`** dan **`setExternalWorkbook`**, Anda dapat membuat buku kerja eksternal dari awal atau menjadikan buku kerja internal menjadi eksternal.

Kode PHP ini menunjukkan proses pembuatan buku kerja eksternal:

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

### **Menetapkan Buku Kerja Eksternal**

Dengan metode **`setExternalWorkbook`**, Anda dapat menetapkan buku kerja eksternal ke diagram sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke buku kerja eksternal (jika buku kerja tersebut telah dipindahkan).

Meskipun Anda tidak dapat mengedit data dalam buku kerja yang disimpan di lokasi atau sumber daya remote, Anda tetap dapat menggunakan buku kerja tersebut sebagai sumber data eksternal. Jika jalur relatif untuk buku kerja eksternal diberikan, jalur tersebut secara otomatis dikonversi menjadi jalur penuh.

Kode PHP ini menunjukkan cara menetapkan buku kerja eksternal:

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

Parameter `ChartData` (di bawah metode `setExternalWorkbook`) digunakan untuk menentukan apakah buku kerja Excel akan dimuat atau tidak.

* Ketika nilai `ChartData` diatur ke `false`, hanya jalur buku kerja yang diperbarui — data diagram tidak akan dimuat atau diperbarui dari buku kerja target. Gunakan pengaturan ini bila buku kerja target tidak ada atau tidak tersedia.
* Ketika nilai `ChartData` diatur ke `true`, data diagram diperbarui dari buku kerja target.

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

### **Mendapatkan Jalur Buku Kerja Sumber Data Eksternal dari Diagram**

1. Buat instance dari kelas [Presentation](https://apireference.aspose.com/slides/id/php-java/aspose.slides/presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Buat objek untuk bentuk diagram.
4. Buat objek untuk tipe sumber (`ChartDataSourceType`) yang mewakili sumber data diagram.
5. Tentukan kondisi yang relevan berdasarkan tipe sumber yang sama dengan tipe sumber data buku kerja eksternal.

Kode PHP ini menunjukkan operasi tersebut:

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

### **Mengedit Data Diagram**

Anda dapat mengedit data dalam buku kerja eksternal dengan cara yang sama seperti mengubah isi buku kerja internal. Ketika buku kerja eksternal tidak dapat dimuat, sebuah pengecualian akan dilempar.

Kode PHP ini merupakan implementasi proses yang dijelaskan:

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

## **FAQ**

**Apakah saya dapat menentukan apakah sebuah diagram terhubung ke buku kerja eksternal atau tersemat?**

Ya. Sebuah diagram memiliki [tipe sumber data](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/getdatasourcetype/) dan [jalur ke buku kerja eksternal](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/getexternalworkbookpath/); jika sumbernya adalah buku kerja eksternal, Anda dapat membaca jalur penuh untuk memastikan file eksternal digunakan.

**Apakah jalur relatif ke buku kerja eksternal didukung, dan bagaimana cara penyimpanannya?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis dikonversi menjadi jalur absolut. Ini memudahkan portabilitas proyek; namun, presentasi akan menyimpan jalur absolut dalam file PPTX.

**Dapatkah saya menggunakan buku kerja yang berada pada sumber daya jaringan/berbagi?**

Ya, buku kerja tersebut dapat digunakan sebagai sumber data eksternal. Namun, mengedit buku kerja remote langsung dari Aspose.Slides tidak didukung — mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**

Tidak. Presentasi menyimpan [tautan ke file eksternal](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdata/getexternalworkbookpath/) dan menggunakannya untuk membaca data. File eksternal itu sendiri tidak diubah saat presentasi disimpan.

**Apa yang harus saya lakukan jika file eksternal dilindungi kata sandi?**

Aspose.Slides tidak menerima kata sandi saat menautkan. Pendekatan umum adalah menghapus perlindungan terlebih dahulu atau menyiapkan salinan yang telah didekripsi (misalnya, menggunakan [Aspose.Cells](/cells/php-java/)) dan menautkan ke salinan tersebut.

**Dapatkah beberapa diagram merujuk ke buku kerja eksternal yang sama?**

Ya. Setiap diagram menyimpan tautannya masing‑masing. Jika semuanya menunjuk ke file yang sama, memperbarui file tersebut akan tercermin pada setiap diagram saat data dimuat kembali.