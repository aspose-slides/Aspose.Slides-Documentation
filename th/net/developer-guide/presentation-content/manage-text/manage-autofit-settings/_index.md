---
title: เพิ่มประสิทธิภาพการนำเสนอของคุณด้วย AutoFit ใน .NET
linktitle: การตั้งค่า Autofit
type: docs
weight: 30
url: /th/net/manage-autofit-settings/
keywords:
- กล่องข้อความ
- AutoFit
- ไม่ใช้ AutoFit
- ปรับข้อความให้พอดี
- หดข้อความ
- ห่อข้อความ
- ปรับขนาดรูปทรง
- PowerPoint
- งานนำเสนอ
- C#
- .NET
- Aspose.Slides
description: "เรียนรู้วิธีจัดการการตั้งค่า AutoFit ใน Aspose.Slides สำหรับ .NET เพื่อเพิ่มประสิทธิภาพการแสดงข้อความในงานนำเสนอ PowerPoint และ OpenDocument ของคุณและปรับปรุงความอ่านง่ายของเนื้อหา."
---
## **บทนำ**

โดยค่าเริ่มต้น เมื่อคุณเพิ่มกล่องข้อความ Microsoft PowerPoint จะใช้การตั้งค่า **Resize shape to fit text** สำหรับกล่องข้อความ—โดยอัตโนมัติปรับขนาดกล่องข้อความเพื่อให้ข้อความของมันพอดีเสมอ

![กล่องข้อความใน PowerPoint](textbox-in-powerpoint.png)

* เมื่อข้อความในกล่องข้อความยาวหรือใหญ่ขึ้น PowerPoint จะขยายขนาดกล่องข้อความโดยอัตโนมัติ—เพิ่มความสูง—เพื่อให้สามารถบรรจุข้อความได้มากขึ้น
* เมื่อข้อความในกล่องข้อความสั้นหรือเล็กลง PowerPoint จะลดขนาดกล่องข้อความโดยอัตโนมัติ—ลดความสูง—เพื่อกำจัดพื้นที่ส่วนเกิน

ใน PowerPoint มีพารามิเตอร์หรือทางเลือกสำคัญสี่ประการที่ควบคุมพฤติกรรม Autofit สำหรับกล่องข้อความ:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![ตัวเลือก Autofit ใน PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for .NET มีตัวเลือกที่คล้ายกัน—properties ภายใต้คลาส [TextFrameFormat](https://reference.aspose.com/slides/th/net/aspose.slides/textframeformat)—ที่ให้คุณควบคุมพฤติกรรม autofit สำหรับกล่องข้อความในงานนำเสนอ

## **เปลี่ยนขนาดรูปร่างให้พอดีข้อความ**

หากคุณต้องการให้ข้อความในกล่องพอดีในกล่องนั้นเสมอหลังจากมีการเปลี่ยนแปลงข้อความ คุณต้องใช้ตัวเลือก **Resize shape to fit text**. เพื่อระบุการตั้งค่านี้ ให้ตั้งค่า property `AutofitType` ของคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/net/aspose.slides/textframeformat) เป็น `Shape`

![ตั้งค่า Resize shape to fit text](alwaysfit-setting-powerpoint.png)

โค้ด C# นี้แสดงวิธีระบุว่าข้อความต้องพอดีในกล่องของมันเสมอในงานนำเสนอ PowerPoint:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

หากข้อความยาวหรือใหญ่ขึ้น กล่องข้อความจะถูกปรับขนาดโดยอัตโนมัติ (เพิ่มความสูง) เพื่อให้ข้อความทั้งหมดพอดี หากข้อความสั้นลง สิ่งตรงกันข้ามจะเกิดขึ้น

## **Do Not Autofit**

หากคุณต้องการให้กล่องข้อความหรือรูปร่างคงมิติของมันไม่ว่าจะมีการเปลี่ยนแปลงข้อความอย่างไร คุณต้องใช้ตัวเลือก **Do not Autofit**. เพื่อระบุการตั้งค่านี้ ให้ตั้งค่า property `AutofitType` ของคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/net/aspose.slides/textframeformat) เป็น `None`

![การตั้งค่า "Do not Autofit" ใน PowerPoint](donotautofit-setting-powerpoint.png)

โค้ด C# นี้แสดงวิธีระบุว่ากล่องข้อความต้องคงมิติของมันเสมอในงานนำเสนอ PowerPoint:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

เมื่อข้อความยาวเกินกว่ากล่องของมัน จะล้นออกมานอกกล่อง

## **Shrink Text on Overflow**

หากข้อความยาวเกินกว่ากล่องของมัน คุณสามารถใช้ตัวเลือก **Shrink text on overflow** เพื่อระบุว่าขนาดและการเว้นระยะของข้อความต้องถูกลดลงเพื่อให้พอดีในกล่องนั้นได้. เพื่อระบุการตั้งค่านี้ ให้ตั้งค่า property `AutofitType` ของคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/net/aspose.slides/textframeformat) เป็น `Normal`

![การตั้งค่า "Shrink text on overflow" ใน PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

โค้ด C# นี้แสดงวิธีระบุว่าข้อความต้องหดตามการล้นในงานนำเสนอ PowerPoint:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Info" color="info" %}}
เมื่อใช้ตัวเลือก **Shrink text on overflow** การตั้งค่านี้จะถูกนำไปใช้เฉพาะเมื่อข้อความยาวเกินกว่ากล่องของมัน
{{% /alert %}}

## **Wrap Text**

หากคุณต้องการให้ข้อความในรูปร่างห่อหุ้มภายในรูปร่างนั้นเมื่อข้อความเกินขอบของรูปร่าง (เฉพาะความกว้าง) คุณต้องใช้พารามิเตอร์ **Wrap text in shape**. เพื่อระบุการตั้งค้านี้ คุณต้องตั้งค่า property `WrapText` ของคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/net/aspose.slides/textframeformat) เป็น `NullableBool.True`

โค้ด C# นี้แสดงวิธีใช้การตั้งค่า Wrap Text ในงานนำเสนอ PowerPoint:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Note" color="warning" %}}
หากคุณตั้งค่า property `WrapText` เป็น `NullableBool.False` สำหรับรูปร่าง เมื่อข้อความภายในรูปร่างยาวกว่าความกว้างของรูปร่าง ข้อความจะขยายออกนอกขอบของรูปร่างในรูปแบบบรรทัดเดียว
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ขอบในของ TextFrame มีผลต่อ AutoFit หรือไม่?**  
ใช่. Padding (ขอบใน) ลดพื้นที่ใช้ได้สำหรับข้อความ ทำให้ AutoFit ทำงานเร็วขึ้น—หดขนาดฟอนต์หรือปรับขนาดรูปร่างเร็วขึ้น ตรวจสอบและปรับขอบก่อนจะปรับจูน AutoFit

**AutoFit ทำงานอย่างไรกับการแทรกบรรทัดใหม่แบบมือและแบบอ่อน?**  
การแทรกบรรทัดใหม่ที่บังคับจะคงอยู่ ส่วน AutoFit ปรับขนาดฟอนต์และการเว้นระยะรอบบรรทัดเหล่านั้น การลบการแทรกบรรทัดที่ไม่จำเป็นมักทำให้ AutoFit ไม่ต้องหดข้อความมาก

**การเปลี่ยนฟอนต์ของธีมหรือการทำให้ฟอนต์แทนที่มีผลต่อผลลัพธ์ของ AutoFit หรือไม่?**  
มีผล. การแทนที่ด้วยฟอนต์ที่มีเมตริกซ์ glyph แตกต่างจะเปลี่ยนความกว้าง/ความสูงของข้อความ ซึ่งอาจเปลี่ยนขนาดฟอนต์สุดท้ายและการห่อบรรทัด หลังจากเปลี่ยนหรือแทนที่ฟอนต์ใด ๆ ให้ตรวจสอบสไลด์ใหม่อีกครั้ง