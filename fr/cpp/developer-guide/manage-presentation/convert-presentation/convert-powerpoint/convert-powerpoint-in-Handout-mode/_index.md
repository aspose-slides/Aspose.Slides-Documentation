---
title: Convertir des présentations PowerPoint en mode Feuille de distribution avec C++
linktitle: Mode Feuille de distribution
type: docs
weight: 150
url: /fr/cpp/convert-powerpoint-in-Handout-mode/
keywords:
- convertir PowerPoint
- convertir présentation
- mode feuille de distribution
- feuille de distribution
- PPT
- PPTX
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Convertir des présentations en feuilles de distribution avec C++. Définir le nombre de diapositives par page, conserver les notes, exporter en PDF ou images avec Aspose.Slides, avec du code d'exemple. Essayez gratuitement."
---

## **Exportation du mode Feuille de distribution**

Aspose.Slides offre la possibilité de convertir des présentations en divers formats, y compris la création de feuilles de distribution pour l’impression en mode Handout. Ce mode vous permet de configurer la façon dont plusieurs diapositives apparaissent sur une même page, ce qui est utile pour les conférences, séminaires et autres événements. Vous pouvez activer ce mode en définissant la méthode `set_SlidesLayoutOptions` dans les interfaces [IPdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ihtmloptions/) et [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/).

Pour configurer le mode Handout, utilisez l’objet [HandoutLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/handoutlayoutingoptions/), qui détermine le nombre de diapositives placées sur une page ainsi que d’autres paramètres d’affichage.

Vous trouverez ci‑dessous un exemple de code montrant comment convertir une présentation en PDF en mode Handout.
```cpp
// Charger une présentation.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Définir les options d'exportation.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 diapositives sur une page horizontalement
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // imprimer les numéros de diapositives
slidesLayoutOptions->set_PrintFrameSlide(true);                      // imprimer un cadre autour des diapositives
slidesLayoutOptions->set_PrintComments(false);                       // pas de commentaires

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Exporter la présentation en PDF avec la mise en page choisie.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```


{{% alert color="warning" %}} 

Gardez à l’esprit que la méthode `set_SlidesLayoutOptions` n’est disponible que pour certains formats de sortie, tels que PDF, HTML, TIFF, et lors du rendu sous forme d’images.

{{% /alert %}} 

## **FAQ**

**Quel est le nombre maximal de vignettes de diapositives par page en mode Handout ?**

Aspose.Slides prend en charge les [préréglages](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) allant jusqu’à 9 vignettes par page avec un ordre horizontal ou vertical : 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) et 9 (horizontal/vertical).

**Puis‑je définir une grille personnalisée, par exemple 5 ou 8 diapositives par page ?**

Non. Le nombre et l’ordre des vignettes sont contrôlés strictement par l’énumération [HandoutType](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) ; les dispositions arbitraires ne sont pas prises en charge.

**Puis‑je inclure les diapositives masquées dans la sortie Handout ?**

Oui. Utilisez la méthode `set_ShowHiddenSlides` dans les paramètres d’exportation du format cible, tel que [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/) ou [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/).