---
title: Diapositive maître
type: docs
weight: 30
url: /fr/net/examples/elements/master-slide/
keywords:
- exemple de diapositive maître
- ajouter une diapositive maître
- accéder à une diapositive maître
- supprimer une diapositive maître
- diapositive maître inutilisée
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Gérez les diapositives maîtres en C# avec Aspose.Slides : créez, modifiez, clonez et formatez les thèmes, arrière-plans et espaces réservés pour unifier les diapositives dans PowerPoint et OpenDocument."
---

Les diapositives maîtres constituent le niveau supérieur de la hiérarchie d’héritage des diapositives dans PowerPoint. Une **diapositive maître** définit des éléments de conception communs tels que les arrière-plans, les logos et le formatage du texte. Les **diapositives de mise en page** héritent des diapositives maîtres, et les **diapositives normales** héritent des diapositives de mise en page.

Cet article montre comment créer, modifier et gérer des diapositives maîtres en utilisant Aspose.Slides pour .NET.

## **Ajouter une diapositive maître**

Cet exemple montre comment créer une nouvelle diapositive maître en dupliquant celle par défaut. Il ajoute ensuite une bannière avec le nom de l’entreprise à toutes les diapositives grâce à l’héritage de la mise en page.

```csharp
static void Add_Master_Slide()
{
    using var pres = new Presentation();

    // Clone the default master slide
    var defaultMasterSlide = pres.Masters[0];
    var newMaster = pres.Masters.AddClone(defaultMasterSlide);

    // Add a banner with company name to the top of the master slide
    var textBox = newMaster.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Assign the new master slide to a layout slide
    var layoutSlide = pres.LayoutSlides[0];
    layoutSlide.MasterSlide = newMaster;

    // Assign the layout slide to the first slide in the presentation
    pres.Slides[0].LayoutSlide = layoutSlide;
}
````

> 💡 **Conseil 1 :** Les diapositives maîtres offrent un moyen d’appliquer une identité visuelle cohérente ou des éléments de conception partagés à toutes les diapositives. Toute modification apportée au maître se répercutera automatiquement sur les mises en page et les diapositives normales dépendantes.

> 💡 **Conseil 2 :** Toutes les formes ou le formatage ajoutés à une diapositive maître sont hérités par les diapositives de mise en page et, à leur tour, par toutes les diapositives normales utilisant ces mises en page. > L’image ci‑dessous illustre comment une zone de texte ajoutée sur une diapositive maître est automatiquement rendue sur la diapositive finale.

![Exemple d'héritage de la diapositive maître](master-slide-banner.png)

## **Accéder à une diapositive maître**

Vous pouvez accéder aux diapositives maîtres en utilisant la collection `Presentation.Masters`. Voici comment les récupérer et travailler avec elles :

```csharp
static void Access_Master_Slide()
{
    using var pres = new Presentation();

    // Access the first master slide
    var firstMasterSlide = pres.Masters[0];

    // Change the background type
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **Supprimer une diapositive maître**

Les diapositives maîtres peuvent être supprimées soit par indice, soit par référence.

```csharp
static void Remove_Master_Slide()
{
    using var pres = new Presentation();

    // Remove by index
    pres.Masters.RemoveAt(0);

    // Or remove by reference
    var firstMasterSlide = pres.Masters[0];
    pres.Masters.Remove(firstMasterSlide);
}
```

## **Supprimer les diapositives maîtres inutilisées**

Certaines présentations contiennent des diapositives maîtres qui ne sont pas utilisées. Les supprimer peut aider à réduire la taille du fichier.

```csharp
static void RemoveUnused_Master_Slide()
{
    using var pres = new Presentation();

    // Remove all unused master slides (even those marked as Preserve)
    pres.Masters.RemoveUnused(ignorePreserveField: true);
}
```

> ⚙️ **Conseil :** Utilisez `RemoveUnused(true)` pour nettoyer les diapositives maîtres inutilisées et minimiser la taille de la présentation.