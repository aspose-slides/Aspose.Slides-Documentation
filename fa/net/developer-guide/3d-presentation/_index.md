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
- برجستگی سه‌بعدی
- گرادیان سه‌بعدی
- متن سه‌بعدی
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "اعمال و رندر افکت‌های سه‌بعدی برای اشکال و متون PowerPoint در .NET با Aspose.Slides. تنظیم دوربین، نورپردازی، ماده، برجستگی، پرکردن‌ها و متن سه‌بعدی."
---
## **بررسی کلی**

Aspose.Slides for .NET می‌تواند فرمت‌بندی سه‌بعدی سبک PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله به افکت‌های سه‌بعدی مانند چرخش، برجستگی، لبه‌دارها، نورپردازی، مواد، پرکردن‌های گرادیان یا تصویر، و متن سه‌بعدی می‌پردازد.

{{% alert color="info" title="Note" %}}
این مقاله دربارهٔ افکت‌های فرمت‌بندی سه‌بعدی روی اشکال و متن‌های PowerPoint است. این دربارهٔ درج یا ویرایش فایل‌های مدل سه‌بعدی مستقل نیست. هنگامی که یک اسلاید را به تصویر، PDF یا HTML صادر می‌کنید، Aspose.Slides آن افکت‌های سه‌بعدی را به خروجی دو‑بعدی صادرشده رندر می‌کند.
{{% /alert %}}

## **مفاهیم فرمت‌بندی سه‌بعدی**

از ویژگی [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) برای اعمال فرمت‌بندی سه‌بعدی بر روی یک شکل استفاده کنید. این ویژگی [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat) را باز می‌کند که صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از ویژگی [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) استفاده کنید. این ویژگی فرمت‌بندی سه‌بعدی را به فریم متن اعمال می‌کند نه به بدنهٔ شکل.

مهم‌ترین ویژگی‌ها عبارتند از:

| ویژگی | چه چیزی را کنترل می‌کند | زمان استفاده |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) | نقطهٔ دید، نوع دوربین پیش‌تنظیم‌شده، چرخش، زوم و پرسپکتیو. | چرخاندن شیء در فضای سه‌بعدی یا مطابقت با یک پیش‌تنظیم چرخش سه‌بعدی PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig) | پیش‌تنظیم نور، جهت و چرخش نور. | تغییر ظاهرهای برجسته و سایه‌ها بر روی سطح سه‌بعدی. |
| [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material) | جنس سطح، مانند صاف، مات، پلاستیک یا فلز. | یک ژئومتری یکسان را صاف‌تر، نرم‌تر، براق یا فلزی نشان دهد. |
| [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) | چقدر شکل از سطح جلو به سمت عقب گسترش می‌یابد. | یک شکل صاف را به یک شیء سه‌بعدی واضحاً ضخیم تبدیل کنید. |
| [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) | رنگ طرف‌های برجسته‌شده. | عمق را قابل مشاهده کنید یا رنگ طرف‌ها را با پر کردن جلو هماهنگ کنید. |
| [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) | عمق سه‌بعدی اضافی که توسط فرمت‌بندی سه‌بعدی PowerPoint استفاده می‌شود. | تنظیم دقیق عمق برای اشکال یا متن، به‌ویژه همراه با تنظیمات لبه و ماده. |
| [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop) و [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) | لبه‌های برجسته یا گرد شده روی سطح‌های جلو و پشت. | یک لبهٔ نرم یا قالب‌دار اضافه کنید به‌جای یک سطح صاف تیز. |
| [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) و [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth) | خط‌چینی دور شیء سه‌بعدی. | مرز شیء را در خروجی رندر شده برجسته کنید. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً قبل از اینکه واقعاً سه‌بعدی به نظر برسد، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض جلو ممکن است برجستگی را پنهان کند.  
- تنظیمات نور، زیرا نورپردازی باعث قابل‌خواندن شدن سطح‌ها و کناره‌ها می‌شود.  
- تنظیمات ماده، زیرا سطح نحوهٔ رندر نور را تحت تاثیر قرار می‌دهد.  
- تنظیمات برجستگی یا عمق، زیرا یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلو اضافه می‌کند و فرمت‌بندی سه‌بعدی اعمال می‌نماید. مقدارهای چرخش دوربین بر حسب درجه هستند و ارتفاع برجستگی ۱۰۰ پوینت است. مثال اسلاید را به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند و ارائه را به صورت PPTX ذخیره می‌نماید.

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

خروجی رندر شده نشان می‌دهد مستطیل به‌صورت بلوک ضخیم سه‌بعدی نمایش داده می‌شود:

![مستطیل سه‌بعدی آبی رندر شده با متن سه‌بعدی سفید روی سطح جلو](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از طریق پنل 3‑D Rotation تنظیم می‌شود. مقادیر چرخش X، Y و Z با چرخشی که از طریق API دوربین تنظیم می‌کنید، مطابقت دارد.

![پنل چرخش 3‑D PowerPoint با برجسته‌سازی مقادیر چرخش X، Y و Z](img_02_01.png)

در Aspose.Slides، دوربین را از طریق [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) دسترسی پیدا می‌کنید. این مثال یک مستطیل می‌سازد، نمای جلوی ارتوگرافیک را انتخاب می‌کند و چرخش‌های X، Y و Z آن را به ترتیب ۲۰، ۳۰ و ۴۰ درجه تنظیم می‌کند. شکل در حافظه پیکربندی می‌شود بدون اینکه فایلی ذخیره شود:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

از دوربین زمانی استفاده کنید که نیاز دارید نحوهٔ دیدن شیء توسط بیننده را تغییر دهید. این کار هندسهٔ ۲بعدی شکل روی اسلاید را عوض نمی‌کند؛ بلکه نقطهٔ دید سه‌بعدی که PowerPoint و Aspose.Slides هنگام رندر استفاده می‌کنند را تغییر می‌دهد.

### **کپی جهت‌گیری دوربین از یک شکل قالب**

برای تطبیق یک شکل در قالب، پیش‌تنظیم [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) آن را کپی کنید و زاویه‌های آن را با [GetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/getrotation/) بخوانید. مثال فایل `template.pptx` را باز می‌کند، دوربین اولین شکل در اولین اسلاید را می‌خواند و جهت‌گیری آن را به شکل دوم اعمال می‌کند. هر دو شکل قبلاً نورپردازی سه‌بعدی دارند و شکل دوم چرخش دوربین صریحی ندارند.

زاویه‌ها بر حسب درجه هستند. ایندکس `0` عرض جغرافیایی، ایندکس `1` طول جغرافیایی و ایندکس `2` دوران را نشان می‌دهند. این مقادیر را به ترتیب به [SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) منتقل کنید. اگر منبع `null` برگرداند، چرخش صریحی ندارد، بنابراین زاویه‌های شکل دوم تنظیم نمی‌شوند. چرخش صریح `(0, 0, 0)` سه صفر بازمی‌گرداند و باید کپی شود.

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

زمانی که `camera-copy.pptx` را دوباره باز می‌کنید، دو شکل همان پیش‌تنظیم و چرخش دوربین را دارند. در PowerPoint، پیکان سمت راست از جهت‌گیری دوربین کپی‌شده از مستطیل سمت چپ استفاده می‌کند. هر دو شکل نورپردازی و عمق برجستگی یکسانی دارند.

![مستطیل سه‌بعدی آبی و یک پیکان راست با جهت‌گیری دوربین هم‌خوان، مشاهده‌شده از بالا و سمت راست](camera-orientation.png)

## **افزودن برجستگی و عمق**

برجستگی باعث می‌شود یک شکل ضخیم به نظر برسد با گسترش به پشت سطح جلو. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ رنگ طرف‌های کناری را تعیین می‌کند.

![کنترل‌های عمق PowerPoint که به رنگ برجستگی و ویژگی‌های ارتفاع برجستگی نگاشت شده‌اند](img_02_02.png)

برای ضخامت، [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) را تنظیم کنید و برای رنگ کناره‌ها [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) را تعیین کنید. این مثال به مستطیل برجستگی ۱۰۰ پوینت با طرف‌های بنفش می‌دهد و دوربین را برای نشان دادن ضخامت می‌چرخاند. شکل در حافظه پیکربندی می‌شود بدون ذخیرهٔ فایل:

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

ویژگی [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) عمق یک شکل سه‌بعدی را تنظیم می‌کند. ویژگی [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) ارتفاع اثر برجستگی را کنترل می‌کند، همان‌طور که در این مثال نشان داده شده است.

## **استفاده از پرکردن‌های گرادیان یا تصویر با افکت‌های سه‌بعدی**

فرمت‌بندی سه‌بعدی مستقل از پرکردن شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا پرکردن تصویری را به سطح جلو اعمال کنید و همچنان از همان دوربین، نور، ماده و تنظیمات برجستگی استفاده کنید.

این مثال یک گرادیان آبی‑به‑نارنجی را بر روی سطح جلو اعمال می‌کند و رنگ کناره‌های برجستگی ۱۵۰ پوینت را به رنگ نارنجی تیره تنظیم می‌کند. نقاط توقف گرادیان در ۰ و ۱۰۰ شروع و پایان گرادیان را مشخص می‌کنند. مقادیر چرخش دوربین بر حسب درجه هستند. اسلاید به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌شود:

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

خروجی رندر شده گرادیان را بر روی سطح جلو حفظ می‌کند و برجستگی را به‌صورت جداگانه رندر می‌نماید:

![مستطیل سه‌بعدی رندر شده با پرکردن گرادیان آبی‑به‑نارنجی و برجستگی نارنجی](img_02_03.png)

برای استفاده از پرکردن تصویری، تصویر را به ارائه اضافه کنید و به پرکردن شکل اختصاص دهید. این مثال به فایلی به نام `image.jpg` در مسیر کاری نیاز دارد. تصویر را برای پر کردن مستطیل کش می‌کند، برجستگی ۱۵۰ پوینت اعمال می‌کند و چرخش دوربین را بر حسب درجه تنظیم می‌کند. شکل در حافظه پیکربندی می‌شود بدون ذخیره یا رندر فایل:

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

![مستطیل سه‌بعدی رندر شده با پرکردن عکس بر روی سطح جلو و برجستگی نارنجی](img_02_04.png)

## **اعمال فرمت‌بندی سه‌بعدی بر روی متن**

فرمت‌بندی سه‌بعدی شکل بر بدنهٔ شکل اثر می‌گذارد. فرمت‌بندی سه‌بعدی متن بر فریم متن تأثیر می‌کند. این برای افکت‌های مشابه WordArt مفید است که حروف نیاز به برجستگی، ماده، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با الگوی مشبک نارنجی‑و‑سفید ایجاد می‌کند، قوس upward اعمال می‌کند و تنظیمات سه‌بعدی را از طریق [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) پیکربندی می‌کند. ارتفاع و عمق برجستگی بر حسب پوینت و چرخش نور بر حسب درجه است. پرکردن و خط‌مرز شکل مخفی هستند تا فقط متن قابل مشاهده باشد. مثال تصویر PNG را با دو برابر ابعاد پیش‌فرض اسلاید رندر می‌کند و ارائه را به صورت PPTX ذخیره می‌کند:

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

![متن سه‌بعدی رندر شده با تبدیل WordArt منحنی، پرکردن الگوی نارنجی و برجستگی تاریک](img_02_05.png)

## **متن را روی شکل سه‌بعدی صاف نگه‌دارید**

برای قابل‌خواندن نگه داشتن متن در حالی که ظاهر سه‌بعدی شکل حفظ می‌شود، [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/keeptextflat/) را از طریق [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframe/textframeformat/) تنظیم کنید. وقتی مقدار `true` باشد، متن خارج از صحنهٔ سه‌بعدی می‌ماند. وقتی `false` باشد، متن در صحنه مشارکت می‌کند و جهت‌گیری سه‌بعدی آن را دنبال می‌کند.

این تنظیم فرمت‌بندی سه‌بعدی شکل را حذف نمی‌کند: دوربین، نورپردازی، ماده و برجستگی آن همچنان از طریق [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) پیکربندی شده‌اند. همچنین متفاوت از چرخش عادی است. [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) شکل را در صفحهٔ اسلاید می‌چرخاند، در حالی که [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) چرخش سفارشی متن را در داخل جعبه مرزی کنترل می‌کند. نگه‌داشتن متن خارج از صحنهٔ سه‌بعدی هیچ‌یک از این زاویه‌ها را بازنشانی نمی‌کند.

مثال زیر یک مستطیل آبی با متن ایجاد می‌کند و آن را در کنارهٔ اصل کپی می‌کند. هر دو شکل همان فرمت‌بندی سه‌بعدی را دارند؛ فقط تنظیم متن متفاوت است: `false` در سمت چپ و `true` در سمت راست. زاویه‌های دوربین بر حسب درجه هستند و ارتفاع برجستگی ۴۰ پوینت است. مثال ارائه را به صورت PPTX ذخیره می‌کند و اسلاید مقایسه‌ای را به PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند:

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

![مستطیل‌های سه‌بعدی کنار هم: KeepTextFlat در سمت چپ false و در سمت راست true](keep_text_flat.png)

## **رفتار صادرات و رندر**

Aspose.Slides فرمت‌بندی سه‌بعدی را هنگام ذخیره به قالب‌های PowerPoint مانند PPTX حفظ می‌کند. هنگام رندر یا صادرات به قالب‌های ثابت‑صفحه، صحنهٔ سه‌بعدی به صورت رستر یا کشیده‌شده به خروجی به عنوان نتیجهٔ دو‑بعدی تبدیل می‌شود. این هنگام رندر اسلایدها به [PNG](/slides/fa/net/convert-powerpoint-to-png/)، صادرات به [PDF](/slides/fa/net/convert-powerpoint-to-pdf/)، صادرات به [HTML](/slides/fa/net/convert-powerpoint-to-html/)، یا تولید فریم برای [video conversion](/slides/fa/net/convert-powerpoint-to-video/) صادق است.

- تصاویر و PDFهای صادرشده تعاملی نیستند. پس از صادرات، نمی‌توان شیء را توسط بیننده چرخاند.  
- ظاهر نهایی به ترکیب دوربین، نورپردازی، ماده، برجستگی، پرکردن و مقیاس اسلاید بستگی دارد.  
- اگر نیاز به بررسی مقادیر فرمت‌بندی ارث‌بری یا مبتنی بر تم دارید، [ویژگی‌های مؤثر شکل](/slides/fa/net/shape-effective-properties/) را بخوانید.  
- برخی قالب‌های خروجی نمی‌توانند فرمت‌بندی سه‌بعدی قابل ویرایش PowerPoint را ذخیره کنند. در آن قالب‌ها، نتیجهٔ بصری رندر می‌شود نه اینکه به عنوان تنظیمات سه‌بعدی قابل ویرایش حفظ شود.

## **سوالات متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های سه‌بعدی تعاملی ایجاد کند؟**

Aspose.Slides افکت‌های سه‌بعدی PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این ابزار تصاویر، PDFها یا صفحات HTML صادرشده را به صحنه‌های سه‌بعدی تعاملی که بیننده می‌تواند آنها را بچرخاند، تبدیل نمی‌کند. در PPTX، فرمت‌بندی سه‌بعدی در PowerPoint ویرایش‌پذیر می‌ماند هرجا که قالب از آن پشتیبانی کند.

**تفاوت بین مدل سه‌بعدی و افکت سه‌بعدی چیست؟**

یک مدل سه‌بعدی یک شیء سه‌بعدی جداگانه است که داخل ارائه وارد می‌شود. یک افکت سه‌بعدی فرمت‌بندی است که بر روی یک شکل یا متن معمولی PowerPoint اعمال می‌شود، مانند چرخش، برجستگی، لبه‌دار، نورپردازی و ماده. این مقاله به افکت‌های سه‌بعدی می‌پردازد.

**کدام تنظیمات برای یک شکل سه‌بعدی قابل مشاهده لازم است؟**

حداقل باید چرخش دوربین و یا برجستگی یا عمق را تنظیم کنید. در عمل، همچنین یک نورپردازی و ماده تنظیم می‌شود تا سطح‌های رندر شده روشنایی و سایه‌های واضحی داشته باشند.

**آیا می‌توانم افکت‌های سه‌بعدی را هم روی اشکال و هم روی متن اعمال کنم؟**

بله. برای بدنهٔ شکل از [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) و برای متن از [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) استفاده کنید.

**آیا افکت‌های سه‌بعدی هنگام صادرات به تصاویر، PDF، HTML یا فریم‌های ویدیو ظاهر می‌شوند؟**

بله. Aspose.Slides افکت‌های سه‌بعدی را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های مورد استفاده برای تبدیل ویدیو رندر می‌کند. خروجی صادرشده تنها حاوی ظاهر رندر شده است، نه یک شیء سه‌بعدی قابل ویرایش.

**آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟**

بله. از APIهای فرمت‌بندی مؤثر توصیف‌شده در [ویژگی‌های مؤثر شکل](/slides/fa/net/shape-effective-properties/) برای خواندن دوربین نهایی، نورپردازی، لبه و مقادیر مرتبط با سه‌بعدی استفاده کنید.