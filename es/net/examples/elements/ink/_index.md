---
title: Tinta
type: docs
weight: 180
url: /es/net/examples/elements/ink/
keywords:
- ejemplo de tinta
- acceder a tinta
- eliminar tinta
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Maneja tinta digital en diapositivas en C# con Aspose.Slides: agrega trazos de lápiz, edita rutas, establece color y ancho, y exporta los resultados para PowerPoint y OpenDocument."
---

Proporciona ejemplos de acceso a formas de tinta existentes y su eliminación usando **Aspose.Slides for .NET**.

> ❗ **Nota:** Las formas de tinta representan la entrada del usuario desde dispositivos especializados. Aspose.Slides no puede crear nuevos trazos de tinta mediante código, pero puedes leer y modificar la tinta existente.

## **Acceder a la tinta**

Lee las etiquetas de la primera forma de tinta en una diapositiva.
```csharp
static void Access_Ink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // Utilice tagName según sea necesario
        }
    }
}
```


## **Eliminar tinta**

Elimina una forma de tinta de la diapositiva si existe.
```csharp
static void Remove_Ink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```
