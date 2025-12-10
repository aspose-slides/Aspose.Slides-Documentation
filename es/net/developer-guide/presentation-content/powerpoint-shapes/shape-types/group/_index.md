---
title: Formas de presentación en grupo en .NET
linktitle: Grupo de formas
type: docs
weight: 40
url: /es/net/group/
keywords:
- forma de grupo
- grupo de formas
- agregar grupo
- texto alternativo
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a agrupar y desagrupar formas en presentaciones de PowerPoint usando Aspose.Slides para .NET: guía rápida, paso a paso, con código C# gratuito."
---

## **Agregar una forma de grupo**
Aspose.Slides admite trabajar con formas de grupo en las diapositivas. Esta funcionalidad ayuda a los desarrolladores a crear presentaciones más ricas. Aspose.Slides para .NET admite agregar o acceder a formas de grupo. Es posible agregar formas a una forma de grupo añadida para completarla o acceder a cualquier propiedad de la forma de grupo. Para agregar una forma de grupo a una diapositiva usando Aspose.Slides para .NET:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtener la referencia de una diapositiva usando su índice.
1. Agregar una forma de grupo a la diapositiva.
1. Agregar las formas a la forma de grupo añadida.
1. Guardar la presentación modificada como un archivo PPTX.

El siguiente ejemplo agrega una forma de grupo a una diapositiva.
```c#
// Instanciar la clase Presentation 
using (Presentation pres = new Presentation())
{
    // Obtener la primera diapositiva 
    ISlide sld = pres.Slides[0];

    // Acceder a la colección de formas de las diapositivas 
    IShapeCollection slideShapes = sld.Shapes;

    // Añadir una forma de grupo a la diapositiva 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Añadir formas dentro de la forma de grupo añadida 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Añadir el marco de la forma de grupo 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // Guardar el archivo PPTX en disco 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```


## **Acceder a la propiedad AltText**
Este tema muestra pasos simples, con ejemplos de código, para agregar una forma de grupo y acceder a la propiedad AltText de las formas de grupo en las diapositivas. Para acceder al AltText de una forma de grupo en una diapositiva usando Aspose.Slides para .NET:

1. Instanciar la clase `Presentation` que representa un archivo PPTX.
1. Obtener la referencia de una diapositiva usando su índice.
1. Acceder a la colección de formas de las diapositivas.
1. Acceder a la forma de grupo.
1. Acceder a la propiedad AltText.

El siguiente ejemplo accede al texto alternativo de la forma de grupo.
```c#
// Instanciar la clase Presentation que representa el archivo PPTX
Presentation pres = new Presentation("AltText.pptx");

// Obtener la primera diapositiva
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // Accediendo a la colección de formas de las diapositivas
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // Accediendo a la forma de grupo.
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // Accediendo a la propiedad AltText
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```


## **Preguntas frecuentes**

**¿Se admite la agrupación anidada (un grupo dentro de otro grupo)?**

Sí. [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) tiene una propiedad [ParentGroup](https://reference.aspose.com/slides/net/aspose.slides/shape/parentgroup/), que indica directamente el soporte de jerarquía (un grupo puede ser hijo de otro grupo).

**¿Cómo controlo el orden Z del grupo en relación con otros objetos en la diapositiva?**

Utilice la propiedad [ZOrderPosition](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) del [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) para inspeccionar su posición en la pila de visualización.

**¿Puedo impedir mover/editar/desagrupar?**

Sí. La sección de bloqueo del grupo se expone mediante [GroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/groupshape/groupshapelock/), lo que le permite restringir operaciones sobre el objeto.