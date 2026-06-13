---
title: مدیریت نشانگرهای داده نمودار در ارائه‌ها در اندروید
linktitle: نشانگر داده
type: docs
url: /fa/androidjava/chart-data-marker/
keywords:
- نمودار
- نقطه داده
- نشانگر
- گزینه‌های نشانگر
- اندازه نشانگر
- نوع پرشدن
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "سفارشی‌سازی نشانگرهای داده نمودار در Aspose.Slides برای اندروید، با افزایش تاثیر ارائه در فرمت‌های PPT و PPTX با مثال‌های واضح کد جاوا."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با نشانگرهای داده نمودار در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه یک نمودار ایجاد کنید، به یک سری و نقاط داده آن دسترسی پیدا کنید، پرکردن تصویر را برای نشانگرها در سطح نقطه داده اعمال کنید، اندازه نشانگر را تنظیم کنید و ارائه به‌روز شده را ذخیره کنید. همچنین اشاره می‌کند که اشکال استاندارد نشانگر از طریق enum `MarkerStyleType` در دسترس هستند و ظاهر نشانگر هنگام خروجی گرفتن نمودارها به فرمت‌های رستر یا SVG حفظ می‌شود.

## **تنظیم گزینه‌های نشانگر نمودار**
نشانگرها می‌توانند بر روی نقاط داده نمودار درون سری‌های خاص تنظیم شوند. برای تنظیم گزینه‌های نشانگر نمودار، لطفاً مراحل زیر را دنبال کنید:

- ایجاد یک شی از کلاس [ارائه](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) .
- ایجاد نمودار پیش‌فرض.
- تنظیم تصویر.
- دریافت اولین سری نمودار.
- افزودن نقطه داده جدید.
- نوشتن ارائه بر روی دیسک.

در مثال زیر، گزینه‌های نشانگر نمودار را در سطح نقاط داده تنظیم کرده‌ایم.

```java
// ایجاد یک ارائه خالی
Presentation pres = new Presentation();
try {
    // دسترسی به اولین اسلاید
    ISlide slide = pres.getSlides().get_Item(0);
    
    // ایجاد نمودار پیش‌فرض
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // دریافت شاخص ورک‌شیت داده‌های نمودار پیش‌فرض
    int defaultWorksheetIndex = 0;
    
    // دریافت ورک‌شیت داده‌های نمودار
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
    
    // افزودن نقطه جدید (1:3) آنجا.
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
    
    // ذخیره ارائه همراه با نمودار
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **پرسش‌های متداول**

**کدام اشکال نشانگر به‌صورت پیش‌فرض در دسترس هستند؟**  
اشکال استاندارد در دسترس هستند (دایره، مربع، الماس، مثلث و غیره)؛ این فهرست توسط کلاس [MarkerStyleType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/markerstyletype/) تعریف شده است. اگر به شکل غیراستاندارد نیاز دارید، از نشانگری با پرکردن تصویر استفاده کنید تا نمای سفارشی را شبیه‌سازی کنید.

**آیا نشانگرها هنگام خروجی گرفتن نمودار به تصویر یا SVG حفظ می‌شوند؟**  
بله. هنگام رندر نمودارها به [فرمت‌های رستر](/slides/fa/androidjava/convert-powerpoint-to-png/) یا ذخیره [اشکال به‌عنوان SVG](/slides/fa/androidjava/render-a-slide-as-an-svg-image/)، نشانگرها ظاهر و تنظیمات خود از جمله اندازه، پرکردن و خطوط مرزی را حفظ می‌کنند.