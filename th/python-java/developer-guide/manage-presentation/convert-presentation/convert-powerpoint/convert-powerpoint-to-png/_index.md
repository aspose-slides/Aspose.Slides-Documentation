---
title: แปลงสไลด์ PowerPoint เป็น PNG ใน Python
linktitle: PowerPoint เป็น PNG
type: docs
weight: 30
url: /th/python-java/convert-powerpoint-to-png/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PNG
- งานนำเสนอเป็น PNG
- สไลด์เป็น PNG
- PPT เป็น PNG
- PPTX เป็น PNG
- บันทึก PPT เป็น PNG
- บันทึก PPTX เป็น PNG
- ส่งออก PPT เป็น PNG
- ส่งออก PPTX เป็น PNG
- Python
- Java
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint เป็นภาพ PNG ใน Python ผ่าน Java. ส่งออกงานนำเสนอ PPT, PPTX และ ODP ด้วยสเกลที่กำหนดเองหรือขนาดภาพที่แม่นยำ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงสไลด์การนำเสนอเป็นภาพ PNG โดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java คุณสามารถโหลดงานนำเสนอในรูปแบบต่าง ๆ เช่น PPT, PPTX และ ODP เรนเดอร์แต่ละสไลด์และบันทึกเป็นไฟล์ PNG แยกกัน

ตัวอย่างด้านล่างแสดงการเรนเดอร์ที่สเกลเริ่มต้น การเพิ่มสเกล การระบุขนาดผลลัพธ์เป็นพิกเซล และการเลือกสไตล์การเรนเดอร์แบบไล่สี

## **แปลง PowerPoint เป็น PNG**

โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) และเข้าถึงสไลด์ผ่านคอลเลกชัน [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) ตัวอย่างนี้เรนเดอร์ทุกสไลด์ด้วย [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) โดยไม่มีพารามิเตอร์เพื่อสร้างรูปย่อ จากนั้นเรียก [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) พร้อมกับ [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) เพื่อบันทึกสไลด์ที่เรนเดอร์แต่ละอันเป็นไฟล์ PNG

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
การเรียกใช้ [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) โดยไม่มีพารามิเตอร์จะเรนเดอร์ที่สเกล 0.2 ตัวอย่างเช่น สไลด์ขนาด 720 × 540 จุดจะให้รูปย่อขนาด 144 × 108 พิกเซล หากต้องการควบคุมขนาดผลลัพธ์ ให้ใช้การ overload ที่รับสเกลแฟกเตอร์หรือขนาดภาพอย่างชัดเจนตามที่แสดงด้านล่าง
{{% /alert %}}

## **แปลง PowerPoint เป็น PNG ด้วยมิติที่กำหนดเอง**

ส่งค่าสเกลแนวนอนและแนวตั้งไปยัง [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) เพื่อควบคุมขนาดที่เรนเดอร์ ในตัวอย่างนี้ทั้งสองค่ามีค่าเป็น 2 ดังนั้นสไลด์ขนาด 720 × 540 จุดจะให้ภาพ 1440 × 1080 พิกเซล ค่าสเกลที่เท่ากันจะรักษอัตราส่วนของสไลด์ไว้แต่ละภาพที่เรนเดอร์จะถูกบันทึกในรูปแบบ PNG

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **แปลง PowerPoint เป็น PNG ด้วยขนาดที่กำหนดเอง**

เพื่อระบุขนาดผลลัพธ์เป็นพิกเซล ให้ส่งขนาดไปยัง [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) แทนการใช้สเกลแฟกเตอร์ ตัวอย่างนี้เรนเดอร์ทุกสไลด์ที่ 960 × 720 พิกเซลและบันทึกผลลัพธ์ในรูปแบบ PNG เลือกขนาดที่สอดคล้องกับอัตราส่วนของสไลด์เพื่อหลีกเลี่ยงการยืดภาพ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **เลือกสไตล์การเรนเดอร์แบบไล่สี**

สมมติว่ามีสไลด์ที่มีการเติมสีไล่สี แต่การแปลงเป็น PNG แล้วสีไล่สีดูอ่อนลงหรือแตกต่างจากที่คุณเห็นใน PowerPoint คุณสามารถใช้เมธอด [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) ที่สืบทอดมาจาก [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/) เพื่อกำหนดวิธีการเรนเดอร์ไล่สี

ดาวน์โหลด [gradient-styles.pptx](gradient-styles.pptx) แล้ววางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกของไฟล์นี้มีไล่สีเชิงเส้นสองแบบ: จากสีฟ้าอมเขียวไปสีส้มที่ด้านบนและจากสีน้ำเงินไปสีเหลืองที่ด้านล่าง แต่ละไล่สีมีจุดหยุดสองจุดที่ 0% และ 100%

ตัวอย่างต่อไปนี้โหลดงานนำเสนอนี้และเรนเดอร์สไลด์แรกเดียวกันในสองโหมดด้วย [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

| Default | PowerPointUI |
| --- | --- |
| ![ไล่สีจากสีฟ้าอมเขียวไปสีส้มและจากสีน้ำเงินไปสีเหลืองที่เรนเดอร์ด้วย Default](gradient-Default.png) | ![ไล่สีเดียวกันที่เรนเดอร์ด้วย PowerPointUI](gradient-PowerPointUI.png) |

ในตัวอย่างนี้ `Default` จะให้สีกลางที่อ่อนกว่าในขณะที่ `PowerPointUI` ให้สีกลางที่เข้มกว่า ความแตกต่างขึ้นอยู่กับสีและจุดหยุดในไล่สี

เลือก `Default` เมื่อผลลัพธ์มาตรฐานของ Aspose.Slides ตอบสนองความต้องการของคุณ ลอง `PowerPointUI` เมื่อคุณต้องการให้ผลลัพธ์ตรงกับลักษณะใน PowerPoint เปรียบเทียบผลลัพธ์ทั้งสองกับผลลัพธ์ที่คุณต้องการ; ไม่มีโหมดใดที่ดีกว่าตลอดเวลา

## **คำถามที่พบบ่อย**

**ฉันจะส่งออกรูปทรงเฉพาะ เช่น แผนภูมิหรือรูปภาพ แทนการส่งออกสไลด์ทั้งหมดได้อย่างไร?**

Aspose.Slides รองรับ [การสร้างรูปย่อสำหรับรูปทรงแต่ละตัว](/slides/th/python-java/create-shape-thumbnails/), ซึ่งช่วยให้คุณเรนเดอร์รูปทรงเป็นภาพ PNG

**การแปลงแบบขนานได้รับการสนับสนุนบนเซิร์ฟเวอร์หรือไม่?**

ใช่ ใช้อินสแตนซ์งานนำเสนอแยกกันสำหรับแต่ละเธรดหรือโพรเซส; [ห้ามแชร์อินสแตนซ์เดียวกันข้ามเธรด](/slides/th/python-java/multithreading/)

**ข้อจำกัดของรุ่นประเมินค่าเมื่อส่งออกเป็น PNG มีอะไรบ้าง?**

โหมดประเมินค่าจะเพิ่มลายน้ำในภาพผลลัพธ์และใช้ [ข้อจำกัดอื่น ๆ](/slides/th/python-java/licensing/) จนกว่าจะมีการใช้ใบอนุญาต