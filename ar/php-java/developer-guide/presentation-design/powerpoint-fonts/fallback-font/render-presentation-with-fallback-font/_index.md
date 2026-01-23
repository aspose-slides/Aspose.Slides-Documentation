---
title: عرض العروض التقديمية بخطوط احتياطية في PHP
linktitle: عرض العروض التقديمية
type: docs
weight: 30
url: /ar/php-java/render-presentation-with-fallback-font/
keywords:
- خط احتياطي
- عرض PowerPoint
- عرض العرض التقديمي
- عرض الشريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "عرض العروض التقديمية بخطوط احتياطية في Aspose.Slides للـ PHP عبر Java – حافظ على تناسق النص عبر PPT و PPTX و ODP مع أمثلة شفرة خطوة بخطوة."
---

المثال التالي يتضمن هذه الخطوات:

1. نقوم بـ[إنشاء مجموعة قواعد الخط الاحتياطي](/slides/ar/php-java/create-fallback-fonts-collection/).
1. [إزالة] قاعدة خط احتياطي و[addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) إلى قاعدة أخرى.
1. عيّن مجموعة القواعد إلى [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) الطريقة.
1. باستخدام طريقة [Presentation.save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) يمكننا حفظ العرض التقديمي بنفس التنسيق، أو حفظه بتنسيق آخر. بعد تعيين مجموعة قواعد الخط الاحتياطي إلى [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)، تُطبق هذه القواعد أثناء أي عمليات على العرض التقديمي: حفظ، عرض، تحويل، إلخ.
```php
  # إنشاء نسخة جديدة من مجموعة القواعد
  $rulesList = new FontFallBackRulesCollection();
  # إنشاء عدد من القواعد
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # محاولة إزالة خط FallBack "Tahoma" من القواعد المحملة
    $fallBackRule->remove("Tahoma");
    # وتحديث القواعد للنطاق المحدد
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # يمكننا أيضًا إزالة أي قواعد موجودة من القائمة
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # تعيين قائمة القواعد المعدة للاستخدام
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # إنشاء صورة مصغرة باستخدام مجموعة القواعد المُهيأة وحفظها كملف JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # حفظ الصورة إلى القرص بتنسيق JPEG
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
اقرأ المزيد حول كيفية [تحويل PPT و PPTX إلى JPG في PHP](/slides/ar/php-java/convert-powerpoint-to-jpg/).
{{% /alert %}}