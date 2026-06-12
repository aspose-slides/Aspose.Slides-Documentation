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
description: "Duplikat slide PowerPoint dengan cepat menggunakan Aspose.Slides untuk Node.js. Ikuti contoh kode kami untuk mengotomatiskan pembuatan PPT dalam hitungan detik dan menghilangkan pekerjaan manual."
---
## **Pendahuluan**

Penggandaan adalah proses membuat salinan atau replika yang persis dari sesuatu. Aspose.Slides untuk Node.js via Java juga memungkinkan membuat salinan atau klon dari slide apa pun dan kemudian menyisipkan slide yang diklon tersebut ke presentasi yang sedang aktif atau presentasi lain yang terbuka. Proses penggandaan slide membuat slide baru yang dapat dimodifikasi oleh pengembang tanpa mengubah slide asli. Ada beberapa cara untuk mengkloning slide:

- Klon di Akhir dalam Presentasi.
- Klon di Posisi Lain dalam Presentasi.
- Klon di Akhir dalam Presentasi lain.
- Klon di Posisi Lain dalam Presentasi lain.
- Klon di posisi spesifik dalam Presentasi lain.

Dalam Aspose.Slides untuk Node.js via Java, (sekumpulan objek [Slide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Slide) ) yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) menyediakan metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) dan [insertClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) untuk melakukan jenis penggandaan slide di atas

## **Klon di Akhir dalam Presentasi**
Jika Anda ingin mengklon sebuah slide dan kemudian menggunakannya dalam file presentasi yang sama di akhir slide yang ada, gunakan metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) sesuai dengan langkah-langkah di bawah ini:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Instansiasi kelas [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--) dengan merujuk koleksi Slides yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
3. Panggil metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) yang diekspos oleh objek [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--) dan berikan slide yang akan diklon sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
4. Tuliskan file presentasi yang telah dimodifikasi.

Pada contoh di bawah, kami telah mengklon sebuah slide (yang berada pada posisi pertama – indeks nol – dalam presentasi) ke akhir presentasi.

```javascript
// Buat instance kelas Presentation yang mewakili file presentasi
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

## **Klon di Posisi Lain dalam Presentasi**
Jika Anda ingin mengklon sebuah slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi pada posisi yang berbeda, gunakan metode [insertClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-):

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
1. Instansiasi kelas dengan merujuk koleksi [**Slides**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--) yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
1. Panggil metode [insertClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) yang diekspos oleh objek [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--) dan berikan slide yang akan diklon bersama indeks posisi baru sebagai parameter ke metode [insertClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah, kami telah mengklon sebuah slide (yang berada pada indeks nol – posisi 1 – dalam presentasi) ke indeks 1 – Posisi 2 – dalam presentasi.

```javascript
// Buat instance kelas Presentation yang mewakili file presentasi
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

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang berisi presentasi sumber slide.
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang berisi presentasi tujuan tempat slide akan ditambahkan.
1. Instansiasi kelas [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection) dengan merujuk koleksi [**Slides**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--) yang diekspos oleh objek Presentation dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) yang diekspos oleh objek [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--) dan berikan slide dari presentasi sumber sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Tuliskan file presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah, kami telah mengklon sebuah slide (dari indeks pertama pada presentasi sumber) ke akhir presentasi tujuan.

```javascript
// Buat instance kelas Presentation untuk memuat file presentasi sumber
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Buat instance kelas Presentation untuk PPTX tujuan (di mana slide akan diklon)
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

## **Klon di Posisi Lain dalam Presentasi lain**
Jika Anda perlu mengklon sebuah slide dari satu presentasi dan menggunakannya dalam file presentasi lain, pada posisi tertentu:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang berisi presentasi sumber slide.
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang berisi presentasi tujuan tempat slide akan ditambahkan.
1. Instansiasi kelas [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--) dengan merujuk koleksi Slides yang diekspos oleh objek Presentation dari presentasi tujuan.
1. Panggil metode [insertClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) yang diekspos oleh objek [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--) dan berikan slide dari presentasi sumber bersama posisi yang diinginkan sebagai parameter ke metode [insertClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. Tuliskan file presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah, kami telah mengklon sebuah slide (dari indeks nol pada presentasi sumber) ke indeks 1 (posisi 2) pada presentasi tujuan.

```javascript
// Buat instance kelas Presentation untuk memuat file presentasi sumber
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Buat instance kelas Presentation untuk PPTX tujuan (di mana slide akan diklon)
    var destPres = new aspose.slides.Presentation();
    try {
        // Klon slide yang diinginkan dari presentasi sumber ke akhir koleksi slide dalam presentasi tujuan
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // Tulis presentasi tujuan ke disk
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klon di posisi spesifik dalam Presentasi lain**
Jika Anda perlu mengklon sebuah slide dengan master slide dari satu presentasi dan menggunakannya dalam presentasi lain, Anda harus terlebih dahulu mengklon master slide yang diinginkan dari presentasi sumber ke presentasi tujuan. Kemudian gunakan master slide tersebut untuk mengklon slide dengan master slide. Metode [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) mengharapkan master slide dari presentasi tujuan, bukan dari presentasi sumber. Untuk mengklon slide dengan master, ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang berisi presentasi sumber slide.
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang berisi presentasi tujuan slide.
1. Akses slide yang akan diklon beserta master slide‑nya.
1. Instansiasi kelas [MasterSlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/MasterSlideCollection) dengan merujuk koleksi Masters yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) yang diekspos oleh objek [MasterSlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/MasterSlideCollection) dan berikan master dari PPTX sumber yang akan diklon sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Instansiasi kelas [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--) dengan mengatur referensi ke koleksi Slides yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) yang diekspos oleh objek [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--) dan berikan slide dari presentasi sumber yang akan diklon serta master slide sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Tuliskan file presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah, kami telah mengklon sebuah slide dengan master (yang berada pada indeks nol pada presentasi sumber) ke akhir presentasi tujuan menggunakan master dari slide sumber.

```javascript
// Buat instance kelas Presentation untuk memuat file presentasi sumber
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Buat instance kelas Presentation untuk presentasi tujuan (di mana slide akan diklon)
    var destPres = new aspose.slides.Presentation();
    try {
        // Instansiasi ISlide dari koleksi slide dalam presentasi sumber bersama
        // Slide master
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Klon slide master yang diinginkan dari presentasi sumber ke dalam koleksi master di
        // Presentasi tujuan
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Klon slide master yang diinginkan dari presentasi sumber ke dalam koleksi master di
        // Presentasi tujuan
        var iSlide = masters.addClone(SourceMaster);
        // Klon slide yang diinginkan dari presentasi sumber dengan master yang diinginkan ke akhir
        // Koleksi slide dalam presentasi tujuan
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
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
Jika Anda ingin mengklon sebuah slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi pada bagian yang berbeda, gunakan metode [**addClone**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) yang diekspos oleh kelas [**SlideCollection**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection). Aspose.Slides untuk Node.js via Java memungkinkan mengklon slide dari bagian pertama lalu menyisipkan slide yang diklon ke bagian kedua dalam presentasi yang sama.

Potongan kode berikut menunjukkan cara mengklon slide dan menyisipkan slide yang diklon ke bagian yang ditentukan.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Simpan presentasi tujuan ke disk
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Apakah catatan pembicara dan komentar reviewer juga diklon?**

Ya. Halaman catatan dan komentar ulasan termasuk dalam klon. Jika Anda tidak menginginkannya, [hapus mereka](/slides/id/nodejs-java/presentation-notes/) setelah penyisipan.

**Bagaimana chart dan sumber data mereka ditangani?**

Objek chart, pemformatan, dan data yang disematkan disalin. Jika chart terhubung ke sumber eksternal (mis., buku kerja OLE yang disematkan), tautan tersebut dipertahankan sebagai [objek OLE](/slides/id/nodejs-java/manage-ole/). Setelah dipindahkan antar file, verifikasi ketersediaan data dan perilaku penyegaran.

**Apakah saya dapat mengontrol posisi penyisipan dan bagian untuk klon?**

Ya. Anda dapat menyisipkan klon pada indeks slide tertentu dan menempatkannya ke dalam [bagian](/slides/id/nodejs-java/slide-section/) yang dipilih. Jika bagian target tidak ada, buat terlebih dahulu dan kemudian pindahkan slide ke dalamnya.