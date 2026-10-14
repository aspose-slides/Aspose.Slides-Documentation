---
title: Convertir les diapositives PowerPoint en PNG avec Python
linktitle: PowerPoint en PNG
type: docs
weight: 30
url: /fr/python-net/convert-powerpoint-to-png/
keywords:
- convertir PowerPoint en PNG
- convertir présentation en PNG
- convertir diapositive en PNG
- convertir PPT en PNG
- convertir PPTX en PNG
- convertir ODP en PNG
- PowerPoint en PNG
- présentation en PNG
- diapositive en PNG
- PPT en PNG
- PPTX en PNG
- ODP en PNG
- Python
- Aspose.Slides
description: "Convertissez les présentations PowerPoint et OpenDocument en images PNG de haute qualité rapidement avec Aspose.Slides pour Python via .NET, garantissant des résultats précis et automatisés."
---
## **Vue d'ensemble**

Cet article explique comment convertir des diapositives de présentation en images PNG en utilisant Aspose.Slides pour Python via .NET. Vous pouvez charger des présentations dans des formats tels que PPT, PPTX et ODP, rendre chaque diapositive et l’enregistrer comme une image PNG distincte.

Les exemples ci‑dessous montrent le rendu à l’échelle par défaut, l’augmentation de l’échelle, la spécification des dimensions de sortie en pixels et le choix d’un style de rendu de dégradé.

## **Convertir PowerPoint en PNG**

Chargez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et accédez à ses diapositives via la collection [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/). L’exemple rend chaque diapositive avec [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) sans paramètres pour créer une vignette. Il appelle ensuite [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) avec [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) pour enregistrer chaque diapositive rendue en tant qu’image PNG.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
La surcharge de [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) sans paramètres rend à une échelle de 0.2. Par exemple, une diapositive mesurant 720 × 540 points produit une vignette de 144 × 108 pixels. Pour contrôler les dimensions de sortie, utilisez les surcharges avec des facteurs d’échelle ou une taille d’image explicite montrée ci‑dessous.
{{% /alert %}}

## **Convertir PowerPoint en PNG avec des dimensions personnalisées**

Passez des facteurs d’échelle horizontaux et verticaux à [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) pour contrôler les dimensions rendues. Dans cet exemple, les deux facteurs sont 2, ainsi une diapositive mesurant 720 × 540 points produit une image de 1440 × 1080 pixels. Des facteurs d’échelle égaux conservent le rapport d’aspect de la diapositive. Chaque image est enregistrée au format PNG avec [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/).

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Convertir PowerPoint en PNG avec une taille personnalisée**

Pour spécifier les dimensions de sortie en pixels, transmettez une taille à [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) au lieu des facteurs d’échelle. Cet exemple rend chaque diapositive à 960 × 720 pixels et enregistre le résultat avec [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Choisissez des dimensions qui correspondent au rapport d’aspect de la diapositive afin d’éviter d’étirer l’image.

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Choisir un style de rendu de dégradé**

Supposons qu’une diapositive contienne des remplissages dégradés, mais que les transitions dans le PNG exporté apparaissent plus claires ou différentes de ce que vous voyez dans PowerPoint. Vous pouvez utiliser la propriété [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) de [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) pour choisir la façon dont les dégradés sont rendus.

Téléchargez [gradient-styles.pptx](gradient-styles.pptx) et placez‑le dans le répertoire de travail de l’application. Sa première diapositive contient deux dégradés linéaires : cyan vers orange en haut et bleu vers jaune en bas. Chaque dégradé possède deux arrêts, à 0 % et 100 %.

L’exemple suivant charge cette présentation et rend la même première diapositive dans les deux modes avec [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/).

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

Les images ci‑dessous montrent le rendu de la même diapositive, avec les deux dégradés dans chaque image :

| Par défaut | PowerPointUI |
| --- | --- |
| ![Dégradés cyan‑à‑orange et bleu‑à‑jaune rendus avec Par défaut](gradient-Default.png) | ![Les mêmes dégradés rendus avec PowerPointUI](gradient-PowerPointUI.png) |

Dans cet exemple, `DEFAULT` produit des couleurs intermédiaires plus claires, tandis que `POWER_POINT_UI` produit des couleurs intermédiaires plus sombres. La différence dépend des couleurs et des arrêts dans le dégradé.

Choisissez `DEFAULT` lorsque la sortie standard d’Aspose.Slides convient à vos besoins. Optez pour `POWER_POINT_UI` lorsque votre priorité est de correspondre à l’apparence dans PowerPoint. Comparez les deux rendus avec le résultat souhaité ; aucun mode n’est universellement préférable.

## **FAQ**

**Comment exporter une forme spécifique, comme un graphique ou une image, au lieu de l'intégralité de la diapositive ?**

Aspose.Slides prend en charge la [génération de vignettes pour des formes individuelles](/slides/fr/python-net/create-shape-thumbnails/), vous permettant de rendre une forme en image PNG.

**La conversion parallèle est‑elle prise en charge sur un serveur ?**

Oui. Utilisez une instance de présentation distincte pour chaque thread ou processus ; [ne partagez pas une seule instance entre les threads](/slides/fr/python-net/multithreading/).

**Quelles sont les limitations de l'évaluation lors de l'exportation au format PNG ?**

Le mode d'évaluation ajoute un filigrane aux images de sortie et applique [d'autres restrictions](/slides/fr/python-net/licensing/) tant qu'une licence n'est pas appliquée.