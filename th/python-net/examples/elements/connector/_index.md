---
title: คอนเนคเตอร์
type: docs
weight: 190
url: /th/python-net/examples/elements/connector/
keywords:
- คอนเนคเตอร์
- เพิ่มคอนเนคเตอร์
- เข้าถึงคอนเนคเตอร์
- ลบคอนเนคเตอร์
- เชื่อมต่อรูปทรงใหม่
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "วาดและควบคุมคอนเนคเตอร์ใน Python ด้วย Aspose.Slides: เพิ่ม, วางเส้นทาง, ปรับเส้นทางใหม่, ตั้งจุดเชื่อมต่อ, ลูกศรและสไตล์เพื่อเชื่อมโยงรูปทรงใน PPT, PPTX และ ODP."
---
แสดงวิธีเชื่อมต่อรูปทรงด้วยคอนเนคเตอร์และเปลี่ยนเป้าหมายของมันโดยใช้ **Aspose.Slides for Python via .NET**.

## **เพิ่มคอนเนคเตอร์**

แทรกรูปทรงคอนเนคเตอร์ระหว่างจุดสองจุดบนสไลด์.

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # เพิ่มรูปทรงคอนเนคเตอร์แบบโค้ง
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงคอนเนคเตอร์**

ดึงรูปทรงคอนเนคเตอร์ตัวแรกที่เพิ่มลงในสไลด์.

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # เข้าถึงคอนเนคเตอร์แรกบนสไลด์.
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **ลบคอนเนคเตอร์**

ลบคอนเนคเตอร์ออกจากสไลด์.

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # สมมติว่า shape แรกเป็นคอนเนคเตอร์.
        connector = slide.shapes[0]

        # ลบคอนเนคเตอร์.
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **เชื่อมต่อรูปทรงใหม่**

แนบคอนเนคเตอร์กับรูปทรงสองรูปโดยกำหนดเป้าหมายเริ่มต้นและสิ้นสุด.

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # เพิ่มรูปสี่เหลี่ยมจัตุรัสแรก.
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # เพิ่มรูปสี่เหลี่ยมจัตุรัสที่สอง.
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # เพิ่มรูปคอนเนคเตอร์แบบโค้ง.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # เชื่อมต่อส่วนเริ่มต้นของคอนเนคเตอร์กับรูปแรก.
        connector.start_shape_connected_to = shape1
        # เชื่อมต่อส่วนสุดของคอนเนคเตอร์กับรูปที่สอง.
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```