---
title: Diapositive
type: docs
weight: 10
url: /fr/net/examples/elements/slide/
keywords:
- diapositive
- ajouter diapositive
- accéder diapositive
- indice diapositive
- dupliquer diapositive
- réorganiser diapositives
- supprimer diapositive
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Contrôlez les diapositives dans Aspose.Slides for .NET : créez, dupliquez, réorganisez, redimensionnez, définissez les arrière-plans et appliquez des transitions avec C# pour les présentations PPT, PPTX et ODP."
---
Cet article propose une série d'exemples illustrant comment travailler avec des diapositives à l'aide de **Aspose.Slides for .NET**. Vous apprendrez comment ajouter, accéder, cloner, réorganiser et supprimer des diapositives à l'aide de la classe `Presentation`.

Chaque exemple ci‑dessous comprend une brève explication suivie d’un extrait de code en C#.

## **Ajouter une diapositive**

Pour ajouter une nouvelle diapositive, vous devez d'abord sélectionner une disposition. Dans cet exemple, nous utilisons la disposition `Blank` et ajoutons une diapositive vide à la présentation.

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // Chaque diapositive repose sur une disposition, qui elle-même repose sur une diapositive maître.
    // Utilisez la disposition Blank pour créer une nouvelle diapositive.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Ajoutez une nouvelle diapositive vide en utilisant la disposition sélectionnée.
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Remarque:** Chaque disposition de diapositive est dérivée d'une diapositive maître, qui définit la conception globale et la structure des espaces réservés. L'image ci‑dessous illustre comment les diapositives maîtres et leurs dispositions associées sont organisées dans PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## **Accéder aux diapositives par index**

Vous pouvez accéder aux diapositives en utilisant leur indice, ou trouver l'indice d'une diapositive à partir d'une référence. Cela est utile pour parcourir ou modifier des diapositives spécifiques.

```csharp
static void AccessSlide()
{
    // Par défaut, une présentation est créée avec une diapositive vide.
    using var presentation = new Presentation();

    // Ajoutez une autre diapositive vide.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Accédez aux diapositives par indice.
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // Obtenez l'indice de la diapositive à partir d'une référence, puis accédez-y par indice.
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **Cloner une diapositive**

Cet exemple montre comment cloner une diapositive existante. La diapositive clonée est automatiquement ajoutée à la fin de la collection de diapositives.

```csharp
static void CloneSlide()
{
    // Par défaut, la présentation contient une diapositive vide.
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Clonez la première diapositive; elle sera ajoutée à la fin de la présentation.
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // L'index de la diapositive clonée est 1 (deuxième diapositive de la présentation).
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **Réorganiser les diapositives**

Vous pouvez modifier l'ordre des diapositives en en déplaçant une vers un nouvel indice. Dans ce cas, nous déplaçons une diapositive clonée à la première position.

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Ajoutez un clone de la première diapositive (créée par défaut).
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // Déplacez le clone de la diapositive à la première position (les autres se décalent vers le bas).
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **Supprimer une diapositive**

Pour supprimer une diapositive, il suffit d’y faire référence et d’appeler `Remove`. Cet exemple ajoute une deuxième diapositive puis supprime l'originale, ne laissant que la nouvelle.

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // Ajoutez une nouvelle diapositive vide en plus de la première diapositive par défaut.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Supprimez la première diapositive; seule la diapositive nouvellement ajoutée restera.
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```