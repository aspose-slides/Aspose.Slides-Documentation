---
title: Grup Bentuk
type: docs
weight: 170
url: /id/python-java/examples/elements/group-shape/
keywords:
- contoh kode
- grup bentuk
- tambah grup bentuk
- akses grup bentuk
- hapus grup bentuk
- lepas grup bentuk
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Kelola grup bentuk dalam presentasi dengan Aspose.Slides for Python via Java: tambahkan, akses, hapus, dan lepas grup bentuk dalam file PowerPoint dan OpenDocument."
---
Artikel ini menunjukkan cara membuat grup bentuk, mengaksesnya, menghapusnya, dan memisahkan isi grup menggunakan **Aspose.Slides for Python via Java**.

Instal paket seperti yang dijelaskan di [Instalasi](/slides/id/python-java/installation/). Setiap contoh mengimpor `asposeslides` sebelum memulai JVM, lalu mengimpor API setelah JVM berjalan.

## **Tambah Bentuk Grup**

Buat grup yang berisi dua bentuk dasar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50)
finally:
    presentation.dispose()
```

## **Akses Bentuk Grup**

Ambil bentuk grup pertama dari slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    first_group = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, GroupShape):
            first_group = shape
            break
finally:
    presentation.dispose()
```

## **Hapus Bentuk Grup**

Hapus bentuk grup dari slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()

    slide.getShapes().remove(group)
finally:
    presentation.dispose()
```

## **Lepaskan Grup Bentuk**

Pindahkan sebuah bentuk keluar dari kontainer grup.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    rectangle = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    # Pindahkan bentuk keluar dari grup.
    slide.getShapes().addClone(rectangle)
    group.getShapes().remove(rectangle)
finally:
    presentation.dispose()
```