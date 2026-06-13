---
title: จัดการโหนดรูปทรง SmartArt ในงานนำเสนอด้วย Python
linktitle: โหนดรูปทรง SmartArt
type: docs
weight: 30
url: /th/python-net/manage-smartart-shape-node/
keywords:
- โหนด SmartArt
- โหนดย่อย
- เพิ่มโหนด
- ตำแหน่งโหนด
- เข้าถึงโหนด
- ลบโหนด
- กำหนดตำแหน่งเอง
- โหนดผู้ช่วย
- รูปแบบการเติม
- เรนเดอร์โหนด
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "จัดการโหนดรูปทรง SmartArt ในไฟล์ PPT, PPTX และ ODP ด้วย Aspose.Slides for Python via .NET. รับตัวอย่างโค้ดที่ชัดเจนและเคล็ดลับเพื่อทำให้งานนำเสนอของคุณเป็นระเบียบง่ายขึ้น."
---
## **ภาพรวม**

กราฟิก SmartArt ในงานนำเสนอ PowerPoint ถูกจัดระเบียบโดยโหนดที่มีข้อความและกำหนดโครงสร้างของแผนภูมิ Aspose.Slides ให้คุณทำงานกับโหนด SmartArt เหล่านี้โดยใช้โปรแกรม: เพิ่มโหนดและโหนดย่อยใหม่ แทรกโหนดย่อยในตำแหน่งเฉพาะ เข้าถึงโหนดที่มีอยู่ และอ่านข้อความ ระดับ และตำแหน่งของโหนด

บทความนี้อธิบายวิธีจัดการโหนดรูปทรง SmartArt แสดงวิธีการลบโหนด ทำงานกับโหนดย่อยโดยใช้ดัชนีหรือตำแหน่ง เปลี่ยนโหนดผู้ช่วยเป็นโหนดปกติ ปรับตำแหน่ง ขนาด และการหมุนของโหนดรูปทรง SmartArt ตั้งค่า Fill Format ของโหนด และสร้างภาพขนาดย่อสำหรับโหนดย่อยของ SmartArt

## **เพิ่มโหนด SmartArt**
Aspose.Slides for Python via .NET มี API ที่ง่ายที่สุดเพื่อจัดการรูปทรง SmartArt อย่างง่ายที่สุด ตัวอย่างโค้ดต่อไปนี้จะช่วยให้คุณเพิ่มโหนดและโหนดย่อยภายในรูปทรง SmartArt

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และโหลดงานนำเสนอที่มี SmartArt Shape
- รับอ้างอิงสไลด์แรกโดยใช้ Index ของมัน
- วนผ่านรูปทรงทั้งหมดในสไลด์แรก
- ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่และทำ Typecast รูปทรงที่เลือกเป็น SmartArt หากเป็น SmartArt
- เพิ่มโหนดใหม่ใน SmartArt Shape NodeCollection และตั้งข้อความใน TextFrame
- จากนั้น เพิ่มโหนดย่อยในโหนด SmartArt ที่เพิ่มใหม่และตั้งข้อความใน TextFrame
- บันทึกงานนำเสนอ

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# โหลดงานนำเสนอที่ต้องการ
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # วนผ่านรูปทรงทั้งหมดในสไลด์แรก
    for shape in pres.slides[0].shapes:

        # ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if type(shape) is art.SmartArt:
            # เพิ่มโหนด SmartArt ใหม่
            node1 = shape.all_nodes.add_node()
            # เพิ่มข้อความ
            node1.text_frame.text = "Test"

            # เพิ่มโหนดย่อยใหม่ในโหนดแม่ จะถูกเพิ่มในตำแหน่งสุดท้ายของคอลเลกชัน
            new_node = node1.child_nodes.add_node()

            # เพิ่มข้อความ
            new_node.text_frame.text = "New Node Added"

    # บันทึกงานนำเสนอ
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มโหนด SmartArt ในตำแหน่งเฉพาะ**
ในตัวอย่างโค้ดต่อไปนี้จะแสดงวิธีเพิ่มโหนดย่อยที่สังกัดโหนดของรูปทรง SmartArt ในตำแหน่งที่กำหนด

- สร้างอินสแตนซ์ของคลาส `Presentation`
- รับอ้างอิงสไลด์แรกโดยใช้ Index ของมัน
- เพิ่มรูปทรง SmartArt ประเภท StackedList ในสไลด์ที่เข้าถึง
- เข้าถึงโหนดแรกในรูปทรง SmartArt ที่เพิ่ม
- จากนั้น เพิ่มโหนดย่อยสำหรับโหนดที่เลือกที่ตำแหน่ง 2 และตั้งข้อความ
- บันทึกงานนำเสนอ

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# สร้างอินสแตนซ์ของงานนำเสนอ
with slides.Presentation() as pres:
    # เข้าถึงสไลด์ของงานนำเสนอ
    slide = pres.slides[0]

    # เพิ่ม Smart Art IShape
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # เข้าถึงโหนด SmartArt ที่ดัชนี 0
    node = smart.all_nodes[0]

    # เพิ่มโหนดย่อยใหม่ที่ตำแหน่ง 2 ในโหนดแม่
    chNode = node.child_nodes.add_node_by_position(2)

    # เพิ่มข้อความ
    chNode.text_frame.text = "Sample text Added"

    # บันทึกงานนำเสนอ
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงโหนด SmartArt**
ตัวอย่างโค้ดต่อไปนี้จะช่วยให้คุณเข้าถึงโหนดภายในรูปทรง SmartArt โปรดทราบว่าคุณไม่สามารถเปลี่ยน LayoutType ของ SmartArt ได้ เนื่องจากเป็นค่าอ่านอย่างเดียวและจะถูกตั้งค่าเมื่อเพิ่มรูปทรง SmartArt

- สร้างอินสแตนซ์ของคลาส `Presentation` และโหลดงานนำเสนอที่มี SmartArt Shape
- รับอ้างอิงสไลด์แรกโดยใช้ Index ของมัน
- วนผ่านรูปทรงทั้งหมดในสไลด์แรก
- ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่และทำ Typecast รูปทรงที่เลือกเป็น SmartArt หากเป็น SmartArt
- วนผ่านโหนดทั้งหมดภายใน SmartArt Shape
- เข้าถึงและแสดงข้อมูลเช่น ตำแหน่งโหนด SmartArt ระดับและข้อความ

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# โหลดงานนำเสนอที่ต้องการ
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # วนผ่านรูปทรงทั้งหมดในสไลด์แรก
    for shape in pres.slides[0].shapes:
        # ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if type(shape) is art.SmartArt:
            # วนผ่านโหนดทั้งหมดภายใน SmartArt
            for i in range(len(shape.all_nodes)):
                # เข้าถึงโหนด SmartArt ที่ดัชนี i
                node = shape.all_nodes[i]

                # พิมพ์พารามิเตอร์ของโหนด SmartArt
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```

## **เข้าถึงโหนดย่อยของ SmartArt**
ตัวอย่างโค้ดต่อไปนี้จะช่วยให้คุณเข้าถึงโหนดย่อยที่สังกัดโหนดของรูปทรง SmartArt

- สร้างอินสแตนซ์ของคลาส PresentationEx และโหลดงานนำเสนอที่มี SmartArt Shape
- รับอ้างอิงสไลด์แรกโดยใช้ Index ของมัน
- วนผ่านรูปทรงทั้งหมดในสไลด์แรก
- ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่และทำ Typecast รูปทรงที่เลือกเป็น SmartArtEx หากเป็น SmartArt
- วนผ่านโหนดทั้งหมดภายใน SmartArt Shape
- สำหรับแต่ละโหนด SmartArt ที่เลือก วนผ่านโหนดย่อยทั้งหมดภายในโหนดนั้น
- เข้าถึงและแสดงข้อมูลเช่น ตำแหน่งโหนดย่อย ระดับและข้อความ

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# โหลดงานนำเสนอที่ต้องการ
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # วนผ่านรูปทรงทั้งหมดในสไลด์แรก
    for shape in pres.slides[0].shapes:
        # ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if type(shape) is art.SmartArt:
            # วนผ่านโหนดทั้งหมดภายใน SmartArt
            for node0 in shape.all_nodes:
                # วนผ่านโหนดย่อย
                for j in range(len(node0.child_nodes)):
                    # เข้าถึงโหนดย่อยในโหนด SmartArt
                    node = node0.child_nodes[j]

                    # พิมพ์พารามิเตอร์ของโหนดย่อย SmartArt
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))
```

## **เข้าถึงโหนดย่อยของ SmartArt ในตำแหน่งเฉพาะ**
ในตัวอย่างนี้ เราจะเรียนรู้การเข้าถึงโหนดย่อยในตำแหน่งเฉพาะที่สังกัดโหนดของรูปทรง SmartArt

- สร้างอินสแตนซ์ของคลาส `Presentation`
- รับอ้างอิงสไลด์แรกโดยใช้ Index ของมัน
- เพิ่มรูปทรง SmartArt ประเภท StackedList
- เข้าถึงรูปทรง SmartArt ที่เพิ่ม
- เข้าถึงโหนดที่ดัชนี 0 ของรูปทรง SmartArt ที่เข้าถึง
- จากนั้น เข้าถึงโหนดย่อยที่ตำแหน่ง 1 ของโหนด SmartArt ที่เข้าถึงโดยใช้เมธอด GetNodeByPosition()
- เข้าถึงและแสดงข้อมูลเช่น ตำแหน่งโหนดย่อย ระดับและข้อความ

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# สร้างอินสแตนซ์ของงานนำเสนอ
with slides.Presentation() as pres:
    # เข้าถึงสไลด์แรก
    slide = pres.slides[0]
    # เพิ่มรูปทรง SmartArt ในสไลด์แรก
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # เข้าถึงโหนด SmartArt ที่ดัชนี 0
    node = smart.all_nodes[0]
    # เข้าถึงโหนดย่อยที่ตำแหน่ง 1 ในโหนดแม่
    position = 1
    chNode = node.child_nodes[position] 
    # พิมพ์พารามิเตอร์ของโหนดย่อย SmartArt
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))

```

## **ลบโหนด SmartArt**
ในตัวอย่างนี้ เราจะเรียนรู้การลบโหนดภายในรูปทรง SmartArt

- สร้างอินสแตนซ์ของคลาส `Presentation` และโหลดงานนำเสนอที่มี SmartArt Shape
- รับอ้างอิงสไลด์แรกโดยใช้ Index ของมัน
- วนผ่านรูปทรงทั้งหมดในสไลด์แรก
- ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่และทำ Typecast รูปทรงที่เลือกเป็น SmartArt หากเป็น SmartArt
- ตรวจสอบว่า SmartArt มีโหนดมากกว่า 0 หรือไม่
- เลือกโหนด SmartArt ที่ต้องการลบ
- จากนั้น ลบโหนดที่เลือกโดยใช้เมธอด RemoveNode() * บันทึกงานนำเสนอ

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# โหลดงานนำเสนอที่ต้องการ
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # วนผ่านรูปทรงทั้งหมดในสไลด์แรก
    for shape in pres.slides[0].shapes:
        # ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if type(shape) is art.SmartArt:
            # ทำ Typecast รูปทรงเป็น SmartArtEx
            if len(shape.all_nodes) > 0:
                # เข้าถึงโหนด SmartArt ที่ดัชนี 0
                node = shape.all_nodes[0]

                # ลบโหนดที่เลือก
                shape.all_nodes.remove_node(node)

    # บันทึกงานนำเสนอ
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ลบโหนด SmartArt ในตำแหน่งเฉพาะ**
ในตัวอย่างนี้ เราจะเรียนรู้การลบโหนดภายในรูปทรง SmartArt ที่ตำแหน่งเฉพาะ

- สร้างอินสแตนซ์ของคลาส `Presentation` และโหลดงานนำเสนอที่มี SmartArt Shape
- รับอ้างอิงสไลด์แรกโดยใช้ Index ของมัน
- วนผ่านรูปทรงทั้งหมดในสไลด์แรก
- ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่และทำ Typecast รูปทรงที่เลือกเป็น SmartArt หากเป็น SmartArt
- เลือกโหนดรูปทรง SmartArt ที่ดัชนี 0
- จากนั้น ตรวจสอบว่าโหนด SmartArt ที่เลือกมีโหนดย่อยมากกว่า 2 หรือไม่
- จากนั้น ลบโหนดที่ตำแหน่ง 1 โดยใช้เมธอด RemoveNodeByPosition()
- บันทึกงานนำเสนอ

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# โหลดงานนำเสนอที่ต้องการ
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # วนผ่านรูปทรงทั้งหมดในสไลด์แรก
    for shape in pres.slides[0].shapes:
        # ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if type(shape) is art.SmartArt:
            # ทำ Typecast รูปทรงเป็น SmartArt
            if len(shape.all_nodes) > 0:
                # เข้าถึงโหนด SmartArt ที่ดัชนี 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # ลบโหนดย่อยที่ตำแหน่ง 1
                    node.child_nodes.remove_node(1)

    # บันทึกงานนำเสนอ
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าตำแหน่งกำหนดเองสำหรับโหนดย่อยใน SmartArt**
ตอนนี้ Aspose.Slides for Python via .NET รองรับการตั้งค่า X และ Y ของ SmartArtShape โค้ดสแนปช็อตด้านล่างแสดงวิธีตั้งค่าตำแหน่ง ขนาด และการหมุนของ SmartArtShape โปรดทราบว่าการเพิ่มโหนดใหม่จะทำให้มีการคำนวณตำแหน่งและขนาดของโหนดทั้งหมดใหม่

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# โหลดงานนำเสนอที่ต้องการ
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# ย้ายรูปทรง SmartArt ไปยังตำแหน่งใหม่
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# เปลี่ยนความกว้างของรูปทรง SmartArt
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# เปลี่ยนความสูงของรูปทรง SmartArt
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# เปลี่ยนการหมุนของรูปทรึง SmartArt
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```

## **ตรวจสอบโหนดผู้ช่วย**
ในตัวอย่างโค้ดต่อไปนี้เราจะสำรวจวิธีระบุโหนดผู้ช่วยในคอลเลกชันโหนด SmartArt และการเปลี่ยนแปลงพวกมัน

- สร้างอินสแตนซ์ของคลาส PresentationEx และโหลดงานนำเสนอที่มี SmartArt Shape
- รับอ้างอิงสไลด์ที่สองโดยใช้ Index ของมัน
- วนผ่านรูปทรงทั้งหมดในสไลด์แรก
- ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่และทำ Typecast รูปทรงที่เลือกเป็น SmartArtEx หากเป็น SmartArt
- วนผ่านโหนดทั้งหมดในรูปทรง SmartArt และตรวจสอบว่าพวกมันเป็นโหนดผู้ช่วยหรือไม่
- เปลี่ยนสถานะของโหนดผู้ช่วยเป็นโหนดปกติ
- บันทึกงานนำเสนอ

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# สร้างอินสแตนซ์ของงานนำเสนอ
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # วนผ่านรูปทรงทั้งหมดในสไลด์แรก
    for shape in pres.slides[0].shapes:
        # ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if type(shape) is art.SmartArt:
            # วนผ่านโหนดทั้งหมดของรูปทรง SmartArt
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # ตรวจสอบว่าโหนดเป็นโหนดผู้ช่วยหรือไม่
                if node.is_assistant:
                    # ตั้งค่าโหนดผู้ช่วยเป็น false และทำให้เป็นโหนดปกติ
                    node.is_assistant = False
    # บันทึกงานนำเสนอ
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่า Fill Format ของโหนด**
Aspose.Slides for Python via .NET ทำให้คุณสามารถเพิ่มรูปทรง SmartArt ที่กำหนดเองและตั้งค่า Fill Format ของมันได้ บทความนี้อธิบายวิธีสร้างและเข้าถึงรูปทรง SmartArt และตั้งค่า Fill Format ด้วย Aspose.Slides for Python via .NET

โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส `Presentation`
- รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
- เพิ่มรูปทรง SmartArt โดยตั้งค่า LayoutType
- ตั้งค่า FillFormat สำหรับโหนดของรูปทรง SmartArt
- เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # เข้าถึงสไลด์
    slide = presentation.slides[0]

    # เพิ่มรูปทรง SmartArt และโหนด
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # ตั้งค่าสีเติมของโหนด
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # บันทึกงานนำเสนอ
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **สร้างภาพขนาดย่อของโหนดย่อย SmartArt**
นักพัฒนาสามารถสร้างภาพขนาดย่อของโหนดย่อยของ SmartArt ได้โดยทำตามขั้นตอนต่อไปนี้

1. สร้างอ็อบเจกต์ `Presentation` ที่แทนไฟล์ PPTX
2. เพิ่ม SmartArt
3. รับอ้างอิงโหนดโดยใช้ Index ของมัน
4. รับภาพขนาดย่อ
5. บันทึกภาพขนาดย่อในรูปแบบภาพที่ต้องการ

ตัวอย่างด้านล่างแสดงการสร้างภาพขนาดย่อของโหนดย่อย SmartArt

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX 
with slides.Presentation() as presentation: 
    # เพิ่ม SmartArt 
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # รับอ้างอิงของโหนดโดยใช้ Index ของมัน  
    node = smart.nodes[1]

    # รับภาพขนาดย่อ
    with node.shapes[0].get_image() as bmp:
        # บันทึกภาพขนาดย่อ
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```

## **คำถามที่พบบ่อย**

**SmartArt รองรับการเคลื่อนไหวหรือไม่?**

ใช่. SmartArt ถูกจัดการเป็นรูปทรงทั่วไป ดังนั้นคุณสามารถ [apply standard animations](/slides/th/python-net/shape-animation/) (การเข้า, การออก, การเน้น, เส้นทางการเคลื่อนที่) และปรับเวลาได้ คุณยังสามารถทำให้รูปทรงภายในโหนด SmartArt เคลื่อนไหวเมื่อจำเป็น

**จะหาตำแหน่ง SmartArt ที่เฉพาะเจาะจงบนสไลด์ได้อย่างไรหากไม่รู้ ID ภายใน?**

กำหนดและค้นหาโดยใช้ [alternative text](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartart/alternative_text/) การตั้งค่า AltText ที่เป็นเอกลักษณ์บน SmartArt จะช่วยให้คุณพบได้โดยโปรแกรมโดยไม่ต้องพึ่งพาตัวระบุภายใน

**ลักษณะการแสดงผลของ SmartArt จะคงที่เมื่อตีค่าเป็น PDF หรือไม่?**

ใช่. Aspose.Slides จะเรนเดอร์ SmartArt ด้วยความละเอียดสูงในระหว่างการ [PDF export](/slides/th/python-net/convert-powerpoint-to-pdf/) ทำให้คงรูปแบบ, สี, และเอฟเฟกต์

**สามารถดึงภาพของ SmartArt ทั้งหมด (สำหรับพรีวิวหรือรายงาน) ได้หรือไม่?**

ใช่. คุณสามารถเรนเดอร์รูปทรง SmartArt ไปยัง [raster formats](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartart/get_image/) หรือไปยัง [SVG](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartart/write_as_svg/) สำหรับผลลัพธ์เวกเตอร์ขยายได้ ทำให้เหมาะสำหรับภาพขนาดย่อ, รายงาน, หรือการใช้บนเว็บ