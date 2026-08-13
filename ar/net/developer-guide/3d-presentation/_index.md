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

يمكن لـ Aspose.Slides for .NET إنشاء وتحرير وحفظ وعرض تنسيق ثلاثي الأبعاد على نمط PowerPoint للأشكال والنص. يغطي هذا المقال التأثيرات ثلاثية الأبعاد مثل الدوران، البثق، الحواف المائلة، الإضاءة، المادة، التعبئات المتدرجة أو صورة، والنص ثلاثي الأبعاد.

{{% alert color="info" %}}
هذا المقال يدور حول تأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. لا يتناول إدراج أو تعديل ملفات نموذج ثلاثي الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، يقوم Aspose.Slides بعرض تلك التأثيرات ثلاثية الأبعاد في الناتج الثنائي الأبعاد.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم خاصية [IShape.ThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/properties/threedformat) لتطبيق تنسيق ثلاثي الأبعاد على شكل. تُظهر الخاصية [IThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat) التي تتحكم في المشهد ثلاثي الأبعاد لهذا الشكل.

بالنسبة للنص، استخدم خاصية [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/properties/threedformat). هذا يطبق تنسيق ثلاثي الأبعاد على إطار النص بدلاً من جسم الشكل.

أهم الخصائص هي:

| الخاصية | ما الذي يتحكم فيه | متى يتم استخدامه |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/camera) | نقطة المشهد، نوع الكاميرا المُسبق، الدوران، التكبير، والمنظور. | دوران الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد مسبق للدوران ثلاثي الأبعاد في PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/lightrig) | إعداد مسبق للإضاءة، الاتجاه، ودوران الضوء. | تغيير طريقة ظهور الإضاءات والظلال على السطح ثلاثي الأبعاد. |
| [Material](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/material) | مادة السطح، مثل مسطّح، مطفي، بلاستيك، أو معدن. | جعل الهندسة نفسها تبدو أكثر تسطيحًا أو نعومة أو لامعة أو معدنية. |
| [ExtrusionHeight](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/extrusionheight) | المدى الذي يمتد فيه الشكل إلى الخلف من وجهه الأمامي. | تحويل شكل مسطّح إلى كائن ثلاثي الأبعاد سميك واضح. |
| [ExtrusionColor](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/extrusioncolor) | لون الجوانب المَبثُقة. | إظهار العمق أو تنسيق لون الجوانب مع تعبئة الوجه الأمامي. |
| [Depth](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/depth) | عمق ثلاثي الأبعاد إضافي يستخدمه تنسيق ثلاثي الأبعاد في PowerPoint. | ضبط العمق بدقة للأشكال أو النص، خصوصًا مع إعدادات الحافة والمواد. |
| [BevelTop](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/beveltop) و [BevelBottom](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/bevelbottom) | حواف مرتفعة أو مُدوّرة على الوجوه الأمامية والخلفية. | إضافة حافة مُنعمّة أو مُشكّلة بدلاً من وجه مسطّح حاد. |
| [ContourColor](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/contourcolor) و [ContourWidth](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/contourwidth) | مخطط حول الكائن ثلاثي الأبعاد. | التأكيد على حدود الكائن في المخرجات المعروضة. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثي الأبعاد بشكل مقنع:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البثق.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب قابلة للقراءة.
- إعدادات المادة، لأن السطح يؤثر على كيفية عرض الضوء.
- إعدادات البثق أو العمق، لأن الشكل المسطّح يحتاج إلى سماكة.

المثال التالي ينشئ مستطيلاً، يضيف نصًا إلى وجهه الأمامي، يطبق تنسيق ثلاثي الأبعاد، يحفظ العرض التقديمي كملف PPTX، ويقوم بعرض الشريحة كصورة PNG.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

تُظهر صورة الشريحة المعروضة المستطيل ككتلة ثلاثية الأبعاد سميكة:

![مستطيل ثلاثي الأبعاد أزرق تم عرضه مع نص ثلاثي الأبعاد أبيض على الوجه الأمامي](img_01_01.png)

## **دوران الشكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين الدوران ثلاثي الأبعاد من لوحة 3-D Rotation. قيم الدوران X وY وZ تتوافق مع الدوران الذي تحدده عبر واجهة برمجة تطبيقات الكاميرا.

![لوحة 3-D Rotation في PowerPoint مع إبراز قيم الدوران X، Y، وZ](img_02_01.png)

في Aspose.Slides، قم بتعيين نوع الكاميرا والدوران عبر [IThreeDFormat.Camera](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/camera):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا يقوم بتغيير هندسة الشكل الثنائية الأبعاد على الشريحة. بل يغير منظور ثلاثي الأبعاد الذي يستخدمه PowerPoint وAspose.Slides أثناء العرض.

## **إضافة البثق والعمق**

البثق يجعل الشكل يبدو سميكًا عن طريق إطالته خلف الوجه الأمامي. في PowerPoint، يحدد التحكم بالعمق هذه السماكة المرئية، وتحدد خاصية اللون لون الوجوه الجانبية.

![عناصر تحكم العمق في PowerPoint المرتبطة بخصائص لون البثق وارتفاع البثق](img_02_02.png)

اضبط [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/extrusionheight) للسمك و[IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/extrusioncolor) للون الجوانب:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

استخدم [IThreeDFormat.Depth](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/depth) عندما تحتاج إلى التعامل مباشرة مع قيمة العمق في PowerPoint أو دمج العمق مع الحافة، المادة، وتأثيرات النص. في العديد من سيناريوهات الشكل، تكون `ExtrusionHeight` الإعداد الأكثر وضوحًا لأنه يعبر مباشرة عن البثق المرئي.

## **استخدام التعبئات المتدرجة أو صورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون ثابت أو تعبئة متدرجة أو نمط أو صورة على الوجه الأمامي وما زلت تستخدم نفس إعدادات الكاميرا والإضاءة والمادة والبثق.

هذا المثال يطبق تعبئة متدرجة على الشكل ولون بثق أغمق على الجوانب:

```csharp
using System.Drawing;
using Aspose.Slides;

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

المخرج المعروض يحتفظ بالتدرج على الوجه الأمامي ويعرض البثق بشكل منفصل:

![مستطيل ثلاثي الأبعاد مُعروض بتعبئة متدرجة من الأزرق إلى البرتقالي وبثق برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها لتعبئة الشكل:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

الصورة تُعرض على الوجه الأمامي، بينما يُعرض البثق كسطح جانبي ثلاثي الأبعاد:

![مستطيل ثلاثي الأبعاد مُعروض بتعبئة صورة على الوجه الأمامي وبثق برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق الشكل ثلاثي الأبعاد يؤثر على جسم الشكل. تنسيق النص ثلاثي الأبعاد يؤثر على إطار النص. هذا مفيد لتأثيرات مشابهة لـ WordArt حيث تحتاج الحروف نفسها إلى البثق، المادة، الإضاءة، وإعدادات الكاميرا.

المثال التالي ينشئ نصًا بتعبئة نمطية، يطبق تحويل WordArt، ويضبط إعدادات ثلاثية الأبعاد على [ITextFrameFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat):

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

النص يُعرض كحروف مشوهة ومبعثرة ثلاثية الأبعاد:

![نص ثلاثي الأبعاد مُعروض بتقويس WordArt، تعبئة نمطية برتقالية، وبثق داكن](img_02_05.png)

## **سلوك التصدير والعرض**

يحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند حفظه إلى صيغ PowerPoint مثل PPTX. عند العرض أو التصدير إلى صيغ ذات تخطيط ثابت، يتم تحويل المشهد ثلاثي الأبعاد إلى نقطية أو رسمه في الناتج كنتيجة ثنائية الأبعاد. ينطبق ذلك عندما تقوم بعرض الشرائح إلى [PNG](/slides/ar/net/convert-powerpoint-to-png/)، أو تصدير إلى [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، أو تصدير إلى [HTML](/slides/ar/net/convert-powerpoint-to-html/)، أو إنشاء إطارات لتحويل [video conversion](/slides/ar/net/convert-powerpoint-to-video/).

- الصور وملفات PDF المصدرة غير تفاعلية. لا يمكن للمشاهد تدوير الكائن بعد التصدير.
- المظهر النهائي يعتمد على مزيج الكاميرا، نظام الإضاءة، المادة، البثق، التعبئة، وتكبير الشريحة.
- إذا كنت بحاجة إلى فحص قيم التنسيق الموروثة أو المستندة إلى السمة، اقرأ [خصائص الشكل الفعّالة](/slides/ar/net/shape-effective-properties/).
- بعض صيغ الإخراج لا يمكنها تخزين تنسيق ثلاثي الأبعاد القابل للتحرير في PowerPoint. في تلك الصيغ، يتم عرض النتيجة البصرية بدلاً من حفظها كإعدادات ثلاثية الأبعاد قابلة للتحرير.

## **FAQ**

### هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟

يقوم Aspose.Slides بإنشاء وعرض تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا يجعل الصور المصدرة أو ملفات PDF أو صفحات HTML مشاهد ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في ملف PPTX، يبقى تنسيق ثلاثي الأبعاد قابلاً للتحرير في PowerPoint حيث يدعم الصيغة ذلك.

### ما الفرق بين نموذج ثلاثي الأبعاد وتأثير ثلاثي الأبعاد؟

النموذج الثلاثي الأبعاد هو كائن ثلاثي الأبعاد منفصل يُدرج في العرض التقديمي. التأثير الثلاثي الأبعاد هو تنسيق يُطبق على شكل أو نص عادي في PowerPoint، مثل الدوران، البثق، الحافة، الإضاءة، والمادة. يغطي هذا المقال التأثيرات الثلاثية الأبعاد.

### ما الإعدادات المطلوبة للحصول على شكل ثلاثي الأبعاد مرئي؟

على الأقل، قم بتعيين دوران الكاميرا وإما البثق أو العمق. عمليًا، يجب أيضًا تعيين نظام الإضاءة والمادة حتى تكون الوجوه المُظهرّة ذات إضاءات وظلال واضحة.

### هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على كل من الأشكال والنص؟

نعم. استخدم [IShape.ThreeDFormat] لتطبيق التنسيق على جسم الشكل و[ITextFrameFormat.ThreeDFormat] للنص.

### هل تظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى صور أو PDF أو HTML أو إطارات الفيديو؟

نعم. يقوم Aspose.Slides بعرض تأثيرات ثلاثية الأبعاد عند إنتاج صور الشرائح، ومخرجات PDF، ومخرجات HTML، وإطارات التحويل إلى الفيديو. يحتوي الناتج المصدَّر على المظهر المعروض، وليس كائنًا ثلاثي الأبعاد قابلاً للتحرير.

### هل يمكنني قراءة القيم النهائية ثلاثية الأبعاد بعد تطبيق الوراثة وإعدادات السمة؟

نعم. استخدم واجهات برمجة تطبيقات التنسيق الفعّال الموضحة في [Shape Effective Properties](/slides/ar/net/shape-effective-properties/) لقراءة الكاميرا النهائية، نظام الإضاءة، الحافة، والقيم الثلاثية الأبعاد ذات الصلة.