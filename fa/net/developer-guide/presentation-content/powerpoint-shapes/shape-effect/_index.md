---
title: اعمال افکت‌های شکل در ارائه‌ها در .NET
linktitle: افکت شکل
type: docs
weight: 30
url: /fa/net/shape-effect/
keywords:
- افکت شکل
- افکت سایه
- افکت بازتاب
- افکت درخشندگی
- افکت لبه‌های نرم
- قالب افکت
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با افکت‌های پیشرفته شکل با استفاده از Aspose.Slides برای .NET تبدیل کنید — اسلایدهای برجسته و حرفه‌ای را در ثانیه‌ها ایجاد کنید."
---
## **معرفی**

در حالی که افکت‌ها در پاورپوینت می‌توانند برای برجسته‌کردن یک شکل استفاده شوند، آنها با [پرکننده‌ها](/slides/fa/net/shape-formatting/#gradient-fill) یا خطوط پیرامونی متفاوت هستند. با استفاده از افکت‌های پاورپوینت می‌توانید بازتاب‌های قانع‌کننده‌ای روی یک شکل ایجاد کنید، تابش شکل را گسترش دهید، و غیره.

![اثر شکل](shape-effect.png)

پاورپوینت شش افکت فراهم می‌کند که می‌توان به شکل‌ها اعمال کرد. می‌توانید یک یا چند افکت را به یک شکل اعمال کنید.

برخی ترکیب‌های افکت‌ها نسبت به دیگران زیباتر به نظر می‌رسند. به همین دلیل، پاورپوینت گزینه‌هایی تحت **Preset** دارد. گزینه‌های Preset اساساً ترکیبی شناخته‌شده و زیبا از دو یا چند افکت هستند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف وقت برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن یک ترکیب مناسب نیست.

Aspose.Slides خصوصیات و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) فراهم می‌کند که به شما امکان می‌دهد همان افکت‌ها را به شکل‌ها در ارائه‌های پاورپوینت اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides برای .NET از سایه‌های خارجی و داخلی برای شکل‌ها پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع تار شدن آنها را به‌گونه‌ای تنظیم کنید که با طراحی ارائه شما تطبیق داشته باشد.

### **اعمال سایه خارجی**

از سایه خارجی برای برجسته‌کردن یک کارت یا پنل در مقابل پس‌زمینه اسلاید استفاده کنید. سایه فراتر از لبه‌های شکل گسترش می‌یابد و این تصور را می‌دهد که شکل از اسلاید بالا آمده است. رنگ، جهت، فاصله و شعاع تار شدن آن را برای مطابقت با نورپردازی و سبک قالب خود تنظیم کنید.

این کد C# نشان می‌دهد چگونه [افکت سایه خارجی](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) را بر روی یک مستطیل اعمال کنید:

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

هنگام بازسازی سبک بصری یک قالب، از سایه داخلی استفاده کنید تا به یک کارت یا پنل ظاهری فرو رفته بدهید. سایه خارجی خارج از شکل گسترش می‌یابد و ظاهری برآمده ایجاد می‌کند، در حالی که سایه داخلی داخل لبه‌های شکل را تار می‌کند.

متد [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) را فراخوانی کنید، سپس [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/) را پیکربندی کنید. مقادیر بزرگتر لبه‌های نرم‌تری تولید می‌کنند.

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

برای حذف سایه داخلی، متد [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) را بر روی فرمت افکت شکل فراخوانی کنید.

## **اعمال افکت بازتاب**

برای اعمال افکت بازتاب در Aspose.Slides برای .NET، می‌توانید بازتابی شبیه آینه به شکل‌ها اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت زیبایی ارائه‌های شما را با ارائه ظاهری صیقلی و پیشرفته به شکل‌ها ارتقا می‌دهد. پیاده‌سازی آن با کد ساده آسان است و امکان استفاده سریع بر روی عناصر متعدد برای داشتن طراحی یکدست را فراهم می‌کند.

این کد C# نشان می‌دهد چگونه [افکت بازتاب](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) را بر روی یک شکل اعمال کنید:

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

![افکت بازتاب](reflection_effect.png)

## **اعمال افکت درخشندگی**

برای اعمال افکت درخشندگی به یک شکل در Aspose.Slides برای .NET، می‌توانید هاله‌ای نرم و تابان در اطراف شکل‌ها اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این افکت به برجسته‌کردن شکل‌ها کمک می‌کند و عنصر بصری جذاب و چشم‌نواز به ارائه شما اضافه می‌بندد. پیاده‌سازی آن با کد کم به سادگی انجام می‌شود و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

این کد C# نشان می‌دهد چگونه [افکت درخشندگی](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) را بر روی یک شکل اعمال کنید:

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

![افکت درخشندگی](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides برای .NET، می‌توانید انتقالی صاف و تار در اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهری ملایم‌تر و تصحیح‌شده می‌دهد که برای طرح‌هایی که نیاز به نمایی ملایم و نرم دارند مناسب است. می‌توانید به‌راحتی پارامترهایی مانند شعاع را تنظیم کنید تا افکت مطلوب را بر روی شکل‌های مختلف در ارائه خود به دست آورید.

این کد C# نشان می‌دهد چگونه [لبه‌های نرم](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) را بر روی یک شکل اعمال کنید:

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

از تاری شکل برای نرم کردن پرکردگی و خطوط پیرامونی شکل استفاده کنید در حالی که شکل قابل ویرایش می‌ماند. متد [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) را بر روی فرمت افکت شکل فراخوانی کنید. شعاع بر حسب پوینت (1/72 اینچ) اندازه‌گیری می‌شود: از مقدار غیر منفی استفاده کنید؛ مقادیر بزرگتر تاری قوی‌تری تولید می‌کنند. شعاع صفر ظاهر را تغییر نمی‌دهد.

تنظیم [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) محدوده قابل مشاهده افکت را کنترل می‌کند. با `false`، تاری به مرزهای اولیه رنگ شده، شامل خطوط پیرامونی، محدود می‌شود. با `true`، تاری می‌تواند فراتر از آن مرزها گسترش یابد. هیچ‌یک از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهد.

مقایسه زیر از همان پرکردگی، خطوط پیرامونی و ابعاد شکل در تمام مراحل استفاده می‌کند. ردیف بالایی از `grow = false` استفاده می‌کند؛ ردیف پایین از `grow = true`.

![مستطیل اصلی مقایسه‌شده با شعاع‌های تاری 5 و 15 پوینت، با Grow غیرفعال و فعال](shape_blur_comparison.png)

این مثال C# یک مستطیل نارنجی با خطوط پیرامونی آبی تیره ایجاد می‌کند، تاری 5 پوینت را اعمال می‌نماید و سپس با فراخوانی مجدد [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) به تاری 15 پوینت بروزرسانی می‌کند. هر دو وضعیت تاری را ذخیره می‌کند، سپس [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) را فراخوانی کرده و شکل را بدون تاری ذخیره می‌نماید.

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

تاری شکل بر هر دو پرکردگی و خطوط پیرامونی اثر می‌گذارد. افکت لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که تاری سایه فقط سایه را نرم می‌کند. افکت‌های تبدیل تصویر بر محتوای تصویر عمل می‌کنند؛ این مثال تاری را مستقیماً بر فرمت افکت شکل اعمال می‌کند بدون اینکه شکل به تصویر تبدیل شود.

## **سؤالات متداول**

**آیا می‌توانم چند افکت را بر یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، بازتاب و درخشندگی را بر روی یک شکل ترکیب کنید تا ظاهری پویا تر به دست آورید.

**به چه شکل‌هایی می‌توانم افکت‌ها اعمال کنم؟**

می‌توانید افکت‌ها را بر انواع شکل‌ها اعمال کنید، از جمله اشکال خودکار، نمودارها، جداول، تصاویر، اشیای SmartArt، اشیای OLE و غیره.

**آیا می‌توانم افکت‌ها را بر شکل‌های گروهی اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر شکل‌های گروهی اعمال کنید. افکت بر کل گروه اعمال می‌شود.