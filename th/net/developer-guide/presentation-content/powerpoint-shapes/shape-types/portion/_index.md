---
title: จัดการส่วนข้อความในงานนำเสนอด้วย .NET
linktitle: ส่วนข้อความ
type: docs
weight: 70
url: /th/net/portion/
keywords:
- ส่วนข้อความ
- ส่วนของข้อความ
- พิกัดข้อความ
- ตำแหน่งข้อความ
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีจัดการส่วนข้อความในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for .NET เพื่อเพิ่มประสิทธิภาพและการปรับแต่ง"
---
## **ภาพรวม**

ข้อความส่วนหนึ่งเป็นส่วนย่อยของข้อความภายในย่อหน้าและอนุญาตให้คุณทำงานกับส่วนนั้นได้โดยอิสระจากเนื้อหาโดยรอบ ใน Aspose.Slides สามารถใช้ส่วนข้อความเมื่อคุณต้องการดึงตำแหน่งของส่วนข้อความ, ใช้การจัดรูปแบบกับเพียงบางส่วนของย่อหน้า, หรือควบคุมพฤติกรรมของข้อความในระดับที่ละเอียดขึ้น

บทความนี้แสดงวิธีการรับค่าพิกัดของจุดเริ่มต้นของส่วนข้อความโดยใช้เมธอด `GetCoordinates()` นอกจากนี้ยังเน้นสถานการณ์ทั่วไปที่เกี่ยวกับส่วนข้อความ เช่น การใส่ลิงก์ไฮเปอร์ลิงก์ให้กับส่วนข้อความหนึ่งเดียว, การทำความเข้าใจว่าการจัดรูปแบบถูกสืบทอดผ่านส่วน, ย่อหน้า, กรอบข้อความ, และธีมอย่างไร, และการจัดการกรณีที่แบบอักษรที่ระบุไม่พบ อีกทั้งยังชี้ให้เห็นว่าการเติมสีข้อความ, สี, และความโปร่งแสงสามารถตั้งค่าแบบต่างหากสำหรับแต่ละส่วนภายในย่อหน้าเดียวกันได้

## **รับค่าพิกัดของส่วนข้อความ**
**GetCoordinates()** เมธอดถูกเพิ่มเข้าไปในคลาส IPortion และ Portion ซึ่งอนุญาตให้ดึงค่าพิกัดของจุดเริ่มต้นของส่วนข้อความได้:

```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใส่ลิงก์ไฮเปอร์ลิงก์ให้กับบางส่วนของข้อความภายในย่อหน้าเดียวได้หรือไม่?**

ได้ คุณสามารถ [กำหนดไฮเปอร์ลิงก์](/slides/th/net/manage-hyperlinks/) ให้กับส่วนข้อความหนึ่งได้; เฉพาะส่วนนั้นจะคลิกได้, ไม่ใช่ย่อหน้าทั้งหมด.

**ลักษณะการสืบทอดสไตล์ทำงานอย่างไร: Portion จะครอบคลุมอะไรบ้าง, และอะไรที่ได้รับมาจาก Paragraph/TextFrame?**

คุณสมบัติระดับ Portion มีความสำคัญสูงสุด หากคุณสมบัติไม่ได้ตั้งค่าไว้บน [Portion](https://reference.aspose.com/slides/th/net/aspose.slides/portion/), เอนจิ้นจะดึงค่าจาก [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph/); หากยังไม่ได้ตั้งค่าอีกที่นั่น, จะดึงจาก [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/) หรือสไตล์ของ [theme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/theme/).

**เกิดอะไรขึ้นหากแบบอักษรที่ระบุสำหรับ Portion ไม่พบบนเครื่อง/เซิร์ฟเวอร์เป้าหมาย?**

[กฎการทดแทนแบบอักษร](/slides/th/net/font-selection-sequence/) จะถูกนำมาใช้ ข้อความอาจเปลี่ยนแปลงรูปแบบการไหลใหม่: ตัวชี้วัด, การแทรก hyphen, และความกว้างอาจเปลี่ยนแปลง ซึ่งมีผลต่อการกำหนดตำแหน่งที่แม่นยำ.

**ฉันสามารถตั้งค่าความโปร่งแสงหรือไล่สีของการเติมข้อความระดับ Portion แยกจากส่วนอื่นของย่อหน้าได้หรือไม่?**

ได้ สีข้อความ, การเติม, และความโปร่งแสงในระดับ [Portion](https://reference.aspose.com/slides/th/net/aspose.slides/portion/) สามารถแตกต่างจากส่วนที่อยู่ใกล้เคียงได้.