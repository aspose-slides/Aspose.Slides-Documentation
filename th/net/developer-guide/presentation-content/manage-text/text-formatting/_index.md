---
title: จัดรูปแบบข้อความนำเสนอใน .NET
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
- คุณสมบัติฟอนต์
- ตระกูลฟอนต์
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติ Autofit
- จุดยึดกรอบข้อความ
- การจัด Tab ของข้อความ
- ภาษาเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดรูปแบบและกำหนดสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ .NET ปรับแต่งฟอนต์, สี, การจัดแนว และอื่น ๆ."
---
## **ภาพรวม**

บทความนี้แสดงวิธีจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides for .NET ครอบคลุมสีพื้นหลัง ความโปร่งใส ระยะห่างระหว่างอักขระ คุณสมบัติฟอนต์ การหมุน ระยะห่างของย่อหน้า พฤติกรรม autofit การยึดตำแหน่งข้อความ จุดหยุดแท็บ และการตั้งค่าภาษา

ยกเว้นที่ระบุไว้เป็นอย่างอื่น ตัวอย่างจะใช้ [sample.pptx](sample.pptx) รูปร่างแรกบนสไลด์แรกเป็นกล่องข้อความและย่อหน้าแรกมีข้อความตามด้านล่าง ดัชนีสไลด์และรูปร่างใช้เลขฐานศูนย์ ตัวอย่างที่เลือกส่วนข้อความหนาตั้งค่าแบบฟอร์แมตที่ใช้งานจริงรวมถึงการสืบทอดการตั้งค่าแบบหนา:

![ข้อความตัวอย่าง](sample_text.png)

เพื่อค้นหาและเน้นข้อความตามตัวอักษรหรือผลลัพธ์ของ regular‑expression ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/net/search-and-replace-text/)

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้ [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) เพื่อตั้งค่าสีไฮไลต์เริ่มต้นสำหรับย่อหน้า หรือใช้ [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) สำหรับส่วนข้อความแต่ละส่วน

ตัวอย่างต่อไปนี้ตั้งค่าสีไฮไลต์สีเทาอ่อนเป็นค่าเริ่มต้นสำหรับย่อหน้าแรก การตั้งค่าสีไฮไลต์แบบเฉพาะบนส่วนข้อความจะลำดับความสำคัญเหนือค่าเริ่มต้น:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// ตั้งค่าสีไฮไลท์สำหรับย่อหน้าทั้งหมด.
presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ย่อหน้าสีเทา](gray_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่มีฟอนต์หนา** :

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

ใช้ [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) เพื่อตั้งค่าการจัดแนวย่อหน้าในกรอบข้อความ ค่าอาจเป็น centered, left‑aligned, right‑aligned, justified ฯลฯ

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดแนวย่อหน้าให้อยู่ **กึ่งกลาง** :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// ตั้งค่าการจัดแนวย่อหน้าให้อยู่ตรงกลาง.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ย่อหน้าที่จัดแนกแล้ว](aligned_paragraph.png)

## **จัดแนวฟอนต์ภายในบรรทัด**

ใช้ [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) เพื่อจัดแนวแนวนอนของส่วนข้อความที่มีขนาดฟอนต์ต่างกันภายในบรรทัด การตั้งค่านี้ใช้กับย่อหน้าทั้งหมดและควบคุมการจัดแนวภายในแต่ละบรรทัดของย่อหน้า

ตัวอย่างต่อไปนี้สร้างกล่องข้อความที่มีป้ายกำกับสี่กล่องบนสไลด์เดียว ย่อหน้าแต่ละย่อหน้ามีข้อความเดียวกันขนาด 18, 36, และ 54 จุด พร้อมการจัดแนวฟอนต์ที่แตกต่างกัน ใช้ Arial ปิด autofit และการตัดบรรทัด และทำให้กรอบข้อความใหญ่พอสำหรับบรรทัดเดียว

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

![เปรียบเทียบการจัดแนว Baseline, Top, Center, Bottom กับฟอนต์ขนาดผสม](font_alignment.png)

การจัดแนวฟอนต์อาศัยเมตริกของฟอนต์ ดังนั้นขอบของตัวอักษรแต่ละตัวอาจไม่ตรงกันอย่างสมบูรณ์ ตัวอย่างรวมอักษรพิมพ์ใหญ่และตัวที่ลงล่างเพื่อชี้ให้เห็นความแตกต่างระหว่าง baseline และ bottom ความพร้อมใช้งานของฟอนต์และการแทนที่ ตัวอักษรที่ใช้ และความแตกต่างของขนาดฟอนต์ทั้งหมดมีผลต่อผลลัพธ์ ขนาดกรอบ, ระยะขอบ, ระยะห่างบรรทัด, การตัดบรรทัดและ autofit ก็มีผลต่อการจัดวางเช่นกัน; ควรใช้ฟอนต์และการตั้งค่าเดียวกันเมื่อเปรียบเทียบโหมดต่าง ๆ

การตั้งค่านี้แตกต่างจาก [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) ซึ่งควบคุมการจัดแนวแนวนอนของย่อหน้า และ [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) ที่กำหนดตำแหน่งบล็อกข้อความในแนวตั้งภายในรูปร่าง การจัดฟอนต์ซับสคริปต์และซุปเปอร์สคริปต์ผ่าน [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) จะย้ายส่วนข้อความแต่ละส่วนตาม baseline แทนการตั้งค่าการจัดแนวฟอนต์สำหรับบรรทัดของย่อหน้า

## **ตั้งค่าความโปร่งใสของข้อความ**

ความโปร่งใสของข้อความควบคุมโดยส่วนประกอบแอลฟาของสีที่กำหนดให้ [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) ตัวอย่างด้านล่าง `alpha = 50` เป็นค่าแอลฟา ARGB บนสเกล 0–255 ไม่ใช่เปอร์เซ็นต์ความโปร่งใส

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ย่อหน้าทั้งหมด** :

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// ตั้งค่าสีเติมสีดำกึ่งโปร่งแสงสำหรับข้อความ.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ย่อหน้าที่โปร่งใส](transparent_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ส่วนข้อความที่มีฟอนต์หนา** :

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

## **ตั้งค่าระยะห่างระหว่างอักขระของข้อความ**

ใช้ [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) เพื่อขยายหรือยุบระยะห่างระหว่างอักขระในกล่องข้อความ ตัวอย่างเพิ่มระยะห่าง 3 จุด; ค่าติดลบจะทำให้ข้อความหนาแน่นขึ้น

โค้ด C# ต่อไปนี้แสดงวิธีขยายระยะห่างอักขระใน **ย่อหน้าทั้งหมด** :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างระหว่างอักขระ.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // ขยายระยะห่างระหว่างอักขระ.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ระยะห่างอักขระในย่อหน้า](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีขยายระยะห่างอักขระใน **ส่วนข้อความที่มีฟอนต์หนา** :

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
        portion.PortionFormat.Spacing = 3;  // ขยายระยะห่างระหว่างอักขระ.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ระยะห่างอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการใช้งาน Kerning สำหรับฟอนต์เฉพาะ**

ในบางกรณีข้อความที่เรนเดอร์ด้วย Aspose.Slides อาจดูแคบกว่าข้อความเดียวกันใน PowerPoint เนื่องจาก PowerPoint อาจละเว้นข้อมูล kerning ของฟอนต์บางตัว แม้ฟอนต์จะมีข้อมูล kerning ที่ถูกต้องและเปิดใช้งานในการตั้งค่าของ PowerPoint

เพื่อให้ผลลัพธ์ที่เรนเดอร์ใกล้เคียงกับ PowerPoint มากขึ้น คุณสามารถปิดการใช้งาน kerning สำหรับส่วนข้อความที่ใช้ฟอนต์นั้นได้ ตั้งค่า [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) ให้มีค่ามากกว่าขนาดฟอนต์จริง ตัวอย่างนี้ต้องการไฟล์ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปร่างแรกบนสไลด์แรก ตรวจสอบชื่อฟอนต์ที่ใช้งานจริงรวมถึงฟอนต์ที่สืบทอด และตั้งค่าเกณฑ์ 100 จุดสำหรับส่วนที่ใช้ Roboto ซึ่งจะปิด kerning สำหรับส่วนที่มีขนาดฟอนต์ต่ำกว่า 100 จุด :

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

สำหรับข้อความที่ตรงกับเกณฑ์นี้ การตั้งค่านี้จะป้องกันการทำ kerning และช่วยให้การเรนเดอร์ของ Aspose.Slides ตรงกับผลลัพธ์ที่มองเห็นใน PowerPoint สำหรับฟอนต์ที่ได้รับผลกระทบจากพฤติกรรมเฉพาะของ PowerPoint นี้

## **จัดการคุณสมบัติกของฟอนต์ข้อความ**

คุณสมบัติของฟอนต์สามารถตั้งค่าที่ระดับย่อหน้าได้ผ่าน [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) หรือบนส่วนข้อความแต่ละส่วนผ่าน [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/)

ตัวอย่างต่อไปนี้ตั้งค่าฟอนต์เริ่มต้นของย่อหน้าแรกเป็น Times New Roman ขนาด 12 จุด พร้อมการจัดรูปแบบหนา, เทคนิค, และขีดเส้นใต้เป็นจุด สีที่กำหนดโดยส่วนข้อความเฉพาะจะเหนือกว่าค่าตั้งต้นเหล่านี้ :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// ตั้งค่าคุณสมบัติฟอนต์สำหรับย่อหน้า.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![คุณสมบัติฟอนต์ของย่อหน้า](font_properties_for_paragraph.png)

ตัวอย่างต่อไปนี้ใช้ Times New Roman ขนาด 13 จุด, การจัดรูปแบบอักษรเอียง, และขีดเส้นใต้เป็นจุดกับส่วนข้อความที่มีการจัดรูปแบบแบบ effective เป็นแบบหนา :

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
        // ตั้งค่าคุณสมบัติฟอนต์สำหรับส่วนข้อความ.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![คุณสมบัติฟอนต์ของส่วนข้อความ](font_properties_for_text_portions.png)

## **ควบคุมการทำ Normalisation ความสูงของข้อความ**

ใช้ [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) เมื่อต้องการทำ Normalisation ตัวอักษรในเทมเพลตหรือเมื่อศึกษาความแตกต่างของความสูงอักขระ ใน PowerPoint การเปิดใช้งาน Normalisation จะขยายหรือบีบอัดอักขระแต่ละตัวในแนวตั้งให้มีความสูงที่มองเห็นได้สม่ำเสมอภายในส่วนข้อความ แต่ไม่ได้รับประกันว่าความสูงของข้อความทั้งหมดจะแน่นอนในฟอนต์ต่าง ๆ

ตั้งค่าคุณลักษณะนี้เป็น [NullableBool.True หรือ False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) เพื่อเปิดหรือปิด Normalisation อย่างชัดเจน `NullableBool.NotDefined` จะปล่อยให้การตั้งค่าท้องถิ่นว่างเปล่า เพื่อให้ส่วนข้อความสืบทอดค่าจาก [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) ของย่อหน้า ไม่ได้หมายถึง `False` ใช้ [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) และอ่าน [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) เพื่อรับค่าบูลีนที่แก้ไขแล้ว

ตัวอย่างต่อไปนี้ต้องมี **Arial** ติดตั้งไว้ มันสร้างบล็อกข้อความสองส่วนที่มีอักษรพิมพ์ใหญ่, พิมพ์เล็ก, ตัวลงล่าง และอักขระมีสำเนียงเดียวกันขนาด 54 จุด ทั้งสองย่อหน้าเปิด Normalisation โดยค่าเริ่มต้น ส่วนบนปิด Normalisation อย่างชัดเจน; ส่วนล่างสืบทอดค่าจากย่อหน้า การตั้งค่ากรอบ, ระยะขอบ, และระยะห่างย่อหน้าเหมือนกัน, ปิดการตัดบรรทัดและ Autofit เพื่อให้การเปรียบเทียบคงที่ ตัวอย่างพิมพ์ `False: False` และ `NotDefined: True` แล้วบันทึกเป็น "text_height_normalization.pptx"

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

ผลลัพธ์ที่ส่งออกจากไฟล์พรีเซนเทชันที่บันทึกไว้ แถวบนมี Normalisation ปิด (`False`) แถวล่างสืบทอดค่าที่เปิด (`NotDefined` → `True`) โปรดติดตั้ง Arial เพื่อให้ได้ผลลัพธ์เดียวกัน

![ข้อความ Arial ขนาด 54 จุดที่มี Normalisation ปิดด้านบนและ Normalisation สืบทอดด้านล่าง](text_height_normalization.png)

Normalisation เปลี่ยนความสูงอักขระโดยไม่กระทบค่าที่กำหนดใน [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) ซึ่งระบุขนาดฟอนต์เป็นจุด ย่อหน้า [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) ควบคุมระยะห่างบรรทัด ส่วน [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) ของกรอบข้อความควบคุมการปรับขนาดข้อความหรือกรอบเพื่อให้พอดี การตั้งค่าเหล่านี้ทำหน้าที่ต่างกันและอาจส่งผลต่อการจัดวางโดยรวมโดยอิสระ สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการจัดรูปแบบย่อหน้าและการสืบทอด ให้ดูที่ [จัดการย่อหน้า](/slides/th/net/manage-paragraph/)

## **ใช้และลบเส้นขีดฆ่า (Strikethrough)**

ใช้ [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) บนส่วนข้อความเพื่อแสดงการแก้ไข, คำที่ยกเลิก, หรือราคาก่อนหน้าโดยไม่ลบข้อความต้นฉบับ ตั้งค่าเป็น [TextStrikethroughType.Single หรือ Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) เพื่อแสดงหนึ่งหรือสองเส้นขีดผ่านข้อความ

เพื่อเอาเส้นขีดฆ่าออก ให้กำหนดค่า `TextStrikethroughType.None` ซึ่งจะปิดผลลัพธ์โดยชัดเจน แม้ว่าการจัดรูปแบบโดยรอบจะระบุให้มีเส้นขีดฆ่า ต่างจาก `TextStrikethroughType.NotDefined` ที่ปล่อยให้การตั้งค่าท้องถิ่นว่างเปล่า ทำให้ส่วนข้อความสืบทอดการจัดรูปแบบจากย่อหน้า ตัวเลือกนี้อาจไม่ได้ลบเส้นขีดฆ่าออกโดยอัตโนมัติ ใช้ [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) เพื่ออ่านค่าการจัดรูปแบบที่ได้รวมถึงค่าที่สืบทอด

ตัวอย่างต่อไปนี้สร้างการเปรียบเทียบราคาสามกรณี ย่อหน้าแต่ละย่อหน้ามีส่วนข้อความแยกสำหรับป้าย, ราคาก่อนหน้า, และราคาปัจจุบัน ดังนั้นจึงมีผลต่อเฉพาะราคาก่อนหน้า แถวแรกใช้และลบเส้นขีดฆ่า; แถวอื่นรักษาเส้นขีดฆ่าแบบเดี่ยวและแบบคู่ การเปลี่ยนแปลงคุณสมบัตินี้ทำให้ข้อความและการจัดรูปแบบอื่น ๆ รวมถึงการทำให้ราคาก่อนหน้าเป็นแบบหนา ยังคงอยู่

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

// ใช้เส้นขีดฆ่า จากนั้นลบออกอย่างชัดเจนจากราคาก่อนหน้าตัวแรก.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

ผลลัพธ์จากบนลงล่าง: ไม่มีเส้นขีดฆ่า, เส้นขีดฆ่าแบบเดี่ยว, และเส้นขีดฆ่าแบบคู่

![ราคาก่อนหน้าไม่มีเส้นขีดฆ่า, มีเส้นขีดฆ่าแบบเดี่ยว, และมีเส้นขีดฆ่าแบบคู่](strikethrough.png)

## **ตั้งค่าการหมุนของข้อความ**

ใช้ [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) เพื่อกำหนดทิศทางข้อความที่กำหนดล่วงหน้าในรูปร่าง

ตัวอย่างโค้ดต่อไปนี้ตั้งค่าทิศทางข้อความในรูปร่างเป็น [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) ซึ่งจะหมุนข้อความ **90 องศาตรงข้ามเข็มนาฬิกา** :

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

## **แสดงตัวเลขติดกันในข้อความแนวตั้ง**

เพื่อให้ตัวเลขสองหลักอยู่ติดกันในป้ายภาษาญี่ปุ่นแนวตั้ง ให้ใส่ทั้งสองหลักในส่วนข้อความเดียวและตั้งค่า [IBasePortionFormat.Kumimoji](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kumimoji/) สำหรับส่วนนั้น ตัวอย่างใช้ [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) และฟอนต์ MS Gothic ขนาด 40 จุดสำหรับทั้งสองป้าย ค่าที่แตกต่างกันเพียงอย่างเดียวคือค่า [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) ที่กำหนดให้กับส่วนตัวเลข

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

AddLabel(slide, 120, NullableBool.True);
AddLabel(slide, 360, NullableBool.False);

presentation.Save("vertical_date.pptx", SaveFormat.Pptx);

static void AddLabel(ISlide slide, float x, NullableBool kumimoji)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;

    var frame = label.AddTextFrame("");
    frame.TextFrameFormat.TextVerticalType = TextVerticalType.EastAsianVertical;

    var paragraph = frame.Paragraphs[0];
    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    var font = new FontData("MS Gothic");
    format.LatinFont = font;
    format.EastAsianFont = font;
    format.FontHeight = 40;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var digits = new Portion("12");
    digits.PortionFormat.Kumimoji = kumimoji;
    
    paragraph.Portions.Clear();
    paragraph.Portions.Add(new Portion("令和"));
    paragraph.Portions.Add(digits);
    paragraph.Portions.Add(new Portion("年"));
}
```

ใน PowerPoint ป้ายซ้าย (`True`) แสดงตัวเลขตรงและอยู่ข้างกันระหว่าง 和 และ 年 ส่วนป้ายขวา (`False`) ตัวเลขจะหมุน 90 องศาตามเข็มนาฬิกา ตัวอักษรญี่ปุ่นรอบข้างยังคงตรงในทั้งสองป้าย

![การเปรียบเทียบป้ายวันที่แนวตั้งใน PowerPoint ที่มีตัวเลขตรงด้านซ้ายและหมุนด้านขวา](vertical_date.png)

## **ตั้งค่าการหมุนแบบกำหนดเองสำหรับกรอบข้อความ**

ใช้ [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) เพื่อกำหนดมุมการหมุนแบบกำหนดเองให้กับ [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)

ตัวอย่างโค้ดด้านล่างหมุนกรอบข้อความ 3 องศาตามเข็มนาฬิกาภายในรูปร่าง :

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

## **ตั้งค่าการระยะห่างบรรทัดของย่อหน้า**

Aspose.Slides มี [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/), และ [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) เพื่อควบคุมระยะห่างของย่อหน้า การใช้คุณสมบัติเหล่านี้มีดังนี้ :

* ใช้ค่าบวกเพื่อกำหนดระยะห่างเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าลบเพื่อกำหนดระยะห่างเป็นจุด

ตัวอย่างต่อไปนี้ตั้งค่าระยะห่างภายในย่อหน้าแรกเป็น 200 % ของความสูงบรรทัด (สองเท่า) :

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

![ระยะห่างบรรทัดภายในย่อหน้า](line_spacing.png)

## **ควบคุมการตัดบรรทัด**

กฎการตัดบรรทัดของย่อหน้าเป็นประโยชน์ในบล็อกข้อความแคบและการนำเสนอที่ผสมระหว่างข้อความละตินและข้อความเอเชียตะวันออก คุณสมบัติดังต่อไปนี้เป็นของ [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/) ดังนั้นจึงใช้กับย่อหน้าทั้งหมด :

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) ควบคุมกฎการตัดบรรทัดของละติน หากใช้กับข้อความผสมอาจเปลี่ยนตำแหน่งการตัดบรรทัดของข้อความเอเชียตะวันออกและเครื่องหมายวรรคตอน
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) ควบคุมกฎการตัดบรรทัดของเอเชียตะวันออก รวมถึงข้อจำกัดของอักขระที่อยู่ต้นหรือปลายบรรทัด

กฎเหล่านี้ไม่ทดแทน [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) ซึ่งเปิดการตัดบรรทัดอัตโนมัติภายในกรอบข้อความ พวกมันส่งผลต่อการจัดวางเมื่อเกิดการตัดบรรทัด; ไม่ได้ใส่อักขระการตัดบรรทัด การตัดบรรทัดอย่างชัดเจนจะบังคับให้เกิดบรรทัดใหม่ภายในย่อหน้าโดยไม่คำนึงถึงความกว้างที่มี

ตัวอย่างต่อไปนี้สร้างบล็อกข้อความแคบที่มีทั้งภาษาจีนและละติน ตั้งค่ากฎการตัดบรรทัดทั้งสองอย่างชัดเจนและบันทึกเป็น "line_breaking.pptx" เพื่อลองเปลี่ยนค่าของกฎใดกฎหนึ่งขณะที่คงค่าของอีกกฎหนึ่งไว้ ตัวอย่างใช้ Arial ขนาด 24 จุดและ SimSun พร้อมความกว้างกรอบ 160 จุดและระยะขอบแนวนอนของกรอบข้อความเป็นศูนย์ [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) ถูกตั้งเป็น [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) เพื่อให้ขนาดข้อความและขนาดกรอบคงที่

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

## **ควบคุมการแขวนเครื่องหมายวรรคตอน**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) ทำให้เครื่องหมายวรรคตอนที่เหมาะสมขยายออกไปเกินขอบขวาของบรรทัดข้อความแทนการย้ายไปบรรทัดถัดไป ใช้กับย่อหน้าทั้งหมดและแตกต่างจากการเยื้องแบบ hanging

ตัวอย่างต่อไปนี้เปิดใช้งานการแขวนเครื่องหมายวรรคตอนในกรอบข้อความความกว้าง 100 จุดและบันทึกเป็น "hanging_punctuation.pptx" ด้วย Arial ขนาด 24 จุดและระยะขอบแนวนอนเป็นศูนย์ จุดสุดท้ายจะอยู่หลังคำว่า "sentence" และขยายเกินขอบขวาของข้อความ ตั้งค่าคุณลักษณะเป็น [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) เพื่อเปรียบเทียบ: ด้วยการตั้งค่านี้ จุดสุดท้ายจะอยู่บนบรรทัดแยกต่างหาก การตัดบรรทัดเปิดใช้งานและ autofit ปิดเพื่อคงความกว้างที่กำหนดไว้

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

ไม่ใช่เครื่องหมายวรรคตอนทุกตัวที่สามารถแขวนได้ เงื่อนไขของฟอนต์และการจัดวางที่อธิบายไว้ข้างต้น ([ดูหัวข้อ ควบคุมการตัดบรรทัด](#control-line-breaking)) ก็กำหนดผลลัพธ์เช่นกัน การเปลี่ยนฟอนต์, ความกว้างที่ใช้, ระยะขอบ หรือการตั้งค่า autofit อาจทำให้ความแตกต่างที่มองเห็นหายไป

## **ตั้งค่าประเภท Autofit สำหรับกรอบข้อความ**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) กำหนดว่าข้อความทำอย่างไรเมื่อตัวอักษรเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าจะให้ข้อความย่อขนาด, ล้นออกนอกกรอบ, หรือให้รูปร่างปรับขนาดอัตโนมัติ ตัวอย่างต่อไปนี้กำหนดให้รูปร่างปรับขนาดให้พอดีกับข้อความและบันทึกผลเป็น "autofit_type.pptx"

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

เพื่อดูจำนวนบรรทัดหลังการตัดบรรทัดอัตโนมัติและดูว่าขนาดข้อความหรือความกว้างของรูปร่างเปลี่ยนผลลัพธ์อย่างไร ดูที่ [Count Rendered Lines](/slides/th/net/manage-paragraph/) จำนวนบรรทัดเพียงอย่างเดียวไม่บ่งบอกว่าข้อความล้นคอนเทนเนอร์หรือไม่

## **ตั้งค่า Anchor ของกรอบข้อความ**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) กำหนดว่าข้อความตั้งตำแหน่งแนวตั้งภายในรูปร่างอย่างไร เช่น ด้านบน, กลาง, หรือด้านล่าง ตัวอย่างต่อไปนี้ยึดข้อความไว้ที่ด้านล่างของรูปร่างแรกและบันทึกผลเป็น "text_anchor.pptx"

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าการจัด Tab ของข้อความ**

ใช้ [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) และ [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) เพื่อกำหนดจุดหยุดแท็บในย่อหน้า ตัวอย่างต่อไปนี้ตั้งค่าช่วงแท็บเริ่มต้นเป็น 100 จุดและเพิ่มจุดหยุดแท็บซ้ายที่ 30 จุด การตั้งค่าเหล่านี้มีผลต่อข้อความที่มีอักขระแท็บ

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

## **ตั้งค่าภาษา Proofing**

Aspose.Slides มี [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) ให้คุณตั้งค่าภาษา proofing สำหรับส่วนข้อความ ภาษา proofing จะกำหนดภาษาที่ใช้สำหรับการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

ตัวอย่างต่อไปนี้ต้องการ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปร่างแรกบนสไลด์แรกและต้องมีอย่างน้อยหนึ่งย่อหน้า มันแทนที่เนื้อหาของย่อหน้าแรกด้วย "1。", ตั้งค่า SimSun เป็นฟอนต์และกำหนดภาษา proofing เป็นภาษาจีนตัวย่อ (`zh-CN`) แล้วบันทึกผลเป็น "proofing_language.pptx"

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

// ตั้งค่าภาษา proofing เป็นภาษาจีนตัวย่อ.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **คัดลอกเมตาดาต้าภาษา**

เมื่อคัดลอกข้อความหลายภาษาจากเทมเพลต ควรรักษา [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) และ [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/) ตัวอย่างต่อไปนี้สร้างส่วนข้อความต้นทางที่มีภาษา US English เป็นภาษาหลักและ French เป็นภาษาทางเลือก แล้วคัดลอกข้อความและตัวระบุไปยังส่วนข้อความในพรีเซนเทชันใหม่

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
// หากแหล่งที่ไม่มีภาษาเลือก ค่ null จะล้างค่าภาษาเลือกของปลายทาง.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

หากต้องการลองแหล่งที่ไม่มีภาษาเลือกให้ละเว้นการกำหนดค่า `"fr-FR"` ตัวระบุทางเลือกจะเป็น `null` และคำสั่งคัดลอกเดียวกันจะรักษาเงื่อนไขนี้ไว้โดยไม่สร้างค่าตั้งต้นแม้ว่าปลายทางเคยมีภาษาเลือกกำหนดไว้ก่อนหน้านี้

ตัวระบุเหล่านี้เป็นเมตาดาต้าภาษา การรักษาไว้ไม่ได้เป็นการกำหนดว่าพจนานุกรมใดของ PowerPoint จะใช้สำหรับการตรวจสอบการสะกดหรือไวยากรณ์

## **ตั้งค่าภาษาเริ่มต้น**

ใช้ [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) เพื่อกำหนดภาษาตั้งต้นสำหรับข้อความที่สร้างขณะโหลดหรือสร้างพรีเซนเทชัน ตัวอย่างต่อไปนี้สร้างพรีเซนเทชันที่มี US English เป็นภาษาข้อความเริ่มต้น เพิ่มกล่องข้อความและพิมพ์ `en‑US` สำหรับส่วนข้อความแรก

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// เพิ่มรูปสี่เหลี่ยมใหม่ที่มีข้อความ.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// ตรวจสอบภาษาของส่วนข้อความแรก.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **ตั้งค่า Default Text Style**

เพื่อใช้การจัดรูปแบบข้อความเริ่มต้นในระดับพรีเซนเทชัน ให้ใช้ [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/)

ตัวอย่างต่อไปนี้ตั้งค่าฟอนต์หนาขนาด 14 จุดเป็นค่าตั้งต้นสำหรับย่อหน้าในระดับบนของพรีเซนเทชันใหม่และบันทึกเป็น "default_text_style.pptx" ข้อความสามารถสืบทอดค่านี้ได้ เว้นแต่การจัดรูปแบบที่เจาะจงมากกว่าจะทับค่าตั้งต้นเหล่านี้

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

## **สกัดข้อความพร้อมเอฟเฟ็กต์ All‑Caps**

ใน PowerPoint การใช้เอฟเฟ็กต์ **All Caps** ทำให้ข้อความปรากฏเป็นตัวพิมพ์ใหญ่บนสไลด์ แม้ว่าจะพิมพ์เป็นตัวพิมพ์เล็ก ตัวอย่างโค้ดที่ดึงส่วนข้อความด้วย Aspose.Slides จะคืนค่าข้อความตามที่ป้อนไว้ เพื่อให้ได้ข้อความที่แสดงบนสไลด์ ให้ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) และแปลงสตริงที่ได้รับเป็นตัวพิมพ์ใหญ่เมื่อค่าที่ได้คือ `All`

ตัวอย่างนี้ต้องการ "sample2.pptx" ที่มีกล่องข้อความเป็นรูปร่างแรกบนสไลด์แรก ย่อหน้าแรกของมันมีส่วนแรกเป็น "Hello, Aspose!" พร้อมเอฟเฟ็กต์ All Caps ตามภาพด้านล่าง

![เอฟเฟ็กต์ All Caps](all_caps_effect.png)

โค้ดต่อไปนี้แสดงวิธีสกัดข้อความพร้อมเอฟเฟ็กต์ **All Caps** :

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

ผลลัพธ์ :

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**ฉันจะแก้ไขข้อความในตารางบนสไลด์อย่างไร?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ใช้ [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) วนลูปผ่านเซลล์และอัปเดตแต่ละเซลล์ผ่าน [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) และจัดรูปแบบย่อหน้าผ่าน [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/)

**ฉันจะใช้สีไล่ระดับสีกับข้อความบนสไลด์ PowerPoint อย่างไร?**

ใช้ [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) ตั้งค่า [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) เป็น [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) และกำหนดจุดหยุดไล่ระดับ, ทิศทาง, และความโปร่งใส

คุณลักษณะที่เกี่ยวข้อง : [จัดรูปแบบข้อความภายในสไลด์](/slides/th/features/text-formatting/)