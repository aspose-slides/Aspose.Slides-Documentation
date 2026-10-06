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
description: "Sesuaikan catatan presentasi dengan Aspose.Slides untuk Android melalui Java. Bekerja dengan mulus pada catatan PowerPoint dan OpenDocument untuk meningkatkan produktivitas Anda."
---
## **Overview**

Aspose.Slides mendukung penghapusan slide catatan dari sebuah presentasi. Pada topik ini, kami akan memperkenalkan fitur ini, termasuk cara menghapus catatan dan cara menerapkan gaya pada slide catatan dalam sebuah presentasi. Aspose.Slides memungkinkan Anda menghapus catatan dari slide mana pun serta menerapkan gaya pada catatan yang ada. Pengembang dapat menghapus catatan dengan cara berikut:

- Menghapus catatan dari slide tertentu dalam sebuah presentasi.
- Menghapus catatan dari semua slide dalam sebuah presentasi.

Untuk membaca atau mengubah dimensi halaman catatan, mengubah orientasi, dan memeriksa perilaku ekspor, lihat [Notes Page Size](/slides/id/androidjava/notes-size/).

## **Remove Notes from a Slide**
Catatan dari slide tertentu dapat dihapus seperti yang ditunjukkan pada contoh di bawah ini:

```java
import com.aspose.slides.*;

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

## **Remove Notes from a Presentation**
Catatan dari semua slide dalam sebuah presentasi dapat dihapus seperti yang ditunjukkan pada contoh di bawah ini:

```java
import com.aspose.slides.*;

// Membuat objek Presentation yang mewakili file presentasi
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Menghapus catatan semua slide
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

## **Add a Notes Style**
[getNotesStyle](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) method telah ditambahkan ke antarmuka [IMasterNotesSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IMasterNotesSlide) dan kelas [MasterNotesSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/MasterNotesSlide) masing‑masing. Properti ini menentukan gaya teks catatan. Implementasinya ditunjukkan pada contoh di bawah ini.

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
    
        // Atur bullet simbol untuk paragraf level pertama
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Which API entity provides access to the notes of a specific slide?**

Catatan diakses melalui manajer catatan slide: slide memiliki [NotesSlideManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/notesslidemanager/) dan sebuah [method](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) yang mengembalikan objek catatan, atau `null` jika tidak ada catatan.

**Are there differences in notes support across the PowerPoint versions the library works with?**

Perpustakaan ini mendukung berbagai format Microsoft PowerPoint (97‑sejak versi terbaru) dan ODP; catatan didukung dalam format‑format ini tanpa tergantung pada instalasi PowerPoint.