---
title: Grupo
type: docs
weight: 40
url: /es/androidjava/group/
---

## **Agregar Forma de Grupo**
Aspose.Slides admite trabajar con formas de grupo en las diapositivas. Esta función ayuda a los desarrolladores a crear presentaciones más ricas. Aspose.Slides para Android a través de Java admite la adición o el acceso a formas de grupo. Es posible agregar formas a una forma de grupo añadida para completarla o acceder a cualquier propiedad de la forma de grupo. Para agregar una forma de grupo a una diapositiva utilizando Aspose.Slides para Android a través de Java:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtener la referencia de una diapositiva utilizando su índice.
1. Agregar una forma de grupo a la diapositiva.
1. Agregar las formas a la forma de grupo añadida.
1. Guardar la presentación modificada como un archivo PPTX.

El siguiente ejemplo agrega una forma de grupo a una diapositiva.

```java
// Instanciar la clase Presentation
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Accediendo a la colección de formas de las diapositivas
    IShapeCollection slideShapes = sld.getShapes();

    // Agregar una forma de grupo a la diapositiva
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Agregar formas dentro de la forma de grupo añadida
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Agregar marco de forma de grupo
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Escribir el archivo PPTX en disco
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Acceder a la Propiedad AltText**
Este tema muestra pasos simples, completos con ejemplos de código, para agregar una forma de grupo y acceder a la propiedad AltText de las formas de grupo en las diapositivas. Para acceder a AltText de una forma de grupo en una diapositiva utilizando Aspose.Slides para Android a través de Java:

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que representa el archivo PPTX.
1. Obtener la referencia de una diapositiva utilizando su índice.
1. Accediendo a la colección de formas de las diapositivas.
1. Accediendo a la forma de grupo.
1. Accediendo a la propiedad [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) .

El siguiente ejemplo accede al texto alternativo de la forma de grupo.

```java
// Instanciar la clase Presentation que representa el archivo PPTX
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