---
title: จัดการ Hyperlink ของงานนำเสนอใน .NET
linktitle: จัดการ Hyperlink
type: docs
weight: 20
url: /th/net/manage-hyperlinks/
keywords:
- เพิ่ม URL
- เพิ่ม Hyperlink
- สร้าง Hyperlink
- รูปแบบ Hyperlink
- ลบ Hyperlink
- ปรับปรุง Hyperlink
- Hyperlink ข้อความ
- Hyperlink สไลด์
- Hyperlink รูปร่าง
- Hyperlink รูปภาพ
- Hyperlink วิดีโอ
- Hyperlink ที่ปรับเปลี่ยนได้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เพิ่ม, กำหนดรูปแบบ, ปรับปรุง, และลบ Hyperlink ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET, ใช้ตัวอย่าง C#."
---
## **บทนำ**

Hyperlink เชื่อมต่อเนื้อหาในงานนำเสนอไปยังเว็บไซต์หรือสถานที่ภายในงานนำเสนอเอง ใน PowerPoint Hyperlink มักใช้เพื่อสองวัตถุประสงค์หลัก:

* เปิดเว็บไซต์จากข้อความ, รูปร่าง, หรือกรอบสื่อ
* นำทางไปยังสไลด์อื่น, ตัวอย่างเช่น จากสารบัญ

Aspose.Slides for .NET ให้คุณเพิ่มลิงก์เหล่านี้, ควบคุมลักษณะและเสียง, ปรับปรุงคุณสมบัติ, และลบออก ตัวอย่างด้านล่างแสดงวิธีทำงานกับ Hyperlink บนองค์ประกอบแต่ละตัวและวิธีเข้าถึง Hyperlink ระดับงานนำเสนอ, สไลด์, หรือกรอบข้อความ

{{% alert color="info" title="หมายเหตุ" %}}
คุณสามารถแก้ไขงานนำเสนอได้ด้วย [เครื่องมือแก้ไข PowerPoint ออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/th/editor)
{{% /alert %}} 

## **เพิ่ม Hyperlink URL**

คุณสามารถกำหนด URL ของเว็บไซต์ให้กับข้อความ, รูปร่าง, หรือกรอบสื่อได้ พื้นที่ที่คลิกได้จะถูกกำหนดโดยองค์ประกอบที่คุณกำหนด Hyperlink: ส่วนของข้อความเชื่อมต่อกับข้อความที่เลือก, ขณะที่รูปร่างหรือกรอบเชื่อมต่อกับออบเจ็กต์สไลด์

### **เพิ่ม Hyperlink URL ให้กับข้อความ**

เพื่อเชื่อมข้อความกับเว็บไซต์, ให้กำหนด [Hyperlink](https://reference.aspose.com/slides/th/net/aspose.slides/hyperlink/) ให้กับคุณสมบัติ [HyperlinkClick](https://reference.aspose.com/slides/th/net/aspose.slides/portionformat/hyperlinkclick/) ของส่วนข้อความ, ตามตัวอย่างด้านล่าง ส่วนข้อความนั้นจะกลายเป็นคลิกได้เท่านั้น

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var textShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
textShape.AddTextFrame("Aspose: File Format APIs");
var portionFormat = textShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
portionFormat.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";
portionFormat.FontHeight = 32;

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

### **เพิ่ม Hyperlink URL ให้กับรูปร่างและกรอบสื่อ**

เพื่อทำให้รูปร่างหรือกรอบคลิกได้, ให้ตั้งค่าคุณสมบัติ [HyperlinkClick](https://reference.aspose.com/slides/th/net/aspose.slides/shape/hyperlinkclick/) ของมัน Hyperlink จะเป็นของออบเจ็กต์เอง ไม่ใช่ของส่วนข้อความภายใน

แนวทางเดียวกันใช้กับกรอบรูป, เสียง, และวิดีโอ: กำหนด Hyperlink ให้กับกรอบและตั้งค่า [Tooltip](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/tooltip/) ของลิงก์หากต้องการ

ตัวอย่างต่อไปทำให้สี่เหลี่ยมคลิกได้:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **ใช้ Hyperlink สร้างสารบัญ**

Hyperlink ภายในทำให้ผู้อ่านกระโดดจากสารบัญไปยังสไลด์เฉพาะ ตัวอย่างต่อไปใช้ [SetInternalHyperlinkClick](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) เพื่อเชื่อมข้อความ “Page 2” บนสไลด์แรกไปยังสไลด์ที่สอง

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var tableOfContents = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
tableOfContents.FillFormat.FillType = FillType.NoFill;
tableOfContents.LineFormat.FillFormat.FillType = FillType.NoFill;
tableOfContents.TextFrame.Paragraphs.Clear();

var paragraph = new Paragraph();
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
paragraph.Text = "Title of slide 2 .......... ";

var linkPortion = new Portion();
linkPortion.Text = "Page 2";
linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

paragraph.Portions.Add(linkPortion);
tableOfContents.TextFrame.Paragraphs.Add(paragraph);

presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
```

## **จัดรูปแบบ Hyperlink**

### **สี**

คุณสมบัติ [ColorSource](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/colorsource/) ของ [IHyperlink](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/) กำหนดว่า Hyperlink จะใช้สี Hyperlink ของงานนำเสนอหรือการจัดรูปแบบของส่วนข้อความหรือไม่ เพื่อกำหนดสีข้อความแบบกำหนดเอง, เลือก [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/hyperlinkcolorsource/) แล้วตั้งค่าสีเติมของส่วนนั้น ฟีเจอร์นี้เริ่มต้นใน PowerPoint 2019; เวอร์ชันก่อนหน้าจะไม่ใช้การตั้งค่านี้

ตัวอย่างต่อไปเพิ่ม Hyperlink ข้อความสองลิงก์ในสไลด์เดียว ลิงก์แรกใช้สีเติมข้อความสีแดง, ส่วนลิงก์ที่สองใช้สี Hyperlink เริ่มต้น

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var coloredShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
coloredShape.AddTextFrame("This hyperlink uses a custom color.");
var coloredPortionFormat = coloredShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
coloredPortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
coloredPortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
coloredPortionFormat.FillFormat.FillType = FillType.Solid;
coloredPortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

var defaultShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
defaultShape.AddTextFrame("This hyperlink uses the default color.");
defaultShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
```
### **เสียง**

Hyperlink สามารถเล่นเสียงเมื่อเปิดใช้งานหรือหยุดเสียงที่กำลังเล่นอยู่ ใช้คุณสมบัติดังต่อไปนี้เพื่อกำหนดพฤติกรรม:

- [IHyperlink.Sound](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/sound/) ระบุไฟล์เสียงที่เชื่อมกับ Hyperlink
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/stopsoundonclick/) ควบคุมว่าการคลิก Hyperlink จะหยุดเสียงก่อนหน้าหรือไม่

#### **เพิ่มเสียงให้ Hyperlink**

ตัวอย่างต่อไปโหลด `sampleaudio.wav` และเชื่อมกับปุ่มบนสไลด์แรก การคลิกปุ่มจะเล่นเสียงและนำทางไปยังสไลด์ถัดไป รูปแบบที่สองบนสไลด์เดียวกันจะหยุดเสียงก่อนหน้าเมื่อคลิกโดยไม่ทำการนำทาง

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var audioData = File.ReadAllBytes("sampleaudio.wav");
var hyperlinkSound = presentation.Audios.AddAudio(audioData);

var firstSlide = presentation.Slides[0];

var playButton = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
playButton.HyperlinkClick = Hyperlink.NextSlide;

if (!playButton.HyperlinkClick.StopSoundOnClick && playButton.HyperlinkClick.Sound == null)
{
    playButton.HyperlinkClick.Sound = hyperlinkSound;
}

var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var stopButton = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
stopButton.HyperlinkClick = Hyperlink.NoAction;

stopButton.HyperlinkClick.StopSoundOnClick = true;

presentation.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
```

#### **ดึงข้อความเสียงจาก Hyperlink**

ตัวอย่างต่อไปเปิดงานนำเสนอที่สร้างไว้ข้างต้นและอ่านเสียง Hyperlink ของรูปร่างแรกเข้าสู่หน่วยความจำโดยใช้ [Sound](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/sound/) และ [BinaryData](https://reference.aspose.com/slides/th/net/aspose.slides/iaudio/binarydata/)

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("hyperlink-sound.pptx");

if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
{
    var hyperlink = presentation.Slides[0].Shapes[0].HyperlinkClick;
    var sound = hyperlink?.Sound;
    if (sound != null)
    {
        var audioData = sound.BinaryData;
        Console.WriteLine($"Extracted {audioData.Length} bytes of hyperlink audio.");
    }
    else
    {
        Console.WriteLine("The first shape has no hyperlink sound.");
    }
}
else
{
    Console.WriteLine("The presentation has no first slide or shape to inspect.");
}
```

### **Tooltip และการตั้งค่าการโต้ตอบ**

คุณสามารถอัปเดตคุณสมบัติเบื้องต้นของ [IHyperlink](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/) หลังจากกำหนด Hyperlink ให้กับข้อความหรือรูปร่าง:

- [Tooltip](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/tooltip/) ตั้งข้อความที่ผู้ดูสามารถแสดงเป็นคำแนะนำสำหรับลิงก์
- [TargetFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/targetframe/) ระบุเฟรมเป้าหมายภายในชุดเฟรม HTML ของพาเรนต์ (หากมี)
- [History](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/history/) ควบคุมว่าการเปิดลิงก์จะเพิ่มเป้าหมายลงในรายการ Hyperlink ที่ดูแล้วหรือไม่
- [HighlightClick](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/highlightclick/) ควบคุมว่าลิงก์จะไฮไลต์เมื่อคลิกหรือไม่

## **ลบ Hyperlink ออกจากงานนำเสนอ**

ใช้ [GetAnyHyperlinks](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) เพื่อรวบรวมคอนเทนเนอร์ของ Hyperlink, รวมถึงลิงก์ส่วนข้อความ, ก่อนทำการเปลี่ยนแปลง ตัวอย่างต่อไปลบประเภทการเปิดใช้งานทั้งสองจากสไลด์แรก หากต้องการลบประเภทเดียวให้เรียกเฉพาะ [RemoveHyperlinkClick](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) หรือ [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); การลบการคลิกจะไม่ลบการเม้าส์โอเวอร์ที่สอดคล้อง

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

if (presentation.Slides.Count > 0)
{
    var containers = presentation.Slides[0].HyperlinkQueries.GetAnyHyperlinks().ToList();
    foreach (var container in containers)
    {
        container.HyperlinkManager.RemoveHyperlinkClick();
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
    presentation.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The presentation has no slides to process.");
}
```

สำหรับการลบแบบไม่มีเงื่อนไข, [RemoveAllHyperlinks](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) จะลบทั้งสองประเภทในขอบเขตที่เลือกในครั้งเดียว สำหรับการทำความสะอาดแบบเลือกและครอบคลุมมาสเตอร์, เลย์เอาต์, และโน๊ต, ดูหัวข้อ [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)

## **สร้างรายการตรวจสอบ Hyperlink อย่างสมบูรณ์**

ก่อนแจกจ่ายงานนำเสนอ, ควรทำรายการตรวจสอบการกระทำเชิงโต้ตอบและลิงก์เว็บของมัน [GetAnyHyperlinks](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) คืนค่าอ็อบเจ็กต์ [IHyperlinkContainer](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkcontainer/) ไม่ใช่รายการแบนของสตริง URL ตรวจสอบทั้ง [HyperlinkClick](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) และ [HyperlinkMouseOver](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) ในแต่ละคอนเทนเนอร์ พวกมันเป็นอิสระ: คอนเทนเนอร์เดียวกันอาจเปิดเผยการกระทำทั้งสอง, ดังนั้นรายงานที่สมบูรณ์อาจต้องมีสองแถวต่อคอนเทนเนอร์

การตรวจสอบเฉพาะระดับรูปร่างอาจพลาดลิงก์ที่แนบกับส่วนข้อความ ให้สอบถามในขอบเขตที่เหมาะสมแทนและเก็บคอนเทนเนอร์ที่ได้เพื่อให้สามารถอัปเดตหรือถอนการกระทำในภายหลังได้

### **สอบถามขอบเขต Presentation, Slide, และ Text‑Frame**

อินเทอร์เฟซ [IHyperlinkQueries](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkqueries/) มีให้ผ่าน [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseslide/hyperlinkqueries/), และ [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/hyperlinkqueries/). แต่ละขอบเขตสนับสนุนคำถามเดียวกัน:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) คืนคอนเทนเนอร์ที่มีการกระทำคลิก
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) คืนคอนเทนเนอร์ที่มีการกระทำเม้าส์โอเวอร์
- [GetAnyHyperlinks](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) คืนคอนเทนเนอร์ที่มีอย่างใดอย่างหนึ่งหรือทั้งสอง

ตัวอย่างต่อไปสร้าง `hyperlink-audit-input.pptx` พร้อมลิงก์คลิกภายนอก, ลิงก์เม้าส์โอเวอร์ไฟล์, การนำทางสไลด์ภายใน, ลิงก์เม้าส์โอเวอร์ข้อความ, และการกระทำแมโคร ตัวอย่างนี้ไม่ได้เรียกใช้การกระทำใดๆ คำถามสามประเภททำงานที่ทุกขอบเขต; จำนวนที่แสดงเป็นจำนวนคอนเทนเนอร์ ไม่ใช่จำนวนการกระทำรวม ขอบเขต Text‑Frame จะละเว้นลิงก์ของรูปร่างที่หุ้มเอง

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var destination = presentation.Slides.AddEmptySlide(slide.LayoutSlide);
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Click the text to go to slide 2";
shape.HyperlinkManager.SetExternalHyperlinkClick("https://example.com/");
shape.HyperlinkClick.Tooltip = "Public website";
shape.HyperlinkManager.SetExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

var portionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkManager.SetInternalHyperlinkClick(destination);
portionFormat.HyperlinkManager.SetExternalHyperlinkMouseOver("https://example.com/help");
var macroButton = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
macroButton.HyperlinkManager.SetMacroHyperlinkClick("ReviewPresentation");

PrintCounts("Presentation", presentation.HyperlinkQueries);
PrintCounts("Slide 1", slide.HyperlinkQueries);
PrintCounts("Text frame", shape.TextFrame.HyperlinkQueries);
presentation.Save("hyperlink-audit-input.pptx", SaveFormat.Pptx);

static void PrintCounts(string scope, IHyperlinkQueries queries)
{
    var clickContainers = queries.GetHyperlinkClicks();
    var mouseOverContainers = queries.GetHyperlinkMouseOvers();
    var allContainers = queries.GetAnyHyperlinks();
    Console.WriteLine($"{scope}: click={clickContainers.Count}, mouse-over={mouseOverContainers.Count}, any={allContainers.Count}");
}
```

ในตัวอย่างนี้, คำถามระดับ Presentation และ Slide แต่ละอันรายงานคอนเทนเนอร์คลิกสามรายการ, คอนเทนเนอร์เม้าส์โอเวอร์สองรายการ, และคอนเทนเนอร์ที่มีอย่างใดอย่างหนึ่งสามรายการ ขอบเขต Text‑Frame รายงานคอนเทนเนอร์หนึ่งรายการในแต่ละหมวด

### **จำแนกการกระทำและปลายทาง**

ใช้ [IHyperlink.ActionType](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/actiontype/) เพื่อแปลความหมายของการกระทำก่อนแปลความหมายของปลายทาง ค่า [HyperlinkActionType](https://reference.aspose.com/slides/th/net/aspose.slides/hyperlinkactiontype/) ครอบคลุมมากกว่าการนำทางเว็บ:

| Values | ความหมายสำหรับการตรวจสอบ |
| --- | --- |
| `Hyperlink` | Hyperlink ภายนอก; ตรวจสอบ URL และ scheme |
| `JumpSpecificSlide` | การนำทางภายในไปยังสไลด์เฉพาะ |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | การนำทางสไลด์โชว์ที่มีมาในตัว, แก้ไขตามบริบทของการแสดง |
| `JumpEndShow`, `StartCustomSlideShow` | จบการแสดงปัจจุบันหรือเริ่มการแสดงที่กำหนดเอง |
| `StartMacro` | เรียกใช้งานแมโคร |
| `StartProgram` | เริ่มโปรแกรม |
| `OpenFile`, `OpenPresentation` | เปิดไฟล์หรือการนำเสนออื่น; แยกตรวจสอบจาก URL เว็บ |
| `StartStopMedia` | เริ่มหรือหยุดการเล่นสื่อ |
| `NoAction`, `Unknown` | ไม่มีการนำทางหรือการกระทำที่ไม่รู้จักต้องตรวจสอบ |

อ่านปลายทางภายนอกจาก [ExternalUrl](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/externalurl/) และปลายทางภายในเฉพาะจาก [TargetSlide](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/targetslide/). การกระทำภายในและคำสั่งในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่ได้หมายความว่าคอนเทนเนอร์ไม่มีการกระทำ เก็บ [ExternalUrlOriginal](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/externalurloriginal/) ไว้เมื่อแตกต่างจาก URL ที่ทำให้เป็นมาตรฐาน และรวม [Tooltip](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/tooltip/) เมื่อมี

### **รายงาน, ทำความสะอาด, และตรวจสอบ Hyperlink**

ตัวอย่าง .NET 6+ ต่อไปนี้อ่านงานนำเสนอที่มีอยู่ (ใช้ไฟล์ที่สร้างข้างต้น), เขียนไฟล์ `hyperlink-audit.json`, ใช้นโยบาย, บันทึกเป็น `hyperlink-sanitized.pptx`, แล้วเปิดใหม่เพื่อเช็กการกระทำทั้งสองประเภทอีกครั้ง มันรวบรวมคอนเทนเนอร์ก่อนเปลี่ยนและใช้การเปรียบเทียบอ้างอิงเพื่อหลีกเลี่ยงการประมวลผลคอนเทนเนอร์เดียวกันซ้ำ คำถาม Presentation ครอบคลุมสไลด์ทั่วไป; สำหรับรายการตรวจสอบทั่วแพ็กเกจ จะสอบถามมาสเตอร์, เลย์เอาต์, โน๊ต, และมาสเตอร์โน๊ตและใบแจกเมื่อมี

รายงานบันทึกดัชนีสไลด์ที่เริ่มจาก 1 และ [SlideId](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseslide/slideid/) เมื่อมีให้ [ISlideComponent.Slide](https://reference.aspose.com/slides/th/net/aspose.slides/islidecomponent/slide/) ให้สไลด์เจ้าของสำหรับคอนเทนเนอร์ที่สนับสนุน มาสเตอร์, เลย์เอาต์, และโน๊ตไม่มีดัชนีสไลด์ปกติและจะระบุด้วยขอบเขตของตนเอง คอนเทนเนอร์รูปร่างและคอนเทนเนอร์การจัดรูปแบบส่วนข้อความจะมีป้ายชื่อแยกกัน; ประเภทคอนเทนเนอร์อื่นจะคงชื่อชนิดรันไทม์ของตน แต่ละคอนเทนเนอร์จะได้รับ ID ในรายงานเพื่อให้การกระทำสองอย่างสามารถเชื่อมโยงกันได้

นโยบายแอปพลิเคชันที่เข้มงวดนี้อนุญาตเฉพาะ URL HTTPS แบบเต็มและเป้าหมายสไลด์ภายในที่ถูกต้อง มันปฏิเสธแมโคร, โปรแกรม, การกระทำไฟล์, การกระทำสไลด์โชว์อื่น ๆ, การกระทำที่ไม่รู้จัก, และสกีม URL อื่น การปฏิเสธเหล่านี้เป็นการตัดสินใจของนโยบาย ไม่ใช่ข้อสรุปด้านความปลอดภัยของ Aspose.Slides HTTPS เพียงอย่างเดียวไม่รับประกันความน่าเชื่อถือ: ควรเพิ่มรายการอนุญาตโฮสต์และการตรวจสอบอื่น ๆ สำหรับแอปของคุณ ทั้ง URL ภายนอกต้นฉบับและที่ทำให้เป็นมาตรฐานจะถูกตรวจสอบ ตัวอย่างนี้ตรวจสอบเมตาดาต้าโดยไม่ตามลิงก์หรือเรียกการกระทำ

สำหรับการแก้ไข, [HyperlinkManager](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) ของคอนเทนเนอร์สนับสนุน [SetExternalHyperlinkClick](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/), และ [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). ที่นี่ ลิงก์คลิกภายนอกที่ไม่ได้รับอนุญาตจะถูกแทนที่ด้วยหน้าแลนดิ้ง HTTPS คงที่; การคลิกที่ไม่ได้รับอนุญาตและการเม้าส์โอเวอร์ที่ไม่ได้รับอนุญาตอื่น ๆ จะถูกลบแยกกัน ตั้งค่า `replaceExternalClicks` เป็น `false` เพื่อเอาออกทั้งหมดแทนเลือกหน้าที่แทนที่ที่เป็นของแอปก่อนปรับใช้

ค่าสถานะส่งออกของรายงานใช้แนวนโยบายการตรวจสอบ PDF อย่างระมัดระวัง: ทำเครื่องหมายการกระทำเม้าส์โอเวอร์และสิ่งใดที่ไม่ใช่ลิงก์ภายนอกหรือการกระโดดสไลด์เฉพาะว่าอาจไม่รองรับ เป็นเพียงคำแนะนำการตรวจสอบ ไม่ใช่การทดสอบความสามารถหรือการรับประกันว่าลิงก์ที่ไม่ได้ทำเครื่องหมายจะคงอยู่ในการส่งออก การส่งออก PDF และ HTML ที่รองรับอาจคง Hyperlink ขึ้นอยู่กับการกระทำ, ตัวเลือกการส่งออก, และโปรแกรมดูภาพ Raster เช่น [images](/slides/th/net/convert-powerpoint-to-png/) และ [video](/slides/th/net/convert-powerpoint-to-video/) ไม่สามารถคง Hyperlink เชิงโต้ตอบได้; ทำเครื่องหมายทุกการกระทำเมื่อทำการตรวจสอบสำหรับเอาต์พุตเหล่านั้น

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

const bool replaceExternalClicks = true;
const string replacementUrl = "https://example.com/blocked-link";
using var presentation = new Presentation("hyperlink-audit-input.pptx");
var containers = CollectContainers(presentation);
var rows = new List<object>();

for (var index = 0; index < containers.Count; index++)
{
    var container = containers[index];
    AddRow(container.HyperlinkClick, "click", container, index + 1);
    AddRow(container.HyperlinkMouseOver, "mouse-over", container, index + 1);
}

var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
var json = JsonSerializer.Serialize(rows, jsonOptions);
File.WriteAllText("hyperlink-audit.json", json);

foreach (var container in containers)
{
    var click = container.HyperlinkClick;
    if (PolicyViolation(click) != null)
    {
        if (replaceExternalClicks && click.ActionType == HyperlinkActionType.Hyperlink)
        {
            container.HyperlinkManager.SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container.HyperlinkManager.RemoveHyperlinkClick();
        }
    }
    if (PolicyViolation(container.HyperlinkMouseOver) != null)
    {
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
}

presentation.Save("hyperlink-sanitized.pptx", SaveFormat.Pptx);
using var reopened = new Presentation("hyperlink-sanitized.pptx");
var remainingContainers = CollectContainers(reopened);
var violations = 0;
foreach (var container in remainingContainers)
{
    if (PolicyViolation(container.HyperlinkClick) != null) violations++;
    if (PolicyViolation(container.HyperlinkMouseOver) != null) violations++;
}
Console.WriteLine($"Audit rows: {rows.Count}; prohibited actions after reopening: {violations}");
if (violations != 0)
{
    Console.WriteLine("Verification failed: do not distribute the saved presentation.");
    Environment.ExitCode = 1;
}

void AddRow(IHyperlink? link, string activation, IHyperlinkContainer container, int containerId)
{
    if (link == null) return;
    var ownerSlide = (container as ISlideComponent)?.Slide;
    var targetSlide = link.TargetSlide;
    var violation = PolicyViolation(link);
    var ownerType = container is IShape ? "Shape" : container is IPortionFormat ? "Text portion" : container.GetType().Name;
    var ordinaryAction = link.ActionType == HyperlinkActionType.Hyperlink || link.ActionType == HyperlinkActionType.JumpSpecificSlide;
    rows.Add(new
    {
        ContainerId = containerId,
        SlideIndex = SlideIndex(presentation, ownerSlide),
        SlideId = ownerSlide?.SlideId,
        Scope = ownerSlide?.GetType().Name,
        OwnerType = ownerType,
        Activation = activation,
        ActionType = link.ActionType.ToString(),
        ExternalUrl = link.ExternalUrl,
        TargetSlideIndex = SlideIndex(presentation, targetSlide),
        TargetSlideId = targetSlide?.SlideId,
        Tooltip = link.Tooltip,
        OriginalExternalUrl = link.ExternalUrlOriginal != link.ExternalUrl ? link.ExternalUrlOriginal : null,
        PotentiallyUnsafe = violation != null,
        PolicyViolation = violation,
        TargetExport = "PDF",
        PotentiallyUnsupportedByExport = activation == "mouse-over" || !ordinaryAction
    });
}

static int? SlideIndex(IPresentation presentation, IBaseSlide? slide)
{
    for (var index = 0; index < presentation.Slides.Count; index++)
    {
        if (ReferenceEquals(presentation.Slides[index], slide)) return index + 1;
    }
    return null;
}

static string? PolicyViolation(IHyperlink? link)
{
    if (link == null) return null;
    if (link.ActionType == HyperlinkActionType.JumpSpecificSlide)
    {
        return link.TargetSlide == null ? "Missing target slide" : null;
    }
    if (link.ActionType != HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!IsHttps(link.ExternalUrl)) return "Normalized URL is not absolute HTTPS";
    var original = link.ExternalUrlOriginal;
    if (!string.IsNullOrEmpty(original) && !IsHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

static bool IsHttps(string? value)
{
    return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
}

static List<IHyperlinkContainer> CollectContainers(IPresentation presentation)
{
    var found = new List<IHyperlinkContainer>();
    found.AddRange(presentation.HyperlinkQueries.GetAnyHyperlinks());
    foreach (var master in presentation.Masters) AddScope(master);
    foreach (var layout in presentation.LayoutSlides) AddScope(layout);
    foreach (var slide in presentation.Slides) AddScope(slide.NotesSlideManager.NotesSlide);
    AddScope(presentation.MasterNotesSlideManager.MasterNotesSlide);
    AddScope(presentation.MasterHandoutSlideManager.MasterHandoutSlide);
    return found.Distinct<IHyperlinkContainer>(ReferenceEqualityComparer.Instance).ToList();

    void AddScope(IBaseSlide? slide)
    {
        if (slide != null) found.AddRange(slide.HyperlinkQueries.GetAnyHyperlinks());
    }
}
```

ด้วยอินพุตที่สร้างไว้ข้างต้น รายงานประกอบด้วยแถวการกระทำห้าแถว ลิงก์เม้าส์โอเวอร์ไฟล์และแมโครคลิกจะถูกลบ, ในขณะที่ลิงก์ HTTPS และการนำทางสไลด์ภายในยังคงอยู่ การตรวจสอบพิมพ์จำนวนการกระทำที่ผิดกฎเป็นศูนย์ อินพุตที่มี URL คลิกภายนอกที่ผิดกฎยังแสดงสาขาการแทนที่ คอนเทนเนอร์ที่มีคลิกที่อนุญาตและเม้าส์โอเวอร์ที่ไม่ได้รับอนุญาตจะคงคลิกไว้

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [RemoveAllHyperlinks](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) ซึ่งลบการกระทำทั้งสองประเภทในขอบเขตที่เลือกโดยไม่คำนึงถึงนโยบาย การตรวจสอบที่นี่ตรวจสอบเพียงการกระทำของ Hyperlink; ไม่ได้ลบ VBA ฝัง, OLE object, หรือเนื้อหาเชิงโต้ตอบอื่น ๆ, และไม่ตรวจสอบไฟล์ PDF หรือ HTML ที่ส่งออก

## **FAQ**

**ฉันจะลิงก์ไปยังส่วนหรือสไลด์แรกของส่วนได้อย่างไร?**

ส่วนใน PowerPoint จัดกลุ่มสไลด์, แต่ Hyperlink ภายในจะชี้ไปยังสไลด์เดียว การสร้างการนำทางไปยังส่วนให้ลิงก์ไปยังสไลด์แรกของส่วนนั้น

**ฉันสามารถแนบ Hyperlink ให้กับองค์ประกอบมาสเตอร์สไลด์เพื่อให้ทำงานบนทุกสไลด์ได้ไหม?**

ได้ ด้านมาสเตอร์สไลด์และเลย์เอาต์รองรับ Hyperlink ลิงก์บนองค์ประกอบเหล่านี้จะพร้อมใช้งานในระหว่างการแสดงสไลด์บนสไลด์ที่ใช้มาสเตอร์หรือเลย์เอาต์นั้น

**Hyperlink จะคงอยู่หรือไม่เมื่อส่งออกเป็น PDF, HTML, ภาพ หรือวิดีโอ?**

การส่งออก PDF และ HTML ที่รองรับอาจคง Hyperlink ไว้; ภาพเรสเตอร์และวิดีโอไม่สามารถคง Hyperlink เชิงโต้ตอบได้ ดูข้อพิจารณาการส่งออกในหัวข้อ [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)