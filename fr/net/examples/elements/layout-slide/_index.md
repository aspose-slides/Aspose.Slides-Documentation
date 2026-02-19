---
title: Diapositive de mise en page
type: docs
weight: 20
url: /fr/net/examples/elements/layout-slide/
keywords:
- diapositive de mise en page
- ajouter diapositive de mise en page
- accéder à la diapositive de mise en page
- supprimer diapositive de mise en page
- diapositive de mise en page inutilisée
- cloner diapositive de mise en page
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Diapositives principales de mise en page dans Aspose.Slides pour .NET: choisissez, appliquez et personnalisez les mises en page de diapositives, les espaces réservés et les maîtres avec des exemples C# pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment travailler avec les **diapositives de mise en page** dans Aspose.Slides pour .NET. Une diapositive de mise en page définit la conception et le formatage hérités par les diapositives normales. Vous pouvez ajouter, accéder, cloner et supprimer des diapositives de mise en page, ainsi que nettoyer celles qui ne sont pas utilisées afin de réduire la taille de la présentation.

## **Ajouter une diapositive de mise en page**

Vous pouvez créer une diapositive de mise en page personnalisée pour définir un formatage réutilisable. Par exemple, vous pouvez ajouter une zone de texte qui apparaît sur toutes les diapositives utilisant cette mise en page.

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // Créez une diapositive de mise en page avec un type de mise en page vierge et un nom personnalisé.
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // Ajoutez une zone de texte à la diapositive de mise en page.
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Ajoutez deux diapositives en utilisant cette mise en page ; les deux hériteront du texte de la mise en page.
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **Note 1:** Les diapositives de mise en page servent de modèles pour les diapositives individuelles. Vous pouvez définir les éléments communs une fois et les réutiliser sur de nombreuses diapositives.

> 💡 **Note 2:** Lorsque vous ajoutez des formes ou du texte à une diapositive de mise en page, toutes les diapositives basées sur cette mise en page afficheront automatiquement ce contenu partagé.  
> La capture d'écran ci‑dessous montre deux diapositives, chacune héritant d'une zone de texte de la même diapositive de mise en page.

![Diapositives héritant du contenu de la mise en page](layout-slide-result.png)

## **Accéder à une diapositive de mise en page**

Les diapositives de mise en page peuvent être accédées par index ou par type de mise en page (par ex., `Blank`, `Title`, `SectionHeader`, etc.).

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Accédez à une diapositive de mise en page par index.
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // Accédez à une diapositive de mise en page par type.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **Supprimer une diapositive de mise en page**

Vous pouvez supprimer une diapositive de mise en page spécifique si elle n'est plus nécessaire.

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Récupérez une diapositive de mise en page par type et supprimez-la.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **Supprimer les diapositives de mise en page inutilisées**

Pour réduire la taille de la présentation, vous pouvez vouloir supprimer les diapositives de mise en page qui ne sont utilisées par aucune diapositive normale.

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Supprime automatiquement toutes les diapositives de mise en page qui ne sont référencées par aucune diapositive.
    presentation.LayoutSlides.RemoveUnused();
}
```

## **Cloner une diapositive de mise en page**

Vous pouvez dupliquer une diapositive de mise en page en utilisant la méthode `AddClone`.

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Obtenez une diapositive de mise en page existante par type.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Clonez la diapositive de mise en page à la fin de la collection de diapositives de mise en page.
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Résumé:** Les diapositives de mise en page sont des outils puissants pour gérer un formatage cohérent sur les diapositives. Aspose.Slides permet un contrôle total sur la création, la gestion et l'optimisation des diapositives de mise en page.