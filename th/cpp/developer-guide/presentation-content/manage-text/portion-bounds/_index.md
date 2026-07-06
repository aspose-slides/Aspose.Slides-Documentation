---
title: "รับขอบเขตส่วนข้อความจากงานนำเสนอใน C++"
linktitle: "ขอบเขตส่วนข้อความ"
type: docs
weight: 47
url: /th/cpp/portion-bounds/
keywords:
- "ขอบเขตส่วนข้อความ"
- "ส่วนข้อความ"
- "ส่วนของข้อความ"
- "พิกัดข้อความ"
- "ตำแหน่งข้อความ"
- "PowerPoint"
- "งานนำเสนอ"
- "C++"
- "Aspose.Slides"
description: "เรียนรู้วิธีดึงขอบเขตส่วนข้อความในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

ส่วนข้อความเป็นตัวแทนของส่วนย่อยของข้อความในย่อหน้าและทำให้คุณสามารถทำงานกับส่วนนั้นได้อย่างอิสระจากเนื้อหาบริเวณโดยรอบ. ใน Aspose.Slides, ส่วนข้อความสามารถใช้เมื่อคุณต้องการดึงพิกัดของส่วนข้อความ, ใช้การจัดรูปแบบกับเพียงบางส่วนของย่อหน้า, หรือควบคุมพฤติกรรมของข้อความในระดับที่ละเอียดขึ้น.

บทความนี้แสดงวิธีการรับสี่เหลี่ยมขอบของส่วนข้อความโดยใช้ [IPortion::GetRect](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/getrect/). นอกจากนี้ยังแสดงวิธีการรับพิกัดของจุดเริ่มต้นของส่วนข้อความโดยใช้ [IPortion::GetCoordinates](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/getcoordinates/). นอกจากนี้ยังเน้นสถานการณ์ทั่วไปที่เกี่ยวกับส่วนข้อความ เช่น การใส่ไฮเปอร์ลิงก์ให้กับส่วนข้อความเดียว, การทำความเข้าใจว่าการจัดรูปแบบผ่านส่วนข้อความ, ย่อหน้า, กรอบข้อความ และการสืบทอดธีมทำงานอย่างไร, และการจัดการกรณีที่ฟอนต์ที่ระบุไม่มีอยู่.

## **รับขอบเขตของส่วนข้อความ**

ใช้ [IPortion::GetRect](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/getrect/) เพื่อดึงสี่เหลี่ยมขอบของส่วนข้อความ:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **รับพิกัดของส่วนข้อความ**

ใช้ [IPortion::GetCoordinates](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/getcoordinates/) เพื่อดึงพิกัดของจุดเริ่มต้นของส่วนข้อความ:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **FAQ**

**ฉันสามารถใส่ไฮเปอร์ลิงก์ให้กับบางส่วนของข้อความในย่อหน้าเดียวได้หรือไม่?**

ได้, คุณสามารถ [กำหนดไฮเปอร์ลิงก์](/slides/th/cpp/manage-hyperlinks/) ให้กับส่วนข้อความแต่ละส่วน; เพียงส่วนนั้นเท่านั้นที่จะสามารถคลิกได้, ไม่ใช่ย่อหน้าทั้งหมด.

**การสืบทอดสไตล์ทำงานอย่างไร: ส่วนข้อความจะเขียนทับอะไรบ้าง, แล้วอะไรมาจากย่อหน้าหรือกรอบข้อความ?**

คุณสมบัติระดับ Portion มีลำดับความสำคัญสูงสุด. หากคุณสมบัติไม่ได้ตั้งค่าที่ [IPortion](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/), Aspose.Slides จะดึงมาจาก [IParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/). หากยังไม่ได้ตั้งค่าที่นั่นด้วย, Aspose.Slides จะใช้สไตล์จาก [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) หรือ [theme](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/theme/).

**จะเกิดอะไรขึ้นหากฟอนต์ที่ระบุสำหรับส่วนข้อความไม่มีอยู่บนเครื่องหรือเซิร์ฟเวอร์เป้าหมาย?**

[gกฎการทดแทนฟอนต์](/slides/th/cpp/font-selection-sequence/) จะถูกนำมาใช้. ข้อความอาจเปลี่ยนตำแหน่ง: ตัวชี้วัด, การแบ่งคำ, และความกว้างอาจเปลี่ยน, ซึ่งสำคัญต่อการวางตำแหน่งที่แม่นยำ.

**ฉันสามารถตั้งค่าความโปร่งใสของการเติมข้อความหรือไล่สีสำหรับส่วนข้อความโดยแยกจากย่อหน้าอื่นได้หรือไม่?**

ได้, สีข้อความ, การเติม, และความโปร่งใสที่ระดับ [IPortion](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/) สามารถแตกต่างจากส่วนใกล้เคียงได้.