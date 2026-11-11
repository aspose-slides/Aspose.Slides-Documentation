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
description: "Sesuaikan catatan presentasi dengan Aspose.Slides untuk Python via .NET. Bekerja dengan mulus pada catatan PowerPoint dan OpenDocument untuk meningkatkan produktivitas Anda."
---
## **Gambaran Umum**

Aspose.Slides mendukung penghapusan slide catatan dari sebuah presentasi. Dalam topik ini, kami akan memperkenalkan fitur ini, termasuk cara menghapus catatan dan cara menerapkan gaya pada slide catatan dalam sebuah presentasi. Aspose.Slides memungkinkan Anda menghapus catatan dari slide mana pun dan juga menerapkan gaya pada catatan yang ada. Pengembang dapat menghapus catatan dengan cara berikut:

- Hapus catatan dari slide tertentu dalam presentasi.
- Hapus catatan dari semua slide dalam presentasi.

Untuk membaca atau mengubah dimensi halaman catatan, mengubah orientasi, dan memeriksa perilaku ekspor, lihat [Ukuran Halaman Catatan](/slides/id/python-net/notes-size/).

## **Hapus Catatan dari Slide**
Catatan dari slide tertentu dapat dihapus seperti ditunjukkan pada contoh di bawah ini:

```py
import aspose.slides as slides

# Membuat objek Presentation yang mewakili file presentasi 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Menghapus catatan slide pertama
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # menyimpan presentasi ke disk
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hapus Catatan dari Semua Slide**
Catatan dari semua slide dalam presentasi dapat dihapus seperti ditunjukkan pada contoh di bawah ini:

```py
import aspose.slides as slides

# Membuat objek Presentation yang mewakili file presentasi 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Menghapus catatan semua slide
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # menyimpan presentasi ke disk
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Terapkan Gaya Catatan**
Properti [notes_style](https://reference.aspose.com/slides/id/python-net/aspose.slides/masternotesslide/notes_style/) telah ditambahkan ke kelas [MasterNotesSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/masternotesslide/). Properti ini menentukan gaya teks catatan. Implementasinya ditunjukkan dalam contoh di bawah ini.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file presentasi
with slides.Presentation("AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Dapatkan gaya teks MasterNotesSlide
        notesStyle = notesMaster.notes_style

        #Set simbol bullet untuk paragraf level pertama
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # menyimpan file PPTX ke Disk
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Entitas API mana yang memberikan akses ke catatan slide tertentu?**

Catatan diakses melalui manajer catatan slide: slide memiliki [NotesSlideManager](https://reference.aspose.com/slides/id/python-net/aspose.slides/notesslidemanager/) dan sebuah [property](https://reference.aspose.com/slides/id/python-net/aspose.slides/notesslidemanager/notes_slide/) yang mengembalikan objek catatan, atau `None` jika tidak ada catatan.

**Apakah ada perbedaan dukungan catatan di antara versi PowerPoint yang didukung oleh perpustakaan ini?**

Perpustakaan ini mendukung berbagai format Microsoft PowerPoint (97–newer) dan ODP; catatan didukung dalam format tersebut tanpa bergantung pada salinan PowerPoint yang terpasang.