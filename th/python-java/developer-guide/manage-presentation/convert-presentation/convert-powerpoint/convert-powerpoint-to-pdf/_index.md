---
title: แปลง PPT และ PPTX เป็น PDF ใน Python ผ่าน Java [รวมฟีเจอร์ขั้นสูง]
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
description: "แปลง PowerPoint PPT/PPTX เป็น PDF ที่มีคุณภาพสูงและสามารถค้นหาได้ใน Python ผ่าน Java ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดที่รวดเร็วและตัวเลือกการแปลงขั้นสูง."
---
## **ภาพรวม**

การแปลงการนำเสนอ PowerPoint (PPT, PPTX, ODP เป็นต้น) เป็นรูปแบบ PDF ใน Python ผ่าน Java มีข้อได้เปรียบหลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่างๆ และการรักษาโครงสร้างและรูปแบบของการนำเสนอ คู่มือนี้จะแสดงวิธีแปลงการนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่างๆ เพื่อควบคุมคุณภาพรูปภาพ รวมถึงสไลด์ที่ซ่อนอยู่ ปกป้องไฟล์ PDF ด้วยรหัสผ่าน ตรวจจับการทดแทนฟอนต์ เลือกสไลด์เฉพาะสำหรับการแปลง และใช้มาตรฐานการปฏิบัติตามในเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

ด้วย Aspose.Slides คุณสามารถแปลงการนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงการนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ไปยังคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) แล้วบันทึกการนำเสนอเป็น PDF โดยใช้เมธอด [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) คลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) เปิดเผยเมธอด [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) ซึ่งโดยทั่วไปใช้เพื่อแปลงการนำเสนอเป็น PDF

{{% alert color="info" title="หมายเหตุ" %}}
Aspose.Slides for Python via Java จะใส่ข้อมูล API และหมายเลขรุ่นลงในเอกสารผลลัพธ์ ตัวอย่างเช่นเมื่อแปลงการนำเสนอเป็น PDF Aspose.Slides จะเติมฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่าที่มีรูปแบบ "*Aspose.Slides v XX.XX*". **หมายเหตุ** คุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้.
{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* การนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากการนำเสนอเป็น PDF

Aspose.Slides ส่งออกการนำเสนอเป็น PDF โดยทำให้ PDF ที่ได้ตรงกับการนำเสนอเดิมอย่างใกล้ชิด ส่วนประกอบและแอตทริบิวต์จะถูกเรนเดอร์อย่างแม่นยำในการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ลิงก์
* ส่วนหัวและส่วนท้าย
* จุดหัวข้อ
* ตาราง

## **แปลง PowerPoint เป็น PDF**

การแปลงมาตรฐานใช้การตั้งค่าเริ่มต้นของการส่งออก PDF ใช้ตัวเลือกแบบกำหนดเองเมื่อคุณต้องการควบคุมคุณภาพรูปภาพ เนื้อหาหน้า หรือการปฏิบัติตามมาตรฐาน PDF

ติดตั้ง [Aspose.Slides for Python via Java](/slides/th/python-java/installation/) และ Java runtime ที่เข้ากันได้ก่อนเรียกใช้ตัวอย่าง แต่ละตัวอย่างจะอ่านไฟล์ `presentation.pptx` จากไดเรกทอรีทำงานปัจจุบัน; แทนที่ด้วยไฟล์ PPT, PPTX หรือ ODP ของคุณ เริ่ม JVM หนึ่งครั้งต่อกระบวนการ Python

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

{{% alert color="info" title="หมายเหตุ" %}}
Aspose มีตัวแปลงออนไลน์ฟรี [**ตัวแปลง PowerPoint เป็น PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ที่แสดงกระบวนการแปลงการนำเสนอเป็น PDF คุณสามารถทดสอบด้วยตัวแปลงนี้เพื่อดูการทำงานจริงของขั้นตอนที่อธิบายไว้ที่นี่.
{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides มีตัวเลือกแบบกำหนดเอง—คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)—ที่ให้คุณปรับแต่ง PDF ที่ได้ ล็อก PDF ด้วยรหัสผ่าน หรือระบุวิธีที่กระบวนการแปลงควรดำเนินต่อไป

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกแบบกำหนดเอง**

โดยใช้ตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ ระบุวิธีการจัดการเมตาฟาไฟล์ ตั้งค่าระดับการบีบอัดสำหรับข้อความ กำหนดค่า DPI สำหรับภาพ และอื่นๆ

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF 1.5 โดยตั้งค่าคุณภาพ JPEG เป็น 90 ความละเอียดภาพเป็น 300 DPI เมตาฟาไฟล์บันทึกเป็น PNG และการบีบอัดข้อความแบบ Flate

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

หากการนำเสนอมีเวิร์กบุ๊ก Excel ที่ฝังอยู่ คุณอาจต้องการให้ผู้รับ PDF เข้าถึงข้อมูลของเวิร์กบุ๊กพร้อมกับดูสไลด์ เรียกใช้เมธอด [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) พร้อมค่า `True` เพื่อรักษาไฟล์ OLE ที่ฝังไว้เป็นไฟล์แนบใน PDF ที่ได้

ค่าเริ่มต้นคือ `False`: รูปภาพหรือไอคอนพรีวิวของอ็อบเจ็กต์ OLE จะถูกเรนเดอร์บนหน้า PDF แต่ไฟล์ที่ฝังไว้จะไม่ถูกแนบเป็นไฟล์แนบ การตั้งค่าตัวเลือกเป็น `True` จะเพิ่มการแนบข้อมูลไฟล์ พรีวิวยังคงเป็นการแสดงภาพ; ไฟล์แนบทำให้ผู้รับสามารถเปิดหรือบันทึกไฟล์ที่ฝังไว้แยกจากกัน อ็อบเจ็กต์ OLE จะไม่กลายเป็นแผ่นงาน Excel แบบโต้ตอบบนหน้า PDF

ตัวอย่างต่อไปนี้โหลดการนำเสนอที่มีเวิร์กบุ๊ก Excel ที่ฝังอยู่แล้วและส่งออกเป็น PDF พร้อมแนบเวิร์กบุ๊ก

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
2. เปิดแผง **Attachments** ของโปรแกรมดูและค้นหาเวิร์กบุ๊กที่ฝังไว้.
3. บันทึกไฟล์แนบและเปิดใน Excel เพื่อตรวจสอบข้อมูล หรเปิดโดยตรงหากโปรแกรมดูอนุญาต พรีวิวบนหน้า PDF แยกจากไฟล์แนบ.

{{% alert color="info" title="หมายเหตุ" %}}
มาตรฐาน PDF/A กำหนดข้อจำกัดของไฟล์แนบ: PDF/A-1 ห้ามไฟล์ที่ฝังอยู่, PDF/A-2 อนุญาตเฉพาะไฟล์แนบ PDF/A, และ PDF/A-3 อนุญาตประเภทไฟล์อื่น รวมถึงเวิร์กบุ๊ก Excel นี่เป็นข้อกำหนดของมาตรฐาน ไม่ใช่ข้อจำกัดของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF เริ่มต้นและไม่ได้สาธิตการส่งออกเป็น PDF/A.
{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากการนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) จากคลาส [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนเป็นหน้าใน PDF ที่ได้

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF โดยรวมสไลด์ที่ซ่อนอยู่ทั้งหมด

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

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF ที่ต้องใช้รหัสผ่าน `password` เพื่อเปิด การอนุญาตการเข้าถึงอนุญาตให้พิมพ์ รวมถึงการพิมพ์คุณภาพสูง

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

### **ตรวจจับการทดแทนฟอนต์**

Aspose.Slides มีเมธอด [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) ใต้คลาส [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) ที่ทำให้คุณสามารถตรวจจับการทดแทนฟอนต์ระหว่างกระบวนการแปลงการนำเสนอเป็น PDF

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF และพิมพ์คำเตือนการทดแทนฟอนต์ไปที่คอนโซล คำเตือนจะถูกพิมพ์เฉ็ตเมื่อฟอนต์ที่ไม่พร้อมใช้งานถูกทดแทนระหว่างการส่งออก ใช้พร็อกซี JPype เพื่อรับการเรียกคืนคำเตือนจาก Java API แปลงสตริงคำอธิบายของ Java เป็นสตริง Python ก่อนตรวจสอบคำนำหน้า:

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

{{% alert color="info" title="หมายเหตุ" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการทดแทนฟอนต์ ดูบทความ [การทดแทนฟอนต์](/slides/th/python-java/font-substitution/)
{{% /alert %}}

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

หมายเลขสไลด์ที่ส่งให้กับเมธอด [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) นับจาก 1 ตัวอย่างนี้จะส่งออกสไลด์ที่ 1 และ 3 หากทั้งสองมีอยู่:

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

ตัวอย่างนี้ส่งออกสไลด์แรกบนหน้าที่มีขนาด 612 x 792 พอยต์ (US Letter) โดยทำการโคลนสไลด์ไปยังการนำเสนอใหม่ที่กำหนดขนาดดังกล่าวและปรับสเกลเนื้อหาสไลด์ให้พอดี

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

    # ลบสไลด์เปล่าที่สร้างขึ้นมาพร้อมการนำเสนอใหม่.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **แปลง PowerPoint เป็น PDF ในมุมมองโน้ตสไลด์**

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF โดยวางโน้ตผู้พูดของแต่ละสไลด์ด้านล่างสไลด์ ใช้การนำเสนอที่มีโน้ตผู้พูดเพื่อดูผลลัพธ์

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

เมื่อต้องการเตรียม PDF ที่เข้าถึงได้ ให้อ้างอิง [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ใช้เมธอด [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) เพื่อเลือกมาตรฐานผลลัพธ์: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**.

โค้ดนี้สาธิตกระบวนการแปลง PowerPoint เป็น PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามที่ต่างกัน:

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

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะจัดการกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิและสูตรเป็นรูปเดียว 요소ทางเส้นเดี่ยวจะไม่ถูกรักษาเป็นเนื้อหาแยกและอาจถูกระบุเป็นสิ่งที่ไม่ต้องการ; ข้อความแทนที่จะให้เฉพาะสำหรับรูปทั้งหมดเท่านั้น.

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงไฟล์ PowerPoint จำนวนหลายไฟล์เป็น PDF พร้อมกันได้หรือไม่?**

ใช่, Aspose.Slides รองรับการแปลงเป็นชุดของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนผ่านไฟล์ของคุณและเรียกใช้กระบวนการแปลงโดยอัตโนมัติ

**สามารถป้องกันรหัสผ่านให้กับ PDF ที่แปลงแล้วได้หรือไม่?**

ใช่ ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) เพื่อตั้งรหัสผ่านและกำหนดการอนุญาตการเข้าถึงระหว่างกระบวนการแปลง

**ฉันจะรวมสไลด์ที่ซ่อนอยู่ใน PDF อย่างไร?**

เรียกใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) พร้อมค่า `True` ในคลาส [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่ได้

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**

ใช่ คุณสามารถควบคุมคุณภาพภาพโดยใช้เมธอดเช่น [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) และ [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) ในคลาส [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

**Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?**

ใช่, Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่ปฏิบัติตามมาตรฐานต่างๆ [เช่นนี้](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/) รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA เพื่อการเข้าถึงหรือการเก็บถาวร เลือกมาตรฐานที่เหมาะสมและตรวจสอบผลลัพธ์ตามความต้องการของคุณ

## **แหล่งข้อมูลเพิ่มเติม**

- [เอกสาร Aspose.Slides for Python via Java](/slides/th/python-java/)
- [อ้างอิง API Aspose.Slides for Python via Java](https://reference.aspose.com/slides/python-java/)
- [ตัวแปลงออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/conversion)