---
title: Section
type: docs
weight: 90
url: /fr/net/examples/elements/section/
keywords:
- section
- section de diapositive
- ajouter une section
- accéder à la section
- supprimer la section
- renommer la section
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Gérez les sections de diapositives dans Aspose.Slides for .NET : créez, renommez, réorganisez et regroupez les diapositives avec des exemples C# pour PPT, PPTX et ODP."
---
Exemples de gestion des sections de présentation — ajouter, accéder, supprimer et renommer programmaticalement à l'aide de **Aspose.Slides for .NET**.

## **Ajouter une section**

Créez une section qui commence à une diapositive spécifique.

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Spécifiez la diapositive qui marque le début de la section.
    presentation.Sections.AddSection("New Section", slide);
}
```

## **Accéder à une section**

Lisez les informations de section d'une présentation.

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // Accéder à une section par index.
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **Supprimer une section**

Supprimez une section précédemment ajoutée.

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // Supprimez la première section.
    presentation.Sections.RemoveSection(section);
}
```

## **Renommer une section**

Modifiez le nom d'une section existante.

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