---
title: Kelola Catatan Presentasi di Android
linktitle: Catatan Presentasi
type: docs
weight: 110
url: /id/androidjava/presentation-notes/
keywords:
- catatan
- slide catatan
- menambahkan catatan
- menghapus catatan
- gaya catatan
- catatan master
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Sesuaikan catatan presentasi dengan Aspose.Slides untuk Android via Java. Bekerja secara mulus dengan catatan PowerPoint dan OpenDocument untuk meningkatkan produktivitas Anda."
---
## **Ikhtisar**

Aspose.Slides mendukung penghapusan slide catatan dari sebuah presentasi. Dalam topik ini, kami akan memperkenalkan fitur ini, termasuk cara menghapus catatan dan cara menerapkan gaya pada slide catatan dalam sebuah presentasi. Aspose.Slides memungkinkan Anda menghapus catatan dari slide mana pun serta menerapkan gaya pada catatan yang sudah ada. Pengembang dapat menghapus catatan dengan cara berikut:

- Menghapus catatan dari slide tertentu dalam sebuah presentasi.
- Menghapus catatan dari semua slide dalam sebuah presentasi.

## **Hapus Catatan dari Slide**
Catatan dari slide tertentu dapat dihapus seperti yang ditunjukkan dalam contoh di bawah ini:

```java
// Membuat objek Presentation yang mewakili file presentasi
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Menghapus catatan slide pertama
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Menyimpan presentasi ke disk
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hapus Catatan dari Presentasi**
Catatan dari semua slide dalam sebuah presentasi dapat dihapus seperti yang ditunjukkan dalam contoh di bawah ini:

```java
// Membuat objek Presentation yang mewakili file presentasi
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Menghapus catatan dari semua slide
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Menyimpan presentasi ke disk
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tambahkan Gaya Catatan**
[getNotesStyle](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) metode telah ditambahkan ke [IMasterNotesSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IMasterNotesSlide) interface dan kelas [MasterNotesSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/MasterNotesSlide) masing‑masing. Properti ini menentukan gaya teks catatan. Implementasinya ditunjukkan dalam contoh di bawah ini.

```java
// Membuat objek Presentation yang mewakili file presentasi
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Dapatkan gaya teks MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Setel bullet simbol untuk paragraf tingkat pertama
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Entitas API mana yang menyediakan akses ke catatan slide tertentu?**

Catatan diakses melalui manajer catatan slide: slide memiliki [NotesSlideManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/notesslidemanager/) dan sebuah [method](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) yang mengembalikan objek catatan, atau `null` jika tidak ada catatan.

**Apakah ada perbedaan dalam dukungan catatan di antara versi PowerPoint yang didukung pustaka ini?**

Pustaka ini menargetkan berbagai format Microsoft PowerPoint (97–lebih baru) dan ODP; catatan didukung dalam format‑format tersebut tanpa bergantung pada salinan PowerPoint yang terpasang.