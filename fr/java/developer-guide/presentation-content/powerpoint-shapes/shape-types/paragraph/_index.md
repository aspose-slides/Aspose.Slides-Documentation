---
title: Paragraphe
type: docs
weight: 60
url: /fr/java/paragraph/
---


## Obtenir les coordonnées de Paragraphe et Portion dans TextFrame ##
En utilisant Aspose.Slides pour Java, les développeurs peuvent maintenant obtenir les coordonnées rectangulaires pour le Paragraphe à l'intérieur de la collection de paragraphes de TextFrame. Cela vous permet également d'obtenir [les coordonnées de portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) dans la collection de portions d'un paragraphe. Dans ce sujet, nous allons démontrer à l'aide d'un exemple comment obtenir les coordonnées rectangulaires pour un paragraphe ainsi que la position de la portion à l'intérieur d'un paragraphe.

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```


## **Obtenir les coordonnées rectangulaires du Paragraphe**
En utilisant [**getRect()**](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--) méthode, les développeurs peuvent obtenir le rectangle des limites du paragraphe.

```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Largeur: " + rect.width + " Hauteur: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtenir la taille du paragraphe et de la portion à l'intérieur d'un cadre de texte de cellule de tableau** ##

Pour obtenir la taille et les coordonnées de la [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) ou du [Paragraphe](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph) dans un cadre de texte de cellule de tableau, vous pouvez utiliser les méthodes [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getRect--) et [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--).

Ce code d'exemple démontre l'opération décrite :

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