---
title: Añadir formas de línea a presentaciones en Java
linktitle: Línea
type: docs
weight: 50
url: /es/java/Line/
keywords:
- línea
- crear línea
- añadir línea
- línea simple
- configurar línea
- personalizar línea
- estilo de guión
- cabeza de flecha
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda a manipular el formato de líneas en presentaciones de PowerPoint con Aspose.Slides para Java. Descubra propiedades, métodos y ejemplos."
---

{{% alert color="primary" %}} 

Aspose.Slides for Java admite la inserción de diferentes tipos de formas en las diapositivas. En este tema, comenzaremos a trabajar con formas añadiendo líneas a las diapositivas. Con Aspose.Slides for Java, los desarrolladores pueden no solo crear líneas simples, sino también dibujar líneas decorativas en las diapositivas.

{{% /alert %}} 

## **Create a Plain Line**

Para agregar una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtenga la referencia de una diapositiva usando su Index.
- Añada un AutoShape de tipo Line usando el método [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido una línea a la primera diapositiva de la presentación.
```java
// Instanciar la clase PresentationEx que representa el archivo PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Agregar un AutoShape de tipo línea
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Guardar el PPTX en disco
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Create an Arrow-Shaped Line**

Aspose.Slides for Java también permite a los desarrolladores configurar algunas propiedades de la línea para que tenga un aspecto más atractivo. Intentemos configurar algunas propiedades de la línea para que parezca una flecha. Siga los pasos a continuación:

- Cree una instancia de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtenga la referencia de una diapositiva usando su Index.
- Añada un AutoShape de tipo Line usando el método [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Establezca el [Line Style](https://reference.aspose.com/slides/java/com.aspose.slides/LineStyle) a uno de los estilos ofrecidos por Aspose.Slides for Java.
- Defina el Width de la línea.
- Establezca el [Dash Style](https://reference.aspose.com/slides/java/com.aspose.slides/LineDashStyle) de la línea a uno de los estilos ofrecidos por Aspose.Slides for Java.
- Establezca el [Arrow Head Style](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) y el [Length](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength) del punto de inicio de la línea.
- Establezca el [Arrow Head Style](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) y el [Length](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength) del punto final de la línea.
- Guarde la presentación modificada como un archivo PPTX.
```java
// Instanciar la clase PresentationEx que representa el archivo PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Agregar un AutoShape de tipo línea
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Aplicar algo de formato a la línea
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Guardar el PPTX en disco
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Can I convert a regular line into a connector so it "snaps" to shapes?**

No. Una línea regular (un [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) de tipo [Line](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/)) no se convierte automáticamente en un conector. Para que se ajuste a las formas, utilice el tipo dedicado [Connector](https://reference.aspose.com/slides/java/com.aspose.slides/connector/) y las [corresponding APIs](/slides/es/java/connector/) para conexiones.

**What should I do if a line’s properties are inherited from the theme and it’s hard to determine the final values?**

[Read the effective properties](/slides/es/java/shape-effective-properties/) a través de las interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ilinefillformateffectivedata/); estas ya tienen en cuenta la herencia y los estilos del tema.

**Can I lock a line against editing (moving, resizing)?**

Sí. Las formas proporcionan [lock objects](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/#getAutoShapeLock--) que permiten [disallow editing operations](/slides/es/java/applying-protection-to-presentation/).