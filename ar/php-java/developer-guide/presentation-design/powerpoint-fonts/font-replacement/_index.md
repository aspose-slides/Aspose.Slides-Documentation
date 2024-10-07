---
title: استبدال الخطوط - PowerPoint Java API
linktitle: استبدال الخطوط
type: docs
weight: 60
url: /php-java/font-replacement/
description: تعرف على كيفية استبدال الخطوط باستخدام طريقة الاستبدال الصريحة في PowerPoint باستخدام Java API.
---

إذا غيرت رأيك بشأن استخدام خط، يمكنك استبدال ذلك الخط بخط آخر. سيتم استبدال جميع حالات الخط القديم بالخط الجديد.

تتيح لك Aspose.Slides استبدال خط بهذه الطريقة:

1. تحميل العرض التقديمي ذي الصلة.
2. تحميل الخط الذي سيتم استبداله.
3. تحميل الخط الجديد.
4. استبدال الخط.
5. كتابة العرض التقديمي المعدل كملف PPTX.

هذا الكود في PHP يوضح استبدال الخطوط:

```php
  # تحميل عرض تقديمي
  $pres = new Presentation("Fonts.pptx");
  try {
    # تحميل خط المصدر الذي سيتم استبداله
    $sourceFont = new FontData("Arial");
    # تحميل الخط الجديد
    $destFont = new FontData("Times New Roman");
    # استبدال الخطوط
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # حفظ العرض التقديمي
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="ملاحظة" color="warning" %}} 

لتحديد القواعد التي تحدد ما يحدث في ظروف معينة (إذا لم يكن من الممكن الوصول إلى خط، على سبيل المثال)، انظر [**استبدال الخطوط**](/slides/php-java/font-substitution/).

{{% /alert %}}