---
title: Sección
type: docs
weight: 90
url: /es/net/examples/elements/section/
keywords:
- sección
- sección de diapositiva
- añadir sección
- acceder sección
- eliminar sección
- renombrar sección
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Gestiona secciones de diapositivas en Aspose.Slides para .NET: crea, renombra, reordena y agrupa diapositivas con ejemplos en C# para PPT, PPTX y ODP."
---
Ejemplos de gestión de secciones de presentación—añadir, acceder, eliminar y renombrar programáticamente usando **Aspose.Slides for .NET**.

## **Agregar una sección**

Crea una sección que comienza en una diapositiva específica.

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Especifica la diapositiva que marca el comienzo de la sección.
    presentation.Sections.AddSection("New Section", slide);
}
```

## **Acceder a una sección**

Lee la información de la sección de una presentación.

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // Accede a una sección por índice.
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **Eliminar una sección**

Elimina una sección añadida previamente.

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // Elimina la primera sección.
    presentation.Sections.RemoveSection(section);
}
```

## **Renombrar una sección**

Cambia el nombre de una sección existente.

```csharp
static void RenameSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("Old Name", slide);

    var section = presentation.Sections[0];
    section.Name = "New Name";
}
```