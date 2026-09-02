---
title: Kelola Header dan Footer Presentasi di JavaScript
linktitle: Header dan Footer
type: docs
weight: 140
url: /id/nodejs-java/presentation-header-and-footer/
keywords:
- header
- teks header
- footer
- teks footer
- atur header
- atur footer
- handout
- catatan
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara mengelola placeholder footer, tanggal-waktu, nomor slide, dan header pada slide, halaman catatan, dan handout dengan Aspose.Slides untuk Node.js via Java."
---
## **Ringkasan**

PowerPoint menggunakan placeholder header dan footer yang berbeda tergantung pada jenis halaman. Aspose.Slides untuk Node.js via Java memungkinkan Anda mengontrol teks dan visibilitas placeholder ini melalui kelas manager header/footer.

Placeholder yang tersedia bergantung pada ruang lingkup:

| Ruang lingkup | Header | Footer | Tanggal/waktu | Nomor slide/halaman |
|---|---|---|---|---|
| Slide reguler | Tidak | Ya | Ya | Ya |
| Master catatan | Ya | Ya | Ya | Ya |
| Slide catatan | Ya | Ya | Ya | Ya |
| Master handout | Ya | Ya | Ya | Ya |

Slide presentasi reguler tidak memiliki placeholder header. Header tersedia pada halaman catatan dan handout. Untuk slide reguler, gunakan placeholder footer, tanggal/waktu, dan nomor slide sebagai gantinya.

Ruang lingkup perubahan tergantung pada manager yang Anda gunakan. Kelas [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideheaderfootermanager/) mengontrol satu slide reguler. Kelas [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notesslideheaderfootermanager/) mengontrol satu slide catatan. Manager master dan layout juga dapat menyebarkan pengaturan ke slide yang bergantung, sementara kelas [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) mengontrol master handout.

## **Menetapkan Footer, Tanggal/Waktu, dan Nomor Slide pada Slide Reguler**

Untuk slide reguler, alur kerja dasar adalah mengakses manager header/footer setiap slide, mengatur teks footer dan tanggal/waktu, mengaktifkan placeholder yang diperlukan, dan menyimpan presentasi. Nomor slide dihasilkan oleh presentasi, jadi Anda hanya perlu mengontrol visibilitasnya.

Gunakan [`setFooterText`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) dan [`setDateTimeText`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) untuk mengatur teks, serta gunakan [`setFooterVisibility`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [`setDateTimeVisibility`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility), dan [`setSlideNumberVisibility`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) untuk menampilkan placeholder yang bersangkutan.

Contoh end-to-end berikut menerapkan footer, teks tanggal/waktu, dan visibilitas nomor slide yang sama ke semua slide reguler:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jika Anda perlu memperbarui hanya satu slide, akses slide tersebut secara langsung melalui metode [`getSlides`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getslides/) alih-alih iterasi seluruh koleksi.

## **Menetapkan Header dan Footer pada Master Catatan**

Master catatan mendefinisikan pemformatan umum dan perilaku placeholder untuk halaman catatan. Gunakan kelas [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) ketika Anda ingin mengubah hanya master catatan itu sendiri.

Contoh berikut mengatur header, footer, dan teks tanggal/waktu pada master catatan serta membuat semua placeholder yang didukung terlihat pada master tersebut:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metode [`getMasterNotesSlide`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) mengembalikan `null` ketika presentasi tidak berisi master catatan.

## **Menerapkan Pengaturan Master Catatan ke Slide Catatan Anak**

Master catatan dapat menerapkan pengaturan header dan footer ke dirinya sendiri dan ke semua slide catatan yang bergantung. Gunakan metode propagasi khusus pada [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) ketika pengaturan yang sama harus diterapkan di seluruh hierarki catatan.

Sebagai contoh, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) dan [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) memperbarui header master catatan dan semua header anak. Metode setara tersedia untuk footer, tanggal/waktu, dan nomor slide.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metode propagasi yang digunakan di atas meliputi [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility), dan [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Menetapkan Header dan Footer pada Slide Catatan Individual**

Slide catatan merupakan bagian dari slide reguler tertentu. Gunakan kelas [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notesslideheaderfootermanager/) ketika Anda ingin menyesuaikan hanya halaman catatan tersebut.

Metode [`addNotesSlide`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) mengembalikan slide catatan untuk slide saat ini dan membuat satu jika belum ada. Contoh berikut mengonfigurasi halaman catatan yang terkait dengan slide pertama presentasi:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jika Anda pertama-tama menyebarkan pengaturan dari master catatan dan kemudian mengubah slide catatan individual, pengaturan per-slide berikutnya memungkinkan Anda menyesuaikan halaman catatan tersebut secara independen.

## **Menetapkan Header dan Footer pada Master Handout**

Halaman handout menggunakan master handout untuk placeholder header, footer, tanggal/waktu, dan nomor halaman. Tidak seperti halaman catatan, pengaturan handout dikelola melalui master handout bukan melalui slide handout individual.

Gunakan [`getMasterHandoutSlide`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) untuk mengakses master handout. Jika tidak ada, panggil [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) untuk membuat master handout default.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Memahami Ruang Lingkup dan Pewarisan**

Pilih manager header/footer yang sesuai dengan ruang lingkup yang ingin Anda ubah:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideheaderfootermanager/) mengubah pengaturan footer, tanggal/waktu, dan nomor slide untuk satu slide reguler.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) mengontrol sebuah slide layout dan dapat menyebarkan pengaturan yang didukung ke slide yang bergantung.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslideheaderfootermanager/) mengontrol master slide reguler dan dapat menyebarkan pengaturan yang didukung ke slide yang bergantung.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) mengontrol master catatan dan dapat menyebarkan pengaturan ke semua slide catatan yang bergantung.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notesslideheaderfootermanager/) mengubah satu slide catatan dan mendukung placeholder header selain footer, tanggal/waktu, dan nomor slide.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) mengubah master handout dan mendukung keempat jenis placeholder.

Gunakan propagasi dari master atau layout ketika pengaturan yang sama harus berlaku di seluruh hierarki. Gunakan manager slide individual atau notes-slide ketika Anda memerlukan pengaturan lokal untuk satu halaman.

## **FAQ**

**Apakah saya dapat menambahkan header ke slide reguler?**

Tidak. PowerPoint tidak mendefinisikan placeholder header untuk slide reguler. Pada slide reguler, gunakan placeholder footer, tanggal/waktu, dan nomor slide. Placeholder header tersedia pada halaman catatan dan handout.

**Bagaimana jika placeholder footer, tanggal/waktu, atau nomor slide tidak terlihat?**

Gunakan manager header/footer yang bersangkutan untuk memeriksa visibilitasnya dan mengaktifkannya bila diperlukan. Misalnya, [`isFooterVisible`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) melaporkan apakah placeholder footer ada, dan [`setFooterVisibility`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) mengubah visibilitasnya.

**Bagaimana cara memulai penomoran slide dari nilai selain 1?**

Panggil metode [`setFirstSlideNumber`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) pada presentasi. Placeholder nomor slide kemudian akan menggunakan urutan penomoran yang diperbarui.

**Apa yang terjadi pada header dan footer saat mengekspor ke PDF, gambar, atau HTML?**

Elemen header dan footer yang terlihat dirender bersama konten presentasi lainnya dalam format output. Penampilannya tergantung pada jenis halaman yang diekspor dan pengaturan visibilitas placeholder yang bersangkutan.