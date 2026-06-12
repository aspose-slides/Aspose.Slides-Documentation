---
title: Kelola Catatan Presentasi dalam JavaScript
linktitle: Catatan Presentasi
type: docs
weight: 110
url: /id/nodejs-java/presentation-notes/
keywords:
- catatan
- slide catatan
- menambahkan catatan
- menghapus catatan
- gaya catatan
- master catatan
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Sesuaikan catatan presentasi dalam JavaScript dengan Aspose.Slides untuk Node.js. Bekerja secara mulus dengan catatan PowerPoint dan OpenDocument untuk meningkatkan produktivitas Anda."
---
## **Ringkasan**

Aspose.Slides mendukung penghapusan slide catatan dari presentasi. Dalam topik ini, kami akan memperkenalkan fitur ini, termasuk cara menghapus catatan dan cara menerapkan gaya pada slide catatan dalam presentasi. Aspose.Slides memungkinkan Anda menghapus catatan dari slide mana pun dan juga menerapkan gaya pada catatan yang ada. Pengembang dapat menghapus catatan dengan cara berikut:

- Menghapus catatan dari slide tertentu dalam presentasi.
- Menghapus catatan dari semua slide dalam presentasi.

## **Hapus Catatan dari Slide**
Catatan dari slide tertentu dapat dihapus seperti pada contoh di bawah:

```javascript
// Membuat objek Presentation yang mewakili file presentasi
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
Catatan dari semua slide dalam presentasi dapat dihapus seperti pada contoh di bawah:

```javascript
// Membuat objek Presentation yang mewakili file presentasi
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
Metode[getNotesStyle](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) telah ditambahkan ke kelas[MasterNotesSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/MasterNotesSlide) dan kelas[MasterNotesSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/MasterNotesSlide) masing-masing. Properti ini menentukan gaya teks catatan. Implementasinya ditunjukkan pada contoh di bawah.

```javascript
// Membuat objek Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Dapatkan gaya teks MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // Atur bullet simbol untuk paragraf tingkat pertama
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(aspose.slides.BulletType.Symbol);
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

Catatan diakses melalui manajer catatan slide: slide memiliki[NotesSlideManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notesslidemanager/) dan sebuah[method](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) yang mengembalikan objek catatan, atau `null` jika tidak ada catatan.

**Apakah ada perbedaan dukungan catatan di antara versi PowerPoint yang didukung perpustakaan?**

Perpustakaan menargetkan berbagai format Microsoft PowerPoint (97-newer) dan ODP; catatan didukung dalam format tersebut tanpa bergantung pada salinan PowerPoint yang terinstal.