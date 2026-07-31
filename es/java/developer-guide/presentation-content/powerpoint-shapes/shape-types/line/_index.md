---
title: Añadir formas de línea a presentaciones en Java
linktitle: Línea
type: docs
weight: 50
url: /es/java/line/
keywords:
- línea
- crear línea
- añadir línea
- línea simple
- configurar línea
- personalizar línea
- estilo de guiones
- punta de flecha
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda a manipular el formato de líneas en presentaciones de PowerPoint con Aspose.Slides para Java. Descubra propiedades, métodos y ejemplos."
---
## **Visión general**

Aspose.Slides le permite añadir formas de línea a diapositivas de PowerPoint mediante código. Este artículo muestra cómo crear una línea sencilla y cómo personalizar una línea para que aparezca como una flecha.

Aprenderá cómo añadir una forma de línea a una diapositiva, ajustar su aspecto visual y guardar la presentación actualizada. Los ejemplos se centran en configuraciones prácticas de formato de línea, como estilo, ancho, patrón de guiones, opciones de punta de flecha y color de relleno.

## **Crear una línea simple**

Para añadir una línea simple a la diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva mediante su índice.
- Añada una AutoShape de tipo Línea usando el método [addAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/IShapeCollection).
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido una línea a la primera diapositiva de la presentación.

```java
// Instanciar la clase PresentationEx que representa el archivo PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Añadir una AutoShape de tipo línea
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Guardar el PPTX en disco
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Crear una línea con forma de flecha**

Aspose.Slides for Java también permite a los desarrolladores configurar algunas propiedades de la línea para que resulte más atractiva. Vamos a configurar algunas propiedades de una línea para que tenga forma de flecha. Siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva mediante su índice.
- Añada una AutoShape de tipo Línea usando el método [addAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/IShapeCollection).
- Establezca el [Line Style](https://reference.aspose.com/slides/es/java/com.aspose.slides/LineStyle) a uno de los estilos ofrecidos por Aspose.Slides for Java.
- Establezca el ancho de la línea.
- Establezca el [Dash Style](https://reference.aspose.com/slides/es/java/com.aspose.slides/LineDashStyle) de la línea a uno de los estilos ofrecidos por Aspose.Slides for Java.
- Establezca el [Arrow Head Style](https://reference.aspose.com/slides/es/java/com.aspose.slides/LineArrowheadStyle) y la [Length](https://reference.aspose.com/slides/es/java/com.aspose.slides/LineArrowheadLength) del punto de inicio de la línea.
- Establezca el [Arrow Head Style](https://reference.aspose.com/slides/es/java/com.aspose.slides/LineArrowheadStyle) y la [Length](https://reference.aspose.com/slides/es/java/com.aspose.slides/LineArrowheadLength) del punto final de la línea.
- Guarde la presentación modificada como un archivo PPTX.

```java
// Instanciar la clase PresentationEx que representa el archivo PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Añadir una AutoShape de tipo línea
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

## **Preguntas frecuentes**

**¿Puedo convertir una línea normal en un conector para que "se ajuste" a las formas?**

No. Una línea normal (una [AutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/autoshape/) de tipo [Line](https://reference.aspose.com/slides/es/java/com.aspose.slides/shapetype/)) no se convierte automáticamente en un conector. Para que se ajuste a las formas, use el tipo [Connector](https://reference.aspose.com/slides/es/java/com.aspose.slides/connector/) dedicado y las [APIs correspondientes](/slides/es/java/connector/) para conexiones.

**¿Qué debo hacer si las propiedades de una línea se heredan del tema y es difícil determinar los valores finales?**

[Leer las propiedades efectivas](/slides/es/java/shape-effective-properties/) a través de las interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilinefillformateffectivedata/) —estas ya tienen en cuenta la herencia y los estilos del tema.

**¿Puedo bloquear una línea contra la edición (movimiento, redimensionado)?**

Sí. Las formas proporcionan [objetos de bloqueo](https://reference.aspose.com/slides/es/java/com.aspose.slides/autoshape/#getAutoShapeLock--) que le permiten [denegar operaciones de edición](/slides/es/java/applying-protection-to-presentation/).