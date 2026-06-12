---
title: Kelola Catatan Presentasi di .NET
linktitle: Catatan Presentasi
type: docs
weight: 110
url: /id/net/presentation-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Sesuaikan catatan presentasi dengan Aspose.Slides untuk .NET. Bekerja mulus dengan catatan PowerPoint dan OpenDocument untuk meningkatkan produktivitas Anda."
---
## **Ikhtisar**

Aspose.Slides mendukung penghapusan catatan slide dari sebuah presentasi. Dalam topik ini, kami akan memperkenalkan fitur ini, termasuk cara menghapus catatan dan cara menerapkan gaya pada catatan slide dalam sebuah presentasi. Aspose.Slides memungkinkan Anda menghapus catatan dari slide mana pun dan juga menerapkan gaya pada catatan yang ada. Pengembang dapat menghapus catatan dengan cara berikut:

- Hapus catatan dari slide tertentu dalam presentasi.
- Hapus catatan dari semua slide dalam presentasi.

## **Hapus Catatan dari Slide**
Catatan pada slide tertentu dapat dihapus seperti yang ditunjukkan pada contoh di bawah:

```c#
// Membuat objek Presentation yang mewakili file presentasi 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// Menghapus catatan slide pertama
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Simpan presentasi ke disk
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Hapus Catatan dari Semua Slide**
Catatan pada semua slide dalam sebuah presentasi dapat dihapus seperti yang ditunjukkan pada contoh di bawah:

```c#
// Membuat objek Presentation yang mewakili file presentasi 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Menghapus catatan semua slide
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Simpan presentasi ke disk
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **Tambahkan Gaya Catatan**
Properti NotesStyle telah ditambahkan ke antarmuka[IMasterNotesSlide](https://reference.aspose.com/slides/id/net/aspose.slides/imasternotesslide)dan kelas[MasterNotesSlide](https://reference.aspose.com/slides/id/net/aspose.slides/masternotesslide)masing‑masing. Properti ini menentukan gaya teks catatan. Implementasinya ditunjukkan dalam contoh di bawah.

```c#
 // Membuat instance kelas Presentation yang mewakili file presentasi
 using (Presentation presentation = new Presentation("AccessSlides.pptx"))
 {
     IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

     if (notesMaster != null)
     {
         // Dapatkan gaya teks MasterNotesSlide
         ITextStyle notesStyle = notesMaster.NotesStyle;

         //Atur simbol bullet untuk paragraf tingkat pertama
         IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
         paragraphFormat.Bullet.Type = BulletType.Symbol;
     }

     // Simpan file PPTX ke Disk
     presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

 }
```

## **FAQ**

**Entitas API mana yang menyediakan akses ke catatan slide tertentu?**

Catatan diakses melalui pengelola catatan slide: slide memiliki[NotesSlideManager](https://reference.aspose.com/slides/id/net/aspose.slides/notesslidemanager/)dan sebuah[property](https://reference.aspose.com/slides/id/net/aspose.slides/notesslidemanager/notesslide/)yang mengembalikan objek catatan, atau `null` jika tidak ada catatan.

**Apakah ada perbedaan dukungan catatan di antara versi PowerPoint yang didukung pustaka ini?**

Pustaka ini mendukung beragam format Microsoft PowerPoint (97–terbaru) dan ODP; catatan didukung dalam format‑format ini tanpa bergantung pada instalasi PowerPoint.