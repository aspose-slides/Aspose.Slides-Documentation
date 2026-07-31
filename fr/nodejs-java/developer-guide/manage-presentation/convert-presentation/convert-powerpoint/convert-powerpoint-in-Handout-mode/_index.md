---
title: Convertir des présentations PowerPoint en mode Handout avec JavaScript
linktitle: Mode Handout
type: docs
weight: 150
url: /fr/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- convertir PowerPoint
- convertir présentation
- mode handout
- handout
- PPT
- PPTX
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertissez des présentations en documents de distribution. Définissez le nombre de diapositives par page, conservez les notes, exportez au PDF ou en images avec Aspose.Slides pour Node.js, avec du code d'exemple. Essayez-le gratuitement."
---
## **Introduction**

Aspose.Slides offre la possibilité de convertir des présentations en divers formats, y compris la création de documents de distribution pour l'impression en mode Handout. Ce mode vous permet de configurer la façon dont plusieurs diapositives apparaissent sur une seule page, ce qui le rend utile pour les conférences, séminaires et autres événements. Vous pouvez activer ce mode en définissant la méthode `setSlidesLayoutOptions` dans les classes [PdfOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/htmloptions/), et [TiffOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/tiffoptions/).

## **Exportation du mode Handout**

Pour configurer le mode Handout, utilisez l'objet [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/handoutlayoutingoptions/), qui détermine le nombre de diapositives placées sur une seule page ainsi que d'autres paramètres d'affichage.

Voici un exemple de code montrant comment convertir une présentation en PDF en mode Handout.

```js
// Charger une présentation.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Définir les options d'exportation.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 diapositives sur une page horizontalement
slidesLayoutOptions.setPrintSlideNumbers(true);                                // imprimer les numéros de diapositives
slidesLayoutOptions.setPrintFrameSlide(true);                                  // imprimer un cadre autour des diapositives
slidesLayoutOptions.setPrintComments(false);                                   // aucun commentaire

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Exporter la présentation au PDF avec la mise en page choisie.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
Notez que la méthode `setSlidesLayoutOptions` n'est disponible que pour certains formats de sortie, tels que PDF, HTML, TIFF, et lors du rendu sous forme d'images.
{{% /alert %}} 

## **FAQ**

**Quel est le nombre maximal de vignettes de diapositives par page en mode Handout ?**

Aspose.Slides prend en charge les [préréglages](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/handouttype/) jusqu'à 9 vignettes par page avec un ordre horizontal ou vertical : 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) et 9 (horizontal/vertical).

**Puis-je définir une grille personnalisée, par exemple 5 ou 8 diapositives par page ?**

Non. Le nombre et l'ordre des vignettes sont strictement contrôlés par l'énumération [HandoutType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/handouttype/); les dispositions arbitraires ne sont pas prises en charge.

**Puis-je inclure des diapositives masquées dans la sortie Handout ?**

Oui. Utilisez la méthode `setShowHiddenSlides` dans les paramètres d'exportation du format cible, comme [PdfOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/htmloptions/), ou [TiffOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/tiffoptions/).