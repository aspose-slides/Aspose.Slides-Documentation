---
title: Extraction avancée de texte à partir de présentations en C#
linktitle: Extraire du texte
type: docs
weight: 90
url: /fr/net/extract-text-from-presentation/
keywords:
- extraire du texte
- extraire du texte d'une diapositive
- extraire du texte d'une présentation
- extraire du texte de PowerPoint
- extraire du texte de PPT
- extraire du texte de PPTX
- extraire du texte de ODP
- C#
- .NET
- Aspose.Slides
description: "Apprenez comment extraire rapidement et facilement du texte des présentations PowerPoint à l'aide d'Aspose.Slides for .NET. Suivez notre guide simple, étape par étape, pour gagner du temps et accéder efficacement au contenu des diapositives dans vos applications."
---

## **Vue d'ensemble**

L'extraction de texte à partir de présentations est une tâche courante mais essentielle pour les développeurs qui travaillent avec du contenu de diapositive. Que vous manipuliez des fichiers Microsoft PowerPoint au format PPT ou PPTX, ou des présentations OpenDocument (ODP), accéder et récupérer les données textuelles peut être crucial pour l'analyse, l'automatisation, l'indexation ou la migration de contenu.

Cet article fournit un guide complet sur la façon d'extraire efficacement du texte de divers formats de présentation, y compris PPT, PPTX et ODP, en utilisant Aspose.Slides for .NET. Vous apprendrez à parcourir systématiquement les éléments d'une présentation pour récupérer avec précision le texte dont vous avez besoin.

## **Extraire le texte d'une diapositive**

Aspose.Slides for .NET fournit l'espace de noms [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/) qui inclut la classe [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/). Cette classe expose plusieurs méthodes statiques surchargées pour extraire tout le texte d'une présentation ou d'une diapositive. Pour extraire le texte d'une diapositive d'une présentation, utilisez la méthode [GetAllTextBoxes](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextboxes/). Cette méthode accepte en paramètre un objet de type [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/). Lorsqu'elle est exécutée, la méthode parcourt toute la diapositive à la recherche de texte et renvoie un tableau d'objets de type [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/), en conservant la mise en forme du texte.

Le fragment de code suivant extrait tout le texte de la première diapositive de la présentation :
```cs
int slideIndex = 0;

// Instancier la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
using Presentation presentation = new Presentation("demo.pptx");

// Obtenir une référence à la diapositive.
ISlide slide = presentation.Slides[slideIndex];

// Obtenir un tableau de cadres de texte à partir de la diapositive.
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

// Parcourir le tableau des cadres de texte.
for (int i = 0; i < textFrames.Length; i++)
{
    // Parcourir les paragraphes du cadre de texte actuel.
    foreach (IParagraph paragraph in textFrames[i].Paragraphs)
    {
        // Parcourir les portions de texte du paragraphe actuel.
        foreach (IPortion portion in paragraph.Portions)
        {
            // Afficher le texte de la portion de texte actuelle.
            Console.WriteLine(portion.Text);

            // Afficher la hauteur de la police du texte.
            Console.WriteLine(portion.PortionFormat.FontHeight);

            // Afficher le nom de la police du texte.
            if (portion.PortionFormat.LatinFont != null)
                Console.WriteLine(portion.PortionFormat.LatinFont.FontName);
        }
    }
}
```


## **Extraire le texte d'une présentation**

Pour parcourir le texte de l'ensemble de la présentation, utilisez la méthode statique [GetAllTextFrames](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextframes/) exposée par la classe [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/). Elle accepte deux paramètres :

1. Tout d'abord, un objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) représentant une présentation PowerPoint ou OpenDocument dont le texte sera extrait.  
2. Deuxièmement, une valeur `Boolean` indiquant si les diapositives maîtres doivent être incluses lors du balayage du texte de la présentation.

La méthode renvoie un tableau d'objets de type [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/), incluant les informations de mise en forme du texte. Le code ci‑dessous parcourt le texte et les détails de mise en forme d'une présentation, y compris les diapositives maîtres.
```cs
// Instancier la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
using Presentation presentation = new Presentation("demo.pptx");

// Obtenir un tableau de cadres de texte à partir de toutes les diapositives de la présentation.
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, true);

// Parcourir le tableau des cadres de texte.
for (int i = 0; i < textFrames.Length; i++)
{
    // Parcourir les paragraphes du cadre de texte actuel.
    foreach (IParagraph paragraph in textFrames[i].Paragraphs)
    {
        // Parcourir les portions de texte du paragraphe actuel.
        foreach (IPortion portion in paragraph.Portions)
        {
            // Afficher le texte de la portion de texte actuelle.
            Console.WriteLine(portion.Text);

            // Afficher la hauteur de la police du texte.
            Console.WriteLine(portion.PortionFormat.FontHeight);

            // Afficher le nom de la police du texte.
            if (portion.PortionFormat.LatinFont != null)
                Console.WriteLine(portion.PortionFormat.LatinFont.FontName);
        }
    }
}
```


## **Extraction de texte catégorisée et rapide**

La classe [PresentationFactory](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/) propose également des méthodes statiques pour extraire tout le texte des présentations :
``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```


L'argument d'énumération [TextExtractionArrangingMode](https://reference.aspose.com/slides/net/aspose.slides/textextractionarrangingmode/) indique le mode d'organisation du résultat d'extraction du texte et peut être défini sur les valeurs suivantes :
- `Unarranged` - Le texte brut sans tenir compte de sa position sur la diapositive.  
- `Arranged` - Le texte est organisé dans le même ordre que sur la diapositive.

Le mode non organisé (`Unarranged`) peut être utilisé lorsque la rapidité est cruciale ; il est plus rapide que le mode organisé.

[IPresentationText](https://reference.aspose.com/slides/net/aspose.slides/ipresentationtext/) représente le texte brut extrait de la présentation. Il contient la propriété [SlidesText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) de l'espace de noms [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/), qui renvoie un tableau d'objets de type [ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/). Chaque objet représente le texte sur la diapositive correspondante. L'objet de type [ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) possède les propriétés suivantes :

- `Text` - Le texte contenu dans les formes de la diapositive.  
- `MasterText` - Le texte contenu dans les formes de la diapositive maîtresse associée à cette diapositive.  
- `LayoutText` - Le texte contenu dans les formes de la diapositive de mise en page associée à cette diapositive.  
- `NotesText` - Le texte contenu dans les formes de la diapositive de notes associée à cette diapositive.  
- `CommentsText` - Le texte des commentaires associés à cette diapositive.  
```cs
IPresentationText text = new PresentationFactory().GetPresentationText("presentation.ppt", TextExtractionArrangingMode.Unarranged);
Console.WriteLine(text.SlidesText[0].Text);
Console.WriteLine(text.SlidesText[0].LayoutText);
Console.WriteLine(text.SlidesText[0].MasterText);
Console.WriteLine(text.SlidesText[0].NotesText);
Console.WriteLine(text.SlidesText[0].CommentsText);
```


## **FAQ**

**Quelle est la vitesse de traitement d'Aspose.Slides pour les présentations volumineuses lors de l'extraction de texte ?**

Aspose.Slides est optimisé pour des performances élevées et traite efficacement même les présentations très volumineuses, ce qui le rend adapté aux scénarios de traitement en temps réel ou en lots.

**Aspose.Slides peut-il extraire le texte des tableaux et des graphiques présents dans les présentations ?**

Oui, Aspose.Slides prend entièrement en charge l'extraction du texte des tableaux, des graphiques et d'autres éléments complexes de diapositives, vous permettant d'accéder et d'analyser facilement tout le contenu textuel.

**Ai‑je besoin d'une licence spéciale Aspose.Slides pour extraire du texte des présentations ?**

Vous pouvez extraire du texte avec la version d'essai gratuite d'Aspose.Slides, bien qu'elle comporte certaines limitations, comme le traitement d'un nombre limité de diapositives. Pour une utilisation illimitée et pour gérer de plus grandes présentations, l'achat d'une licence complète est recommandé.