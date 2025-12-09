---
title: Convertir des présentations PowerPoint en mode Feuillet sous .NET
linktitle: Mode Feuillet
type: docs
weight: 150
url: /fr/net/convert-powerpoint-in-Handout-mode/
keywords:
- convertir PowerPoint
- convertir présentation
- mode Feuillet
- feuillet
- PowerPoint
- présentation
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Convertissez des présentations en feuillets sous .NET. Définissez le nombre de diapositives par page, conservez les notes, exportez en PDF ou images avec Aspose.Slides, avec du code C# d'exemple. Essayez-le gratuitement."
---

## **Exportation du mode Feuillet**

Aspose.Slides offre la possibilité de convertir des présentations en divers formats, y compris la création de fiches pour l’impression en mode Feuillet. Ce mode vous permet de configurer la façon dont plusieurs diapositives apparaissent sur une seule page, ce qui le rend utile pour les conférences, séminaires et autres événements. Vous pouvez activer ce mode en définissant la propriété `SlidesLayoutOptions` dans les interfaces [IPdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmloptions/) et [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/).

Pour configurer le mode Feuillet, utilisez l’objet [HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/), qui détermine le nombre de diapositives placées sur une seule page ainsi que d’autres paramètres d’affichage.

Ci‑dessous un exemple de code montrant comment convertir une présentation en PDF en mode Feuillet.
```c#
// Charger une présentation.
using var presentation = new Presentation("sample.pptx");

// Définir les options d'exportation.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 diapositives sur une page horizontalement
        PrintSlideNumbers = true,                   // imprimer les numéros de diapositives
        PrintFrameSlide = true,                     // imprimer un cadre autour des diapositives
        PrintComments = false                       // pas de commentaires
    }
};

// Exporter la présentation en PDF avec la mise en page choisie.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```


{{% alert color="warning" %}} 
Gardez à l’esprit que la propriété `SlidesLayoutOptions` n’est disponible que pour certains formats de sortie, tels que PDF, HTML, TIFF, et lors du rendu en tant qu’images.
{{% /alert %}} 

## **FAQ**

**Quel est le nombre maximal de vignettes de diapositives par page en mode Feuillet ?**

Aspose.Slides prend en charge les [préréglages](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) jusqu’à 9 vignettes par page avec un ordre horizontal ou vertical : 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) et 9 (horizontal/vertical).

**Puis‑je définir une grille personnalisée, comme 5 ou 8 diapositives par page ?**

Non. Le nombre et l’ordre des vignettes sont contrôlés strictement par l’énumération [HandoutType](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) ; les mises en page arbitraires ne sont pas prises en charge.

**Puis‑je inclure des diapositives masquées dans la sortie du Feuillet ?**

Oui. Activez l’option `ShowHiddenSlides` dans les paramètres d’exportation pour le format cible, tel que [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/) ou [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/).