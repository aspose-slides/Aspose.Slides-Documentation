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
- จัดรูปแบบ Hyperlink
- ลบ Hyperlink
- อัปเดต Hyperlink
- Hyperlink ข้อความ
- Hyperlink สไลด์
- Hyperlink รูปทรง
- Hyperlink รูปภาพ
- Hyperlink วิดีโอ
- Hyperlink ที่แก้ไขได้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการ Hyperlink ในงานนำเสนอ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ .NET—เพิ่มการโต้ตอบและกระบวนการทำงานในไม่กี่นาที."
---
## **บทนำ**

Hyperlink คือการอ้างอิงถึงวัตถุหรือข้อมูลหรือสถานที่ในบางอย่าง ซึ่งเป็น Hyperlink ที่พบทั่วไปในงานนำเสนอ PowerPoint:

* ลิงก์ไปยังเว็บไซต์ในข้อความ รูปร่าง หรือสื่อ
* ลิงก์ไปยังสไลด์

Aspose.Slides สำหรับ .NET ให้คุณทำงานหลายอย่างที่เกี่ยวกับ Hyperlink ในงานนำเสนอได้

{{% alert color="info" %}} 
คุณอาจต้องการดู Aspose แบบง่าย, [โปรแกรมแก้ไข PowerPoint ออนไลน์ฟรี.](https://products.aspose.app/slides/th/editor)
{{% /alert %}} 

## **เพิ่ม URL Hyperlink**

### **เพิ่ม URL Hyperlink ไปยังข้อความ**

โค้ด C# นี้แสดงวิธีเพิ่ม Hyperlink เว็บไซต์ไปยังข้อความ:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.AddTextFrame("Aspose: File Format APIs");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

	presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

### **เพิ่ม URL Hyperlink ไปยังรูปทรงหรือกรอบ**

ตัวอย่างโค้ดใน C# นี้แสดงวิธีเพิ่ม Hyperlink เว็บไซต์ไปยังรูปทรง:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **เพิ่ม URL Hyperlink ไปยังสื่อ**

Aspose.Slides อนุญาตให้คุณเพิ่ม Hyperlink ไปยังไฟล์รูปภาพ, เสียง, และวิดีโอ.

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่ม Hyperlink ไปยัง **รูปภาพ**:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    // เพิ่มภาพไปยังงานนำเสนอ
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // สร้าง picture frame บนสไลด์ 1 จากภาพที่เพิ่มไว้ก่อนหน้า
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่ม Hyperlink ไปยัง **ไฟล์เสียง**:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่ม Hyperlink ไปยัง **วิดีโอ**:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

{{%  alert  title="Tip"  color="info"  %}} 
คุณอาจต้องการดู *[จัดการ OLE](https://docs.aspose.com/slides/th/net/manage-ole/)*.
{{% /alert %}}

## **ใช้ Hyperlink เพื่อสร้างสารบัญ**

เนื่องจาก Hyperlink ให้คุณเพิ่มการอ้างอิงถึงวัตถุหรือสถานที่ คุณสามารถใช้มันเพื่อสร้างสารบัญได้.

ตัวอย่างโค้ดนี้แสดงวิธีสร้างสารบัญพร้อม Hyperlink:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

    var contentTable = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.FillFormat.FillType = FillType.NoFill;
    contentTable.LineFormat.FillFormat.FillType = FillType.NoFill;
    contentTable.TextFrame.Paragraphs.Clear();

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    paragraph.Text = "Title of slide 2 .......... ";

    var linkPortion = new Portion();
    linkPortion.Text = "Page 2";
    linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

    paragraph.Portions.Add(linkPortion);
    contentTable.TextFrame.Paragraphs.Add(paragraph);

    presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
}
```

## **รูปแบบ Hyperlink**

### **สี**

ด้วยคุณสมบัติ [ColorSource](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/properties/colorsource) ในอินเตอร์เฟส [IHyperlink](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink) คุณสามารถตั้งค่าสีสำหรับ Hyperlink และยังสามารถรับข้อมูลสีจาก Hyperlink ได้ ฟีเจอร์นี้ถูกแนะนำครั้งแรกใน PowerPoint 2019 ดังนั้นการเปลี่ยนแปลงที่เกี่ยวกับคุณสมบัตินี้จะไม่ใช้กับเวอร์ชัน PowerPoint เก่า

ตัวอย่างโค้ดนี้แสดงการดำเนินการที่เพิ่ม Hyperlink ที่มีสีต่างกันลงในสไลด์เดียว:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.AddTextFrame("This is a sample of colored hyperlink.");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

    IAutoShape shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.AddTextFrame("This is a sample of usual hyperlink.");
    shape2.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

    presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
}
```
### **เสียง**

Aspose.Slides ให้คุณสมบัติเหล่านี้เพื่อให้คุณเน้น Hyperlink ด้วยเสียง:
- [IHyperlink.Sound](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **เพิ่มเสียง Hyperlink**

โค้ด C# นี้แสดงวิธีตั้งค่า Hyperlink ที่เล่นเสียงและหยุดเสียงด้วย Hyperlink อีกอัน:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	// เพิ่มออดิโอใหม่ไปยังคอลเลกชันออดิโอของงานนำเสนอ
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// เพิ่มรูปทรงใหม่พร้อม Hyperlink ไปยังสไลด์ถัดไป
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// ตรวจสอบ Hyperlink สำหรับ "ไม่มีเสียง"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// ตั้งค่า Hyperlink ที่เล่นเสียง
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// เพิ่มสไลด์เปล่า 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// เพิ่มรูปทรงใหม่พร้อม Hyperlink NoAction
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// ตั้งค่าสถานะ Hyperlink "หยุดเสียงก่อนหน้า"
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **สกัดเสียง Hyperlink**

โค้ด C# นี้แสดงวิธีสกัดเสียงที่ใช้ใน Hyperlink:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// รับ Hyperlink ของรูปทรงแรก
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// สกัดเสียง Hyperlink ออกเป็นอาเรย์ไบต์
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **ลบ Hyperlink จากงานนำเสนอ**

### **ลบ Hyperlink จากข้อความ**

โค้ด C# นี้แสดงวิธีลบ Hyperlink จากข้อความในสไลด์ของงานนำเสนอ:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        IAutoShape autoShape = shape as IAutoShape;
        if (autoShape != null)
        {
            foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
            {
                foreach (IPortion portion in paragraph.Portions)
                {
                    portion.PortionFormat.HyperlinkManager.RemoveHyperlinkClick();
                }
            }
        }
    }
    
    pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
```

### **ลบ Hyperlink จากรูปทรงหรือกรอบ**

โค้ด C# นี้แสดงวิธีลบ Hyperlink จากรูปทรงในสไลด์ของงานนำเสนอ: 

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx")) 
{ 
   ISlide slide = pres.Slides[0]; 
   foreach (IShape shape in slide.Shapes) 
     { 
       shape.HyperlinkManager.RemoveHyperlinkClick(); 
     } 
   pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx); 
}
```

## **Hyperlink ที่แก้ไขได้**

คลาส [Hyperlink](https://reference.aspose.com/slides/th/net/aspose.slides/hyperlink) เป็นแบบ mutable พร้อมกับคลาสนี้คุณสามารถเปลี่ยนค่าให้กับคุณสมบัติเหล่านี้ได้:
- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/properties/highlightclick)

ส่วนของโค้ดนี้แสดงวิธีเพิ่ม Hyperlink ไปยังสไลด์และแก้ไข tooltip ของมันภายหลัง:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{   
   IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);    
    
   shape1.AddTextFrame("Aspose: File Format APIs");
    
   shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;
    
 presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **คุณสมบัติที่รองรับใน IHyperlinkQueries**

คุณสามารถเข้าถึง IHyperlinkQueries จากงานนำเสนอ, สไลด์ หรือข้อความที่กำหนด Hyperlink ไว้ได้.

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/properties/hyperlinkqueries)

คลาส IHyperlinkQueries รองรับเมธอดและคุณสมบัติดังต่อไปนี้: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **คำถามที่พบบ่อย**

### ฉันจะสร้างการนำทางภายในไม่ใช่แค่ไปยังสไลด์เท่านั้น แต่ไปยัง “ส่วน” หรือสไลด์แรกของส่วนได้อย่างไร?
ส่วนใน PowerPoint เป็นการจัดกลุ่มของสไลด์; การนำทางโดยเทคนิคจะชี้ไปยังสไลด์เฉพาะ เพื่อ “ไปยังส่วน” คุณมักจะเชื่อมโยงไปยังสไลด์แรกของส่วนนั้น.

### ฉันสามารถแนบ Hyperlink ไปยังองค์ประกอบมาสเตอร์สไลด์เพื่อให้ทำงานบนสไลด์ทั้งหมดได้หรือไม่?
ได้. องค์ประกอบมาสเตอร์สไลด์และเลเอาต์รองรับ Hyperlink ลิงก์เหล่านี้จะแสดงบนสไลด์ย่อยและสามารถคลิกได้ในระหว่างการนำเสนอ.

### Hyperlink จะยังคงอยู่เมื่อส่งออกเป็น PDF, HTML, รูปภาพ หรือวิดีโอหรือไม่?
ใน [PDF](/slides/th/net/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/net/convert-powerpoint-to-html/) ใช่—ลิงก์โดยทั่วไปจะถูกรักษาไว้ เมื่อส่งออกเป็น [images](/slides/th/net/convert-powerpoint-to-png/) และ [video](/slides/th/net/convert-powerpoint-to-video/) ความสามารถในการคลิกจะไม่ถูกรักษาเนื่องจากลักษณะของรูปแบบเหล่านั้น (เฟรมภาพ/วิดีโอแบบราสเตอร์ไม่รองรับ Hyperlink).