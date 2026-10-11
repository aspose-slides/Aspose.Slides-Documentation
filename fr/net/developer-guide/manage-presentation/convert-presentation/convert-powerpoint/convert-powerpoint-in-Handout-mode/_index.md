---
title: Convertir des présentations PowerPoint en mode Feuillet dans .NET
linktitle: Mode Feuillet
type: docs
weight: 150
url: /fr/net/convert-powerpoint-in-handout-mode/
keywords:
- convertir PowerPoint
- convertir présentation
- mode feuillet
- feuillet
- PowerPoint
- présentation
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Convertir des présentations en feuillets dans .NET. Définir le nombre de diapositives par page, conserver les notes, exporter en PDF ou images avec Aspose.Slides, avec un exemple de code C#. Essayez-le gratuitement."
---
## **Introduction**

Aspose.Slides vous permet de convertir des présentations vers des formats de sortie qui prennent en charge le mode Feuillet. Dans ce mode, plusieurs diapositives sont disposées sur une même page, ce qui est utile pour imprimer le matériel de présentation pour des conférences, séminaires et événements similaires.

Le mode Feuillet est configuré via la propriété `SlidesLayoutOptions`, qui est disponible dans [IPdfOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/ihtmloptions/), et [ITiffOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/itiffoptions/). Pour définir la disposition du feuillet, utilisez l'objet [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/handoutlayoutingoptions/) .

Pour définir les dimensions et l'orientation de la page du feuillet avant l'exportation, voir [Notes Page Size](/slides/fr/net/notes-size/).

## **Export en mode Feuillet**

Pour exporter une présentation en mode Feuillet, définissez la propriété `SlidesLayoutOptions` pour les options d'exportation cibles et assignez une instance [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/handoutlayoutingoptions/) qui définit le nombre de diapositives par page et les paramètres d'affichage associés.

Ci-dessous un exemple de code montrant comment convertir une présentation en PDF en mode Feuillet.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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
Gardez à l'esprit que la propriété `SlidesLayoutOptions` n'est disponible que pour certains formats de sortie, tels que PDF, HTML, TIFF, et lors du rendu sous forme d'images.
{{% /alert %}} 

## **FAQ**

### Quel est le nombre maximum de miniatures de diapositives par page en mode Feuillet ?

Aspose.Slides prend en charge les [presets](https://reference.aspose.com/slides/fr/net/aspose.slides.export/handouttype/) jusqu'à 9 miniatures par page avec un ordre horizontal ou vertical : 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) et 9 (horizontal/vertical).

### Puis-je définir une grille personnalisée, comme 5 ou 8 diapositives par page ?

Non. Le nombre et l'ordre des miniatures sont contrôlés strictement par l'énumération [HandoutType](https://reference.aspose.com/slides/fr/net/aspose.slides.export/handouttype/) ; les mises en page arbitraires ne sont pas prises en charge.

### Puis-je inclure des diapositives masquées dans la sortie du mode Feuillet ?

Oui. Activez l'option `ShowHiddenSlides` dans les paramètres d'exportation du format cible, tel que [PdfOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/htmloptions/) ou [TiffOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions/).