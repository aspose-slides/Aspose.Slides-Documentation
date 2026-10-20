---
title: ปรับขนาดรูปทรงบนสไลด์การนำเสนอใน Python ผ่าน Java
type: docs
weight: 110
url: /th/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/re-sizing-shapes-on-slide/
  - /th/python-java/re-sizing-shapes-on-slide/
keywords:
  - ปรับขนาดรูปทรง
  - เปลี่ยนขนาดรูปทรง
  - PowerPoint
  - OpenDocument
  - งานนำเสนอ
  - Python
  - Java
  - Aspose.Slides
description: "ปรับขนาดรูปทรงบนสไลด์ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ Python ผ่าน Java—ทำงานปรับแต่งเลเอาต์สไลด์อัตโนมัติและเพิ่มประสิทธิภาพการทำงาน."
---
## **ภาพรวม**

เมื่อคุณเปลี่ยนขนาดสไลด์ของงานนำเสนอ คุณอาจต้องปรับขนาดและเปลี่ยนตำแหน่งรูปทรงให้พอดีกับมิติใหม่ บทความนี้แสดงวิธีปรับสเกลรูปทรงด้วยตนเองและวิธีจัดการตารางบนสไลด์ มาสเตอร์ และเลเอาต์

## **ปรับขนาดรูปทรง**

เพื่อรักษาตำแหน่งและขนาดสัมพัทธ์ของแต่ละรูปทรง ให้คูณพิกัดแนวนอนและความกว้างของรูปทรงด้วยอัตราส่วนของความกว้างสไลด์ใหม่ต่อความกว้างเดิม นำอัตราส่วนความสูงที่สอดคล้องไปคูณกับพิกัดแนวตั้งและความสูงของรูปทรง

ตัวอย่างแรกโหลดงานนำเสนอที่สไลด์ไม่มีตาราง เปลี่ยนขนาดสไลด์เป็น A4 และบันทึกผลลัพธ์ ใช้ [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) พร้อมกับ [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) เพื่อให้ลูปถัดไปควบคุมการสเกล อัตราส่วนไม่มีหน่วย; ตำแหน่งและขนาดของรูปทรงวัดเป็นจุด อัตราส่วนความกว้างและความสูงที่ต่างกันสามารถทำให้รูปทรงบิดเบี้ยว และการเปลี่ยนขนาดรูปทรงจะไม่สเกลขนาดฟอนต์ของมัน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # คำนวณปัจจัยสเกลแนวนอนและแนวตั้งอย่างอิสระ.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
ตารางต้องการการจัดการแยกต่างหาก: ปรับสเกลความกว้างของคอลัมน์และความสูงของแถวแทนการกำหนดความกว้างและความสูงรวมของตาราง ความสูงของแถวอาจยังคงใหญ่กว่าที่ร้องขอหากเนื้อหาในเซลล์ต้องการพื้นที่มากกว่า
{{% /alert %}}

ตัวอย่างที่สองรองรับตารางและประมวลผลรูปทรงบนมาสเตอร์และเลเอาต์รวมถึงสไลด์เดี่ยวก่อนบันทึกงานนำเสนอที่ปรับขนาด ตัวช่วยของมันจัดการแต่ละ [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) โดยปรับสเกลความกว้างของคอลัมน์ด้วย [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) และความสูงขั้นต่ำของแถวด้วย [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) จากนั้นปรับสเกลตำแหน่งของตารางโดยไม่แยกการสเกลมิติรวมของมัน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # มิติของตารางถูกควบคุมโดยความกว้างของคอลัมน์และความสูงของแถว.
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # คำนวณปัจจัยสเกลแนวนอนและแนวตั้งอย่างอิสระ.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # ปรับขนาดรูปทรงที่กำหนดบนมาสเตอร์และเลเอาต์รวมถึงสไลด์แต่ละอัน.
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ทำไมรูปทรงจึงบิดเบี้ยวหรือถูกตัดหลังจากปรับขนาดสไลด์?**

หากคุณเปลี่ยนขนาดสไลด์โดยไม่มีการสเกลรูปทรง รูปทรงจะคงตำแหน่งและขนาดเดิมและอาจยื่นออกนอกสไลด์ การสเกลความกว้างและความสูงด้วยอัตราส่วนที่ต่างกันก็อาจทำให้รูปทรงบิดเบี้ยวได้

**โค้ดที่ให้มาทำงานได้กับทุกประเภทของรูปทรงหรือไม่?**

ตัวอย่างแรกเปลี่ยนขอบเขตของรูปทรงโดยตรงและออกแบบมาสำหรับสไลด์ที่ไม่มีตาราง ตัวอย่างที่สองจัดการตารางแยกต่างหาก ตรวจสอบเลเอาต์ที่ได้ โดยเฉพาะข้อความและตาราง เนื่องจากตัวอย่างเหล่านี้ไม่ได้สเกลขนาดฟอนต์และเนื้อหาตารางอาจจำกัดความสูงของแถว

**ฉันจะปรับขนาดตารางเมื่อปรับขนาดสไลด์อย่างไร?**

ปรับสเกลความกว้างของคอลัมน์ตามอัตราส่วนความกว้างและความสูงขั้นต่ำของแถวตามอัตราส่วนความสูง จากนั้นปรับสเกลตำแหน่งของตารางตามที่แสดงในตัวอย่างที่สอง

**การปรับขนาดนี้จะทำงานกับมาสเตอร์สไลด์และเลเอาต์สไลด์หรือไม่?**

ใช่ ตัวอย่างที่สองวนลูปผ่าน [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) และ [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) ของแต่ละมาสเตอร์ แล้วใช้ตรรกะการปรับขนาดเดียวกันกับรูปทรงของพวกมัน

**ฉันสามารถเปลี่ยนแนวสไลด์ (แนวตั้ง/แนวนอน) พร้อมกับการปรับขนาดได้หรือไม่?**

ใช่ เรียก [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) หลังจากเปลี่ยนขนาดสไลด์และก่อนอ่านมิติเป้าหมาย เพื่อให้ปัจจัยสเกลสะท้อนแนวสุดท้าย

**มีข้อจำกัดใดต่อขนาดสไลด์ที่ฉันสามารถตั้งค่าได้หรือไม่?**

คุณสามารถกำหนดมิติสไลด์แบบกำหนดเองได้ด้วย [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) มิติที่สนับสนุนยังขึ้นกับรูปแบบงานนำเสนอและแอปพลิเคชันที่ใช้เปิดไฟล์

**ฉันจะป้องกันไม่ให้รูปทรงที่มีอัตราส่วนคงที่บิดเบี้ยวได้อย่างไร?**

ใช้ปัจจัยสเกลเดียวกันสำหรับความกว้างและความสูง เพื่อให้เลเอาต์เดิมพอดีกับมิติสไลด์ใหม่ ให้ใช้ค่าอัตราส่วนที่เล็กกว่ารหว่างความกว้างและความสูงสำหรับทั้งสองมิติและตำแหน่ง วิธีนี้รักษาส่วนประกอบไว้ แต่อาจทำให้เหลือพื้นที่ว่างที่ขอบหนึ่ง