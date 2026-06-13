---
title: سفارشی‌سازی نقاط داده در نمودارهای Treemap و Sunburst با استفاده از PHP
linktitle: نقاط داده در نمودارهای Treemap و Sunburst
type: docs
url: /fa/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- نمودار treemap
- نمودار sunburst
- نقطه داده
- رنگ برچسب
- رنگ شاخه
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه نقاط داده را در نمودارهای treemap و sunburst با Aspose.Slides برای PHP via Java مدیریت کنید، سازگار با فرمت‌های PowerPoint."
---
## **مقدمه**

در میان انواع دیگر نمودارهای PowerPoint، دو نوع «سلسله‌مراتبی» وجود دارد - **Treemap** و **Sunburst** (که به عنوان Sunburst Graph، Sunburst Diagram، Radial Chart، Radial Graph یا Multi Level Pie Chart نیز شناخته می‌شوند). این نمودارها داده‌های سلسله‌مراتبی را به صورت یک درخت - از برگ‌ها تا بالای شاخه - نمایش می‌دهند. برگ‌ها توسط نقاط داده سری تعریف می‌شوند و هر سطح گروه‌بندی تو در تو بعدی توسط دسته مرتبط تعریف می‌شود. Aspose.Slides for PHP via Java امکان قالب‌بندی نقاط داده نمودار Sunburst و Treemap را فراهم می‌کند.

در زیر یک نمودار Sunburst نشان داده شده است که داده‌های ستون Series1 گره‌های برگ را تعریف می‌کند، در حالی که ستون‌های دیگر نقاط داده سلسله‌مراتبی را تعیین می‌کنند:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

بیایید با افزودن یک نمودار Sunburst جدید به ارائه شروع کنیم:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="See also" %}} 
- [**ایجاد یا به‌روزرسانی نمودارهای ارائه پاورپوینت در PHP**](/slides/fa/php-java/create-chart/)
{{% /alert %}}

اگر نیازی به قالب‌بندی نقاط دادهٔ نمودار باشد، باید از موارد زیر استفاده کنیم:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapointlevelsmanager/)، 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapointlevel/) کلاس‌ها 
و روش [**ChartDataPoint::getDataPointLevels**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) 
دسترسی به قالب‌بندی نقاط دادهٔ نمودارهای Treemap و Sunburst را فراهم می‌کنند. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapointlevelsmanager/) 
برای دسترسی به دسته‌بندی‌های چندسطحی استفاده می‌شود - این شیء container 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapointlevel/) را نشان می‌دهد. 
در اصل این یک wrapper برای 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartcategorylevelsmanager/) است که 
ویژگی‌های خاص برای نقاط داده به آن اضافه شده است. 
کلاس [**ChartDataPointLevel**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapointlevel/) دو متد دارد: 
[**getFormat**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapointlevel/#getFormat) و 
[**getDataLabel**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatapointlevel/#getLabel) که دسترسی به تنظیمات مربوطه را فراهم می‌کنند.

## **نمایش مقدار یک نقطه داده**
نمایش مقدار نقطه داده «Leaf 4»:

```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **تنظیم برچسب و رنگ نقطه داده**
برچسب داده «Branch 1» را طوری تنظیم کنید که نام سری («Series1») را به جای نام دسته نمایش دهد. سپس رنگ متن را به زرد تغییر دهید:

```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **تنظیم رنگ شاخهٔ نقطه داده**
رنگ شاخه «Steam 4» را تغییر دهید:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **سؤالات متداول**

**آیا می‌توانم ترتیب (مرتب‌سازی) بخش‌ها در Sunburst/Treemap را تغییر دهم؟**

خیر. PowerPoint بخش‌ها را به‌طور خودکار (معمولاً بر اساس مقادیر نزولی و به صورت ساعت‌گرد) مرتب می‌کند. Aspose.Slides این رفتار را بازتاب می‌دهد: نمی‌توانید ترتیب را به‌صورت مستقیم تغییر دهید؛ بلکه باید با پیش‌پردازش داده‌ها این کار را انجام دهید.

**قالب ارائه چگونه بر رنگ‌های بخش‌ها و برچسب‌ها تأثیر می‌گذارد؟**

رنگ‌های نمودار، به همان‌صورت رنگ‌های قالب/پالت ارائه [/slides/fa/php-java/presentation-theme/](/slides/fa/php-java/presentation-theme/) به ارث می‌برند، مگر این‌که شما پرکردن‌ها/قلم‌ها را به‌طور صریح تنظیم کنید. برای نتایج ثابت، پرکردن‌های ثابت و قالب‌بندی متن را در سطوح مورد نیاز قفل کنید.

**آیا خروجی به PDF/PNG رنگ‌های سفارشی شاخه و تنظیمات برچسب را حفظ می‌کند؟**

بله. هنگام خروجی گرفتن از ارائه، تنظیمات نمودار (پرکردن‌ها، برچسب‌ها) در فرمت‌های خروجی حفظ می‌شوند زیرا Aspose.Slides با قالب‌بندی نمودار رندر می‌شود.

**آیا می‌توانم مختصات واقعی یک برچسب/عنصر را برای قرارگیری سفارشی روی نمودار محاسبه کنم؟**

بله. پس از اعتبارسنجی طرح‌بندی نمودار، مقدار واقعی *x* و *y* برای عناصر (برای مثال یک [DataLabel](https://reference.aspose.com/slides/fa/php-java/aspose.slides/datalabel/)) در دسترس است که برای موقعیت‌یابی دقیق پوشش‌ها کمک می‌کند.