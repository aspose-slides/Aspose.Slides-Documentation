---
title: اعمال افکت‌های شکل در ارائه‌ها در .NET
linktitle: افکت شکل
type: docs
weight: 30
url: /fa/net/shape-effect/
keywords:
- افکت شکل
- افکت سایه
- افکت انعکاس
- افکت نورانی
- افکت لبه‌های نرم
- فرمت افکت
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با افکت‌های پیشرفته شکل با استفاده از Aspose.Slides برای .NET تبدیل کنید—در عرض چند ثانیه اسلایدهای حرفه‌ای و چشم‌نواز بسازید."
---
## **معرفی**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته‌کردن یک شکل استفاده شوند، آن‌ها با [پرکننده‌ها](/slides/fa/net/shape-formatting/#gradient-fill) یا خطوط مرزی متفاوت هستند. با استفاده از افکت‌های PowerPoint می‌توانید انعکاس‌های قانع‌کننده‌ای روی یک شکل ایجاد کنید، نورانی شدن (glow) شکل را گسترش دهید و غیره.

![اثر شکل](shape-effect.png)

PowerPoint شش افکت ارائه می‌دهد که می‌توان به شکل‌ها اعمال کرد. می‌توانید یک یا چند افکت را به یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از دیگران به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **Preset** دارد. گزینه‌های Preset اساساً ترکیبی شناخته‌شده و زیبا از دو یا چند افکت هستند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیبی مناسب نخواهید داشت.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) فراهم می‌کند که به شما امکان می‌دهد همان افکت‌ها را به اشکال در ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides for .NET از سایه‌های خارجی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع تار شدن آن‌ها را برای مطابقت با طراحی ارائه‌تان سفارشی کنید.

### **اعمال سایه خارجی**

از سایه خارجی برای برجسته‌کردن کارت یا پنل نسبت به پس‌زمینه اسلاید استفاده کنید. سایه خارج از لبه‌های شکل گسترش می‌یابد و احساسی از برآمدگی شکل نسبت به اسلاید ایجاد می‌کند. رنگ، جهت، فاصله و شعاع تار شدن آن را با نورپردازی و سبک الگوی خود هماهنگ کنید.

این کد C# نشان می‌دهد چگونه می‌توانید [افکت سایه خارجی](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) را به یک مستطیل اعمال کنید:

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

![افکت سایه](shadow_effect.png)

### **اعمال سایه داخلی**

هنگامی که می‌خواهید استایل بصری یک الگو را بازآفرینی کنید، از سایه داخلی برای دادن ظاهر فرو رفته به کارت یا پنل استفاده کنید. سایه خارجی خارج از شکل گسترش می‌یابد و آن را برآمده نشان می‌دهد، در حالی که سایه داخلی داخل لبه‌های شکل را تار می‌کند.

متد [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) را فراخوانی کنید، سپس [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/) را تنظیم کنید. مقادیر بزرگ‌تر لبه‌های نرم‌تری تولید می‌کنند.

این مثال C# یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد کرده و به‌صورت فایل PPTX ذخیره می‌کند:

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

برای حذف سایه داخلی، متد [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) را بر روی فرمت افکت شکل فراخوانی کنید.

### **اعمال، تغییر و حذف یک سایه پیش‌تنظیم‌شده**

متد [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) را فراخوانی کنید و ویژگی [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) را به یک [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/) نام‌دار تنظیم کنید. برای تغییر سبک، پیش‌تنظیم را بر روی همان شکل تغییر دهید. برای حذف سایه در حالی که پرکننده و خط مرزی حفظ می‌شود، متد [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) را فراخوانی کنید.

این مثال یک کپی از مستطیل را در هر مرحله نگه می‌دارد. هر دو سایه به اندازه 10 پوینت جابجا شده‌اند. جهت ۲۲۵° سایه اول را بالای سمت چپ مستطیل قرار می‌دهد و ۴۵° سایه دوم را پایین سمت راست.

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
| ![بدون سایه](preset_shadow_original.png) | ![سایه‌دار بالاچپ](preset_shadow_top_left.png) | ![سایه‌دار پایین راست](preset_shadow_bottom_right.png) | ![بدون سایه پس از حذف](preset_shadow_removed.png) |

## **اعمال افکت انعکاس**

برای اعمال افکت انعکاس در Aspose.Slides for .NET، می‌توانید انعکاس آینه‌ای به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت زیبایی ارائه‌های شما را افزایش می‌دهد و به اشکال ظاهری صیقلی و پیشرفته می‌بخشد. پیاده‌سازی آن با کد ساده است و امکان اعمال سریع در چندین عنصر برای یک طراحی یکپارچه را فراهم می‌کند.

این کد C# نشان می‌دهد چگونه می‌توانید [افکت انعکاس](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) را به یک شکل اعمال کنید:

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

## **اعمال افکت نورانی (Glow)**

برای اعمال افکت نورانی به یک شکل در Aspose.Slides for .NET، می‌توانید هاله‌ای نرم و درخشانی در اطراف اشکال اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این افکت به برجسته‌کردن شکل‌ها کمک می‌کند و عنصر بصری جذاب و چشم‌نوازی به ارائه‌تان می‌افزاید. پیاده‌سازی آن با کم‌ترین کد امکان‌پذیر است و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

این کد C# نشان می‌دهد چگونه می‌توانید [افکت نورانی](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) را به یک شکل اعمال کنید:

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

![افکت نورانی](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides for .NET، می‌توانید انتقالی نرم و تار به دور لبه‌های یک شکل ایجاد کنید. این افکت ظاهری ملایم‌تر و براق‌تر می‌دهد که برای طرح‌هایی که نیاز به ظاهر لطیف‌تری دارند، ایده‌آل است. می‌توانید به‌راحتی پارامترهایی مانند شعاع را تنظیم کنید تا اثر مطلوب را در اشکال مختلف ارائه‌تان به دست آورید.

این کد C# نشان می‌دهد چگونه می‌توانید [لبه‌های نرم](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) را به یک شکل اعمال کنید:

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

## **اعمال افکت تار شدن (Blur)**

از تار شدن شکل برای نرم کردن پرکننده و خط مرزی شکل استفاده کنید در حالی که شکل قابل ویرایش باقی می‌ماند. متد [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) را بر روی فرمت افکت شکل فراخوانی کنید. شعاع بر حسب پوینت (1/72 اینچ) اندازه‌گیری می‌شود: از مقدار غیرمنفی استفاده کنید؛ مقادیر بزرگ‌تر تار شدن قوی‌تری تولید می‌کنند. شعاع صفر ظاهر را بدون تغییر می‌گذارد.

تنظیم [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) مرزهای قابل مشاهده اثر را کنترل می‌کند. با `false`، تار شدن به مرزهای رنگ‌شده اصلی، شامل خط مرزی، محدود می‌شود. با `true`، تار شدن می‌تواند فراتر از این مرزها گسترش یابد. هیچ‌کدام از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهند.

مقایسه زیر از همان پرکننده، خط مرزی و ابعاد شکل در تمام حالات استفاده می‌کند. ردیف بالا از `grow = false` استفاده می‌کند؛ ردیف پایین از `grow = true`.

![مستطیل اصلی در مقایسه با شعاع‌های تار شدن 5 و 15 پوینت، با Grow غیرفعال و فعال](shape_blur_comparison.png)

این مثال C# یک مستطیل نارنجی با خط مرزی آبی تیره ایجاد می‌کند، تار شدن 5 پوینتی اعمال می‌کند و سپس با فراخوانی دوباره [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) آن را به تار شدن 15 پوینت به‌روز می‌سازد. هر دو حالت تار شده را ذخیره می‌کند، سپس متد [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) را فراخوانی کرده و شکل را بدون تار شدن ذخیره می‌کند.

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

تار شدن شکل هم پرکننده و هم خط مرزی را تحت تأثیر قرار می‌دهد. افکت لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که تار شدن سایه تنها سایه را نرم می‌کند. افکت‌های تبدیل تصویر بر روی محتوای تصویر عمل می‌کنند؛ این مثال تار شدن را مستقیماً بر روی فرمت افکت شکل بدون تبدیل به تصویر اعمال می‌کند.

## **سوالات متداول**

**آیا می‌توانم چندین افکت را بر روی یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و نورانی را روی یک شکل ترکیب کنید تا ظاهر پویاتری ایجاد کنید.

**کدام اشکال می‌توانم به آن‌ها افکت اعمال کنم؟**

می‌توانید افکت‌ها را به انواع مختلفی از اشکال اعمال کنید، از جمله اشکال خودکار، نمودارها، جدول‌ها، تصاویر، اشیاء SmartArt، اشیاء OLE و غیره.

**آیا می‌توانم افکت‌ها را به اشکال گروهی اعمال کنم؟**

بله، می‌توانید افکت‌ها را به اشکال گروهی اعمال کنید. افکت بر کل گروه اعمال می‌شود.