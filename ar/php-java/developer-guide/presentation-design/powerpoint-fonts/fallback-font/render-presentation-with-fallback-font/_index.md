---
title: عرض العرض التقديمي بخيارات الخط الاحتياطي
type: docs
weight: 30
url: /php-java/render-presentation-with-fallback-font/
---

يتضمن المثال التالي هذه الخطوات:

1. نحن [ننشئ مجموعة قواعد الخط الاحتياطي](/slides/php-java/create-fallback-fonts-collection/).
1. [قم بإزالة](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) قاعدة الخط الاحتياطي و [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) إلى قاعدة أخرى.
1. قم بتعيين مجموعة القواعد إلى [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) الطريقة.
1. باستخدام [Presentation.save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) الطريقة يمكننا حفظ العرض التقديمي بنفس التنسيق، أو حفظه بتنسيق آخر. بعد تعيين مجموعة قواعد الخط الاحتياطي إلى [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)، يتم تطبيق هذه القواعد أثناء أي عمليات على العرض التقديمي: حفظ، عرض، تحويل، إلخ.

```php
  # إنشاء مثيل جديد من مجموعة القواعد
  $rulesList = new FontFallBackRulesCollection();
  # إنشاء عدد من القواعد
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # محاولة إزالة خط الاحتياطي "Tahoma" من القواعد المحملة
    $fallBackRule->remove("Tahoma");
    # وتحديث القواعد للنطاق المحدد
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # أيضًا يمكننا إزالة أي قواعد موجودة من القائمة
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # تعيين قائمة القواعد المعدة للاستخدام
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # عرض الصورة المصغرة باستخدام مجموعة القواعد المهيأة وحفظها بصيغة JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # حفظ الصورة على القرص بتنسيق JPEG
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
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

{{% alert color="primary" %}} 
اقرأ المزيد عن [الحفظ والتحويل في العرض التقديمي](/slides/php-java/creating-saving-and-converting-a-presentation/).
{{% /alert %}}