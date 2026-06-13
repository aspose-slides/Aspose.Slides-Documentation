---
title: รับขอบเขตย่อหน้าจากการนำเสนอใน .NET
linktitle: ย่อหน้า
type: docs
weight: 60
url: /th/net/paragraph/
keywords:
- ขอบเขตย่อหน้า
- ขอบเขตส่วนข้อความ
- พิกัดย่อหน้า
- พิกัดส่วน
- ขนาดย่อหน้า
- ขนาดส่วนข้อความ
- กรอบข้อความ
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีการดึงขอบเขตย่อหน้าและส่วนข้อความใน Aspose.Slides สำหรับ .NET เพื่อเพิ่มประสิทธิภาพการวางตำแหน่งข้อความในงานนำเสนอ PowerPoint"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการดึงขอบเขต ขนาด และพิกัดของย่อหน้าและส่วนของข้อความใน Aspose.Slides แสดงวิธีการดึงสี่เหลี่ยมของย่อหน้าใน `TextFrame` ด้วยการใช้ `GetRect()` วิธีการดึงพิกัดของย่อหน้าและส่วนภายใน TextFrame ของเซลล์ตาราง รวมถึงเน้นรายละเอียดสำคัญเช่น หน่วยวัด ผลของการตัดบรรทัดต่อขอบเขต การแปลงเป็นพิกเซล และค่าการจัดรูปแบบย่อหน้าแบบ effective

## **รับพิกัดย่อหน้าและส่วนใน TextFrame**
โดยใช้ Aspose.Slides สำหรับ .NET นักพัฒนาตอนนี้สามารถรับพิกัดสี่เหลี่ยมของ Paragraph ภายในคอลเลกชันของ Paragraph ใน TextFrame ได้ นอกจากนี้ยังสามารถรับพิกัดของ portion ภายในคอลเลกชันของ portion ของ Paragraph ได้ ในหัวข้อนี้ เราจะสาธิตด้วยตัวอย่างว่าจะรับพิกัดสี่เหลี่ยมของ Paragraph พร้อมตำแหน่งของ portion ภายใน Paragraph อย่างไร

## **รับพิกัดสี่เหลี่ยมของ Paragraph**
เมธอดใหม่ **GetRect()** ได้ถูกเพิ่มเข้ามา ซึ่งช่วยให้รับสี่เหลี่ยมขอบเขตของ Paragraph ได้

```c#
// สร้างวัตถุ Presentation ที่แสดงไฟล์การนำเสนอ
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **รับขนาดของ Paragraph และ Portion ใน TextFrame ของเซลล์ตาราง**
เพื่อรับขนาดและพิกัดของ [Portion](https://reference.aspose.com/slides/th/net/aspose.slides/portion) หรือ [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph) ใน TextFrame ของเซลล์ตาราง คุณสามารถใช้เมธอด [IPortion.GetRect](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/methods/getrect) และ [IParagraph.GetRect](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/methods/getrect) ได้

ตัวอย่างโค้ดต่อไปนี้แสดงการทำงานที่อธิบายไว้:

```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```

## **FAQ**

**พิกัดที่ส่งกลับสำหรับย่อหน้าและส่วนข้อความวัดเป็นหน่วยอะไร?**  
เป็นหน่วยพอยต์ โดย 1 นิ้ว = 72 พอยต์ ซึ่งใช้กับพิกัดและมิติทั้งหมดบนสไลด์

**การตัดบรรทัดอัตโนมัติมีผลต่อขอบเขตของย่อหน้าหรือไม่?**  
ใช่ หาก [wrapping](https://reference.aspose.com/slides/th/net/aspose.slides/textframeformat/wraptext/) ถูกเปิดใช้งานใน [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/), ข้อความจะตัดบรรทัดให้พอกับความกว้างของพื้นที่ซึ่งทำให้ขอบเขตของย่อหน้าจริงเปลี่ยนแปลง

**พิกัดของย่อหน้าสามารถแมปเป็นพิกเซลในภาพที่ส่งออกได้อย่างน่าเชื่อถือหรือไม่?**  
ใช่ แปลงพอยต์เป็นพิกเซลโดยใช้: pixels = points × (DPI / 72). ผลลัพธ์จะขึ้นกับค่า DPI ที่เลือกสำหรับการเรนเดอร์/ส่งออก

**ฉันจะรับพารามิเตอร์การจัดรูปแบบย่อหน้าแบบ "effective" ที่คำนึงถึงการสืบทอดสไตล์อย่างไร?**  
ใช้ [effective paragraph formatting data structure](/slides/th/net/shape-effective-properties/); มันจะคืนค่าที่สรุปแล้วของการเยื้อม, ระยะห่าง, การตัดบรรทัด, RTL และอื่น ๆ