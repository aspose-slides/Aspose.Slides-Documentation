---
title: Dapatkan Seluruh Latar Belakang Slide dari Presentasi sebagai Gambar
linktitle: Seluruh Latar Belakang Slide
type: docs
weight: 95
url: /id/php-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- latar belakang slide
- latar belakang akhir
- ekstrak latar belakang
- latar belakang lengkap
- latar belakang menjadi gambar
- latar belakang PPT
- latar belakang PPTX
- latar belakang ODP
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Ekstrak latar belakang slide penuh sebagai gambar dari presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk PHP via Java, menyederhanakan alur kerja visual."
---
## **Gambaran Umum**

Dalam presentasi PowerPoint, latar belakang slide dapat dibentuk dari beberapa elemen, termasuk gambar latar belakang slide, tema presentasi, skema warna, dan objek yang ditempatkan di master slide atau layout slide.

Artikel ini menunjukkan cara mengekstrak seluruh latar belakang slide sebagai gambar menggunakan Aspose.Slides. Karena tidak ada metode tunggal untuk tugas ini, pendekatannya melibatkan penggandaan slide yang dipilih ke dalam presentasi sementara, menghapus bentuk-bentuk slide, dan kemudian mengonversi latar belakang slide yang dihasilkan menjadi gambar.

## **Dapatkan Seluruh Latar Belakang Slide**

Aspose.Slides untuk PHP via Java tidak menyediakan metode sederhana untuk mengekstrak seluruh latar belakang slide presentasi sebagai gambar, tetapi Anda dapat mengikuti langkah-langkah di bawah ini untuk melakukannya:
1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Dapatkan ukuran slide dari presentasi.
1. Pilih sebuah slide.
1. Buat presentasi sementara.
1. Atur ukuran slide yang sama pada presentasi sementara.
1. Gandakan slide yang dipilih ke dalam presentasi sementara.
1. Hapus bentuk-bentuk dari slide yang digandakan.
1. Konversi slide yang digandakan menjadi gambar.

Contoh kode berikut mengekstrak seluruh latar belakang slide presentasi sebagai gambar.
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```

## **FAQ**

**Apakah gradien kompleks, tekstur, atau isian gambar dari master slide akan dipertahankan dalam gambar latar belakang yang dihasilkan?**

Ya. Aspose.Slides merender isian gradien, gambar, dan tekstur yang didefinisikan pada slide, layout, atau master. Jika Anda perlu memisahkan tampilan dari master yang diwarisi, [atur latar belakang sendiri](/slides/id/php-java/presentation-background/) pada slide saat ini sebelum mengekspor.

**Bisakah saya menambahkan watermark ke gambar latar belakang yang dihasilkan sebelum menyimpannya?**

Ya. Anda dapat [tambahkan watermark](/slides/id/php-java/watermark/) berupa bentuk atau gambar pada [salinan slide](/slides/id/php-java/clone-slides/) kerja (ditempatkan di belakang konten lain) dan kemudian mengekspor. Ini memungkinkan Anda menghasilkan gambar latar belakang dengan watermark yang sudah tertanam.

**Bisakah saya mendapatkan latar belakang untuk layout atau master tertentu tanpa mengaitkannya dengan slide yang ada?**

Ya. Akses master atau layout yang diinginkan, terapkan pada [slide sementara](/slides/id/php-java/clone-slides/) dengan ukuran yang diperlukan, dan ekspor slide tersebut untuk memperoleh latar belakang yang dihasilkan dari layout atau master itu.

**Apakah ada batasan lisensi yang memengaruhi ekspor gambar?**

Fitur rendering sepenuhnya tersedia dengan [lisensi yang valid](/slides/id/php-java/licensing/). Dalam mode evaluasi, output mungkin memiliki batasan seperti watermark. Aktifkan lisensi sekali per proses sebelum menjalankan ekspor batch.