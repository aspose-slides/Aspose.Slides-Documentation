---
title: Extraction avancée de texte à partir de présentations en .NET
linktitle: Extraire du texte
type: docs
weight: 90
url: /fr/net/extract-text-from-presentation/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/overview/
  - /net/slides-on-cloud-platforms/extracting-text/slides/fr/
keywords:
- extraire du texte
- extraire du texte d'une diapositive
- extraire du texte d'une présentation
- extraire du texte de PowerPoint
- extraire du texte d'OpenDocument
- extraire du texte de PPT
- extraire du texte de PPTX
- extraire du texte d'ODP
- récupérer le texte
- récupérer le texte d'une diapositive
- récupérer le texte d'une présentation
- récupérer le texte de PowerPoint
- récupérer le texte d'OpenDocument
- récupérer le texte de PPT
- récupérer le texte de PPTX
- récupérer le texte d'ODP
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Extrayez rapidement du texte des présentations PowerPoint et OpenDocument a l'aide d'Aspose.Slides pour .NET. Suivez notre guide simple, étape par étape, pour gagner du temps."
---
## **Aperçu**

L'extraction de texte à partir de présentations est une tâche courante mais essentielle pour les développeurs travaillant avec du contenu de diapositives. Que vous manipuliez des fichiers Microsoft PowerPoint au format PPT ou PPTX, ou des présentations OpenDocument (ODP), accéder aux données textuelles et les récupérer peut être crucial pour l'analyse, l'automatisation, l'indexation ou la migration de contenu.

Cet article fournit un guide complet sur la façon d'extraire efficacement du texte à partir de différents formats de présentation, notamment PPT, PPTX et ODP, en utilisant Aspose.Slides pour .NET. Vous apprendrez comment parcourir systématiquement les éléments d'une présentation afin de récupérer avec précision le contenu texte dont vous avez besoin.

## **Extraire du texte d'une diapositive**

Aspose.Slides pour .NET fournit l'espace de noms [Aspose.Slides.Util](https://reference.aspose.com/slides/fr/net/aspose.slides.util/) qui comprend la classe [SlideUtil](https://reference.aspose.com/slides/fr/net/aspose.slides.util/slideutil/). Cette classe expose plusieurs méthodes statiques surchargées pour extraire tout le texte d'une présentation ou d'une diapositive. Pour extraire du texte d'une diapositive dans une présentation, utilisez la méthode [GetAllTextBoxes](https://reference.aspose.com/slides/fr/net/aspose.slides.util/slideutil/getalltextboxes/). Cette méthode accepte un objet de type [IBaseSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseslide/) en paramètre. Lorsqu'elle est exécutée, la méthode parcourt l'intégralité de la diapositive à la recherche de texte et renvoie un tableau d'objets de type [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/), en conservant tout le formatage du texte.

Le fragment de code suivant extrait tout le texte de la première diapositive de la présentation :

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Extraire du texte d'une présentation**

Pour analyser le texte de l'ensemble de la présentation, utilisez la méthode statique [GetAllTextFrames](https://reference.aspose.com/slides/fr/net/aspose.slides.util/slideutil/getalltextframes/) exposée par la classe [SlideUtil](https://reference.aspose.com/slides/fr/net/aspose.slides.util/slideutil/). Elle accepte deux paramètres :

1. Tout d'abord, un objet [IPresentation](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentation/) représentant une présentation PowerPoint ou OpenDocument à partir de laquelle le texte sera extrait.
1. Ensuite, une valeur `Boolean` indiquant si les diapositives maîtres doivent être incluses lors de l'analyse du texte de la présentation.

La méthode renvoie un tableau d'objets de type [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/), incluant les informations de formatage du texte. Le code ci‑dessous analyse le texte et les détails de formatage d'une présentation, y compris les diapositives maîtres.

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Extraction de texte catégorisée et rapide**

La classe [PresentationFactory](https://reference.aspose.com/slides/fr/net/aspose.slides/presentationfactory/) propose également des méthodes pour extraire tout le texte des présentations :

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

L'argument enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/fr/net/aspose.slides/textextractionarrangingmode/) indique le mode d'organisation du résultat d'extraction de texte et peut être défini sur les valeurs suivantes :

- `Unarranged` - Le texte brut sans tenir compte de sa position sur la diapositive.
- `Arranged` - Le texte est organisé dans le même ordre que sur la diapositive.

Le mode non organisé peut être utilisé lorsque la vitesse est cruciale ; il est plus rapide que le mode organisé.

[IPresentationText](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationtext/) représente le texte brut extrait de la présentation. Sa propriété `SlidesText` renvoie un tableau d'objets de type [ISlideText](https://reference.aspose.com/slides/fr/net/aspose.slides/islidetext/). Chaque objet représente le texte de la diapositive correspondante. L'objet de type [ISlideText](https://reference.aspose.com/slides/fr/net/aspose.slides/islidetext/) possède les propriétés suivantes :

- `Text` - Le texte contenu dans les formes de la diapositive.
- `MasterText` - Le texte contenu dans les formes de la diapositive maîtresse associée à cette diapositive.
- `LayoutText` - Le texte contenu dans les formes de la diapositive de mise en page associée à cette diapositive.
- `NotesText` - Le texte contenu dans les formes de la diapositive de notes associée à cette diapositive.
- `CommentsText` - Le texte contenu dans les commentaires associés à cette diapositive.

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **FAQ**

**Quelle rapidité Aspose.Slides atteint‑il pour le traitement de grandes présentations lors de l'extraction de texte ?**

Aspose.Slides est optimisé pour des performances élevées et peut traiter même les [grandes présentations](/slides/fr/net/open-presentation/), ce qui le rend adapté aux scénarios de traitement en temps réel ou en volume.

**Aspose.Slides peut‑il extraire du texte des tableaux et des graphiques dans les présentations ?**

Oui. Aspose.Slides peut extraire du texte de nombreux éléments de diapositive, y compris les tableaux et les objets liés aux graphiques, vous permettant d'accéder et d'analyser le contenu textuel des structures de présentation courantes.

**Ai‑je besoin d’une licence spéciale Aspose.Slides pour extraire du texte des présentations ?**

Vous pouvez extraire du texte à l'aide de la version d'essai gratuite d'Aspose.Slides, bien qu'elle comporte [certaines limitations](/slides/fr/net/licensing/), telles que le traitement d'un nombre limité de diapositives. Pour une utilisation illimitée et pour gérer des présentations plus volumineuses, il est recommandé d'acheter une licence complète.