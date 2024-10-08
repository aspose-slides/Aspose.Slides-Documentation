---
title: Mise en Page des Diapositives
type: docs
weight: 60
url: /fr/net/slide-layout/
keyword: "Définir la taille des diapositives, définir les options des diapositives, spécifier la taille des diapositives, visibilité du pied de page, pied de page enfant, mise à l'échelle du contenu, taille de page, C#, Csharp, .NET, Aspose.Slides"
description: "Définir la taille et les options des diapositives PowerPoint en C# ou .NET"
---

Une mise en page de diapositive contient les zones de texte et les informations de formatage pour tout le contenu qui apparaît sur une diapositive. La mise en page détermine les zones de contenu disponibles et où elles sont placées.

Les mises en page des diapositives vous permettent de créer et de concevoir rapidement des présentations (qu'elles soient simples ou complexes). Voici quelques-unes des mises en page de diapositives les plus populaires utilisées dans les présentations PowerPoint :

* **Mise en Page de Diapositive de Titre**. Cette mise en page se compose de deux zones de texte. Une zone est pour le titre et l'autre est pour le sous-titre.
* **Mise en Page de Titre et Contenu**. Cette mise en page contient une zone de texte relativement petite en haut pour le titre et une zone plus grande pour le contenu principal (graphique, paragraphes, liste à puces, liste numérotée, images, etc.).
* **Mise en Page Vide**. Cette mise en page ne contient pas de zones de texte, ce qui vous permet de créer des éléments à partir de zéro.

Puisqu'un maître de diapositive est la diapositive hiérarchique principale qui stocke des informations sur les mises en page de diapositives, vous pouvez utiliser la diapositive maître pour accéder aux mises en page de diapositives et y apporter des modifications. Une diapositive de mise en page peut être accédée par type ou par nom. De même, chaque diapositive a un identifiant unique qui peut être utilisé pour y accéder.

Alternativement, vous pouvez apporter des modifications directement à une mise en page de diapositive spécifique dans une présentation.

* Pour vous permettre de travailler avec des mises en page de diapositives (y compris celles des diapositives maîtres), Aspose.Slides fournit des propriétés comme [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) et [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) sous la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
* Pour effectuer des tâches connexes, Aspose.Slides fournit [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/baseslideheaderfootermanager/), et de nombreux autres types.

{{% alert title="Info" color="info" %}}

Pour plus d'informations sur le travail avec les diapositives maîtres en particulier, consultez l'article [Slide Master](https://docs.aspose.com/slides/net/slide-master/).

{{% /alert %}}

## **Ajouter une Mise en Page de Diapositive à la Présentation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Accédez à la collection [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/).
1. Parcourez les diapositives de mise en page existantes pour confirmer que la mise en page de diapositive requise existe déjà dans la collection de diapositives de mise en page. Sinon, ajoutez la diapositive de mise en page que vous souhaitez.
1. Ajoutez une diapositive vide basée sur la nouvelle mise en page de diapositive.
1. Enregistrez la présentation.

Ce code C# vous montre comment ajouter une mise en page de diapositive à une présentation PowerPoint :

```c#
// Instancie une classe Presentation représentant le fichier de présentation
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Parcourt les types de diapositives de mise en page
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // La situation où une présentation ne contient pas certains types de mise en page.
        // Le fichier de présentation ne contient que des types de mise en page vides et personnalisés.
        // Mais les diapositives de mise en page avec des types personnalisés ont des noms de diapositive différents,
        // comme "Titre", "Titre et Contenu", etc. Et il est possible d'utiliser ces
        // noms pour la sélection des diapositives de mise en page.
        // Vous pouvez également utiliser un ensemble de types de formes de zones de texte. Par exemple,
        // La diapositive de titre ne doit avoir que le type de zone de texte Titre, etc.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Titre et Objet")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Titre")
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
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Titre et Objet");
                }
            }
        }
    }

    // Ajoute une diapositive vide avec la mise en page ajoutée
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Enregistre la présentation sur le disque
    presentation.Save("AddLayoutSlides_out.pptx", SaveFormat.Pptx);
}
```

## **Supprimer la Diapositive de Mise en Page Inutilisée**

Aspose.Slides fournit la méthode [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) de la classe [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) pour vous permettre de supprimer des diapositives de mise en page non désirées et inutilisées. Ce code C# vous montre comment supprimer une diapositive de mise en page d'une présentation PowerPoint :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Définir la Taille et le Type pour la Mise en Page de Diapositive**

Pour vous permettre de définir la taille et le type d'une diapositive de mise en page spécifique, Aspose.Slides fournit les propriétés [Type](https://reference.aspose.com/slides/net/aspose.slides/slidesize/properties/type) et [Size](https://reference.aspose.com/slides/net/aspose.slides/slidesize/properties/size) (de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)). Ce C# démontre l'opération :

```c#
// Instancie un objet Presentation représentant un fichier de présentation
Presentation presentation = new Presentation("AccessSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Définit la taille de la diapositive pour la présentation générée à celle de la source
auxPresentation.SlideSize.SetSize(presentation.SlideSize.Type,SlideSizeScaleType.EnsureFit);

auxPresentation.Slides.InsertClone(0, slide);
auxPresentation.Slides.RemoveAt(0);
// Enregistre la présentation sur le disque
auxPresentation.Save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
```

## **Définir la Visibilité du Pied de Page à l'Intérieur de la Diapositive**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence de la diapositive par son index.
1. Définissez la zone de texte du pied de page de la diapositive comme visible.
1. Définissez la zone de texte de date-heure comme visible.
1. Enregistrez la présentation.

Ce code C# vous montre comment définir la visibilité d'un pied de page de diapositive (et effectuer des tâches connexes) :

```c#
using (Presentation presentation = new Presentation("presentation.ppt"))
{
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.Slides[0].HeaderFooterManager;
    if (!headerFooterManager.IsFooterVisible) // La propriété IsFooterVisible est utilisée pour spécifier qu'une zone de pied de page de diapositive est manquante
    {
        headerFooterManager.SetFooterVisibility(true); // La méthode SetFooterVisibility est utilisée pour définir une zone de pied de page de diapositive comme visible
    }
    if (!headerFooterManager.IsSlideNumberVisible) // La propriété IsSlideNumberVisible est utilisée pour spécifier qu'une zone de numéro de page de diapositive est manquante
    {
        headerFooterManager.SetSlideNumberVisibility(true); // La méthode SetSlideNumberVisibility est utilisée pour définir une zone de numéro de page de diapositive comme visible
    }
    if (!headerFooterManager.IsDateTimeVisible) // La propriété IsDateTimeVisible est utilisée pour spécifier qu'une zone de date-heure de diapositive est manquante
    {
        headerFooterManager.SetDateTimeVisibility(true); // La méthode SetFooterVisibility est utilisée pour définir une zone de date-heure de diapositive comme visible
    }
    headerFooterManager.SetFooterText("Texte du pied de page"); // La méthode SetFooterText est utilisée pour définir un texte pour une zone de pied de page de diapositive
    headerFooterManager.SetDateTimeText("Texte de date et heure"); // La méthode SetDateTimeText est utilisée pour définir un texte pour une zone de date-heure de diapositive.

	presentation.Save("Presentation.ppt",SaveFormat.ppt);
}
```

## **Définir la Visibilité du Pied de Page Enfant à l'Intérieur de la Diapositive**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence pour la diapositive maître par son index.
1. Définissez la diapositive maître et toutes les zones de pied de page enfants comme visibles.
1. Définissez un texte pour la diapositive maître et toutes les zones de pied de page enfants.
1. Définissez un texte pour la diapositive maître et toutes les zones de date-heure enfants.
1. Enregistrez la présentation.

Ce code C# démontre l'opération :

```c#
using (Presentation presentation = new Presentation("presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;
    headerFooterManager.SetFooterAndChildFootersVisibility(true); // La méthode SetFooterAndChildFootersVisibility est utilisée pour définir la diapositive maître et toutes les zones de pied de page enfants comme visibles
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // La méthode SetSlideNumberAndChildSlideNumbersVisibility est utilisée pour définir la diapositive maître et toutes les zones de numéro de page enfants comme visibles
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // La méthode SetDateTimeAndChildDateTimesVisibility est utilisée pour définir une diapositive maître et toutes les zones de date-heure enfants comme visibles

    headerFooterManager.SetFooterAndChildFootersText("Texte du pied de page"); // La méthode SetFooterAndChildFootersText est utilisée pour définir des textes pour la diapositive maître et toutes les zones de pied de page enfants
    headerFooterManager.SetDateTimeAndChildDateTimesText("Texte de date et heure"); // La méthode SetDateTimeAndChildDateTimesText est utilisée pour définir du texte pour la diapositive maître et toutes les zones de date-heure enfants
}
```

## **Définir la Taille de Diapositive par Rapport à la Mise à l'Échelle du Contenu**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) et chargez la présentation contenant la diapositive dont vous souhaitez définir la taille.
1. Créez une autre instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) pour générer une nouvelle présentation.
1. Obtenez la référence de la diapositive (de la première présentation) par son index.
1. Définissez la zone de texte du pied de page de la diapositive comme visible.
1. Définissez la zone de texte de date-heure comme visible.
1. Enregistrez la présentation.

Ce C# démontre l'opération :

```c#
// Instancie un objet Presentation représentant un fichier de présentation 
Presentation presentation = new Presentation("AccessSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Définit la taille de la diapositive pour les présentations générées à celle de la source
presentation.SlideSize.SetSize(540, 720, SlideSizeScaleType.EnsureFit); // La méthode SetSize est utilisée pour définir la taille de la diapositive avec échelle de contenu pour garantir un ajustement
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // La méthode SetSize est utilisée pour définir la taille de la diapositive avec la taille maximale du contenu
           
// Enregistre la présentation sur le disque
auxPresentation.Save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
```

## **Définir la Taille de Page lors de la Génération du PDF**

Certaines présentations (comme les affiches) sont souvent converties en documents PDF. Si vous souhaitez convertir votre PowerPoint en PDF pour accéder aux meilleures options d'impression et d'accessibilité, vous souhaitez définir vos diapositives à des tailles adaptées aux documents PDF (A4, par exemple).

Aspose.Slides fournit la classe [SlideSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/) pour vous permettre de spécifier vos paramètres préférés pour les diapositives. Ce code C# vous montre comment utiliser la propriété [Type](https://reference.aspose.com/slides/net/aspose.slides/slidesize/type/) (de la classe `SlideSize`) pour définir une taille de papier spécifique pour les diapositives dans une présentation :

```c#
// Instancie un objet Presentation représentant un fichier de présentation 
Presentation presentation = new Presentation();

// Définit la propriété SlideSize.Type 
presentation.SlideSize.SetSize(SlideSizeType.A4Paper,SlideSizeScaleType.EnsureFit);

// Définit différentes propriétés pour les options PDF
PdfOptions opts = new  PdfOptions();
opts.SufficientResolution = 600;

// Enregistre la présentation sur le disque
presentation.Save("SetPDFPageSize_out.pdf", SaveFormat.Pdf, opts);
```