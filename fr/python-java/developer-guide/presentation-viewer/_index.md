---
title: Créer un visualiseur de présentation en Python via Java
linktitle: Visualiseur de présentation
type: docs
weight: 50
url: /fr/python-java/presentation-viewer/
keywords:
- visualiser la présentation
- visualiseur de présentation
- créer un visualiseur de présentation
- visualiser PPT
- visualiser PPTX
- visualiser ODP
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Créer un visualiseur de présentation personnalisé en Python via Java à l'aide d'Aspose.Slides. Affichez facilement les fichiers PowerPoint et OpenDocument sans Microsoft PowerPoint."
---
## **Introduction**

Aspose.Slides for Python via Java est utilisé pour créer des fichiers de présentation contenant des diapositives. Ces diapositives peuvent être visualisées en ouvrant les présentations dans Microsoft PowerPoint, par exemple. Cependant, il arrive que les développeurs souhaitent afficher les diapositives sous forme d’images dans leur visualiseur d’images préféré ou créer leur propre visualiseur de présentations. Dans ces cas, Aspose.Slides vous permet d’exporter une diapositive individuelle sous forme d’image. Cet article décrit comment procéder.

## **Générer une image SVG à partir d’une diapositive**

Pour générer une image SVG à partir d’une diapositive de présentation avec Aspose.Slides, suivez les étapes ci‑dessus :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenez la référence de la diapositive par son index.
1. Ouvrez un flux d’octets.
1. Enregistrez la diapositive en tant qu’image SVG dans le flux et écrivez‑la dans un fichier.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import ByteArrayOutputStream

slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Générer un SVG avec un identifiant de forme personnalisé**

Aspose.Slides peut être utilisé pour générer un [SVG](https://docs.fileformat.com/page-description-language/svg/) à partir d’une diapositive avec un identifiant de forme personnalisé. Pour ce faire, utilisez la méthode [SvgShape.setId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgshape/#setId) de la classe [SvgShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` peut être utilisé pour définir l’identifiant de la forme.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import ByteArrayOutputStream

class CustomSvgShapeFormattingController:
    def __init__(self, shape_start_index=0):
        self.shape_index = shape_start_index

    def formatShape(self, svg_shape, shape):
        svg_shape.setId(f"shape-{self.shape_index}")
        self.shape_index += 1


slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    controller = CustomSvgShapeFormattingController()
    controller_proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(controller_proxy)

    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream, svg_options)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Créer une image miniature d’une diapositive**

Aspose.Slides vous aide à générer des images miniatures de diapositives. Pour générer une miniature d’une diapositive avec Aspose.Slides, suivez les étapes ci‑dessus :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenez la référence de la diapositive par son index.
1. Obtenez l’image miniature de la diapositive référencée à une échelle définie.
1. Enregistrez l’image miniature dans le format d’image souhaité.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat

slide_index = 0
scale_x = 1.0
scale_y = scale_x

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(scale_x, scale_y)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Créer une miniature de diapositive avec des dimensions définies par l’utilisateur**

Pour créer une image miniature de diapositive avec des dimensions définies par l’utilisateur, suivez les étapes ci‑dessus :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenez la référence de la diapositive par son index.
1. Obtenez l’image miniature de la diapositive référencée avec les dimensions définies.
1. Enregistrez l’image miniature dans le format d’image souhaité.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat
from java.awt import Dimension

slide_index = 0
slide_size = Dimension(1200, 800)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(slide_size)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Créer une miniature de diapositive avec les notes du présentateur**

Pour générer la miniature d’une diapositive avec les notes du présentateur à l’aide d’Aspose.Slides, suivez les étapes ci‑dessus :

1. Créez une instance de la classe [RenderingOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/renderingoptions/).
1. Utilisez la méthode [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) pour définir la position des notes du présentateur.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenez la référence de la diapositive par son index.
1. Obtenez l’image miniature de la diapositive référencée avec les options de rendu.
1. Enregistrez l’image miniature dans le format d’image souhaité.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, RenderingOptions

slide_index = 0
layouting_options = NotesCommentsLayoutingOptions()
layouting_options.setNotesPosition(NotesPositions.BottomTruncated)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layouting_options)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(rendering_options)
    try:
        image.save("output.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Exemple en direct**

Vous pouvez essayer l’application gratuite [**Aspose.Slides Viewer**](https://products.aspose.app/slides/fr/viewer/) pour voir ce que vous pouvez implémenter avec l’API Aspose.Slides :

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Puis‑je intégrer un visualiseur de présentation dans une application Web ?**

Oui. Vous pouvez utiliser Aspose.Slides côté serveur pour rendre les diapositives sous forme d’images ou de HTML et les afficher dans le navigateur. Les fonctionnalités de navigation et de zoom peuvent être implémentées avec JavaScript pour une expérience interactive.

**Quelle est la meilleure façon d’afficher les diapositives dans un visualiseur personnalisé ?**

La méthode recommandée consiste à rendre chaque diapositive sous forme d’image (par ex. PNG ou SVG) ou à la convertir en HTML à l’aide d’Aspose.Slides, puis à afficher le résultat dans une zone d’image (pour le bureau) ou un conteneur HTML (pour le Web).

**Comment gérer de grandes présentations contenant de nombreuses diapositives ?**

Pour les présentations volumineuses, envisagez le chargement différé ou le rendu à la demande des diapositives. Cela signifie générer le contenu d’une diapositive uniquement lorsque l’utilisateur y navigue, ce qui réduit la consommation de mémoire et le temps de chargement.