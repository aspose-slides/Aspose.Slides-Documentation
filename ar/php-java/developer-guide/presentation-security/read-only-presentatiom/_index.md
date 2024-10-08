---
title: عرض للقراءة فقط
type: docs
weight: 30
url: /ar/php-java/read-only-presentation/

---

في PowerPoint 2019، قدمت Microsoft إعداد **فتحه دائمًا للقراءة فقط** كواحد من الخيارات التي يمكن للمستخدمين استخدامها لحماية عروضهم التقديمية. قد ترغب في استخدام هذا الإعداد للقراءة فقط لحماية عرض تقديمي عندما

- تريد منع التعديلات غير المقصودة والحفاظ على محتوى عرضك التقديمي آمنًا.
- تريد تنبيه الناس أن العرض الذي قدمته هو النسخة النهائية.

بعد أن تختار خيار **فتحه دائمًا للقراءة فقط** لعرض تقديمي، عندما يفتح المستخدمون العرض التقديمي، يرون توصية **للقراءة فقط** وقد يرون رسالة بهذا الشكل: *لمنع التغييرات غير المقصودة، قام المؤلف بتعيين هذا الملف لفتحه كقراءة فقط.*

توصية القراءة فقط هي رادع بسيط ولكنه فعال يثبط التعديل لأن المستخدمين عليهم أداء مهمة لإزالته قبل أن يُسمح لهم بتعديل عرض تقديمي. إذا كنت لا ترغب في أن يجري المستخدمون تغييرات على عرض تقديمي وتريد إخبارهم بذلك بطريقة مهذبة، فإن توصية القراءة فقط قد تكون خيارًا جيدًا لك.

> إذا تم فتح عرض تقديمي مع حماية **للقراءة فقط** في تطبيق Microsoft PowerPoint أقدم - الذي لا يدعم الوظيفة التي تم تقديمها مؤخرًا - سيتم تجاهل توصية **للقراءة فقط** (يتم فتح العرض بشكل عادي).

Aspose.Slides لـ PHP عبر Java يتيح لك تعيين عرض تقديمي ليكون **للقرأءة فقط**، مما يعني أن المستخدمين (بعد أن يفتحوا العرض التقديمي) يرون توصية **للقراءة فقط**. هذا الكود العيني يوضح لك كيف تعين عرض تقديمي ليكون **للقراءة فقط** باستخدام Aspose.Slides:

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

**ملاحظة**: توصية **للقراءة فقط** تهدف ببساطة إلى تثبيط التعديل أو منع المستخدمين من إجراء تغييرات غير مقصودة على عرض PowerPoint. إذا قرر شخص متحمس - يعرف ما يفعله - تعديل عرضك التقديمي، يمكنه بسهولة إزالة إعداد القراءة فقط. إذا كنت بحاجة ماسة لمنع التعديل غير المصرح به، فإن من الأفضل استخدام [حمايات أكثر صرامة تتضمن التشفيرات وكلمات المرور](https://docs.aspose.com/slides/php-java/password-protected-presentation/).

{{% /alert %}} 