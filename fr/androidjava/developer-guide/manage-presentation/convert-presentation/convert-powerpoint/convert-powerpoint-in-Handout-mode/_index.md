---
title: Convertir des présentations PowerPoint en mode distribution sur Android
linktitle: Mode distribution
type: docs
weight: 150
url: /fr/androidjava/convert-powerpoint-in-Handout-mode/
keywords:
- convertir PowerPoint
- convertir présentation
- mode distribution
- distribution
- PPT
- PPTX
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Convertissez les présentations en fiches de distribution en Java. Définissez le nombre de diapositives par page, conservez les notes, exportez au format PDF ou images avec Aspose.Slides pour Android, avec un exemple de code. Essayez-le gratuitement."
---

## **Exportation du mode distribution**

Aspose.Slides offre la possibilité de convertir des présentations en divers formats, y compris la création de fiches de distribution pour l’impression en mode Distribution. Ce mode vous permet de configurer la manière dont plusieurs diapositives apparaissent sur une même page, ce qui est utile pour les conférences, séminaires et autres événements. Vous pouvez activer ce mode en définissant la méthode `setSlidesLayoutOptions` dans les interfaces [IPdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihtmloptions/), et [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/).

Pour configurer le mode Distribution, utilisez l’objet [HandoutLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handoutlayoutingoptions/), qui détermine combien de diapositives sont placées sur une seule page ainsi que d’autres paramètres d’affichage.

Vous trouverez ci‑dessous un exemple de code montrant comment convertir une présentation en PDF en mode Distribution.
```java
// Charger une présentation.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Définir les options d'exportation.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 diapositives sur une page horizontalement
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // imprimer les numéros de diapositives
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

Gardez à l’esprit que la méthode `setSlidesLayoutOptions` n’est disponible que pour certains formats de sortie, tels que PDF, HTML, TIFF, et lors du rendu en images.

{{% /alert %}} 

## **FAQ**

**Quel est le nombre maximal de vignettes de diapositives par page en mode Distribution ?**

Aspose.Slides prend en charge les [préréglages](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/) jusqu’à 9 vignettes par page avec un ordre horizontal ou vertical : 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) et 9 (horizontal/vertical).

**Puis‑je définir une grille personnalisée, par exemple 5 ou 8 diapositives par page ?**

Non. Le nombre et l’ordre des vignettes sont contrôlés strictement par la classe [HandoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/) ; les dispositions arbitraires ne sont pas prises en charge.

**Puis‑je inclure les diapositives masquées dans la sortie Distribution ?**

Oui. Activez les diapositives masquées en utilisant la méthode `setShowHiddenSlides` dans les paramètres d’exportation du format cible, tels que [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/htmloptions/), ou [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/).