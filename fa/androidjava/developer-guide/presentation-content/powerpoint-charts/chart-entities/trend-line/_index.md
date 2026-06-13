---
title: افزودن خطوط روند به نمودارهای ارائه در اندروید
linktitle: خط روند
type: docs
url: /fa/androidjava/trend-line/
keywords:
- نمودار
- خط روند
- خط روند نمایی
- خط روند خطی
- خط روند لگاریتمی
- خط روند متوسط متحرک
- خط روند چندجمله‌ای
- خط روند توان
- خط روند سفارشی
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "به سرعت خطوط روند را در نمودارهای PowerPoint با Aspose.Slides برای Android از طریق Java اضافه و سفارشی کنید — راهنمای عملی برای جذب مخاطبان شما."
---
## **بررسی اجمالی**

این مقاله توضیح می‌دهد چگونه خطوط روند را به نمودارهای ارائه با استفاده از Aspose.Slides اضافه کنیم. این مقاله نشان می‌دهد چگونه یک نمودار ایجاد کنیم، خطوط روند را به سری‌های نمودار اضافه کنیم، و با انواع مختلف خطوط روند شامل نمایی، خطی، لگاریتمی، متوسط متحرک، چندجمله‌ای و توان کار کنیم.

همچنین توضیح می‌دهد چگونه یک خط سفارشی به یک نمودار اضافه کنیم با وارد کردن یک شکل خطی، و شامل پرسش و پاسخ کوتاهی درباره مقادیر پیش‌بینی خط روند به سمت جلو و عقب و این که آیا خطوط روند هنگام خروجی به PDF یا SVG و هنگام رندر نمودارها به صورت تصویر حفظ می‌شوند یا خیر.

## **افزودن خط روند**
Aspose.Slides for Android via Java یک API ساده برای مدیریت خطوط روند مختلف نمودار ارائه می‌دهد:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2. با استفاده از ایندکس، مرجع یک اسلاید را دریافت کنید.
3. یک نمودار با داده‌های پیش‌فرض به همراه هر نوع دلخواه اضافه کنید (در این مثال از ChartType.ClusteredColumn استفاده شده است).
4. افزودن خط روند نمایی برای سری 1 نمودار.
5. افزودن خط روند خطی برای سری 1 نمودار.
6. افزودن خط روند لگاریتمی برای سری 2 نمودار.
7. افزودن خط روند متوسط متحرک برای سری 2 نمودار.
8. افزودن خط روند چندجمله‌ای برای سری 3 نمودار.
9. افزودن خط روند توان برای سری 3 نمودار.
10. ارائه تغییر یافته را در یک فایل PPTX بنویسید.

کد زیر برای ایجاد یک نمودار با خطوط روند استفاده می‌شود.

```java
// ایجاد یک نمونه از کلاس Presentation
Presentation pres = new Presentation();
try {
    // ساخت یک نمودار ستونی خوشه‌ای
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // افزودن خط روند نمایی برای سری 1 نمودار
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // افزودن خط روند خطی برای سری 1 نمودار
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // افزودن خط روند لگاریتمی برای سری 2 نمودار
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // افزودن خط روند متوسط متحرک برای سری 2 نمودار
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // افزودن خط روند چندجمله‌ای برای سری 3 نمودار
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // افزودن خط روند توان برای سری 3 نمودار
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // ذخیره ارائه
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **افزودن خط سفارشی**
Aspose.Slides for Android via Java یک API ساده برای افزودن خطوط سفارشی در یک نمودار فراهم می‌کند. برای افزودن یک خط ساده به یک اسلاید انتخابی از ارائه، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید
- مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید
- یک نمودار جدید با استفاده از متد AddChart که توسط شیء Shapes ارائه می‌شود، ایجاد کنید
- یک AutoShape از نوع خط را با استفاده از متد AddAutoShape که توسط شیء Shapes ارائه می‌شود، اضافه کنید
- رنگ خطوط شکل را تنظیم کنید.
- ارائه تغییر یافته را به عنوان فایل PPTX بنویسید

کد زیر برای ایجاد یک نمودار با خطوط سفارشی استفاده می‌شود.

```java
// ایجاد یک نمونه از کلاس Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**معنای 'forward' و 'backward' در یک خط روند چیست؟**

آنها طول‌های خط روند هستند که به سمت جلو/عقب پیش‌بینی می‌شوند: برای نمودارهای پراکندگی (XY) — بر حسب واحدهای محور؛ برای نمودارهای غیرپراکندگی — بر حسب تعداد دسته‌ها. تنها مقادیر غیرمنفی مجاز هستند.

**آیا خط روند هنگام خروجی به PDF یا SVG یا هنگام رندر یک اسلاید به تصویر حفظ می‌شود؟**

بله. Aspose.Slides ارائه‌ها را به [PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/)/[SVG](/slides/fa/androidjava/render-a-slide-as-an-svg-image/) تبدیل می‌کند و نمودارها را به تصویر رندر می‌نماید؛ خطوط روند به عنوان بخشی از نمودار در این عملیات‌ها حفظ می‌شوند. همچنین یک متد برای [صادرات تصویر نمودار](/slides/fa/androidjava/create-shape-thumbnails/) وجود دارد.