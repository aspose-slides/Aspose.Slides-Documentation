---
title: Kelola Catatan Presentasi di Python via Java
linktitle: Catatan Presentasi
type: docs
weight: 110
url: /id/python-java/presentation-notes/
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
- Java
- Aspose.Slides
description: "Sesuaikan catatan presentasi dengan Aspose.Slides untuk Python via Java. Bekerja mulus dengan catatan PowerPoint dan OpenDocument untuk meningkatkan produktivitas Anda."
---
## **Gambaran Umum**

Aspose.Slides mendukung penghapusan slide catatan dari sebuah presentasi. Topik ini memperkenalkan fitur tersebut, termasuk cara menghapus catatan dan cara menerapkan gaya pada slide catatan dalam sebuah presentasi. Aspose.Slides memungkinkan Anda menghapus catatan dari slide mana pun dan menerapkan gaya pada catatan yang ada. Pengembang dapat menghapus catatan dengan cara berikut:

- Menghapus catatan dari slide tertentu dalam sebuah presentasi.
- Menghapus catatan dari semua slide dalam sebuah presentasi.

## **Hapus Catatan dari Slide**

Catatan dari slide tertentu dapat dihapus seperti yang ditunjukkan pada contoh di bawah ini:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Membuat objek Presentation yang mewakili file presentasi.
presentation = Presentation("presWithNotes.pptx")
try:
    # Hapus catatan dari slide pertama.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # Simpan presentasi ke disk.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hapus Catatan dari Presentasi**

Catatan dari semua slide dalam sebuah presentasi dapat dihapus seperti yang ditunjukkan pada contoh di bawah ini:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Membuat objek Presentation yang mewakili file presentasi.
presentation = Presentation("presWithNotes.pptx")
try:
    # Hapus catatan dari semua slide.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # Simpan presentasi ke disk.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tambahkan Gaya Catatan**

Metode [getNotesStyle](https://reference.aspose.com/slides/id/python-java/aspose.slides/masternotesslide/#getNotesStyle) dari kelas [MasterNotesSlide](https://reference.aspose.com/slides/id/python-java/aspose.slides/masternotesslide/) memberikan akses ke gaya teks catatan. Implementasinya ditunjukkan dalam contoh di bawah ini.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# Membuat objek Presentation yang mewakili file presentasi.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # Dapatkan gaya teks master notes slide.
        notes_style = notes_master.getNotesStyle()

        # Atur bullet simbol untuk paragraf tingkat pertama.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Entitas API mana yang menyediakan akses ke catatan slide tertentu?**

Catatan dapat diakses melalui manajer catatan slide: slide memiliki [NotesSlideManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/notesslidemanager/) dan metode [getNotesSlide](https://reference.aspose.com/slides/id/python-java/aspose.slides/notesslidemanager/#getNotesSlide) yang mengembalikan objek catatan, atau `None` jika tidak ada catatan.

**Apakah ada perbedaan dukungan catatan di antara versi PowerPoint yang didukung library?**

Library ini menargetkan berbagai format Microsoft PowerPoint (versi 97 ke atas) dan ODP; catatan didukung dalam format tersebut tanpa bergantung pada instalasi PowerPoint.