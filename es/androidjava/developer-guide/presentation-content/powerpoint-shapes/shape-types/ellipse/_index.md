---
title: Elipse
type: docs
weight: 30
url: /androidjava/ellipse/
---


{{% alert color="primary" %}} 

En este tema, presentaremos a los desarrolladores cómo agregar formas de elipse a sus diapositivas utilizando Aspose.Slides para Android a través de Java. Aspose.Slides para Android a través de Java proporciona un conjunto más fácil de API para dibujar diferentes tipos de formas con solo unas pocas líneas de código.

{{% /alert %}} 

## **Crear Elipse**
Para agregar una elipse simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Obtener la referencia de una diapositiva utilizando su índice.
- Agregar una forma automática de tipo Elipse utilizando el método [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Escribir la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos agregado una elipse a la primera diapositiva.

```java
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Agregar forma automática de tipo elipse
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Escribir el archivo PPTX en el disco
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Crear Elipse Formateada**
Para agregar una elipse mejor formateada a una diapositiva, siga los pasos a continuación:

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Obtener la referencia de una diapositiva utilizando su índice.
- Agregar una forma automática de tipo Elipse utilizando el método [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Establecer el tipo de relleno de la elipse a Sólido.
- Establecer el color de la elipse utilizando la propiedad SolidFillColor.Color como se expone en el objeto [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat) asociado al objeto [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape).
- Establecer el color de las líneas de la elipse.
- Establecer el ancho de las líneas de la elipse.
- Escribir la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos agregado una elipse formateada a la primera diapositiva de la presentación.

```java
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Agregar forma automática de tipo elipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Aplicar algún formato a la forma de elipse
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Aplicar algún formato a la línea de la elipse
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Escribir el archivo PPTX en el disco
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```