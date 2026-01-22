---
title: Añadir rectángulos a presentaciones en JavaScript
linktitle: Rectángulo
type: docs
weight: 80
url: /es/nodejs-java/rectangle/
keywords:
- añadir rectángulo
- crear rectángulo
- forma de rectángulo
- rectángulo simple
- rectángulo con formato
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Mejora tus presentaciones de PowerPoint añadiendo rectángulos con JavaScript y Aspose.Slides para Node.js—diseña y modifica formas de forma programada fácilmente."
---

{{% alert color="primary" %}} 

Al igual que en los temas anteriores, este también trata sobre añadir una forma y, en esta ocasión, la forma de la que hablaremos es **Rectangle**. En este tema, hemos descrito cómo los desarrolladores pueden añadir rectángulos simples o con formato a sus diapositivas usando Aspose.Slides para Node.js a través de Java.

{{% /alert %}} 

## **Añadir rectángulo a la diapositiva**
Para añadir un rectángulo simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva utilizando su Index.
- Añada un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) de tipo Rectangle usando el método [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido un rectángulo simple a la primera diapositiva de la presentación.
```javascript
// Instanciar la clase Presentation que representa el PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Agregar AutoShape de tipo elipse
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Escribir el archivo PPTX en el disco
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Añadir rectángulo formateado a la diapositiva**
Para añadir un rectángulo con formato a una diapositiva, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva utilizando su Index.
- Añada un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) de tipo Rectangle usando el método [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Establezca el [Fill Type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillType) del Rectangle a Solid.
- Establezca el Color del Rectangle usando [SolidFillColor.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) como expuesto por el objeto [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat) asociado al objeto [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape).
- Establezca el Color de las líneas del Rectangle.
- Establezca el Ancho de las líneas del Rectangle.
- Guarde la presentación modificada como archivo PPTX.

Los pasos anteriores se implementan en el ejemplo que se muestra a continuación.
```javascript
// Instanciar la clase Presentation que representa el PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Añadir AutoShape de tipo elipse
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Aplicar algo de formato a la forma elipse
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // Aplicar algo de formato a la línea de la elipse
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Guardar el archivo PPTX en disco
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Cómo añado un rectángulo con esquinas redondeadas?**

Utilice el [shape type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/) con esquinas redondeadas y ajuste el radio de la esquina en las propiedades de la forma; el redondeo también puede aplicarse por esquina mediante ajustes de geometría.

**¿Cómo lleno un rectángulo con una imagen (textura)?**

Seleccione el [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), proporcione la fuente de la imagen y configure los [stretching/tiling modes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/).

**¿Puede un rectángulo tener sombra y resplandor?**

Sí. [Outer/inner shadow, glow, and soft edges](/slides/es/nodejs-java/shape-effect/) están disponibles con parámetros ajustables.

**¿Puedo convertir un rectángulo en un botón con un hipervínculo?**

Sí. [Assign a hyperlink](/slides/es/nodejs-java/manage-hyperlinks/) al hacer clic en la forma (ir a una diapositiva, archivo, dirección web o correo electrónico).

**¿Cómo puedo proteger un rectángulo contra movimientos y cambios?**

Utilice bloqueos de forma: puede prohibir mover, cambiar el tamaño, seleccionar o editar texto para preservar el diseño.

**¿Puedo convertir un rectángulo a una imagen raster o SVG?**

Sí. Puede [render the shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) a una imagen con un tamaño/escala especificados o [export it as SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) para uso vectorial.

**¿Cómo obtengo rápidamente las propiedades reales (efectivas) de un rectángulo considerando el tema y la herencia?**

[Use the shape’s effective properties](/slides/es/nodejs-java/shape-effective-properties/): la API devuelve valores calculados que tienen en cuenta los estilos del tema, el diseño y la configuración local, simplificando el análisis de formato.