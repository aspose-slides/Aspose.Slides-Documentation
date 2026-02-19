---
title: Tinta
type: docs
weight: 180
url: /es/net/examples/elements/ink/
keywords:
- tinta
- acceder a tinta
- eliminar tinta
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Trabaje con Tinta en Aspose.Slides for .NET: dibuje, importe y edite trazos, ajuste el color y el ancho, y exporte a PPT, PPTX y ODP usando ejemplos en C#."
---
Este artículo ofrece ejemplos de cómo acceder a formas de tinta existentes y eliminarlas usando **Aspose.Slides for .NET**.

> ❗ **Nota:** Las formas de tinta representan la entrada del usuario procedente de dispositivos especializados. Aspose.Slides no puede crear nuevos trazos de tinta de forma programática, pero puedes leer y modificar la tinta existente.

## **Acceder a la tinta**

Lee las etiquetas de la primera forma de tinta en una diapositiva.

```csharp
static void AccessInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // Utilice tagName según sea necesario.
        }
    }
}
```

## **Eliminar tinta**

Elimina una forma de tinta de la diapositiva si existe.

```csharp
static void RemoveInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```