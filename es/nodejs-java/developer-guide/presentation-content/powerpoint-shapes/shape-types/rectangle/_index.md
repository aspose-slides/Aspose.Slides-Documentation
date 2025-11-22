---
title: Rectángulo
type: docs
weight: 80
url: /es/nodejs-java/rectangle/
---

{{% alert color="primary" %}} 

Al igual que los temas anteriores, este también trata sobre agregar una forma y esta vez la forma de la que hablaremos es **Rectangle**. En este tema, hemos descrito cómo los desarrolladores pueden agregar rectángulos simples o con formato a sus diapositivas usando Aspose.Slides para Node.js a través de Java.

{{% /alert %}} 

## **Agregar Rectángulo a la Diapositiva**
Para agregar un rectángulo simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva usando su Índice.
- Añada un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) de tipo Rectangle mediante el método [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Escriba la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos agregado un rectángulo simple a la primera diapositiva de la presentación.
```javascript
// Instanciar la clase Presentation que representa el PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Agregar AutoShape de tipo elipse
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Guardar el archivo PPTX en disco
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Agregar Rectángulo con Formato a la Diapositiva**
Para agregar un rectángulo con formato a una diapositiva, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva usando su Índice.
- Añada un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) de tipo Rectangle mediante el método [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Establezca el [Fill Type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillType) del Rectángulo a Solid.
- Establezca el Color del Rectángulo usando [SolidFillColor.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) como expone el objeto [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat) asociado al objeto [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape).
- Establezca el Color de las líneas del Rectángulo.
- Establezca el Ancho de las líneas del Rectángulo.
- Escriba la presentación modificada como archivo PPTX.

Los pasos anteriores se implementan en el ejemplo que se muestra a continuación.
```javascript
// Instanciar la clase Presentation que representa el PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Agregar AutoShape de tipo elipse
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


## **FAQ**

**¿Cómo agrego un rectángulo con esquinas redondeadas?**

Utilice el [shape type] con esquinas redondeadas y ajuste el radio de la esquina en las propiedades de la forma; el redondeado también puede aplicarse por esquina mediante ajustes de geometría.

**¿Cómo lleno un rectángulo con una imagen (textura)?**

Seleccione el [fill type] de imagen, proporcione la fuente de la imagen y configure los modos de [stretching/tiling] apropiados.

**¿Puede un rectángulo tener sombra y resplandor?**

Sí. [Outer/inner shadow, glow, and soft edges](/slides/es/nodejs-java/shape-effect/) están disponibles con parámetros ajustables.

**¿Puedo convertir un rectángulo en un botón con un hipervínculo?**

Sí. [Assign a hyperlink](/slides/es/nodejs-java/manage-hyperlinks/) a la forma al hacer clic (salto a una diapositiva, archivo, dirección web o correo electrónico).

**¿Cómo puedo proteger un rectángulo contra movimiento y cambios?**

[Use shape locks](/slides/es/nodejs-java/applying-protection-to-presentation/): puede impedir mover, redimensionar, seleccionar o editar texto para preservar el diseño.

**¿Puedo convertir un rectángulo a una imagen raster o SVG?**

Sí. Puede [render the shape] a una imagen con un tamaño/escala especificados o [export it as SVG] para uso vectorial.

**¿Cómo obtengo rápidamente las propiedades reales (efectivas) de un rectángulo considerando el tema y la herencia?**

[Use the shape’s effective properties](/slides/es/nodejs-java/shape-effective-properties/): la API devuelve valores calculados que tienen en cuenta los estilos del tema, la disposición y la configuración local, simplificando el análisis de formato.