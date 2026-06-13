---
title: سفارشی‌سازی لگن‌های نمودار در ارائه‌ها با .NET
linktitle: لگن نمودار
type: docs
url: /fa/net/chart-legend/
keywords:
- لگن نمودار
- موقعیت لگن
- اندازه قلم
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "لگن‌های نمودار را با Aspose.Slides برای .NET سفارشی کنید تا ارائه‌های پاورپوینت را با قالب‌بندی ویژه لگن بهینه‌سازی کنید."
---
## **مرور کلی**

Aspose.Slides گزینه‌هایی برای سفارشی‌سازی لگن نمودارها در ارائه‌های PowerPoint فراهم می‌کند. این مقاله نشان می‌دهد چگونه لگن را موقعیت‌دهی و اندازه‌گیری کنید، اندازه قلم کل لگن را تنظیم کنید و قالب‌بندی را برای یک ورودی منفرد لگن اعمال کنید.

همچنین در بخش سوالات متداول به چند رفتار مرتبط پرداخته می‌شود، از جمله استفاده از حالت غیر‑پوششی (non‑overlay) تا ناحیه رسم برای لگن فضا ایجاد کند، اجازه به بسته شدن خودکار برچسب‌های طولانی یا استفاده از شکست خط، و امکان ارث‌بری قالب‌بندی لگن از تم ارائه هنگامی‌که تنظیمات صریح متن و پر کردن اعمال نشده باشد.

## **موقعیت لگن**
برای تنظیم ویژگی‌های لگن، مراحل زیر را دنبال کنید:

- ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation).
- دریافت مرجع اسلاید.
- افزودن یک نمودار به اسلاید.
- تنظیم ویژگی‌های لگن.
- نوشتن ارائه به‌صورت فایل PPTX.

در مثال زیر، موقعیت و اندازه لگن نمودار را تنظیم کرده‌ایم.

```c#
 // Create an instance of Presentation class
 // Get reference of the slide
 // Add a clustered column chart on the slide
 // Set Legend Properties
 // Write presentation to disk
Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```

## **تنظیم اندازه قلم لگن**
Aspose.Slides برای .NET به توسعه‌دهندگان امکان تنظیم اندازه قلم لگن را می‌دهد. لطفاً مراحل زیر را دنبال کنید:

- نمونه‌سازی کلاس `Presentation`.
- ایجاد نمودار پیش‌فرض.
- تنظیم اندازه قلم.
- تنظیم مقدار حداقل محور.
- تنظیم مقدار بیشینه محور.
- نوشتن ارائه روی دیسک.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **تنظیم اندازه قلم یک ورودی لگن**
Aspose.Slides برای .NET به توسعه‌دهندگان امکان تنظیم اندازه قلم ورودی‌های منفرد لگن را می‌دهد. لطفاً مراحل زیر را دنبال کنید:

- نمونه‌سازی کلاس `Presentation`.
- ایجاد نمودار پیش‌فرض.
- دسترسی به ورودی لگن.
- تنظیم اندازه قلم.
- تنظیم مقدار حداقل محور.
- تنظیم مقدار بیشینه محور.
- نوشتن ارائه روی دیسک.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

**آیا می‌توانم لگن را فعال کنم تا نمودار به‌صورت خودکار برای آن فضا اختصاص دهد به‌جای اینکه آن را روی‌هم قرار دهد؟**

بله. از حالت غیر‑پوششی استفاده کنید ([Overlay](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/legend/overlay/) = `false`); در این صورت ناحیه رسم برای جا دادن به لگن کوچک می‌شود.

**آیا می‌توانم برچسب‌های لگن چندخطی داشته باشم؟**

بله. برچسب‌های طولانی به‌صورت خودکار در صورت عدم کافی بودن فضا به خطوط بعدی می‌رسند؛ شکست خط اجباری نیز از طریق کاراکترهای newline در نام سری پشتیبانی می‌شود.

**چگونه می‌توانم لگن را طوری تنظیم کنم که رنگ‌های آن از طرح رنگ تم ارائه ارث‌بری شود؟**

به‌جای تعیین صریح رنگ‌ها/پرکردن‌ها/قلم‌ها برای لگن یا متن آن، این ویژگی‌ها را تنظیم نکنید. در این صورت رنگ‌ها از تم ارث‌بری می‌شوند و هنگام تغییر طراحی به‌درستی به‌روز می‌شوند.