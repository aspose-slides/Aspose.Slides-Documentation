---
title: Terapkan atau Ubah Tata Letak Slide di JavaScript
linktitle: Tata Letak Slide
type: docs
weight: 60
url: /id/nodejs-java/slide-layout/
keywords:
- tata letak slide
- tata letak konten
- placeholder
- desain presentasi
- desain slide
- tata letak tak terpakai
- visibilitas footer
- slide judul
- judul dan konten
- header bagian
- dua konten
- perbandingan
- hanya judul
- tata letak kosong
- konten dengan keterangan
- gambar dengan keterangan
- judul dan teks vertikal
- judul vertikal dan teks
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Terapkan, buat, dan modifikasi tata letak slide di Aspose.Slides untuk Node.js via Java, tambahkan placeholder, hapus tata letak yang tidak terpakai, dan kontrol visibilitas footer."
---
## **Ringkasan**

Tata letak slide menentukan posisi dan pemformatan placeholder seperti judul, teks, gambar, diagram, dan tabel. Menerapkan tata letak memberikan slide struktur yang konsisten sekaligus memungkinkan setiap slide memiliki kontennya masing‑ma.

Layout yang paling umum meliputi:

- **Title Slide**: Berisi placeholder judul dan subjudul.
- **Title and Content**: Berisi placeholder judul dan placeholder konten serbaguna.
- **Blank**: Tidak berisi placeholder konten dan berguna ketika setiap shape akan ditempatkan secara manual.

## **Memahami Pewarisan Tata Letak**

Sebuah presentasi memiliki tiga tingkatan terkait:

1. Sebuah [master slide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslide/) mendefinisikan tema, pemformatan bersama, latar belakang, dan objek umum.
2. Sebuah [layout slide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/) milik master dan mendefinisikan susunan placeholder tertentu.
3. Sebuah [normal slide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/) menggunakan satu tata letak dan menyimpan konten yang dimasukkan untuk slide tersebut.

Sebuah normal slide mewarisi tema dan pemformatan dari layoutnya, dan layout mewarisi dari masternya. Nilai yang ditetapkan langsung pada normal slide menimpa nilai yang diwarisi pada level tersebut. Ketika normal slide dibuat, shape placeholder‑nya dihasilkan dari layout yang dipilih, sementara konten yang dimasukkan ke dalam placeholder tersebut menjadi milik normal slide.

Tambahkan placeholder yang diperlukan ke layout sebelum membuat slide darinya. Menambahkan placeholder lain ke layout nanti tidak secara otomatis menambah shape placeholder yang sesuai ke slide normal yang sudah ada.

Hubungan ini memiliki dua konsekuensi penting:

- Mengubah pemformatan yang diwarisi atau geometri placeholder yang ada pada layout dapat memperbarui setiap slide yang bergantung padanya. Sebelum mengedit layout yang sudah digunakan, periksa slide‑slide yang tergantung dan tinjau hasil presentasi.
- Layout yang masih digunakan oleh slide tidak dapat dihapus. Alihkan slide‑slide yang bergantung ke layout lain terlebih dahulu, atau hapus hanya layout yang tidak digunakan.

Untuk informasi lebih lanjut tentang tingkat atas hierarki ini, lihat [Slide Master](/slides/id/nodejs-java/slide-master/).

## **Pilih dan Terapkan Tata Letak Slide**

Gunakan nilai [SlideLayoutType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidelayouttype/) ketika presentasi mengikuti definisi tata letak PowerPoint standar. Nama layout dapat diedit pengguna dan dapat dilokalisasi, sehingga pemilihan berdasarkan nama kurang andal kecuali Anda mengendalikan templat sumber.

Contoh berikut mencari **Title and Content** pada master pertama. Jika layout itu tidak tersedia, secara sengaja beralih ke **Blank**. Pemeriksaan null kedua diperlukan karena sebuah presentasi dapat berisi hanya layout khusus. Layout yang dipilih kemudian diterapkan ke slide normal pertama melalui metode [Slide.setLayoutSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/#setLayoutSlide).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mengubah tata letak slide tidak menghapus shape biasa yang ditambahkan langsung ke slide. Namun, posisi placeholder, pemformatan yang diwarisi, dan korespondensi antara placeholder yang ada dengan layout baru dapat berubah, jadi periksa output saat beralih antara layout yang sangat berbeda.

## **Tambahkan Slide Tata Letak**

Pemilihan dan pembuatan adalah operasi terpisah. Contoh sebelumnya memilih layout yang ada; tidak membuat yang baru. Untuk membuat layout, panggil metode [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) pada koleksi layout master target.

Contoh berikut selalu menambahkan layout **Title and Content** baru bernama `Report Title and Content`, kemudian menambahkan slide normal berdasarkan layout tersebut. Nama layout harus unik dalam koleksi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tambahkan layout hanya ketika templat memang memerlukan struktur dapat pakai kembali lainnya. Jika layout yang cocok sudah ada, pilih dan gunakan kembali alih‑alih membuat duplikat.

## **Tambahkan Placeholder ke Slide Tata Letak**

Metode [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) menyediakan [LayoutPlaceholderManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/) untuk menambahkan shape placeholder ke layout.

| PowerPoint Placeholder              | `LayoutPlaceholderManager` Method |
| ----------------------------------- | --------------------------------- |
| ![Content](content.png)             | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                   | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)       | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)             | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)                 | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)                 | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                 | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)    | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Contoh berikut memverifikasi bahwa layout **Blank** ada, menambahkan empat placeholder ke dalamnya, lalu membuat slide normal yang menggunakan layout yang telah dimodifikasi. Urutannya disengaja: placeholder ditambahkan sebelum slide normal dibuat, sehingga Aspose.Slides dapat menghasilkan shape placeholder yang sesuai pada slide tersebut.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Placeholder pada slide tata letak](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Mengubah pemformatan yang diwarisi atau geometri placeholder layout yang ada dapat memengaruhi slide‑slide yang bergantung. Placeholder layout yang baru ditambahkan tidak secara otomatis ditambahkan ke slide normal yang sudah ada. Uji perubahan layout pada salinan presentasi dan periksa setiap slide yang tergantung.
{{% /alert %}}

## **Hapus Slide Tata Letak yang Tidak Digunakan**

Gunakan metode [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) untuk menghapus layout yang tidak dirujuk oleh slide normal mana pun. Metode ini membiarkan layout yang masih dipakai tetap utuh.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk menghapus satu layout tertentu, pertama gunakan metode [hasDependingSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) atau [getDependingSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/#getDependingSlides). Alihkan semua slide yang bergantung sebelum memanggil [LayoutSlide.remove](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/#remove). Mencoba menghapus layout yang masih digunakan akan memunculkan [PptxEditException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxeditexception/).

## **Kontrol Visibilitas Footer pada Slide Tata Letak**

Sebuah layout memiliki footer, nomor slide, dan placeholder tanggal‑waktu masing‑masing. Gunakan metode [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) untuk mengontrol placeholder tersebut pada satu layout. Ini berguna ketika, misalnya, layout konten harus menampilkan footer tetapi layout judul tidak.

Contoh berikut memilih layout secara aman dan membuat elemen footernya terlihat:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kontrol Visibilitas Footer pada Master dan Tata Letak Anak‑nya**

Untuk menerapkan pengaturan footer yang konsisten di seluruh hierarki master, gunakan metode [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). Metode propagasi dari [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslideheaderfootermanager/) beroperasi pada master serta layout slide dan slide normal yang bergantung; tidak hanya pada satu slide normal.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apa Perbedaan Antara Master Slide dan Layout Slide?**

Master slide mendefinisikan tema dan pemformatan bersama presentasi. Layout slide termasuk dalam master dan mendefinisikan satu susunan placeholder yang dapat dipakai kembali. Slide normal menggunakan layout‑layout tersebut dan menyimpan konten khusus slide.

**Bisakah Saya Menyalin Layout Slide dari Satu Presentasi ke Presentasi Lain?**

Ya. Tambahkan salinan ke koleksi tujuan dengan metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone). Saat menyalin antara presentasi, pastikan juga memeriksa font, tema, gambar, dan sumber daya lain yang digunakan oleh layout sumber.

**Apa yang Terjadi Ketika Saya Memodifikasi Layout yang Sudah Digunakan?**

Slide yang bergantung mewarisi perubahan layout kecuali mereka menimpa pemformatan atau objek yang terpengaruh secara lokal. Geometri placeholder dan gaya yang diwarisi dapat berubah pada banyak slide sekaligus. Gunakan [getDependingSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) untuk mengidentifikasi slide yang terpengaruh sebelum mengedit layout.

**Apa yang Terjadi Jika Saya Menghapus Layout yang Masih Digunakan?**

Aspose.Slides akan melempar [PptxEditException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxeditexception/). Alihkan slide yang bergantung terlebih dahulu, atau gunakan [removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) untuk menghapus hanya layout yang tidak direferensikan.)