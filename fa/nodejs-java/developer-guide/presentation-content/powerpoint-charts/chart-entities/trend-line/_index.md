---
title: افزودن خطوط روند به نمودارهای ارائه در جاوااسکریپت
linktitle: خط روند
type: docs
url: /fa/nodejs-java/trend-line/
keywords:
- نمودار
- خط روند
- خط روند نمایی
- خط روند خطی
- خط روند لگاریتمی
- خط روند میانگین متحرک
- خط روند چندجمله‌ای
- خط روند توان
- خط روند سفارشی
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "به سرعت خطوط روند را در نمودارهای PowerPoint با جاوااسکریپت و Aspose.Slides برای Node.js از طریق جاوا اضافه و سفارشی‌سازی کنید — راهنمای عملی برای جذب مخاطب شما."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با استفاده از Aspose.Slides خطوط روند را به نمودارهای ارائه اضافه کنید. نشان می‌دهد چگونه یک نمودار ایجاد کنید، خطوط روند را به سری‌های نمودار اضافه کنید، و با چند نوع خط روند کار کنید، از جمله نمایی، خطی، لگاریتمی، میانگین متحرک، چندجمله‌ای و توان.

همچنین شرح می‌دهد که چگونه با وارد کردن یک شکل خطی، یک خط سفارشی به نمودار اضافه کنید، و شامل یک سؤالات متداول کوتاه در مورد مقادیر پیش‌بینی جلو و عقب خط روند و این که آیا خطوط روند در هنگام صادرات به PDF یا SVG و هنگام رندر نمودارها به عنوان تصویر حفظ می‌شوند یا نه.

## **اضافه کردن خط روند**

Aspose.Slides برای Node.js از طریق Java یک API ساده برای مدیریت خطوط روند مختلف نمودارها فراهم می‌کند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.
3. یک نمودار با داده‌های پیش‌فرض به همراه هر یک از انواع موردنظر اضافه کنید (در این مثال از ChartType.ClusteredColumn استفاده شده است).
4. اضافه کردن خط روند نمایی برای سری شماره 1 نمودار.
5. اضافه کردن خط روند خطی برای سری شماره 1 نمودار.
6. اضافه کردن خط روند لگاریتمی برای سری شماره 2 نمودار.
7. اضافه کردن خط روند میانگین متحرک برای سری شماره 2 نمودار.
8. اضافه کردن خط روند چندجمله‌ای برای سری شماره 3 نمودار.
9. اضافه کردن خط روند توان برای سری شماره 3 نمودار.
10. ارائه‌نامه تغییر یافته را به یک فایل PPTX بنویسید.

کد زیر برای ایجاد یک نمودار با خطوط روند استفاده می‌شود.

```javascript
// یک نمونه از کلاس Presentation ایجاد کنید
var pres = new aspose.slides.Presentation();
try {
    // ایجاد یک نمودار ستونی خوشه‌ای
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // اضافه کردن خط روند نمایی برای سری نمودار 1
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // اضافه کردن خط روند خطی برای سری نمودار 1
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // اضافه کردن خط روند لگاریتمی برای سری نمودار 2
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // اضافه کردن خط روند میانگین متحرک برای سری نمودار 2
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // اضافه کردن خط روند چندجمله‌ای برای سری نمودار 3
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // اضافه کردن خط روند توان برای سری نمودار 3
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // ذخیرهٔ ارائه
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **اضافه کردن خط سفارشی**

Aspose.Slides برای Node.js از طریق Java یک API ساده برای افزودن خطوط سفارشی در یک نمودار فراهم می‌کند. برای افزودن یک خط ساده به اسلاید انتخاب‌شده ارائه، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید
- مرجع یک اسلاید را با استفاده از Index آن به دست آورید
- یک نمودار جدید با استفاده از متد AddChart که توسط شی Shapes ارائه شده است، ایجاد کنید
- یک AutoShape از نوع Line را با استفاده از متد AddAutoShape که توسط شی Shapes ارائه شده است، اضافه کنید
- رنگ خطوط شکل را تنظیم کنید.
- ارائه‌نامه تغییر یافته را به صورت فایل PPTX ذخیره کنید

کد زیر برای ایجاد یک نمودار با خطوط سفارشی استفاده می‌شود.

```javascript
// یک نمونه از کلاس Presentation ایجاد کنید
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سؤالات متداول**

**معنای 'forward' و 'backward' در خط روند چیست؟**

این‌ها طول‌های خط روند هستند که به سمت جلو/عقب پیش‌بینی می‌شوند: برای نمودارهای نقطه‌ای (XY) — به واحدهای محور؛ برای نمودارهای غیرنقطه‌ای — به تعداد دسته‌ها. فقط مقادیر غیرمنفی مجاز هستند.

**آیا خط روند هنگام صادرات ارائه به PDF یا SVG یا هنگام رندر اسلاید به تصویر حفظ می‌شود؟**

بله. Aspose.Slides ارائه‌ها را به [PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/fa/nodejs-java/render-a-slide-as-an-svg-image/) تبدیل می‌کند و نمودارها را به تصاویر رندر می‌کند؛ خطوط روند به عنوان بخشی از نمودار در طول این عملیات حفظ می‌شوند. همچنین یک متد برای [صادر کردن تصویر نمودار](/slides/fa/nodejs-java/create-shape-thumbnails/) وجود دارد.