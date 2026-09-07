---
title: SmartArt
type: docs
weight: 140
url: /id/python-java/examples/elements/smart-art/
keywords:
- contoh kode
- SmartArt
- menambahkan SmartArt
- mengakses SmartArt
- menghapus SmartArt
- tata letak SmartArt
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Bekerja dengan SmartArt di Aspose.Slides for Python via Java: menambahkan, mengakses, menghapus, dan mengubah tata letak diagram dalam presentasi PowerPoint dan OpenDocument."
---
Artikel ini menunjukkan cara menambahkan grafik SmartArt, mengaksesnya, menghapusnya, dan mengubah tata letak menggunakan **Aspose.Slides for Python via Java**.

Instal paket sebagaimana dijelaskan dalam [Installation](/slides/id/python-java/installation/). Setiap contoh mengimpor `asposeslides` sebelum memulai JVM, kemudian mengimpor API setelah JVM berjalan.

## **Menambahkan SmartArt**

Sisipkan grafik SmartArt menggunakan salah satu tata letak bawaan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)
finally:
    presentation.dispose()
```

## **Mengakses SmartArt**

Ambil objek SmartArt pertama pada slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    first_smart_art = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, SmartArt):
            first_smart_art = shape
            break
finally:
    presentation.dispose()
```

## **Menghapus SmartArt**

Hapus bentuk SmartArt dari slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    slide.getShapes().remove(smart_art)
finally:
    presentation.dispose()
```

## **Mengubah Tata Letak SmartArt**

Perbarui tipe tata letak dari grafik SmartArt yang ada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.VerticalPictureList)
finally:
    presentation.dispose()
```