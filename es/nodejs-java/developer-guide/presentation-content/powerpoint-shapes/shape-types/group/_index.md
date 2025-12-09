---
title: Grupo
type: docs
weight: 40
url: /es/nodejs-java/group/
---

## **Agregar forma de grupo**
Aspose.Slides admite el trabajo con formas de grupo en diapositivas. Esta función ayuda a los desarrolladores a crear presentaciones más ricas. Aspose.Slides para Node.js a través de Java permite agregar o acceder a formas de grupo. Es posible añadir formas a una forma de grupo creada para completarla o acceder a cualquier propiedad de la forma de grupo. Para agregar una forma de grupo a una diapositiva usando Aspose.Slides para Node.js a través de Java:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Obtenga la referencia de una diapositiva usando su índice
1. Agregue una forma de grupo a la diapositiva.
1. Agregue las formas a la forma de grupo añadida.
1. Guarde la presentación modificada como un archivo PPTX.

El ejemplo a continuación agrega una forma de grupo a una diapositiva.
```javascript
// Instanciar la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Acceder a la colección de formas de las diapositivas
    var slideShapes = sld.getShapes();
    // Añadir una forma de grupo a la diapositiva
    var groupShape = slideShapes.addGroupShape();
    // Añadir formas dentro de la forma de grupo añadida
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // Añadir el marco de la forma de grupo
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // Escribir el archivo PPTX en disco
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Acceder a la propiedad AltText**
Este tema muestra pasos simples, completos con ejemplos de código, para agregar una forma de grupo y acceder a la propiedad AltText de las formas de grupo en diapositivas. Para acceder al AltText de una forma de grupo en una diapositiva usando Aspose.Slides para Node.js a través de Java:

1. Instancie la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) que representa un archivo PPTX.
1. Obtenga la referencia de una diapositiva usando su índice.
1. Acceda a la colección de formas de las diapositivas.
1. Acceda a la forma de grupo.
1. Llame a la propiedad [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getAlternativeText--) .

El ejemplo a continuación accede al texto alternativo de la forma de grupo.
```javascript
// Instanciar la clase Presentation que representa el archivo PPTX
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // Obtener la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // Acceder a la colección de formas de las diapositivas
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // Accediendo a la forma de grupo.
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // Accediendo a la propiedad AltText
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**¿Se admite la agrupación anidada (un grupo dentro de otro grupo)?**

Sí. [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/) tiene un método [getParentGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getparentgroup/) que indica directamente el soporte de jerarquía (un grupo puede ser hijo de otro grupo).

**¿Cómo controlo el orden Z del grupo en relación con otros objetos en la diapositiva?**

Use el método [getZOrderPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getzorderposition/) de [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/) para inspeccionar su posición en la pila de visualización.

**¿Puedo evitar mover/editar/desagrupar?**

Sí. La sección de bloqueo del grupo se expone a través de [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/getgroupshapelock/), que le permite restringir operaciones sobre el objeto.