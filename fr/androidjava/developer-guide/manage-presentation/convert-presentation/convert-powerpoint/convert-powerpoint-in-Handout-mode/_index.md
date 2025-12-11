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
description: "Convertir les présentations en documents de distribution en Java. Définir le nombre de diapositives par page, conserver les notes, exporter en PDF ou images avec Aspose.Slides pour Android, avec du code d'exemple. Essayez gratuitement."
---

## **Exportation du mode Handout**

Aspose.Slides offre la possibilité de convertir des présentations en divers formats, y compris la création de feuilles de distribution pour l’impression en mode Handout. Ce mode vous permet de configurer la façon dont plusieurs diapositives apparaissent sur une même page, ce qui le rend utile pour les conférences, séminaires et autres événements. Vous pouvez activer ce mode en définissant la méthode `setSlidesLayoutOptions` dans les interfaces [IPdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihtmloptions/), et [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) .

Pour configurer le mode Handout, utilisez l’objet [HandoutLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handoutlayoutingoptions/) qui détermine le nombre de diapositives placées sur une seule page ainsi que d’autres paramètres d’affichage.

Ci‑dessous un exemple de code montrant comment convertir une présentation en PDF en mode Handout.
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
Notez que la méthode `setSlidesLayoutOptions` n’est disponible que pour certains formats de sortie, tels que PDF, HTML, TIFF, et lors du rendu sous forme d’images.
{{% /alert %}} 

## **FAQ**

**Quel est le nombre maximal de miniatures de diapositives par page en mode Handout ?**

Aspose.Slides prend en charge les [presets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/) jusqu’à 9 miniatures par page avec un ordre horizontal ou vertical : 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) et 9 (horizontal/vertical).

**Puis‑je définir une grille personnalisée, par exemple 5 ou 8 diapositives par page ?**

Non. Le nombre et l’ordre des miniatures sont contrôlés strictement par la classe [HandoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/) ; les dispositions arbitraires ne sont pas prises en charge.

**Puis‑je inclure des diapositives cachées dans la sortie Handout ?**

Oui. Activez les diapositives cachées en utilisant la méthode `setShowHiddenSlides` dans les paramètres d’exportation du format cible, tels que [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/htmloptions/), ou [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/).