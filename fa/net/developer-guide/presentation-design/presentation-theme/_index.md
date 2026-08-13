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
- سبک تم
- اثر تم
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "تم‌های اصلی ارائه در Aspose.Slides برای .NET برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندینگ ثابت."
---
## **معرفی**

یک طرح ارائه ویژگی‌های عناصر طراحی را تعریف می‌کند. هنگامی که یک طرح ارائه را انتخاب می‌کنید، در واقع مجموعه‌ای خاص از عناصر بصری و ویژگی‌های آن‌ها را برمی‌گزینید.

در PowerPoint، یک طرح شامل رنگ‌ها، [فونت‌ها](/slides/fa/net/powerpoint-fonts/)، [سبک‌های پس‌زمینه](/slides/fa/net/presentation-background/) و افکت‌ها است.

![theme-constituents](theme-constituents.png)

## **تغییر رنگ طرح**

یک طرح PowerPoint از مجموعه‌ای خاص از رنگ‌ها برای عناصر مختلف یک اسلاید استفاده می‌کند. اگر رنگ‌ها را دوست ندارید، می‌توانید با اعمال رنگ‌های جدید برای طرح، آن‌ها را تغییر دهید. برای انتخاب رنگ جدید طرح، Aspose.Slides مقادیر را تحت شمارش‌گر [SchemeColor](https://reference.aspose.com/slides/fa/net/aspose.slides/schemecolor/) ارائه می‌دهد.

این کد C# نشان می‌دهد چگونه رنگ تأکید یک طرح را تغییر دهید:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

به این روش می‌توانید مقدار مؤثر رنگ حاصل را تعیین کنید:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    var fillEffective = shape.FillFormat.GetEffective();

    Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (رنگ [A=255, R=128, G=100, B=162])
}
```

برای نشان دادن بیشتر عملیات تغییر رنگ، یک عنصر دیگر ایجاد می‌کنیم و رنگ تأکید (از عملیات اولیه) را به آن اختصاص می‌دهیم. سپس رنگ را در طرح تغییر می‌دهیم:

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.FillFormat.FillType = FillType.Solid;

    otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
}
```

رنگ جدید به‌صورت خودکار بر روی هر دو عنصر اعمال می‌شود.

### **تنظیم رنگ طرح از پالت افزودنی**

هنگامی که تبدیل‌های روشنی را بر رنگ اصلی طرح (1) اعمال می‌کنید، رنگ‌هایی از پالت افزودنی (2) تشکیل می‌شود. سپس می‌توانید آن رنگ‌های طرح را تنظیم و دریافت کنید.

![additional-palette-colors](additional-palette-colors.png)

**1** - رنگ‌های اصلی طرح

**2** - رنگ‌های پالت افزودنی.

این کد C# عملیاتی را نشان می‌دهد که در آن رنگ‌های پالت افزودنی از رنگ اصلی طرح به دست می‌آیند و سپس در شکل‌ها استفاده می‌شوند:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // اکسنت 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // اکسنت 4، روشن تر 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // اکسنت 4، روشن تر 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // اکسنت 4، روشن تر 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // اکسنت 4، تیره تر 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // اکسنت 4، تیره تر 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **نقشه‌برداری `SchemeColor` به رنگ‌های `IColorScheme`**

وقتی با [SchemeColor](https://reference.aspose.com/slides/fa/net/aspose.slides/schemecolor/) کار می‌کنید، ممکن است متوجه شوید که شامل مقادیر رنگی زیر برای طرح است: `Background1`, `Background2`, `Text1` و `Text2`.

اما `Presentation.MasterTheme.ColorScheme` یک [IColorScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/icolorscheme/) باز می‌گرداند که رنگ‌های متناظر را به شکل زیر فراهم می‌کند: `Dark1`, `Dark2`, `Light1` و `Light2`.

این تفاوت فقط در نام‌گذاری است. این مقادیر به همان اسلات‌های رنگی طرح اشاره دارند و نقشه‌برداری ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هیچ تبدیل دینامیکی بین `Text`/`Background` و `Dark`/`Light` وجود ندارد. آن‌ها صرفاً نام‌های جایگزین برای همان رنگ‌های طرح هستند.

این تفاوت نام‌گذاری از اصطلاحات Microsoft Office ناشی می‌شود. نسخه‌های قدیمی Office از `Dark 1`، `Light 1`، `Dark 2` و `Light 2` استفاده می‌کردند، در حالی که نسخه‌های جدید UI همان اسلات‌ها را به صورت `Text 1`، `Background 1`، `Text 2` و `Background 2` نمایش می‌دهند.

## **تغییر فونت طرح**

برای این که بتوانید فونت‌ها را برای طرح‌ها و مقاصد دیگر انتخاب کنید، Aspose.Slides از این شناسه‌های خاص (مشابه آنچه در PowerPoint استفاده می‌شود) استفاده می‌کند:

* **+mn-lt** - فونت متن اصلی لاتین (فونت لاتین جزئی)
* **+mj-lt** - فونت عنوان لاتین (فونت لاتین اصلی)
* **+mn-ea** - فونت متن اصلی آسیای شرقی (فونت آسیای شرقی جزئی)
* **+mj-ea** - فونت متن اصلی آسیای شرقی (فونت آسیای شرقی جزئی)

این کد C# نشان می‌دهد چگونه فونت لاتین را به یک عنصر طرح اختصاص دهید:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.Portions.Add(portion);

    shape.TextFrame.Paragraphs.Add(paragraph);

    portion.PortionFormat.LatinFont = new FontData("+mn-lt");
}
```

این کد C# نشان می‌دهد چگونه فونت طرح ارائه را تغییر دهید:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
}
```

فونت در تمام جعبه‌های متن به‌روز خواهد شد.

{{% alert color="info" title="TIP" %}} 
ممکن است بخواهید [فونت‌های PowerPoint](/slides/fa/net/powerpoint-fonts/) را ببینید.
{{% /alert %}}

## **تغییر سبک پس‌زمینه طرح**

به‌طور پیش‌فرض، برنامه PowerPoint 12 پس‌زمینه پیش‌تعریف شده ارائه می‌دهد اما تنها 3 تا از این 12 پس‌زمینه در یک ارائه معمولی ذخیره می‌شوند. 

![todo:image_alt_text](presentation-design_8.png)

به‌عنوان مثال، پس از ذخیره یک ارائه در برنامه PowerPoint، می‌توانید این کد C# را اجرا کنید تا تعداد پس‌زمینه‌های پیش‌تعریف شده در ارائه را بیابید:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
با استفاده از ویژگی [BackgroundFillStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) از کلاس [FormatScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/)، می‌توانید سبک پس‌زمینه را در یک طرح PowerPoint اضافه یا دسترسی داشته باشید. 
{{% /alert %}}

این کد C# نشان می‌دهد چگونه پس‌زمینه یک ارائه را تنظیم کنید:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Masters[0].Background.StyleIndex = 2;
}
```

**راهنمای شاخص**: مقدار 0 برای بدون پر کردن استفاده می‌شود. شاخص از 1 شروع می‌شود.

{{% alert color="info" title="TIP" %}} 
ممکن است بخواهید [پس‌زمینه PowerPoint](/slides/fa/net/presentation-background/) را ببینید.
{{% /alert %}}

## **تغییر اثر طرح**

یک طرح PowerPoint معمولاً شامل 3 مقدار برای هر آرایه سبک است. این آرایه‌ها به 3 اثر ترکیب می‌شوند: ظریف، متوسط و شدید. به عنوان مثال، این نتیجه است وقتی که این اثرها بر روی یک شکل خاص اعمال می‌شوند:

![todo:image_alt_text](presentation-design_10.png)

با استفاده از 3 ویژگی ([FillStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/fillstyles)، [LineStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/linestyles)، [EffectStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/effectstyles)) از کلاس [FormatScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme) می‌توانید عناصر یک طرح را تغییر دهید (حتی انعطاف‌پذیرتر از گزینه‌های PowerPoint).

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

تغییرات حاصل در رنگ پرکننده، نوع پرکننده، افکت سایه و غیره:

![todo:image_alt_text](presentation-design_11.png)

## **پرسش‌های متداول**

### آیا می‌توانم یک طرح را بر روی یک اسلاید واحد اعمال کنم بدون اینکه مستر را تغییر دهم؟

بله. Aspose.Slides از نادیده‌گیری‌های طرح در سطح اسلاید پشتیبانی می‌کند، بنابراین می‌توانید یک طرح محلی را فقط برای آن اسلاید اعمال کنید در حالی که طرح مستر دست‌نخورده باقی می‌ماند (از طریق [SlideThemeManager](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/slidethememanager/)).

### ایمن‌ترین روش برای انتقال یک طرح از یک ارائه به ارائه دیگر چیست؟

[کلون اسلایدها](/slides/fa/net/clone-slides/) همراه با مسترشان به ارائه مقصد منتقل کنید. این کار مستر اصلی، چیدمان‌ها و طرح مرتبط را حفظ می‌کند تا ظاهر یکسان باقی بماند.

### چگونه می‌توانم مقادیر "موثر" را پس از تمام وراثت و نادیده‌گیری‌ها ببیند؟

از نمای ["effective"](/slides/fa/net/shape-effective-properties/) API برای طرح/رنگ/فونت/اثر استفاده کنید. این نماها ویژگی‌های نهایی و حل‌شده را پس از اعمال مستر به علاوه هرگونه نادیده‌گیری محلی برمی‌گردانند.