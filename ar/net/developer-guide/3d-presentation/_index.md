---
title: إنشاء عروض تقديمية ثلاثية الأبعاد في .NET
linktitle: عرض تقديمي ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/net/3d-presentation/
keywords:
- PowerPoint ثلاثية الأبعاد
- عرض تقديمي ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بسط ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية في .NET باستخدام Aspose.Slides بسهولة. صدّر بسرعة إلى صيغ PowerPoint و OpenDocument للاستخدام المتعدد."
---

## **نظرة عامة**
كيف تقوم عادةً بإنشاء عرض تقديمي ثلاثي الأبعاد باستخدام PowerPoint؟
يسمح Microsoft PowerPoint بإنشاء عروض تقديمية ثلاثية الأبعاد بحيث يمكننا إضافة نماذج ثلاثية الأبعاد هناك، تطبيق تأثيرات ثلاثية الأبعاد على الأشكال،
إنشاء نص ثلاثي الأبعاد، رفع رسومات ثلاثية الأبعاد إلى العرض، وإنشاء رسومات متحركة ثلاثية الأبعاد في PowerPoint.

يُحدث إنشاء تأثيرات ثلاثية الأبعاد تأثيرًا كبيرًا في تحسين عرضك إلى عرض ثلاثي الأبعاد، وقد يكون أسهل طريقة لتطبيق عرض ثلاثي الأبعاد.
منذ إصدار Aspose.Slides 20.9، تم إضافة **محرك ثلاثي الأبعاد متعدد المنصات** جديد. يتيح المحرك الثلاثي الأبعد الجديد
تصدير ورسم الأشكال والنصوص ذات التأثيرات الثلاثية الأبعاد. في الإصدارات السابقة،
كانت الأشكال ذات التأثيرات الثلاثية الأبعاد تُرسم بشكل مسطح. ولكن الآن يمكن
رسم الأشكال **بتقنية ثلاثية الأبعاد كاملة**.
علاوةً على ذلك، أصبح بإمكانك الآن إنشاء أشكال ذات تأثيرات ثلاثية الأبعاد عبر API العامة لـ Slides.

في Aspose.Slides API، لجعل
شكل ما يصبح شكلاً ثلاثيًا في PowerPoint استخدم خاصية [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) ،
التي تورّث ميزات واجهة [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat):
- [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) 
و[BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop): ضبط الحافة على الشكل، تحديد نوع الحافة (مثل Angle، Circle، SoftRound)، وتحديد الارتفاع والعرض.
- [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera): تُستخدم لمحاكاة تحركات الكاميرا حول الكائن. بمعنى آخر، من خلال ضبط دوران الكاميرا، التكبير والخصائص الأخرى يمكنك التلاعب بأشكالك كما لو كانت نموذجًا ثلاثيًا في PowerPoint.
- [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) 
و[ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth): ضبط خصائص الحد لجعل الشكل يبدو كشكل ثلاثي الأبعاد في PowerPoint.
- [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth)،
[ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) 
و[ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight): تُستخدم لجعل الشكل ثلاثي الأبعاد، أي تحويل شكل ثنائي الأبعاد إلى شكل ثلاثي الأبعاد، عن طريق ضبط العمق أو البثق.
- [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig): يمكنه إنشاء تأثير إضاءة على الشكل الثلاثي الأبعاد. منطق هذه الخاصية مشابه للكاميرا، يمكنك ضبط دوران الضوء بالنسبة للشكل الثلاثي الأبعاد واختيار نوع الإضاءة.
- [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material): تحديد نوع مادة الشكل الثلاثي الأبعاد يمكن أن يُضفي تأثيرًا أكثر حيوية. توفر الخاصية مجموعة من المواد المحددة مسبقًا مثل:
Metal، Plastic، Powder، Matte، إلخ.

يمكن تطبيق جميع الميزات الثلاثية الأبعاد على كل من الأشكال والنصوص. دعنا نرى كيفية الوصول إلى الخصائص المذكورة أعلاه ثم نتفحصها بالتفصيل خطوة بخطوة:
``` csharp 
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.TextFrame.Text = "3D";
    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    shape.ThreeDFormat.Material = MaterialPresetType.Flat;
    shape.ThreeDFormat.ExtrusionHeight = 100;
    shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

    using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
    {
        thumbnail.Save("sample_3d.png");
    }

    presentation.Save("sandbox_3d.pptx", SaveFormat.Pptx);
}
```


الصورة المصغرة المُرَسَمَة تبدو هكذا:

![todo:image_alt_text](img_01_01.png)

## **الدوران الثلاثي الأبعاد**
يمكن تدوير الأشكال الثلاثية الأبعاد في PowerPoint على مستوى ثلاثي الأبعاد، ما يضيف تفاعلية أكثر. لتدوير الشكل الثلاثي الأبعاد في PowerPoint، عادةً ما تستخدم القائمة التالية:

![todo:image_alt_text](img_02_01.png)

في Aspose.Slides API يمكن إدارة دوران الشكل الثلاثي الأبعاد باستخدام خاصية [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera):
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... ضبط معلمات المشهد ثلاثية الأبعاد الأخرى

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


## **العمق والتمدد الثلاثي الأبعاد**
لإضفاء البُعد الثالث على الشكل وجعله شكلًا ثلاثيًا، استخدم خاصيتي [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight)
و[IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor):
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
// ... ضبط معلمات المشهد ثلاثية الأبعاد الأخرى

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


عادةً ما تستخدم قائمة Depth في PowerPoint لتعيين العمق للشكل الثلاثي الأبعاد:

![todo:image_alt_text](img_02_02.png)

## **التدرج الثلاثي الأبعاد**
يمكن استخدام التدرج لتعبئة لون الشكل الثلاثي الأبعاد في PowerPoint. لننشئ شكلًا بتعبئة تدرجية ونُطبق عليه تأثير ثلاثي الأبعاد:
``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.TextFrame.Text = "3D Gradient";
    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
    shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);
    
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    shape.ThreeDFormat.ExtrusionHeight = 150;
    shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

    using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
    {
        thumbnail.Save("sample_3d.png");
    }
}
```


وهنا النتيجة:

![todo:image_alt_text](img_02_03.png)

إلى جانب تعبئة التدرج اللوني، يمكن أيضًا تعبئة الأشكال بصورة:
``` csharp
byte[] imageData = File.ReadAllBytes("image.jpg");
IPPImage image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
// ... ضبط ثلاثي الأبعاد: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* properties

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


هذا هو الشكل النهائي:

![todo:image_alt_text](img_02_04.png)

## **النص الثلاثي الأبعاد (WordArt)**
يسمح Aspose.Slides بتطبيق تأثير ثلاثي الأبعاد على النص أيضًا. لإنشاء نص ثلاثي الأبعاد يمكن استخدام تأثير تحويل WordArt:
``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.TextFrame.Text = "3D Text";

    Portion portion = (Portion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

    ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
    // ضبط تأثير تحويل WordArt "Arch Up"
    textFrameFormat.Transform = TextShapeType.ArchUp;

    textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
    textFrameFormat.ThreeDFormat.Depth = 3;
    textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
    textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

    using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
    {
        thumbnail.Save("text3d.png");
    }

    presentation.Save("text3d.pptx", SaveFormat.Pptx);
}
```


وهنا النتيجة:

![todo:image_alt_text](img_02_05.png)

## **الأسئلة المتداولة**

**هل يتم الحفاظ على تأثيرات ثلاثية الأبعاد عند تصدير العرض إلى صور/PDF/HTML؟**

نعم. يقوم محرك Slides ثلاثي الأبعاد برسم تأثيرات ثلاثية الأبعاد عند التصدير إلى الصيغ المدعومة ([الصور](/slides/ar/net/convert-powerpoint-to-png/)، [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، [HTML](/slides/ar/net/convert-powerpoint-to-html/)، إلخ).

**هل يمكنني استرجاع القيم "الفعّالة" (النهائية) لمعلمات ثلاثية الأبعاد التي تأخذ في الاعتبار السمات والوراثة وما إلى ذلك؟**

نعم. توفر Slides واجهات برمجة تطبيقات لقراءة القيم الفعّالة ([read effective values](/slides/ar/net/shape-effective-properties/)) (بما في ذلك للإضاءة، الحواف، إلخ) حتى تتمكن من رؤية الإعدادات النهائية المطبقة.

**هل تعمل تأثيرات ثلاثية الأبعاد عند تحويل العرض إلى فيديو؟**

نعم. عند [إنشاء إطارات للفيديو](/slides/ar/net/convert-powerpoint-to-video/)، يتم رسم تأثيرات ثلاثية الأبعاد كما هي عند [تصدير الصور](/slides/ar/net/convert-powerpoint-to-png/).