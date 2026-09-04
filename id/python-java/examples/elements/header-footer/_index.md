---
title: Header dan Footer
type: docs
weight: 220
url: /id/python-java/examples/elements/header-footer/
keywords:
- contoh kode
- header
- footer
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Kontrol header dan footer slide dengan Aspose.Slides untuk Python via Java: tambahkan tanggal, nomor slide, dan teks kustom dalam presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara menambahkan footer dan memperbarui placeholder tanggal dan waktu menggunakan **Aspose.Slides for Python via Java**.

Instal paket seperti yang dijelaskan di [Installation](/slides/id/python-java/installation/). Setiap contoh mengimpor `asposeslides` sebelum memulai JVM, kemudian mengimpor API setelah JVM berjalan.

## **Menambahkan Footer**

Tambahkan teks ke area footer pada slide dan buat agar terlihat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **Perbarui Tanggal dan Waktu**

Ubah placeholder tanggal dan waktu pada slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```