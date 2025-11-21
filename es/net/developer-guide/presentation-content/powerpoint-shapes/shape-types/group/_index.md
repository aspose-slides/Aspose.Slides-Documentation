---
title: Formas de presentación en grupo en .NET
linktitle: Grupo de formas
type: docs
weight: 40
url: /es/net/group/
keywords:
- forma de grupo
- grupo de forma
- agregar grupo
- texto alternativo
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a agrupar y desagrupar formas en presentaciones de PowerPoint usando Aspose.Slides para .NET—guía rápida paso a paso con código C# gratuito."
---

## **Agregar forma de grupo**
Aspose.Slides admite trabajar con formas de grupo en diapositivas. Esta característica ayuda a los desarrolladores a crear presentaciones más ricas. Aspose.Slides para .NET permite agregar o acceder a formas de grupo. Es posible agregar formas a una forma de grupo añadida para poblarla o acceder a cualquier propiedad de la forma de grupo. Para agregar una forma de grupo a una diapositiva usando Aspose.Slides para .NET:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenga la referencia de una diapositiva usando su índice
1. Agregue una forma de grupo a la diapositiva.
1. Agregue las formas a la forma de grupo añadida.
1. Guarde la presentación modificada como un archivo PPTX.

El ejemplo a continuación agrega una forma de grupo a una diapositiva.
```c#
// Instanciar la clase Presentation 
using (Presentation pres = new Presentation())
{
    // Obtener la primera diapositiva 
    ISlide sld = pres.Slides[0];

    // Accediendo a la colección de formas de las diapositivas 
    IShapeCollection slideShapes = sld.Shapes;

    // Añadiendo una forma de grupo a la diapositiva 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Añadiendo formas dentro del grupo añadido 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Añadiendo el marco de la forma de grupo 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // Guardar el archivo PPTX en disco 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```




## **Acceder a la propiedad AltText**
Este tema muestra pasos simples, con ejemplos de código, para agregar una forma de grupo y acceder a la propiedad AltText de las formas de grupo en diapositivas. Para acceder al AltText de una forma de grupo en una diapositiva usando Aspose.Slides para .NET:

1. Instancie la clase `Presentation` que representa un archivo PPTX.
1. Obtenga la referencia de una diapositiva usando su índice.
1. Acceda a la colección de formas de las diapositivas.
1. Acceda a la forma de grupo.
1. Acceda a la propiedad AltText.

El ejemplo a continuación accede al texto alternativo de la forma de grupo.
```c#
// Instanciar la clase Presentation que representa un archivo PPTX
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


## **FAQ**

**¿Se admite la agrupación anidada (un grupo dentro de otro grupo)?**

Sí. [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) tiene una propiedad [ParentGroup](https://reference.aspose.com/slides/net/aspose.slides/shape/parentgroup/) que indica directamente el soporte de jerarquía (un grupo puede ser hijo de otro grupo).

**¿Cómo controlo el orden Z del grupo relativo a otros objetos en la diapositiva?**

Utilice la propiedad [ZOrderPosition](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) del [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) para inspeccionar su posición en la pila de visualización.

**¿Puedo evitar mover/editar/desagrupar?**

Sí. La sección de bloqueo del grupo se expone a través de [GroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/groupshape/groupshapelock/), lo que le permite restringir operaciones sobre el objeto.