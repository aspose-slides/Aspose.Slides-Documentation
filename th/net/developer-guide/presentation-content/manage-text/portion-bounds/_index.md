---
title: รับขอบเขตส่วนข้อความจากงานนำเสนอใน .NET
linktitle: ขอบเขตส่วนข้อความ
type: docs
weight: 47
url: /th/net/portion-bounds/
keywords:
- ขอบเขตส่วนข้อความ
- ส่วนข้อความ
- ส่วนของข้อความ
- พิกัดข้อความ
- ตำแหน่งข้อความ
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีดึงขอบเขตส่วนข้อความในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

ส่วนข้อความ (text portion) แสดงถึงส่วนย่อยของข้อความภายในย่อหน้าและทำให้คุณสามารถทำงานกับส่วนนั้นแยกจากเนื้อหารอบข้างได้ ใน Aspose.Slides, portion สามารถใช้เมื่อคุณต้องการดึงขอบเขตของส่วนข้อความ, นำรูปแบบไปใช้กับเพียงบางส่วนของย่อหน้า, หรือควบคุมพฤติกรรมของข้อความในระดับที่ละเอียดกว่านั้น. บทความนี้แสดงวิธีการรับสี่เหลี่ยมบังการของ portion โดยใช้ [IPortion.GetRect](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/getrect/). นอกจากนี้ยังแสดงวิธีการรับพิกัดของจุดเริ่มต้นของ portion โดยใช้ [IPortion.GetCoordinates](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/getcoordinates/). รวมทั้งเน้นสถานการณ์ทั่วไปที่เกี่ยวกับ portion เช่น การใส่ไฮเปอร์ลิงก์ให้กับส่วนข้อความเดียว, การทำความเข้าใจว่าการจัดรูปแบบถูกแก้ไขผ่าน portion, paragraph, text frame, และการสืบทอดธีมอย่างไร, และการจัดการกรณีที่ฟอนต์ที่ระบุไม่พร้อมใช้งาน.

## **รับขอบเขตของส่วนข้อความ**

ใช้ [IPortion.GetRect](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/getrect/) เพื่อดึงสี่เหลี่ยมบังการของส่วนข้อความ:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **รับพิกัดของส่วนข้อความ**

ใช้ [IPortion.GetCoordinates](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/getcoordinates/) เพื่อดึงพิกัดของจุดเริ่มต้นของส่วนข้อความ:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใส่ไฮเปอร์ลิงก์ให้กับส่วนหนึ่งของข้อความภายในย่อหน้าเดียวได้หรือไม่?**

ได้, คุณสามารถ [assign a hyperlink](/slides/th/net/manage-hyperlinks/) ให้กับ portion เดียวได้; เฉพาะส่วนนั้นเท่านั้นจะคลิกได้, ไม่ใช่ทั้งย่อหน้า.

**สไตล์การสืบทอดทำงานอย่างไร: portion จะทับอะไรและอะไรจะถูกนำมาจาก paragraph หรือ text frame?**

คุณสมบัติระดับ portion มีลำดับความสำคัญสูงสุด หากคุณสมบัตินั้นไม่ได้กำหนดบน [IPortion](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/), Aspose.Slides จะนำมาจาก [IParagraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/). หากยังไม่ได้กำหนดที่นั่นด้วย, Aspose.Slides จะใช้สไตล์ของ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) หรือ [theme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/theme/) .

**จะเกิดอะไรขึ้นหากฟอนต์ที่ระบุสำหรับ portion ไม่พบบนเครื่องหรือเซิร์ฟเวอร์เป้าหมาย?**

[Font substitution rules](/slides/th/net/font-selection-sequence/) จะถูกนำมาใช้ ข้อความอาจจะเปลี่ยนแปลงการไหล: เมตริกซ์, การใส่ hyphenation, และความกว้างอาจเปลี่ยนแปลง ซึ่งสำคัญต่อการกำหนดตำแหน่งอย่างแม่นยำ.

**ฉันสามารถตั้งค่าความโปร่งใสของการเติมข้อความหรือการไล่สีสำหรับ portion โดยแยกจากส่วนอื่นของย่อหน้าได้หรือไม่?**

ได้, สีข้อความ, การเติม, และความโปร่งใสที่ระดับ [IPortion](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/) สามารถแตกต่างจากส่วนที่อยู่ใกล้เคียงได้.