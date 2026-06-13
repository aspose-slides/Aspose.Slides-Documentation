---
title: ไฮเปอร์ลิงก์
type: docs
weight: 130
url: /th/cpp/examples/elements/hyperlink/
keywords:
- ตัวอย่างโค้ด
- ไฮเปอร์ลิงก์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เพิ่มและจัดการไฮเปอร์ลิงก์ใน Aspose.Slides for C++: เชื่อมโยงข้อความ, รูปร่าง, และรูปภาพ, ตั้งค่าเป้าหมายและการกระทำสำหรับ PPT, PPTX, และ ODP พร้อมตัวอย่าง C++."
---
บทความนี้แสดงวิธีการเพิ่ม, เข้าถึง, ลบ และอัปเดตไฮเปอร์ลิงก์บนรูปทรงโดยใช้ **Aspose.Slides for C++**.

## **เพิ่มไฮเปอร์ลิงก์**

สร้างรูปสี่เหลี่ยมผืนผ้าพร้อมไฮเปอร์ลิงก์ที่ชี้ไปยังเว็บไซต์ภายนอก.

```cpp
static void AddHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    presentation->Dispose();
}
```

## **เข้าถึงไฮเปอร์ลิงก์**

อ่านข้อมูลไฮเปอร์ลิงก์จากส่วนข้อความของรูปทรง.

```cpp
static void AccessHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    auto hyperlink = textPortion->get_PortionFormat()->get_HyperlinkClick();

    presentation->Dispose();
}
```

## **ลบไฮเปอร์ลิงก์**

ลบไฮเปอร์ลิงก์ออกจากข้อความของรูปทรง.

```cpp
static void RemoveHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    textPortion->get_PortionFormat()->set_HyperlinkClick(nullptr);

    presentation->Dispose();
}
```

## **อัปเดตไฮเปอร์ลิงก์**

เปลี่ยนเป้าหมายของไฮเปอร์ลิงก์ที่มีอยู่ ใช้ `HyperlinkManager` เพื่อแก้ไขข้อความที่มีไฮเปอร์ลิงก์อยู่แล้ว ซึ่งจำลองพฤติกรรมการอัปเดตไฮเปอร์ลิงก์ของ PowerPoint อย่างปลอดภัย.

```cpp
static void UpdateHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://old.example.com"));

    // การเปลี่ยนไฮเปอร์ลิงก์ภายในข้อความที่มีอยู่ควรทำผ่าน
    // HyperlinkManager แทนการตั้งค่าคุณสมบัติโดยตรง.
    // นี้จำลองวิธีที่ PowerPoint อัปเดตไฮเปอร์ลิงก์อย่างปลอดภัย.
    textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://new.example.com");

    presentation->Dispose();
}
```