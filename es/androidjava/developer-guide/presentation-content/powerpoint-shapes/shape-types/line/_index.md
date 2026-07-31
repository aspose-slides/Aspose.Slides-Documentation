---
title: Agregar formas de línea a presentaciones en Android
linktitle: Línea
type: docs
weight: 50
url: /es/androidjava/line/
keywords:
- línea
- crear línea
- añadir línea
- línea simple
- configurar línea
- personalizar línea
- estilo de guión
- punta de flecha
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda a manipular el formato de líneas en presentaciones de PowerPoint con Aspose.Slides para Android. Descubra propiedades, métodos y ejemplos en Java."
---
## **Descripción general**

Aspose.Slides le permite añadir formas de línea a diapositivas de PowerPoint de forma programática. Este artículo muestra cómo crear una línea simple y cómo personalizar una línea para que aparezca como una flecha.

Aprenderá cómo añadir una forma de línea a una diapositiva, ajustar su apariencia visual y guardar la presentación actualizada. Los ejemplos se centran en ajustes prácticos de formato de línea, como el estilo, el ancho, el patrón de guiones, las opciones de punta de flecha y el color de relleno.

## **Crear una línea simple**

Para añadir una línea simple y plana a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva mediante su índice.
- Agregue un AutoShape de tipo Línea utilizando el método [addAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IShapeCollection).
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido una línea a la primera diapositiva de la presentación.

```java
// Instanciar la clase PresentationEx que representa el archivo PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Añadir un AutoShape de tipo línea
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Guardar el PPTX en disco
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Crear una línea con forma de flecha**

Aspose.Slides para Android mediante Java también permite a los desarrolladores configurar algunas propiedades de la línea para que tenga un aspecto más atractivo. Intentemos configurar algunas propiedades de una línea para que parezca una flecha. Siga los pasos a continuación para hacerlo:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva mediante su índice.
- Agregue un AutoShape de tipo Línea utilizando el método [addAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IShapeCollection).
- Establezca el [Line Style](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/LineStyle) a uno de los estilos ofrecidos por Aspose.Slides para Android mediante Java.
- Establezca el ancho de la línea.
- Establezca el [Dash Style](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/LineDashStyle) de la línea a uno de los estilos ofrecidos por Aspose.Slides para Android mediante Java.
- Establezca el [Arrow Head Style](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/LineArrowheadStyle) y la [Length](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/LineArrowheadLength) del punto de inicio de la línea.
- Establezca el [Arrow Head Style](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/LineArrowheadStyle) y la [Length](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/LineArrowheadLength) del punto final de la línea.
- Guarde la presentación modificada como un archivo PPTX.

```java
// Instanciar la clase PresentationEx que representa el archivo PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Añadir un AutoShape de tipo línea
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

**¿Puedo convertir una línea normal en un conector para que se “ajuste” a las formas?**

No. Una línea normal (un [AutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/autoshape/) de tipo [Line](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/shapetype/)) no se convierte automáticamente en un conector. Para que se ajuste a las formas, utilice el tipo [Connector](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/connector/) dedicado y las [corresponding APIs](/slides/es/androidjava/connector/) para conexiones.

**¿Qué debo hacer si las propiedades de una línea se heredan del tema y resulta difícil determinar los valores finales?**

[Lea las propiedades efectivas](/slides/es/androidjava/shape-effective-properties/) a través de las interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — estas ya tienen en cuenta la herencia y los estilos del tema.

**¿Puedo bloquear una línea para que no se pueda editar (mover, cambiar de tamaño)?**

Sí. Las formas proporcionan [lock objects](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) que permiten impedir operaciones de edición.