---
title: ایجاد و اعمال افکت‌های WordArt در .NET
linktitle: WordArt
type: docs
weight: 110
url: /fa/net/wordart/
keywords:
- WordArt
- ایجاد WordArt
- قالب WordArt
- افکت WordArt
- افکت سایه
- افکت انعکاس
- افکت نوردهی
- تغییر شکل WordArt
- افکت 3بعدی
- افکت سایه بیرونی
- افکت سایه داخلی
- .NET
- C#
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی افکت‌های WordArt در Aspose.Slides برای .NET. این راهنمای گام‌به‌گام به توسعه‌دهندگان کمک می‌کند تا ارائه‌ها را با متن حرفه‌ای در C# بهبود دهند."
---
## **بررسی کلی**

WordArt effects به شما امکان می‌دهند متن را با پرکننده‌ها، خطوط دور، سایه‌ها، انعکاس‌ها، نوردهی، تغییر شکل‌ها و قالب‌بندی سه‌بعدی استایل کنید. این مقاله توضیح می‌دهد چگونه این افکت‌ها را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای .NET ایجاد و سفارشی کنید، بدون نصب Microsoft Office.

## **ایجاد یک قالب ساده WordArt و اعمال آن بر متن**

مثال‌های زیر یک سبک ساده WordArt را با تنظیم متن، قلم، پرکردن الگو و خطوط دور ایجاد می‌کنند.

هر مثال یک ارائه جدید ایجاد می‌کند و یک مستطیل به اسلاید اول آن اضافه می‌نماید؛ نیازی به فایل ورودی نیست. مثال اول متن را به "Aspose.Slides" تنظیم می‌کند. موقعیت و ابعاد شکل بر حسب پوینت اندازه‌گیری می‌شوند:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

قلم را به Arial Black با اندازه 36 پوینت تنظیم کنید تا قالب‌بندی واضح‌تر شود:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;
```

یک الگوی [SmallGrid](https://reference.aspose.com/slides/fa/net/aspose.slides/patternstyle/) با پیش‌زمینه نارنجی تیره و زمینه سفید اعمال کنید، سپس یک خطوط دور متنی سیاه با عرض 1 پوینت اضافه کنید:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

portion.PortionFormat.LineFormat.Width = 1;
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

متن حاصل:

![قالب ساده WordArt](WordArt_template.png)

## **اعمال افکت‌های دیگر WordArt**

مثال‌های زیر نحوه اعمال سایه‌ها، انعکاس‌ها، نوردهی، تغییر شکل‌ها و افکت‌های سه‌بعدی بر متن را نشان می‌دهند.

### **اعمال افکت سایه بیرونی**

سایه بیرونی با قرار دادن سایه‌ای پشت متن عمق می‌بخشد. می‌توانید رنگ، جهت، فاصله، شعاع تاری، مقیاس و کج‌شدگی آن را سفارشی کنید.

این مثال [EnableOuterShadowEffect](https://reference.aspose.com/slides/fa/net/aspose.slides/effectformat/enableoutershadoweffect/) را فراخوانی می‌کند و یک سایهٔ سیاه با شعاع تاری 4 پوینت، جهت 230 درجه و فاصله 30 پوینت تنظیم می‌نماید. مقادیر مقیاس 100 اندازهٔ سایه را حفظ می‌کند، در حالی که کج‑شدگی افقی آن را 20 درجه می‌چرخاند. تبدیل آلفا شفافیت آن را به 32% تنظیم می‌کند:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 30;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 20;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
```

متن حاصل:

![افکت سایه بیرونی](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- وقتی سایه‌های بیرونی و از پیش تعیین‌شده با هم استفاده شوند، فقط سایهٔ بیرونی اعمال می‌شود.
- اگر سایه‌های بیرونی و داخلی به‌طور همزمان استفاده شوند، اثر نهایی به نسخهٔ PowerPoint بستگی دارد. به‌عنوان مثال، در PowerPoint 2013 اثر دو برابر می‌شود، در حالی که در PowerPoint 2007 فقط سایهٔ بیرونی اعمال می‌شود.
{{% /alert %}}

### **اعمال افکت انعکاس**

انعکاس یک نسخهٔ آینه‌ای از متن ایجاد می‌کند. می‌توانید موقعیت، مقیاس، تاری و شفافیت آن را تنظیم کنید تا ظاهر آن را کنترل کنید.

این مثال [EnableReflectionEffect](https://reference.aspose.com/slides/fa/net/aspose.slides/effectformat/enablereflectioneffect/) را فراخوانی می‌کند و انعکاس را به صورت عمودی با مقیاس -100٪ می‌چرخاند. از شعاع تاری 0.5 پوینت و فاصله 4.72 پوینت استفاده می‌کند. شفافیت بین موقعیت‌های 0٪ و 60٪ در طول انعکاس از 60٪ به 0.9٪ کاهش می‌یابد:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableReflectionEffect();
portion.PortionFormat.EffectFormat.ReflectionEffect.BlurRadius = 0.5;
portion.PortionFormat.EffectFormat.ReflectionEffect.Distance = 4.72;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartPosAlpha = 0f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndPosAlpha = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.Direction = 90;
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleVertical = -100;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartReflectionOpacity = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndReflectionOpacity = 0.9f;
portion.PortionFormat.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.BottomLeft;
```

متن حاصل:

![افکت انعکاس](reflection_effect.png)

### **اعمال افکت نوردهی**

نوردهی یک خط دور نرم و رنگی در اطراف متن اضافه می‌کند. می‌توانید رنگ، شفافیت و شعاع آن را تنظیم کنید تا افکت را کنترل نمایید.

این مثال [EnableGlowEffect](https://reference.aspose.com/slides/fa/net/aspose.slides/effectformat/enablegloweffect/) را فراخوانی می‌کند و یک نوردهی قرمز با شفافیت 54% و شعاع 7 پوینت اعمال می‌نماید:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.Color = System.Drawing.Color.Red;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

متن حاصل:

![افکت نوردهی](glow_effect.png)

### **اعمال تغییر شکل‌های WordArt**

تغییر شکل‌های WordArt یک بلوک متن را خم، کشیده یا پیچیده می‌کنند.

تغییر [Transform](https://reference.aspose.com/slides/fa/net/aspose.slides/textframeformat/transform/) را به [ArchUpPour](https://reference.aspose.com/slides/fa/net/aspose.slides/textshapetype/) تنظیم کنید تا فریم متنی تماماً به سمت بالا منحنی شود:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

متن حاصل:

![تغییر شکل WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides برای .NET مجموعه‌ای از [انواع تغییر شکل](https://reference.aspose.com/slides/fa/net/aspose.slides/textshapetype/) از پیش تعریف‌شده را فراهم می‌کند.
{{% /alert %}}

### **اعمال افکت‌های 3D بر اشکال و متن**

می‌توانید افکت‌های 3D را بر یک شکل یا متن آن اعمال کنید. برش‌ها (Bevels)، برون‌سپاری (extrusion)، روشنایی و تنظیمات دوربین ظاهر نهایی را کنترل می‌کنند.

مثال زیر از [ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/threedformat/) برای افزودن برش‌های دایره‌ای، برون‌سپاری نارنجی و حاشیهٔ قرمز تیره به مستطیل استفاده می‌کند. ابعاد برش، ارتفاع برون‌سپاری، عرض حاشیه و عمق بر حسب پوینت محاسبه می‌شوند. یک مادهٔ پلاستیک، روشنایی متعادل که 40 درجه حول محور Z چرخانده شده و دوربینی پرسپکتیو ظاهر آن را تعریف می‌کنند:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
autoShape.TextFrame.Text = "Aspose.Slides";

autoShape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelBottom.Height = 10.5;
autoShape.ThreeDFormat.BevelBottom.Width = 10.5;

autoShape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelTop.Height = 12.5;
autoShape.ThreeDFormat.BevelTop.Width = 11;

autoShape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
autoShape.ThreeDFormat.ExtrusionHeight = 6;

autoShape.ThreeDFormat.ContourColor.Color = Color.DarkRed;
autoShape.ThreeDFormat.ContourWidth = 1.5;

autoShape.ThreeDFormat.Depth = 3;

autoShape.ThreeDFormat.Material = MaterialPresetType.Plastic;

autoShape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
autoShape.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

شکل حاصل:

![افکت 3D شکل](shape_3D_effect.png)

این مثال قالب‌بندی 3D مشابهی را بر متن از طریق [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/textframeformat/threedformat/) اعمال می‌کند. برش‌های کوچکتر لبه‌های حروف را شکل می‌دهند، در حالی که برون‌سپاری و روشنایی به متن عمق می‌بخشند:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";

textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 6;

textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;

textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

متن حاصل:

![افکت 3D متن](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
اعمال افکت‌های 3D بر متن یا شکل‌های آن—و تعامل بین این افکت‌ها—بر پایه قوانین خاصی تنظیم می‌شود. صحنه‌ای که هم متن و هم شکل حاوی آن را در بر می‌گیرد در نظر بگیرید. یک افکت 3D شامل نمایش 3D شیء و صحنه‌ای است که در آن قرار دارد.

- اگر صحنه‌ای برای هر دو شکل و متن تنظیم شده باشد، صحنهٔ شکل اولویت دارد و صحنهٔ متن نادیده گرفته می‌شود.
- اگر شکل صحنهٔ خود را نداشته باشد اما نمایش 3D داشته باشد، صحنهٔ متن استفاده می‌شود.
- اگر شکل هیچ افکت 3D نداشته باشد، به صورت صاف در نظر گرفته می‌شود و افکت 3D فقط بر متن اعمال می‌شود.

این رفتارها به ویژگی‌های [ThreeDFormat.LightRig](https://reference.aspose.com/slides/fa/net/aspose.slides/threedformat/lightrig/) و [ThreeDFormat.Camera](https://reference.aspose.com/slides/fa/net/aspose.slides/threedformat/camera/) مربوط می‌شوند.
{{% /alert %}}

برای نگه داشتن متن صاف و قابل خواندن در حالی که قالب‌بندی 3D شکل آن حفظ می‌شود، به [Keep Text Flat on a 3D Shape](/slides/fa/net/3d-presentation/) برای مقایسهٔ هر دو تنظیم و یک مثال کامل C# مراجعه کنید.

## **پرسش‌های متداول**

**آیا می‌توانم از افکت‌های WordArt با فونت‌ها یا اسکریپت‌های مختلف (مانند عربی، چینی) استفاده کنم؟**

بله، Aspose.Slides برای .NET از یونیکد پشتیبانی می‌کند و با تمام فونت‌ها و اسکریپت‌های اصلی کار می‌کند. افکت‌های WordArt مانند سایه، پرکننده و خطوط دور می‌توانند صرف‌نظر از زبان اعمال شوند، اگرچه در دسترس بودن و رندر شدن فونت ممکن است به فونت‌های سیستم بستگی داشته باشد.

**آیا می‌توانم افکت‌های WordArt را بر عناصر مستر اسلاید اعمال کنم؟**

بله، می‌توانید افکت‌های WordArt را بر اشکال موجود در اسلایدهای مستر، از جمله نگهدارنده‌های عنوان، فوترها یا متن پس‌زمینه اعمال کنید. تغییرات اعمال‌شده به طرح مستر در تمام اسلایدهای مرتبط بازتاب خواهد یافت.

**آیا افکت‌های WordArt بر اندازهٔ فایل ارائه تأثیر می‌گذارند؟**

به‌صورت جزئی. افکت‌های WordArt مانند سایه‌ها، نوردهی و پرکننده‌های گرادیان ممکن است به‌دلیل اضافه شدن متادیتای قالب‌بندی، اندازهٔ فایل را کمی افزایش دهند، اما تفاوت معمولاً ناچیز است.

**آیا می‌توانم نتیجهٔ افکت‌های WordArt را بدون ذخیرهٔ ارائه پیش‌نمایش کنم؟**

بله، می‌توانید اسلایدهای حاوی WordArt را به تصویر (مثلاً PNG، JPEG) با استفاده از [ISlide.GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/getimage/) تبدیل کنید یا اشکال جداگانه را با استفاده از [IShape.GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/getimage/) رندر کنید. این امکان را می‌دهد که نتیجه را در حافظه یا روی صفحه نمایش پیش‌نمایش کنید قبل از اینکه ارائه را ذخیره یا صادر کنید.