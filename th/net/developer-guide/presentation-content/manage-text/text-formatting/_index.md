---
title: จัดรูปแบบข้อความการนำเสนอใน .NET
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/net/text-formatting/
keywords:
- ไฮไลท์ข้อความ
- นิพจน์ปกติ
- จัดแนวย่อหน้า
- สไตล์ข้อความ
- พื้นหลังข้อความ
- ความโปร่งใสของข้อความ
- ระยะห่างอักขระ
- คุณสมบัติฟอนต์
- ตระกูลฟอนต์
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- ระยะบรรทัด
- คุณสมบัติ autofit
- จุดยึดกรอบข้อความ
- การตั้งค่าแท็บข้อความ
- ภาษาหลัก
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดรูปแบบและสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ .NET ปรับแต่งฟอนต์, สี, การจัดแนว และอื่น ๆ อีกมากมาย."
---
## **ภาพรวม**

บทความนี้แสดงวิธีจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ .NET รวมถึงการเน้นสี, สีพื้นหลัง, ความโปร่งใส, การเว้นระยะระหว่างอักษร, คุณสมบัติของฟอนต์, การหมุน, การเว้นระยะย่อหน้า, พฤติกรรม autofit, การยึดข้อความ, การตั้งค่าตำแหน่งแท็บ, และการตั้งค่าภาษาต่าง ๆ

ในตัวอย่างด้านล่าง เราจะใช้ไฟล์ชื่อ "sample.pptx" ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกพร้อมข้อความต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

## **ไฮไลท์ข้อความ**

ใช้เมธอด [ITextFrame.HighlightText](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/highlighttext/) เมื่อคุณต้องการไฮไลท์ข้อความที่ตรงกับตัวอย่างเฉพาะภายในกรอบข้อความ เมธอดนี้จะกำหนดสีไฮไลท์ให้กับส่วนข้อความที่ตรงกันและสามารถใช้ร่วมกับ [TextSearchOptions](https://reference.aspose.com/slides/th/net/aspose.slides/textsearchoptions/) เพื่อควบคุมวิธีการค้นหาได้ เช่น เพื่อให้ตรงกับคำเต็มเท่านั้น

ตัวอย่างโค้ดด้านล่างจะแสดงการไฮไลท์ทุกการปรากฏของอักขระ **"try"** แล้วจึงไฮไลท์เฉพาะคำเต็ม **"to"** เท่านั้น

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // ดึงรูปร่างแรกจากสไลด์แรก.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // ไฮไลท์คำ "try" ในรูปร่าง.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // ไฮไลท์คำ "to" ในรูปร่าง.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```

![ข้อความที่ไฮไลท์](highlighted_text.png)

## **ไฮไลท์ข้อความด้วย Regular Expressions**

เมธอด [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/highlightregex/) จะไฮไลท์ข้อความที่ตรงกับผลลัพธ์ของ regular expression ใน .NET API นี้เปิดให้ใช้บน [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/)

ตัวอย่างโค้ดด้านล่างไฮไลท์ทุกคำที่มี **เจ็ดตัวอักษรหรือมากกว่า**:

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // ไฮไลท์ทุกคำที่มีอักขระเจ็ดตัวหรือมากกว่า.
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

![ข้อความที่ไฮไลท์ด้วย regular expression](highlighted_text_using_regex.png)

## **กำหนดสีพื้นหลังข้อความ**

ใช้ [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/defaultportionformat/) เพื่อกำหนดสีไฮไลท์เริ่มต้นสำหรับย่อหน้า หรือใช้ [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/th/net/aspose.slides/iportionformat/highlightcolor/) สำหรับส่วนข้อความแต่ละส่วน

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีกำหนดสีพื้นหลังสำหรับ **ย่อหน้าทั้งหมด**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // กำหนดสีไฮไลท์สำหรับย่อหน้าทั้งหมด.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

![ย่อหน้าสีเทา](gray_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีกำหนดสีพื้นหลังสำหรับ **ส่วนข้อความที่ใช้ฟอนต์หนา**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // กำหนดสีไฮไลท์สำหรับส่วนข้อความ.
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```

![ส่วนข้อความสีเทา](gray_text_portions.png)

## **จัดแนวย่อหน้าข้อความ**

ใช้ [IParagraphFormat.Alignment](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/alignment/) เพื่อตั้งค่าการจัดแนวย่อหน้าในกรอบข้อความ ค่าที่ตั้งได้อาจเป็นการจัดกึ่งกลาง, จัดซ้าย, จัดขวา, จัดแนวตรงบรรทัด, เป็นต้น

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดย่อหน้าให้ **กึ่งกลาง**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // ตั้งค่าการจัดแนวของย่อหน้าให้กึ่งกลาง.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

![ย่อหน้าที่จัดแนว](aligned_paragraph.png)

## **กำหนดความโปร่งใสของข้อความ**

ความโปร่งใสของข้อความถูกควบคุมผ่านคอมโพเนนต์ alpha ของสีที่กำหนดให้กับ [IPortionFormat.FillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iportionformat/fillformat/). ในตัวอย่างด้านล่าง `alpha = 50` เป็นค่าช่อง alpha ของ ARGB บนสเกล 0–255 ไม่ใช่เปอร์เซ็นต์ความโปร่งใส

ตัวอย่างโค้ดด้านล่างแสดงวิธีใช้ความโปร่งใสกับ **ย่อหน้าทั้งหมด**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // กำหนดสีเติมของข้อความเป็นสีโปร่งใส.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

![ย่อหน้าที่โปร่งใส](transparent_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ส่วนข้อความที่ใช้ฟอนต์หนา**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // กำหนดความโปร่งใสของส่วนข้อความ.
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```

![ส่วนข้อความที่โปร่งใส](transparent_text_portions.png)

## **กำหนดระยะห่างระหว่างอักขระของข้อความ**

ใช้ [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/spacing/) เพื่อขยายหรือบีบอัดระยะห่างระหว่างอักขระในกล่องข้อความ

โค้ด C# ต่อไปนี้แสดงวิธีขยายระยะห่างอักขระใน **ย่อหน้าทั้งหมด**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างอักขระ.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // ขยายระยะห่างอักขระ.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

![ระยะห่างอักขระในย่อหน้า](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีขยายระยะห่างอักขระใน **ส่วนข้อความที่ใช้ฟอนต์หนา**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างอักขระ.
            portion.PortionFormat.Spacing = 3;  // ขยายระยะห่างอักขระ.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

![ระยะห่างอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการทำ Kerning สำหรับฟอนต์เฉพาะ**

ในบางกรณี ข้อความที่แสดงโดย Aspose.Slides อาจดูแนบหนากว่าเดียวกับใน PowerPoint เนื่องจาก PowerPoint อาจละเว้นข้อมูล kerning สำหรับฟอนต์บางตัว แม้ฟอนต์จะมีข้อมูล kerning ที่ถูกต้องและเปิดใช้งานในการตั้งค่า PowerPoint ก็ตาม

เพื่อทำให้ผลลัพธ์ที่แสดงใกล้เคียงกับ PowerPoint มากขึ้นในกรณีเหล่านี้ คุณสามารถปิดการทำ kerning สำหรับส่วนข้อความที่ใช้ฟอนต์ที่ได้รับผลกระทบได้ โดยตั้งค่า [IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/kerningminimalsize/) ให้มีค่ามากกว่าขนาดฟอนต์จริงอย่างมีนัยสำคัญ:

```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

การตั้งค่านี้ป้องกันไม่ให้ทำ kerning กับส่วนข้อความที่ตรงกันและสามารถช่วยให้การแสดงผลของ Aspose.Slides สอดคล้องกับการแสดงผลของ PowerPoint สำหรับฟอนต์ที่ได้รับผลกระทบจากพฤติกรรมเฉพาะของ PowerPoint นี้

## **จัดการคุณสมบัติฟอนต์ของข้อความ**

คุณสมบัติฟอนต์สามารถตั้งค่าที่ระดับย่อหน้าได้ผ่าน [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/defaultportionformat/) หรือบนส่วนข้อความแต่ละส่วนผ่าน [IPortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iportionformat/)

โค้ดต่อไปนี้ตั้งค่าฟอนต์และสไตล์ข้อความสำหรับย่อหน้าทั้งหมด: จะกำหนดขนาดฟอนต์, ตัวหนา, ตัวเอียง, ขีดเส้นใต้แบบจุด, และฟอนต์ Times New Roman ให้กับทุกส่วนในย่อหน้า

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // ตั้งค่าคุณสมบัติฟอนต์สำหรับย่อหน้า.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

![คุณสมบัติฟอนต์ของย่อหน้า](font_properties_for_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้ใช้คุณสมบัติคล้ายกันกับ **ส่วนข้อความที่ใช้ฟอนต์หนา**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

![คุณสมบัติฟอนต์ของส่วนข้อความ](font_properties_for_text_portions.png)

## **กำหนดการหมุนของข้อความ**

ใช้ [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/textverticaltype/) เพื่อตั้งค่าการวางแนวข้อความที่กำหนดไว้ล่วงหน้าในรูปทรง

ตัวอย่างโค้ดต่อไปนี้ตั้งค่าการวางแนวข้อความในรูปทรงเป็น `Vertical270` ซึ่งจะหมุนข้อความ **90 องศาตรงทวนเข็มนาฬิกา**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

![การหมุนข้อความ](text_rotation.png)

## **กำหนดการหมุนแบบกำหนดเองสำหรับกรอบข้อความ**

ใช้ [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/rotationangle/) เพื่อกำหนดมุมการหมุนแบบกำหนดเองสำหรับ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/)

ตัวอย่างโค้ดด้านล่างหมุนกรอบข้อความโดย 3 องศาตามเข็มนาฬิกาในรูปทรง:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

![การหมุนข้อความแบบกำหนดเอง](custom_text_rotation.png)

## **กำหนดระยะบรรทัดของย่อหน้า**

Aspose.Slides มี [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/spacebefore/), และ [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/spacewithin/) เพื่อควบคุมระยะห่างของย่อหน้า คุณสมบัติเหล่านี้ใช้ดังนี้:

* ใช้ค่าบวกเพื่อระบุตัวห่างบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าลบเพื่อระบุตัวห่างบรรทัดเป็นหน่วยจุด

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีกำหนดระยะบรรทัดภายในย่อหน้า:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

![ระยะบรรทัดภายในย่อหน้า](line_spacing.png)

## **กำหนดประเภท Autofit สำหรับกรอบข้อความ**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/autofittype/) กำหนดวิธีการทำงานของข้อความเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะหด, ล้นออก, หรือปรับขนาดรูปทรงโดยอัตโนมัติ

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **กำหนดจุดยึดของกรอบข้อความ**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/anchoringtype/) กำหนดตำแหน่งแนวตั้งของข้อความภายในรูปทรง เช่น ด้านบน, กลาง, หรือด้านล่าง

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **กำหนดการจัดตำแหน่งแท็บของข้อความ**

ใช้ [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/defaulttabsize/) และ [IParagraphFormat.Tabs](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraphformat/tabs/) เพื่อกำหนดตำแหน่งแท็บในย่อหน้า

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```

![แท็บของย่อหน้า](paragraph_tabs.png)

## **กำหนดภาษาการตรวจสอบ**

Aspose.Slides มี [IPortionFormat.LanguageId](https://reference.aspose.com/slides/th/net/aspose.slides/iportionformat/languageid/) ซึ่งอนุญาตให้ตั้งค่าภาษาการตรวจสอบสำหรับส่วนข้อความ ภาษาการตรวจสอบจะกำหนดภาษาที่ใช้สำหรับการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าภาษาการตรวจสอบสำหรับส่วนข้อความ:

```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // กำหนด Id ของภาษาการตรวจสอบ.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **กำหนดภาษาพื้นฐาน**

ใช้ [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/defaulttextlanguage/) เพื่อกำหนดภาษาพื้นฐานสำหรับข้อความที่สร้างขึ้นขณะโหลดหรือสร้างงานนำเสนอ

```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // เพิ่มรูปทรงสี่เหลี่ยมผืนผ้าใหม่พร้อมข้อความ.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // ตรวจสอบภาษาของส่วนข้อความแรก.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **กำหนดสไตล์ข้อความเริ่มต้น**

เพื่อใช้การจัดรูปแบบข้อความเริ่มต้นระดับงานนำเสนอ ให้ใช้ [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/defaulttextstyle/)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าฟอนต์หนาเริ่มต้นขนาด 14 pt สำหรับข้อความทั้งหมดในสไลด์ทั้งหมดของงานนำเสนอใหม่

```cs
using (var presentation = new Presentation())
{
    // รับรูปแบบย่อหน้าระดับบนสุด.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **สกัดข้อความด้วยเอฟเฟกต์ All-Caps**

ใน PowerPoint การใช้เอฟเฟกต์ฟอนต์ **All Caps** ทำให้ข้อความแสดงเป็นตัวพิมพ์ใหญ่ทั้งหมดบนสไลด์ แม้ว่าจะพิมพ์เป็นตัวพิมพ์เล็กเดิมก็ตาม เมื่อคุณดึงส่วนข้อความดังกล่าวด้วย Aspose.Slides ไลบรารีจะคืนค่าข้อความตามที่ป้อนไว้โดยตรง หากต้องการให้ตรงกับข้อความที่แสดงให้ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/th/net/aspose.slides/textcaptype/) และแปลงสตริงที่คืนค่าเป็นตัวพิมพ์ใหญ่เมื่อค่ามีค่า `All`

สมมติว่ามีกล่องข้อความต่อไปนี้บนสไลด์แรกของไฟล์ sample2.pptx

![เอฟเฟกต์ All Caps](all_caps_effect.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีสกัดข้อความโดยมีเอฟเฟกต์ **All Caps** ถูกใช้งาน:

```cs
using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**วิธีแก้ไขข้อความในตารางบนสไลด์?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ให้ใช้ [ITable](https://reference.aspose.com/slides/th/net/aspose.slides/itable/). ทำการวนลูปผ่านเซลล์และอัปเดตแต่ละเซลล์ผ่าน [ICell.TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/icell/textframe/) และกำหนดรูปแบบย่อหน้าผ่าน [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/paragraphformat/)

**วิธีใช้สีไล่ระดับสีกับข้อความในสไลด์ PowerPoint?**

เพื่อใช้สีไล่ระดับสีกับข้อความ ให้ใช้ [IPortionFormat.FillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iportionformat/fillformat/). ตั้งค่า [IFillFormat.FillType](https://reference.aspose.com/slides/th/net/aspose.slides/ifillformat/filltype/) เป็น [FillType.Gradient](https://reference.aspose.com/slides/th/net/aspose.slides/filltype/) แล้วกำหนดจุดไล่สี, ทิศทาง, และความโปร่งใสตามต้องการ