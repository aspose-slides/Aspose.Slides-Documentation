---
title: Convertir les diapositives de présentation en images en Python
linktitle: Diapositive vers image
type: docs
weight: 35
url: /fr/python-java/convert-slide/
keywords:
- convertir diapositive
- exporter diapositive
- diapositive en image
- enregistrer diapositive comme image
- diapositive en EMF
- diapositive en PNG
- diapositive en JPEG
- diapositive en bitmap
- diapositive en TIFF
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Convertir des diapositives des présentations PPT, PPTX et ODP en PNG, JPEG, GIF, TIFF, EMF et d’autres formats d’image en Python avec Aspose.Slides."
---
## **Introduction**

Aspose.Slides for Python via Java peut rendre des diapositives individuelles provenant de présentations PowerPoint et OpenDocument en PNG, JPEG, GIF, TIFF et d’autres formats d’image.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Sélectionnez la diapositive que vous souhaitez rendre.
3. Si nécessaire, configurez le rendu avec la classe [RenderingOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/renderingoptions/) ou [TiffOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tiffoptions/).
4. Appelez la méthode [Slide.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage). Elle renvoie un objet image.
5. Enregistrez l’image et spécifiez le format de sortie avec une valeur [ImageFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imageformat/).

## **Convert a Slide to a PNG Image**

La conversion la plus simple utilise les paramètres de rendu par défaut. L’objet image résultant peut être traité en mémoire ou enregistré dans un fichier.

L’exemple Python suivant rend la première diapositive et l’enregistre au format PNG :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage()
    try:
        image.save("Slide_0.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Convert Slides to Images with Custom Sizes**

Utilisez la surcharge de [Slide.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage) qui accepte une valeur [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) pour rendre une diapositive avec des dimensions de pixels exactes.

L’exemple suivant crée une image JPEG de 1820 × 1040 px :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

image_size = Dimension(1820, 1040)

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(image_size)
    try:
        image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Convert Slides with Notes and Comments to Images**

Par défaut, les images de diapositive n’incluent pas les notes ni les commentaires. Transmettez un objet [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notescommentslayoutingoptions/) à la méthode [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) pour contrôler l’emplacement des notes et des commentaires.

L’exemple suivant place les notes tronquées sous la diapositive et les commentaires à sa droite :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Color

scale_x = 2.0
scale_y = scale_x

comments_area_color = Color(250, 235, 215)

layout_options = NotesCommentsLayoutingOptions()
layout_options.setNotesPosition(NotesPositions.BottomTruncated)
layout_options.setCommentsPosition(CommentsPositions.Right)
layout_options.setCommentsAreaWidth(500)
layout_options.setCommentsAreaColor(comments_area_color)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("Presentation_with_notes_and_comments.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(rendering_options, scale_x, scale_y)
    try:
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
Pour la conversion de diapositive en image, ne transmettez pas [BottomFull](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notespositions/#BottomFull) à la méthode [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Les notes peuvent contenir plus de texte que la taille fixe de l’image ne le permet. Utilisez [BottomTruncated](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notespositions/#BottomTruncated) à la place.
{{% /alert %}}

## **Convert Slides to Images Using TIFF Options**

La classe [TiffOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tiffoptions/) vous permet de contrôler la taille, la résolution et d’autres propriétés de l’image TIFF rendue.

L’exemple suivant rend la première diapositive en une image TIFF de 2160 × 2880 px à 300 dpi :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, TiffOptions
from java.awt import Dimension

image_size = Dimension(2160, 2880)

tiff_options = TiffOptions()
tiff_options.setImageSize(image_size)
tiff_options.setDpiX(300)
tiff_options.setDpiY(300)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(tiff_options)
    try:
        image.save("output.tiff", ImageFormat.Tiff)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
La prise en charge du format TIFF n’est pas garantie dans les versions de Java antérieures à JDK 9.
{{% /alert %}}

## **Convert All Slides to Images**

Parcourez la collection de diapositives pour convertir l’ensemble de la présentation en une série d’images. Les diapositives masquées sont incluses sauf si vous les excluez explicitement.

L’exemple suivant rend chaque diapositive en une image JPEG avec des facteurs d’échelle horizontaux et verticaux de 2 :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = scale_x

presentation = Presentation("Presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for index in range(slide_count):
        slide = presentation.getSlides().get_Item(index)
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"Slide_{index}.jpg", ImageFormat.Jpeg)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Create Enhanced Metafile Output**

Le Metafile amélioré (EMF) est utile lorsque des graphiques vectoriels doivent être échangés avec Microsoft Office ou d’autres applications Windows qui prennent en charge les métafichiers Windows. Contrairement à une image pixelisée, un EMF peut conserver les opérations de dessin vectoriel qui s’échelonnent sans perdre de netteté. Cependant, l’EMF est principalement un format de compatibilité pour les applications qui supportent les métafichiers Windows, pas un format d’échange universel. De plus, le contenu complexe d’une diapositive, tel que les images bitmap et certains effets, peut être stocké sous forme d’éléments rasterisés à l’intérieur du conteneur de métafichier vectoriel.

### **Export a Slide to EMF**

La méthode [Slide.writeAsEmf](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/) écrit une [Slide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/) dans un flux cible au format EMF. L’exemple suivant charge une présentation, sélectionne la première diapositive et l’écrit dans un flux de fichier EMF :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = FileOutputStream("Slide_0.emf")
    try:
        slide.writeAsEmf(emf_stream)
    finally:
        emf_stream.close()
finally:
    presentation.dispose()
```

L’appelant possède le flux transmis à [Slide.writeAsEmf](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/) et est responsable de le fermer, comme indiqué ci‑dessus.

### **Convert an SVG Image to EMF and Add It to a Presentation**

Utilisez [SvgImage.writeAsEmf](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgimage/) pour convertir le contenu SVG en EMF. Les octets résultants peuvent être ajoutés à la présentation via [ImageCollection.addImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagecollection/#addImage) et placés sur une diapositive avec [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addPictureFrame).

L’exemple suivant crée un [SvgImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgimage/) à partir de balises SVG, le convertit en EMF en mémoire, insère le métafichier sur la première diapositive et enregistre la présentation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage
from java.io import ByteArrayOutputStream

svg_content = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>"
svg_image = SvgImage(svg_content)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = ByteArrayOutputStream()
    try:
        svg_image.writeAsEmf(emf_stream)

        emf_data = emf_stream.toByteArray()
        image = presentation.getImages().addImage(emf_data)
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image)
    finally:
        emf_stream.close()

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgimage/) ne prend pas la possession du flux de destination. Un [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) stocke toutes les données générées en mémoire, ainsi aucun réinitialisation de position n’est nécessaire avant d’appeler [ByteArrayOutputStream.toByteArray](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html#toByteArray--). Le tableau d’octets retourné reste valide après la fermeture du flux.

La génération d’EMF est disponible sur les systèmes d’exploitation pris en charge par la configuration sélectionnée d’Aspose.Slides for Python via Java et du JDK, mais le rendu peut varier selon les plateformes lorsque les polices ou les dépendances graphiques sont indisponibles. Installez les polices utilisées par le contenu source ou configurez des substitutions appropriées, suivez les [exigences de la plateforme](/slides/fr/python-java/system-requirements/) d’Aspose.Slides for Python via Java, et validez le résultat dans l’application cible qui consomme les EMF. Les applications sous Linux et macOS ont souvent une prise en charge limitée ou incohérente de l’affichage et de l’édition des métafichiers Windows.

## **Color Emoji Rendering**

{{% alert title="Note" color="info" %}}
Pour rendre correctement les emojis couleur lors de la conversion des diapositives de présentation en images, les polices d’emoji utilisées dans la présentation doivent être installées et disponibles sur le système effectuant la conversion. Par exemple, si la présentation utilise **Segoe UI Emoji** et que cette police est absente, les emojis peuvent apparaître en monochrome dans les images de sortie.
{{% /alert %}}

## **FAQ**

**Aspose.Slides prend‑il en charge le rendu des diapositives avec des animations ?**

Non. La méthode [Slide.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage) rend une image statique de la diapositive et n’exporte pas les animations.

**Les diapositives masquées peuvent‑elles être exportées en images ?**

Oui. Les diapositives masquées peuvent être rendues comme des diapositives normales. Incluez‑les dans la boucle de traitement, comme illustré dans l’exemple ci‑dessus.

**Les ombres et autres effets sont‑ils conservés dans les images de diapositives ?**

Oui. Aspose.Slides rend les ombres, la transparence et d’autres effets graphiques supportés dans les images de diapositives.