---
title: ตัวเชื่อม
type: docs
weight: 190
url: /th/cpp/examples/elements/connector/
keywords:
- ตัวอย่างโค้ด
- ตัวเชื่อม
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม เส้นเชื่อม และปรับแต่งสไตล์ของตัวเชื่อมระหว่างรูปร่างโดยใช้ Aspose.Slides for C++ พร้อมตัวอย่างสำหรับการนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้แสดงให้เห็นวิธีเชื่อมต่อรูปร่างด้วยตัวเชื่อมและเปลี่ยนเป้าหมายของพวกมันโดยใช้ **Aspose.Slides for C++**.

## **เพิ่มตัวเชื่อม**

แทรกรูปแบบตัวเชื่อมระหว่างสองจุดบนสไลด์.

```cpp
static void AddConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);
    presentation->Dispose();
}
```

## **เข้าถึงตัวเชื่อม**

ดึงรูปแบบตัวเชื่อมตัวแรกที่เพิ่มเข้ามาบนสไลด์.

```cpp
static void AccessConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    // เข้าถึงตัวเชื่อมตัวแรกบนสไลด์.
    auto connector = SharedPtr<IConnector>();
    for (auto&& shape :  slide->get_Shapes())
    {
        if (ObjectExt::Is<IConnector>(shape))
        {
            connector = ExplicitCast<IConnector>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **ลบตัวเชื่อม**

ลบตัวเชื่อมออกจากสไลด์.

```cpp
static void RemoveConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    slide->get_Shapes()->Remove(connector);

    presentation->Dispose();
}
```

## **เชื่อมต่อรูปร่างใหม่**

แนบตัวเชื่อมกับสองรูปร่างโดยกำหนดเป้าหมายเริ่มต้นและสิ้นสุด.

```cpp
static void ReconnectShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
    auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 50, 50);
    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    connector->set_StartShapeConnectedTo(shape1);
    connector->set_EndShapeConnectedTo(shape2);

    presentation->Dispose();
}
```