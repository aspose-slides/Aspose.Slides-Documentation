---
title: SmartArt
type: docs
weight: 140
url: /th/cpp/examples/elements/smart-art/
keywords:
- ตัวอย่างโค้ด
- SmartArt
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ทำงานกับ SmartArt ใน Aspose.Slides สำหรับ C++: สร้าง แก้ไข แปลง และออกแบบแผนภาพด้วย C++ สำหรับงานนำเสนอ PowerPoint และ OpenDocument"
---
บทความนี้อธิบายวิธีเพิ่มกราฟิก SmartArt, เข้าถึง, ลบ, และเปลี่ยนเลย์เอาต์โดยใช้ **Aspose.Slides for C++**.

## **เพิ่ม SmartArt**

แทรกกราฟิก SmartArt โดยใช้หนึ่งในเลย์เอาต์ที่ติดมากับระบบ.

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **เข้าถึง SmartArt**

ดึงอ็อบเจกต์ SmartArt ตัวแรกบนสไลด์.

```cpp
static void AccessSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    auto firstSmartArt = SharedPtr<ISmartArt>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<ISmartArt>(shape))
        {
            firstSmartArt = ExplicitCast<ISmartArt>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **ลบ SmartArt**

ลบรูปทรง SmartArt ออกจากสไลด์.

```cpp
static void RemoveSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    slide->get_Shapes()->Remove(smartArt);

    presentation->Dispose();
}
```

## **เปลี่ยนเลย์เอาต์ SmartArt**

อัปเดตประเภทเลย์เอาต์ของกราฟิก SmartArt ที่มีอยู่.

```cpp
static void ChangeSmartArtLayout()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicBlockList);
    smartArt->set_Layout(SmartArtLayoutType::VerticalPictureList);

    presentation->Dispose();
}
```