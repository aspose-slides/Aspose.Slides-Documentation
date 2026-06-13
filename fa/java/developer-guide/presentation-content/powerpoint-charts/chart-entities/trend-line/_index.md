---
title: افزودن خطوط روند به نمودارهای ارائه در جاوا
linktitle: خط روند
type: docs
url: /fa/java/trend-line/
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
- Java
- Aspose.Slides
description: "به سرعت خطوط روند را در نمودارهای PowerPoint با Aspose.Slides برای Java اضافه و سفارشی کنید — راهنمایی عملی برای جذب مخاطبان شما."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه خطوط روند را به نمودارهای ارائه با استفاده از Aspose.Slides اضافه کنیم. نشان می‌دهد چگونه یک نمودار ایجاد کنیم، خطوط روند را به سری‌های نمودار اضافه کنیم، و با چندین نوع خط روند کار کنیم، از جمله نمایی، خطی، لگاریتمی، میانگین متحرک، چندجمله‌ای و توان.

همچنین توضیح می‌دهد چگونه یک خط سفارشی به نمودار اضافه کنیم با افزودن یک شکل خط، و شامل یک پرسش‌وپاسخ کوتاه درباره مقادیر پیش‌بینی‌گر “forward” و “backward” خطوط روند و این که آیا خطوط روند در زمان صادرات به PDF یا SVG و هنگام رندر نمودارها به عنوان تصویر حفظ می‌شوند یا خیر.

## **افزودن خط روند**
Aspose.Slides for Java یک API ساده برای مدیریت انواع مختلف خطوط روند نمودار ارائه می‌دهد:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را بر اساس ایندکس آن به دست آورید.
3. یک نمودار با داده‌های پیش‌فرض و از هر نوع دلخواه اضافه کنید (در این مثال از ChartType.ClusteredColumn استفاده شده است).
4. اضافه کردن خط روند نمایی برای سری نمودار 1.
5. اضافه کردن خط روند خطی برای سری نمودار 1.
6. اضافه کردن خط روند لگاریتمی برای سری نمودار 2.
7. اضافه کردن خط روند میانگین متحرک برای سری نمودار 2.
8. اضافه کردن خط روند چندجمله‌ای برای سری نمودار 3.
9. اضافه کردن خط روند توان برای سری نمودار 3.
10. ارائه اصلاح‌شده را به یک فایل PPTX بنویسید.

کد زیر برای ایجاد یک نمودار با خطوط روند استفاده می‌شود.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    // ایجاد نمودار ستون خوشه‌ای
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // افزودن خط روند نمایی برای سری نمودار ۱
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // افزودن خط روند خطی برای سری نمودار ۱
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // افزودن خط روند لگاریتمی برای سری نمودار ۲
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // افزودن خط روند میانگین متحرک برای سری نمودار ۲
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // افزودن خط روند چندجمله‌ای برای سری نمودار ۳
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // افزودن خط روند توان برای سری نمودار ۳
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // ذخیرهٔ ارائه
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **افزودن خط سفارشی**
Aspose.Slides for Java یک API ساده برای افزودن خطوط سفارشی در یک نمودار فراهم می‌کند. برای افزودن یک خط ساده به اسلاید انتخابی ارائه، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید
- مرجع یک اسلاید را با استفاده از ایندکس آن به دست آورید
- یک نمودار جدید با استفاده از متد AddChart که توسط شی Shapes عرضه می‌شود ایجاد کنید
- یک AutoShape از نوع Line را با استفاده از متد AddAutoShape که توسط شی Shapes عرضه می‌شود اضافه کنید
- رنگ خطوط شکل را تنظیم کنید.
- ارائه اصلاح‌شده را به عنوان یک فایل PPTX بنویسید

کد زیر برای ایجاد یک نمودار با خطوط سفارشی استفاده می‌شود.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
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

## **سؤالات متداول**

**'forward' و 'backward' در یک خط روند چه معنایی دارند؟**

اینها طول‌های خط روند هستند که به سمت جلو/عقب پیش‌بینی می‌شوند: برای نمودارهای پراکندگی (XY) — بر حسب واحدهای محور؛ برای نمودارهای غیرپراکندگی — بر حسب تعداد دسته‌ها. فقط مقادیر غیرمنفی مجاز هستند.

**آیا خط روند در هنگام صادرات ارائه به PDF یا SVG، یا هنگام رندر اسلاید به یک تصویر حفظ می‌شود؟**

بله. Aspose.Slides ارائه‌ها را به [PDF](/slides/fa/java/convert-powerpoint-to-pdf/)/[SVG](/slides/fa/java/render-a-slide-as-an-svg-image/) تبدیل می‌کند و نمودارها را به تصاویر رندر می‌سازد؛ خطوط روند، به عنوان بخشی از نمودار، در طول این عملیات حفظ می‌شوند. همچنین یک متد برای [صادر کردن یک تصویر از خود نمودار](/slides/fa/java/create-shape-thumbnails/) موجود است.