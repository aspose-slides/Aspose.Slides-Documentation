---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للوراء في Aspose.Slides for Java 15.11.0
linktitle: Aspose.Slides for Java 15.11.0
type: docs
weight: 190
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- الترحيل
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "استعراض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides for Java لتسهيل ترحيل حلول العروض التقديمية PowerPoint PPT و PPTX و ODP الخاصة بك."
---
{{% alert color="info" %}} 

تُظهر هذه الصفحة جميع الفئات، والأساليب، والخصائص، وما إلى ذلك التي تم [إضافتها](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) أو [إزالتها](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) وكذلك التغييرات الأخرى التي تم تقديمها مع واجهة برمجة تطبيقات Aspose.Slides for Java 15.11.0.

{{% /alert %}} 
## **تغييرات API العامة**
#### **تم حذف الأساليب القديمة في الفئة com.aspose.slides.DataLabelCollection**
تم حذف الأساليب القديمة في الفئة com.aspose.slides.DataLabelCollection:

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


#### **تمت إضافة الأساليب الجديدة getFirstSlideNumber() و setFirstSlideNumber() إلى الفئة Presentation**
تمت إضافة الأساليب الجديدة getFirstSlideNumber() و setFirstSlideNumber() لتتيح الحصول على رقم الشريحة الأولى أو ضبطه في العرض التقديمي.
عند تحديد قيمة جديدة لرقم الشريحة الأولى يتم إعادة حساب جميع أرقام الشرائح.

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    int firstSlideNumber = pres.getFirstSlideNumber();

    pres.setFirstSlideNumber(10);

    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```