---
title: Línea
type: docs
weight: 50
url: /es/androidjava/Line/
---


{{% alert color="primary" %}} 

Aspose.Slides para Android a través de Java soporta la adición de diferentes tipos de formas a las diapositivas. En este tema, comenzaremos a trabajar con formas añadiendo líneas a las diapositivas. Usando Aspose.Slides para Android a través de Java, los desarrolladores pueden no solo crear líneas simples, sino que también se pueden dibujar algunas líneas elegantes en las diapositivas.

{{% /alert %}} 

## **Crear Línea Sencilla**

Para añadir una línea sencilla a una diapositiva seleccionada de la presentación, por favor sigue los pasos a continuación:

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtén la referencia de una diapositiva usando su índice.
- Añade un AutoShape de tipo Línea usando el método [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Escribe la presentación modificada como un archivo PPTX.

En el ejemplo dado a continuación, hemos añadido una línea a la primera diapositiva de la presentación.

```java
// Instanciar la clase PresentationEx que representa el archivo PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Añadir un AutoShape de tipo línea
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Escribir el PPTX en el disco
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Crear Línea con Forma de Flecha**

Aspose.Slides para Android a través de Java también permite a los desarrolladores configurar algunas propiedades de la línea para hacerla más atractiva. Intentemos configurar algunas propiedades de una línea para que se asemeje a una flecha. Por favor sigue los pasos a continuación para hacerlo:

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtén la referencia de una diapositiva usando su índice.
- Añade un AutoShape de tipo Línea usando el método [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Establece el [Estilo de Línea](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) a uno de los estilos ofrecidos por Aspose.Slides para Android a través de Java.
- Establece el ancho de la línea.
- Establece el [Estilo de Guion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) de la línea a uno de los estilos ofrecidos por Aspose.Slides para Android a través de Java.
- Establece el [Estilo de Cabeza de Flecha](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) y [Longitud](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) del punto inicial de la línea.
- Establece el [Estilo de Cabeza de Flecha](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) y [Longitud](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) del punto final de la línea.
- Escribe la presentación modificada como un archivo PPTX.

```java
// Instanciar la clase PresentationEx que representa el archivo PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Añadir un AutoShape de tipo línea
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