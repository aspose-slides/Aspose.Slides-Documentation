---
title: จัดการไฮเปอร์ลิงก์การนำเสนอใน .NET
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
- ปรับปรุงไฮเปอร์ลิงก์
- ไฮเปอร์ลิงก์ข้อความ
- ไฮเปอร์ลิงก์สไลด์
- ไฮเปอร์ลิงก์รูปทรง
- ไฮเปอร์ลิงก์รูปภาพ
- ไฮเปอร์ลิงก์วีดีโอ
- ไฮเปอร์ลิงก์ที่แก้ไขได้
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เพิ่ม, จัดรูปแบบ, ปรับปรุง, และลบไฮเปอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET โดยใช้ตัวอย่าง C#."
---
## **บทนำ**

ไฮเปอร์ลิงก์เชื่อมต่อเนื้อหาการนำเสนอไปยังเว็บไซต์หรือสถานที่ภายในการนำเสนอ ใน PowerPoint ไฮเปอร์ลิงก์มักใช้เพื่อวัตถุประสงค์สองอย่าง:

* เปิดเว็บไซต์จากข้อความ รูปทรง หรือกรอบสื่อ
* ไปยังสไลด์อื่น เช่น จากสารบัญ

Aspose.Slides for .NET ให้คุณเพิ่มลิงก์เหล่านี้ ควบคุมลักษณะและเสียง ปรับปรุงคุณสมบัติ และลบออก ตัวอย่างด้านล่างแสดงวิธีการทำงานกับไฮเปอร์ลิงก์บนองค์ประกอบแต่ละตัวและวิธีเข้าถึงไฮเปอร์ลิงก์ในระดับการนำเสนอ สไลด์ หรือกรอบข้อความ

{{% alert color="info" title="Note" %}}
คุณยังสามารถแก้ไขการนำเสนอด้วย [เครื่องมือแก้ไข PowerPoint ออนไลน์ของ Aspose ฟรี](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **เพิ่มไฮเปอร์ลิงก์ URL**

คุณสามารถกำหนด URL ของเว็บไซต์ให้กับข้อความ รูปทรง หรือกรอบสื่อได้ องค์ประกอบที่คุณกำหนดไฮเปอร์ลิงก์จะเป็นตัวกำหนดพื้นที่ที่คลิกได้: ส่วนของข้อความจะลิงก์ข้อความที่เลือก ส่วนรูปทรงหรือกรอบจะลิงก์วัตถุสไลด์

[จัดการฐานไฮเปอร์ลิงก์](/slides/th/net/presentation-properties/#manage-the-hyperlink-base) เพื่ออ่าน เปลี่ยน หรือ ล้างฐานระดับเอกสาร

### **เพิ่มไฮเปอร์ลิงก์ URL ไปยังข้อความ**

เพื่อทำให้ข้อความลิงก์ไปยังเว็บไซต์ ให้กำหนด [ไฮเปอร์ลิงก์](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) ให้กับคุณสมบัติ [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) ของส่วนข้อความ ตามที่แสดงด้านล่าง ส่วนของข้อความนั้นเท่านั้นที่จะคลิกได้

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

### **เพิ่มไฮเปอร์ลิงก์ URL ไปยังรูปทรงและกรอบสื่อ**

กำหนด URL ให้กับคุณสมบัติ [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/) ของสี่เหลี่ยมเพื่อทำให้พื้นที่ทั้งหมดของมันคลิกได้ [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) จะให้คำบอกใบ้เกี่ยวกับปลายทางเมื่อผู้ใช้เลื่อนเมาส์เหนือสี่เหลี่ยม คุณสมบัติเช่นเดียวกันนี้ใช้กับกรอบรูป ภาพ เสียง และวิดีโอด้วย

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

ไฮเปอร์ลิงก์ภายในทำให้ผู้ใช้กระโดดจากสารบัญไปยังสไลด์เฉพาะ ตัวอย่างต่อไปนี้ใช้ [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) เพื่อเชื่อมข้อความ “Page 2” บนสไลด์แรกไปยังสไลด์ที่สอง

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

## **จัดรูปแบบไฮเปอร์ลิงก์**

คุณสามารถเปลี่ยนสีของข้อความที่เชื่อมโยง เล่นหรือหยุดเสียงเมื่อผู้ใช้เปิดลิงก์ และตั้งค่า tooltip ที่แสดงเมื่อเลื่อนเมาส์

### **สี**

คุณสมบัติ [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) ของ [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) กำหนดว่าไฮเปอร์ลิงก์จะใช้สีไฮเปอร์ลิงก์ของการนำเสนอหรือการฟอร์แมตของส่วนข้อความหรือไม่ หากต้องการกำหนดสีข้อความเอง ให้เลือก [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) แล้วตั้งค่าสีเติมของส่วนนั้น ฟีเจอร์นี้เปิดตัวใน PowerPoint 2019; เวอร์ชันเก่าจะไม่ใช้การตั้งค่านี้

ในตัวอย่างนี้ การตั้งค่า [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) บนลิงก์แรกทำให้ข้อความของมันเป็นสีแดง ลิงก์ที่สองจะใช้สีไฮเปอร์ลิงก์ของการนำเสนอ

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

ไฮเปอร์ลิงก์สามารถเล่นเสียงเมื่อเปิดใช้งานหรือหยุดเสียงที่กำลังเล่นอยู่ ใช้คุณสมบัติด้านล่างเพื่อกำหนดพฤติกรรมเหล่านี้:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) ระบุเสียงที่เชื่อมกับไฮเปอร์ลิงก์
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) ควบคุมว่าการเปิดไฮเปอร์ลิงก์จะหยุดเสียงก่อนหน้าหรือไม่

#### **เพิ่มเสียงไฮเปอร์ลิงก์**

ปุ่มบนสไลด์แรกใช้ [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) เพื่อเล่นไฟล์ WAV เมื่อผู้ใช้คลิกเพื่อเลื่อนหน้า ส่วนบนสไลด์ที่สอง ปุ่มแยกใช้ [StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) เพื่อหยุดการเล่นและให้ผู้ใช้อยู่บนสไลด์นั้น

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

#### **ดึงเสียงจากไฮเปอร์ลิงก์**

ตัวอย่างต่อไปนี้เปิดการนำเสนอที่สร้างข้างต้นและอ่านเสียงไฮเปอร์ลิงก์ของรูปทรงแรกเข้าสู่หน่วยความจำผ่าน [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) และ [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/)

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

คุณสามารถอัปเดตคุณสมบัติดังต่อไปนี้ของ [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) หลังจากกำหนดไฮเปอร์ลิงก์ให้กับข้อความหรือรูปทรง:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) ตั้งข้อความที่ผู้ชมจะเห็นเป็นคำบอกใบ้ของลิงก์
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) ระบุเฟรมเป้าหมายภายในชุดเฟรม HTML พ่อแม่ หากใช้ได้
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) ควบคุมว่าการเปิดลิงก์จะเพิ่มปลายทางลงในรายการไฮเปอร์ลิงก์ที่ดูแล้วหรือไม่
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) ควบคุมว่าการคลิกจะทำให้ไฮเปอร์ลิงก์ถูกไฮไลต์หรือไม่

## **ลบไฮเปอร์ลิงก์จากการนำเสนอ**

ใช้ [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) เพื่อรวบรวมคอนเทนเนอร์ของไฮเปอร์ลิงก์ รวมถึงลิงก์ของส่วนข้อความ ก่อนทำการเปลี่ยนแปลง ตัวอย่างต่อไปนี้ลบทั้งสองประเภทการเปิดใช้งานจากสไลด์แรก หากต้องการลบเพียงประเภทเดียว ให้เรียกใช้เฉพาะ [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) หรือ [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); การลบการคลิกจะไม่ลบการโฮเวอร์ที่สอดคล้องกัน

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

สำหรับการลบโดยไม่มีเงื่อนไข, [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) จะลบทั้งสองประเภทการเปิดใช้งานในขอบเขตที่เลือกในหนึ่งคำสั่ง สำหรับการทำความสะอาดแบบเลือกและการครอบคลุมมาสเตอร์, เลย์เอาต์, และโน้ต ดูที่ [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

### **ล้างไฮเปอร์ลิงก์ก่อนแทนที่ข้อความ SmartArt**

เมื่อคุณแทนที่ย่อหน้าภายในโหนด SmartArt ที่มีอยู่ การล้างส่วนข้อความของมันอาจทำให้ไฮเปอร์ลิงก์เก่ายังคงอยู่ ดึงย่อหน้าผ่าน [ISmartArtNode.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/textframe/) ก่อนล้างส่วนข้อความ ให้เรียก [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) ผ่าน [HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) บนกรอบข้อความของรูปทรงโหนดที่แสดงย่อหน้านั้น จะลบไฮเปอร์ลิงก์ทั้งหมดในกรอบนั้น รวมถึงลิงก์ในย่อหน้าอื่นๆ

ตัวอย่างสมมติว่ารูปทรงที่สามบนสไลด์แรกเป็นกราฟิก SmartArt มันแทนที่ย่อหน้าที่หนึ่งของโหนดที่สี่ ในการนำเสนอนี้ โหนดรูปแรกจะแสดงย่อหน้านั้น

หลังจากเพิ่มทั้งสองส่วน ตัวอย่างอ่านการฟอร์แมตที่มีผลของพวกมันด้วย [GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/). คุณสมบัติ [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/iportionformateffectivedata/hyperlinkclick/) ที่มีผลจะคืนค่าไฮเปอร์ลิงก์ใหม่สำหรับส่วนแรกและ `null` สำหรับส่วนที่สอง

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("SmartArtHyperlink.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt)slide.Shapes[2];
var node = smartArt.AllNodes[3];
var paragraph = node.TextFrame.Paragraphs[0];

node.Shapes[0].TextFrame.HyperlinkQueries.RemoveAllHyperlinks();
paragraph.Portions.Clear();

var link = new Portion("New reference");
link.PortionFormat.HyperlinkClick = new Hyperlink("https://example.com/new");
paragraph.Portions.Add(link);
var text = new Portion(" (updated)");
paragraph.Portions.Add(text);

Console.WriteLine(link.PortionFormat.GetEffective().HyperlinkClick.ExternalUrl); // https://example.com/new
Console.WriteLine(text.PortionFormat.GetEffective().HyperlinkClick?.ToString() ?? "null"); // null
```

## **สร้างรายการไฮเปอร์ลิงก์ที่ครบถ้วน**

ก่อนแจกจ่ายการนำเสนอ ควรทำรายการการกระทำแบบโต้ตอบและลิงก์เว็บของมัน [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) คืนค่าอ็อบเจ็กต์ [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/) ไม่ใช่รายการสตริง URL แบน ตรวจสอบทั้ง [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) และ [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) ของแต่ละคอนเทนเนอร์ พวกมันทำงานแยกกัน: คอนเทนเนอร์เดียวกันอาจมีทั้งสองการกระทำ ดังนั้นรายงานที่ครบถ้วนอาจต้องมีแถวสูงสุดสองแถวต่อคอนเทนเนอร์

การสแกนเฉพาะไฮเปอร์ลิงก์ระดับรูปทรงอาจพลาดลิงก์ที่แนบกับส่วนข้อความ ให้สอบถามขอบเขตที่เหมาะแทน และเก็บคอนเทนเนอร์ที่คืนค่าไว้เพื่อที่คุณจะได้อัปเดตหรือลบการกระทำของพวกมันในภายหลัง

### **สอบถามขอบเขตการนำเสนอ, สไลด์, และกรอบข้อความ**

อินเตอร์เฟซ [IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) มีให้ผ่าน [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/) และ [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) แต่ละขอบเขตรองรับคำสั่งเดียวกัน:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) คืนค่าคอนเทนเนอร์ที่มีการกระทำคลิก
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) คืนค่าคอนเทนเนอร์ที่มีการกระทำเมาส์โอเวอร์
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) คืนค่าคอนเทนเนอร์ที่มีอย่างใดอย่างหนึ่งหรือทั้งสองการกระทำ

ตัวอย่างนี้กำหนดการกระทำคลิกและเมาส์โอเวอร์ให้กับรูปทรงและข้อความของมัน และการกระทำมาโครให้กับปุ่มแยก มันเปรียบเทียบคอนเทนเนอร์ที่ได้จาก [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) กับจำนวนของแต่ละประเภทการเปิดใช้งาน การสอบถามกรอบข้อความจะนับเฉพาะลิงก์ในข้อความ การกระทำของรูปทรงที่หุ้มจะแสดงในคำสั่งสไลด์และการนำเสนอ

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

สำหรับตัวอย่างนี้ คำสั่งของการนำเสนอและสไลด์แต่ละคำสั่งรายงานคอนเทนเนอร์คลิก 3 รายการ, คอนเทนเนอร์เมาส์โอเวอร์ 2 รายการ, และคอนเทนเนอร์ที่มีอย่างใดอย่างหนึ่ง 3 รายการ คำสั่งกรอบข้อความรายงานคอนเทนเนอร์หนึ่งรายการในแต่ละประเภท

### **จำแนกการกระทำและปลายทาง**

ใช้ [IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) เพื่อแปลความหมายของการกระทำก่อนแปลความหมายของปลายทาง ค่าใน [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) ครอบคลุมมากกว่าการนำทางเว็บ:

| ค่า | ความหมายสำหรับการตรวจสอบ |
| --- | --- |
| `Hyperlink` | ไฮเปอร์ลิงก์ภายนอก; ตรวจสอบ URL และสกีมของมัน |
| `JumpSpecificSlide` | การนำทางภายในไปยังสไลด์เฉพาะ |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | การนำทางสไลด์โชว์ในตัว, แก้ไขตามบริบทของสไลด์โชว์ |
| `JumpEndShow`, `StartCustomSlideShow` | จบการแสดงปัจจุบันหรือเริ่มการแสดงแบบกำหนดเอง |
| `StartMacro` | เรียกใช้งานมาโคร |
| `StartProgram` | เปิดโปรแกรม |
| `OpenFile`, `OpenPresentation` | เปิดไฟล์หรือการนำเสนออื่น; ตรวจสอบแยกจาก URL เว็บ |
| `StartStopMedia` | เริ่มหรือหยุดการเล่นสื่อ |
| `NoAction`, `Unknown` | ไม่มีการนำทาง, หรือการกระทำที่ไม่รู้จักที่ต้องตรวจสอบ |

อ่านปลายทางภายนอกจาก [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) และปลายทางภายในเฉพาะจาก [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/). การกระทำภายในและคำสั่งในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่หมายความว่าคอนเทนเนอร์ไม่มีการกระทำ ให้เก็บ [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) ไว้เมื่อมันแตกต่างจาก URL ที่ทำให้เป็นมาตรฐาน และรวม [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) เมื่อมีให้ใช้

### **รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์**

ตัวอย่าง .NET 6+ นี้เปิดการนำเสนอจากตัวอย่างก่อนหน้าและเขียนบันทึก JSON หนึ่งรายการต่อการกระทำ ใช้ [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) เพื่อรวบรวมคอนเทนเนอร์บนสไลด์ทั่วไป, มาสเตอร์, เลย์เอาต์, และโน้ต รวมถึงมาสเตอร์โน้ตและแฮนด์เอาท์เมื่อมีอยู่ ใช้การเทียบอ้างอิงเพื่อให้นับคอนเทนเนอร์แต่ละรายการครั้งเดียว ประยุกต์นโยบายที่อธิบายด้านล่างและเปิดการนำเสนอที่บันทึกใหม่เพื่อเช็คการกระทำคลิกและเมาส์โอเวอร์ทั้งสอง

รายงานบันทึกดัชนีสไลด์แบบนับจากหนึ่งและ [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) หากมี [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) ให้สไลด์เจ้าของสำหรับคอนเทนเนอร์ที่สนับสนุน มาสเตอร์, เลย์เอาต์, และโน้ตไม่มีดัชนีสไลด์ทั่วไปและจะถูกระบุด้วยขอบเขตของมัน คอนเทนเนอร์รูปทรงและคอนเทนเนอร์ฟอร์แมตส่วนข้อความจะมีป้ายกำกับแยกกัน; ประเภทคอนเทนเนอร์อื่นจะคงชื่อประเภทในเวลารัน แต่ละคอนเทนเนอร์จะได้รับ ID ในรายงานเพื่อให้การกระทำสองอย่างของมันสามารถเชื่อมโยงกันได้

นโยบายแอปพลิเคชันที่จำกัดโดยเจตนานี้อนุญาตเฉพาะ URL HTTPS แบบเต็มและเป้าหมายสไลด์ภายในที่เป็นไปได้ จะปฏิเสธมาโคร, โปรแกรม, การกระทำไฟล์, การกระทำสไลด์โชว์อื่น, การกระทำที่ไม่รู้จัก, และสกีม URL อื่นๆ การปฏิเสธเหล่านี้เป็นการตัดสินใจเชิงนโยบาย ไม่ใช่คำตัดสินด้านความปลอดภัยของ Aspose.Slides HTTPS เพียงอย่างเดียวไม่สร้างความเชื่อถือ: เพิ่มรายชื่อผู้ให้บริการที่ได้รับอนุญาตและการตรวจสอบเพิ่มเติมสำหรับแอปของคุณ ทั้ง URL ภายนอกต้นฉบับและที่ทำให้เป็นมาตรฐานจะถูกตรวจสอบ ตัวอย่างทำการตรวจสอบเมตาดาต้าโดยไม่ตามลิงก์หรือรันการกระทำ

สำหรับการแก้ไข, [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) ของคอนเทนเนอร์รองรับ [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) และ [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). ที่นี่ ลิงก์คลิกภายนอกที่ผิดกฎหมายจะถูกแทนที่ด้วยหน้า Landing Page HTTPS คงที่; คลิกที่ผิดกฎหมายอื่นและการกระทำเมาส์โอเวอร์ที่ผิดกฎหมายจะถูกลบแยกกัน ตั้งค่า `replaceExternalClicks` เป็น `false` เพื่อทำการลบการละเมิดนโยบายทั้งหมด แทนที่ด้วยหน้าที่แอปเป็นเจ้าของก่อนการปรับใช้

ค่าสถานะการส่งออกของรายงานใช้แนวนโยบายการตรวจสอบ PDF อย่างระมัดระวัง: ทำเครื่องหมายการกระทำเมาส์โอเวอร์และสิ่งใดที่นอกเหนือจากลิงก์ภายนอกหรือการกระโดดสไลด์เฉพาะว่าอาจไม่รองรับ นี่เป็นเคล็ดลับการตรวจสอบ ไม่ใช่การทดสอบความสามารถหรือการรับประกันว่าลิงก์ที่ไม่ได้ทำเครื่องหมายจะคงอยู่หลังการส่งออก การส่งออก [PDF](/slides/th/net/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/net/convert-powerpoint-to-html/) ที่รองรับอาจเก็บไฮเปอร์ลิงก์ไว้ ขึ้นอยู่กับการกระทำ, ตัวเลือกการส่งออก, และตัวดูภาพ Raster [images](/slides/th/net/convert-powerpoint-to-png/) และ [video](/slides/th/net/convert-powerpoint-to-video/) ไม่สามารถเก็บไฮเปอร์ลิงก์เชิงโต้ตอบ; ทำเครื่องหมายทุกการกระทำเมื่อทำการตรวจสอบสำหรับผลลัพธ์เหล่านั้น

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

ด้วยอินพุตที่สร้างข้างต้น รายงานประกอบด้วยแถวการกระทำห้ารายการ ลิงก์เมาส์โอเวอร์ของไฟล์และการคลิกมาโครถูกลบออก ส่วนลิงก์ HTTPS และการนำทางสไลด์ภายในยังคงอยู่ การตรวจสอบพิมพ์การกระทำที่ห้ามศูนย์ อินพุตที่มี URL คลิกภายนอกที่ห้ามจะทดสอบสาขาการแทนที่ คอนเทนเนอร์ที่มีคลิกที่อนุญาตและเมาส์โอเวอร์ที่ห้ามจะคงการกระทำคลิกไว้

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) ที่ลบทั้งสองประเภทการเปิดใช้งานทั่วขอบเขตที่เลือกโดยไม่คำนึงถึงนโยบาย การตรวจสอบที่นี่ตรวจสอบเฉพาะการกระทำของไฮเปอร์ลิงก์; ไม่ลบโปรเจกต์ VBA ที่ฝังอยู่, วัตถุ OLE, หรือเนื้อหาแอคทีฟอื่นๆ และไม่ตรวจสอบไฟล์ PDF หรือ HTML ที่ส่งออก

## **คำถามที่พบบ่อย**

**ฉันจะลิงก์ไปยังส่วนหรือสไลด์แรกของมันได้อย่างไร?**

ส่วนใน PowerPoint จัดกลุ่มสไลด์, แต่ไฮเปอร์ลิงก์ภายในจะชี้ไปที่สไลด์เดียว เพื่อสร้างการนำทางไปยังส่วน ให้ลิงก์ไปยังสไลด์แรกของส่วนนั้น

**ฉันสามารถแนบไฮเปอร์ลิงก์ให้กับองค์ประกอบมาสเตอร์สไลด์เพื่อให้ทำงานบนสไลด์ทั้งหมดได้หรือไม่?**

ได้. องค์ประกอบมาสเตอร์สไลด์และเลย์เอาต์รองรับไฮเปอร์ลิงก์ ลิงก์บนองค์ประกอบเหล่านี้จะใช้งานได้ในระหว่างการแสดงสไลด์บนสไลด์ที่ใช้มาสเตอร์หรือเลย์เอาต์ที่สอดคล้องกัน

**ไฮเปอร์ลิงก์จะถูกเก็บรักษาไว้เมื่อส่งออกเป็น PDF, HTML, รูปภาพ หรือวิดีโอหรือไม่?**

การส่งออก PDF และ HTML ที่รองรับอาจเก็บไฮเปอร์ลิงก์ไว้; ภาพแรสเตอร์และวิดีโอไม่สามารถทำได้ ดูข้อควรพิจารณาการส่งออกใน [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).