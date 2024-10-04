---
title: Línea
type: docs
weight: 50
url: /es/java/Line/
---


{{% alert color="primary" %}} 

Aspose.Slides para Java admite la adición de diferentes tipos de formas a las diapositivas. En este tema, comenzaremos a trabajar con formas añadiendo líneas a las diapositivas. Al utilizar Aspose.Slides para Java, los desarrolladores no solo pueden crear líneas simples, sino que también se pueden dibujar líneas más elaboradas en las diapositivas.

{{% /alert %}} 

## **Crear Línea Simple**

Para añadir una línea simple y recta a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Añada una AutoShape de tipo Línea utilizando el método [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Escriba la presentación modificada como un archivo PPTX.

En el ejemplo dado a continuación, hemos añadido una línea a la primera diapositiva de la presentación.

```java
// Instanciar la clase PresentationEx que representa el archivo PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Añadir una AutoShape de tipo línea
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Escribir el PPTX en el disco
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Crear Línea en Forma de Flecha**

Aspose.Slides para Java también permite a los desarrolladores configurar algunas propiedades de la línea para hacerla más atractiva. Intentemos configurar algunas propiedades de una línea para que se parezca a una flecha. Siga los pasos a continuación para hacerlo:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Añada una AutoShape de tipo Línea utilizando el método [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Establezca el [Estilo de Línea](https://reference.aspose.com/slides/java/com.aspose.slides/LineStyle) en uno de los estilos ofrecidos por Aspose.Slides para Java.
- Establezca el ancho de la línea.
- Establezca el [Estilo de Guion](https://reference.aspose.com/slides/java/com.aspose.slides/LineDashStyle) de la línea en uno de los estilos ofrecidos por Aspose.Slides para Java.
- Establezca el [Estilo de Cabeza de Flecha](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) y la [Longitud](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength) del punto de inicio de la línea.
- Establezca el [Estilo de Cabeza de Flecha](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) y la [Longitud](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength) del punto final de la línea.
- Escriba la presentación modificada como un archivo PPTX.

```java
// Instanciar la clase PresentationEx que representa el archivo PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Añadir una AutoShape de tipo línea
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Aplicar algún formato a la línea
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Escribir el PPTX en el disco
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```