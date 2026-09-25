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
- امتداد ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- عرض
- .NET
- C#
- Aspose.Slides
description: "تطبيق وعرض تأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص في .NET باستخدام Aspose.Slides. تكوين الكاميرا والإضاءة والمادة والامتداد والتعبئات والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for .NET إنشاء وتعديل وحفظ وعرض تنسيق ثلاثي الأبعاد بأسلوب PowerPoint للأشكال والنص. تغطي هذه المقالة تأثيرات ثلاثية الأبعاد مثل الدوران، والإنبعاث، والحواف، والإضاءة، والمواد، وتعبئات التدرج أو الصورة، والنص ثلاثي الأبعاد.

{{% alert color="info" title="Note" %}}
هذه المقالة تتعلق بتأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. ليست حول إدراج أو تحرير ملفات نموذج ثلاثي الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، تقوم Aspose.Slides بعرض تلك التأثيرات ثلاثية الأبعاد في الناتج الثنائي الأبعاد المُصدّر.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم الخاصية [IShape.ThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/properties/threedformat) لتطبيق تنسيق ثلاثي الأبعاد على شكل. تكشف الخاصية عن [IThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat)، الذي يتحكم في مشهد ثلاثي الأبعاد لهذا الشكل.

بالنسبة للنص، استخدم الخاصية [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/properties/threedformat). يطبق هذا تنسيق ثلاثي الأبعاد على إطار النص بدلاً من جسم الشكل.

أهم الخصائص هي:

| الخاصية | ما الذي يتحكم فيه | متى يتم استخدامه |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/camera) | نقطة العرض، نوع الكاميرا المُعَد مسبقًا، الدوران، التقريب، والمنظور. | دوّر الكائن في الفضاء ثلاثي الأبعاد أو طابق إعداد مسبق للدوران ثلاثي الأبعاد في PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/lightrig) | إعداد الضوء، الاتجاه، ودوران الضوء. | تغيير طريقة ظهور الإضاءات والظلال على السطح ثلاثي الأبعاد. |
| [Material](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/material) | مادة السطح، مثل مسطح، غير لامع، بلاستيك، أو معدن. | اجعل الهندسة نفسها تبدو أكثر تسطيحًا، أو نعومة، أو لامعة، أو معدنية. |
| [ExtrusionHeight](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/extrusionheight) | المسافة التي يمتد فيها الشكل إلى الخلف من وجهه الأمامي. | تحويل شكل مسطح إلى كائن ثلاثي الأبعاد سميك مرئي. |
| [ExtrusionColor](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/extrusioncolor) | لون الجوانب المُمتدة. | إظهار العمق أو تنسيق لون الجوانب مع تعبئة الوجه الأمامي. |
| [Depth](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/depth) | عمق ثلاثي الأبعاد إضافي يستخدمه تنسيق ثلاثي الأبعاد في PowerPoint. | ضبط العمق بدقة للأشكال أو النص، خاصةً مع إعدادات الحافة والمواد. |
| [BevelTop](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/beveltop) و [BevelBottom](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/bevelbottom) | حواف مرفوعة أو مستديرة على الوجهين الأمامي والخلفي. | إضافة حافة ناعمة أو مصقولة بدلاً من وجه مسطح حاد. |
| [ContourColor](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/contourcolor) و [ContourWidth](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/contourwidth) | الخط الخارجي حول الكائن ثلاثي الأبعاد. | تسليط الضوء على حدود الكائن في النتيجة المعروضة. |

## **إنشاء شكل ثلاثي الأبعاد**

عادةً ما يحتاج الشكل إلى أربعة أنواع من الإعدادات قبل أن يبدو ثلاثي الأبعاد بشكل مقنع:
- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفى الامتداد.
- إعدادات الضوء، لأن الإضاءة تجعل الوجوه والجوانب قابلة للقراءة.
- إعدادات المواد، لأن السطح يؤثر على كيفية عرض الضوء.
- إعدادات الامتداد أو العمق، لأن الشكل المسطح يحتاج إلى سماكة.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى وجهه الأمامي، ويطبق تنسيقًا ثلاثيًا الأبعاد. قيم دوران الكاميرا بالدرجات، وارتفاع الامتداد هو 100 نقطة. يُعرض المثال الشريحة إلى صورة PNG بمقاس ضعف أبعادها الافتراضية ويحفظ العرض التقديمي كملف PPTX.

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

![مستطيل ثلاثي الأبعاد أزرق مع نص ثلاثي الأبعاد أبيض على الوجه الأمامي](img_01_01.png)

## **دوران الشكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين الدوران ثلاثي الأبعاد من لوحة 3-D Rotation. قيم الدوران X وY وZ تتطابق مع الدوران الذي تحدده عبر واجهة برمجة تطبيقات الكاميرا.

![لوحة 3-D Rotation في PowerPoint مع إبراز قيم الدوران X وY وZ](img_02_01.png)

في Aspose.Slides، يمكنك الوصول إلى الكاميرا عبر [IThreeDFormat.Camera](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/camera). ينشئ هذا المثال مستطيلًا، يختار عرضًا أماميًا أرثوغرافيًا، ويحدد دورانات X وY وZ إلى 20 و30 و40 درجة على التوالي. يكوّن الشكل في الذاكرة دون حفظ ملف:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة مشاهدة المشاهد للكائن. لا يغيّر ذلك هندسة الشكل ثنائية الأبعاد على الشريحة. إنه يغيّر منظور ثلاثي الأبعاد الذي يستخدمه PowerPoint و Aspose.Slides عند العرض.

## **إضافة الامتداد والعمق**

يُجعل الامتداد الشكل يبدو سميكًا عن طريق تمديده خلف الوجه الأمامي. في PowerPoint، يتحكم العمق في هذه السماكة الظاهرة، وتتحكم خاصية اللون في لون الجوانب.

![ضوابط العمق في PowerPoint مرتبطة بخصائص لون الامتداد وارتفاع الامتداد](img_02_02.png)

قم بتعيين [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/extrusionheight) للسمك و[IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/extrusioncolor) للون الجوانب. يمنح هذا المثال المستطيل امتدادًا 100 نقطة مع جوانب أرجوانية ويُدوّر الكاميرا لتظهر سماكته. يكوّن الشكل في الذاكرة دون حفظ ملف:

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

تحدد الخاصية [IThreeDFormat.Depth](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/depth) عمق الشكل ثلاثي الأبعاد. تتحكم الخاصية [ExtrusionHeight](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/properties/extrusionheight) في ارتفاع تأثير الامتداد، كما هو موضح في هذا المثال.

## **استخدام تعبئات التدرج أو الصورة مع تأثيرات ثلاثية الأبعاد**

تنسيق ثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب أو تدرج أو نمط أو تعبئة صورة على الوجه الأمامي ولا يزال بإمكانك استخدام نفس إعدادات الكاميرا والضوء والمواد والامتداد.

يطبق هذا المثال تدرجًا من الأزرق إلى البرتقالي على الوجه الأمامي ولونًا برتقاليًا غامقًا على امتداد 150 نقطة. تُحدِّد نقاط التوقف عند 0 و100 بداية ونهاية التدرج. قيم دوران الكاميرا بالدرجات. تُعرض الشريحة إلى صورة PNG بمقاس ضعف أبعادها الافتراضية:

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

تحافظ النتيجة المعروضة على التدرج على الوجه الأمامي وتعرض الامتداد بشكل منفصل:

![مستطيل ثلاثي الأبعاد مُعرض مع تعبئة تدرج أزرق إلى برتقالي وامتداد برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها لتعبئة الشكل. يتطلب هذا المثال ملفًا موجودًا اسمه "image.jpg" في دليل العمل. يمدد الصورة لتملأ المستطيل، يطبق امتدادًا 150 نقطة، ويضبط دوران الكاميرا بالدرجات. يكوّن الشكل في الذاكرة دون حفظ أو عرض ملف:

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

![مستطيل ثلاثي الأبعاد مُعرض مع تعبئة صورة على الوجه الأمامي وامتداد برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

يؤثر تنسيق ثلاثي الأبعاد للشكل على جسم الشكل. يؤثر تنسيق ثلاثي الأبعاد للنص على إطار النص. هذا مفيد لتأثيرات شبيهة بـ WordArt حيث تحتاج الأحرف نفسها إلى امتداد، مادة، إضاءة، وإعدادات كاميرا.

ينشئ المثال التالي نصًا بنمط شبكة برتقالي وأبيض، يطبق قوسًا صاعدًا، ويكوّن إعدادات ثلاثية الأبعاد عبر [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/properties/threedformat). ارتفاع الامتداد والعمق بوحدات النقاط، ودوران الضوء بالدرجات. تم إخفاء تعبئة الشكل والحد لتكون النص فقط مرئيًا. يُعرض المثال صورة PNG بمقاس ضعف أبعاد الشريحة الافتراضية ويحفظ العرض التقديمي كملف PPTX:

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

![نص ثلاثي الأبعاد مع تحويل WordArt مقوّس، تعبئة نمط برتقالي، وامتداد داكن](img_02_05.png)

## **إبقاء النص مسطحًا على شكل ثلاثي الأبعاد**

للحفاظ على قابلية قراءة النص مع الحفاظ على مظهر الشكل ثلاثي الأبعاد، عيّن [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/keeptextflat/) عبر [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/textframeformat/). عندما تكون القيمة `true`، يبقى النص خارج المشهد ثلاثي الأبعاد. عندما تكون `false`، يشارك النص في المشهد ويتبع توجّه ثلاثي الأبعاد.

هذا الإعداد لا يزيل تنسيق ثلاثي الأبعاد للشكل: لا تزال كاميرته وإضاءته وماده وامتداده مُكوَّنة عبر [IShape.ThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/threedformat/). وهو مختلف أيضًا عن الدوران العادي. تقوم [IShape.Rotation](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/rotation/) بتدوير الشكل في مستوى الشريحة، بينما تتحكم [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/rotationangle/) في دوران مخصص للنص داخل صندوقه المحيط. إبقاء النص خارج المشهد ثلاثي الأبعاد لا يعيد تعيين أي من هذين الزاويتين.

ينشئ المثال المستقل التالي مستطيلًا أزرق مع نص ويستنسخه بجانب الأصلي. كلا الشكلين لهما نفس تنسيق ثلاثي الأبعاد؛ الفرق فقط في إعداد النص: `false` على اليسار و`true` على اليمين. زوايا الكاميرا بالدرجات، وارتفاع الامتداد 40 نقطة. يحفظ المثال العرض التقديمي كملف PPTX ويعرض شريحة المقارنة إلى PNG بمقاس ضعف أبعادها الافتراضية.

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

على اليسار، يتبع النص توجّه ثلاثي الأبعاد. على اليمين، يبقى مسطحًا وأسهل للقراءة. يحتفظ كلا المستطيلين بنفس الامتداد المرئي وتوجّه ثلاثي الأبعاد.

![مستطيلات ثلاثية الأبعاد جنبًا إلى جنب: KeepTextFlat = false على اليسار وtrue على اليمين](keep_text_flat.png)

## **سلوك التصدير والعرض**

تحافظ Aspose.Slides على تنسيق ثلاثي الأبعاد عند الحفظ إلى صيغ PowerPoint مثل PPTX. عند العرض أو التصدير إلى صيغ ذات تخطيط ثابت، يتم تحويل المشهد ثلاثي الأبعاد إلى نقطية أو رسمه في الناتج كنتيجة ثنائية الأبعاد. ينطبق ذلك عندما تقوم بعرض الشرائح إلى [PNG](/slides/ar/net/convert-powerpoint-to-png/)، أو تصدير إلى [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، أو إلى [HTML](/slides/ar/net/convert-powerpoint-to-html/)، أو إنشاء إطارات لتحويل [الفيديو](/slides/ar/net/convert-powerpoint-to-video/).

احتفظ بهذه النقاط في الاعتبار:
- الصور وPDF المصدّرة ليست تفاعلية. لا يمكن للمشاهد تدوير الكائن بعد التصدير.
- المظهر النهائي يعتمد على مزيج الكاميرا، مجموعة الإضاءة، المادة، الامتداد، التعبئة، وتكبير الشريحة.
- إذا كنت بحاجة إلى فحص قيم التنسيق الموروثة أو المستندة إلى السمة، اقرأ [خصائص الشكل الفعّالة](/slides/ar/net/shape-effective-properties/).
- بعض صيغ الخرج لا يمكنها تخزين تنسيق ثلاثي الأبعاد القابل للتحرير في PowerPoint. في تلك الصيغ، يتم عرض النتيجة المرئية بدلاً من الحفاظ عليها كإعدادات ثلاثية الأبعاد قابلة للتحرير.

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides إنشاء عروض تقديمية ثلاثية الأبعاد تفاعلية؟**

يقوم Aspose.Slides بإنشاء وعرض تأثيرات ثلاثية الأبعاد لبرنامج PowerPoint للأشكال والنص. لا يجعل الصور المصدّرة أو ملفات PDF أو صفحات HTML مشاهد ثلاثية الأبعاد تفاعلية يمكن للمشاهد تدويرها. في PPTX، يبقى تنسيق ثلاثي الأبعاد قابلاً للتحرير في PowerPoint حيث يدعم الصيغة ذلك.

**ما الفرق بين النموذج ثلاثي الأبعاد والتأثير ثلاثي الأبعاد؟**

النموذج ثلاثي الأبعاد هو كائن ثلاثي الأبعاد مستقل يُدرج في العرض التقديمي. التأثير ثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، الامتداد، الحافة، الإضاءة، والمواد. تغطي هذه المقالة التأثيرات ثلاثية الأبعاد.

**ما الإعدادات المطلوبة للحصول على شكل ثلاثي الأبعاد مرئي؟**

على الأقل، عيّن دوران الكاميرا وإما الامتداد أو العمق. عمليًا، يُنصَح أيضًا بتعيين مجموعة الإضاءة والمادة حتى تكون الوجوه المعروضة ذات إضاءات وظلال واضحة.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص معًا؟**

نعم. استخدم [IShape.ThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/properties/threedformat) لجسم الشكل و[ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/properties/threedformat) للنص.

**هل ستظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى صور، PDF، HTML، أو إطارات فيديو؟**

نعم. تقوم Aspose.Slides بعرض تأثيرات ثلاثية الأبعاد عند إنتاج صور الشرائح، إخراج PDF، إخراج HTML، وإطارات تستخدم لتحويل الفيديو. يحتوي الناتج المُصدّر على المظهر المعروض، وليس كائنًا ثلاثيًا قابلًا للتحرير.

**هل يمكنني قراءة القيم النهائية ثلاثية الأبعاد بعد تطبيق الوراثة وإعدادات السمة؟**

نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الموضحة في [خصائص الشكل الفعّالة](/slides/ar/net/shape-effective-properties/) لقراءة الكاميرا النهائية، مجموعة الإضاءة، الحافة، والقيم الثلاثية الأبعاد ذات الصلة.