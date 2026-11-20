---
title: จัดรูปแบบข้อความการนำเสนอใน .NET
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/net/text-formatting/
keywords:
- จัดแนวย่อหน้า
- สไตล์ข้อความ
- พื้นหลังข้อความ
- ความโปร่งใสของข้อความ
- ระยะห่างระหว่างอักขระ
- คุณสมบัติแบบอักษร
- ตระกูลแบบอักษร
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติ autofit
- ตำแหน่งยึดกรอบข้อความ
- การแท็บข้อความ
- ภาษาดีฟอลต์
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดรูปแบบและกำหนดสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET ปรับแบบอักษร สี การจัดแนว และอื่น ๆ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides for .NET ครอบคลุมสีพื้นหลัง, ความโปร่งใส, การจัดระยะห่างระหว่างอักขระ, คุณสมบัติของแบบอักษร, การหมุน, การจัดระยะห่างของย่อหน้า, พฤติกรรม autofit, การยึดข้อความ, จุดหยุดแท็บ, และการตั้งค่าภาษา

หากไม่ได้ระบุเป็นอย่างอื่น ตัวอย่างจะใช้ [sample.pptx](sample.pptx). รูปร่างแรกบนสไลด์แรกเป็นกล่องข้อความและย่อหน้าที่หนึ่งของมันมีข้อความที่แสดงด้านล่าง ทั้งดัชนีสไลด์และรูปทรงเริ่มจากศูนย์ ตัวอย่างที่เลือกส่วนที่เป็นตัวหนาใช้การจัดรูปแบบที่มีผลรวมถึงการจัดรูปแบบตัวหนาที่สืบทอดมาดังนี้:

![Sample text](sample_text.png)

เพื่อค้นหาและเน้นข้อความตามตัวอักษรหรือการจับคู่แบบ regular‑expression ให้ดูที่ [Search and Replace Text](/slides/th/net/search-and-replace-text/).

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้ [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) เพื่อตั้งค่าสีไฮไลต์เริ่มต้นสำหรับย่อหน้า หรือใช้ [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) สำหรับส่วนข้อความแต่ละส่วน

ตัวอย่างต่อไปนี้ตั้งค่าสีไฮไลต์สีเทาอ่อนให้เป็นค่าเริ่มต้นสำหรับย่อหน้าแรก สีไฮไลต์ที่ระบุโดยตรงบนส่วนข้อความแต่ละส่วนจะมีลำดับความสำคัญเหนือค่านี้:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// ตั้งค่าสีไฮไลต์สำหรับย่อหน้าทั้งหมด.
presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![The gray paragraph](gray_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่มีแบบอักษรตัวหนา**:

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
        // ตั้งค่าสีไฮไลต์สำหรับส่วนข้อความ.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![The gray text portions](gray_text_portions.png)

## **จัดแนวย่อหน้าข้อความ**

ใช้ [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) เพื่อกำหนดการจัดแนวย่อหน้าภายในกรอบข้อความ ค่าที่สามารถใช้ได้เช่น กึ่งกลาง, จัดซ้าย, จัดขวา, จัดชิดและอื่น ๆ

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดแนวย่อหน้าให้อยู่ **กึ่งกลาง**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// ตั้งค่าการจัดแนวของย่อหน้าให้กึ่งกลาง.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![The aligned paragraph](aligned_paragraph.png)

## **จัดแนวแบบอักษรภายในบรรทัด**

ใช้ [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) เพื่อจัดแนวแนวตั้งของส่วนข้อความที่มีขนาดแบบอักษรต่างกันภายในบรรทัด การตั้งค่านี้ใช้กับย่อหน้าทั้งหมดและควบคุมการจัดแนวภายในแต่ละบรรทัดของย่อหน้า

ตัวอย่างต่อไปนี้สร้างกล่องข้อความที่มีป้ายกำกับสี่กล่องบนสไลด์หนึ่ง แต่ละย่อหน้ามีข้อความเดียวกันที่ขนาด 18, 36, และ 54 จุด โดยใช้การจัดแนวแบบอักษรที่แตกต่างกัน ใช้ฟอนต์ Arial, ปิดการทำ autofit และการตัดบรรทัด, และทำให้กรอบข้อความใหญ่พอสำหรับบรรทัดเดียว

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var alignments = new[] { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
var fontSizes = new[] { 18f, 36f, 54f };

for (var i = 0; i < alignments.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;

    var label = textFrame.Paragraphs[0];
    label.Text = alignments[i].ToString();
    label.ParagraphFormat.Alignment = TextAlignment.Left;
    label.ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
    label.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.FontAlignment = alignments[i];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    foreach (var fontSize in fontSizes)
    {
        var portion = new Portion("Ag ");
        portion.PortionFormat.FontHeight = fontSize;
        paragraph.Portions.Add(portion);
    }

    textFrame.Paragraphs.Add(paragraph);
}

presentation.Save("font_alignment.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![Comparison of Baseline, Top, Center, and Bottom font alignment with mixed font sizes](font_alignment.png)

การจัดแนวแบบอักษรใช้เมตริกฟอนต์ ดังนั้นขอบด้านที่มองเห็นของอักขระแต่ละตัวอาจไม่ตรงกันอย่างแม่นยำ ตัวอย่างรวมอักษรตัวพิมพ์ใหญ่และตัวลงล่างเพื่อแสดงความแตกต่างระหว่างการจัดแนว baseline กับ bottom ความพร้อมใช้งานของฟอนต์และการแทนที่, ตัวอักษรที่ใช้, และความแตกต่างของขนาดฟอนต์ล้วนมีผลต่อผลลัพธ์ ขนาดกรอบ, ระยะขอบ, ระยะห่างบรรทัด, การตัดบรรทัด, และการทำ autofit ก็มีผลต่อการจัดวาง; ใช้ฟอนต์และการตั้งค่าเลเอาต์เดียวกันเมื่อเปรียบเทียบโหมดต่าง ๆ

การตั้งค่านี้แตกต่างจาก [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) ซึ่งควบคุมการจัดแนวแนวนอนของย่อหน้า, และ [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) ที่กำหนดตำแหน่งบล็อกข้อความแบบแนวตั้งภายในรูปร่าง การจัดฟอร์แมตเชลท์และซับเชลท์ผ่าน [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) จะย้ายส่วนแต่ละส่วนสัมพันธ์กับ baseline แทนที่จะตั้งค่าการจัดแนวแบบอักษรสำหรับบรรทัดของย่อหน้า

## **ตั้งค่าความโปร่งใสสำหรับข้อความ**

ความโปร่งใสของข้อความถูกควบคุมผ่านส่วนประกอบอัลฟาของสีที่กำหนดให้กับ [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). ในตัวอย่างด้านล่าง `alpha = 50` เป็นค่าช่องอัลฟา ARGB บนสเกล 0–255 ไม่ใช่เปอร์เซ็นต์ความโปร่งใส

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ย่อหน้าทั้งหมด**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// ตั้งค่าการเติมสีดำกึ่งโปร่งใสสำหรับข้อความ.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![The transparent paragraph](transparent_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ส่วนข้อความที่มีแบบอักษรตัวหนา**:

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

![The transparent text portions](transparent_text_portions.png)

## **ตั้งค่าการจัดระยะห่างอักขระสำหรับข้อความ**

ใช้ [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) เพื่อขยายหรือบีบอัดระยะห่างระหว่างอักขระในกล่องข้อความ ตัวอย่างเพิ่มระยะห่าง 3 จุด; ค่าลบจะบีบอัดข้อความ

โค้ด C# ต่อไปนี้แสดงวิธีขยายการจัดระยะห่างอักขระใน **ย่อหน้าทั้งหมด**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// หมายเหตุ: ใช้ค่าลบเพื่อบีบอัดระยะห่างระหว่างอักขระ.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // ขยายระยะห่างระหว่างอักขระ.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีขยายการจัดระยะห่างอักขระใน **ส่วนข้อความที่มีแบบอักษรตัวหนา**:

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
        // หมายเหตุ: ใช้ค่าลบเพื่อบีบอัดระยะห่างระหว่างอักขระ.
        portion.PortionFormat.Spacing = 3;  // ขยายระยะห่างระหว่างอักขระ.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **ปิดการทำ Kerning สำหรับฟอนต์เฉพาะ**

ในบางกรณีข้อความที่เรนเดอร์ด้วย Aspose.Slides อาจดูแน่นกว่าข้อความเดียวกันที่แสดงใน PowerPoint สิ่งนี้อาจเกิดจาก PowerPoint ไม่สนใจข้อมูล kerning สำหรับฟอนต์บางตัว แม้ว่าฟอนต์จะมีข้อมูล kerning ที่ถูกต้องและ kerning ถูกเปิดใช้งานในการตั้งค่า PowerPoint

เพื่อให้ผลลัพธ์ที่เรนเดอร์ใกล้เคียงกับ PowerPoint มากขึ้น คุณสามารถปิดการทำ kerning สำหรับส่วนข้อความที่ใช้ฟอนต์ที่ได้รับผลกระทบได้ ตั้งค่า [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) เป็นค่าที่ใหญ่กว่าขนาดฟอนต์จริง ตัวอย่างนี้ต้องการไฟล์ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรก มันตรวจสอบชื่อฟอนต์ที่มีผลรวม รวมถึงฟอนต์ที่สืบทอดมา และกำหนดเกณฑ์ 100 จุดสำหรับส่วนที่ใช้ Roboto การทำเช่นนี้จะปิด kerning สำหรับส่วนที่ใช้ฟอนต์ขนาดต่ำกว่า 100 จุด:

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

สำหรับข้อความที่ตรงกับเกณฑ์ด้านล่าง การตั้งค่านี้จะป้องกัน kerning และช่วยให้การเรนเดอร์ของ Aspose.Slides สอดคล้องกับผลลัพธ์ภาพของ PowerPoint สำหรับฟอนต์ที่ได้รับผลกระทบจากพฤติกรรมเฉพาะของ PowerPoint นี้

## **จัดการคุณสมบัติแบบอักษรของข้อความ**

คุณสมบัติแบบอักษรสามารถตั้งค่าที่ระดับย่อหน้าผ่าน [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) หรือบนส่วนแต่ละส่วนผ่าน [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/)

ตัวอย่างต่อไปนี้ตั้งค่าแบบอักษรเริ่มต้นของย่อหน้าแรกเป็น Times New Roman ขนาด 12 จุด พร้อมการจัดรูปแบบตัวหนา, ตัวเอียง, และขีดเส้นใต้แบบจุด จุดไฮไลต์ที่ระบุโดยตรงบนส่วนแต่ละส่วนจะมีลำดับความสำคัญเหนือค่านี้:

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

![The font properties for the paragraph](font_properties_for_paragraph.png)

ตัวอย่างต่อไปนี้นำ Times New Roman ขนาด 13 จุด, การจัดรูปแบบตัวเอียง, และขีดเส้นใต้แบบจุด ไปใช้กับส่วนที่มีการจัดรูปแบบที่มีผลรวมเป็นตัวหนา:

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

![The font properties for text portions](font_properties_for_text_portions.png)

## **ควบคุมการทำ Normalisation ความสูงของข้อความ**

ใช้ [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) เมื่อต้องทำสำเนาแบบอักษรจากแม่แบบหรือสอบสวนความแตกต่างของความสูงอักขระ ใน PowerPoint การเปิดใช้งานการทำ Normalisation จะยืดหรือบีบอัดอักขระแต่ละตัวในแนวตั้งให้มีความสูงที่มองเห็นได้สม่ำเสมอภายในส่วนข้อความ แต่ไม่ได้รับประกันว่าความสูงของข้อความจะเท่ากันในฟอนต์ต่างกัน

ตั้งค่าเป็น [NullableBool.True หรือ False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) เพื่อเปิดหรือปิดการทำ Normalisation อย่างชัดเจน `NullableBool.NotDefined` จะปล่อยให้การตั้งค่าท้องถิ่นว่างเปล่าเพื่อให้ส่วนสืบทอดค่าจากที่อื่น เช่น จาก [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) ของย่อหน้า มันไม่เท่ากับ `False` ใช้ [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) และอ่าน [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) เพื่อรับค่า Boolean ที่แก้ไขแล้ว

ตัวอย่างต่อไปนี้ต้องมี **Arial** ติดตั้ง มันสร้างบล็อกข้อความสองบล็อกที่มีอักษรตัวพิมพ์ใหญ่, ตัวพิมพ์เล็ก, ตัวลงล่าง, และอักขระมีสำเนียงที่ขนาด 54 จุด ทั้งสองย่อหน้ามีการเปิด Normalisation โดยค่าเริ่มต้น ส่วนบนปิด Normalisation อย่างชัดเจน; ส่วนล่างสืบทอดค่า การตั้งค่าขนาดกรอบ, ระยะขอบ, และระยะห่างย่อหน้าตรงกัน, ปิดการตัดบรรทัดและ Autofit เพื่อให้การเปรียบเทียบสอดคล้อง ตัวอย่างพิมพ์ `False: False` และ `NotDefined: True` แล้วบันทึกเป็น "text_height_normalization.pptx"

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var settings = new[] { NullableBool.False, NullableBool.NotDefined };

for (var i = 0; i < settings.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Text = "Hxgjpq ÅÉ 0123";
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.MarginTop = 0;
    textFrame.TextFrameFormat.MarginLeft = 0;

    var paragraph = textFrame.Paragraphs[0];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceBefore = 0;
    paragraph.ParagraphFormat.SpaceAfter = 0;
    paragraph.ParagraphFormat.SpaceWithin = 100;
    paragraph.ParagraphFormat.DefaultPortionFormat.NormaliseHeight = NullableBool.True;

    var portion = paragraph.Portions[0];
    portion.PortionFormat.LatinFont = new FontData("Arial");
    portion.PortionFormat.FontHeight = 54;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.NormaliseHeight = settings[i];

    Console.WriteLine($"{settings[i]}: {portion.PortionFormat.GetEffective().NormaliseHeight}");
}

presentation.Save("text_height_normalization.pptx", SaveFormat.Pptx);
```

การเปรียบเทียบด้านล่างส่งออกจากงานนำเสนอที่บันทึก ส่วนบนมี Normalisation ปิด (`False`) ส่วนล่างสืบทอดค่าที่เปิด (`NotDefined` → `True`) ควรติดตั้ง Arial เพื่อทำให้ภาพนี้แสดงผลได้

![Arial 54-point text with normalization disabled above and inherited normalization enabled below](text_height_normalization.png)

การทำ Normalisation เปลี่ยนความสูงของอักขระโดยไม่เปลี่ยนค่า [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) ที่ระบุขนาดฟอนต์เป็นจุด ย่อหน้า [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) ควบคุมระยะห่างบรรทัด, ในขณะที่ [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) ของกรอบข้อความควบคุมวิธีที่ข้อความหรือคอนเทนเนอร์ปรับขนาดเพื่อให้พอดี การตั้งค่าเหล่านี้มีจุดประสงค์ต่างกันและอาจส่งผลต่อการจัดวางโดยรวมได้อย่างอิสระ สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการจัดรูปแบบย่อหน้าและการสืบทอด ดูที่ [Manage Paragraph](/slides/th/net/manage-paragraph/).

## **ใช้และลบขีดฆ่า**

ใช้ [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) บนส่วนข้อความเพื่อแสดงการแก้ไข, คำที่ยกเลิก, หรือราคาก่อนหน้าโดยไม่ต้องลบข้อความเดิม ตั้งค่าเป็น [TextStrikethroughType.Single หรือ Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) เพื่อใส่เส้นขีดหนึ่งหรือสองเส้นผ่านข้อความ

เพื่อเอาขีดฆ่าออก ให้กำหนด `TextStrikethroughType.None` ซึ่งจะปิดผลนี้อย่างชัดเจน แม้ว่าการจัดรูปแบบรอบข้างจะกำหนดให้มีขีดฆ่า ก็ตาม `TextStrikethroughType.NotDefined` จะปล่อยให้การตั้งค่าท้องถิ่นว่างเปล่าเพื่อให้ส่วนสืบทอดการจัดรูปแบบจากที่อื่น เช่น จากย่อหน้า มันไม่รับประกันว่าขีดฆ่าจะถูกลบ ใช้ [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) เพื่ออ่านการจัดรูปแบบที่ได้รวมถึงค่าที่สืบทอด

ตัวอย่างต่อไปนี้สร้างการเปรียบเทียบราคา 3 รายการ แต่ละย่อหน้ามีส่วนที่แยกสำหรับป้าย, ราคาก่อนหน้า, และราคาปัจจุบัน ดังนั้นเฉพาะราคาก่อนหน้าถูกกระทบ ส่วนแรกทำการใช้และลบขีดฆ่า ส่วนที่เหลือคงไว้ด้วยขีดฆ่าแบบหนึ่งและแบบสอง การเปลี่ยนแปลงคุณสมบัตินี้จะคงข้อความและการจัดรูปแบบอื่น ๆ ไว้รวมถึงราคาก่อนหน้าที่เป็นตัวหนา

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

var labels = new[] { "None: ", "Single: ", "Double: " };

foreach (var label in labels)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceAfter = 20;

    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    format.FontHeight = 28;
    format.LatinFont = new FontData("Arial");
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    paragraph.Portions.Add(new Portion(label));

    var previousPrice = new Portion("$100");
    previousPrice.PortionFormat.FontBold = NullableBool.True;
    paragraph.Portions.Add(previousPrice);
    paragraph.Portions.Add(new Portion(" → $80"));
    
    shape.TextFrame.Paragraphs.Add(paragraph);
}

var paragraphs = shape.TextFrame.Paragraphs;

// ใช้การขีดฆ่าแล้วลบออกอย่างชัดเจนจากราคาก่อนหน้าตัวแรก.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

ผลลัพธ์จากบนลงล่าง: ไม่มีขีดฆ่า, มีขีดฆ่าแบบหนึ่ง, และมีขีดฆ่าแบบสอง

![Previous prices without strikethrough, with single strikethrough, and with double strikethrough](strikethrough.png)

## **ตั้งค่าการหมุนของข้อความ**

ใช้ [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) เพื่อกำหนดทิศทางข้อความที่กำหนดล่วงหน้าภายในรูปร่าง

ตัวอย่างโค้ดต่อไปนี้ตั้งค่าทิศทางข้อความในรูปร่างเป็น [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), ซึ่งจะหมุนข้อความ **90 องศาแบบหมุนทวนเข็มนาฬิกา**:

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

![The text rotation](text_rotation.png)

## **ตั้งค่าการหมุนแบบกำหนดเองสำหรับกรอบข้อความ**

ใช้ [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) เพื่อกำหนดมุมการหมุนที่กำหนดเองสำหรับ [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)

โค้ดต่อไปนี้หมุนกรอบข้อความ 3 องศาแบบตามเข็มนาฬิกาภายในรูปร่าง:

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

![The custom text rotation](custom_text_rotation.png)

## **ตั้งค่าการจัดระยะห่างบรรทัดของย่อหน้า**

Aspose.Slides มี [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/), และ [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) เพื่อควบคุมระยะห่างของย่อหน้า คุณสมบัติเหล่านี้ใช้ดังนี้

* ใช้ค่าบวกเพื่อกำหนดระยะห่างบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าลบเพื่อกำหนดระยะห่างบรรทัดเป็นจุด

ตัวอย่างต่อไปนี้ตั้งค่าการจัดระยะห่างภายในย่อหน้าแรกเป็น 200% ของความสูงบรรทัด (ระยะห่างสองเท่า):

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

![The line spacing within the paragraph](line_spacing.png)

## **ควบคุมการตัดบรรทัด**

กฎการตัดบรรทัดของย่อหน้ามีประโยชน์ในบล็อกข้อความแคบและงานนำเสนอที่ผสมข้อความละตินและเอเชียตะวันออก ตัวคุณสมบัติดังต่อไปนี้เป็นของ [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), ดังนั้นจึงใช้กับย่อหน้าเต็ม:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) ควบคุมกฎการตัดบรรทัดละติน ในข้อความผสม การเปลี่ยนแปลงอาจส่งผลต่อจุดที่ข้อความเอเชียตะวันออกและเครื่องหมายวรรคตอนใกล้เคียงตัดบรรทัดด้วย
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) ควบคุมกฎการตัดบรรทัดเอเชียตะวันออก รวมถึงข้อจำกัดของอักขระที่ตำแหน่งต้นหรือปลายบรรทัด

กฎเหล่านี้ไม่ได้แทนที่ [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), ซึ่งเปิดการตัดบรรทัดอัตโนมัติภายในกรอบข้อความ พวกมันมีอิทธิพลต่อการจัดวางเมื่อเกิดการตัดบรรทัด; พวกมันไม่ได้ใส่อักขระตัดบรรทัด การตัดบรรทัดแบบชัดเจน (explicit line break) จะบังคับให้บรรทัดใหม่ภายในย่อหน้าโดยไม่คำนึงถึงความกว้างที่มี

ตัวอย่างต่อไปนี้สร้างบล็อกข้อความแคบที่มีข้อความจีนและละติน ตั้งค่ากฎการตัดบรรทัดทั้งสองอย่างชัดเจนและบันทึกเป็น "line_breaking.pptx". เพื่อทดลองกับกฎใดกฎหนึ่ง ให้เปลี่ยนค่าของคุณสมบัตินั้นขณะยังคงตั้งค่าที่เหลือตามเดิม ตัวอย่างใช้ Arial 24 จุดและ SimSun กับความกว้างกรอบ 160 จุดและระยะขอบแนวนอนของกรอบข้อความศูนย์ [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) ถูกตั้งเป็น [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) เพื่อให้ขนาดข้อความและมิติกรอบคงที่

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

## **ควบคุมการห้อยเครื่องหมายวรรคตอน**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) ทำให้เครื่องหมายวรรคตอนที่มีคุณสมบัติเหมาะสมสามารถขยายออกไปเหนือขอบขวาของเส้นข้อความแทนการอยู่ในบรรทัดถัดไป มันใช้กับย่อหน้าทั้งหมดและต่างจากการเยื้องบรรทัดแบบห้อย

ตัวอย่างต่อไปนี้เปิดการห้อยเครื่องหมายวรรคตอนในกรอบข้อความกว้าง 100 จุดและบันทึกเป็น "hanging_punctuation.pptx". ด้วย Arial 24 จุดและระยะขอบแนวนอนศูนย์ จุดสุดท้ายของประโยคจะอยู่หลังคำว่า "sentence" และขยายออกไปเหนือขอบขวาของข้อความ ตั้งค่าคุณสมบัติเป็น [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) เพื่อเปรียบเทียบ: ด้วยการตั้งค่านี้ จุดสุดท้ายจะอยู่ในบรรทัดแยก การตัดบรรทัดเปิดและ autofit ปิดเพื่อคงความกว้างที่มี

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

ไม่ใช่ทุกเครื่องหมายวรรคตอนที่จะห้อยได้ เงื่อนไขของฟอนต์และการจัดวางที่อธิบายไว้ในส่วน [ควบคุมการตัดบรรทัด](#control-line-breaking) ก็ใช้กับการเปรียบเทียบนี้เช่นกัน: การเปลี่ยนฟอนต์, ความกว้างที่ใช้ได้, ระยะขอบ, หรือการตั้งค่า autofit สามารถทำให้ความแตกต่างที่มองเห็นได้หายไป

## **ตั้งค่าชนิด Autofit สำหรับกรอบข้อความ**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) กำหนดว่าข้อความทำพฤติกรรมอย่างไรเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้มันเพื่อควบคุมว่าข้อความจะหด, ไหลออกนอก, หรือปรับขนาดรูปร่างโดยอัตโนมัติ ตัวอย่างต่อไปนี้กำหนดให้รูปร่างปรับขนาดเพื่อให้พอดีกับข้อความและบันทึกผลเป็น "autofit_type.pptx"

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

หากต้องการนับบรรทัดหลังการตัดบรรทัดอัตโนมัติและดูว่าความกว้างของข้อความหรือรูปร่างเปลี่ยนผลอย่างไร ให้ดูที่ [Count Rendered Lines](/slides/th/net/manage-paragraph/). จำนวนบรรทัดเพียงอย่างเดียวไม่ได้บ่งบอกว่าข้อความไหลออกนอกคอนเทนเนอร์หรือไม่

## **ตั้งค่าการยึดของกรอบข้อความ**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) กำหนดว่าข้อความถูกวางตำแหน่งแนวตั้งภายในรูปร่างอย่างไร เช่น ที่ด้านบน, กลาง, หรือด้านล่าง ตัวอย่างต่อไปนี้ยึดข้อความไปยังด้านล่างของรูปร่างแรกและบันทึกผลเป็น "text_anchor.pptx"

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าการแท็บของข้อความ**

ใช้ [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) และ [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) เพื่อกำหนดจุดหยุดแท็บในย่อหน้า ตัวอย่างต่อไปนี้ตั้งค่าช่วงระยะแท็บเริ่มต้นเป็น 100 จุดและเพิ่มจุดหยุดแท็บแบบจัดซ้ายที่ 30 จุด การตั้งค่าเหล่านี้มีผลต่อข้อความที่มีอักขระแท็บ

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

![The paragraph tabs](paragraph_tabs.png)

## **ตั้งค่าภาษา proofing**

Aspose.Slides มี [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) ให้คุณตั้งค่าภาษา proofing สำหรับส่วนข้อความ ภาษา proofing กำหนดภาษาที่ใช้ตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

ตัวอย่างต่อไปนี้ต้องมีไฟล์ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรกและมีอย่างน้อยหนึ่งย่อหน้า มันแทนที่เนื้อหาของย่อหน้าแรกด้วย "1。", ตั้งค่า SimSun เป็นฟอนต์, และกำหนดภาษา proofing ภาษาจีนอย่างง่าย (`zh-CN`). จากนั้นบันทึกผลเป็น "proofing_language.pptx":

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

// ตั้งค่าภาษา proofing เป็นภาษาจีนแบบ Simplified.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **คัดลอกเมตาดาต้าภาษา**

เมื่อคัดลอกข้อความหลายภาษาจากแม่แบบ ใหรักษา [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) และ [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/) ไว้ ตัวอย่างต่อไปนี้สร้างส่วนต้นแบบที่มีภาษาอังกฤษสหรัฐเป็นภาษาและฝรั่งเศสเป็นภาษาทางเลือก แล้วคัดลอกข้อความและตัวระบุไปยังส่วนในงานนำเสนอใหม่

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new Portion("Hello! Bonjour!");
source.PortionFormat.LanguageId = "en-US";
source.PortionFormat.AlternativeLanguageId = "fr-FR";

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var destination = new Portion();
destination.Text = source.Text;
destination.PortionFormat.LanguageId = source.PortionFormat.LanguageId;
    // หากแหล่งที่มไม่มีภาษาทางเลือกค่า null จะล้างค่าของปลายทาง.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

หากต้องการทดสอบแหล่งที่ไม่มีภาษาแทนที่ ให้ละเว้นการกำหนดค่า `"fr-FR"` ตัวระบุทางเลือกจะเป็น `null` และคำสั่งคัดลอกเดียวกันจะรักษาการไม่มีค่านั้นโดยไม่สร้างค่าติดตั้งเริ่มต้น แม้ปลายทางจะเคยมีภาษาทางเลือกกำหนดไว้ก็ตาม

ตัวระบุเหล่านี้เป็นเมตาดาต้าภาษา การรักษาพวกมันไว้ไม่ได้กำหนดว่าพจนานุกรมใดของ PowerPoint จะถูกเลือกสำหรับการตรวจสอบการสะกดหรือไวยากรณ์

## **ตั้งค่าภาษาดีฟอลต์**

ใช้ [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) เพื่อกำหนดภาษาดีฟอลต์สำหรับข้อความที่สร้างขณะโหลดหรือสร้างงานนำเสนอ ตัวอย่างต่อไปนี้สร้างงานนำเสนอที่มีภาษาอังกฤษสหรัฐเป็นภาษาข้อความดีฟอลต์, เพิ่มกล่องข้อความ, และพิมพ์ `en-US` สำหรับส่วนข้อความแรก

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// เพิ่มรูปสี่เหลี่ยมใหม่พร้อมข้อความ.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// ตรวจสอบภาษาของส่วนข้อความแรก.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **ตั้งค่ารูปแบบข้อความดีฟอลต์**

เพื่อใช้รูปแบบข้อความดีฟอลต์ในระดับงานนำเสนอ ใช้ [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/)

ตัวอย่างต่อไปนี้ตั้งค่าแบบอักษรขนาด 14 จุดและเป็นตัวหนาเป็นค่าดีฟอลต์สำหรับย่อหน้าในระดับบนของงานนำเสนอใหม่และบันทึกเป็น "default_text_style.pptx". ข้อความสามารถสืบทอดค่าดีฟอลต์เหล่านี้ได้ เว้นแต่การจัดรูปแบบที่เจาะจงมากกว่าจะทับไว้

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// รับรูปแบบย่อหน้าในระดับบนสุด.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **สกัดข้อความด้วยเอฟเฟกต์ All‑Caps**

ใน PowerPoint การใช้เอฟเฟกต์ฟอนต์ **All Caps** ทำให้ข้อความปรากฏเป็นตัวพิมพ์ใหญ่บนสไลด์ แม้ว่าต้นฉบับจะพิมพ์เป็นตัวพิมพ์เล็ก เมื่อคุณดึงส่วนข้อความเช่นนั้นด้วย Aspose.Slides ไลบรารีจะคืนค่าข้อความตามที่พิมพ์ไว้ เพื่อตรงกับข้อความที่แสดงบนสไลด์ ให้ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) และแปลงสตริงที่คืนค่ามาเป็นตัวพิมพ์ใหญ่เมื่อค่ามันเป็น `All`

ตัวอย่างนี้ต้องมีไฟล์ "sample2.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรก ย่อหน้าแรกของมันมีส่วนแรกที่มีข้อความ "Hello, Aspose!" พร้อมเอฟเฟกต์ All Caps ตามที่แสดงด้านล่าง

![The All Caps effect](all_caps_effect.png)

โค้ดต่อไปนี้แสดงวิธีสกัดข้อความที่มีเอฟเฟกต์ **All Caps** ถูกใช้:

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

**ฉันจะแก้ไขข้อความในตารางบนสไลด์อย่างไร?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ให้ใช้ [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). วนลูปผ่านเซลล์และอัปเดตแต่ละเซลล์ผ่าน [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) และจัดรูปแบบย่อหน้าผ่าน [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/)

**ฉันจะใส่สีไล่ระดับสีให้กับข้อความในสไลด์ PowerPoint ได้อย่างไร?**

เพื่อใส่สีไล่ระดับสีให้กับข้อความ ให้ใช้ [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). ตั้งค่า [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) เป็น [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) และกำหนดหยุดไล่ระดับ, ทิศทาง, และความโปร่งใส

ฟีเจอร์ที่เกี่ยวข้อง: [Format text within slides](/slides/th/features/text-formatting/).