---
title: Section
type: docs
weight: 90
url: /fr/net/examples/elements/section/
keywords:
- exemple de section
- section de diapositive
- ajouter une section
- accès à la section
- supprimer une section
- renommer une section
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Gérez les sections de diapositives en C# avec Aspose.Slides : créez, renommez, réorganisez facilement, déplacez les diapositives entre les sections et contrôlez la visibilité pour PPT, PPTX et ODP."
---

Exemples de gestion des sections de présentation — ajouter, accéder, supprimer et renommer programmatique ment à l’aide d’**Aspose.Slides for .NET**.

## **Ajouter une section**

Créer une section qui commence à une diapositive spécifique.
```csharp
static void Add_Section()
{
    using var pres = new Presentation();

    // Spécifiez la diapositive qui marque le début de la section
    pres.Sections.AddSection("New Section", pres.Slides[0]);
}
```


## **Accéder à une section**

Lire les informations de la section d’une présentation.
```csharp
static void Access_Section()
{
    using var pres = new Presentation();
    pres.Sections.AddSection("My Section", pres.Slides[0]);

    // Accéder à la section par index
    var section = pres.Sections[0];
    var sectionName = section.Name;
}
```


## **Supprimer une section**

Supprimer une section ajoutée précédemment.
```csharp
static void Remove_Section()
{
    using var pres = new Presentation();
    var section = pres.Sections.AddSection("Temporary Section", pres.Slides[0]);

    // Supprimer la première section
    pres.Sections.RemoveSection(section);
}
```


## **Renommer une section**

Modifier le nom d’une section existante.
```csharp
static void Rename_Section()
{
    using var pres = new Presentation();
    pres.Sections.AddSection("Old Name", pres.Slides[0]);

    var section = pres.Sections[0];
    section.Name = "New Name";
}
```
