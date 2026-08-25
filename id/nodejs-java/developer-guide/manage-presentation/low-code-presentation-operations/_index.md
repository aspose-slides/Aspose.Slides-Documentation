---
title: Operasi Presentasi Low-Code dalam JavaScript
linktitle: API Low-Code
type: docs
weight: 50
url: /id/nodejs-java/low-code-presentation-operations/
keywords:
- API presentasi low-code
- konversi presentasi
- gabungkan presentasi
- iterasi slide
- iterasi shape
- iterasi teks
- kumpulkan shape
- kompresi presentasi
- hapus master slide yang tidak terpakai
- hapus layout slide yang tidak terpakai
- kompresi font tersemat
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Gunakan API low-code Aspose.Slides dalam JavaScript untuk mengonversi dan menggabungkan presentasi, mengiterasi konten, mengumpulkan shape, dan mengurangi ukuran presentasi."
---
## **Gambaran Umum**

Namespace `aspose.slides` menyediakan kelas pembantu statis untuk operasi presentasi umum. Pembantu ini membungkus alur kerja model objek yang sering digunakan dalam metode yang terfokus, sehingga Anda dapat mengonversi atau menggabungkan file, memproses elemen presentasi, mengumpulkan shape, dan menghapus konten yang tidak terpakai dengan lebih sedikit kode.

Pembantu low-code paling berguna ketika operasi diterapkan pada seluruh file atau presentasi dan alur kerja default sesuai dengan kebutuhan Anda. Gunakan model objek [Aspose.Slides object model](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/) secara lengkap ketika Anda memerlukan kontrol halus atas slide individual, master, layout, shape, pengaturan ekspor, atau hubungan antar elemen presentasi.

Tabel berikut merangkum pembantu yang tersedia:

| Pembantu | Untuk apa |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/convert/) | Mengonversi presentasi ke format lain dengan panggilan file-ke-file langsung. |
| [Merger](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/merger/) | Menggabungkan file presentasi lengkap dengan format yang sama. |
| [ForEach](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/foreach/) | Menjalankan aksi untuk setiap slide, shape, paragraf, atau potongan teks. |
| [Collect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/collect/) | Mengambil shape dari seluruh presentasi untuk pemrosesan atau analisis berulang. |
| [Compress](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compress/) | Menghapus master dan layout yang tidak terpakai serta mengurangi data font yang tersemat. |

## **Mengonversi Presentasi**

Gunakan [Convert.autoByExtension](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/convert/#autoByExtension) ketika ekstensi file output cukup untuk memilih format ekspor. Metode ini membuka presentasi sumber, menentukan format yang diperlukan dari jalur output, dan menulis hasilnya.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

Kelas [Convert](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/convert/) juga menyediakan metode khusus untuk output PDF, SVG, JPEG, PNG, dan TIFF. Gunakan model objek lengkap ketika Anda perlu memeriksa atau mengubah presentasi sebelum ekspor atau mengonfigurasi opsi ekspor yang tidak disediakan oleh pembantu yang dipilih. Lihat [Convert Presentation](/slides/id/nodejs-java/convert-presentation/) untuk alur kerja dan opsi spesifik format.

## **Menggabungkan Presentasi**

Gunakan [Merger.process](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/merger/#process) untuk menggabungkan file presentasi lengkap dengan satu panggilan. Presentasi input harus memiliki format file yang sama.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

Pembantu ini tepat ketika semua slide harus ditambahkan ke satu hasil tanpa memilih atau memetakan ulang secara individual. Gunakan model objek lengkap ketika Anda perlu menggabungkan slide yang dipilih, menerapkan master atau layout tujuan, mempertahankan bagian secara eksplisit, atau menyelaraskan ukuran slide yang berbeda. Lihat [Merge Presentations](/slides/id/nodejs-java/merge-presentation/) untuk skenario tersebut.

## **Iterasi Elemen Presentasi**

Kelas [ForEach](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/foreach/) memanggil callback untuk setiap tipe elemen presentasi yang diminta. Ini menghindari loop koleksi bersarang dan nyaman untuk inspeksi atau perubahan format pada seluruh presentasi. Di Node.js, buat implementasi antarmuka callback dengan `java.newProxy`.

Contoh berikut menggunakan [ForEach.slide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/foreach/#paragraph), dan [ForEach.portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/foreach/#portion) untuk memeriksa elemen yang sesuai:

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

Secara default, penelusuran shape dan teks pada seluruh presentasi mencakup slide normal, master, dan layout. Overload dengan parameter `includeNotes` juga dapat memproses slide catatan. Gunakan loop koleksi langsung ketika urutan penelusuran, penghentian awal, penyaringan sebelum pemanggilan callback, atau kontrol induk‑anak yang detail penting.

## **Mengumpulkan Shape**

Gunakan [Collect.shapes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/collect/#shapes) ketika Anda membutuhkan koleksi semua shape dalam sebuah presentasi alih‑alih callback untuk setiap shape. Ini berguna ketika set yang sama akan difilter, dihitung, atau diproses lebih dari satu kali.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

Gunakan [ForEach.shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/foreach/#shape) sebagai gantinya ketika setiap shape dapat diproses segera dan Anda tidak perlu menyimpan hasil yang dikumpulkan.

## **Mengompres Konten Presentasi**

Kelas [Compress](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compress/) dapat menghapus elemen struktural yang tidak terpakai dan mengurangi data font yang tersemat:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) menghapus slide layout yang tidak direferensikan oleh slide normal.  
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) menghapus slide master yang tidak lagi digunakan.  
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) menghapus karakter yang tidak terpakai dari font yang tersemat.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hapus layout yang tidak terpakai sebelum master yang tidak terpakai sehingga master yang menjadi tidak direferensikan setelah pembersihan layout juga dapat dihapus. Simpan presentasi yang dioptimalkan ke file baru jika Anda mungkin membutuhkan master, layout, atau data font tersemat lengkap yang asli nanti. Untuk detail lebih lanjut, lihat [Slide Master](/slides/id/nodejs-java/slide-master/) dan [Embedded Font](/slides/id/nodejs-java/embedded-font/).

## **FAQ**

**Kapan saya harus menggunakan API low-code dibandingkan model objek lengkap?**

Gunakan pembantu low-code ketika operasi standar diterapkan pada file atau presentasi lengkap dan tidak memerlukan kontrol detail atas elemen individual. Gunakan model objek lengkap ketika Anda perlu memilih slide tertentu, mengontrol hubungan master dan layout, memeriksa keadaan menengah, atau mengonfigurasi perilaku yang tidak disediakan oleh pembantu.

**Apakah Merger dapat menggabungkan presentasi dengan format file yang berbeda?**

Tidak. [Merger.process](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/merger/#process) memerlukan presentasi input dengan format yang sama. Konversi file input ke format umum terlebih dahulu, misalnya dengan [Convert.autoByExtension](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/convert/#autoByExtension), lalu gabungkan file yang telah dikonversi.

**Apakah ForEach memproses slide master, layout, dan catatan?**

[ForEach.slide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/foreach/#slide) mengiterasi slide presentasi normal. Operasi [ForEach.shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/foreach/#paragraph), dan [ForEach.portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/foreach/#portion) pada seluruh presentasi secara default mencakup slide normal, master, dan layout. Gunakan overload mereka dengan `includeNotes` diset ke `true` untuk menyertakan slide catatan.

**Apa perbedaan antara ForEach.shape dan Collect.shapes?**

Gunakan [ForEach.shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/foreach/#shape) untuk memproses setiap shape segera melalui callback. Gunakan [Collect.shapes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/collect/#shapes) ketika Anda membutuhkan hasil yang dapat diiterasi, disimpan, difilter, dihitung, atau dilalui berkali‑kali.

**Apakah Compress selalu membuat file presentasi lebih kecil?**

Tidak selalu. Hasilnya tergantung pada apakah presentasi berisi layout yang tidak terpakai, master yang tidak terpakai, atau font tersemat dengan karakter yang tidak terpakai. Jika tidak ada yang demikian, operasi [Compress](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compress/) terkait mungkin tidak mengurangi ukuran file.

**Apakah perubahan yang dibuat oleh ForEach atau Compress disimpan secara otomatis?**

Tidak. Pembantu ini beroperasi pada objek [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) yang dimuat di memori. Setelah mengubah elemen dalam callback [ForEach](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/foreach/) atau menjalankan [Compress](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compress/), panggil [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save) untuk menulis hasilnya.

## **Artikel Terkait**

- [Mengonversi Presentasi](/slides/id/nodejs-java/convert-presentation/)
- [Menggabungkan Presentasi](/slides/id/nodejs-java/merge-presentation/)
- [Master Slide](/slides/id/nodejs-java/slide-master/)
- [Mengelola Kotak Teks](/slides/id/nodejs-java/manage-textbox/)
- [Font Tersemat](/slides/id/nodejs-java/embedded-font/)