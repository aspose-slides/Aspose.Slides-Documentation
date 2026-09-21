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
description: "Sesuaikan catatan presentasi dengan Aspose.Slides untuk .NET. Bekerja secara mulus dengan catatan PowerPoint dan OpenDocument untuk meningkatkan produktivitas Anda."
---
## **Gambaran Umum**

Aspose.Slides mendukung penghapusan slide catatan dari presentasi. Dalam topik ini, kami akan memperkenalkan fitur ini, termasuk cara menghapus catatan dan cara menerapkan gaya pada slide catatan dalam sebuah presentasi. Aspose.Slides memungkinkan Anda menghapus catatan dari slide mana pun dan juga menerapkan gaya pada catatan yang ada. Pengembang dapat menghapus catatan dengan cara berikut:

- Menghapus catatan dari slide tertentu dalam presentasi.
- Menghapus catatan dari semua slide dalam presentasi.

Untuk membaca atau mengubah dimensi halaman catatan, mengubah orientasi, dan memeriksa perilaku ekspor, lihat [Ukuran Halaman Catatan](/slides/id/net/notes-size/).

## **Menghapus Catatan dari Slide**

Catatan dari slide tertentu dapat dihapus seperti yang ditunjukkan pada contoh di bawah ini:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Membuat objek Presentation yang mewakili file presentasi
Presentation presentation = new Presentation("AccessSlides.pptx");

// Menghapus catatan slide pertama
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Simpan presentasi ke disk
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Menghapus Catatan dari Semua Slide**

Catatan dari semua slide dalam sebuah presentasi dapat dihapus seperti yang ditunjukkan pada contoh di bawah ini:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Menambahkan Gaya Catatan**

Properti NotesStyle telah ditambahkan ke antarmuka [IMasterNotesSlide](https://reference.aspose.com/slides/id/net/aspose.slides/imasternotesslide) dan kelas [MasterNotesSlide](https://reference.aspose.com/slides/id/net/aspose.slides/masternotesslide) masing‑masing. Properti ini menentukan gaya teks catatan. Implementasinya ditunjukkan dalam contoh di bawah ini.

```c#
using Aspose.Slides;

// Membuat instance kelas Presentation yang mewakili file presentasi
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Dapatkan gaya teks MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Set simbol bullet untuk paragraf tingkat pertama
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Simpan file PPTX ke Disk
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **FAQ**

### Entitas API mana yang menyediakan akses ke catatan slide tertentu?

Catatan diakses melalui pengelola catatan slide: slide memiliki [NotesSlideManager](https://reference.aspose.com/slides/id/net/aspose.slides/notesslidemanager/) dan sebuah [property](https://reference.aspose.com/slides/id/net/aspose.slides/notesslidemanager/notesslide/) yang mengembalikan objek catatan, atau `null` jika tidak ada catatan.

### Apakah ada perbedaan dukungan catatan di antara versi PowerPoint yang didukung perpustakaan ini?

Perpustakaan ini menargetkan berbagai format Microsoft PowerPoint (97–terbaru) dan ODP; catatan didukung dalam format-format tersebut tanpa bergantung pada salinan PowerPoint yang terpasang.