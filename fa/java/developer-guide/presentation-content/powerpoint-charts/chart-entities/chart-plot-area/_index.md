---
title: سفارشی‌سازی نواحی رسم نمودارهای ارائه در جاوا
linktitle: ناحیه رسم
type: docs
url: /fa/java/chart-plot-area/
keywords:
- نمودار
- ناحیه رسم
- عرض ناحیه رسم
- ارتفاع ناحیه رسم
- اندازه ناحیه رسم
- حالت چینش
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "کشف کنید چگونه نواحی رسم نمودارها را در ارائه‌های PowerPoint با Aspose.Slides برای Java سفارشی کنید. به راحتی جلوه‌های بصری اسلایدهای خود را بهبود دهید."
---
## **مروری کلی**

این مقاله نشان می‌دهد چگونه با ناحیهٔ رسم نمودار در Aspose.Slides کار کنید. این مقاله توضیح می‌دهد چگونه موقعیت و اندازه واقعی ناحیهٔ رسم را با اعتبارسنجی چینش نمودار و سپس خواندن مقادیر X، Y، عرض و ارتفاع آن به‌دست آورید.

همچنین نشان می‌دهد چگونه حالت چینش ناحیهٔ رسم را هنگام تنظیم دستی چینش پیکربندی کنید، با استفاده از `LayoutTargetType` برای تعریف اینکه آیا ناحیهٔ رسم بر اساس ناحیه داخلی یا ناحیه خارجی همراه با محورها و برچسب‌های محور محاسبه شود.

## **دریافت عرض و ارتفاع ناحیهٔ رسم نمودار**
Aspose.Slides for Java یک API ساده برای . فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. نمودار را با داده‌های پیش‌فرض اضافه کنید.
4. قبل از دریافت مقادیر واقعی، متد [IChart.validateChartLayout()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChart#validateChartLayout--) را فراخوانی کنید.
5. موقعیت X واقعی (چپ) عنصر نمودار را نسبت به گوشهٔ بالایی سمت چپ نمودار به‌دست می‌آورد.
6. موقعیت بالای واقعی عنصر نمودار را نسبت به گوشهٔ بالایی سمت چپ نمودار به‌دست می‌آورد.
7. عرض واقعی عنصر نمودار را به‌دست می‌آورد.
8. ارتفاع واقعی عنصر نمودار را به‌دست می‌آورد.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم حالت چینش ناحیهٔ رسم نمودار**
Aspose.Slides برای Java یک API ساده برای تنظیم حالت چینش ناحیهٔ رسم نمودار فراهم می‌کند. متدهای [**setLayoutTargetType**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) و [**getLayoutTargetType**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) به کلاس [**ChartPlotArea**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ChartPlotArea) و اینترفیس [**IChartPlotArea**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartPlotArea) اضافه شده‌اند. اگر چینش ناحیهٔ رسم به‌صورت دستی تعریف شود، این خصوصیت مشخص می‌کند که ناحیهٔ رسم بر اساس داخل (بدون شامل محور و برچسب‌های محور) یا خارج (شامل محور و برچسب‌های محور) چینش یابد. دو مقدار ممکن وجود دارد که در شمارش [**LayoutTargetType**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/LayoutTargetType) تعریف شده‌اند.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/LayoutTargetType#Inner) - مشخص می‌کند که اندازه ناحیهٔ رسم، اندازهٔ ناحیهٔ رسم را تعیین کند، بدون شامل علامت‌های تقسیم‌بندی و برچسب‌های محور.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/LayoutTargetType#Outer) - مشخص می‌کند که اندازه ناحیهٔ رسم، اندازهٔ ناحیهٔ رسم، علامت‌های تقسیم‌بندی و برچسب‌های محور را تعیین کند.

کد نمونه در زیر ارائه شده است.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **پرسش‌های متداول**

**واحدهای بازگردانده‌شده برای x واقعی، y واقعی، عرض واقعی و ارتفاع واقعی چیست؟**

در واحد نقطه؛ ۱ اینچ = ۷۲ نقطه. این‌ها واحدهای مختصات Aspose.Slides هستند.

**ناحیهٔ رسم چه تفاوتی با ناحیهٔ نمودار از نظر محتوا دارد؟**

ناحیهٔ رسم، ناحیهٔ رسم داده‌ها (سری‌ها، خطوط شبکه، خطوط روند و غیره) است؛ ناحیهٔ نمودار شامل عناصر اطراف مثل عنوان، کلید راهنما و غیره می‌شود. در نمودارهای سه‌بعدی، ناحیهٔ رسم همچنین شامل دیوارها/کف و محورها می‌شود.

**هنگامی که چینش به‌صورت دستی باشد، مقادیر x، y، عرض و ارتفاع ناحیهٔ رسم چگونه تفسیر می‌شوند؟**

آنها کسری (۰ تا ۱) از اندازه کلی نمودار هستند؛ در این حالت، موقعیت‌یابی خودکار غیرفعال می‌شود و کسری که تنظیم می‌کنید مورد استفاده قرار می‌گیرد.

**چرا موقعیت ناحیهٔ رسم پس از افزودن/جابجایی کلید راهنما تغییر کرد؟**

کلید راهنما در ناحیهٔ نمودار خارج از ناحیهٔ رسم قرار می‌گیرد اما بر چینش و فضای موجود تأثیر می‌گذارد، بنابراین ناحیهٔ رسم ممکن است وقتی موقعیت‌یابی خودکار فعال است جابجا شود. (این رفتار استاندارد در نمودارهای PowerPoint است.)