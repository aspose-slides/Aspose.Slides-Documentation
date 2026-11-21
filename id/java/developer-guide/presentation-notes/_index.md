---
title: Kelola Catatan Presentasi di Java
linktitle: Catatan Presentasi
type: docs
weight: 110
url: /id/java/presentation-notes/
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
- Java
- Aspose.Slides
description: "Sesuaikan catatan presentasi dengan Aspose.Slides untuk Java. Bekerja dengan lancar pada catatan PowerPoint dan OpenDocument untuk meningkatkan produktivitas Anda."
---
## **Gambaran Umum**

Aspose.Slides mendukung penghapusan slide catatan dari presentasi. Pada topik ini, kami akan memperkenalkan fitur ini, termasuk cara menghapus catatan dan cara menerapkan gaya ke slide catatan dalam presentasi. Aspose.Slides memungkinkan Anda menghapus catatan dari slide mana pun dan juga menerapkan styling ke catatan yang ada. Pengembang dapat menghapus catatan dengan cara berikut:

- Menghapus catatan dari slide tertentu dalam presentasi.
- Menghapus catatan dari semua slide dalam presentasi.

Untuk membaca atau mengubah dimensi halaman catatan, mengubah orientasi, dan memeriksa perilaku ekspor, lihat [Ukuran Halaman Catatan](/slides/id/java/notes-size/).

## **Menghapus Catatan dari Slide**
Catatan dari slide tertentu dapat dihapus seperti yang ditunjukkan pada contoh di bawah ini:

```java
import com.aspose.slides.*;

// Buat objek Presentation yang mewakili file presentasi
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Menghapus catatan pada slide pertama
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Menyimpan presentasi ke disk
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Menghapus Catatan dari Presentasi**
Catatan dari semua slide dalam presentasi dapat dihapus seperti yang ditunjukkan pada contoh di bawah ini:

```java
import com.aspose.slides.*;

// Membuat objek Presentation yang mewakili file presentasi
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Menghapus catatan pada semua slide
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

## **Menambahkan Gaya Catatan**
[getNotesStyle](https://reference.aspose.com/slides/id/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) method telah ditambahkan ke antarmuka [IMasterNotesSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/IMasterNotesSlide) dan kelas [MasterNotesSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/MasterNotesSlide) masing-masing. Properti ini menentukan gaya teks catatan. Implementasinya ditunjukkan dalam contoh di bawah.

```java
import com.aspose.slides.*;

// Membuat objek Presentation yang mewakili file presentasi
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Dapatkan gaya teks MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Set bullet simbol untuk paragraf level pertama
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

Catatan diakses melalui pengelola catatan slide: slide memiliki [NotesSlideManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/notesslidemanager/) dan sebuah [method](https://reference.aspose.com/slides/id/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) yang mengembalikan objek catatan, atau `null` jika tidak ada catatan.

**Apakah ada perbedaan dukungan catatan di antara versi PowerPoint yang didukung perpustakaan?**

Perpustakaan ini menargetkan berbagai format Microsoft PowerPoint (97–terbaru) dan ODP; catatan didukung dalam format-format ini tanpa bergantung pada instalasi PowerPoint.