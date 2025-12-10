---
title: Obtener límites de párrafo de presentaciones en Java
linktitle: Párrafo
type: docs
weight: 60
url: /es/java/paragraph/
keywords:
- límites de párrafo
- límites de porción de texto
- coordenada de párrafo
- coordenada de porción
- tamaño de párrafo
- tamaño de porción de texto
- marco de texto
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda cómo recuperar los límites de párrafo y de porción de texto en Aspose.Slides para Java para optimizar la posición del texto en presentaciones de PowerPoint."
---

## **Obtener coordenadas de párrafo y porción en un TextFrame**
Con Aspose.Slides for Java, los desarrolladores ahora pueden obtener las coordenadas rectangulares de un Paragraph dentro de la colección de párrafos de un TextFrame. También permite obtener [las coordenadas de la porción](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) dentro de la colección de porciones de un párrafo. En este tema, vamos a demostrar con la ayuda de un ejemplo cómo obtener las coordenadas rectangulares de un párrafo junto con la posición de la porción dentro de un párrafo.
``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```


## **Obtener coordenadas rectangulares de un párrafo**
Con el método [**getRect()**](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--) los desarrolladores pueden obtener el rectángulo de los límites del párrafo.
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


## **Obtener el tamaño de un párrafo y porción dentro de un TextFrame de celda de tabla**
Para obtener el tamaño y las coordenadas de la [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) o del [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph) en un TextFrame de celda de tabla, puede usar los métodos [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getRect--) y [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraph#getRect--).
Este código de ejemplo muestra la operación descrita:
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


## **Preguntas frecuentes**

**¿En qué unidades se devuelven las coordenadas de un párrafo y de las porciones de texto?**  
En puntos, donde 1 pulgada = 72 puntos. Esto se aplica a todas las coordenadas y dimensiones en la diapositiva.

**¿Afecta el ajuste de texto a los límites de un párrafo?**  
Sí. Si el [wrapping](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setWrapText-byte-) está habilitado en el [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/), el texto se parte para ajustarse al ancho del área, lo que cambia los límites reales del párrafo.

**¿Se pueden mapear de forma fiable las coordenadas del párrafo a píxeles en la imagen exportada?**  
Sí. Convierta puntos a píxeles usando: pixels = points × (DPI / 72). El resultado depende del DPI seleccionado para el renderizado/exportación.

**¿Cómo obtener los parámetros de formato de párrafo "efectivo", teniendo en cuenta la herencia de estilos?**  
Utilice la [estructura de datos de formato de párrafo efectivo](/slides/es/java/shape-effective-properties/); devuelve los valores consolidados finales para sangrías, espaciado, ajuste, RTL y más.