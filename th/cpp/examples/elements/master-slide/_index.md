---
title: มาสเตอร์สไลด์
type: docs
weight: 30
url: /th/cpp/examples/elements/master-slide/
keywords:
- ตัวอย่างโค้ด
- มาสเตอร์สไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "สำรวจตัวอย่างมาสเตอร์สไลด์ของ Aspose.Slides for C++: สร้าง แก้ไข และออกแบบมาสเตอร์, ตัวแสดงตำแหน่ง, และธีมใน PPT, PPTX, และ ODP ด้วยโค้ด C++ ที่ชัดเจน."
---
มาสเตอร์สไลด์เป็นระดับบนสุดของลำดับชั้นการสืบทอดสไลด์ใน PowerPoint. A **master slide** กำหนดองค์ประกอบการออกแบบทั่วไป เช่น พื้นหลัง, โลโก้, และการจัดรูปแบบข้อความ. **Layout slides** สืบทอดจาก master slides, และ **normal slides** สืบทอดจาก layout slides.

บทความนี้แสดงวิธีสร้าง, แก้ไข และจัดการมาสเตอร์สไลด์โดยใช้ Aspose.Slides for C++.

## **เพิ่มมาสเตอร์สไลด์**

ตัวอย่างนี้แสดงวิธีสร้างมาสเตอร์สไลด์ใหม่โดยการคัดลอกมาสเตอร์สไลด์เริ่มต้น. จากนั้นเพิ่มแบนเนอร์ชื่อบริษัทไปยังสไลด์ทั้งหมดผ่านการสืบทอดเลย์เอาต์.

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // คัดลอกมาสเตอร์สไลด์เริ่มต้น.
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // เพิ่มแบนเนอร์ชื่อบริษัทที่ด้านบนของมาสเตอร์สไลด์.
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // กำหนดมาสเตอร์สไลด์ใหม่ให้กับสไลด์เลย์เอาต์.
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // กำหนดสไลด์เลย์เอาต์ให้กับสไลด์แรกในงานนำเสนอ.
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Note 1:** มาสเตอร์สไลด์ให้วิธีการใช้แบรนด์หรือองค์ประกอบการออกแบบที่สอดคล้องกันทั่วทุกสไลด์. การเปลี่ยนแปลงใด ๆ ที่ทำกับมาสเตอร์จะถูกสะท้อนโดยอัตโนมัติบนเลย์เอาต์และสไลด์ปกติที่ขึ้นอยู่.  
> 💡 **Note 2:** รูปร่างหรือการจัดรูปแบบใด ๆ ที่เพิ่มลงในมาสเตอร์สไลด์จะถูกสืบทอดโดยสไลด์เลย์เอาต์และต่อด้วยสไลด์ปกติทั้งหมดที่ใช้เลย์เอาต์นั้น.  
> ภาพด้านล่างแสดงให้เห็นว่ากล่องข้อความที่เพิ่มบนมาสเตอร์สไลด์จะถูกเรนเดอร์โดยอัตโนมัติบนสไลด์สุดท้าย.

![ตัวอย่างการสืบทอดมาสเตอร์](master-slide-banner.png)

## **เข้าถึงมาสเตอร์สไลด์**

คุณสามารถเข้าถึงมาสเตอร์สไลด์โดยใช้คอลเลกชันมาสเตอร์ของงานนำเสนอ. นี่คือวิธีดึงและทำงานกับมัน:

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // เปลี่ยนประเภทพื้นหลัง.
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **ลบมาสเตอร์สไลด์**

มาสเตอร์สไลด์สามารถลบได้โดยใช้ดัชนีหรือโดยอ้างอิง.

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // ลบมาสเตอร์สไลด์โดยดัชนี.
    presentation->get_Masters()->RemoveAt(0);

    // ลบมาสเตอร์สไลด์โดยอ้างอิง.
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้**

งานนำเสนอบางส่วนมีมาสเตอร์สไลด์ที่ไม่ได้ใช้งาน. การลบสไลด์เหล่านี้สามารถช่วยลดขนาดไฟล์ได้.

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้ทั้งหมด (รวมถึงสไลด์ที่ถูกทำเครื่องหมายว่า Preserve).
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```