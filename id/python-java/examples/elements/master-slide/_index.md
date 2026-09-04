---
title: Slide Master
type: docs
weight: 30
url: /id/python-java/examples/elements/master-slide/
keywords:
- contoh kode
- slide master
- tambahkan slide master
- akses slide master
- hapus slide master
- slide master yang tidak digunakan
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Kelola slide master dengan Aspose.Slides untuk Python via Java: buat, akses, hapus, dan bersihkan master dalam presentasi PowerPoint dan OpenDocument."
---
Master slide berada pada tingkat teratas dalam hierarki pewarisan slide di PowerPoint. **Master slide** mendefinisikan elemen desain umum seperti latar belakang, logo, dan pemformatan teks. **Layout slide** mewarisi dari master slide, dan **normal slide** mewarisi dari layout slide.

Artikel ini menunjukkan cara membuat, memodifikasi, dan mengelola master slide menggunakan **Aspose.Slides for Python via Java**.

Instal paket seperti yang dijelaskan di [Installation](/slides/id/python-java/installation/). Setiap contoh mengimpor `asposeslides` sebelum memulai JVM, kemudian mengimpor API setelah JVM berjalan.

## **Add a Master Slide**

Contoh ini menunjukkan cara membuat master slide baru dengan mengkloning master default. Kemudian menambahkan banner nama perusahaan ke semua slide melalui pewarisan layout.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Mengkloning slide master default.
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # Menambahkan banner dengan nama perusahaan ke bagian atas slide master.
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # Menetapkan slide master baru ke slide layout.
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # Menetapkan slide layout ke slide pertama dalam presentasi.
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Master slide menyediakan cara untuk menerapkan branding konsisten atau elemen desain bersama di seluruh slide. Perubahan yang dilakukan pada master secara otomatis tercermin pada layout dan normal slide yang bergantung.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Bentuk dan pemformatan yang ditambahkan ke master slide diwarisi oleh layout slide dan, pada gilirannya, oleh semua normal slide yang menggunakan layout tersebut. Gambar di bawah menggambarkan bagaimana kotak teks yang ditambahkan ke master slide secara otomatis ditampilkan pada slide akhir.
{{% /alert %}}

![Contoh Pewarisan Master](master-slide-banner.png)

## **Access a Master Slide**

Anda dapat mengakses master slide melalui koleksi master pada presentasi. Contoh ini mengambil master slide pertama dan mengubah tipe latar belakangnya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **Remove a Master Slide**

Master slide dapat dihapus berdasarkan indeks atau referensi setelah tidak lagi digunakan. Contoh ini menetapkan master slide yang telah diklon ke presentasi dan kemudian menghapus master asli berdasarkan indeks.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # Hapus master slide asli yang tidak terpakai berdasarkan indeks.
    presentation.getMasters().removeAt(0)

    # Alternatifnya, hapus master slide yang tidak terpakai berdasarkan referensi:
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **Remove Unused Master Slides**

Beberapa presentasi berisi master slide yang tidak terpakai. Menghapus slide tersebut dapat membantu mengurangi ukuran file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # Hapus semua master slide yang tidak terpakai, termasuk yang ditandai sebagai Preserve.
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```