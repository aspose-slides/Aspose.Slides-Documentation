---
title: แปลง PPT และ PPTX เป็น PDF ใน Python ผ่าน Java [รวมคุณสมบัติขั้นสูง]
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
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูงที่สามารถค้นหาได้ใน Python ผ่าน Java โดยใช้ Aspose.Slides พร้อมตัวอย่างโค้ดที่รวดเร็วและตัวเลือกการแปลงขั้นสูง"
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ใน Python ผ่าน Java มีประโยชน์หลายประการ รวมถึงความเข้ากันได้บนอุปกรณ์ต่าง ๆ และการรักษาโครงร่างและการจัดรูปแบบของงานนำเสนอ ไฟล์คู่มือนี้แสดงวิธีการแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพของภาพ รวมถึงการใส่สไลด์ที่ซ่อนอยู่ ป้องกันไฟล์ PDF ด้วยรหัสผ่าน ตรวจจับการแทนที่แบบอักษร เลือกสไลด์เฉพาะสำหรับการแปลง และใช้มาตรฐานการปฏิบัติตามเพื่อเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ให้คลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) แล้วบันทึกงานนำเสนอเป็น PDF โดยใช้เมธอด [save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) วิธีนี้คลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) มีเมธอด [save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ที่ปกติใช้สำหรับแปลงงานนำเสนอเป็น PDF

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java ใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF Aspose.Slides จะเติมฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่าในรูปแบบ "*Aspose.Slides v XX.XX*" **หมายเหตุ** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้
{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:
* การนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากการนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF เพื่อให้ไฟล์ PDF ที่ได้ตรงกับงานนำเสนอเดิมมากที่สุด ส่วนประกอบและแอตทริบิวต์ต่าง ๆ จะถูกแสดงผลอย่างแม่นยำในการแปลง รวมถึง:
* รูปภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* สัญลักษณ์หัวข้อย่อย
* ตาราง

## **แปลง PowerPoint เป็น PDF**

การแปลงมาตรฐานใช้การตั้งค่าเริ่มต้นของการส่งออก PDF ใช้ตัวเลือกแบบกำหนดเองเมื่อคุณต้องการควบคุมคุณภาพของภาพ เนื้อหาหน้ากระดาษ หรือการปฏิบัติตามมาตรฐาน PDF

ติดตั้ง [Aspose.Slides for Python via Java](/slides/th/python-java/installation/) และ Java runtime ที่เข้ากันได้ก่อนรันตัวอย่าง แต่ละตัวอย่างจะอ่านไฟล์ `presentation.pptx` จากไดเรกทอรีทำงานปัจจุบัน; แทนที่ด้วยไฟล์ PPT, PPTX หรือ ODP ของคุณ เริ่ม JVM ครั้งเดียวต่อกระบวนการ Python

โค้ดนี้จะแปลงงานนำเสนอเป็น PDF:

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
Aspose มีตัวแปลง **PowerPoint ไปเป็น PDF** ออนไลน์ฟรีที่ https://products.aspose.app/slides/th/conversion/ppt-to-pdf ซึ่งแสดงขั้นตอนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดสอบกับตัวแปลงนี้เพื่อดูการทำงานจริงของกระบวนการที่อธิบายไว้ที่นี่
{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides ให้ตัวเลือกแบบกำหนดเอง—properties ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/)—ซึ่งช่วยให้คุณปรับแต่ง PDF ที่ได้ ล็อก PDF ด้วยรหัสผ่าน หรือระบุวิธีการทำงานของกระบวนการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกแบบกำหนดเอง**

ด้วยตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ กำหนดวิธีการจัดการ metafiles ตั้งค่าระดับการบีบอัดข้อความ กำหนด DPI สำหรับภาพ ฯลฯ

ตัวอย่างโค้ดด้านล่างแสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมตัวเลือกแบบกำหนดเองหลายรายการ:

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

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) จากคลาส [PdfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/) เพื่อใส่สไลด์ที่ซ่อนเป็นหน้าต่าง PDF ที่ได้

โค้ดนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่:

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

### **แปลง PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่าน**

โค้ดนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่านโดยใช้พารามิเตอร์การป้องกันจากคลาส [PdfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/):

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

### **ตรวจจับการแทนที่แบบอักษร**

Aspose.Slides มีเมธอด [setWarningCallback](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveoptions/#setWarningCallback) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/) ที่ช่วยให้คุณตรวจจับการแทนที่แบบอักษรระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

ใช้ JPype proxy เพื่อติดตามการแจ้งเตือนจาก Java API แปลงสตริงคำอธิบายจาก Java ให้เป็นสตริง Python ก่อนตรวจสอบคำนำหน้า:

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
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการรับการแจ้งเตือนการแทนที่แบบอักษรระหว่างกระบวนการเรนเดอร์ ดูที่ [Getting Warning Callbacks for Font Substitution](/slides/th/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่แบบอักษร ดูบทความ [Font Substitution](/slides/th/python-java/font-substitution/)
{{% /alert %}}

## **แปลงสไลด์ที่เลือกใน PowerPoint เป็น PDF**

หมายเลขสไลด์ที่ส่งให้ [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) จะเริ่มจาก 1 ตัวอย่างนี้ส่งออกสไลด์ที่ 1 และ 3 เมื่อทั้งสองมีอยู่:

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

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่กำหนดเอง**

ตัวอย่างนี้ส่งออกสไลด์แรกบนหน้าที่มีขนาด 612 × 792 จุด (US Letter) และทำสำเนาสไลด์นั้นไปยังงานนำเสนอใหม่ที่กำหนดขนาดตามที่ต้องการ:

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

โค้ดนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF ที่รวมบันทึกย่อด้วย:

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

## **มาตรฐานการเข้าถึงและการปฏิบัติตามสำหรับ PDF**

เมื่อจัดทำ PDF ที่เข้าถึงได้ ให้ดู [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ใช้ [PdfOptions.setCompliance](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#setCompliance) เพื่อเลือกมาตรฐานผลลัพธ์: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

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

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA Aspose.Slides จะถือกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิ และสูตรเป็นรูปเดียว ส่วนองค์ประกอบเส้นทางแต่ละส่วนจะไม่ถูกเก็บเป็นเนื้อหาแยกและอาจถูกมาร์คเป็น artifacts; ข้อความแทนที่จะมีเฉพาะสำหรับรูปทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF เป็นกลุ่มได้หรือไม่?**

ได้, Aspose.Slides รองรับการแปลงเป็นกลุ่มของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนรอบไฟล์ของคุณและเรียกใช้กระบวนการแปลงโดยอัตโนมัติ

**สามารถตั้งรหัสผ่านให้ PDF ที่แปลงแล้วได้หรือไม่?**

ได้ ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/) เพื่อตั้งรหัสผ่านและกำหนดสิทธิ์การเข้าถึงในระหว่างกระบวนการแปลง

**จะใส่สไลด์ที่ซ่อนอยู่ใน PDF ได้อย่างไร?**

ใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/) เพื่อใส่สไลด์ที่ซ่อนอยู่ใน PDF ที่ได้

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**

ได้ คุณสามารถควบคุมคุณภาพภาพโดยใช้เมธอดเช่น [setJpegQuality](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#setJpegQuality) และ [setSufficientResolution](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#setSufficientResolution) ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

**Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?**

ได้ Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่สอดคล้องกับ [various standards](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfcompliance/) รวมถึง PDF/A1a, PDF/A1b และ PDF/UA สำหรับการเข้าถึงหรือการเก็บถาวร เลือกมาตรฐานที่เหมาะสมและตรวจสอบผลลัพธ์ตามความต้องการของคุณ

## **แหล่งข้อมูลเพิ่มเติม**

- [Aspose.Slides for Python via Java Documentation](/slides/th/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/th/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/th/conversion)