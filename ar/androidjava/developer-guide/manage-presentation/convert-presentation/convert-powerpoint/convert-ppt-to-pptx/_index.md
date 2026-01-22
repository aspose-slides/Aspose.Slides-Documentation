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
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "تحويل عروض PPT القديمة إلى PPTX الحديثة بسرعة في Java باستخدام Aspose.Slides لنظام Android — برنامج تعليمي واضح، عينات شفرة مجانية، بدون الاعتماد على Microsoft Office."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPT إلى تنسيق PPTX باستخدام Java ومع تطبيق التحويل عبر الإنترنت من PPT إلى PPTX. الموضوع التالي مغطى.

- تحويل PPT إلى PPTX باستخدام Java

## **تحويل PPT إلى PPTX على Android**

للحصول على شفرة عينة Java لتحويل PPT إلى PPTX، يرجى الاطلاع على القسم أدناه أي [Convert PPT to PPTX](#convert-ppt-to-pptx). تقوم الشفرة بتحميل ملف PPT وحفظه بتنسيق PPTX. عن طريق تحديد تنسيقات حفظ مختلفة، يمكنك أيضًا حفظ ملف PPT إلى العديد من الصيغ الأخرى مثل PDF، XPS، ODP، HTML، إلخ كما تم مناقشته في هذه المقالات.

- [تحويل PPT إلى PDF على Android](/slides/ar/androidjava/convert-powerpoint-to-pdf/)
- [تحويل PPT إلى XPS على Android](/slides/ar/androidjava/convert-powerpoint-to-xps/)
- [تحويل PPT إلى HTML على Android](/slides/ar/androidjava/convert-powerpoint-to-html/)
- [تحويل PPT إلى ODP على Android](/slides/ar/androidjava/save-presentation/)
- [تحويل PPT إلى PNG على Android](/slides/ar/androidjava/convert-powerpoint-to-png/)

## **حول تحويل PPT إلى PPTX**

تحويل صيغة PPT القديمة إلى PPTX باستخدام Aspose.Slides API. إذا كنت بحاجة إلى تحويل آلاف عروض PPT إلى صيغة PPTX، فإن الحل الأفضل هو القيام بذلك برمجياً. باستخدام Aspose.Slides API من الممكن القيام بذلك في بضع أسطر من الشيفرة فقط. تدعم API توافقاً كاملاً لتحويل عرض PPT إلى PPTX ويمكنك من:

- تحويل الهياكل المعقدة للماسترات، التخطيطات والشرائح.
- تحويل عرض يحتوي على مخططات.
- تحويل عرض يحتوي على أشكال مجموعة، أشكال تلقائية (مثل المستطيلات والبيضاوي)، أشكال ذات هندسة مخصصة.
- تحويل عرض يحتوي على أنماط تعبئة بالنقوش والصور للأشكال التلقائية.
- تحويل عرض يحتوي على عناصر نائبة، إطارات نصية وحوامل نصية.

{{% alert color="primary" %}} 

ألق نظرة على تطبيق [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

هذا التطبيق مبني على [**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/)، لذا يمكنك رؤية مثال حي لقدرات التحويل الأساسية من PPT إلى PPTX. تحويل Aspose.Slides هو تطبيق ويب، يسمح بإسقاط ملف عرض بصيغة PPT وتحميله محولاً إلى PPTX.

ابحث عن أمثلة حية أخرى لـ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) examples.
{{% /alert %}} 

## **تحويل PPT إلى PPTX**

تسهل الآن Aspose.Slides لنظام Android عبر Java للمطورين الوصول إلى PPT باستخدام مثال الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وتحويله إلى الصيغة المناسبة [PPTX](https://docs.fileformat.com/presentation/pptx/). حالياً، يدعم التحويل الجزئي من [PPT ](https://docs.fileformat.com/presentation/ppt/) إلى PPTX.

توفر Aspose.Slides لنظام Android عبر Java فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) التي تمثل ملف عرض **PPTX**. يمكن الآن لفئة Presentation أيضًا الوصول إلى **PPT** من خلال Presentation عند إنشاء الكائن. المثال التالي يوضح كيفية تحويل عرض PPT إلى عرض PPTX Presentation.
```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("Aspose.ppt");
try {
// حفظ عرض PPTX بالتنسيق PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**الشكل : عرض PPT المصدر**|

الكود أعلاه ينتج العرض التالي بعد التحويل:

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**الشكل: عرض PPTX المُنشأ بعد التحويل**|

## **الأسئلة المتكررة**

**ما الفرق بين صيغتي PPT و PPTX؟**

PPT هو صيغة الملف الثنائي القديمة المستخدمة من قبل Microsoft PowerPoint، بينما PPTX هي الصيغة القائمة على XML التي تم تقديمها مع Microsoft Office 2007. توفر ملفات PPTX أداءً أفضل، حجم ملف أصغر، وتحسن في استعادة البيانات.

**هل يدعم Aspose.Slides التحويل الجماعي لعدة ملفات PPT إلى PPTX؟**

نعم، يمكنك استخدام Aspose.Slides ضمن حلقة لتحويل عدة ملفات PPT إلى PPTX برمجياً، مما يجعلها مناسبة لسيناريوهات التحويل الجماعي.

**هل سيتم الحفاظ على المحتوى والتنسيق بعد التحويل؟**

تحافظ Aspose.Slides على دقة عالية عند تحويل العروض التقديمية. يتم الحفاظ على تخطيطات الشرائح، الرسوم المتحركة، الأشكال، المخططات، وغيرها من عناصر التصميم أثناء تحويل PPT إلى PPTX.

**هل يمكنني تحويل صيغ أخرى مثل PDF أو HTML من ملفات PPT؟**

نعم، يدعم Aspose.Slides تحويل ملفات PPT إلى [صيغ متعددة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/)، بما في ذلك PDF، XPS، HTML، ODP، وصيغ الصور مثل PNG و JPEG.

**هل من الممكن تحويل PPT إلى PPTX بدون تثبيت Microsoft PowerPoint؟**

نعم، Aspose.Slides هي API مستقلة ولا تتطلب تثبيت Microsoft PowerPoint أو أي برنامج طرف ثالث لإجراء التحويل.

**هل توجد أداة عبر الإنترنت متاحة لتحويل PPT إلى PPTX؟**

نعم، يمكنك استخدام تطبيق الويب المجاني [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) لإجراء التحويل مباشرةً في المتصفح دون كتابة أي شفرة.