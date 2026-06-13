---
title: سفارشی‌سازی نقاط داده در نمودارهای Treemap و Sunburst در Android
linktitle: نقاط داده در نمودارهای Treemap و Sunburst
type: docs
url: /fa/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- نمودار Treemap
- نمودار Sunburst
- نقطه داده
- رنگ برچسب
- رنگ شاخه
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه نقاط داده را در نمودارهای Treemap و Sunburst با Aspose.Slides برای Android از طریق Java مدیریت کنید، سازگار با قالب‌های PowerPoint."
---
## **معرفی**

در میان انواع دیگر نمودارهای PowerPoint، دو نوع «سلسله‌مراتبی» وجود دارد - نمودار **Treemap** و **Sunburst** (که همچنین به عنوان نمودار Sunburst، دیاگرام Sunburst، نمودار شعاعی، گراف شعاعی یا نمودار کیکی چند سطحی شناخته می‌شود). این نمودارها داده‌های سلسله‌مراتبی را که به شکل درختی سازماندهی شده‌اند - از برگ‌ها تا بالای شاخه - نمایش می‌دهند. برگ‌ها توسط نقاط داده سری تعریف می‌شوند و هر سطح گروه‌بندی تو در تو بعدی توسط دسته‌بندی مربوطه تعریف می‌شود. Aspose.Slides برای Android از طریق Java امکان قالب‌بندی نقاط داده نمودار Sunburst و Treemap را در Java فراهم می‌کند.

در اینجا یک نمودار Sunburst وجود دارد که داده‌های ستون Series1 گره‌های برگ را تعریف می‌کند، در حالی که ستون‌های دیگر نقاط داده سلسله‌مراتبی را تعریف می‌کنند:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

بیایید با افزودن یک نمودار Sunburst جدید به ارائه شروع کنیم:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="همچنین ببینید" %}} 
- [**ایجاد یا به‌روزرسانی نمودارهای ارائه PowerPoint در Android**](/slides/fa/androidjava/create-chart/)
{{% /alert %}}

اگر نیازی به قالب‌بندی نقاط داده نمودار باشد، باید از موارد زیر استفاده کنیم:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartDataPointLevelsManager)، 
[IChartDataPointLevel](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartDataPointLevel) classes 
and [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) method 
provide access to format data points of Treemap and Sunburst charts.

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartDataPointLevelsManager) برای دسترسی به دسته‌بندی‌های چندسطحی استفاده می‌شود - این یک محفظه برای اشیاء [**IChartDataPointLevel**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartDataPointLevel) است.

در اصل، این یک wrapper برای [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartCategoryLevelsManager) است که ویژگی‌های خاص برای نقاط داده به آن اضافه شده است.

کلاس [**IChartDataPointLevel**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartDataPointLevel) دو متد دارد: [**getFormat**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) و [**getDataLabel**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--) که دسترسی به تنظیمات مربوطه را فراهم می‌کنند.

## **نمایش مقدار یک نقطه داده**

نمایش مقدار نقطه داده «Leaf 4»:

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **تنظیم برچسب و رنگ یک نقطه داده**

برچسب داده «Branch 1» را تنظیم کنید تا نام سری («Series1») به جای نام دسته‌بندی نمایش داده شود. سپس رنگ متن را به زرد تنظیم کنید:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **تنظیم رنگ شاخه یک نقطه داده**

رنگ شاخه «Steam 4» را تغییر دهید:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **سوالات متداول**

**آیا می‌توانم ترتیب (مرتب‌سازی) بخش‌ها در Sunburst/Treemap را تغییر دهم؟**

خیر. PowerPoint بخش‌ها را به‌طور خودکار (معمولاً بر حسب مقدار نزولی و به ترتیب ساعت‌گرد) مرتب می‌کند. Aspose.Slides این رفتار را بازتاب می‌دهد: شما نمی‌توانید ترتیب را به‌صورت مستقیم تغییر دهید؛ برای این کار باید داده‌ها را پیش‌پردازش کنید.

**تم ارائه چگونه بر رنگ‌های بخش‌ها و برچسب‌ها تأثیر می‌گذارد؟**

رنگ‌های نمودار از [تم/پالت](/slides/fa/androidjava/presentation-theme/) ارائه ارث می‌برند مگر این که پر شدن‌ها/فونت‌ها را به‌صورت صریح تنظیم کنید. برای نتایج سازگار، پر شدن‌های ثابت و قالب‌بندی متن را در سطوح مورد نیاز ثابت کنید.

**آیا خروجی به PDF/PNG رنگ‌های سفارشی شاخه‌ها و تنظیمات برچسب را حفظ می‌کند؟**

بله. هنگام خروجی گرفتن از ارائه، تنظیمات نمودار (پر شدن‌ها، برچسب‌ها) در فرمت‌های خروجی حفظ می‌شوند زیرا Aspose.Slides با اعمال قالب‌بندی نمودار رندر می‌کند.

**آیا می‌توانم مختصات واقعی یک برچسب/عنصر را برای قرار دادن پوشش سفارشی بر روی نمودار محاسبه کنم؟**

بله. پس از اعتبارسنجی چیدمان نمودار، مقدار واقعی *x* و *y* برای عناصر در دسترس است (به عنوان مثال، یک [DataLabel](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/datalabel/)) که برای موقعیت‌یابی دقیق پوشش‌ها مفید است.