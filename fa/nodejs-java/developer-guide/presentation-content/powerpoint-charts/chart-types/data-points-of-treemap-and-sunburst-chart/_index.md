---
title: سفارشی‌سازی نقاط داده در نمودارهای Treemap و Sunburst با استفاده از JavaScript
linktitle: نقاط داده در نمودارهای Treemap و Sunburst
type: docs
url: /fa/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- نمودار Treemap
- نمودار Sunburst
- نقطه داده
- رنگ برچسب
- رنگ شاخه
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه نقاط داده را در نمودارهای Treemap و Sunburst با JavaScript و Aspose.Slides برای Node.js از طریق Java مدیریت کنید، که با فرمت‌های PowerPoint سازگار هستند."
---
## **معرفی**

در میان انواع دیگر نمودارهای PowerPoint، دو نوع «سلسله‌مراتبی» وجود دارد - **Treemap** و **Sunburst** (که همچنین به عنوان نمودار Sunburst، دیاگرام Sunburst، نمودار شعاعی، گراف شعاعی یا نمودار کیک چندسطحی شناخته می‌شود). این نمودارها داده‌های سلسله‌مراتبی را که به صورت درخت سازماندهی شده‌اند - از برگ‌ها تا بالای شاخه - نمایش می‌دهند. برگ‌ها توسط نقاط داده سری تعریف می‌شوند و هر سطح گروه‌بندی تو در تو بعدی توسط دسته‌بندی مربوطه تعریف می‌شود. Aspose.Slides for Node.js via Java امکان قالب‌بندی نقاط داده نمودار Sunburst و Treemap را در JavaScript فراهم می‌کند.

در اینجا یک نمودار Sunburst آورده شده است که داده‌های ستون Series1 گره‌های برگ را تعریف می‌کنند، در حالی که ستون‌های دیگر نقاط داده سلسله‌مراتبی را تعریف می‌کنند:
![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

بیایید با افزودن یک نمودار Sunburst جدید به ارائه شروع کنیم:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" title="همچنین ببینید" %}} 
- [**Create or Update PowerPoint Presentation Charts in JavaScript**](/slides/fa/nodejs-java/create-chart/)
{{% /alert %}}

اگر نیاز به قالب‌بندی نقاط داده نمودار باشد، باید از موارد زیر استفاده کنیم:
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartDataPointLevelsManager)،
[ChartDataPointLevel](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartDataPointLevel) کلاس‌ها
و
[**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) متد
دسترسی به قالب‌بندی نقاط دادهٔ Treemap و Sunburst را فراهم می‌کنند.
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartDataPointLevelsManager)
برای دسترسی به دسته‌بندی‌های چندسطحی استفاده می‌شود – این یک کانتنر برای
[**ChartDataPointLevel**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartDataPointLevel) اشیاء است.
در اصل این یک wrapper برای
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartCategoryLevelsManager) با
خواص اضافه شده خاص برای نقاط داده است.
کلاس [**ChartDataPointLevel**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartDataPointLevel) دو متد دارد: [**getFormat**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) و
[**getDataLabel**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) که دسترسی به تنظیمات مربوطه را فراهم می‌کنند.

## **نمایش مقدار نقطه داده**

نمایش مقدار نقطه داده «Leaf 4»:
```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **تنظیم برچسب و رنگ نقطه داده**

برچسب داده «Branch 1» را تنظیم کنید تا نام سری («Series1») را به جای نام دسته نمایش دهد. سپس رنگ متن را به زرد تنظیم کنید:
```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **تنظیم رنگ شاخه نقطه داده**

رنگ شاخه «Steam 4» را تغییر دهید:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **سوالات متداول**

**آیا می‌توانم ترتیب (مرتب‌سازی) بخش‌ها در Sunburst/Treemap را تغییر دهم؟**

خیر. PowerPoint به‌صورت خودکار بخش‌ها را مرتب می‌کند (معمولاً بر اساس مقادیر نزولی، به صورت ساعتگرد). Aspose.Slides این رفتار را بازتاب می‌دهد: نمی‌توانید ترتیب را به‌طور مستقیم تغییر دهید؛ این کار را با پیش‌پردازش داده‌ها انجام می‌دهید.

**قالب ارائه چگونه بر رنگ‌های بخش‌ها و برچسب‌ها تأثیر می‌گذارد؟**

رنگ‌های نمودار از [قالب/پالت](/slides/fa/nodejs-java/presentation-theme/) ارائه ارث می‌برند مگر این‌که به‌صورت صریح پرها/قلم‌ها را تنظیم کنید. برای نتایج ثابت، پرهای ثابت و قالب‌بندی متن را در سطوح مورد نیاز قفل کنید.

**آیا صادرات به PDF/PNG رنگ‌های سفارشی شاخه و تنظیمات برچسب را حفظ می‌کند؟**

بله. هنگام صادرات ارائه، تنظیمات نمودار (پرها، برچسب‌ها) در فرمت‌های خروجی حفظ می‌شوند زیرا Aspose.Slides با اعمال قالب‌بندی نمودار رندر می‌کند.

**آیا می‌توانم مختصات واقعی یک برچسب/عنصر را برای قرار دادن لایه سفارشی بر روی نمودار محاسبه کنم؟**

بله. پس از تأیید طرح نمودار، مقادیر X واقعی و Y واقعی برای عناصر در دسترس است (به عنوان مثال، یک [DataLabel](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datalabel/)) که برای موقعیت‌گذاری دقیق لایه‌های پوششی مفید است.