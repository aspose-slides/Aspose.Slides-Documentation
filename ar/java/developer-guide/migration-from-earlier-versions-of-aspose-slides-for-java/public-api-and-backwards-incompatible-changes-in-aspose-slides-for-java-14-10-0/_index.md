---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides for Java 14.10.0
linktitle: Aspose.Slides لـ Java 14.10.0
type: docs
weight: 90
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
keywords:
- الهجرة
- الكود القديم
- الكود الحديث
- النهج القديم
- النهج الحديث
- PowerPoint
- OpenDocument
- العرض التقديمي
- Java
- Aspose.Slides
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات الجذرية في Aspose.Slides for Java لتحديث حلول عروض PowerPoint (PPT، PPTX) وODP بسلاسة."
---
{{% alert color="info" %}}
هذه الصفحة تسرد جميع [مضافة](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) الفئات، الطرق، الخصائص وما إلى ذلك، وأي قيود جديدة و[التغييرات](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) التي تم تقديمها مع Aspose.Slides for Java 14.10.0 API.
{{% /alert %}}
## **تغييرات واجهة برمجة التطبيقات العامة**
### **طريقة com.aspose.slides.FieldType.getFooter() تم إضافتها**
طريقة getFooter() تُعيد نوع حقل التذييل. تم إضافتها لتوفير إمكانية إنشاء حقول من هذا النوع وللسماح بتسلسل العرض التقديمي بشكل صحيح.
### **العنصر com.aspose.slides.ShapeElementFillSource.Own تم حذفه**
العنصر ShapeElementFillSource.Own تم حذفه لأنه مكرر. استخدم ShapeElementFillSource.Shape بدلاً من ShapeElementFillSource.Own.
### **تم إضافة طرق لإزالة نقاط بيانات المخطط والفئات**
**الطرق التالية التي تسمح بإزالة نقطة بيانات من مجموعة نقاط بيانات المخطط تم إضافتها:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**الطريقة التالية التي تسمح بإزالة فئة مخطط من المجموعة الحاوية تم إضافتها:**

IChartCategory.remove()

``` java
import com.aspose.slides.*;


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
### **تم حذف طرق Aspose.Slides.ParagraphFormat القديمة**
تم حذف الطرق getBulletChar()، getBulletColor()، getBulletColorFormat()، getBulletFont()، getBulletHeight()، getBulletType()، isBulletHardColor()، isBulletHardFont()، getNumberedBulletStartWith()، getNumberedBulletStyle() والطُرق المقابلة set. كانت مُعلَّمة بأنها قديمة منذ زمن طويل.
### **تم حذف البُنَيات غير المفيدة والقديمة**
البنائيات التالية تم حذفها:

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