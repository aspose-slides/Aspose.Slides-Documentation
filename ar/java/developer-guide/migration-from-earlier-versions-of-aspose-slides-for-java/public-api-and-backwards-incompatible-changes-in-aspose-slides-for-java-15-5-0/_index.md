---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 15.5.0
type: docs
weight: 130
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
---

{{% alert color="primary" %}} 

تقوم هذه الصفحة بإدراج جميع [الإضافات](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) من الفئات والأساليب والخصائص وما إلى ذلك، وأي قيود جديدة وأخرى [التغييرات](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 15.5.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **تمت إضافة فئة CommonSlideViewProperties وواجهة ICommonSlideViewProperties**
تُمثل فئة com.aspose.slides.CommonSlideViewProperties (وواجهتها com.aspose.slides.ICommonSlideViewProperties) خصائص عرض الشرائح المشتركة (حاليًا خيارات مقياس العرض).
### **تمت إضافة طرق IAxis.getLabelOffset() و setLabelOffset(int)**
تتيح طرق IAxis.getLabelOffset() و setLabelOffset(int) الحصول على وتحديد المسافة بين التسميات والمحور. تُطبق على المحاور الفئوية أو الزمنية.
### **تمت إضافة طرق IChartTextBlockFormat.getAutofitType() و setAutofitType(byte)**
تمت إضافة طرق getAutofitType() و setAutofitType(/**TextAutofitType**/byte) إلى واجهة com.aspose.slides.IChartTextBlockFormat.
يمكن أن يؤثر تغيير هذه القيمة على أجزاء معينة فقط من الرسم البياني: DataLabel و DataLabelFormat (دعم كامل في PowerPoint 2013؛ في PowerPoint 2007 لا يوجد تأثير على الرندر).
### **تمت إضافة طرق IChartTextBlockFormat.getWrapText() و setWrapText(byte)**
تمت إضافة طرق getWrapText() و setWrapText(/**NullableBool**/byte) إلى واجهة com.aspose.slides.IChartTextBlockFormat.
يمكن أن يؤثر تغيير هذه القيمة على أجزاء معينة فقط من الرسم البياني: DataLabel و DataLabelFormat (دعم كامل في PowerPoint 2007/2013).
### **تمت إضافة طرق لإدارة الهوامش إلى IChartTextBlockFormat**
تمت إضافة طرق getMarginLeft() و setMarginLeft(double) و getMarginRight() و setMarginRight(double) و getMarginTop() و setMarginTop(double) و getMarginBottom() و setMarginBottom(double) إلى واجهة com.aspose.slides.IChartTextBlockFormat.
يمكن أن يؤثر تغيير هذه القيم على أجزاء معينة فقط من الرسم البياني: DataLabel و DataLabelFormat (دعم كامل في PowerPoint 2013؛ في PowerPoint 2007 لا يوجد تأثير على الرندر).
### **تمت إضافة طريقة ViewProperties.getNotesViewProperties()**
تمت إضافة خاصية com.aspose.slides.ViewProperties.getNotesViewProperties(). تسترجع الخصائص العامة المرتبطة بوضع عرض الملاحظات.
### **تمت إضافة طريقة ViewProperties.getSlideViewProperties()**
تمت إضافة طريقة com.aspose.slides.ViewProperties.getSlideViewProperties(). تسترجع الخصائص العامة المرتبطة بوضع عرض الشريحة.