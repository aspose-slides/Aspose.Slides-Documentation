---
title: Buat Presentasi di Android
linktitle: Buat Presentasi
type: docs
weight: 10
url: /id/androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Buat presentasi dalam Java dengan Aspose.Slides untuk Android—hasilkan file PPT, PPTX, dan ODP, manfaatkan dukungan OpenDocument, dan simpan secara programatik untuk hasil yang dapat diandalkan."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara membuat presentasi di Aspose.Slides, menambahkan konten sederhana ke sebuah slide, dan menyimpan hasilnya sebagai file. Artikel ini juga menunjukkan cara membuat dan menyimpan presentasi baru, membuka presentasi yang ada dalam format yang didukung, dan menyimpannya ke format lain.

## **Buat Presentasi PowerPoint**
Untuk menambahkan garis sederhana ke slide yang dipilih dalam presentasi, ikuti langkah-langkah di bawah ini:

1. Buat instance dari kelas Presentation.
1. Dapatkan referensi slide dengan menggunakan Index-nya.
1. Tambahkan AutoShape tipe Line menggunakan metode addAutoShape yang disediakan oleh objek Shapes.
1. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Dalam contoh di bawah ini, kami telah menambahkan garis ke slide pertama presentasi.

```java
// Instansiasi objek Presentation yang mewakili file presentasi
Presentation pres = new Presentation();
try {
    // Dapatkan slide pertama
    ISlide slide = pres.getSlides().get_Item(0);

    // Tambahkan autoshape tipe garis
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tanya Jawab**

**Format apa yang dapat saya simpan untuk presentasi baru?**

Anda dapat menyimpan ke [PPTX, PPT, dan ODP](/slides/id/androidjava/save-presentation/), dan mengekspor ke [PDF](/slides/id/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/id/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/id/androidjava/convert-powerpoint-to-html/), [SVG](/slides/id/androidjava/convert-powerpoint-to-png/), dan [images](/slides/id/androidjava/convert-powerpoint-to-png/), di antara lainnya.

**Apakah saya dapat memulai dari template (POTX/POTM) dan menyimpan sebagai PPTX biasa?**

Ya. Muat template dan simpan ke format yang diinginkan; format POTX/POTM/PPTM dan format serupa [didukung](/slides/id/androidjava/supported-file-formats/).

**Bagaimana cara mengontrol ukuran/rasio aspek slide saat membuat presentasi?**

Atur [slide size](/slides/id/androidjava/slide-size/) (termasuk preset seperti 4:3 dan 16:9 atau dimensi khusus) dan pilih bagaimana konten harus diskalakan.

**Dalam satuan apa ukuran dan koordinat diukur?**

Dalam poin: 1 inci sama dengan 72 unit.

**Bagaimana cara menangani presentasi yang sangat besar (dengan banyak berkas media) untuk mengurangi penggunaan memori?**

Gunakan [strategi manajemen BLOB](/slides/id/androidjava/manage-blob/), batasi penyimpanan dalam memori dengan memanfaatkan berkas sementara, dan pilih alur kerja berbasis berkas daripada alur kerja yang sepenuhnya dalam memori.

**Apakah saya dapat membuat/menyimpan presentasi secara paralel?**

Anda tidak dapat mengoperasikan [Presentasi]https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/ yang sama dari [beberapa thread](/slides/id/androidjava/multithreading/). Jalankan instance terpisah yang terisolasi per thread atau proses.

**Bagaimana cara menghapus watermark percobaan dan batasan?**

[Terapkan lisensi](/slides/id/androidjava/licensing/) sekali per proses. XML lisensi harus tetap tidak diubah, dan penyiapan lisensi harus disinkronkan jika ada banyak thread yang terlibat.

**Apakah saya dapat menandatangani secara digital PPTX yang saya buat?**

Ya. [Tanda tangan digital](/slides/id/androidjava/digital-signature-in-powerpoint/) (penambahan dan verifikasi) didukung untuk presentasi.

**Apakah makro (VBA) didukung dalam presentasi yang dibuat?**

Ya. Anda dapat [buat/edit proyek VBA](/slides/id/androidjava/presentation-via-vba/) dan menyimpan berkas yang mendukung makro seperti PPTM/PPSM.