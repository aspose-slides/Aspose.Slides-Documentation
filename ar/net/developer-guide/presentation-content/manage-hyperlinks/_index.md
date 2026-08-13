---
title: إدارة ارتباطات العرض التقديمي في .NET
linktitle: إدارة الارتباط التشعبي
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
- ارتباط تشعبي للنص
- ارتباط تشعبي للشرائح
- ارتباط تشعبي للشكل
- ارتباط تشعبي للصورة
- ارتباط تشعبي للفيديو
- ارتباط تشعبي قابل للتعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة الارتباطات التشعبية بسهولة في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET—حسّن التفاعل وسير العمل خلال دقائق."
---
## **المقدمة**

الارتباط التشعبي هو إشارة إلى كائن أو بيانات أو موقع في شيء ما. هذه أمثلة شائعة للارتباطات التشعبية في عروض PowerPoint:

* روابط إلى مواقع الويب داخل النصوص أو الأشكال أو الوسائط
* روابط إلى الشرائح

تتيح لك Aspose.Slides for .NET تنفيذ العديد من المهام المتعلقة بالارتباطات التشعبية في العروض التقديمية.

{{% alert color="info" %}} 
قد ترغب في تجربة محرر PowerPoint البسيط المجاني من Aspose، [محرر PowerPoint عبر الإنترنت مجاني.](https://products.aspose.app/slides/ar/editor)
{{% /alert %}} 

## **إضافة روابط URL**

### **إضافة روابط URL إلى النص**

يوضح لك هذا الكود C# كيفية إضافة ارتباط تشعبي لموقع ويب إلى نص:

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

### **إضافة روابط URL إلى الأشكال أو الإطارات**

يوضح لك هذا المثال في C# كيفية إضافة ارتباط تشعبي لموقع ويب إلى شكل:

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

### **إضافة روابط URL إلى الوسائط**

تتيح لك Aspose.Slides إضافة ارتباطات تشعبية إلى الصور وملفات الصوت والفيديو. 

يوضح لك هذا المثال كيفية إضافة ارتباط تشعبي إلى **صورة**:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    // يضيف صورة إلى العرض التقديمي
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // ينشئ إطار صورة على الشريحة 1 استنادًا إلى الصورة المضافة مسبقًا
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

يوضح لك هذا المثال كيفية إضافة ارتباط تشعبي إلى **ملف صوت**:

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

يوضح لك هذا المثال كيفية إضافة ارتباط تشعبي إلى **فيديو**:

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
قد ترغب في مراجعة *[إدارة OLE](https://docs.aspose.com/slides/ar/net/manage-ole/)*.
{{% /alert %}}

## **استخدام الارتباطات التشعبية لإنشاء جدول المحتويات**

نظرًا لأن الارتباطات التشعبية تتيح لك إضافة إشارات إلى كائنات أو مواقع، يمكنك استخدامها لإنشاء جدول محتويات.

يوضح لك هذا المثال كيفية إنشاء جدول محتويات باستخدام الارتباطات التشعبية:

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

## **تنسيق الارتباطات التشعبية**

### **اللون**

باستخدام خاصية [ColorSource](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/properties/colorsource) في واجهة [IHyperlink](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink)، يمكنك تعيين اللون للارتباطات التشعبية وكذلك الحصول على معلومات اللون منها. تم تقديم هذه الميزة لأول مرة في PowerPoint 2019، لذا لا تنطبق التغييرات المتعلقة بهذه الخاصية على إصدارات PowerPoint الأقدم.

يوضح هذا المثال كيفية إضافة ارتباطات تشعبية بألوان مختلفة إلى نفس الشريحة:

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
### **الصوت**

توفر لك Aspose.Slides هذه الخصائص لتمكينك من التأكيد على ارتباط تشعبي بصوت:
- [IHyperlink.Sound](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **إضافة صوت للارتباط التشعبي**

يوضح لك هذا الكود C# كيفية تعيين ارتباط تشعبي يشغل صوتًا وإيقافه باستخدام ارتباط تشعبي آخر:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	// يضيف صوتًا جديدًا إلى مجموعة الأصوات في العرض التقديمي
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// يضيف شكلًا جديدًا مع ارتباط تشعبي إلى الشريحة التالية
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// يفحص الارتباط التشعبي لـ "بدون صوت"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// يضبط الارتباط التشعبي الذي يشغل الصوت
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// يضيف شريحة فارغة 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// يضيف شكلًا جديدًا مع ارتباط NoAction
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// يضبط علم الارتباط التشعبي "إيقاف الصوت السابق"
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **استخراج صوت الارتباط التشعبي**

يوضح لك هذا الكود C# كيفية استخراج الصوت المستخدم في ارتباط تشعبي:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// يحصل على ارتباط الشكل الأول
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// يستخرج صوت الارتباط التشعبي كمصفوفة بايت
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **إزالة الارتباطات التشعبية من العروض التقديمية**

### **إزالة الارتباطات التشعبية من النص**

يوضح لك هذا الكود C# كيفية إزالة الارتباط التشعبي من نص في شريحة عرض تقديمي:

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

### **إزالة الارتباطات التشعبية من الأشكال أو الإطارات**

يوضح لك هذا الكود C# كيفية إزالة الارتباط التشعبي من شكل في شريحة عرض تقديمي: 

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

## **الارتباط التشعبي القابل للتعديل**

الفئة [Hyperlink](https://reference.aspose.com/slides/ar/net/aspose.slides/hyperlink) قابلة للتعديل. باستخدام هذه الفئة، يمكنك تغيير قيم الخصائص التالية:
- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/properties/highlightclick)

يوضح لك مقطع الشيفرة كيفية إضافة ارتباط تشعبي إلى شريحة وتعديل تلميحه لاحقًا:

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

## **الخصائص المدعومة في IHyperlinkQueries**

يمكنك الوصول إلى IHyperlinkQueries من عرض تقديمي أو شريحة أو نص تم تعريف الارتباط التشعبي له. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/properties/hyperlinkqueries)

تدعم الفئة IHyperlinkQueries هذه الأساليب والخصائص: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **التعليمات المتكررة**

### كيف يمكنني إنشاء تنقل داخلي ليس فقط إلى شريحة، بل إلى "قسم" أو أول شريحة في قسم؟

الأقسام في PowerPoint هي مجموعات من الشرائح؛ التنقل يستهدف عادةً شريحة محددة. لت "التنقل إلى قسم"، عادةً ما تقوم بربط إلى أول شريحة في ذلك القسم.

### هل يمكنني إرفاق ارتباط تشعبي بعناصر الشريحة الرئيسية ليعمل على جميع الشرائح؟

نعم. تدعم عناصر الشريحة الرئيسية وتخطيطها الارتباطات التشعبية. تظهر هذه الروابط على الشرائح التابعة وتكون قابلة للنقر أثناء عرض الشرائح.

### هل سيتم الحفاظ على الارتباطات التشعبية عند التصدير إلى PDF أو HTML أو صور أو فيديو؟

In [PDF](/slides/ar/net/convert-powerpoint-to-pdf/) و [HTML](/slides/ar/net/convert-powerpoint-to-html/)، نعم — عادةً ما تُحافظ الروابط. عند التصدير إلى [images](/slides/ar/net/convert-powerpoint-to-png/) و [video](/slides/ar/net/convert-powerpoint-to-video/)، لن تُنقل قابلية النقر بسبب طبيعة تلك الصيغ (إطارات نقطية/فيديو لا تدعم الارتباطات التشعبية).