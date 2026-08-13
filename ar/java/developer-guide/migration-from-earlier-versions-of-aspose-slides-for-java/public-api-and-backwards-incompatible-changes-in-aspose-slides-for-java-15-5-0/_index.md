---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة إلى الخلف في Aspose.Slides for Java 15.5.0
linktitle: Aspose.Slides لـ Java 15.5.0
type: docs
weight: 130
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- الهجرة
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides for Java لتسهيل ترحيل حلول عروض PowerPoint (PPT, PPTX) و ODP الخاصة بك."
---
{{% alert color="info" %}} 

تُدرج هذه الصفحة جميع [المضافة](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) الفئات والطرق والخصائص وما إلى ذلك، وأي قيود جديدة و[التغييرات](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) الأخرى التي تم تقديمها مع Aspose.Slides for Java 15.5.0 API.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **تمت إضافة الفئة CommonSlideViewProperties والواجهة ICommonSlideViewProperties**
تمثل الفئة com.aspose.slides.CommonSlideViewProperties (وواجهتها com.aspose.slides.ICommonSlideViewProperties) خصائص عرض الشريحة العامة (حالياً خيارات مقياس العرض).
### **تمت إضافة الطرق IAxis.getLabelOffset() و setLabelOffset(int)**
تسمح الطرق IAxis.getLabelOffset() و setLabelOffset(int) بالحصول على وتحديد المسافة بين التسميات والمحور. تُطبق على محور الفئة أو التاريخ.
### **تمت إضافة الطرق IChartTextBlockFormat.getAutofitType() و setAutofitType(byte)**
تمت إضافة الطريقتين getAutofitType() و setAutofitType(/**TextAutofitType**/byte) إلى الواجهة com.aspose.slides.IChartTextBlockFormat. يمكن أن يؤثر تغيير هذه القيمة فقط على أجزاء المخطط التالية: DataLabel و DataLabelFormat (دعم كامل في PowerPoint 2013؛ لا تأثير في PowerPoint 2007 للعرض).
### **تمت إضافة الطرق IChartTextBlockFormat.getWrapText() و setWrapText(byte)**
تمت إضافة الطريقتين getWrapText() و setWrapText(/**NullableBool**/byte) إلى الواجهة com.aspose.slides.IChartTextBlockFormat. يمكن أن يؤثر تغيير هذه القيمة فقط على أجزاء المخطط التالية: DataLabel و DataLabelFormat (دعم كامل في PowerPoint 2007/2013).
### **تمت إضافة طرق إدارة الهوامش إلى IChartTextBlockFormat**
تمت إضافة الطرائق getMarginLeft()، setMarginLeft(double)، getMarginRight()، setMarginRight(double)، getMarginTop()، setMarginTop(double)، getMarginBottom() و setMarginBottom(double) إلى الواجهة com.aspose.slides.IChartTextBlockFormat. يمكن أن يؤثر تغيير هذه القيم فقط على أجزاء المخطط التالية: DataLabel و DataLabelFormat (دعم كامل في PowerPoint 2013؛ لا تأثير في PowerPoint 2007 للعرض).
### **تمت إضافة الطريقة ViewProperties.getNotesViewProperties()**
تمت إضافة الخاصية com.aspose.slides.ViewProperties.getNotesViewProperties()، والتي تُعيد خصائص العرض العامة المرتبطة بوضع عرض الملاحظات.
### **تمت إضافة الطريقة ViewProperties.getSlideViewProperties()**
تمت إضافة الطريقة com.aspose.slides.ViewProperties.getSlideViewProperties()، والتي تُعيد خصائص العرض العامة المرتبطة بوضع عرض الشريحة.