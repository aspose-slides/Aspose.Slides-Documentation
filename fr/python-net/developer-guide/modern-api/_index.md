---
title: Améliorez le traitement d’images avec l’API moderne
linktitle: API moderne
type: docs
weight: 280
url: /fr/python-net/modern-api/
keywords:
- API moderne
- dessin
- vignette de diapositive
- diapositive en image
- vignette de forme
- forme en image
- vignette de présentation
- présentation en images
- ajouter une image
- ajouter une illustration
- Python
- Aspose.Slides
description: "Modernisez le traitement des images de diapositives en remplaçant les API d’imagerie obsolètes par l’API moderne en Python pour une automatisation fluide de PowerPoint et d’OpenDocument."
---

## Introduction

Actuellement, la bibliothèque Aspose.Slides pour Python via .NET a des dépendances dans son API publique sur les classes suivantes de `aspose.pydrawing` :
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

À partir de la version 24.4, cette API publique est déclarée obsolète en raison de [changements](https://releases.aspose.com/slides/net/release-notes/2024/aspose-slides-for-net-24-4-release-notes/#introducing-a-new-modern-api) dans l'API publique d'Aspose.Slides pour .NET.

Pour se débarrasser des dépendances sur `aspose.pydrawing` dans l'API publique, nous avons ajouté ce que nous appelons "API Moderne". Les méthodes utilisant `aspose.pydrawing.Image` et `aspose.pydrawing.Bitmap` sont déclarées obsolètes et seront remplacées par les méthodes correspondantes de l'API Moderne. Les méthodes utilisant `aspose.pydrawing.Graphics` sont déclarées obsolètes et leur support sera supprimé de l'API publique.

La suppression de l'API publique obsolète avec des dépendances sur `aspose.pydrawing` sera effectuée dans la version 24.8.

## API Moderne

Ajout des classes et énumérations suivantes à l'API publique :

- [`aspose.slides.IImage`](https://reference.aspose.com/slides/python-net/aspose.slides/iimage) - représente l'image raster ou vectorielle.
- [`aspose.slides.ImageFormat`](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat) - représente le format de fichier de l'image.
- [`aspose.slides.Images`](https://reference.aspose.com/slides/python-net/aspose.slides/images) - méthodes pour instancier et travailler avec l'interface `IImage`.

Un scénario typique d'utilisation de la nouvelle API peut ressembler à ceci :

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as pres:
    image = slides.Images.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
    with pres.slides[0].get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## Remplacer l'ancien code par l'API Moderne

Pour faciliter la transition, l'interface du nouvel `IImage` répète les signatures séparées des classes `Image` et `Bitmap`. En général, vous aurez juste besoin de remplacer l'appel à l'ancienne méthode utilisant `aspose.pydrawing` par la nouvelle.

### Obtenir une vignette de diapositive

Code utilisant une API obsolète :

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    pres.slides[0].get_thumbnail().save("slide1.png")
```

API Moderne :

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    with pres.slides[0].get_image() as image:
        image.save("slide1.png")
```

### Obtenir une vignette de forme

Code utilisant une API obsolète :

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    pres.slides[0].shapes[0].get_thumbnail().save("shape.png")
```

API Moderne :

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    with pres.slides[0].shapes[0].get_image() as image:
        image.save("shape.png")
```

### Obtenir une vignette de présentation

Code utilisant une API obsolète :

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    thumbnails = pres.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for idx, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{idx}.png", drawing.imaging.ImageFormat.png)
```

API Moderne :

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    thumbnails = pres.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for idx, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{idx}.png", slides.ImageFormat.PNG)
```

### Ajouter une image à une présentation

Code utilisant une API obsolète :

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as pres:
    image = drawing.Image.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
```

API Moderne :

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    image = slides.Images.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
```

## Méthodes/propriétés à supprimer et leur remplacement dans l'API Moderne

### Classe Presentation
|Signature de méthode|Signature de méthode de remplacement|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|Sera complètement supprimé|
|save(fname, format, options, response, show_inline)|Sera complètement supprimé|
|print()|Sera complètement supprimé|
|print(printer_settings)|Sera complètement supprimé|
|print(printer_name)|Sera complètement supprimé|
|print(printer_settings, pres_name)|Sera complètement supprimé|

### Classe Slide
|Signature de méthode|Signature de méthode de remplacement|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOotions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|Sera complètement supprimé|
|render_to_graphics(options, graphics, scale_x, scale_y)|Sera complètement supprimé|
|render_to_graphics(options, graphics, rendering_size)|Sera complètement supprimé|

### Classe Shape
|Signature de méthode|Signature de méthode de remplacement|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### Classe ImageCollection
|Signature de méthode|Signature de méthode de remplacement|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### Classe PPImage
|Signature de méthode/propriété|Signature de méthode/propriété de remplacement|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/image/)|

### Classe ImageWrapperFactory
|Signature de méthode|Signature de méthode de remplacement|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### Classe PatternFormat
|Signature de méthode|Signature de méthode de remplacement|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### Classe IPatternFormatEffectiveData
|Signature de méthode|Signature de méthode de remplacement|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### Classe Output
|Signature de méthode|Signature de méthode de remplacement|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## Le support de l'API pour `aspose.pydrawing.Graphics` sera interrompu

Les méthodes avec `aspose.pydrawing.Graphics` sont déclarées obsolètes et leur support sera supprimé de l'API publique.

La partie de l'API qui l'utilise sera supprimée :
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`