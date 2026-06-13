---
title: "بهینه‌سازی محاسبات نمودار برای ارائه‌ها در جاوااسکریپت"
linktitle: "محاسبات نمودار"
type: docs
weight: 50
url: /fa/nodejs-java/chart-calculations/
keywords:
- "محاسبات نمودار"
- "عناصر نمودار"
- "موقعیت عنصر"
- "موقعیت واقعی"
- "عنصر فرزند"
- "عنصر والد"
- "مقادیر نمودار"
- "مقدار واقعی"
- "PowerPoint"
- "ارائه"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "محاسبات نمودار، به‌روزرسانی داده‌ها و کنترل دقت را در Aspose.Slides برای Node.js برای PPT و PPTX درک کنید، با مثال‌های کاربردی کد JavaScript."
---
## **نمای کلی**

Aspose.Slides APIهایی را برای کار با محاسبات نمودار و داده‌های طرح‌بندی در ارائه‌ها فراهم می‌کند. این مقاله نشان می‌دهد چگونه مقادیر واقعی عناصر نمودار، از جمله موقعیت و اندازه واقعی عناصر و مقادیر واقعی محورها را دریافت کنید. همچنین توضیح می‌دهد که این مقادیر پس از اعتبارسنجی طرح‌بندی نمودار پر می‌شوند.

علاوه بر این، مقاله نشان می‌دهد چگونه موقعیت واقعی عناصر والد نمودار را بدست آورید و چگونه مؤلفه‌های نمودار مانند عنوان، محورها، افسانه و خطوط شبکه را مخفی کنید. این مثال‌ها به شما کمک می‌کنند تا اطلاعات طرح‌بندی نمودار را بررسی کرده و نمایش عناصر نمودار را در ارائه‌های PowerPoint به‌صورت برنامه‌نویسی کنترل کنید.

## **محاسبه مقادیر واقعی عناصر نمودار**

Aspose.Slides for Node.js via Java یک API ساده برای دریافت این خصوصیات ارائه می‌دهد. خصوصیات کلاس [Axis](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Axis) اطلاعاتی درباره موقعیت واقعی عنصر محور نمودار فراهم می‌کند ([Axis.getActualMaxValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Axis#getActualMaxValue--)،[Axis.getActualMinValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Axis#getActualMinValue--)،[Axis.getActualMajorUnit](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Axis#getActualMajorUnit--),[Axis.getActualMinorUnit](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Axis#getActualMinorUnit--),[Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--),[Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)). برای پر شدن خصوصیات با مقادیر واقعی، لازم است پیش از آن متد [Chart.validateChartLayout()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Chart#validateChartLayout--) را فراخوانی کنید.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **محاسبه موقعیت واقعی عناصر والد نمودار**

Aspose.Slides for Node.js via Java یک API ساده برای دریافت این خصوصیات فراهم می‌کند. خصوصیات کلاس `ActualLayout` اطلاعاتی درباره موقعیت واقعی عنصر والد نمودار ارائه می‌دهد: `ActualLayout.getActualX`، `ActualLayout.getActualY`، `ActualLayout.getActualWidth` و `ActualLayout.getActualHeight`. برای پر شدن این خصوصیات با مقادیر واقعی، لازم است پیش از آن متد [Chart.validateChartLayout()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Chart#validateChartLayout--) را صدا بزنید.

```javascript
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

## **پنهان کردن اطلاعات از نمودار**

این موضوع به شما کمک می‌کند تا نحوه پنهان کردن اطلاعات از نمودار را درک کنید. با استفاده از Aspose.Slides for Node.js via Java می‌توانید **عنوان، محور عمودی، محور افقی** و **خطوط شبکه** را از نمودار مخفی کنید. مثال کد زیر نشان می‌دهد چگونه از این خصوصیات استفاده کنید.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // پنهان کردن عنوان نمودار
    chart.setTitle(false);
    // /پنهان کردن محور مقادیر
    chart.getAxes().getVerticalAxis().setVisible(false);
    // نمایان بودن محور دسته‌بندی
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // پنهان کردن افسانه
    chart.setLegend(false);
    // پنهان کردن خطوط شبکه اصلی
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // تنظیم رنگ خط سری
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **پرسش‌های متداول**

**آیا کتاب‌های کار Excel خارجی به عنوان منبع داده کار می‌کنند و این چگونه بر بازمحاسبه تأثیر می‌گذارد؟**

بله. یک نمودار می‌تواند به یک کتاب‌کار خارجی ارجاع دهد: وقتی منبع خارجی را متصل یا تازه‌سازی می‌کنید، فرمول‌ها و مقادیر از آن کتاب‌کار گرفته می‌شوند و نمودار در طول عملیات باز/ویرایش به‌روزرسانی‌ها را نشان می‌دهد. این API به شما اجازه می‌دهد مسیر [specify the external workbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) را تعیین کنید و داده‌های پیوندی را مدیریت کنید.

**آیا می‌توانم خطوط روند را محاسبه و نمایش دهم بدون اینکه خودم رگرسیون را پیاده‌سازی کنم؟**

بله. [Trendlines](/slides/fa/nodejs-java/trend-line/) (خطی، نمایی و سایر) توسط Aspose.Slides اضافه و به‌روزرسانی می‌شوند؛ پارامترهای آنها به‌صورت خودکار از داده‌های سری‌ها بازمحاسبه می‌شود، بنابراین نیازی به پیاده‌سازی محاسبات خودتان ندارید.

**اگر یک ارائه چندین نمودار با لینک‌های خارجی داشته باشد، آیا می‌توانم کنترل کنم که هر نمودار از کدام کتاب‌کار برای مقادیر محاسبه‌شده استفاده کند؟**

بله. هر نمودار می‌تواند به [external workbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) خود اشاره کند، یا می‌توانید برای هر نمودار به‌صورت مستقل یک کتاب‌کار خارجی ایجاد یا جایگزین کنید.