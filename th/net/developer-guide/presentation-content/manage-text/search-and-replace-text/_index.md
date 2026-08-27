---
title: ค้นหาและแทนที่ข้อความในงานนำเสนอ PowerPoint ด้วย .NET
linktitle: ค้นหาและแทนที่ข้อความ
type: docs
weight: 55
url: /th/net/search-and-replace-text/
keywords:
- ค้นหาข้อความ
- การเน้นข้อความ
- แทนที่ข้อความ
- นิพจน์ปกติ
- callback ผลลัพธ์
- กรอบข้อความ
- รายงานการตรวจสอบ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นหา, เน้นสี, และแทนที่ข้อความในงานนำเสนอ PowerPoint พร้อมเก็บทุกการจับคู่ด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Aspose.Slides for .NET สามารถค้นหา, เน้นสี, และแทนที่ข้อความในกรอบข้อความเดี่ยวหรือทั่วทั้งงานนำเสนอได้ ทุกการดำเนินการยังสามารถแจ้งแอปพลิเคชันเกี่ยวกับแต่ละการจับคู่ผ่านผลลัพธ์ callback ทำให้สามารถอัปเดตงานนำเสนอและสร้างร่องรอยการตรวจสอบที่ประกอบด้วยข้อความที่จับคู่, บริบท, ตำแหน่ง, กรอบข้อความ, และหมายเลขสไลด์ได้พร้อมกัน

ความสามารถเหล่านี้มีประโยชน์สำหรับการตรวจทาน, การลบข้อมูล, การตรวจสอบคำศัพท์, การทำความสะอาดแม่แบบ, และการทำงานอัตโนมัติในการสร้างรายงาน

ในตัวอย่างแรกด้านล่าง เราใช้ไฟล์ชื่อ "sample.pptx" ซึ่งมีกล่องข้อความเดี่ยวบนสไลด์แรกพร้อมกับข้อความต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

## **เลือกขอบเขตการค้นหา**

ใช้เมธอดบน [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) เพื่อจำกัดการดำเนินการไว้ที่กรอบข้อความเดียว ใช้เมธอดบน [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เพื่อประมวลผลข้อความทั้งหมดที่ใช้ได้ในงานนำเสนอ

| การดำเนินการ | เฟรมข้อความเดียว | งานนำเสนอทั้งหมด |
|---|---|---|
| เน้นข้อความตามตัวอักษร | [ITextFrame.HighlightText](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/highlighttext/) |
| เน้นผลการจับคู่ของ regular expression | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/highlightregex/) |
| แทนที่ข้อความตามตัวอักษร | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/replacetext/) |
| แทนที่ผลการจับคู่ของ regular expression | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/replaceregex/) |

## **กำหนดการจับคู่ข้อความ**

สำหรับการดำเนินการแบบข้อความตามตัวอักษร ใช้ [TextSearchOptions](https://reference.aspose.com/slides/th/net/aspose.slides/textsearchoptions/) เพื่อควบคุมการจับคู่:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/th/net/aspose.slides/textsearchoptions/wholewordsonly/) จำกัดการจับคู่ให้เป็นคำเต็มเท่านั้น
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/th/net/aspose.slides/textsearchoptions/casesensitive/) ควบคุมว่าต้องตรงตามการใช้ตัวพิมพ์ใหญ่‑เล็กหรือไม่
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/th/net/aspose.slides/textsearchoptions/includenotes/) รวมบันทึกสไลด์ในการค้นหา, การแทนที่, และการเน้นสีระดับงานนำเสนอ

การดำเนินการแบบ regular expression ใช้ `Regex` ของ .NET ดังนั้นกฎการจับคู่ เช่น ความไวต่อการใช้ตัวอักษรใหญ่‑เล็กและขอบเขตคำ จะถูกกำหนดโดยนิพจน์และตัวเลือกของมันเอง

## **ระบุเจ้าของของเฟรมข้อความ**

การทำงานทั่วไปกับข้อความมักได้รับ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ในระหว่างการค้นหา, แทนที่, ตรวจสอบ, หรือส่งออกข้อความ ใช้ [ITextFrame.ParentShape](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/parentshape/) และ [ITextFrame.ParentCell](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/parentcell/) เพื่อระบุว่าออบเจ็กต์งานนำเสนอใดเป็นเจ้าของกรอบข้อความนั้น

ค่าที่คาดหวังขึ้นอยู่กับเจ้าของ:

| เจ้าของเฟรมข้อความ | `ParentShape` | `ParentCell` |
|---|---|---|
| AutoShape หรือรูปร่างที่มีข้อความอื่น | ออบเจ็กต์ [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) ที่เป็นเจ้าของ | `null` |
| เซลล์ของตาราง | `null` | ออบเจ็กต์ [ICell](https://reference.aspose.com/slides/th/net/aspose.slides/icell/) ที่เป็นเจ้าของ |

คุณสมบัติดังกล่าวเป็นคุณสมบัติการนำทางแบบอ่าน‑อย่างเดียว การอ่านค่าเหล่านี้จะไม่ย้ายกรอบข้อความหรือเปลี่ยนเจ้าของ โค้ดทั่วไปควรตรวจสอบค่าทั้งสองสำหรับ `null` และจัดการกรณีที่ไม่มีเจ้าของใด ๆ พร้อมใช้งาน

ตัวอย่างต่อไปนี้ใช้ [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/th/net/aspose.slides.util/slideutil/getalltextframes/) เพื่อวนลูปกรอบข้อความทั้งหมดในงานนำเสนอ สำหรับรูปร่าง จะรายงานชื่อรูปร่าง, ชนิดรูปร่าง, และสไลด์ที่บรรจุไว้ สำหรับเซลล์ของตาราง จะรายงานพิกัดคอลัมน์และแถวเริ่มจากศูนย์และสไลด์ที่บรรจุ

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation("presentation.pptx");

var textFrames = SlideUtil.GetAllTextFrames(presentation, false);

foreach (var textFrame in textFrames)
{
    var ownerShape = textFrame.ParentShape;
    if (ownerShape != null)
    {
        var shapeName = string.IsNullOrEmpty(ownerShape.Name) ? "(unnamed)" : ownerShape.Name;
        var shapeType = GetShapeType(ownerShape);
        var slideLabel = GetSlideLabel(ownerShape.Slide);
        Console.WriteLine($"Shape: {shapeName}; type: {shapeType}; {slideLabel}");

        continue;
    }

    var ownerCell = textFrame.ParentCell;
    if (ownerCell != null)
    {
        var slideLabel = GetSlideLabel(ownerCell.Slide);
        Console.WriteLine($"Table cell: column {ownerCell.FirstColumnIndex}, row {ownerCell.FirstRowIndex}; {slideLabel}");
        continue;
    }

    Console.WriteLine("The text frame owner is not available as a shape or table cell.");
}

static string GetShapeType(IShape shape)
{
    if (shape is IGeometryShape geometryShape)
    {
        return geometryShape.ShapeType.ToString();
    }

    return shape.GetType().Name;
}

static string GetSlideLabel(IBaseSlide baseSlide)
{
    if (baseSlide is ISlide slide)
    {
        return $"slide {slide.SlideNumber}";
    }

    if (baseSlide is INotesSlide notesSlide)
    {
        return $"notes for slide {notesSlide.ParentSlide.SlideNumber}";
    }

    return baseSlide.GetType().Name;
}
```

สำหรับเนื้อหา SmartArt ให้วนลูปรูปร่างใน [ISmartArtNode.Shapes](https://reference.aspose.com/slides/th/net/aspose.slides.smartart/ismartartnode/shapes/) และเข้าถึงแต่ละ [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides.smartart/ismartartshape/textframe/) กรอบข้อความสามารถสืบหาไปยังรูปร่างที่เกี่ยวข้องผ่าน [ITextFrame.ParentShape](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/parentshape/) ส่วน [ITextFrame.ParentCell](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/parentcell/) จะเป็น `null` ดังนั้นสาขารูปร่างในตัวอย่างจึงจัดการข้อความจากโหนด SmartArt ด้วยเช่นกัน

## **รวบรวมข้อมูลการจับคู่ด้วย Callback**

ดำเนินการ implement [IFindResultCallback](https://reference.aspose.com/slides/th/net/aspose.slides/ifindresultcallback/) เพื่อรับการแจ้งเตือนสำหรับการจับคู่แต่ละครั้งเมธอด [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/th/net/aspose.slides/ifindresultcallback/foundresult/) ให้กรอบข้อความที่เกี่ยวข้อง, ข้อความต้นฉบับ, ข้อความที่จับคู่, และตำแหน่งการจับคู่

Callback ไม่ได้รับหมายเลขสไลด์โดยตรง การดำเนินการด้านล่างจะสืบหาเลขสไลด์จากสไลด์แม่และยังจัดการข้อความที่พบในบันทึกสไลด์ด้วย เลขสไลด์ที่เป็นค่า nullable ทำให้โมเดลผลลัพธ์เดียวกันสามารถแสดงข้อความที่เกี่ยวข้องกับประเภทสไลด์อื่นได้

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
        var parentSlide = textFrame.ParentShape?.Slide ?? textFrame.ParentCell?.Slide ?? textFrame.Slide;

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

สำหรับการดำเนินการแทนที่ `FoundText` จะบรรจุข้อความที่จับคู่เดิม ดังนั้น callback สามารถบันทึกคำที่ถูกแทนที่ได้อย่างแม่นยำ

## **เน้นข้อความ**

ใช้เมธอด [ITextFrame.HighlightText](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/highlighttext/) เพื่อเน้นผลการจับคู่ของข้อความตามตัวอักษรในกรอบข้อความ ส่ง [TextSearchOptions](https://reference.aspose.com/slides/th/net/aspose.slides/textsearchoptions/) เพื่อควบคุมการค้นหาและ callback เพื่อรวบรวมรายละเอียดการจับคู่

โค้ดตัวอย่างด้านล่างเน้นทุกการปรากฏของอักขระ **"try"** แล้วจึงเน้นเฉพาะคำเต็ม **"to"** ทั้งสองการค้นหาจะส่งผลลัพธ์ไปยัง callback เดียวกัน

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

![ข้อความที่ถูกเน้น](highlighted_text.png)

## **เน้นข้อความโดยใช้ Regular Expressions**

เมธอด [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/highlightregex/) จะเน้นข้อความที่ตรงกับ regular expression ในกรอบข้อความ

โค้ดต่อไปนี้เน้นทุกคำที่มีความยาวเจ็ดตัวอักษรหรือมากกว่าและรวบรวมแต่ละการจับคู่

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

![ข้อความที่ถูกเน้นโดยใช้ regular expression](highlighted_text_using_regex.png)

## **เน้นข้อความทั่วทั้งงานนำเสนอ**

ใช้ [Presentation.HighlightText](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/highlighttext/) และ [Presentation.HighlightRegex](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/highlightregex/) เพื่อค้นหากรอบข้อความทั้งหมดที่ใช้ได้ในงานนำเสนอ ตัวอย่างต่อไปนี้จะเน้นคำตามตัวอักษรและที่อยู่อีเมลทั้งหมดโดยแยกคอลเลกชันผลลัพธ์สำหรับการค้นหาแต่ละประเภท

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

ใช้ [ITextFrame.ReplaceText](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/replacetext/) สำหรับข้อความตามตัวอักษรและ [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/replaceregex/) สำหรับการแทนที่ตามรูปแบบ เมธอดเหล่านี้อัปเดตข้อความที่จับคู่ภายในกรอบข้อความเดิม ซึ่งคงรูปแบบส่วนที่อยู่รอบ ๆ แทนการสร้างกรอบข้อความใหม่จากสตริงเปล่า

ตัวอย่างต่อไปนี้ทำให้รูปแบบการสะกดมาตรฐานหนึ่งแบบและจากนั้นแทนที่ป้ายเวอร์ชันเดียวกัน Callback เดียวกันบันทึกคำต้นฉบับที่จับคู่จากทั้งสองการดำเนินการ

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

หากการจับคู่ครอบคลุมส่วนที่มีรูปแบบแตกต่างกัน โปรดตรวจสอบผลลัพธ์เพื่อยืนยันว่าต้องใช้รูปแบบใดกับข้อความที่แทนที่

## **แทนที่ข้อความทั่วทั้งงานนำเสนอ**

ใช้ [Presentation.ReplaceText](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/replacetext/) และ [Presentation.ReplaceRegex](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/replaceregex/) เพื่อทำการเดียวกันทั่วทั้งงานนำเสนอ สิ่งนี้เป็นประโยชน์สำหรับการทำความสะอาดแม่แบบ, การอัปเดตศัพท์, และการลบข้อมูล

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

## **จัดกลุ่มผลการจับคู่เพื่อการรายงาน**

เนื่องจากแต่ละผลลัพธ์เก็บหมายเลขสไลด์และกรอบข้อความไว้ แอปพลิเคชันจึงสามารถจัดกลุ่มผลลัพธ์เพื่อการตรวจสอบ, รายงาน, หรือกระบวนการทบทวน ตัวอย่างต่อไปนี้จัดกลุ่มผลลัพธ์ที่รวบรวมได้โดยแรกตามสไลด์และต่อมาตามกรอบข้อความ

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

**ฉันจะค้นหาเฉพาะกล่องข้อความเดียวแทนการค้นหาทั้งงานนำเสนอได้อย่างไร?**

รับกรอบข้อความของรูปทรงแล้วเรียกใช้ [ITextFrame.HighlightText](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/replacetext/), หรือ [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/replaceregex/) บนกรอบข้อความนั้น เมธอดระดับงานนำเรื่องจะประมวลผลกรอบข้อความทั้งหมดที่ใช้ได้แทน

**ฉันจะจับคู่คำเต็มโดยคงรูปแบบการใช้ตัวอักษรใหญ่‑เล็กให้ถูกต้องได้อย่างไร?**

ตั้งค่า [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/th/net/aspose.slides/textsearchoptions/wholewordsonly/) และ [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/th/net/aspose.slides/textsearchoptions/casesensitive/) ให้เป็น `true` แล้วส่งตัวเลือกเหล่านั้นไปยังเมธอดเน้นสีหรือแทนที่ข้อความตามตัวอักษร สำหรับ regular expression ให้กำหนดขอบเขตคำและความไวต่อการใช้ตัวอักษรใหญ่‑เล็กใน `Regex` เอง

**การค้นหาและการแทนที่สามารถรวมข้อความในบันทึกสไลด์ได้หรือไม่?**

ได้ ตั้งค่า [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/th/net/aspose.slides/textsearchoptions/includenotes/) ให้เป็น `true` เมื่อใช้เมธอดการดำเนินการข้อความตามตัวอักษรระดับงานนำเสนอ Callback ที่แสดงในข้างต้นจะแมปการจับคู่ในสไลด์บันทึกกลับไปยังหมายเลขสไลด์แม่

**ฉันจะสร้างรายงานโดยไม่ต้องสแกนงานนำเสนอครั้งที่สองได้อย่างไร?**

ส่งอิมพลีเมนเทชันของ [IFindResultCallback](https://reference.aspose.com/slides/th/net/aspose.slides/ifindresultcallback/) ไปยังการเน้นสีหรือการแทนที่ เมธอด Callback จะรับการจับคู่ทุกครั้งขณะดำเนินการดังนั้นแอปพลิเคชันจึงสามารถเก็บข้อความต้นฉบับ, ข้อความที่จับคู่, ตำแหน่ง, กรอบข้อความ, และหมายเลขสไลด์ที่สกัดได้สำหรับการจัดกลุ่มหรือการส่งออกในภายหลัง

**การแทนที่ข้อความจะคงรูปแบบไว้หรือไม่?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/replacetext/) และ [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/replaceregex/) แก้ไขข้อความที่จับคู่ภายในกรอบข้อความเดิมและคงรูปแบบส่วนที่อยู่รอบ ๆ ไว้ หากการจับคู่ครอบคลุมส่วนที่มีรูปแบบต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อให้แน่ใจว่าการแทนที่จะใช้สไตล์ที่ต้องการ