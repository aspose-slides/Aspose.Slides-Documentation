---
title: สไลด์เลเอาต์
type: docs
weight: 20
url: /th/cpp/examples/elements/layout-slide/
keywords:
- ตัวอย่างโค้ด
- สไลด์เลเอาต์
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ควบคุมสไลด์เลเอาต์ใน Aspose.Slides for C++: เลือก ใช้งาน และปรับแต่งเลเอาต์สไลด์, ตัวจัดเก็บตำแหน่ง, และมาสเตอร์ด้วยตัวอย่าง C++ สำหรับการนำเสนอรูปแบบ PPT, PPTX, และ ODP"
---
บทความนี้แสดงวิธีทำงานกับ **Layout Slides** ใน Aspose.Slides for C++. สไลด์เลเอาต์กำหนดการออกแบบและการจัดรูปแบบที่สไลด์ปกติสืบทอดมา คุณสามารถเพิ่ม, เข้าถึง, คัดลอก, และลบสไลด์เลเอาต์ รวมถึงทำความสะอาดสไลด์ที่ไม่ได้ใช้เพื่อ ลดขนาดการนำเสนอได้

## **เพิ่มสไลด์เลเอาต์**

คุณสามารถสร้างสไลด์เลเอาต์แบบกำหนดเองเพื่อกำหนดการจัดรูปแบบที่นำกลับมาใช้ใหม่ได้ ตัวอย่างเช่น คุณอาจเพิ่มกล่องข้อความที่ปรากฏบนทุกสไลด์ที่ใช้เลเอาต์นี้

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // สร้างสไลด์เลเอาต์ที่มีประเภทเลเอาต์แบบว่างเปล่าและชื่อที่กำหนดเอง.
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // เพิ่มกล่องข้อความลงในสไลด์เลเอาต์.
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // เพิ่มสไลด์สองสไลด์โดยใช้เลเอาต์นี้; ทั้งสองจะสืบทอดข้อความจากเลเอาต์.
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Note 1:** สไลด์เลเอาต์ทำหน้าที่เป็นแม่แบบสำหรับสไลด์แต่ละชิ้น คุณสามารถกำหนดองค์ประกอบทั่วไปเพียงครั้งเดียวและนำกลับมาใช้ใหม่ในหลายสไลด์

> 💡 **Note 2:** เมื่อคุณเพิ่มรูปทรงหรือข้อความลงในสไลด์เลเอาต์ สไลด์ทั้งหมดที่อิงจากเลเอาต์นั้นจะอัตโนมัติแสดงเนื้อหา المشترกนี้  
> ภาพหน้าจอด้านล่างแสดงสองสไลด์ที่แต่ละสไลด์สืบทอดกล่องข้อความจากสไลด์เลเอาต์เดียวกัน

![สไลด์ที่สืบทอดเนื้อหาเลเอาต์](layout-slide-result.png)

## **เข้าถึงสไลด์เลเอาต์**

สไลด์เลเอาต์สามารถเข้าถึงได้โดยใช้ดัชนีหรือโดยประเภทเลเอาต์ (เช่น `Blank`, `Title`, `SectionHeader`, เป็นต้น).

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // เข้าถึงสไลด์เลเอาต์โดยดัชนี.
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // เข้าถึงสไลด์เลเอาต์โดยประเภท.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **ลบสไลด์เลเอาต์**

คุณสามารถลบสไลด์เลเอาต์เฉพาะได้หากไม่ต้องการใช้งานต่อ

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // รับสไลด์เลเอาต์ตามประเภทและลบออก.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **ลบสไลด์เลเอาต์ที่ไม่ได้ใช้**

เพื่อทำให้ขนาดการนำเสนอถูกลง คุณอาจต้องการลบสไลด์เลเอาต์ที่ไม่ได้ถูกใช้โดยสไลด์ปกติใดๆ

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // ลบสไลด์เลเอาต์ทั้งหมดที่ไม่ได้อ้างอิงโดยสไลด์ใดๆ อย่างอัตโนมัติ.
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **คัดลอกสไลด์เลเอาต์**

คุณสามารถทำสำเนาสไลด์เลเอาต์โดยใช้เมธอด `AddClone`.

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // รับสไลด์เลเอาต์ที่มีอยู่ตามประเภท.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // คัดลอกสไลด์เลเอาต์ไปยังตำแหน่งสุดท้ายของคอลเลกชันสไลด์เลเอาต์.
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **สรุป:** สไลด์เลเอาต์เป็นเครื่องมือที่มีประสิทธิภาพสำหรับการจัดการการจัดรูปแบบที่สอดคล้องกันในหลายสไลด์ Aspose.Slides ให้การควบคุมเต็มที่ในการสร้าง, จัดการ, และเพิ่มประสิทธิภาพสไลด์เลเอาต์.