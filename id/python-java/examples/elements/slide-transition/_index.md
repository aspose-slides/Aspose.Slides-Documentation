---
title: Transisi Slide
type: docs
weight: 110
url: /id/python-java/examples/elements/slide-transition/
keywords:
- contoh kode
- transisi slide
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Menerapkan dan menghapus transisi slide serta mengatur waktu maju otomatis slide dengan contoh kode Aspose.Slides untuk Python via Java untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan penerapan efek transisi slide dan pengatur waktunya dengan **Aspose.Slides for Python via Java**.

Instal paket sebagaimana dijelaskan pada [Installation](/slides/id/python-java/installation/). Setiap contoh mengimpor `asposeslides` sebelum memulai JVM, kemudian mengimpor API setelah JVM berjalan.

## **Tambahkan Transisi Slide**

Terapkan efek transisi memudar pada slide pertama.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Terapkan transisi memudar.
    slide.getSlideShowTransition().setType(TransitionType.Fade)
finally:
    presentation.dispose()
```

## **Akses Transisi Slide**

Baca jenis transisi yang saat ini ditetapkan pada slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Push)

    # Akses jenis transisi.
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **Hapus Transisi Slide**

Hapus semua efek transisi. JPype mengekspor konstanta Java yang bernama `None` sebagai `None_` karena `None` adalah kata yang dipesan di Python.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Fade)

    # Hapus efek transisi.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **Atur Durasi Transisi**

Tentukan berapa lama slide ditampilkan sebelum maju secara otomatis. Contoh ini maju setelah dua detik dan juga memungkinkan maju dengan klik mouse. Pengaturan waktu ini mengontrol perpindahan slide, bukan kecepatan efek transisi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setAdvanceOnClick(True)
    slide.getSlideShowTransition().setAdvanceAfter(True)
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # Dalam milidetik.
finally:
    presentation.dispose()
```