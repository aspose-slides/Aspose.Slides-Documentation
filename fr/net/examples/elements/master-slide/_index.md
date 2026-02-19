---
title: Diapositive maître
type: docs
weight: 30
url: /fr/net/examples/elements/master-slide/
keywords:
- diapositive maître
- ajouter diapositive maître
- accéder diapositive maître
- supprimer diapositive maître
- diapositive maître inutilisée
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Explorez les exemples de diapositives maîtres d'Aspose.Slides pour .NET : créez, modifiez et stylisez les maîtres, les espaces réservés et les thèmes dans PPT, PPTX et ODP avec du code C# clair."
---
Les diapositives maîtres constituent le niveau supérieur de la hiérarchie d'héritage des diapositives dans PowerPoint. Une **diapositive maître** définit les éléments de conception communs tels que les arrière-plans, les logos et le formatage du texte. Les **diapositives de mise en page** héritent des diapositives maîtres, et les **diapositives normales** héritent des diapositives de mise en page.

Cet article montre comment créer, modifier et gérer les diapositives maîtres à l'aide d'Aspose.Slides pour .NET.

## **Ajouter une diapositive maître**

Cet exemple montre comment créer une nouvelle diapositive maître en clonant celle par défaut. Il ajoute ensuite une bannière avec le nom de l'entreprise à toutes les diapositives grâce à l'héritage de la mise en page.

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // Clone la diapositive maître par défaut.
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // Ajoutez une bannière avec le nom de l'entreprise en haut de la diapositive maître.
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Assignez la nouvelle diapositive maître à une diapositive de mise en page.
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // Assignez la diapositive de mise en page à la première diapositive de la présentation.
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **Note 1 :** Les diapositives maîtres offrent un moyen d'appliquer une identité visuelle ou des éléments de conception partagés de manière cohérente sur toutes les diapositives. Toute modification apportée à la maître se répercutera automatiquement sur les mises en page et les diapositives normales dépendantes.
> 
> 💡 **Note 2 :** Tous les formes ou formatages ajoutés à une diapositive maître sont hérités par les diapositives de mise en page et, à leur tour, par toutes les diapositives normales utilisant ces mises en page.
> 
> L'image ci‑dessous illustre comment une zone de texte ajoutée sur une diapositive maître est automatiquement rendue sur la diapositive finale.

![Exemple d'héritage de diapositive maître](master-slide-banner.png)

## **Accéder à une diapositive maître**

Vous pouvez accéder aux diapositives maîtres à l'aide de la collection `Presentation.Masters`. Voici comment les récupérer et travailler avec elles :

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // Accédez à la première diapositive maître.
    var firstMasterSlide = presentation.Masters[0];

    // Modifiez le type d'arrière-plan.
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **Supprimer une diapositive maître**

Les diapositives maîtres peuvent être supprimées soit par indice, soit par référence.

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // Supprimez une diapositive maître par indice.
    presentation.Masters.RemoveAt(0);

    // Supprimez une diapositive maître par référence.
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **Supprimer les diapositives maîtres inutilisées**

Certaines présentations contiennent des diapositives maîtres qui ne sont pas utilisées. Supprimer ces diapositives peut aider à réduire la taille du fichier.

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // Supprimez toutes les diapositives maîtres inutilisées (même celles marquées comme Preserve).
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```