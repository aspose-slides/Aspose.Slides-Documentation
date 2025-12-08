---
title: "عرض تقديمي ثلاثي الأبعاد"
type: docs
weight: 232
url: /ar/net/3d-presentation/
keywords:
- 3D
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- تدوير ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بثق ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- عرض PowerPoint
- C#
- Csharp
- Aspose.Slides لـ .NET
description: "عرض تقديمي ثلاثي الأبعاد لـ PowerPoint باستخدام C# أو .NET"
---

## **نظرة عامة**
كيف تقوم عادةً بإنشاء عرض تقديمي ثلاثي الأبعاد في PowerPoint؟

Microsoft PowerPoint يتيح إنشاء عروض تقديمية ثلاثية الأبعاد بحيث يمكننا إضافة نماذج ثلاثية الأبعاد هناك، وتطبيق تأثيرات ثلاثية الأبعاد على الأشكال، وإنشاء نص ثلاثي الأبعاد، وتحميل رسومات ثلاثية الأبعاد إلى العرض، وإنشاء رسومات متحركة ثلاثية الأبعاد في PowerPoint.

إنشاء تأثيرات ثلاثية الأبعاد يحقق تأثيرًا كبيرًا في تحسين عرضك التقديمي إلى عرض ثلاثي الأبعاد، وقد يكون أسهل طريقة لتنفيذ عرض ثلاثي الأبعاد.

منذ إصدار Aspose.Slides 20.9، تم إضافة **محرك ثلاثي الأبعاد متعدد المنصات** جديد. يتيح المحرك الثلاثي الأبعاد الجديد تصدير وتحويل الأشكال والنصوص ذات التأثيرات الثلاثية الأبعاد إلى رسومات نقطية. في الإصدارات السابقة، كانت الأشكال التي تم تطبيق تأثيرات ثلاثية الأبعاد عليها تُرسم مسطحة. الآن يمكن رسم الأشكال بـ **ثلاثية أبعاد كاملة**.

علاوة على ذلك، أصبح من الممكن الآن إنشاء أشكال بتأثيرات ثلاثية الأبعاد عبر واجهة برمجة تطبيقات Slides العامة.

في Aspose.Slides API، لجعل شكل يصبح شكلاً ثلاثيًا في PowerPoint استخدم خاصية [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) التي ترث ميزات واجهة [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat):

- [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) و [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop): تعيين الحافة للشكل، تحديد نوع الحافة (مثل Angle أو Circle أو SoftRound)، وتحديد ارتفاع وعرض الحافة.
- [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera): تُستخدم لمحاكاة حركات الكاميرا حول الكائن. بعبارة أخرى، من خلال ضبط دوران الكاميرا، التكبير وخصائص أخرى يمكنك التلاعب بالأشكال كما لو كانت نموذجًا ثلاثيًا في PowerPoint.
- [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) و [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth): تعيين خصائص الحد لجعل الشكل يبدو كأنه شكل PowerPoint ثلاثي الأبعاد.
- [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth)، [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) و [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight): تُستخدم لجعل الشكل ثلاثي الأبعاد، أي تحويل شكل ثنائي الأبعاد إلى شكل ثلاثي الأبعاد عن طريق ضبط العمق أو القيام بالإخراج.
- [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig): يمكنه إنشاء تأثير إضاءة على الشكل الثلاثي الأبعاد. منطق هذه الخاصية قريب من Camera؛ يمكنك ضبط دوران الضوء بالنسبة للشكل واختيار نوع الضوء.
- [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material): تحديد نوع مادة الشكل الثلاثي الأبعاد يمكن أن يضيف تأثيرًا أكثر حيوية. توفر الخاصية مجموعة من المواد المُعَرَّفة مسبقًا مثل Metal و Plastic و Powder و Matte وغيرها.

يمكن تطبيق جميع الخصائص الثلاثية الأبعاد على كل من الأشكال والنص. دعنا نرى كيف نصل إلى الخصائص المذكورة أعلاه ثم نستعرضها بالتفصيل خطوة بخطوة:
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


الصورة المصغرة التي تم توليدها تبدو هكذا:

![todo:image_alt_text](img_01_01.png)

## **تدوير ثلاثي الأبعاد**
من الممكن تدوير أشكال PowerPoint الثلاثية الأبعاد في مستوى ثلاثي الأبعاد، مما يضيف تفاعلية أكبر. لتدوير شكل ثلاثي الأبعاد في PowerPoint، عادةً ما تستخدم القائمة التالية:

![todo:image_alt_text](img_02_01.png)

في Aspose.Slides API يمكن إدارة تدوير الشكل الثلاثي الأبعاد باستخدام خاصية [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera):
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... تعيين معلمات مشهد ثلاثي الأبعاد الأخرى

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


## **عمق ثلاثي الأبعاد والاستخراج**
لإضفاء البعد الثالث على الشكل وجعله شكلًا ثلاثيًا، استخدم خصائص [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) و [IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor):
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
// ... تعيين معلمات مشهد ثلاثي الأبعاد أخرى

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


عادةً ما تستخدم قائمة Depth في PowerPoint لتحديد العمق لشكل PowerPoint ثلاثي الأبعاد:

![todo:image_alt_text](img_02_02.png)


## **تدرج ثلاثي الأبعاد**
يمكن استخدام التدرج لتعبئة لون شكل PowerPoint ثلاثي الأبعاد. لننشئ شكلًا بتعبئة تدرجية ونطبق عليه تأثير ثلاثي الأبعاد:
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

إلى جانب تعبئة التدرج، يمكن تعبئة الأشكال بصورة:
``` csharp
byte[] imageData = File.ReadAllBytes("image.jpg");
IPPImage image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
// ... إعداد ثلاثي الأبعاد: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* الخصائص

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


وهذا ما يبدو عليه:

![todo:image_alt_text](img_02_04.png)

## **نص ثلاثي الأبعاد (WordArt)**
يسمح Aspose.Slides بتطبيق ثلاثية أبعاد على النص أيضًا. لإنشاء نص ثلاثي الأبعاد يمكن استخدام تأثير تحويل WordArt:
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

## **الأسئلة الشائعة**

**هل سيتم حفظ التأثيرات الثلاثية الأبعاد عند تصدير العرض إلى الصور/PDF/HTML؟**

نعم. يقوم محرك Slides الثلاثي الأبعاد برسم التأثيرات الثلاثية الأبعاد عند التصدير إلى الصيغ المدعومة ([الصور](/slides/ar/net/convert-powerpoint-to-png/)، [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، [HTML](/slides/ar/net/convert-powerpoint-to-html/)، إلخ).

**هل يمكنني استرجاع القيم "الفعّالة" (النهائية) لمعلمات ثلاثية الأبعاد التي تأخذ في الاعتبار السمات والوراثة وما إلى ذلك؟**

نعم. توفر Slides واجهات برمجة تطبيقات لـ [قراءة القيم الفعّالة](/slides/ar/net/shape-effective-properties/) (بما في ذلك الإضاءة، الحواف الثلاثية الأبعاد، إلخ) حتى تتمكن من رؤية الإعدادات النهائية المطبقة.

**هل تعمل التأثيرات الثلاثية الأبعاد عند تحويل العرض إلى فيديو؟**

نعم. عند [إنشاء إطارات للفيديو](/slides/ar/net/convert-powerpoint-to-video/)، يتم رسم التأثيرات الثلاثية الأبعاد تمامًا كما هي عند [الصور المصدرة](/slides/ar/net/convert-powerpoint-to-png/).