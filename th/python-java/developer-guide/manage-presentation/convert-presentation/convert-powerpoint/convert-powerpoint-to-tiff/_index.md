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
description: "เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint (PPT, PPTX) เป็นภาพ TIFF คุณภาพสูงอย่างง่ายดายโดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java พร้อมตัวอย่างโค้ด"
---
## **บทนำ**

TIFF (**Tagged Image File Format**) เป็นรูปแบบภาพแรสเตอร์ที่รองรับหลายหน้าและการบีบอัดแบบไม่มีการสูญเสียข้อมูล มันมีประโยชน์สำหรับการเก็บสไลด์ที่เรนเดอร์ไว้ในไฟล์ภาพเดียว

โดยใช้ Aspose.Slides for Python ผ่าน Java คุณสามารถแปลงงานนำเสนอ PowerPoint (PPT, PPTX) และ OpenDocument (ODP) เป็น TIFF ตัวอย่างแต่ละอันด้านล่างจะเริ่มเครื่องเสมือน Java หากจำเป็นและจะปล่อยงานนำเสนอหลังการใช้งาน

## **แปลงงานนำเสนอเป็น TIFF**

โดยใช้เมธอด [save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ที่ให้อยู่ในคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) คุณสามารถแปลงงานนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างเร็ว ผลลัพธ์ TIFF แบบหลายหน้าจะมีภาพที่เรนเดอร์ของแต่ละสไลด์ในขนาดเริ่มต้น

โค้ดนี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น TIFF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # บันทึกสไลด์ทั้งหมดในไฟล์ TIFF แบบหลายหน้า.
    presentation.save("output.tiff", SaveFormat.Tiff)
finally:
    presentation.dispose()
```

## **แปลงงานนำเสนอเป็น TIFF สีขาว-ดำ**

เมธอด [setBwConversionMode](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/#setBwConversionMode) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/) ให้คุณระบุอัลกอริทึมที่ใช้เมื่อแปลงสไลด์หรือภาพสีเป็น TIFF สีขาว-ดำ โปรดทราบว่าการตั้งค่านี้ใช้ได้เฉพาะเมื่อเมธอด [setCompressionType](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/#setCompressionType) ถูกตั้งค่าเป็น [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) หรือ [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffcompressiontypes/#CCITT3).

{{% alert color="info" title="หมายเหตุ" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/#setBwConversionMode) เป็นการตั้งระดับการส่งออกที่เลือกอัลกอริทึมการแปลงพิกเซลสำหรับภาพ TIFF ทั้งหมด เพื่อกำหนดว่ารูปร่างแต่ละอันควรแสดงอย่างไรเมื่อโหมดแสดงสีขาว-ดำเปิดใช้งาน ให้ใช้ [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#setBlackWhiteMode). ดู [Control Black-and-White Rendering for Shapes](/slides/th/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes) สำหรับตัวอย่าง.
{{% /alert %}}

สมมติว่าเรามีไฟล์ "sample.pptx" ที่มีสไลด์ต่อไปนี้:

![สไลด์งานนำเสนอ](slide_black_and_white.png)

โค้ดนี้แสดงวิธีการแปลงสไลด์สีเป็น TIFF สีขาว-ดำ:

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

![TIFF สีขาว-ดำ](TIFF_black_and_white.png)

## **แปลงงานนำเสนอเป็น TIFF ด้วยขนาดกำหนดเอง**

หากคุณต้องการภาพ TIFF ที่มีขนาดเฉพาะ คุณสามารถกำหนดค่าที่ต้องการด้วยเมธอดที่มีใน [TiffOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/). ตัวอย่างเช่น เมธอด [setImageSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/#setImageSize) ให้คุณกำหนดขนาดของภาพที่ได้.

โค้ดนี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยขนาดกำหนดเอง:

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

    # กำหนดความละเอียดในแนวนอนและแนวตั้ง.
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # กำหนดขนาดผลลัพธ์เป็นพิกเซล.
    image_size = Dimension(1728, 1078)
    tiff_options.setImageSize(image_size)

    # รวมหมายเหตุของผู้พูดทั้งหมดไว้ด้านล่างของแต่ละสไลด์.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    tiff_options.setSlidesLayoutOptions(notes_options)

    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

## **แปลงงานนำเสนอเป็น TIFF ด้วยฟอร์แมตพิกเซลของภาพที่กำหนดเอง**

โดยใช้เมธอด [setPixelFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/#setPixelFormat) ของคลาส [TiffOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/) คุณสามารถระบุฟอร์แมตพิกเซลที่ต้องการสำหรับภาพ TIFF ที่ได้.

โค้ดนี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยฟอร์แมตพิกเซลที่กำหนดเอง:

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

{{% alert title="เคล็ดลับ" color="success" %}}
ลองดู [เครื่องแปลง PowerPoint เป็นโปสเตอร์ฟรี](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online) ของ Aspose.
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงสไลด์เดียวแทนการแปลงงานนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้หรือไม่?**

ใช่ Aspose.Slides อนุญาตให้คุณแปลงสไลด์แต่ละอันจากงานนำเสนอ PowerPoint และ OpenDocument เป็นภาพ TIFF แยกกันได้.

**ไม่มีขีดจำกัดจำนวนสไลด์ที่กำหนดสำหรับการส่งออกเป็น TIFF หรือไม่?**

ไม่มีขีดจำกัดจำนวนสไลด์ที่กำหนดสำหรับการส่งออกเป็น TIFF จำนวนสไลด์ที่คุณสามารถประมวลผลได้ขึ้นอยู่กับหน่วยความจำที่มีอยู่ ความซับซ้อนของสไลด์ และขนาดของภาพผลลัพธ์.

**แอนิเมชันและเอฟเฟกต์การเปลี่ยนภาพของ PowerPoint จะถูกเก็บไว้เมื่อแปลงสไลด์เป็น TIFF หรือไม่?**

ไม่, TIFF เป็นรูปแบบภาพคงที่ ดังนั้นแอนิเมชันและเอฟเฟกต์การเปลี่ยนภาพจะไม่ถูกเก็บไว้; มีเพียงภาพสแนปช็อตคงที่ของสไลด์ที่ถูกส่งออก.