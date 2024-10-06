---
title: Convertir PowerPoint en TIFF
type: docs
weight: 90
url: /python-net/convert-powerpoint-to-tiff/
keywords: "Convertir présentation PowerPoint, PowerPoint en TIFF, PPT en TIFF, PPTX en TIFF, Python, Aspose.Slides"
description: "Convertir une présentation PowerPoint en TIFF en Python"
---

**TIFF** (Tagged Image File Format) est un format d'image raster sans perte et de haute qualité. Les professionnels utilisent TIFF pour leurs besoins en design, photographie et publication assistée par ordinateur. Par exemple, si vous souhaitez préserver les calques et les réglages de votre design ou image, vous voudrez peut-être enregistrer votre travail en tant que fichier image TIFF.

Aspose.Slides vous permet de convertir les diapositives de PowerPoint directement en TIFF.

{{% alert title="Conseil" color="primary" %}}

Vous voudrez peut-être consulter le [convertisseur PowerPoint en poster GRATUIT d'Aspose](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **Convertir PowerPoint en TIFF**

En utilisant la méthode [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#methods) exposée par la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), vous pouvez rapidement convertir une présentation PowerPoint entière en TIFF. Les images TIFF résultantes correspondent à la taille par défaut des diapositives.

Ce code Python vous montre comment convertir PowerPoint en TIFF :

```python
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier de présentation
presentation = slides.Presentation("pres.pptx")
# Enregistre la présentation en tant que TIFF
presentation.save("Tiffoutput_out.tiff", slides.export.SaveFormat.TIFF)
```

## **Convertir PowerPoint en TIFF noir et blanc**

Dans Aspose.Slides 23.10, Aspose.Slides a ajouté une nouvelle propriété `bw_conversion_mode` à la classe [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) pour vous permettre de spécifier l'algorithme qui est suivi lorsqu'une diapositive ou image colorée est convertie en TIFF noir et blanc. Notez que ce paramètre n'est appliqué que lorsque la propriété `compression_type` est définie sur `CCITT4` ou `CCITT3`.

Ce code Python vous montre comment convertir une diapositive ou une image colorée en TIFF noir et blanc :

```python
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

presentation = slides.Presentation("sample.pptx")
presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **Convertir PowerPoint en TIFF avec une taille personnalisée**

Si vous avez besoin d'une image TIFF avec des dimensions définies, vous pouvez définir vos chiffres préférés via les propriétés fournies sous [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/). Par exemple, en utilisant la propriété `image_size`, vous pouvez définir une taille pour l'image résultante.

Ce code Python vous montre comment convertir PowerPoint en images TIFF avec une taille personnalisée :

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

# Instancie un objet Presentation qui représente un fichier de présentation
pres = slides.Presentation("pres.pptx")

# Instancie la classe TiffOptions
opts = slides.export.TiffOptions()

# Définit le type de compression
opts.compression_type = slides.export.TiffCompressionTypes.DEFAULT
opts.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Définit la DPI de l'image
opts.dpi_x = 200
opts.dpi_y = 100

# Définit la taille de l'image
opts.image_size = drawing.Size(1728, 1078)

# Enregistre la présentation en TIFF avec la taille spécifiée
pres.save("TiffWithCustomSize_out.tiff", slides.export.SaveFormat.TIFF, opts)
```

## **Convertir PowerPoint en TIFF avec un format de pixel d'image personnalisé**

En utilisant la propriété `pixel_format` sous la classe [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/), vous pouvez spécifier votre format de pixel préféré pour l'image TIFF résultante.

Ce code Python vous montre comment convertir PowerPoint en image TIFF avec un format de pixel personnalisé :

```python
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier de présentation
pres = slides.Presentation("pres.pptx")

# Instancie la classe TiffOptions
options = slides.export.TiffOptions()

options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED

# Enregistre la présentation en TIFF avec la taille spécifiée
pres.save("Tiff_With_Custom_Image_Pixel_Format_out.tiff", slides.export.SaveFormat.TIFF, options)
```