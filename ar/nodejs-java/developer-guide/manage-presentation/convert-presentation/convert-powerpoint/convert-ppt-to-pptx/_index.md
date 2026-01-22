---
title: تحويل PPT إلى PPTX باستخدام JavaScript
linktitle: PPT إلى PPTX
type: docs
weight: 20
url: /ar/nodejs-java/convert-ppt-to-pptx/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل الشريحة
- تحويل PPT
- PPT إلى PPTX
- حفظ PPT بصيغة PPTX
- تصدير PPT إلى PPTX
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل عروض PPT القديمة إلى PPTX الحديثة بسرعة مع Aspose.Slides لـ Node.js — دليل واضح، أمثلة رموز مجانية، بدون اعتماد على Microsoft Office."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPT إلى تنسيق PPTX باستخدام JavaScript ومع تطبيق التحويل عبر الإنترنت من PPT إلى PPTX. يتم تغطية الموضوع التالي.

- تحويل PPT إلى PPTX باستخدام JavaScript

## **تحويل PPT إلى PPTX باستخدام Java**

للحصول على عينة كود JavaScript لتحويل PPT إلى PPTX، يرجى الاطلاع على القسم أدناه أي [تحويل PPT إلى PPTX](#convert-ppt-to-pptx). يقوم ببساطة بتحميل ملف PPT وحفظه بتنسيق PPTX. عن طريق تحديد صيغ حفظ مختلفة، يمكنك أيضًا حفظ ملف PPT إلى صيغ أخرى مثل PDF وXPS وODP وHTML وغيرها كما نوقشت في هذه المقالات.

- [تحويل PPT إلى PDF باستخدام JavaScript](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/)
- [تحويل PPT إلى XPS باستخدام JavaScript](/slides/ar/nodejs-java/convert-powerpoint-to-xps/)
- [تحويل PPT إلى HTML باستخدام JavaScript](/slides/ar/nodejs-java/convert-powerpoint-to-html/)
- [تحويل PPT إلى ODP باستخدام JavaScript](/slides/ar/nodejs-java/save-presentation/)
- [تحويل PPT إلى PNG باستخدام JavaScript](/slides/ar/nodejs-java/convert-powerpoint-to-png/)

## **حول تحويل PPT إلى PPTX**

تحويل تنسيق PPT القديم إلى PPTX باستخدام Aspose.Slides API. إذا كنت بحاجة إلى تحويل آلاف عروض PPT إلى تنسيق PPTX، فإن الحل الأفضل هو القيام بذلك برمجياً. باستخدام Aspose.Slides API يمكن القيام بذلك ببضع أسطر من الكود فقط. يدعم API توافقًا كاملاً لتحويل عرض PPT إلى PPTX ويمكنه:

- تحويل الهياكل المعقدة من القوالب والتخطيطات والشرائح.
- تحويل العروض التي تحتوي على مخططات.
- تحويل العروض التي تحتوي على مجموعات أشكال، وأشكال تلقائية (مثل المستطيلات والدوائر)، وأشكال ذات هندسة مخصصة.
- تحويل العروض التي تحتوي على أنماط تعبئة من القواميس والصور للأشكال التلقائية.
- تحويل العروض التي تحتوي على عناصر نائبة، وإطارات نصية وحاملات نص.

{{% alert color="primary" %}} 

ألقِ نظرة على تطبيق [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

تم بناء هذا التطبيق بناءً على [**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/)، لذا يمكنك رؤية مثال حي لقدرات التحويل الأساسية من PPT إلى PPTX. Aspose.Slides Conversion هو تطبيق ويب يتيح سحب ملف عرض بصيغة PPT وتحميله بعد تحويله إلى PPTX.

اعثر على أمثلة حية أخرى لـ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}} 

## **تحويل PPT إلى PPTX**

تمكن Aspose.Slides لـ Node.js عبر Java المطورين الآن من الوصول إلى PPT باستخدام فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) وتحويله إلى الصيغة المناسبة [PPTX](https://docs.fileformat.com/presentation/pptx/). في الوقت الحالي، يدعم التحويل الجزئي من [PPT](https://docs.fileformat.com/presentation/ppt/) إلى PPTX.

توفر Aspose.Slides لـ Node.js عبر Java فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) التي تمثل ملف عرض **PPTX**. يمكن لفئة Presentation الآن أيضًا الوصول إلى **PPT** عبر Presentation عند إنشاء الكائن. يوضح المثال التالي كيفية تحويل عرض PPT إلى عرض PPTX.
```javascript
// إنشاء كائن Presentation يمثل ملف PPTX
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // حفظ عرض PPTX بتنسيق PPTX
    pres.save("ConvertedAspose.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**الشكل: عرض PPT المصدر**|

الكود أعلاه يولد عرض PPTX التالي بعد التحويل

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**الشكل: عرض PPTX المُنتج بعد التحويل**|

## **الأسئلة الشائعة**

**ما هو الفرق بين صيغتي PPT و PPTX؟**

PPT هو تنسيق الملف الثنائي القديم الذي تستخدمه Microsoft PowerPoint، بينما PPTX هو التنسيق الجديد القائم على XML والذي تم تقديمه مع Microsoft Office 2007. ملفات PPTX توفر أداءً أفضل، حجم ملف أصغر، وتحسينًا في استعادة البيانات.

**هل يدعم Aspose.Slides التحويل الجماعي لعدة ملفات PPT إلى PPTX؟**

نعم، يمكنك استخدام Aspose.Slides داخل حلقة لتحويل عدة ملفات PPT إلى PPTX برمجياً، مما يجعله مناسبًا لسيناريوهات التحويل الجماعي.

**هل سيتم الحفاظ على المحتوى والتنسيق بعد التحويل؟**

يحافظ Aspose.Slides على دقة عالية عند تحويل العروض. يتم الحفاظ على تخطيطات الشرائح، والرسوم المتحركة، والأشكال، والمخططات، وعناصر التصميم الأخرى أثناء تحويل PPT إلى PPTX.

**هل يمكنني تحويل صيغ أخرى مثل PDF أو HTML من ملفات PPT؟**

نعم، يدعم Aspose.Slides تحويل ملفات PPT إلى صيغ متعددة بما في ذلك PDF وXPS وHTML وODP وصيغ الصور مثل PNG وJPEG.

**هل يمكن تحويل PPT إلى PPTX دون تثبيت Microsoft PowerPoint؟**

نعم، Aspose.Slides هو API مستقل ولا يتطلب وجود Microsoft PowerPoint أو أي برنامج طرف ثالث لإجراء التحويل.

**هل هناك أداة عبر الإنترنت متاحة لتحويل PPT إلى PPTX؟**

نعم، يمكنك استخدام تطبيق الويب المجاني [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) لإجراء التحويل مباشرةً في المتصفح دون كتابة أي كود.