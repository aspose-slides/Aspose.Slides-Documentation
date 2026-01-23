---
title: Configurer les collections de polices de secours en PHP
linktitle: Collection de polices de secours
type: docs
weight: 20
url: /fr/php-java/create-fallback-fonts-collection/
keywords:
- police de secours
- règle de secours
- collection de polices
- configurer la police
- installer la police
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Configurer une collection de polices de secours dans Aspose.Slides pour PHP via Java afin de garder le texte cohérent et net dans les présentations PowerPoint et OpenDocument."
---

## **Appliquer les règles de secours**

Des instances de la classe [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) peuvent être organisées dans une [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection). Il est possible d'ajouter ou de supprimer des règles de la collection.

Ensuite, cette collection peut être assignée à la méthode [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) de la classe [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager). FontsManager contrôle les polices dans toute la présentation.

Chaque [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) possède une méthode [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager) avec sa propre instance de la classe [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager).

Voici un exemple de création d'une collection de règles de polices de secours et de son affectation au [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager) d'une présentation donnée :
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


Après que FontsManager a été initialisé avec la collection de polices de secours, les polices de secours sont appliquées lors du rendu de la présentation.

{{% alert color="primary" %}} 
En savoir plus sur la façon de [Rendre la présentation avec une police de secours](/slides/fr/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Mes règles de secours seront‑elles incorporées dans le fichier PPTX et visibles dans PowerPoint après l'enregistrement ?**

Non. Les règles de secours sont des paramètres de rendu à l'exécution ; elles ne sont pas sérialisées dans le PPTX et n'apparaîtront pas dans l'interface de PowerPoint.

**Le secours s'applique‑t‑il au texte à l'intérieur de SmartArt, WordArt, graphiques et tableaux ?**

Oui. Le même mécanisme de substitution de glyphes est utilisé pour tout texte dans ces objets.

**Aspose distribue‑t‑il des polices avec la bibliothèque ?**

Non. Vous ajoutez et utilisez les polices de votre côté, sous votre propre responsabilité.

**Le remplacement/substitution des polices manquantes et le secours des glyphes manquants peuvent‑ils être utilisés ensemble ?**

Oui. Ce sont des étapes indépendantes du même pipeline de résolution de polices : d'abord le moteur résout la disponibilité des polices ([replacement](/slides/fr/php-java/font-replacement/)/[substitution](/slides/fr/php-java/font-substitution/)), puis le secours comble les lacunes des glyphes manquants dans les polices disponibles.