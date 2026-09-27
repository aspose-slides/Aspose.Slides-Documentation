---
title: Buat Presentasi dalam JavaScript
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
description: "Buat presentasi dengan Aspose.Slides—hasilkan file PPT, PPTX, dan ODP, manfaatkan dukungan OpenDocument, dan simpan secara programatik untuk hasil yang andal."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara membuat presentasi di Aspose.Slides, menambahkan kotak teks ke slide pertama, dan menyimpan hasilnya sebagai file.

Sebelum memulai, instal paket `aspose.slides.via.java` dari npm, bersama dengan JDK, Python, dan alat build C++ yang diperlukan. Lihat [Installation](/slides/id/nodejs-java/installation/).

## **Buat Presentasi PowerPoint**

Untuk membuat presentasi dan menempatkan kotak teks pada slide pertama, ikuti langkah‑langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Presentasi baru sudah berisi satu slide kosong.
1. Dapatkan slide tersebut dari [slide collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) dengan indeks 0.
1. Tambahkan persegi panjang dengan metode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addautoshape/) dan atur teksnya dengan [setText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/settext/).
1. Simpan presentasi sebagai file PPTX dengan metode [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/).
1. Bebaskan presentasi dengan metode [dispose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/dispose/), dan akhiri proses.

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides berjalan di dalam mesin virtual Java yang membuat Node.js tetap berjalan, sehingga proses perlu dihentikan secara eksplisit.
process.exit(0);
```

Sudut kiri atas persegi panjang berada 50 poin dari tepi kiri dan 50 poin dari tepi atas slide, dan persegi panjang tersebut berukuran 400 poin lebar serta 100 poin tinggi. Simpan kode sebagai *hello.js* di folder proyek Anda dan jalankan `node hello.js`: itu akan menyimpan *hello.pptx*, dengan satu slide yang berisi persegi panjang dan teksnya, di folder saat ini.

Aspose.Slides berjalan di dalam mesin virtual Java yang dimulai oleh paket `java` di dalam proses Node.js. Mesin virtual tersebut mencegah Node.js keluar secara otomatis setelah skrip selesai, sehingga contoh berakhir dengan `process.exit(0)`.

Tanpa lisensi, Aspose.Slides juga menambahkan watermark evaluasi pada setiap slide yang disimpan; lihat [Licensing](/slides/id/nodejs-java/licensing/).

## **FAQ**

### What formats can I save a new presentation to?

Anda dapat menyimpan ke [PPTX, PPT, and ODP](/slides/id/nodejs-java/save-presentation/), dan mengekspor ke [PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/id/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/id/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/id/nodejs-java/render-a-slide-as-an-svg-image/), serta [images](/slides/id/nodejs-java/convert-powerpoint-to-png/), di antara lainnya.

### Can I start from a template (POTX/POTM) and save as a regular PPTX?

Ya. Muat templat tersebut dan simpan ke format yang diinginkan; format POTX/POTM/PPTM dan format serupa [are supported](/slides/id/nodejs-java/supported-file-formats/).

### How do I control slide size/aspect ratio when creating a presentation?

Atur [slide size](/slides/id/nodejs-java/slide-size/) (termasuk preset seperti 4:3 dan 16:9 atau dimensi khusus) dan pilih bagaimana konten harus diskalakan.

### In what units are sizes and coordinates measured?

Dalam poin: 1 inci sama dengan 72 unit.

### How do I handle very large presentations (with many media files) to reduce memory usage?

Gunakan [BLOB management strategies](/slides/id/nodejs-java/manage-blob/), batasi penyimpanan dalam memori dengan memanfaatkan file sementara, dan lebih pilih alur kerja berbasis file daripada alur aliran murni dalam memori.

### Can I create/save presentations in parallel?

Anda tidak dapat mengoperasikan instance [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) yang sama dari [multiple threads](/slides/id/nodejs-java/multithreading/). Jalankan instance terpisah dan terisolasi per thread atau proses.

### How do I remove the trial watermark and limitations?

[Apply a license](/slides/id/nodejs-java/licensing/) sekali per proses. XML lisensi harus tetap tidak diubah, dan penyiapan lisensi harus disinkronkan jika beberapa thread terlibat.

### Can I digitally sign the PPTX I create?

Ya. [Digital signatures](/slides/id/nodejs-java/digital-signature-in-powerpoint/) (penambahan dan verifikasi) didukung untuk presentasi.

### Are macros (VBA) supported in created presentations?

Ya. Anda dapat [create/edit VBA projects](/slides/id/nodejs-java/presentation-via-vba/) dan menyimpan file yang mendukung macro seperti PPTM/PPSM.