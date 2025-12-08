---
title: Appliquer ou modifier une mise en page de diapositive en C#
linktitle: Mise en page de diapositive
type: docs
weight: 60
url: /fr/net/slide-layout/
keywords:
- mise en page de diapositive
- mise en page du contenu
- espace réservé
- conception de présentation
- conception de diapositive
- mise en page inutilisée
- visibilité du pied de page
- diapositive titre
- titre et contenu
- en-tête de section
- deux contenus
- comparaison
- titre seul
- mise en page vierge
- contenu avec légende
- image avec légende
- titre et texte vertical
- titre vertical et texte
- C#
- .NET
- Aspose.Slides
description: "Apprenez à gérer et personnaliser les mises en page de diapositives dans Aspose.Slides pour .NET. Explorez les types de mise en page, le contrôle des espaces réservés, la visibilité du pied de page et la manipulation des mises en page à l'aide d'exemples de code en C#."
---

## **Vue d'ensemble**

Une disposition de diapositive définit l’agencement des zones réservées et le formatage du contenu d’une diapositive. Elle contrôle quelles zones réservées sont disponibles et où elles apparaissent. Les dispositions de diapositives vous aident à créer des présentations rapidement et de façon cohérente—qu’il s’agisse de quelque chose de simple ou de plus complexe. Parmi les dispositions de diapositives les plus courantes dans PowerPoint :

**Disposition de diapositive Titre** – Comprend deux zones réservées : une pour le titre et une pour le sous‑titre.

**Disposition Titre et Contenu** – Propose une petite zone réservée de titre en haut et une plus grande en dessous pour le contenu principal (texte, puces, graphiques, images, etc.).

**Disposition Vide** – Ne contient aucune zone réservée, vous donnant un contrôle total pour concevoir la diapositive à partir de zéro.

Les dispositions de diapositives font partie d’un masque de diapositive, qui est la diapositive de niveau supérieur définissant les styles de disposition pour la présentation. Vous pouvez accéder aux dispositions et les modifier via le masque de diapositives—par leur type, leur nom ou leur ID unique. Vous pouvez également éditer une disposition spécifique directement dans la présentation.

Pour travailler avec les dispositions de diapositives dans Aspose.Slides for .NET, vous pouvez utiliser :

- Des propriétés telles que [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) et [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) sous la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)
- Des types comme [ILayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutplaceholdermanager/) et [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Pour en savoir plus sur la gestion des masques de diapositives, consultez l’article [Slide Master](/slides/fr/net/slide-master/).
{{% /alert %}}

## **Ajouter des dispositions de diapositive aux présentations**

Pour personnaliser l’apparence et la structure de vos diapositives, il peut être nécessaire d’ajouter de nouvelles dispositions à une présentation. Aspose.Slides for .NET vous permet de vérifier si une disposition donnée existe déjà, d’en ajouter une nouvelle si besoin, puis d’insérer des diapositives basées sur cette disposition.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Accédez à la [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/).
3. Vérifiez si la disposition souhaitée existe déjà dans la collection. Si ce n’est pas le cas, ajoutez la disposition requise.
4. Ajoutez une diapositive vide basée sur la nouvelle disposition.
5. Enregistrez la présentation.

Le code C# suivant montre comment ajouter une disposition de diapositive à une présentation PowerPoint :
```cs
// Instancier la classe Presentation qui représente un fichier PowerPoint.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Parcourir les types de diapositives de mise en page pour sélectionner une mise en page.
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // Situation où la présentation ne contient pas tous les types de mise en page.
        // Le fichier de présentation ne contient que les types de mise en page Blank et Custom.
        // Cependant, les diapositives de mise en page avec des types personnalisés peuvent avoir des noms reconnaissables,
        // comme "Title", "Title and Content", etc., qui peuvent être utilisés pour la sélection de la diapositive de mise en page.
        // Vous pouvez également vous appuyer sur un ensemble de types de formes d'espace réservé.
        // Par exemple, une diapositive Title ne doit contenir que le type d'espace réservé Title, etc.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Ajouter une diapositive vide en utilisant la mise en page ajoutée.
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Enregistrer la présentation sur le disque.  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **Supprimer les dispositions de diapositive inutilisées**

Aspose.Slides fournit la méthode [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) de la classe [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) pour vous permettre de supprimer les dispositions de diapositive indésirables et non utilisées.

Le code C# suivant montre comment supprimer une disposition de diapositive d’une présentation PowerPoint :
```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **Ajouter des zones réservées aux dispositions de diapositive**

Aspose.Slides fournit la propriété [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/placeholdermanager/) qui permet d’ajouter de nouvelles zones réservées à une disposition.

Ce gestionnaire propose des méthodes pour les types de zones réservées suivants :

| Espace réservé PowerPoint          | Méthode ILayoutPlaceholderManager                                 |
| ----------------------------------- | ----------------------------------------------------------------- |
| ![Contenu](content.png)             | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Contenu (Vertical)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Texte](text.png)                   | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Texte (Vertical)](textV.png)       | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Image](picture.png)                | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Graphique](chart.png)              | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Tableau](table.png)                | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)            | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Média](media.png)                  | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Image en ligne](onlineimage.png)   | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Le code C# suivant montre comment ajouter de nouvelles formes de zone réservée à la disposition « Blank » :
```cs
using (var presentation = new Presentation())
{
    // Obtenir la diapositive de mise en page vierge.
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Obtenir le gestionnaire d'espaces réservés de la diapositive de mise en page.
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // Ajouter différents espaces réservés à la diapositive de mise en page vierge.
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // Ajouter une nouvelle diapositive avec la mise en page vierge.
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Les espaces réservés sur la diapositive de disposition](add_placeholders.png)

## **Définir la visibilité du pied de page pour une disposition de diapositive**

Dans les présentations PowerPoint, les éléments de pied de page tels que la date, le numéro de diapositive et le texte personnalisé peuvent être affichés ou masqués selon la disposition. Aspose.Slides for .NET vous permet de contrôler la visibilité de ces zones réservées de pied de page. Cela est utile lorsque vous souhaitez que certaines dispositions affichent les informations de pied de page tandis que d’autres restent épurées.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Obtenez une référence à une disposition par son index.
3. Définissez la zone réservée du pied de page de la diapositive comme visible.
4. Définissez la zone réservée du numéro de diapositive comme visible.
5. Définissez la zone réservée de la date‑heure comme visible.
6. Enregistrez la présentation.

Le code C# suivant montre comment régler la visibilité du pied de page d’une diapositive :
```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```


## **Définir la visibilité du pied de page enfant pour une diapositive**

Dans les présentations PowerPoint, les éléments de pied de page tels que la date, le numéro de diapositive et le texte personnalisé peuvent être contrôlés au niveau du masque afin d’assurer la cohérence sur toutes les dispositions. Aspose.Slides for .NET vous permet de définir la visibilité et le contenu de ces zones réservées de pied de page sur le masque maître et de propager ces paramètres à toutes les dispositions enfants. Cette approche garantit une information de pied de page uniforme tout au long de votre présentation.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Obtenez une référence au masque de diapositive par son index.
3. Définissez les zones réservées du pied de page du masque et de tous les enfants comme visibles.
4. Définissez les zones réservées du numéro de diapositive du masque et de tous les enfants comme visibles.
5. Définissez les zones réservées de la date‑heure du masque et de tous les enfants comme visibles.
6. Enregistrez la présentation.

Le code C# suivant montre cette opération :
```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Quelle est la différence entre une diapositive maître et une diapositive de disposition ?**

Une diapositive maître définit le thème global et le formatage par défaut, tandis que les diapositives de disposition précisent les agencements spécifiques des zones réservées pour différents types de contenu.

**Puis‑je copier une diapositive de disposition d’une présentation à une autre ?**

Oui, vous pouvez cloner une diapositive de disposition depuis la collection [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) d’une présentation et l’insérer dans une autre en utilisant la méthode `AddClone`.

**Que se passe‑t‑il si je supprime une diapositive de disposition encore utilisée par une diapositive ?**

Si vous tentez de supprimer une diapositive de disposition qui est encore référencée par au moins une diapositive de la présentation, Aspose.Slides lèvera une [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception/). Pour éviter cela, utilisez [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) qui supprime uniquement les dispositions non utilisées.