---
title: จัดรูปแบบข้อความการนำเสนอใน .NET
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/net/text-formatting/
keywords:
- จัดแนวย่อหน้า
- รูปแบบข้อความ
- พื้นหลังข้อความ
- ความโปร่งใสของข้อความ
- ระยะห่างระหว่างอักขระ
- คุณสมบัติแบบอักษร
- ตระกูลแบบอักษร
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- การเว้นบรรทัด
- คุณสมบัติ autofit
- จุดยึดกรอบข้อความ
- การตั้งค่าแท็บข้อความ
- ภาษาเริ่มต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดรูปแบบและตกแต่งข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET ปรับแบบอักษร สี การจัดแนว และอื่น ๆ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides for .NET ครอบคลุมสีพื้นหลัง, ความโปร่งใส, ระยะห่างระหว่างอักขระ, คุณสมบัติของแบบอักษร, การหมุน, ระยะห่างของย่อหน้า, พฤติกรรม autofit, การตั้งจุดยึดข้อความ, การกำหนดตำแหน่งแท็บ, และการตั้งค่าภาษา.

หากไม่ได้ระบุเป็นอย่างอื่น ตัวอย่างจะใช้ [sample.pptx](sample.pptx) รูปแบบแรกบนสไลด์แรกเป็นกล่องข้อความ และย่อหน้าแรกของมันมีข้อความที่แสดงด้านล่าง ดัชนีของสไลด์และรูปทรงเป็นศูนย์ฐาน ตัวอย่างที่เลือกส่วนที่หนาตำแหน่งใช้การจัดรูปแบบที่มีประสิทธิภาพ รวมถึงการจัดรูปแบบหนาที่สืบทอดมาด้วย:

![ข้อความตัวอย่าง](sample_text.png)

เพื่อค้นหาและไฮไลท์ข้อความตามตัวอักษรหรือผลการจับคู่ตาม regular-expression ให้ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/net/search-and-replace-text/).

## **ตั้งค่าสีพื้นหลังข้อความ**

ใช้ [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/defaultportionformat/) เพื่อกำหนดสีไฮไลท์เริ่มต้นสำหรับย่อหน้า หรือใช้ [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/highlightcolor/) สำหรับส่วนข้อความแต่ละส่วน.

ตัวอย่างต่อไปนี้ตั้งค่าสีไฮไลท์สีเทาอ่อนเป็นค่าเริ่มต้นสำหรับย่อหน้าแรก สีไฮไลท์ที่ระบุโดยตรงในแต่ละส่วนจะมีลำดับความสำคัญเหนือค่าเริ่มต้นนี้:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// ตั้งค่าสีไฮไลท์สำหรับย่อหน้าทั้งหมด.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ย่อหน้าเทา](gray_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีการตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่มีแบบอักษรหนา**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // ตั้งค่าสีไฮไลท์สำหรับส่วนข้อความ.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ส่วนข้อความสีเทา](gray_text_portions.png)

## **จัดแนวย่อหน้าข้อความ**

ใช้ [IParagraphFormat.Alignment](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/alignment/) เพื่อกำหนดการจัดแนวของย่อหน้าภายในกรอบข้อความ ค่าอาจเป็นการจัดกึ่งกลาง, จัดซ้าย, จัดขวา, จัดเต็ม, ฯลฯ

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการจัดแนวย่อหน้าให้อยู่ที่ **กึ่งกลาง**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// ตั้งค่าการจัดแนวของย่อหน้าให้ศูนย์กลาง.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ย่อหน้าที่จัดแนวแล้ว](aligned_paragraph.png)

## **ตั้งค่าความโปร่งใสสำหรับข้อความ**

ความโปร่งใสของข้อความถูกควบคุมผ่านส่วนประกอบอัลฟ่าของสีที่กำหนดให้กับ [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/fillformat/). ในตัวอย่างด้านล่าง `alpha = 50` เป็นค่าช่องอัลฟ่า ARGB ในช่วง 0–255 ไม่ใช่เปอร์เซ็นต์ความโปร่งใส.

ตัวอย่างโค้ดด้านล่างแสดงวิธีการใช้ความโปร่งใสกับ **ย่อหน้าทั้งหมด**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// ตั้งค่าการเติมสีดำครึ่งโปร่งใสสำหรับข้อความ.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ย่อหน้าที่โปร่งใส](transparent_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการใช้ความโปร่งใสกับ **ส่วนข้อความที่มีแบบอักษรหนา**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // ตั้งค่าความโปร่งใสของส่วนข้อความ.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ส่วนข้อความที่โปร่งใส](transparent_text_portions.png)

## **ตั้งค่าระยะห่างระหว่างอักขระสำหรับข้อความ**

ใช้ [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/spacing/) เพื่อขยายหรือบีบอัดระยะห่างระหว่างอักขระในกล่องข้อความ ตัวอย่างเพิ่มระยะห่าง 3 พ้อยต์; ค่าติดลบจะบีบอัดข้อความ.

โค้ด C# ด้านล่างแสดงวิธีการขยายระยะห่างอักขระใน **ย่อหน้าทั้งหมด**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// หมายเหตุ: ใช้ค่าเป็นลบเพื่อบีบอัดระยะห่างระหว่างอักขระ.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // ขยายระยะห่างอักขระ.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ระยะห่างอักขระในย่อหน้า](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีการขยายระยะห่างอักขระใน **ส่วนข้อความที่มีแบบอักษรหนา**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างระหว่างอักขระ.
        portion.PortionFormat.Spacing = 3;  // ขยายระยะห่างอักขระ.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ระยะห่างอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการ Kerning สำหรับแบบอักษรเฉพาะ**

ในบางกรณี ข้อความที่เรนเดอร์โดย Aspose.Slides อาจดูแน่นกว่าข้อความเดียวกันที่แสดงใน PowerPoint นี้อาจเกิดขึ้นเพราะ PowerPoint อาจละเว้นข้อมูล kerning สำหรับแบบอักษรบางตัว แม้ว่าแบบอักษรนั้นจะมีข้อมูล kerning ที่ถูกต้องและเปิดการใช้ kerning ในการตั้งค่าของ PowerPoint.

เพื่อทำให้ผลลัพธ์ที่เรนเดอร์ใกล้เคียงกับ PowerPoint มากขึ้นในกรณีเช่นนี้ คุณสามารถปิดการใช้งาน kerning สำหรับส่วนข้อความที่ใช้แบบอักษรที่ได้รับผลกระทบ ตั้งค่า [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/kerningminimalsize/) เป็นค่าที่ใหญ่กว่าขนาดแบบอักษรจริง ตัวอย่างนี้ต้องการไฟล์ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรก จะตรวจสอบชื่อแบบอักษรที่มีผลรวมรวมถึงแบบอักษรที่สืบทอดและตั้งค่าขีดจำกัดที่ 100 พ้อยต์สำหรับส่วนที่ใช้ Roboto ซึ่งจะปิดการใช้งาน kerning สำหรับส่วนที่มีขนาดแบบอักษรต่ำกว่า 100 พ้อยต์:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var targetFont = "Roboto";

foreach (var paragraph in autoShape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var textFormat = portion.PortionFormat.GetEffective();
        
        var usesTargetFont = textFormat.LatinFont?.FontName == targetFont || 
            textFormat.EastAsianFont?.FontName == targetFont || 
            textFormat.ComplexScriptFont?.FontName == targetFont;

        if (usesTargetFont)
        {
            portion.PortionFormat.KerningMinimalSize = 100;
        }
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

สำหรับข้อความที่ตรงกับเงื่อนไขและมีขนาดต่ำกว่าขีดจำกัด การตั้งค่านี้จะป้องกันการใช้ kerning และช่วยให้การเรนเดอร์ของ Aspose.Slides ใกล้เคียงกับผลลัพธ์ภาพของ PowerPoint สำหรับแบบอักษรที่ได้รับผลกระทบจากพฤติกรรมเฉพาะของ PowerPoint นี้.

## **จัดการคุณสมบัติแบบอักษรของข้อความ**

คุณสมบัติแบบอักษรสามารถตั้งค่าในระดับย่อหน้าผ่าน [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/defaultportionformat/) หรือในแต่ละส่วนผ่าน [IPortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iportionformat/).

ตัวอย่างต่อไปนี้ตั้งค่าแบบอักษรเริ่มต้นของย่อหน้าแรกเป็น Times New Roman ขนาด 12 พอยต์ พร้อมการกำหนดรูปแบบหนา, เรียงเอียง, และขีดเส้นใต้แบบจุด จุดการจัดรูปแบบโดยตรงในแต่ละส่วนจะมีลำดับความสำคัญเหนือค่าเริ่มต้นเหล่านี้:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// ตั้งค่าคุณสมบัติแบบอักษรสำหรับย่อหน้า.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![คุณสมบัติเข้ารูปแบบของย่อหน้า](font_properties_for_paragraph.png)

ตัวอย่างต่อไปนี้ใช้ Times New Roman ขนาด 13 พอยต์, รูปแบบเอียง, และขีดเส้นใต้แบบจุด กับส่วนที่มีการจัดรูปแบบที่มีผลเป็นแบบหนา:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // ตั้งค่าคุณสมบัติแบบอักษรสำหรับส่วนข้อความ.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![คุณสมบัติแบบอักษรของส่วนข้อความ](font_properties_for_text_portions.png)

## **ตั้งค่าการหมุนข้อความ**

ใช้ [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/textverticaltype/) เพื่อกำหนดทิศทางข้อความที่กำหนดไว้ล่วงหน้าในรูปทรง.

ตัวอย่างโค้ดต่อไปนี้ตั้งค่าการวางแนวข้อความในรูปทรงเป็น [TextVerticalType.Vertical270](https://reference.aspose.com/slides/th/net/aspose.slides/textverticaltype/), ซึ่งจะหมุนข้อความ **90 องศาทวนเข็มนาฬิกา**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![การหมุนข้อความ](text_rotation.png)

## **ตั้งค่าการหมุนแบบกำหนดเองสำหรับกรอบข้อความ**

ใช้ [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/rotationangle/) เพื่อกำหนดมุมการหมุนแบบกำหนดเองสำหรับ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/).

ตัวอย่างโค้ดด้านล่างหมุนกรอบข้อความโดย 3 องศาตามเข็มนาฬิกาในรูปทรง:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![การหมุนข้อความแบบกำหนดเอง](custom_text_rotation.png)

## **ตั้งค่าการเว้นบรรทัดของย่อหน้า**

Aspose.Slides มี [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/spacebefore/), และ [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/spacewithin/) เพื่อควบคุมระยะห่างของย่อหน้า คุณสมบัติเหล่านี้ใช้ดังต่อไปนี้:

* ใช้ค่าบวกเพื่อระบุการเว้นบรรทัดเป็นเปอร์เซ็นต์ของความสูงของบรรทัด.
* ใช้ค่าลบเพื่อระบุการเว้นบรรทัดเป็นพอยต์.

ตัวอย่างต่อไปนี้ตั้งค่าการเว้นบรรทัดภายในย่อหน้าแรกให้เป็น 200% ของความสูงบรรทัด (เว้นบรรทัดสองเท่า):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.SpaceWithin = 200;

presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![การเว้นบรรทัดภายในย่อหน้า](line_spacing.png)

## **ควบคุมการตัดบรรทัด**

กฎการตัดบรรทัดของย่อ้ามีประโยชน์ในบล็อกข้อความแคบและการพรีเซนเทชันที่ผสมข้อความละตินและเอเชียตะวันออก คุณสมบัติดังต่อไปนี้เป็นของ [IParagraphFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/), ดังนั้นจะใช้กับย่อหน้าทั้งหมด:

- [LatinLineBreak](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/latinlinebreak/) ควบคุมกฎการตัดบรรทัดสำหรับข้อความละติน ในข้อความผสม การเปลี่ยนแปลงอาจทำให้ตำแหน่งการตัดบรรทัดของข้อความเอเชียตะวันออกและเครื่องหมายวรรคตอนที่อยู่ติดกันเปลี่ยนไป.
- [EastAsianLineBreak](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/eastasianlinebreak/) ควบคุมกฎการตัดบรรทัดสำหรับเอเชียตะวันออก รวมถึงข้อจำกัดของอักขระที่เริ่มต้นและสิ้นสุดบรรทัด.

กฎเหล่านี้ไม่ทดแทน [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/wraptext/), ที่เปิดการตัดบรรทัดอัตโนมัติภายในกรอบข้อความ พวกมันมีอิทธิพลต่อการจัดหน้าเมื่อมีการตัดบรรทัด; ไม่ได้แทรกอักขระการตัดบรรทัด การตัดบรรทัดแบบชัดเจนจะบังคับให้ขึ้นบรรทัดใหม่ภายในย่อหน้าโดยไม่คำนึงถึงความกว้างที่มี.

ตัวอย่างที่เป็นอิสระต่อไปนี้สร้างบล็อกข้อความแคบที่มีข้อความจีนและละติน เพื่อตั้งค่าคุณสมบัติการตัดบรรทัดทั้งสองอย่างชัดเจนและบันทึกเป็น "line_breaking.pptx" เพื่อทดลองใช้กฎใดกฎหนึ่งให้เปลี่ยนค่าของคุณสมบัตินั้นในขณะที่ตั้งค่าอื่นคงที่ ตัวอย่างใช้แบบอักษร Arial และ SimSun ขนาด 24 พอยต์พร้อมความกว้างกรอบ 160 พอยต์และไม่มีระยะขอบแนวนอนของกรอบข้อความ [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/autofittype/) ถูกตั้งเป็น [TextAutofitType.None](https://reference.aspose.com/slides/th/net/aspose.slides/textautofittype/) เพื่อให้ขนาดข้อความและมิติกรอบคงที่.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "中文排版测试，PowerPoint 中文演示。";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.EastAsianFont = new FontData("SimSun");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.LatinLineBreak = NullableBool.False;
format.EastAsianLineBreak = NullableBool.True;

presentation.Save("line_breaking.pptx", SaveFormat.Pptx);
```

## **ควบคุมเครื่องหมายวรรคตอนที่ลอย**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/hangingpunctuation/) ทำให้เครื่องหมายวรรคตอนที่เหมาะสมขยายออกนอกขอบขวาของบรรทัดข้อความแทนที่จะอยู่ในบรรทัดต่อไป มันใช้กับย่อหน้าทั้งหมดและแตกต่างจากการเยื้องลอย.

ตัวอย่างที่เป็นอิสระต่อไปนี้เปิดใช้งานการลอยของเครื่องหมายวรรคตอนในกรอบข้อความกว้าง 100 พอยต์และบันทึกเป็น "hanging_punctuation.pptx" โดยใช้ Arial ขนาด 24 พอยต์และไม่มีระยะขอบแนวนอนของกรอบข้อความ จุดสุดท้ายจะอยู่หลัง "sentence" และขยายออกนอกขอบข้อความด้านขวา ตั้งค่าคุณสมบัตินี้เป็น [NullableBool.False](https://reference.aspose.com/slides/th/net/aspose.slides/nullablebool/) เพื่อเปรียบเทียบ: ด้วยการตั้งค่านี้ จุดสุดท้ายจะอยู่ในบรรทัดแยก Wrapping ถูกเปิดและ Autofit ถูกปิดเพื่อคงความกว้างที่ใช้ได้คงที่.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "Simple text, next sentence.";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.HangingPunctuation = NullableBool.True;

presentation.Save("hanging_punctuation.pptx", SaveFormat.Pptx);
```

ไม่ได้ทุกเครื่องหมายวรรคตอนที่สามารถลอยได้ เงื่อนไขของแบบอักษรและการจัดเลเอาต์ที่อธิบายไว้ข้างต้น ([font and layout conditions described above](#conditions-and-limitations)) ยังใช้กับการเปรียบเทียบนี้: การเปลี่ยนแบบอักษร, ความกว้างที่ใช้ได้, ระยะขอบ หรือการตั้งค่า autofit อาจทำให้ความแตกต่างที่มองเห็นหายไป.

## **ตั้งค่าประเภท Autofit สำหรับกรอบข้อความ**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/autofittype/) กำหนดว่าข้อความทำงานอย่างไรเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะหด, ล้น, หรือปรับขนาดรูปร่างโดยอัตโนมัติ ตัวอย่างต่อไปนี้กำหนดค่ารูปร่างให้ปรับขนาดให้พอดีกับข้อความและบันทึกผลลัพธ์เป็น "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

เพื่อคำนวณจำนวนบรรทัดหลังจากการตัดบรรทัดอัตโนมัติและดูว่าขนาดข้อความหรือรูปร่างเปลี่ยนผลลัพธ์อย่างไร ดูที่ [Count Rendered Lines](/slides/th/net/manage-paragraph/). จำนวนบรรทัดเพียงอย่างเดียวไม่บ่งบอกว่าข้อความล้นคอนเทนเนอร์หรือไม่.

## **ตั้งค่าตำแหน่งยึดของกรอบข้อความ**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/anchoringtype/) กำหนดว่าข้อความวางตำแหน่งแนวตั้งภายในรูปทรงอย่างไร เช่น ที่ด้านบน, กลาง, หรือด้านล่าง ตัวอย่างต่อไปนี้ยึดข้อความไว้ที่ด้านล่างของรูปทรงแรกและบันทึกผลลัพธ์เป็น "text_anchor.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าการแท็บข้อความ**

ใช้ [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/defaulttabsize/) และ [IParagraphFormat.Tabs](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/tabs/) เพื่อกำหนดตำแหน่งแท็บในย่อหน้า ตัวอย่างต่อไปนี้ตั้งค่าช่วงแท็บเริ่มต้นเป็น 100 พอยต์และเพิ่มตำแหน่งแท็บจัดซ้ายที่ 30 พอยต์ การตั้งค่าเหล่านี้มีผลต่อข้อความที่มีอักขระแท็บ.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultTabSize = 100;
paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![แท็บของย่อหน้า](paragraph_tabs.png)

## **ตั้งค่าภาษาการตรวจสอบ**

Aspose.Slides มี [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/languageid/) ซึ่งให้คุณกำหนดภาษาการตรวจสอบสำหรับส่วนข้อความ ภาษาการตรวจสอบกำหนดภาษาที่ใช้สำหรับการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint.

ตัวอย่างต่อไปนี้ต้องการไฟล์ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรกและอย่างน้อยหนึ่งย่อหน้า จะเปลี่ยนเนื้อหาของย่อหน้าแรกเป็น "1。", ตั้งค่า SimSun เป็นแบบอักษรและกำหนดภาษาการตรวจสอบเป็นภาษาจีนตัวย่อ (`zh-CN`). แล้วบันทึกผลลัพธ์เป็น "proofing_language.pptx":

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var font = new FontData("SimSun");

var textPortion = new Portion();
textPortion.PortionFormat.ComplexScriptFont = font;
textPortion.PortionFormat.EastAsianFont = font;
textPortion.PortionFormat.LatinFont = font;

// ตั้งค่าภาษาการตรวจสอบเป็นภาษาจีนตัวย่อ.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าภาษาเริ่มต้น**

ใช้ [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/defaulttextlanguage/) เพื่อนิยามภาษาตั้งต้นสำหรับข้อความที่สร้างขณะโหลดหรือสร้างพรีเซนเทชัน ตัวอย่างต่อไปนี้สร้างพรีเซนเทชันโดยมีภาษาอังกฤษสหรัฐเป็นภาษาข้อความเริ่มต้น เพิ่มกล่องข้อความ และพิมพ์ `en-US` สำหรับส่วนข้อความแรก.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// เพิ่มรูปสี่เหลี่ยมผืนผ้าใหม่ที่มีข้อความ.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// ตรวจสอบภาษาของส่วนแรก.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **ตั้งค่ารูปแบบข้อความเริ่มต้น**

เพื่อใช้การจัดรูปแบบข้อความเริ่มต้นในระดับพรีเซนเทชัน ใช้ [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/defaulttextstyle/).

ตัวอย่างต่อไปนี้ตั้งค่าแบบอักษรหนาขนาด 14 พอยต์เป็นค่าเริ่มต้นสำหรับย่อหน้าในระดับบนของพรีเซนเทชันใหม่และบันทึกเป็น "default_text_style.pptx" ข้อความสามารถสืบทอดค่าเริ่มต้นนี้ได้เว้นแต่การจัดรูปแบบที่เฉพาะเจาะจงจะทับ.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// ดึงรูปแบบย่อหน้าระดับบนสุด.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **ดึงข้อความพร้อมเอฟเฟ็กต์ All-Caps**

ใน PowerPoint การใช้เอฟเฟ็กต์แบบอักษร **All Caps** จะทำให้ข้อความปรากฏเป็นตัวพิมพ์ใหญ่บนสไลด์ แม้ว่าจะพิมพ์เป็นตัวพิมพ์เล็กเดิม เมื่อคุณดึงส่วนข้อความแบบนี้ด้วย Aspose.Slides ไลบรารีจะคืนค่าข้อความตามที่พิมพ์ไว้ เพื่อให้ตรงกับข้อความที่แสดง ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/th/net/aspose.slides/textcaptype/) และแปลงสตริงที่คืนค่าเป็นตัวพิมพ์ใหญ่เมื่อค่ามีค่า `All`.

ตัวอย่างนี้ต้องการไฟล์ "sample2.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรก ส่วนแรกของย่อหน้าแรกมีข้อความ "Hello, Aspose!" พร้อมเอฟเฟ็กต์ All Caps ตามที่แสดงด้านล่าง.

![เอฟเฟ็กต์ All Caps](all_caps_effect.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีดึงข้อความที่มีเอฟเฟ็กต์ **All Caps** ถูกใช้งาน:

```cs
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample2.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

Console.WriteLine($"Original text: {textPortion.Text}");

var textFormat = textPortion.PortionFormat.GetEffective();
if (textFormat.TextCapType == TextCapType.All)
{
    var text = textPortion.Text.ToUpper();
    Console.WriteLine($"All-Caps effect: {text}");
}
```

ผลลัพธ์:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**ฉันจะแก้ไขข้อความในตารางบนสไลด์ได้อย่างไร?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ให้ใช้ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/). ทำการวนลูปผ่านเซลล์และอัปเดตแต่ละเซลล์ผ่าน [ICell.TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/icell/textframe/) และจัดรูปแบบย่อหน้าผ่าน [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/paragraphformat/).

**ฉันจะใช้สีไล่ระดับบนข้อความในสไลด์ PowerPoint ได้อย่างไร?**

เพื่อใช้สีไล่ระดับบนข้อความ ให้ใช้ [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/fillformat/). ตั้งค่า [IFillFormat.FillType](https://reference.aspose.com/slides/th/net/aspose.slides/ifillformat/filltype/) เป็น [FillType.Gradient](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/) แล้วกำหนดจุดไล่ระดับ, ทิศทาง, และความโปร่งใส.