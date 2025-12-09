---
title: إنشاء عروض تقديمية ثلاثية الأبعاد في .NET
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/net/3d-presentation/
keywords:
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بروز ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- OpenDocument
- عرض
- .NET
- C#
- Aspose.Slides
description: "إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية في .NET باستخدام Aspose.Slides بسهولة. تصدير سريع إلى صيغ PowerPoint وOpenDocument لاستخدام متعدد الأغراض."
---

## **نظرة عامة**
كيف عادةً ما تنشئ عرضاً تقديمياً ثلاثي الأبعاد في PowerPoint؟
يتيح Microsoft PowerPoint إنشاء عروض ثلاثية الأبعاد بحيث يمكننا إضافة نماذج ثلاثية الأبعاد، تطبيق تأثيرات ثلاثية الأبعاد على الأشكال، إنشاء نص ثلاثي الأبعاد، تحميل رسومات ثلاثية الأبعاد إلى العرض، وإنشاء رسوم متحركة ثلاثية الأبعاد في PowerPoint.

إنشاء تأثيرات ثلاثية الأبعاد يحدث فرقاً كبيراً في تحسين عرضك ليصبح عرضاً ثلاثي الأبعاد، وقد يكون أسهل طريقة لتطبيق عرض ثلاثي الأبعاد.
منذ إصدار Aspose.Slides 20.9، تمت إضافة **محرك ثلاثي الأبعاد عبر الأنظمة**. يتيح المحرك الثلاثي الأبعاد الجديد تصدير ورسم الأشكال والنص مع تأثيرات ثلاثية الأبعاد. في الإصدارات السابقة، كانت الأشكال ذات التأثيرات الثلاثية الأبعاد تُرسم مسطحة. الآن، يمكن رسم الأشكال بـ **تأثير ثلاثي الأبعاد كامل**.
علاوةً على ذلك، أصبح من الممكن الآن إنشاء أشكال بتأثيرات ثلاثية الأبعاد عبر واجهة برمجة تطبيقات Slides العامة.

في واجهة برمجة تطبيقات Aspose.Slides، لجعل الشكل يصبح شكل PowerPoint ثلاثي الأبعاد استخدم خاصية [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) التي ترث ميزات واجهة [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat):
- [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) و[BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop): ضبط الحافة للشكل، تعريف نوع الحافة (مثل Angle, Circle, SoftRound)، وتعريف الارتفاع والعرض.
- [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera): تُستخدم لمحاكاة حركة الكاميرا حول الكائن. بمعنى آخر، عن طريق ضبط دوران الكاميرا، التكبير والخصائص الأخرى يمكنك التلاعب بأشكالك كما لو كانت نموذجاً ثلاثيًا الأبعاد في PowerPoint.
- [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) و[ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth): ضبط خصائص الحد لجعل الشكل يبدو كأنه شكل PowerPoint ثلاثي الأبعاد.
- [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth)،[ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) و[ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight): تُستخدم لجعل الشكل ثلاثي الأبعاد، أي تحويل شكل ثنائي الأبعاد إلى شكل ثلاثي الأبعاد عن طريق ضبط العمق أو البث.
- [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig): يمكنه إنشاء تأثير إضاءة على الشكل الثلاثي الأبعاد. منطق هذه الخاصية مشابه للكاميرا، يمكنك ضبط دوران الضوء بالنسبة للشكل الثلاثي الأبعاد واختيار نوع الضوء.
- [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material): ضبط نوع مادة الشكل الثلاثي الأبعاد يضيف تأثيراً أكثر حيوية. توفر الخاصية مجموعة من المواد المُعرَّفة مسبقاً مثل: Metal, Plastic, Powder, Matte, إلخ.

يمكن تطبيق جميع ميزات ثلاثية الأبعاد على كلٍ من الأشكال والنص. دعنا نرى كيفية الوصول إلى الخصائص المذكورة أعلاه ثم نتعمق فيها خطوة بخطوة:
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


الصورة المصغرة المُصدَّرة تبدو هكذا:

![todo:image_alt_text](img_01_01.png)

## **تدوير ثلاثي الأبعاد**
يمكن تدوير أشكال PowerPoint ثلاثية الأبعاد في الفضاء الثلاثي الأبعاد، مما يزيد التفاعلية. لتدوير الشكل الثلاثي الأبعاد في PowerPoint، عادةً ما تستخدم القائمة التالية:

![todo:image_alt_text](img_02_01.png)

في واجهة برمجة تطبيقات Aspose.Slides يمكن إدارة تدوير الشكل الثلاثي الأبعاد باستخدام خاصية [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera):
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... تعيين معلمات المشهد ثلاثي الأبعاد الأخرى

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


## **عمق ثلاثي الأبعاد والبث**
لإضفاء البُعد الثالث على شكلك وجعله شكلاً ثلاثيًا الأبعاد، استخدم خصائص [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) و[IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor):
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
// ... تعيين معلمات المشهد ثلاثية الأبعاد الأخرى

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


عادةً ما تستخدم قائمة Depth في PowerPoint لتعيين العمق لشكل PowerPoint ثلاثي الأبعاد:

![todo:image_alt_text](img_02_02.png)


## **تدرج لوني ثلاثي الأبعاد**
يمكن استخدام التدرج اللوني لملء لون شكل PowerPoint ثلاثي الأبعاد. لننشئ شكلاً بملء تدرج لوني ونطبق عليه تأثير ثلاثي الأبعاد:
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

إلى جانب ملء التدرج اللوني، يمكن أيضاً ملء الأشكال بصورة:
``` csharp
byte[] imageData = File.ReadAllBytes("image.jpg");
IPPImage image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
// ... إعداد ثلاثي الأبعاد: shape.ThreeDFormat.Camera، shape.ThreeDFormat.LightRig، خصائص shape.ThreeDFormat.Extrusion*

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


وهذا هو الشكل:

![todo:image_alt_text](img_02_04.png)

## **نص ثلاثي الأبعاد (WordArt)**
يسمح Aspose.Slides بتطبيق ثلاثية الأبعاد على النص أيضًا. لإنشاء نص ثلاثي الأبعاد يمكن استخدام تأثير تحويل WordArt:
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
    // تعيين تأثير تحويل WordArt "Arch Up"
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

## **الأسئلة المتكررة**

**هل يتم حفظ تأثيرات ثلاثية الأبعاد عند تصدير العرض إلى صور/PDF/HTML؟**

نعم. يقوم محرك Slides ثلاثي الأبعاد برندر تأثيرات ثلاثية الأبعاد عند التصدير إلى الصيغ المدعومة ([الصور](/slides/ar/net/convert-powerpoint-to-png/)، [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، [HTML](/slides/ar/net/convert-powerpoint-to-html/)، إلخ).

**هل يمكنني استرجاع القيم "الفعّالة" (النهائية) لمعلمات ثلاثية الأبعاد التي تأخذ في الاعتبار السمات والوراثة وغيرها؟**

نعم. توفر Slides واجهات برمجة تطبيقات ل[قراءة القيم الفعّالة](/slides/ar/net/shape-effective-properties/) (بما في ذلك للإضاءة، الحواف، إلخ) لتتمكن من رؤية الإعدادات النهائية المطبقة.

**هل تعمل تأثيرات ثلاثية الأبعاد عند تحويل العرض إلى فيديو؟**

نعم. عند [إنشاء إطارات الفيديو](/slides/ar/net/convert-powerpoint-to-video/)، تُرسم تأثيرات ثلاثية الأبعاد كما هي في [الصور المصدَّرة](/slides/ar/net/convert-powerpoint-to-png/).