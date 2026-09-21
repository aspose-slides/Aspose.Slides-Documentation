---
title: Kelola Catatan Presentasi dalam JavaScript
linktitle: Catatan Presentasi
type: docs
weight: 110
url: /id/nodejs-java/presentation-notes/
keywords:
- catatan
- slide catatan
- tambahkan catatan
- hapus catatan
- gaya catatan
- catatan master
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Sesuaikan catatan presentasi dalam JavaScript dengan Aspose.Slides untuk Node.js. Kerjakan catatan PowerPoint dan OpenDocument secara mulus untuk meningkatkan produktivitas Anda."
---
## **Gambaran Umum**

Aspose.Slides mendukung penghapusan slide catatan dari sebuah presentasi. Pada topik ini, kami akan memperkenalkan fitur ini, termasuk cara menghapus catatan dan cara menerapkan gaya pada slide catatan dalam sebuah presentasi. Aspose.Slides memungkinkan Anda menghapus catatan dari slide mana pun serta menerapkan gaya pada catatan yang ada. Pengembang dapat menghapus catatan dengan cara berikut:

- Menghapus catatan dari slide tertentu dalam sebuah presentasi.
- Menghapus catatan dari semua slide dalam sebuah presentasi.

Untuk membaca atau mengubah dimensi halaman catatan, mengubah orientasi, dan memeriksa perilaku ekspor, lihat [Ukuran Halaman Catatan](/slides/id/nodejs-java/notes-size/).

## **Hapus Catatan dari Slide**
Catatan dari slide tertentu dapat dihapus seperti yang ditunjukkan pada contoh di bawah ini:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Buat objek Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Menghapus catatan slide pertama
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // Menyimpan presentasi ke disk
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hapus Catatan dari Presentasi**
Catatan dari semua slide dalam sebuah presentasi dapat dihapus seperti yang ditunjukkan pada contoh di bawah ini:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Buat objek Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Menghapus catatan semua slide
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // Menyimpan presentasi ke disk
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tambah NotesStyle**
[getNotesStyle](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) method telah ditambahkan ke kelas [MasterNotesSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/MasterNotesSlide) dan kelas [MasterNotesSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/MasterNotesSlide) masing‑masing. Properti ini menentukan gaya teks catatan. Implementasinya ditunjukkan dalam contoh di bawah ini.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Buat objek Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Dapatkan gaya teks MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // Atur bullet simbol untuk paragraf level pertama
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Entitas API mana yang menyediakan akses ke catatan slide tertentu?**

Catatan dapat diakses melalui manajer catatan slide: slide memiliki [NotesSlideManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notesslidemanager/) dan sebuah [method](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) yang mengembalikan objek catatan, atau `null` jika tidak ada catatan.

**Apakah ada perbedaan dukungan catatan di antara versi PowerPoint yang didukung perpustakaan?**

Perpustakaan menargetkan berbagai format Microsoft PowerPoint (97–terbaru) dan ODP; catatan didukung dalam format‑format ini tanpa bergantung pada instalasi PowerPoint yang ada.