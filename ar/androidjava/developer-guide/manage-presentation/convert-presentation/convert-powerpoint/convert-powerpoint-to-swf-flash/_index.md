---
title: تحويل عروض PowerPoint إلى SWF فلاش على Android
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
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "تحويل PowerPoint (PPT/PPTX) إلى SWF فلاش في Java باستخدام Aspose.Slides لنظام Android. عينات كود خطوة بخطوة، إخراج سريع وعالي الجودة، دون أتمتة PowerPoint."
---

## **تحويل PPT(X) إلى SWF**
يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) التي تعرضها فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) لتحويل العرض التقديمي بالكامل إلى مستند **SWF**. يُظهر المثال التالي كيفية تحويل عرض تقديمي إلى مستند **SWF** باستخدام الخيارات المتوفرة في فئة [**SWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SwfOptions). يمكنك أيضًا تضمين التعليقات في ملف SWF المُولد باستخدام فئة [**ISWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISwfOptions) وفئة [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions).
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

نعم. قم بتمكين الشرائح المخفية باستخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) في فئة [SwfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/). بشكل افتراضي، لا يتم تصدير الشرائح المخفية.

**كيف يمكنني التحكم في الضغط وحجم SWF النهائي؟**

استخدم طريقة [setCompressed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) و[adjust JPEG quality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) لتحقيق توازن بين حجم الملف وجودة الصور.

**ما هو الغرض من 'setViewerIncluded' ومتى يجب تعطيله؟**

تضيف طريقة [setViewerIncluded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) واجهة مستخدم مشغّل مدمجة (أدوات التنقل، الألواح، البحث). عطلها إذا كنت تخطط لاستخدام مشغّلك الخاص أو تحتاج إلى إطار SWF بسيط بدون واجهة.

**ماذا يحدث إذا كان الخط الأصلي غير موجود على جهاز التصدير؟**

ستقوم Aspose.Slides باستبدال الخط الذي تحدده عبر [setDefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) في فئة [SwfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/) لتجنب الاعتماد غير المقصود على خط آخر.