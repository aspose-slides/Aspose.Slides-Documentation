---
title: مدیریت ابرلینک‌های ارائه در .NET
linktitle: مدیریت ابرلینک
type: docs
weight: 20
url: /fa/net/manage-hyperlinks/
keywords:
- افزودن آدرس
- افزودن ابرلینک
- ایجاد ابرلینک
- قالب‌بندی ابرلینک
- حذف ابرلینک
- به‌روزرسانی ابرلینک
- ابرلینک متن
- ابرلینک اسلاید
- ابرلینک شکل
- ابرلینک تصویر
- ابرلینک ویدئو
- ابرلینک قابل تغییر
- پاورپوینت
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌راحتی ابرلینک‌ها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای .NET مدیریت کنید—تعامل و جریان کاری را در چند دقیقه ارتقا دهید."
---
## **معرفی**

یک ابرلینک ارجاعی به یک شیء یا داده یا مکانی در یک محتوا است. این‌ها نمونه‌های رایج ابرلینک در ارائه‌های PowerPoint هستند:

* لینک به وب‌سایت‌ها در متن‌ها، اشکال یا رسانه‌ها
* لینک به اسلایدها

Aspose.Slides برای .NET امکان انجام بسیاری از کارهای مرتبط با ابرلینک‌ها در ارائه‌ها را فراهم می‌کند. 

{{% alert color="info" %}} 

ممکن است بخواهید ویرایشگر ساده و **رایگان** آنلاین PowerPoint Aspose را امتحان کنید.[free online PowerPoint editor.](https://products.aspose.app/slides/fa/editor)

{{% /alert %}} 

## **افزودن ابرلینک‌های URL**

### **افزودن ابرلینک‌های URL به متن**

این کد C# نشان می‌دهد چگونه به یک متن لینک وب‌سایت اضافه کنید:

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

### **افزودن ابرلینک‌های URL به اشکال یا فریم‌ها**

این نمونه کد C# نشان می‌دهد چگونه به یک شکل لینک وب‌سایت اضافه کنید:

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

### **افزودن ابرلینک‌های URL به رسانه‌ها**

Aspose.Slides به شما امکان افزودن ابرلینک به تصاویر، فایل‌های صوتی و ویدئویی را می‌دهد. 

این نمونه کد نشان می‌دهد چگونه به یک **تصویر** ابرلینک اضافه کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    // تصویر را به ارائه اضافه می‌کند
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // یک قاب تصویر در اسلاید 1 بر پایه تصویری که قبلاً اضافه شده است ایجاد می‌کند
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

 این نمونه کد نشان می‌دهد چگونه به یک **فایل صوتی** ابرلینک اضافه کنید:

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

 این نمونه کد نشان می‌دهد چگونه به یک **ویدئو** ابرلینک اضافه کنید:

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

ممکن است بخواهید *[Manage OLE](https://docs.aspose.com/slides/fa/net/manage-ole/)* را مشاهده کنید.

{{% /alert %}}


## **استفاده از ابرلینک‌ها برای ایجاد فهرست مطالب**

از آنجا که ابرلینک‌ها امکان افزودن ارجاع به اشیا یا مکان‌ها را می‌دهند، می‌توانید از آن‌ها برای ایجاد فهرست مطالب استفاده کنید. 

این نمونه کد نشان می‌دهد چگونه فهرست مطالبی با ابرلینک‌ها ایجاد کنید:

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

## **قالب‌بندی ابرلینک‌ها**

### **رنگ**

با ویژگی [ColorSource](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/properties/colorsource) در رابط [IHyperlink](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink) می‌توانید رنگ ابرلینک‌ها را تنظیم کرده و اطلاعات رنگ را از آن‌ها دریافت کنید. این ویژگی اولین بار در PowerPoint 2019 معرفی شد، بنابراین تغییرات مرتبط با این ویژگی در نسخه‌های قدیمی‌تر PowerPoint اعمال نمی‌شود.

این نمونه کد عملیاتی را نشان می‌دهد که در آن ابرلینک‌های با رنگ‌های مختلف به همان اسلاید اضافه شده‌اند:

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
### **صدا**

Aspose.Slides این ویژگی‌ها را برای تأکید بر ابرلینک با صدا فراهم می‌کند:
- [IHyperlink.Sound](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **افزودن صدا به ابرلینک**

این کد C# نشان می‌دهد چگونه ابرلینکی تنظیم کنید که صدا پخش کند و با ابرلینک دیگری صدا را متوقف کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	// صدای جدید را به مجموعه صداهای ارائه اضافه می‌کند
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// شکل جدیدی با ابرلینک به اسلاید بعدی اضافه می‌کند
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// بررسی می‌کند که ابرلینک برای «بدون صدا» است یا خیر
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// ابرلینکی را تنظیم می‌کند که صدا پخش کند
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// اسلاید خالی را اضافه می‌کند 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// شکل جدیدی با ابرلینک NoAction اضافه می‌کند
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// پرچم «توقف صدا قبلی» را برای ابرلینک تنظیم می‌کند
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **استخراج صدا از ابرلینک**

این کد C# نشان می‌دهد چگونه صدای استفاده شده در یک ابرلینک را استخراج کنید:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// دریافت ابرلینک اولین شکل
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// استخراج صدای ابرلینک به صورت آرایه بایت
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **حذف ابرلینک‌ها از ارائه‌ها**

### **حذف ابرلینک‌ها از متن**

این کد C# نشان می‌دهد چگونه ابرلینک را از یک متن در اسلاید ارائه حذف کنید:

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

### **حذف ابرلینک‌ها از اشکال یا فریم‌ها**

این کد C# نشان می‌دهد چگونه ابرلینک را از یک شکل در اسلاید ارائه حذف کنید: 

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

## **ابرلینک قابل تغییر**

کلاس [Hyperlink](https://reference.aspose.com/slides/fa/net/aspose.slides/hyperlink) قابل تغییر است. با استفاده از این کلاس می‌توانید مقادیر ویژگی‌های زیر را تغییر دهید:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/properties/highlightclick)

این قطعه کد نشان می‌دهد چگونه یک ابرلینک به اسلاید اضافه کنید و پس از آن tooltip آن را ویرایش کنید:

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

## **ویژگی‌های پشتیبانی‌شده در IHyperlinkQueries**

می‌توانید IHyperlinkQueries را از یک ارائه، اسلاید یا متن که ابرلینک برای آن تعریف شده است، دسترسی پیدا کنید. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/properties/hyperlinkqueries)

کلاس IHyperlinkQueries این متدها و ویژگی‌ها را پشتیبانی می‌کند: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **پرسش‌های متداول**

### چگونه می‌توان ناوبری داخلی را نه فقط به یک اسلاید، بلکه به «بخش» یا اولین اسلاید یک بخش ایجاد کرد؟

بخش‌ها در PowerPoint گروه‌بندی‌ای از اسلایدها هستند؛ ناوبری در واقع به یک اسلاید خاص ارجاع می‌دهد. برای «رفتن به یک بخش» معمولاً به اولین اسلاید آن بخش لینک می‌زنید.

### آیا می‌توانم ابرلینک را به عناصر اسلاید مستر پیوست کنم تا در همه اسلایدها کار کند؟

بله. عناصر اسلاید مستر و لایه‌گذاری‌ها از ابرلینک پشتیبانی می‌کنند. این لینک‌ها در اسلایدهای فرزند ظاهر می‌شوند و در طول نمایش اسلاید قابل کلیک هستند.

### آیا ابرلینک‌ها هنگام خروجی گرفتن به PDF، HTML، تصاویر یا ویدئو حفظ می‌شوند؟

در [PDF](/slides/fa/net/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/net/convert-powerpoint-to-html/) بله—لینک‌ها عموماً حفظ می‌شوند. هنگام خروجی به [تصاویر](/slides/fa/net/convert-powerpoint-to-png/) و [ویدئو](/slides/fa/net/convert-powerpoint-to-video/)، کلیک‌پذیری به دلیل ماهیت این فرمت‌ها (فریم‌های رستر/ویدئو از ابرلینک پشتیبانی نمی‌کنند) منتقل نمی‌شود.