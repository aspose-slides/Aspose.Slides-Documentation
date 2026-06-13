---
title: หมึก
type: docs
weight: 180
url: /th/cpp/examples/elements/ink/
keywords:
- ตัวอย่างโค้ด
- หมึก
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ทำงานกับหมึกใน Aspose.Slides for C++: วาด, นำเข้า, และแก้ไขเส้น, ปรับสีและความกว้าง, และส่งออกเป็น PPT, PPTX, และ ODP โดยใช้ตัวอย่าง C++."
---
บทความนี้ให้ตัวอย่างการเข้าถึงรูปร่างหมึกที่มีอยู่แล้วและการลบออกโดยใช้ **Aspose.Slides for C++**.

> ❗ **หมายเหตุ:** รูปร่างหมึกแสดงถึงการป้อนข้อมูลจากอุปกรณ์พิเศษ. Aspose.Slides ไม่สามารถสร้างลบใหม่ของหมึกโดยโปรแกรมได้, แต่คุณสามารถอ่านและแก้ไขหมึกที่มีอยู่แล้ว.

## **เข้าถึงหมึก**

อ่านแท็กจากรูปร่างหมึกแรกบนสไลด์.

```cpp
static void AccessInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shape(0);
    if (ObjectExt::Is<IInk>(shape))
    {
        auto inkShape = ExplicitCast<IInk>(shape);
        auto tags = inkShape->get_CustomData()->get_Tags();
        if (tags->get_Count() > 0)
        {
            auto tagName = tags->GetNameByIndex(0);
            // ใช้ tagName ตามต้องการ.
        }
    }

    presentation->Dispose();
}
```

## **ลบหมึก**

ลบรูปร่างหมึกจากสไลด์หากมีอยู่.

```cpp
static void RemoveInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto ink = SharedPtr<IInk>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IInk>(shape))
        {
            ink = ExplicitCast<IInk>(shape);
            break;
        }
    }
    if (ink != nullptr)
    {
        slide->get_Shapes()->Remove(ink);
    }

    presentation->Dispose();
}
```