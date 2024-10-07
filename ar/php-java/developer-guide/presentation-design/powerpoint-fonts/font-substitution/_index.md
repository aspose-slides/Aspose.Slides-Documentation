---
title: استبدال الخط - واجهة برمجة تطبيقات PowerPoint Java
linktitle: استبدال الخط
type: docs
weight: 70
url: /php-java/font-substitution/
keywords: "خط، خط بديل، عرض PowerPoint، Java، Aspose.Slides لـ PHP عبر Java"
description: "استبدال الخط في PowerPoint"
---

تسمح لك Aspose.Slides بتعيين قواعد للخطوط التي تحدد ما يجب القيام به في ظروف معينة (على سبيل المثال، عندما لا يمكن الوصول إلى خط) بهذه الطريقة:

1. قم بتحميل العرض التقديمي المعني.
2. قم بتحميل الخط الذي سيتم استبداله.
3. قم بتحميل الخط الجديد.
4. أضف قاعدة للاستبدال.
5. أضف القاعدة إلى مجموعة قواعد استبدال الخطوط في العرض التقديمي.
6. قم بإنشاء صورة الشريحة لملاحظة التأثير.

يوضح هذا الرمز PHP عملية استبدال الخط:

```php
  # تحميل عرض تقديمي
  $pres = new Presentation("Fonts.pptx");
  try {
    # تحميل الخط المصدر الذي سيتم استبداله
    $sourceFont = new FontData("SomeRareFont");
    # تحميل الخط الجديد
    $destFont = new FontData("Arial");
    # إضافة قاعدة خط لاستبدال الخط
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # إضافة القاعدة إلى مجموعة قواعد استبدال الخط
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # إضافة مجموعة قاعدة خط إلى قائمة القواعد
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # سيتم استخدام خط Arial بدلاً من SomeRareFont عندما يكون الأخير غير متاح
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # حفظ الصورة على القرص بتنسيق JPEG
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

{{% alert title="ملاحظة" color="warning" %}} 

قد ترغب في رؤية [**استبدال الخط**](/slides/php-java/font-replacement/).

{{% /alert %}}