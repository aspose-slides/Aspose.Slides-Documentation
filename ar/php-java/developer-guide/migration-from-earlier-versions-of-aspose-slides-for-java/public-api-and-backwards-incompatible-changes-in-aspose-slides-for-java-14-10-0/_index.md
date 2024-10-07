---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدار السابق في Aspose.Slides لـ PHP عبر Java 14.10.0
type: docs
weight: 90
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع [الإضافات](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) من الفئات والأساليب والخصائص وما إلى ذلك، وأي قيود جديدة وتغييرات أخرى [تغيرات](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) تم إدخالها مع واجهة برمجة التطبيقات Aspose.Slides لـ PHP عبر Java 14.10.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **تم إضافة طريقة com.aspose.slides.FieldType::getFooter()**
ترجع طريقة getFooter() نوع حقل التذييل. تم إضافتها لتطبيق إمكانية إنشاء حقول من هذا النوع وserialization العرض الصحيح.
### **تم حذف عنصر com.aspose.slides.ShapeElementFillSource.Own**
تم حذف عنصر ShapeElementFillSource.Own لأنه مكرر. استخدم ShapeElementFillSource.Shape بدلاً من ShapeElementFillSource.Own.
### **تمت إضافة طرق لإزالة بيانات نقاط الرسم البياني والفئات**
**تمت إضافة الطرق التالية، التي تسمح بإزالة نقطة بيانات الرسم البياني من مجموعة نقاط بيانات الرسم البياني:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**تمت إضافة الطريقة التالية، التي تسمح بإزالة فئة الرسم البياني من المجموعة المحتوية:**

IChartCategory.remove()

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 400, true);
  $chart->getChartData()->getCategories()->get_Item(0)->remove();// إزالة باستخدام ChartCategory.remove()

  $chart->getChartData()->getCategories()->remove($chart->getChartData()->getCategories()->get_Item(0));// إزالة باستخدام ChartCategoryCollection.remove()

  foreach($chart->getChartData()->getSeries() as $ser) {
    $ser->getDataPoints()->get_Item(0)->remove();// إزالة باستخدام ChartDataPoint.remove()

    $ser->getDataPoints()->remove($ser->getDataPoints()->get_Item(0));// ChartDataPointCollection.remove()

  }
  $pres->save("presentation.pptx", SaveFormat::Pptx);

```
### **تمت إزالة طرق Aspose.Slides.ParagraphFormat القديمة**
تمت إزالة الطرق getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() والطرق المقابلة لها. تم وضع علامة عليها على أنها قديمة منذ فترة طويلة.
### **تمت إزالة المنشئات غير المفيدة والقديمة**
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