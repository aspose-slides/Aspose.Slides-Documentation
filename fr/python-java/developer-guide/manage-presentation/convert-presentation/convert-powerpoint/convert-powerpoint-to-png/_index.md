---
title: Convertir des diapositives PowerPoint en PNG en Python
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
description: "Convertir des diapositives PowerPoint en images PNG en Python via Java. Exporter des présentations PPT, PPTX et ODP avec des échelles personnalisées ou des dimensions d'image exactes."
---
## **Aperçu**

Cet article explique comment convertir des présentations PowerPoint en images PNG à l’aide d’Aspose.Slides pour Python via Java. Vous pouvez charger des fichiers PPT, PPTX et ODP, rendre chaque diapositive et l’enregistrer en tant qu’image PNG distincte.

Les exemples montrent également comment contrôler les dimensions de sortie à l’aide de facteurs d’échelle ou d’une largeur et hauteur exactes. Chaque exemple démarre la machine virtuelle Java si nécessaire et libère les ressources de la présentation et de l’image après utilisation.

## **Convertir PowerPoint en PNG**

1. Chargez le fichier d’entrée avec la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Récupérez les diapositives avec [Presentation.getSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSlides).
3. Rendez chaque diapositive avec [Slide.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage).
4. Enregistrez chaque image rendue avec [ImageFormat.Png](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imageformat/#Png), puis libérez ses ressources.

L’exemple Python suivant exporte toutes les diapositives à leur taille par défaut :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Convertir PowerPoint en PNG avec une échelle personnalisée**

Passez des facteurs d’échelle horizontaux et verticaux à [Slide.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage) pour augmenter ou diminuer les dimensions de sortie. Par exemple, une diapositive de 720 × 540 points rendue avec un facteur d’échelle de 2 sur les deux axes produit une image de 1440 × 1080 pixels.

Utilisez des facteurs d’échelle égaux pour conserver le ratio d’aspect de la diapositive. Des facteurs différents étirent la diapositive horizontalement ou verticalement.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Convertir PowerPoint en PNG avec une taille personnalisée**

Pour spécifier des dimensions exactes en pixels, transmettez un objet Java `Dimension` contenant la largeur et la hauteur souhaitées à [Slide.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage). Choisissez des dimensions avec le même ratio d’aspect que la diapositive source afin d’éviter les distorsions.

L’exemple suivant enregistre chaque diapositive en tant qu’image PNG de 960 × 720 pixels :

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
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Puis-je exporter une forme individuelle, comme un graphique ou une image, au lieu de la diapositive entière ?**

Oui. Aspose.Slides prend en charge la [génération de miniatures pour des formes individuelles](/slides/fr/python-java/create-shape-thumbnails/), que vous pouvez enregistrer en tant qu’images PNG.

**Puis-je convertir des présentations en parallèle sur un serveur ?**

Utilisez une instance de présentation distincte pour chaque thread ou processus, et des chemins de sortie uniques pour éviter que les fichiers ne soient écrasés. Ne partagez pas une instance de présentation entre les threads. Voir [Multithreading](/slides/fr/python-java/multithreading/).

**Quelles sont les limitations de la version d’évaluation lors de l’exportation en PNG ?**

Le mode d’évaluation ajoute un filigrane aux images de sortie et applique [d’autres restrictions](/slides/fr/python-java/licensing/). Appliquez une licence pour supprimer ces limitations.