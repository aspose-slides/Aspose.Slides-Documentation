---
title: Gérer les exposants et indices dans les présentations sur Android
linktitle: Exposants et indices
type: docs
weight: 80
url: /fr/androidjava/superscript-and-subscript/
keywords:
  - exposant
  - indice
  - ajouter exposant
  - ajouter indice
  - PowerPoint
  - OpenDocument
  - présentation
  - Android
  - Java
  - Aspose.Slides
description: "Maîtrisez les exposants et indices dans Aspose.Slides pour Android via Java et améliorez vos présentations avec une mise en forme de texte professionnelle pour un impact maximal."
---

## **Gérer le texte en exposant et indice**
Vous pouvez ajouter du texte en exposant et en indice dans n'importe quelle partie de paragraphe. Pour ajouter du texte en exposant ou en indice dans le cadre de texte d'Aspose.Slides, vous devez utiliser la méthode [**setEscapement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) de la classe [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PortionFormat).

Cette propriété renvoie ou définit le texte en exposant ou en indice (valeur de -100 % (indice) à 100 % (exposant)). Par exemple :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtenir la référence d'une diapositive en utilisant son Index.
- Ajouter une [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) de type [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) à la diapositive.
- Accéder au [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) associé à la [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
- Effacer les Paragraphs existants
- Créer un nouvel objet paragraphe pour contenir le texte en exposant et l'ajouter à la [IParagraphs collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) du [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame).
- Créer un nouvel objet portion
- Définir la propriété Escapement pour la portion entre 0 et 100 pour ajouter un exposant. (0 signifie aucun exposant)
- Définir du texte pour la [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) puis l'ajouter à la collection de portions du paragraphe.
- Créer un nouvel objet paragraphe pour contenir le texte en indice et l'ajouter à la IParagraphs collection du ITextFrame.
- Créer un nouvel objet portion
- Définir la propriété Escapement pour la portion entre 0 et -100 pour ajouter un indice. (0 signifie aucun indice)
- Définir du texte pour la [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) puis l'ajouter à la collection de portions du paragraphe.
- Enregistrer la présentation au format PPTX.

L'implémentation des étapes ci‑above est présentée ci‑dessous.
```java
// Instancier une classe Presentation qui représente un PPTX
Presentation pres = new Presentation();
try {
    // Obtenir la diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Créer une zone de texte
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Créer un paragraphe pour le texte en exposant
    IParagraph superPar = new Paragraph();

    // Créer une portion avec du texte normal
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Créer une portion avec du texte en exposant
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Créer un paragraphe pour le texte en indice
    IParagraph paragraph2 = new Paragraph();

    // Créer une portion avec du texte normal
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Créer une portion avec du texte en indice
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Ajouter les paragraphes à la zone de texte
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**L'exposant et l'indice seront-ils conservés lors de l'exportation vers PDF ou d'autres formats ?**

Oui, Aspose.Slides conserve correctement le format d'exposant et d'indice lors de l'exportation des présentations vers PDF, PPT/PPTX, images et autres formats pris en charge. Le formatage spécialisé reste intact dans tous les fichiers de sortie.

**L'exposant et l'indice peuvent-ils être combinés avec d'autres styles de formatage tels que gras ou italique ?**

Oui, Aspose.Slides vous permet de mélanger différents styles de texte au sein d'une même portion. Vous pouvez activer le gras, l'italique, le soulignement, et appliquer simultanément un exposant ou un indice en configurant les propriétés correspondantes dans [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/).

**Le formatage d'exposant et d'indice fonctionne-t-il pour le texte à l'intérieur des tableaux, graphiques ou SmartArt ?**

Oui, Aspose.Slides prend en charge le formatage dans la plupart des objets, y compris les tableaux et les éléments de graphiques. Lors de la manipulation de SmartArt, vous devez accéder aux éléments appropriés (comme [SmartArtNode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartnode/)) et leurs conteneurs de texte, puis configurer les propriétés de [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) de manière similaire.