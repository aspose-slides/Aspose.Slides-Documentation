---
title: Convertir les présentations PowerPoint en mode Handout en Java
linktitle: Mode Handout
type: docs
weight: 150
url: /fr/java/convert-powerpoint-in-Handout-mode/
keywords:
- convertir PowerPoint
- convertir présentation
- mode handout
- document
- PPT
- PPTX
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Convertir des présentations en documents de distribution en Java. Définir le nombre de diapositives par page, conserver les notes, exporter en PDF ou en images avec Aspose.Slides, avec un exemple de code Java. Essayez-le gratuitement."
---

Aspose.Slides offre la possibilité de convertir des présentations en différents formats, y compris la création de documents de distribution pour l’impression en mode Handout. Ce mode vous permet de configurer la façon dont plusieurs diapositives apparaissent sur une même page, ce qui le rend utile pour les conférences, les séminaires et d’autres événements. Vous pouvez activer ce mode en définissant la méthode `setSlidesLayoutOptions` dans les interfaces [IPdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ihtmloptions/) et [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/itiffoptions/).

Pour configurer le mode Handout, utilisez l’objet [HandoutLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/handoutlayoutingoptions/), qui détermine le nombre de diapositives placées sur une même page ainsi que d’autres paramètres d’affichage.

Voici un exemple de code montrant comment convertir une présentation en PDF en mode Handout.
```java
// Charger une présentation.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Définir les options d'exportation.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 diapositives sur une page horizontalement
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // imprimer les numéros des diapositives
    slidesLayoutOptions.setPrintFrameSlide(true);                     // imprimer un cadre autour des diapositives
    slidesLayoutOptions.setPrintComments(false);                      // aucun commentaire

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Exporter la présentation en PDF avec la disposition choisie.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```


{{% alert color="warning" %}} 
Gardez à l’esprit que la méthode `setSlidesLayoutOptions` n’est disponible que pour certains formats de sortie, tels que PDF, HTML, TIFF, et lors du rendu sous forme d’images.
{{% /alert %}}