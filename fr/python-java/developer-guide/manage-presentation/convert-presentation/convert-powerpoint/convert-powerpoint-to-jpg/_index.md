---
title: Convertir PPT et PPTX en JPG avec Python
linktitle: PowerPoint en JPG
type: docs
weight: 60
url: /fr/python-java/convert-powerpoint-to-jpg/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- PowerPoint en JPG
- PPT en JPG
- PPTX en JPG
- enregistrer la diapositive en JPG
- exporter PPT en JPG
- exporter PPTX en JPG
- Python
- Java
- Aspose.Slides
description: "Convertir les diapositives PowerPoint (PPT, PPTX) en images JPG avec Python via Java. Définir des dimensions d'image personnalisées et rendre les notes et les commentaires avec Aspose.Slides."
---
## **Introduction**

Aspose.Slides for Python via Java vous permet de convertir des présentations PowerPoint et OpenDocument (PPT, PPTX et ODP) en images JPEG. Vous pouvez exporter chaque diapositive ou une diapositive sélectionnée pour créer des vignettes, construire un visualiseur de présentations ou intégrer des aperçus de diapositives dans un site Web ou une application.

## **Convertir PowerPoint PPT/PPTX en JPG**

1. Chargez la présentation avec [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Récupérez les diapositives à l’aide de [getSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSlides).
3. Appelez [Slide.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage) avec des facteurs d’échelle horizontaux et verticaux pour rendre chaque diapositive.
4. Enregistrez chaque image rendue au format JPEG à l’aide de [ImageFormat.Jpeg](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imageformat/#Jpeg), puis libérez les ressources de l’image.

{{% alert color="info" title="Remarque" %}}
L’exportation au format JPG crée une image distincte pour chaque diapositive. Enregistrez l’image rendue plutôt que de sauvegarder directement la présentation dans un format d’image.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Convertir PowerPoint PPT/PPTX en JPG avec des dimensions personnalisées**

Calculez les facteurs d’échelle horizontaux et verticaux à partir des dimensions en pixels souhaitées et de la taille originale de la diapositive, puis passez‑les à [Slide.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage). L’exemple suivant cible une image de 1200 × 800 pixels pour chaque diapositive.

Utiliser des facteurs d’échelle différents peut étirer la diapositive. Pour conserver son ratio d’aspect, utilisez le même facteur d’échelle pour les deux axes ; la largeur et la hauteur résultantes suivront alors les proportions originales de la diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Rendre les commentaires lors de l’enregistrement des diapositives en images**

Utilisez [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notescommentslayoutingoptions/) pour configurer les notes et les commentaires, et appliquez la mise en page via [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions). Cet exemple place les notes en bas, tronquant celles qui ne tiennent pas, et affiche les commentaires à droite dans une zone de 200 pixels de large. Il enregistre chaque diapositive rendue en tant qu’image JPG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Puis‑je convertir plusieurs diapositives ou présentations en JPG ?**

Oui. Les exemples parcourent toutes les diapositives et enregistrent un JPG par diapositive. Pour traiter plusieurs présentations, répétez la conversion pour chaque fichier d’entrée et utilisez des dossiers de sortie séparés ou des noms de fichiers uniques afin d’éviter d’écraser les images.

**Les graphiques, SmartArt, tableaux et formes sont‑ils inclus dans les images ?**

Ces objets sont rendus comme partie intégrante de la diapositive. Assurez‑vous que les polices utilisées par la présentation sont disponibles dans l’environnement de conversion afin de réduire les différences causées par le remplacement de polices.

**Comment réduire la consommation de mémoire lors de l’exportation de présentations volumineuses ?**

Traitez les images une à une, libérez chaque image après l’avoir enregistrée et évitez des dimensions de sortie inutilement grandes. Les besoins en mémoire dépendent du contenu des diapositives et de la taille de l’image.

## **Voir aussi**

- [Convertir PowerPoint en PNG](/slides/fr/python-java/convert-powerpoint-to-png/).
- [Rendre une diapositive en image SVG](/slides/fr/python-java/render-a-slide-as-an-svg-image/).