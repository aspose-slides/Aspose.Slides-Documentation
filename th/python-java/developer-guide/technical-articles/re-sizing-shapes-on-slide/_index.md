---
title: ปรับขนาดรูปทรงบนสไลด์การนำเสนอใน Python ผ่าน Java
type: docs
weight: 110
url: /th/python-java/re-sizing-shapes-on-slide/
keywords:
- ปรับขนาดรูปทรง
- เปลี่ยนขนาดรูปทรง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ปรับขนาดรูปทรงบนสไลด์ PowerPoint และ OpenDocument ได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ Python ผ่าน Java—อัตโนมัติการปรับเลเอาต์สไลด์และเพิ่มประสิทธิภาพการทำงาน."
---
## **ภาพรวม**

หนึ่งในคำถามที่พบบ่อยที่สุดจากลูกค้า Aspose.Slides for Python via Java คือวิธีการปรับขนาดรูปทรงเพื่อให้เมื่อขนาดสไลด์เปลี่ยนแปลง ข้อมูลไม่ถูกตัดออก บทความเทคนิคสั้นนี้จะแสดงวิธีทำเช่นนั้น

## **ปรับขนาดรูปทรง**

เพื่อป้องกันไม่ให้รูปทรงเลื่อนตำแหน่งเมื่อขนาดสไลด์เปลี่ยนแปลง ให้ปรับตำแหน่งและขนาดของแต่ละรูปทรงให้สอดคล้องกับเค้าโครงสไลด์ใหม่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# โหลดไฟล์การนำเสนอ.
presentation = Presentation("sample.ppt")
try:
    # รับขนาดสไลด์ดั้งเดิม.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # เปลี่ยนขนาดสไลด์โดยไม่สเกลรูปทรงที่มีอยู่.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # รับขนาดสไลด์ใหม่.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # ปรับขนาดและตำแหน่งใหม่ของรูปทรงบนแต่ละสไลด์.
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # สเกลขนาดรูปทรง.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # สเกลตำแหน่งรูปทรง.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="หมายเหตุ" %}} 
ตารางไม่ต้องการการจัดการพิเศษ: การตั้งค่าความกว้างและความสูงของตารางจะปรับสัดส่วนคอลัมน์และแถวโดยอัตโนมัติ ดังนั้นการปรับความสูงของแถวและความกว้างของคอลัมน์อีกครั้งจะทำให้สัดส่วนถูกนำไปใช้สองครั้ง
{{% /alert %}} 

โค้ดด้านบนจะเปลี่ยนเฉพาะรูปทรงบนสไลด์เท่านั้น สไลด์มาสเตอร์และสไลด์เลเอาต์จะมีรูปทรงของตนเอง ดังนั้นให้ปรับสเกลของมันด้วยเมื่อคุณต้องการให้การนำเสนอทั้งหมดตามขนาดสไลด์ใหม่:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # รับขนาดสไลด์ดั้งเดิม.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # เปลี่ยนขนาดสไลด์โดยไม่สเกลรูปทรงที่มีอยู่.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # รับขนาดสไลด์ใหม่.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # สเกลขนาดรูปทรง.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # สเกลตำแหน่งรูปทรง.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # สเกลขนาดรูปทรง.
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # สเกลตำแหน่งรูปทรง.
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # สเกลขนาดรูปทรง.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # สเกลตำแหน่งรูปทรง.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ทำไมรูปทรงจึงบิดเบี้ยวหรือถูกตัดออกหลังจากปรับขนาดสไลด์?**  
เมื่อทำการปรับขนาดสไลด์ รูปทรงจะคงตำแหน่งและขนาดเดิมไว้ เว้นแต่สเกลจะถูกเปลี่ยนแปลงโดยเจตนา ซึ่งอาจทำให้เนื้อหาถูกตัดออกหรือรูปทรงเลื่อนตำแหน่ง

**โค้ดที่ให้มาทำงานกับประเภทรูปทรงทั้งหมดหรือไม่?**  
ใช่ การกำหนดความสูงและความกว้างทำงานกับกล่องข้อความ รูปภาพ แผนภูมิ และตารางได้เช่นเดียวกัน

**ฉันจะแปรขนาดตารางเมื่อปรับขนาดสไลด์อย่างไร?**  
ปรับสเกลของรูปทรงตารางเองเช่นเดียวกับรูปทรงอื่น ๆ แถวและคอลัมน์จะปรับตามสัดส่วนโดยอัตโนมัติ ดังนั้นไม่ต้องปรับสเกลของพวกมันอีกครั้งหลังจากนั้น

**การปรับขนาดนี้จะทำงานกับสไลด์มาสเตอร์และสไลด์เลเอาต์หรือไม่?**  
ใช่ แต่คุณควรวนลูปผ่าน [Presentation.getMasters](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getMasters) และ [Presentation.getLayoutSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getLayoutSlides) และใช้ตรรกะการสเกลเดียวกันกับรูปทรงของพวกมันเพื่อให้แน่ใจว่าการนำเสนอทั้งหมดสอดคล้องกัน

**ฉันสามารถเปลี่ยนทิศทางของสไลด์ (แนวตั้ง/แนวนอน) พร้อมกับการปรับขนาดได้หรือไม่?**  
ใช่ คุณสามารถใช้ [SlideSize.setOrientation](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesize/#setOrientation) เพื่อเปลี่ยนทิศทางได้ อย่าลืมตั้งค่าตรรกะการสเกลให้สอดคล้องเพื่อรักษาเค้าโครง

**มีข้อจำกัดเรื่องขนาดสไลด์ที่ฉันตั้งค่าได้หรือไม่?**  
Aspose.Slides รองรับขนาดที่กำหนดเองได้ แต่ขนาดที่ใหญ่มากอาจส่งผลต่อประสิทธิภาพหรือความเข้ากันได้กับบางเวอร์ชันของ PowerPoint

**ฉันจะป้องกันไม่ให้รูปทรงที่ล็อครูปแบบอัตราส่วนคงที่บิดเบี้ยวได้อย่างไร?**  
คุณสามารถตรวจสอบเมธอด [getAspectRatioLocked](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) ของการล็อกรูปทรงก่อนทำการสเกล หากมันล็อกอยู่ ให้ปรับความกว้างหรือความสูงโดยอัตราส่วนเทียบกันแทนการสเกลแยกกัน