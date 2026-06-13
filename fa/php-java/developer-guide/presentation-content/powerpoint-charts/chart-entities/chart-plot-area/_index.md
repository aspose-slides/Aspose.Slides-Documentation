---
title: سفارشی‌سازی نواحی نمودارهای ارائه در PHP
linktitle: ناحیه نمودار
type: docs
url: /fa/php-java/chart-plot-area/
keywords:
- نمودار
- ناحیه نمودار
- عرض ناحیه نمودار
- ارتفاع ناحیه نمودار
- اندازه ناحیه نمودار
- حالت چیدمان
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید نواحی نمودار در ارائه‌های PowerPoint را با Aspose.Slides برای PHP via Java سفارشی کنید. جلوه‌های اسلایدهای خود را به‌صورت آسان بهبود دهید."
---
## **مرور کلی**

این مقاله نشان می‌دهد چگونه در Aspose.Slides با ناحیه‌نمودار یک نمودار کار کنیم. این مقاله توضیح می‌دهد چگونه موقعیت و اندازه واقعی ناحیه‌نمودار را با اعتبارسنجی طرح نمودار و سپس خواندن مقادیر X، Y، عرض و ارتفاع آن به دست آورید.

همچنین نشان می‌دهد چگونه حالت چیدمان ناحیه‌نمودار را زمانی که چیدمان به‌صورت دستی تنظیم می‌شود، پیکربندی کنید، با استفاده از `LayoutTargetType` برای تعریف اینکه آیا ناحیه‌نمودار بر اساس ناحیه داخلی یا ناحیه خارجی به همراه محورها و برچسب‌های محور محاسبه می‌شود.

## **دریافت عرض و ارتفاع ناحیه‌نمودار یک نمودار**
Aspose.Slides for PHP via Java یک API ساده برای . فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
2. به اسلاید اول دسترسی پیدا کنید.
3. نمودار را با داده‌های پیش‌فرض اضافه کنید.
4. قبل از دریافت مقادیر واقعی، متد [Chart.validateChartLayout](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/validatechartlayout/) را فراخوانی کنید.
5. موقعیت واقعی X (چپ) عنصر نمودار را نسبت به گوشهٔ بالای چپ نمودار به دست می‌آورد.
6. بالای واقعی عنصر نمودار را نسبت به گوشهٔ بالای چپ نمودار به دست می‌آورد.
7. عرض واقعی عنصر نمودار را به دست می‌آورد.
8. ارتفاع واقعی عنصر نمودار را به دست می‌آورد.

```php
  # یک نمونه از کلاس Presentation ایجاد کنید
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم حالت چیدمان ناحیه‌نمودار یک نمودار**
Aspose.Slides for PHP via Java یک API ساده برای تنظیم حالت چیدمان ناحیه‌نمودار نمودار فراهم می‌کند. متدهای [**setLayoutTargetType**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) و [**getLayoutTargetType**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) به کلاس [**ChartPlotArea**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ChartPlotArea) اضافه شده‌اند. اگر چیدمان ناحیه‌نمودار به‌صورت دستی تعریف شود، این خصوصیت تعیین می‌کند که ناحیه‌نمودار بر اساس داخل (بدون شامل کردن محور و برچسب‌های محور) یا خارج (شامل محور و برچسب‌های محور) چیدمان شود. دو مقدار ممکن وجود دارد که در شمارندهٔ [**LayoutTargetType**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/LayoutTargetType) تعریف شده‌اند.

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/LayoutTargetType#Inner) - مشخص می‌کند اندازه ناحیه‌نمودار باید اندازهٔ ناحیه‌نمودار را تعیین کند، بدون شامل کردن علامت‌های تیک و برچسب‌های محور.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/LayoutTargetType#Outer) - مشخص می‌کند اندازه ناحیه‌نمودار باید اندازهٔ ناحیه‌نمودار، علامت‌های تیک و برچسب‌های محور را تعیین کند.

کد نمونه در زیر آورده شده است.

```php
  # یک نمونه از کلاس Presentation ایجاد کنید
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**واحدهای بازگردانی مقادیر x واقعی، y واقعی، عرض واقعی و ارتفاع واقعی چیست؟**  
در واحد پوینت؛ 1 اینچ = 72 پوینت. این‌ها واحدهای مختصات Aspose.Slides هستند.

**چگونگی تفاوت ناحیه‌نمودار با ناحیه‌نمودار کلی (Chart Area) از نظر محتوا؟**  
ناحیه‌نمودار ناحیهٔ رسم داده‌ها (سری‌ها، خطوط توری، خطوط روند و غیره) است؛ در حالی که ناحیه‌نمودار کلی (Chart Area) شامل عناصر پیرامونی (عنوان، legend و غیره) می‌شود. در نمودارهای 3 بعدی، ناحیه‌نمودار همچنین شامل دیوارها/کف و محورها می‌گردد.

**وقتی چیدمان به‌صورت دستی باشد، مقادیر x، y، عرض و ارتفاع ناحیه‌نمودار چگونه تفسیر می‌شوند؟**  
آنها به‌صورت کسری (۰‑۱) از اندازه کلی نمودار هستند؛ در این حالت، موقعیت‌یابی خودکار غیرفعال می‌شود و کسری که تنظیم می‌کنید مورد استفاده قرار می‌گیرد.

**چرا موقعیت ناحیه‌نمودار پس از افزودن/جابه‌جایی legend تغییر کرد؟**  
legend در ناحیه‌نمودار کلی در خارج از ناحیه‌نمودار قرار می‌گیرد اما بر چیدمان و فضای موجود تاثیر می‌گذارد، بنابراین ناحیه‌نمودار ممکن است زمانی که موقعیت‌یابی خودکار فعال است جابجا شود. (این رفتار استاندارد برای نمودارهای PowerPoint است.)