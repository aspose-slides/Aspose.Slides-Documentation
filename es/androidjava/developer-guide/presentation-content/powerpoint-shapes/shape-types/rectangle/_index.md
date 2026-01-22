---
title: Añadir rectángulos a presentaciones en Android
linktitle: Rectángulo
type: docs
weight: 80
url: /es/androidjava/rectangle/
keywords:
- añadir rectángulo
- crear rectángulo
- forma de rectángulo
- rectángulo sencillo
- rectángulo con formato
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Mejora tus presentaciones de PowerPoint añadiendo rectángulos con Aspose.Slides para Android mediante Java: diseña y modifica formas fácilmente de forma programática."
---

{{% alert color="primary" %}} 

Al igual que en temas anteriores, este también trata sobre añadir una forma y en esta ocasión la forma de la que hablaremos es **Rectangle**. En este tema hemos descrito cómo los desarrolladores pueden añadir rectángulos simples o con formato a sus diapositivas usando Aspose.Slides para Android a través de Java.

{{% /alert %}} 

## **Añadir un Rectangle a una diapositiva**
Para añadir un rectángulo simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Obtenga la referencia de una diapositiva mediante su índice.
- Añada un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) de tipo Rectangle mediante el método [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido un rectángulo simple a la primera diapositiva de la presentación.
```java
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Añadir AutoShape de tipo elipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Escribir el archivo PPTX en disco
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Añadir un Rectangle con formato a una diapositiva**
Para añadir un rectangle con formato a una diapositiva, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Obtenga la referencia de una diapositiva mediante su índice.
- Añada un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) de tipo Rectangle mediante el método [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Establezca el [Fill Type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) del Rectangle a Solid.
- Establezca el color del Rectangle mediante el método [SolidFillColor.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) expuesto por el objeto [IFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat) asociado al objeto [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape).
- Establezca el color de las líneas del Rectangle.
- Establezca el ancho de las líneas del Rectangle.
- Guarde la presentación modificada como PPTX file.

Los pasos anteriores se implementan en el ejemplo que se muestra a continuación.
```java
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Añadir AutoShape de tipo elipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Aplicar algo de formato a la forma elipse
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Aplicar algo de formato a la línea del elipse
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Escribir el archivo PPTX en disco
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Cómo añado un rectangle con esquinas redondeadas?**

Utilice el [shape type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/) de esquinas redondeadas y ajuste el radio de la esquina en las propiedades de la forma; el redondeo también puede aplicarse por esquina mediante ajustes de geometría.

**¿Cómo relleno un rectangle con una imagen (textura)?**

Seleccione el [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) de imagen, proporcione la fuente de la imagen y configure los [modos de estiramiento/azulejo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/).

**¿Puede un rectangle tener sombra y resplandor?**

Sí. [Outer/inner shadow, glow, and soft edges](/slides/es/androidjava/shape-effect/) están disponibles con parámetros ajustables.

**¿Puedo convertir un rectangle en un botón con un hipervínculo?**

Sí. [Assign a hyperlink](/slides/es/androidjava/manage-hyperlinks/) al hacer clic en la forma (ir a una diapositiva, archivo, dirección web o correo electrónico).

**¿Cómo puedo proteger un rectangle contra movimientos y cambios?**

Utilice bloqueos de forma: puede prohibir mover, redimensionar, seleccionar o editar texto para preservar el diseño.

**¿Puedo convertir un rectangle a una imagen raster o SVG?**

Sí. Puede [render the shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) a una imagen con un tamaño/escala especificados o [export it as SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) para uso vectorial.

**¿Cómo obtengo rápidamente las propiedades reales (efectivas) de un rectangle considerando el tema y la herencia?**

[Use the shape’s effective properties](/slides/es/androidjava/shape-effective-properties/): la API devuelve valores calculados que tienen en cuenta los estilos del tema, el diseño y la configuración local, simplificando el análisis de formato.