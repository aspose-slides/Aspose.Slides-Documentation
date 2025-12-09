---
title: إنشاء عروض تقديمية ثلاثية الأبعاد في .NET
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/net/3d-presentation/
keywords:
- PowerPoint ثلاثي الأبعاد
- عرض تقديمي ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بثق ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية في .NET باستخدام Aspose.Slides بسهولة. تصدير سريع إلى صيغ PowerPoint و OpenDocument للاستخدام المتعدد."
---

## **نظرة عامة**
كيف تقوم عادةً بإنشاء عرض تقديمي ثلاثي الأبعاد باستخدام PowerPoint؟  
Microsoft PowerPoint يتيح إنشاء عروض ثلاثية الأبعاد من خلال إضافة نماذج ثلاثية الأبعاد، تطبيق مؤثرات 3D على الأشكال، إنشاء نص ثلاثي الأبعاد، تحميل رسومات ثلاثية الأبعاد إلى العرض، وإنشاء رسومات متحركة ثلاثية الأبعاد في PowerPoint.  

إضافة مؤثرات 3D يؤدي إلى تحسين كبير للعرض وتحويله إلى عرض ثلاثي الأبعاد، وقد يكون أسهل طريقة لتطبيق 3D في العروض.  
منذ إصدار Aspose.Slides 20.9، تمت إضافة **محرك 3D متعدد المنصات** جديد. يتيح المحرك 3D الجديد تصدير وراسترزة الأشكال والنص مع مؤثرات 3D. في الإصدارات السابقة، كانت الأشكال التي تحتوي على مؤثرات 3D تُعرض بشكل مسطح. الآن أصبح بالإمكان **عرض الأشكال بشكل ثلاثي الأبعاد كامل**.  
علاوة على ذلك، أصبح بإمكانك الآن إنشاء أشكال مع مؤثرات 3D عبر API العامة لـ Slides.  

في واجهة Aspose.Slides API، لجعل شكل ما يصبح شكل PowerPoint ثلاثي الأبعاد استخدم الخاصية [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat)، التي ترث ميزات الواجهة [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat):
- [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) و[BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop): تعيين حافة للشكل، تحديد نوع الحافة (مثل Angle، Circle، SoftRound)، وتحديد ارتفاع وعرض الحافة.
- [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera): تُستخدم لمحاكاة حركات الكاميرا حول الكائن. بمعنى آخر، عبر ضبط الدوران، التكبير وخصائص أخرى يمكن التحكم في الأشكال كما لو كانت نموذجًا ثلاثيًا الأبعاد في PowerPoint.
- [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) و[ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth): تعيين خصائص الحدود لجعل الشكل يبدو كشكل PowerPoint ثلاثي الأبعاد.
- [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth)، [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) و[ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight): تُستخدم لجعل الشكل ثلاثي الأبعاد، أي تحويل شكل ثنائي الأبعاد إلى شكل ثلاثي الأبعاد عبر ضبط العمق أو البثق.
- [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig): يمكنه إنشاء تأثير إضاءة على الشكل الثلاثي الأبعاد. منطق هذه الخاصية قريب من Camera، يمكنك ضبط دوران الضوء بالنسبة للشكل واختيار نوع الضوء.
- [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material): ضبط نوع مادة الشكل الثلاثي الأبعاد يمكن أن يضيف تأثيرًا أكثر حيوية. توفر الخاصية مجموعة من المواد المعرفة مسبقًا مثل: Metal، Plastic، Powder، Matte، وغيرها.  

يمكن تطبيق جميع ميزات 3D على كل من الأشكال والنص. دعنا نرى كيفية الوصول إلى الخصائص المذكورة أعلاه ثم نتعمق فيها خطوة بخطوة:
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


الصورة المصغرة التي تم عرضها تبدو هكذا:

![todo:image_alt_text](img_01_01.png)

## **دوران 3D**
يمكنك تدوير أشكال PowerPoint الثلاثية الأبعاد في مساحة 3D، مما يضيف تفاعلية أكبر. لتدوير الشكل الثلاثي الأبعاد في PowerPoint، عادةً ما تستخدم القائمة التالية:

![todo:image_alt_text](img_02_01.png)

في Aspose.Slides API يمكن إدارة دوران الشكل الثلاثي الأبعاد باستخدام خاصية [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera):
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... ضبط معلمات المشهد ثلاثي الأبعاد الأخرى

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


## **عمق 3D والبثق**
لإضفاء البُعد الثالث على الشكل وتحويله إلى شكل ثلاثي الأبعاد، استخدم خاصيتي [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) و[IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor):
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


عادةً ما تستخدم قائمة Depth في PowerPoint لضبط العمق للشكل الثلاثي الأبعاد:

![todo:image_alt_text](img_02_02.png)


## **تدرج 3D**
يمكن استخدام التدرج لتعبئة لون الشكل الثلاثي الأبعاد. لنقم بإنشاء شكل بتعبئة تدرج لوني وتطبيق مؤثر 3D عليه:
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

إلى جانب تدرج اللون، يمكن تعبئة الأشكال بصورة:

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


وهذا ما يظهر:

![todo:image_alt_text](img_02_04.png)

## **نص 3D (WordArt)**
يسمح Aspose.Slides بتطبيق 3D على النص أيضًا. لإنشاء نص ثلاثي الأبعاد يمكن استخدام مؤثر التحويل WordArt:
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

## **الأسئلة المتداولة**

**هل سيتم الحفاظ على مؤثرات 3D عند تصدير العرض إلى صور/PDF/HTML؟**

نعم. محرك Slides 3D يقوم برندر مؤثرات 3D عند التصدير إلى الصيغ المدعومة ([images](/slides/ar/net/convert-powerpoint-to-png/)، [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، [HTML](/slides/ar/net/convert-powerpoint-to-html/)، وغيرها).

**هل يمكنني استرجاع القيم "الفعالة" (النهائية) لمعلمات 3D التي تأخذ في الاعتبار السمات والوراثة وما إلى ذلك؟**

نعم. توفر Slides واجهات برمجة تطبيقات ل[قراءة القيم الفعالة](/slides/ar/net/shape-effective-properties/) (بما في ذلك 3D—الإضاءة، الحواف، إلخ) بحيث يمكنك رؤية الإعدادات النهائية المطبقة.

**هل تعمل مؤثرات 3D عند تحويل العرض إلى فيديو؟**

نعم. عند [إنشاء إطارات للفيديو](/slides/ar/net/convert-powerpoint-to-video/)، يتم رندر مؤثرات 3D تمامًا كما يتم رندرها لل[الصور المصدرة](/slides/ar/net/convert-powerpoint-to-png/).