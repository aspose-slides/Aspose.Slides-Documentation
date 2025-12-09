---
title: Exposant et indice
type: docs
weight: 80
url: /fr/nodejs-java/superscript-and-subscript/
---

## **Gérer le texte en exposant et indice**

Vous pouvez ajouter du texte en exposant ou en indice à l'intérieur de n'importe quelle portion de paragraphe. Pour ajouter du texte en exposant ou en indice dans un cadre texte Aspose.Slides, il faut utiliser la méthode [**setEscapement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) de la classe [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat).

Cette propriété renvoie ou définit le texte en exposant ou en indice (valeur de -100 % (indice) à 100 % (exposant)). Par exemple :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Obtenir la référence d'une diapositive en utilisant son index.
- Ajouter un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) de type [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) à la diapositive.
- Accéder au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) associé à l'[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
- Effacer les paragraphes existants.
- Créer un nouvel objet paragraphe pour contenir le texte en exposant et l'ajouter à la collection [Paragraphs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getParagraphs--) du [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame).
- Créer un nouvel objet portion.
- Définir la propriété Escapement pour la portion entre 0 et 100 afin d'ajouter un exposant. (0 signifie aucun exposant)
- Définir du texte pour la [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) puis l'ajouter à la collection de portions du paragraphe.
- Créer un nouvel objet paragraphe pour contenir le texte en indice et l'ajouter à la collection IParagraphs du ITextFrame.
- Créer un nouvel objet portion.
- Définir la propriété Escapement pour la portion entre 0 et -100 afin d'ajouter un indice. (0 signifie aucun indice)
- Définir du texte pour la [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) puis l'ajouter à la collection de portions du paragraphe.
- Enregistrer la présentation en tant que fichier PPTX.

L'implémentation des étapes ci‑above est présentée ci‑dessous.
```javascript
// Instancier une classe Presentation qui représente un PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la diapositive
    var slide = pres.getSlides().get_Item(0);
    // Créer une zone de texte
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // Créer un paragraphe pour le texte en exposant
    var superPar = new aspose.slides.Paragraph();
    // Créer une portion avec du texte normal
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // Créer une portion avec du texte en exposant
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // Créer un paragraphe pour le texte en indice
    var paragraph2 = new aspose.slides.Paragraph();
    // Créer une portion avec du texte normal
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // Créer une portion avec du texte en indice
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // Ajouter les paragraphes à la zone de texte
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**L'exposant et l'indice seront-ils conservés lors de l'exportation vers PDF ou d'autres formats ?**

Oui, Aspose.Slides conserve correctement le formatage en exposant et indice lors de l'exportation des présentations vers PDF, PPT/PPTX, images et autres formats pris en charge. Le formatage spécialisé reste intact dans tous les fichiers de sortie.

**L'exposant et l'indice peuvent-ils être combinés avec d'autres styles de formatage tels que gras ou italique ?**

Oui, Aspose.Slides vous permet de mélanger divers styles de texte au sein d'une même portion. Vous pouvez activer le gras, l'italique, le soulignement et appliquer simultanément l'exposant ou l'indice en configurant les propriétés correspondantes dans [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/).

**Le formatage en exposant et indice fonctionne-t-il pour le texte à l'intérieur des tableaux, graphiques ou SmartArt ?**

Oui, Aspose.Slides prend en charge le formatage dans la plupart des objets, y compris les éléments de tableau et de graphique. Lors du travail avec SmartArt, vous devez accéder aux éléments appropriés (tels que [SmartArtNode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/)) et à leurs conteneurs de texte, puis configurer les propriétés [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) de façon similaire.