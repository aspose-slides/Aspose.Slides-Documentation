---
title: Tingkatkan Presentasi Anda dengan AutoFit di Python
linktitle: Pengaturan Autofit
type: docs
weight: 30
url: /id/python-java/manage-autofit-settings/
keywords:
- kotak teks
- autofit
- jangan autofit
- sesuaikan teks
- perkecil teks
- bungkus teks
- ubah ukuran bentuk
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari cara mengelola pengaturan AutoFit di Aspose.Slides untuk Python via Java untuk mengoptimalkan tampilan teks dalam presentasi PowerPoint dan OpenDocument Anda serta meningkatkan keterbacaan konten."
---
## **Pendahuluan**

Secara default, saat Anda menambahkan kotak teks, Microsoft PowerPoint menggunakan pengaturan **Resize shape to fit text** untuk kotak teks—secara otomatis mengubah ukuran kotak teks untuk memastikan teksnya selalu sesuai.

![Kotak teks di PowerPoint](textbox-in-powerpoint.png)

* Ketika teks dalam kotak teks menjadi lebih panjang atau lebih besar, PowerPoint secara otomatis memperbesar kotak teks—meningkatkan tinggiannya—untuk menampung lebih banyak teks.
* Ketika teks dalam kotak teks menjadi lebih pendek atau lebih kecil, PowerPoint secara otomatis memperkecil kotak teks—menurunkan tinggiannya—untuk menghilangkan ruang berlebih.

Di PowerPoint, berikut ini adalah 4 parameter atau opsi penting yang mengontrol perilaku autofit untuk kotak teks:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![opsi autofit PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java menyediakan opsi serupa—beberapa properti di bawah kelas [TextFrameFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/)—yang memungkinkan Anda mengontrol perilaku autofit untuk kotak teks dalam presentasi.

## **Ubah Ukuran Bentuk agar Sesuai dengan Teks**

Jika Anda ingin teks dalam sebuah kotak selalu sesuai dengan kotak tersebut setelah perubahan teks, Anda harus menggunakan opsi **Resize shape to fit text**. Untuk menentukan pengaturan ini, gunakan metode [setAutofitType](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#setAutofitType) (dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/)) dengan [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/textautofittype/#Shape).

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Kode Python ini menunjukkan cara menentukan bahwa teks harus selalu sesuai dengan kotaknya dalam presentasi PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Shape)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Jika teks menjadi lebih panjang atau lebih besar, kotak teks akan secara otomatis diubah ukurannya (tinggi bertambah) untuk memastikan semua teks muat. Jika teks menjadi lebih pendek, hal sebaliknya terjadi.

## **Jangan Autofit**

Jika Anda ingin kotak teks atau bentuk mempertahankan dimensinya terlepas dari perubahan teks di dalamnya, Anda harus menggunakan opsi **Do not Autofit**. Untuk menentukan pengaturan ini, gunakan metode [setAutofitType](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#setAutofitType) (dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/)) dengan [None](https://reference.aspose.com/slides/id/python-java/aspose.slides/textautofittype/#None).

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Kode Python ini menunjukkan cara menentukan bahwa kotak teks harus selalu mempertahankan dimensinya dalam presentasi PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.None_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ketika teks menjadi terlalu panjang untuk kotaknya, teks akan meluber keluar.

## **Kecilkan Teks saat Melebihi**

Jika teks menjadi terlalu panjang untuk kotaknya, Anda dapat menggunakan opsi **Shrink text on overflow** untuk menentukan bahwa ukuran dan jarak teks harus diperkecil agar muat dalam kotak. Untuk menentukan pengaturan ini, gunakan metode [setAutofitType](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#setAutofitType) (dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/)) dengan [Normal](https://reference.aspose.com/slides/id/python-java/aspose.slides/textautofittype/#Normal).

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Kode Python ini menunjukkan cara menentukan bahwa teks harus diperkecil saat melebihi dalam presentasi PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}}
Saat opsi **Shrink text on overflow** digunakan, pengaturan hanya diterapkan ketika teks menjadi terlalu panjang untuk kotaknya. 
{{% /alert %}}

## **Bungkus Teks**

Jika Anda ingin teks dalam sebuah bentuk membungkus di dalam bentuk tersebut ketika teks melewati batas lebar bentuk, Anda harus menggunakan parameter **Wrap text in shape**. Untuk menentukan pengaturan ini, gunakan metode [setWrapText](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#setWrapText) (dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/)) dengan [NullableBool.True_](https://reference.aspose.com/slides/id/python-java/aspose.slides/nullablebool/#True).

Kode Python ini menunjukkan cara menggunakan pengaturan Wrap Text dalam presentasi PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, NullableBool, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setWrapText(NullableBool.True_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 
Jika Anda menggunakan metode [setWrapText](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#setWrapText) dengan [NullableBool.False](https://reference.aspose.com/slides/id/python-java/aspose.slides/nullablebool/#False) untuk sebuah bentuk, ketika teks di dalam bentuk menjadi lebih panjang daripada lebar bentuk, teks akan meluas melampaui batas bentuk dalam satu baris tunggal. 
{{% /alert %}}

## **FAQ**

**Apakah margin internal bingkai teks memengaruhi AutoFit?**

Ya. Padding (margin internal) mengurangi area yang dapat digunakan untuk teks, sehingga AutoFit akan aktif lebih awal—mengecilkan font atau mengubah ukuran bentuk lebih cepat. Periksa dan sesuaikan margin sebelum menyetel AutoFit.

**Bagaimana AutoFit berinteraksi dengan jeda baris manual dan lunak?**

Jeda paksa tetap ada, dan AutoFit menyesuaikan ukuran font serta jarak di sekitarnya. Menghapus jeda yang tidak diperlukan sering kali mengurangi tingkat agresif AutoFit dalam mengecilkan teks.

**Apakah mengubah font tema atau memicu substitusi font memengaruhi hasil AutoFit?**

Ya. Mengganti font dengan metrik glyph yang berbeda mengubah lebar/tinggi teks, yang dapat mengubah ukuran font akhir dan pembungkus baris. Setelah perubahan atau substitusi font apa pun, tinjau kembali slide.