---
title: ایجاد افکت‌های 3D در ارائه‌ها با استفاده از .NET
linktitle: ارائه 3D
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
description: ".NET با Aspose.Slides برای اعمال و رندر افکت‌های سه‌بعدی بر روی اشکال و متن PowerPoint. دوربین، نورپردازی، ماده، برآمدگی، پرکن‌ها و متن سه‌بعدی را پیکربندی کنید."
---
## **مرور کلی**

Aspose.Slides for .NET می‌تواند قالب‌بندی سه‌بعدی شبیه به PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله اثرات سه‌بعدی مانند چرخش، برآمدگی، لبه‌زنی، روشنایی، ماده، پرکن گرادیان یا تصویر و متن سه‌بعدی را پوشش می‌دهد.

{{% alert color="info" %}}
این مقاله دربارهٔ اثرات قالب‌بندی سه‌بعدی بر اشکال و متن‌های PowerPoint است. دربارهٔ افزودن یا ویرایش فایل‌های مدل سه‌بعدی جداگانه نیست. وقتی یک اسلاید را به تصویر، PDF یا HTML صادر می‌کنید، Aspose.Slides آن اثرات سه‌بعدی را در خروجی دو‌بعدی رندر می‌کند.
{{% /alert %}}

## **مفاهیم قالب‌بندی 3D**

از ویژگی [IShape.ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/properties/threedformat) برای اعمال قالب‌بندی سه‌بعدی بر یک شکل استفاده کنید. این ویژگی [IThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat) را در دسترس می‌گذارد که صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از ویژگی [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/properties/threedformat) استفاده کنید. این ویژگی قالب‌بندی سه‌بعدی را بر فریم متن به‌جای بدنهٔ شکل اعمال می‌نماید.

مهم‌ترین ویژگی‌ها عبارتند از:

| ویژگی | چه چیزی را کنترل می‌کند | کی استفاده شود |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/camera) | نقطهٔ دید، نوع دوربین پیش‌فرض، چرخش، زوم و پرسپکتیو. | برای چرخاندن شیء در فضای سه‌بعدی یا مطابقت با یک پیش‌تنظیم چرخش PowerPoint استفاده شود. |
| [LightRig](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/lightrig) | پیش‌تنظیم نور، جهت و چرخش نور. | برای تغییر ظاهر برجستگی‌ها و سایه‌ها بر سطح سه‌بعدی. |
| [Material](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/material) | مادهٔ سطح، مانند صاف، مات، پلاستیک یا فلز. | برای اینکه یک هندسهٔ مشابه صاف‌تر، نرم‌تر، براق یا فلزی به‌نظر برسد. |
| [ExtrusionHeight](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/extrusionheight) | فاصله‌ای که شکل از سطح جلویی خود به عقب گسترش می‌یابد. | تبدیل یک شکل صاف به یک شیء سه‌بعدی واضحاً ضخیم. |
| [ExtrusionColor](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/extrusioncolor) | رنگ وجه‌های برآمده. | برای مشاهده عمق یا هماهنگ‌سازی رنگ جانبی با پرکن جلویی. |
| [Depth](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/depth) | عمق سه‌بعدی اضافه‌ای که PowerPoint از آن استفاده می‌کند. | تنظیم دقیق عمق برای اشکال یا متن، به‌ویژه همراه با تنظیمات لبه‌زنی و ماده. |
| [BevelTop](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/beveltop) و [BevelBottom](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/bevelbottom) | لبه‌های برجسته یا گرد بر سطح جلویی و عقب. | افزودن لبهٔ نرم‌شده یا قالب‌دار به‌جای سطح صاف و تیز. |
| [ContourColor](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/contourcolor) و [ContourWidth](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/contourwidth) | خط مرزی اطراف شیء سه‌بعدی. | برجسته‌سازی مرز شیء در خروجی رندر شده. |

## **ایجاد یک شکل 3D**

یک شکل معمولاً قبل از اینکه به‌طور قابل‌قانع‌کننده‌ای سه‌بعدی به‌نظر برسد، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، چون نمای پیش‌فرض ممکن است برآمدگی را مخفی کند.
- تنظیمات نور، چون نورپردازی باعث قابل‌خواندن شدن وجه‌ها و کناره‌ها می‌شود.
- تنظیمات ماده، چون سطح بر نحوهٔ رندر نور تأثیر می‌گذارد.
- تنظیمات برآمدگی یا عمق، چون یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌نماید، قالب‌بندی سه‌بعدی را اعمال می‌کند، ارائه را به‌صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌نماید.

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

تصویر رندر شده اسلاید، مستطیل را به‌صورت یک بلوک ضخیم سه‌بعدی نشان می‌دهد:

![مستطیل 3D آبی رندر شده با متن 3D سفید روی سطح جلویی](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از پنل 3‑D Rotation پیکربندی می‌شود. مقادیر چرخش X، Y و Z متناظر با چرخشی هستند که از طریق API دوربین تنظیم می‌کنید.

![پنل 3‑D Rotation در PowerPoint با مقادیر چرخش X، Y و Z هایلایت شده](img_02_01.png)

در Aspose.Slides، نوع دوربین و چرخش را از طریق [IThreeDFormat.Camera](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/camera) تنظیم کنید:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

از دوربین زمانی استفاده کنید که نیاز به تغییر نحوهٔ مشاهدهٔ شیء توسط کاربر داشته باشید. این تنظیم، هندسهٔ دو‌بعدی شکل را در اسلاید تغییر نمی‌دهد؛ بلکه نقطهٔ دید سه‌بعدی مورد استفاده PowerPoint و Aspose.Slides هنگام رندر را تغییر می‌دهد.

## **افزودن برآمدگی و عمق**

برآمدگی باعث می‌شود شکل به‌صورت ضخیم دیده شود زیرا به پشت سطح جلویی گسترش می‌یابد. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ رنگ جانب‌ها را تعیین می‌نماید.

![کنترل‌های عمق در PowerPoint که به ویژگی‌های رنگ برآمدگی و ارتفاع برآمدگی نگاشته می‌شوند](img_02_02.png)

برای تنظیم ضخامت، از [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/extrusionheight) و برای رنگ جانبی، از [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/extrusioncolor) استفاده کنید:

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

از [IThreeDFormat.Depth](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/properties/depth) زمانی استفاده کنید که نیاز به کار مستقیم با مقدار عمق PowerPoint دارید یا عمق را همراه با لبه‌زنی، ماده و اثرات متن ترکیب می‌کنید. در بسیاری از سناریوهای شکل، `ExtrusionHeight` تنظیم واضح‌تری است چون مستقیماً برآمدگی قابل مشاهده را بیان می‌کند.

## **استفاده از پرکن‌های گرادیان یا تصویر با اثرات 3D**

قالب‌بندی سه‌بعدی مستقل از پرکن شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا پرکن تصویر را بر سطح جلویی اعمال کنید و همچنان از همان تنظیمات دوربین، نور، ماده و برآمدگی استفاده کنید.

مثال زیر یک پرکن گرادیان را بر شکل اعمال می‌کند و رنگ برآمدگی جانبی را تیره‌تر می‌سازد:

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

خروجی رندر شده، گرادیان را بر سطح جلویی نگه می‌دارد و برآمدگی را به‌طور جداگانه رندر می‌کند:

![مستطیل 3D رندر شده با پرکن گرادیان آبی‑به‑نارنجی و برآمدگی نارنجی](img_02_03.png)

برای استفاده از پرکن تصویر، تصویر را به ارائه اضافه کنید و آن را به پرکن شکل اختصاص دهید:

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

تصویر بر روی سطح جلویی رندر می‌شود، در حالی که برآمدگی به‌عنوان سطح جانبی سه‌بعدی رندر می‌گردد:

![مستطیل 3D رندر شده با پرکن عکس روی سطح جلویی و برآمدگی نارنجی](img_02_04.png)

## **اعمال قالب‌بندی 3D بر متن**

قالب‌بندی سه‌بعدی شکل بر بدنهٔ شکل تأثیر می‌گذارد. قالب‌بندی سه‌بعدی متن بر فریم متن اعمال می‌شود. این برای اثرات شبیه به WordArt مفید است که حروف خود نیاز به برآمدگی، ماده، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با پرکن الگو ایجاد می‌کند، تبدیل WordArt را اعمال می‌کند و تنظیمات 3D را بر [ITextFrameFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat) پیکربندی می‌نماید:

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

متن به‌صورت حروف خمیده و برآمده سه‌بعدی رندر می‌شود:

![متن 3D رندر شده با تبدیل WordArt قوسی، پرکن الگو نارنجی و برآمدگی تیره](img_02_05.png)

## **رفتار صادرات و رندرینگ**

Aspose.Slides قالب‌بندی سه‌بعدی را هنگام ذخیره در قالب‌های PowerPoint مانند PPTX حفظ می‌کند. هنگام رندر یا صادرات به قالب‌های ثابت‑صفحه، صحنهٔ سه‌بعدی به‌صورت raster یا به‌صورت خروجی دو‌بعدی کشیده می‌شود. این موضوع برای رندر اسلایدها به [PNG](/slides/fa/net/convert-powerpoint-to-png/)، صادرات به [PDF](/slides/fa/net/convert-powerpoint-to-pdf/)، صادرات به [HTML](/slides/fa/net/convert-powerpoint-to-html/) یا تولید فریم‌ها برای [video conversion](/slides/fa/net/convert-powerpoint-to-video/) صادق است.

نکات مهم:

- تصاویر و PDF‌های صادراتی تعاملی نیستند. پس از صادرات، کاربر نمی‌تواند شیء را بچرخاند.
- ظاهر نهایی به ترکیب دوربین، نور، ماده، برآمدگی، پرکن و مقیاس اسلاید بستگی دارد.
- اگر نیاز به بررسی مقادیر قالب‌بندی ارث‌بری یا مبتنی بر تم دارید، APIهای **effective shape properties** را مطالعه کنید.
- برخی قالب‌های خروجی نمی‌توانند قالب‌بندی سه‌بعدی قابل ویرایش PowerPoint را ذخیره کنند. در این قالب‌ها، نتیجهٔ بصری رندر شده است نه تنظیمات سه‌بعدی قابل ویرایش.

## **سوالات متداول**

### آیا Aspose.Slides می‌تواند ارائه‌های تعاملی 3D ایجاد کند؟

Aspose.Slides اثرات 3D PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. اما تصاویر، PDFها یا صفحات HTML صادر شده را به صحنه‌های 3D تعاملی تبدیل نمی‌کند که کاربر بتواند آن‌ها را بچرخاند. در PPTX، قالب‌بندی 3D در PowerPoint ویرایش‌پذیر می‌ماند زمانی که فرمت آن را پشتیبانی می‌کند.

### تفاوت بین یک مدل 3D و یک اثر 3D چیست؟

یک مدل 3D یک شیء سه‌بعدی جداگانه است که به ارائه اضافه می‌شود. یک اثر 3D قالب‌بندی‌ای است که بر یک شکل یا متن معمولی PowerPoint اعمال می‌شود، مانند چرخش، برآمدگی، لبه‌زنی، نورپردازی و ماده. این مقاله به اثرات 3D می‌پردازد.

### کدام تنظیمات برای مشاهده یک شکل 3D ضروری هستند؟

حداقل باید یک چرخش دوربین و یا برآمدگی یا عمق تنظیم شود. در عمل، تنظیم یک نور و ماده نیز توصیه می‌شود تا وجه‌های رندر شده روشنایی و سایه واضحی داشته باشند.

### آیا می‌توانم اثرات 3D را هم بر اشکال و هم بر متن اعمال کنم؟

بله. برای بدنهٔ شکل از [IShape.ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/properties/threedformat) و برای متن از [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/properties/threedformat) استفاده کنید.

### آیا اثرات 3D هنگام صادرات به تصاویر، PDF، HTML یا فریم‌های ویدئو ظاهر می‌شوند؟

بله. Aspose.Slides اثرات 3D را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های استفاده‌شده برای تبدیل به ویدئو رندر می‌کند. خروجی صادر شده شامل ظاهر رندر شده است، نه یک شیء 3D قابل ویرایش.

### آیا می‌توانم مقادیر نهایی 3D را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟

بله. از APIهای قالب‌بندی مؤثر توضیح داده‌شده در [Shape Effective Properties](/slides/fa/net/shape-effective-properties/) برای خواندن دوربین، نور، لبه‌زنی و مقادیر 3D مرتبط نهایی استفاده کنید.