---
title: Párrafo
type: docs
weight: 60
url: /es/java/paragraph/
---


## Obtener las coordenadas de párrafo y porciones en TextFrame ##
Usando Aspose.Slides para Java, los desarrolladores ahora pueden obtener las coordenadas rectangulares para los párrafos dentro de la colección de párrafos de TextFrame. También permite obtener [las coordenadas de la porción](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) dentro de la colección de porciones de un párrafo. En este tema, vamos a demostrar con la ayuda de un ejemplo cómo obtener las coordenadas rectangulares para el párrafo junto con la posición de la porción dentro de un párrafo.

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```


## **Obtener las coordenadas rectangulares del párrafo**
Usando [**getRect()**](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--) los desarrolladores pueden obtener el rectángulo de límites del párrafo.

```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Ancho: " + rect.width + " Altura: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtener el tamaño del párrafo y la porción dentro del marco de texto de la celda de la tabla** ##

Para obtener el tamaño y las coordenadas de la [Porción](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) o [Párrafo](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph) en un marco de texto de celda de tabla, puedes usar los métodos [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getRect--) y [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--).

Este código de ejemplo demuestra la operación descrita:

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