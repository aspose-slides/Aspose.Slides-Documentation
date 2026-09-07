---
title: แปลงงานนำเสนอ PowerPoint เป็น TIFF ด้วย Python
linktitle: PowerPoint เป็น TIFF
type: docs
weight: 90
url: /th/python-java/convert-powerpoint-to-tiff/
keywords:
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น TIFF
- งานนำเสนอเป็น TIFF
- สไลด์เป็น TIFF
- PPT เป็น TIFF
- PPTX เป็น TIFF
- บันทึก PPT เป็น TIFF
- บันทึก PPTX เป็น TIFF
- ส่งออก PPT เป็น TIFF
- ส่งออก PPTX เป็น TIFF
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint (PPT, PPTX) เป็นภาพ TIFF คุณภาพสูงโดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java พร้อมตัวอย่างโค้ด"
---
## **บทนำ**

TIFF (**Tagged Image File Format**) เป็นรูปแบบภาพเรสเตอร์ที่รองรับหลายหน้าและการบีบอัดแบบไม่มีการสูญเสียข้อมูล เหมาะสำหรับการเก็บสไลด์ที่เรนเดอร์เป็นไฟล์ภาพเดียว

โดยใช้ Aspose.Slides for Python via Java คุณสามารถแปลงงานนำเสนอ PowerPoint (PPT, PPTX) และ OpenDocument (ODP) เป็น TIFF ตัวอย่างแต่ละอันเริ่มเครื่องเสมือน Java (JVM) หากจำเป็นและจะปล่อยงานนำเสนอหลังการใช้งาน

## **แปลงงานนำเสนอเป็น TIFF**

โดยใช้เมธอด [save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ที่มาจากคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) คุณสามารถแปลงงานนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว TIFF ที่มีหลายหน้าเหล่านี้จะมีภาพที่เรนเดอร์ของแต่ละสไลด์ในขนาดเริ่มต้น

โค้ดตัวอย่างต่อไปนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น TIFF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # บันทึกทุกสไลด์ในไฟล์ TIFF แบบหลายหน้า.
    presentation.save("output.tiff", SaveFormat.Tiff)
finally:
    presentation.dispose()
```

## **แปลงงานนำเสนอเป็น TIFF ขาว-ดำ**

เมธอด [setBwConversionMode](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/#setBwConversionMode) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/) ช่วยให้คุณระบุอัลกอริธึมที่ใช้เมื่อแปลงสไลด์หรือภาพสีเป็น TIFF ขาว-ดำ โปรดทราบว่าการตั้งค่านี้จะใช้เฉพาะเมื่อเมธอด [setCompressionType](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/#setCompressionType) ตั้งค่าเป็น [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) หรือ [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffcompressiontypes/#CCITT3)

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/#setBwConversionMode) เป็นการตั้งค่าระดับการส่งออกที่เลือกอัลกอริธึมการแปลงพิกเซลสำหรับภาพ TIFF ทั้งหมด หากต้องการกำหนดวิธีการแสดงผลของรูปร่างหนึ่ง ๆ เมื่อเปิดโหมดแสดงผลขาว-ดำ ให้ใช้ [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#setBlackWhiteMode) ดูตัวอย่างได้ที่ [Control Black-and-White Rendering for Shapes](/slides/th/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes)
{{% /alert %}}

สมมติว่ามีไฟล์ “sample.pptx” ที่มีสไลด์ดังต่อไปนี้:

![A presentation slide](slide_black_and_white.png)

โค้ดต่อไปนี้แสดงวิธีแปลงสไลด์สีเป็น TIFF ขาว-ดำ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteConversionMode, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions

tiff_options = TiffOptions()
tiff_options.setCompressionType(TiffCompressionTypes.CCITT4)
tiff_options.setBwConversionMode(BlackWhiteConversionMode.Dithering)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **แปลงงานนำเสนอเป็น TIFF ด้วยขนาดกำหนดเอง**

หากคุณต้องการภาพ TIFF ที่มีขนาดกำหนดเอง สามารถตั้งค่าขนาดที่ต้องการได้โดยใช้เมธอดต่าง ๆ ของ [TiffOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/) ตัวอย่างเช่น เมธอด [setImageSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/#setImageSize) ช่วยกำหนดขนาดของภาพที่ได้

โค้ดต่อไปนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็นภาพ TIFF ที่มีขนาดกำหนดเอง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setCompressionType(TiffCompressionTypes.Default)

    # ตั้งค่าความละเอียดแนวนอนและแนวตั้ง.
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # ตั้งค่าขนาดผลลัพธ์เป็นพิกเซล.
    image_size = Dimension(1728, 1078)
    tiff_options.setImageSize(image_size)

    # รวมบันทึกผู้พูดทั้งหมดไว้ด้านล่างแต่ละสไลด์.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    tiff_options.setSlidesLayoutOptions(notes_options)

    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

## **แปลงงานนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลกำหนดเอง**

โดยใช้เมธอด [setPixelFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/#setPixelFormat) ของคลาส [TiffOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/) คุณสามารถระบุรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ที่ได้

โค้ดต่อไปนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยรูปแบบพิกเซลที่กำหนด:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImagePixelFormat, Presentation, SaveFormat, TiffOptions

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setPixelFormat(ImagePixelFormat.Format8bppIndexed)

    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

{{% alert title="Tip" color="success" %}}
ลองใช้งาน **FREE PowerPoint to Poster converter** ของ Aspose ที่ https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online
{{% /alert %}}

## **FAQ**

**สามารถแปลงสไลด์เดียวแทนที่จะเป็นงานนำเสนอทั้งหมดเป็น TIFF ได้หรือไม่?**

ได้ Aspose.Slides รองรับการแปลงสไลด์แต่ละสไลด์จากงานนำเสนอ PowerPoint และ OpenDocument เป็นภาพ TIFF แยกกัน

**มีข้อจำกัดเรื่องจำนวนสไลด์เมื่อแปลงงานนำเสนอเป็น TIFF หรือไม่?**

ไม่มีข้อจำกัดจำนวนสไลด์คงที่สำหรับการส่งออกเป็น TIFF ขนาดของงานที่สามารถประมวลผลได้ขึ้นอยู่กับหน่วยความจำที่มีอยู่ ความซับซ้อนของสไลด์ และขนาดของผลลัพธ์

**ภาพเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนสไลด์ของ PowerPoint จะถูกรักษาเมื่อแปลงเป็น TIFF หรือไม่?**

ไม่ เนื่องจาก TIFF เป็นรูปแบบภาพคงที่ ดังนั้นภาพเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนสไลด์จะไม่ถูกรักษา มีเพียงภาพนิ่งของสไลด์ที่ถูกส่งออกเท่านั้น