---
title: ส่วน
type: docs
weight: 90
url: /th/cpp/examples/elements/section/
keywords:
- ตัวอย่างโค้ด
- ส่วน
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "จัดการส่วนสไลด์ใน Aspose.Slides สำหรับ C++: สร้าง, เปลี่ยนชื่อ, เรียงลำดับใหม่, และจัดกลุ่มสไลด์ด้วยตัวอย่าง C++ สำหรับ PPT, PPTX, และ ODP."
---
ตัวอย่างการจัดการส่วนของงานนำเสนอ — เพิ่ม, เข้าถึง, ลบ และเปลี่ยนชื่อโดยใช้ **Aspose.Slides for C++** อย่างโปรแกรมเมติก

## **เพิ่มส่วน**

สร้างส่วนที่เริ่มต้นจากสไลด์เฉพาะหนึ่งหน้า.

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // ระบุสไลด์ที่ทำเครื่องหมายเป็นจุดเริ่มต้นของส่วน.
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **เข้าถึงส่วน**

อ่านข้อมูลส่วนจากงานนำเสนอ.

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // เข้าถึงส่วนตามดัชนี.
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **ลบส่วน**

ลบส่วนที่เพิ่มไว้ก่อนหน้านี้.

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // ลบส่วนแรก.
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **เปลี่ยนชื่อส่วน**

เปลี่ยนชื่อของส่วนที่มีอยู่.

```cpp
static void RenameSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"Old Name", slide);

    auto section = presentation->get_Section(0);
    section->set_Name(u"New Name");

    presentation->Dispose();
}
```