---
title: Superscript et Subscript
type: docs
weight: 80
url: /php-java/superscript-and-subscript/
---

## **Gérer le texte en exposant et en indice**
Vous pouvez ajouter du texte en exposant et en indice dans n'importe quelle portion de paragraphe. Pour ajouter du texte en exposant ou en indice dans le cadre de texte Aspose.Slides, il faut utiliser la méthode [**setEscapement**](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setEscapement-float-) de la classe [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PortionFormat).

Cette propriété retourne ou définit le texte en exposant ou en indice (valeur de -100 % (indice) à 100 % (exposant). Par exemple :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez une [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) de type [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) à la diapositive.
- Accédez au [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) associé à l'[IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
- Effacez les paragraphes existants.
- Créez un nouvel objet de paragraphe pour contenir le texte en exposant et ajoutez-le à la collection [IParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#getParagraphs--) du [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame).
- Créez un nouvel objet de portion.
- Définissez la propriété Escapement pour la portion entre 0 et 100 pour ajouter un exposant. (0 signifie pas d'exposant)
- Définissez du texte pour la [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) et ajoutez-le ensuite dans la collection de portions du paragraphe.
- Créez un nouvel objet de paragraphe pour contenir le texte en indice et ajoutez-le à la collection IParagraphs du ITextFrame.
- Créez un nouvel objet de portion.
- Définissez la propriété Escapement pour la portion entre 0 et -100 pour ajouter un indice. (0 signifie pas d'indice)
- Définissez du texte pour la [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) et ajoutez-le ensuite dans la collection de portions du paragraphe.
- Enregistrez la présentation sous forme de fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

```php
  # Instanciez une classe Presentation qui représente un PPTX
  $pres = new Presentation();
  try {
    # Obtenez la diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Créez une zone de texte
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # Créez un paragraphe pour le texte en exposant
    $superPar = new Paragraph();
    # Créez une portion avec du texte habituel
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # Créez une portion avec du texte en exposant
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # Créez un paragraphe pour le texte en indice
    $paragraph2 = new Paragraph();
    # Créez une portion avec du texte habituel
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # Créez une portion avec du texte en indice
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # Ajoutez les paragraphes à la zone de texte
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```