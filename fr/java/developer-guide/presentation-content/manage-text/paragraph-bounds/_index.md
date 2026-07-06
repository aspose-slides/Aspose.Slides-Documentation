---
title: Obtenir les limites du paragraphe à partir des présentations en Java
linktitle: Limites du paragraphe
type: docs
weight: 43
url: /fr/java/paragraph-bounds/
keywords:
- limites du paragraphe
- coordonnée du paragraphe
- taille du paragraphe
- cadre de texte
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez comment récupérer les limites du paragraphe dans Aspose.Slides pour Java afin d'optimiser le positionnement du texte dans les présentations PowerPoint."
---
## **Vue d'ensemble**

Cet article explique comment obtenir les limites, la taille et les coordonnées des paragraphes dans Aspose.Slides. Il montre comment récupérer le rectangle d’un paragraphe à partir d’un [ITextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/) en utilisant [IParagraph.getRect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IParagraph#getRect--), comment obtenir les coordonnées du paragraphe à l’intérieur d’un TextFrame de cellule de tableau, et souligne des détails importants tels que les unités de mesure, l’effet du renvoi à la ligne sur les limites, la conversion en pixels et les valeurs de mise en forme de paragraphe effectives.

## **Obtenir les coordonnées rectangulaires d'un paragraphe**

Utilisez [IParagraph.getRect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IParagraph#getRect--) pour obtenir le rectangle englobant d’un paragraphe.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    java.awt.geom.Rectangle2D.Float rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Obtenir la taille d'un paragraphe à l'intérieur d'un TextFrame de cellule de tableau**

Pour obtenir la taille et les coordonnées d’un [IParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraph/) dans un TextFrame de cellule de tableau, utilisez [IParagraph.getRect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IParagraph#getRect--). Le rectangle retourné est relatif au TextFrame de la cellule de tableau, il faut donc ajouter la position du tableau et le décalage de la cellule lorsque vous avez besoin des coordonnées au niveau de la diapositive.

L’exemple suivant récupère les limites du paragraphe à l’intérieur d’une cellule de tableau et trace des rectangles sur la diapositive pour visualiser ces limites :

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        java.awt.geom.Rectangle2D.Float paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.x + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.y + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width,
                paragraphRectangle.height);

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Dans quelles unités les coordonnées de paragraphe sont‑elles mesurées ?**

Elles sont mesurées en points, où 1 pouce équivaut à 72 points. Cela s’applique à toutes les coordonnées et dimensions de la diapositive.

**Le renvoi à la ligne affecte‑t‑il les limites d’un paragraphe ?**

Oui. Si [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) est activé pour le [ITextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/), le texte est coupé pour s’adapter à la largeur de la zone, ce qui modifie les limites réelles du paragraphe.

**Les coordonnées de paragraphe peuvent‑elles être mappées de façon fiable aux pixels dans l’image exportée ?**

Oui. Convertissez les points en pixels à l’aide de cette formule : pixels = points × (DPI / 72). Le résultat dépend du DPI choisi pour le rendu ou l’exportation.

**Comment obtenir les paramètres de mise en forme « effectifs » du paragraphe, en tenant compte de l’héritage de style ?**

Utilisez la [structure de données de mise en forme effective du paragraphe](/slides/fr/java/shape-effective-properties/); elle renvoie les valeurs consolidées finales pour les retraits, l’espacement, le renvoi à la ligne, le texte RTL, etc.