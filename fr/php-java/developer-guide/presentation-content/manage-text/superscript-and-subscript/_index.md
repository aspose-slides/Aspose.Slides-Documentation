---
title: Gérer les exposants et les indices dans les présentations avec PHP
linktitle: Exposant et indice
type: docs
weight: 80
url: /fr/php-java/superscript-and-subscript/
keywords:
- exposant
- indice
- ajouter un exposant
- ajouter un indice
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Maîtrisez les exposants et les indices dans Aspose.Slides pour PHP via Java et améliorez vos présentations avec un formatage de texte professionnel pour un impact maximal."
---

## **Gérer le texte en exposant et indice**
Vous pouvez ajouter du texte en exposant ou indice dans n'importe quelle portion de paragraphe. Pour ajouter du texte en exposant ou indice dans le cadre de texte Aspose.Slides, vous devez utiliser la méthode [**setEscapement**](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setEscapement-float-) de la classe [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PortionFormat).

Cette propriété renvoie ou définit le texte en exposant ou indice (valeur de -100 % (indice) à 100 % (exposant)). Par exemple :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez un [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) de type [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) à la diapositive.
- Accédez au [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) associé au [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
- Effacez les paragraphes existants
- Créez un nouvel objet paragraphe pour contenir le texte en exposant et ajoutez‑le à la collection [IParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#getParagraphs--) du [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame).
- Créez un nouvel objet portion
- Définissez la propriété Escapement de la portion entre 0 et 100 pour ajouter un exposant. (0 signifie aucun exposant)
- Définissez du texte pour la [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) puis ajoutez‑le à la collection de portions du paragraphe.
- Créez un nouvel objet paragraphe pour contenir le texte en indice et ajoutez‑le à la collection IParagraphs du ITextFrame.
- Créez un nouvel objet portion
- Définissez la propriété Escapement de la portion entre 0 et -100 pour ajouter un indice. (0 signifie aucun indice)
- Définissez du texte pour la [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) puis ajoutez‑le à la collection de portions du paragraphe.
- Enregistrez la présentation au format PPTX.

L'implémentation des étapes ci‑dessus est fournie ci‑dessous.
```php
  # Instancier une classe Presentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Obtenir la diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Créer une zone de texte
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # Créer un paragraphe pour le texte en exposant
    $superPar = new Paragraph();
    # Créer une portion avec du texte normal
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # Créer une portion avec du texte en exposant
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # Créer un paragraphe pour le texte en indice
    $paragraph2 = new Paragraph();
    # Créer une portion avec du texte normal
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # Créer une portion avec du texte en indice
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # Ajouter les paragraphes à la zone de texte
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**L'exposant et l'indice seront-ils conservés lors de l'exportation vers PDF ou d'autres formats ?**

Oui, Aspose.Slides conserve correctement le formatage en exposant et indice lors de l'exportation des présentations vers PDF, PPT/PPTX, images et les autres formats pris en charge. Le formatage spécialisé reste intact dans tous les fichiers de sortie.

**L'exposant et l'indice peuvent-ils être combinés avec d'autres styles de formatage tels que le gras ou l'italique ?**

Oui, Aspose.Slides vous permet de mélanger plusieurs styles de texte au sein d'une même portion. Vous pouvez activer le gras, l'italique, le soulignement et appliquer simultanément l'exposant ou l'indice en configurant les propriétés correspondantes dans [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/).

**Le formatage en exposant et indice fonctionne-t-il pour le texte à l'intérieur des tableaux, graphiques ou SmartArt ?**

Oui, Aspose.Slides prend en charge le formatage dans la plupart des objets, y compris les tableaux et les éléments de graphiques. Lors du travail avec SmartArt, vous devez accéder aux éléments appropriés (comme [SmartArtNode](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/)) et à leurs conteneurs de texte, puis configurer les propriétés [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) de manière similaire.