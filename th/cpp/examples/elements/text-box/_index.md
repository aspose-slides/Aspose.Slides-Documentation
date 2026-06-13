---
title: กล่องข้อความ
type: docs
weight: 40
url: /th/cpp/examples/elements/text-box/
keywords:
- ตัวอย่างโค้ด
- กล่องข้อความ
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ทำงานกับกล่องข้อความใน Aspose.Slides สำหรับ C++: เพิ่ม, จัดรูปแบบ, จัดแนว, ทำการห่อ, ปรับอัตโนมัติ, และกำหนดสไตล์ข้อความโดยใช้ C++ สำหรับงานนำเสนอ PPT, PPTX, และ ODP"
---
ใน Aspose.Slides, **กล่องข้อความ** จะถูกแทนด้วย `AutoShape` แทบทุกรูปทรงสามารถบรรจุตัวอักษรได้ แต่กล่องข้อความทั่วไปจะไม่มีการเติมสีหรือขอบและจะแสดงเฉพาะข้อความเท่านั้น

คู่มือนี้อธิบายวิธีการเพิ่ม, เข้าถึง และลบกล่องข้อความโดยใช้โปรแกรม

## **เพิ่มกล่องข้อความ**

กล่องข้อความเป็นเพียง `AutoShape` ที่ไม่มีการเติมสีหรือขอบและมีข้อความที่จัดรูปแบบอยู่ นี่คือตัวอย่างการสร้าง:

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // สร้างรูปสี่เหลี่ยม (ค่าปกติคือเติมสีพร้อมขอบและไม่มีข้อความ).
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // ลบการเติมสีและขอบเพื่อให้ดูเหมือนกล่องข้อความทั่วไป.
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // กำหนดรูปแบบข้อความ.
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // กำหนดเนื้อหาข้อความจริง.
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **หมายเหตุ:** `AutoShape` ใด ๆ ที่มี `TextFrame` ที่ไม่ว่างเปล่าสามารถทำหน้าที่เป็นกล่องข้อความได้

## **เข้าถึงกล่องข้อความตามเนื้อหา**

เพื่อค้นหากล่องข้อความทั้งหมดที่มีคีย์เวิร์ดเฉพาะ (เช่น "Slide") ให้วนลูปผ่านรูปทรงทั้งหมดและตรวจสอบข้อความของมัน:

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // เฉพาะ AutoShape เท่านั้นที่สามารถบรรจุตัวอักษรที่แก้ไขได้.
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // ทำบางอย่างกับกล่องข้อความที่ตรงกัน.
            }
        }
    }

    presentation->Dispose();
}
```

## **ลบกล่องข้อความตามเนื้อหา**

ตัวอย่างนี้ค้นหาและลบกล่องข้อความทั้งหมดบนสไลด์แรกที่มีคีย์เวิร์ดเฉพาะ:

```cpp
static void RemoveTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    auto shapesToRemove = MakeObject<List<SharedPtr<IShape>>>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            if (autoShape->get_TextFrame()->get_Text().Contains(u"Slide"))
            {
                shapesToRemove->Add(shape);
            }
        }
    }

    for (auto&& shape : shapesToRemove)
    {
        slide->get_Shapes()->Remove(shape);
    }

    presentation->Dispose();
}
```

> 💡 **เคล็ดลับ:** ควรสร้างสำเนาของคอลเลกชันรูปทรรก่อนทำการแก้ไขในขณะวนลูปเพื่อหลีกเลี่ยงข้อผิดพลาดการแก้ไขคอลเลกชัน.