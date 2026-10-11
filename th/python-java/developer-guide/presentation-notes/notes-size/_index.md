---
title: เปลี่ยนขนาดและแนวหน้าบันทึกใน Python ผ่าน Java
linktitle: ขนาดหน้าบันทึก
type: docs
weight: 10
url: /th/python-java/notes-size/
keywords:
- ขนาดหน้าบันทึก
- แนวบันทึก
- บันทึกแนวนอน
- บันทึกแนวตั้ง
- ขนาดเอกสารสรุป
- PowerPoint
- การนำเสนอ
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "อ่านและเปลี่ยนขนาดหน้าบันทึกใน Aspose.Slides สำหรับ Python ผ่าน Java, สลับแนว, ตรวจสอบขนาดที่บันทึก, และส่งออกบันทึกหรือเอกสารสรุปเป็น PDF และรูปภาพ."
---
## **ภาพรวม**

ใช้ [Presentation.getNotesSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getNotesSize) เพื่อเข้าถึงการตั้งค่าหน้าจำหมายของการนำเสนอ มันจะคืนค่าอ็อบเจ็กต์ [NotesSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/notessize/) ที่มีเมธอด [setSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/notessize/#setSize) เพื่อกำหนดขนาดหน้ากระดาษ แม้ว่าจะไม่สามารถเปลี่ยนอ็อบเจ็กต์การตั้งค่าได้โดยตรง คุณสามารถกำหนดขนาดใหม่ผ่านเมธอดนี้ได้

ความกว้างและความสูงระบุเป็น **จุด** โดยมี 72 จุดต่อหนึ่งนิ้ว ตัวอย่างเช่น 900 × 600 จุด เท่ากับ 12.5 × 8⅓ นิ้ว การตั้งค่าเหล่านี้ใช้กับการนำเสนอทั้งหมด ไม่ใช่กับหน้าจำหมายของสไลด์แต่ละหน้า

| การตั้งค่า | วัตถุประสงค์ |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getNotesSize) | ควบคุมขนาดหน้าจำหมายและขนาดหน้าที่ใช้ในการส่งออกเอกสารสรุป |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlideSize) | ควบคุมขนาดสไลด์ปกติของการนำเสนอผ่าน [SlideSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesize/) |

การเปลี่ยนการตั้งค่าใด ๆ จะไม่ทำให้การตั้งค่าอื่นเปลี่ยนโดยอัตโนมัติ การเปลี่ยนแนวหน้าจำหมายก็ไม่ทำให้สไลด์ปกติหมุน ให้ดูที่ [Slide Size](/slides/th/python-java/slide-size/) เพื่อปรับขนาดสไลด์ปกติ

ตัวอย่างด้านล่างใช้ไฟล์ `sample.pptx` ที่มีอยู่แล้ว สำหรับตัวอย่างการส่งออก ให้ใช้การนำเสนอที่มีสไลด์อย่างน้อยหนึ่งสไลด์ที่มีบันทึกคำพูด ตัวอย่างแต่ละตัวสามารถรันแยกกันได้

## **อ่านขนาดและแนวหน้าจำหมาย**

อ่านค่าความกว้างและความสูงแล้วเปรียบเทียบเพื่อกำหนณแนว: หน้ากว้างกว่าความสูงคือแนวนอน, สูงกว่าความกว้างคือแนวตั้ง, ความกว้างเท่ากันคือหน้ากระดาษสี่เหลี่ยม ตัวอย่างนี้พิมพ์ขนาดจริงเป็นจุดโดยไม่อิงขนาดกระดาษมาตรฐาน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **สลับเป็นแนวนอนโดยไม่เปลี่ยนขนาดกระดาษ**

เพื่อเปลี่ยนเฉพาะแนว ให้สลับค่าความกว้างและความสูงที่มีอยู่ ซึ่งจะรักษาความยาวของทั้งสองด้านรวมถึงขนาดกระดาษที่กำหนดเอง เงื่อนไขด้านล่างป้องกันไม่ให้หน้าที่เป็นแนวนอนถูกสลับกลับเป็นแนวตั้งและไม่กระทบหน้ากระดาษสี่เหลี่ยม

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

สำหรับแนวตั้ง ให้ใช้การกำหนดค่าเดียวกันเมื่อ `size.getWidth() > size.getHeight()` อย่าแทนค่าขนาด A4 หรือ Letter เว้นแต่คุณต้องการเปลี่ยนขนาดกระดาษด้วย

## **กำหนดและตรวจสอบขนาดหน้าจำหมายที่กำหนดเอง**

กำหนดขนาดทั้งสองด้านพร้อมกัน แล้วใช้ [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) เพื่อบันทึกการนำเสนอ ตัวอย่างนี้ตั้งค่าหน้าแนวนอน 900 × 600 จุด บันทึกเป็น PPTX แล้วเปิดไฟล์ที่บันทึกใหม่เพื่อตรวจสอบค่าที่บันทึกไว้ การเปรียบเทียบยอมรับความคลาดเคลื่อน 0.01 จุดสำหรับค่าทศนิยม; ไม่ได้เป็นการรับประกันความแม่นยำสำหรับทุกรูปแบบไฟล์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

ผลลัพธ์ที่คาดหวังคือ `900.0 x 600.0 points` และ `Size preserved: True` การตรวจสอบการนำเสนอที่เปิดใหม่ยืนยันไฟล์ที่บันทึก แทนการตรวจสอบเฉพาะค่าที่อยู่ในหน่วยความจำ

## **ส่งออกบันทึกและเอกสารสรุป**

ขนาดหน้าเป็นตัวกำหนดพื้นที่ที่ใช้สำหรับเลย์เอาต์บันทึกหรือเอกสารสรุป ไม่ได้ทำให้เลย์เอาต์เหล่านั้นทำงานโดยอัตโนมัติ: ต้องกำหนดตัวเลือกการส่งออกด้วยเช่นกัน การส่งออกสไลด์ปกติยังคงใช้ขนาดสไลด์ของการนำเสนอ

### **ส่งออกบันทึกเป็น PDF และ PNG**

กำหนด [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/) ให้กับ [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) เพื่อรวมบันทึกใน PDF ตัวอย่างนี้ยังแสดงสไลด์แรกที่มีบันทึกเป็น PNG โดยใช้ [Slide.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) และ [RenderingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/renderingoptions/)

โหมด [BottomTruncated](https://reference.aspose.com/slides/th/python-java/aspose.slides/notespositions/) จะเก็บบันทึกไว้บนหน้าเดียว; บันทึกที่ไม่พอดีจะถูกตัด PDF ใช้หน้าขนาด 900 × 600 จุด ที่สเกลภาพ 1 × 1 ตามตัวอย่างด้านล่าง PNG มีขนาด 900 × 600 พิกเซล จุดบรรยายเรขาคณิตของหน้า; พิกเซลบรรยายผลลัพธ์แบบแรสเตอร์ ซึ่งขนาดพิกเซลขึ้นอยู่กับสเกลการเรนเดอร์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

สำหรับการส่งออก PDF ที่มีบันทึกยาว, [BottomFull](https://reference.aspose.com/slides/th/python-java/aspose.slides/notespositions/) จะอนุญาตให้เพิ่มหน้าได้ตามต้องการ อย่าใช้โหมดนั้นกับการเรียกภาพสไลด์เดี่ยวด้านบน เนื่องจากไม่รองรับ หลังปรับขนาด ตรวจสอบผลลัพธ์ว่ามีบันทึกถูกตัดหรือไม่และตำแหน่งของวัตถุ notes‑master ที่มีอยู่; การเปลี่ยนขนาดหน้าโดยเดียวอาจไม่รับประกันว่าทุกเนื้อหาจะพอดี ดูเพิ่มเติมที่ [Convert PowerPoint to PDF with Notes](/slides/th/python-java/convert-powerpoint-to-pdf-with-notes/) สำหรับข้อมูลการส่งออกบันทึก

### **ส่งออกเอกสารสรุปเป็น PDF**

ใช้ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/handoutlayoutingoptions/) เพื่อแสดงรูปย่อของหลายสไลด์บนหนึ่งหน้า ตัวอย่างต่อไปนี้ตั้งค่าหน้า 900 × 600 จุดและใช้ [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/th/python-java/aspose.slides/handouttype/) เพื่อจัดสไลด์สูงสุดสี่สไลด์ต่อหน้า พรีเซ็ตแนวนอนควบคุมลำดับสไลด์; แนวหน้ามาจากความกว้างและความสูงของหน้า

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

การเปลี่ยนขนาดหน้าจะเปลี่ยนพื้นที่ที่ใช้สำหรับตารางเอกสารสรุปโดยไม่กระทบขนาดสไลด์ต้นฉบับ สำหรับภาพเอกสารสรุป ให้ใช้ [Presentation.getImages](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getImages) พร้อมเลย์เอาต์เอกสารสรุป แทนการใช้เมธอดภาพของสไลด์เดี่ยว ใน Aspose.Slides การเรนเดอร์เอกสารสรุประดับการนำเสนอใช้ขนาดหน้าจดหมาย ในขณะเดียวกันการเรียกภาพสไลด์เดี่ยวยังไม่สร้างหน้าสรุป ดูที่ [Handout Mode](/slides/th/python-java/convert-powerpoint-in-handout-mode/) สำหรับตัวเลือกเลย์เอาต์

## **ขนาดหน้าในตัวดู, การส่งออก, และการพิมพ์**

แยกเก็บขนาดการนำเสนอที่บันทึก, ขนาดหน้าที่ส่งออก, และขนาดกระดาษที่พิมพ์ไว้ต่างหาก:

- **ตัวดูการนำเสนอ:** ตัวดูสามารถแสดงหรือพิมพ์บันทึกโดยใช้กฎเลย์เอาต์ของตัวเอง หากแอปพลิเคชันอื่นบันทึกไฟล์ ให้เปิดไฟล์นั้นใหม่และตรวจสอบขนาดอีกครั้ง; การแปลงรูปแบบของแอปนั้นอาจทำให้ค่ามาตรฐานได้
- **รูปแบบการส่งออก:** ตัวอย่าง PDF ของบันทึกและเอกสารสรุปข้างต้นใช้ขนาดหน้าที่กำหนดไว้ ภาพแรสเตอร์ใช้ขนาดพิกเซลเป็นจำนวนเต็มและสเกลการเรนเดอร์ ดังนั้นค่าจุดเศษส่วนอาจถูกปัดเป็นจำนวนเต็มในผลลัพธ์ภาพ การส่งออกสไลด์ปกติจะไม่ใช้ขนาดหน้าจดหมาย
- **ไดรเวอร์เครื่องพิมพ์:** การเลือกกระดาษ, การหมุนอัตโนมัติ, และการตั้งค่าให้พอดีกับหน้าอาจเปลี่ยนผลลัพธ์จริงโดยไม่เปลี่ยนขนาดที่บันทึกในไฟล์การนำเสนอหรือ PDF สำหรับขนาดกระดาษเฉพาะ ให้ตั้งค่าเครื่องพิมพ์ให้ตรงกันและตรวจสอบตัวอย่างพิมพ์

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งค่าขนาดบันทึกเฉพาะสไลด์เดียวได้หรือไม่?**

ขนาดหน้าบันทึกเป็นการตั้งค่าระดับการนำเสนอ สไลด์แต่ละหน่วยสามารถมีเนื้อหาบันทึกที่ต่างกันได้ แต่คุณสมบัตินี้ไม่ให้ขนาดหน้าที่แยกกันสำหรับแต่ละสไลด์

**ทำไมการเปลี่ยนแนวหน้าบันทึกจึงไม่ทำให้สไลด์ของฉันเปลี่ยน?**

หน้าบันทึกและสไลด์ปกติมีขนาดอิสระกัน ใช้การตั้งค่าขนาดสไลด์ปกติเมื่อคุณต้องการปรับขนาดสไลด์เอง

**ผลลัพธ์ที่บันทึกหรือพิมพ์ออกมามีขนาดต่างกันทำไม?**

ให้เปิดการนำเสนอที่บันทึกไว้ใหม่แล้วเปรียบเทียบขนาดบันทึก หากมีการเปลี่ยนแปลง ให้ตรวจสอบว่าการบันทึกหรือแปลงไฟล์ในแอปพลิเคชันอื่นทำให้การตั้งค่าหน้าถูกเปลี่ยนหรือไม่ หากไม่เปลี่ยน ให้ตรวจสอบเลย์เอาต์การส่งออก, สเกลภาพ, การตั้งค่าตัวดู, และการเลือกกระดาษของเครื่องพิมพ์