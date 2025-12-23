---
title: Convertir des présentations PowerPoint en mode fiche avec PHP
linktitle: Mode fiche
type: docs
weight: 150
url: /fr/php-java/convert-powerpoint-in-Handout-mode/
keywords:
- convertir PowerPoint
- convertir présentation
- mode fiche
- fiche
- PPT
- PPTX
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Convertir des présentations en fiches avec PHP. Définissez le nombre de diapositives par page, conservez les notes, exportez en PDF ou en images avec Aspose.Slides pour PHP, avec du code d'exemple. Essayez-le gratuitement."
---

## **Exportation du mode Fiche**

Aspose.Slides offre la possibilité de convertir des présentations en plusieurs formats, y compris la création de fiches pour impression en mode Handout. Ce mode vous permet de configurer comment plusieurs diapositives apparaissent sur une seule page, ce qui le rend utile pour les conférences, séminaires et autres événements. Vous pouvez activer ce mode en définissant la méthode `setSlidesLayoutOptions` dans les classes [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/htmloptions/) et [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/).

Pour configurer le mode Handout, utilisez l'objet [HandoutLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/handoutlayoutingoptions/), qui détermine le nombre de diapositives placées sur une seule page ainsi que d'autres paramètres d'affichage.

Ci-dessous un exemple de code montrant comment convertir une présentation en PDF en mode Handout.
```php
// Charger une présentation.
$presentation = new Presentation("sample.pptx");

// Définir les options d'exportation.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 diapositives sur une page horizontalement
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // imprimer les numéros de diapositive
$slidesLayoutOptions->setPrintFrameSlide(true);                      // imprimer un cadre autour des diapositives
$slidesLayoutOptions->setPrintComments(false);                       // aucun commentaire

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Exporter la présentation en PDF avec la disposition choisie.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```


{{% alert color="warning" %}} 
Gardez à l'esprit que la méthode `setSlidesLayoutOptions` n'est disponible que pour certains formats de sortie, tels que PDF, HTML, TIFF, et lors du rendu sous forme d'images.
{{% /alert %}} 

## **FAQ**

**Quel est le nombre maximal de vignettes de diapositive par page en mode Handout ?**

Aspose.Slides prend en charge les [préréglages](https://reference.aspose.com/slides/php-java/aspose.slides/handouttype/) jusqu'à 9 vignettes par page avec un ordre horizontal ou vertical : 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) et 9 (horizontal/vertical).

**Puis-je définir une grille personnalisée, comme 5 ou 8 diapositives par page ?**

Non. Le nombre et l'ordre des vignettes sont contrôlés strictement par la classe [HandoutType](https://reference.aspose.com/slides/php-java/aspose.slides/handouttype/) ; les mises en page arbitraires ne sont pas prises en charge.

**Puis-je inclure des diapositives masquées dans la sortie Handout ?**

Oui. Activez les diapositives masquées en utilisant la méthode `setShowHiddenSlides` dans les paramètres d'exportation du format cible, tel que [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/htmloptions/) ou [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/).