---
title: Convertir des présentations en mode Dépliant avec Python
linktitle: Mode Dépliant
type: docs
weight: 150
url: /fr/python-net/convert-powerpoint-in-Handout-mode/
keywords:
- convertir PowerPoint
- convertir présentation
- mode dépliant
- dépliant
- PowerPoint
- présentation
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Convertir des présentations en dépliants avec Python. Définir le nombre de diapositives par page, conserver les notes, exporter en PDF ou images avec Aspose.Slides, avec du code d'exemple. Essayez gratuitement."
---

## **Exportation en mode Dépliant**

Aspose.Slides offre la possibilité de convertir des présentations en différents formats, y compris la création de dépliants pour l’impression en mode Dépliant. Ce mode vous permet de configurer la façon dont plusieurs diapositives apparaissent sur une même page, ce qui le rend utile pour les conférences, séminaires et autres événements. Vous pouvez activer ce mode en définissant la propriété `slides_layout_options` dans les classes [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) et [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/).

Pour configurer le mode Dépliant, utilisez l’objet [HandoutLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/handoutlayoutingoptions/), qui détermine le nombre de diapositives placées sur une page ainsi que d’autres paramètres d’affichage.

Ci‑dessous un exemple de code illustrant comment convertir une présentation en PDF en mode Dépliant.
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

    # Exporter la présentation en PDF avec la mise en page choisie.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```


{{% alert color="warning" %}} 
Notez que la propriété `slides_layout_options` n’est disponible que pour certains formats de sortie, tels que PDF, HTML, TIFF, et lors du rendu sous forme d’images.
{{% /alert %}} 

## **FAQ**

**Quel est le nombre maximal de vignettes de diapositives par page en mode Dépliant ?**

Aspose.Slides prend en charge les [presets](https://reference.aspose.com/slides/python-net/aspose.slides.export/handouttype/) jusqu’à 9 vignettes par page avec un ordre horizontal ou vertical : 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) et 9 (horizontal/vertical).

**Puis‑je définir une grille personnalisée, par exemple 5 ou 8 diapositives par page ?**

Non. Le nombre et l’ordre des vignettes sont strictement contrôlés par l’énumération [HandoutType](https://reference.aspose.com/slides/python-net/aspose.slides.export/handouttype/) ; les mises en page arbitraires ne sont pas prises en charge.

**Puis‑je inclure les diapositives cachées dans la sortie du dépliant ?**

Oui. Activez l’option `show_hidden_slides` dans les paramètres d’exportation du format cible, comme [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) ou [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/).