---
title: إنشاء تأثيرات ثلاثية الأبعاد في العروض التقديمية باستخدام .NET
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/net/3d-presentation/
keywords:
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بثق ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص في .NET باستخدام Aspose.Slides. تكوين الكاميرا والإضاءة والمادة والبثق والتعبئات والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for .NET إنشاء وتعديل وحفظ وعرض تنسيق ثلاثي الأبعاد بنمط PowerPoint للأشكال والنصوص. تغطي هذه المقالة تأثيرات ثلاثية الأبعاد مثل الدوران، والبثق، والحواف المحدبة، والإضاءة، والمواد، وتعبئات التدرج أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="primary" %}}
هذه المقالة تتناول تأثيرات تنسيق ثلاثية الأبعاد على أشكال PowerPoint والنصوص. لا تتعلق بإدراج أو تعديل ملفات نماذج ثلاثية الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، يقوم Aspose.Slides بعرض تلك التأثيرات ثلاثية الأبعاد في الناتج الثنائي الأبعاد المُصدَّر.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم خاصية [IShape.ThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/properties/threedformat) لتطبيق تنسيق ثلاثي الأبعاد على شكل. تعرض هذه الخاصية [IThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat) الذي يتحكم في المشهد ثلاثي الأبعاد لذلك الشكل.

للنص، استخدم خاصية [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/properties/threedformat). هذا يطبق تنسيق ثلاثي الأبعاد على إطار النص بدلاً من جسم الشكل.

أهم الخصائص هي:

| الخاصية | ما الذي يتحكم به | متى يتم الاستخدام |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/camera) | نقطة النظر، نوع الكاميرا المحدد مسبقًا، الدوران، التكبير، والمنظور. | دوران الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد مسبق للدوران ثلاثي الأبعاد في PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/lightrig) | إعداد إضاءة محدد مسبقًا، الاتجاه، ودوران الضوء. | تغيير مظهر المناطق المضيئة والظلال على السطح ثلاثي الأبعاد. |
| [Material](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/material) | مادة السطح، مثل مسطحة، غير لامعة، بلاستيك، أو معدن. | جعل الشكل نفسه يبدو أكثر تسطيحًا، نعومة، لمعانًا أو ميتاليًا. |
| [ExtrusionHeight](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/extrusionheight) | مدى امتداد الشكل إلى الخلف من وجهه الأمامي. | تحويل شكل مسطح إلى جسم ثلاثي الأبعاد سميك مرئي. |
| [ExtrusionColor](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/extrusioncolor) | لون الجوانب البُثقة. | إظهار العمق أو تنسيق لون الجوانب مع ملء الوجه الأمامي. |
| [Depth](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/depth) | عمق ثلاثي أبعاد إضافي يستخدمه تنسيق PowerPoint ثلاثي الأبعاد. | ضبط العمق بدقة للأشكال أو النصوص، خاصةً مع إعدادات الحافة والمادة. |
| [BevelTop](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/beveltop) و[BevelBottom](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/bevelbottom) | حواف مرتفعة أو مستديرة على الوجوه الأمامية والخلفية. | إضافة حافة ناعمة أو مصقولة بدلاً من وجه مسطح حاد. |
| [ContourColor](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/contourcolor) و[ContourWidth](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/contourwidth) | حدود حول الجسم ثلاثي الأبعاد. | إبراز حد الكائن في الناتج المعروض. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربع أنواع من الإعدادات قبل أن يبدو ثلاثيًا بشكل مقنع:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البثق.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب قابلة للقراءة.
- إعدادات المادة، لأن سطح الشكل يؤثر على طريقة عرض الضوء.
- إعدادات البثق أو العمق، لأن الشكل المسطح يحتاج إلى سماكة.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، يطبق تنسيقًا ثلاثيًا الأبعاد، يحفظ العرض التقديمي كـ PPTX، ويعرض الشريحة كصورة PNG.

```csharp
const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.TextFrame.Text = "3D";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("shape_3d.png");

presentation.Save("shape_3d.pptx", SaveFormat.Pptx);
```

الصورة المعروضة تُظهر المستطيل ككتلة ثلاثية الأبعاد سميكة:

![مستطيل ثلاثي الأبعاد أزرق مُعرض مع نص ثلاثي الأبعاد أبيض على الوجه الأمامي](img_01_01.png)

## **تدوير شكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين الدوران ثلاثي الأبعاد من خلال لوحة ‎3-D Rotation‎. قيم الدوران X وY وZ تتCorrespond to the rotation you set through the camera API.

![لوحة ‎PowerPoint 3-D Rotation‎ مع إبراز قيم الدوران X وY وZ](img_02_01.png)

في Aspose.Slides، اضبط نوع الكاميرا والدوران عبر [IThreeDFormat.Camera](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/camera):

```csharp
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا يغير ذلك هندسة الشكل الثنائي الأبعاد على الشريحة. إنه يغير نقطة النظر الثلاثية الأبعاد التي يستخدمها PowerPoint وAspose.Slides عند العرض.

## **إضافة بُثق وعمق**

البثق يجعل الشكل يبدو سميكًا بامتداده خلف الوجه الأمامي. في PowerPoint، يتحكم التحكم في العمق في هذه السماكة المرئية، ويتحكم التحكم في اللون في لون وجوه الجوانب.

![ضوابط العمق في PowerPoint مرتبطة بخصائص لون البثق وارتفاع البثق](img_02_02.png)

اضبط [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/extrusionheight) للسماكة و[IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/extrusioncolor) للون الجوانب:

```csharp
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

استخدم [IThreeDFormat.Depth](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/depth) عندما تحتاج إلى العمل مباشرةً مع قيمة العمق في PowerPoint أو دمج العمق مع الحافة، المادة، وتأثيرات النص. في كثير من سيناريوهات الشكل، يكون `ExtrusionHeight` الإعداد الأكثر وضوحًا لأنه يعبر مباشرةً عن البثق المرئي.

## **استخدام التعبئات المتدرجة أو صورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب أو تدرج أو نمط أو تعبئة صورة على الوجه الأمامي وما زلت تستخدم نفس إعدادات الكاميرا، الإضاءة، المادة، والبثق.

هذا المثال يطبق تعبئة متدرجة على الشكل ولون بُثق أغمق للجوانب:

```csharp
const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.TextFrame.Text = "3D Gradient";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("gradient_3d.png");
```

الناتج المعروض يحتفظ بالتدرج على الوجه الأمامي ويعرض البُثق بشكل منفصل:

![مستطيل ثلاثي الأبعاد مُعرض مع تعبئة متدرجة من الأزرق إلى البرتقالي وبثقة برتقالية](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها كملء للشكل:

```csharp
var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

الصورة تُعرض على الوجه الأمامي، بينما يُعرض البُثق كسطح جانبي ثلاثي الأبعاد:

![مستطيل ثلاثي الأبعاد مُعرض مع تعبئة صورة على الوجه الأمامي وبثقة برتقالية](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق الشكل ثلاثي الأبعاد يؤثر على جسم الشكل. تنسيق النص ثلاثي الأبعاد يؤثر على إطار النص. هذا مفيد لتأثيرات تشبه WordArt حيث تحتاج الحروف نفسها إلى بُثق، مادة، إضاءة، وإعدادات كاميرا.

المثال التالي ينشئ نصًا بتعبئة نمط، يطبق تحويل WordArt، ويضبط إعدادات ثلاثية الأبعاد على [ITextFrameFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat):

```csharp
const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Text = "3D Text";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

var textFrameFormat = shape.TextFrame.TextFrameFormat;
textFrameFormat.Transform = TextShapeType.ArchUp;
textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
textFrameFormat.ThreeDFormat.Depth = 3;
textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("text_3d.png");

presentation.Save("text_3d.pptx", SaveFormat.Pptx);
```

النص يُعرض كحروف ثلاثية الأبعاد مقوسة ومُبثرة:

![نص ثلاثي الأبعاد مُعرض مع تحويل WordArt مقوس، تعبئة نمط برتقالية، وبُثق داكن](img_02_05.png)

## **سلوك التصدير والعرض**

يحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند الحفظ إلى صيغ PowerPoint مثل PPTX. عند العرض أو التصدير إلى صيغ ثابتة التخطيط، يتم تقطيع المشهد ثلاثي الأبعاد أو رسمه في الناتج كنتيجة ثنائية الأبعاد. ينطبق هذا عند عرض الشرائح إلى [PNG](/slides/ar/net/convert-powerpoint-to-png/)، التصدير إلى [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، التصدير إلى [HTML](/slides/ar/net/convert-powerpoint-to-html/)، أو إنشاء إطارات لـ [تحويل الفيديو](/slides/ar/net/convert-powerpoint-to-video/).

احرص على هذه النقاط:

- الصور وملفات PDF المصدَّرة ليست تفاعلية. لا يمكن للمستخدم تدوير الكائن بعد التصدير.
- المظهر النهائي يعتمد على مزيج الكاميرا، مجموعة الإضاءة، المادة، البُثق، التعبئة، وتكبير الشريحة.
- إذا كنت بحاجة إلى فحص قيم التنسيق الموروثة أو المستندة إلى السمة، اقرأ [خصائص الشكل الفعّالة](/slides/ar/net/shape-effective-properties/).
- بعض صيغ الإخراج لا يمكنها تخزين تنسيق ثلاثي الأبعاد قابل للتحرير في PowerPoint. في تلك الصيغ، يتم عرض النتيجة بصريًا بدلاً من حفظها كإعدادات ثلاثية الأبعاد قابلة للتحرير.

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**

يقوم Aspose.Slides بإنشاء وعرض تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنصوص. لا يجعل الصور المصدَّرة أو ملفات PDF أو صفحات HTML مشاهد ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في PPTX، يبقى تنسيق ثلاثي الأبعاد قابلًا للتحرير في PowerPoint حيث تدعم الصيغة ذلك.

**ما الفرق بين نموذج ثلاثي الأبعاد وتأثير ثلاثي الأبعاد؟**

النموذج الثلاثي الأبعاد هو جسم ثلاثي أبعاد مستقل يُدرج في العرض التقديمي. التأثير الثلاثي الأبعاد هو تنسيق يُطبّق على شكل PowerPoint عادي أو نص، مثل الدوران، البُثق، الحافة، الإضاءة، والمادة. هذه المقالة تغطي التأثيرات الثلاثية الأبعاد.

**ما الإعدادات المطلوبة للحصول على شكل ثلاثي الأبعاد مرئي؟**

على الأقل، قم بتعيين دوران الكاميرا وإما البُثق أو العمق. عمليًا، يُفضل أيضًا تعيين مجموعة الإضاءة والمادة حتى تكون الوجوه المعروضة واضحة مع تباينات الظلال والإضاءات.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنصوص معًا؟**

نعم. استخدم [IShape.ThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/properties/threedformat) لجسم الشكل و[ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/properties/threedformat) للنص.

**هل ستظهر التأثيرات الثلاثية الأبعاد عند التصدير إلى صور أو PDF أو HTML أو إطارات فيديو؟**

نعم. يقوم Aspose.Slides بعرض التأثيرات الثلاثية الأبعاد عند إنتاج صور الشرائح، مخرجات PDF، مخرجات HTML، وإطارات الفيديو. الناتج المصدَّر يحتوي على الشكل المعروض، وليس ككائن ثلاثي الأبعاد قابل للتحرير.

**هل يمكنني قراءة القيم الثلاثية النهائية بعد تطبيق الميراث وإعدادات السمة؟**

نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الموضحة في [خصائص الشكل الفعّالة](/slides/ar/net/shape-effective-properties/) لقراءة الكاميرا النهائية، مجموعة الإضاءة، الحافة، والقيم الثلاثية المرتبطة.