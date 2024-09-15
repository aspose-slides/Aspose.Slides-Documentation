---
title: Create Fallback Fonts Collection
type: docs
weight: 20
url: /php-java/create-fallback-fonts-collection/
---

Instances of [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) class can be organized into [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection), that implements [IFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRulesCollection) interface. It is possible to add or remove rules from the collection.

Then this collection may be assigned to [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) method of the [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) class. FontsManager controls fonts across the presentation. Read more [About FontsManager and FontsLoader](/slides/php-java/about-fontsmanager-and-fontsloader/).

Each [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) has a [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) method with its own instance of the [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) class.

Here is an examples how to create fallback fonts rules collection and assign in into the [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) of a certain presentation:  

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

After FontsManager is initialised with fallback fonts collection, the fallback fonts are applied during presentation rendering.

{{% alert color="primary" %}} 
Read more how to [Render Presentation with Fallback Font](/slides/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}
