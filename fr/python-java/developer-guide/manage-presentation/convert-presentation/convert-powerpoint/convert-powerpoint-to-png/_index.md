---
title: Convertir des diapositives PowerPoint en PNG avec Python
linktitle: PowerPoint en PNG
type: docs
weight: 30
url: /fr/python-java/convert-powerpoint-to-png/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en PNG
- présentation en PNG
- diapositive en PNG
- PPT en PNG
- PPTX en PNG
- enregistrer PPT en PNG
- enregistrer PPTX en PNG
- exporter PPT en PNG
- exporter PPTX en PNG
- Python
- Java
- Aspose.Slides
description: "Convertir des diapositives PowerPoint en images PNG avec Python via Java. Exporter les présentations PPT, PPTX et ODP avec des échelles personnalisées ou des dimensions d'image précises."
---
## **Vue d'ensemble**

Cet article explique comment convertir des diapositives de présentation en images PNG à l'aide d'Aspose.Slides pour Python via Java. Vous pouvez charger des présentations aux formats tels que PPT, PPTX et ODP, rendre chaque diapositive et l'enregistrer en tant qu'image PNG distincte.

## **Convertir PowerPoint en PNG**

Chargez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) et accédez à ses diapositives via la collection [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides). L'exemple rend chaque diapositive avec [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) sans paramètres pour créer une miniature. Il appelle ensuite [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) avec [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) pour enregistrer chaque diapositive rendue en image PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
La surcharge sans paramètre de [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) rend à une échelle de 0,2. Par exemple, une diapositive de 720 × 540 points produit une miniature de 144 × 108 pixels. Pour contrôler les dimensions de sortie, utilisez les surcharges avec des facteurs d'échelle ou une taille d'image explicite comme indiqué ci-dessous.
{{% /alert %}}

## **Convertir PowerPoint en PNG avec des dimensions personnalisées**

Passez des facteurs d'échelle horizontaux et verticaux à [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) pour contrôler les dimensions rendues. Dans cet exemple, les deux facteurs sont de 2, ainsi une diapositive de 720 × 540 points produit une image de 1440 × 1080 pixels. Des facteurs d'échelle égaux conservent le rapport d'aspect de la diapositive. Chaque image rendue est enregistrée au format PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Convertir PowerPoint en PNG avec une taille personnalisée**

Pour spécifier les dimensions de sortie en pixels, transmettez une taille à [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) plutôt que des facteurs d'échelle. Cet exemple rend chaque diapositive à 960 × 720 pixels et enregistre le résultat au format PNG. Choisissez des dimensions qui correspondent au rapport d'aspect de la diapositive afin d'éviter d'étirer l'image.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Choisir un style de rendu de gradient**

Supposons qu'une diapositive contienne des remplissages en dégradé, mais que les transitions dans le PNG exporté apparaissent plus claires ou différentes de ce que vous voyez dans PowerPoint. Vous pouvez utiliser la méthode [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) héritée par [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/) pour choisir la façon dont les dégradés sont rendus.

Téléchargez [gradient-styles.pptx](gradient-styles.pptx) et placez-le dans le répertoire de travail de l'application. Sa première diapositive contient deux dégradés linéaires : cyan vers orange en haut et bleu vers jaune en bas. Chaque dégradé possède deux arrêts, à 0 % et 100 %.

L'exemple suivant charge cette présentation et rend la même première diapositive dans les deux modes avec [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

Les images ci-dessous affichent le résultat de la même diapositive, avec les deux dégradés dans chaque image :

| Default | PowerPointUI |
| --- | --- |
| ![Dégradés cyan‑vers‑orange et bleu‑vers‑jaune rendus avec Default](gradient-Default.png) | ![Les mêmes dégradés rendus avec PowerPointUI](gradient-PowerPointUI.png) |

Dans cet exemple, `Default` produit des couleurs intermédiaires plus claires, tandis que `PowerPointUI` produit des couleurs intermédiaires plus sombres. La différence dépend des couleurs et des arrêts du dégradé.

Choisissez `Default` lorsque la sortie standard d'Aspose.Slides répond à vos besoins. Essayez `PowerPointUI` lorsque votre priorité est de correspondre à l'apparence dans PowerPoint. Comparez les deux résultats avec votre résultat attendu ; aucun des deux modes n'est universellement préférable.

## **FAQ**

**Comment puis‑je exporter une forme spécifique, telle qu'un graphique ou une image, au lieu de la diapositive entière ?**

Aspose.Slides prend en charge la [génération de miniatures pour des formes individuelles](/slides/fr/python-java/create-shape-thumbnails/), vous permettant de rendre une forme en image PNG.

**La conversion parallèle est‑elle prise en charge sur un serveur ?**

Oui. Utilisez une instance de présentation distincte pour chaque thread ou processus ; [ne partagez pas une même instance entre les threads](/slides/fr/python-java/multithreading/).

**Quelles sont les limitations de l'évaluation lors de l'exportation en PNG ?**

Le mode d'évaluation ajoute un filigrane aux images de sortie et applique [d'autres restrictions](/slides/fr/python-java/licensing/) jusqu'à ce qu'une licence soit appliquée.