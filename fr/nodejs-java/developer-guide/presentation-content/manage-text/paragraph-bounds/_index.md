---
title: Obtenir les limites des paragraphes à partir de présentations en JavaScript
linktitle: Limites des paragraphes
type: docs
weight: 43
url: /fr/nodejs-java/paragraph-bounds/
keywords:
- limites du paragraphe
- coordonnée du paragraphe
- taille du paragraphe
- cadre de texte
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez comment récupérer les limites des paragraphes dans Aspose.Slides pour Node.js via Java afin d'optimiser le positionnement du texte dans les présentations PowerPoint."
---
## **Aperçu**

Cet article explique comment obtenir les limites, la taille et les coordonnées des paragraphes dans Aspose.Slides. Il montre comment récupérer un rectangle de paragraphe à partir d'un [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) en utilisant [Paragraph.getRect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/getrect/), comment obtenir les coordonnées du paragraphe dans le cadre de texte d'une cellule de tableau, et met en évidence des détails importants tels que les unités de mesure, l'effet du renvoi à la ligne sur les limites, la conversion en pixels et les valeurs de formatage effectif du paragraphe.

## **Obtenir les coordonnées rectangulaires d'un paragraphe**

Utilisez [Paragraph.getRect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/getrect/) pour obtenir le rectangle englobant d’un paragraphe.

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Obtenir la taille d'un paragraphe dans le TextFrame d'une cellule de tableau**

Pour obtenir la taille et les coordonnées d’un [Paragraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/) dans le cadre de texte d’une cellule de tableau, utilisez [Paragraph.getRect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/getrect/). Le rectangle retourné est relatif au cadre de texte de la cellule du tableau, il faut donc ajouter la position du tableau et le décalage de la cellule lorsque vous avez besoin des coordonnées au niveau de la diapositive.

L’exemple suivant obtient les limites du paragraphe à l’intérieur d’une cellule de tableau et dessine des rectangles sur la diapositive pour visualiser ces limites :

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Dans quelles unités les coordonnées du paragraphe sont‑elles mesurées ?**

Elles sont mesurées en points, où 1 pouce équivaut à 72 points. Cela s’applique à toutes les coordonnées et dimensions de la diapositive.

**Le renvoi à la ligne affecte‑t‑il les limites du paragraphe ?**

Oui. Si [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/setwraptext/) est activé pour le [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/), le texte se casse pour s’adapter à la largeur de la zone, ce qui modifie les limites réelles du paragraphe.

**Les coordonnées du paragraphe peuvent‑elles être converties de façon fiable en pixels dans l’image exportée ?**

Oui. Convertissez les points en pixels à l’aide de la formule suivante : pixels = points × (DPI / 72). Le résultat dépend du DPI choisi pour le rendu ou l’exportation.

**Comment obtenir les paramètres de formatage « effectif » du paragraphe, en tenant compte de l’héritage de style ?**

Utilisez la [structure de données de formatage effectif du paragraphe](/slides/fr/nodejs-java/shape-effective-properties/); elle renvoie les valeurs consolidées finales pour les retraits, l’espacement, le renvoi à la ligne, le RTL et plus encore.