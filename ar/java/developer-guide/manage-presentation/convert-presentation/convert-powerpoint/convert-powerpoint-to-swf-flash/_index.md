---
title: تحويل عروض PowerPoint إلى SWF فلاش في Java
linktitle: PowerPoint إلى SWF
type: docs
weight: 80
url: /ar/java/convert-powerpoint-to-swf-flash/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى SWF
- العرض التقديمي إلى SWF
- الشريحة إلى SWF
- PPT إلى SWF
- PPTX إلى SWF
- PowerPoint إلى فلاش
- العرض التقديمي إلى فلاش
- الشريحة إلى فلاش
- PPT إلى فلاش
- PPTX إلى فلاش
- حفظ PPT كـ SWF
- حفظ PPTX كـ SWF
- تصدير PPT إلى SWF
- تصدير PPTX إلى SWF
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تحويل PowerPoint (PPT/PPTX) إلى SWF فلاش في Java باستخدام Aspose.Slides. عينات كود خطوة بخطوة، مخرجات سريعة وعالية الجودة، بدون أتمتة PowerPoint."
---

## **تحويل PPT(X) إلى SWF**
يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) المعروضة من قبل الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) لتحويل العرض التقديمي بالكامل إلى مستند **SWF**. يوضح المثال التالي كيفية تحويل عرض تقديمي إلى مستند **SWF** باستخدام الخيارات المقدمة من الفئة [**SWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/SwfOptions) class. يمكنك أيضًا تضمين التعليقات في ملف SWF المُولد باستخدام الفئة [**ISWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/ISwfOptions) والواجهة [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions) interface.
```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // حفظ العرض التقديمي
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```
