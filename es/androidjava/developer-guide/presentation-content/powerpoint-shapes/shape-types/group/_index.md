---
title: Formas de presentación grupales en Android
linktitle: Grupo de formas
type: docs
weight: 40
url: /es/androidjava/group/
keywords:
- forma de grupo
- grupo de formas
- agregar grupo
- texto alternativo
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda a agrupar y desagrupar formas en presentaciones de PowerPoint usando Aspose.Slides para Android: guía rápida paso a paso con código Java gratuito."
---

## **Agregar una forma de grupo**
Aspose.Slides admite el trabajo con formas de grupo en diapositivas. Esta característica ayuda a los desarrolladores a crear presentaciones más ricas. Aspose.Slides for Android via Java admite agregar o acceder a formas de grupo. Es posible agregar formas a una forma de grupo añadida para completarla o acceder a cualquier propiedad de la forma de grupo. Para agregar una forma de grupo a una diapositiva usando Aspose.Slides for Android via Java:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtenga la referencia de una diapositiva usando su índice
1. Agregue una forma de grupo a la diapositiva.
1. Agregue las formas a la forma de grupo añadida.
1. Guarde la presentación modificada como un archivo PPTX.

El ejemplo a continuación agrega una forma de grupo a una diapositiva.
```java
// Instanciar la clase Presentation
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Accediendo a la colección de formas de las diapositivas
    IShapeCollection slideShapes = sld.getShapes();

    // Añadiendo una forma de grupo a la diapositiva
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Añadiendo formas dentro del grupo añadido
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Añadiendo el marco del grupo de forma
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Guardar el archivo PPTX en disco
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Acceder a la propiedad AltText**
Este tema muestra pasos simples, con ejemplos de código, para agregar una forma de grupo y acceder a la propiedad AltText de las formas de grupo en diapositivas. Para acceder a AltText de una forma de grupo en una diapositiva usando Aspose.Slides for Android via Java:

1. Instancie la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que representa un archivo PPTX.
1. Obtenga la referencia de una diapositiva usando su índice.
1. Acceda a la colección de formas de las diapositivas.
1. Acceda a la forma de grupo.
1. Acceda a la propiedad [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--).

El ejemplo a continuación accede al texto alternativo de la forma de grupo.
```java
// Instanciar la clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation("AltText.pptx");
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Accediendo a la colección de formas de las diapositivas
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Accediendo a la forma de grupo.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // Accediendo a la propiedad AltText
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Se admite la agrupación anidada (un grupo dentro de otro grupo)?**

Sí. [GroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/) tiene un método [getParentGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getParentGroup--) que indica directamente el soporte de jerarquía (un grupo puede ser hijo de otro grupo).

**¿Cómo controlo el orden Z del grupo en relación con otros objetos en la diapositiva?**

Utilice el método [getZOrderPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getZOrderPosition--) de [GroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/) para inspeccionar su posición en la pila de visualización.

**¿Puedo evitar mover/editar/desagrupar?**

Sí. La sección de bloqueo del grupo se expone mediante [getGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/#getGroupShapeLock--), lo que le permite restringir operaciones sobre el objeto.