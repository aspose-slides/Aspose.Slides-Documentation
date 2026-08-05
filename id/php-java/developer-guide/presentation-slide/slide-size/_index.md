---
title: Ubah Ukuran Slide Presentasi dalam PHP
linktitle: Ukuran Slide
type: docs
weight: 70
url: /id/php-java/slide-size/
keywords:
- ukuran slide
- rasio aspek
- standar
- layar lebar
- 4:3
- 16:9
- atur ukuran slide
- ubah ukuran slide
- ukuran slide kustom
- ukuran slide khusus
- ukuran slide unik
- slide ukuran penuh
- tipe layar
- tidak berskala
- pastikan muat
- maksimalkan
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara dengan cepat mengubah ukuran slide dalam file PPT, PPTX, dan ODP menggunakan PHP dan Aspose.Slides, mengoptimalkan presentasi untuk layar apa pun tanpa mengurangi kualitas."
---
## **Pendahuluan**

Aspose.Slides menyediakan alat yang komprehensif untuk menyesuaikan ukuran slide dan rasio aspek dalam presentasi PowerPoint, penting untuk pencetakan maupun tampilan di layar.  

Ukuran Slide dan Rasio Populer:

- **Standard (4:3 Aspect Ratio)**: Ideal untuk layar dan perangkat lama.  
- **Widescreen (16:9 Aspect Ratio)**: Disarankan untuk proyektor dan tampilan modern.  

Pastikan konsistensi di seluruh presentasi Anda karena satu ukuran slide dan rasio aspek diterapkan pada semua slide. Untuk hasil optimal, atur dimensi slide di awal proses pembuatan presentasi untuk menghindari komplikasi.  

{{% alert color="primary" %}} 
Secara default, presentasi yang dibuat dengan Aspose.Slides menggunakan rasio aspek standar 4:3. 
{{% /alert %}}

## **Ubah Ukuran Slide dalam Presentasi**

Kode contoh ini menunjukkan cara mengubah ukuran slide dalam sebuah presentasi menggunakan Aspose.Slides:

```php
  $pres = new Presentation("pres-4x3-aspect-ratio.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
    $pres->save("pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tentukan Ukuran Slide Kustom dalam Presentasi**

Jika Anda menemukan ukuran slide umum (4:3 dan 16:9) tidak cocok untuk pekerjaan Anda, Anda dapat memutuskan untuk menggunakan ukuran slide yang spesifik atau unik. Misalnya, jika Anda berencana mencetak slide berukuran penuh dari presentasi Anda pada tata letak halaman khusus atau jika Anda ingin menampilkan presentasi pada tipe layar tertentu, Anda kemungkinan akan mendapat manfaat dengan menggunakan pengaturan ukuran kustom untuk presentasi Anda.  

Kode contoh ini menunjukkan cara menggunakan Aspose.Slides untuk PHP melalui Java untuk menentukan ukuran slide kustom untuk sebuah presentasi :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// Ukuran kertas A4

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tangani Konten Slide Setelah Mengubah Ukuran**

Setelah Anda mengubah ukuran slide untuk sebuah presentasi, konten slide (gambar atau objek, misalnya) dapat menjadi terdistorsi. Secara default, objek secara otomatis diubah ukurannya agar sesuai dengan ukuran slide baru. Namun, saat mengubah ukuran slide presentasi, Anda dapat menentukan pengaturan yang menentukan bagaimana Aspose.Slides menangani konten pada slide.  

Bergantung pada apa yang ingin Anda lakukan atau capai, Anda dapat menggunakan salah satu pengaturan berikut:

- `DoNotScale`

  Jika Anda TIDAK ingin objek pada slide diubah ukurannya, gunakan pengaturan ini.

- `EnsureFit`

  Jika Anda ingin memperkecil ukuran slide dan membutuhkan Aspose.Slides untuk mengecilkan objek slide agar semuanya muat pada slide (dengan cara ini, Anda menghindari kehilangan konten), gunakan pengaturan ini. 

- `Maximize`

  Jika Anda ingin memperbesar ukuran slide dan membutuhkan Aspose.Slides untuk memperbesar objek slide agar proporsional dengan ukuran slide baru, gunakan pengaturan ini. 

Kode contoh ini menunjukkan cara menggunakan pengaturan `Maximize` saat mengubah ukuran slide sebuah presentasi:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah saya dapat mengatur ukuran slide kustom menggunakan satuan selain inci (misalnya, poin atau milimeter)?**

Ya. Aspose.Slides menggunakan poin secara internal, di mana 1 poin sama dengan 1/72 inci. Anda dapat mengonversi satuan apa pun (seperti milimeter atau sentimeter) ke poin dan menggunakan nilai yang dikonversi untuk menentukan lebar dan tinggi slide.  

**Apakah ukuran slide kustom yang sangat besar akan memengaruhi kinerja dan penggunaan memori selama proses rendering?**

Ya. Dimensi slide yang lebih besar (dalam poin) yang dikombinasikan dengan skala rendering yang lebih tinggi menyebabkan peningkatan konsumsi memori dan waktu proses yang lebih lama. Tujuannya adalah menggunakan ukuran slide yang praktis dan menyesuaikan skala rendering hanya bila diperlukan untuk mencapai kualitas output yang diinginkan.  

**Apakah saya dapat mendefinisikan satu ukuran slide non-standar dan kemudian menggabungkan slide dari presentasi yang memiliki ukuran berbeda?**

Anda tidak dapat [merge presentations](/slides/id/php-java/merge-presentation/) ketika mereka memiliki ukuran slide yang berbeda — pertama, ubah ukuran satu presentasi agar cocok dengan yang lain. Saat mengubah ukuran slide, Anda dapat memilih cara menangani konten yang ada melalui opsi [SlideSizeScaleType](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidesizescaletype/). Setelah ukuran diselaraskan, Anda dapat menggabungkan slide sambil mempertahankan format.  

**Apakah saya dapat menghasilkan thumbnail untuk bentuk individu atau wilayah tertentu dari sebuah slide, dan apakah mereka akan menghormati ukuran slide yang baru?**

Ya. Aspose.Slides dapat merender thumbnail untuk [entire slides](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#getImage) serta untuk [selected shapes](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getImage). Gambar yang dihasilkan mencerminkan ukuran slide dan rasio aspek saat ini, memastikan bingkai dan geometri yang konsisten.