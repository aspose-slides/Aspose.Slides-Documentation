---
title: تحويل عروض PowerPoint إلى SWF Flash على Android
linktitle: PowerPoint إلى SWF
type: docs
weight: 80
url: /ar/androidjava/convert-powerpoint-to-swf-flash/
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
- PowerPoint إلى Flash
- العرض التقديمي إلى Flash
- الشريحة إلى Flash
- PPT إلى Flash
- PPTX إلى Flash
- حفظ PPT كـ SWF
- حفظ PPTX كـ SWF
- تصدير PPT إلى SWF
- تصدير PPTX إلى SWF
- PowerPoint
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "تحويل PowerPoint (PPT/PPTX) إلى SWF Flash في Java باستخدام Aspose.Slides لنظام Android. نماذج شفرة خطوة بخطوة، إخراج سريع عالي الجودة، بدون أتمتة PowerPoint."
---

## **تحويل PPT(X) إلى SWF**
يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) التي توفرها الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) لتحويل العرض بالكامل إلى مستند **SWF**. يوضح المثال التالي كيفية تحويل عرض إلى مستند **SWF** باستخدام الخيارات التي توفرها الفئة [**SWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SwfOptions). يمكنك أيضًا تضمين التعليقات في ملف SWF المُنشأ باستخدام الفئة [**ISWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISwfOptions) والواجهة [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions).
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


## **الأسئلة المتكررة**
**هل يمكنني تضمين الشرائح المخفية في ملف SWF؟**

نعم. قم بتمكين الشرائح المخفية باستخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) في الفئة [SwfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/). بشكل افتراضي، لا يتم تصدير الشرائح المخفية.

**كيف يمكنني التحكم في الضغط وحجم ملف SWF النهائي؟**

استخدم طريقة [setCompressed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) و[adjust JPEG quality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) لتحقيق التوازن بين حجم الملف وجودة الصورة.

**ما هو الهدف من 'setViewerIncluded' ومتى ينبغي تعطيله؟**

تضيف [setViewerIncluded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) واجهة مستخدم مشغّل مدمجة (أدوات تنقل، ألواح، بحث). عطلها إذا كنت تنوي استخدام مشغّل خاص بك أو إذا كنت تحتاج إطار SWF بسيط بدون واجهة.

**ماذا يحدث إذا كان الخط الأصلي غير موجود على جهاز التصدير؟**

ستستبدل Aspose.Slides الخط الذي تحدده عبر [setDefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) في الفئة [SwfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/) لتجنب الانتقال غير المقصود إلى خط آخر.