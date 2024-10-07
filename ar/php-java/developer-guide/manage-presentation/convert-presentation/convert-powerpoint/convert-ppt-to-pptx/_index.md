---
title: تحويل PPT إلى PPTX
linktitle: تحويل PPT إلى PPTX
type: docs
weight: 20
url: /php-java/convert-ppt-to-pptx/
keywords: "PHP تحويل PPT إلى PPTX، PowerPoint PPT إلى PPTX"
description: "تحويل PowerPoint PPT إلى PPTX."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPT إلى تنسيق PPTX باستخدام PHP ومع تطبيق تحويل PPT إلى PPTX عبر الإنترنت. الموضوعات التالية مغطاة.

- تحويل PPT إلى PPTX

## **تحويل PPT إلى PPTX باستخدام Java**

للحصول على كود عينة Java لتحويل PPT إلى PPTX، يرجى مراجعة القسم أدناه أي [تحويل PPT إلى PPTX](#convert-ppt-to-pptx). يقوم بتحميل ملف PPT وحفظه بتنسيق PPTX. من خلال تحديد تنسيقات الحفظ المختلفة، يمكنك أيضًا حفظ ملف PPT في العديد من التنسيقات الأخرى مثل PDF، XPS، ODP، HTML، إلخ كما هو موضح في هذه المقالات.

- [تحويل PPT إلى PDF باستخدام Java](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [تحويل PPT إلى XPS باستخدام Java](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [تحويل PPT إلى HTML باستخدام Java](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [تحويل PPT إلى ODP باستخدام Java](https://docs.aspose.com/slides/php-java/save-presentation/)
- [تحويل PPT إلى صورة باستخدام Java](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **حول تحويل PPT إلى PPTX**
قم بتحويل تنسيق PPT القديم إلى PPTX باستخدام واجهة برمجة تطبيقات Aspose.Slides. إذا كنت بحاجة إلى تحويل الآلاف من عروض PPT إلى تنسيق PPTX، فإن أفضل حل هو القيام بذلك برمجيًا. باستخدام واجهة برمجة تطبيقات Aspose.Slides، من الممكن القيام بذلك في بضع أسطر من التعليمات البرمجية. تدعم واجهة برمجة التطبيقات التوافق الكامل لتحويل عرض PPT إلى PPTX ومن الممكن:

- تحويل الهياكل المعقدة للأساتذة والتخطيطات والشرائح.
- تحويل العرض مع الرسوم البيانية.
- تحويل العرض مع الأشكال المجمعة، الأشكال التلقائية (مثل المستطيلات والدوائر)، الأشكال ذات الهندسة المخصصة.
- تحويل العرض، الذي يحتوي على أنماط ملء للنسيج والصور للأشكال التلقائية.
- تحويل العرض مع القوالب، إطارات النص وأماكن النص.

{{% alert color="primary" %}} 

إلق نظرة على [**تحويل PPT إلى PPTX بواسطة Aspose.Slides**](https://products.aspose.app/slides/conversion/ppt-to-pptx) التطبيق:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

هذا التطبيق مبني على [**واجهة برمجة تطبيقات Aspose.Slides**](https://products.aspose.com/slides/php-java/)، لذا يمكنك رؤية مثال حي على قدرات تحويل PPT إلى PPTX الأساسية. تحويل Aspose.Slides هو تطبيق ويب، يسمح بإسقاط ملف العرض بتنسيق PPT وتنزيله بعد تحويله إلى PPTX.

ابحث عن أمثلة حية أخرى من [**تحويل Aspose.Slides**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 

## **تحويل PPT إلى PPTX**
يسهل Aspose.Slides لـ PHP عبر Java الآن للمطورين الوصول إلى PPT باستخدام مثيل فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وتحويله إلى تنسيق [PPTX](https://docs.fileformat.com/presentation/pptx/). حاليًا، يدعم التحويل الجزئي من [PPT ](https://docs.fileformat.com/presentation/ppt/)إلى PPTX. لمزيد من التفاصيل حول الميزات المدعومة وغير المدعومة في تحويل PPT إلى PPTX، يرجى الانتقال إلى وثائق هذا [الرابط](/slides/php-java/ppt-to-pptx-conversion/).

يقدم Aspose.Slides لـ PHP عبر Java فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) التي تمثل ملف عرض **PPTX**. يمكن لفئة Presentation الآن أيضًا الوصول إلى **PPT** من خلال Presentation عند إنشاء الكائن. توضح المثال التالي كيفية تحويل عرض PPT إلى عرض PPTX.

```php
  # إنشاء كائن Presentation يمثل ملف PPTX
  $pres = new Presentation("Aspose.ppt");
  try {
    # حفظ عرض PPTX إلى تنسيق PPTX
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

أنشأت مقطع الكود أعلاه عرض PPTX التالي بعد التحويل

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**الشكل: عرض PPTX الناتج بعد التحويل**|