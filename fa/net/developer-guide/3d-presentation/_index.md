---
title: ایجاد افکت‌های سه‌بعدی در ارائه‌ها با استفاده از .NET
linktitle: ارائه سه‌بعدی
type: docs
weight: 232
url: /fa/net/3d-presentation/
keywords:
- PowerPoint سه‌بعدی
- ارائه سه‌بعدی
- چرخش سه‌بعدی
- عمق سه‌بعدی
- برآمدگی سه‌بعدی
- گرادیان سه‌بعدی
- متن سه‌بعدی
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "با Aspose.Slides در .NET افکت‌های سه‌بعدی را برای اشکال و متن PowerPoint اعمال و رندر کنید. دوربین، نورپردازی، ماده، برآمدگی، پرکردنی‌ها و متن سه‌بعدی را پیکربندی کنید."
---
## **بررسی کلی**

Aspose.Slides برای .NET می‌تواند قالب‌بندی سه‌بعدی شبیه PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله به افکت‌های سه‌بعدی مانند چرخش، برآمدگی، برجستگی‌ها، نورپردازی، مواد، پر کردن‌های گرادیانی یا تصویری و متن سه‌بعدی می‌پردازد.

{{% alert color="info" title="Note" %}}
این مقاله درباره افکت‌های قالب‌بندی سه‌بعدی روی اشکال و متن PowerPoint است. درباره درج یا ویرایش فایل‌های مدل سه‌بعدی مستقل نیست. هنگامی که یک اسلاید را به تصویر، PDF یا HTML صادر می‌کنید، Aspose.Slides این افکت‌های سه‌بعدی را به خروجی دو‌بعدی رندر می‌کند.
{{% /alert %}}

## **مفاهیم قالب‌بندی سه‌بعدی**

برای اعمال قالب‌بندی سه‌بعدی به یک شکل، از ویژگی [IShape.ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/properties/threedformat) استفاده کنید. این ویژگی [IThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat) را در دسترس می‌گذارد که صحنه سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از ویژگی [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/properties/threedformat) استفاده کنید. این ویژگی قالب‌بندی سه‌بعدی را به فریم متن اعمال می‌کند، نه به بدنهٔ شکل.

مهم‌ترین ویژگی‌ها عبارتند از:

| ویژگی | چه چیزی را کنترل می‌کند | زمان استفاده |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/camera) | نقطه دید، نوع دوربین پیش‌تنظیم‌شده، چرخش، زوم و پرسپکتیو. | برای چرخش شیء در فضای سه‌بعدی یا تطبیق با پیش‌تنظیم چرخش سه‌بعدی PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/lightrig) | پیش‌تنظیم نور، جهت و چرخش نور. | برای تغییر ظاهر برجستگی‌ها و سایه‌ها روی سطح سه‌بعدی. |
| [Material](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/material) | مادهٔ سطح، مانند صاف، مات، پلاستیک یا فلزی. | برای نمایش هندسه به صورتی صاف‌تر، نرم‌تر، براق یا فلزی. |
| [ExtrusionHeight](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/extrusionheight) | میزان امتداد شکل به‌عقب از سطح جلو آن. | برای تبدیل یک شکل صاف به یک شیء سه‌بعدی واضحاً ضخیم. |
| [ExtrusionColor](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/extrusioncolor) | رنگ جانبی‌های برآمده. | برای نمایش عمق یا هماهنگ‌سازی رنگ جانبی با پر کردن سطح جلو. |
| [Depth](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/depth) | عمق سه‌بعدی اضافی که توسط قالب‌بندی PowerPoint استفاده می‌شود. | برای تنظیم دقیق عمق اشکال یا متن، به‌ویژه همراه با تنظیمات برجستگی و ماده. |
| [BevelTop](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/beveltop) و [BevelBottom](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/bevelbottom) | لبه‌های برجسته یا گرد شده روی سطوح جلو و پشت. | برای افزودن لبهٔ نرم یا قالب‌دار به‌جای سطح صاف و تیز. |
| [ContourColor](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/contourcolor) و [ContourWidth](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/contourwidth) | خط مرزی اطراف شیء سه‌بعدی. | برای برجسته‌سازی مرز شیء در خروجی رندر شده. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً برای ظاهر قانع‌کنندهٔ سه‌بعدی به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض ممکن است برآمدگی را مخفی کند.
- تنظیمات نور، زیرا نورپردازی باعث خوانایی سطوح و جانبی‌ها می‌شود.
- تنظیمات ماده، زیرا سطح تأثیر می‌گذارد که نور چگونه رندر شود.
- تنظیمات برآمدگی یا عمق، زیرا یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلو اضافه می‌کند و قالب‌بندی سه‌بعدی را اعمال می‌نماید. مقادیر چرخش دوربین بر حسب درجه است و ارتفاع برآمدگی ۱۰۰ پوینت است. مثال اسلاید را به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند و ارائه را به‌صورت PPTX ذخیره می‌نماید.

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

تصویر رندر شدهٔ اسلاید، مستطیل را به‌صورت یک بلوک سه‌بعدی ضخیم نشان می‌دهد:

![مستطیل سه‌بعدی آبی رندر شده با متن سه‌بعدی سفید بر روی وجه جلو](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از پانل 3‑D Rotation تنظیم می‌شود. مقادیر چرخش X، Y و Z متناظر با چرخشی هستند که از طریق API دوربین تنظیم می‌کنید.

![پانل 3‑D Rotation در PowerPoint با مقادیر X، Y و Z برجسته شده](img_02_01.png)

در Aspose.Slides، از طریق [IThreeDFormat.Camera](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/camera) به دوربین دسترسی پیدا کنید. این مثال یک مستطیل ایجاد می‌کند، نمای جلو ارتوگرافیک را انتخاب می‌کند و چرخش‌های X، Y و Z را به ترتیب 20، 30 و 40 درجه تنظیم می‌نماید. شکل در حافظه پیکربندی می‌شود بدون اینکه فایلی ذخیره شود:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

از دوربین زمانی استفاده کنید که بخواهید نحوهٔ مشاهدهٔ شیء توسط کاربر را تغییر دهید. این کار هندسهٔ دو‌بعدی شکل روی اسلاید را تغییر نمی‌دهد؛ فقط نقطهٔ دید سه‌بعدی مورد استفاده توسط PowerPoint و Aspose.Slides در زمان رندر را تنظیم می‌کند.

## **افزودن برآمدگی و عمق**

برآمدگی باعث می‌شود یک شکل به‌صورت ضخیم ظاهر شود زیرا از سطح جلو به عقب امتداد می‌یابد. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ، رنگ سطوح کناری را تعیین می‌نماید.

![کنترل‌های عمق PowerPoint که به ویژگی‌های رنگ برآمدگی و ارتفاع برآمدگی نگاشت می‌شوند](img_02_02.png)

برای تعیین ضخامت از [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/extrusionheight) و برای رنگ جانبی‌ها از [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/extrusioncolor) استفاده کنید. این مثال به مستطیل یک برآمدگی ۱۰۰ پوینتی با لبه‌های بنفش می‌دهد و دوربین را برای نمایش ضخامت می‌چرخاند. شکل در حافظه پیکربندی می‌شود بدون ذخیرهٔ فایل:

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

ویژگی [IThreeDFormat.Depth](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/depth) عمق یک شکل سه‌بعدی را تنظیم می‌کند. ویژگی [ExtrusionHeight](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/extrusionheight) ارتفاع اثر برآمدگی را کنترل می‌کند، همان‌طور که در این مثال نشان داده شده است.

## **استفاده از پر کردن‌های گرادیان یا تصویر با افکت‌های سه‌بعدی**

قالب‌بندی سه‌بعدی مستقل از پر کردن شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا تصویر را بر روی سطح جلو اعمال کنید و همچنان از همان تنظیمات دوربین، نور، ماده و برآمدگی استفاده نمایید.

این مثال یک گرادیان از آبی به نارنجی را بر روی سطح جلو و یک رنگ نارنجی تیره را بر روی برآمدگی ۱۵۰ پوینتی اعمال می‌کند. نقاط توقف گرادیان در 0 و 100 آغاز و پایان گرادیان را نشان می‌دهند. مقادیر چرخش دوربین بر حسب درجه هستند. اسلاید به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌شود:

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

خروجی رندر شده، گرادیان را بر روی سطح جلو حفظ می‌کند و برآمدگی را به‌صورت جداگانه رندر می‌کند:

![مستطیل سه‌بعدی با پر کردن گرادیان آبی‑به‑نارنجی و برآمدگی نارنجی](img_02_03.png)

برای استفاده از پر کردن تصویر، تصویر را به ارائه اضافه کنید و آن را به پر کردن شکل اختصاص دهید. این مثال نیاز به فایل موجودی به نام "image.jpg" در پوشهٔ کاری دارد. تصویر را به‌صورت کششی برای پر کردن مستطیل اعمال می‌کند، برآمدگی ۱۵۰ پوینتی را تنظیم می‌کند و چرخش دوربین را بر حسب درجه تنظیم می‌نماید. شکل در حافظه پیکربندی می‌شود بدون ذخیره یا رندر فایل:

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

تصویر بر روی سطح جلو رندر می‌شود، در حالی که برآمدگی به‌عنوان سطح جانبی سه‌بعدی رندر می‌گردد:

![مستطیل سه‌بعدی با پر کردن تصویر روی سطح جلو و برآمدگی نارنجی](img_02_04.png)

## **اعمال قالب‌بندی سه‌بعدی به متن**

قالب‌بندی سه‌بعدی شکل به بدنهٔ شکل اثر می‌گذارد. قالب‌بندی سه‌بعدی متن به فریم متن اثر می‌گذارد. این برای افکت‌های شبیه WordArt مفید است که حروف نیاز به برآمدگی، ماده، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با الگوی شبکه‌ای نارنجی‑سفید ایجاد می‌کند، یک قوس وارونی اعمال می‌کند و تنظیمات سه‌بعدی را از طریق [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/properties/threedformat) پیکربندی می‌نماید. ارتفاع برآمدگی و عمق بر حسب پوینت و چرخش نور بر حسب درجه هستند. پر کردن و خط بیرونی شکل مخفی شده‌اند تا فقط متن قابل مشاهده باشد. مثال تصویر PNG را با دو برابر ابعاد پیش‌فرض اسلاید رندر می‌کند و ارائه را به‌صورت PPTX ذخیره می‌نماید:

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

متن به‌صورت حروف 3‑بعدی منحنی و برآمده رندر می‌شود:

![متن سه‌بعدی رندر شده با تبدیل انحنا‑یی WordArt، پر کردن الگوی نارنجی و برآمدگی تیره](img_02_05.png)

## **حفظ متن صاف بر روی شکل سه‌بعدی**

برای حفظ خوانایی متن در حالی که ظاهر سه‌بعدی شکل حفظ می‌شود، از [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/keeptextflat/) از طریق [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/textframeformat/) استفاده کنید. وقتی مقدار آن `true` باشد، متن خارج از صحنهٔ سه‌بعدی می‌ماند. وقتی `false` باشد، متن در صحنه شرکت کرده و با جهت‌گیری سه‌بعدی همراه می‌شود.

این تنظیم قالب‌بندی سه‌بعدی شکل را حذف نمی‌کند: دوربین، نورپردازی، ماده و برآمدگی آن همچنان از طریق [IShape.ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/threedformat/) پیکربندی شده‌اند. همچنین متفاوت از چرخش معمولی است. [IShape.Rotation](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/rotation/) شکل را در صفحه اسلاید می‌چرخاند، در حالی که [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/rotationangle/) چرخش سفارشی متن را داخل جعبهٔ محصورکننده کنترل می‌کند. نگه داشتن متن خارج از صحنهٔ سه‌بعدی هیچ‌یک از این زاویه‌ها را بازنشانی نمی‌کند.

مثال خودکفی زیر یک مستطیل آبی با متن ایجاد می‌کند و آن را در کنار اصلی کپی می‌سازد. هر دو شکل یک قالب‌بندی سه‌بعدی یکسان دارند؛ تنها تنظیم متن متفاوت است: `false` در سمت چپ و `true` در سمت راست. زاویه‌های دوربین بر حسب درجه و ارتفاع برآمدگی ۴۰ پوینت است. مثال ارائه را به‌صورت PPTX ذخیره می‌کند و اسلاید مقایسه‌ای را به PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند.

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

در سمت چپ، متن جهت‌گیری سه‌بعدی را دنبال می‌کند. در سمت راست، متن صاف می‌ماند و خواناتر است. هر دو مستطیل همان برآمدگی و جهت‌گیری سه‌بعدی قابل مشاهده را دارند.

![مستطیل‌های سه‌بعدی کنار هم: KeepTextFlat در سمت چپ false و در سمت راست true](keep_text_flat.png)

## **رفتار صادرات و رندرینگ**

Aspose.Slides قالب‌بندی سه‌بعدی را هنگام ذخیره به فرمت‌های PowerPoint مانند PPTX حفظ می‌کند. هنگام رندر یا صادرات به فرمت‌های چیدمان ثابت، صحنهٔ سه‌بعدی به‌صورت نقطه‌نقطه یا به‌صورت تصویری دو‌بعدی در خروجی کشیده می‌شود. این امر هنگام رندر اسلایدها به [PNG](/slides/fa/net/convert-powerpoint-to-png/)، صادرات به [PDF](/slides/fa/net/convert-powerpoint-to-pdf/)، صادرات به [HTML](/slides/fa/net/convert-powerpoint-to-html/)، یا تولید فریم برای [تبدیل ویدیو](/slides/fa/net/convert-powerpoint-to-video/) صدق می‌کند.

نکات کلیدی:

- تصاویر و PDFهای صادر شده تعاملی نیستند. پس از صادرات، کاربر نمی‌تواند شیء را بچرخاند.
- ظاهر نهایی به ترکیب دوربین، نورپردازی، ماده، برآمدگی، پر کردن و مقیاس اسلاید وابسته است.
- اگر نیاز دارید مقادیر قالب‌بندی به‌دست‌آمده از وراثت یا تم را بررسی کنید، از [ویژگی‌های مؤثر شکل](/slides/fa/net/shape-effective-properties/) استفاده کنید.
- برخی فرمت‌های خروجی نمی‌توانند قالب‌بندی سه‌بعدی قابل ویرایش PowerPoint را ذخیره کنند. در این فرمت‌ها، نتیجه بصری رندر می‌شود نه اینکه به‌عنوان تنظیمات سه‌بعدی قابل ویرایش حفظ شود.

## **سؤالات متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های سه‌بعدی تعاملی ایجاد کند؟**

Aspose.Slides افکت‌های سه‌بعدی PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این کتابخانه تصاویر، PDFها یا صفحات HTML صادر شده را به صحنه‌های سه‌بعدی تعاملی تبدیل نمی‌کند که کاربر بتواند آن‌ها را بچرخاند. در PPTX، قالب‌بندی سه‌بعدی در PowerPoint به‌صورت ویرایش‌پذیر باقی می‌ماند؛ مشروط بر اینکه فرمت آن را پشتیبانی کند.

**تفاوت بین مدل سه‌بعدی و افکت سه‌بعدی چیست؟**

یک مدل سه‌بعدی یک شیء سه‌بعدی مستقل است که به ارائه اضافه می‌شود. یک افکت سه‌بعدی قالب‌بندی است که بر روی یک شکل یا متن معمولی PowerPoint اعمال می‌شود، مانند چرخش، برآمدگی، برجستگی، نورپردازی و ماده. این مقاله به افکت‌های سه‌بعدی می‌پردازد.

**کدام تنظیمات برای داشتن یک شکل سه‌بعدی قابل مشاهده لازم است؟**

حداقل باید یک چرخش دوربین و یا برآمدگی یا عمق تنظیم کنید. در عمل، تنظیم نورپردازی و ماده نیز توصیه می‌شود تا سطوح رندر شده دارای برجستگی‌ها و سایه‌های واضح باشند.

**آیا می‌توانم افکت‌های سه‌بعدی را هم به اشکال و هم به متن اعمال کنم؟**

بله. برای بدنهٔ شکل از [IShape.ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/properties/threedformat) و برای متن از [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/properties/threedformat) استفاده کنید.

**آیا افکت‌های سه‌بعدی هنگام صادرات به تصاویر، PDF، HTML یا فریم‌های ویدیو ظاهر می‌شوند؟**

بله. Aspose.Slides افکت‌های سه‌بعدی را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های استفاده‌شده برای تبدیل به ویدیو رندر می‌کند. خروجی صادر شده شامل ظاهر رندر شده است، نه یک شیء سه‌بعدی قابل ویرایش.

**آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال وراثت و تنظیمات تم بخوانم؟**

بله. از APIهای قالب‌بندی مؤثر توصیف‌شده در [ویژگی‌های مؤثر شکل](/slides/fa/net/shape-effective-properties/) استفاده کنید تا دوربین، نورپردازی، برجستگی و دیگر مقادیر سه‌بعدی نهایی را بخوانید.