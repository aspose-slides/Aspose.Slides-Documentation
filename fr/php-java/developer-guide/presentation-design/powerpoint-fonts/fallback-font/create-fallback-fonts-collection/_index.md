---
title: Créer une Collection de Polices de Secours
type: docs
weight: 20
url: /fr/php-java/create-fallback-fonts-collection/
---

Les instances de la classe [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) peuvent être organisées en [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection), qui implémente l'interface [IFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRulesCollection). Il est possible d'ajouter ou de supprimer des règles de la collection.

Ensuite, cette collection peut être assignée à la méthode [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) de la classe [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager). FontsManager contrôle les polices à travers la présentation. En savoir plus [À propos de FontsManager et FontsLoader](/slides/fr/php-java/about-fontsmanager-and-fontsloader/).

Chaque [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) dispose d'une méthode [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) avec sa propre instance de la classe [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager).

Voici un exemple de la façon de créer une collection de règles de polices de secours et de l'assigner dans le [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) d'une certaine présentation :  

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

Après que le FontsManager ait été initialisé avec la collection de polices de secours, les polices de secours sont appliquées lors du rendu de la présentation.

{{% alert color="primary" %}} 
En savoir plus sur [Rendre une Présentation avec une Police de Secours](/slides/fr/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}