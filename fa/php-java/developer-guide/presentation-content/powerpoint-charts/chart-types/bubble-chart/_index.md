---
title: سفارشی‌سازی نمودارهای حبابی در ارائه‌ها با استفاده از PHP
linktitle: نمودار حبابی
type: docs
url: /fa/php-java/bubble-chart/
keywords:
- نمودار حبابی
- اندازه حباب
- مقیاس‌گذاری اندازه
- نمایش اندازه
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "نمودارهای حبابی قدرتمند را در PowerPoint با Aspose.Slides برای PHP از طریق Java ایجاد و سفارشی‌سازی کنید تا به سادگی تجسم داده‌های خود را بهبود ببخشید."
---
## **بررسی کلی**

این مقاله نحوه کار با نمودارهای حبابی در Aspose.Slides را نشان می‌دهد. دو گزینه سفارشی‌سازی خاص را پوشش می‌دهد: مقیاس‌گذاری اندازه‌های حباب‌ها از طریق متد `setBubbleSizeScale` و کنترل نحوه نمایش مقادیر اندازه حباب‌ها از طریق متد `setBubbleSizeRepresentation`.

نمونه‌ها نشان می‌دهند چگونه یک نمودار حبابی ایجاد کنید، مقیاس اندازه آن را تنظیم کنید و نمایش اندازه حباب را به استفاده از عرض تغییر دهید. مقاله همچنین شامل بخشی کوتاه از سوالات متداول است که پشتیبانی از نوع نمودار «حباب با 3‑بعد» را روشن می‌کند، اشاره می‌کند که محدودیت‌های عملی نمودار به عملکرد و نسخه هدف PowerPoint بستگی دارد، و توضیح می‌دهد که صادرات ظاهر نمودار را طی موتور رندرینگ Aspose.Slides حفظ می‌کند.

## **تنظیم مقیاس اندازه حباب**

Aspose.Slides برای PHP از طریق Java پشتیبانی از مقیاس‌گذاری اندازه نمودارهای حبابی را فراهم می‌کند. در Aspose.Slides برای PHP از طریق Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/getbubblesizescale/)، [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) و [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) متدها اضافه شده‌اند. نمونه کد زیر ارائه شده است.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **نمایش داده‌ها به عنوان اندازه‌های نمودار حبابی**

متدهای [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) و [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) به کلاس‌های [ChartSeries](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseries/)، [ChartSeriesGroup](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartseriesgroup/) و کلاس‌های مرتبط افزوده شده‌اند. **BubbleSizeRepresentation** تعیین می‌کند که مقادیر اندازه حباب‌ها در نمودار حبابی چگونه نمایش داده شوند. مقادیر ممکن عبارتند از: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/BubbleSizeRepresentationType#Area) و [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/BubbleSizeRepresentationType#Width). بنابراین، [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/BubbleSizeRepresentationType) enum برای مشخص کردن روش‌های ممکن نمایش داده‌ها به عنوان اندازه‌های نمودار حبابی اضافه شده است. نمونه کد در زیر آورده شده است.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**آیا «نمودار حباب با اثر سه‌بعدی» پشتیبانی می‌شود و چگونه با نمودار عادی متفاوت است؟**

بله. یک نوع نمودار جداگانه به نام «Bubble with 3‑D» وجود دارد. این نوع سبک‌سازی سه‌بعدی را بر روی حباب‌ها اعمال می‌کند ولی محور اضافی اضافه نمی‌کند؛ داده‌ها همچنان به صورت X‑Y‑S (اندازه) باقی می‌مانند. این نوع در کلاس [chart type](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/) موجود است.

**آیا محدودیتی برای تعداد سری‌ها و نقاط در یک نمودار حبابی وجود دارد؟**

در سطح API محدودیت سخت‌گیرانه‌ای وجود ندارد؛ محدودیت‌ها توسط عملکرد و نسخه هدف PowerPoint تعیین می‌شوند. توصیه می‌شود تعداد نقاط را در حد معقولی نگه دارید تا خوانایی و سرعت رندرینگ حفظ شود.

**صادرات چگونه بر ظاهر یک نمودار حبابی (PDF، تصویر) تأثیر می‌گذارد؟**

صادرات به فرمت‌های پشتیبانی‌شده ظاهر نمودار را حفظ می‌کند؛ رندرینگ توسط موتور Aspose.Slides انجام می‌شود. برای فرمت‌های رستری/وکتوری، قوانین کلی رندرینگ گرافیک نمودار (رزولوشن، ضد‌لبه) اعمال می‌شود، بنابراین برای چاپ DPI کافی را انتخاب کنید.