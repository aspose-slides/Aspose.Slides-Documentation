---
title: การเคลื่อนไหว
type: docs
weight: 100
url: /th/cpp/examples/elements/animation/
keywords:
- ตัวอย่างโค้ด
- การเคลื่อนไหว
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "สำรวจตัวอย่างการเคลื่อนไหวของ Aspose.Slides for C++: การเพิ่ม, การจัดลำดับ, และการปรับแต่งเอฟเฟกต์และการเปลี่ยนเฟรมด้วย C++ สำหรับการนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้แสดงวิธีสร้างการเคลื่อนไหวแบบง่ายและจัดการลำดับของพวกมันโดยใช้ **Aspose.Slides for C++**.

## **เพิ่มการเคลื่อนไหว**

สร้างรูปสี่เหลี่ยมและใช้เอฟเฟกต์ค่อยลายเข้าเมื่อคลิก.

```cpp
static void AddAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    // เอฟเฟกต์ค่อยหายไป.
    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    presentation->Dispose();
}
```

## **เข้าถึงการเคลื่อนไหว**

ดึงเอฟเฟ็กต์การเคลื่อนไหวแรกจากไทม์ไลน์ของสไลด์.

```cpp
static void AccessAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // เข้าถึงเอฟเฟกต์การเคลื่อนไหวแรก.
    auto effect = slide->get_Timeline()->get_MainSequenceEffect(0);

    presentation->Dispose();
}
```

## **ลบการเคลื่อนไหว**

ลบเอฟเฟ็กต์การเคลื่อนไหวออกจากลำดับ.

```cpp
static void RemoveAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // ลบเอฟเฟกต์.
    slide->get_Timeline()->get_MainSequence()->Remove(effect);

    presentation->Dispose();
}
```

## **ลำดับการเคลื่อนไหว**

เพิ่มเอฟเฟ็กต์หลายรายการและสาธิตลำดับที่การเคลื่อนไหวเกิดขึ้น.

```cpp
static void SequenceAnimations()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);
    auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 200, 50, 100, 100);

    auto sequence = slide->get_Timeline()->get_MainSequence();
    sequence->AddEffect(shape1, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
    sequence->AddEffect(shape2, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);

    presentation->Dispose();
}
```