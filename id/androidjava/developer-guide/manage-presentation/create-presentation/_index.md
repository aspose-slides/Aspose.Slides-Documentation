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
description: "Buat presentasi dalam Java dengan Aspose.Slides untuk Android—hasilkan file PPT, PPTX, dan ODP, manfaatkan dukungan OpenDocument, serta simpan secara programatik untuk hasil yang dapat diandalkan."
---
## **Ikhtisar**

Artikel ini menunjukkan cara membuat presentasi di Aspose.Slides untuk Android melalui Java, menambahkan kotak teks ke slide pertama, dan menyimpan hasilnya sebagai file di penyimpanan aplikasi Anda. Untuk membuka presentasi yang sudah ada atau menyimpannya dalam format lain, lihat [Open Presentation](/slides/id/androidjava/open-presentation/) dan [Save Presentation](/slides/id/androidjava/save-presentation/). FAQ singkat di akhir mencakup pertanyaan umum tentang format, templat, ukuran slide, satuan, penggunaan memori, threading, lisensi, tanda tangan digital, dan dukungan VBA.

Sebelum memulai, tambahkan Aspose.Slides ke proyek Android Anda dari repositori Maven Aspose. Lihat [Installation](/slides/id/androidjava/install-aspose-slides-for-android-via-java/).

## **Buat Presentasi PowerPoint**

Untuk membuat presentasi dan menambahkan kotak teks pada slide pertama, ikuti langkah‑langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/). Presentasi baru sudah berisi satu slide kosong.  
2. Dapatkan slide tersebut dari [slide collection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidecollection/) dengan indeksnya, 0.  
3. Tambahkan persegi panjang dengan metode [addAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) pada [shape collection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/) dan setel teks pada [text frame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/)‑nya menggunakan metode [setText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-).  
4. Simpan presentasi sebagai file PPTX dengan metode [save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) dalam format [SaveFormat.Pptx](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/saveformat/).

Kode dijalankan di dalam sebuah `Activity`, misalnya pada metode `onCreate`. Itu menyimpan file ke direktori yang dikembalikan oleh metode [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) : penyimpanan privat aplikasi Anda, yang dapat ditulis tanpa meminta izin apapun.

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sudut kiri‑atas persegi panjang berada 50 point dari tepi kiri dan 50 point dari tepi atas slide, dan persegi panjang tersebut berukuran 400 point lebar dan 100 point tinggi. File yang disimpan berisi satu slide dengan persegi panjang dan teksnya. Tanpa lisensi, Aspose.Slides juga menambahkan watermark evaluasi pada setiap slide yang disimpan; lihat [Licensing](/slides/id/androidjava/licensing/).

Untuk melihat file tersebut, buka [Device Explorer](https://developer.android.com/studio/debug/device-file-explorer) di Android Studio dan temukan *hello.pptx* di bawah *data/data/*, pada folder *files* aplikasi Anda. Pada aplikasi nyata, proses presentasi pada thread latar belakang agar antarmuka pengguna tetap responsif.

## **FAQ**

### Format apa saja yang dapat saya gunakan untuk menyimpan presentasi baru?

Anda dapat menyimpan ke [PPTX, PPT, dan ODP](/slides/id/androidjava/save-presentation/), dan mengekspor ke [PDF](/slides/id/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/id/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/id/androidjava/convert-powerpoint-to-html/), [SVG](/slides/id/androidjava/render-a-slide-as-an-svg-image/), serta [gambar](/slides/id/androidjava/convert-powerpoint-to-png/), dan lain‑lain.

### Dapatkah saya memulai dari templat (POTX/POTM) dan menyimpannya sebagai PPTX biasa?

Ya. Muat templat tersebut dan simpan ke format yang diinginkan; format POTX/POTM/PPTM dan format serupa [didukung](/slides/id/androidjava/supported-file-formats/).

### Bagaimana cara mengontrol ukuran/rasio aspek slide saat membuat presentasi?

Atur [ukuran slide](/slides/id/androidjava/slide-size/) (termasuk preset seperti 4:3 dan 16:9 atau dimensi khusus) dan pilih bagaimana konten harus diskalakan.

### Dalam satuan apa ukuran dan koordinat diukur?

Dalam point: 1 inci sama dengan 72 unit.

### Bagaimana cara menangani presentasi yang sangat besar (dengan banyak file media) untuk mengurangi penggunaan memori?

Gunakan [strategi manajemen BLOB](/slides/id/androidjava/manage-blob/), batasi penyimpanan di memori dengan memanfaatkan file temporer, dan lebih pilih alur kerja berbasis file daripada aliran murni di memori.

### Dapatkah saya membuat/menyimpan presentasi secara paralel?

Anda tidak dapat mengoperasikan instance [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) yang sama dari [multiple threads](/slides/id/androidjava/multithreading/). Jalankan instance terpisah dan terisolasi per thread atau proses.

### Bagaimana cara menghapus watermark percobaan dan batasan?

[Apply a license](/slides/id/androidjava/licensing/) sekali per proses. File XML lisensi harus tetap tidak diubah, dan penyiapan lisensi harus disinkronkan jika ada banyak thread.

### Dapatkah saya menandatangani secara digital PPTX yang saya buat?

Ya. [Digital signatures](/slides/id/androidjava/digital-signature-in-powerpoint/) (penambahan dan verifikasi) didukung untuk presentasi.

### Apakah macro (VBA) didukung dalam presentasi yang dibuat?

Ya. Anda dapat [create/edit VBA projects](/slides/id/androidjava/presentation-via-vba/) dan menyimpan file yang mendukung macro seperti PPTM/PPSM.