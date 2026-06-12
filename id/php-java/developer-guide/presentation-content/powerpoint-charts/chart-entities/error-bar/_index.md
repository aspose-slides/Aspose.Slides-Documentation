---
title: "Kustomisasi Batang Galat dalam Diagram Presentasi Menggunakan PHP"
linktitle: "Batang Galat"
type: docs
url: /id/php-java/error-bar/
keywords:
- batang galat
- nilai khusus
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara menambahkan dan menyesuaikan batang galat dalam diagram dengan Aspose.Slides for PHP via Java — optimalkan visual data dalam presentasi PowerPoint."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan batang galat dalam diagram presentasi dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara menambahkan batang galat ke seri diagram, mengonfigurasi pengaturan batang galat X dan Y, serta menerapkan berbagai jenis nilai seperti nilai tetap, persentase, dan nilai khusus.

Ini juga memperagakan cara menetapkan nilai batang galat khusus untuk titik data individu dalam sebuah seri dengan menggunakan koleksi titik data yang bersangkutan. Selain itu, artikel ini menyertakan catatan singkat tentang bagaimana batang galat berperilaku selama ekspor, kompatibilitasnya dengan penanda dan label data, serta tempat menemukan kelas dan enum referensi API terkait.

## **Menambahkan Batang Galat**
Aspose.Slides for PHP via Java menyediakan API sederhana untuk mengelola nilai batang galat. Kode contoh berlaku ketika menggunakan jenis nilai khusus. Untuk menentukan nilai, gunakan properti **ErrorBarCustomValues** dari titik data tertentu dalam koleksi [**data points**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartseriescollection/) seri:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Tambahkan diagram gelembung pada slide yang diinginkan.
1. Akses seri diagram pertama dan atur format batang galat X.
1. Akses seri diagram pertama dan atur format batang galat Y.
1. Atur nilai batang dan formatnya.
1. Tulis presentasi yang telah dimodifikasi ke file PPTX.

```php
  # Buat instance dari kelas Presentation
  $pres = new Presentation();
  try {
    # Membuat diagram gelembung
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Menambahkan batang galat dan mengatur formatnya
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # Menyimpan presentasi
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menambahkan Nilai Batang Galat Khusus**
Aspose.Slides for PHP via Java menyediakan API sederhana untuk mengelola nilai batang galat khusus. Kode contoh berlaku ketika metode [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/id/php-java/aspose.slides/errorbarsformat/#getValueType) mengembalikan **Custom**. Untuk menentukan nilai, gunakan properti **ErrorBarCustomValues** dari titik data tertentu dalam koleksi [**data points**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartseriescollection/) seri:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Tambahkan diagram gelembung pada slide yang diinginkan.
1. Akses seri diagram pertama dan atur format batang galat X.
1. Akses seri diagram pertama dan atur format batang galat Y.
1. Akses titik data individu pada seri diagram dan atur nilai Batang Galat untuk setiap titik data seri.
1. Atur nilai batang dan formatnya.
1. Tulis presentasi yang telah dimodifikasi ke file PPTX.

```php
  # Buat instance dari kelas Presentation
  $pres = new Presentation();
  try {
    # Membuat diagram gelembung
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Menambahkan batang galat kustom dan mengatur formatnya
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # Mengakses titik data seri diagram dan mengatur nilai batang galat untuk
    # titik individu
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # Mengatur batang galat untuk titik-titik seri diagram
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # Menyimpan presentasi
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apa yang terjadi pada batang galat saat mengekspor presentasi ke PDF atau gambar?**

Mereka dirender sebagai bagian dari diagram dan dipertahankan selama konversi bersama dengan seluruh format diagram, dengan asumsi versi atau renderer yang kompatibel.

**Apakah batang galat dapat digabungkan dengan penanda dan label data?**

Ya. Batang galat adalah elemen terpisah dan kompatibel dengan penanda serta label data; jika elemen saling tumpang tindih, Anda mungkin perlu menyesuaikan formatnya.

**Di mana saya dapat menemukan daftar properti dan kelas untuk bekerja dengan batang galat dalam API?**

Di referensi API: kelas [ErrorBarsFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/errorbarsformat/) dan kelas terkait [ErrorBarType](https://reference.aspose.com/slides/id/php-java/aspose.slides/errorbartype/) serta [ErrorBarValueType](https://reference.aspose.com/slides/id/php-java/aspose.slides/errorbarvaluetype/).