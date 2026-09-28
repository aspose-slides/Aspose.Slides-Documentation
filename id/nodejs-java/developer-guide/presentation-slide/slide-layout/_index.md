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
- tata letak tidak terpakai
- visibilitas footer
- slide judul
- judul dan konten
- tajuk bagian
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
description: "Terapkan, buat, dan modifikasi tata letak slide dalam Aspose.Slides untuk Node.js melalui Java, tambahkan placeholder, hapus tata letak yang tidak terpakai, dan kontrol visibilitas footer."
---
## **Gambaran Umum**

Sebuah tata letak slide menentukan posisi dan pemformatan placeholder seperti judul, teks, gambar, diagram, dan tabel. Menerapkan tata letak memberikan slide struktur yang konsisten sambil memungkinkan setiap slide memiliki kontennya masing‑ma​n.

Tata letak yang paling umum meliputi:

- **Slide Judul**: Menyertakan placeholder judul dan subjudul.
- **Judul dan Konten**: Menyertakan placeholder judul dan placeholder konten serbaguna.
- **Kosong**: Tidak menyertakan placeholder konten dan berguna ketika setiap bentuk akan diposisikan secara manual.

## **Memahami Pewarisan Tata Letak**

Sebuah presentasi memiliki tiga level terkait:

1. Sebuah [slide master](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslide/) mendefinisikan tema, pemformatan bersama, latar belakang, dan objek umum.
1. Sebuah [slide tata letak](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/) merupakan bagian dari master dan mendefinisikan susunan placeholder tertentu.
1. Sebuah [slide normal](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/) menggunakan satu tata letak dan menyimpan konten yang dimasukkan untuk slide tersebut.

Sebuah slide normal mewarisi tema dan pemformatan dari tata letaknya, dan tata letak mewarisi dari masternya. Nilai yang ditetapkan langsung pada slide normal akan menimpa nilai yang diwariskan pada level itu. Ketika slide normal dibuat, bentuk placeholder‑nya dihasilkan dari tata letak yang dipilih, sementara konten yang dimasukkan ke dalam placeholder‑placeholder tersebut menjadi milik slide normal.

Tambahkan placeholder yang diperlukan ke sebuah tata letak sebelum membuat slide darinya. Menambahkan placeholder lain ke tata letak kemudian tidak secara otomatis menambah bentuk placeholder yang bersesuaian ke slide normal yang sudah ada.

Hubungan ini memiliki dua konsekuensi penting:

- Mengubah pemformatan yang diwariskan atau geometri placeholder yang ada pada tata letak dapat memperbarui setiap slide yang bergantung padanya. Sebelum mengedit tata letak yang sudah digunakan, periksa slide‑slide yang tergantung dan tinjau hasil presentasi.
- Sebuah tata letak yang masih digunakan oleh sebuah slide tidak dapat dihapus. Alihkan slide‑slide yang bergantung ke tata letak lain terlebih dahulu, atau hapus hanya tata letak yang tidak terpakai.

Untuk informasi lebih lanjut tentang level atas hierarki ini, lihat [Slide Master](/slides/id/nodejs-java/slide-master/).

Untuk menyembunyikan logo yang diwariskan atau bentuk master dekoratif pada satu slide atau melalui tata letak bersama, lihat [Control the Visibility of Master Graphics](/slides/id/nodejs-java/slide-master/). Contoh ini membandingkan dua slide yang menggunakan master yang sama.

## **Pilih dan Terapkan Tata Letak Slide**

Gunakan nilai [SlideLayoutType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidelayouttype/) ketika presentasi mengikuti definisi tata letak PowerPoint standar. Nama tata letak dapat diedit pengguna dan dapat dilokalisasi, sehingga pemilihan berbasis nama kurang dapat diandalkan kecuali Anda mengontrol templat sumber.

Contoh berikut mencari **Judul dan Konten** pada master pertama. Jika tata letak itu tidak tersedia, secara sengaja beralih ke **Kosong**. Pemeriksaan null kedua diperlukan karena sebuah presentasi dapat berisi hanya tata letak khusus. Tata letak yang dipilih kemudian diterapkan ke slide normal pertama melalui metode [Slide.setLayoutSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/#setLayoutSlide).

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

Mengubah tata letak slide tidak menghapus bentuk biasa yang ditambahkan langsung ke slide. Namun, posisi placeholder, pemformatan yang diwariskan, dan korespondensi antara placeholder yang ada dengan tata letak baru dapat berubah, sehingga periksa output saat beralih antara tata letak yang berbeda secara substansial.

## **Tambahkan Slide Tata Letak**

Pemilihan dan pembuatan adalah operasi terpisah. Contoh sebelumnya memilih tata letak yang ada; itu tidak membuat yang baru. Untuk membuat tata letak, panggil metode [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) pada koleksi tata letak master target.

Contoh berikut selalu menambahkan tata letak **Judul dan Konten** baru bernama `Report Title and Content`, lalu menambahkan slide normal yang didasarkan padanya. Nama tata letak harus unik dalam koleksi.

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

Tambahkan tata letak hanya ketika templat memang membutuhkan struktur yang dapat digunakan kembali. Jika tata letak yang cocok sudah ada, pilih dan gunakan kembali alih‑alih membuat duplikat.

## **Tambahkan Placeholder ke Slide Tata Letak**

Metode [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) menyediakan sebuah [LayoutPlaceholderManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/) untuk menambahkan bentuk placeholder ke sebuah tata letak.

| Placeholder PowerPoint | Metode `LayoutPlaceholderManager` |
| ----------------------- | --------------------------------- |
| ![Konten](content.png) | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Konten (Vertikal)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Teks](text.png) | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Teks (Vertikal)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Gambar](picture.png) | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Diagram](chart.png) | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabel](table.png) | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Gambar Online](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Contoh berikut memverifikasi bahwa tata letak **Kosong** ada, menambahkan empat placeholder ke dalamnya, lalu membuat slide normal yang menggunakan tata letak yang telah dimodifikasi. Urutannya disengaja: placeholder ditambahkan sebelum slide normal dibuat, sehingga Aspose.Slides dapat menghasilkan bentuk placeholder yang bersesuaian pada slide tersebut.

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

Hasilnya:

![Placeholder pada slide tata letak](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Mengubah pemformatan yang diwariskan atau geometri placeholder tata letak yang ada dapat memengaruhi slide‑slide yang bergantung. Placeholder tata letak yang baru ditambahkan tidak secara otomatis ditambahkan ke slide normal yang sudah ada. Uji perubahan tata letak pada salinan presentasi dan periksa setiap slide yang bergantung.
{{% /alert %}}

## **Hapus Slide Tata Letak yang Tidak Digunakan**

Gunakan metode [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) untuk menghapus tata letak yang tidak dirujuk oleh slide normal mana pun. Metode ini membiarkan tata letak yang masih digunakan tetap utuh.

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

Untuk menghapus satu tata letak tertentu, pertama gunakan metode [hasDependingSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) atau [getDependingSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/#getDependingSlides). Alihkan semua slide yang bergantung sebelum memanggil [LayoutSlide.remove](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/#remove). Mencoba menghapus tata letak yang masih dipakai akan memicu [PptxEditException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxeditexception/).

## **Kontrol Visibilitas Footer pada Slide Tata Letak**

Sebuah tata letak memiliki footer, nomor slide, dan placeholder tanggal‑waktu sendiri. Gunakan metode [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) untuk mengontrol placeholder‑placeholder tersebut pada satu tata letak. Ini berguna ketika, misalnya, tata letak konten harus menampilkan footer tetapi tata letak judul tidak.

Contoh berikut memilih tata letak secara aman dan membuat elemen footernya terlihat:

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

Untuk menerapkan pengaturan footer yang konsisten di seluruh hierarki master, gunakan metode [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). Metode propagasi pada [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslideheaderfootermanager/) beroperasi pada master serta slide tata letak dan slide normal yang bergantung; mereka tidak menargetkan hanya satu slide normal.

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

**Apa Perbedaan Antara Slide Master dan Slide Tata Letak?**

Slide master mendefinisikan tema presentasi dan pemformatan bersama. Slide tata letak merupakan bagian dari master dan mendefinisikan satu susunan placeholder yang dapat digunakan kembali. Slide normal menggunakan tata letak‑tata letak tersebut dan menyimpan konten spesifik slide.

**Bisakah Saya Menyalin Slide Tata Letak dari Satu Presentasi ke Presentasi Lain?**

Ya. Tambahkan salinan ke koleksi tujuan dengan metode [addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone). Saat menyalin antar presentasi, verifikasi juga font, tema, gambar, dan sumber daya lain yang digunakan oleh tata letak sumber.

**Apa yang Terjadi Jika Saya Memodifikasi Tata Letak yang Sudah Digunakan?**

Slide‑slide yang bergantung mewarisi perubahan tata letak kecuali mereka menimpa pemformatan atau objek yang terpengaruh secara lokal. Geometri placeholder dan gaya yang diwariskan dapat berubah pada banyak slide sekaligus. Gunakan [getDependingSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) untuk mengidentifikasi slide yang terpengaruh sebelum menyunting tata letak.

**Apa yang Terjadi Jika Saya Menghapus Tata Letak yang Masih Digunakan?**

Aspose.Slides akan melempar [PptxEditException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxeditexception/). Alihkan slide‑slide yang bergantung terlebih dahulu, atau gunakan [removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) untuk menghapus hanya tata letak yang tidak dirujuk.