---
title: การค้นหาและแทนที่ข้อความในงานนำเสนอ PowerPoint ด้วย .NET
linktitle: ค้นหาและแทนที่ข้อความ
type: docs
weight: 55
url: /th/net/search-and-replace-text/
keywords:
- ค้นหาข้อความ
- ไฮไลต์ข้อความ
- แทนที่ข้อความ
- นิพจน์ทั่วไป
- การเรียกกลับผลลัพธ์
- เฟรมข้อความ
- รายงานการตรวจสอบ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นหา, ไฮไลต์และแทนที่ข้อความในงานนำเสนอ PowerPoint พร้อมเก็บบันทึกการจับคู่ทุกรายการด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Aspose.Slides for .NET สามารถค้นหา, ไฮไลต์, และแทนที่ข้อความในเฟรมข้อความเดี่ยวหรือทั่วทั้งงานนำเสนอได้ แต่ละการดำเนินการยังสามารถแจ้งให้แอปพลิเคชันทราบทุกการจับคู่ผ่านผลลัพธ์ callback ทำให้สามารถอัปเดตงานนำเสนอและในขณะเดียวกันสร้างบันทึกตรวจสอบที่ประกอบด้วยข้อความที่จับคู่, บริบท, ตำแหน่ง, เฟรมข้อความและหมายเลขสไลด์

ความสามารถเหล่านี้มีประโยชน์สำหรับการตรวจทาน, การลบข้อมูล, การตรวจสอบคำศัพท์, การทำความสะอาดเทมเพลต, และกระบวนการรายงานอัตโนมัติ

ในตัวอย่างแรกด้านล่าง เราใช้ไฟล์ชื่อ “sample.pptx” ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกพร้อมข้อความต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

## **เลือกขอบเขตการค้นหา**

ใช้เมธอดบน [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) เพื่อจำกัดการดำเนินการไว้ที่เฟรมข้อความหนึ่ง ใช้เมธอดบน [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เพื่อประมวลผลข้อความที่ใช้ได้ทั้งหมดในงานนำเสนอ

| การดำเนินการ | หนึ่งเฟรมข้อความ | งานนำเสนอทั้งหมด |
|---|---|---|
| ไฮไลต์ข้อความธรรมดา | [ITextFrame.HighlightText](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/highlighttext/) |
| ไฮไลต์การจับคู่ regular‑expression | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/highlightregex/) |
| แทนที่ข้อความธรรมดา | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/replacetext/) |
| แทนที่การจับคู่ regular‑expression | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/replaceregex/) |

## **กำหนดการจับคู่ข้อความ**

สำหรับการดำเนินการข้อความธรรมดา ให้ใช้ [TextSearchOptions](https://reference.aspose.com/slides/th/net/aspose.slides/textsearchoptions/) เพื่อควบคุมการจับคู่:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/th/net/aspose.slides/textsearchoptions/wholewordsonly/) จำกัดการจับคู่ให้เป็นคำเต็มเท่านั้น
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/th/net/aspose.slides/textsearchoptions/casesensitive/) ควบคุมว่าตัวอักษรต้องตรงตามขนาดหรือไม่
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/th/net/aspose.slides/textsearchoptions/includenotes/) รวมโน้ตสไลด์ในการค้นหา, การแทนที่และการไฮไลต์ระดับงานนำเสนอ

การดำเนินการ regular‑expression ใช้ .NET `Regex` ดังนั้นกฎการจับคู่เช่นความไวต่อขนาดตัวอักษรและขอบเขตคำจะถูกกำหนดโดยนิพจน์และตัวเลือกของมัน

## **รวบรวมข้อมูลการจับคู่ด้วย Callback**

ทำการ implement [IFindResultCallback](https://reference.aspose.com/slides/th/net/aspose.slides/ifindresultcallback/) เพื่อรับการแจ้งเตือนสำหรับทุกการจับคู่ เมธอด [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/th/net/aspose.slides/ifindresultcallback/foundresult/) จะให้ข้อมูลเฟรมข้อความที่เกี่ยวข้อง, ข้อความต้นฉบับ, ข้อความที่จับคู่และตำแหน่งการจับคู่

Callback จะไม่ได้รับหมายเลขสไลด์โดยตรง การทำงานด้านล่างสกัดหมายเลขสไลด์จากสไลด์แม่และจัดการข้อความที่พบในโน้ตสไลด์เช่นกัน หมายเลขสไลด์แบบ nullable ทำให้โมเดลผลลัพธ์เดียวกันสามารถแทนข้อความที่เกี่ยวข้องกับประเภทสไลด์อื่นได้

```cs
using System.Collections.Generic;
using Aspose.Slides;

public sealed class TextMatch
{
    public TextMatch(ITextFrame textFrame, string sourceText, string foundText, int textPosition, int? slideNumber)
    {
        TextFrame = textFrame;
        SourceText = sourceText;
        FoundText = foundText;
        TextPosition = textPosition;
        SlideNumber = slideNumber;
    }

    public ITextFrame TextFrame { get; }
    public string SourceText { get; }
    public string FoundText { get; }
    public int TextPosition { get; }
    public int? SlideNumber { get; }
}

public sealed class TextSearchCallback : IFindResultCallback
{
    public List<TextMatch> Results { get; } = new();

    public void FoundResult(ITextFrame textFrame, string sourceText, string foundText, int textPosition)
    {
        var slideNumber = GetSlideNumber(textFrame);
        var result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);

        Results.Add(result);
    }

    private static int? GetSlideNumber(ITextFrame textFrame)
    {
        if (textFrame is not TextFrame concreteTextFrame)
        {
            return null;
        }

        var parentSlide = concreteTextFrame.Slide;

        if (parentSlide is ISlide slide)
        {
            return slide.SlideNumber;
        }

        if (parentSlide is INotesSlide notesSlide)
        {
            return notesSlide.ParentSlide.SlideNumber;
        }

        return null;
    }
}
```

สำหรับการดำเนินการแทนที่ `FoundText` จะมีข้อความต้นฉบับที่จับคู่อยู่ ดังนั้น callback สามารถบันทึกได้อย่างแม่นยำว่าคำใดบ้างที่ถูกแทนที่

## **ไฮไลต์ข้อความ**

ใช้เมธอด [ITextFrame.HighlightText](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/highlighttext/) เพื่อไฮไลต์การจับคู่ข้อความธรรมดาในเฟรมข้อความ ส่ง [TextSearchOptions](https://reference.aspose.com/slides/th/net/aspose.slides/textsearchoptions/) เพื่อควบคุมการค้นหาและส่ง callback เพื่อรวบรวมรายละเอียดการจับคู่

โค้ดตัวอย่างด้านล่างไฮไลต์ทุกตำแหน่งของอักขระ **"try"** แล้วตามด้วยการไฮไลต์เฉพาะคำเต็ม **"to"** ทั้งสองการค้นหาจะรายงานผลการจับคู่ไปยัง callback เดียวกัน

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Get the first shape from the first slide.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Highlight every occurrence of "try" in the text frame.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Highlight only the complete word "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ข้อความที่ไฮไลต์](highlighted_text.png)

## **ไฮไลต์ข้อความโดยใช้ Regular Expressions**

เมธอด [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/highlightregex/) จะไฮไลต์ข้อความที่ตรงกับ regular expression ในเฟรมข้อความ

โค้ดต่อไปนี้ไฮไลต์ทุกคำที่มีความยาวเจ็ดอักขระหรือมากกว่าและรวบรวมการจับคู่แต่ละรายการ:

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var regex = new Regex(@"\b[^\s]{7,}\b");

shape.TextFrame.HighlightRegex(regex, Color.Yellow, callback);

presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ข้อความที่ไฮไลต์โดยใช้ regular expression](highlighted_text_using_regex.png)

## **ไฮไลต์ข้อความทั่วทั้งงานนำเสนอ**

ใช้ [Presentation.HighlightText](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/highlighttext/) และ [Presentation.HighlightRegex](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/highlightregex/) เพื่อค้นหาเฟรมข้อความที่ใช้ได้ทั้งหมดในงานนำเสนอ ตัวอย่างต่อไปนี้ไฮไลต์คำธรรมดาและที่อยู่อีเมลทั้งหมดโดยแยกผลลัพธ์ของการค้นหาแต่ละแบบออกจากกัน

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var termCallback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

presentation.HighlightText("confidential", Color.Orange, searchOptions, termCallback);

var emailCallback = new TextSearchCallback();
var emailRegex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);

presentation.HighlightRegex(emailRegex, Color.Yellow, emailCallback);

presentation.Save("highlighted_presentation.pptx", SaveFormat.Pptx);
```

## **แทนที่ข้อความในเฟรมข้อความ**

ใช้ [ITextFrame.ReplaceText](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/replacetext/) สำหรับข้อความธรรมดาและ [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/replaceregex/) สำหรับการแทนที่ตามรูปแบบ เมธอดเหล่านี้อัปเดตข้อความที่จับคู่ภายในเฟรมข้อความที่มีอยู่ ซึ่งรักษาการจัดรูปแบบส่วนโดยรอบแทนที่จะสร้างเฟรมข้อความใหม่จากสตริงธรรมดา

ตัวอย่างต่อไปนี้ทำให้รูปแบบการสะกดแบบต่าง ๆ เป็นมาตรฐานแล้วแทนที่ป้ายรุ่นเดียวกัน Callback เดียวกันบันทึกคำต้นฉบับที่จับคู่จากทั้งสองการดำเนินการ

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

shape.TextFrame.ReplaceText("colour", "color", searchOptions, callback);

var versionRegex = new Regex(@"\bv\d+(?:\.\d+)*\b", RegexOptions.IgnoreCase);
shape.TextFrame.ReplaceRegex(versionRegex, "current version", callback);

presentation.Save("updated_text_frame.pptx", SaveFormat.Pptx);
```

หากการจับคู่หนึ่งครอบคลุมส่วนที่มีการจัดรูปแบบแตกต่างกัน โปรดตรวจสอบผลลัพธ์เพื่อยืนยันว่าการจัดรูปแบบใดควรใช้กับข้อความที่แทนที่

## **แทนที่ข้อความทั่วงานนำเสนอ**

ใช้ [Presentation.ReplaceText](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/replacetext/) และ [Presentation.ReplaceRegex](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/replaceregex/) เพื่อดำเนินการเดียวกันทั่วงานนำเสนอ สิ่งนี้มีประโยชน์สำหรับการทำความสะอาดเทมเพลต, การอัปเดตคำศัพท์, และการลบข้อมูล

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};

presentation.ReplaceText("Contoso", "Example Corp", searchOptions, callback);

var accountNumberRegex = new Regex(@"\bACCT-\d{6}\b");
presentation.ReplaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

presentation.Save("updated_presentation.pptx", SaveFormat.Pptx);
```

## **จัดกลุ่มการจับคู่เพื่อการรายงาน**

เนื่องจากผลลัพธ์แต่ละรายการเก็บหมายเลขสไลด์และเฟรมข้อความ แอปพลิเคชันสามารถจัดกลุ่มการจับคู่เพื่อการตรวจสอบ, รายงาน หรือกระบวนการทบทวน ตัวอย่างต่อไปนี้จัดกลุ่มผลลัพธ์ที่รวบรวมโดยแรกตามสไลด์แล้วตามเฟรมข้อความ:

```cs
using System;
using System.Linq;

var matchesBySlide = callback.Results.GroupBy(result => result.SlideNumber);

foreach (var slideGroup in matchesBySlide)
{
    var slideLabel = slideGroup.Key.HasValue ? slideGroup.Key.Value.ToString() : "Other";
    Console.WriteLine($"Slide: {slideLabel}");

    var matchesByTextFrame = slideGroup.GroupBy(result => result.TextFrame);
    foreach (var textFrameGroup in matchesByTextFrame)
    {
        Console.WriteLine($"  Text frame: {textFrameGroup.Key.Text}");

        foreach (var result in textFrameGroup)
        {
            Console.WriteLine($"    '{result.FoundText}' at position {result.TextPosition}; context: '{result.SourceText}'");
        }
    }
}
```

## **คำถามที่พบบ่อย**

**How can I search only one text box instead of the entire presentation?**  
รับเฟรมข้อความของรูปร่างแล้วเรียกใช้ [ITextFrame.HighlightText](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/replacetext/), หรือ [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/replaceregex/) บนเฟรมข้อความนั้น วิธีการระดับงานนำโชจจะประมวลผลทุกเฟรมข้อความที่ใช้ได้แทน

**How can I match complete words with the correct capitalization?**  
ตั้งค่า [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/th/net/aspose.slides/textsearchoptions/wholewordsonly/) และ [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/th/net/aspose.slides/textsearchoptions/casesensitive/) ให้เป็น `true` และส่งตัวเลือกไปยังเมธอดไฮไลต์หรือแทนที่ข้อความธรรมดา สำหรับ regular expression ให้กำหนดขอบเขตคำและความไวต่อขนาดตัวอักษรภายใน `Regex` ของ .NET เอง

**Can search and replacement include text in slide notes?**  
ได้ ตั้งค่า [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/th/net/aspose.slides/textsearchoptions/includenotes/) ให้เป็น `true` เมื่อใช้การดำเนินการข้อความธรรมดาระดับงานนำเสนอ Callback ที่แสดงด้านบนจะแมพการจับคู่ในโน้ตสไลด์กลับไปยังหมายเลขสไลด์แม่

**How can I create a report without scanning the presentation a second time?**  
ส่ง implementation ของ [IFindResultCallback](https://reference.aspose.com/slides/th/net/aspose.slides/ifindresultcallback/) ไปยังการไฮไลต์หรือการแทนที่ Callback จะรับทุกการจับคู่ขณะดำเนินการ ทำให้แอปพลิเคชันสามารถบันทึกข้อความต้นฉบับ, ข้อความที่จับคู่, ตำแหน่ง, เฟรมข้อความและหมายเลขสไลด์ที่สกัดไว้สำหรับการจัดกลุ่มหรือส่งออกในภายหลัง

**Does replacing text preserve its formatting?**  
[ITextFrame.ReplaceText](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/replacetext/) และ [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/replaceregex/) ปรับข้อความที่จับคู่ภายในเฟรมข้อความเดิมและรักษาการจัดรูปแบบส่วนโดยรอบ หากการจับคู่ครอบคลุมส่วนที่มีการจัดรูปแบบต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อให้แน่ใจว่าการแทนที่ใช้สไตล์ที่ต้องการ