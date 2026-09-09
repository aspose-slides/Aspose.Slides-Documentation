---
title: Convertir des présentations PowerPoint en TIFF en Python
linktitle: PowerPoint en TIFF
type: docs
weight: 90
url: /fr/python-java/convert-powerpoint-to-tiff/
keywords:
- convertir PowerPoint
- convertir OpenDocument
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en TIFF
- présentation en TIFF
- diapositive en TIFF
- PPT en TIFF
- PPTX en TIFF
- enregistrer PPT au format TIFF
- enregistrer PPTX au format TIFF
- exporter PPT en TIFF
- exporter PPTX en TIFF
- Python
- Java
- Aspose.Slides
description: "Apprenez comment convertir facilement des présentations PowerPoint (PPT, PPTX) en images TIFF de haute qualité en utilisant Aspose.Slides pour Python via Java, avec des exemples de code."
---
## **Introduction**

TIFF (**Tagged Image File Format**) est un format d'image raster qui prend en charge plusieurs pages et la compression sans perte. Il est utile pour stocker les diapositives rendues dans un seul fichier image.

Avec Aspose.Slides pour Python via Java, vous pouvez convertir des présentations PowerPoint (PPT, PPTX) et OpenDocument (ODP) en TIFF. Chaque exemple ci‑dessous démarre la machine virtuelle Java si nécessaire et libère la présentation après utilisation. 

## **Convertir une présentation en TIFF**

En utilisant la méthode [save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) fournie par la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/), vous pouvez rapidement convertir une présentation PowerPoint complète en TIFF. Le TIFF multipage résultant contient une image rendue de chaque diapositive à la taille par défaut.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Enregistrez toutes les diapositives dans un fichier TIFF multipage.
    presentation.save("output.tiff", SaveFormat.Tiff)
finally:
    presentation.dispose()
```

## **Convertir une présentation en TIFF noir et blanc**

La méthode [setBwConversionMode](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tiffoptions/#setBwConversionMode) dans la classe [TiffOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tiffoptions/) vous permet de préciser l'algorithme utilisé lors de la conversion d'une diapositive ou d'une image couleur en TIFF noir et blanc. Notez que ce paramètre s'applique uniquement lorsque la méthode [setCompressionType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tiffoptions/#setCompressionType) est définie sur [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) ou [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tiffcompressiontypes/#CCITT3).

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tiffoptions/#setBwConversionMode) est un paramètre au niveau de l'exportation qui sélectionne un algorithme de conversion de pixels pour l'image TIFF complète. Pour définir l'apparence d'une forme individuelle lorsque le mode d'affichage noir et blanc est actif, utilisez [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#setBlackWhiteMode). Consultez [Contrôler le rendu noir et blanc pour les formes](/slides/fr/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes) pour des exemples.
{{% /alert %}}

Supposons que nous ayons un fichier "sample.pptx" contenant la diapositive suivante :

![Une diapositive de présentation](slide_black_and_white.png)

Ce code montre comment convertir la diapositive couleur en TIFF noir et blanc :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteConversionMode, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions

tiff_options = TiffOptions()
tiff_options.setCompressionType(TiffCompressionTypes.CCITT4)
tiff_options.setBwConversionMode(BlackWhiteConversionMode.Dithering)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

Le résultat :

![TIFF noir et blanc](TIFF_black_and_white.png)

## **Convertir une présentation en TIFF avec une taille personnalisée**

Si vous avez besoin d'une image TIFF avec des dimensions spécifiques, vous pouvez définir les valeurs souhaitées à l'aide des méthodes disponibles dans [TiffOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tiffoptions/). Par exemple, la méthode [setImageSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tiffoptions/#setImageSize) vous permet de spécifier la taille de l'image résultante.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setCompressionType(TiffCompressionTypes.Default)

    # Définir la résolution horizontale et verticale.
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # Définir les dimensions de sortie en pixels.
    image_size = Dimension(1728, 1078)
    tiff_options.setImageSize(image_size)

    # Inclure les notes du présentateur complètes sous chaque diapositive.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    tiff_options.setSlidesLayoutOptions(notes_options)

    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

## **Convertir une présentation en TIFF avec un format de pixel d'image personnalisé**

En utilisant la méthode [setPixelFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tiffoptions/#setPixelFormat) de la classe [TiffOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tiffoptions/), vous pouvez indiquer le format de pixel souhaité pour l'image TIFF résultante.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImagePixelFormat, Presentation, SaveFormat, TiffOptions

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setPixelFormat(ImagePixelFormat.Format8bppIndexed)

    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

{{% alert title="Astuce" color="success" %}}
Découvrez le [convertisseur GRATUIT PowerPoint vers Poster]https://products.aspose.app/slides/fr/conversion/convert-ppt-to-poster-online) d’Aspose.
{{% /alert %}}

## **FAQ**

**Puis‑je convertir une diapositive individuelle au lieu de toute la présentation PowerPoint en TIFF ?**

Oui. Aspose.Slides vous permet de convertir des diapositives individuelles de présentations PowerPoint et OpenDocument en images TIFF séparément.

**Existe‑t‑il une limite au nombre de diapositives lors de la conversion d’une présentation en TIFF ?**

Il n’existe pas de limite fixe du nombre de diapositives pour l’exportation en TIFF. La mémoire disponible, la complexité des diapositives et les dimensions de sortie influencent la taille des présentations que vous pouvez traiter.

**Les animations et les transitions PowerPoint sont‑elles conservées lors de la conversion des diapositives en TIFF ?**

Non, le TIFF est un format d'image statique. Ainsi, les animations et les effets de transition ne sont pas conservés ; seules des captures d’écran statiques des diapositives sont exportées.