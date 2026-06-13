---
title: ایجاد اثرات سه‌بعدی در ارائه‌ها با استفاده از .NET
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
description: "اثرات سه‌بعدی را برای اشکال و متن PowerPoint در .NET با Aspose.Slides اعمال و رندر کنید. دوربین، نورپردازی، مواد، برآمدگی، پرکردن‌ها و متن سه‌بعدی را پیکربندی کنید."
---
## **نمای کلی**

Aspose.Slides برای .NET می‌تواند قالب‌بندی سه‌بعدی شبیه به PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله به اثرات سه‌بعدی نظیر چرخش، برآمدگی (Extrusion)، گوشه‌دار (Bevel)، نورپردازی، مواد، پرکردن گرادیان یا تصویر، و متن سه‌بعدی می‌پردازد.

{{% alert color="primary" %}}
این مقاله دربارهٔ اثرات قالب‌بندی سه‌بعدی بر اشکال و متن در PowerPoint است. منظور از افزودن یا ویرایش فایل‌های مدل سه‌بعدی مستقل نیست. وقتی یک اسلاید را به تصویر، PDF یا HTML صادر می‌کنید، Aspose.Slides این اثرات سه‌بعدی را به خروجی دو‑بعدی صادرشده رندر می‌کند.
{{% /alert %}}

## **مفاهیم قالب‌بندی سه‌بعدی**

از ویژگی [IShape.ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/properties/threedformat) برای اعمال قالب‌بندی سه‌بعدی به یک شکل استفاده کنید. این ویژگی شیء [IThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat) را در اختیار می‌گذارد که صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از ویژگی [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/properties/threedformat) استفاده کنید. این ویژگی قالب‌بندی سه‌بعدی را به فریم متن اعمال می‌کند نه به بدنهٔ شکل.

مهم‌ترین ویژگی‌ها عبارتند از:

| Property | What it controls | When to use it |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/camera) | نقطه دید، نوع دوربین پیش‌تنظیم‌شده، چرخش، زوم و پرسپکتیو. | برای چرخش شیء در فضای سه‌بعدی یا تطبیق با یک پیش‌تنظیم چرخش سه‌بعدی PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/lightrig) | پیش‌تنظیم نور، جهت و چرخش نور. | برای تغییر ظاهر نقاط برجسته و سایه‌ها بر سطح سه‌بعدی. |
| [Material](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/material) | مواد سطح، مانند صاف، مات، پلاستیک یا فلز. | برای اینکه همان هندسه به شکل صاف‌تر، نرم‌تر، براق یا فلزی به نظر برسد. |
| [ExtrusionHeight](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/extrusionheight) | فاصله‌ای که شکل از صفحه جلو به عقب امتداد می‌یابد. | تبدیل یک شکل صاف به یک شیء سه‌بعدی به‌وضوح ضخیم. |
| [ExtrusionColor](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/extrusioncolor) | رنگ اضلاع برآمده. | ظاهر کردن عمق یا هماهنگ‌سازی رنگ اضلاع با پرکردن جلو. |
| [Depth](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/depth) | عمق سه‌بعدی اضافی که PowerPoint برای قالب‌بندی سه‌بعدی استفاده می‌کند. | تنظیم دقیق عمق برای اشکال یا متن، به‌ویژه همراه با تنظیمات گوشه‌دار و مواد. |
| [BevelTop](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/beveltop) و [BevelBottom](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/bevelbottom) | اضلاع برجسته یا گرد شده در سطوح جلو و پشت. | افزودن لبهٔ نرم یا قالب‌دار به‌جای یک سطح صاف و تیز. |
| [ContourColor](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/contourcolor) و [ContourWidth](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/contourwidth) | خط دور شیء سه‌بعدی. | برجسته‌سازی مرز شیء در خروجی رندر شده. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً برای داشتن ظاهر معتبر سه‌بعدی به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، چون نمای پیش‌فرض ممکن است برآمدگی را پنهان کند.
- تنظیمات نور، چون نورپردازی باعث خوانایی وجه‌ها و اضلاع می‌شود.
- تنظیمات مواد، چون سطح تأثیر می‌گذارد که نور چگونه درخشیده شود.
- تنظیمات برآمدگی یا عمق، چون یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متنی به سطح جلو اضافه می‌گیرد، قالب‌بندی سه‌بعدی اعمال می‌کند، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌نماید.

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

تصویر رندر شدهٔ اسلاید، مستطیل را به‌صورت یک بلوک سه‌بعدی ضخیم نشان می‌دهد:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از پانل 3‑D Rotation تنظیم می‌شود. مقادیر چرخش X، Y و Z متناظر با چرخشی هستند که از طریق API دوربین تنظیم می‌کنید.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

در Aspose.Slides، نوع دوربین و چرخش را از طریق [IThreeDFormat.Camera](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/camera) تنظیم کنید:

```csharp
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

از دوربین زمانی استفاده کنید که لازم باشد نحوهٔ دیدن شیء توسط بیننده تغییر کند. این کار هندسهٔ دو‑بعدی شکل روی اسلاید را تغییر نمی‌دهد؛ تنها نقطهٔ مشاهدهٔ سه‌بعدی PowerPoint و Aspose.Slides در زمان رندر را تغییر می‌دهد.

## **افزودن برآمدگی و عمق**

برآمدگی باعث می‌شود یک شکل به‌نظر ضخیم برسد با این‌که به پشت سطح جلو گسترش پیدا کند. در PowerPoint، کنترل عمق این ضخامت قابل رؤیت را تنظیم می‌کند و کنترل رنگ رنگ اضلاع جانبی را تعیین می‌کند.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

برای ضخامت، [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/extrusionheight) و برای رنگ جانبی، [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/extrusioncolor) را تنظیم کنید:

```csharp
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

از [IThreeDFormat.Depth](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/depth) زمانی استفاده کنید که نیاز به کار مستقیم با مقدار عمق PowerPoint دارید یا می‌خواهید عمق را با گوشه‌دار، مواد و اثرات متنی ترکیب کنید. در بسیاری از سناریوهای شکل، `ExtrusionHeight` تنظیم واضح‌تری است زیرا مستقیماً ضخامت قابل رؤیت را بیان می‌کند.

## **استفاده از پرکردن گرادیان یا تصویر همراه با اثرات سه‌بعدی**

قالب‌بندی سه‌بعدی مستقل از پرکردن شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا تصویر را به سطح جلو اعمال کنید و همچنان از همان تنظیمات دوربین، نور، مواد و برآمدگی استفاده کنید.

این مثال یک پرکردن گرادیان به شکل می‌افزاید و رنگ برآمدگی جانبی را تیره‌تر می‌کند:

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

خروجی رندر شده گرادیان را بر روی سطح جلو حفظ می‌کند و برآمدگی را به‌صورت جداگانه رندر می‌کند:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

برای استفاده از پرکردن تصویر، تصویر را به ارائه اضافه کنید و به پرکردن شکل اختصاص دهید:

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

تصویر بر روی سطح جلو رندر می‌شود، در حالی که برآمدگی به‌عنوان سطح جانبی سه‌بعدی رندر می‌شود:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **اعمال قالب‌بندی سه‌بعدی بر متن**

قالب‌بندی سه‌بعدی شکل بر بدنهٔ شکل تأثیر می‌گذارد. قالب‌بندی سه‌بعدی متن بر فریم متن اثر می‌گذارد. این مورد برای افکت‌های شبیه WordArt مفید است که حروف خود نیاز به برآمدگی، مواد، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با پرکردن الگو ایجاد می‌کند، تبدیل WordArt را اعمال می‌کند و تنظیمات سه‌بعدی را بر [ITextFrameFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat) پیکربندی می‌کند:

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

متن به‌صورت حروف منحنی و برآمدهٔ سه‌بعدی رندر می‌شود:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **رفتار صادر کردن و رندرینگ**

Aspose.Slides هنگام ذخیره به قالب‌های PowerPoint مانند PPTX قالب‌بندی سه‌بعدی را حفظ می‌کند. هنگام رندر یا صادر کردن به قالب‌های ثابت‑صفحه، صحنهٔ سه‌بعدی به‌صورت تصویر پیکسل یا نقاشی به خروجی دو‑بعدی تبدیل می‌شود. این مورد برای رندر اسلایدها به [PNG](/slides/fa/net/convert-powerpoint-to-png/)، صادر کردن به [PDF](/slides/fa/net/convert-powerpoint-to-pdf/)، صادر کردن به [HTML](/slides/fa/net/convert-powerpoint-to-html/)، یا تولید فریم برای [تبدیل به ویدیو](/slides/fa/net/convert-powerpoint-to-video/) اعمال می‌شود.

نکات مهم:

- تصاویر و PDFهای صادرشده تعاملی نیستند. پس از صادرات شیء قابل چرخش توسط بیننده نیست.
- ظاهر نهایی به ترکیب دوربین، نورپردازی، مواد، برآمدگی، پرکردن و مقیاس اسلاید وابسته است.
- اگر نیاز به بررسی مقادیر قالب‌بندی وارثتی یا مبتنی بر تم دارید، APIهای ویژگی‌های مؤثر شکل را مطالعه کنید: [effective shape properties](/slides/fa/net/shape-effective-properties/).
- برخی قالب‌های خروجی نمی‌توانند قالب‌بندی سه‌بعدی قابل ویرایش PowerPoint را ذخیره کنند. در این قالب‌ها، نتیجهٔ بصری رندر می‌شود نه این‌که به‌عنوان تنظیمات سه‌بعدی قابل ویرایش حفظ شود.

## **سوالات متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های سه‌بعدی تعاملی ایجاد کند؟**

Aspose.Slides اثرات سه‌بعدی PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این کتابخانه تصاویر، PDF یا صفحات HTML صادرشده را به صحنه‌های سه‌بعدی تعاملی که کاربر بتواند بچرخاند، تبدیل نمی‌کند. در PPTX، قالب‌بندی سه‌بعدی در PowerPoint که از این قالب پشتیبانی می‌کند، به‌صورت قابل ویرایش می‌ماند.

**تفاوت بین یک مدل سه‌بعدی و یک اثر سه‌بعدی چیست؟**

یک مدل سه‌بعدی شیء مستقل است که به ارائه اضافه می‌شود. یک اثر سه‌بعدی قالب‌بندی‌ای است که بر یک شکل یا متن معمولی PowerPoint اعمال می‌شود، مانند چرخش، برآمدگی، گوشه‌دار، نورپردازی و مواد. این مقاله به اثرات سه‌بعدی می‌پردازد.

**کدام تنظیمات برای مشاهدهٔ یک شکل سه‌بعدی ضروری هستند؟**

حداقل باید یک چرخش دوربین و یا برآمدگی یا عمق تنظیم شود. در عمل، همچنین تنظیم یک نورپردازی و ماده توصیه می‌شود تا سطوح رندر شده نکات برجسته و سایه واضح داشته باشند.

**آیا می‌توانم اثرات سه‌بعدی را هم بر اشکال و هم بر متن اعمال کنم؟**

بله. برای بدنهٔ شکل از [IShape.ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/properties/threedformat) و برای متن از [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/properties/threedformat) استفاده کنید.

**آیا اثرات سه‌بعدی هنگام صادر کردن به تصاویر، PDF، HTML یا فریم‌های ویدیو ظاهر می‌شوند؟**

بله. Aspose.Slides هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های مورد استفاده برای تبدیل به ویدیو، اثرات سه‌بعدی را رندر می‌کند. خروجی صادرشده شامل ظاهر رندر شده است، نه یک شیء سه‌بعدی قابل ویرایش.

**آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟**

بله. از APIهای قالب‌بندی مؤثر که در [Shape Effective Properties](/slides/fa/net/shape-effective-properties/) توضیح داده شده است استفاده کنید تا دوربین، نورپردازی، گوشه‌دار و مقادیر سه‌بعدی مرتبط نهایی را بخوانید.