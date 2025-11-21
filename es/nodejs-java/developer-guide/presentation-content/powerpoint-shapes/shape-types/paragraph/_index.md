---
title: Párrafo
type: docs
weight: 60
url: /es/nodejs-java/paragraph/
---

## **Obtener coordenadas de párrafo y porción en TextFrame**
Usando Aspose.Slides para Node.js a través de Java, los desarrolladores ahora pueden obtener las coordenadas rectangulares del Paragraph dentro de la colección de párrafos de TextFrame. También permite obtener [las coordenadas de la porción](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getCoordinates--) dentro de la colección de porciones de un párrafo. En este tema, vamos a demostrar, con la ayuda de un ejemplo, cómo obtener las coordenadas rectangulares del párrafo junto con la posición de la porción dentro de un párrafo.
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```


## **Obtener coordenadas rectangulares del Paragraph**
Usando el método [**getRect()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph#getRect--) los desarrolladores pueden obtener el rectángulo de límites del párrafo.
```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtener el tamaño del Paragraph y la Portion dentro del TextFrame de la celda de tabla**

Para obtener el tamaño y las coordenadas de la [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) o del [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph) en el TextFrame de una celda de tabla, puedes usar los métodos [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getRect--) y [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph#getRect--).
Este código de ejemplo demuestra la operación descrita:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿En qué unidades se devuelven las coordenadas de un párrafo y porciones de texto?**

En puntos, donde 1 pulgada = 72 puntos. Esto se aplica a todas las coordenadas y dimensiones en la diapositiva.

**¿Afecta el ajuste de línea a los límites del párrafo?**

Sí. Si el [ajuste de línea](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) está habilitado en el [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/), el texto se ajusta para encajar en el ancho del área, lo que modifica los límites reales del párrafo.

**¿Se pueden mapear de manera fiable las coordenadas del párrafo a píxeles en la imagen exportada?**

Sí. Convierte puntos a píxeles usando: píxeles = puntos × (DPI / 72). El resultado depende del DPI elegido para la renderización/exportación.

**¿Cómo obtener los parámetros de formato "efectivo" del párrafo, teniendo en cuenta la herencia de estilos?**

Utiliza la [estructura de datos de formato de párrafo efectivo](/slides/es/nodejs-java/shape-effective-properties/); devuelve los valores finales consolidados para sangrías, espaciado, ajuste, RTL y más.