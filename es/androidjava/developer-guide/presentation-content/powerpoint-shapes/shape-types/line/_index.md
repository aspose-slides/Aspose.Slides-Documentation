---
title: Agregar formas de línea a presentaciones en Android
linktitle: Línea
type: docs
weight: 50
url: /es/androidjava/Line/
keywords:
- línea
- crear línea
- agregar línea
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
description: "Aprenda a manipular el formato de líneas en presentaciones PowerPoint con Aspose.Slides para Android. Descubra propiedades, métodos y ejemplos en Java."
---

{{% alert color="primary" %}} 

Aspose.Slides for Android via Java admite agregar diferentes tipos de formas a las diapositivas. En este tema, comenzaremos a trabajar con formas agregando líneas a las diapositivas. Con Aspose.Slides for Android via Java, los desarrolladores pueden no solo crear líneas simples, sino también dibujar algunas líneas elegantes en las diapositivas.

{{% /alert %}} 

## **Crear una línea simple**

Para agregar una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva usando su índice.
- Agregue un AutoShape de tipo Línea usando el método [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Grabe la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, hemos agregado una línea a la primera diapositiva de la presentación.
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

Aspose.Slides for Android via Java también permite a los desarrolladores configurar algunas propiedades de la línea para que se vea más atractiva. Intentemos configurar algunas propiedades de una línea para que tenga forma de flecha. Por favor, siga los pasos a continuación para hacerlo:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva usando su índice.
- Agregue un AutoShape de tipo Línea usando el método [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Establezca el [Line Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) a uno de los estilos ofrecidos por Aspose.Slides for Android via Java.
- Establezca el ancho de la línea.
- Establezca el [Dash Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) de la línea a uno de los estilos ofrecidos por Aspose.Slides for Android via Java.
- Establezca el [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) y la [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) del punto inicial de la línea.
- Establezca el [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) y la [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) del punto final de la línea.
- Grabe la presentación modificada como un archivo PPTX.
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

**¿Puedo convertir una línea regular en un conector para que se "ajuste" a las formas?**

No. Una línea regular (un [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/) de tipo [Line](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/)) no se convierte automáticamente en un conector. Para que se ajuste a las formas, utilice el tipo [Connector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/connector/) dedicado y las [APIs correspondientes](/slides/es/androidjava/connector/) para conexiones.

**¿Qué debo hacer si las propiedades de una línea son heredadas del tema y es difícil determinar los valores finales?**

Lea las [propiedades efectivas](/slides/es/androidjava/shape-effective-properties/) a través de las interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilinefillformateffectivedata/); estas ya tienen en cuenta la herencia y los estilos del tema.

**¿Puedo bloquear una línea contra la edición (mover, cambiar tamaño)?**

Sí. Las formas ofrecen [lock objects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) que le permiten [denegar operaciones de edición](/slides/es/androidjava/applying-protection-to-presentation/).