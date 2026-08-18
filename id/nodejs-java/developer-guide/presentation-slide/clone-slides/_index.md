---
title: Klon Slide Presentasi dalam JavaScript
linktitle: Klon Slide
type: docs
weight: 35
url: /id/nodejs-java/clone-slides/
keywords:
- klon slide
- salin slide
- simpan slide
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Dengan cepat menduplikasi slide PowerPoint dengan Aspose.Slides untuk Node.js. Ikuti contoh kode kami untuk mengotomatisasi pembuatan PPT dalam hitungan detik dan menghilangkan pekerjaan manual."
---
## **Pendahuluan**

Cloning adalah proses membuat salinan atau replika yang persis dari sesuatu. Aspose.Slides for Node.js via Java juga memungkinkan untuk membuat salinan atau klon dari slide apa pun dan kemudian menyisipkan slide yang telah diklon tersebut ke presentasi saat ini atau presentasi lain yang terbuka. Proses kloning slide membuat slide baru yang dapat dimodifikasi oleh pengembang tanpa mengubah slide asli. Ada beberapa cara untuk mengklon slide:

- Klon di Akhir dalam Presentasi.
- Klon pada Posisi Lain dalam Presentasi.
- Klon di Akhir dalam Presentasi lain.
- Klon pada Posisi Lain dalam Presentasi lain.
- Klon pada posisi tertentu dalam Presentasi lain.

Di Aspose.Slides for Node.js via Java, (sebuah koleksi objek [Slide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Slide)) yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) menyediakan metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) dan [insertClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) untuk melakukan jenis-jenis kloning slide di atas

## **Klon di Akhir dalam Presentasi**
Jika Anda ingin mengklon sebuah slide dan kemudian menggunakannya dalam file presentasi yang sama di akhir slide yang ada, gunakan metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) menurut langkah-langkah di bawah ini:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
1. Instansiasi kelas [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--) dengan merujuk ke koleksi Slides yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) yang diekspos oleh objek [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--) dan berikan slide yang akan diklon sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Tulis file presentasi yang telah dimodifikasi.

Pada contoh di bawah ini, kami telah mengklon sebuah slide (yang berada pada posisi pertama – indeks nol – dalam presentasi) ke akhir presentasi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instansiasi kelas Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Klon slide yang diinginkan ke akhir koleksi slide dalam presentasi yang sama
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Tulis presentasi yang telah dimodifikasi ke disk
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klon pada Posisi Lain dalam Presentasi**
Jika Anda ingin mengklon sebuah slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi pada posisi yang berbeda, gunakan metode [insertClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-):

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
1. Instansiasi kelas dengan merujuk ke koleksi **Slides** yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
1. Panggil metode [insertClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) yang diekspos oleh objek [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--) dan berikan slide yang akan diklon bersama dengan indeks untuk posisi baru sebagai parameter ke metode [insertClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah mengklon sebuah slide (yang berada pada indeks 1 – posisi 2 – dalam presentasi) ke indeks 2 – posisi 3 – dalam presentasi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instansiasi kelas Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Klon slide yang diinginkan ke akhir koleksi slide dalam presentasi yang sama
    var slds = pres.getSlides();
    // Klon slide yang diinginkan ke indeks yang ditentukan dalam presentasi yang sama
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Tulis presentasi yang telah dimodifikasi ke disk
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klon di Akhir dalam Presentasi lain**
Jika Anda perlu mengklon sebuah slide dari satu presentasi dan menggunakannya dalam file presentasi lain, di akhir slide yang ada:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang berisi presentasi sumber tempat slide akan diklon.
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang berisi presentasi tujuan tempat slide akan ditambahkan.
1. Instansiasi kelas [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection) dengan merujuk ke koleksi **Slides** yang diekspos oleh objek Presentation dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) yang diekspos oleh objek [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--) dan berikan slide dari presentasi sumber sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Tulis file presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah ini, kami telah mengklon sebuah slide (dari indeks pertama pada presentasi sumber) ke akhir presentasi tujuan.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instansiasi kelas Presentation untuk memuat file presentasi sumber
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instansiasi kelas Presentation untuk PPTX tujuan (di mana slide akan diklon)
    var destPres = new aspose.slides.Presentation();
    try {
        // Klon slide yang diinginkan dari presentasi sumber ke akhir koleksi slide dalam presentasi tujuan
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Tulis presentasi tujuan ke disk
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klon pada Posisi Lain dalam Presentasi lain**
Jika Anda perlu mengklon sebuah slide dari satu presentasi dan menggunakannya dalam file presentasi lain, pada posisi tertentu:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang berisi presentasi sumber tempat slide akan diklon.
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang berisi presentasi tujuan tempat slide akan ditambahkan.
1. Instansiasi kelas [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--) dengan merujuk ke koleksi Slides yang diekspos oleh objek Presentation dari presentasi tujuan.
1. Panggil metode [insertClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) yang diekspos oleh objek [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--) dan berikan slide dari presentasi sumber bersama dengan posisi yang diinginkan sebagai parameter ke metode [insertClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. Tulis file presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah ini, kami telah mengklon sebuah slide (dari indeks nol pada presentasi sumber) ke indeks 1 (posisi 2) pada presentasi tujuan.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instansiasi kelas Presentation untuk memuat file presentasi sumber
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instansiasi kelas Presentation untuk PPTX tujuan (di mana slide akan diklon)
    var destPres = new aspose.slides.Presentation();
    try {
        // Klon slide yang diinginkan dari presentasi sumber ke akhir koleksi slide dalam presentasi tujuan
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // Tulis presentasi tujuan ke disk
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klon pada posisi tertentu dalam Presentasi lain**
Jika Anda perlu mengklon sebuah slide dengan master slide dari satu presentasi dan menggunakannya dalam presentasi lain, Anda harus mengklon master slide yang diinginkan dari presentasi sumber ke presentasi tujuan terlebih dahulu. Kemudian Anda perlu menggunakan master slide tersebut untuk mengklon slide dengan master slide. Metode [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) mengharapkan master slide dari presentasi tujuan, bukan dari presentasi sumber. Untuk mengklon slide dengan master, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang berisi presentasi sumber tempat slide akan diklon.
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang berisi presentasi tujuan tempat slide akan diklon.
1. Akses slide yang akan diklon beserta master slide-nya.
1. Instansiasi kelas [MasterSlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/MasterSlideCollection) dengan merujuk ke koleksi Masters yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) yang diekspos oleh objek [MasterSlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/MasterSlideCollection) dan berikan master dari PPTX sumber yang akan diklon sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Instansiasi kelas [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--) dengan menetapkan referensi ke koleksi Slides yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) yang diekspos oleh objek [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--) dan berikan slide dari presentasi sumber yang akan diklon serta master slide sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Tulis file presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah ini, kami telah mengklon sebuah slide dengan master (yang berada pada indeks nol pada presentasi sumber) ke akhir presentasi tujuan menggunakan master dari slide sumber.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instansiasi kelas Presentation untuk memuat file presentasi sumber
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instansiasi kelas Presentation untuk presentasi tujuan (di mana slide akan diklon)
    var destPres = new aspose.slides.Presentation();
    try {
        // Instansiasi ISlide dari koleksi slide dalam presentasi sumber bersama dengan
        // Slide master
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Klon master slide yang diinginkan dari presentasi sumber ke koleksi master dalam
        // Presentasi tujuan
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // Klon slide yang diinginkan dari presentasi sumber dengan master yang diinginkan ke akhir
        // Koleksi slide dalam presentasi tujuan
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // Simpan presentasi tujuan ke disk
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klon di Akhir dalam Bagian yang Ditentukan**
Jika Anda ingin mengklon sebuah slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi pada bagian yang berbeda, gunakan metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) yang diekspos oleh kelas [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection). Aspose.Slides for Node.js via Java memungkinkan mengklon slide dari bagian pertama dan kemudian menyisipkan slide yang diklon tersebut ke bagian kedua dari presentasi yang sama.

Potongan kode berikut menunjukkan cara mengklon slide dan menyisipkan slide yang diklon ke dalam sebuah bagian yang ditentukan.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Simpan presentasi tujuan ke disk
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Pastikan Ukuran Slide Cocok**

Saat mengklon slide ke dalam presentasi lain, pastikan presentasi tujuan memiliki ukuran slide yang sama dengan sumber. Jika ukuran slide berbeda, Aspose.Slides tidak secara otomatis mengubah skala bentuk yang diklon—koordinat dan dimensi asli mereka dipertahankan, yang dapat menyebabkan konten tampak tidak sejajar atau melampaui batas slide.

Anda dapat mengatur ukuran slide presentasi tujuan agar cocok dengan sumber sebelum mengklon master dan slide:

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

Lakukan ini sebelum mengklon master dan slide.

## **FAQ**

**Apakah catatan pembicara dan komentar peninjau juga diklon?**

Ya. Halaman catatan dan komentar peninjau termasuk dalam klon. Jika Anda tidak menginginkannya, [hapus mereka](/slides/id/nodejs-java/presentation-notes/) setelah penyisipan.

**Bagaimana grafik dan sumber data mereka ditangani?**

Objek grafik, pemformatan, dan data yang tersemat disalin. Jika grafik terhubung ke sumber eksternal (misalnya, buku kerja yang disematkan OLE), kaitan tersebut dipertahankan sebagai [objek OLE](/slides/id/nodejs-java/manage-ole/). Setelah dipindahkan antar file, verifikasi ketersediaan data dan perilaku penyegaran.

**Bisakah saya mengontrol posisi penyisipan dan bagian untuk klon?**

Ya. Anda dapat menyisipkan klon pada indeks slide tertentu dan menempatkannya ke [bagian](/slides/id/nodejs-java/slide-section/) yang dipilih. Jika bagian target belum ada, buat terlebih dahulu dan kemudian pindahkan slide ke dalamnya.