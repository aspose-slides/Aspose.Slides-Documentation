---
title: แปลง PPT และ PPTX เป็น PDF ใน Python ผ่าน Java [รวมฟีเจอร์ขั้นสูง]
linktitle: PowerPoint เป็น PDF
type: docs
weight: 40
url: /th/python-java/convert-powerpoint-to-pdf/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- PowerPoint เป็น PDF
- งานนำเสนอเป็น PDF
- PPT เป็น PDF
- แปลง PPT เป็น PDF
- PPTX เป็น PDF
- แปลง PPTX เป็น PDF
- บันทึก PowerPoint เป็น PDF
- บันทึก PPT เป็น PDF
- บันทึก PPTX เป็น PDF
- ส่งออก PPT เป็น PDF
- ส่งออก PPTX เป็น PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น PDF ที่มีคุณภาพสูงและค้นหาได้ใน Python ผ่าน Java ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดที่รวดเร็วและตัวเลือกการแปลงขั้นสูง."
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ใน Python ผ่าน Java มีข้อได้เปรียบหลายอย่าง รวมถึงความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการรักษารูปแบบเค้าโครงและการจัดรูปแบบของงานนำเสนอ คู่มือนี้สาธิตวิธีการแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพภาพ รวมถึงการแทรกสไลด์ที่ซ่อนอยู่ การตั้งรหัสผ่านให้ไฟล์ PDF การตรวจจับการแทนที่ฟอนต์ การเลือกสไลด์เฉพาะสำหรับการแปลง และการใช้มาตรฐานความสอดคล้องกับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ไปยังคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) แล้วบันทึกงานนำเสนอเป็น PDF ด้วยเมธอด [save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) คลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) เปิดเผยเมธอด [save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ที่โดยทั่วไปใช้ในการแปลงงานนำเสนอเป็น PDF

{{% alert color="info" title="Note" %}}
Aspose.Slides สำหรับ Python ผ่าน Java ใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อตัวแปลงงานนำเสนอเป็น PDF Aspose.Slides จะเติมฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่าในรูปแบบ "*Aspose.Slides v XX.XX*" **Note** ว่าคุณไม่สามารถสั่ง Aspose.Slides ให้เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้
{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้ไฟล์ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง ส่วนประกอบและแอตทริบิวต์จะถูกเรนเดอร์อย่างแม่นยำในการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปทรง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ลิงก์
* ส่วนหัวและส่วนท้าย
* รายการหัวข้อย่อย
* ตาราง

## **แปลง PowerPoint เป็น PDF**

การแปลงมาตรฐานใช้ค่าการส่งออก PDF เริ่มต้น ใช้ตัวเลือกกำหนดเองเมื่อคุณต้องการควบคุมคุณภาพภาพ เนื้อหาเพจ หรือความสอดคล้องของ PDF

ติดตั้ง [Aspose.Slides for Python via Java](/slides/th/python-java/installation/) และ Java runtime ที่เข้ากันได้ก่อนรันตัวอย่าง แต่ละตัวอย่างจะอ่านไฟล์ `presentation.pptx` จากไดเรกทอรีทำงานปัจจุบัน; แทนที่ด้วยไฟล์ PPT, PPTX หรือ ODP ของคุณ เริ่ม JVM ครั้งหนึ่งต่อกระบวนการ Python

โค้ดนี้แปลงงานนำเสนอเป็น PDF:

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
Aspose มีตัวแปลงออนไลน์ฟรี **PowerPoint to PDF converter** ([https://products.aspose.app/slides/th/conversion/ppt-to-pdf](https://products.aspose.app/slides/th/conversion/ppt-to-pdf)) ที่สาธิตกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดสอบด้วยตัวแปลงนี้เพื่อดูการทำงานจริงของขั้นตอนที่อธิบายไว้ที่นี่
{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides ให้ตัวเลือกกำหนดเอง—คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/)—เพื่อให้คุณสามารถปรับแต่ง PDF ที่สร้างขึ้น ล็อก PDF ด้วยรหัสผ่าน หรือกำหนดวิธีการทำงานของกระบวนการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกกำหนดเอง**

ด้วยตัวเลือกการแปลงกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพแรสเตอร์ ระบุวิธีการจัดการเมตาฟายล์ ตั้งระดับการบีบอัดสำหรับข้อความ กำหนด DPI สำหรับภาพ และอื่น ๆ

โค้ดตัวอย่างด้านล่างแสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมตัวเลือกกำหนดเองหลายรายการ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setJpegQuality(jpype.JByte(90))
    pdf_options.setSufficientResolution(300)
    pdf_options.setSaveMetafilesAsPng(True)
    pdf_options.setTextCompression(PdfTextCompression.Flate)
    pdf_options.setCompliance(PdfCompliance.Pdf15)
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) จากคลาส [PdfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนเป็นหน้าใน PDF ที่ได้

โค้ดนี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนรวมอยู่:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setShowHiddenSlides(True)
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **แปลง PowerPoint เป็น PDF ที่มีการตั้งรหัสผ่าน**

โค้ดนี้สาธิตวิธีการแปลงงานนำเสนอ PowerPoint เป็น PDF ที่มีการตั้งรหัสผ่านโดยใช้พารามิเตอร์การป้องกันจากคลาส [PdfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setPassword("password")
    permissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
    pdf_options.setAccessPermissions(permissions)
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **ตรวจจับการแทนที่ฟอนต์**

Aspose.Slides มีเมธอด [setWarningCallback](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveoptions/#setWarningCallback) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/) ซึ่งช่วยให้คุณตรวจจับการแทนที่ฟอนต์ระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

ใช้พร็อกซี่ JPype เพื่อรับคอลแบ็กคำเตือนจาก Java API แปลงสตริงคำอธิบายจาก Java เป็นสตริง Python ก่อนตรวจสอบคำนำหน้า:

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


presentation = Presentation("presentation.pptx")
try:
    handler = FontSubstitutionHandler()
    callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
    pdf_options = PdfOptions()
    pdf_options.setWarningCallback(callback)
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการรับคอลแบ็กการแทนที่ฟอนต์ระหว่างกระบวนการเรนเดอร์ ดูที่ [Getting Warning Callbacks for Fonts Substitution](/slides/th/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่ฟอนต์ ดูบทความ [Font Substitution](/slides/th/python-java/font-substitution/)
{{% /alert %}}

## **แปลงสไลด์ที่เลือกใน PowerPoint เป็น PDF**

หมายเลขสไลด์ที่ส่งให้กับ [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) จะนับจาก 1 ตัวอย่างนี้ส่งออกสไลด์ที่ 1 และ 3 เมื่อทั้งสองมีอยู่:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    if presentation.getSlides().size() >= 3:
        slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
        presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
    else:
        print("The presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์กำหนดเอง**

ตัวอย่างนี้ส่งออกสไลด์แรกบนหน้าที่มีขนาด 612x792 จุด (US Letter) โดยทำการโคลนสไลด์ไปยังงานนำเสนอใหม่ที่มีขนาดตามที่กำหนด:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
try:
    resized_presentation = Presentation()
    try:
        resized_presentation.getSlideSize().setSize(612.0, 792.0, SlideSizeScaleType.EnsureFit)
        if presentation.getSlides().size() > 0:
            slide = presentation.getSlides().get_Item(0)
            resized_presentation.getSlides().insertClone(0, slide)
            resized_presentation.getSlides().removeAt(1)
            resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
        else:
            print("The presentation contains no slides.")
    finally:
        resized_presentation.dispose()
finally:
    presentation.dispose()
```

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์บันทึกย่อ**

โค้ดนี้สาธิตวิธีการแปลงงานนำเสนอ PowerPoint เป็น PDF ที่รวมบันทึกย่อไว้ด้วย:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **มาตรฐานการเข้าถึงและความสอดคล้องของ PDF**

เมื่อเตรียม PDF ที่เข้าถึงได้ ให้ดูที่ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ใช้ [PdfOptions.setCompliance](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#setCompliance) เพื่อเลือกมาตรฐานผลลัพธ์: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ดนี้แสดงกระบวนการแปลง PowerPoint เป็น PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานความสอดคล้องที่แตกต่างกัน:

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

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA Aspose.Slides จะถือกราฟิกที่ซับซ้อนเช่น SmartArt, แผนภูมิ และสูตรเป็นรูปเดียว รายการเส้นทางย่อยจะไม่ได้รับการเก็บเป็นเนื้อหาแยก และอาจถูกทำเครื่องหมายว่าเป็น artifacts; ข้อความอธิบายจะให้เฉพาะกับรูปทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงหลายไฟล์ PowerPoint เป็น PDF พร้อมกันได้หรือไม่?**

ได้, Aspose.Slides รองรับการแปลงเป็นชุดของหลายไฟล์ PPT หรือ PPTX เป็น PDF คุณสามารถวนลูปไฟล์ของคุณและเรียกใช้กระบวนการแปลงโดยอัตโนมัติ

**สามารถตั้งรหัสผ่านให้ PDF ที่แปลงแล้วได้หรือไม่?**

ได้ ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/) เพื่อกำหนดรหัสผ่านและกำหนดสิทธิ์การเข้าถึงระหว่างกระบวนการแปลง

**จะรวมสไลด์ที่ซ่อนอยู่ใน PDF อย่างไร?**

ใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่ได้

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**

ได้, คุณสามารถควบคุมคุณภาพภาพโดยใช้เมธอดเช่น [setJpegQuality](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#setJpegQuality) และ [setSufficientResolution](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#setSufficientResolution) ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

**Aspose.Slides รองรับมาตรฐานความสอดคล้อง PDF/A หรือไม่?**

ได้, Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่สอดคล้องกับ [มาตรฐานต่าง ๆ](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfcompliance/) ได้แก่ PDF/A1a, PDF/A1b, และ PDF/UA เพื่อการเข้าถึงหรือการเก็บถาวร เลือกมาตรฐานที่เหมาะสมและตรวจสอบผลลัพธ์ตามความต้องการของคุณ

## **แหล่งข้อมูลเพิ่มเติม**

- [Aspose.Slides for Python via Java Documentation](/slides/th/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/th/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/th/conversion)