---
title: แปลง PPT และ PPTX เป็น JPG ใน Python
linktitle: PowerPoint เป็น JPG
type: docs
weight: 60
url: /th/python-java/convert-powerpoint-to-jpg/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- PowerPoint เป็น JPG
- PPT เป็น JPG
- PPTX เป็น JPG
- บันทึกสไลด์เป็น JPG
- ส่งออก PPT เป็น JPG
- ส่งออก PPTX เป็น JPG
- Python
- Java
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint (PPT, PPTX) เป็นภาพ JPG ใน Python ผ่าน Java. กำหนดขนาดภาพที่กำหนดเองและเรนเดอร์โน้ตและคอมเมนต์ด้วย Aspose.Slides."
---
## **บทนำ**

Aspose.Slides for Python via Java ช่วยให้คุณแปลงงานนำเสนอ PowerPoint และ OpenDocument (PPT, PPTX, และ ODP) เป็นภาพ JPEG คุณสามารถส่งออกทุกสไลด์หรือสไลด์ที่เลือกเพื่อสร้างภาพย่อลง, สร้างตัวดูงานนำเสนอ, หรือฝังภาพพรีวิวสไลด์ในเว็บไซต์หรือแอปพลิเคชันได้

## **แปลง PowerPoint PPT/PPTX ไปเป็น JPG**

1. โหลดงานนำเสนอด้วย [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/).
2. ดึงสไลด์โดยใช้ [getSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlides).
3. เรียก [Slide.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) ด้วยปัจจัยสเกลแนวนอนและแนวตั้งเพื่อเรนเดอร์แต่ละสไลด์.
4. บันทึกแต่ละภาพที่เรนเดอร์เป็น JPEG โดยใช้ [ImageFormat.Jpeg](https://reference.aspose.com/slides/th/python-java/aspose.slides/imageformat/#Jpeg), จากนั้นปล่อยทรัพยากรภาพ.

{{% alert color="info" title="หมายเหตุ" %}}
การส่งออกเป็น JPG จะสร้างภาพแยกสำหรับแต่ละสไลด์ บันทึกภาพที่เรนเดอร์แทนการบันทึกงานนำเสนอโดยตรงเป็นรูปแบบภาพ
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **แปลง PowerPoint PPT/PPTX ไปเป็น JPG พร้อมขนาดที่กำหนดเอง**

คำนวณปัจจัยสเกลแนวนอนและแนวตั้งจากมิติพิกเซลที่ต้องการและขนาดสไลด์เดิม, จากนั้นส่งค่าเหล่านี้ไปยัง [Slide.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage). ตัวอย่างต่อไปนี้ตั้งค่าภาพ 1200 × 800 สำหรับแต่ละสไลด์.

การใช้ปัจจัยสเกลที่ต่างกันอาจทำให้สไลด์บิดและยืด หากต้องการรักษาอัตราส่วนภาพ ให้ใช้ปัจจัยสเกลเดียวกันสำหรับทั้งสองแกน; ความกว้างและความสูงที่ได้จะสอดคล้องกับสัดส่วนเดิมของสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **เรนเดอร์คอมเมนต์เมื่อบันทึกสไลด์เป็นภาพ**

ใช้ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/) เพื่อกำหนดค่าโน้ตและคอมเมนต์, และใช้การจัดวางผ่าน [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions). ตัวอย่างนี้วางโน้ตไว้ที่ด้านล่าง, ตัดโน้ตที่ไม่พอดี, และแสดงคอมเมนต์ที่ด้านขวาในพื้นที่กว้าง 200 พิกเซล. มันบันทึกแต่ละสไลด์ที่เรนเดอร์เป็นภาพ JPG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงหลายสไลด์หรือหลายงานนำเสนอเป็น JPG ได้หรือไม่?**  
ได้ ตัวอย่างจะวนลูปผ่านสไลด์ทั้งหมดและบันทึก JPG หนึ่งไฟล์ต่อสไลด์ เพื่อประมวลผลหลายงานนำเสนอ ให้ทำการแปลงซ้ำสำหรับแต่ละไฟล์อินพุตและใช้โฟลเดอร์ผลลัพธ์แยกหรือชื่อไฟล์ที่ไม่ซ้ำกันเพื่อหลีกเลี่ยงการเขียนทับภาพ

**แผนภูมิ, SmartArt, ตาราง, และรูปร่างรวมอยู่ในภาพหรือไม่?**  
วัตถุเหล่านี้จะถูกเรนเดอร์เป็นส่วนหนึ่งของสไลด์ ให้ทำให้ฟอนต์ที่ใช้ในงานนำเสนอพร้อมใช้งานในสภาพแวดล้อมการแปลงเพื่อ ลดความแตกต่างที่เกิดจากการแทนที่ฟอนต์

**ฉันจะลดการใช้หน่วยความจำเมื่อส่งออกงานนำเสนอขนาดใหญ่ได้อย่างไร?**  
ประมวลผลภาพทีละภาพ, ปลดปล่อยแต่ละภาพหลังบันทึก, และหลีกเลี่ยงการตั้งขนาดผลลัพธ์ที่ใหญ่เกินความจำเป็น ความต้องการหน่วยความจำขึ้นอยู่กับเนื้อหาสไลด์และขนาดภาพ

## **ดูเพิ่มเติม**

- [แปลง PowerPoint ไปเป็น PNG](/slides/th/python-java/convert-powerpoint-to-png/).
- [เรนเดอร์สไลด์เป็นภาพ SVG](/slides/th/python-java/render-a-slide-as-an-svg-image/).