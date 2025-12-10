---
title: Agregar rectángulos a presentaciones en Java
linktitle: Rectángulo
type: docs
weight: 80
url: /es/java/rectangle/
keywords:
- añadir rectángulo
- crear rectángulo
- forma de rectángulo
- rectángulo simple
- rectángulo formateado
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Mejore sus presentaciones de PowerPoint añadiendo rectángulos con Aspose.Slides para Java—diseñe y modifique formas fácilmente de forma programática."
---

{{% alert color="primary" %}} 

Al igual que en temas anteriores, este también trata sobre añadir una forma y esta vez la forma de la que hablaremos es **Rectangle**. En este tema, hemos descrito cómo los desarrolladores pueden añadir rectángulos simples o con formato a sus diapositivas usando Aspose.Slides for Java.

{{% /alert %}} 

## **Agregar un Rectangle a una diapositiva**
- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Obtenga la referencia de una diapositiva mediante su índice.
- Agregue un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) de tipo Rectangle usando el método [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido un rectangle simple a la primera diapositiva de la presentación.
```java
// Instanciar la clase Prseetation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Añadir AutoShape de tipo elipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Grabar el archivo PPTX en disco
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Agregar un Rectangle formateado a una diapositiva**
- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Obtenga la referencia de una diapositiva mediante su índice.
- Agregue un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) de tipo Rectangle usando el método [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Establezca el [Fill Type](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) del Rectangle a Solid.
- Establezca el Color del Rectangle usando el método [SolidFillColor.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) expuesto por el objeto [IFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat) asociado al objeto [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape).
- Establezca el Color de las líneas del Rectangle.
- Establezca el Ancho de las líneas del Rectangle.
- Guarde la presentación modificada como un archivo PPTX.

Los pasos anteriores se implementan en el ejemplo que se muestra a continuación.
```java
// Instanciar la clase Prseetation que representa el PPTX
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

    // Grabar el archivo PPTX en disco
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Cómo añado un rectangle con esquinas redondeadas?**

Utilice el [shape type](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/) de esquinas redondeadas y ajuste el radio de la esquina en las propiedades de la forma; el redondeo también puede aplicarse por esquina mediante ajustes de geometría.

**¿Cómo lleno un rectangle con una imagen (textura)?**

Seleccione el [fill type](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) de imagen, proporcione la fuente de la imagen y configure los [modos de estiramiento/encolado](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/).

**¿Puede un rectangle tener sombra y resplandor?**

Sí. [Sombra externa/interna, resplandor y bordes suaves](/slides/es/java/shape-effect/) están disponibles con parámetros ajustables.

**¿Puedo convertir un rectangle en un botón con hipervínculo?**

Sí. [Asigne un hipervínculo](/slides/es/java/manage-hyperlinks/) al clic de la forma (ir a una diapositiva, archivo, dirección web o correo electrónico).

**¿Cómo puedo proteger un rectangle contra moverlo y cambios?**

[Utilice bloqueos de forma](/slides/es/java/applying-protection-to-presentation/): puede prohibir el mover, redimensionar, seleccionar o editar texto para preservar el diseño.

**¿Puedo convertir un rectangle a una imagen raster o SVG?**

Sí. Puede [renderizar la forma](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) a una imagen con un tamaño/escala especificados o [exportarla como SVG](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) para uso vectorial.

**¿Cómo obtengo rápidamente las propiedades reales (efectivas) de un rectangle considerando el tema y la herencia?**

[Utilice las propiedades efectivas de la forma](/slides/es/java/shape-effective-properties/): la API devuelve valores calculados que tienen en cuenta los estilos del tema, el diseño y la configuración local, simplificando el análisis de formato.