---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 15.5.0
type: docs
weight: 130
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
---

{{% alert color="primary" %}} 

تدرج هذه الصفحة جميع [الإضافات](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) من الفصول، والأساليب، والخصائص، وما إلى ذلك، وأي قيود جديدة وأي [تغييرات](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) مقدمة مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 15.5.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **تم إضافة فئة CommonSlideViewProperties وواجهة ICommonSlideViewProperties**
تمثل فئة com.aspose.slides.CommonSlideViewProperties (وواجهتها com.aspose.slides.ICommonSlideViewProperties) خصائص عرض الشريحة العامة (خيارات مقياس العرض الحالية).
### **تم إضافة الأساليب IAxis.getLabelOffset() و setLabelOffset(int)**
تسمح الأساليب IAxis.getLabelOffset() و setLabelOffset(int) بالحصول على المسافة وتحديدها بين التسميات والمحور. تُطبق على محور الفئة أو التاريخ.
### **تم إضافة الأساليب IChartTextBlockFormat.getAutofitType() و setAutofitType(byte)**
تمت إضافة الأساليب getAutofitType() و setAutofitType(/**TextAutofitType**/byte) إلى واجهة com.aspose.slides.IChartTextBlockFormat.
يمكن أن يؤثر تغيير هذه القيمة بشكل معين فقط على هذه الأجزاء من المخطط: DataLabel و DataLabelFormat (دعم كامل في PowerPoint 2013؛ في PowerPoint 2007 ليس هناك تأثير على العرض).
### **تم إضافة الأساليب IChartTextBlockFormat.getWrapText() و setWrapText(byte)**
تمت إضافة الأساليب getWrapText() و setWrapText(/**NullableBool**/byte) إلى واجهة com.aspose.slides.IChartTextBlockFormat.
يمكن أن يؤثر تغيير هذه القيمة بشكل معين فقط على هذه الأجزاء من المخطط: DataLabel و DataLabelFormat (دعم كامل في PowerPoint 2007/2013).
### **تمت إضافة الأساليب لإدارة الهوامش إلى IChartTextBlockFormat**
تمت إضافة الأساليب getMarginLeft() و setMarginLeft(double) و getMarginRight() و setMarginRight(double) و getMarginTop() و setMarginTop(double) و getMarginBottom() و setMarginBottom(double) إلى واجهة com.aspose.slides.IChartTextBlockFormat.
يمكن أن يؤثر تغيير هذه القيم بشكل معين فقط على هذه الأجزاء من المخطط: DataLabel و DataLabelFormat (دعم كامل في PowerPoint 2013؛ في PowerPoint 2007 ليس هناك تأثير على العرض).
### **تم إضافة الأسلوب ViewProperties.getNotesViewProperties()**
تمت إضافة الخاصية com.aspose.slides.ViewProperties.getNotesViewProperties(). تحصل على خصائص العرض العامة المرتبطة بوضع عرض الملاحظات.
### **تم إضافة الأسلوب ViewProperties.getSlideViewProperties()**
تمت إضافة الأسلوب com.aspose.slides.ViewProperties.getSlideViewProperties(). تحصل على خصائص العرض العامة المرتبطة بوضع عرض الشريحة.