---
title: กลุ่มรูปร่าง
type: docs
weight: 170
url: /th/cpp/examples/elements/group-shape/
keywords:
- ตัวอย่างโค้ด
- กลุ่มรูปร่าง
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "จัดการกลุ่มรูปร่างใน Aspose.Slides for C++: สร้าง, ซ้อน, จัดแนว, เปลี่ยนลำดับ, และกำหนดรูปแบบกลุ่มรูปร่างด้วยตัวอย่าง C++ ในการนำเสนอ PPT, PPTX, และ ODP"
---
ตัวอย่างการสร้างกลุ่มของรูปร่าง การเข้าถึง การแยกกลุ่ม และการลบโดยใช้ **Aspose.Slides for C++**.

## **เพิ่มกลุ่มรูปร่าง**

สร้างกลุ่มที่มีรูปร่างพื้นฐานสองรูป.

```cpp
static void AddGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
    group->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 60, 0, 50, 50);

    presentation->Dispose();
}
```

## **เข้าถึงกลุ่มรูปร่าง**

ดึงกลุ่มรูปร่างแรกจากสไลด์.

```cpp
static void AccessGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    auto firstGroup = SharedPtr<IGroupShape>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IGroupShape>(shape))
        {
            firstGroup = ExplicitCast<IGroupShape>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **ลบกลุ่มรูปร่าง**

ลบกลุ่มรูปร่างออกจากสไลด์.

```cpp
static void RemoveGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();

    slide->get_Shapes()->Remove(group);

    presentation->Dispose();
}
```

## **แยกกลุ่มรูปร่าง**

ย้ายรูปร่างออกจากคอนเทนเนอร์ของกลุ่ม.

```cpp
static void UngroupShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    auto rect = group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    // ย้ายรูปร่างออกจากกลุ่ม.
    slide->get_Shapes()->AddClone(rect);
    group->get_Shapes()->Remove(rect);

    presentation->Dispose();
}
```