---
title: حفظ العروض التقديمية في وضع القراءة‑فقط باستخدام PHP
linktitle: عرض تقديمي قراءة‑فقط
type: docs
weight: 30
url: /ar/php-java/read-only-presentation/
keywords:
- قراءة‑فقط
- حماية العرض التقديمي
- منع التعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تحميل وحفظ ملفات PowerPoint (PPT, PPTX) في وضع القراءة‑فقط باستخدام Aspose.Slides للـ PHP، مع تقديم معاينات دقيقة للشرائح دون تعديل العروض التقديمية."
---

## **تطبيق وضع القراءة‑فقط**

في PowerPoint 2019، قدمت Microsoft إعداد **Always Open Read-Only** كأحد الخيارات التي يمكن للمستخدمين استخدامها لحماية عروضهم التقديمية. قد ترغب في استخدام هذا الإعداد للحماية عندما

- تريد منع التحريرات العارضة والحفاظ على محتوى العرض التقديمي آمنًا. 
- تريد تنبيه الأشخاص أن العرض التقديمي الذي قدمته هو النسخة النهائية. 

بعد أن تختار خيار **Always Open Read-Only** لعرض تقديمي، عندما يفتح المستخدمون العرض يرون توصية **Read-Only** وقد يظهر لهم رسالة بهذا الشكل: *To prevent accidental changes, the author has set this file to open as read-only.*

تُعَد توصية **Read-Only** رادعًا بسيطًا لكنه فعّال يُثَبِّط التحرير لأن المستخدمين يجب أن يقوموا بإجراء لإزالتها قبل أن يُسمح لهم بتحرير العرض. إذا كنت لا تريد أن يُجري المستخدمون تغييرات على العرض وتريد إبلاغهم بذلك بطريقة مهذبة، فربما تكون توصية **Read-Only** خيارًا جيدًا لك. 

> إذا تم فتح عرض تقديمي محمي بـ **Read-Only** في نسخة أقدم من Microsoft PowerPoint — لا تدعم الوظيفة التي تم تقديمها مؤخرًا — يتم تجاهل توصية **Read-Only** (يُفتح العرض كالمعتاد).

Aspose.Slides for PHP via Java يتيح لك تعيين عرض تقديمي إلى **Read-Only**، مما يعني أن المستخدمين (بعد فتحهم للعرض) يرون توصية **Read-Only**. يوضح لك هذا المثال كيفية تعيين عرض تقديمي إلى **Read-Only** باستخدام Aspose.Slides:
```php
  $pres = new Presentation();
  try {
    $pres->getProtectionManager()->setReadOnlyRecommended(true);
    $pres->save("ReadOnlyPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 

**ملاحظة**: توصية **Read-Only** تهدف فقط إلى تثبيط التحرير أو منع المستخدمين من إحداث تغييرات عارضة في عرض PowerPoint. إذا قرر شخص مُتحفّز — يعرف ما يفعله — تعديل العرض، يمكنه بسهولة إزالة إعداد القراءة‑فقط. إذا كنت بحاجة فعليًا إلى منع التحرير غير المصرّح به، فمن الأفضل استخدام [حمايات أكثر صرامة تشمل التشفير وكلمات المرور](https://docs.aspose.com/slides/php-java/password-protected-presentation/).

{{% /alert %}} 

## **الأسئلة الشائعة**

**كيف يختلف “Read-Only recommended” عن الحماية بكلمة مرور كاملة؟**

“Read-Only recommended” يعرض فقط اقتراحًا بفتح الملف في وضع القراءة‑فقط ويسهل تجاوزه. [Password protection](/slides/ar/php-java/password-protected-presentation/) يقيّد فعليًا الفتح أو التحرير ويُستخدم عندما تحتاج إلى ضوابط أمان حقيقية.

**هل يمكن دمج “Read-Only recommended” مع العلامات المائية لتثبيط التحرير أكثر؟**

نعم. يمكن إقران التوصية مع [watermarks](/slides/ar/php-java/watermark/) كوسيلة مرئية للردع؛ فهما آليتان منفصلتان وتعملان معًا بشكل جيد.

**هل لا يزال بإمكان ماكرو أو أداة خارجية تعديل الملف عندما تكون التوصية مفعّلة؟**

نعم. التوصية لا تُمنع التغييرات البرمجية. لمنع التحرير الآلي، استخدم [passwords and encryption](/slides/ar/php-java/password-protected-presentation/).

**كيف يرتبط “Read-Only recommended” بالطرق “isEncrypted” و “isWriteProtected”؟**

هما إشارات مختلفة. “Read-Only recommended” هو تحذير ناعم واختياري؛ [isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/iswriteprotected/) و [isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isencrypted/) يشيران إلى قيود كتابة أو قراءة فعلية تعتمد على كلمات مرور أو تشفير.