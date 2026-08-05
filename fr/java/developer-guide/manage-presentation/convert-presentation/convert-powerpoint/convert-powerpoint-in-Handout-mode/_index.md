---
title: Convertir des présentations PowerPoint en mode support avec Java
linktitle: Mode support
type: docs
weight: 150
url: /fr/java/convert-powerpoint-in-handout-mode/
keywords:
- convertir PowerPoint
- convertir présentation
- mode support
- support
- PPT
- PPTX
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Convertissez des présentations en supports en Java. Définissez le nombre de diapositives par page, conservez les notes, exportez en PDF ou en images avec Aspose.Slides, avec un exemple de code Java. Essayez-le gratuitement."
---
## **Introduction**

Aspose.Slides vous permet de convertir des présentations vers des formats de sortie qui prennent en charge le mode Handout. Dans ce mode, plusieurs diapositives sont disposées sur une même page, ce qui est utile pour imprimer le matériel de présentation pour des conférences, des séminaires et des événements similaires.

Le mode Handout est configuré via la méthode `setSlidesLayoutOptions`, qui est disponible dans [IPdfOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ihtmloptions/) et [ITiffOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiffoptions/). Pour définir la disposition du Handout, utilisez l’objet [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/handoutlayoutingoptions/).

## **Exportation en mode Handout**

Pour exporter une présentation en mode Handout, définissez la méthode `setSlidesLayoutOptions` pour les options d’exportation cibles et assignez une instance [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/handoutlayoutingoptions/) qui définit le nombre de diapositives par page ainsi que les paramètres d’affichage associés.

Voici un exemple de code montrant comment convertir une présentation en PDF en mode Handout.

```java
// Charger une présentation.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Définir les options d'exportation.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 diapositives sur une page horizontalement
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // imprimer les numéros de diapositives
    slidesLayoutOptions.setPrintFrameSlide(true);                     // imprimer un cadre autour des diapositives
    slidesLayoutOptions.setPrintComments(false);                      // pas de commentaires

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Exporter la présentation en PDF avec la mise en page choisie.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 
Gardez à l’esprit que la méthode `setSlidesLayoutOptions` n’est disponible que pour certains formats de sortie, tels que PDF, HTML, TIFF, et lors du rendu en tant qu’images.
{{% /alert %}} 

## **FAQ**

**Quel est le nombre maximal de vignettes de diapositives par page en mode Handout ?**

Aspose.Slides prend en charge les [préréglages](https://reference.aspose.com/slides/fr/java/com.aspose.slides/handouttype/) jusqu’à 9 vignettes par page avec un agencement horizontal ou vertical : 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) et 9 (horizontal/vertical).

**Puis-je définir une grille personnalisée, par exemple 5 ou 8 diapositives par page ?**

Non. Le nombre et l’ordre des vignettes sont contrôlés strictement par la classe [HandoutType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/handouttype/) ; les mises en page arbitraires ne sont pas prises en charge.

**Puis-je inclure des diapositives masquées dans la sortie Handout ?**

Oui. Activez les diapositives masquées en utilisant la méthode `setShowHiddenSlides` dans les paramètres d’exportation pour le format cible, tels que [PdfOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/htmloptions/) ou [TiffOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/tiffoptions/).