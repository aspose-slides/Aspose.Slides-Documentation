---
title: การเปลี่ยนสไลด์
type: docs
weight: 110
url: /th/cpp/examples/elements/slide-transition/
keywords:
- ตัวอย่างโค้ด
- การเปลี่ยนสไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ควบคุมการเปลี่ยนสไลด์ใน Aspose.Slides for C++: เพิ่ม, ปรับแต่ง และจัดลำดับเอฟเฟกต์และระยะเวลา ด้วยตัวอย่าง C++ สำหรับงานนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้แสดงวิธีการประยุกต์ใช้เอฟเฟกต์การเปลี่ยนสไลด์และการตั้งเวลาโดยใช้ **Aspose.Slides for C++**.

## **เพิ่มการเปลี่ยนสไลด์**

ใช้เอฟเฟกต์การเปลี่ยนแบบค่อยหายไปบนสไลด์แรก.

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // ใช้การเปลี่ยนแบบค่อยหายไป.
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **เข้าถึงการเปลี่ยนสไลด์**

อ่านประเภทการเปลี่ยนที่กำหนดไว้ในสไลด์ปัจจุบัน.

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // เข้าถึงประเภทการเปลี่ยน.
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **ลบการเปลี่ยนสไลด์**

ลบเอฟเฟกต์การเปลี่ยนใด ๆ โดยตั้งค่าประเภทเป็น `None`.

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // ลบการเปลี่ยนโดยตั้งค่าเป็น None.
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **ตั้งระยะเวลาเปลี่ยนสไลด์**

ระบุระยะเวลาที่สไลด์จะแสดงก่อนที่จะเลื่อนต่อโดยอัตโนมัติ.

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // ในมิลลิวินาที.

    presentation->Dispose();
}
```