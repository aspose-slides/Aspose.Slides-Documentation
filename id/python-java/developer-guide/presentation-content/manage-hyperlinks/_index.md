---
title: Kelola Hyperlink Presentasi di Python melalui Java
linktitle: Kelola Hyperlink
type: docs
weight: 20
url: /id/python-java/manage-hyperlinks/
keywords:
- tambah URL
- tambah hyperlink
- buat hyperlink
- format hyperlink
- hapus hyperlink
- perbarui hyperlink
- hyperlink teks
- hyperlink slide
- hyperlink bentuk
- hyperlink gambar
- hyperlink video
- hyperlink yang dapat diubah
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Kelola hyperlink dengan mudah dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python melalui Java—tingkatkan interaktivitas dan alur kerja dalam hitungan menit."
---
## **Pendahuluan**

Tautan hiperteks adalah referensi ke objek atau data atau tempat dalam sesuatu. Ini adalah contoh tautan hiperteks umum dalam Presentasi PowerPoint:

* Tautan ke situs web di dalam teks, bentuk, atau media
* Tautan ke slide

Aspose.Slides untuk Python via Java memungkinkan Anda melakukan banyak tugas yang melibatkan tautan hiperteks dalam presentasi. 

{{% alert color="info" title="Catatan" %}} 

Anda mungkin ingin mencoba Aspose sederhana, [editor PowerPoint daring gratis.](https://products.aspose.app/slides/id/editor)

{{% /alert %}} 

## **Tambahkan Tautan URL**

### **Tambahkan Tautan URL ke Teks**

Kode Python ini menunjukkan cara menambahkan tautan situs web ke teks:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tambahkan Tautan URL ke Bentuk atau Bingkai**

Contoh kode ini dalam Python via Java menunjukkan cara menambahkan tautan situs web ke bentuk:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tambahkan Tautan URL ke Media**

Aspose.Slides memungkinkan Anda menambahkan tautan ke file gambar, audio, dan video. 

Kode contoh ini menunjukkan cara menambahkan tautan ke **gambar**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Tambahkan gambar ke presentasi
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # Membuat bingkai gambar pada slide 1 berdasarkan gambar yang telah ditambahkan sebelumnya
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kode contoh ini menunjukkan cara menambahkan tautan ke **file audio**:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = presentation.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio)

    audio_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    audio_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kode contoh ini menunjukkan cara menambahkan tautan ke **video**:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.avi").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video)

    video_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    video_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tips" %}} 

Anda mungkin ingin melihat *[Manage OLE](/slides/id/python-java/manage-ole/)*.

{{% /alert %}}

## **Gunakan Tautan untuk Membuat Daftar Isi**

Karena tautan memungkinkan Anda menambahkan referensi ke objek atau tempat, Anda dapat menggunakannya untuk membuat daftar isi. 

Kode contoh ini menunjukkan cara membuat daftar isi dengan tautan:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    content_table = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    content_table.getFillFormat().setFillType(FillType.NoFill)
    content_table.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    content_table.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    content_table.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Format Tautan**

### **Warna**

Dengan properti [Hyperlink.setColorSource](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/#setColorSource) dalam kelas [Hyperlink](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/), Anda dapat mengatur warna untuk tautan dan juga mendapatkan informasi warna dari tautan. Fitur ini pertama kali diperkenalkan di PowerPoint 2019, sehingga perubahan properti tidak berlaku pada versi PowerPoint yang lebih lama.

Kode contoh ini menunjukkan operasi dimana tautan dengan warna berbeda ditambahkan ke slide yang sama:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This is a sample of colored hyperlink.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This is a sample of usual hyperlink.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hapus Tautan dari Presentasi**

### **Hapus Tautan dari Teks**

Kode Python ini menunjukkan cara menghapus tautan dari teks di slide presentasi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, AutoShape

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick()

    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Hapus Tautan dari Bentuk atau Bingkai**

Kode Python ini menunjukkan cara menghapus tautan dari bentuk di slide presentasi: 

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        shape.getHyperlinkManager().removeHyperlinkClick()
    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tautan yang Dapat Diubah**

Kelas [Hyperlink](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/) bersifat mutable. Dengan kelas ini, Anda dapat mengubah nilai properti berikut:

- [setTargetFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

Potongan kode ini menunjukkan cara menambahkan tautan ke slide dan mengedit tooltip‑nya kemudian:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    # Mengubah tooltip hyperlink yang sudah ditambahkan
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Properti yang Didukung dalam HyperlinkQueries**

Anda dapat mengakses [HyperlinkQueries](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkqueries/) dari sebuah presentasi, slide, atau teks yang memiliki tautan yang didefinisikan. 

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/#getHyperlinkQueries)

Kelas [HyperlinkQueries](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkqueries/) mendukung metode dan properti berikut: 

- [getHyperlinkClicks](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **FAQ**

**Bagaimana cara membuat navigasi internal tidak hanya ke satu slide, tetapi ke “bagian” atau slide pertama dari sebuah bagian?**

Bagian di PowerPoint adalah pengelompokan slide; navigasi secara teknis menargetkan slide tertentu. Untuk “menavigasi ke bagian”, biasanya Anda menautkan ke slide pertamanya.

**Apakah saya dapat menempelkan tautan ke elemen master slide sehingga berfungsi di semua slide?**

Ya. Elemen master slide dan tata letak mendukung tautan. Tautan tersebut muncul pada slide turunan dan dapat diklik selama pertunjukan.

**Apakah tautan akan tetap ada saat mengekspor ke PDF, HTML, gambar, atau video?**

Di [PDF](/slides/id/python-java/convert-powerpoint-to-pdf/) dan [HTML](/slides/id/python-java/convert-powerpoint-to-html/), ya—tautan biasanya dipertahankan. Saat mengekspor ke [images](/slides/id/python-java/convert-powerpoint-to-png/) dan [video](/slides/id/python-java/convert-powerpoint-to-video/), kemampuan mengklik tidak terbawa karena sifat format tersebut (frame raster/video tidak mendukung tautan).