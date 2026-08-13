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
- افکت درخشندگی
- تبدیل WordArt
- افکت ۳بعدی
- افکت سایه خارجی
- افکت سایه داخلی
- .NET
- C#
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی افکت‌های WordArt در Aspose.Slides برای .NET. این راهنمای گام به گام به توسعه‌دهندگان کمک می‌کند تا ارائه‌ها را با متن حرفه‌ای در C# بهبود دهند."
---
## **بررسی کلی**

افکت‌های WordArt به شما امکان می‌دهند متن‌های بصری جذاب و استایل‌دار را به ارائه‌های PowerPoint خود اضافه کنید. با Aspose.Slides برای .NET، توسعه‌دهندگان می‌توانند به‌صورت برنامه‌نویسی WordArt را ایجاد، سفارشی‌سازی و مدیریت کنند همانند Microsoft PowerPoint — بدون نیاز به نصب Office. این مقاله نمای کلی کار با WordArt در .NET را ارائه می‌دهد، از جمله نحوه اعمال تبدیلات متن، سبک‌های پر، خطوط حاشیه، سایه‌ها و سایر گزینه‌های قالب‌بندی برای بیان‌گراتر و جذاب‌تر کردن محتوای ارائه شما. WordArt به شما اجازه می‌دهد متن را به‌عنوان یک شیء گرافیکی در نظر بگیرید. این شامل افکت‌ها یا اصلاحات ویژه‌ای است که بر متن اعمال می‌شوند تا جذاب‌تر یا قابل توجه‌تر باشد.

## **ایجاد یک الگوی ساده WordArt و اعمال آن بر متن**

در این بخش، نحوه ایجاد یک الگوی ساده WordArt و اعمال آن بر متن با استفاده از Aspose.Slides برای .NET را بررسی می‌کنیم. WordArt روشی آسان برای بهبود ظاهر متن با افکت‌ها و سبک‌های بصری برجسته فراهم می‌کند. با یادگیری گام‌های پایهٔ ایجاد و استفاده از WordArt، می‌توانید این تکنیک‌ها را به‌سرعت برای هر پروژه‌ای تطبیق دهید و ارائه‌های خود را زنده‌تر و به‌یادماندنی‌تر کنید.

ابتدا متن ساده‌ای با استفاده از کد C# زیر ایجاد می‌کنیم:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```

سپس، ارتفاع فونت متن را به مقدار بزرگ‌تری تنظیم می‌کنیم تا اثر واضح‌تر باشد، با استفاده از کد زیر:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";

    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
}
```

در اینجا، پر کردن الگوی SmallGrid را به متن اعمال می‌کنیم و یک حاشیه متن سیاه با عرض ۱ اضافه می‌کنیم، با استفاده از کد زیر:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
}
```

متن حاصل:

![قالب ساده WordArt](WordArt_template.png)

## **اعمال افکت‌های دیگر WordArt**

علی‌رغم تبدیلات پایه، Aspose.Slides برای .NET به شما اجازه می‌دهد انواع افکت‌های پیشرفتهٔ WordArt را برای بهبود ظاهر متن خود اعمال کنید. این افکت‌ها شامل خطوط حاشیه، پرکننده‌ها، سایه‌ها، انعکاس‌ها و افکت‌های درخشندگی هستند. با ترکیب این ویژگی‌ها می‌توانید سبک‌های متنی چشم‌نواز ایجاد کنید که در ارائه‌های شما برجسته می‌شوند. این بخش نشان می‌دهد چگونه این افکت‌ها را به‌صورت برنامه‌نویسی با مثال‌های کد ساده و تمیز اعمال کنید.

### **اعمال افکت‌های سایهٔ خارجی**

افکت‌های سایهٔ خارجی به متن کمک می‌کنند تا با افزودن سایه‌ای پشت حاشیهٔ آن، برتری پیدا کند و حس عمق و جدایی از پس‌زمینه ایجاد شود. Aspose.Slides برای .NET به شما امکان می‌دهد به‌راحتی سایه‌های خارجی را بر متن WordArt اعمال و سفارشی‌سازی کنید. در این بخش، نحوه تنظیم رنگ سایه، جهت، فاصله، شعاع محو شدن و موارد دیگر را برای دستیابی به تأثیر بصری مطلوب یاد می‌گیرید.

کد C# زیر یک افکت سایه را بر متن ایجاد شده در بالا اعمال می‌کند.

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
}
```

![افکت سایهٔ خارجی](outer_shadow_effect.png)

{{% alert color="info" %}} 
- زمانی که OuterShadow و PresetShadow همزمان استفاده شوند، فقط افکت OuterShadow اعمال می‌شود.
- اگر OuterShadow و InnerShadow همزمان استفاده شوند، اثر نهایی به نسخهٔ PowerPoint بستگی دارد. به عنوان مثال، در PowerPoint 2013، اثر دو برابر می‌شود، در حالی که در PowerPoint 2007، تنها افکت OuterShadow اعمال می‌شود.
{{% /alert %}}

### **اعمال افکت‌های انعکاس**

در این بخش، نحوه اعمال افکت‌های انعکاس در اسلایدهای خود با استفاده از Aspose.Slides برای .NET را بررسی می‌کنیم. افکت‌های انعکاس می‌توانند راهی مؤثر برای دادن ظاهری شیک و مدرن به متن یا اشکال شما باشند، باعث برجسته شدن عناصر کلیدی می‌شوند و عمق به ارائه‌تان می‌افزایند. با درک فرایند اعمال و سفارشی‌سازی این افکت‌ها، می‌توانید به‌سادگی آن‌ها را مطابق نیازهای طراحی و برندینگ خود تنظیم کنید.

با استفاده از مثال کد C# زیر، افکت انعکاس را به متن اضافه کنید:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
}
```

![افکت انعکاس](reflection_effect.png)

### **اعمال افکت‌های درخشندگی**

در این بخش، نحوهٔ اعمال افکت درخشندگی به متن با استفاده از Aspose.Slides برای .NET را بررسی می‌کنیم. افکت درخشندگی می‌تواند متن شما را با حاشیه‌ای نورانی برجسته کند و جذابیت بصری اسلایدها را افزایش دهد. با تنظیماتی مانند رنگ و شدت، می‌توانید به‌راحتی درخشندگی را مطابق نیازهای طراحی و برندینگ خود تنظیم کنید تا نکات کلیدی در ارائه‌تان توجه مخاطبان را جلب کند.

با استفاده از کد زیر، افکت درخشندگی را به متن اعمال کنید تا بدرخشید یا برجسته شود:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
}
```

![افکت درخشندگی](glow_effect.png)

### **اعمال تبدیلات WordArt**

در این بخش، نحوه استفاده از تبدیلات در WordArt با Aspose.Slides برای .NET را بررسی می‌کنیم. تبدیلات به شما اجازه می‌دهند متن را خم، کشیده یا منحنی کنید و افکت‌های منحصربه‌فرد و بصری جذابی ایجاد کنید. با تسلط بر این تکنیک‌ها، می‌توانید به‌راحتی شکل‌ها و سبک‌های متن را مطابق با برند یا چشم‌انداز خلاقانه خود تنظیم کنید و ارائه‌ای جذاب و صیقلی فراهم کنید.

از ویژگی `Transform` (که بر کل بلوک متن اعمال می‌شود) با استفاده از کد زیر استفاده کنید:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
}
```

![تبدیل WordArt](transform_effect.png)

{{% alert color="info" %}} 
Aspose.Slides for .NET مجموعه‌ای از [انواع تبدیل](https://reference.aspose.com/slides/fa/net/aspose.slides/textshapetype/) پیش‌تعریف‌شده را ارائه می‌دهد.
{{% /alert %}} 

### **اعمال افکت‌های سه‌بعدی بر اشکال و متن**

ایجاد جلوه‌های بصری واقعی و چشم‌نواز می‌تواند تأثیر ارائه‌های شما را به‌طرزی قابل‌توجه افزایش دهد. در این بخش، نحوهٔ اعمال افکت‌های سه‌بعدی (3D) بر اشکال را با استفاده از Aspose.Slides برای .NET بررسی می‌کنیم. با تنظیم پارامترهایی مانند عمق، زاویه و نورپردازی، می‌توانید تبدیلات 3D چشمگیری ایجاد کنید که بلافاصله توجه مخاطبان را جلب می‌کند. چه به‌دنبال برجسته‌سازی‌های ظریف باشید و چه به‌دنبال توهمات драматیک، این ویژگی‌ها روش‌های انعطاف‌پذیری برای ارتقاء طراحی و انتقال ایده‌ها به شکلی جذاب‌تر ارائه می‌دهند.

از کد نمونه زیر برای تنظیم افکت 3D بر شکل استفاده کنید:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
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
}
```

![افکت 3D شکل](shape_3D_effect.png)

از کد نمونه زیر برای تنظیم افکت 3D بر متن استفاده کنید:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
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
}
```

![افکت 3D متن](text_3D_effect.png)

{{% alert color="info" %}} 
اعمال افکت‌های سه‌بعدی بر متن یا اشکال آن—و تعامل بین این افکت‌ها—بر اساس قوانین خاصی تنظیم می‌شود. صحنه‌ای را در نظر بگیرید که هم متن و هم شکلی که متن درون آن قرار دارد شامل شود. یک افکت 3D شامل نمایش سه‌بعدی شیء و صحنه‌ای است که بر روی آن قرار گرفته است.

- اگر صحنه‌ای برای هر دو، شکل و متن تنظیم شده باشد، صحنهٔ شکل اولویت دارد و صحنهٔ متن نادیده گرفته می‌شود.
- اگر شکل صحنهٔ خود را نداشته باشد ولی نمایش سه‌بعدی داشته باشد، صحنهٔ متن مورد استفاده قرار می‌گیرد.
- اگر شکل به‌طور کامل فاقد افکت 3D باشد، به‌صورت صاف در نظر گرفته می‌شود و افکت 3D فقط بر متن اعمال می‌شود.

این رفتارها به ویژگی‌های [ThreeDFormat.LightRig](https://reference.aspose.com/slides/fa/net/aspose.slides/threedformat/lightrig/) و [ThreeDFormat.Camera](https://reference.aspose.com/slides/fa/net/aspose.slides/threedformat/camera/) مرتبط هستند.
{{% /alert %}} 

## **پرسش‌های متداول**

### آیا می‌توانم افکت‌های WordArt را با قلم‌ها یا اسکریپت‌های مختلف (مانند عربی، چینی) استفاده کنم؟

بله، Aspose.Slides برای .NET از یونیکد پشتیبانی می‌کند و با تمام قلم‌ها و اسکریپت‌های اصلی کار می‌کند. افکت‌های WordArt مانند سایه، پر کردن و حاشیه می‌توانند بدون توجه به زبان اعمال شوند، هرچند دسترسی به قلم و رندرینگ آن ممکن است به قلم‌های سیستم وابسته باشد.

### آیا می‌توانم افکت‌های WordArt را بر عناصر مستر اسلاید اعمال کنم؟

بله، می‌توانید افکت‌های WordArt را بر اشکال در مستر اسلایدها اعمال کنید، از جمله جایگاه‌دارهای عنوان، پاورقی‌ها یا متن پس‌زمینه. تغییرات انجام شده در طرح مستر در تمام اسلایدهای مرتبط انعکاس خواهد یافت.

### آیا افکت‌های WordArt بر حجم فایل ارائه تأثیر می‌گذارند؟

تا حدودی. افکت‌های WordArt مانند سایه‌ها، درخشندگی‌ها و پرکننده‌های گرادیانی می‌توانند به‌خاطر افزودن متاداده‌های قالب‌بندی، کمی حجم فایل را افزایش دهند، اما این اختلاف معمولاً ناچیز است.

### آیا می‌توانم نتایج افکت‌های WordArt را بدون ذخیرهٔ ارائه پیش‌نمایش کنم؟

بله، می‌توانید اسلایدهای حاوی WordArt را به تصویر (مثلاً PNG، JPEG) رندر کنید با استفاده از متد `GetImage` از رابط‌های [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) یا [ISlide](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/). این امکان را می‌دهد که نتیجه را به‌صورت در‑حافظه یا روی صفحه پیش‌نمایش کنید قبل از ذخیره یا خروجی‌گیری از ارائه کامل.