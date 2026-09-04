---
title: Catatan
type: docs
weight: 240
url: /id/python-java/examples/elements/note/
keywords:
- contoh kode
- catatan
- catatan pembicara
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Bekerja dengan catatan slide di Aspose.Slides untuk Python via Java: menambahkan, membaca, menghapus, dan memperbarui catatan pembicara dalam presentasi PowerPoint dan OpenDocument."
---
Artikel ini menunjukkan cara menambahkan, membaca, menghapus, dan memperbarui slide catatan menggunakan **Aspose.Slides for Python via Java**.

Instal paket seperti dijelaskan di [Installation](/slides/id/python-java/installation/). Setiap contoh mengimpor `asposeslides` sebelum memulai JVM, kemudian mengimpor API setelah JVM berjalan.

## **Tambah Slide Catatan**

Buat slide catatan dan tetapkan teks ke dalamnya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")
finally:
    presentation.dispose()
```

## **Akses Slide Catatan**

Baca teks dari slide catatan yang ada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")

    notes = notes_slide.getNotesTextFrame().getText()
    print(notes)
finally:
    presentation.dispose()
```

## **Hapus Slide Catatan**

Hapus slide catatan yang terkait dengan slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getNotesSlideManager().addNotesSlide()
    slide.getNotesSlideManager().removeNotesSlide()
finally:
    presentation.dispose()
```

## **Perbarui Teks Catatan**

Ubah teks slide catatan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("Old")
    notes_slide.getNotesTextFrame().setText("Updated")
finally:
    presentation.dispose()
```