---
title: Localisation de la Présentation
type: docs
weight: 100
url: /fr/php-java/presentation-localization/
---

## **Changer la Langue pour le Texte de la Présentation et des Formes**
- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez un [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) de type [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) à la diapositive.
- Ajoutez du texte au TextFrame.
- [Définir l'Identifiant de Langue](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) pour le texte.
- Écrivez la présentation sous forme de fichier PPTX.

L'implémentation des étapes ci-dessus est démontrée ci-dessous dans un exemple.

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Texte pour appliquer la langue de vérification orthographique");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```