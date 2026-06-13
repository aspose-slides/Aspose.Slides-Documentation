---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای جاوا 15.2.0
linktitle: Aspose.Slides برای جاوا 15.2.0
type: docs
weight: 110
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- پاورپوینت
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات شکسته‌کننده در Aspose.Slides برای جاوا را مرور کنید تا به‌صورت روان برنامه‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="primary" %}} 

این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و غیره [added](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) را فهرست می‌کند، هر محدودیت جدید و سایر [changes](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) که با Aspose.Slides for Java 15.2.0 API معرفی شده‌اند.

{{% /alert %}} {{% alert color="primary" %}} 

مشکلات شناخته‌شده‌ای با برخی گلوله‌های تصویری و اشیاء WordArt وجود دارد که در Aspose.Slides for Java 15.2.0 رفع خواهند شد.

{{% /alert %}} 
## **تغییرات عمومی API**
### **متدهای addDataPointForDoughnutSeries اضافه شده‌اند**
دو overload از متد IChartDataPointCollection.addDataPointForDoughnutSeries() برای افزودن نقاط داده به سری‌های نوع Doughnut اضافه شده‌اند.
### **کلاس com.aspose.slides.SmartArtShape از کلاس com.aspose.slides.GeometryShape ارث‌بری شده است**
کلاس com.aspose.slides.SmartArtShape از کلاس com.aspose.slides.GeometryShape ارث‌بری شده است. این تغییر مدل شیء Aspose.Slides را بهبود می‌بخشد و ویژگی‌های جدیدی به کلاس SmartArtShape می‌افزاید.
### **متدهای IGradientStopCollection.add(...) و IGradientStopCollection.insert(...) تغییر کرده‌اند**
امضای IGradientStop add(float position, int presetColor) با امضای IGradientStop addPresetColor(float position, int presetColor) جایگزین شده است.

امضای IGradientStopCollection add(float position, SchemeColor schemeColor) با امضای IGradientStop addSchemeColor(float position, int schemeColor) جایگزین شده است.

امضای متد IGradientStopCollection void insert(int index, float position, int presetColor) با امضای void insertPresetColor(int index, float position, int presetColor) جایگزین شده است.

امضای متد IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) با امضای void insertSchemeColor(int index, float position, int schemeColor) جایگزین شده است.
### **متد java.awt.Color getAutomaticSeriesColor() به com.aspose.slides.IChartSeries اضافه شده است**
متد getAutomaticSeriesColor() یک رنگ خودکار برای سری بر اساس ایندکس سری و سبک نمودار برمی‌گرداند. این رنگ به‌طور پیش‌فرض استفاده می‌شود اگر FillType برابر NotDefined باشد.
 

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **متدی برای حذف نقطه داده نمودار و دسته‌بندی نمودار بر اساس ایندکس افزوده شده است**
متد IChartDataPointCollection.removeAt(int index) برای حذف نقطه داده نمودار بر اساس ایندکس اضافه شده است.
متد IChartCategoryCollection.removeAt(int index) برای حذف دسته‌بندی نمودار بر اساس ایندکس اضافه شده است.
### **مقدار PptXPptY به شمارش com.aspose.slides.PropertyType اضافه شده است**
مقدار PptXPptY به شمارش com.aspose.slides.PropertyType اضافه شده است تا مشکل مربوط به سریالیزیشن برطرف شود.