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
- افکت نمایش
- افکت درخشش
- تبدیل WordArt
- افکت 3بعدی
- افکت سایه خارجی
- افکت سایه داخلی
- .NET
- C#
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی افکت‌های WordArt در Aspose.Slides برای .NET. این راهنمای گام به گام به توسعه‌دهندگان کمک می‌کند تا ارائه‌ها را با متن حرفه‌ای در C# ارتقا دهند."
---
## **بررسی کلی**

افکت‌های WordArt به شما امکان می‌دهند متن‌های بصری جذاب و سبک‌دار را به ارائه‌های PowerPoint خود اضافه کنید. با Aspose.Slides برای .NET، توسعه‌دهندگان می‌توانند به‌صورت برنامه‌نویسی WordArt را همانند Microsoft PowerPoint ایجاد، سفارشی‌سازی و مدیریت کنند—بدون نیاز به نصب Office. این مقاله یک مرور کلی از کار با WordArt در .NET ارائه می‌دهد، از جمله نحوه اعمال تبدیل‌های متنی، سبک‌های پرکردن، خطوط کانتور، سایه‌ها و سایر گزینه‌های قالب‌بندی برای بیان‌دهی و جذاب‌تر کردن محتوای ارائه شما. WordArt به شما این امکان را می‌دهد که متن را به عنوان یک شیء گرافیکی در نظر بگیرید. این شامل افکت‌ها یا تغییرات ویژه‌ای است که بر متن اعمال می‌شوند تا آن را جذاب‌تر یا قابل‌توجه‌تر کنند.

## **ایجاد یک قالب WordArt ساده و اعمال آن بر متن**

در این بخش، نحوه ایجاد یک قالب WordArt ساده و اعمال آن بر متن را با استفاده از Aspose.Slides برای .NET بررسی می‌کنیم. WordArt روشی آسان برای ارتقای ظاهر متن با افکت‌ها و سبک‌های بصری چشم‌گیر ارائه می‌دهد. با یادگیری گام‌های پایه‌ای ایجاد و استفاده از WordArt، می‌توانید این تکنیک‌ها را به سادگی برای هر پروژه‌ای به‌کار ببرید و ارائه‌های خود را پویا و به‌یادماندنی کنید.

ابتدا، متن ساده را با کد C# زیر می‌سازیم:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```

سپس، ارتفاع فونت متن را به مقدار بزرگتری تنظیم می‌کنیم تا افکت بیشتر به چشم بیاید:

```cs
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
```

در اینجا، پرکنش الگوی SmallGrid را به متن اعمال می‌کنیم و یک کادر متن سیاه با ضخامت ۱ اضافه می‌کنیم:

```cs
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
                
    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

متن حاصل:

![قالب ساده WordArt](WordArt_template.png)

## **اعمال افکت‌های دیگر WordArt**

علاوه بر تبدیل‌های پایه، Aspose.Slides برای .NET به شما اجازه می‌دهد تا انواع افکت‌های پیشرفته WordArt را برای بهبود ظاهر متن به کار ببرید. این افکت‌ها شامل خطوط کانتور، پرکنش‌ها، سایه‌ها، انعکاس‌ها و افکت‌های درخشش هستند. با ترکیب این ویژگی‌ها، می‌توانید سبک‌های متنی چشم‌نوازی ایجاد کنید که در ارائه‌های شما برجسته شوند. این بخش نشان می‌دهد چگونه این افکت‌ها را به‌صورت برنامه‌نویسی با مثال‌های کد ساده و تمیز اعمال کنید.

### **اعمال افکت سایه خارجی**

افکت‌های سایه خارجی به متن کمک می‌کنند تا با اضافه کردن سایه‌ای پشت خطوط کانتور، عمق و جدایی از پس‌زمینه ایجاد شود. Aspose.Slides برای .NET امکان اعمال و سفارشی‌سازی آسان سایه‌های خارجی بر متن WordArt را فراهم می‌کند. در این بخش، نحوه تنظیم رنگ سایه، جهت، فاصله، شعاع محو شدن و موارد دیگر برای دستیابی به تأثیر بصری مطلوب را یاد خواهید گرفت.

قطعه کد C# زیر افکت سایه را بر متن ایجاد شده در بالا اعمال می‌کند.

```cs
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

![افکت سایه خارجی](outer_shadow_effect.png)

{{% alert color="primary" %}} 
- وقتی OuterShadow و PresetShadow همزمان استفاده شوند، تنها افکت OuterShadow اعمال می‌شود.
- اگر OuterShadow و InnerShadow به‌صورت همزمان اعمال شوند، اثر نهایی بسته به نسخه PowerPoint متفاوت است. برای مثال، در PowerPoint 2013 افکت دو برابر می‌شود، در حالی که در PowerPoint 2007 فقط افکت OuterShadow اعمال می‌شود.
{{% /alert %}}

### **اعمال افکت انعکاس**

در این بخش، نحوه اعمال افکت‌های انعکاس در اسلایدها با استفاده از Aspose.Slides برای .NET را بررسی می‌کنیم. افکت‌های انعکاس می‌توانند به متن یا اشکال شما ظاهری شیک و مدرن بدهند، عناصر کلیدی را برجسته کنند و عمق به ارائه‌تان اضافه کنند. با درک فرآیند اعمال و سفارشی‌سازی این افکت‌ها، می‌توانید به‌راحتی آنها را با نیازهای طراحی و برندینگ خود هماهنگ کنید.

افکت انعکاس را به متن با استفاده از مثال کد C# زیر اضافه کنید:

```cs
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

### **اعمال افکت درخشش**

در این بخش، نحوه اعمال افکت درخشش به متن با استفاده از Aspose.Slides برای .NET را بررسی می‌کنیم. افکت درخشش می‌تواند متن شما را با یک حاشیه روشن برجسته کند و جذابیت بصری اسلایدها را افزایش دهد. با تنظیم تنظیماتی مانند رنگ و شدت، می‌توانید درخشش را متناسب با طراحی و نیازهای برند خود تنظیم کنید تا نکات کلیدی ارائه‌تان توجه مخاطب را جلب کند.

با استفاده از کد زیر، افکت درخشش را به متن اعمال کنید تا براق یا برجسته شود:

```cs
    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

متن حاصل:

![افکت درخشش](glow_effect.png)

### **اعمال تبدیل‌های WordArt**

در این بخش، نحوه استفاده از تبدیل‌ها در WordArt با Aspose.Slides برای .NET را بررسی می‌کنیم. تبدیل‌ها به شما اجازه می‌دهند متن را خم، کشیده یا تغییر شکل دهید و افکت‌های منحصر به‌فرد و بصری خیره‌کننده‌ای ایجاد کنید. با تسلط بر این تکنیک‌ها، می‌توانید شکل‌ها و سبک‌های متنی را مطابق با برند یا چشم‌انداز خلاقانه خود تنظیم کنید و ارائه‌ای قانع‌کننده و صیقلی بسازید.

از ویژگی `Transform` (که بر کل بلوک متن اعمال می‌شود) با کد زیر استفاده کنید:

```cs
    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

متن حاصل:

![تبدیل WordArt](transform_effect.png)

{{% alert color="primary" %}} 
Aspose.Slides برای .NET مجموعه‌ای از [انواع تبدیل]‌(https://reference.aspose.com/slides/fa/net/aspose.slides/textshapetype/) پیش‌تعریف شده را فراهم می‌کند.
{{% /alert %}} 

### **اعمال افکت‌های سه‌بعدی بر اشکال و متن**

ایجاد جلوه‌های واقعی و جذاب می‌تواند تاثیر ارائه‌های شما را به‌طرز چشمگیری افزایش دهد. در این بخش، نحوه اعمال افکت‌های سه‌بعدی (3D) بر اشکال با Aspose.Slides برای .NET را بررسی می‌کنیم. با تنظیم پارامترهایی مانند عمق، زاویه و نورپردازی، می‌توانید تبدیل‌های سه‌بعدی شگفت‌انگیزی تولید کنید که بلافاصله توجه مخاطب را جلب کنند. چه به‌دنبال برجسته‌سازی‌های جزئی باشید یا توهمات دراماتیک، این ویژگی‌ها راه‌های انعطافی برای ارتقاء طراحی و انتقال ایده‌ها به‌صورت جذاب‌تر ارائه می‌دهند.

از کد نمونه زیر برای تنظیم افکت سه‌بعدی بر شکل استفاده کنید:

```cs
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

![افکت سه‌بعدی شکل](shape_3D_effect.png)

از کد نمونه زیر برای تنظیم افکت سه‌بعدی بر متن استفاده کنید:

```cs
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight= 6;

    textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

    textFrame.TextFrameFormat.ThreeDFormat.Depth= 3;

    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

متن حاصل:

![افکت سه‌بعدی متن](text_3D_effect.png)

{{% alert color="primary" %}} 
اعمال افکت‌های سه‌بعدی بر متن یا اشکال آن‌ها—و تعامل بین این افکت‌ها—بر اساس قوانین خاصی انجام می‌شود. یک صحنه شامل هر دو متن و شکل حاوی آن متن در نظر بگیرید. یک افکت سه‌بعدی شامل نمایش سه‌بعدی شیء و صحنه‌ای است که در آن قرار دارد.

- اگر صحنه‌ای برای هر دو shape و text تنظیم شده باشد، صحنه shape اولویت دارد و صحنه text نادیده گرفته می‌شود.
- اگر shape صحنه خود را نداشته باشد اما نمای سه‌بعدی داشته باشد، صحنه text استفاده می‌شود.
- اگر shape هیچ افکت سه‌بعدی نداشته باشد، به‌عنوان صاف در نظر گرفته می‌شود و افکت سه‌بعدی فقط بر متن اعمال می‌شود.

این رفتارها مربوط به ویژگی‌های [ThreeDFormat.LightRig]‌(https://reference.aspose.com/slides/fa/net/aspose.slides/threedformat/lightrig/) و [ThreeDFormat.Camera]‌(https://reference.aspose.com/slides/fa/net/aspose.slides/threedformat/camera/) هستند.
{{% /alert %}} 

## **پرسش‌های متداول**

**آیا می‌توانم افکت‌های WordArt را با فونت‌ها یا اسکریپت‌های مختلف (مانند عربی، چینی) استفاده کنم؟**

بله، Aspose.Slides برای .NET از یونیکد پشتیبانی می‌کند و با تمام فونت‌ها و اسکریپت‌های اصلی کار می‌کند. افکت‌های WordArt مانند سایه، پرکنش و خط‌کانتور می‌توانند بدون در نظر گرفتن زبان اعمال شوند، هرچند در دسترس بودن فونت و رندر ممکن است به فونت‌های سیستم وابسته باشد.

**آیا می‌توانم افکت‌های WordArt را بر عناصر مستر اسلاید اعمال کنم؟**

بله، می‌توانید افکت‌های WordArt را بر اشکال در مستر اسلایدها، از جمله جای‌دارهای عنوان، فوترها یا متن پس‌زمینه اعمال کنید. تغییرات اعمال‌شده بر طرح مستر در تمام اسلایدهای مرتبط بازتاب خواهد یافت.

**آیا افکت‌های WordArt بر حجم فایل ارائه تأثیر می‌گذارند؟**

به‌صورت کمی. افکت‌های WordArt مانند سایه‌ها، درخشندگی‌ها و پرکنش‌های گرادیان ممکن است به‌دلیل افزودن متادیتای قالب‌بندی، حجم فایل را اندکی افزایش دهند، اما معمولاً این تفاوت غیرقابل‌توجه است.

**آیا می‌توانم نتایج افکت‌های WordArt را بدون ذخیره ارائه پیش‌نمایش کنم؟**

بله، می‌توانید اسلایدهای حاوی WordArt را به تصاویر (مانند PNG یا JPEG) رندر کنید با استفاده از متد `GetImage` از اینترفیس‌های [IShape]‌(https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) یا [ISlide]‌(https://reference.aspose.com/slides/fa/net/aspose.slides/islide/). این کار به شما امکان می‌دهد نتایج را به‌صورت در‑حافظه یا روی صفحه نمایش پیش‌نمایش کنید قبل از ذخیره یا صدور کامل ارائه.