---
title: Convertir des présentations PowerPoint en mode Livret avec Java
linktitle: Mode Livret
type: docs
weight: 150
url: /fr/java/convert-powerpoint-in-handout-mode/
keywords:
- convertir PowerPoint
- convertir présentation
- mode livret
- livret
- PPT
- PPTX
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Convertir des présentations en livret avec Java. Définir le nombre de diapositives par page, conserver les notes, exporter en PDF ou en images avec Aspose.Slides, avec un exemple de code Java. Essayez gratuitement."
---
## **Introduction**

Aspose.Slides vous permet de convertir des présentations vers des formats de sortie qui prennent en charge le mode Livret. Dans ce mode, plusieurs diapositives sont disposées sur une même page, ce qui est utile pour imprimer le matériel de présentation pour des conférences, séminaires et événements similaires.

Le mode Livret est configuré via la méthode `setSlidesLayoutOptions`, qui est disponible dans [IPdfOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ihtmloptions/) et [ITiffOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiffoptions/). Pour définir la disposition du livret, utilisez l'objet [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/handoutlayoutingoptions/).

Pour définir les dimensions et l'orientation de la page du livret avant l'exportation, consultez [Taille de la page des notes](/slides/fr/java/notes-size/).

## **Exportation du mode Livret**

Pour exporter une présentation en mode Livret, définissez la méthode `setSlidesLayoutOptions` pour les options d'exportation cibles et affectez une instance de [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/handoutlayoutingoptions/) qui définit le nombre de diapositives par page et les paramètres d'affichage associés.

Ci-dessous un exemple de code montrant comment convertir une présentation en PDF en mode Livret.

```java
import com.aspose.slides.*;

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

    // Exporter la présentation en PDF avec la disposition choisie.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" title="Warning" %}}
Gardez à l'esprit que la méthode `setSlidesLayoutOptions` n'est disponible que pour certains formats de sortie, tels que PDF, HTML, TIFF, et lors du rendu sous forme d'images.
{{% /alert %}} 

## **FAQ**

**Quel est le nombre maximal de vignettes de diapositives par page en mode Livret ?**

Aspose.Slides prend en charge les [presets](https://reference.aspose.com/slides/fr/java/com.aspose.slides/handouttype/) jusqu'à 9 vignettes par page avec un ordre horizontal ou vertical : 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) et 9 (horizontal/vertical).

**Puis-je définir une grille personnalisée, comme 5 ou 8 diapositives par page ?**

Non. Le nombre et l'ordre des vignettes sont strictement contrôlés par la classe [HandoutType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/handouttype/) ; les mises en page arbitraires ne sont pas prises en charge.

**Puis-je inclure des diapositives masquées dans la sortie du livret ?**

Oui. Activez les diapositives masquées en utilisant la méthode `setShowHiddenSlides` dans les paramètres d'exportation du format cible, tels que [PdfOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/htmloptions/) ou [TiffOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/tiffoptions/).