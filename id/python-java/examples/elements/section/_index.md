---
title: Bagian
type: docs
weight: 90
url: /id/python-java/examples/elements/section/
keywords:
- contoh kode
- bagian
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Kelola bagian presentasi di Aspose.Slides untuk Python via Java: tambahkan, akses, hapus, dan ganti nama bagian dengan contoh kode Python."
---
Contoh untuk mengelola bagian presentasi—menambah, mengakses, menghapus, dan mengganti nama secara programatis menggunakan **Aspose.Slides for Python via Java**.

Instal paket seperti yang dijelaskan pada [Installation](/slides/id/python-java/installation/). Setiap contoh mengimpor `asposeslides` sebelum memulai JVM, kemudian mengimpor API setelah JVM berjalan.

## **Menambahkan Bagian**

Buat sebuah bagian yang dimulai pada slide tertentu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Tentukan slide yang menandai awal bagian.
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **Mengakses Bagian**

Baca informasi bagian dari sebuah presentasi.

```python
import jpade
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # Akses sebuah bagian berdasarkan indeks.
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **Menghapus Bagian**

Hapus bagian yang sebelumnya ditambahkan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # Hapus bagian pertama.
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **Mengganti Nama Bagian**

Ubah nama bagian yang ada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("Old Name", slide)

    section = presentation.getSections().get_Item(0)
    section.setName("New Name")
finally:
    presentation.dispose()
```