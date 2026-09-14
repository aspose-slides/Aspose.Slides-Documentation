---
title: Menambahkan Tanda Air ke Presentasi dengan Python
linktitle: Tanda Air
type: docs
weight: 40
url: /id/python-java/watermark/
keywords:
- tanda air
- tanda air teks
- tanda air gambar
- menambahkan tanda air
- mengubah tanda air
- menghapus tanda air
- menghapus tanda air
- menambahkan tanda air ke PPT
- menambahkan tanda air ke PPTX
- menambahkan tanda air ke ODP
- menghapus tanda air dari PPT
- menghapus tanda air dari PPTX
- menghapus tanda air dari ODP
- menghapus tanda air dari PPT
- menghapus tanda air dari PPTX
- menghapus tanda air dari ODP
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Kelola tanda air teks dan gambar dalam presentasi PowerPoint dan OpenDocument menggunakan Python untuk menunjukkan draft, informasi rahasia, hak cipta, dan lainnya."
---
## **Pendahuluan**

**Watermark** dalam presentasi adalah stempel teks atau gambar yang digunakan pada satu slide atau di seluruh slide presentasi. Biasanya, watermark digunakan untuk menunjukkan bahwa presentasi tersebut masih draft (misalnya watermark “Draft”), berisi informasi rahasia (misalnya watermark “Confidential”), untuk menyatakan perusahaan mana yang memilikinya (misalnya watermark “Nama Perusahaan”), untuk mengidentifikasi penulis presentasi, dll. Watermark membantu mencegah pelanggaran hak cipta dengan menandakan bahwa presentasi tidak boleh disalin. Watermark digunakan pada format presentasi PowerPoint maupun OpenOffice. Pada Aspose.Slides, Anda dapat menambahkan watermark ke format file PowerPoint PPT, PPTX, dan OpenOffice ODP.

Di [**Aspose.Slides**](https://products.aspose.com/slides/id/python-java/), ada berbagai cara untuk membuat watermark pada dokumen PowerPoint atau OpenOffice serta mengubah desain dan perilakunya. Aspek umum adalah untuk menambahkan watermark teks, Anda harus menggunakan kelas [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/), dan untuk menambahkan watermark gambar, gunakan kelas [PictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/) atau isi bentuk watermark dengan gambar. [PictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/) mewarisi dari kelas [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/), sehingga Anda dapat menggunakan semua pengaturan fleksibel dari objek shape. Karena [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/) bukan shape dan pengaturannya terbatas, ia dibungkus dalam objek [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/).

Ada dua cara watermark dapat diterapkan: pada satu slide saja atau pada semua slide presentasi. Slide Master digunakan untuk menerapkan watermark ke semua slide presentasi — watermark ditambahkan ke Slide Master, dirancang sepenuhnya di sana, dan diterapkan ke semua slide tanpa mempengaruhi izin mengubah watermark pada slide individu.

Watermark biasanya dianggap tidak dapat diedit oleh pengguna lain. Untuk mencegah watermark (atau shape induk watermark) diedit, Aspose.Slides menyediakan fungsi penguncian shape. Sebuah shape tertentu dapat dikunci pada slide normal atau pada Slide Master. Ketika shape watermark dikunci pada Slide Master, ia akan terkunci pada semua slide presentasi.

Anda dapat memberi nama pada watermark sehingga di masa mendatang, bila ingin menghapusnya, Anda dapat menemukannya di shape slide berdasarkan nama.

Anda dapat merancang watermark dengan cara apa pun; biasanya watermark memiliki fitur umum seperti penataan tengah, rotasi, posisi di depan, dll. Kami akan menunjukkan cara menggunakan fitur-fitur tersebut dalam contoh di bawah.

## **Watermark Teks**

### **Menambahkan Watermark Teks ke Slide**

Untuk menambahkan watermark teks dalam PPT, PPTX, atau ODP, pertama‑tama tambahkan shape ke slide, lalu tambahkan text frame ke shape tersebut. Text frame direpresentasikan oleh kelas [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/). Tipe ini tidak mewarisi dari [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/), yang memiliki banyak properti untuk memposisikan watermark secara fleksibel. Karena itu, objek [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/) dibungkus dalam objek [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/). Untuk menambahkan teks watermark ke shape, gunakan metode [addTextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/#addTextFrame) seperti contoh di bawah.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [Cara Menggunakan Kelas TextFrame](/slides/id/python-java/text-formatting/)
{{% /alert %}}

### **Menambahkan Watermark Teks ke Seluruh Presentasi**

Jika Anda ingin menambahkan watermark teks ke seluruh presentasi (yaitu semua slide sekaligus), tambahkan ke [MasterSlide](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslide/). Logika selanjutnya sama seperti menambahkan watermark ke satu slide — buat objek [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) dan kemudian tambahkan watermark ke dalamnya menggunakan metode [addTextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/#addTextFrame).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    watermark_shape = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [Cara Menggunakan Slide Master](/slides/id/python-java/slide-master/)
{{% /alert %}}

### **Mengatur Transparansi Shape Watermark**

Secara default, shape persegi panjang diberikan warna isi dan garis. Baris kode berikut menjadikan shape transparan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.getFillFormat().setFillType(FillType.NoFill)
    watermark_shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
finally:
    presentation.dispose()
```

### **Mengatur Font untuk Watermark Teks**

Anda dapat mengubah font watermark teks seperti contoh di bawah.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FontData

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    text_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat()
    font = FontData("Arial")
    text_format.setLatinFont(font)
    text_format.setFontHeight(50)
finally:
    presentation.dispose()
```

### **Mengatur Warna Teks Watermark**

Untuk mengatur warna teks watermark, gunakan kode berikut:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    alpha, red, green, blue = 150, 200, 200, 200
    fill_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat()
    fill_format.setFillType(FillType.Solid)
    color = Color(red, green, blue, alpha)
    fill_format.getSolidFillColor().setColor(color)
finally:
    presentation.dispose()
```

### **Menengahkan Watermark Teks**

Anda dapat menengahkan watermark pada slide dengan melakukan hal berikut:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_size = presentation.getSlideSize().getSize()
    watermark_width = 400
    watermark_height = 40
    watermark_x = (slide_size.getWidth() - watermark_width) / 2
    watermark_y = (slide_size.getHeight() - watermark_height) / 2
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, watermark_x, watermark_y, watermark_width, watermark_height)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

Gambar di bawah menunjukkan hasil akhir.

![Watermark teks](text_watermark.png)

## **Watermark Gambar**

### **Menambahkan Watermark Gambar ke Presentasi**

Untuk menambahkan watermark gambar ke slide presentasi, Anda dapat melakukan hal berikut:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, PictureFillMode

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    image_data = Path("watermark.png").read_bytes()
    image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_data))
    watermark_shape.getFillFormat().setFillType(FillType.Picture)
    watermark_shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    watermark_shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
finally:
    presentation.dispose()
```

### **Mengunci Watermark dari Pengeditan**

Jika perlu mencegah watermark diedit, gunakan metode [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/#getAutoShapeLock) pada shape. Dengan properti ini, Anda dapat melindungi shape agar tidak dipilih, diubah ukurannya, dipindahkan, digabungkan dengan elemen lain, mengunci teksnya dari pengeditan, dan banyak lagi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    # Kunci shape watermark agar tidak dapat dimodifikasi.
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **Membawa Watermark ke Depan**

Di Aspose.Slides, urutan Z shape dapat diatur melalui metode [ShapeCollection.reorder](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#reorder). Untuk melakukannya, panggil metode ini dari koleksi shape slide dan berikan referensi shape serta nomor urutannya. Dengan cara ini, Anda dapat membawa shape ke depan atau mengirimnya ke belakang slide. Fitur ini sangat berguna bila Anda perlu menempatkan watermark di depan presentasi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    shape_count = slide.getShapes().size()
    slide.getShapes().reorder(shape_count - 1, watermark_shape)
finally:
    presentation.dispose()
```

### **Mengatur Rotasi Watermark**

Berikut contoh kode untuk menyesuaikan rotasi watermark sehingga berada secara diagonal pada slide:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    slide_size = presentation.getSlideSize().getSize()
    diagonal_angle = math.atan((slide_size.getHeight() / slide_size.getWidth())) * 180 / math.pi
    watermark_shape.setRotation(diagonal_angle)
finally:
    presentation.dispose()
```

### **Memberi Nama pada Watermark**

Aspose.Slides memungkinkan Anda memberi nama pada shape. Dengan menggunakan nama shape, Anda dapat mengaksesnya di masa mendatang untuk memodifikasi atau menghapusnya. Untuk memberi nama pada shape watermark, berikan nama tersebut ke metode [Shape.setName](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#setName):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.setName("watermark")
finally:
    presentation.dispose()
```

### **Menghapus Watermark**

Untuk menghapus shape watermark, gunakan metode [Shape.getName](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getName) untuk menemukannya di shape slide. Kemudian, berikan shape watermark ke metode [ShapeCollection.remove](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#remove):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    slide_shapes = slide.getShapes().toArray()
    for shape in slide_shapes:
        if shape.getName() == "watermark":
            slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

## **FAQ**

**Apa itu watermark dan mengapa harus menggunakannya?**

Watermark adalah lapisan teks atau gambar yang diterapkan pada slide untuk membantu melindungi hak kekayaan intelektual, meningkatkan pengenalan merek, atau mencegah penggunaan tidak sah pada presentasi.

**Apakah saya dapat menambahkan watermark ke semua slide dalam sebuah presentasi?**

Ya, Aspose.Slides memungkinkan Anda menambahkan watermark secara programatik ke setiap slide dalam sebuah presentasi. Anda dapat mengiterasi semua slide dan menerapkan pengaturan watermark secara individu.

**Bagaimana cara mengatur transparansi watermark?**

Anda dapat mengatur transparansi watermark dengan memodifikasi pengaturan isi ([getFillFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getFillFormat)) pada shape. Hal ini memastikan watermark tetap halus dan tidak mengganggu konten slide.

**Format gambar apa yang didukung untuk watermark?**

Aspose.Slides mendukung berbagai format gambar seperti PNG, JPEG, GIF, BMP, SVG, dan lainnya.

**Apakah saya dapat menyesuaikan font dan gaya watermark teks?**

Ya, Anda dapat memilih font, ukuran, dan gaya apa pun yang sesuai dengan desain presentasi Anda dan menjaga konsistensi merek.

**Bagaimana cara mengubah posisi atau orientasi watermark?**

Anda dapat menyesuaikan posisi dan orientasi watermark secara programatik dengan memodifikasi koordinat, ukuran, dan properti rotasi pada shape.