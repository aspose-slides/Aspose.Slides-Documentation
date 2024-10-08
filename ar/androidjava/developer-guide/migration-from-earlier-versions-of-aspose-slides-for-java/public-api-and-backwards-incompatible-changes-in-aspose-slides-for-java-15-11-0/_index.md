---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع النسخ السابقة في Aspose.Slides لـ Java 15.11.0
type: docs
weight: 190
url: /ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
---

{{% alert color="primary" %}} 

تستعرض هذه الصفحة جميع [المضاف](/slides/ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) أو [المزيل](/slides/ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) من الفئات، والطرق، والخصائص، وما إلى ذلك، وغيرها من التغييرات التي تم إدخالها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 15.11.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تم حذف الطرق القديمة في فئة com.aspose.slides.DataLabelCollection**
تم حذف الطرق القديمة في فئة com.aspose.slides.DataLabelCollection:

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


#### **تمت إضافة طرق جديدة getFirstSlideNumber() و setFirstSlideNumber() إلى فئة Presentation**
تسمح الطرق الجديدة getFirstSlideNumber() و setFirstSlideNumber() بالحصول على رقم الشريحة الأولى أو تعيينه في العرض التقديمي.
عند تحديد قيمة جديدة لرقم الشريحة الأولى يتم إعادة حساب أرقام جميع الشرائح.

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```