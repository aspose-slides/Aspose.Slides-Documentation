---
title: Convertir des présentations en mode Handout avec Python
linktitle: Mode Handout
type: docs
weight: 150
url: /fr/python-net/convert-powerpoint-in-handout-mode/
keywords:
- convertir PowerPoint
- convertir présentation
- mode Handout
- notes de cours
- PowerPoint
- présentation
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Convertir des présentations en notes de cours avec Python. Définissez le nombre de diapositives par page, conservez les notes, exportez en PDF ou en images avec Aspose.Slides, avec du code d'exemple. Essayez-le gratuitement."
---
## **Introduction**

Aspose.Slides offre la possibilité de convertir les présentations en divers formats, y compris la création de notes de cours pour l'impression en mode Handout. Ce mode vous permet de configurer la façon dont plusieurs diapositives apparaissent sur une même page, ce qui le rend utile pour les conférences, séminaires et autres événements. Vous pouvez activer ce mode en définissant la propriété `slides_layout_options` dans les classes [PdfOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/htmloptions/), et [TiffOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/tiffoptions/) .

## **Exportation du mode Handout**

Pour configurer le mode Handout, utilisez l'objet [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/handoutlayoutingoptions/) qui détermine le nombre de diapositives placées sur une page unique et d'autres paramètres d'affichage.

Voici un exemple de code montrant comment convertir une présentation en PDF en mode Handout.

```py
# Charger une présentation.
with slides.Presentation("sample.pptx") as presentation:

    # Définir les options d'exportation.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 diapositives sur une page horizontalement
    slides_layout_options.print_slide_numbers = True                                 # imprimer les numéros de diapositives
    slides_layout_options.print_frame_slide = True                                   # imprimer un cadre autour des diapositives
    slides_layout_options.print_comments = False                                     # pas de commentaires

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Exporter la présentation en PDF avec la disposition choisie.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
Gardez à l'esprit que la propriété `slides_layout_options` n'est disponible que pour certains formats de sortie, tels que PDF, HTML, TIFF, et lors du rendu sous forme d'images.
{{% /alert %}} 

## **FAQ**

**Quel est le nombre maximal de miniatures de diapositives par page en mode Handout ?**

Aspose.Slides prend en charge les [presets](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/handouttype/) jusqu'à 9 miniatures par page avec un agencement horizontal ou vertical : 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) et 9 (horizontal/vertical).

**Puis-je définir une grille personnalisée, comme 5 ou 8 diapositives par page ?**

Non. Le nombre et l'ordre des miniatures sont contrôlés strictement par l'énumération [HandoutType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/handouttype/) ; les dispositions arbitraires ne sont pas prises en charge.

**Puis-je inclure des diapositives cachées dans la sortie Handout ?**

Oui. Activez l'option `show_hidden_slides` dans les paramètres d'exportation du format cible, tel que [PdfOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/htmloptions/), ou [TiffOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/tiffoptions/).