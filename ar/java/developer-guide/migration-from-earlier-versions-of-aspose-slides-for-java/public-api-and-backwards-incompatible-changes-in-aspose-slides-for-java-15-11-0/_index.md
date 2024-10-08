---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 15.11.0
type: docs
weight: 190
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
---

{{% alert color="primary" %}} 

تستعرض هذه الصفحة جميع [المضافات](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) أو [المحذوفات](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) من الفئات، والأساليب، والخصائص، وما إلى ذلك، والتغييرات الأخرى التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 15.11.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تم حذف الأساليب القديمة في فئة com.aspose.slides.DataLabelCollection**
تم حذف الأساليب القديمة في فئة com.aspose.slides.DataLabelCollection:

DataLabelCollection.getNumberFormat()
DataLabelCollection.setNumberFormat(String value)
DataLabelCollection.getLinkedSource()
DataLabelCollection.setLinkedSource(boolean value)
DataLabelCollection.getDelete()
DataLabelCollection.setDelete(boolean value)
DataLabelCollection.getFormat()
DataLabelCollection.setFormat(Format value)
DataLabelCollection.getPosition()
DataLabelCollection.setPosition(int value)
DataLabelCollection.getSeparator()
DataLabelCollection.setSeparator(String value)
DataLabelCollection.getShowLegendKey()
DataLabelCollection.setShowLegendKey(boolean value)
DataLabelCollection.getShowLeaderLines()
DataLabelCollection.setShowLeaderLines(boolean value)
DataLabelCollection.getShowCategoryName()
DataLabelCollection.setShowCategoryName(boolean value)
DataLabelCollection.getShowValue()
DataLabelCollection.setShowValue(boolean value)
DataLabelCollection.getShowPercentage()
DataLabelCollection.setShowPercentage(boolean value)
DataLabelCollection.getShowSeriesName()
DataLabelCollection.setShowSeriesName(boolean value)
DataLabelCollection.getShowBubbleSize()
DataLabelCollection.setShowBubbleSize(boolean value)


#### **تمت إضافة أساليب جديدة getFirstSlideNumber() و setFirstSlideNumber() إلى فئة Presentation**
تسمح الأساليب الجديدة getFirstSlideNumber() و setFirstSlideNumber() بالحصول على أو تعيين رقم الشريحة الأولى في العرض التقديمي.
عند تحديد قيمة جديدة لرقم الشريحة الأولى، يتم إعادة حساب جميع أرقام الشرائح.

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```