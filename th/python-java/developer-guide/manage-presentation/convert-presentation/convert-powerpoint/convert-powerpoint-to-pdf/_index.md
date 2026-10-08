---
title: แปลง PPT และ PPTX เป็น PDF ด้วย Python ผ่าน Java [รวมคุณลักษณะขั้นสูง]
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
- การแนบไฟล์
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูงที่ค้นหาได้ใน Python ผ่าน Java ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดเร็วและตัวเลือกการแปลงขั้นสูง."
---
## **ภาพรวม**

การแปลงไฟล์นำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ด้วย Python ผ่าน Java มีข้อดีหลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการรักษาเค้าโครงและรูปแบบของการนำเสนอของคุณ คู่มือนี้จะแสดงวิธีแปลงการนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพของภาพ รวมถึงสไลด์ที่ซ่อนอยู่ ป้องกันไฟล์ PDF ด้วยรหัสผ่าน ตรวจจับการแทนที่ฟอนท์ เลือกสไลด์เฉพาะสำหรับการแปลง และใช้มาตรฐานการปฏิบัติตามเพื่อเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงการนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงการนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ไปยังคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) จากนั้นบันทึกการนำเสนอเป็น PDF โดยใช้เมธอด [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) คลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) มีเมธอด [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) ที่มักใช้เพื่อแปลงการนำเสนอเป็น PDF

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java inserts its API information and version number into output documents. For example, when converting a presentation to PDF, Aspose.Slides populates the Application field with "*Aspose.Slides*" and the PDF Producer field with a value in the form "*Aspose.Slides v XX.XX*". **หมายเหตุ** ที่คุณไม่สามารถบังคับให้ Aspose.Slides เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้.
{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* การนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากการนำเสนอเป็น PDF

Aspose.Slides ส่งออกการนำเสนอเป็น PDF เพื่อให้ PDF ที่ได้ตรงกับการนำเสนอเดิมอย่างใกล้เคียง องค์ประกอบและแอตทริบิวต์จะถูกเรนเดอร์อย่างแม่นยำในกระบวนการแปลง รวมถึง:

* ภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ลิงก์
* ส่วนหัวและส่วนท้าย
* จุดสัญลักษณ์
* ตาราง

## **แปลง PowerPoint เป็น PDF**

การแปลงมาตรฐานใช้การตั้งค่าเริ่มต้นของการส่งออก PDF ใช้ตัวเลือกที่กำหนดเองเมื่อคุณต้องการควบคุมคุณภาพของภาพ เนื้อหาหน้า หรือการปฏิบัติตาม PDF

ติดตั้ง [Aspose.Slides for Python via Java](/slides/th/python-java/installation/) และ Java runtime ที่เข้ากันได้ก่อนรันตัวอย่าง แต่ละตัวอย่างอ่าน `presentation.pptx` จากไดเรกทอรีทำงานปัจจุบัน; แทนที่ด้วยไฟล์ PPT, PPTX หรือ ODP ของคุณ เริ่ม JVM ครั้งเดียวต่อกระบวนการ Python

ตัวอย่างต่อไปนี้โหลดการนำเสนอและบันทึกสไลด์ที่มองเห็นทั้งหมดเป็น PDF โดยใช้การตั้งค่าการส่งออกเริ่มต้น

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
Aspose มีตัวแปลงออนไลน์ฟรี [**ตัวแปลง PowerPoint เป็น PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ที่แสดงกระบวนการแปลงการนำเสนอเป็น PDF คุณสามารถทดสอบกับตัวแปลงนี้เพื่อดูการทำงานของขั้นตอนที่อธิบายไว้ที่นี่
{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides ให้ตัวเลือกที่กำหนดเอง — properties ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) — ที่ช่วยให้คุณปรับแต่ง PDF ที่ได้ ล็อก PDF ด้วยรหัสผ่าน หรือกำหนดวิธีการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกที่กำหนดเอง**

โดยใช้ตัวเลือกการแปลงที่กำหนดเองคุณสามารถกำหนดค่าคุณภาพที่ต้องการสำหรับภาพราสเตอร์ ระบุวิธีการจัดการ metafile ตั้งค่าระดับการบีบอัดสำหรับข้อความ กำหนด DPI สำหรับภาพ เป็นต้น

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF 1.5 โดยตั้งค่า JPEG quality เป็น 90 ความละเอียดภาพเป็น 300 DPI บันทึก metafiles เป็น PNG และบีบอัดข้อความด้วย Flate

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

### **รักษาไฟล์ OLE ที่ฝังไว้เป็นไฟล์แนบ PDF**

หากการนำเสนอมีเวิร์กบุ๊ก Excel ฝังอยู่ คุณอาจต้องการให้ผู้รับ PDF สามารถเข้าถึงข้อมูลในเวิร์กบุ๊กได้เช่นกัน เรียกใช้เมธอด [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) ด้วยค่า `True` เพื่อรักษาไฟล์ OLE ที่ฝังไว้เป็นไฟล์แนบใน PDF ที่สร้างขึ้น

ค่าเริ่มต้นคือ `False`: รูปภาพตัวอย่างหรือไอคอนของอ็อบเจกต์ OLE จะถูกเรนเดอร์บนหน้า PDF แต่ไฟล์ที่ฝังอยู่จะไม่รวมเป็นไฟล์แนบ การตั้งค่าเป็น `True` จะเพิ่มไฟล์ข้อมูลเข้าไป อีกทั้งการแสดงตัวอย่างยังคงเป็นภาพใกล้เคียง; ไฟล์แนบช่วยให้ผู้รับเปิดหรือบันทึกไฟล์ฝังแยกจากกัน อ็อบเจกต์ OLE จะไม่กลายเป็นเวิร์กชีต Excel แบบโต้ตอบบนหน้า PDF

ตัวอย่างต่อไปนี้โหลดการนำเสนอที่มีเวิร์กบุ๊ก Excel ฝังอยู่แล้วและส่งออกเป็น PDF พร้อมแนบเวิร์กบุ๊ก

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

1. เปิด PDF ที่ส่งออกในโปรแกรมดูที่รองรับไฟล์แนบ เช่น Adobe Acrobat Reader
2. เปิดแผง **Attachments** ของโปรแกรมและค้นหาเวิร์กบุ๊กที่ฝังอยู่
3. บันทึกไฟล์แนบและเปิดใน Excel เพื่อตรวจสอบข้อมูล หรือเปิดโดยตรงหากโปรแกรมอนุญาต การแสดงตัวอย่างบนหน้า PDF แยกจากไฟล์แนบ

{{% alert color="info" title="Note" %}}
มาตรฐาน PDF/A กำหนดข้อจำกัดสำหรับไฟล์แนบ: PDF/A-1 ไม่อนุญาตไฟล์ฝัง, PDF/A-2 อนุญาตเฉพาะไฟล์แนบ PDF/A, PDF/A-3 อนุญาตประเภทไฟล์อื่นรวมถึงเวิร์กบุ๊ก Excel สิ่งเหล่านี้เป็นข้อกำหนดของมาตรฐาน ไม่ได้เป็นข้อจำกัดเฉพาะของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF เริ่มต้นและไม่ได้สาธิตการส่งออก PDF/A
{{% /alert %}}

### **แปลง PowerPoint เป็น PDF ด้วยสไลด์ที่ซ่อนอยู่**

หากการนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) จากคลาส [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนเป็นหน้าใน PDF ที่สร้างขึ้น

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF พร้อมรวมสไลด์ที่ซ่อนอยู่ทั้งหมด

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

### **แปลง PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่าน**

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF ที่ต้องใช้รหัสผ่าน `password` เพื่อเปิด การอนุญาตการเข้าถึงให้พิมพ์ รวมถึงการพิมพ์คุณภาพสูง

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

### **ตรวจจับการแทนที่ฟอนท์**

Aspose.Slides ให้เมธอด [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) เพื่อให้คุณตรวจจับการแทนที่ฟอนท์ระหว่างกระบวนการแปลงการนำเสนอเป็น PDF

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF และพิมพ์คำเตือนการแทนที่ฟอนท์ไปยังคอนโซล คำเตือนจะปรากฏเฉพาะเมื่อฟอนท์ที่ไม่มีอยู่ถูกแทนที่ระหว่างการส่งออก ใช้พร็อกซี JPype เพื่อรับการเรียกกลับการเตือนจาก API ของ Java แปลงสตริงคำอธิบายจาก Java เป็นสตริง Python ก่อนตรวจสอบคำนำหน้าของมัน

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
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่ฟอนท์ โปรดดูบทความ [การแทนที่ฟอนท์](/slides/th/python-java/font-substitution/)
{{% /alert %}}

### **จัดการฟอนท์ที่ไม่มีรูปแบบ Bold เฉพาะ**

การนำเสนอสามารถใช้การจัดรูปแบบหนาแม้ฟอนท์จะไม่มีรูปแบบ Bold เฉพาะข้อความจะยังคงแสดงเป็นหนาผ่านการทำให้หนาสังเคราะห์ ซึ่งทำให้ glyph ปกติหนาขึ้น เมื่อข้อความนั้นดูหนามากเกินไปหรือแตกต่างจากที่คาดไว้ใน PDF ให้ลองเรียกเมธอด [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) ด้วยค่า `True` ตัวเลือกนี้จะเรนเดอร์ข้อความที่ได้รับผลกระทบเป็นบิทแมพในระหว่างการส่งออก PDF และอาจช่วยปรับปรุงการแสดงผลของฟอนท์บางประเภท ค่าเริ่มต้นคือ `False`

การนำเสนอแบบตัวอย่างมีสองกล่องข้อความ: กล่องหนึ่งมีข้อความปกติและอีกกล่องหนึ่งมีการจัดรูปแบบหนาใช้ฟอนท์เดียวกันที่ไม่มีรูปแบบ Bold เฉพาะ ตัวอย่างต่อไปนี้โหลดการนำเสนอ เปิดการ rasterize ฟอนท์ที่ไม่มีรูปแบบ Bold และส่งออกเป็น PDF

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

ตัวอย่างต่อไปนี้แสดงผลลัพธ์ที่ปิดและเปิดตัวเลือก ในตัวอย่างนี้ข้อความหนามีขีดที่หนากว่าเมื่อปิดตัวเลือก เมื่อเปิดตัวเลือก ขีดจะบางลง; ข้อความปกติไม่เปลี่ยนแปลง เปรียบเทียบผลลัพธ์ก่อนเลือกการตั้งค่าสำหรับการนำเสนอของคุณ

| ตัวเลือกปิด (`False`, ค่าเริ่มต้น) | ตัวเลือกเปิด (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

ในตัวอย่างนี้ การเปิดตัวเลือกทำให้ข้อความหนาแปลงเป็นบิทแมพเท่านั้น: ไม่สามารถเลือก คัดลอก หรือค้นหาเป็นข้อความโดยไม่มี OCR ได้และขอบของมันดูนุ่มขึ้นเมื่อซูม 800% ข้อความปกติยังคงค้นหาได้ เมื่อปิดตัวเลือก ทั้งสองสตริงจะยังคงเป็นข้อความ

ตัวเลือกนี้ทำให้ rasterize ข้อความที่จัดรูปแบบเป็นหนาเมื่อฟอนท์ไม่มีรูปแบบ Bold เฉพาะ การ [การแทนที่ฟอนท์](/slides/th/python-java/font-substitution/) จะเลือกฟอนท์อื่นเมื่อฟอนท์ต้นฉบับไม่มีอยู่

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

หมายเลขสไลด์ที่ส่งให้กับเมธอด [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) เริ่มต้นที่ 1 ตัวอย่างนี้ส่งออกสไลด์ที่ 1 และ 3 เมื่อทั้งสองสไลด์มีอยู่

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

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่กำหนดเอง**

ตัวอย่างนี้ส่งออกสไลด์แรกบนหน้าที่มีขนาด 612 × 792 points (US Letter) โดยทำการโคลนสไลด์เข้าสู่การนำเสนอใหม่ด้วยขนาดที่ระบุและปรับขนาดเนื้อหาสไลด์ให้พอดี

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

    # ลบสไลด์ว่างที่ถูกสร้างขึ้นเมื่อสร้างการนำเสนอใหม่
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **แปลง PowerPoint เป็น PDF ในมุมมองโน้ตสไลด์**

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF โดยวางโน้ตผู้พูดของแต่ละสไลด์ไว้ด้านล่างสไลด์ ใช้การนำเสนอที่มีโน้ตผู้พูดเพื่อดูผลลัพธ์

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

เมื่อจัดทำ PDF ที่เข้าถึงได้ โปรดอ้างอิง [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ใช้เมธอด [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) เพื่อเลือกมาตรฐานผลลัพธ์: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ดนี้สาธิตกระบวนการแปลง PowerPoint เป็น PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามที่ต่างกัน

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

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะถือกราฟิกซับซ้อนเช่น SmartArt, ชาร์ต, และสูตรเป็นรูปเดียว ไม่แยกส่วนเส้นทางเป็นเนื้อหาแยกและอาจถูกทำเครื่องหมายเป็นวัตถุประดิษฐ์; ข้อความอธิบายภาพ (alternative text) จะให้เฉพาะสำหรับรูปทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF ได้เป็นชุดหรือไม่?**  
ได้, Aspose.Slides รองรับการแปลงแบบเป็นชุดของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนลูปไฟล์ของคุณและเรียกใช้กระบวนการแปลงโดยอัตโนมัติ

**สามารถป้องกัน PDF ที่แปลงแล้วด้วยรหัสผ่านได้หรือไม่?**  
ได้ ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) เพื่อตั้งค่ารหัสผ่านและกำหนดสิทธิ์การเข้าถึงระหว่างกระบวนการแปลง

**ฉันจะรวมสไลด์ที่ซ่อนอยู่ใน PDF อย่างไร?**  
เรียกเมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) ด้วยค่า `True` ในคลาส [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่สร้างขึ้น

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**  
ได้ คุณสามารถควบคุมคุณภาพภาพโดยใช้เมธอดเช่น [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) และ [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) ในคลาส [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

**Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?**  
ได้ Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่สอดคล้องกับ [มาตรฐานต่าง ๆ](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/) รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA สำหรับการเข้าถึงหรือการเก็บถาวร เลือกมาตรฐานที่เหมาะสมและตรวจสอบผลลัพธ์ตามความต้องการของคุณ

## **ทรัพยากรเพิ่มเติม**

- [เอกสาร Aspose.Slides for Python via Java](/slides/th/python-java/)
- [อ้างอิง API Aspose.Slides for Python via Java](https://reference.aspose.com/slides/python-java/)
- [เครื่องแปลงออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/conversion)