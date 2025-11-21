---
title: "تحويل PPT إلى PPTX في JavaScript"
linktitle: "تحويل PPT إلى PPTX"
type: docs
weight: 20
url: /ar/nodejs-java/convert-ppt-to-pptx/
keywords: "تحويل PPT إلى PPTX باستخدام Java، PowerPoint PPT إلى PPTX في JavaScript"
description: "تحويل PowerPoint PPT إلى PPTX في JavaScript."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض تقديمي PowerPoint بتنسيق PPT إلى تنسيق PPTX باستخدام JavaScript ومع تطبيق التحويل عبر الإنترنت من PPT إلى PPTX. الموضوع التالي مغطى.

- تحويل PPT إلى PPTX في JavaScript

## **Java تحويل PPT إلى PPTX**

للحصول على عينة كود JavaScript لتحويل PPT إلى PPTX، يرجى الاطلاع على القسم أدناه أي [Convert PPT to PPTX](#convert-ppt-to-pptx). يقوم الكود بتحميل ملف PPT وحفظه بتنسيق PPTX. عن طريق تحديد صيغ حفظ مختلفة، يمكنك أيضًا حفظ ملف PPT إلى صيغ أخرى مثل PDF و XPS و ODP و HTML وغيرها كما هو موضح في هذه المقالات.

- [Java تحويل PPT إلى PDF](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-pdf/)
- [Java تحويل PPT إلى XPS](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-xps/)
- [Java تحويل PPT إلى HTML](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-html/)
- [Java تحويل PPT إلى ODP](https://docs.aspose.com/slides/nodejs-java/save-presentation/)
- [Java تحويل PPT إلى صورة](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-png/)

## **حول تحويل PPT إلى PPTX**
قم بتحويل تنسيق PPT القديم إلى PPTX باستخدام Aspose.Slides API. إذا كنت بحاجة إلى تحويل آلاف العروض التقديمية من PPT إلى تنسيق PPTX، فإن أفضل حل هو القيام بذلك برمجياً. مع Aspose.Slides API يمكن تحقيق ذلك ببضع أسطر من الشيفرة فقط. يدعم الـ API توافقًا كاملًا لتحويل عرض PPT إلى PPTX ويمكنه:

- تحويل البُنى المعقدة للماسترز والتخطيطات والشرائح.
- تحويل العروض التي تحتوي على مخططات.
- تحويل العروض التي تحتوي على أشكال مجموعات، أشكال تلقائية (مثل المستطيلات والبيضات)، أشكال ذات هندسة مخصصة.
- تحويل العروض التي تحتوي على أنماط تعبئة النصوص والصور للأشكال التلقائية.
- تحويل العروض التي تحتوي على نُسخ مؤقتة، إطارات نصية وحاملات نص.

{{% alert color="primary" %}} 

ألقِ نظرة على تطبيق [**Aspose.Slides PPT إلى PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

تم بناء هذا التطبيق استنادًا إلى [**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/)، لذا يمكنك مشاهدة مثال حي لقدرات التحويل الأساسية من PPT إلى PPTX. Aspose.Slides Conversion هو تطبيق ويب يتيح سحب ملف عرض بصيغة PPT وتحميله بعد تحويله إلى PPTX.

اعثر على أمثلة حية أخرى لـ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .
{{% /alert %}} 

## **تحويل PPT إلى PPTX**
يسهل Aspose.Slides for Node.js via Java الآن على المطورين الوصول إلى PPT باستخدام فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) وتحويله إلى صيغة [PPTX](https://docs.fileformat.com/presentation/pptx/) المقابلة. حاليًا، يدعم التحويل الجزئي من [PPT](https://docs.fileformat.com/presentation/ppt/) إلى PPTX. لمزيد من التفاصيل حول الميزات المدعومة وغير المدعومة في تحويل PPT إلى PPTX، يرجى الرجوع إلى وثائق [الرابط](/slides/ar/nodejs-java/ppt-to-pptx-conversion/).

يوفر Aspose.Slides for Node.js via Java فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) التي تمثل ملف عرض **PPTX**. يمكن الآن أيضًا الوصول إلى **PPT** عبر Presentation عند إنشاء الكائن. يوضح المثال التالي كيفية تحويل عرض PPT إلى عرض PPTX.
```javascript
// إنشاء كائن Presentation يمثل ملف PPTX
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // حفظ عرض PPTX إلى تنسيق PPTX
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
|**الشكل: عرض PPTX الناتج بعد التحويل**|

## **الأسئلة المتكررة**

**ما الفرق بين صيغتي PPT و PPTX؟**

PPT هو تنسيق ملف ثنائي قديم يستخدمه Microsoft PowerPoint، بينما PPTX هو التنسيق القائم على XML الذي تم تقديمه مع Microsoft Office 2007. ملفات PPTX تقدم أداءً أفضل، حجم ملف أصغر، وتحسيناً في استعادة البيانات.

**هل يدعم Aspose.Slides التحويل الجماعي لعدة ملفات PPT إلى PPTX؟**

نعم، يمكنك استخدام Aspose.Slides داخل حلقة لتحويل عدة ملفات PPT إلى PPTX برمجيًا، مما يجعلها مناسبة لسيناريوهات التحويل الدفعي.

**هل سيتم الحفاظ على المحتوى والتنسيق بعد التحويل؟**

يحافظ Aspose.Slides على دقة عالية عند تحويل العروض. يتم الحفاظ على تخطيطات الشرائح، الرسوم المتحركة، الأشكال، المخططات، وعناصر التصميم الأخرى أثناء التحويل من PPT إلى PPTX.

**هل يمكنني تحويل صيغ أخرى مثل PDF أو HTML من ملفات PPT؟**

نعم، يدعم Aspose.Slides تحويل ملفات PPT إلى صيغ متعددة، بما في ذلك PDF و XPS و HTML و ODP وصيغ الصور مثل PNG و JPEG.

**هل يمكن تحويل PPT إلى PPTX دون الحاجة إلى تثبيت Microsoft PowerPoint؟**

نعم، Aspose.Slides هو API مستقل ولا يتطلب تثبيت Microsoft PowerPoint أو أي برنامج طرف ثالث لأداء التحويل.

**هل هناك أداة عبر الإنترنت متاحة لتحويل PPT إلى PPTX؟**

نعم، يمكنك استخدام تطبيق الويب المجاني [Aspose.Slides PPT إلى PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) لإجراء التحويل مباشرة في المتصفح دون كتابة أي شيفرة.