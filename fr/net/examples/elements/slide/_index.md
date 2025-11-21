---
title: Diapositive
type: docs
weight: 10
url: /fr/net/examples/elements/slide/
keywords:
- exemple de diapositive
- ajouter une diapositive
- accéder à la diapositive
- index de diapositive
- dupliquer la diapositive
- réorganiser les diapositives
- supprimer la diapositive
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Gérez les diapositives en C# avec Aspose.Slides : créez, dupliquez, réorganisez, masquez, définissez les arrière-plans et la taille, appliquez des transitions et exportez vers PowerPoint et OpenDocument."
---

Cet article fournit une série d'exemples illustrant comment travailler avec les diapositives à l'aide de **Aspose.Slides for .NET**. Vous apprendrez comment ajouter, accéder, dupliquer, réorganiser et supprimer des diapositives en utilisant la classe `Presentation`.

Chaque exemple ci‑dessous comprend une brève explication suivie d’un extrait de code en C#.

## Ajouter une diapositive

Pour ajouter une nouvelle diapositive, vous devez d'abord sélectionner une disposition. Dans cet exemple, nous utilisons la disposition `Blank` et ajoutons une diapositive vide à la présentation.
```csharp
static void Add_Slide()
{
    using var pres = new Presentation();

    // Chaque diapositive est basée sur une disposition, qui elle‑même repose sur une diapositive maître.
    // Utilisez la disposition Blank pour créer une nouvelle diapositive.
    var blankLayout = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Ajoutez une nouvelle diapositive vide en utilisant la disposition sélectionnée
    pres.Slides.AddEmptySlide(layout: blankLayout);
}
````

> 💡 **Tip:** Each slide layout is derived from a master slide, which defines the overall design and placeholder structure. The image below illustrates how master slides and their associated layouts are organized in PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## Access Slides by Index

You can access slides using their index, or find a slide’s index based on a reference. This is useful for iterating through or modifying specific slides.

```csharp
static void Access_Slide()
{
    // Par défaut, une présentation est créée avec une diapositive vide
    using var pres = new Presentation();

    // Ajoutez une autre diapositive vide
    pres.Slides.AddEmptySlide(layout: pres.LayoutSlides.GetByType(SlideLayoutType.Blank));

    // Accédez aux diapositives par index
    var firstSlide = pres.Slides[0];
    var secondSlide = pres.Slides[1];

    // Obtenez l'index de la diapositive à partir d'une référence, puis accédez‑y par index
    var secondSlideIndex = pres.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = pres.Slides[secondSlideIndex];
}
```

## Clone a Slide

This example demonstrates how to clone an existing slide. The cloned slide is automatically added to the end of the slide collection.

```csharp
static void Clone_Slide()
{
    // Par défaut, la présentation contient une diapositive vide
    using var pres = new Presentation();

    // Clonez la première diapositive ; elle sera ajoutée à la fin de la présentation
    var clonedSlide = pres.Slides.AddClone(sourceSlide: pres.Slides[0]);

    // L'index de la diapositive clonée est 1 (deuxième diapositive de la présentation)
    var clonedSlideIndex = pres.Slides.IndexOf(clonedSlide);
}
```

## Reorder Slides

You can change the order of slides by moving one to a new index. In this case, we move a cloned slide to the first position.

```csharp
static void ReOrder_Slide()
{
    using var pres = new Presentation();

    // Ajoutez un clone de la première diapositive (créée par défaut).
    var clonedSlide = pres.Slides.AddClone(pres.Slides[0]);

    // Déplacez le clone de la diapositive à la première position (les autres sont décalés vers le bas)
    pres.Slides.Reorder(index: 0, clonedSlide);
}
```

## Remove a Slide

To remove a slide, simply reference it and call `Remove`. This example adds a second slide and then removes the original, leaving only the new one.

```csharp
static void Remove_Slide()
{
    using var pres = new Presentation();

    // Ajoutez une nouvelle diapositive vide en plus de la première diapositive par défaut
    var secondSlide = pres.Slides.AddEmptySlide(layout: pres.LayoutSlides.GetByType(SlideLayoutType.Blank));

    // Supprimez la première diapositive ; seule la diapositive nouvellement ajoutée restera
    var firstSlide = pres.Slides[0];
    pres.Slides.Remove(firstSlide);
}
```
