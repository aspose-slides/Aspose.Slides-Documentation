---
title: สไลด์
type: docs
weight: 10
url: /th/cpp/examples/elements/slide/
keywords:
- ตัวอย่างโค้ด
- สไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ควบคุมสไลด์ใน Aspose.Slides for C++: สร้าง, ทำสำเนา, เปลี่ยนลำดับ, ปรับขนาด, ตั้งพื้นหลัง, และใช้การเปลี่ยนแบบกับ C++ สำหรับการนำเสนอ PPT, PPTX, และ ODP."
---
บทความนี้ให้ตัวอย่างหลายชุดที่แสดงวิธีการทำงานกับสไลด์โดยใช้ **Aspose.Slides for C++** คุณจะได้เรียนรู้วิธีเพิ่ม, เข้าถึง, ทำสำเนา, เรียงลำดับใหม่ และลบสไลด์โดยใช้คลาส `Presentation`.

แต่ละตัวอย่างด้านล่างประกอบด้วยคำอธิบายสั้น ๆ ตามด้วยโค้ดสแนปช็อตใน C++.

## **Add a Slide**

เพื่อเพิ่มสไลด์ใหม่ คุณต้องเลือกเค้าโครงก่อน ในตัวอย่างนี้เราใช้เค้าโครง `Blank` และเพิ่มสไลด์ว่างลงในพรีเซนเทชัน

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡 **หมายเหตุ:** แต่ละเค้าโครงสไลด์มาจากมาสเตอร์สไลด์ ซึ่งกำหนดการออกแบบโดยรวมและโครงสร้างของตัวแทนภาพ ภาพด้านล่างแสดงให้เห็นว่า มาสเตอร์สไลด์และเค้าโครงที่เกี่ยวข้องจัดเรียงอย่างไรใน PowerPoint.

![ความสัมพันธ์ระหว่างมาสเตอร์และเค้าโครง](master-layout-slide.png)

## **Access Slides by Index**

คุณสามารถเข้าถึงสไลด์โดยใช้ดัชนีของมัน, หรือค้นหาดัชนีของสไลด์จากการอ้างอิง นี่เป็นประโยชน์สำหรับการวนลูปหรือการแก้ไขสไลด์เฉพาะ

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // เพิ่มสไลด์เปล่าอีกหนึ่งสไลด์.
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // เข้าถึงสไลด์โดยใช้ดัชนี.
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // รับดัชนีสไลด์จากการอ้างอิงแล้วเข้าถึงโดยใช้ดัชนี.
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **Clone a Slide**

ตัวอย่างนี้แสดงวิธีทำสำเนาสไลด์ที่มีอยู่ สไลด์ที่ทำสำเนาจะถูกเพิ่มโดยอัตโนมัติไปที่ตำแหน่งสุดท้ายของคอลเลกชันสไลด์

```cpp
static void CloneSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    auto clonedSlideIndex = presentation->get_Slides()->IndexOf(clonedSlide);

    presentation->Dispose();
}
```

## **Reorder Slides**

คุณสามารถเปลี่ยนลำดับของสไลด์โดยย้ายสไลด์หนึ่งไปยังดัชนีใหม่ ในกรณีนี้ เราย้ายสไลด์ที่ทำสำเนาไปยังตำแหน่งแรก

```cpp
static void ReorderSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    presentation->get_Slides()->Reorder(0, clonedSlide);

    presentation->Dispose();
}
```

## **Remove a Slide**

เพื่อเอาสไลด์ออก เพียงอ้างอิงสไลด์นั้นและเรียก `Remove` ตัวอย่างนี้เพิ่มสไลด์ที่สองแล้วลบสไลด์ต้นฉบับ ทำให้เหลือเพียงสไลด์ใหม่เท่านั้น

```cpp
static void RemoveSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    auto secondSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

    auto firstSlide = presentation->get_Slide(0);
    presentation->get_Slides()->Remove(firstSlide);

    presentation->Dispose();
}
```