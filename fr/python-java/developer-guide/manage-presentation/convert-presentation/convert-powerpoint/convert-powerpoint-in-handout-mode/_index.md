---
title: Convertir des présentations PowerPoint en mode livret avec Python
linktitle: Mode livret
type: docs
weight: 150
url: /fr/python-java/convert-powerpoint-in-handout-mode/
keywords:
- convertir PowerPoint
- convertir présentation
- mode livret
- livret
- PPT
- PPTX
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Convertir des présentations PowerPoint en livrets avec Python via Java. Disposer plusieurs diapositives par page et exporter en PDF avec Aspose.Slides."
---
## **Introduction**

Aspose.Slides for Python via Java vous permet d’exporter des présentations en mode livret, en disposant plusieurs diapositives sur une même page. Cela est utile pour imprimer le matériel de présentation lors de conférences, séminaires et événements similaires.

Configurez la mise en page via la méthode [setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions). Les mises en page de livret sont prises en charge par [PdfOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/htmloptions/), et [TiffOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tiffoptions/). Utilisez un objet [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/handoutlayoutingoptions/) pour spécifier la mise en page et les paramètres d’affichage.

## **Exportation en mode livret**

Pour exporter une présentation en mode livret, créez une instance de [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/handoutlayoutingoptions/) et affectez‑la aux options d’exportation cibles à l’aide de [setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

L’exemple suivant charge `sample.pptx` et l’exporte vers PDF avec quatre diapositives par page en ordre horizontal. Il inclut les numéros de diapositives et des cadres autour des diapositives, et exclut les commentaires.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Charger une présentation.
presentation = Presentation("sample.pptx")
try:
    # Configurer la disposition du livret.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # Exporter la présentation en PDF avec la disposition choisie.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Avertissement" %}}
Les paramètres de mise en page du livret s’appliquent aux formats de sortie pris en charge, tels que PDF, HTML, TIFF et les images rendues. Ils ne réorganisent pas les diapositives dans la présentation source.
{{% /alert %}}

## **FAQ**

**Quel est le nombre maximum de vignettes de diapositives par page en mode livret ?**

Aspose.Slides prend en charge jusqu’à neuf vignettes par page. Les préréglages [HandoutType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/handouttype/) offrent une, deux, trois, quatre, six ou neuf diapositives par page. Les préréglages de quatre, six et neuf diapositives permettent un ordre horizontal et vertical.

**Puis‑je définir une grille personnalisée, comme cinq ou huit diapositives par page ?**

Non. Le nombre et l’ordre des vignettes sont contrôlés par les valeurs prédéfinies de [HandoutType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/handouttype/). Les grilles arbitraires ne sont pas prises en charge par ces paramètres de mise en page du livret.

**Puis‑je inclure des diapositives masquées dans la sortie du livret ?**

Oui. Activez les diapositives masquées dans les paramètres d’exportation du format cible. Pour le PDF, appelez [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) avec `True` avant d’enregistrer la présentation.