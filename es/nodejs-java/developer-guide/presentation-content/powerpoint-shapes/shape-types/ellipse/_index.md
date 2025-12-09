---
title: Elipse
type: docs
weight: 30
url: /es/nodejs-java/ellipse/
---

{{% alert color="primary" %}} 

En este tema, presentaremos a los desarrolladores cómo agregar formas de elipse a sus diapositivas usando Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java ofrece un conjunto de API más sencillo para dibujar diferentes tipos de formas con solo unas pocas líneas de código.

{{% /alert %}} 

## **Crear elipse**
Para agregar una elipse simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva usando su índice.
- Agregue un AutoShape de tipo Ellipse usando el método [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, hemos agregado una elipse a la primera diapositiva
```javascript
// Instanciar la clase Presentation que representa el PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Añadir AutoShape de tipo elipse
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Guardar el archivo PPTX en disco
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Crear elipse con formato**
Para agregar una elipse mejor formateada a una diapositiva, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva usando su índice.
- Agregue un AutoShape de tipo Ellipse usando el método [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Establezca el tipo de relleno de la elipse a sólido.
- Establezca el color de la elipse usando la propiedad SolidFillColor.Color expuesta por el objeto [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat) asociado al objeto [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape).
- Establezca el color de las líneas de la elipse.
- Establezca el ancho de las líneas de la elipse.
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, hemos agregado una elipse con formato a la primera diapositiva de la presentación.
```javascript
// Instanciar la clase Presentation que representa el PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Añadir AutoShape de tipo elipse
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Aplicar algo de formato a la forma elipse
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // Aplicar algo de formato a la línea de la elipse
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Guardar el archivo PPTX en disco
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

 
## **Preguntas frecuentes**

**¿Cómo establecer la posición exacta y el tamaño de una elipse respecto a las unidades de la diapositiva?**

Las coordenadas y tamaños se especifican típicamente **en puntos**. Para obtener resultados predecibles, base sus cálculos en el tamaño de la diapositiva y convierta los milímetros o pulgadas requeridos a puntos antes de asignar los valores.

**¿Cómo puedo colocar una elipse encima o debajo de otros objetos (controlar el orden de apilamiento)?**

Ajuste el orden de dibujo del objeto llevándolo al frente o enviándolo al fondo. Esto permite que la elipse se superponga a otros objetos o revele los que están debajo de ella.

**¿Cómo animar la aparición o énfasis de una elipse?**

[Apply](/slides/es/nodejs-java/shape-animation/) efectos de entrada, énfasis o salida a la forma, y configure disparadores y temporización para orquestar cuándo y cómo se reproduce la animación.