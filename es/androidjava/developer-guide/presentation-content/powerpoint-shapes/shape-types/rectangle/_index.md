---
title: Agregar rectángulos a presentaciones en Android
linktitle: Rectángulo
type: docs
weight: 80
url: /es/androidjava/rectangle/
keywords:
- agregar rectángulo
- crear rectángulo
- forma de rectángulo
- rectángulo simple
- rectángulo formateado
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Impulsa tus presentaciones de PowerPoint añadiendo rectángulos con Aspose.Slides para Android mediante Java—diseña y modifica formas programáticamente con facilidad."
---

{{% alert color="primary" %}} 

Al igual que los temas anteriores, este también trata sobre agregar una forma y esta vez la forma de la que hablaremos es **Rectangle**. En este tema, hemos descrito cómo los desarrolladores pueden agregar rectángulos simples o formateados a sus diapositivas usando Aspose.Slides para Android con Java.

{{% /alert %}} 

## **Agregar un rectángulo a una diapositiva**
Para agregar un rectángulo simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Obtenga la referencia de una diapositiva usando su índice.
- Agregue un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) de tipo Rectangle usando el método [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos agregado un rectángulo simple a la primera diapositiva de la presentación.
```java
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Agregar AutoShape de tipo elipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Guardar el archivo PPTX en disco
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Agregar un rectángulo formateado a una diapositiva**
Para agregar un rectángulo formateado a una diapositiva, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Obtenga la referencia de una diapositiva usando su índice.
- Agregue un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) de tipo Rectangle usando el método [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Establezca el [Fill Type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) del rectángulo a Solid.
- Establezca el color del rectángulo usando el método [SolidFillColor.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) expuesto por el objeto [IFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat) asociado al objeto [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape).
- Establezca el color de las líneas del rectángulo.
- Establezca el ancho de las líneas del rectángulo.
- Guarde la presentación modificada como un archivo PPTX.

Los pasos anteriores se implementan en el ejemplo que se muestra a continuación.
```java
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Agregar AutoShape de tipo elipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Aplicar formato a la forma elipse
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Aplicar formato a la línea de la elipse
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Guardar el archivo PPTX en disco
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Cómo agrego un rectángulo con esquinas redondeadas?**

Utilice el [shape type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/) de esquina redondeada y ajuste el radio de la esquina en las propiedades de la forma; el redondeado también puede aplicarse por esquina mediante ajustes de geometría.

**¿Cómo relleno un rectángulo con una imagen (textura)?**

Seleccione el [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) de imagen, proporcione la fuente de la imagen y configure los [stretching/tiling modes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/).

**¿Puede un rectángulo tener sombra y resplandor?**

Sí. [Outer/inner shadow, glow, and soft edges](/slides/es/androidjava/shape-effect/) están disponibles con parámetros ajustables.

**¿Puedo convertir un rectángulo en un botón con un hipervínculo?**

Sí. [Assign a hyperlink](/slides/es/androidjava/manage-hyperlinks/) al hacer clic en la forma (saltar a una diapositiva, archivo, dirección web o correo electrónico).

**¿Cómo puedo proteger un rectángulo contra movimientos y cambios?**

[Use shape locks](/slides/es/androidjava/applying-protection-to-presentation/): puede prohibir mover, redimensionar, seleccionar o editar texto para preservar el diseño.

**¿Puedo convertir un rectángulo a una imagen raster o SVG?**

Sí. Puede [render the shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) a una imagen con un tamaño/escala especificados o [export it as SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) para uso vectorial.

**¿Cómo obtengo rápidamente las propiedades reales (efectivas) de un rectángulo considerando el tema y la herencia?**

[Use the shape’s effective properties](/slides/es/androidjava/shape-effective-properties/): la API devuelve valores calculados que tienen en cuenta los estilos del tema, el diseño y la configuración local, simplificando el análisis de formato.