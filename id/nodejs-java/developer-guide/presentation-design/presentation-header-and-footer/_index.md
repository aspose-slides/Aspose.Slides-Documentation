---
title: Kelola Header dan Footer Presentasi di JavaScript
linktitle: Header & Footer
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
description: "Gunakan JavaScript dan Aspose.Slides untuk Node.js untuk menambahkan dan menyesuaikan header serta footer pada presentasi PowerPoint dan OpenDocument agar tampilan menjadi profesional."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengelola pengaturan header dan footer dalam presentasi PowerPoint. Header dan footer ditangani pada tingkat master presentasi, dan API menyediakan metode untuk mengatur teks footer, mengubah visibilitas footer, dan memperbarui teks header pada slide master catatan.

Anda juga dapat mengelola header dan footer untuk slide handout dan catatan. Ini mencakup mengubah visibilitas dan teks placeholder header, footer, nomor slide, dan tanggal‑waktu untuk master catatan, semua slide catatan anak, atau slide catatan individu.

## **Kelola Header dan Footer dalam Presentasi**
Catatan beberapa slide tertentu dapat dihapus seperti yang ditunjukkan pada contoh di bawah:

```javascript
// Muat Presentasi
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // Mengatur Footer
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // Akses dan Perbarui Header
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // Simpan presentasi
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Kelola Header dan Footer dalam Slide Handout dan Catatan**
Aspose.Slides untuk Node.js via Java mendukung Header dan Footer dalam slide Handout dan catatan. Ikuti langkah‑langkah berikut:

- Muat sebuah [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang berisi video.
- Ubah pengaturan Header dan Footer untuk master catatan dan semua slide catatan.
- Atur placeholder Footer master catatan dan semua anak menjadi terlihat.
- Atur placeholder Tanggal dan waktu master catatan dan semua anak menjadi terlihat.
- Ubah pengaturan Header dan Footer hanya untuk slide catatan pertama.
- Atur placeholder Header slide catatan menjadi terlihat.
- Atur teks untuk placeholder Header slide catatan.
- Atur teks untuk placeholder Tanggal‑waktu slide catatan.
- Tulis file presentasi yang telah dimodifikasi.

Potongan kode disediakan dalam Contoh di bawah.

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // Ubah pengaturan Header dan Footer untuk master catatan dan semua slide catatan
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// buat slide master catatan dan semua placeholder Footer anak menjadi terlihat
        headerFooterManager.setFooterAndChildFootersVisibility(true);// buat slide master catatan dan semua placeholder Header anak menjadi terlihat
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// buat slide master catatan dan semua placeholder SlideNumber anak menjadi terlihat
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// buat slide master catatan dan semua placeholder Date dan time anak menjadi terlihat
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// set teks ke slide master catatan dan semua placeholder Header anak
        headerFooterManager.setFooterAndChildFootersText("Footer text");// set teks ke slide master catatan dan semua placeholder Footer anak
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// set teks ke slide master catatan dan semua placeholder Date dan time anak
    }
    // Ubah pengaturan Header dan Footer hanya untuk slide catatan pertama
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// buat placeholder Header slide catatan ini menjadi terlihat
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// buat placeholder Footer slide catatan ini menjadi terlihat
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// buat placeholder SlideNumber slide catatan ini menjadi terlihat
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// buat placeholder Date-time slide catatan ini menjadi terlihat
        headerFooterManager.setHeaderText("New header text");// set teks ke placeholder Header slide catatan
        headerFooterManager.setFooterText("New footer text");// set teks ke placeholder Footer slide catatan
        headerFooterManager.setDateTimeText("New date and time text");// set teks ke placeholder Date-time slide catatan
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah saya dapat menambahkan “header” pada slide reguler?**

Di PowerPoint, “Header” hanya ada untuk catatan dan handout; pada slide reguler, elemen yang didukung adalah footer, tanggal/waktu, dan nomor slide. Di Aspose.Slides hal ini memiliki batasan yang sama: header hanya untuk Catatan/Handout, dan pada slide—Footer/TanggalWaktu/NomorSlide.

**Bagaimana jika tata letak tidak memiliki area footer—apakah saya dapat “mengaktifkan” visibilitasnya?**

Ya. Periksa visibilitas melalui manajer header/footer dan aktifkan bila diperlukan. Indikator dan metode API ini dirancang untuk kasus ketika placeholder tidak ada atau disembunyikan.

**Bagaimana cara membuat nomor slide mulai dari nilai selain 1?**

Atur [first slide number](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) presentasi; setelah itu, semua penomoran dihitung ulang. Misalnya, Anda dapat memulai dari 0 atau 10, dan menyembunyikan nomor pada slide judul.

**Apa yang terjadi pada header/footer saat mengekspor ke PDF/gambar/HTML?**

Mereka dirender sebagai elemen teks biasa dalam presentasi. Artinya, jika elemen tersebut terlihat pada slide/halaman catatan, mereka juga akan muncul dalam format output bersama dengan konten lainnya.