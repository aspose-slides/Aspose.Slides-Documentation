---
title: تكوين استبدال الخطوط في العروض التقديمية باستخدام PHP
linktitle: استبدال الخط
type: docs
weight: 70
url: /ar/php-java/font-substitution/
keywords:
- خط
- خط بديل
- استبدال الخط
- استبدال الخط
- استبدال الخط
- قاعدة الاستبدال
- قاعدة الاستبدال
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تمكين استبدال الخطوط الأمثل في Aspose.Slides لـ PHP عبر Java عند تحويل عروض PowerPoint و OpenDocument إلى صيغ ملفات أخرى."
---

## **تحديد قواعد استبدال الخطوط**

تسمح Aspose.Slides لك بتحديد قواعد للخطوط تحدد ما يجب القيام به في ظروف معينة (مثلاً عندما لا يمكن الوصول إلى خط) بهذه الطريقة:

1. تحميل العرض التقديمي المناسب.
2. تحميل الخط الذي سيتم استبداله.
3. تحميل الخط الجديد.
4. إضافة قاعدة للاستبدال.
5. إضافة القاعدة إلى مجموعة قواعد استبدال خطوط العرض التقديمي.
6. توليد صورة الشريحة لملاحظة النتيجة.

هذا الكود PHP يوضح عملية استبدال الخط:
```php
  # يحمل عرضاً تقديمياً
  $pres = new Presentation("Fonts.pptx");
  try {
    # يحمل الخط المصدر الذي سيتم استبداله
    $sourceFont = new FontData("SomeRareFont");
    # يحمل الخط الجديد
    $destFont = new FontData("Arial");
    # يضيف قاعدة لاستبدال الخط
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # يضيف القاعدة إلى مجموعة قواعد استبدال الخط
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # يضيف مجموعة قواعد الخط إلى قائمة القواعد
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # سيتم استخدام خط Arial بدلاً من SomeRareFont عندما يكون الأخير غير متاح
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # يحفظ الصورة إلى القرص بتنسيق JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{%  alert title="ملاحظة"  color="warning"   %}} 

قد ترغب في الاطلاع على [**استبدال الخط**](/slides/ar/php-java/font-replacement/).

{{% /alert %}}

## **الأسئلة المتكررة**

**ما الفرق بين استبدال الخط واستبدال الخطوط (substitution)؟**

[الاستبدال](/slides/ar/php-java/font-replacement/) هو تجاوز إجبارية لخط بآخر عبر كامل العرض التقديمي. الاستبدال (substitution) هو قاعدة تُفعل تحت شرط محدد، مثل عدم توفر الخط الأصلي، ثم يُستخدم خط بديل معين.

**متى تُطبق قواعد الاستبدال بالتحديد؟**

تشارك القواعد في تسلسل [اختيار الخط](/slides/ar/php-java/font-selection-sequence/) القياسي الذي يتم تقييمه أثناء التحميل، والعرض، والتحويل؛ إذا كان الخط المختار غير متوفر، يتم تطبيق الاستبدال أو الاستبدال (substitution).

**ما السلوك الافتراضي إذا لم يتم تكوين استبدال ولا استبدال (substitution) وكان الخط مفقودًا على النظام؟**

سيحاول المكتبة اختيار أقرب خط نظام متاح، مشابه للكيفية التي يتصرف بها PowerPoint.

**هل يمكنني إرفاق خطوط خارجية مخصصة في وقت التشغيل لتجنب الاستبدال؟**

نعم. يمكنك [إضافة خطوط خارجية](/slides/ar/php-java/custom-font/) في وقت التشغيل بحيث تأخذ المكتبة هذه الخطوط في الاعتبار للاختيار والعرض، بما في ذلك التحويلات اللاحقة.

**هل توزع Aspose أي خطوط مع المكتبة؟**

لا. لا توزع Aspose خطوطًا مدفوعة أو مجانية؛ أنت تضيف وتستخدم الخطوط بناءً على تقديرك ومسؤوليتك.

**هل هناك اختلافات في سلوك الاستبدال بين Windows وLinux وmacOS؟**

نعم. يبدأ اكتشاف الخطوط من مجلدات خطوط نظام التشغيل. مجموعة الخطوط المتاحة افتراضيًا ومسارات البحث تختلف بين الأنظمة، مما يؤثر على التوافر والحاجة إلى الاستبدال.

**كيف ينبغي أن أُجهّز البيئة لتقليل الاستبدال غير المتوقع أثناء التحويلات الجماعية؟**

قُم بمزامنة مجموعة الخطوط عبر الأجهزة أو الحاويات، [أضف الخطوط الخارجية](/slides/ar/php-java/custom-font/) المطلوبة للمستندات الناتجة، و[ضم الخطوط](/slides/ar/php-java/embedded-font/) في العروض التقديمية عندما يكون ذلك ممكنًا حتى تكون الخطوط المختارة متاحة أثناء العرض.