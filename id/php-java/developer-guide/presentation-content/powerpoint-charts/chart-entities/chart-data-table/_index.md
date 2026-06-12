---
title: Sesuaikan Tabel Data Grafik dalam Presentasi Menggunakan PHP
linktitle: Tabel Data
type: docs
url: /id/php-java/chart-data-table/
keywords:
- data grafik
- tabel data
- properti font
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Sesuaikan tabel data grafik untuk PPT dan PPTX dengan Aspose.Slides untuk PHP via Java guna meningkatkan efisiensi dan daya tarik dalam presentasi."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan tabel data grafik di Aspose.Slides. Artikel ini menunjukkan cara menampilkan tabel data untuk sebuah grafik dan menyesuaikan pemformatan teksnya dengan mengatur properti font seperti gaya tebal dan tinggi font. Contoh ini mendemonstrasikan memuat presentasi, menambahkan grafik, mengaktifkan tabel data grafik, menerapkan pengaturan font, dan menyimpan presentasi yang telah diperbarui.

Artikel ini juga menyertakan jawaban singkat untuk pertanyaan umum tentang menampilkan kunci legenda di tabel data grafik, mempertahankan tabel data saat ekspor, bekerja dengan grafik yang dimuat dari presentasi atau templat yang sudah ada, serta mengidentifikasi grafik di mana tabel data diaktifkan.

## **Mengatur Properti Font untuk Tabel Data Grafik**
Aspose.Slides for PHP via Java menyediakan dukungan untuk mengubah warna kategori dalam warna seri.

1. Membuat objek kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Menambahkan grafik pada slide.
1. Mengatur tabel grafik.
1. Menetapkan tinggi font.
1. Menyimpan presentasi yang dimodifikasi.

Contoh sampel di bawah diberikan.

```php
  # Membuat presentasi kosong
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah saya dapat menampilkan kunci legenda kecil di sebelah nilai dalam tabel data grafik?**

Ya. Tabel data mendukung [legend keys](https://reference.aspose.com/slides/id/php-java/aspose.slides/datatable/setshowlegendkey/), dan Anda dapat mengaktifkan atau menonaktifkannya.

**Apakah tabel data akan dipertahankan saat mengekspor presentasi ke PDF, HTML, atau gambar?**

Ya. Aspose.Slides merender grafik sebagai bagian dari slide, sehingga [PDF](/slides/id/php-java/convert-powerpoint-to-pdf/)/[HTML](/slides/id/php-java/convert-powerpoint-to-html/)/[image](/slides/id/php-java/convert-powerpoint-to-png/) yang diekspor menyertakan grafik beserta tabel datanya.

**Apakah tabel data didukung untuk grafik yang berasal dari file templat?**

Ya. Untuk setiap grafik yang dimuat dari presentasi atau templat yang ada, Anda dapat memeriksa dan mengubah apakah tabel data [ditampilkan](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/hasdatatable/) menggunakan properti grafik tersebut.

**Bagaimana saya dapat dengan cepat menemukan grafik mana dalam file yang memiliki tabel data diaktifkan?**

Periksa properti masing‑masing grafik yang menunjukkan apakah tabel data [ditampilkan](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/hasdatatable/) dan iterasi melalui slide‑slide untuk mengidentifikasi grafik yang mengaktifkan tabel data.