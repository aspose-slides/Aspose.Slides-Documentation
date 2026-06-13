---
title: سفارشی‌سازی نواحی رسم نمودارهای ارائه در .NET
linktitle: ناحیه رسم
type: docs
url: /fa/net/chart-plot-area/
keywords:
- نمودار
- ناحیه رسم
- عرض ناحیه رسم
- ارتفاع ناحیه رسم
- اندازه ناحیه رسم
- حالت چیدمان
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کشف کنید چگونه نواحی رسم نمودارها را در ارائه‌های PowerPoint با Aspose.Slides برای .NET سفارشی‌سازی کنید. به راحتی جلوه‌های بصری اسلایدهای خود را بهبود دهید."
---
## **مروری کلی**

این مقاله نشان می‌دهد که چگونه با ناحیهٔ رسم نمودار در Aspose.Slides کار کنید. توضیح می‌دهد که چگونه با اعتبارسنجی چیدمان نمودار، موقعیت و اندازه واقعی ناحیهٔ رسم را به‌دست آورید و سپس مقادیر X، Y، عرض و ارتفاع آن را بخوانید.

همچنین نشان می‌دهد چگونه حالت چیدمان ناحیهٔ رسم را هنگام تنظیم دستی چیدمان، با استفاده از `LayoutTargetType` برای تعریف اینکه ناحیهٔ رسم بر اساس ناحیهٔ داخلی یا ناحیهٔ خارجی همراه با محورها و برچسب‌های محورها محاسبه شود، پیکربندی کنید.

## **دریافت عرض و ارتفاع ناحیهٔ رسم نمودار**
Aspose.Slides برای .NET یک API ساده فراهم می‌کند برای .

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. نمودار با داده‌های پیش‌فرض اضافه کنید.
4. قبل از دریافت مقادیر واقعی، متد IChart.ValidateChartLayout() را فراخوانی کنید.
5. موقعیت X واقعی (چپ) عنصر نمودار را نسبت به گوشهٔ بالای چپ نمودار دریافت می‌کند.
6. موقعیت Y واقعی (بالا) عنصر نمودار را نسبت به گوشهٔ بالای چپ نمودار دریافت می‌کند.
7. عرض واقعی عنصر نمودار را دریافت می‌کند.
8. ارتفاع واقعی عنصر نمودار را دریافت می‌کند.

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// ذخیره ارائه با نمودار
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```

## **تنظیم حالت چیدمان ناحیهٔ رسم نمودار**
Aspose.Slides برای .NET یک API ساده برای تنظیم حالت چیدمان ناحیهٔ رسم نمودار فراهم می‌کند. ویژگی **LayoutTargetType** به کلاس‌های **ChartPlotArea** و **IChartPlotArea** اضافه شده است. اگر چیدمان ناحیهٔ رسم به‌صورت دستی تعریف شده باشد، این ویژگی تعیین می‌کند که ناحیهٔ رسم بر اساس داخل (بدون محورها و برچسب‌های محورها) یا خارج (شامل محورها و برچسب‌های محورها) چیدمان شود. دو مقدار ممکن وجود دارد که در پیمانه **LayoutTargetType** تعریف شده‌اند.

- **LayoutTargetType.Inner** - مشخص می‌کند که اندازه ناحیهٔ رسم بر اساس خود ناحیهٔ رسم تعیین شود و شامل علائم تقسیم‌بندی و برچسب‌های محور نباشد.
- **LayoutTargetType.Outer** - مشخص می‌کند که اندازه ناحیهٔ رسم شامل خود ناحیهٔ رسم، علائم تقسیم‌بندی و برچسب‌های محور باشد.

کد نمونه در زیر ارائه شده است.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

**واحدهای بازگشتی ActualX، ActualY، ActualWidth و ActualHeight چیست؟**

بر حسب پوینت؛ 1 اینچ = 72 پوینت. این‌ها واحدهای مختصات Aspose.Slides هستند.

**ناحیهٔ رسم (Plot Area) چگونه با ناحیهٔ نمودار (Chart Area) از نظر محتوا متفاوت است؟**

ناحیهٔ رسم ناحیهٔ رسم داده‌ها (سری‌ها، خطوط شبکه، خطوط روند و غیره) است؛ ناحیهٔ نمودار عناصر اطراف را شامل می‌شود (عنوان، legend و غیره). در نمودارهای سه‌بعدی، ناحیهٔ رسم همچنین شامل دیوارها/کف و محورها است.

**در صورت چیدمان دستی، مقادیر X، Y، Width و Height ناحیهٔ رسم چگونه تفسیر می‌شوند؟**

آنها کسری (0–1) از اندازه کلی نمودار هستند؛ در این حالت موقعیت‌یابی خودکار غیرفعال می‌شود و کسری که تنظیم می‌کنید استفاده می‌شود.

**چرا پس از افزودن/جابه‌جایی legend موقعیت ناحیهٔ رسم تغییر کرد؟**

legend در ناحیهٔ نمودار خارج از ناحیهٔ رسم قرار می‌گیرد اما بر چیدمان و فضای موجود تأثیر می‌گذارد، بنابراین در زمانی که موقعیت‌یابی خودکار فعال است، ناحیهٔ رسم ممکن است جابه‌جا شود. (این رفتار استاندارد برای نمودارهای PowerPoint است.)