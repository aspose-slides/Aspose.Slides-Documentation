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
description: "Pelajari cara mengelola pengaturan AutoFit di Aspose.Slides untuk Python via Java guna mengoptimalkan tampilan teks dalam presentasi PowerPoint dan OpenDocument Anda serta meningkatkan keterbacaan konten."
---
## **Pendahuluan**

Secara default, ketika Anda menambahkan kotak teks, Microsoft PowerPoint menggunakan pengaturan **Resize shape to fix text** untuk kotak teks tersebut—secara otomatis mengubah ukuran kotak teks untuk memastikan teksnya selalu muat di dalamnya. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Ketika teks dalam kotak teks menjadi lebih panjang atau lebih besar, PowerPoint secara otomatis memperbesar kotak teks—menambah tinggi—untuk memungkinkan menampung lebih banyak teks. 
* Ketika teks dalam kotak teks menjadi lebih pendek atau lebih kecil, PowerPoint secara otomatis mengecilkan kotak teks—mengurangi tinggi—untuk menghilangkan ruang berlebih. 

Di PowerPoint, terdapat 4 parameter atau opsi penting yang mengendalikan perilaku autofit untuk kotak teks: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java menyediakan opsi serupa—beberapa properti di dalam kelas [TextFrameFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/)—yang memungkinkan Anda mengontrol perilaku autofit untuk kotak teks dalam presentasi. 

## **Ubah Ukuran Bentuk Agar Sesuai Teks**

Jika Anda ingin teks dalam sebuah kotak selalu muat ke dalam kotak tersebut setelah perubahan pada teks, Anda harus menggunakan opsi **Resize shape to fix text**. Untuk menentukan pengaturan ini, gunakan metode [setAutofitType](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#setAutofitType) (dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/)) dengan [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/textautofittype/#Shape).

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Kode Python berikut menunjukkan cara menentukan bahwa teks harus selalu muat ke dalam kotaknya dalam presentasi PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpace.startJVM()

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

Jika teks menjadi lebih panjang atau lebih besar, kotak teks akan secara otomatis diubah ukurannya (menambah tinggi) untuk memastikan semua teks muat di dalamnya. Jika teks menjadi lebih pendek, hal sebaliknya terjadi. 

## **Tidak Autofit**

Jika Anda ingin kotak teks atau bentuk mempertahankan dimensinya apa pun perubahan pada teks yang dikandungnya, Anda harus menggunakan opsi **Do not Autofit**. Untuk menentukan pengaturan ini, gunakan metode [setAutofitType](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#setAutofitType) (dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/)) dengan [None](https://reference.aspose.com/slides/id/python-java/aspose.slides/textautofittype/#None). 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Kode Python berikut menunjukkan cara menentukan bahwa kotak teks harus selalu mempertahankan dimensinya dalam presentasi PowerPoint:

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
    text_frame_format.setAutofitType(TextAutofitType.None)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ketika teks menjadi terlalu panjang untuk kotaknya, teks akan meluap keluar. 

## **Kecilkan Teks pada Overflow**

Jika teks menjadi terlalu panjang untuk kotaknya, melalui opsi **Shrink text on overflow**, Anda dapat menentukan bahwa ukuran dan spasi teks harus dikurangi agar muat ke dalam kotak. Untuk menentukan pengaturan ini, gunakan metode [setAutofitType](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#setAutofitType) (dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/)) dengan [Normal](https://reference.aspose.com/slides/id/python-java/aspose.slides/textautofittype/#Normal).

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Kode Python berikut menunjukkan cara menentukan bahwa teks harus diperkecil saat meluap dalam presentasi PowerPoint:

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

{{% alert title="Catatan" color="info" %}}
Ketika opsi **Shrink text on overflow** digunakan, pengaturan ini hanya diterapkan ketika teks menjadi terlalu panjang untuk kotaknya. 
{{% /alert %}}

## **Bungkus Teks**

Jika Anda ingin teks dalam sebuah bentuk dibungkus di dalam bentuk tersebut ketika teks melampaui batas bentuk (hanya lebar), Anda harus menggunakan parameter **Wrap text in shape**. Untuk menentukan pengaturan ini, gunakan metode [setWrapText](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#setWrapText) (dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/)) dengan [NullableBool.True](https://reference.aspose.com/slides/id/python-java/aspose.slides/nullablebool/#True). 

Kode Python berikut menunjukkan cara menggunakan pengaturan Wrap Text dalam presentasi PowerPoint:

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
    text_frame_format.setWrapText(NullableBool.True)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Peringatan" color="warning" %}} 
Jika Anda menggunakan metode [setWrapText](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#setWrapText) dengan [NullableBool.False](https://reference.aspose.com/slides/id/python-java/aspose.slides/nullablebool/#False) untuk sebuah bentuk, ketika teks di dalam bentuk menjadi lebih panjang daripada lebar bentuk, teks akan meluas melewati batas bentuk dalam satu baris tunggal. 
{{% /alert %}}

## **FAQ**

**Apakah margin internal frame teks memengaruhi AutoFit?**

Ya. Padding (margin internal) mengurangi area yang dapat digunakan untuk teks, sehingga AutoFit akan aktif lebih awal—mengecilkan font atau mengubah ukuran bentuk lebih cepat. Periksa dan sesuaikan margin sebelum menyetel AutoFit.

**Bagaimana AutoFit berinteraksi dengan break baris manual dan lunak?**

Break paksa tetap dipertahankan, dan AutoFit menyesuaikan ukuran font serta spasi di sekitarnya. Menghapus break yang tidak diperlukan sering mengurangi seberapa agresif AutoFit harus mengecilkan teks.

**Apakah mengubah font tema atau memicu substitusi font memengaruhi hasil AutoFit?**

Ya. Mengganti ke font dengan metrik glif yang berbeda mengubah lebar/tinggi teks, yang dapat mengubah ukuran font akhir serta pembungkus baris. Setelah perubahan atau substitusi font apa pun, periksa kembali slide.