---
title: Convertir des présentations PowerPoint en mode Handout avec C++
linktitle: Mode Handout
type: docs
weight: 150
url: /fr/cpp/convert-powerpoint-in-handout-mode/
keywords:
- convertir PowerPoint
- convertir présentation
- mode handout
- document d'accompagnement
- PPT
- PPTX
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Convertir des présentations en documents d'accompagnement avec C++. Définir le nombre de diapositives par page, conserver les notes, exporter en PDF ou en images avec Aspose.Slides, avec du code d'exemple. Essayez-le gratuitement."
---
## **Introduction**

Aspose.Slides fournit la possibilité de convertir des présentations en différents formats, y compris la création de documents d’accompagnement pour l’impression en mode Handout. Ce mode vous permet de configurer la façon dont plusieurs diapositives apparaissent sur une même page, ce qui le rend utile pour les conférences, séminaires et autres événements. Vous pouvez activer ce mode en appelant la méthode `set_SlidesLayoutOptions` dans les interfaces [IPdfOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/ipdfoptions/),[IRenderingOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/irenderingoptions/),[IHtmlOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/ihtmloptions/), et [ITiffOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/itiffoptions/) .

Pour définir les dimensions et l’orientation de la page de document d’accompagnement avant l’exportation, consultez [Notes Page Size](/slides/fr/cpp/notes-size/) .

## **Exportation en mode Handout**

Pour configurer le mode Handout, utilisez l’objet [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/handoutlayoutingoptions/) , qui détermine le nombre de diapositives placées sur une même page ainsi que d’autres paramètres d’affichage.

Voici un exemple de code montrant comment convertir une présentation en PDF en mode Handout.

```cpp
#include <DOM/Presentation.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

### Quel est le nombre maximal de vignettes de diapositives par page en mode Handout ?

Aspose.Slides prend en charge les [préréglages](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/handouttype/) jusqu’à 9 vignettes par page avec un ordre horizontal ou vertical : 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) et 9 (horizontal/vertical).

### Puis-je définir une grille personnalisée, comme 5 ou 8 diapositives par page ?

Non. Le nombre et l’ordre des vignettes sont contrôlés strictement par l’énumération [HandoutType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/handouttype/) ; les mises en page arbitraires ne sont pas prises en charge.

### Puis-je inclure des diapositives masquées dans la sortie Handout ?

Oui. Utilisez la méthode `set_ShowHiddenSlides` dans les paramètres d’exportation du format cible, tels que [PdfOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/pdfoptions/),[HtmlOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/htmloptions/), ou [TiffOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/).