---
title: تحويل PPT إلى PPTX على Android
linktitle: PPT إلى PPTX
type: docs
weight: 20
url: /ar/androidjava/convert-ppt-to-pptx/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- PPT إلى PPTX
- حفظ PPT كـ PPTX
- تصدير PPT إلى PPTX
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تحويل عروض PPT القديمة إلى PPTX الحديثة بسرعة باستخدام Java مع Aspose.Slides لأندرويد — دليل واضح، عينات شيفرة مجانية، دون اعتماد على Microsoft Office."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بصيغة PPT إلى صيغة PPTX باستخدام Java ومع تطبيق تحويل PPT إلى PPTX عبر الإنترنت. الموضوع التالي مغطى.

- تحويل PPT إلى PPTX باستخدام Java

## **تحويل PPT إلى PPTX على Android**

للحصول على عينة شفرة Java لتحويل PPT إلى PPTX، يرجى الاطلاع على القسم أدناه أي [Convert PPT to PPTX](#convert-ppt-to-pptx). تقوم بتحميل ملف PPT وحفظه بصيغة PPTX. عن طريق تحديد صِيَغ حفظ مختلفة، يمكنك أيضًا حفظ ملف PPT إلى العديد من الصيغ الأخرى مثل PDF و XPS و ODP و HTML إلخ كما نوقش في هذه المقالات.

- [Java تحويل PPT إلى PDF](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java تحويل PPT إلى XPS](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java تحويل PPT إلى HTML](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java تحويل PPT إلى ODP](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java تحويل PPT إلى صورة](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **حول تحويل PPT إلى PPTX**

تحويل صيغة PPT القديمة إلى PPTX باستخدام Aspose.Slides API. إذا كنت بحاجة إلى تحويل الآلاف من عروض PPT إلى صيغة PPTX، فإن أفضل حل هو القيام بذلك برمجيًا. باستخدام Aspose.Slides API يمكن القيام بذلك ببضع أسطر من الشيفرة فقط. يدعم API توافقًا كاملًا لتحويل عرض PPT إلى PPTX ويمكنه:

- تحويل البُنى المعقدة للماستر، التخطيطات والشرائح.
- تحويل العرض مع المخططات.
- تحويل العرض مع أشكال المجموعة، الأشكال التلقائية (مثل المستطيلات والبيضات)، الأشكال ذات الهندسة المخصصة.
- تحويل عرض يحتوي على أنماط ملء القوام والصور للأشكال التلقائية.
- تحويل عرض يحتوي على نِسَب الأماكن، إطارات النص وحوامل النص.

{{% alert color="primary" %}} 

ألق نظرة على تطبيق [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

تم بناء هذا التطبيق استنادًا إلى [**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/)، لذا يمكنك رؤية مثال حي على قدرات التحويل الأساسي من PPT إلى PPTX. Aspose.Slides Conversion هو تطبيق ويب يتيح سحب ملف عرض بصيغة PPT وتحميله بعد تحويله إلى PPTX.

اعثر على أمثلة حية أخرى لـ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

## **تحويل PPT إلى PPTX**

يُسهل Aspose.Slides لـ Android عبر Java الآن للمطورين الوصول إلى PPT باستخدام فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وتحويلها إلى الصيغة المناسبة [PPTX](https://docs.fileformat.com/presentation/pptx/). حالياً، يدعم التحويل الجزئي من [PPT ](https://docs.fileformat.com/presentation/ppt/)إلى PPTX. لمزيد من التفاصيل حول الميزات المدعومة وغير المدعومة في تحويل PPT إلى PPTX، يرجى الانتقال إلى توثيق [link](/slides/ar/androidjava/ppt-to-pptx-conversion/).

يقدم Aspose.Slides لـ Android عبر Java فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) التي تمثل ملف عرض **PPTX**. يمكن الآن لفئة Presentation أيضًا الوصول إلى **PPT** عبر Presentation عند إنشاء الكائن. تُظهر الأمثلة التالية كيفية تحويل عرض PPT إلى عرض PPTX.

```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("Aspose.ppt");
try {
// حفظ عرض PPTX بصيغة PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**الشكل : عرض PPT الأصلي**|

مقتطف الشيفرة أعلاه يولد عرض PPTX التالي بعد التحويل

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**الشكل: عرض PPTX المُنتج بعد التحويل**|

## **الأسئلة المتكررة**

**ما هو الفرق بين صيغتي PPT و PPTX؟**

PPT هو صيغة الملف الثنائي القديمة التي يستخدمها Microsoft PowerPoint، بينما PPTX هي الصيغة المبنية على XML والتي تم تقديمها مع Microsoft Office 2007. توفر ملفات PPTX أداءً أفضل، حجم ملف أصغر، وتحسين في استعادة البيانات.

**هل يدعم Aspose.Slides تحويل دفعات متعددة من ملفات PPT إلى PPTX؟**

نعم، يمكنك استخدام Aspose.Slides داخل حلقة لتحويل ملفات PPT متعددة إلى PPTX برمجيًا، مما يجعله مناسبًا لسيناريوهات التحويل الدفعي.

**هل سيتم الحفاظ على المحتوى والتنسيق بعد التحويل؟**

يحافظ Aspose.Slides على دقة عالية عند تحويل العروض. تُحافظ تخطيطات الشرائح، الرسوم المتحركة، الأشكال، المخططات، وعناصر التصميم الأخرى خلال عملية التحويل من PPT إلى PPTX.

**هل يمكنني تحويل صيغ أخرى مثل PDF أو HTML من ملفات PPT؟**

نعم، يدعم Aspose.Slides تحويل ملفات PPT إلى [عدة صيغ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/)، بما في ذلك PDF و XPS و HTML و ODP وصور مثل PNG و JPEG.

**هل من الممكن تحويل PPT إلى PPTX دون تثبيت Microsoft PowerPoint؟**

نعم، Aspose.Slides هو API مستقل ولا يتطلب Microsoft PowerPoint أو أي برنامج طرف ثالث لأداء التحويل.

**هل هناك أداة عبر الإنترنت متاحة لتحويل PPT إلى PPTX؟**

نعم، يمكنك استخدام تطبيق الويب المجاني [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) لإجراء التحويل مباشرةً في المتصفح دون كتابة أي رمز.