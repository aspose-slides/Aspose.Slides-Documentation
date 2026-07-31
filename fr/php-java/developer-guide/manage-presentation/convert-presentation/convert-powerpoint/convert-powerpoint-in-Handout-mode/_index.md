---
title: Convertir des présentations PowerPoint en mode Handout avec PHP
linktitle: Mode Handout
type: docs
weight: 150
url: /fr/php-java/convert-powerpoint-in-handout-mode/
keywords:
- convertir PowerPoint
- convertir présentation
- mode de distribution
- distribution
- PPT
- PPTX
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Convertir des présentations en documents de distribution avec PHP. Définir le nombre de diapositives par page, conserver les notes, exporter en PDF ou en images avec Aspose.Slides pour PHP, avec un exemple de code. Essayez-le gratuitement."
---
## **Introduction**

Aspose.Slides offre la possibilité de convertir des présentations en différents formats, y compris la création de documents de distribution à imprimer en mode « Handout ». Ce mode vous permet de configurer la façon dont plusieurs diapositives apparaissent sur une seule page, ce qui est utile pour les conférences, les séminaires et d’autres événements. Vous pouvez activer ce mode en définissant la méthode `setSlidesLayoutOptions` dans les classes [PdfOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/htmloptions/) et [TiffOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tiffoptions/).

## **Exportation en mode Handout**

Pour configurer le mode Handout, utilisez l’objet [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/handoutlayoutingoptions/) qui détermine le nombre de diapositives placées sur une seule page ainsi que d’autres paramètres d’affichage.

Voici un exemple de code montrant comment convertir une présentation en PDF en mode Handout.

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

Gardez à l’esprit que la méthode `setSlidesLayoutOptions` n’est disponible que pour certains formats de sortie, tels que PDF, HTML, TIFF, et lors du rendu sous forme d’images.

{{% /alert %}} 

## **FAQ**

**Quel est le nombre maximal de vignettes de diapositives par page en mode Handout ?**

Aspose.Slides prend en charge les [préréglages](https://reference.aspose.com/slides/fr/php-java/aspose.slides/handouttype/) jusqu’à 9 vignettes par page avec un ordre horizontal ou vertical : 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) et 9 (horizontal/vertical).

**Puis‑je définir une grille personnalisée, par exemple 5 ou 8 diapositives par page ?**

Non. Le nombre et l’ordre des vignettes sont contrôlés strictement par la classe [HandoutType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/handouttype/) ; les dispositions arbitraires ne sont pas prises en charge.

**Puis‑je inclure les diapositives masquées dans la sortie Handout ?**

Oui. Activez les diapositives masquées en utilisant la méthode `setShowHiddenSlides` dans les paramètres d’exportation du format cible, tel que [PdfOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/htmloptions/) ou [TiffOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tiffoptions/).