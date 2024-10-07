---
title: تقديم ثلاثي الأبعاد
type: docs
weight: 232
url: /net/3d-presentation/
keywords:
- 3D
- PowerPoint ثلاثي الأبعاد
- تقديم ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بروز ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- تقديم PowerPoint
- C#
- Csharp
- Aspose.Slides لـ .NET
description: "تقديم PowerPoint ثلاثي الأبعاد بلغة C# أو .NET"
---


## نظرة عامة
كيف تقوم عادةً بإنشاء تقديم PowerPoint ثلاثي الأبعاد؟
يتيح Microsoft PowerPoint إنشاء عروض تقديمية ثلاثية الأبعاد من حيث إمكانية إضافة نماذج ثلاثية الأبعاد، وتطبيق تأثيرات ثلاثية الأبعاد على الأشكال، 
وإنشاء نصوص ثلاثية الأبعاد، وتحميل الرسوم البيانية ثلاثية الأبعاد في العرض التقديمي، وإنشاء رسوم متحركة ثلاثية الأبعاد في PowerPoint.

إنشاء تأثيرات ثلاثية الأبعاد له تأثير كبير في تحسين تقديمك إلى تقديم ثلاثي الأبعاد، وقد تكون أسهل تنفيذ لتقديم ثلاثي الأبعاد. 
منذ إصدار Aspose.Slides 20.9، تمت إضافة **محرك ثلاثي الأبعاد متعدد المنصات** جديد. يتيح محرك 3D الجديد 
تصدير وتحويل الأشكال والنصوص مع تأثيرات ثلاثية الأبعاد. في الإصدارات السابقة، 
كانت أشكال الشرائح مع تأثيرات 3D مطبقة، قد تم عرضها بشكل مسطح. ولكن، الآن من الممكن 
عرض الأشكال بشكل **ثلاثي الأبعاد كامل**.
علاوة على ذلك، الآن من الممكن إنشاء أشكال مع تأثيرات ثلاثية الأبعاد عبر واجهة برمجة التطبيقات العامة لـ Slides.

في واجهة برمجة تطبيقات Aspose.Slides، لجعل 
شكل ما يصبح شكل PowerPoint ثلاثي الأبعاد استخدم خاصية [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat)، 
التي ترث ميزات واجهة [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat):
- [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) 
و[BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop): تعيين الحواف على الشكل، تحديد نوع الحواف (مثل: زاوية، دائرة، مستديرة ناعمة)، تحديد ارتفاع وعرض الحواف.
- [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera): تستخدم لتقليد حركة الكاميرا حول الكائن. بعبارة أخرى، من خلال ضبط دوران الكاميرا، التكبير وغيرها من الخصائص - يمكنك التفاعل مع 
أشكالك كما هو الحال مع النموذج ثلاثي الأبعاد في PowerPoint.
- [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) 
و[ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth): تعيين خصائص المحيط لجعل الشكل يبدو مثل شكل PowerPoint ثلاثي الأبعاد.
- [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth)، 
[ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) 
و[ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight): تُستخدم لجعل الشكل ثلاثي الأبعاد، مما يعني تحويل شكل ثنائي الأبعاد إلى شكل ثلاثي الأبعاد، 
من خلال تعيين عمقه أو بروز الشكل.
- [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig): يمكن أن تخلق تأثير ضوء على شكل ثلاثي الأبعاد. منطق هذه الخاصية قريب من الكاميرا، يمكنك ضبط دوران الضوء 
بما يتناسب مع الشكل ثلاثي الأبعاد وتحديد نوع الضوء.
- [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material): تحديد نوع المادة المستخدمة في الشكل ثلاثي الأبعاد يمكن أن يُضفي تأثيراً أكثر حيوية عليه. توفر الخاصية مجموعة من المواد المعرفة مسبقًا، مثل: 
معدن، بلاستيك، مسحوق، غير لامع، إلخ.  

يمكن تطبيق جميع ميزات 3D على كل من الأشكال والنصوص. دعنا نرى كيف يمكن الوصول إلى الخصائص المذكورة أعلاه ثم نلقي نظرة عليها بالتفصيل خطوة بخطوة:
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

الصورة المصغرة المعالجة تبدو كالتالي:

![todo:image_alt_text](img_01_01.png)

## دوران ثلاثي الأبعاد
من الممكن تدوير أشكال PowerPoint ثلاثية الأبعاد في المستوى ثلاثي الأبعاد، مما يجلب المزيد من التفاعل. لتدوير شكل ثلاثي الأبعاد في PowerPoint، عادةً ما تستخدم القائمة التالية:

![todo:image_alt_text](img_02_01.png)

في واجهة برمجة التطبيقات Aspose.Slides يمكن إدارة دوران الشكل الثلاثي الأبعاد باستخدام خاصية [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera):

``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... ضبط معلمات المشهد ثلاثي الأبعاد الأخرى

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```

## عمق ثلاثي الأبعاد وبروز
لإضفاء البعد الثالث على شكلك وجعله شكلاً ثلاثي الأبعاد، استخدم الخاصيتين [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) 
و[IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor):

``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
// ... ضبط معلمات المشهد ثلاثي الأبعاد الأخرى

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```

عادةً ما تستخدم قائمة العمق في PowerPoint لتعيين العمق لشكل PowerPoint ثلاثي الأبعاد:

![todo:image_alt_text](img_02_02.png)


## تدرج ثلاثي الأبعاد
يمكن استخدام التدرج لملء لون شكل PowerPoint ثلاثي الأبعاد. دعنا ننشئ شكلاً بلون ملئ تدريجي ونطبق عليه تأثير ثلاثي الأبعاد:

``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.TextFrame.Text = "تدرج ثلاثي الأبعاد";
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

وهنا هي النتيجة:

![todo:image_alt_text](img_02_03.png)

بالإضافة إلى لون التعبئة التدريجي، من الممكن ملء الأشكال بصورة:
``` csharp
byte[] imageData = File.ReadAllBytes("image.jpg");
IPPImage image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
// ... إعداد 3D: shape.ThreeDFormat.Camera، shape.ThreeDFormat.LightRig، shape.ThreeDFormat.Extrusion* properties

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```

هكذا تبدو:

![todo:image_alt_text](img_02_04.png)

## نص ثلاثي الأبعاد (WordArt)
يتيح Aspose.Slides تطبيق تأثير ثلاثي الأبعاد على النص أيضًا. لإنشاء نص ثلاثي الأبعاد، من الممكن استخدام تأثير تحويل WordArt:

``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.TextFrame.Text = "نص ثلاثي الأبعاد";

    Portion portion = (Portion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

    ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
    // تعيين تأثير تحويل WordArt "قوس للأعلى"
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

إليك النتيجة:

![todo:image_alt_text](img_02_05.png)


## غير مدعوم - قادم قريبًا
الميزات الثلاثية الأبعاد التالية في PowerPoint غير مدعومة بعد: 
- الحواف
- المادة
- المحيط
- الإضاءة

نستمر في تحسين محركنا ثلاثي الأبعاد، وهذه الميزات هي موضوع للتنفيذ المستقبلي.