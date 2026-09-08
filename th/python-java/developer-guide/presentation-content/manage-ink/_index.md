---
title: จัดการวัตถุ Ink ของงานนำเสนอใน Python ผ่าน Java
linktitle: จัดการ Ink
type: docs
weight: 95
url: /th/python-java/manage-ink/
keywords:
- หมึก
- วัตถุหมึก
- ร่องหมึก
- จัดการหมึก
- วาดหมึก
- การวาด
- ส่งออกหมึก
- การเรนเดอร์หมึก
- ซ่อนหมึก
- InkOptions
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "จัดการวัตถุหมึกใน PowerPoint แก้ไขร่องและคุณสมบัติของแปรง, และควบคุมการแสดงผลของหมึกระหว่างการส่งออกเป็น PDF, HTML, SVG, TIFF และรูปภาพด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **คำนำ**

PowerPoint มีฟีเจอร์ Ink ที่ให้คุณวาดเส้นอิสระ Ink สามารถใช้เพื่อทำไฮไลท์วัตถุอื่น ๆ แสดงการเชื่อมต่อและกระบวนการ และดึงความสนใจไปยังรายการเฉพาะบนสไลด์

Aspose.Slides มีประเภทที่จำเป็นสำหรับทำงานกับวัตถุ Ink ตัวอย่างเช่นคลาส [Ink](https://reference.aspose.com/slides/th/python-java/aspose.slides/ink/) แทนวัตถุ Ink บนสไลด์

## **ความแตกต่างระหว่างอ็อบเจ็กต์ปกติและอ็อบเจ็กต์ Ink**

อ็อบเจ็กต์บนสไลด์ PowerPoint ส่วนใหญ่จะแสดงด้วยอ็อบเจ็กต์ shape ในรูปแบบที่ง่ายที่สุด shape คือคอนเทนเนอร์ที่กำหนดพื้นที่ของอ็อบเจ็กต์เอง (เฟรม) พร้อมคุณสมบัติต่าง ๆ เช่น ขนาดคอนเทนเนอร์ รูปร่าง และพื้นหลัง รายละเอียดเพิ่มเติมดูที่ [Shape Layout Format](/slides/th/python-java/shape-manipulations/#access-layout-formats-for-shape)

อย่างไรก็ตามเมื่อ PowerPoint จัดการกับวัตถุ Ink จะละเลยคุณสมบัติทั้งหมดของเฟรมอ็อบเจ็กต์ (คอนเทนเนอร์) ยกเว้นขนาดของมัน ขนาดของพื้นที่คอนเทนเนอร์กำหนดโดยเมธอดมาตรฐาน [Shape.getWidth](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getWidth) และ [Shape.getHeight](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **ร่อง Ink**

ร่อง Ink คือองค์ประกอบพื้นฐานที่ใช้บันทึกเส้นทางของปากกาเมื่อผู้ใช้เขียน Ink ดิจิทัล ร่องเก็บลำดับจุดที่ต่อเนื่องกัน

รูปแบบการเข้ารหัสที่ง่ายที่สุดระบุพิกัด X และ Y ของแต่ละจุดตัวอย่าง เมื่อจุดทั้งหมดที่ต่อกันถูกเรนเดอร์จะได้ภาพเช่นนี้:

![ink_powerpoint2](ink_powerpoint2.png)

## **คุณสมบัติ Brush สำหรับการวาด**

Brush ใช้วาดเส้นที่เชื่อมต่อจุดของร่อง Ink Brush มีสีและขนาดของตนเอง โดยใช้เมธอด [InkBrush.getColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/inkbrush/#getColor) และ [InkBrush.getSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/inkbrush/#getSize)

### **ตั้งค่าสี Brush ของ Ink**

ตัวอย่างโค้ด Python นี้แสดงวิธีตั้งค่าสีของ Brush Ink:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **ตั้งค่าขนาด Brush ของ Ink**

ตัวอย่างโค้ด Python นี้แสดงวิธีตั้งค่าขนาดของ Brush Ink:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

โดยทั่วไปความกว้างและความสูงของ Brush จะไม่เท่ากัน ดังนั้น PowerPoint จึงไม่แสดงขนาดของ Brush (ส่วนข้อมูลที่สอดคล้องจะสีเทา) เมื่อความกว้างและความสูงของ Brush เท่ากัน PowerPoint จะแสดงขนาดดังนี้:

![ink_powerpoint3](ink_powerpoint3.png)

เพื่อความชัดเจน เราจะเพิ่มความสูงของวัตถุ Ink และตรวจสอบมิติที่สำคัญ:

![ink_powerpoint4](ink_powerpoint4.png)

คอนเทนเนอร์ (เฟรม) ไม่คำนึงถึงขนาดของ Brush – มันจะสมมติว่าความหนาของเส้นเป็นศูนย์ (ดูรูปก่อนหน้า)

ดังนั้นเพื่อกำหนดพื้นที่ที่มองเห็นของวัตถุ Ink ทั้งหมด ต้องคำนึงถึงขนาด Brush ของร่องที่เกี่ยวข้อง ที่นี่วัตถุเป้าหมาย (ร่องข้อความที่เขียนด้วยมือ) ได้ถูกสเกลไปยังขนาดของคอนเทนเนอร์ (เฟรม) เมื่อขนาดของคอนเทนเนอร์เปลี่ยนแปลง Brush จะคงที่ และในทางกลับกัน

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint ใช้พฤติลักษณะเดียวกันสำหรับวัตถุข้อความ:

![ink_powerpoint6](ink_powerpoint6.png)

## **ควบคุมการแสดงผล Ink ระหว่างการส่งออกและการเรนเดอร์**

Aspose.Slides มีคลาส [InkOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/inkoptions/) เพื่อควบคุมวิธีการที่วัตถุ Ink ปรากฏในผลลัพธ์ที่ส่งออกหรือเรนเดอร์ คุณสามารถใช้คุณสมบัติต่าง ๆ เพื่อซ่อน Ink อย่างสมบูรณ์หรือเปลี่ยนวิธีการตีความการทำงานของ mask Brush Ink

ตัวเลือก Ink สามารถใช้ได้ผ่านตัวเลือกการส่งออกหรือการเรนเดอร์สำหรับหลายรูปแบบผลลัพธ์:

| Output | Ink options property |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/renderingoptions/#getInkOptions) |

เมธอด [InkOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/inkoptions/) ต่อไปนี้เปิดเผยการตั้งค่าสองอย่างเดียวกัน:

- [getHideInk](https://reference.aspose.com/slides/th/python-java/aspose.slides/inkoptions/#getHideInk) กำหนดว่าวัตถุ Ink จะรวมอยู่ในผลลัพธ์หรือไม่ ค่าเริ่มต้นคือ `False`
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/th/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) กำหนดว่าการดำเนินการ mask จะตีความเป็นความทึบแสงเมื่อเรนเดอร์ Brush Ink หรือไม่ ค่าเริ่มต้นคือ `True`; เรียก [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/th/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) กับ `False` เพื่อใช้การดำเนินการ ROP แทน

### **ซ่อนวัตถุ Ink ในผลลัพธ์ PDF**

โดยค่าเริ่มต้นวัตถุ Ink จะยังคงมองเห็นได้เมื่อส่งออก หากต้องการผลลัพธ์ที่สะอาดโดยไม่มีหมายเหตุเขียนด้วยมือหรือเนื้อหา Ink อื่น ๆ ให้เรียก [InkOptions.setHideInk](https://reference.aspose.com/slides/th/python-java/aspose.slides/inkoptions/#setHideInk) กับ `True`

ตัวอย่าง Python ด้านล่างส่งออกงานนำเสนอเป็น PDF พร้อมซ่อนวัตถุ Ink ทั้งหมด:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **ซ่อนวัตถุ Ink เมื่อเรนเดอร์สไลด์เป็นรูปภาพ**

เพื่อซ่อนวัตถุ Ink เมื่อเรนเดอร์สไลด์เป็นภาพบิตแมพ ให้กำหนดค่า [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/renderingoptions/#getInkOptions) และส่งตัวเลือกการเรนเดอร์ไปยัง [Slide.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage)

ตัวอย่าง Python ด้านล่างเรนเดอร์สไลด์แรกเป็นภาพ PNG โดยไม่มีวัตถุ Ink:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **ควบคุมการเรนเดอร์ Mask ของ Ink**

การตั้งค่า [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/th/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) ควบคุมวิธีการตีความการดำเนินการ mask เมื่อเรนเดอร์ Brush Ink ค่าเริ่มต้นคือ `True` (ใช้ความทึบแสง) หากต้องการใช้การดำเนินการ ROP ให้เรียก [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/th/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) กับ `False`

ตัวอย่าง Python ด้านล่างส่งออกสไลด์เป็น SVG และใช้การเรนเดอร์แบบ ROP สำหรับการดำเนินการ mask ของ Ink:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

การตั้งค่าเดียวกันสามารถใช้ผ่าน [TiffOptions.getInkOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/#getInkOptions) เมื่อส่งออกงานนำเสนอหรือเรนเดอร์สไลด์เป็น TIFF

### **เลือกว่าจะซ่อนหรือรักษา Ink**

เมื่อต้องการเวอร์ชันที่สะอาดของงานนำเสนอที่มีหมายเหตุสำหรับการกระจายโดยไม่มีเครื่องหมายตรวจสอบ ให้เรียก [InkOptions.setHideInk](https://reference.aspose.com/slides/th/python-java/aspose.slides/inkoptions/#setHideInk) กับ `True` ขณะส่งออก

ทิ้งให้ [InkOptions.getHideInk](https://reference.aspose.com/slides/th/python-java/aspose.slides/inkoptions/#getHideInk) มีค่าเริ่มต้นเป็น `False` เมื่อหมายเหตุ Ink เป็นส่วนหนึ่งของเนื้อหาที่ต้องการ เช่น ความคิดเห็นการตรวจสอบ โน้ตเขียนด้วยมือ ไฮไลท์ หรือการวาดที่ควรคงมองเห็นในผลลัพธ์ที่ส่งออก วิธีนี้ทำให้แอปพลิเคชันสร้างผลลัพธ์การตรวจสอบและผลลัพธ์ขั้นสุดท้ายแยกกันจากงานนำเสนอเดียวกันโดยไม่ต้องแก้ไขวัตถุ Ink ต้นฉบับ

## **คำถามที่พบบ่อย**

**ฉันสามารถเปลี่ยนสีหรือขนาดของเส้น Ink ที่มีอยู่ได้หรือไม่?**  
ได้ คุณสามารถเรียก [Ink.getTraces](https://reference.aspose.com/slides/th/python-java/aspose.slides/ink/#getTraces) เพื่อรับร่อง แล้วเปลี่ยน [InkTrace.getBrush](https://reference.aspose.com/slides/th/python-java/aspose.slides/inktrace/#getBrush) โดยเรียก [InkBrush.setColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/inkbrush/#setColor) หรือ [InkBrush.setSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/inkbrush/#setSize)

**การซ่อน Ink จะทำให้งานนำเสนอที่เป็นแหล่งข้อมูลเปลี่ยนแปลงหรือไม่?**  
ไม่ได้ การเรียก [InkOptions.setHideInk](https://reference.aspose.com/slides/th/python-java/aspose.slides/inkoptions/#setHideInk) มีผลเฉพาะกับผลลัพธ์ที่เรนเดอร์หรือส่งออก ไม่ได้ลบหรือแก้ไขวัตถุ Ink ในงานนำเสนอที่เป็นแหล่งข้อมูล

**รูปแบบการส่งออกใดบ้างที่รองรับ Ink options?**  
คุณสามารถกำหนด Ink options สำหรับ PDF, HTML, SVG, TIFF และรูปภาพสไลด์แบบบิตแมพผ่านตัวเลือกการส่งออกหรือการเรนเดอร์ที่แสดงข้างต้น

**อ่านต่อ**

* เพื่ออ่านเกี่ยวกับ shape โดยทั่วไป ดูส่วน [PowerPoint Shapes](/slides/th/python-java/powerpoint-shapes/)
* สำหรับข้อมูลเกี่ยวกับค่า Effective ดู [Shape Effective Properties](/slides/th/python-java/shape-effective-properties/#get-effective-font-height-value)
* รายละเอียดการส่งออก PDF ดู [Convert PPT and PPTX to PDF](/slides/th/python-java/convert-powerpoint-to-pdf/)
* รายละเอียดการส่งออก HTML ดู [Convert PowerPoint Presentations to HTML](/slides/th/python-java/convert-powerpoint-to-html/)
* รายละเอียดการส่งออก SVG ดู [Render Presentation Slides as SVG Images](/slides/th/python-java/render-a-slide-as-an-svg-image/)
* รายละเอียดการส่งออก TIFF ดู [Convert PowerPoint Presentations to TIFF](/slides/th/python-java/convert-powerpoint-to-tiff/)
* รายละเอียดการเรนเดอร์สไลด์เป็นภาพดู [Convert Presentation Slides to Images](/slides/th/python-java/convert-slide/)