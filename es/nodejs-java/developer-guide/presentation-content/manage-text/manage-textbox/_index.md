---
title: Administrar cuadro de texto
type: docs
weight: 20
url: /es/nodejs-java/manage-textbox/
keywords:
- cuadro de texto
- marco de texto
- agregar texto
- actualizar texto
- cuadro de texto con hipervínculo
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides para Node.js mediante Java
description: "Administre un cuadro de texto o un marco de texto en presentaciones de PowerPoint usando JavaScript"
---

Los textos en las diapositivas normalmente existen en cuadros de texto o formas. Por lo tanto, para agregar texto a una diapositiva, debes agregar un cuadro de texto y luego colocar algo de texto dentro del cuadro de texto. Aspose.Slides for Node.js via Java proporciona la clase [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) que permite agregar una forma que contiene texto.

{{% alert title="Info" color="info" %}}

Aspose.Slides también proporciona la clase [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) que permite agregar formas a las diapositivas. Sin embargo, no todas las formas añadidas mediante la clase `Shape` pueden contener texto. Pero las formas añadidas mediante la clase [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) pueden contener texto.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Por lo tanto, cuando trabajes con una forma a la que deseas agregar texto, puedes querer comprobar y confirmar que fue convertida mediante la clase `AutoShape`. Sólo entonces podrás trabajar con [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame), que es una propiedad de `AutoShape`. Consulta la sección [Update Text](https://docs.aspose.com/slides/nodejs-java/manage-textbox/#update-text) en esta página.

{{% /alert %}}

## **Crear cuadro de texto en la diapositiva**

Para crear un cuadro de texto en una diapositiva, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtén una referencia a la primera diapositiva en la presentación recién creada. 
3. Añade un objeto [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) con [ShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) configurado como `Rectangle` en una posición especificada de la diapositiva y obtén la referencia al objeto `AutoShape` recién añadido.
4. Agrega una propiedad `TextFrame` al objeto `AutoShape` que contendrá texto. En el ejemplo inferior, añadimos este texto: *Aspose TextBox*
5. Finalmente, escribe el archivo PPTX mediante el objeto `Presentation`. 

Este código JavaScript—una implementación de los pasos anteriores—te muestra cómo agregar texto a una diapositiva:
```javascript
    // Instancia la presentación
    var pres = new aspose.slides.Presentation();
    try {
        // Obtiene la primera diapositiva de la presentación
        var sld = pres.getSlides().get_Item(0);
        // Añade un AutoShape con el tipo configurado como Rectángulo
        var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
        // Añade un TextFrame al rectángulo
        ashp.addTextFrame(" ");
        // Accede al marco de texto
        var txtFrame = ashp.getTextFrame();
        // Crea el objeto Paragraph para el marco de texto
        var para = txtFrame.getParagraphs().get_Item(0);
        // Crea un objeto Portion para el párrafo
        var portion = para.getPortions().get_Item(0);
        // Establece el texto
        portion.setText("Aspose TextBox");
        // Guarda la presentación en disco
        pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Comprobar forma de cuadro de texto**

Aspose.Slides proporciona el método [isTextBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#isTextBox) de la clase [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) que permite examinar formas e identificar cuadros de texto.

![Text box and shape](istextbox.png)

Este código JavaScript te muestra cómo verificar si una forma se creó como un cuadro de texto:
```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```


Ten en cuenta que si simplemente añades una autoshape usando el método `addAutoShape` de la clase [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/), el método `isTextBox` de la autoshape devolverá `false`. Sin embargo, después de agregar texto a la autoshape mediante el método `addTextFrame` o el método `setText`, la propiedad `isTextBox` devolverá `true`.
```javascript
var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() devuelve false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() devuelve true

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() devuelve false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() devuelve true

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() devuelve false
shape3.addTextFrame("");
// shape3.isTextBox() devuelve false

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() devuelve false
shape4.getTextFrame().setText("");
// shape4.isTextBox() devuelve false
```


## **Agregar columna en cuadro de texto**

Aspose.Slides proporciona los métodos [setColumnCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) y [setColumnSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) de la clase [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) que permiten agregar columnas a los cuadros de texto. Puedes especificar el número de columnas en un cuadro de texto y establecer la separación en puntos entre columnas.

Este código en JavaScript demuestra la operación descrita: 
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Obtiene la primera diapositiva de la presentación
    var slide = pres.getSlides().get_Item(0);
    // Añade un AutoShape con el tipo configurado como Rectángulo
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Añade un TextFrame al rectángulo
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // Obtiene el formato de texto del TextFrame
    var format = aShape.getTextFrame().getTextFrameFormat();
    // Especifica el número de columnas en el TextFrame
    format.setColumnCount(3);
    // Especifica el espaciado entre columnas
    format.setColumnSpacing(10);
    // Guarda la presentación
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Agregar columna en marco de texto**

Aspose.Slides for Node.js via Java proporciona el método [setColumnCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) de la clase [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) que permite agregar columnas en marcos de texto. Mediante esta propiedad, puedes especificar el número de columnas que deseas en un marco de texto.

Este código JavaScript te muestra cómo agregar una columna dentro de un marco de texto:
```javascript
var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Actualizar texto**

Aspose.Slides permite cambiar o actualizar el texto contenido en un cuadro de texto o todos los textos contenidos en una presentación. 

Este código JavaScript demuestra una operación en la que se actualizan o cambian todos los textos de una presentación:
```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Verifica si la forma soporta marco de texto (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Itera a través de los párrafos en el marco de texto
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Itera a través de cada porción en el párrafo
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// Cambia el texto
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Cambia el formato
                    }
                }
            }
        }
    }
    // Guarda la presentación modificada
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Agregar cuadro de texto con hipervínculo** 

Puedes insertar un enlace dentro de un cuadro de texto. Cuando se hace clic en el cuadro de texto, los usuarios son dirigidos a abrir el enlace. 

Para agregar un cuadro de texto que contenga un enlace, sigue estos pasos:

1. Crea una instancia de la clase `Presentation`. 
2. Obtén una referencia a la primera diapositiva en la presentación recién creada. 
3. Añade un objeto `AutoShape` con `ShapeType` configurado como `Rectangle` en una posición especificada de la diapositiva y obtén la referencia al objeto `AutoShape` recién añadido.
4. Agrega un `TextFrame` al objeto `AutoShape` que contenga *Aspose TextBox* como texto predeterminado. 
5. Instancia la clase `HyperlinkManager`. 
6. Asigna el objeto `HyperlinkManager` a la propiedad [HyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick--) asociada a la porción preferida de tu `TextFrame`.
7. Finalmente, escribe el archivo PPTX mediante el objeto `Presentation`. 

Este código JavaScript—una implementación de los pasos anteriores—te muestra cómo agregar un cuadro de texto con un hipervínculo a una diapositiva:
```javascript
// Instancia una clase Presentation que representa un PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtiene la primera diapositiva de la presentación
    var slide = pres.getSlides().get_Item(0);
    // Añade un objeto AutoShape con el tipo establecido como Rectángulo
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Convierte la forma a AutoShape
    var pptxAutoShape = shape;
    // Accede a la propiedad ITextFrame asociada al AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Añade algo de texto al marco
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Establece el hipervínculo para el texto de la porción
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // Guarda la presentación PPTX
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**¿Cuál es la diferencia entre un cuadro de texto y un marcador de posición de texto al trabajar con diapositivas maestras?**

Un [placeholder](/slides/es/nodejs-java/manage-placeholder/) hereda estilo/posición de la [master](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) y puede ser sobrescrito en los [layouts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/), mientras que un cuadro de texto normal es un objeto independiente en una diapositiva específica y no cambia cuando cambias de layout.

**¿Cómo puedo realizar un reemplazo masivo de texto en toda la presentación sin tocar el texto dentro de gráficos, tablas y SmartArt?**

Limita tu iteración a auto‑shapes que tengan marcos de texto y excluye los objetos incrustados ([charts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/)) recorriendo sus colecciones por separado o omitendo esos tipos de objetos.