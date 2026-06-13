---
title: จัดการ SmartArt ในการนำเสนอ PowerPoint ด้วย Python
linktitle: จัดการ SmartArt
type: docs
weight: 10
url: /th/python-net/manage-smartart/
keywords:
- SmartArt
- ข้อความจาก SmartArt
- ประเภทเค้าโครง
- คุณสมบัติซ่อน
- แผนภูมิโครงสร้างองค์กร
- แผนภูมิโครงสร้างองค์กรรูปภาพ
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและแก้ไข SmartArt ของ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET โดยใช้ตัวอย่างโค้ดที่ชัดเจนซึ่งเร่งการออกแบบสไลด์และการทำงานอัตโนมัติ"
---
## **ภาพรวม**

SmartArt คือแผนภูมิ PowerPoint ที่ประกอบด้วยโหนด, รูปร่างของโหนด, และเค้าโครง ด้วย Aspose.Slides for Python via .NET คุณสามารถสร้าง SmartArt, อ่านข้อความจากโหนดของมัน, เปลี่ยนเค้าโครง, ตรวจสอบโหนดที่ซ่อนอยู่, กำหนดค่าเค้าโครงแผนภูมิโครงสร้างองค์กร, และสร้างแผนภูมิโครงสร้างองค์กรรูปภาพได้.

## **ดึงข้อความจากออบเจ็กต์ SmartArt**

โหนด SmartArt สามารถประกอบด้วยรูปทรงหนึ่งรูปหรือหลายรูป การอ่านข้อความที่มองเห็นได้ ให้ทำการวนลูปผ่าน [SmartArt.all_nodes](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartart/all_nodes/), จากนั้นอ่าน [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ที่ส่งกลับโดย [SmartArtShape.text_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartartshape/text_frame/).

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        smart_art = shape

        for smart_art_node in smart_art.all_nodes:
            for smart_art_shape in smart_art_node.shapes:
                if smart_art_shape.text_frame is not None:
                    print(smart_art_shape.text_frame.text)
```

## **เปลี่ยนประเภทเค้าโครงของออบเจ็กต์ SmartArt**

เค้าโครง SmartArt ควบคุมการจัดเรียงและการเชื่อมต่อของโหนด ตัวอย่างต่อไปนี้สร้างออบเจ็กต์ SmartArt ด้วยค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST` จากนั้นเปลี่ยนเป็นค่า `BASIC_PROCESS` และบันทึกการนำเสนอ.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ตรวจสอบว่าโหนด SmartArt ถูกซ่อนหรือไม่**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartartnode/is_hidden/) บ่งบอกว่าโหนดถูกซ่อนไขในโมเดลข้อมูล SmartArt หรือไม่ โหนดที่ซ่อนอาจยังคงมีอยู่ในโครงสร้างแม้ว่าเค้าโครงที่เลือกจะไม่แสดงเป็นองค์ประกอบแผนภูมิที่มองเห็นได้.

ตัวอย่างต่อไปนี้เพิ่มโหนดให้กับออบเจ็กต์ SmartArt ที่ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` และตรวจสอบสถานะการซ่อนของโหนด.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    smart_art_node = smart_art.all_nodes.add_node()
    is_hidden = smart_art_node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```

## **รับหรือกำหนดเค้าโครงแผนภูมิโครงสร้างองค์กร**

สำหรับแผนภูมิ SmartArt ที่ใช้เค้าโครงแผนภูมิโครงสร้างองค์กร, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) กำหนดวิธีการจัดเรียงโหนดลูกภายใต้โหนดพาเรนท์ ตัวอย่างเช่น คุณสามารถกำหนดให้โหนดลูกห้อยจากด้านซ้าย, ด้านขวา, หรือทั้งสองด้าน ขึ้นอยู่กับ [OrganizationChartLayoutType](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/organizationchartlayouttype/) ที่เลือก.

ตัวอย่างต่อไปนี้สร้างแผนภูมิโครงสร้างองค์กรและกำหนดเค้าโครงสำหรับโหนดแรกเป็นค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **สร้างแผนภูมิโครงสร้างองค์กรรูปภาพ**

แผนภูมิโครงสร้างองค์กรรูปภาพคือเค้าโครง SmartArt ที่ออกแบบมาสำหรับแผนภูมิระดับชั้นที่มีช่องใส่รูปภาพ ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` เมื่อต้องการเพิ่มออบเจ็กต์ SmartArt ลงในสไลด์.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**Does SmartArt support mirroring or reversing for RTL languages?**

ใช่. คุณสมบัติ [SmartArt.is_reversed](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartart/is_reversed/) จะสลับทิศทางของแผนภูมิจากซ้ายไปขวาเป็นขวาไปซ้าย หรือกลับกัน เมื่อเค้าโครง SmartArt ที่เลือกรองรับการย้อนกลับ.

**How can I copy SmartArt to the same slide or to another presentation while preserving formatting?**

คุณสามารถ [clone the SmartArt shape](/slides/th/python-net/shape-manipulations/) ด้วย [ShapeCollection.add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_clone/) หรือ [clone the whole slide](/slides/th/python-net/clone-slides/) ที่มี SmartArt ทั้งหมด วิธีทั้งสองจะคงขนาด, ตำแหน่ง, และรูปแบบไว้.

**How do I render SmartArt to a raster image for preview or web export?**

[Render the slide](/slides/th/python-net/convert-powerpoint-to-png/) หรือการนำเสนอทั้งหมดเป็น PNG หรือ JPEG SmartArt จะถูกเรนเดอร์เป็นส่วนหนึ่งของสไลด์.

**How can I find a specific SmartArt object on a slide if there are several?**

กำหนดค่า [Shape.alternative_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/alternative_text/) หรือ [Shape.name](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/name/) ที่แตกต่างบนรูปทรง SmartArt แล้วค้นหาค่านั้นใน [Slide.shapes](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/shapes/), จากนั้นตรวจสอบว่ารูปทรงที่ตรงกันเป็น [SmartArt](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartart/).