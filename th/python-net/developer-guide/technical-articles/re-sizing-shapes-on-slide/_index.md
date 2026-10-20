---
title: ปรับขนาดรูปร่างบนสไลด์งานนำเสนอใน Python
type: docs
weight: 130
url: /th/python-net/resizing-shapes-on-slide/
aliases:
  - /python-net/re-sizing-shapes-on-slide/
  - /th/python-net/re-sizing-shapes-on-slide/
keywords:
- ปรับขนาดรูปร่าง
- เปลี่ยนขนาดรูปร่าง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ปรับขนาดรูปร่างบนสไลด์ PowerPoint และ OpenDocument ได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ Python ผ่าน .NET—อัตโนมัติการปรับแต่งเลเอาต์สไลด์และเพิ่มประสิทธิภาพการทำงาน."
---
## **ภาพรวม**

เมื่อคุณเปลี่ยนขนาดสไลด์ของงานนำเสนอ คุณอาจต้องปรับขนาดและตำแหน่งของรูปร่างเพื่อให้พอดีกับมิติใหม่ บทความนี้แสดงวิธีปรับขนาดรูปร่างด้วยตนเองและวิธีจัดการตารางบนสไลด์ มาสเตอร์ และเลเอาต์

## **ปรับขนาดรูปร่าง**

เพื่อรักษาตำแหน่งและขนาดสัมพัทธ์ของแต่ละรูปร่าง ให้คูณพิกัดแนวนอนและความกว้างของมันด้วยอัตราส่วนของความกว้างสไลด์ใหม่ต่อความกว้างเดิม แล้วใช้ค่าอัตราส่วนความสูงที่สอดคล้องกับพิกัดแนวตั้งและความสูงของมัน  

ตัวอย่างแรกโหลดงานนำเสนอที่สไลด์ไม่มีตาราง เปลี่ยนขนาดสไลด์เป็น A4 และบันทึกผลลัพธ์ ตัวอย่างนี้ใช้ [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) พร้อมกับ [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) เพื่อให้ลูปต่อมาควบคุมการสเกล อัตราส่วนไม่มีหน่วย; ตำแหน่งและมิติของรูปร่างวัดเป็นจุด อัตราส่วนความกว้างและความสูงที่ต่างกันอาจทำให้รูปร่างบิดเบี้ยว และการเปลี่ยนมิติของรูปร่างไม่ได้สเกลขนาดฟอนต์

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # คำนวณอัตราส่วนสเกลแนวนอนและแนวตั้งแยกกัน.
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
ตารางต้องการการจัดการแยกต่างหาก: ปรับสเกลความกว้างของคอลัมน์และความสูงของแถวแทนการกำหนดความกว้างและความสูงโดยรวมของตาราง ความสูงของแถวอาจยังคงใหญ่กว่าที่ร้องขอหากเนื้อหาในเซลล์ต้องการพื้นที่เพิ่ม
{{% /alert %}}

ตัวอย่างที่สองรองรับตารางและประมวลผลรูปร่างบนมาสเตอร์และเลเอาต์รวมถึงสไลด์เดี่ยวก่อนบันทึกงานนำเสนอที่ปรับขนาด ตัวช่วยของมันจัดการกับแต่ละ [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) โดยปรับสเกล [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) และ [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) จากนั้นปรับสเกลตำแหน่งของตารางโดยไม่ต้องสเกลมิติรวมของตารางแยกต่างหาก

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
    # คำนวณอัตราส่วนสเกลแนวนอนและแนวตั้งแยกกัน.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # ปรับขนาดรูปร่างที่กำหนดบนมาสเตอร์และเลเอาต์ รวมถึงสไลด์เดี่ยว.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ทำไมรูปร่างถึงบิดเบี้ยวหรือถูกตัดหลังจากปรับขนาดสไลด์?**

หากคุณเปลี่ยนขนาดสไลด์โดยไม่สเกลรูปร่าง รูปร่างจะคงตำแหน่งและมิติเดิมและอาจขยายออกนอกสไลด์ การสเกลความกว้างและความสูงด้วยอัตราส่วนที่แตกต่างกันก็อาจทำให้รูปร่างบิดเบี้ยวได้  

**โค้ดที่ให้มาทำงานกับทุกประเภทของรูปร่างหรือไม่?**

ตัวอย่างแรกเปลี่ยนขอบเขตของรูปร่างโดยตรงและออกแบบมาสำหรับสไลด์ที่ไม่มีตาราง ตัวอย่างที่สองจัดการตารางแยกต่างหาก ตรวจสอบเลเอาต์ที่ได้โดยเฉพาะข้อความและตาราง เนื่องจากตัวอย่างเหล่านี้ไม่ได้สเกลขนาดฟอนต์และเนื้อหาตารางอาจจำกัดความสูงของแถว  

**ฉันจะปรับขนาดตารางอย่างไรเมื่อปรับขนาดสไลด์?**

ปรับสเกลความกว้างของคอลัมน์ด้วยอัตราส่วนความกว้างและความสูงขั้นต่ำของแถวด้วยอัตราส่วนความสูง แล้วปรับสเกลตำแหน่งของตารางตามที่แสดงในตัวอย่างที่สอง  

**การปรับขนาดนี้จะทำงานกับมาสเตอร์สไลด์และเลเอาต์สไลด์หรือไม่?**

ใช่ ตัวอย่างที่สองวนผ่าน [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) และ [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) ของแต่ละมาสเตอร์และใช้ตรรกะการปรับขนาดเดียวกันกับรูปร่างของพวกมัน  

**ฉันสามารถเปลี่ยนทิศทางของสไลด์ (แนวตั้ง/แนวนอน) พร้อมกับการปรับขนาดได้หรือไม่?**

ใช่ ตั้งค่า [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) หลังจากเปลี่ยนขนาดสไลด์และก่อนอ่านมิติเป้าหมาย เพื่อให้ค่าแฟกเตอร์การสเกลสะท้อนทิศทางสุดท้าย  

**มีขีดจำกัดของขนาดสไลด์ที่ฉันสามารถตั้งค่าได้หรือไม่?**

คุณสามารถกำหนดมิติสไลด์ที่กำหนดเองได้โดยใช้ [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) มิติที่รองรับยังขึ้นอยู่กับรูปแบบของงานนำเสนอและแอปพลิเคชันที่ใช้เปิดไฟล์  

**ฉันจะป้องกันไม่ให้รูปร่างที่มีอัตราส่วนคงที่บิดเบียวได้อย่างไร?**

ใช้ค่าแฟกเตอร์สเกลเดียวกันสำหรับความกว้างและความสูง เพื่อให้เลเอาต์ต้นฉบับพอดีกับมิติสไลด์ใหม่ ให้ใช้ค่าอัตราส่วนที่เล็กกว่าระหว่างอัตราส่วนความกว้างและความสูงสำหรับทั้งสองมิติและตำแหน่ง วิธีนี้จะรักษาสัดส่วนไว้แต่บางครั้งอาจทำให้เหลือพื้นที่ว่างที่ขอบหนึ่ง