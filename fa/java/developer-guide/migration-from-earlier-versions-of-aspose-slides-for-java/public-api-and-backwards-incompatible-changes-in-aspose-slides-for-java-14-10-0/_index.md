---
title: API عمومی و تغییرات ناسازگار به عقب در Aspose.Slides برای Java 14.10.0
linktitle: Aspose.Slides برای Java 14.10.0
type: docs
weight: 90
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
keywords:
- مهاجرت
- کد قدیمی
- کد مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای Java را بررسی کنید تا بتوانید راه‌حل‌های ارائه PowerPoint (PPT, PPTX) و ODP خود را به‌صورت روان مهاجرت کنید."
---
{{% alert color="primary" %}} 

این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و غیره [اضافه‌شده](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) را، هر محدودیت جدید و سایر [تغییرات](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) معرفی‌شده با Aspose.Slides for Java 14.10.0 API، فهرست می‌کند.

{{% /alert %}} 
## **تغییرات API عمومی**
### **متد com.aspose.slides.FieldType.getFooter() اضافه شده است**
متد getFooter() نوع فیلد پاورقی را برمی‌گرداند. این متد برای امکان‌پذیری ایجاد فیلدهای این نوع و برای سریال‌سازی صحیح ارائه اضافه شده است.
### **عنصر com.aspose.slides.ShapeElementFillSource.Own حذف شده است**
عنصر ShapeElementFillSource.Own به‌دلیل تکراری بودن حذف شده است. به جای ShapeElementFillSource.Own از ShapeElementFillSource.Shape استفاده کنید.
### **متدهایی برای حذف نقاط داده نمودار و دسته‌ها اضافه شده‌اند**
**متدهای زیر که امکان حذف نقطه داده نمودار از مجموعه نقاط داده نمودار را فراهم می‌کنند، اضافه شده‌اند:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**متد زیر که امکان حذف یک دسته‌بندی نمودار از مجموعه مربوطه را فراهم می‌کند، اضافه شده است:**

IChartCategory.remove()

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // حذف با ChartCategory.remove()

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // حذف با ChartCategoryCollection.remove()

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // حذف با ChartDataPoint.remove()

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // حذف با ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **متدهای منسوخ‌شده Aspose.Slides.ParagraphFormat حذف شده‌اند**
متدهای getBulletChar()، getBulletColor()، getBulletColorFormat()، getBulletFont()، getBulletHeight()، getBulletType()، isBulletHardColor()، isBulletHardFont()، getNumberedBulletStartWith()، getNumberedBulletStyle() و متدهای set مربوطه حذف شده‌اند. این‌ها مدت‌ها پیش به‌عنوان منسوخ علامت‌گذاری شده بودند.
### **سازنده‌های غیرقابل‌استفاده و منسوخ حذف شده‌اند**
سازنده‌های زیر حذف شده‌اند:

com.aspose.slides.AlphaBiLevel(float)
com.aspose.slides.AlphaModulateFixed(float)
com.aspose.slides.AlphaReplace(float)
com.aspose.slides.BiLevel(float)
com.aspose.slides.Blur(double, boolean)
com.aspose.slides.HSL(float, float, float)
com.aspose.slides.ImageTransformOperation(com.aspose.slides.ImageTransformOperationCollection)
com.aspose.slides.Luminance(float, float)
com.aspose.slides.Tint(float, float)
com.aspose.slides.PortionFormat(com.aspose.slides.ParagraphFormat)
com.aspose.slides.PortionFormat(com.aspose.slides.Portion)
com.aspose.slides.PortionFormat(com.aspose.slides.PortionFormat)