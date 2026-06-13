---
title: مدیریت لینک‌های ارائه در .NET
linktitle: مدیریت لینک
type: docs
weight: 20
url: /fa/net/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن لینک
- ایجاد لینک
- قالب‌بندی لینک
- حذف لینک
- به‌روزرسانی لینک
- لینک متن
- لینک اسلاید
- لینک شکل
- لینک تصویر
- لینک ویدئو
- لینک قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌راحتی لینک‌ها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای .NET مدیریت کنید—در مدت چند دقیقه تعامل و جریان کار را ارتقا دهید."
---
## **مقدمه**

هایپرلینک یک ارجاع به یک شیء یا داده یا مکانی در چیزی است. این‌ها نمونه‌های رایج هایپرلینک در ارائه‌های PowerPoint هستند:

* لینک‌ها به وب‌سایت‌ها داخل متن‌ها، شکل‌ها یا رسانه‌ها
* لینک‌ها به اسلایدها

Aspose.Slides برای .NET به شما امکان انجام کارهای متعددی مرتبط با هایپرلینک‌ها در ارائه‌ها را می‌دهد. 

{{% alert color="primary" %}} 

ممکن است بخواهید ویرایشگر ساده و رایگان آنلاین PowerPoint Aspose را بررسی کنید، [ویرایشگر آنلاین رایگان PowerPoint.](https://products.aspose.app/slides/fa/editor)

{{% /alert %}} 

## **افزودن هایپرلینک‌های URL**

### **افزودن هایپرلینک‌های URL به متن**

این کد C# نشان می‌دهد چگونه یک هایپرلینک وب‌سایت را به یک متن اضافه کنید:

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

### **افزودن هایپرلینک‌های URL به اشکال یا فریم‌ها**

این نمونه کد در C# نشان می‌دهد چگونه یک هایپرلینک وب‌سایت را به یک شکل اضافه کنید:

```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **افزودن هایپرلینک‌های URL به رسانه‌ها**

Aspose.Slides به شما امکان افزودن هایپرلینک به تصاویر، فایل‌های صوتی و ویدئویی را می‌دهد. 

این نمونه کد نشان می‌دهد چگونه به یک **تصویر** هایپرلینک اضافه کنید:

```c#
using (Presentation pres = new Presentation())
{
    // تصویر را به ارائه اضافه می‌کند
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // فریم تصویر را در اسلاید 1 بر اساس تصویر اضافه‌شده قبلی ایجاد می‌کند
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

 این نمونه کد نشان می‌دهد چگونه به یک **فایل صوتی** هایپرلینک اضافه کنید:

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

 این نمونه کد نشان می‌دهد چگونه به یک **ویدئو** هایپرلینک اضافه کنید:

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

ممکن است بخواهید *[مدیریت OLE](https://docs.aspose.com/slides/fa/net/manage-ole/)* را ببینید.

{{% /alert %}}


## **استفاده از هایپرلینک‌ها برای ایجاد فهرست مطالب**

از آنجا که هایپرلینک‌ها به شما امکان افزودن ارجاع به اشیاء یا مکان‌ها را می‌دهند، می‌توانید از آن‌ها برای ایجاد فهرست مطالب استفاده کنید. 

این نمونه کد نشان می‌دهد چگونه فهرست مطالبی با هایپرلینک‌ها ایجاد کنید:

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

## **قالب‌بندی هایپرلینک‌ها**

### **رنگ**

با ویژگی [ColorSource](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/properties/colorsource) در رابط [IHyperlink](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink) می‌توانید رنگ برای هایپرلینک‌ها را تنظیم کنید و همچنین اطلاعات رنگ را از هایپرلینک‌ها دریافت کنید. این ویژگی اولین بار در PowerPoint 2019 معرفی شد، بنابراین تغییرات مربوط به این ویژگی در نسخه‌های قدیمی‌تر PowerPoint اعمال نمی‌شوند.

این نمونه کد عملیاتی را نشان می‌دهد که در آن هایپرلینک‌های با رنگ‌های مختلف به همان اسلاید اضافه شده‌اند:

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
### **صدا**

Aspose.Slides این ویژگی‌ها را فراهم می‌کند تا بتوانید با افزودن صدا به یک هایپرلینک تأکید کنید:
- [IHyperlink.Sound](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **افزودن صدای هایپرلینک**

این کد C# نشان می‌دهد چگونه یک هایپرلینک را تنظیم کنید که صدا پخش کند و با هایپرلینک دیگری آن را متوقف کنید:

```c#
using (Presentation pres = new Presentation())
{
	// صوت جدید را به مجموعه صداهای ارائه اضافه می‌کند
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// شکل جدیدی با هایپرلینک به اسلاید بعدی اضافه می‌کند
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// هایپرلینک را برای «بدون صدا» بررسی می‌کند
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// هایپرلینکی که صدا را اجرا می‌کند تنظیم می‌کند
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// اسلاید خالی را اضافه می‌کند
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// شکل جدیدی با هایپرلینک NoAction اضافه می‌کند
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// پرچم توقف صدای قبلی هایپرلینک را تنظیم می‌کند
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **استخراج صدای هایپرلینک**

این کد C# نشان می‌دهد چگونه صدای استفاده‌شده در یک هایپرلینک را استخراج کنید:

```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// دریافت هایپرلینک اولین شکل
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// استخراج صدای هایپرلینک به صورت آرایه بایت
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **حذف هایپرلینک‌ها از ارائه‌ها**

### **حذف هایپرلینک‌ها از متن**

این کد C# نشان می‌دهد چگونه هایپرلینک را از یک متن در اسلاید ارائه حذف کنید:

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

### **حذف هایپرلینک‌ها از اشکال یا فریم‌ها**

این کد C# نشان می‌دهد چگونه هایپرلینک را از یک شکل در اسلاید ارائه حذف کنید: 

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

## **هایپرلینک قابل تغییر**

کلاس [Hyperlink](https://reference.aspose.com/slides/fa/net/aspose.slides/hyperlink) قابلیت تغییر دارد. با استفاده از این کلاس می‌توانید مقادیر ویژگی‌های زیر را تغییر دهید:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/properties/highlightclick)

این قطعه کد نشان می‌دهد چگونه به یک اسلاید هایپرلینک اضافه کنید و پس از آن متن راهنمای آن را ویرایش کنید:

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

## **ویژگی‌های پشتیبانی‌شده در IHyperlinkQueries**

می‌توانید IHyperlinkQueries را از یک ارائه، اسلاید یا متنی که هایپرلینک برای آن تعریف شده است، دسترسی پیدا کنید. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/properties/hyperlinkqueries)

کلاس IHyperlinkQueries این متدها و ویژگی‌ها را پشتیبانی می‌کند: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **سوالات متداول**

**چگونه می‌توانم ناوبری داخلی نه فقط به یک اسلاید، بلکه به یک «بخش» یا اولین اسلاید یک بخش ایجاد کنم؟**

بخش‌ها در PowerPoint گروه‌بندی‌ای از اسلایدها هستند؛ ناوبری به‌طور فنی به یک اسلاید خاص هدف می‌گیرد. برای «ناوبری به یک بخش»، معمولاً به اولین اسلاید آن بخش لینک می‌دهید.

**آیا می‌توانم یک هایپرلینک را به عناصر اسلاید اصلی (master) متصل کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر اسلاید اصلی و طرح‌بندی‌ها از هایپرلینک پشتیبانی می‌کنند. چنین لینک‌هایی در اسلایدهای فرعی ظاهر می‌شوند و در حالت نمایش اسلاید قابل کلیک هستند.

**آیا هایپرلینک‌ها هنگام خروجی گرفتن به PDF، HTML، تصاویر یا ویدئو حفظ می‌شوند؟**

در [PDF](/slides/fa/net/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/net/convert-powerpoint-to-html/) بله—لینک‌ها به‌طور کلی حفظ می‌شوند. هنگام خروجی به [تصاویر](/slides/fa/net/convert-powerpoint-to-png/) و [ویدئو](/slides/fa/net/convert-powerpoint-to-video/)، کلیک‌پذیری به دلیل طبیعت آن قالب‌ها (فریم‌های رستر/ویدئوها از هایپرلینک پشتیبانی نمی‌کنند) منتقل نمی‌شود.