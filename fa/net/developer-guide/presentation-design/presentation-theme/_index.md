---
title: مدیریت تم‌های ارائه در .NET
linktitle: تم ارائه
type: docs
weight: 10
url: /fa/net/presentation-theme/
keywords:
- تم PowerPoint
- تم ارائه
- تم اسلاید
- تنظیم تم
- تغییر تم
- مدیریت تم
- رنگ تم
- پالت اضافی
- فونت تم
- استایل تم
- اثر تم
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "تم‌های ارائه اصلی را در Aspose.Slides برای .NET مدیریت کنید تا فایل‌های PowerPoint را با برندسازی یکسان ایجاد، سفارشی‌سازی و تبدیل کنید."
---
## **معرفی**

یک تم ارائه ویژگی‌های عناصر طراحی را تعریف می‌کند. وقتی تم ارائه‌ای را انتخاب می‌کنید، در واقع مجموعه‌ای خاص از عناصر بصری و ویژگی‌های آن‌ها را برمی‌گزینید.

در PowerPoint، یک تم شامل رنگ‌ها، [فونت‌ها](/slides/fa/net/powerpoint-fonts/)، [سبک‌های پس‌زمینه](/slides/fa/net/presentation-background/)، و افکت‌ها است.

![تم-اجزای]{{theme-constituents.png}}

## **تغییر رنگ تم**

یک تم PowerPoint برای عناصر مختلف یک اسلاید از مجموعه‌ای خاص رنگ استفاده می‌کند. اگر رنگ‌ها را دوست ندارید، می‌توانید با اعمال رنگ‌های جدید برای تم، آن‌ها را تغییر دهید. برای اینکه بتوانید رنگ تم جدیدی را انتخاب کنید، Aspose.Slides مقادیر زیر را تحت enumeration [SchemeColor](https://reference.aspose.com/slides/fa/net/aspose.slides/schemecolor/) ارائه می‌دهد.

این کد C# نحوه تغییر رنگ Accent برای یک تم را نشان می‌دهد:

```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

می‌توانید مقدار موثر رنگ حاصل را به این شکل تعیین کنید:

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (رنگ [A=255, R=128, G=100, B=162])
```

برای نمایش بهتر عملیات تغییر رنگ، عنصر دیگری ایجاد می‌کنیم و رنگ Accent (از عملیات اولیه) را به آن اختصاص می‌دهیم. سپس رنگ تم را تغییر می‌دهیم:

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

رنگ جدید به‌صورت خودکار بر روی هر دو عنصر اعمال می‌شود.

### **تنظیم رنگ تم از یک پالت اضافی**

وقتی تبدیل‌های روشنایی را بر رنگ اصلی تم (1) اعمال می‌کنید، رنگ‌هایی از پالت اضافی (2) تشکیل می‌شود. سپس می‌توانید این رنگ‌های تم را تنظیم و دریافت کنید.

![رنگ‌های‑پالت‑اضافی]{{additional-palette-colors.png}}

**1** - رنگ‌های اصلی تم

**2** - رنگ‌های پالت اضافی.

این کد C# عملیاتی را نشان می‌دهد که در آن رنگ‌های پالت اضافی از رنگ اصلی تم استخراج شده و سپس در شکل‌ها استفاده می‌شوند:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // اکسنت 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // اکسنت 4، روشن‌تر 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // اکسنت 4، روشن‌تر 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // اکسنت 4، روشن‌تر 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // اکسنت 4، تیره‌تر 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // اکسنت 4، تیره‌تر 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **نقش‌گذاری `SchemeColor` به رنگ‌های `IColorScheme`**

هنگام کار با [SchemeColor](https://reference.aspose.com/slides/fa/net/aspose.slides/schemecolor/)، ممکن است متوجه شوید که مقادیر رنگ تم زیر را شامل می‌شود:

`Background1`، `Background2`، `Text1` و `Text2`.

اما `Presentation.MasterTheme.ColorScheme` یک [IColorScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/icolorscheme/) برمی‌گرداند که رنگ‌های متناظر را به این شکل نشان می‌دهد:

`Dark1`، `Dark2`، `Light1` و `Light2`.

این تفاوت فقط در نام‌گذاری است. این مقادیر به همان اسلات‌های رنگ تم ارجاع می‌دهند و نقش‌گذاری ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هیچ تبدیل داینامیکی بین `Text`/`Background` و `Dark`/`Light` وجود ندارد. آن‌ها صرفاً نام‌های جایگزین برای همان رنگ‌های تم هستند.

این تفاوت نام‌گذاری از اصطلاحات Microsoft Office نشأت می‌گیرد. نسخه‌های قدیمی Office از `Dark 1`، `Light 1`، `Dark 2` و `Light 2` استفاده می‌کردند، در حالی که نسخه‌های جدید UI همان اسلات‌ها را به صورت `Text 1`، `Background 1`، `Text 2` و `Background 2` نمایش می‌دهند.

## **تغییر فونت تم**

برای اینکه بتوانید فونت‌ها را برای تم‌ها و مقاصد دیگر انتخاب کنید، Aspose.Slides از این شناسه‌های ویژه (مشابه آن‌هایی که در PowerPoint استفاده می‌شود) بهره می‌برد:

* **+mn‑lt** - فونت بدنه لاتین (Minor Latin Font)
* **+mj‑lt** - فونت سرعنوان لاتین (Major Latin Font)
* **+mn‑ea** - فونت بدنه آسیای شرقی (Minor East Asian Font)
* **+mj‑ea** - فونت سرعنوان آسیای شرقی (Major East Asian Font)

این کد C# نشان می‌دهد چگونه فونت لاتین را به یک عنصر تم اختصاص دهید:

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

این کد C# نحوه تغییر فونت تم ارائه را نشان می‌دهد:

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

فونت تمام جعبه‌های متن به‌روز خواهد شد.

{{% alert color="primary" title="TIP" %}} 
ممکن است بخواهید به [فونت‌های PowerPoint](/slides/fa/net/powerpoint-fonts/) نگاهی بیندازید.
{{% /alert %}}

## **تغییر سبک پس‌زمینه تم**

به‌صورت پیش‌فرض، برنامه PowerPoint 12 پس‌زمینه از پیش تعریف‌شده ارائه می‌دهد اما فقط 3 مورد از این 12 پس‌زمینه در یک ارائه معمولی ذخیره می‌شوند.

![todo:image_alt_text]{{presentation-design_8.png}}

به عنوان مثال، پس از ذخیره یک ارائه در برنامه PowerPoint، می‌توانید این کد C# را اجرا کنید تا تعداد پس‌زمینه‌های پیش‌تعریف‌شده در ارائه را بیابید:

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
با استفاده از ویژگی [BackgroundFillStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) از کلاس [FormatScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/) می‌توانید سبک پس‌زمینه را در یک تم PowerPoint اضافه یا دسترسی پیدا کنید. 
{{% /alert %}}

این کد C# نشان می‌دهد چگونه پس‌زمینه یک ارائه را تنظیم کنید:

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**راهنمای ایندکس**: 0 برای بدون پر استفاده می‌شود. ایندکس از 1 شروع می‌شود.

{{% alert color="primary" title="TIP" %}} 
ممکن است بخواهید به [پس‌زمینه PowerPoint](/slides/fa/net/presentation-background/) نگاهی بیندازید.
{{% /alert %}}

## **تغییر افکت تم**

یک تم PowerPoint معمولاً برای هر آرایه سبک 3 مقدار دارد. این آرایه‌ها به 3 افکت زیر ترکیب می‌شوند: Subtle، Moderate و Intense. به عنوان مثال، این نتیجه زمانی است که افکت‌ها بر یک شکل خاص اعمال شوند:

![todo:image_alt_text]{{presentation-design_10.png}}

با استفاده از 3 ویژگی ([FillStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/fillstyles)، [LineStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/linestyles)، [EffectStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/effectstyles)) از کلاس [FormatScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme) می‌توانید عناصر یک تم را (به‌مراتب انعطاف‌پذیرتر از گزینه‌های موجود در PowerPoint) تغییر دهید.

این کد C# نشان می‌دهد چگونه یک افکت تم را با تغییر بخش‌های مختلف عناصر تغییر دهید:

```c#
using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

تغییرات حاصل در رنگ پر، نوع پر، افکت سایه و غیره:

![todo:image_alt_text]{{presentation-design_11.png}}

## **سؤالات متداول**

**آیا می‌توانم تم را فقط بر یک اسلاید اعمال کنم بدون اینکه مستر را تغییر دهم؟**

بله. Aspose.Slides از بازنویسی تم در سطح اسلاید پشتیبانی می‌کند، بنابراین می‌توانید تم محلی را تنها بر آن اسلاید اعمال کنید در حالی که تم مستر دست نخورده باقی می‌ماند (از طریق [SlideThemeManager](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/slidethememanager/)).

**ایمن‌ترین روش برای انتقال یک تم از یک ارائه به ارائه دیگر چیست؟**

[کلون کردن اسلایدها](/slides/fa/net/clone-slides/) همراه با مستر آن‌ها به ارائه هدف. این کار مستر، چیدمان‌ها و تم مرتبط را حفظ می‌کند تا ظاهر یکسان بماند.

**چگونه می‌توانم مقادیر «موثر» پس از تمام وراثت و بازنویسی‌ها را مشاهده کنم؟**

از نماهای «effective» API برای تم/رنگ/فونت/افکت استفاده کنید. این نماها ویژگی‌های نهایی حل‌شده پس از اعمال مستر به‌علاوه هر بازنویسی محلی را برمی‌گردانند.