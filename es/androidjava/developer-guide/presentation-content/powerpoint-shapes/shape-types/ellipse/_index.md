---
title: Agregar elipses a presentaciones en Android
linktitle: Elipse
type: docs
weight: 30
url: /es/androidjava/ellipse/
keywords:
- elipse
- forma
- agregar elipse
- crear elipse
- dibujar elipse
- elipse formateada
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda cómo crear, formatear y manipular formas de elipse en Aspose.Slides para Android en presentaciones PPT y PPTX, con ejemplos de código Java incluidos."
---

{{% alert color="primary" %}} 
En este tema, presentaremos a los desarrolladores la forma de agregar formas elípticas a sus diapositivas usando Aspose.Slides para Android mediante Java. Aspose.Slides para Android mediante Java proporciona un conjunto más sencillo de API para dibujar diferentes tipos de formas con solo unas pocas líneas de código.
{{% /alert %}} 

## **Crear una elipse**
Para agregar una elipse simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Obtenga la referencia de una diapositiva usando su índice.
- Agregue un AutoShape de tipo Elipse usando el método [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos agregado una elipse a la primera diapositiva
```java
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Agregar AutoShape de tipo elipse
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Guardar el archivo PPTX en disco
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Crear una elipse formateada**
Para agregar una elipse mejor formateada a una diapositiva, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Obtenga la referencia de una diapositiva usando su índice.
- Agregue un AutoShape de tipo Elipse usando el método [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Establezca el tipo de relleno de la elipse a sólido.
- Establezca el color de la elipse usando la propiedad SolidFillColor.Color expuesta por el objeto [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat) asociado con el objeto [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape).
- Establezca el color de las líneas de la elipse.
- Establezca el ancho de las líneas de la elipse.
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos agregado una elipse formateada a la primera diapositiva de la presentación.
```java
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Agregar AutoShape de tipo elipse
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

Las coordenadas y tamaños suelen especificarse **en puntos**. Para obtener resultados predecibles, base sus cálculos en el tamaño de la diapositiva y convierta los milímetros o pulgadas requeridos a puntos antes de asignar los valores.

**¿Cómo puedo colocar una elipse encima o debajo de otros objetos (controlar el orden de apilamiento)?**

Ajuste el orden de dibujo del objeto llevándolo al frente o enviándolo al fondo. Esto permite que la elipse se superponga a otros objetos o revele los que están debajo.

**¿Cómo animo la aparición o énfasis de una elipse?**

[Apply](/slides/es/androidjava/shape-animation/) efectos de entrada, énfasis o salida a la forma, y configure disparadores y tiempos para orquestar cuándo y cómo se reproduce la animación.