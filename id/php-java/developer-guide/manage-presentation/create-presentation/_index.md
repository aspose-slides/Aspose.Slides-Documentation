---
title: Buat Presentasi dalam PHP
linktitle: Buat Presentasi
type: docs
weight: 10
url: /id/php-java/create-presentation/
keywords:
- buat presentasi
- presentasi baru
- buat PPT
- PPT baru
- buat PPTX
- PPTX baru
- buat ODP
- ODP baru
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Buat presentasi dengan Aspose.Slides untuk PHP via Java — hasilkan file PPT, PPTX, dan ODP serta simpan secara programatis untuk hasil yang dapat diandalkan."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara membuat presentasi di Aspose.Slides, menambahkan konten sederhana ke sebuah slide, dan menyimpan hasilnya sebagai file. Artikel ini juga memperlihatkan cara membuat dan menyimpan presentasi baru, membuka presentasi yang ada dalam format yang didukung, dan menyimpannya ke format lain. Selain itu, artikel ini mencakup FAQ singkat yang membahas pertanyaan umum terkait format, templat, ukuran slide, satuan, penggunaan memori, threading, lisensi, tanda tangan digital, dan dukungan VBA.

## **Buat Presentasi**

Untuk menambahkan garis sederhana pada slide yang dipilih dalam presentasi, ikuti langkah-langkah berikut:

1. Buat instance dari kelas Presentation.
1. Dapatkan referensi slide dengan menggunakan Index-nya.
1. Tambahkan AutoShape tipe Line dengan menggunakan metode addAutoShape yang disediakan oleh objek Shapes.
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah menambahkan garis ke slide pertama presentasi.

```php
  # Membuat objek Presentation yang merepresentasikan file presentasi
  $pres = new Presentation();
  try {
    # Dapatkan slide pertama
    $slide = $pres->getSlides()->get_Item(0);
    # Tambahkan autoshape tipe garis
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Format apa saja yang dapat saya simpan untuk presentasi baru?**

Anda dapat menyimpan ke [PPTX, PPT, dan ODP](/slides/id/php-java/save-presentation/), dan mengekspor ke [PDF](/slides/id/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/id/php-java/convert-powerpoint-to-xps/), [HTML](/slides/id/php-java/convert-powerpoint-to-html/), [SVG](/slides/id/php-java/convert-powerpoint-to-png/), serta [images](/slides/id/php-java/convert-powerpoint-to-png/), di antara lainnya.

**Apakah saya dapat memulai dari templat (POTX/POTM) dan menyimpannya sebagai PPTX biasa?**

Ya. Muat templat dan simpan ke format yang diinginkan; format POTX/POTM/PPTM dan format serupa [didukung](/slides/id/php-java/supported-file-formats/).

**Bagaimana cara mengontrol ukuran/rasio aspek slide saat membuat presentasi?**

Atur [ukuran slide](/slides/id/php-java/slide-size/) (termasuk preset seperti 4:3 dan 16:9 atau dimensi khusus) dan pilih bagaimana konten harus diskalakan.

**Dalam satuan apa ukuran dan koordinat diukur?**

Dalam poin: 1 inci sama dengan 72 unit.

**Bagaimana saya menangani presentasi yang sangat besar (dengan banyak file media) untuk mengurangi penggunaan memori?**

Gunakan [strategi manajemen BLOB](/slides/id/php-java/manage-blob/), batasi penyimpanan dalam memori dengan memanfaatkan file sementara, dan lebih pilih alur kerja berbasis file daripada alur murni dalam memori.

**Apakah saya dapat membuat/menyimpan presentasi secara paralel?**

Anda tidak dapat mengoperasikan instance [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) yang sama dari [beberapa thread](/slides/id/php-java/multithreading/). Jalankan instance terpisah dan terisolasi per thread atau proses.

**Bagaimana cara menghapus watermark percobaan dan batasan?**

[Terapkan lisensi](/slides/id/php-java/licensing/) sekali per proses. XML lisensi harus tetap tidak diubah, dan pengaturan lisensi harus disinkronkan jika ada banyak thread yang terlibat.

**Apakah saya dapat menandatangani digital PPTX yang saya buat?**

Ya. [tanda tangan digital](/slides/id/php-java/digital-signature-in-powerpoint/) (menambahkan dan memverifikasi) didukung untuk presentasi.

**Apakah makro (VBA) didukung dalam presentasi yang dibuat?**

Ya. Anda dapat [buat/edit proyek VBA](/slides/id/php-java/presentation-via-vba/) dan menyimpan file yang mendukung makro seperti PPTM/PPSM.