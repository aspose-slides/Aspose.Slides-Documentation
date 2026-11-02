---
title: จัดการไฮเปอร์ลิงก์ในการนำเสนอใน .NET
linktitle: จัดการไฮเปอร์ลิงก์
type: docs
weight: 20
url: /th/net/manage-hyperlinks/
keywords:
- เพิ่ม URL
- เพิ่มไฮเปอร์ลิงก์
- สร้างไฮเปอร์ลิงก์
- จัดรูปแบบไฮเปอร์ลิงก์
- ลบไฮเปอร์ลิงก์
- อัปเดตไฮเปอร์ลิงก์
- ไฮเปอร์ลิงก์ข้อความ
- ไฮเปอร์ลิงก์สไลด์
- ไฮเปอร์ลิงก์รูปร่าง
- ไฮเปอร์ลิงก์รูปภาพ
- ไฮเปอร์ลิงก์วิดีโอ
- ไฮเปอร์ลิงก์ที่เปลี่ยนแปลงได้
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เพิ่ม, จัดรูปแบบ, อัปเดต และลบไฮเปอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET โดยใช้ตัวอย่าง C#."
---
## **คำนำ**

ไฮเปอร์ลิงก์เชื่อมโยงเนื้อหาการนำเสนอไปยังเว็บไซต์หรือตำแหน่งภายในงานนำเสนอ ใน PowerPoint ไฮเปอร์ลิงก์มักทำหน้าที่สองอย่าง:

* เปิดเว็บไซต์จากข้อความ, รูปร่าง, หรือเฟรมสื่อ
* ไปยังสไลด์อื่น, ตัวอย่างเช่น จากสารบัญ

Aspose.Slides for .NET ให้คุณเพิ่มลิงก์เหล่านี้, ควบคุมลักษณะและเสียง, อัปเดตคุณสมบัติ, และลบออก ตัวอย่างด้านล่างแสดงวิธีการทำงานกับไฮเปอร์ลิงก์บนองค์ประกอบแต่ละอันและวิธีเข้าถึงไฮเปอร์ลิงก์ในระดับงานนำเสนอ, สไลด์, หรือ Text-Frame

{{% alert color="info" title="Note" %}}
คุณยังสามารถแก้ไขงานนำเสนอด้วย [เครื่องมือแก้ไข PowerPoint ออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/editor) .
{{% /alert %}} 

## **เพิ่มไฮเปอร์ลิงก์ URL**

คุณสามารถกำหนด URL ของเว็บไซต์ให้กับข้อความ, รูปร่าง, หรือเฟรมสื่อ องค์ประกอบที่คุณกำหนดไฮเปอร์ลิงก์จะเป็นตัวกำหนดพื้นที่ที่คลิกได้: ส่วนของข้อความลิงก์กับข้อความที่เลือก, ส่วนของรูปร่างหรือเฟรมลิงกกับวัตถุสไลด์

สำหรับงานนำเสนอที่มีไฮเปอร์ลิงก์แบบ relative, ดูที่ [จัดการฐานของไฮเปอร์ลิงก์](/slides/th/net/presentation-properties/#manage-the-hyperlink-base) เพื่ออ่าน, เปลี่ยน, หรือเคลียร์ฐานระดับเอกสาร

### **เพิ่มไฮเปอร์ลิงก์ URL ให้กับข้อความ**

เพื่อเชื่อมข้อความไปยังเว็บไซต์, กำหนด [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) ให้กับคุณสมบัติ [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) ของส่วนข้อความ ตามตัวอย่างด้านล่าง ส่วนของข้อความนั้นจะกลายเป็นคลิกได้เท่านั้น

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

### **เพิ่มไฮเปอร์ลิงก์ URL ให้กับรูปร่างและเฟรมสื่อ**

เพื่อทำให้รูปร่างหรือเฟรมคลิกได้, ตั้งค่าคุณสมบัติ [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/) ของมัน ไฮเปอร์ลิงก์จะเป็นของวัตถุเอง ไม่ใช่ของส่วนข้อความภายใน

วิธีเดียวกันใช้กับเฟรมรูปภาพ, เสียง, และวิดีโอ: กำหนดไฮเปอร์ลิงก์ให้กับเฟรมและตั้งค่า [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) หากต้องการ

ตัวอย่างต่อไปนี้ทำให้สี่เหลี่ยมคลิกได้:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **ใช้ไฮเปอร์ลิงก์เพื่อสร้างสารบัญ**

ไฮเปอร์ลิงก์ภายในช่วยให้ผู้อ่านกระโดดจากสารบัญไปยังสไลด์เฉพาะ ตัวอย่างต่อไปนี้ใช้ [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) เพื่อลิงก์ข้อความ “Page 2” บนสไลด์แรกไปยังสไลด์ที่สอง

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

## **รูปแบบไฮเปอร์ลิงก์**

### **สี**

คุณสมบัติ [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) ของ [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) กำหนดว่าไฮเปอร์ลิงก์จะใช้สีไฮเปอร์ลิงก์ของงานนำเสนอหรือการจัดรูปแบบของส่วนข้อความหรือไม่ เพื่อใช้สีข้อความที่กำหนดเองให้เลือก [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) แล้วตั้งค่าสีเติมของส่วนนั้น ฟีเจอร์นี้เริ่มต้นตั้งแต่ PowerPoint 2019; รุ่นเก่าจะไม่ใช้การตั้งค่านี้

ตัวอย่างต่อไปนี้เพิ่มไฮเปอร์ลิงก์ข้อความสองอันลงบนสไลด์เดียว อันแรกใช้สีเติมข้อความสีแดง, ส่วนอันที่สองใช้สีไฮเปอร์ลิงก์เริ่มต้น

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

ไฮเปอร์ลิงก์สามารถเล่นเสียงเมื่อเปิดใช้งานหรือหยุดเสียงที่กำลังเล่นอยู่ ใช้คุณสมบัติดังต่อไปนี้เพื่อกำหนดพฤติกรรมเหล่านั้น:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) ระบุไฟล์เสียงที่เชื่อมกับไฮเปอร์ลิงก์
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) ควบคุมว่าการเปิดใช้งานไฮเปอร์ลิงก์จะหยุดเสียงก่อนหน้าหรือไม่

#### **เพิ่มเสียงไฮเปอร์ลิงก์**

ตัวอย่างต่อไปนี้โหลด `sampleaudio.wav` และเชื่อมโยงกับปุ่มบนสไลด์แรก การคลิกปุ่มจะเล่นเสียงและไปยังสไลด์ถัดไป รูปร่างที่สองบนสไลด์นั้นจะหยุดเสียงก่อนหน้าเมื่อคลิก, โดยไม่ทำการนำทางใดๆ

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

#### **ดึงเสียงไฮเปอร์ลิงก์**

ตัวอย่างต่อไปนี้เปิดงานนำเสนอที่สร้างไว้ข้างต้นและอ่านเสียงไฮเปอร์ลิงก์ของรูปร่างแรกเข้าสู่หน่วยความจำผ่าน [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) และ [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/)

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

### **การตั้งค่า Tooltip และการโต้ตอบ**

คุณสามารถอัปเดตคุณสมบัติของ [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) ต่อไปนี้หลังจากกำหนดไฮเปอร์ลิงก์ให้กับข้อความหรือรูปร่าง:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) กำหนดข้อความที่ผู้ชมสามารถแสดงเป็นคำแนะนำสำหรับลิงก์
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) ระบุเฟรมเป้าหมายภายในชุดเฟรม HTML ของพาเรนต์ เมื่อมีการใช้งาน
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) ควบคุมว่าการเปิดใช้งานลิงก์จะเพิ่มปลายทางลงในรายการไฮเปอร์ลิงก์ที่เคยดูหรือไม่
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) ควบคุมว่าฮไฮเปอร์ลิงก์จะถูกไฮไลท์เมื่อคลิกหรือไม่

## **ลบไฮเปอร์ลิงก์จากงานนำเสนอ**

ใช้ [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) เพื่อรวบรวมคอนเทนเนอร์ของไฮเปอร์ลิงก์, รวมถึงลิงก์ส่วนข้อความ, ก่อนทำการเปลี่ยนแปลง ตัวอย่างต่อไปนี้ลบทั้งสองประเภทการเปิดใช้งานจากสไลด์แรก หากต้องการลบเพียงประเภทเดียวให้เรียกใช้เฉพาะ [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) หรือ [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) ; การลบการคลิกจะไม่ลบการเลื่อนเมาส์ที่สอดคล้องกัน

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

สำหรับการลบโดยไม่มีเงื่อนไข, [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) จะลบทั้งสองประเภทการเปิดใช้งานในสโคปที่เลือกพร้อมกัน ในการทำความสะอาดแบบเลือกและครอบคลุมมาสเตอร์, เลย์เอาต์, และโน๊ต, ดูที่ [รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์](#report-sanitize-and-verify-hyperlinks)

## **สร้างรายการไฮเปอร์ลิงก์ที่ครบถ้วน**

ก่อนจัดจำหน่ายงานนำเสนอ ให้ทำรายการการกระทำแบบโต้ตอบและลิงก์เว็บของมัน [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) จะคืนอ็อบเจ็กต์ [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/) ไม่ใช่รายการแบนของสตริง URL ตรวจสอบทั้ง [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) และ [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) ในแต่ละคอนเทนเนอร์ พวกมันเป็นอิสระ: คอนเทนเนอร์เดียวกันสามารถเปิดเผยทั้งสองการกระทำได้, ดังนั้นรายงานที่ครบถ้วนจึงอาจต้องมีสองแถวต่อคอนเทนเนอร์

การสแกนเฉพาะไฮเปอร์ลิงก์ระดับรูปร่างอาจพลาดลิงก์ที่แนบกับส่วนข้อความ ให้สอบถามสโคปที่เหมาะสมแทน, และเก็บคอนเทนเนอร์ที่คืนค่ามาเพื่อให้คุณสามารถอัปเดตหรือลบการกระทำของมันในภายหลังได้

### **สอบถามสโคปของการนำเสนอ, สไลด์, และ Text-Frame**

อินเทอร์เฟซ [IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) สามารถเข้าถึงได้ผ่าน [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/), และ [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/). แต่ละสโคปสนับสนุนการสอบถามเดียวกัน:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) คืนคอนเทนเนอร์ที่มีการกระทำคลิก
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) คืนคอนเทนเนอร์ที่มีการกระทำเลื่อนเมาส์
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) คืนคอนเทนเนอร์ที่มีหนึ่งหรือทั้งสองการกระทำ

ตัวอย่างต่อไปนี้สร้าง `hyperlink-audit-input.pptx` ด้วยลิงก์คลิกภายนอก, ลิงก์เลื่อนเมาส์ไฟล์, การนำทางสไลด์ภายใน, ลิงก์เลื่อนเมาส์ข้อความ, และการกระทำมาร์โคร ซึ่งไม่ทำการเรียกใช้การกระทำใดเลย การสอบถามทั้งสามทำงานที่ทุกสโคป; จำนวนที่แสดงเป็นจำนวนคอนเทนเนอร์, ไม่ใช่จำนวนการกระทำ การสอบถาม Text-Frame จะยกเว้นลิงก์ของรูปร่างที่บรรจุอยู่

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

สำหรับตัวอย่างนี้, การสอบถามการนำเสนอและสไลด์แต่ละอันรายงานคอนเทนเนอร์คลิกสามรายการ, คอนเทนเนอร์เลื่อนเมาส์สองรายการ, และคอนเทนเนอร์ที่มีหนึ่งหรือทั้งสองการกระทำสามรายการ. การสอบถาม Text-Frame รายงานคอนเทนเนอร์หนึ่งรายการในแต่ละหมวด

### **จำแนกการทำงานและปลายทาง**

ใช้ [IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) เพื่อแปลความหมายของการกระทำก่อนแปลความหมายของปลายทางค่าของ [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) ครอบคลุมมากกว่าการนำทางเว็บ:

| ค่า | ความหมายสำหรับการตรวจสอบ |
| --- | --- |
| `Hyperlink` | ไฮเปอร์ลิงก์ภายนอก; ตรวจสอบ URL และสคีมของมัน |
| `JumpSpecificSlide` | การนำทางภายในไปยังสไลด์เฉพาะ |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | การนำทางสไลด์โชว์ในตัว, แก้ไขในบริบทของสไลด์โชว์ |
| `JumpEndShow`, `StartCustomSlideShow` | จบการแสดงปัจจุบันหรือเริ่มการแสดงแบบกำหนดเอง |
| `StartMacro` | เรียกใช้มาร์โคร |
| `StartProgram` | เปิดโปรแกรม |
| `OpenFile`, `OpenPresentation` | เปิดไฟล์หรือการนำเสนออื่น; ตรวจสอบแยกจาก URL เว็บ |
| `StartStopMedia` | เริ่มหรือหยุดการเล่นสื่อ |
| `NoAction`, `Unknown` | ไม่มีการนำทาง, หรือการกระทำที่ไม่รู้จักต้องตรวจสอบ |

อ่านปลายทางภายนอกจาก [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) และปลายทางภายในเฉพาะจาก [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/). การกระทำภายในและคำสั่งในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่หมายความว่าคอนเทนเนอร์ไม่มีการกระทำ ให้เก็บ [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) เมื่อต่างจาก URL ที่ทำให้เป็นมาตรฐาน, และรวม [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) เมือมี

### **รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์**

ตัวอย่าง .NET 6+ ต่อไปนี้อ่านงานนำเสนอที่มีอยู่ (ใช้ไฟล์ที่สร้างข้างต้น), เขียน `hyperlink-audit.json`, ใช้นโยบาย, บันทึก `hyperlink-sanitized.pptx`, แล้วเปิดใหม่เพื่อตรวจสอบทั้งสองประเภทการเปิดใช้งานอีกครั้ง จะรวบรวมคอนเทนเนอร์ก่อนทำการเปลี่ยนแปลงและใช้การเทียบอัตลักษณ์เพื่อหลีกเลี่ยงการประมวลผลคอนเทนเนอร์เดียวซ้ำซ้อน การสอบถามงานนำเสนอครอบคลุมสไลด์ปกติ; สำหรับรายการระดับแพ็คเกจจะสอบถามมาสเตอร์, เลย์เอาต์, โน๊ต, และมาสเตอร์โน๊ตและแฮนด์เอาต์เมื่อตัวมี

รายงานบันทึกดัชนีสไลด์โดยเริ่มจาก 1 และ [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) เมื่อมีอยู่ [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) ให้สไลด์เจ้าของสำหรับคอนเทนเนอร์ที่สนับสนุน มาสเตอร์, เลย์เอาต์, และโน๊ตไม่มีดัชนีสไลด์ปกติและจะระบุด้วยสโคปของตนเอง คอนเทนเนอร์รูปร่างและคอนเทนเนอร์การจัดรูปแบบส่วนข้อความจะถูกตั้งชื่อแยกกัน; ประเภทคอนเทนเนอร์อื่นจะคงชื่อประเภทรันไทม์ของมัน แต่ละคอนเทนเนอร์จะได้รับ ID รายงานภายในเพื่อให้สามารถเชื่อมโยงการกระทำสองอย่างได้

นโยบายแอปพลิเคชันที่เข้มงวดนี้อนุญาตเฉพาะ URL HTTPS แบบ absolute และเป้าหมายสไลด์ภายในที่ถูกต้อง มันจะปฏิเสธมาร์โคร, โปรแกรม, การกระทำไฟล์, การกระทำสไลด์โชว์อื่น, การกระทำที่ไม่รู้จัก, และสคีม URL อื่น ๆ การปฏิเสธเหล่านี้เป็นการตัดสินใจตามนโยบาย, ไม่ใช่ข้อสรุปด้านความปลอดภัยของ Aspose.Slides HTTPS เพียงอย่างเดียวไม่ได้สร้างความเชื่อถือ: เพิ่มรายการอนุญาตโฮสต์และการตรวจสอบอื่น ๆ สำหรับแอปของคุณ ทั้ง URL ภายนอกต้นฉบับและที่ทำให้เป็นมาตรฐานจะถูกตรวจสอบ ตัวอย่างตรวจสอบเมทาดาต้าโดยไม่ตามลิงก์หรือเรียกการกระทำ

สำหรับการแก้ไข, [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) ของคอนเทนเนอร์รองรับ [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/), และ [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). ที่นี่, ลิงก์คลิกภายนอกที่ห้ามจะถูกแทนที่ด้วยหน้า Landing Page HTTPS คงที่; คลิกห้ามอื่นและการกระทำเมื่อนำเมาส์ที่ห้ามจะถูกลบแยกกัน ตั้งค่า `replaceExternalClicks` เป็น `false` เพื่อเพิ่มการลบการละเมิดทั้งหมด เลือกหน้าทดแทนที่เป็นของแอปก่อนการเผยแพร่

แฟล็กการส่งออกของรายงานใช้แนวนโยบายการตรวจสอบ PDF ที่ระมัดระวัง: ทำแฟล็กการกระทำเมื่อนำเมาส์และสิ่งอื่นใดที่ไม่ใช่ลิงก์ภายนอกหรือการกระโดดสไลด์เฉพาะเป็นการอาจไม่สนับสนุน นี่เป็นคำแนะนำการตรวจสอบ, ไม่ใช่การทดสอบความสามารถหรือการรับประกันว่าลิงก์ที่ไม่ได้แฟล็กจะยังคงอยู่ในการส่งออก การส่งออก PDF [PDF](/slides/th/net/convert-powerpoint-to-pdf/) และ HTML [HTML](/slides/th/net/convert-powerpoint-to-html/) ที่สนับสนุนอาจรักษาไฮเปอร์ลิงก์ไว้, ขึ้นกับการกระทำ, ตัวเลือกการส่งออก, และผู้ดูภาพ Raster [images](/slides/th/net/convert-powerpoint-to-png/) และ [video](/slides/th/net/convert-powerpoint-to-video/) ไม่สามารถรักษาไฮเปอร์ลิงก์แบบโต้ตอบ; ควรทำแฟล็กทุกการกระทำเมื่อตรวจสอบสำหรับเอาต์พุตเหล่านั้น

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

ด้วยอินพุตที่สร้างข้างต้น, รายงานมีห้าแถวการกระทำ ลิงก์เมื่อนำเมาส์ไฟล์และคลิกมาร์โครถูกลบ, ส่วนลิงก์ HTTPS และการนำทางสไลด์ภายในยังคงอยู่ การตรวจสอบพิมพ์การกระทำห้ามเป็นศูนย์ อินพุตที่มี URL คลิกภายนอกห้ามก็จะทดสอบเส้นทางการแทนที่ คอนเทนเนอร์ที่มีคลิกที่อนุญาตและเมื่อนำเมาส์ที่ห้ามจะเก็บคลิกไว้

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) ที่ลบทั้งสองประเภทการเปิดใช้งานในสโคปที่เลือกโดยไม่คำนึงถึงนโยบาย การตรวจสอบที่นี่ตรวจสอบเฉพาะการกระทำของไฮเปอร์ลิงก์; ไม่ได้ลบโครงการ VBA ที่ฝังอยู่, วัตถุ OLE, หรือเนื้อหาแอ็คทีฟอื่น ๆ, และไม่ได้ตรวจสอบไฟล์ PDF หรือ HTML ที่ส่งออก

## **คำถามที่พบบ่อย**

**ฉันจะลิงก์ไปยังส่วนหรือสไลด์แรกของส่วนได้อย่างไร?**

ส่วนใน PowerPoint จัดกลุ่มสไลด์, แต่ไฮเปอร์ลิงก์ภายในจะชี้ไปยังสไลด์แต่ละรายการ เพื่อสร้างการนำทางไปยังส่วน, ให้ลิงก์ไปยังสไลด์แรกของส่วนนั้น

**ฉันสามารถแนบไฮเปอร์ลิงก์กับองค์ประกอบของสไลด์แม่เพื่อให้ทำงานบนทุกสไลด์ได้หรือไม่?**

ได้. องค์ประกอบของสไลด์แม่และเลย์เอาต์รองรับไฮเปอร์ลิงก์ ลิงก์บนองค์ประกอบเหล่านี้จะพร้อมใช้งานระหว่างการแสดงสไลด์บนสไลด์ที่ใช้มาสเตอร์หรือเลย์เอาต์ที่สอดคล้องกัน

**ไฮเปอร์ลิงก์จะถูกเก็บไว้เมื่อส่งออกเป็น PDF, HTML, รูปภาพ หรือวิดีโอหรือไม่?**

การส่งออก PDF และ HTML ที่สนับสนุนอาจรักษาไฮเปอร์ลิงก์ไว้; รูปภาพแรสเตอร์และวิดีโอไม่สามารถทำเช่นนั้นได้ ดูคำแนะนำการส่งออกใน [รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์](#report-sanitize-and-verify-hyperlinks) .