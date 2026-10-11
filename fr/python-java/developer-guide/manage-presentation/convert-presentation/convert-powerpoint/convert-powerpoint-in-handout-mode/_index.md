---
title: Convertir des présentations PowerPoint en mode d'accompagnement avec Python
linktitle: Mode d'accompagnement
type: docs
weight: 150
url: /fr/python-java/convert-powerpoint-in-handout-mode/
keywords:
- convertir PowerPoint
- convertir présentation
- mode d'accompagnement
- accompagnement
- PPT
- PPTX
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Convertir des présentations PowerPoint en mode d'accompagnement avec Python via Java. Disposer plusieurs diapositives par page et exporter en PDF avec Aspose.Slides."
---
## **Introduction**

Aspose.Slides for Python via Java vous permet d'exporter des présentations en mode diapositive d’accompagnement, en disposant plusieurs diapositives sur une seule page. Cela est utile pour imprimer du matériel de présentation pour des conférences, séminaires et événements similaires.

Configurez la mise en page via la méthode [setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions). Les dispositions de diapositive d’accompagnement sont prises en charge par [PdfOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmloptions/) et [TiffOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tiffoptions/). Utilisez un objet [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/handoutlayoutingoptions/) pour spécifier les paramètres de mise en page et d’affichage.

Pour définir les dimensions et l’orientation de la page d’accompagnement avant l’exportation, consultez [Notes Page Size](/slides/fr/python-java/notes-size/).

## **Export en mode diapositive d’accompagnement**

Pour exporter une présentation en mode diapositive d’accompagnement, créez une instance [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/handoutlayoutingoptions/) et affectez‑la aux options d’exportation cibles à l’aide de [setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

L’exemple suivant charge `sample.pptx` et l’exporte vers PDF avec quatre diapositives par page dans l’ordre horizontal. Il inclut les numéros de diapositives et des cadres autour des diapositives, et exclut les commentaires.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Charger une présentation.
presentation = Presentation("sample.pptx")
try:
    # Configurer la mise en page d'accompagnement.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # Exporter la présentation en PDF avec la mise en page choisie.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Les paramètres de mise en page d’accompagnement s’appliquent aux formats de sortie pris en charge, tels que PDF, HTML, TIFF et les images rendues. Ils ne réorganisent pas les diapositives dans la présentation source.
{{% /alert %}}

## **FAQ**

**Quel est le nombre maximal de vignettes de diapositive par page en mode diapositive d’accompagnement ?**

Aspose.Slides prend en charge jusqu’à neuf vignettes par page. Les paramètres prédéfinis [HandoutType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/handouttype/) offrent une, deux, trois, quatre, six ou neuf diapositives par page. Les paramètres de quatre, six et neuf diapositives proposent un ordre horizontal et vertical.

**Puis‑je définir une grille personnalisée, par exemple cinq ou huit diapositives par page ?**

Non. Le nombre et l’ordre des vignettes sont contrôlés par les valeurs prédéfinies [HandoutType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/handouttype/). Les grilles arbitraires ne sont pas prises en charge par ces paramètres de mise en page d’accompagnement.

**Puis‑je inclure les diapositives masquées dans la sortie d’accompagnement ?**

Oui. Activez les diapositives masquées dans les paramètres d’exportation du format cible. Pour PDF, appelez [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) avec `True` avant d’enregistrer la présentation.