---
title: Agregar elipses a presentaciones en Java
linktitle: Elipse
type: docs
weight: 30
url: /es/java/ellipse/
keywords:
- elipse
- forma
- agregar elipse
- crear elipse
- dibujar elipse
- elipse con formato
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda cómo crear, formatear y manipular formas elípticas en Aspose.Slides para Java en presentaciones PPT y PPTX—se incluyen ejemplos de código Java."
---

{{% alert color="primary" %}} 
En este tema, presentaremos a los desarrolladores cómo añadir formas elípticas a sus diapositivas utilizando Aspose.Slides for Java. Aspose.Slides for Java ofrece un conjunto de API más sencillo para dibujar diferentes tipos de formas con solo unas pocas líneas de código.
{{% /alert %}} 

## **Crear una elipse**
Para añadir una elipse sencilla a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentación](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Obtenga la referencia de una diapositiva usando su índice.
- Añada una AutoShape de tipo Elipse mediante el método [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido una elipse a la primera diapositiva
```java
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Añadir AutoShape de tipo elipse
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Guardar el archivo PPTX en disco
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Crear una elipse con formato**
Para añadir una elipse mejor formateada a una diapositiva, siga los pasos a continuación:

- Cree una instancia de la clase [Presentación](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Obtenga la referencia de una diapositiva usando su índice.
- Añada una AutoShape de tipo Elipse mediante el método [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Establezca el tipo de relleno de la elipse a Sólido.
- Defina el color de la elipse mediante la propiedad SolidFillColor.Color del objeto [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat) asociado al objeto [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape).
- Defina el color de las líneas de la elipse.
- Defina el ancho de las líneas de la elipse.
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido una elipse con formato a la primera diapositiva de la presentación.
```java
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Añadir AutoShape de tipo elipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Aplicar algo de formato a la forma elipse
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Aplicar algo de formato a la línea de la elipse
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Guardar el archivo PPTX en disco
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Cómo establezco la posición exacta y el tamaño de una elipse respecto a las unidades de la diapositiva?**

Las coordenadas y tamaños se especifican normalmente **en puntos**. Para obtener resultados predecibles, base sus cálculos en el tamaño de la diapositiva y convierta los milímetros o pulgadas requeridos a puntos antes de asignar los valores.

**¿Cómo puedo colocar una elipse por encima o por debajo de otros objetos (controlar el orden de apilamiento)?**

Ajuste el orden de dibujo del objeto llevándolo al frente o enviándolo al fondo. Esto permite que la elipse se superponga a otros objetos o revele los que están bajo ella.

**¿Cómo animo la aparición o el énfasis de una elipse?**

[Aplicar](/slides/es/java/shape-animation/) efectos de entrada, énfasis o salida a la forma, y configure disparadores y tiempos para orquestar cuándo y cómo se reproduce la animación.