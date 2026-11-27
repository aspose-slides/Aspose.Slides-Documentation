---
title: "اعمال افکت‌های شکل در ارائه‌ها در .NET"
linktitle: "افکت شکل"
type: docs
weight: 30
url: /fa/net/shape-effect/
keywords:
- "افکت شکل"
- "افکت سایه"
- "افکت انعکاس"
- "افکت تابش"
- "افکت لبه‌های نرم"
- "قالب افکت"
- "PowerPoint"
- "ارائه"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "فایل‌های PPT و PPTX خود را با استفاده از افکت‌های پیشرفته شکل در Aspose.Slides برای .NET تبدیل کنید—در عرض چند ثانیه اسلایدهای برجسته و حرفه‌ای ایجاد کنید."
---
## **معرفی**

در حالی که افکت‌ها در پاورپوینت می‌توانند برای برجسته کردن یک شکل استفاده شوند، آن‌ها با [پرکننده‌ها](/slides/fa/net/shape-formatting/#gradient-fill) یا خطوط مرزی متفاوت هستند. با استفاده از افکت‌های پاورپوینت می‌توانید انعکاس‌های قابل‌اعتماد روی یک شکل ایجاد کنید، تابش شکل را گسترش دهید، و غیره.

![Shape effect](shape-effect.png)

پاورپوینت شش افکت را ارائه می‌دهد که می‌توانند بر روی اشکال اعمال شوند. می‌توانید یک یا چند افکت را بر روی یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از دیگران به نظر می‌رسند. به همین دلیل، پاورپوینت گزینه‌هایی تحت **Preset** دارد. گزینه‌های Preset در واقع ترکیبی شناخته‌شده و زیبا از دو یا چند افکت هستند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب ندارید.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) فراهم می‌کند که به شما اجازه می‌دهد همان افکت‌ها را بر روی اشکال در ارائه‌های پاورپوینت اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides برای .NET از سایه‌های بیرونی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع تاری آن‌ها را برای مطابقت با طراحی ارائه خود سفارشی کنید.

### **اعمال سایه بیرونی**

از سایه بیرونی برای برجسته کردن یک کارت یا پنل نسبت به پس‌زمینه اسلاید استفاده کنید. سایه فراتر از لبه‌های شکل امتداد می‌یابد و احساسی از بالا آمدن شکل نسبت به اسلاید ایجاد می‌کند. رنگ، جهت، فاصله و شعاع تاری آن را برای سازگاری با نورپردازی و سبک قالب خود تنظیم کنید.

این کد C# نشان می‌دهد که چگونه [افکت سایه بیرونی](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) را به یک مستطیل اعمال کنید:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```

![Shadow effect](shadow_effect.png)

#### **کنترل جهت سایه هنگام چرخش یک شکل**

به طور پیش‌فرض، [RotateShadowWithShape](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/rotateshadowwithshape/) برابر `true` است، بنابراین سایه همراه با شکل می‌چرخد. برای اینکه اشکالی با چرخش‌های مختلف به‌ظاهر از همان جهت روشن شوند، این ویژگی را به `false` تنظیم کنید و به سایه‌هایشان همان [Direction](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/direction/) را بدهید.

مثال دو پیکان با سایه‌های خاکستری که به سمت راست افکنده شده‌اند (`Direction = 0`) ایجاد می‌کند. سپس اسلاید را کپی می‌کند و هر دو پیکان را 90° ساعت‌گرد می‌چرخاند.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var before = presentation.Slides[0];

var left = before.Shapes.AddAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
left.FillFormat.FillType = FillType.Solid;
left.FillFormat.SolidFillColor.Color = Color.SteelBlue;
left.LineFormat.FillFormat.FillType = FillType.NoFill;

left.EffectFormat.EnableOuterShadowEffect();
var shadow = left.EffectFormat.OuterShadowEffect;
shadow.ShadowColor.Color = Color.Gray;
shadow.Direction = 0;
shadow.Distance = 42;
shadow.BlurRadius = 0;
shadow.RotateShadowWithShape = true;

var right = before.Shapes.AddClone(left);
right.X = 395;
right.EffectFormat.OuterShadowEffect.RotateShadowWithShape = false;

var after = presentation.Slides.AddClone(before);
foreach (var arrow in after.Shapes)
    arrow.Rotation = 90;

presentation.Save("arrow_shadows.pptx", SaveFormat.Pptx);
```

در اسلاید دوم، پیکان چپ سایه‌اش را به سمت پایین می‌اندازد، در حالی که پیکان راست هنوز سایه‌اش را به سمت راست می‌اندازد. جهت تنظیم‌شده برای هر دو سایه 0° باقی می‌ماند.

![رندر PowerPoint قبل و پس از چرخش 90°. هر دو سایه ابتدا در سمت راست هستند. پس از چرخش، سایه زیر پیکان چپ حرکت می‌کند و در سمت راست پیکان راست می‌ماند.](arrow-shadow-rotation.png)

### **اعمال سایه داخلی**

هنگام بازآفرینی سبک بصری یک قالب، از سایه داخلی برای دادن ظاهری فرو رفته به کارت یا پنل استفاده کنید. یک سایه بیرونی خارج از شکل امتداد می‌یابد و آن را بالا می‌آورد، در حالی که یک سایه داخلی داخل لبه‌های شکل را سایه‌دار می‌کند.

متد [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) را فراخوانی کنید، سپس [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/) را پیکربندی کنید. مقادیر بزرگ‌تر لبه‌های نرم‌تری تولید می‌کنند.

این مثال C# یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و آن را به‌صورت فایل PPTX ذخیره می‌نماید:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;

shape.EffectFormat.EnableInnerShadowEffect();
var shadow = shape.EffectFormat.InnerShadowEffect;
shadow.ShadowColor.Color = Color.DimGray;
shadow.Direction = 225;
shadow.Distance = 7;
shadow.BlurRadius = 6;

presentation.Save("inner_shadow_effect.pptx", SaveFormat.Pptx);
```

![مستطیل آبی روشن با سایه داخلی](inner_shadow_effect.png)

برای حذف سایه داخلی، متد [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) را بر روی فرمت افکت شکل صدا بزنید.

### **اعمال، تغییر و حذف سایه پیش‌تنظیم شده**

متد [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) را فراخوانی کنید و [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) را به یک [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/) نام‌گذاری‌شده تنظیم کنید. برای تغییر سبک‌ها، پیش‌تنظیم را بر روی همان شکل تغییر دهید. برای حذف سایه در حالی که پرکننده و خط مرزی حفظ می‌شوند، متد [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) را صدا بزنید.

این مثال یک کپی از مستطیل را در هر مرحله نگه می‌دارد. هر دو سایه 10 پوینت جابجا شده‌اند. جهت 225° اولین سایه را بالای مستطیل و به سمت چپ قرار می‌دهد، و 45° دومین سایه را پایین و به سمت راست مستطیل می‌گذارد.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(800, 120, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var shape = shapes.AddAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.SteelBlue;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.TextFrame.Text = "No shadow";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.EnablePresetShadowEffect();
var shadow = shape.EffectFormat.PresetShadowEffect;
shadow.Preset = PresetShadowType.TopLeftDropShadow;
shadow.Distance = 10;
shadow.Direction = 225;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shadow.Preset = PresetShadowType.BottomRightDropShadow;
shadow.Direction = 45;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.DisablePresetShadowEffect();
shape.TextFrame.Text = "No shadow";

presentation.Save("preset_shadows.pptx", SaveFormat.Pptx);
```

| اصلی | پیش‌تنظیم اول | پیش‌تنظیم دوم | پس از حذف |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **اعمال افکت انعکاس**

برای اعمال افکت انعکاس در Aspose.Slides برای .NET، می‌توانید یک انعکاس شبیه آینه به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت زیبایی ارائه‌های شما را با دادن ظاهری صیقلی و پیشرفته به اشکال ارتقاء می‌دهد. پیاده‌سازی آن با کد ساده آسان است و امکان اعمال سریع در چندین عنصر برای یک طراحی یکدست را فراهم می‌کند.

این کد C# نشان می‌دهد که چگونه [افکت انعکاس](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) را بر روی یک شکل اعمال کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableReflectionEffect();
shape.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.Bottom;
shape.EffectFormat.ReflectionEffect.Direction = 90;
shape.EffectFormat.ReflectionEffect.Distance = 40;
shape.EffectFormat.ReflectionEffect.BlurRadius = 2;

presentation.Save("reflection_effect.pptx", SaveFormat.Pptx);
```

![افکت انعکاس](reflection_effect.png)

## **اعمال افکت تابش**

برای اعمال افکت تابش به یک شکل در Aspose.Slides برای .NET، می‌توانید اطراف اشکال یک هاله نرم و تابان اضافه کنید و خصوصیات مانند رنگ و اندازه را تنظیم کنید. این افکت به برجسته شدن اشکال کمک می‌کند و یک عنصر بصری جذاب و چشم‌نواز به ارائه شما می‌افزاید. پیاده‌سازی آن با کد کمینه آسان است و ظاهر کلی اسلایدهای شما را ارتقا می‌دهد.

این کد C# نشان می‌دهد که چگونه [افکت تابش](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) را بر روی یک شکل اعمال کنید:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![افکت تابش](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides برای .NET، می‌توانید یک انتقال صاف و تار شده اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهر ظریف‌تری می‌افزاید که برای طراحی‌هایی که به ظاهر ملایم و نرم نیاز دارند، مناسب است. می‌توانید به راحتی پارامترهایی مانند شعاع را تنظیم کنید تا افکت دلخواه را بر روی اشکال مختلف در ارائه‌تان بدست آورید.

این کد C# نشان می‌دهد که چگونه [لبه‌های نرم](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) را بر روی یک شکل اعمال کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![افکت لبه‌های نرم](soft_edges_effect.png)

## **اعمال افکت تاری**

از تاری شکل برای نرم کردن پرکننده و خط مرزی یک شکل استفاده کنید در حالی که شکل قابل ویرایش می‌ماند. متد [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) را بر روی فرمت افکت شکل صدا بزنید. شعاع بر حسب پوینت (1/72 اینچ) اندازه‌گیری می‌شود: از مقدار غیرمنفی استفاده کنید؛ مقادیر بزرگ‌تر تاری قوی‌تری تولید می‌کنند. شعاع صفر ظاهر را تغییر نمی‌دهد.

تنظیم [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) مرزهای قابل مشاهده افکت را کنترل می‌کند. با `false`، تاری به مرزهای اصلی رنگ‌آمیزی شده (از جمله خط مرزی) محدود می‌شود. با `true`، تاری می‌تواند فراتر از آن مرزها گسترش یابد. هیچکدام از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهند.

مقایسه زیر از همان پرکننده، خط مرزی و ابعاد شکل در تمام مراحل استفاده می‌کند. ردیف بالایی از `grow = false` استفاده می‌کند؛ ردیف پایین از `grow = true`.

![مستطیل اصلی مقایسه‌شده با شعاع‌های تاری 5 و 15 پوینت، با Grow غیرفعال و فعال](shape_blur_comparison.png)

این مثال C# یک مستطیل نارنجی با خط مرزی آبی تیره ایجاد می‌کند، تاری 5 پوینتی اعمال می‌کند و سپس با فراخوانی مجدد [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) به تاری 15 پوینت به‌روزرسانی می‌کند. هر دو حالت تاری را ذخیره می‌کند، سپس [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) را صدا می‌زند و شکل را بدون تاری ذخیره می‌کند.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.LineFormat.Width = 8;

shape.EffectFormat.SetBlurEffect(5, false);
presentation.Save("shape_blur_5.pptx", SaveFormat.Pptx);

shape.EffectFormat.SetBlurEffect(15, true);
presentation.Save("shape_blur_15.pptx", SaveFormat.Pptx);

shape.EffectFormat.DisableBlurEffect();
presentation.Save("shape_blur_removed.pptx", SaveFormat.Pptx);
```

تاری شکل هم پرکننده و هم خط مرزی را همراه هم تحت تأثیر قرار می‌دهد. افکت لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که تاری سایه فقط سایه را نرم می‌کند. افکت‌های تبدیل تصویر بر روی محتوای تصویر عمل می‌کنند؛ این مثال تاری را مستقیماً بر روی فرمت افکت شکل بدون تبدیل شکل به تصویر اعمال می‌کند.

## **سوالات متداول**

**آیا می‌توانم چندین افکت را بر روی یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و تابش را بر روی یک شکل ترکیب کنید تا ظاهر دینامیک‌تری ایجاد کنید.

**به کدام اشکال می‌توانم افکت اعمال کنم؟**

می‌توانید افکت‌ها را به انواع اشکال از جمله اشکال خودکار، نمودارها، جداول، تصاویر، اشیای SmartArt، اشیای OLE و موارد دیگر اعمال کنید.

**آیا می‌توانم افکت‌ها را بر روی شکل‌های گروهی اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر روی شکل‌های گروهی اعمال کنید. افکت بر تمام گروه اعمال می‌شود.