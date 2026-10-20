---
title: แปลง PPT และ PPTX เป็น PDF ใน Python ผ่าน Java [รวมคุณลักษณะขั้นสูง]
linktitle: PowerPoint เป็น PDF
type: docs
weight: 40
url: /th/python-java/convert-powerpoint-to-pdf/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- PowerPoint เป็น PDF
- การนำเสนอเป็น PDF
- PPT เป็น PDF
- แปลง PPT เป็น PDF
- PPTX เป็น PDF
- แปลง PPTX เป็น PDF
- บันทึก PowerPoint เป็น PDF
- บันทึก PPT เป็น PDF
- บันทึก PPTX เป็น PDF
- ส่งออก PPT เป็น PDF
- ส่งออก PPTX เป็น PDF
- ไฟล์แนบ
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูงและสามารถค้นหาได้ใน Python ผ่าน Java ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดที่รวดเร็วและตัวเลือกการแปลงขั้นสูง"
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ใน Python ผ่าน Java มีข้อได้เปรียบหลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการรักษาโครงร่างและการจัดรูปแบบของงานนำเสนอของคุณ คู่มือนี้จะแสดงวิธีแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อตรวจสอบคุณภาพภาพ รวมถึงการรวมสไลด์ที่ซ่อนไว้ การตั้งรหัสผ่านให้ไฟล์ PDF การตรวจจับการแทนที่ฟอนต์ การเลือกสไลด์เฉพาะสำหรับการแปลง และการใช้มาตรฐานการปฏิบัติตามสำหรับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอากิวเมนต์ให้กับคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) แล้วบันทึกงานนำเสนอเป็น PDF ด้วยเมธอด [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) คลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) เปิดเผยเมธอด [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) ที่โดยทั่วไปใช้เพื่อแปลงงานนำเสนอเป็น PDF

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java ใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่นเมื่อแปลงงานนำเสนอเป็น PDF, Aspose.Slides จะเติมค่าในฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่ารูปแบบ "*Aspose.Slides v XX.XX*" . **หมายเหตุ** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้.
{{% /alert %}}

Aspose.Slides ให้คุณแปลง:

* การนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากการนำเสนอเป็น PDF

Aspose.Slides ส่งออกการนำเสนอเป็น PDF เพื่อให้ PDF ที่ได้ตรงกับการนำเสนอเดิมอย่างใกล้ชิด องค์ประกอบและแอตทริบิวต์จะถูกเรนเดอร์อย่างแม่นยำในการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* สัญลักษณ์หัวข้อ
* ตาราง

## **แปลง PowerPoint เป็น PDF**

การแปลงแบบมาตรฐานจะใช้การตั้งค่าเริ่มต้นของการส่งออก PDF ใช้ตัวเลือกกำหนดเองเมื่อคุณต้องการควบคุมคุณภาพภาพ เนื้อหาในหน้า หรือการปฏิบัติตามมาตรฐาน PDF

ตัวอย่างต่อไปนี้โหลดการนำเสนอและบันทึกสไลด์ที่มองเห็นทั้งหมดเป็น PDF โดยใช้การตั้งค่าเริ่มต้นของการส่งออก

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose มีตัวแปลงออนไลน์ฟรี [**ตัวแปลง PowerPoint เป็น PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ที่แสดงกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดลองใช้ตัวแปลงนี้เพื่อทำการดำเนินการตามขั้นตอนที่อธิบายไว้ที่นี่.
{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides มีตัวเลือกกำหนดเอง — คุณสมบัติโดยคลาส [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) — ที่ให้คุณกำหนด PDF ที่ได้, ล็อก PDF ด้วยรหัสผ่าน, หรือระบุวิธีการทำงานของกระบวนการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกกำหนดเอง**

โดยใช้ตัวเลือกการแปลงกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพราสเตอร์ ระบุวิธีการจัดการเมทาฟายล์ ตั้งค่าระดับการบีบอัดสำหรับข้อความ กำหนด DPI สำหรับภาพ และอื่น ๆ

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF 1.5 พร้อมคุณภาพ JPEG ตั้งเป็น 90, ความละเอียดภาพตั้งเป็น 300 DPI, เมทาฟายล์บันทึกเป็น PNG, และการบีบอัดข้อความแบบ Flate.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **เลือกการบีบอัดภาพโดยอัตโนมัติ**

เมื่อการนำเสนอมีรูปถ่ายหรือภาพหน้าจอจำนวนมาก การลดขนาด PDF ที่ส่งออกจะทำให้ส่งอีเมลหรือดาวน์โหลดได้ง่ายขึ้น เรียกใช้เมธอด [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setBestImagesCompressionRatio) ด้วยค่า `True` เพื่อให้เลือกอัลกอริทึมการบีบอัดที่เหมาะสมที่สุดสำหรับแต่ละภาพโดยอัตโนมัติในระหว่างการส่งออก PDF

ตัวอย่างต่อไปนี้โหลดการนำเสนอที่มีอยู่แล้ว เปิดการเลือกการบีบอัดภาพอัตโนมัติ และบันทึกเป็นเอกสาร PDF การตั้งค่าอื่น ๆ ของการส่งออก PDF ยังคงใช้ค่าเริ่มต้น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setBestImagesCompressionRatio(True)

presentation = Presentation("image-heavy.pptx")
try:
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

ตัวเลือกนี้เลือกอัลกอริธึมการบีบอัดสำหรับแต่ละภาพ การลดค่าที่ส่งให้กับเมธอด [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) จะทำให้คุณภาพภาพ JPEG ลดลง ในขณะที่การลดค่าที่ส่งให้กับเมธอด [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) จะทำให้ภาพถูกลดความละเอียดลง ซึ่งอาจทำให้รายละเอียดลดลง การเปิดใช้งานการเลือกการบีบอัดอัตโนมัติไม่ได้ทำให้ค่าตั้งต้นเหล่านี้ลดลง

การเลือกอัลกอริธึมการบีบอัดภาพต้องใช้เวลาและหน่วยความจำเพิ่มเติม การลดขนาดขึ้นอยู่กับภาพและการตั้งค่าการส่งออกของการนำเสนอ; การลดขนาดแบบคงที่ไม่รับประกันสำหรับทุกการนำเสนอ

### **รักษาไฟล์ OLE ฝังเป็นไฟล์แนบ PDF**

หากการนำเสนอมีเวิร์กบุ๊ค Excel ฝังอยู่ คุณอาจต้องการให้ผู้รับ PDF สามารถเข้าถึงข้อมูลของเวิร์กบุ๊คพร้อมกับดูสไลด์ได้ เรียกเมธอด [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) ด้วยค่า `True` เพื่อรักษาไฟล์ OLE ฝังเป็นไฟล์แนบใน PDF ที่ได้

ค่าตั้งต้นคือ `False`: รูปภาพหรือไอคอนตัวอย่างของวัตถุ OLE จะถูกเรนเดอร์บนหน้า PDF แต่ไฟล์ฝังจะไม่รวมเป็นไฟล์แนบ การตั้งค่าเป็น `True` จะเพิ่มข้อมูลไฟล์เข้าไป การแสดงตัวอย่างยังคงเป็นภาพนิ่ง; ไฟล์แนบทำให้ผู้รับเปิดหรือบันทึกไฟล์ฝังแยกจากกัน วัตถุ OLE จะไม่กลายเป็นชีต Excel แบบโต้ตอบบนหน้า PDF

ตัวอย่างต่อไปนี้โหลดการนำเสนอที่มีเวิร์กบุ๊ค Excel ฝังอยู่แล้วและส่งออกเป็น PDF พร้อมแนบเวิร์กบุ๊ค

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

เพื่อตรวจสอบผลลัพธ์:

1. เปิด PDF ที่ส่งออกในโปรแกรมดูที่รองรับไฟล์แนบ เช่น Adobe Acrobat Reader.
2. เปิดแผง **Attachments** ของโปรแกรมดูและค้นหาเวิร์กบุ๊คที่ฝังอยู่.
3. บันทึกไฟล์แนบและเปิดใน Excel เพื่อตรวจสอบข้อมูลของมัน หรือเปิดโดยตรงหากโปรแกรมดูอนุญาต การแสดงตัวอย่างบนหน้า PDF แยกจากไฟล์แนบ.

{{% alert color="info" title="Note" %}}
มาตรฐาน PDF/A มีข้อจำกัดเกี่ยวกับไฟล์แนบ: PDF/A-1 ห้ามไฟล์ฝัง, PDF/A-2 อนุญาตเฉพาะไฟล์แนบ PDF/A, และ PDF/A-3 อนุญาตไฟล์ประเภทอื่นรวมถึงเวิร์กบุ๊ค Excel สิ่งเหล่านี้เป็นข้อกำหนดของมาตรฐาน ไม่ใช่ข้อจำกัดของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF เริ่มต้นและไม่แสดงการส่งออก PDF/A.
{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อน**

หากการนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) จากคลาส [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนเป็นหน้าต่าง PDF ที่ได้.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **แปลง PowerPoint เป็น PDF ที่มีการตั้งรหัสผ่าน**

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF ที่ต้องใช้รหัสผ่าน `password` เพื่อเปิด การอนุญาตการเข้าถึงอนุญาตการพิมพ์ รวมถึงการพิมพ์คุณภาพสูง.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **ตรวจจับการแทนที่ฟอนต์**

Aspose.Slides มีเมธอด [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) ที่ช่วยให้คุณตรวจจับการแทนที่ฟอนต์ระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF และพิมพ์คำเตือนการแทนที่ฟอนต์ไปยังคอนโซล คำเตือนจะถูกพิมพ์เฉพาะเมื่อฟอนต์ที่ไม่มีอยู่ถูกแทนที่ในการส่งออก ใช้ JPype proxy เพื่อรับการตอบสนองคำเตือนจาก Java API แปลงสตริงคำอธิบาย Java เป็นสตริง Python ก่อนตรวจสอบคำนำหน้า:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่ฟอนต์ ดูบทความ [การแทนที่ฟอนต์](/slides/th/python-java/font-substitution/)
{{% /alert %}}

### **จัดการฟอนต์ที่ไม่มีแบบอักษรหนาเฉพาะ**

การนำเสนอสามารถทำให้ข้อความเป็นตัวหนาได้แม้ฟอนต์ไม่มีแบบอักษรหนาเฉพาะ ข้อความอาจแสดงเป็นตัวหนาผ่านการทำตัวหนาสังเคราะห์ ซึ่งทำให้ตัวอักษรเดิมหนาขึ้น เมื่อข้อความนั้นดูหนามากเกินไปหรือแตกต่างจากลักษณะที่ต้องการใน PDF ให้ลองเรียกเมธอด [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) ด้วยค่า `True` ตัวเลือกนี้จะเรนเดอร์ข้อความที่ได้รับผลกระทบเป็นบิตแมพในระหว่างการส่งออก PDF และอาจปรับปรุงลักษณะของฟอนต์บางตัว ค่าเริ่มต้นคือ `False`.

ตัวอย่างการนำเสนอมีสองกล่องข้อความ: หนึ่งมีข้อความปกติและหนึ่งมีการจัดรูปแบบเป็นตัวหนาโดยใช้ฟอนต์เดียวกันที่ไม่มีแบบอักษรหนาเฉพาะ ตัวอย่างต่อไปนี้โหลดการนำเสนอ เปิดการแรสเตอร์ฟอนต์ที่ไม่รองรับ และส่งออกเป็น PDF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setRasterizeUnsupportedFontStyles(True)

presentation = Presentation("unsupported-bold.pptx")
try:
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

ภาพตัวอย่างต่อไปนี้แสดงผลลัพธ์เมื่อปิดและเปิดตัวเลือก ในตัวอย่างนี้ข้อความหนามีเส้นหนากว่าที่ปิดตัวเลือก เมื่อเปิดตัวเลือก เส้นของข้อความหนาจะบางลง; ข้อความปกติไม่เปลี่ยนแปลง เปรียบเทียบผลลัพธ์ก่อนเลือกการตั้งค่าสำหรับการนำเสนอของคุณ.

| ตัวเลือกปิด (`False`, ค่าเริ่มต้น) | ตัวเลือกเปิด (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

ในตัวอย่างนี้ การเปิดตัวเลือกทำให้ข้อความหนาเป็นบิตแมพเท่านั้น: ไม่สามารถเลือก, คัดลอก หรือค้นหาเป็นข้อความโดยไม่มี OCR ได้ และขอบของมันดูนุ่มขึ้นที่การขยาย 800% ข้อความปกติยังคงค้นหาได้ เมื่อปิดตัวเลือก ทั้งสองข้อความยังคงเป็นข้อความอยู่.

ตัวเลือกนี้ทำการแรสเตอร์ข้อความที่จัดรูปเป็นตัวหนาเมื่อฟอนต์ไม่มีแบบอักษรหนาเฉพาะ [การแทนที่ฟอนต์](/slides/th/python-java/font-substitution/) แต่จะเลือกฟอนต์อื่นเมื่อฟอนต์เดิมไม่พร้อมใช้งาน.

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

หมายเลขสไลด์ที่ส่งให้เมธอด [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) นับจาก 1 ตัวอย่างนี้ส่งออกสไลด์ที่ 1 และ 3 เมื่อทั้งสองมีอยู่:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์กำหนดเอง**

ตัวอย่างนี้ส่งออกสไลด์แรกบนหน้าที่มีขนาด 612 x 792 จุด (US Letter) มันทำการคัดลอกสไลด์ไปยังการนำเสนอใหม่โดยกำหนดขนาดที่ระบุและปรับขนาดเนื้อหาสไลด์ให้พอดี

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # ลบสไลด์เปล่าที่สร้างมาพร้อมกับการนำเสนอใหม่.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์บันทึกย่อ**

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF โดยวางบันทึกเสียงพูดของแต่ละสไลด์ไว้ใต้สไลด์ ใช้การนำเสนอที่มีบันทึกเสียงพูดเพื่อดูผลลัพธ์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **มาตรฐานการเข้าถึงและการปฏิบัติตามสำหรับ PDF**

เมื่อเตรียม PDF ที่เข้าถึงได้ ให้อ้างอิง [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ใช้เมธอด [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) เพื่อเลือกมาตรฐานผลลัพธ์: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**.

โค้ดนี้แสดงกระบวนการแปลง PowerPoint เป็น PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามที่แตกต่างกัน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()

    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)

    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะถือกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปหนึ่งเดียว ไม่เก็บส่วนเส้นทางแต่ละส่วนเป็นเนื้อหาแยกและอาจถูกทำเครื่องหมายเป็นศิลปวัตถุ; ข้อความแทนที่จะให้เฉพาะรูปทั้งหมดเท่านั้น.

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF เป็นกลุ่มได้หรือไม่?**  
ได้, Aspose.Slides รองรับการแปลงเป็นชุดของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนลูปไฟล์ของคุณและใช้กระบวนการแปลงผ่านโปรแกรมได้.

**สามารถตั้งรหัสผ่านให้ PDF ที่แปลงแล้วได้หรือไม่?**  
ได้. ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) เพื่อกำหนดรหัสผ่านและระบุสิทธิ์การเข้าถึงในระหว่างกระบวนการแปลง.

**ฉันจะรวมสไลด์ที่ซ่อนอยู่ใน PDF ได้อย่างไร?**  
เรียกเมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) ด้วยค่า `True` ในคลาส [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนใน PDF ที่ได้.

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**  
ได้, คุณสามารถควบคุมคุณภาพภาพได้โดยใช้เมธอดเช่น [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) และ [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) ในคลาส [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ.

**Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?**  
ได้, Aspose.Slides ให้คุณส่งออก PDF ที่สอดคล้องกับ [various standards](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/) รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA เพื่อการเข้าถึงหรือการจัดเก็บ เลือกมาตรฐานที่เหมาะสมและตรวจสอบผลลัพธ์ตามความต้องการของคุณ.

## **ทรัพยากรเพิ่มเติม**

- [เอกสาร Aspose.Slides for Python via Java](/slides/th/python-java/)
- [อ้างอิง API Aspose.Slides for Python via Java](https://reference.aspose.com/slides/python-java/)
- [ตัวแปลงออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/conversion)