---
title: ปรับขนาดรูปร่างบนสไลด์งานนำเสนอใน Python
type: docs
weight: 130
url: /th/python-net/resizing-shapes-on-slide/
aliases:
  - /th/python-net/re-sizing-shapes-on-slide/
keywords:
- ปรับขนาดรูปร่าง
- เปลี่ยนขนาดรูปร่าง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ปรับขนาดรูปร่างบนสไลด์ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides for Python via .NET—ทำให้การปรับแต่งเลย์เอาต์สไลด์อัตโนมัติและเพิ่มประสิทธิภาพการทำงาน."
---
## **ภาพรวม**

เมื่อคุณเปลี่ยนขนาดสไลด์ของงานนำเสนอ คุณอาจต้องปรับขนาดและตำแหน่งของรูปร่างเพื่อให้พอดีกับมิติใหม่ คำแนะนำนี้จะแสดงวิธีการปรับขนาดรูปร่างด้วยตนเองและวิธีจัดการตารางบนสไลด์ มาสเตอร์ และเลย์เอาต์

## **ปรับขนาดรูปร่าง**

เพื่อรักษาตำแหน่งและขนาดสัมพัทธ์ของแต่ละรูปร่าง ให้คูณพิกัดแนวนอนและความกว้างด้วยอัตราส่วนของความกว้างสไลด์ใหม่ต่อความกว้างเดิม แล้วใช้ค่าอัตราส่วนความสูงกับพิกัดแนวตั้งและความสูงของรูปร่างด้วยเช่นกัน

ตัวอย่างแรกโหลดงานนำเสนอที่สไลด์ไม่มีตาราง เปลี่ยนขนาดสไลด์เป็น A4 แล้วบันทึกผลลัพธ์ โดยใช้ [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) กับ [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) เพื่อให้ลูปต่อมาควบคุมการสเกลได้ อัตราส่วนเป็นค่าที่ไม่มีหน่วย; ตำแหน่งและมิติของรูปร่างวัดเป็นจุด อัตราส่วนความกว้างและความสูงที่แตกต่างกันอาจทำให้รูปร่างบิดเบี้ยว และการเปลี่ยนแปลงมิติของรูปร่างจะไม่สเกลขนาดฟอนต์

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # คำนวณปัจจัยสเกลแนวนอนและแนวตั้งอย่างอิสระ.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
ตารางต้องการการจัดการแยกต่างหาก: สเกลความกว้างของคอลัมน์และความสูงของแถวแทนการกำหนดความกว้างและความสูงรวมของตาราง ความสูงของแถวอาจยังคงใหญ่กว่าที่ต้องการหากเนื้อหาในเซลล์ต้องการพื้นที่มากกว่า
{{% /alert %}}

ตัวอย่างที่สองรองรับตารางและประมวลผลรูปร่างบนมาสเตอร์และเลย์เอาต์รวมถึงสไลด์แต่ละสไลด์ก่อนบันทึกงานนำเสนอที่ปรับขนาด ตัวช่วยของมันจัดการแต่ละ [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) โดยการสเกล [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) และ [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) แล้วสเกลตำแหน่งของตารางโดยไม่สเกลมิติรวมแยกต่างหาก

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # ขนาดของตารางถูกควบคุมโดยความกว้างของคอลัมน์และความสูงของแถว.
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # คำนวณปัจจัยสเกลแนวนอนและแนวตั้งอย่างอิสระ.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # ปรับขนาดรูปร่างที่กำหนดบนมาสเตอร์และเลย์เอาต์ รวมทั้งสไลด์แต่ละสไลด์.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ทำไมรูปร่างถึงบิดเบี้ยวหรือถูกตัดเมื่อปรับขนาดสไลด์?**

หากคุณเปลี่ยนขนาดสไลด์โดยไม่สเกลรูปร่าง รูปร่างจะคงตำแหน่งและมิติดั้งเดิมและอาจเกินขอบสไลด์ การสเกลความกว้างและความสูงด้วยอัตราส่วนที่ต่างกันก็อาจทำให้รูปร่างบิดเบี้ยวได้เช่นกัน

**โค้ดที่ให้มาทำงานกับรูปแบบรูปร่างทั้งหมดหรือไม่?**

ตัวอย่างแรกเปลี่ยนขอบเขตของรูปร่างโดยตรงและออกแบบมาสำหรับสไลด์ที่ไม่มีตาราง ตัวอย่างที่สองจัดการตารางแยกต่างหาก ตรวจสอบการจัดเรียงผลลัพธ์โดยเฉพาะข้อความและตาราง เนื่องจากตัวอย่างเหล่านี้ไม่สเกลขนาดฟอนต์และเนื้อหาตารางอาจจำกัดความสูงของแถว

**จะปรับขนาดตารางอย่างไรเมื่อปรับขนาดสไลด์?**

สเกลความกว้างของคอลัมน์โดยใช้ค่าอัตราส่วนความกว้างและความสูงขั้นต่ำของแถวโดยใช้ค่าอัตราส่วนความสูง แล้วสเกลตำแหน่งของตารางตามที่แสดงในตัวอย่างที่สอง

**การปรับขนาดนี้ทำงานบนสไลด์มาสเตอร์และสไลด์เลย์เอาต์หรือไม่?**

ทำได้ ตัวอย่างที่สองวนผ่าน [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) และแต่ละมาสเตอร์ของ [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) พร้อมใช้ตรรกะการปรับขนาดเดียวกันกับรูปร่างของพวกมัน

**สามารถเปลี่ยนทิศทางของสไลด์ (แนวตั้ง/แนวนอน) พร้อมกับการปรับขนาดได้หรือไม่?**

ทำได้ ตั้งค่า [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) หลังจากเปลี่ยนขนาดสไลด์และก่อนอ่านมิติเป้าหมาย เพื่อให้ค่าอัตราส่วนสะท้อนทิศทางสุดท้าย

**มีขีดจำกัดใดสำหรับขนาดสไลด์ที่ฉันสามารถตั้งค่าได้หรือไม่?**

คุณสามารถระบุมิติสไลด์แบบกำหนดเองด้วย [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) มิติที่รองรับยังขึ้นกับรูปแบบงานนำเสนอและแอปพลิเคชันที่ใช้เปิดไฟล์อีกด้วย

**จะป้องกันไม่ให้รูปร่างที่มีอัตราส่วนคงที่บิดเบี้ยวได้อย่างไร?**

ใช้ค่าอัตราส่วนเดียวกันสำหรับความกว้างและความสูง เพื่อให้เข้ากับเค้าโครงเดิมภายในมิติสไลด์ใหม่ ให้ใช้ค่าที่น้อยกว่าระหว่างอัตราส่วนความกว้างและความสูงสำหรับทั้งสองมิติและตำแหน่ง ซึ่งจะรักษาสัดส่วนไว้แต่บางครั้งอาจทำให้มีพื้นที่ว่างที่ขอบหนึ่งของสไลด์

