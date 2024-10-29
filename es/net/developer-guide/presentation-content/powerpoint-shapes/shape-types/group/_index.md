---
title: Grupo
type: docs
weight: 40
url: /es/net/group/
keywords: "Forma de grupo, forma de PowerPoint, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Agregar forma de grupo a la presentación de PowerPoint en C# o .NET"
---

## **Agregar Forma de Grupo**
Aspose.Slides admite trabajar con formas de grupo en las diapositivas. Esta función ayuda a los desarrolladores a crear presentaciones más ricas. Aspose.Slides para .NET admite la adición o acceso a formas de grupo. Es posible agregar formas a una forma de grupo añadida para poblarla o acceder a cualquier propiedad de la forma de grupo. Para agregar una forma de grupo a una diapositiva usando Aspose.Slides para .NET:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. Agregue una forma de grupo a la diapositiva.
1. Agregue las formas a la forma de grupo añadida.
1. Guarde la presentación modificada como un archivo PPTX.

El siguiente ejemplo agrega una forma de grupo a una diapositiva.

```c#
// Instanciar la clase Prseetation 
using (Presentation pres = new Presentation())
{
    // Obtener la primera diapositiva 
    ISlide sld = pres.Slides[0];

    // Accediendo a la colección de formas de las diapositivas 
    IShapeCollection slideShapes = sld.Shapes;

    // Agregando una forma de grupo a la diapositiva 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Agregando formas dentro de la forma de grupo añadida 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Agregando marco de la forma de grupo 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // Escribir el archivo PPTX en el disco 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```



## **Acceder a la Propiedad AltText**
Este tema muestra pasos simples, completos con ejemplos de código, para agregar una forma de grupo y acceder a la propiedad AltText de las formas de grupo en las diapositivas. Para acceder a AltText de una forma de grupo en una diapositiva usando Aspose.Slides para .NET:

1. Instanciar la clase `Presentation` que representa el archivo PPTX.
1. Obtener la referencia de una diapositiva utilizando su índice.
1. Accediendo a la colección de formas de las diapositivas.
1. Accediendo a la forma de grupo.
1. Accediendo a la propiedad AltText.

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