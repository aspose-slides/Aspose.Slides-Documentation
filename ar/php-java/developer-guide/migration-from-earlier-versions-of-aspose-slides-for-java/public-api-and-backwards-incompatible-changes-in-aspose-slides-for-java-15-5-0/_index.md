---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ PHP عبر Java 15.5.0
type: docs
weight: 130
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
---

{{% alert color="primary" %}} 

تُدرج هذه الصفحة جميع [الإضافات](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) من الفئات والأساليب والخصائص وما إلى ذلك، أي قيود جديدة وأي [تغييرات](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) مقدمة مع واجهة برمجة التطبيقات Aspose.Slides لـ PHP عبر Java 15.5.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **تمت إضافة فئة CommonSlideViewProperties وواجهة ICommonSlideViewProperties**
تمثل فئة com.aspose.slides.CommonSlideViewProperties (وواجهتها com.aspose.slides.ICommonSlideViewProperties) خصائص عرض الشريحة العامة (خيارات مقياس العرض حالياً).
### **تمت إضافة الطرق IAxis.getLabelOffset() وsetLabelOffset(int)**
تسمح طرق IAxis.getLabelOffset() وsetLabelOffset(int) للحصول على وتحديد المسافة بين التسميات والمحور. يتم تطبيقها على المحور الفئوي أو الزمني.
### **تمت إضافة الطرق IChartTextBlockFormat.getAutofitType() وsetAutofitType(byte)**
تمت إضافة الطرق getAutofitType() وsetAutofitType(/**TextAutofitType**/byte) إلى واجهة com.aspose.slides.IChartTextBlockFormat.
يمكن أن يؤدي تغيير هذه القيمة إلى تأثير معين فقط على هذه الأجزاء من الرسم البياني: DataLabel وDataLabelFormat (دعم كامل في PowerPoint 2013؛ في PowerPoint 2007 لا يوجد تأثير للتصيير).
### **تمت إضافة الطرق IChartTextBlockFormat.getWrapText() وsetWrapText(byte)**
تمت إضافة الطرق getWrapText() وsetWrapText(/**NullableBool**/byte) إلى واجهة com.aspose.slides.IChartTextBlockFormat.
يمكن أن يؤدي تغيير هذه القيمة إلى تأثير معين فقط على هذه الأجزاء من الرسم البياني: DataLabel وDataLabelFormat (دعم كامل في PowerPoint 2007/2013).
### **تمت إضافة الطرق لإدارة الهوامش إلى IChartTextBlockFormat**
تمت إضافة الطرق getMarginLeft() وsetMarginLeft(double) وgetMarginRight() وsetMarginRight(double) وgetMarginTop() وsetMarginTop(double) وgetMarginBottom() وsetMarginBottom(double) إلى واجهة com.aspose.slides.IChartTextBlockFormat.
يمكن أن يؤدي تغيير هذه القيم إلى تأثير معين فقط على هذه الأجزاء من الرسم البياني: DataLabel وDataLabelFormat (دعم كامل في PowerPoint 2013؛ في PowerPoint 2007 لا يوجد تأثير للتصيير).
### **تمت إضافة طريقة ViewProperties.getNotesViewProperties()**
تمت إضافة خاصية com.aspose.slides.ViewProperties.getNotesViewProperties(). تستخدم للحصول على الخصائص العامة المرتبطة بوضع عرض الملاحظات.
### **تمت إضافة طريقة ViewProperties.getSlideViewProperties()**
تمت إضافة طريقة com.aspose.slides.ViewProperties.getSlideViewProperties(). تستخدم للحصول على الخصائص العامة المرتبطة بوضع عرض الشريحة.