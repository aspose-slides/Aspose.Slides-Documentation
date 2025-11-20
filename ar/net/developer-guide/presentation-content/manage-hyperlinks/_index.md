---
title: إدارة الروابط التشعبية
type: docs
weight: 20
url: /ar/net/manage-hyperlinks/
keywords: "إضافة ارتباط تشعبي, عرض تقديمي PowerPoint, ارتباط تشعبي PowerPoint, ارتباط تشعبي نص, ارتباط تشعبي شريحة, ارتباط تشعبي شكل, ارتباط تشعبي صورة, ارتباط تشعبي فيديو, .NET, C#, Csharp"
description: "إضافة ارتباط تشعبي إلى عرض تقديمي PowerPoint باستخدام C# أو .NET"
---

الارتباط التشعبي هو إشارة إلى كائن أو بيانات أو مكان في شيء. هذه روابط تشعبية شائعة في عروض PowerPoint التقديمية:

* روابط إلى مواقع الويب داخل النصوص أو الأشكال أو الوسائط
* روابط إلى الشرائح

يتيح لك Aspose.Slides لـ .NET أداء العديد من المهام المتعلقة بالارتباطات التشعبية في العروض التقديمية.

{{% alert color="primary" %}} 
قد ترغب في تجربة Aspose بسيط، [محرر PowerPoint مجاني عبر الإنترنت.](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **إضافة ارتباطات URL**

### **إضافة ارتباطات URL إلى النصوص**

يعرض هذا الكود C# كيفية إضافة ارتباط تشعبي لموقع ويب إلى نص:
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


### **إضافة ارتباطات URL إلى الأشكال أو الإطارات**

يعرض هذا المثال في C# كيفية إضافة ارتباط تشعبي لموقع ويب إلى شكل:
```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspode APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


### **إضافة ارتباطات URL إلى الوسائط**

يتيح لك Aspose.Slides إضافة روابط تشعبية إلى الصور وملفات الصوت والفيديو.

يعرض هذا المثال كيفية إضافة ارتباط تشعبي إلى **صورة**:
```c#
using (Presentation pres = new Presentation())
{
    // يضيف صورة إلى العرض التقديمي
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // ينشئ إطار صورة على الشريحة 1 استنادًا إلى الصورة التي أضيفت مسبقًا
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


يعرض هذا المثال كيفية إضافة ارتباط تشعبي إلى **ملف صوتي**:
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


يعرض هذا المثال كيفية إضافة ارتباط تشعبي إلى **فيديو**:
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

## **استخدام الارتباطات التشعبية لإنشاء جدول محتويات**

نظرًا لأن الارتباطات التشعبية تتيح لك إضافة إشارات إلى كائنات أو أماكن، يمكنك استخدامها لإنشاء جدول محتويات.

يعرض هذا المثال كيفية إنشاء جدول محتويات مع ارتباطات تشعبية:
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


## **تنسيق الارتباطات التشعبية**

### **اللون**

باستخدام الخاصية [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/colorsource) في واجهة [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink)، يمكنك تحديد لون الارتباطات التشعبية والحصول أيضًا على معلومات اللون من الارتباطات. تم تقديم هذه الميزة لأول مرة في PowerPoint 2019، لذا فإن التغييرات المتعلقة بهذه الخاصية لا تنطبق على إصدارات PowerPoint الأقدم.

يوضح هذا المثال عملية تم فيها إضافة ارتباطات تشعبية بألوان مختلفة إلى الشريحة نفسها:
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

يوفر Aspose.Slides هذه الخصائص لتتيح لك تعزيز ارتباط تشعبي بصوت:
- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **إضافة صوت للارتباط**

يعرض هذا الكود C# كيفية تعيين ارتباط تشعبي يشغل صوتًا وإيقافه عبر ارتباط تشعبي آخر:
```c#
using (Presentation pres = new Presentation())
{
	// يضيف صوتًا جديدًا إلى مجموعة أصوات العرض التقديمي
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// يضيف شكلًا جديدًا مع ارتباط تشعبي إلى الشريحة التالية
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// يتحقق من الارتباط التشعبي "بدون صوت"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// يضبط الارتباط التشعبي الذي يُشغل الصوت
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// يضيف شريحة فارغة 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// يضيف شكلاً جديدًا مع ارتباط تشعبي NoAction
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// يضبط علم "إيقاف الصوت السابق" للارتباط التشعبي
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```


#### **استخراج صوت الارتباط**

يعرض هذا الكود C# كيفية استخراج الصوت المستخدم في ارتباط تشعبي:
```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// الحصول على الارتباط التشعبي للشكل الأول
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// استخراج صوت الارتباط التشعبي في مصفوفة بايت
		byte[] audioData = link.Sound.BinaryData;
	}
}
```


## **إزالة الارتباطات التشعبية في العروض التقديمية**

### **إزالة الارتباطات التشعبية من النصوص**

يعرض هذا الكود C# كيفية إزالة الارتباط التشعبي من نص في شريحة عرض تقديمي:
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


### **إزالة الارتباطات التشعبية من الأشكال أو الإطارات**

يعرض هذا الكود C# كيفية إزالة الارتباط التشعبي من شكل في شريحة عرض تقديمي:
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


## **الارتباط التشعبي القابل للتغيير**

الفئة [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink) قابلة للتغيير. باستخدام هذه الفئة، يمكنك تعديل القيم لهذه الخصائص:
- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/highlightclick)

يعرض مقطع الكود كيفية إضافة ارتباط تشعبي إلى شريحة وتعديل تلميحه لاحقًا:
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

يمكنك الوصول إلى IHyperlinkQueries من عرض تقديمي أو شريحة أو نص تم تعريف الارتباط فيه.
- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/properties/hyperlinkqueries)

تدعم الفئة IHyperlinkQueries هذه الأساليب والخصائص:
- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **FAQ**

**كيف يمكنني إنشاء تنقل داخلي ليس فقط إلى شريحة، بل إلى "قسم" أو الشريحة الأولى من قسم؟**

الأقسام في PowerPoint هي تجميعات للشرائح؛ التنقل يستهدف تقنيًا شريحة محددة. للـ "انتقال إلى قسم"، عادةً ما تقوم بربط إلى شريحته الأولى.

**هل يمكنني إرفاق ارتباط تشعبي بعناصر الشريحة الرئيسة ليعمل على جميع الشرائح؟**

نعم. تدعم عناصر الشريحة الرئيسة وتخطيطها الروابط التشعبية. تظهر هذه الروابط على الشرائح الفرعية وتكون قابلة للنقر أثناء عرض الشرائح.

**هل سيتم الحفاظ على الروابط التشعبية عند التصدير إلى PDF أو HTML أو صور أو فيديو؟**

في [PDF](/slides/ar/net/convert-powerpoint-to-pdf/) و[HTML](/slides/ar/net/convert-powerpoint-to-html/)، نعم—عادةً ما يتم الحفاظ على الروابط. عند التصدير إلى [صور](/slides/ar/net/convert-powerpoint-to-png/) و[فيديو](/slides/ar/net/convert-powerpoint-to-video/)، لن يتم نقل قابلية النقر بسبب طبيعة هذه الصيغ (الإطارات النقطية/الفيديو لا تدعم الروابط التشعبية).