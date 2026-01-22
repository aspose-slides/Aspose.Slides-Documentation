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
description: "تحويل العروض التقديمية القديمة بصيغة PPT إلى صيغة PPTX الحديثة بسرعة في Java باستخدام Aspose.Slides للأندرويد — دليل واضح، عينات شفرة مجانية، بدون اعتماد على Microsoft Office."
---

## **نظرة عامة**

توضح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPT إلى تنسيق PPTX باستخدام Java ومع تطبيق التحويل عبر الإنترنت من PPT إلى PPTX. الموضوع التالي مغطى.

- تحويل PPT إلى PPTX باستخدام Java

## **تحويل PPT إلى PPTX على Android**

للحصول على مثال كود Java لتحويل PPT إلى PPTX، يرجى مراجعة القسم أدناه أي [Convert PPT to PPTX](#convert-ppt-to-pptx). يقوم بتحميل ملف PPT وحفظه بتنسيق PPTX. من خلال تحديد تنسيقات حفظ مختلفة، يمكنك أيضًا حفظ ملف PPT إلى العديد من التنسيقات الأخرى مثل PDF و XPS و ODP و HTML وغيرها كما نوقشت في هذه المقالات.

- [تحويل PPT إلى PDF على Android](/slides/ar/androidjava/convert-powerpoint-to-pdf/)
- [تحويل PPT إلى XPS على Android](/slides/ar/androidjava/convert-powerpoint-to-xps/)
- [تحويل PPT إلى HTML على Android](/slides/ar/androidjava/convert-powerpoint-to-html/)
- [تحويل PPT إلى ODP على Android](/slides/ar/androidjava/save-presentation/)
- [تحويل PPT إلى PNG على Android](/slides/ar/androidjava/convert-powerpoint-to-png/)

## **حول تحويل PPT إلى PPTX**

قم بتحويل تنسيق PPT القديم إلى PPTX باستخدام Aspose.Slides API. إذا كنت بحاجة إلى تحويل آلاف عروض PPT إلى تنسيق PPTX، فإن أفضل حل هو القيام بذلك برمجيًا. باستخدام Aspose.Slides API يمكن القيام بذلك في بضع أسطر من الشيفرة فقط. يدعم API توافقًا كاملاً لتحويل عرض PPT إلى PPTX ومن الممكن:

- تحويل الهياكل المعقدة للماسترات، التخطيطات والشرائح.
- تحويل عرض يحتوي على مخططات.
- تحويل عرض يحتوي على أشكال مجموعة، أشكال تلقائية (مثل المستطيلات والبيضاوي)، أشكال ذات هندسة مخصصة.
- تحويل عرض يحتوي على أنماط ملء للصور والملمس للأشكال التلقائية.
- تحويل عرض يحتوي على مواضع العنصر النائب، إطارات النص وحاملات النص.

{{% alert color="primary" %}} 

ألقِ نظرة على تطبيق [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

تم بناء هذا التطبيق استنادًا إلى [**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/)، لذا يمكنك رؤية مثال حي لقدرات تحويل PPT إلى PPTX الأساسية. Aspose.Slides Conversion هو تطبيق ويب يسمح بإسقاط ملف عرض بصيغة PPT وتحميله بعد تحويله إلى PPTX.

اعثر على أمثلة حية أخرى لـ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}} 

## **تحويل PPT إلى PPTX**

Aspose.Slides for Android عبر Java يسهل الآن على المطورين الوصول إلى PPT باستخدام فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وتحويلها إلى تنسيق [PPTX](https://docs.fileformat.com/presentation/pptx/) المقابل. حاليًا، يدعم تحويلًا جزئيًا من [PPT ](https://docs.fileformat.com/presentation/ppt/) إلى PPTX. لمزيد من التفاصيل حول الميزات المدعومة وغير المدعومة في تحويل PPT إلى PPTX، يرجى الانتقال إلى هذه الوثائق [link](/slides/ar/androidjava/ppt-to-pptx-conversion/).

Aspose.Slides for Android عبر Java يوفر فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) التي تمثل ملف عرض **PPTX**. يمكن الآن أيضًا الوصول إلى **PPT** عبر Presentation عند إنشاء الكائن. المثال التالي يوضح كيفية تحويل عرض PPT إلى عرض PPTX.

```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("Aspose.ppt");
try {
// حفظ عرض PPTX بتنسيق PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**الشكل : عرض PPT المصدر**|

الشفرة أعلاه تولدت العرض PPTX التالي بعد التحويل

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**الشكل: عرض PPTX المُنشأ بعد التحويل**|

## **الأسئلة الشائعة**

**ما هو الفرق بين صيغتي PPT و PPTX؟**

‏PPT هو تنسيق الملف الثنائي الأقدم المستخدم بواسطة Microsoft PowerPoint، بينما PPTX هو التنسيق القائم على XML الذي تم تقديمه مع Microsoft Office 2007. توفر ملفات PPTX أداءً أفضل، وحجم ملف أصغر، وتحسينًا في استعادة البيانات.

**هل يدعم Aspose.Slides تحويل دفعة متعددة من ملفات PPT إلى PPTX؟**

‏نعم، يمكنك استخدام Aspose.Slides في حلقة لتحويل ملفات PPT متعددة إلى PPTX برمجيًا، مما يجعله مناسبًا لسيناريوهات التحويل الدفعي.

**هل سيتم الحفاظ على المحتوى والتنسيق بعد التحويل؟**

‏يحافظ Aspose.Slides على دقة عالية في تحويل العروض. يتم الحفاظ على تخطيطات الشرائح، والرسوم المتحركة، والأشكال، والمخططات، وعناصر التصميم الأخرى أثناء تحويل PPT إلى PPTX.

**هل يمكنني تحويل صيغ أخرى مثل PDF أو HTML من ملفات PPT؟**

‏نعم، يدعم Aspose.Slides تحويل ملفات PPT إلى [multiple formats](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/)، بما في ذلك PDF و XPS و HTML و ODP، وصيغ الصور مثل PNG و JPEG.

**هل من الممكن تحويل PPT إلى PPTX دون تثبيت Microsoft PowerPoint؟**

‏نعم، Aspose.Slides هو API مستقل ولا يتطلب Microsoft PowerPoint أو أي برنامج طرف ثالث لأداء التحويل.

**هل هناك أداة عبر الإنترنت متاحة لتحويل PPT إلى PPTX؟**

‏نعم، يمكنك استخدم تطبيق الويب المجاني [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) لإجراء التحويل مباشرة في المتصفح دون كتابة أي كود.