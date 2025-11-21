---
title: Convertir des présentations en mode Handout en JavaScript
type: docs
weight: 150
url: /fr/nodejs-java/convert-powerpoint-in-Handout-mode/
keywords:
- convertir PowerPoint
- mode Handout
- document de distribution
- PowerPoint
- PPT
- PPTX
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir des présentations en mode Handout en JavaScript"
---

## **Exportation du mode Handout**

Aspose.Slides offre la possibilité de convertir des présentations en différents formats, y compris la création de documents de distribution pour l’impression en mode Handout. Ce mode vous permet de configurer la façon dont plusieurs diapositives apparaissent sur une seule page, ce qui le rend utile pour les conférences, les séminaires et autres événements. Vous pouvez activer ce mode en définissant la méthode `setSlidesLayoutOptions` dans les classes [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/) et [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/).

Pour configurer le mode Handout, utilisez l’objet [HandoutLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handoutlayoutingoptions/) qui détermine combien de diapositives sont placées sur une seule page et d’autres paramètres d’affichage.

Ci-dessous un exemple de code montrant comment convertir une présentation en PDF en mode Handout.
```js
// Charger une présentation.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Définir les options d'exportation.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 diapositives sur une page horizontalement
slidesLayoutOptions.setPrintSlideNumbers(true);                                // imprimer les numéros de diapositives
slidesLayoutOptions.setPrintFrameSlide(true);                                  // imprimer un cadre autour des diapositives
slidesLayoutOptions.setPrintComments(false);                                   // pas de commentaires

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Exporter la présentation en PDF avec la mise en page choisie.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```


{{% alert color="warning" %}} 
Gardez à l’esprit que la méthode `setSlidesLayoutOptions` n’est disponible que pour certains formats de sortie, tels que PDF, HTML, TIFF, et lors du rendu sous forme d’images.
{{% /alert %}} 

## **FAQ**

**Quel est le nombre maximum de miniatures de diapositives par page en mode Handout ?**

Aspose.Slides prend en charge les [presets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handouttype/) jusqu’à 9 miniatures par page avec un ordre horizontal ou vertical : 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) et 9 (horizontal/vertical).

**Puis-je définir une grille personnalisée, par exemple 5 ou 8 diapositives par page ?**

Non. Le nombre et l’ordre des miniatures sont contrôlés strictement par l’énumération [HandoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handouttype/) ; les mises en page arbitraires ne sont pas prises en charge.

**Puis-je inclure les diapositives masquées dans la sortie Handout ?**

Oui. Utilisez la méthode `setShowHiddenSlides` dans les paramètres d’exportation du format cible, comme [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/) ou [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/).