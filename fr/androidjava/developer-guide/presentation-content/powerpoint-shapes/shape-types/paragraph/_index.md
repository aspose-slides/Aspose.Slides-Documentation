---
title: Obtenir les limites du paragraphe dans les présentations sur Android
linktitle: Paragraphe
type: docs
weight: 60
url: /fr/androidjava/paragraph/
keywords:
- limites du paragraphe
- limites de la portion de texte
- coordonnée du paragraphe
- coordonnée de la portion
- taille du paragraphe
- taille de la portion de texte
- cadre de texte
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez comment récupérer les limites du paragraphe et de la portion de texte dans Aspose.Slides pour Android via Java afin d'optimiser le positionnement du texte dans les présentations PowerPoint."
---

## **Obtenir les coordonnées du paragraphe et de la portion dans un TextFrame**
En utilisant Aspose.Slides for Android via Java, les développeurs peuvent désormais obtenir les coordonnées rectangulaires du Paragraph à l'intérieur de la collection de paragraphes d'un TextFrame. Cela permet également d'obtenir [les coordonnées de la portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) dans la collection de portions d'un paragraphe. Dans ce sujet, nous allons démontrer à l'aide d'un exemple comment obtenir les coordonnées rectangulaires du paragraphe ainsi que la position de la portion à l'intérieur d'un paragraphe.
``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```


## **Obtenir les coordonnées rectangulaires d'un paragraphe**
En utilisant la méthode [**getRect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraph#getRect--) les développeurs peuvent obtenir le rectangle des limites du paragraphe.
```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtenir la taille d'un paragraphe et d'une portion à l'intérieur d'un TextFrame de cellule de tableau**
Pour obtenir la taille et les coordonnées de la [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) ou du [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph) dans un TextFrame de cellule de tableau, vous pouvez utiliser les méthodes [IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getRect--) et [IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraph#getRect--).
Ce code d'exemple illustre l'opération décrite :
```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Dans quelles unités les coordonnées retournées pour un paragraphe et les portions de texte sont‑elles mesurées ?**  
En points, où 1 pouce = 72 points. Ceci s'applique à toutes les coordonnées et dimensions sur la diapositive.

**Le retour à la ligne affecte‑t‑il les limites du paragraphe ?**  
Oui. Si le [wrapping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) est activé dans le [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/), le texte se coupe pour s’adapter à la largeur de la zone, ce qui modifie les limites réelles du paragraphe.

**Les coordonnées du paragraphe peuvent‑elles être mappées de façon fiable en pixels dans l'image exportée ?**  
Oui. Convertissez les points en pixels en utilisant : pixels = points × (DPI / 72). Le résultat dépend du DPI choisi pour le rendu/l’exportation.

**Comment obtenir les paramètres de mise en forme « effectifs » du paragraphe, en tenant compte de l’héritage de style ?**  
Utilisez la [structure de données de mise en forme de paragraphe effective](/slides/fr/androidjava/shape-effective-properties/); elle renvoie les valeurs consolidées finales pour les retraits, l’espacement, le wrapping, le RTL et plus encore.