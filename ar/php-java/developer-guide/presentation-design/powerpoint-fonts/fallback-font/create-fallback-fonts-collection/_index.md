---
title: إنشاء مجموعة خطوط احتياطية
type: docs
weight: 20
url: /ar/php-java/create-fallback-fonts-collection/
---

يمكن تنظيم حالات [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) ، التي تنفذ [IFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRulesCollection) واجهة. من الممكن إضافة قواعد أو إزالة قواعد من المجموعة.

ثم يمكن تعيين هذه المجموعة إلى [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) طريقة من فئة [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) . يتحكم FontsManager في الخطوط عبر العرض التقديمي. اقرأ المزيد [حول FontsManager و FontsLoader](/slides/ar/php-java/about-fontsmanager-and-fontsloader/).

لكل [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) طرق [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) مع مثيله الخاص من فئة [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) .

إليك مثالاً على كيفية إنشاء مجموعة قواعد خطوط احتياطية وتعيينها إلى [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) لعرض تقديمي معين:  

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

بعد أن يتم تهيئة FontsManager مع مجموعة الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية أثناء تقديم العرض.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [عرض العرض التقديمي بخط احتياطي](/slides/ar/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}