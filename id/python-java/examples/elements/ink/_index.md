---
title: Tinta
type: docs
weight: 180
url: /id/python-java/examples/elements/ink/
keywords:
- contoh kode
- tinta
- akses tinta
- hapus tinta
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Akses dan hapus bentuk tinta dalam presentasi Aspose.Slides untuk Python via Java, termasuk file PPT, PPTX, dan ODP."
---
Artikel ini menyediakan contoh cara mengakses bentuk tinta yang ada dan menghapusnya menggunakan **Aspose.Slides for Python via Java**.

Instal paket seperti yang dijelaskan di [Installation](/slides/id/python-java/installation/). Setiap contoh mengimpor `asposeslides` sebelum memulai JVM, lalu mengimpor API setelah JVM berjalan.

{{% alert color="info" title="Note" %}}
Bentuk tinta mewakili masukan pengguna dari perangkat khusus. Aspose.Slides tidak dapat membuat goresan tinta baru secara programatis, tetapi Anda dapat membaca dan memodifikasi tinta yang ada.
{{% /alert %}}

## **Akses Tinta**

Baca tag dari bentuk tinta pertama pada slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # Gunakan tag_name sesuai kebutuhan.
finally:
    presentation.dispose()
```

## **Hapus Tinta**

Hapus bentuk tinta dari slide jika ada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    ink = None
    for shape in slide.getShapes():
        if isinstance(shape, Ink):
            ink = shape
            break

    if ink is not None:
        slide.getShapes().remove(ink)
finally:
    presentation.dispose()
```