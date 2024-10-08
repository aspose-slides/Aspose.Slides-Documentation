---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 14.10.0
type: docs
weight: 90
url: /ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع [الإضافات](/slides/ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) من الفئات والأساليب والخصائص وما إلى ذلك، وأي قيود جديدة وأخرى [التغييرات](/slides/ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 14.10.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **تمت إضافة طريقة com.aspose.slides.FieldType.getFooter()**
تقوم طريقة getFooter() بإرجاع نوع حقل التذييل. تمت إضافتها لتطبيق إمكانية إنشاء حقول من هذا النوع ولتسلسل العروض التقديمية بشكل صحيح.
### **تم حذف عنصر com.aspose.slides.ShapeElementFillSource.Own**
تم حذف عنصر ShapeElementFillSource.Own باعتباره مكررًا. استخدم ShapeElementFillSource.Shape بدلاً من ShapeElementFillSource.Own.
### **تمت إضافة طرق لإزالة نقاط بيانات الرسوم البيانية والفئات**
**تمت إضافة الطرق التالية، التي تسمح بإزالة نقطة بيانات الرسوم البيانية من مجموعة نقاط بيانات الرسم البياني:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**تمت إضافة الطريقة التالية، التي تسمح بإزالة فئة الرسم البياني من المجموعة المحتوية:**

IChartCategory.remove()

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // إزالة باستخدام ChartCategory.remove()

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // إزالة باستخدام ChartCategoryCollection.remove()

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // إزالة باستخدام ChartDataPoint.remove()

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **تمت إزالة طرق Aspose.Slides.ParagraphFormat غير الصالحة**
تمت إزالة الطرق getBulletChar()، getBulletColor()، getBulletColorFormat()، getBulletFont()، getBulletHeight()، getBulletType()، isBulletHardColor()، isBulletHardFont()، getNumberedBulletStartWith()، getNumberedBulletStyle() وطرق set المقابلة. تم تصنيفها على أنها غير صالحة منذ فترة طويلة.
### **تمت إزالة المنشئات غير المفيدة وغير الصالحة**
تمت إزالة المنشئات التالية:

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