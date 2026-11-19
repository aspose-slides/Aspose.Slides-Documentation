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
description: "تطبيق وتصيير تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص في .NET باستخدام Aspose.Slides. تكوين الكاميرا والإضاءة والمادة والبثق والتعبئات والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

Aspose.Slides for .NET يمكنه إنشاء وتحرير وحفظ وعرض تنسيق ثلاثي الأبعاد على نمط PowerPoint للأشكال والنص. تغطي هذه المقالة تأثيرات ثلاثية الأبعاد مثل الدوران، البثق، الحواف المرفوعة، الإضاءة، المادة، التعبئة بالتدرج أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="info" title="Note" %}}

هذه المقالة تتناول تأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. وهي ليست حول إدراج أو تحرير ملفات نموذج ثلاثي الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، تقوم Aspose.Slides بتصيير تلك التأثيرات ثلاثية الأبعاد في الناتج الثنائي الأبعاد المصدّر.

{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم خاصية [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) لتطبيق تنسيق ثلاثي الأبعاد على شكل. تعرض الخاصية [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat) المشهد ثلاثي الأبعاد لذلك الشكل.

بالنسبة للنص، استخدم خاصية [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat). هذا يطبق تنسيق ثلاثي الأبعاد على إطار النص بدلاً من جسم الشكل.

الخصائص الأكثر أهمية هي:

| الخاصية | ما الذي تتحكم به | متى تستخدمها |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) | نقطة المشاهدة، نوع الكاميرا المحدد مسبقاً، الدوران، التكبير، والمنظور. | دوران الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد دوران ثلاثي الأبعاد في PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig) | إعداد الإضاءة المسبق، الاتجاه، ودوران الإضاءة. | تغيير مظهر الإضاءات والظلال على السطح الثلاثي الأبعاد. |
| [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material) | مادة السطح، مثل مسطح، غير لامع، بلاستيك، أو معدن. | جعل الهندسة نفسها تبدو أكثر سَطحيةً، ناعمةً، لامعةً أو معدنيةً. |
| [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) | مدى بُعد الشكل إلى الخلف من وجهه الأمامي. | تحويل شكل مسطح إلى كائن ثلاثي الأبعاد سميك يمكن رؤيته. |
| [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) | لون الجوانب البثقية. | إظهار العمق أو تنسيق لون الجوانب مع التعبئة الأمامية. |
| [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) | عمق ثلاثي الأبعاد إضافي يستخدمه تنسيق ثلاثي الأبعاد في PowerPoint. | ضبط العمق بدقة للأشكال أو النص، خصوصاً مع إعدادات الحواف والمادة. |
| [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop) و[BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) | حواف مرفوعة أو مستديرة على الوجوه الأمامية والخلفية. | إضافة حافة مُنعّمة أو مُقوّسة بدلاً من وجه مسطح حاد. |
| [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) و[ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth) | الحد الخارجي حول الكائن الثلاثي الأبعاد. | إبراز حدود الكائن في الناتج المصوّر. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثي الأبعاد بشكل مقنع:

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يُخفي البثق.
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب قابلة للقراءة.
- إعدادات المادة، لأن السطح يؤثر على كيفية تصيير الضوء.
- إعدادات البثق أو العمق، لأن الشكل المسطح يحتاج إلى سماكة.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، ويطبق تنسيقًا ثلاثيًا الأبعاد. قيم دوران الكاميرا بالدرجات، وارتفاع البثق 100 نقطة. يُصوّر المثال الشريحة إلى صورة PNG بمقاسين ضعف الأبعاد الافتراضية ويحفظ العرض التقديمي كملف PPTX.

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

صورة الشريحة المصوّرة تُظهر المستطيل ككتلة ثلاثية الأبعاد سميكة:

![مستطيل ثلاثي الأبعاد أزرق مع نص أبيض ثلاثي الأبعاد على الوجه الأمامي](img_01_01.png)

## **دوران الشكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين دوران ثلاثي الأبعاد من لوحة 3-D Rotation. قيم الدوران X وY وZ تتطابق مع الدوران الذي تحدده عبر واجهة برمجة تطبيقات الكاميرا.

![لوحة PowerPoint 3-D Rotation مع إبراز قيم الدوران X وY وZ](img_02_01.png)

في Aspose.Slides، يمكن الوصول إلى الكاميرا عبر [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera). ينشئ هذا المثال مستطيلًا، يحدد عرضًا أماميًا أرثوغرافيًا، ويضبط دوران X وY وZ إلى 20 و30 و40 درجة على التوالي. يكوّن الشكل في الذاكرة دون حفظ ملف:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا يغيّر ذلك الهندسة الثنائية الأبعاد للشكل على الشريحة. إنه يغيّر وجهة النظر ثلاثية الأبعاد التي يستخدمها PowerPoint وAspose.Slides عند التصيير.

### **نسخ اتجاه الكاميرا من شكل قالب**

لمطابقة شكل في قالب، انسخ إعداد [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) المسبق واقرأ زاوياته عبر [GetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/getrotation/). يفتح المثال `template.pptx`، يقرأ الكاميرا من الشكل الأول على الشريحة الأولى، ويطبق اتجاهها على الشكل الثاني. كلا الشكلين لديهما إضاءة ثلاثية الأبعاد، ولا يمتلك الشكل الثاني دوران كاميرا صريح.

الزوايا بالدرجات. الفهرس `0` هو العرض، الفهرس `1` هو الطول، والفهرس `2` هو الدوران. مررها إلى [SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) بهذا الترتيب. إذا أعاد المصدر `null`، فهذا يعني عدم وجود دوران صريح، لذا اترك زوايا الشكل الثاني غير مضبوطة. دوران صريح للـ `(0, 0, 0)` يعود بثلاث أصفار ويجب نسخه.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var shapes = presentation.Slides[0].Shapes;

var sourceCamera = shapes[0].ThreeDFormat.Camera;
var destinationCamera = shapes[1].ThreeDFormat.Camera;

destinationCamera.CameraType = sourceCamera.CameraType;
var angles = sourceCamera.GetRotation();
if (angles != null)
{
    destinationCamera.SetRotation(angles[0], angles[1], angles[2]);
}

presentation.Save("camera-copy.pptx", SaveFormat.Pptx);
```

عند إعادة فتح `camera-copy.pptx`، يكون للشكلين نفس إعداد الكاميرا المسبق والدوران. في PowerPoint، السهم على اليمين يستخدم اتجاه الكاميرا المنسوخ من المستطيل على اليسار. كلا الشكلين يستخدمان نفس الإضاءة وعمق البثق.

![مستطيل ثلاثي الأبعاد أزرق وسهم أيمن مع اتجاه كاميرا متطابق، يُعرض من الأعلى واليمين](camera-orientation.png)

## **إضافة بثق وعمق**

يُضيف البثق سمكًا إلى الشكل بامتداده خلف الوجه الأمامي. في PowerPoint، يتحكم تحكم العمق في هذا السمك الظار، ويتحكم تحكم اللون في لون وجوه الجوانب.

![تحكمات عمق PowerPoint مرتبطة بلون البثق وخصائص ارتفاع البثق](img_02_02.png)

عيّن [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) للسمك و[IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) للون الجوانب. يضيف هذا المثال إلى المستطيل بترقيم بارتفاع 100 نقطة وجوانب بنفسجية، ويدور الكاميرا لإظهار السمك. يكوّن الشكل في الذاكرة دون حفظ ملف:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

خاصية [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) تحدد عمق الشكل الثلاثي الأبعاد. خاصية [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) تتحكم في ارتفاع تأثير البثق، كما هو موضح في هذا المثال.

## **استخدام تعبئة بالتدرج أو صورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب، تدرج، نمط، أو تعبئة صورة على الوجه الأمامي ولا يزال بالإمكان استخدام نفس إعدادات الكاميرا، الإضاءة، المادة، والبثق.

هذا المثال يطبق تدرج أزرق إلى برتقالي على الوجه الأمامي ولون برتقالي غامق على البثق بارتفاع 150 نقطة. تتوقف نقاط التدرج عند 0 و100 لتحديد بداية ونهاية التدرج. قيم دوران الكاميرا بالدرجات. تُصوّر الشريحة إلى صورة PNG بمقاسين ضعف الأبعاد الافتراضية:

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

الناتج المصوّر يحافظ على التدرج على الوجه الأمامي ويصوّر البثق بشكل منفصل:

![مستطيل ثلاثي الأبعاد مع تعبئة تدرج أزرق إلى برتقالي وبثق برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلًا من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها كعباءة الشكل. يتطلب هذا المثال ملفًا موجودًا باسم "image.jpg" في دليل العمل. يمدّ الصورة لتملأ المستطيل، يطبق بثقًا بارتفاع 150 نقطة، ويضبط دوران الكاميرا بالدرجات. يكوّن الشكل في الذاكرة دون حفظ أو تصيير ملف:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

تُصوّر الصورة على الوجه الأمامي، بينما يُصوّر البثق كسطح جانبي ثلاثي الأبعاد:

![مستطيل ثلاثي الأبعاد مع تعبئة صورة على الوجه الأمامي وبثق برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تؤثر تنسيقات ثلاثية الأبعاد على جسم الشكل. تؤثر تنسيقات النص ثلاثية الأبعاد على إطار النص. هذا مفيد لتأثيرات شبيهة بـ WordArt حيث تحتاج الأحرف نفسها إلى بثق، مادة، إضاءة، وإعدادات كاميرا.

المثال التالي ينشئ نصًا بنمط شبكة برتقالية-بيضاء، يطبق قوسًا صعوديًا، ويكوّن إعدادات ثلاثية الأبعاد عبر [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat). ارتفاع البثق والعمق بالنقاط، ودوران الإضاءة بالدرجات. تم إخفاء تعبئة الشكل والحد لتظهر النص فقط. يُصوّر المثال صورة PNG بمضاعفة أبعاد الشريحة ويحفظ العرض التقديمي كملف PPTX:

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

يُصوّر النص كحروف ثلاثية الأبعاد منحنية ومقواة:

![نص ثلاثي الأبعاد مُصوَر مع تحويل WordArt مقوس، تعبئة بنمط برتقالي، وبثق داكن](img_02_05.png)

## **الحفاظ على النص مسطحًا على شكل ثلاثي الأبعاد**

لإبقاء النص مقروءًا مع الحفاظ على مظهر الشكل الثلاثي الأبعاد، اضبط [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/keeptextflat/) عبر [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframe/textframeformat/). عندما تكون القيمة `true`، يبقى النص خارج المشهد الثلاثي الأبعاد. عندما تكون `false`، يشارك النص في المشهد ويتبع توجيهاته الثلاثية الأبعاد.

هذا الإعداد لا يزيل تنسيق الشكل الثلاثي الأبعاد: الكاميرا، الإضاءة، المادة، والبثق لا تزال مُكوَّنة عبر [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/). كما يختلف عن الدوران العادي. خاصية [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) تدور الشكل في مستوى الشريحة، بينما خاصية [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) تتحكم في دوران النص داخل صندوقه. إبقاء النص خارج المشهد لا يعيد ضبط أي من هاتين الزاويتين.

المثال المستقل التالي ينشئ مستطيلًا أزرقًا مع نص، ثم ينسخه بجانب الأصلي. كلا الشكلين لهما نفس تنسيق ثلاثي الأبعاد؛ يختلف فقط إعداد النص: `false` على اليسار و`true` على اليمين. زوايا الكاميرا بالدرجات، وارتفاع البثق 40 نقطة. يحفظ المثال العرض التقديمي كملف PPTX ويصوّر شريحة المقارنة إلى PNG بمقاسين ضعف الأبعاد الافتراضية.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

shape.TextFrame.Text = "Readable text";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 28;
shape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(30, 30, 0);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 40;
shape.ThreeDFormat.ExtrusionColor.Color = Color.RoyalBlue;
shape.TextFrame.TextFrameFormat.KeepTextFlat = false;

var flatTextShape = (IAutoShape)slide.Shapes.AddClone(shape, 400, 160);
flatTextShape.TextFrame.TextFrameFormat.KeepTextFlat = true;

presentation.Save("keep_text_flat.pptx", SaveFormat.Pptx);
using var image = slide.GetImage(2, 2);
image.Save("keep_text_flat.png");
```

على اليسار، يتبع النص الاتجاه الثلاثي الأبعاد. على اليمين، يبقى مسطحًا وأسهل قراءة. كلا المستطيلين يحتفظان بنفس البثق الظاهر والاتجاه الثلاثي الأبعاد.

![مستطيلان ثلاثيان جنبًا إلى جنب: KeepTextFlat خاطئ على اليسار وصحيح على اليمين](keep_text_flat.png)

## **سلوك التصدير والتصيير**

تحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند الحفظ إلى صيغ PowerPoint مثل PPTX. عند التصيير أو التصدير إلى صيغ ذات تخطيط ثابت، يُرسم المشهد الثلاثي الأبعاد أو يُدمج في الناتج كنتيجة ثنائية الأبعاد. ينطبق ذلك عند تصيير الشرائح إلى [PNG](/slides/ar/net/convert-powerpoint-to-png/)، أو التصدير إلى [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، أو التصدير إلى [HTML](/slides/ar/net/convert-powerpoint-to-html/)، أو توليد إطارات لتحويل [الفيديو](/slides/ar/net/convert-powerpoint-to-video/).

احرص على مراعاة النقاط التالية:

- الصور وملفات PDF المصدرة ليست تفاعلية. لا يمكن للمشاهد تدوير الكائن بعد التصدير.
- المظهر النهائي يعتمد على مزيج الكاميرا، مجموعة الإضاءة، المادة، البثق، التعبئة، وتكبير الشريحة.
- إذا أردت فحص القيم الموروثة أو المستندة إلى السمات، اقرأ [الخصائص الفعّالة للشكل](/slides/ar/net/shape-effective-properties/).
- بعض صيغ الإخراج لا يمكنها تخزين تنسيق ثلاثي الأبعاد قابلاً للتحرير في PowerPoint. في تلك الصيغ، يُرسم النتيجة البصرية بدلًا من الحفاظ على إعدادات ثلاثية الأبعاد قابلة للتحرير.

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**

Aspose.Slides ينشئ ويصوّر تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا يجعل الصور المصدرة أو ملفات PDF أو صفحات HTML مشاهد ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في PPTX، يبقى تنسيق ثلاثي الأبعاد قابلًا للتحرير في PowerPoint حيث تدعم الصيغة ذلك.

**ما الفرق بين النموذج الثلاثي الأبعاد والتأثير الثلاثي الأبعاد؟**

النموذج الثلاثي الأبعاد هو كائن ثلاثي أبعاد منفصل يُدرج في العرض التقديمي. التأثير الثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، البثق، الحافة، الإضاءة، والمادة. تغطي هذه المقالة التأثيرات الثلاثية الأبعاد.

**ما هي الإعدادات المطلوبة للحصول على شكل ثلاثي الأبعاد مرئي؟**

على الأقل، اضبط دوران الكاميرا وإما البثق أو العمق. عمليًا، يفضَّل أيضًا ضبط مجموعة الإضاءة والمادة لضمان وضوح اللمسات والظلال على الوجوه المصورة.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص معًا؟**

نعم. استخدم [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) لجسم الشكل و[ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) للنص.

**هل ستظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى صور أو PDF أو HTML أو إطارات فيديو؟**

نعم. تقوم Aspose.Slides بصيّر تأثيرات ثلاثية الأبعاد عند إنتاج صور الشرائح، مخرجات PDF، مخرجات HTML، وإطارات الفيديو. يحتوي الناتج المصدَّر على المظهر المصوّر، وليس كائنًا ثلاثيًا أبعادًا قابلاً للتحرير.

**هل يمكنني قراءة القيم النهائية الثلاثية الأبعاد بعد تطبيق الوراثة وإعدادات السمات؟**

نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال المذكورة في [خصائص الشكل الفعّالة](/slides/ar/net/shape-effective-properties/) لقراءة الكاميرا النهائية، مجموعة الإضاءة، الحافة، والقيم الثلاثية الأبعاد ذات الصلة.