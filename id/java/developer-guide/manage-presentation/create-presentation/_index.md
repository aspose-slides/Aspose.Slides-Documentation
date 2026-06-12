---
title: Buat Presentasi di Java
linktitle: Buat Presentasi
type: docs
weight: 10
url: /id/java/create-presentation/
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
- Java
- Aspose.Slides
description: "Buat presentasi di Java dengan Aspose.Slides—hasilkan file PPT, PPTX, dan ODP, manfaatkan dukungan OpenDocument, dan simpan secara programatik untuk hasil yang andal."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara membuat presentasi di Aspose.Slides, menambahkan konten sederhana ke sebuah slide, dan menyimpan hasilnya sebagai file. Artikel ini juga memperlihatkan cara membuat dan menyimpan presentasi baru, membuka presentasi yang ada dalam format yang didukung, dan menyimpannya ke format lain. Selain itu, artikel ini menyertakan FAQ singkat yang mencakup pertanyaan umum terkait format, templat, ukuran slide, satuan, penggunaan memori, threading, lisensi, tanda tangan digital, dan dukungan VBA.

## **Buat Presentasi**

Membuat file PowerPoint dari awal di Aspose.Slides untuk Java sesederhana menginstansiasi kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/). Konstruktor secara otomatis menyediakan dek kosong dengan satu slide, memberi Anda kanvas langsung untuk bentuk, teks, diagram, atau konten lain yang dibutuhkan aplikasi Anda. Setelah Anda memodifikasi slide itu—atau menambahkan slide baru—Anda dapat menyimpan hasilnya ke format PPTX, PPT lama, atau bahkan format OpenDocument. Contoh kode singkat di bawah ini menggambarkan alur kerja ini dengan menambahkan bentuk sederhana ke slide pertama.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan objek [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) bertipe `Cloud` menggunakan metode `addAutoShape` yang disediakan oleh koleksi `Shapes`.
1. Tambahkan teks ke auto-shape.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Dalam contoh di bawah, bentuk awan ditambahkan ke slide pertama presentasi.

```java
// Instansiasi kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto-shape tipe Cloud.
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    // Simpan presentasi sebagai file PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Presentasi baru](new_presentation.png)

## **FAQ**

**Format apa yang dapat saya simpan untuk presentasi baru?**

Anda dapat menyimpan ke [PPTX, PPT, dan ODP](/slides/id/java/save-presentation/), dan mengekspor ke [PDF](/slides/id/java/convert-powerpoint-to-pdf/), [XPS](/slides/id/java/convert-powerpoint-to-xps/), [HTML](/slides/id/java/convert-powerpoint-to-html/), [SVG](/slides/id/java/convert-powerpoint-to-png/), dan [gambar](/slides/id/java/convert-powerpoint-to-png/), di antara lainnya.

**Apakah saya dapat memulai dari templat (POTX/POTM) dan menyimpannya sebagai PPTX biasa?**

Ya. Muat templat dan simpan ke format yang diinginkan; format POTX/POTM/PPTM dan format serupa [didukung](/slides/id/java/supported-file-formats/).

**Bagaimana cara mengontrol ukuran/rasio aspek slide saat membuat presentasi?**

Atur [slide size](/slides/id/java/slide-size/) (termasuk preset seperti 4:3 dan 16:9 atau dimensi khusus) dan pilih bagaimana konten harus diskalakan.

**Dalam satuan apa ukuran dan koordinat diukur?**

Dalam poin: 1 inci sama dengan 72 unit.

**Bagaimana cara menangani presentasi yang sangat besar (dengan banyak file media) untuk mengurangi penggunaan memori?**

Gunakan [BLOB management strategies](/slides/id/java/manage-blob/), batasi penyimpanan dalam memori dengan memanfaatkan file sementara, dan lebih pilih alur kerja berbasis file daripada alur kerja murni dalam memori.

**Apakah saya dapat membuat/menyimpan presentasi secara paralel?**

Anda tidak dapat mengoperasikan instance [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) yang sama dari [beberapa thread](/slides/id/java/multithreading/). Jalankan instance terpisah yang terisolasi per thread atau proses.

**Bagaimana cara menghapus watermark percobaan dan batasan?**

[Apply a license](/slides/id/java/licensing/) sekali per proses. XML lisensi harus tetap tidak diubah, dan pengaturan lisensi harus disinkronkan jika beberapa thread terlibat.

**Apakah saya dapat menandatangani digital PPTX yang saya buat?**

Ya. [Digital signatures](/slides/id/java/digital-signature-in-powerpoint/) (menambahkan dan memverifikasi) didukung untuk presentasi.

**Apakah macro (VBA) didukung dalam presentasi yang dibuat?**

Ya. Anda dapat [create/edit VBA projects](/slides/id/java/presentation-via-vba/) dan menyimpan file yang mendukung macro seperti PPTM/PPSM.