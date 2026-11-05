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
- การเว้นระยะอักขระ
- คุณสมบัติตัวอักษร
- ตระกูลฟอนต์
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- การเว้นบรรทัด
- คุณสมบัติ autofit
- จุดยึดกรอบข้อความ
- การกำหนดแท็บข้อความ
- ภาษาตั้งต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดรูปแบบและสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET ปรับแต่งฟอนต์, สี, การจัดแนว และอื่น ๆ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides for .NET ครอบคลุมสีพื้นหลัง, ความโปร่งแสง, การเว้นระยะระหว่างอักขระ, คุณสมบัติตัวอักษร, การหมุน, การเว้นระยะย่อหน้า, พฤติกรรม autofit, การยึดข้อความ, จุดหยุดแท็บ, และการตั้งค่าภาษา.

หากไม่ได้ระบุเป็นพิเศษ ตัวอย่างจะใช้ [sample.pptx](sample.pptx) ข้อความแรกบนสไลด์แรกคือกล่องข้อความและย่อหน้าแรกของมันมีข้อความที่แสดงด้านล่าง ดัชนีสไลด์และรูปร่างเริ่มจากศูนย์ ตัวอย่างที่เลือกส่วนที่หนาใช้รูปแบบที่มีผลรวมถึงรูปแบบหนาที่สืบทอด:

![ข้อความตัวอย่าง](sample_text.png)

เพื่อค้นหาและไฮไลท์ข้อความตามตัวอักษรหรือผลการจับคู่แบบ regular-expression ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/net/search-and-replace-text/).

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้ [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) เพื่อกำหนดสีไฮไลท์เริ่มต้นสำหรับย่อหน้า หรือใช้ [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) สำหรับส่วนของข้อความแต่ละส่วน.

ตัวอย่างต่อไปนี้ตั้งค่าการไฮไลท์สีเทาอ่อนเป็นค่าเริ่มต้นสำหรับย่อหน้าแรก สีไฮไลท์ที่กำหนดแบบชัดเจนบนส่วนของข้อความแต่ละส่วนจะมีลำดับความสำคัญเหนือค่าตั้งต้นนี้:

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

ตัวอย่างโค้ดด้านล่างแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนของข้อความที่มีฟอนต์หนา**:

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
        // ตั้งค่าสีไฮไลท์สำหรับส่วนของข้อความ.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ส่วนข้อความสีเทา](gray_text_portions.png)

## **จัดแนวย่อหน้าข้อความ**

ใช้ [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) เพื่อกำหนดการจัดแนวย่อหน้าภายในกรอบข้อความ ค่าอาจเป็นการจัดกึ่งกลาง, จัดซ้าย, จัดขวา, จัดเต็ม, ฯลฯ

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดแนวย่อหน้าให้ **กึ่งกลาง**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// ตั้งค่าการจัดแนวของย่อหน้าให้เป็นกึ่งกลาง.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ย่อหน้า​ที่​จัดแนว​แล้ว](aligned_paragraph.png)

## **จัดแนวฟอนต์ภายในบรรทัด**

ใช้ [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) เพื่อจัดแนวแนวตั้งของส่วนข้อความที่มีขนาดฟอนต์ต่างกันภายในบรรทัด การตั้งค่านี้ใช้กับย่อหน้าทั้งหมดและควบคุมการจัดแนวภายในแต่ละบรรทัดของย่อหน้า

ตัวอย่างอิสระต่อไปนี้สร้างกล่องข้อความที่มีป้ายชื่อสี่กล่องบนสไลด์หนึ่งย่อหน้าแต่ละย่อมมีข้อความเดียวกันที่ขนาด 18, 36, และ 54 จุด โดยมีการจัดแนวฟอนต์ที่ต่างกัน ใช้ Arial ปิดการทำ autofit และการตัดบรรทัด และทำให้กรอบข้อความใหญ่พอสำหรับบรรทัดเดียว

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

![การเปรียบเทียบการจัดแนวฟอนต์ Baseline, Top, Center, และ Bottom กับขนาดฟอนต์ที่หลากหลาย](font_alignment.png)

การจัดแนวฟอนต์ใช้เมตริกซ์ของฟอนต์ ดังนั้นขอบที่มองเห็นของอักษรแต่ละตัวอาจไม่ตรงกันอย่างสมบูรณ์ ตัวอย่างรวมอักษรพิมพ์ใหญ่และตัวล่างเพื่อแสดงความแตกต่างระหว่างการจัดแนว baseline และ bottom ความพร้อมใช้งานและการเปลี่ยนฟอนต์, ตัวอักษรที่ใช้, และความแตกต่างของขนาดฟอนต์มีผลต่อผลลัพธ์ ขนาดกรอบ, ระยะขอบ, การเว้นบรรทัด, การตัดบรรทัด, และการทำ autofit ยังมีผลต่อการจัดวาง; ควรใช้ฟอนต์และการตั้งค่าการจัดวางเดียวกันเมื่อต้องการเปรียบเทียบโหมด

การตั้งค่านี้แตกต่างจาก [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), ซึ่งควบคุมการจัดแนวย่อหน้าแนวนอน, และ [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), ซึ่งกำหนดตำแหน่งของบล็อกข้อความแนวตั้งภายในรูปร่าง การจัดรูปแบบซูเปอร์สคริปต์และซับสคริปต์ผ่าน [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) จะย้ายส่วนของข้อความแต่ละส่วนสัมพันธ์กับ baseline แทนการตั้งค่าการจัดแนวฟอนต์สำหรับบรรทัดของย่อหน้า

## **ตั้งค่าความโปร่งแสงของข้อความ**

ความโปร่งแสงของข้อความถูกควบคุมผ่านส่วน alpha ของสีที่กำหนดให้กับ [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). ในตัวอย่างด้านล่าง `alpha = 50` คือค่าแชนแนล alpha ของ ARGB ในช่วง 0–255 ไม่ใช่เปอร์เซ็นต์ความโปร่งแสง.

ตัวอย่างโค้ดด้านล่างแสดงวิธีใช้ความโปร่งแสงกับ **ย่อหน้าทั้งหมด**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// ตั้งค่าการเติมสีดำกึ่งโปร่งแสงสำหรับข้อความ.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ย่อหน้าที่โปร่งแสง](transparent_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งแสงกับ **ส่วนข้อความที่มีฟอนต์หนา**:

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

![ส่วนข้อความที่โปร่งแสง](transparent_text_portions.png)

## **ตั้งค่าการเว้นระยะระหว่างอักขระของข้อความ**

ใช้ [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) เพื่อขยายหรือบีบระยะห่างระหว่างอักขระในกล่องข้อความ ตัวอย่างเพิ่มระยะห่าง 3 จุด; ค่าติดลบจะบีบอักขระให้สั้นลง.

โค้ด C# ต่อไปนี้แสดงวิธีขยายการเว้นระยะอักขระใน **ย่อหน้าทั้งหมด**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอักขระให้แคบลง.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // ขยายระยะห่างของอักขระ.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![การเว้นระยะอักขระในย่อหน้า](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีขยายการเว้นระยะอักขระใน **ส่วนข้อความที่มีฟอนต์หนา**:

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
        // หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอักขระให้แคบลง.
        portion.PortionFormat.Spacing = 3;  // ขยายระยะห่างของอักขระ.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![การเว้นระยะอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการทำ Kerning สำหรับฟอนต์เฉพาะ**

ในบางกรณี ข้อความที่แสดงโดย Aspose.Slides อาจดูแน่นกว่าข้อความเดียวกันที่แสดงใน PowerPoint สิ่งนี้อาจเกิดขึ้นเนื่องจาก PowerPoint อาจละเว้นข้อมูล kerning สำหรับฟอนต์บางตัว แม้ฟอนต์จะมีข้อมูล kerning ที่ถูกต้องและเปิดใช้งาน kerning ในการตั้งค่า PowerPoint.

เพื่อให้ผลลัพธ์ที่แสดงใกล้เคียงกับ PowerPoint มากขึ้นในกรณีดังกล่าว คุณสามารถปิดการทำ kerning สำหรับส่วนข้อความที่ใช้ฟอนต์ที่ได้รับผลกระทบ ตั้งค่า [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) เป็นค่าที่ใหญ่กว่าขนาดฟอนต์จริง ตัวอย่างนี้ต้องการไฟล์ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปร่างแรกบนสไลด์แรก จะตรวจสอบชื่อฟอนต์ที่มีผลรวม รวมถึงฟอนต์ที่สืบทอด และตั้งค่าขีดจำกัด 100 จุดสำหรับส่วนที่ใช้ Roboto ซึ่งจะปิดการทำ kerning สำหรับส่วนที่มีขนาดฟอนต์ต่ำกว่า 100 จุด:

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

สำหรับข้อความที่ตรงกับเกณฑ์แต่มีขนาดต่ำกว่าขีดจำกัด การตั้งค่านี้จะป้องกันการทำ kerning และอาจช่วยให้การแสดงผลของ Aspose.Slides สอดคล้องกับผลลัพธ์ภาพของ PowerPoint สำหรับฟอนต์ที่ได้รับผลกระทบจากพฤติกรรมเฉพาะของ PowerPoint นี้.

## **จัดการคุณสมบัติตัวอักษรของข้อความ**

คุณสมบัติตัวอักษรสามารถตั้งค่าที่ระดับย่อหน้าผ่าน [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) หรือบนส่วนย่อยแต่ละส่วนผ่าน [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

ตัวอย่างต่อไปนี้กำหนดฟอนต์เริ่มต้นของย่อหน้าแรกเป็น Times New Roman ขนาด 12 จุด พร้อมการทำให้เป็นตัวหนา, ตัวเอียง, และขีดเส้นใต้แบบจุด เลขา การจัดรูปแบบที่ชัดเจนบนส่วนย่อยแต่ละส่วนจะมีลำดับความสำคัญเหนือค่าตั้งต้นเหล่านี้:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// ตั้งค่าคุณสมบัติตัวอักษรสำหรับย่อหน้า.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![คุณสมบัติตัวอักษรของย่อหน้า](font_properties_for_paragraph.png)

ตัวอย่างต่อไปนี้ใช้ Times New Roman ขนาด 13 จุด, การจัดรูปแบบตัวเอียง, และขีดเส้นใต้แบบจุดกับส่วนที่มีรูปแบบมีผลเป็นตัวหนา:

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
        // ตั้งค่าคุณสมบัติตัวอักษรสำหรับส่วนของข้อความ.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![คุณสมบัติตัวอักษรของส่วนข้อความ](font_properties_for_text_portions.png)

## **ควบคุมการทำให้ความสูงข้อความเป็นมาตรฐาน**

ใช้ [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) เมื่อทำสำเนาการจัดพิมพ์จากเทมเพลตหรือสืบค้นความแตกต่างของความสูงอักขระ ใน PowerPoint การเปิดการทำให้เป็นมาตรฐานจะยืดหรือบีบอักขระแต่ละตัวในแนวตั้งเพื่อให้ความสูงที่มองเห็นสม่ำเสมอภายในส่วนข้อความ แต่ไม่รับประกันความสูงของข้อความที่เท่ากันระหว่างฟอนต์ที่แตกต่างกัน.

กำหนดคุณสมบัตินี้เป็น [NullableBool.True or False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) เพื่อเปิดหรือปิดการทำให้เป็นมาตรฐานอย่างชัดเจน `NullableBool.NotDefined` ทำให้การตั้งค่าท้องถิ่นไม่มีค่า ซึ่งส่วนข้อความจะสืบทอดค่าจากย่อหน้า [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) เช่น ไม่ได้หมายถึง `False` ใช้ [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) และอ่าน [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) เพื่อรับค่า Boolean ที่ได้สรุป.

ตัวอย่างอิสระต่อไปนี้ต้องการให้ **Arial** ติดตั้งไว้ มันสร้างบล็อกข้อความสองบล็อกที่มีอักษรพิมพ์ใหญ่, พิมพ์เล็ก, ตัวตัวล่าง, และอักขระที่มีสำเนียงขนาด 54 จุด ทั้งสองย่อหน้ากำหนดเปิดการทำให้อยู่ในมาตรฐานโดยค่าเริ่มต้น ส่วนบนปิดการทำอย่างชัดเจน; ส่วนล่างสืบทอดค่า การตั้งค่าขนาดเฟรม, ระยะขอบ, และการเว้นระยะย่อหน้าตรงกัน, ปิดการตัดบรรทัดและการทำ autofit เพื่อให้การเปรียบเทียบสอดคล้อง ตัวอย่างพิมพ์ `False: False` และ `NotDefined: True` แล้วบันทึกเป็น "text_height_normalization.pptx".

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

การเปรียบเทียบด้านล่างถูกส่งออกจากงานนำเสนอที่บันทึกไว้ แถวบนมีการทำให้เป็นมาตรฐานปิด (`False`); แถวล่างสืบทอดการตั้งค่าเปิด (`NotDefined` → `True`). ควรติดตั้ง Arial เพื่อสร้างลักษณะนี้.

![ข้อความ Arial 54 จุดที่มีการทำให้เป็นมาตรฐานปิดอยู่ด้านบนและสืบทอดเปิดอยู่ด้านล่าง](text_height_normalization.png)

การทำให้เป็นมาตรฐานจะเปลี่ยนความสูงของอักขระโดยไม่เปลี่ยนค่า [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) ที่ระบุขนาดฟอนต์เป็นจุด ย่อหน้า [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) ควบคุมการเว้นบรรทัด ในขณะที่กรอบข้อความ [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) ควบคุมว่าข้อความหรือคอนเทนเนอร์ปรับขนาดอย่างไร การตั้งค่าเหล่านี้มีวัตถุประสงค์ที่ต่างกันและอาจมีผลต่อการจัดวางโดยรวมแยกกัน สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการจัดรูปแบบย่อหน้าและการสืบทอด ดูที่ [Manage Paragraph](/slides/th/net/manage-paragraph/).

## **เพิ่มและลบการขีดฆ่าข้อความ**

ใช้ [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) บนส่วนของข้อความเพื่อแสดงการแก้ไข, คำที่ยกเลิก, หรือราคาก่อนหน้าโดยไม่ลบข้อความต้นฉบับ ตั้งค่าเป็น [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) เพื่อให้มีเส้นขีดหนึ่งหรือสองเส้นผ่านข้อความ.

เพื่อเอาการขีดฆ่าออก ให้กำหนด `TextStrikethroughType.None` ซึ่งจะปิดเอฟเฟ็กต์นี้อย่างชัดเจน แม้การจัดรูปแบบโดยรอบจะระบุขีดฆ่า ในทางตรงกันข้าม `TextStrikethroughType.NotDefined` จะทำให้การตั้งค่าท้องถิ่นไม่มีค่า ทำให้ส่วนข้อความสืบทอดการจัดรูปแบบ เช่นจากย่อหน้า ไม่ได้รับประกันว่าการขีดฆ่าจะถูกลบออก ใช้ [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) เพื่ออ่านการจัดรูปแบบที่ได้รวมถึงค่าที่สืบทอด.

ตัวอย่างอิสระต่อไปนี้สร้างการเปรียบเทียบราคาสามรายการ แต่ละย่อหน้ามีส่วนแยกสำหรับป้าย, ราคาก่อนหน้า, และราคาปัจจุบัน ดังนั้นจึงมีผลต่อราคาก่อนหน้าเท่านั้น แถวแรกใช้การขีดฆ่าแล้วลบออก; แถวอื่นๆ รักษาการขีดฆ่าแบบเส้นเดียวและเส้นคู่ การเปลี่ยนคุณสมบัตินี้จะคงข้อความและการจัดรูปแบบอื่น ๆ รวมถึงราคาก่อนหน้าที่เป็นตัวหนา.

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

// ใช้การขีดฆ่า, จากนั้นลบออกอย่างชัดเจนจากราคาเดิมตัวแรก.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

ผลลัพธ์จากบนลงล่าง: ไม่มีการขีดฆ่า, มีการขีดฆ่าแบบเส้นเดียว, และมีการขีดฆ่าแบบเส้นคู่.

![ราคาก่อนหน้าไม่มีการขีดฆ่า, มีการขีดฆ่าแบบเส้นเดียว, และมีการขีดฆ่าแบบเส้นคู่](strikethrough.png)

## **ตั้งค่าการหมุนข้อความ**

ใช้ [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) เพื่อกำหนดการวางแนวข้อความที่กำหนดไว้ล่วงหน้าภายในรูปร่าง.

ตัวอย่างโค้ดต่อไปนี้กำหนดการวางแนวข้อความในรูปร่างเป็น [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), ซึ่งจะหมุนข้อความ **90 องศาตรงทวนเข็มนาฬิกา**:

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

ใช้ [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) เพื่อกำหนดมุมการหมุนแบบกำหนดเองสำหรับ [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).

ตัวอย่างโค้ดด้านล่างหมุนกรอบข้อความ 3 องศาตามเข็มนาฬิกาภายในรูปร่าง:

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

Aspose.Slides มี [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/), และ [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) เพื่อควบคุมการเว้นบรรทัดของย่อหน้า วิธีการใช้คุณสมบัติเหล่านี้คือดังนี้:

* ใช้ค่าบวกเพื่อระบุการเว้นบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าลบเพื่อระบุการเว้นบรรทัดเป็นหน่วยจุด

ตัวอย่างต่อไปนี้ตั้งค่าการเว้นบรรทัดภายในย่อหน้าแรกเป็น 200% ของความสูงบรรทัด (เว้นบรรทัดสองเท่า):

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

กฎการตัดบรรทัดของย่อหน้ามีประโยชน์สำหรับบล็อกข้อความแคบและงานนำเสนอที่ผสมข้อความละตินและเอเชียตะวันออก คุณสมบัติดังต่อไปนี้เป็นของ [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), ดังนั้นจะใช้กับย่อหน้าเต็ม:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) ควบคุมกฎการตัดบรรทัดของละติน ในข้อความผสม การเปลี่ยนค่านี้อาจทำให้การตัดบรรทัดของข้อความเอเชียตะวันออกและเครื่องหมายวรรคตอนที่อยู่ใกล้เคียงเปลี่ยนไป
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) ควบคุมกฎการตัดบรรทัดของเอเชียตะวันออก รวมถึงการจำกัดอักขระที่ตำแหน่งต้นและปลายบรรทัด

กฎเหล่านี้ไม่ได้แทนที่ [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), ที่เปิดการตัดบรรทัดอัตโนมัติภายในกรอบข้อความ พวกมันมีผลต่อการจัดวางเมื่อเกิดการตัดบรรทัด; พวกมันไม่แทรกอักขระการตัดบรรทัด การตัดบรรทัดที่ระบุโดยชัดเจนจะบังคับให้เกิดบรรทัดใหม่ภายในย่อหน้าโดยอิสระจากความกว้างที่มีอยู่

ตัวอย่างอิสระต่อไปนี้สร้างบล็อกข้อความแคบที่มีข้อความจีนและละติน ตั้งค่าคุณสมบัติการตัดบรรทัดทั้งสองอย่างชัดเจนและบันทึกเป็น "line_breaking.pptx" เพื่อทดลองใช้กฎใดกฎหนึ่ง ให้เปลี่ยนค่าคุณสมบัตินั้นโดยคงค่าการตั้งค่าอื่นไม่เปลี่ยน ตัวอย่างใช้ Arial 24 จุดและ SimSun พร้อมความกว้างเฟรม 160 จุดและระยะขอบกรอบข้อความแนวนอนเป็นศูนย์ [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) ถูกตั้งเป็น [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) เพื่อให้ขนาดข้อความและมิติของเฟรมคงที่.

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

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) อนุญาตให้เครื่องหมายวรรคตอนที่เหมาะสมขยับออกนอกขอบขวาของบรรทัดข้อความแทนการอยู่ในบรรทัดต่อไป ใช้กับย่อหน้าเต็มและแตกต่างจากการเยื้องแบบ hanging.

ตัวอย่างอิสระต่อไปนี้เปิดการใช้งานการแขวนเครื่องหมายวรรคตอนในกรอบข้อความกว้าง 100 จุดและบันทึกเป็น "hanging_punctuation.pptx" ด้วย Arial 24 จุดและระยะขอบกรอบข้อความแนวนอนศูนย์ จุดสุดท้ายจะอยู่หลัง "sentence" และขยายออกนอกขอบขวาของข้อความ ตั้งค่าคุณสมบัตินี้เป็น [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) เพื่อเปรียบเทียบ: ด้วยการตั้งค่านี้ จุดเต็มจะอยู่ในบรรทัดแยก ส่วนการตัดบรรทัดเปิดใช้งานและการทำ autofit ปิดเพื่อคงความกว้างที่มี

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

ไม่ใช่ทุกเครื่องหมายวรรคตอนที่สามารถแขวนได้ เงื่อนไขของฟอนต์และการจัดวางที่อธิบายไว้ข้างต้น ([font and layout conditions described above](#control-line-breaking)) ยังใช้กับการเปรียบเทียบนี้: การเปลี่ยนฟอนต์, ความกว้างที่มี, ระยะขอบ, หรือการตั้งค่า autofit สามารถทำให้ความแตกต่างที่มองเห็นหายไป.

## **ตั้งค่าชนิด Autofit สำหรับกรอบข้อความ**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) กำหนดว่าข้อความทำงานอย่างไรเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะหด, เกิน, หรือปรับขนาดรูปร่างโดยอัตโนมัติ ตัวอย่างต่อไปนี้ตั้งค่ารูปร่างให้ปรับขนาดเพื่อให้พอดีกับข้อความและบันทึกผลลัพธ์เป็น "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

เพื่อจำนวนบรรทัดหลังการตัดบรรทัดอัตโนมัติและดูว่าขนาดข้อความหรือความกว้างของรูปร่างเปลี่ยนผลลัพธ์อย่างไร ดูที่ [Count Rendered Lines](/slides/th/net/manage-paragraph/). จำนวนบรรทัดเพียงอย่างเดียวไม่ได้บ่งบอกว่าข้อความเกินคอนเทนเนอร์หรือไม่.

## **ตั้งค่าตำแหน่งยึดของกรอบข้อความ**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) กำหนดว่าข้อความวางในแนวตั้งภายในรูปร่างอย่างไร เช่น ด้านบน, กลาง, หรือด้านล่าง ตัวอย่างต่อไปนี้ยึดข้อความที่ด้านล่างของรูปร่างแรกและบันทึกผลเป็น "text_anchor.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าการจัดตำแหน่งแท็บของข้อความ**

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

## **ตั้งค่าภาษาการตรวจสอบ**

Aspose.Slides มี [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), ซึ่งให้คุณตั้งค่าภาษาการตรวจสอบสำหรับส่วนของข้อความ ภาษาการตรวจสอบกำหนดภาษาที่ใช้สำหรับการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint.

ตัวอย่างต่อไปนี้ต้องการไฟล์ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปร่างแรกบนสไลด์แรกและอย่างน้อยหนึ่งย่อหน้า จะเปลี่ยนเนื้อหาของย่อหน้าแรกเป็น "1。", ตั้งค่า SimSun เป็นฟอนต์และกำหนดภาษาการตรวจสอบเป็นภาษาจีนต้นฉบับง่าย (`zh-CN`). จากนั้นบันทึกผลเป็น "proofing_language.pptx":

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

## **ตั้งค่าภาษาเริ่มต้น**

ใช้ [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) เพื่อกำหนดภาษาตั้งต้นสำหรับข้อความที่สร้างขณะโหลดหรือสร้างงานนำเสนอ ตัวอย่างต่อไปนี้สร้างงานนำเสนอโดยตั้งค่าภาษาเริ่มต้นของข้อความเป็นภาษาอังกฤษสหรัฐ, เพิ่มกล่องข้อความ, และพิมพ์ `en-US` สำหรับส่วนข้อความแรก.

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

## **ตั้งค่าสไตล์ข้อความเริ่มต้น**

เพื่อใช้การจัดรูปแบบข้อความเริ่มต้นในระดับงานนำเสนอ ใช้ [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

ตัวอย่างต่อไปนี้กำหนดฟอนต์ขนาด 14 จุดแบบหนาเป็นค่าเริ่มต้นสำหรับย่อหน้าในระดับบนของงานนำเสนอใหม่และบันทึกเป็น "default_text_style.pptx" ข้อความสามารถสืบทอดค่าเริ่มต้นเหล่านี้ได้ยกเว้นการจัดรูปแบบที่เฉพาะเจาะจงกว่าจะเขียนทับ

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// ดึงรูปแบบย่อหน้าในระดับบนสุด.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **สกัดข้อความด้วยเอฟเฟกต์ All-Caps**

ใน PowerPoint การใช้เอฟเฟกต์ฟอนต์ **All Caps** ทำให้ข้อความแสดงเป็นตัวพิมพ์ใหญ่บนสไลด์แม้ว่าจะพิมพ์เป็นตัวพิมพ์เล็กไว้เดิม เมื่อคุณดึงส่วนข้อความเช่นนั้นด้วย Aspose.Slides ไลบรารีจะคืนค่าข้อความตามที่พิมพ์ไว้ เพื่อให้ตรงกับข้อความที่แสดง ให้ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) และแปลงสตริงที่คืนค่าเป็นตัวพิมพ์ใหญ่เมื่อค่าคือ `All`.

ตัวอย่างนี้ต้องการไฟล์ "sample2.pptx" ที่มีกล่องข้อความเป็นรูปร่างแรกบนสไลด์แรก ส่วนแรกของย่อหน้าแรกมีข้อความ "Hello, Aspose!" พร้อมเอฟเฟกต์ All Caps ดังที่แสดงด้านล่าง.

![เอฟเฟกต์ All Caps](all_caps_effect.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีสกัดข้อความที่มีเอฟเฟกต์ **All Caps** อยู่:

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

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **คำถามที่พบบ่อย**

**ฉันจะแก้ไขข้อความในตารางบนสไลด์ได้อย่างไร?**

ในการแก้ไขข้อความในตารางบนสไลด์ ให้ใช้ [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). ทำการวนซ้ำผ่านเซลล์และอัปเดตแต่ละเซลล์ผ่าน [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) และจัดรูปแบบย่อหน้าผ่าน [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**ฉันจะใช้สีไล่ระดับบนข้อความในสไลด์ PowerPoint อย่างไร?**

เพื่อใช้สีไล่ระดับบนข้อความ ให้ใช้ [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). ตั้งค่า [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) เป็น [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) และกำหนดจุดไล่ระดับ, ทิศทาง, และความโปร่งแสง.

ฟีเจอร์ที่เกี่ยวข้อง: [จัดรูปแบบข้อความภายในสไลด์](/slides/th/features/text-formatting/).