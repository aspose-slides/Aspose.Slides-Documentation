---
title: Automatiser la localisation des présentations en PHP
linktitle: Localisation de présentation
type: docs
weight: 100
url: /fr/php-java/presentation-localization/
keywords:
- changer de langue
- vérification orthographique
- identifiant de langue
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Automatisez la localisation des diapositives PowerPoint et OpenDocument avec Aspose.Slides pour PHP via Java, en utilisant des exemples de code pratiques et des conseils pour un déploiement mondial plus rapide."
---

## **Modifier la langue d’une présentation et du texte de forme**
- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenir la référence d’une diapositive en utilisant son Index.
- Ajouter une [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) de type [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) à la diapositive.
- Ajouter du texte au TextFrame.
- [Set Language Id](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) sur le texte.
- Enregistrer la présentation au format PPTX.

L'implémentation des étapes ci‑dessus est illustrée ci‑après dans un exemple.
```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**L'ID de langue déclenche-t-il la traduction automatique du texte ?**

Non. [Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) dans Aspose.Slides stocke la langue pour la vérification orthographique et la correction grammaticale, mais il ne traduit pas et ne modifie pas le contenu du texte. Il s’agit de métadonnées que PowerPoint comprend pour la révision.

**L'ID de langue affecte-t-il la césure et les sauts de ligne lors du rendu ?**

Dans Aspose.Slides, [language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) sert à la révision. La qualité de la césure et du retour à la ligne dépend principalement de la disponibilité des [polices appropriées](/slides/fr/php-java/powerpoint-fonts/) et des paramètres de mise en page/retour à la ligne du système d'écriture. Pour garantir un rendu correct, rendez les polices requises disponibles, configurez les [règles de substitution de polices](/slides/fr/php-java/font-substitution/) et/ou [intégrez les polices](/slides/fr/php-java/embedded-font/) dans la présentation.

**Puis-je définir différentes langues au sein d'un même paragraphe ?**

Oui. [Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) s'applique au niveau de la portion de texte, de sorte qu'un même paragraphe peut mélanger plusieurs langues avec des paramètres de révision distincts.