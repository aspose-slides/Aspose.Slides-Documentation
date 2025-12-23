---
title: "تحويل PPT إلى PPTX في PHP"
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
description: "تحويل عروض PPT القديمة إلى PPTX الحديثة بسرعة باستخدام Aspose.Slides للـ PHP عبر Java — دليل واضح، عينات كود مجانية، دون اعتماد على Microsoft Office."
---

## **نظرة عامة**

يوضح هذا المقال كيفية تحويل عرض تقديمي PowerPoint بصيغة PPT إلى صيغة PPTX باستخدام PHP ومع تطبيق التحويل عبر الإنترنت من PPT إلى PPTX. المواضيع التالية مغطاة.

- تحويل PPT إلى PPTX

## **تحويل PPT إلى PPTX باستخدام PHP**

للحصول على كود مثال Java لتحويل PPT إلى PPTX، يرجى الاطلاع على القسم أدناه أي [تحويل PPT إلى PPTX](#convert-ppt-to-pptx). يقوم فقط بتحميل ملف PPT وحفظه بصيغة PPTX. من خلال تحديد صيغ حفظ مختلفة، يمكنك أيضًا حفظ ملف PPT إلى صيغ أخرى كثيرة مثل PDF وXPS وODP وHTML وغيرها كما نوقش في هذه المقالات.

- [Java تحويل PPT إلى PDF](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [Java تحويل PPT إلى XPS](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [Java تحويل PPT إلى HTML](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [Java تحويل PPT إلى ODP](https://docs.aspose.com/slides/php-java/save-presentation/)
- [Java تحويل PPT إلى Image](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **حول تحويل PPT إلى PPTX**

تحويل الصيغة القديمة PPT إلى PPTX باستخدام Aspose.Slides API. إذا كنت تحتاج إلى تحويل آلاف العروض التقديمية من PPT إلى صيغة PPTX، فإن أفضل حل هو القيام بذلك برمجياً. مع Aspose.Slides API يمكن القيام بذلك في بضع أسطر من الكود فقط. يدعم API التوافق الكامل لتحويل عروض PPT إلى PPTX ويمكنه:

- تحويل هياكل معقدة للماسترس، التخطيطات والشرائح.
- تحويل العرض التقديمي مع المخططات.
- تحويل العرض مع الأشكال المجمعة، الأشكال التلقائية (مثل المستطيلات والبيضاويّات)، الأشكال ذات الهندسة المخصصة.
- تحويل العرض الذي يحتوي على أنماط تعبئة من القوام والصور للأشكال التلقائية.
- تحويل العرض مع العناصر النائبة، إطارات النص وحاملات النص.

{{% alert color="primary" %}} 

ألق نظرة على [**Aspose.Slides PPT إلى PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) التطبيق:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

تم بناء هذا التطبيق بناءً على [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/)، لذا يمكنك رؤية مثال حي لقدرات تحويل PPT إلى PPTX الأساسية. Aspose.Slides Conversion هو تطبيق ويب، يتيح إلقاء ملف عرض بصيغة PPT وتحميله بعد تحويله إلى PPTX.

ابحث عن أمثلة حية أخرى لـ[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}} 

## **تحويل PPT إلى PPTX**

Aspose.Slides for PHP via Java الآن يسهل على المطورين الوصول إلى PPT باستخدام فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وتحويلها إلى صيغة [PPTX](https://docs.fileformat.com/presentation/pptx/) المقابلة. حالياً، يدعم التحويل الجزئي من [PPT ](https://docs.fileformat.com/presentation/ppt/) إلى PPTX. لمزيد من التفاصيل حول الميزات المدعومة وغير المدعومة في تحويل PPT إلى PPTX، يرجى الانتقال إلى هذه الوثائق [الرابط](/slides/ar/php-java/ppt-to-pptx-conversion/).

Aspose.Slides for PHP via Java يقدم فئة [Presentation] التي تمثل ملف عرض **PPTX**. يمكن لفئة Presentation الآن أيضًا الوصول إلى **PPT** من خلال Presentation عند إنشاء الكائن. يُظهر المثال التالي كيفية تحويل عرض PPT إلى عرض PPTX.
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
|**الشكل: عرض PPT المصدر**|

الكود أعلاه يولد عرض PPTX التالي بعد التحويل

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**الشكل: عرض PPTX تم إنشاؤه بعد التحويل**|

## **الأسئلة الشائعة**

**ما هو الفرق بين صيغتي PPT و PPTX؟**

PPT هو تنسيق الملف الثنائي القديم الذي تستخدمه Microsoft PowerPoint، بينما PPTX هو التنسيق القائم على XML الذي تم تقديمه مع Microsoft Office 2007. ملفات PPTX توفر أداءً أفضل، حجم ملف أصغر، وتحسينًا في استعادة البيانات.

**هل يدعم Aspose.Slides تحويل دفعة متعددة من ملفات PPT إلى PPTX؟**

نعم، يمكنك استخدام Aspose.Slides داخل حلقة لتحويل عدة ملفات PPT إلى PPTX برمجياً، مما يجعله مناسبًا لسيناريوهات التحويل الدفعي.

**هل سيتم الحفاظ على المحتوى والتنسيق بعد التحويل؟**

يحافظ Aspose.Slides على دقة عالية أثناء تحويل العروض. يتم الحفاظ على تخطيطات الشرائح، الرسوم المتحركة، الأشكال، المخططات، وغيرها من عناصر التصميم أثناء التحويل من PPT إلى PPTX.

**هل يمكنني تحويل صيغ أخرى مثل PDF أو HTML من ملفات PPT؟**

نعم، يدعم Aspose.Slides تحويل ملفات PPT إلى [صيغ متعددة](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/)، بما في ذلك PDF وXPS وHTML وODP وصيغ الصور مثل PNG وJPEG.

**هل يمكن تحويل PPT إلى PPTX بدون تثبيت Microsoft PowerPoint؟**

نعم، Aspose.Slides هو API مستقل ولا يتطلب وجود Microsoft PowerPoint أو أي برنامج خارجي لإجراء التحويل.

**هل هناك أداة عبر الإنترنت متوفرة لتحويل PPT إلى PPTX؟**

نعم، يمكنك استخدام تطبيق الويب المجاني [Aspose.Slides PPT إلى PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) لإجراء التحويل مباشرةً في المتصفح دون كتابة أي كود.