---
title: Tabel
type: docs
weight: 120
url: /id/python-java/examples/elements/table/
keywords:
- contoh kode
- tabel
- menambahkan tabel
- mengakses tabel
- menghapus tabel
- menggabungkan sel
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Bekerja dengan tabel di Aspose.Slides untuk Python via Java: menambahkan, mengakses, menghapus, dan menggabungkan sel dalam presentasi PowerPoint dan OpenDocument."
---
Contoh untuk menambahkan tabel, mengaksesnya, menghapusnya, dan menggabungkan sel menggunakan **Aspose.Slides for Python via Java**.

Instal paket seperti yang dijelaskan dalam [Installation](/slides/id/python-java/installation/). Setiap contoh mengimpor `asposeslides` sebelum memulai JVM, kemudian mengimpor API setelah JVM berjalan.

## **Menambahkan Tabel**

Buat tabel sederhana dengan dua baris dan dua kolom.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)
finally:
    presentation.dispose()
```

## **Mengakses Tabel**

Ambil bentuk tabel pertama pada slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # Akses tabel pertama pada slide.
    first_table = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Table):
            first_table = shape
            break
finally:
    presentation.dispose()
```

## **Menghapus Tabel**

Hapus tabel dari slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    slide.getShapes().remove(table)
finally:
    presentation.dispose()
```

## **Menggabungkan Sel Tabel**

Gabungkan sel berdekatan pada tabel menjadi satu sel.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # Gabungkan sel.
    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), False)
finally:
    presentation.dispose()
```