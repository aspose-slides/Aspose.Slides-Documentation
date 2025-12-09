---
title: Sección
type: docs
weight: 90
url: /es/net/examples/elements/section/
keywords:
- ejemplo de sección
- sección de diapositiva
- agregar sección
- acceder a la sección
- eliminar sección
- renombrar sección
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Administre las secciones de diapositivas en C# con Aspose.Slides: cree, renombre y reordene fácilmente, mueva diapositivas entre secciones y controle la visibilidad para PPT, PPTX y ODP."
---

Ejemplos para administrar secciones de presentación—agregar, acceder, eliminar y renombrar programáticamente usando **Aspose.Slides for .NET**.

## Agregar una sección

Cree una sección que comience en una diapositiva específica.
```csharp
static void Add_Section()
{
    using var pres = new Presentation();

    // Especifique la diapositiva que marca el comienzo de la sección
    pres.Sections.AddSection("New Section", pres.Slides[0]);
}
```


## Acceder a una sección

Lea la información de la sección de una presentación.
```csharp
static void Access_Section()
{
    using var pres = new Presentation();
    pres.Sections.AddSection("My Section", pres.Slides[0]);

    // Acceder a la sección por índice
    var section = pres.Sections[0];
    var sectionName = section.Name;
}
```


## Eliminar una sección

Elimine una sección previamente agregada.
```csharp
static void Remove_Section()
{
    using var pres = new Presentation();
    var section = pres.Sections.AddSection("Temporary Section", pres.Slides[0]);

    // Eliminar la primera sección
    pres.Sections.RemoveSection(section);
}
```


## Renombrar una sección

Cambie el nombre de una sección existente.
```csharp
static void Rename_Section()
{
    using var pres = new Presentation();
    pres.Sections.AddSection("Old Name", pres.Slides[0]);

    var section = pres.Sections[0];
    section.Name = "New Name";
}
```
