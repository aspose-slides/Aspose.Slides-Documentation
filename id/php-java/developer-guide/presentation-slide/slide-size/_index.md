---
title: Ubah Ukuran Slide Presentasi di PHP
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
- slide berukuran penuh
- tipe layar
- tidak skala
- pastikan pas
- maksimalkan
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara dengan cepat mengubah ukuran slide dalam file PPT, PPTX, dan ODP menggunakan PHP dan Aspose.Slides, mengoptimalkan presentasi untuk semua tipe layar tanpa mengurangi kualitas."
---
## **Pendahuluan**

Aspose.Slides menyediakan alat komprehensif untuk menyesuaikan ukuran slide dan rasio aspek dalam presentasi PowerPoint, yang penting untuk pencetakan maupun tampilan di layar.

Ukuran Slide dan Rasio yang Populer:

- **Standar (Rasio Aspek 4:3)**: Ideal untuk layar dan perangkat lama.
- **Layar Lebar (Rasio Aspek 16:9)**: Direkomendasikan untuk proyektor dan tampilan modern.

Pastikan konsistensi di seluruh presentasi karena satu ukuran slide dan rasio aspek berlaku untuk semua slide. Untuk hasil optimal, tetapkan dimensi slide di awal proses pembuatan presentasi guna menghindari komplikasi.

{{% alert color="info" title="Note" %}}
Secara default, presentasi yang dibuat dengan Aspose.Slides menggunakan rasio aspek standar 4:3.
{{% /alert %}}

Halaman catatan dan handout memiliki dimensi terpisah dari slide reguler. Lihat [Ukuran Halaman Catatan](/slides/id/php-java/notes-size/) untuk mengubah ukuran dan orientasinya.

## **Ubah Ukuran Slide dalam Presentasi**

Contoh kode ini menunjukkan cara mengubah ukuran slide dalam sebuah presentasi menggunakan Aspose.Slides:

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

Jika ukuran slide umum (4:3 dan 16:9) tidak sesuai dengan kebutuhan Anda, Anda dapat memutuskan untuk menggunakan ukuran slide yang spesifik atau unik. Misalnya, jika Anda berencana mencetak slide berukuran penuh dari presentasi Anda pada tata letak halaman kustom atau jika Anda ingin menampilkan presentasi pada tipe layar tertentu, Anda mungkin akan mendapatkan manfaat dari pengaturan ukuran kustom untuk presentasi Anda.

Contoh kode ini menunjukkan cara menggunakan Aspose.Slides untuk PHP via Java untuk menentukan ukuran slide kustom dalam sebuah presentasi:

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

Setelah Anda mengubah ukuran slide untuk sebuah presentasi, konten slide (gambar atau objek, misalnya) dapat menjadi terdistorsi. Secara default, objek-objek secara otomatis diubah ukurannya agar sesuai dengan ukuran slide baru. Namun, ketika mengubah ukuran slide presentasi, Anda dapat menentukan pengaturan yang menentukan bagaimana Aspose.Slides menangani konten pada slide.

Tergantung pada apa yang ingin Anda lakukan atau capai, Anda dapat menggunakan salah satu pengaturan berikut:

- `DoNotScale`

  Jika Anda **TIDAK** ingin objek pada slide diubah ukurannya, gunakan pengaturan ini.

- `EnsureFit`

  Jika Anda ingin memperkecil ukuran slide dan memerlukan Aspose.Slides untuk mengurangi ukuran objek slide sehingga semuanya muat di slide (dengan cara ini, Anda menghindari kehilangan konten), gunakan pengaturan ini.

- `Maximize`

  Jika Anda ingin memperbesar ukuran slide dan memerlukan Aspose.Slides untuk memperbesar objek slide agar proporsional dengan ukuran slide yang baru, gunakan pengaturan ini.

Contoh kode ini menunjukkan cara menggunakan pengaturan `Maximize` ketika mengubah ukuran slide sebuah presentasi:

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

## **Tanya Jawab**

**Apakah saya dapat mengatur ukuran slide kustom menggunakan satuan selain inci (misalnya poin atau milimeter)?**

Ya. Aspose.Slides menggunakan poin secara internal, di mana 1 poin sama dengan 1/72 inci. Anda dapat mengonversi satuan apa pun (seperti milimeter atau sentimeter) ke poin dan menggunakan nilai yang sudah dikonversi untuk mendefinisikan lebar dan tinggi slide.

**Apakah ukuran slide kustom yang sangat besar memengaruhi kinerja dan penggunaan memori selama rendering?**

Ya. Dimensi slide yang lebih besar (dalam poin) dikombinasikan dengan skala rendering yang lebih tinggi akan meningkatkan konsumsi memori dan memperpanjang waktu proses. Targetkan ukuran slide yang praktis dan sesuaikan skala rendering hanya bila diperlukan untuk mencapai kualitas output yang diinginkan.

**Dapatkah saya mendefinisikan satu ukuran slide non-standar lalu menggabungkan slide dari presentasi yang memiliki ukuran berbeda?**

Anda tidak dapat [merge presentations](/slides/id/php-java/merge-presentation/) ketika mereka memiliki ukuran slide yang berbeda — pertama, ubah ukuran salah satu presentasi agar cocok dengan yang lain. Saat mengubah ukuran slide, Anda dapat memilih cara menangani konten yang ada melalui opsi [SlideSizeScaleType](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidesizescaletype/). Setelah ukuran selaras, Anda dapat menggabungkan slide sambil mempertahankan format.

**Apakah saya dapat menghasilkan thumbnail untuk bentuk individual atau region tertentu pada slide, dan apakah mereka akan menghormati ukuran slide yang baru?**

Ya. Aspose.Slides dapat merender thumbnail untuk [entire slides](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#getImage) maupun untuk [selected shapes](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getImage). Gambar yang dihasilkan mencerminkan ukuran slide dan rasio aspek saat ini, memastikan bingkai dan geometri yang konsisten.