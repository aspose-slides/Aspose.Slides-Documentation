---
title: إدارة الروابط التشعبية
type: docs
weight: 20
url: /ar/net/manage-hyperlinks/
keywords: "إضافة رابط تشعبي، عرض PowerPoint، رابط تشعبي PowerPoint، رابط نصي، رابط شريحة، رابط شكل، رابط صورة، رابط فيديو، .NET، C#، Csharp"
description: "إضافة رابط تشعبي إلى عرض PowerPoint باستخدام C# أو .NET"
---

الرابط التشعبي هو إشارة إلى كائن أو بيانات أو مكان في شيء ما. هذه روابط تشعبية شائعة في عروض PowerPoint:

* روابط لمواقع ويب داخل النصوص أو الأشكال أو الوسائط
* روابط إلى الشرائح

تتيح لك Aspose.Slides لـ .NET أداء العديد من المهام المتعلقة بالروابط التشعبية في العروض التقديمية.

{{% alert color="primary" %}} 

قد ترغب في إلقاء نظرة على محرر PowerPoint البسيط [المجاني عبر الإنترنت من Aspose.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **إضافة روابط تشعبية URL**

### **إضافة روابط تشعبية URL إلى النصوص**

يوضح لك هذا الكود بلغة C# كيفية إضافة رابط تشعبي لموقع ويب إلى نص:

```c#
using (Presentation presentation = new Presentation())
{
	IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.AddTextFrame("Aspose: APIs تنسيق الملفات");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "أكثر من 70% من شركات فورتون 100 تثق في APIs من Aspose";
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

	presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

### **إضافة روابط تشعبية URL إلى الأشكال أو الإطارات**

يوضح لك هذا الكود النموذجي بلغة C# كيفية إضافة رابط تشعبي لموقع ويب إلى شكل:

```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "أكثر من 70% من شركات فورتون 100 تثق في APIs من Aspose";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **إضافة روابط تشعبية URL إلى الوسائط**

تتيح لك Aspose.Slides إضافة روابط تشعبية إلى الصور وملفات الصوت والفيديو.

هذا الكود النموذجي يوضح لك كيفية إضافة رابط تشعبي إلى **صورة**:

```c#
using (Presentation pres = new Presentation())
{
    // إضافة صورة إلى العرض التقديمي
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // إنشاء إطار صورة على الشريحة 1 بناءً على الصورة المضافة سابقًا
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "أكثر من 70% من شركات فورتون 100 تثق في APIs من Aspose";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

هذا الكود النموذجي يوضح لك كيفية إضافة رابط تشعبي إلى **ملف صوتي**:

```c#
using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "أكثر من 70% من شركات فورتون 100 تثق في APIs من Aspose";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

هذا الكود النموذجي يوضح لك كيفية إضافة رابط تشعبي إلى **فيديو**:

``` csharp
using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "أكثر من 70% من شركات فورتون 100 تثق في APIs من Aspose";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

{{%  alert  title="نصيحة"  color="primary"  %}} 

قد ترغب في رؤية *[إدارة OLE](https://docs.aspose.com/slides/net/manage-ole/)*.

{{% /alert %}}


## **استخدام الروابط التشعبية لإنشاء جدول محتويات**

نظرًا لأن الروابط التشعبية تتيح لك إضافة إشارات إلى كائنات أو أماكن، يمكنك استخدامها لإنشاء جدول محتويات.

هذا الكود النموذجي يوضح لك كيفية إنشاء جدول محتويات مع روابط تشعبية:

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
    paragraph.Text = "عنوان الشريحة 2 .......... ";

    var linkPortion = new Portion();
    linkPortion.Text = "الصفحة 2";
    linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

    paragraph.Portions.Add(linkPortion);
    contentTable.TextFrame.Paragraphs.Add(paragraph);

    presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
}
```

## **تنسيق الروابط التشعبية**

### **اللون**

بفضل خاصية [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/colorsource) في واجهة [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink)، يمكنك تعيين اللون للروابط التشعبية وأيضًا الحصول على معلومات اللون من الروابط التشعبية. تم تقديم هذه الميزة لأول مرة في PowerPoint 2019، لذا فإن التغييرات المتعلقة بالخاصية لا تنطبق على إصدارات PowerPoint الأقدم.

هذا الكود النموذجي يظهر عملية حيث تمت إضافة روابط تشعبية بألوان مختلفة إلى نفس الشريحة:

```c#
using (Presentation presentation = new Presentation())
{
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.AddTextFrame("هذه عينة من رابط تشعبي ملون.");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

    IAutoShape shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.AddTextFrame("هذه عينة من رابط تشعبي عادي.");
    shape2.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

    presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
}
```
### **الصوت**

توفر Aspose.Slides هذه الخصائص للسماح لك بتأكيد رابط تشعبي بصوت:
- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **إضافة صوت لرابط تشعبي**

يوضح لك هذا الكود بلغة C# كيفية تعيين رابط تشعبي يقوم بتشغيل صوت والتوقف عن استخدام رابط آخر:

```c#
using (Presentation pres = new Presentation())
{
	// إضافة صوت جديد إلى مجموعة الصوت في العرض التقديمي
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// إضافة شكل جديد مع رابط إلى الشريحة التالية
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// التحقق من الرابط التشعبي "لا صوت"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// تعيين الرابط التشعبي الذي يقوم بتشغيل الصوت
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// إضافة الشريحة الفارغة 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// إضافة شكل جديد مع رابط "لا إجراء"
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// تعيين علامة "توقف الصوت السابق"
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **استخراج صوت الرابط التشعبي**

يوضح لك هذا الكود بلغة C# كيفية استخراج الصوت المستخدم في رابط تشعبي:

```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// الحصول على الرابط التشعبي للكيفية الأولى
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// استخراج صوت الرابط التشعبي في مصفوفة البايت
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **إزالة الروابط التشعبية من العروض التقديمية**

### **إزالة الروابط التشعبية من النصوص**

يوضح لك هذا الكود بلغة C# كيفية إزالة رابط تشعبي من نص في شريحة عرض تقديمي:

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

يوضح لك هذا الكود بلغة C# كيفية إزالة رابط تشعبي من شكل في شريحة عرض تقديمي:

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

تصنف [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink) على أنها قابلة للتعديل. باستخدام هذه الفئة، يمكنك تغيير القيم لهذه الخصائص:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/properties/highlightclick)

توضح قطعة الكود كيفية إضافة رابط تشعبي إلى شريحة وتعديل أداة التلميح الخاصة به لاحقًا:

```c#
using (Presentation presentation = new Presentation())
{   
   IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);    
    
   shape1.AddTextFrame("Aspose: APIs تنسيق الملفات");
    
   shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "أكثر من 70% من شركات فورتون 100 تثق في APIs من Aspose";
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;
    
 presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```




## **الخصائص المدعومة في IHyperlinkQueries**

يمكنك الوصول إلى IHyperlinkQueries من عرض تقديمي أو شريحة أو نص تم تعريف الرابط التشعبي له.

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/properties/hyperlinkqueries)

تدعم فئة IHyperlinkQueries هذه الطرق والخصائص: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)