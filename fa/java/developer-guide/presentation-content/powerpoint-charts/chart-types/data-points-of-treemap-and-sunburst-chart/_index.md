---
title: سفارشی‌سازی نقاط داده در نمودارهای Treemap و Sunburst با استفاده از Java
linktitle: نقاط داده در نمودارهای Treemap و Sunburst
type: docs
url: /fa/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- نمودار treemap
- نمودار sunburst
- نقطه داده
- رنگ برچسب
- رنگ شاخه
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "چگونگی مدیریت نقاط داده در نمودارهای treemap و sunburst را با Aspose.Slides برای Java یاد بگیرید، سازگار با فرمت‌های PowerPoint."
---
## **مقدمه**

در میان انواع دیگر نمودارهای PowerPoint، دو نوع «سلسله‌وار» وجود دارد - **Treemap** و **Sunburst** (که همچنین به عنوان Sunburst Graph، Sunburst Diagram، Radial Chart، Radial Graph یا Multi Level Pie Chart شناخته می‌شود). این نمودارها داده‌های سلسله‌وار را که به شکل درخت سازمان یافته‌اند - از برگ‌ها تا رأس شاخه - نمایش می‌دهند. برگ‌ها توسط نقاط داده سری تعریف می‌شوند و هر سطح گروه‌بندی تو در تو بعدی توسط دسته‌بندی مربوطه تعریف می‌شود. Aspose.Slides for Java امکان قالب‌بندی نقاط دادهٔ نمودارهای Sunburst و Treemap را در Java فراهم می‌کند.

در اینجا یک نمودار Sunburst نشان داده شده است که داده‌های ستون Series1 گره‌های برگ را تعریف می‌کنند، در حالی که ستون‌های دیگر نقاط دادهٔ سلسله‌وار را تعریف می‌کنند:

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
- [**ایجاد یا به‌روزرسانی نمودارهای ارائه PowerPoint در Java**](/slides/fa/java/create-chart/)
{{% /alert %}}

اگر نیازی به قالب‌بندی نقاط دادهٔ نمودار باشد، باید از موارد زیر استفاده کنیم:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartDataPointLevel) classes 
and [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) method 
دسترسی به قالب‌بندی نقاط دادهٔ نمودارهای Treemap و Sunburst را فراهم می‌کنند. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartDataPointLevelsManager) 
برای دسترسی به دسته‌بندی‌های چندسطحی استفاده می‌شود - این کلاس مخزن اشیای 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartDataPointLevel) را نمایندگی می‌کند. 
در اصل این یک wrapper برای 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartCategoryLevelsManager) است که ویژگی‌های خاص برای نقاط داده اضافه شده‌اند. 
کلاس [**IChartDataPointLevel**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartDataPointLevel) دارای دو متد است: [**getFormat**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartDataPointLevel#getFormat--) و 
[**getDataLabel**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartDataPointLevel#getLabel--) که دسترسی به تنظیمات مربوطه را فراهم می‌کنند.

## **نمایش مقدار نقطه داده**

نمایش مقدار نقطه داده "Leaf 4":

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **تنظیم برچسب و رنگ نقطه داده**

برچسب داده "Branch 1" را تنظیم کنید تا نام سری ("Series1") را به جای نام دسته‌بندی نمایش دهد. سپس رنگ متن را به زرد تغییر دهید:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **تنظیم رنگ شاخهٔ نقطه داده**

رنگ شاخه "Steam 4" را تغییر دهید:

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

**آیا می‌توانم ترتیب (مرتب‌سازی) قطعات در Sunburst/Treemap را تغییر دهم؟**

خیر. PowerPoint به‌صورت خودکار قطعات را مرتب می‌کند (معمولاً بر اساس مقادیر نزولی و به جهت ساعت‌گرد). Aspose.Slides این رفتار را بازتاب می‌دهد: شما نمی‌توانید ترتیب را به‌صورت مستقیم تغییر دهید؛ برای این کار باید داده‌ها را پیش‌پردازش کنید.

**قالب ارائه چگونه بر رنگ‌های قطعات و برچسب‌ها تأثیر می‌گذارد؟**

رنگ‌های نمودار از [theme/palette](/slides/fa/java/presentation-theme/) ارائه ارث می‌برند مگر اینکه به‌صورت صریح پرها/قلم‌ها را تنظیم کنید. برای نتایج ثابت، پرهای جامد و قالب‌بندی متن را در سطوح مورد نیاز قفل کنید.

**آیا خروجی به PDF/PNG رنگ‌های سفارشی شاخه و تنظیمات برچسب را حفظ می‌کند؟**

بله. هنگام استخراج ارائه، تنظیمات نمودار (پرها، برچسب‌ها) در فرمت‌های خروجی حفظ می‌شوند زیرا Aspose.Slides با اعمال قالب‌بندی نمودار رندر می‌کند.

**آیا می‌توانم مختصات واقعی یک برچسب/عنصر را برای قرار دادن پوشش سفارشی روی نمودار محاسبه کنم؟**

بله. پس از اعتبارسنجی چیدمان نمودار، مقادیر *x* و *y* واقعی برای عناصر در دسترس هستند (به عنوان مثال برای یک [DataLabel](https://reference.aspose.com/slides/fa/java/com.aspose.slides/datalabel/)) که در مکان‌یابی دقیق پوشش‌ها کمک می‌کند.