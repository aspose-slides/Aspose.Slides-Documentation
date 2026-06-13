---
title: سفارشی‌سازی نواحی طرح نمودارهای ارائه در Android
linktitle: ناحیه‌پلات
type: docs
url: /fa/androidjava/chart-plot-area/
keywords:
- نمودار
- ناحیه‌پلات
- عرض ناحیه‌پلات
- ارتفاع ناحیه‌پلات
- اندازه ناحیه‌پلات
- حالت طرح
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "کشف کنید چگونه نواحی طرح نمودارها را در ارائه‌های PowerPoint با Aspose.Slides برای Android از طریق Java سفارشی کنید. به‌سادگی ظاهر اسلایدهای خود را بهبود دهید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد که چگونه با ناحیه‌پلات یک نمودار در Aspose.Slides کار کنید. توضیح می‌دهد که چگونه موقعیت و اندازه واقعی ناحیه‌پلات را با اعتبارسنجی طرح نمودار و سپس خواندن مقادیر X، Y، عرض و ارتفاع آن به دست آورید.

همچنین نشان می‌دهد که چگونه حالت طرح ناحیه‌پلات را زمانی که طرح به‌صورت دستی تنظیم شده است، پیکربندی کنید، با استفاده از `LayoutTargetType` برای تعیین اینکه ناحیه‌پلات بر اساس منطقه داخلی یا منطقه خارجی همراه با محورها و برچسب‌های محورها محاسبه شود.

## **دریافت عرض و ارتفاع ناحیه‌پلات نمودار**

Aspose.Slides for Android via Java یک API ساده فراهم می‌کند برای .

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. نمودار را با داده‌های پیش‌فرض اضافه کنید.
4. قبل از دریافت مقادیر واقعی، متد [IChart.validateChartLayout()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChart#validateChartLayout--) را فراخوانی کنید.
5. موقعیت X واقعی (چپ) عنصر نمودار را نسبت به گوشهٔ بالای چپ نمودار به دست می‌آورد.
6. بالای واقعی عنصر نمودار را نسبت به گوشهٔ بالای چپ نمودار به دست می‌آورد.
7. عرض واقعی عنصر نمودار را به دست می‌آورد.
8. ارتفاع واقعی عنصر نمودار را به دست می‌آورد.

```java
// ایجاد یک نمونه از کلاس Presentation
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

## **تنظیم حالت طرح ناحیه‌پلات نمودار**

Aspose.Slides برای Android از طریق Java یک API ساده برای تنظیم حالت طرح ناحیه‌پلات نمودار فراهم می‌کند. متدهای [**setLayoutTargetType**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) و [**getLayoutTargetType**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) به کلاس [**ChartPlotArea**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ChartPlotArea) و رابط [**IChartPlotArea**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartPlotArea) اضافه شده‌اند. اگر طرح ناحیه‌پلات به‌صورت دستی تعریف شود، این ویژگی مشخص می‌کند که ناحیه‌پلات بر اساس داخل (بدون شامل کردن محورها و برچسب‌های محورها) یا خارج (شامل محورها و برچسب‌های محورها) چیدمان شود. دو مقدار ممکن وجود دارد که در شمارندهٔ [**LayoutTargetType**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/LayoutTargetType) تعریف شده‌اند.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/LayoutTargetType#Inner) - مشخص می‌کند که اندازهٔ ناحیه‌پلات باید اندازهٔ ناحیه‌پلات را تعیین کند، بدون شامل شدن علامت‌های تیک و برچسب‌های محور.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/LayoutTargetType#Outer) - مشخص می‌کند که اندازهٔ ناحیه‌پلات باید اندازهٔ ناحیه‌پلات، علامت‌های تیک و برچسب‌های محور را تعیین کند.

کد نمونه در زیر آورده شده است.

```java
// ایجاد یک نمونه از کلاس Presentation
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

**در چه واحدی مقدارهای x واقعی، y واقعی، عرض واقعی و ارتفاع واقعی برگردانده می‌شوند؟**

در واحد نقطه؛ 1 اینچ = 72 نقطه. این‌ها واحدهای مختصات Aspose.Slides هستند.

**ناحیه‌پلات چگونه از ناحیه‌نمودار از نظر محتوا متفاوت است؟**

ناحیه‌پلات ناحیهٔ رسم داده‌ها (سری‌ها، خطوط شبکه، خطوط روند و غیره) است؛ ناحیه‌نمودار شامل عناصر اطراف آن (عنوان، افسانه و غیره) می‌شود. در نمودارهای سه‌بعدی، ناحیه‌پلات همچنین شامل دیوارها/پایه و محورها می‌باشد.

**وقتی طرح به‌صورت دستی باشد، مقادیر x، y، عرض و ارتفاع ناحیه‌پلات چگونه تفسیر می‌شوند؟**

آن‌ها به صورت کسری (۰–۱) از اندازهٔ کل نمودار هستند؛ در این حالت، موقعیت‌یابی خودکار غیرفعال می‌شود و کسری که تنظیم می‌کنید استفاده می‌شود.

**چرا موقعیت ناحیه‌پلات پس از افزودن/جابه‌جایی افسانه تغییر کرد؟**

افسانه در ناحیهٔ نمودار خارج از ناحیه‌پلات قرار می‌گیرد اما بر طرح و فضای موجود تأثیر می‌گذارد، بنابراین ناحیه‌پلات ممکن است زمانی که موقعیت‌یابی خودکار فعال است جابجا شود. (این رفتار استاندارد برای نمودارهای PowerPoint است.)