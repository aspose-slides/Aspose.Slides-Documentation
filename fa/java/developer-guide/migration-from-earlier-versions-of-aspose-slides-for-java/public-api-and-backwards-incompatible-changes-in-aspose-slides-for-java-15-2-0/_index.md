---
title: API عمومی و تغییرات ناسازگار با عقب‌گرد در Aspose.Slides برای Java 15.2.0
linktitle: Aspose.Slides برای Java 15.2.0
type: docs
weight: 110
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات شکسته‌کننده در Aspose.Slides برای Java را بررسی کنید تا بتوانید راه‌حل‌های ارائه PowerPoint، PPT، PPTX و ODP خود را به‌صورت روان مهاجرت کنید."
---
{{% alert color="info" %}} 

این صفحه تمام کلاس‌ها، متدها، خصوصیات و غیرهٔ [added](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) ، هر محدودیت جدید و سایر [changes](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) معرفی‌شده با API Aspose.Slides for Java 15.2.0 را فهرست می‌کند.

{{% /alert %}} {{% alert color="info" %}} 

مشکلات شناخته‌شده‌ای در برخی از گلوله‌های تصویری و اشیاء WordArt وجود دارد که در Aspose.Slides for Java 15.2.0 رفع خواهد شد.

{{% /alert %}} 
## **تغییرات API عمومی**
### **متدهای addDataPointForDoughnutSeries اضافه شده‌اند**
دو overload از متد IChartDataPointCollection.addDataPointForDoughnutSeries() برای افزودن نقاط داده به سری‌های نوع Doughnut اضافه شده‌اند.
### **کلاس com.aspose.slides.SmartArtShape از کلاس com.aspose.slides.GeometryShape ارث‌بری کرده است**
کلاس com.aspose.slides.SmartArtShape از کلاس com.aspose.slides.GeometryShape ارث‌بری کرده است. این تغییر مدل شیء Aspose.Slides را بهبود می‌بخشد و ویژگی‌های جدیدی به کلاس SmartArtShape اضافه می‌کند.
### **متدهای IGradientStopCollection.add(...) و IGradientStopCollection.insert(...) تغییر کرده‌اند**
امضای IGradientStop add(float position, int presetColor) با امضای IGradientStop addPresetColor(float position, int presetColor) جایگزین شده است.

امضای متد IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) با امضای IGradientStop addSchemeColor(float position, int schemeColor) جایگزین شده است.

امضای متد IGradientStopCollection void insert(int index, float position, int presetColor) با امضای void insertPresetColor(int index, float position, int presetColor) جایگزین شده است.

امضای متد IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) با امضای void insertSchemeColor(int index, float position, int schemeColor) جایگزین شده است.
### **متد java.awt.Color getAutomaticSeriesColor() به com.aspose.slides.IChartSeries اضافه شده است**
متد getAutomaticSeriesColor() یک رنگ خودکار برای سری بر اساس اندیس سری و سبک نمودار برمی‌گرداند. این رنگ به صورت پیش‌فرض استفاده می‌شود اگر FillType برابر NotDefined باشد.
 
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **متدی برای حذف نقطه داده نمودار و دسته‌بندی نمودار بر اساس ایندکس آن اضافه شده است**
متد IChartDataPointCollection.removeAt(int index) برای حذف نقطه داده نمودار بر اساس ایندکس آن اضافه شده است.
متد IChartCategoryCollection.removeAt(int index) برای حذف دسته‌بندی نمودار بر اساس ایندکس آن اضافه شده است.
### **مقدار PptXPptY به شمارش com.aspose.slides.PropertyType اضافه شده است**
مقدار PptXPptY به شمارش com.aspose.slides.PropertyType در چارچوب رفع مشکل سریال‌سازی اضافه شده است.