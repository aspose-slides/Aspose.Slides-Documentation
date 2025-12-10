---
title: إدارة الروابط التشعبية للعرض التقديمي في .NET
linktitle: إدارة الرابط التشعبي
type: docs
weight: 20
url: /ar/net/manage-hyperlinks/
keywords:
- إضافة URL
- إضافة ارتباط تشعبي
- إنشاء ارتباط تشعبي
- تنسيق ارتباط تشعبي
- إزالة ارتباط تشعبي
- تحديث ارتباط تشعبي
- ارتباط تشعبي نصي
- ارتباط تشعبي شريحة
- ارتباط تشعبي شكل
- ارتباط تشعبي صورة
- ارتباط تشعبي فيديو
- ارتباط تشعبي قابل للتعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة الروابط التشعبية بسهولة في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET—عزز التفاعل وسير العمل في دقائق."
---

الارتباط التشعبي هو إشارة إلى كائن أو بيانات أو موقع في شيء ما. هذه بعض الروابط التشعبية الشائعة في عروض PowerPoint:

* روابط إلى مواقع ويب داخل النصوص أو الأشكال أو الوسائط
* روابط إلى الشرائح

تتيح لك Aspose.Slides for .NET تنفيذ العديد من المهام المتعلقة بالروابط التشعبية في العروض التقديمية. 

{{% alert color="primary" %}} 

قد ترغب في تجربة محرر PowerPoint المجاني على الإنترنت من Aspose، [محرر PowerPoint المجاني على الإنترنت.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **إضافة روابط تشعبية URL**

### **إضافة روابط تشعبية URL إلى النص**

يعرض لك هذا الكود C# كيفية إضافة رابط تشعبي لموقع ويب إلى نص:
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


### **إضافة روابط تشعبية URL إلى الأشكال أو الإطارات**

يعرض لك هذا المثال بلغة C# كيفية إضافة رابط تشعبي لموقع ويب إلى شكل:
```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


### **إضافة روابط تشعبية URL إلى الوسائط**

تسمح لك Aspose.Slides بإضافة روابط تشعبية إلى الصور، والصوتيات، وملفات الفيديو. 

هذا المثال يوضح كيفية إضافة رابط تشعبي إلى **صورة**:
```c#
using (Presentation pres = new Presentation())
{
    // يضيف صورة إلى العرض التقديمي
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // ينشئ إطار صورة على الشريحة 1 بناءً على الصورة المضافة مسبقًا
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


 هذا المثال يوضح كيفية إضافة رابط تشعبي إلى **ملف صوتي**:
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


 هذا المثال يوضح كيفية إضافة رابط تشعبي إلى **فيديو**:
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

قد ترغب في الاطلاع على *[إدارة OLE](https://docs.aspose.com/slides/net/manage-ole/)*.

{{% /alert %}}


## **استخدام الروابط التشعبية لإنشاء جدول محتويات**

نظرًا لأن الروابط التشعبية تسمح لك بإضافة إشارات إلى كائنات أو مواقع، يمكنك استخدامها لإنشاء جدول محتويات. 

هذا المثال يوضح كيفية إنشاء جدول محتويات باستخدام الروابط التشعبية:
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


## **تنسيق الروابط التشعبية**

### **اللون**

باستخدام خاصية [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/colorsource) في واجهة [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink)، يمكنك تعيين اللون للروابط التشعبية والحصول أيضًا على معلومات اللون منها. تم تقديم هذه الميزة لأول مرة في PowerPoint 2019، لذا فإن التغييرات المتعلقة بهذه الخاصية لا تنطبق على إصدارات PowerPoint القديمة.

هذا المثال يوضح عملية إضافة روابط تشعبية بألوان مختلفة إلى نفس الشريحة:
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

### **الصوت**

توفر Aspose.Slides الخصائص التالية لتتمكن من تعزيز رابط تشعبي بصوت:
- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **إضافة صوت إلى رابط تشعبي**

يعرض لك هذا الكود C# كيفية تعيين رابط تشعبي يشغل صوتًا وإيقافه برابط تشعبي آخر:
```c#
using (Presentation pres = new Presentation())
{
	// يضيف صوتًا جديدًا إلى مجموعة الأصوات في العرض التقديمي
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// يضيف شكلًا جديدًا مع ارتباط تشعبي إلى الشريحة التالية
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// يتحقق من الارتباط التشعبي "بدون صوت"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// يضبط الارتباط التشعبي الذي يعزف الصوت
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// يضيف شريحة فارغة 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// يضيف شكلًا جديدًا مع ارتباط تشعبي NoAction
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// يضبط علم الارتباط التشعبي "إيقاف الصوت السابق"
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```


#### **استخراج صوت من رابط تشعبي**

يعرض لك هذا الكود C# كيفية استخراج الصوت المستخدم في رابط تشعبي:
```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// يحصل على ارتباط التشعبي للشكل الأول
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// يستخرج صوت الارتباط التشعبي كمصفوفة بايت
		byte[] audioData = link.Sound.BinaryData;
	}
}
```


## **إزالة الروابط التشعبية من العروض التقديمية**

### **إزالة الروابط التشعبية من النص**

يعرض لك هذا الكود C# كيفية إزالة الرابط التشعبي من نص في شريحة عرض تقديمي:
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


### **إزالة الروابط التشعبية من الأشكال أو الإطارات**

يعرض لك هذا الكود C# كيفية إزالة الرابط التشعبي من شكل في شريحة عرض تقديمي: 
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


## **رابط تشعبي قابل للتعديل**

تُعد فئة [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink) قابلة للتعديل. باستخدام هذه الفئة، يمكنك تغيير القيم للخصائص التالية:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/highlightclick)

يظهر المقتطف البرمجي كيفية إضافة رابط تشعبي إلى شريحة وتعديل معلومات الأداة Tooltip لاحقًا:
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


## **الخصائص المدعومة في IHyperlinkQueries**

يمكنك الوصول إلى IHyperlinkQueries من عرض تقديمي أو شريحة أو نص تم تعريف الرابط التشعبي له. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/properties/hyperlinkqueries)

تدعم فئة IHyperlinkQueries الطرق والخصائص التالية: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **الأسئلة المتكررة**

**كيف يمكنني إنشاء تنقل داخلي لا يقتصر على شريحة واحدة فقط، بل إلى "قسم" أو الشريحة الأولى في قسم؟**

الأقسام في PowerPoint هي مجموعات من الشرائح؛ التقنية تستهدف شريحة معينة. للـ "تنقل إلى قسم"، عادةً ما يتم الربط بالشريحة الأولى لذلك القسم.

**هل يمكنني إرفاق رابط تشعبي بعناصر الشريحة الرئيسية بحيث يعمل على جميع الشرائح؟**

نعم. تدعم عناصر الشريحة الرئيسية والقوالب الروابط التشعبية. تظهر هذه الروابط على الشرائح التابعة وتكون قابلة للنقر أثناء عرض الشرائح.

**هل سيتم الحفاظ على الروابط التشعبية عند التصدير إلى PDF أو HTML أو صور أو فيديو؟**

في [PDF](/slides/ar/net/convert-powerpoint-to-pdf/) و[HTML](/slides/ar/net/convert-powerpoint-to-html/)، نعم—عادة ما يتم الحفاظ على الروابط. عند التصدير إلى [الصور](/slides/ar/net/convert-powerpoint-to-png/) و[الفيديو](/slides/ar/net/convert-powerpoint-to-video/)، لن يتم نقل قابلية النقر بسبب طبيعة هذه التنسيقات (الإطارات النقطية أو الفيديو لا تدعم الروابط التشعبية).