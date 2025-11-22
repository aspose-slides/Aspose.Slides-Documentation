---
title: Convertir les présentations PowerPoint en TIFF avec Python
titlelink: PowerPoint en TIFF
type: docs
weight: 90
url: /fr/python-net/convert-powerpoint-to-tiff/
keywords:
- convertir PowerPoint
- convertir OpenDocument
- convertir présentation
- convertir diapositive
- PowerPoint en TIFF
- OpenDocument en TIFF
- présentation en TIFF
- diapositive en TIFF
- PPT en TIFF
- PPTX en TIFF
- ODP en TIFF
- Python
- Aspose.Slides
description: "Apprenez comment convertir facilement les présentations PowerPoint (PPT, PPTX) et OpenDocument (ODP) en images TIFF de haute qualité à l'aide d'Aspose.Slides pour Python via .NET. Guide étape par étape avec des exemples de code inclus."
---

## **Vue d'ensemble**

TIFF (**Tagged Image File Format**) est un format d'image raster sans perte largement utilisé, connu pour sa qualité exceptionnelle et la préservation détaillée des graphiques. Les concepteurs, photographes et éditeurs de bureau choisissent souvent le TIFF pour conserver les calques, la précision des couleurs et les paramètres originaux de leurs images.

Avec Aspose.Slides, vous pouvez convertir facilement vos diapositives PowerPoint (PPT, PPTX) et les diapositives OpenDocument (ODP) directement en images TIFF de haute qualité, garantissant que vos présentations conservent une fidélité visuelle maximale.

## **Convertir une présentation en TIFF**

En utilisant la méthode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#methods) fournie par la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), vous pouvez rapidement convertir une présentation PowerPoint complète en TIFF. Les images TIFF résultantes correspondent à la taille de diapositive par défaut.

Ce code Python montre comment convertir une présentation PowerPoint en TIFF :
```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
with slides.Presentation("presentation.pptx") as presentation:
    # Enregistrer la présentation au format TIFF.
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```


## **Convertir une présentation en TIFF noir et blanc**

La propriété [bw_conversion_mode](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) de la classe [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) vous permet de spécifier l'algorithme utilisé lors de la conversion d'une diapositive ou d'une image couleur en TIFF noir et blanc. Notez que ce paramètre s'applique uniquement lorsque la propriété [compression_type](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/compression_type/) est définie sur `CCITT4` ou `CCITT3`.

Supposons que nous ayons un fichier "sample.pptx" avec la diapositive suivante :
![Une diapositive de présentation](slide_black_and_white.png)

Ce code Python montre comment convertir la diapositive couleur en TIFF noir et blanc :
```py
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```


Le résultat :
![TIFF noir et blanc](TIFF_black_and_white.png)

## **Convertir une présentation en TIFF avec taille personnalisée**

Si vous avez besoin d'une image TIFF avec des dimensions spécifiques, vous pouvez définir les valeurs souhaitées à l'aide des propriétés disponibles dans [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/). Par exemple, la propriété [image_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/image_size/) vous permet de définir la taille de l'image résultante.

Ce code Python montre comment convertir une présentation PowerPoint en images TIFF avec une taille personnalisée :
```py
import aspose.slides as slides
import aspose.pydrawing as drawing

# Instancier la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
with slides.Presentation("sample.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    # Définir le type de compression.
    tiff_options.compression_type = slides.export.TiffCompressionTypes.DEFAULT
    """
    Types de compression :
        Par défaut - Spécifie le schéma de compression par défaut (LZW).
        Aucun - Spécifie aucune compression.
        CCITT3
        CCITT4
        LZW
        RLE
    """

    # Définir le DPI de l'image.
    tiff_options.dpi_x = 200
    tiff_options.dpi_y = 200

    # Définir la taille de l'image.
    tiff_options.image_size = drawing.Size(1728, 1078)

    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL
    tiff_options.slides_layout_options = notes_options

    # Enregistrer la présentation au format TIFF avec la taille spécifiée.
    presentation.save("custom_size.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```


## **Convertir une présentation en TIFF avec format de pixel d'image personnalisé**

En utilisant la propriété [pixel_format](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/pixel_format/) de la classe [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/), vous pouvez spécifier le format de pixel souhaité pour l'image TIFF résultante.

Ce code Python montre comment convertir une présentation PowerPoint en image TIFF avec un format de pixel personnalisé :
```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
with slides.Presentation("Presentation.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    tiff_options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED
    """
    ImagePixelFormat contient les valeurs suivantes (telles qu'indiquées dans la documentation) :
        FORMAT_1BPP_INDEXED - 1 bit par pixel, indexé.
        FORMAT_4BPP_INDEXED - 4 bits par pixel, indexé.
        FORMAT_8BPP_INDEXED - 8 bits par pixel, indexé.
        FORMAT_24BPP_RGB    - 24 bits par pixel, RGB.
        FORMAT_32BPP_ARGB   - 32 bits par pixel, ARGB.
    """

    # Enregistrer la présentation au format TIFF avec la taille d'image spécifiée.
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```


{{% alert title="Tip" color="primary" %}}
Découvrez le [convertisseur GRATUIT PowerPoint vers Poster](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) d'Aspose.
{{% /alert %}}

## **FAQ**

**Puis-je convertir une diapositive individuelle au lieu de l'intégralité d'une présentation PowerPoint en TIFF ?**

Oui. Aspose.Slides vous permet de convertir des diapositives individuelles provenant de présentations PowerPoint et OpenDocument en images TIFF séparément.

**Existe-t-il une limite au nombre de diapositives lors de la conversion d'une présentation en TIFF ?**

Non, Aspose.Slides n'impose aucune restriction sur le nombre de diapositives. Vous pouvez convertir des présentations de toute taille au format TIFF.

**Les animations et les effets de transition PowerPoint sont-ils conservés lors de la conversion des diapositives en TIFF ?**

Non, le TIFF est un format d'image statique. Ainsi, les animations et les effets de transition ne sont pas conservés ; seules des captures statiques des diapositives sont exportées.