---
title: Buat Presentasi di JavaScript
linktitle: Buat Presentasi
type: docs
weight: 10
url: /id/nodejs-java/create-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat presentasi dengan Aspose.Slides—hasilkan file PPT, PPTX, dan ODP, manfaatkan dukungan OpenDocument, dan simpan secara programatik untuk hasil yang dapat diandalkan."
---
## **Ikhtisar**

Artikel ini menunjukkan cara membuat presentasi di Aspose.Slides, menambahkan konten sederhana ke slide, dan menyimpan hasilnya sebagai file.

## **Buat Presentasi PowerPoint**

Untuk menambahkan garis sederhana ke slide yang dipilih dalam presentasi, ikuti langkah-langkah berikut:

1. Buat instance kelas Presentation.
1. Dapatkan referensi slide dengan menggunakan Indeksnya.
1. Tambahkan AutoShape bertipe Garis menggunakan metode addAutoShape yang disediakan oleh objek Shapes.
1. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Dalam contoh di bawah, kami telah menambahkan sebuah garis ke slide pertama dari presentasi.

```javascript
// Instansiasi objek Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation();
try {
    // Ambil slide pertama
    var slide = pres.getSlides().get_Item(0);
    // Tambahkan autoshape tipe garis
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tanya Jawab**

**Format apa yang dapat saya simpan untuk presentasi baru?**

Anda dapat menyimpan ke [PPTX, PPT, dan ODP](/slides/id/nodejs-java/save-presentation/), dan mengekspor ke [PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/id/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/id/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/id/nodejs-java/convert-powerpoint-to-png/), serta [images](/slides/id/nodejs-java/convert-powerpoint-to-png/), di antara lainnya.

**Apakah saya dapat memulai dari templat (POTX/POTM) dan menyimpannya sebagai PPTX biasa?**

Ya. Muat templat tersebut dan simpan ke format yang diinginkan; format POTX/POTM/PPTM dan format serupa [didukung](/slides/id/nodejs-java/supported-file-formats/).

**Bagaimana cara mengontrol ukuran/aspek rasio slide saat membuat presentasi?**

Atur [ukuran slide](/slides/id/nodejs-java/slide-size/) (termasuk preset seperti 4:3 dan 16:9 atau dimensi khusus) dan pilih bagaimana konten harus diskalakan.

**Dalam satuan apa ukuran dan koordinat diukur?**

Dalam poin: 1 inci sama dengan 72 unit.

**Bagaimana cara menangani presentasi sangat besar (dengan banyak file media) untuk mengurangi penggunaan memori?**

Gunakan [strategi manajemen BLOB](/slides/id/nodejs-java/manage-blob/), batasi penyimpanan dalam memori dengan memanfaatkan file sementara, dan lebih memilih alur kerja berbasis file daripada aliran murni dalam memori.

**Apakah saya dapat membuat/menyimpan presentasi secara paralel?**

Anda tidak dapat mengoperasikan instance [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) yang sama dari [multiple threads](/slides/id/nodejs-java/multithreading/). Jalankan instance terpisah dan terisolasi per thread atau proses.

**Bagaimana cara menghapus watermark percobaan dan batasan?**

[Terapkan lisensi](/slides/id/nodejs-java/licensing/) sekali per proses. XML lisensi harus tetap tidak diubah, dan pengaturan lisensi harus disinkronkan jika melibatkan multiple threads.

**Apakah saya dapat menandatangani secara digital PPTX yang saya buat?**

Ya. [Tanda tangan digital](/slides/id/nodejs-java/digital-signature-in-powerpoint/) (penambahan dan verifikasi) didukung untuk presentasi.

**Apakah makro (VBA) didukung dalam presentasi yang dibuat?**

Ya. Anda dapat [membuat/mengedit proyek VBA](/slides/id/nodejs-java/presentation-via-vba/) dan menyimpan file yang mendukung makro seperti PPTM/PPSM.