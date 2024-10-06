---
title: Texte en exposant et en indice
type: docs
weight: 80
url: /androidjava/superscript-and-subscript/
---

## **Gérer le texte en exposant et en indice**
Vous pouvez ajouter du texte en exposant et en indice à l'intérieur de n'importe quelle portion de paragraphe. Pour ajouter du texte en exposant ou en indice dans un cadre de texte Aspose.Slides, il faut utiliser la méthode [**setEscapement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) de la classe [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PortionFormat).

Cette propriété retourne ou définit le texte en exposant ou en indice (valeur allant de -100% (indice) à 100% (exposant). Par exemple :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtenir la référence d'une diapositive en utilisant son index.
- Ajouter une [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) de type [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) à la diapositive.
- Accéder au [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) associé à l'[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
- Effacer les paragraphes existants.
- Créer un nouvel objet de paragraphe pour contenir le texte en exposant et l'ajouter à la collection [IParagraphs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) de [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame).
- Créer un nouvel objet portion.
- Définir la propriété Escapement pour la portion entre 0 et 100 pour ajouter un exposant. (0 signifie pas d'exposant)
- Définit du texte pour la [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) puis l'ajouter dans la collection de portions du paragraphe.
- Créer un nouvel objet de paragraphe pour contenir le texte en indice et l'ajouter à la collection IParagraphs de ITextFrame.
- Créer un nouvel objet portion.
- Définir la propriété Escapement pour la portion entre 0 et -100 pour ajouter un indice. (0 signifie pas d'indice)
- Définir du texte pour la [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) puis l'ajouter dans la collection de portions du paragraphe.
- Enregistrer la présentation sous forme de fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

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

    // Créer une portion avec du texte habituel
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

    // Créer une portion avec du texte habituel
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