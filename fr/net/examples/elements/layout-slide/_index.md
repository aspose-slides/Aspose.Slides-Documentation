---
title: Diapositive de mise en page
type: docs
weight: 20
url: /fr/net/examples/elements/layout-slide/
keywords:
- exemple de diapositive de mise en page
- ajouter diapositive de mise en page
- accéder diapositive de mise en page
- supprimer diapositive de mise en page
- diapositive de mise en page inutilisée
- cloner diapositive de mise en page
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Utilisez C# pour gérer les diapositives de mise en page avec Aspose.Slides : créez, appliquez, clonez, renommez et personnalisez les espaces réservés et les thèmes dans les présentations pour PPT, PPTX et ODP."
---

Cet article montre comment travailler avec **Layout Slides** dans Aspose.Slides for .NET. Une diapositive de mise en page définit la conception et le formatage hérités par les diapositives normales. Vous pouvez ajouter, accéder, cloner et supprimer des diapositives de mise en page, ainsi que nettoyer celles qui ne sont pas utilisées pour réduire la taille de la présentation.

## **Ajouter une diapositive de mise en page**

Vous pouvez créer une diapositive de mise en page personnalisée pour définir un formatage réutilisable. Par exemple, vous pouvez ajouter une zone de texte qui apparaît sur toutes les diapositives utilisant cette mise en page.

```csharp
static void Add_Layout_Slide()
{
    using var pres = new Presentation();
    
    // Create a layout slide with a blank layout type and a custom name
    var layoutSlide = pres.LayoutSlides.Add(pres.Masters[0], SlideLayoutType.Blank, "Main layout");

    // Add a text box to the layout slide
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Add two slides using this layout; both will inherit the text from the layout
    pres.Slides.AddEmptySlide(layoutSlide);
    pres.Slides.AddEmptySlide(layoutSlide);
}
````
> 💡 **Astuce 1 :** Les diapositives de mise en page agissent comme des modèles pour les diapositives individuelles. Vous pouvez définir les éléments communs une fois et les réutiliser sur de nombreuses diapositives.

> 💡 **Astuce 2 :** Lorsque vous ajoutez des formes ou du texte à une diapositive de mise en page, toutes les diapositives basées sur cette mise en page afficheront automatiquement ce contenu partagé.
> La capture d'écran ci‑dessous montre deux diapositives, chacune héritant d'une zone de texte de la même diapositive de mise en page.

![Diapositives héritant du contenu de la mise en page](layout-slide-result.png)


## **Accéder à une diapositive de mise en page**

Les diapositives de mise en page peuvent être accédées par indice ou par type de mise en page (par ex., `Blank`, `Title`, `SectionHeader`, etc.).

```csharp
static void Access_Layout_Slide()
{
    using var pres = new Presentation();
    
    // Access by index
    var firstLayoutSlide = pres.LayoutSlides[0];
    
    // Access by layout type
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **Supprimer une diapositive de mise en page**

Vous pouvez supprimer une diapositive de mise en page spécifique si elle n'est plus nécessaire.

```csharp
static void Remove_Layout_Slide()
{
    using var pres = new Presentation();
    
    // Get a layout slide by type and remove it
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
    pres.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **Supprimer les diapositives de mise en page inutilisées**

Pour réduire la taille de la présentation, vous pouvez vouloir supprimer les diapositives de mise en page qui ne sont utilisées par aucune diapositive normale.

```csharp
static void RemoveUnused_Layout_Slides()
{
    using var pres = new Presentation();
    
    // Automatically removes all layout slides not referenced by any slide
    pres.LayoutSlides.RemoveUnused();
}
```

## **Cloner une diapositive de mise en page**

Vous pouvez dupliquer une diapositive de mise en page à l'aide de la méthode `AddClone`.

```csharp
static void Clone_Layout_Slides()
{
    using var pres = new Presentation();
    
    // Get an existing layout slide by type
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Clone the layout slide to the end of the layout slide collection
    var clonedLayoutSlide = pres.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Résumé :** Les diapositives de mise en page sont des outils puissants pour gérer une mise en forme cohérente sur les diapositives. Aspose.Slides offre un contrôle complet sur la création, la gestion et l'optimisation des diapositives de mise en page.