---
title: سفارشی‌سازی legendهای نمودار در ارائه‌ها با استفاده از JavaScript
linktitle: legend نمودار
type: docs
url: /fa/nodejs-java/chart-legend/
keywords:
- legend نمودار
- موقعیت legend
- اندازه فونت
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "legendهای نمودار را با Aspose.Slides برای Node.js از طریق Java سفارشی کنید تا ارائه‌های PowerPoint را با قالب‌بندی اختصاصی legend بهینه کنید."
---
## **بررسی کلی**

Aspose.Slides for Node.js via Java گزینه‌هایی برای سفارشی‌سازی legendهای نمودار در ارائه‌های PowerPoint فراهم می‌کند. این مقاله نشان می‌دهد چگونه legend را موقعیت‌دهی و اندازه‌گذاری کنید، اندازه فونت کل legend را تنظیم کنید، یک ورودی legend فردی را قالب‌بندی کنید، و ورودی‌های انتخابی را مخفی یا بازیابی کنید.

سوالات متداول رفتارهای مرتبط را شامل می‌شود، از جمله رزرو فضای legend، نمایش برچسب‌های چندخطی، و ارث‌بری قالب‌بندی از تم ارائه.

## **موقعیت‌گذاری legend**

از متدهای [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/), و [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/) legend برای تعیین موقعیت و اندازهٔ آن به عنوان کسری از ابعاد نمودار استفاده کنید.

این مثال یک ارائه ایجاد می‌کند و یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض را به اسلاید اول اضافه می‌کند. تقسیم مقدارهای دلخواه جابجایی و ابعاد legend بر عرض و ارتفاع نمودار، آنها را به مقادیر نسبی تبدیل می‌کند: legend ۵۰ پوینت از گوشهٔ بالایی‑چپ نمودار جابجا شده و به اندازهٔ ۱۰۰ در ۱۰۰ پوینت تنظیم می‌شود.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // موقعیت و اندازهٔ legend را نسبت به نمودار بیان کنید.
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم اندازه فونت legend**

از [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/) legend برای دسترسی به قالب‌بندی متن آن استفاده کنید و با استفاده از [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) اندازه فونت را بر حسب پوینت تنظیم کنید.

این مثال یک نمودار با داده‌های پیش‌فرض ایجاد می‌کند و متن legend را به ۲۰ پوینت تنظیم می‌کند. همچنین محدودهٔ خودکار محور عمودی را غیرفعال می‌کند و محدودهٔ آن را از -۵ تا ۱۰ تنظیم می‌نماید.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم اندازه فونت یک ورودی legend فردی**

از مجموعه‌ای که توسط متد [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/) legend برگردانده می‌شود برای دسترسی به قالب‌بندی یک ورودی خاص استفاده کنید. ایندیس‌های ورودی از صفر شروع می‌شوند، بنابراین ایندیس `1` به ورودی دوم اشاره دارد.

این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند که داده‌های پیش‌فرض آن حداقل شامل دو سری است. ورودی دوم legend را با متن بولد، ایتالیک و رنگ آبی به اندازهٔ ۲۰ پوینت قالب‌بندی می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مخفی‌کردن ورودی‌های legend فردی**

برای حذف یک سری کمکی از legend در حالی که داده‌های آن قابل مشاهده می‌مانند، با استفاده از [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) مقدار `true` را از طریق [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/) فراخوانی کنید. این کار فقط ورودی legend انتخاب‌شده را مخفی می‌کند؛ سری یا نقاط دادهٔ آن حذف نمی‌شوند. در contrast، فراخوانی [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) با مقدار `false` کل legend را مخفی می‌کند.

مثال زیر یک نمودار ستونی خوشه‌ای با چندین سری با استفاده از داده‌های پیش‌فرض ایجاد می‌کند. ورودی legend سری دوم (ایندیس `1`) را مخفی می‌کند و ارائه را ذخیره می‌نماید. سپس با فراخوانی [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) مقدار `false` ورودی را بازیابی می‌کند و یک نسخهٔ دوم را ذخیره می‌نماید. ستون‌ها در هر دو فایل قابل مشاهده باقی می‌مانند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // بازیابی همان ورودی بدون تغییر داده‌های نمودار.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مقایسهٔ زیر همان نمودار را با تمام ورودی‌های قابل مشاهده و با ورودی دوم مخفی نشان می‌دهد. ستون‌های سری دوم بدون تغییر می‌مانند.

![مقایسهٔ نمودار با تمام ورودی‌های legend قابل مشاهده و با مخفی شدن سری ۲ از legend؛ همه ستون‌ها قابل مشاهده باقی می‌مانند.](hide-legend-entry.png)

در نمودارهای ستونی، میله‌ای و خطی، ورودی‌های legend سری‌ها را شناسایی می‌کنند. برای نمودارهای دایره‌ای، آنها نقاط دادهٔ فردی (برش‌ها) را شناسایی می‌کنند، بنابراین به‌جای آن از [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) بر روی برش انتخابی استفاده کنید. API این متد نقطه‌داده را برای انواع نمودار `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, و `BarOfPie` مستند کرده است. فرض نکنید که این متد برای نمودارهای دونات که در آن فهرست گنجانده نشده‌اند، نیز اعمال می‌شود.

## **سوالات متداول**

**آیا می‌توانم نمودار را طوری تنظیم کنم که برای legend فضای اختصاصی صرف کند و آن را روی نمودار ننهند؟**

بله. با فراخوانی [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) مقدار `false` را تنظیم کنید تا به‌جای اجازهٔ هم‌پوشانی با ناحیهٔ نمودار، فضای legend را رزرو کند.

**آیا می‌توانم برچسب‌های legend چندخطی داشته باشم؟**

بله. برچسب‌های طولانی می‌توانند در صورت نرسیدن عرض موجود به‌صورت خودکار شکسته شوند. همچنین می‌توانید از کاراکترهای خط جدید در نام‌های سری برای درخواست شکست خط استفاده کنید.

**چگونه می‌توانم legend را مطابق با طرح رنگی تم ارائه تنظیم کنم؟**

رنگ‌ها، پرکننده‌ها و قلم‌های legend را تنظیم نکنید تا بتواند قالب‌بندی تم را به ارث بگیرد. قالب‌بندی صریح تنظیمات مربوط به تم را بازنویسی می‌کند.