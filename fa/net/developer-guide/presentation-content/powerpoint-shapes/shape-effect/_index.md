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
- افکت درخشش
- افکت لبه‌های نرم
- فرمت افکت
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با استفاده از افکت‌های پیشرفته شکل در Aspose.Slides برای .NET—در عرض ثانیه‌ها اسلایدهای چشم‌نواز و حرفه‌ای ایجاد کنید."
---
## **معرفی**

در حالی که افکت‌ها در PowerPoint برای برجسته کردن یک شکل استفاده می‌شوند، آن‌ها با [پرکننده‌ها](/slides/fa/net/shape-formatting/#gradient-fill) یا خطوط مرزی متفاوت هستند. با استفاده از افکت‌های PowerPoint می‌توانید انعکاس‌های قابل‌قانع روی یک شکل ایجاد کنید، درخشندگی شکل را گسترش دهید و غیره.

![اثر شکل](shape-effect.png)

PowerPoint شش افکت ارائه می‌دهد که می‌توان آن‌ها را به شکل‌ها اعمال کرد. می‌توانید یک یا چند افکت را به یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از سایرین به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **پیش‌تنظیم** دارد. گزینه‌های پیش‌تنظیم در اصل ترکیبی شناخته‌شده و زیبا از دو یا چند افکت هستند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب ندارید.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) فراهم می‌کند که به شما اجازه می‌دهد همان افکت‌ها را به شکل‌ها در ارائه‌های PowerPoint اعمال کنید.

## **اعمال اثر سایه**

Aspose.Slides for .NET از سایه‌های بیرونی و داخلی برای شکل‌ها پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع محو شدن آن‌ها را برای مطابقت با طرح ارائه خود سفارشی کنید.

### **اعمال سایه بیرونی**

از یک سایه بیرونی استفاده کنید تا یک کارت یا پنل در برابر پس‌زمینه اسلاید برجسته شود. سایه فراتر از لبه‌های شکل گسترش می‌یابد و این احساس را ایجاد می‌کند که شکل بالای اسلاید بلند شده است. رنگ، جهت، فاصله و شعاع محو شدن آن را برای مطابقت با نورپردازی و استایل قالب‌تان تنظیم کنید.

این کد C# نشان می‌دهد چگونه می‌توان [اثر سایه بیرونی](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) را به یک مستطیل اعمال کرد:

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

![اثر سایه](shadow_effect.png)

### **اعمال سایه داخلی**

هنگام بازآفرینی سبک بصری یک قالب، از یک سایه داخلی استفاده کنید تا به یک کارت یا پنل ظاهری فرو رفته بدهید. یک سایه بیرونی در خارج از شکل گسترش می‌یابد و آن را بلند نشان می‌دهد، در حالی که یک سایه داخلی داخلی لبه‌های آن را رنگ می‌کند.

متد [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) را فراخوانی کنید، سپس [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/) را پیکربندی کنید. مقادیر بزرگتر لبه‌های نرم‌تری تولید می‌کنند.

این مثال C# یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و آن را به صورت فایل PPTX ذخیره می‌نماید:

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

## **اعمال اثر انعکاس**

برای اعمال یک اثر انعکاس در Aspose.Slides for .NET، می‌توانید انعکاس مشابه آینه‌ای به شکل‌ها اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت زیبایی ارائه‌های شما را با دادن ظاهر صیقلی و پیشرفته به شکل‌ها ارتقا می‌دهد. پیاده‌سازی آن با کد ساده است و امکان اعمال سریع بر روی عناصر متعدد برای طراحی یکنواخت را فراهم می‌کند.

این کد C# نشان می‌دهد چگونه می‌توان [اثر انعکاس](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) را به یک شکل اعمال کرد:

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

![اثر انعکاس](reflection_effect.png)

## **اعمال اثر درخشش**

برای اعمال یک اثر درخشش به شکل در Aspose.Slides for .NET، می‌توانید یک هاله نرم و روشن در اطراف شکل‌ها اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم نمایید. این افکت به برجسته شدن شکل‌ها کمک می‌کند و عنصر بصری جذاب و چشم‌نوازی به ارائه شما می‌افزاید. پیاده‌سازی آن با حداقل کد امکان‌پذیر است و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

این کد C# نشان می‌دهد چگونه می‌توان [اثر درخشش](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) را به یک شکل اعمال کرد:

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

![اثر درخشش](glow_effect.png)

## **اعمال اثر لبه‌های نرم**

برای اعمال یک اثر لبه‌های نرم در Aspose.Slides for .NET، می‌توانید انتقالی صاف و محو در اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهر ظریف‌تر و refined‌تری می‌بخشد که برای طرح‌هایی که نیاز به ظاهر ملایم و نرم دارند ایده‌آل است. می‌توانید به راحتی پارامترهایی مانند شعاع را تنظیم کنید تا اثر مطلوب را بر روی شکل‌های مختلف ارائه خود به دست آورید.

این کد C# نشان می‌دهد چگونه می‌توان [لبه‌های نرم](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) را به یک شکل اعمال کرد:

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

![اثر لبه‌های نرم](soft_edges_effect.png)

## **سؤالات متداول**

**آیا می‌توانم چندین اثر را به یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و درخشش را روی یک شکل ترکیب کنید تا ظاهر دینامیک‌تری ایجاد شود.

**چه شکل‌هایی می‌توانم به آن‌ها افکت اعمال کنم؟**

می‌توانید افکت‌ها را به انواع شکل‌ها از جمله autoshapes، نمودارها، جدول‌ها، تصاویر، اشیاء SmartArt، اشیاء OLE و موارد دیگر اعمال کنید.

**آیا می‌توانم افکت‌ها را به شکل‌های گروهی اعمال کنم؟**

بله، می‌توانید افکت‌ها را به شکل‌های گروهی اعمال کنید. این افکت بر کل گروه اعمال خواهد شد.