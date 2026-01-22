---
title: "تحويل PPT إلى PPTX باستخدام PHP"
linktitle: "PPT إلى PPTX"
type: docs
weight: 20
url: /ar/php-java/convert-ppt-to-pptx/
keywords:
- "تحويل PowerPoint"
- "تحويل العرض التقديمي"
- "تحويل الشريحة"
- "تحويل PPT"
- "PPT إلى PPTX"
- "حفظ PPT كـ PPTX"
- "تصدير PPT إلى PPTX"
- "PowerPoint"
- "العرض التقديمي"
- "PHP"
- "Aspose.Slides"
description: "تحويل عروض PPT القديمة إلى PPTX الحديثة بسرعة باستخدام Aspose.Slides لـ PHP عبر Java — دليل واضح، عينات شيفرة مجانية، دون اعتماد على Microsoft Office."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPT إلى تنسيق PPTX باستخدام PHP ومع تطبيق تحويل PPT إلى PPTX عبر الإنترنت. تم تغطية الموضوع التالي.

- تحويل PPT إلى PPTX

## **تحويل PPT إلى PPTX باستخدام PHP**

للحصول على عينة كود Java لتحويل PPT إلى PPTX، يرجى الاطلاع على القسم أدناه أي [Convert PPT to PPTX](#convert-ppt-to-pptx). يقوم بتحميل ملف PPT وحفظه بتنسيق PPTX. من خلال تحديد صيغ حفظ مختلفة، يمكنك أيضًا حفظ ملف PPT في العديد من الصيغ الأخرى مثل PDF و XPS و ODP و HTML وغيرها كما نوقش في هذه المقالات.

- [تحويل PPT إلى PDF باستخدام PHP](/slides/ar/php-java/convert-powerpoint-to-pdf/)
- [تحويل PPT إلى XPS باستخدام PHP](/slides/ar/php-java/convert-powerpoint-to-xps/)
- [تحويل PPT إلى HTML باستخدام PHP](/slides/ar/php-java/convert-powerpoint-to-html/)
- [تحويل PPT إلى ODP باستخدام PHP](/slides/ar/php-java/save-presentation/)
- [تحويل PPT إلى PNG باستخدام PHP](/slides/ar/php-java/convert-powerpoint-to-png/)

## **حول تحويل PPT إلى PPTX**

تحويل تنسيق PPT القديم إلى PPTX باستخدام Aspose.Slides API. إذا كنت بحاجة إلى تحويل آلاف عروض PPT إلى تنسيق PPTX، فإن أفضل حل هو القيام بذلك programmatically. باستخدام Aspose.Slides API يمكن القيام بذلك ببضع سطور من الشيفرة فقط. يدعم API التوافق الكامل لتحويل عرض PPT إلى PPTX ومن الممكن:

- تحويل هياكل معقدة من القوالب، التخطيطات والشرائح.
- تحويل عرض مع المخططات.
- تحويل عرض يحتوي على أشكال مجموعة، الأشكال التلقائية (مثل المستطيلات والبيضات)، وأشكال ذات هندسة مخصصة.
- تحويل عرض يحتوي على أنسجة وأنماط تعبئة الصور للأشكال التلقائية.
- تحويل عرض يحتوي على عناصر نائبة، إطارات نصية وحاملات نص.

{{% alert color="primary" %}} 

إلق نظرة على تطبيق [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

تم بناء هذا التطبيق استنادًا إلى [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/)، لذا يمكنك رؤية مثال حي لإمكانيات تحويل PPT إلى PPTX الأساسية. Aspose.Slides Conversion هو تطبيق ويب يتيح سحب ملف عرض بصيغة PPT وتحميله بعد تحويله إلى PPTX.

ابحث عن أمثلة أخرى حية لـ[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}} 

## **تحويل PPT إلى PPTX**

تمكن Aspose.Slides for PHP عبر Java الآن المطورين من الوصول إلى PPT باستخدام مثيل الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وتحويله إلى تنسيق [PPTX](https://docs.fileformat.com/presentation/pptx/) المناسب. حاليًا، يدعم التحويل الجزئي من [PPT ](https://docs.fileformat.com/presentation/ppt/) إلى PPTX. لمزيد من التفاصيل حول الميزات المدعومة وغير المدعومة في تحويل PPT إلى PPTX، يرجى الانتقال إلى وثيقة [link](/slides/ar/php-java/ppt-to-pptx-conversion/).

يقدم Aspose.Slides for PHP عبر Java فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) التي تمثل ملف عرض **PPTX**. يمكن الآن لفئة Presentation أيضًا الوصول إلى **PPT** عبر Presentation عند إنشاء الكائن. يوضح المثال التالي كيفية تحويل عرض PPT إلى عرض PPTX.

```php
  # إنشاء كائن Presentation يمثل ملف PPTX
  $pres = new Presentation("Aspose.ppt");
  try {
    # حفظ عرض PPTX بصيغة PPTX
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**الشكل : عرض PPT المصدر**|

انتج مقطع الشيفرة أعلاه عرض PPTX التالي بعد التحويل

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**الشكل: عرض PPTX الناتج بعد التحويل**|

## **الأسئلة المتكررة**

**ما الفرق بين تنسيقي PPT و PPTX؟**

PPT هو تنسيق ملف ثنائي قديم يستخدمه Microsoft PowerPoint، بينما PPTX هو التنسيق القائم على XML الذي تم تقديمه مع Microsoft Office 2007. توفر ملفات PPTX أداءً أفضل، حجم ملف أصغر، وتحسين في استعادة البيانات.

**هل يدعم Aspose.Slides التحويل الدفعي لملفات PPT متعددة إلى PPTX؟**

نعم، يمكنك استخدام Aspose.Slides داخل حلقة لتحويل عدة ملفات PPT إلى PPTX برمجيًا، مما يجعله مناسبًا لسيناريوهات التحويل الدفعي.

**هل سيتم الحفاظ على المحتوى والتنسيق بعد التحويل؟**

يحافظ Aspose.Slides على دقة عالية أثناء تحويل العروض. تبقى تخطيطات الشرائح، الرسوم المتحركة، الأشكال، المخططات، وغيرها من عناصر التصميم محفوظة خلال تحويل PPT إلى PPTX.

**هل يمكنني تحويل صيغ أخرى مثل PDF أو HTML من ملفات PPT؟**

نعم، يدعم Aspose.Slides تحويل ملفات PPT إلى [multiple formats](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/)، بما في ذلك PDF و XPS و HTML و ODP، وأيضًا صيغ الصور مثل PNG و JPEG.

**هل يمكن تحويل PPT إلى PPTX دون تثبيت Microsoft PowerPoint؟**

نعم، Aspose.Slides هو واجهة برمجة تطبيقات مستقلة ولا تحتاج إلى Microsoft PowerPoint أو أي برنامج طرف ثالث لإجراء التحويل.

**هل هناك أداة عبر الإنترنت متاحة لتحويل PPT إلى PPTX؟**

نعم، يمكنك استخدام أداة الويب المجانية [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) لإجراء التحويل مباشرةً في المتصفح دون كتابة أي شفرة.