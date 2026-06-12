---
title: Kelola Catatan Presentasi di Python
linktitle: Catatan Presentasi
type: docs
weight: 110
url: /id/python-net/presentation-notes/
keywords:
- catatan
- slide catatan
- tambahkan catatan
- hapus catatan
- gaya catatan
- master catatan
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Sesuaikan catatan presentasi dengan Aspose.Slides untuk Python via .NET. Bekerja mulus dengan catatan PowerPoint dan OpenDocument untuk meningkatkan produktivitas Anda."
---
## **Gambaran Umum**

Aspose.Slides mendukung penghapusan slide catatan dari presentasi. Pada topik ini, kami akan memperkenalkan fitur tersebut, termasuk cara menghapus catatan dan cara menerapkan gaya pada slide catatan dalam sebuah presentasi. Aspose.Slides memungkinkan Anda menghapus catatan dari slide mana pun serta menerapkan gaya pada catatan yang ada. Pengembang dapat menghapus catatan dengan cara berikut:

- Menghapus catatan dari slide tertentu dalam sebuah presentasi.  
- Menghapus catatan dari semua slide dalam sebuah presentasi.

## **Hapus Catatan dari Slide**
Catatan dari slide tertentu dapat dihapus seperti yang ditunjukkan pada contoh di bawah:

```py
import aspose.slides as slides

# Membuat objek Presentation yang mewakili file presentasi
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Menghapus catatan pada slide pertama
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # menyimpan presentasi ke disk
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hapus Catatan dari Semua Slide**
Catatan dari semua slide dalam sebuah presentasi dapat dihapus seperti yang ditunjukkan pada contoh di bawah:

```py
import aspose.slides as slides

# Membuat objek Presentation yang mewakili file presentasi 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Menghapus catatan pada semua slide
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # menyimpan presentasi ke disk
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Tambah NotesStyle**
Properti [notes_style](https://reference.aspose.com/slides/id/python-net/aspose.slides/masternotesslide/notes_style/) telah ditambahkan ke kelas [MasterNotesSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/masternotesslide/). Properti ini menentukan gaya teks catatan. Implementasinya ditunjukkan pada contoh di bawah.

```py
import aspose.slides as slides

# Membuat kelas Presentation yang mewakili file presentasi
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Dapatkan gaya teks MasterNotesSlide
        notesStyle = notesMaster.notes_style

        #Set simbol bullet untuk paragraf level pertama
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # simpan file PPTX ke Disk
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Entitas API mana yang memberikan akses ke catatan slide tertentu?**

Catatan diakses melalui manajer catatan slide: slide memiliki [NotesSlideManager](https://reference.aspose.com/slides/id/python-net/aspose.slides/notesslidemanager/) dan sebuah [property](https://reference.aspose.com/slides/id/python-net/aspose.slides/notesslidemanager/notes_slide/) yang mengembalikan objek catatan, atau `None` jika tidak ada catatan.

**Apakah ada perbedaan dukungan catatan di antara versi PowerPoint yang didukung oleh pustaka ini?**

Pustaka ini mendukung berbagai format Microsoft PowerPoint (97–versi terbaru) serta ODP; catatan didukung dalam format-format tersebut tanpa bergantung pada instalasi PowerPoint.