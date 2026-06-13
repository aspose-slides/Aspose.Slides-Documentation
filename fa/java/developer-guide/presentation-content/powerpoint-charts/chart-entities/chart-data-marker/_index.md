---
title: مدیریت نشانگرهای دادهٔ نمودار در ارائه‌ها با استفاده از جاوا
linktitle: نشانگر داده
type: docs
url: /fa/java/chart-data-marker/
keywords:
- نمودار
- نقطه داده
- نشانگر
- گزینه‌های نشانگر
- اندازه نشانگر
- نوع پرکننده
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه نشانگرهای دادهٔ نمودار را در Aspose.Slides برای جاوا سفارشی کنید تا تأثیر ارائه را در قالب‌های PPT و PPTX با مثال‌های واضح کد جاوا افزایش دهید."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه با نشانگرهای دادهٔ نمودار در Aspose.Slides کار کنید. این مقاله نشان می‌دهد که چگونه یک نمودار ایجاد کنید، به یک سری و نقاط دادهٔ آن دسترسی پیدا کنید، پرکنندهٔ تصویری را بر روی نشانگرها در سطح نقطهٔ داده اعمال کنید، اندازهٔ نشانگر را تنظیم کنید و ارائهٔ به‌روزشده را ذخیره کنید. همچنین ذکر می‌کند که شکل‌های استاندارد نشانگر از طریق شمارش `MarkerStyleType` در دسترس هستند و ظاهر نشانگر هنگام استخراج نمودارها به فرمت‌های رستر یا SVG حفظ می‌شود.

## **تنظیم گزینه‌های نشانگر نمودار**

نشانگرها می‌توانند بر روی نقاط دادهٔ نمودار درون یک سری خاص تنظیم شوند. برای تنظیم گزینه‌های نشانگر نمودار. لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
- ایجاد نمودار پیش‌فرض.
- تصویر را تنظیم کنید.
- سری اول نمودار را بگیرید.
- یک نقطه دادهٔ جدید اضافه کنید.
- ارائه را روی دیسک بنویسید.

در مثال زیر، ما گزینه‌های نشانگر نمودار را در سطح نقاط داده تنظیم کرده‌ایم.

```java
// ایجاد ارائه خالی
Presentation pres = new Presentation();
try {
    // دسترسی به اسلاید اول
    ISlide slide = pres.getSlides().get_Item(0);
    
    // ایجاد نمودار پیش‌فرض
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // دریافت شاخص WorkSheet داده‌های نمودار پیش‌فرض
    int defaultWorksheetIndex = 0;
    
    // دریافت WorkSheet داده‌های نمودار
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // حذف سری نمونه
    chart.getChartData().getSeries().clear();
    
    // افزودن سری جدید
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // بارگذاری تصویر 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // بارگذاری تصویر 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // دریافت اولین سری نمودار
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // افزودن نقطه جدید (1:3) در آنجا.
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // تغییر نشانگر سری نمودار
    series.getMarker().setSize(15);
    
    // ذخیره ارائه با نمودار
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**کدام شکل‌های نشانگر به‌صورت پیش‌فرض در دسترس هستند؟**

شکل‌های استاندارد (دائرہ، مربع، لوزی، مثلث، و غیره) در دسترس هستند؛ این فهرست توسط کلاس [MarkerStyleType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/markerstyletype/) تعریف شده است. اگر به شکل غیر استاندارد نیاز دارید، می‌توانید از یک نشانگر با پرکنندهٔ تصویری استفاده کنید تا نمای سفارشی را شبیه‌سازی کند.

**آیا نشانگرها هنگام استخراج نمودار به تصویر یا SVG حفظ می‌شوند؟**

بله. هنگام رندر نمودارها به [فرمت‌های رستر](/slides/fa/java/convert-powerpoint-to-png/) یا ذخیرهٔ [شکل‌ها به عنوان SVG](/slides/fa/java/render-a-slide-as-an-svg-image/)، نشانگرها ظاهر و تنظیمات خود را شامل اندازه، پرکننده و خطوط پیرامونی حفظ می‌کنند.