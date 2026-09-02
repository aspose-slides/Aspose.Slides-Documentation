---
title: Gérer les sections de diapositives dans les présentations en .NET
linktitle: Section de diapositive
type: docs
weight: 100
url: /fr/net/slide-section/
keywords:
- créer une section
- ajouter une section
- modifier une section
- changer de section
- nom de la section
- récupérer les diapositives de la section
- traiter les diapositives de la section
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Gérer les sections de diapositives avec Aspose.Slides pour .NET : créer, renommer, réorganiser, récupérer et traiter les diapositives de section dans les présentations PPTX."
---
## **Introduction**

Les sections organisent les diapositives consécutives en groupes nommés sans modifier le contenu des diapositives. Avec Aspose.Slides pour .NET, vous pouvez créer, réordonner, renommer, inspecter et supprimer des sections via la propriété [Presentation.Sections](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/sections/).

Les sections sont particulièrement utiles lorsque :

- une grande présentation doit être divisée en sujets ou chapitres logiques ;
- différents groupes de diapositives sont assignés à différents collaborateurs ;
- les diapositives doivent être traitées, déplacées ou fusionnées par groupes.

Choisissez des noms de sections concis décrivant le but des diapositives groupées. Étant donné que les sections font partie de la structure de la présentation, utilisez les API de sections pour déterminer l’appartenance au lieu de la déduire à partir des positions des diapositives.

## **Créer et gérer les sections**

Utilisez [ISectionCollection.AddSection](https://reference.aspose.com/slides/fr/net/aspose.slides/sectioncollection/addsection/) pour créer une section en spécifiant son nom et la diapositive de départ. Aspose.Slides détermine quelles diapositives appartiennent à la section à partir de la structure actuelle des sections de la présentation.

Le même [ISectionCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/isectioncollection/) vous permet également de :

- déplacer une section avec ses diapositives en utilisant [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/fr/net/aspose.slides/sectioncollection/reordersectionwithslides/) ;
- supprimer uniquement la définition de la section avec [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/fr/net/aspose.slides/sectioncollection/removesection/), qui conserve ses diapositives ;
- supprimer une section et ses diapositives avec [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/fr/net/aspose.slides/sectioncollection/removesectionwithslides/) ;
- ajouter une section vide à la fin avec [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/fr/net/aspose.slides/sectioncollection/appendemptysection/) .

L'exemple suivant crée deux sections, en déplace une, la supprime ainsi que ses diapositives, puis ajoute une section vide :

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var titleSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var resultsSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", titleSlide);
var resultsSection = presentation.Sections.AddSection("Results", resultsSlide);

presentation.Sections.ReorderSectionWithSlides(resultsSection, 0);
presentation.Sections.RemoveSectionWithSlides(resultsSection);
presentation.Sections.AppendEmptySection("Appendix");
```

Après ces opérations, la présentation contient la section `Introduction` avec ses diapositives et une section vide `Appendix`. La section `Results` et ses diapositives ont été supprimées.

## **Renommer les sections**

Pour renommer une section, définissez sa propriété [ISection.Name](https://reference.aspose.com/slides/fr/net/aspose.slides/isection/name/). Les diapositives et la position de la section restent inchangées.

L'exemple suivant crée une section et modifie son nom :

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **Récupérer les diapositives des sections**

La propriété [Presentation.Sections](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/sections/) renvoie une [ISectionCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/isectioncollection/) que vous pouvez parcourir. Pour chaque [ISection](https://reference.aspose.com/slides/fr/net/aspose.slides/isection/), appelez [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/fr/net/aspose.slides/isection/getslideslistofsection/) pour obtenir les diapositives qui lui appartiennent actuellement. La méthode renvoie une [ISectionSlideCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/isectionslidecollection/), qui fournit un compte, un accès indexé et une énumération.

L'exemple suivant crée deux sections remplies et une section vide, puis affiche le [nom](https://reference.aspose.com/slides/fr/net/aspose.slides/isection/name/), l'[identifiant](https://reference.aspose.com/slides/fr/net/aspose.slides/isection/sectionid/), la [diapositive de départ](https://reference.aspose.com/slides/fr/net/aspose.slides/isection/startedfromslide/), le nombre de diapositives et les numéros de diapositives de chaque section. Il utilise l'indexeur de la collection pour lire la première diapositive et `foreach` pour traiter chaque diapositive. Pour la section vide, la collection renvoyée a un compte de zéro, l'indexeur n'est pas utilisé, et l'énumération ne réalise aucune itération.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", firstSlide);
presentation.Sections.AddSection("Details", thirdSlide);
presentation.Sections.AppendEmptySection("Appendix");

foreach (var section in presentation.Sections)
{
    var sectionSlides = section.GetSlidesListOfSection();
    var startingSlide = section.StartedFromSlide == null ? "none" : section.StartedFromSlide.SlideNumber.ToString();

    Console.WriteLine($"Section: {section.Name}");
    Console.WriteLine($"ID: {section.SectionId}");
    Console.WriteLine($"Starting slide: {startingSlide}");
    Console.WriteLine($"Slide count: {sectionSlides.Count}");

    if (sectionSlides.Count > 0)
    {
        Console.WriteLine($"First slide via indexer: {sectionSlides[0].SlideNumber}");
    }

    Console.Write("Slide numbers:");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}
```

L'appartenance à une section est déterminée par la structure des sections de la présentation. Ne calculez pas manuellement la plage d'une section à partir de [ISection.StartedFromSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/isection/startedfromslide/), des index de diapositives et de la diapositive de départ de la section suivante.

Les modifications structurelles peuvent modifier à la fois les diapositives renvoyées pour une section et leurs numéros de diapositives. Cela inclut le réordonnancement des diapositives, le clonage d'une diapositive dans une section, le déplacement d'une section avec ses diapositives, la suppression de diapositives et la suppression de sections. L'exemple suivant appelle [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/fr/net/aspose.slides/isection/getslideslistofsection/) après chaque changement au lieu de conserver des hypothèses sur les anciennes limites de la section.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var firstSection = presentation.Sections.AddSection("First", firstSlide);
var secondSection = presentation.Sections.AddSection("Second", thirdSlide);

static void PrintSectionSlides(string label, ISection section)
{
    var sectionSlides = section.GetSlidesListOfSection();
    Console.Write($"{label} ({sectionSlides.Count} slides):");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}

PrintSectionSlides("Initially", firstSection);

var slidesBeforeClone = firstSection.GetSlidesListOfSection();
presentation.Slides.AddClone(slidesBeforeClone[0], firstSection);
PrintSectionSlides("After cloning into the section", firstSection);

var slidesBeforeReorder = firstSection.GetSlidesListOfSection();
var firstSectionPosition = slidesBeforeReorder[0].SlideNumber - 1;
presentation.Slides.Reorder(firstSectionPosition, slidesBeforeReorder[slidesBeforeReorder.Count - 1]);
PrintSectionSlides("After reordering slides", firstSection);

presentation.Sections.ReorderSectionWithSlides(firstSection, 1);
PrintSectionSlides("After moving the section", firstSection);

var slidesBeforeRemoval = firstSection.GetSlidesListOfSection();
presentation.Slides.Remove(slidesBeforeRemoval[0]);
PrintSectionSlides("After removing a slide", firstSection);

presentation.Sections.RemoveSectionWithSlides(secondSection);
foreach (var section in presentation.Sections)
{
    PrintSectionSlides("Remaining section", section);
}
```

Appelez [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/fr/net/aspose.slides/isection/getslideslistofsection/) à nouveau chaque fois que des diapositives ou des sections sont réordonnées, clonées, déplacées ou supprimées. Cela maintient le traitement ultérieur aligné sur la structure actuelle de la présentation.

Le format PPT (PowerPoint 97–2003) ne conserve pas les métadonnées des sections. Utilisez ce flux de travail avec un format qui prend en charge les sections, tel que PPTX ; la conversion en PPT supprime la structure de sections nécessaire pour une énumération ultérieure.

## **FAQ**

**Les sections sont‑elles conservées lors de l'enregistrement au format PPT (PowerPoint 97–2003) ?**

Non. Le format PPT ne prend pas en charge les métadonnées des sections, donc le regroupement des sections est perdu lors de l'enregistrement au format .ppt.

**Une section entière peut‑elle être « masquée » ?**

Non. Une section n’a aucun état de visibilité. Pour masquer son contenu, définissez la propriété [ISlide.Hidden](https://reference.aspose.com/slides/fr/net/aspose.slides/islide/hidden/) pour chaque diapositive de la section.

**Comment puis‑je trouver la section contenant une diapositive ?**

Parcourez [Presentation.Sections](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/sections/), appelez [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/fr/net/aspose.slides/isection/getslideslistofsection/) pour chaque section, et comparez les diapositives renvoyées avec la diapositive cible. Pour une section non vide, [ISection.StartedFromSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/isection/startedfromslide/) renvoie sa première diapositive ; pour une section vide, elle renvoie `null`.