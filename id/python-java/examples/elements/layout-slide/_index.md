---
title: Slide Tata Letak
type: docs
weight: 20
url: /id/python-java/examples/elements/layout-slide/
keywords:
- contoh kode
- slide tata letak
- tambahkan slide tata letak
- akses slide tata letak
- hapus slide tata letak
- slide tata letak yang tidak terpakai
- klon slide tata letak
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Kelola slide tata letak dengan Aspose.Slides untuk Python via Java: tambahkan, akses, hapus, bersihkan, dan klon tata letak dalam presentasi PowerPoint dan OpenDocument."
---
Artikel ini menunjukkan cara bekerja dengan **layout slides** menggunakan Aspose.Slides untuk Python via Java. Sebuah layout slide mendefinisikan desain dan pemformatan yang diwarisi oleh slide normal. Anda dapat menambahkan, mengakses, mengkloning, dan menghapus layout slides, serta membersihkan yang tidak terpakai untuk mengurangi ukuran presentasi.

Pasang paket sebagaimana dijelaskan dalam [Installation](/slides/id/python-java/installation/). Setiap contoh mengimpor `asposeslides` sebelum memulai JVM, kemudian mengimpor API setelah JVM berjalan.

## **Tambah Layout Slide**

Buat layout slide kustom untuk mendefinisikan pemformatan yang dapat digunakan kembali. Contoh berikut menambahkan kotak teks ke layout baru dan kemudian membuat dua slide yang menggunakannya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Buat slide tata letak dengan tipe tata letak kosong dan nama khusus.
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # Tambahkan kotak teks ke slide tata letak.
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # Tambahkan dua slide yang mewarisi teks dari tata letak.
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **Catatan 1:** Layout slides berfungsi sebagai templat untuk slide individual. Anda dapat mendefinisikan elemen umum sekali dan menggunakannya kembali di banyak slide.

> 💡 **Catatan 2:** Saat Anda menambahkan bentuk atau teks ke layout slide, semua slide yang berbasis pada layout tersebut secara otomatis menampilkan konten yang dibagikan. Tangkapan layar di bawah ini menunjukkan dua slide yang mewarisi kotak teks dari layout slide yang sama.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Akses Layout Slide**

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Akses layout slide berdasarkan indeks.
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # Akses layout slide berdasarkan tipe.
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **Hapus Layout Slide**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **Hapus Layout Slides yang Tidak Digunakan**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **Klon Layout Slide**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **Ringkasan:** Layout slides membantu mempertahankan pemformatan yang konsisten di seluruh presentasi. Aspose.Slides memungkinkan Anda membuat, mengelola, menggunakan kembali, dan membersihkan layout sesuai kebutuhan.