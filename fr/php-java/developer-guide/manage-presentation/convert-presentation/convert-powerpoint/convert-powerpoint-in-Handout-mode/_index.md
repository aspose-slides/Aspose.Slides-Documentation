---
title: Convertir des présentations PowerPoint en mode Handout avec PHP
linktitle: Mode Handout
type: docs
weight: 150
url: /fr/php-java/convert-powerpoint-in-handout-mode/
keywords:
- convertir PowerPoint
- convertir présentation
- mode Handout
- handout
- PPT
- PPTX
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Convertissez des présentations en fiches avec PHP. Définissez le nombre de diapositives par page, conservez les notes, exportez en PDF ou en images avec Aspose.Slides pour PHP, avec du code d'exemple. Essayez gratuitement."
---
## **Introduction**

Aspose.Slides offre la possibilité de convertir des présentations en divers formats, y compris la création de notes de cours pour l'impression en mode Handout. Ce mode vous permet de configurer la façon dont plusieurs diapositives apparaissent sur une même page, ce qui le rend utile pour les conférences, les séminaires et autres événements. Vous pouvez activer ce mode en définissant la méthode `setSlidesLayoutOptions` dans les classes [PdfOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/htmloptions/) et [TiffOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tiffoptions/).

Pour définir les dimensions et l'orientation de la page de notes avant l'exportation, consultez [Taille de la page de notes](/slides/fr/php-java/notes-size/).

## **Exportation en mode Handout**

Pour configurer le mode Handout, utilisez l'objet [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/handoutlayoutingoptions/), qui détermine le nombre de diapositives placées sur une page unique ainsi que d'autres paramètres d'affichage.

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

// Exporter la présentation en PDF avec la mise en page choisie.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" title="Warning" %}}
Gardez à l'esprit que la méthode `setSlidesLayoutOptions` n'est disponible que pour certains formats de sortie, tels que PDF, HTML, TIFF, et lors du rendu sous forme d'images.
{{% /alert %}} 

## **FAQ**

**Quel est le nombre maximal de vignettes de diapositives par page en mode Handout ?**

Aspose.Slides prend en charge les [préréglages](https://reference.aspose.com/slides/fr/php-java/aspose.slides/handouttype/) jusqu'à 9 vignettes par page avec un ordre horizontal ou vertical : 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) et 9 (horizontal/vertical).

**Puis-je définir une grille personnalisée, comme 5 ou 8 diapositives par page ?**

Non. Le nombre et l'ordre des vignettes sont contrôlés strictement par la classe [HandoutType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/handouttype/) ; les mises en page arbitraires ne sont pas prises en charge.

**Puis-je inclure des diapositives cachées dans la sortie Handout ?**

Oui. Activez les diapositives cachées en utilisant la méthode `setShowHiddenSlides` dans les paramètres d'exportation du format cible, tel que [PdfOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/htmloptions/) ou [TiffOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tiffoptions/).