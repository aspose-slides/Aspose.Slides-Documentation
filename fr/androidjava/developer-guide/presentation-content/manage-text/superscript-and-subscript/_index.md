---
title: Gestion des exposants et indices dans les présentations sur Android
linktitle: Exposant et indice
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
description: "Maîtrisez les exposants et indices dans Aspose.Slides pour Android via Java et améliorez vos présentations avec un formatage de texte professionnel pour un impact maximal."
---

## **Gérer le texte en exposant et indice**
Vous pouvez ajouter du texte en exposant ou en indice dans n'importe quelle portion de paragraphe. Pour ajouter du texte en exposant ou en indice dans un cadre de texte Aspose.Slides, vous devez utiliser la méthode [**setEscapement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) de la classe [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PortionFormat).

Cette propriété renvoie ou définit le texte en exposant ou en indice (valeur de -100 % (indice) à 100 % (exposant)). Par exemple :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez une [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) de type [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) à la diapositive.
- Accédez au [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) associé à la [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
- Effacez les Paragraphes existants
- Créez un nouvel objet paragraphe pour contenir le texte en exposant et ajoutez-le à la [IParagraphs collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) du [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame).
- Créez un nouvel objet portion
- Définissez la propriété Escapement pour la portion entre 0 et 100 afin d'ajouter un exposant. (0 signifie aucun exposant)
- Définissez du texte pour la [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) puis ajoutez-le à la collection de portions du paragraphe.
- Créez un nouvel objet paragraphe pour contenir le texte en indice et ajoutez-le à la IParagraphs collection du ITextFrame.
- Créez un nouvel objet portion
- Définissez la propriété Escapement pour la portion entre 0 et -100 afin d'ajouter un indice. (0 signifie aucun indice)
- Définissez du texte pour la [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) puis ajoutez-le à la collection de portions du paragraphe.
- Enregistrez la présentation au format PPTX.

L'implémentation des étapes ci‑dessus est fournie ci‑dessous.
```java
// Instanciez une classe Presentation qui représente un PPTX
Presentation pres = new Presentation();
try {
    // Obtenez la diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Créez une zone de texte
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Créez un paragraphe pour le texte en exposant
    IParagraph superPar = new Paragraph();

    // Créez une portion avec du texte normal
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Créez une portion avec du texte en exposant
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Créez un paragraphe pour le texte en indice
    IParagraph paragraph2 = new Paragraph();

    // Créez une portion avec du texte normal
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Créez une portion avec du texte en indice
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Ajoutez les paragraphes à la zone de texte
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Le texte en exposant et indice sera-t-il conservé lors de l'exportation vers PDF ou d'autres formats ?**

Oui, Aspose.Slides conserve correctement la mise en forme en exposant et en indice lors de l'exportation des présentations vers PDF, PPT/PPTX, images et autres formats pris en charge. La mise en forme spécialisée reste intacte dans tous les fichiers de sortie.

**Le texte en exposant et indice peut-il être combiné avec d'autres styles de mise en forme tels que gras ou italique ?**

Oui, Aspose.Slides vous permet de mélanger différents styles de texte au sein d'une même portion. Vous pouvez activer le gras, l'italique, le soulignement, et appliquer simultanément un exposant ou un indice en configurant les propriétés correspondantes dans [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/).

**La mise en forme en exposant et indice fonctionne-t-elle pour le texte à l'intérieur des tableaux, graphiques ou SmartArt ?**

Oui, Aspose.Slides prend en charge la mise en forme dans la plupart des objets, y compris les tableaux et les éléments de graphiques. Lorsque vous travaillez avec SmartArt, vous devez accéder aux éléments appropriés (tels que [SmartArtNode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartnode/)) et leurs conteneurs de texte, puis configurer les propriétés de [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) de la même manière.