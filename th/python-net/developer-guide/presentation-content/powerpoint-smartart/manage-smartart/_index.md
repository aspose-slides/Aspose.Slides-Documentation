---
title: จัดการ SmartArt ในการนำเสนอ PowerPoint ด้วย Python
linktitle: จัดการ SmartArt
type: docs
weight: 10
url: /th/python-net/manage-smartart/
keywords:
  - SmartArt
  - ข้อความ SmartArt
  - ประเภทการจัดวาง
  - คุณสมบัติซ่อน
  - แผนภูมิองค์กร
  - แผนภูมิองค์กรแบบรูปภาพ
  - PowerPoint
  - การนำเสนอ
  - Python
  - Aspose.Slides
description: "เรียนรู้การสร้างและแก้ไข SmartArt ใน PowerPoint ด้วย Aspose.Slides for Python via .NET ด้วยตัวอย่างโค้ดที่ชัดเจนซึ่งช่วยเร่งการออกแบบสไลด์และการทำอัตโนมัติ"
---
## **ภาพรวม**

SmartArt คือแผนภาพ PowerPoint ที่สร้างจากโหนด รูปร่างของโหนด และการจัดวาง ด้วย Aspose.Slides for Python via .NET คุณสามารถสร้าง SmartArt อ่านข้อความจากโหนดของมัน เปลี่ยนการจัดวาง ตรวจสอบโหนดที่ซ่อนอยู่ กำหนดการจัดวางแผนภูมิองค์กร และสร้างแผนภูมิองค์กรแบบรูปภาพได้

## **รับข้อความจากวัตถุ SmartArt**

โหนด SmartArt สามารถมีรูปทรงหนึ่งหรือหลายรูปทรงได้ เพื่ออ่านข้อความจากรูปทรงของโหนด ให้ทำการวนลูปผ่าน [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/) แล้วอ่าน [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) ที่คืนค่าจาก [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/)  

ตัวอย่างนี้ต้องการการนำเสนอที่มีอย่างน้อยหนึ่งสไลด์และวัตถุ SmartArt อยู่เป็นรูปทรงแรกบนสไลด์นั้น มันจะแสดงแต่ละ TextFrame ที่มีอยู่ในคอนโซล  

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```

## **เปลี่ยนประเภทการจัดวางของวัตถุ SmartArt**

การจัดวางของ SmartArt ควบคุมวิธีการจัดเรียงและเชื่อมต่อโหนด ตัวอย่างต่อไปนี้สร้างวัตถุ SmartArt ด้วยค่า [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST` แล้วเปลี่ยนเป็นค่า `BASIC_PROCESS` และบันทึกการนำเสนอ ตำแหน่งและขนาดที่ส่งให้ [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) ถูกวัดเป็นจุด ตั้งค่า [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/) เพื่อเปลี่ยนการจัดวาง  

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **ตรวจสอบว่าโหนด SmartArt ซ่อนอยู่หรือไม่**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) ระบุว่าโหนดถูกซ่อนในโมเดลข้อมูลของ SmartArt หรือไม่ โหนดที่ซ่อนอาจยังคงอยู่ในโครงสร้างแม้การจัดวางที่เลือกจะไม่แสดงเป็นองค์ประกอบแผนภาพที่มองเห็นได้  

ตัวอย่างต่อไปนี้เพิ่มโหนดเข้าไปในวัตถุ SmartArt ที่ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` แล้วตรวจสอบสถานะการซ่อนของโหนดที่เพิ่มเข้ามา มันจะแสดงข้อความหากโหนดถูกซ่อนและบันทึกแผนภาพ  

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```

## **รับหรือกำหนดการจัดวางแผนภูมิองค์กร**

สำหรับแผนภาพ SmartArt ที่ใช้การจัดวางแผนภูมิองค์กร [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) กำหนดวิธีการจัดเรียงโหนดลูกภายใต้โหนดพาเรนต์ ตัวอย่างเช่น คุณสามารถตั้งค่าให้โหนดลูกแขวนจากด้านซ้าย ด้านขวา หรือทั้งสองด้าน ขึ้นอยู่กับค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) ที่เลือก  

ตัวอย่างต่อไปนี้สร้างแผนภูมิองค์กรและตั้งค่าการจัดวางสำหรับโหนดแรกเป็นค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING` ดัชนีเริ่มต้นจากศูนย์ `0` เลือกโหนดระดับบนสุดแรก; โหนดลูกของมันจะใช้การจัดเรียงที่เลือก การนำเสนอที่แก้ไขแล้วจะถูกบันทึก  

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **สร้างแผนภูมิองค์กรแบบรูปภาพ**

แผนภูมิองค์กรแบบรูปภาพคือการจัดวาง SmartArt ที่ออกแบบมาสำหรับแผนภูมิไฮราร์กีที่มีตัวแทรกภาพ ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` เมื่อเพิ่มวัตถุ SmartArt ไปยังสไลด์ ตัวอย่างนี้บันทึกแผนภาพที่มีตัวแทรกภาพ; แต่ไม่ได้ใส่รูปภาพลงในตัวแทรก  

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **แปลงแผนภูมิเก่ากลับเป็นกลุ่มของรูปทรง**

เมื่อทำการอัปเดตการนำเสนอเก่า คุณอาจต้องอัปเดตแผนภูมิองค์กรที่สร้างใน PowerPoint 97–2003 Aspose.Slides แสดงแผนภูมิเก่าเหล่านั้นเป็นอ็อบเจกต์ [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) ใช้ [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/) เพื่อแปลงแผนภูมิให้เป็นกลุ่มของรูปทรง เพื่อให้คุณสามารถแก้ไของค์ประกอบภาพแต่ละส่วน ดูรายละเอียดเพิ่มเติมที่ [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/)  

การแปลงจะเพิ่มกลุ่มใหม่ลงในคอลเล็กชันของรูปทรงโดยไม่ลบแผนภูมิเดิม หลังจากการแปลงสำเร็จ ให้ลบแผนภูมิเดิมด้วย [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) เพื่อหลีกเลี่ยงเนื้อหาซ้ำ รวบรวมแผนภูมิเก่าไว้ในรายการก่อนแปลงเพื่อให้การเพิ่มและลบรูปทรงไม่ทำให้การวนลูปเสียหาย  

ตัวอย่างต่อไปนี้เปิดการนำเสนอ ค้นหาทุกสไลด์ แปลงแผนภูมิเป็นกลุ่มของรูปทรง และบันทึกการนำเสนอที่อัปเดตเป็น PPTX  

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```

การนำเสนอที่บันทึกไว้จะมีกลุ่มของรูปทรงที่สามารถแก้ไขได้แทนแผนภูมิเก่าที่ถูกแปลง โดยไม่มีแผนภูมิเดิมเหลืออยู่ เปิดไฟล์ PPTX ใน PowerPoint เพื่อแก้ไของค์ประกอบแต่ละส่วนภายในกลุ่ม เช่น ข้อความ การเติมสี หรือตำแหน่ง

## **FAQ**

**SmartArt รองรับการสะท้อนหรือย้อนกลับสำหรับภาษาขวาไปซ้าย (RTL) หรือไม่?**

ใช่. คุณสมบัติ [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) จะสลับทิศทางของแผนภูมิจากซ้ายไปขวาเป็นขวาไปซ้าย หรือกลับกัน เมื่อการจัดวาง SmartArt ที่เลือกสนับสนุนการย้อนกลับ

**ฉันจะคัดลอก SmartArt ไปยังสไลด์เดียวกันหรือไปยังการนำเสนออื่นโดยคงรูปแบบไว้ได้อย่างไร?**

คุณสามารถ [คัดลอกรูปทรง SmartArt](/slides/th/python-net/shape-manipulations/) ด้วย [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) หรือ [คัดลอกสไลด์ทั้งหมด](/slides/th/python-net/clone-slides/) ที่มี SmartArt ทั้งหมด ทั้งสองวิธีจะคงขนาด ตำแหน่ง และรูปแบบไว้

**ฉันจะเรนเดอร์ SmartArt เป็นภาพเรสเตอร์สำหรับการแสดงตัวอย่างหรือส่งออกเว็บอย่างไร?**

[เรนเดอร์สไลด์](/slides/th/python-net/convert-powerpoint-to-png/) หรือการนำเสนอทั้งหมดเป็น PNG หรือ JPEG SmartArt จะถูกเรนเดอร์เป็นส่วนหนึ่งของสไลด์

**ฉันจะหาวัตถุ SmartArt เฉพาะบนสไลด์ได้อย่างไรหากมีหลายวัตถุ?**

ตั้งค่าข้อความทางเลือกที่โดดเด่นด้วย [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) หรือค่า [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) บนรูปทรง SmartArt จากนั้นค้นหาค่านั้นใน [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) และตรวจสอบว่ารูปทรงที่ตรงกันเป็น [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)