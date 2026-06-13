---
title: سفارشی‌سازی نواحی نمودارهای ارائه در JavaScript
linktitle: ناحیه نمودار
type: docs
url: /fa/nodejs-java/chart-plot-area/
keywords:
- نمودار
- ناحیه نمودار
- عرض ناحیه نمودار
- ارتفاع ناحیه نمودار
- اندازه ناحیه نمودار
- حالت چیدمان
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "کشف کنید چگونه نواحی نمودارهای PowerPoint را با JavaScript و Aspose.Slides برای Node.js سفارشی کنید. به‌راحتی جلوه‌های بصری اسلایدهای خود را بهبود دهید."
---
## **نمای کلی**

این مقاله نشان می‌دهد که چگونه با ناحیه نمودار در Aspose.Slides کار کنید. توضیح می‌دهد که چگونه موقعیت و اندازه واقعی ناحیه نمودار را با اعتبارسنجی چیدمان نمودار و سپس خواندن مقادیر X، Y، عرض و ارتفاع آن به دست آورید.

همچنین نشان می‌دهد که چگونه حالت چیدمان ناحیه نمودار را زمانی که چیدمان به صورت دستی تنظیم شده است، پیکربندی کنید، با استفاده از `LayoutTargetType` برای تعیین اینکه آیا ناحیه نمودار بر اساس ناحیه داخلی یا ناحیه خارجی به همراه محورها و برچسب‌های محورها محاسبه می‌شود.

## **دریافت عرض و ارتفاع ناحیه نمودار**

Aspose.Slides for Node.js via Java یک API ساده ارائه می‌دهد برای .

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. نمودار را با داده‌های پیش‌فرض اضافه کنید.
4. قبل از به دست آوردن مقادیر واقعی، متد [Chart.validateChartLayout()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Chart#validateChartLayout--) را فراخوانی کنید.
5. موقعیت X واقعی (چپ) عنصر نمودار را نسبت به گوشهٔ بالا‑چپ نمودار دریافت می‌کند.
6. بالای واقعی عنصر نمودار را نسبت به گوشهٔ بالا‑چپ نمودار دریافت می‌کند.
7. عرض واقعی عنصر نمودار را دریافت می‌کند.
8. ارتفاع واقعی عنصر نمودار را دریافت می‌کند.

```javascript
// ایجاد یک نمونه از کلاس Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم حالت چیدمان ناحیه نمودار**

Aspose.Slides for Node.js via Java یک API ساده برای تنظیم حالت چیدمان ناحیه نمودار فراهم می‌کند. متدهای [**setLayoutTargetType**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) و [**getLayoutTargetType**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) به کلاس [**ChartPlotArea**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartPlotArea) اضافه شده‌اند. اگر چیدمان ناحیه نمودار به صورت دستی تعریف شده باشد، این ویژگی مشخص می‌کند که ناحیه نمودار بر اساس داخل آن (بدون شامل محورها و برچسب‌های محورها) یا خارج آن (شامل محورها و برچسب‌های محورها) چیدمان شود. دو مقدار ممکن وجود دارد که در شمارش‌گر [**LayoutTargetType**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/LayoutTargetType) تعریف شده‌اند.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/LayoutTargetType#Inner) - مشخص می‌کند که اندازه ناحیه نمودار، اندازهٔ ناحیه نمودار را تعیین می‌کند و شامل علامت‌های تیک و برچسب‌های محور نمی‌شود.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/LayoutTargetType#Outer) - مشخص می‌کند که اندازه ناحیه نمودار، اندازهٔ ناحیه نمودار، علامت‌های تیک و برچسب‌های محور را تعیین می‌کند.

کد نمونه در زیر آورده شده است.

```javascript
// ایجاد یک نمونه از کلاس Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سؤالات متداول**

**در چه واحدهایی مقدارهای X واقعی، Y واقعی، عرض واقعی و ارتفاع واقعی بازگردانده می‌شوند؟**

در نقاط؛ 1 اینچ = 72 نقطه. این‌ها واحدهای مختصات Aspose.Slides هستند.

**ناحیه نمودار (Plot Area) چگونه با ناحیه چارت (Chart Area) از نظر محتوا متفاوت است؟**

ناحیه نمودار منطقهٔ رسم داده‌ها است (سری‌ها، خطوط شبکه، خطوط روند و غیره)؛ ناحیه چارت شامل عناصر اطراف آن (عنوان، راهنما، و غیره) می‌شود. در نمودارهای سه‌بعدی، ناحیه نمودار همچنین شامل دیوارها/کف و محورها است.

**مقادیر X، Y، عرض و ارتفاع ناحیه نمودار هنگام چیدمان دستی چگونه تفسیر می‌شوند؟**

آنها کسری (۰–۱) از اندازهٔ کل نمودار هستند؛ در این حالت، موقعیت‌یابی خودکار غیرفعال می‌شود و کسری که تنظیم کرده‌اید استفاده می‌شود.

**چرا موقعیت ناحیه نمودار پس از افزودن/جابه‌جایی راهنما تغییر کرد؟**

راهنما در ناحیه چارت خارج از ناحیه نمودار قرار می‌گیرد اما بر چیدمان و فضای موجود تأثیر می‌گذارد، بنابراین ممکن است ناحیه نمودار هنگام فعال بودن موقعیت‌یابی خودکار جابجا شود. (این رفتار استاندارد نمودارهای PowerPoint است.)