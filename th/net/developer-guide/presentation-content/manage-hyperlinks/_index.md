---
title: จัดการไฮเปอร์ลิงก์ในงานนำเสนอด้วย .NET
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
- ไฮเปอร์ลิงก์ที่แก้ไขได้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการไฮเปอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ .NET—เพิ่มความโต้ตอบและกระบวนการทำงานในไม่กี่นาที."
---
## **บทนำ**

Hyperlink คือการอ้างอิงถึงวัตถุหรือข้อมูลหรือสถานที่ในบางอย่าง นี่คือไฮเปอร์ลิงก์ทั่วไปในงานนำเสนอ PowerPoint:

* ลิงก์ไปยังเว็บไซต์ในข้อความ, รูปร่าง หรือสื่อ
* ลิงก์ไปยังสไลด์

Aspose.Slides for .NET ช่วยให้คุณทำงานหลายอย่างที่เกี่ยวกับไฮเปอร์ลิงก์ในงานนำเสนอได้

{{% alert color="primary" %}} 
คุณอาจต้องการตรวจสอบ Aspose อย่างง่าย, [ตัวแก้ไข PowerPoint ออนไลน์ฟรี.](https://products.aspose.app/slides/th/editor)
{{% /alert %}} 

## **เพิ่มไฮเปอร์ลิงก์ URL**

### **เพิ่มไฮเปอร์ลิงก์ URL ไปยังข้อความ**

โค้ด C# นี้แสดงวิธีเพิ่มไฮเปอร์ลิงก์เว็บไซต์ไปยังข้อความ:

```c#
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

### **เพิ่มไฮเปอร์ลิงก์ URL ไปยังรูปร่างหรือเฟรม**

ตัวอย่างโค้ด C# นี้แสดงวิธีเพิ่มไฮเปอร์ลิงก์เว็บไซต์ไปยังรูปร่าง:

```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **เพิ่มไฮเปอร์ลิงก์ URL ไปยังสื่อ**

Aspose.Slides ให้คุณเพิ่มไฮเปอร์ลิงก์ไปยังรูปภาพ, ไฟล์เสียง, และวิดีโอได้

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มไฮเปอร์ลิงก์ไปยัง **รูปภาพ**:

```c#
using (Presentation pres = new Presentation())
{
    // เพิ่มรูปภาพลงในงานนำเสนอ
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // สร้างเฟรมรูปภาพบนสไลด์ 1 จากรูปภาพที่เพิ่มก่อนหน้า
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มไฮเปอร์ลิงก์ไปยัง **ไฟล์เสียง**:

```c#
using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มไฮเปอร์ลิงก์ไปยัง **วิดีโอ**:

``` csharp
using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

{{%  alert  title="Tip"  color="primary"  %}} 
คุณอาจต้องการดู *[การจัดการ OLE](https://docs.aspose.com/slides/th/net/manage-ole/)*.
{{% /alert %}}

## **ใช้ไฮเปอร์ลิงก์สร้างสารบัญ**

เนื่องจากไฮเปอร์ลิงก์ทำให้คุณเพิ่มการอ้างอิงถึงวัตถุหรือสถานที่ได้ คุณจึงสามารถใช้มันสร้างสารบัญได้

ตัวอย่างโค้ดนี้แสดงวิธีสร้างสารบัญโดยใช้ไฮเปอร์ลิงก์:

```c#
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

## **จัดรูปแบบไฮเปอร์ลิงก์**

### **สี**

ด้วย property [ColorSource](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/properties/colorsource) ใน interface [IHyperlink](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink) คุณสามารถตั้งค่าสีสำหรับไฮเปอร์ลิงก์และยังสามารถดึงข้อมูลสีจากไฮเปอร์ลิงก์ได้ ฟีเจอร์นี้ถูกแนะนำครั้งแรกใน PowerPoint 2019 ดังนั้นการเปลี่ยนแปลงที่เกี่ยวข้องกับ property นี้จะไม่ทำงานกับเวอร์ชัน PowerPoint ที่เก่ากว่า

ตัวอย่างโค้ดนี้แสดงการดำเนินการที่เพิ่มไฮเปอร์ลิงก์หลายสีลงในสไลด์เดียว:

```c#
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

Aspose.Slides มี property เหล่านี้เพื่อให้คุณเน้นไฮเปอร์ลิงก์ด้วยเสียง:

- [IHyperlink.Sound](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **เพิ่มเสียงไฮเปอร์ลิงก์**

โค้ด C# นี้แสดงวิธีตั้งค่าไฮเปอร์ลิงก์ให้เล่นเสียงและหยุดเสียงด้วยไฮเปอร์ลิงก์อื่น:

```c#
using (Presentation pres = new Presentation())
{
	// เพิ่มเสียงใหม่ลงในคอลเลกชันเสียงของงานนำเสนอ
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// เพิ่มรูปร่างใหม่พร้อมไฮเปอร์ลิงก์ไปยังสไลด์ต่อไป
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// ตรวจสอบไฮเปอร์ลิงก์สำหรับ "ไม่มีเสียง"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// ตั้งค่าไฮเปอร์ลิงก์ที่เล่นเสียง
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// เพิ่มสไลด์เปล่า 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// เพิ่มรูปร่างใหม่พร้อมไฮเปอร์ลิงก์ NoAction
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// ตั้งค่าสถานะไฮเปอร์ลิงก์ "หยุดเสียงก่อนหน้า"
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **ดึงเสียงจากไฮเปอร์ลิงก์**

โค้ด C# นี้แสดงวิธีดึงเสียงที่ใช้ในไฮเปอร์ลิงก์:

```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// ดึงไฮเปอร์ลิงก์ของรูปร่างแรก
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// ดึงเอาเสียงของไฮเปอร์ลิงก์เป็นอาร์เรย์ไบต์
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **ลบไฮเปอร์ลิงก์ออกจากงานนำเสนอ**

### **ลบไฮเปอร์ลิงก์จากข้อความ**

โค้ด C# นี้แสดงวิธีลบไฮเปอร์ลิงก์จากข้อความในสไลด์งานนำเสนอ:

```c#
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

### **ลบไฮเปอร์ลิงก์จากรูปร่างหรือเฟรม**

โค้ด C# นี้แสดงวิธีลบไฮเปอร์ลิงก์จากรูปร่างในสไลด์งานนำเสนอ: 

``` csharp
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

## **ไฮเปอร์ลิงก์ที่แก้ไขได้**

คลาส [Hyperlink](https://reference.aspose.com/slides/th/net/aspose.slides/hyperlink) สามารถแก้ไขได้ ด้วยคลาสนี้คุณสามารถเปลี่ยนค่าของ property เหล่านี้ได้:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlink/properties/highlightclick)

ส่วนโค้ดนี้แสดงวิธีเพิ่มไฮเปอร์ลิงก์ไปยังสไลด์และแก้ไข tooltip ของมันภายหลัง:

```c#
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

## **คุณสมบัติที่สนับสนุนใน IHyperlinkQueries**

คุณสามารถเข้าถึง IHyperlinkQueries จากงานนำเสนอ, สไลด์ หรือข้อความที่กำหนดไฮเปอร์ลิงก์ไว้ได้.

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/properties/hyperlinkqueries)

คลาส IHyperlinkQueries รองรับเมธอดและ property เหล่านี้: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/th/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **คำถามที่พบบ่อย**

**ฉันจะสร้างการนำทางภายในไม่ใช่แค่ไปยังสไลด์ แต่ไปยัง "ส่วน" หรือสไลด์แรกของส่วนได้อย่างไร?**

Sections ใน PowerPoint เป็นการจัดกลุ่มสไลด์; การนำทางโดยเทคนิคจะชี้ไปยังสไลด์เฉพาะ เพื่อ "ไปยังส่วน" คุณมักจะลิงก์ไปยังสไลด์แรกของส่วนนั้น

**ฉันสามารถแนบไฮเปอร์ลิงก์กับองค์ประกอบของมาสเตอร์สไลด์ได้หรือไม่เพื่อให้ทำงานบนทุกสไลด์?**

ใช่. องค์ประกอบของมาสเตอร์สไลด์และเลย์เอาต์รองรับไฮเปอร์ลิงก์ ลิงก์เหล่านี้จะแสดงบนสไลด์ลูกและสามารถคลิกได้ระหว่างการนำเสนอ

**ไฮเปอร์ลิงก์จะถูกเก็บรักษาไว้เมื่อส่งออกเป็น PDF, HTML, รูปภาพ หรือวิดีโอหรือไม่?**

ใน [PDF](/slides/th/net/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/net/convert-powerpoint-to-html/) ใช่—ลิงก์มักจะถูกเก็บไว้ เมื่อส่งออกเป็น [images](/slides/th/net/convert-powerpoint-to-png/) และ [video](/slides/th/net/convert-powerpoint-to-video/) ความสามารถในการคลิกจะไม่ถ่ายโอนเนื่องจากลักษณะของรูปแบบเหล่านั้น (เฟรมเรสเตอร์/วิดีโอไม่รองรับไฮเปอร์ลิงก์).