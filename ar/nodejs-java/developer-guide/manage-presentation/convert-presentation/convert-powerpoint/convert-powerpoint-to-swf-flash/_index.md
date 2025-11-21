---
title: تحويل PowerPoint إلى SWF Flash
type: docs
weight: 80
url: /ar/nodejs-java/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX إلى SWF"
description: "تحويل PowerPoint PPT، PPTX إلى SWF في JavaScript"
---

## **تحويل PPT(X) إلى SWF**
يمكن استخدام طريقة [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) المعرضة من قبل فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) لتحويل العرض التقديمي بالكامل إلى مستند **SWF**. يوضح المثال التالي كيفية تحويل عرض تقديمي إلى مستند **SWF** باستخدام الخيارات التي توفرها فئة [**SWFOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SwfOptions) . يمكنك أيضًا تضمين التعليقات في ملف SWF المُولد باستخدام فئة [**SWFOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SwfOptions) وفئة [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions) .
```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // حفظ العرض التقديمي
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة الشائعة**

**هل يمكنني تضمين الشرائح المخفية في ملف SWF؟**
نعم. استخدم طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) في فئة [SwfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/). بشكل افتراضي، لا يتم تصدير الشرائح المخفية.

**كيف يمكنني التحكم في الضغط وحجم ملف SWF النهائي؟**
استخدم طريقة [setCompressed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setcompressed/) وطريقة [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setjpegquality/) لتحقيق التوازن بين حجم الملف وجودة الصورة.

**ما هو الغرض من 'setViewerIncluded' ومتى يجب استخدامه؟**
[setViewerIncluded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) يضيف واجهة مستخدم مدمجة للمشغل (عناصر تحكم التنقل، اللوحات، البحث). استخدمه إذا كنت تخطط لاستخدام مشغلك الخاص أو تحتاج إلى إطار SWF بسيط بدون واجهة.

**ماذا يحدث إذا كان الخط المصدر مفقودًا على جهاز التصدير؟**
ستقوم Aspose.Slides باستبدال الخط الذي تحدده عبر [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) في فئة [SwfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/) لتجنب الرجوع غير المقصود.