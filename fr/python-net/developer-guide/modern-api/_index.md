---
title: Améliorer le traitement d'images avec l'API moderne
linktitle: API moderne
type: docs
weight: 280
url: /fr/python-net/modern-api/
keywords:
- API moderne
- dessin
- vignette de diapositive
- diapositive vers image
- vignette de forme
- forme vers image
- vignette de présentation
- présentation vers images
- ajouter image
- ajouter image
- Python
- Aspose.Slides
description: "Modernisez le traitement des images de diapositives en remplaçant les API d'imagerie obsolètes par l'API moderne Python pour une automatisation transparente de PowerPoint et OpenDocument."
---

## **Introduction**

L'API publique Aspose.Slides for Python dépend actuellement des types `aspose.pydrawing` suivants :
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

Depuis la version 24.4, cette API publique est **obsolète** en raison des [modifications](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) apportées à l'API publique Aspose.Slides for Python.

Pour éliminer `aspose.pydrawing` de l'API publique, nous avons introduit l'**API moderne**. Les méthodes qui utilisent `aspose.pydrawing.Image` et `aspose.pydrawing.Bitmap` sont obsolètes et seront remplacées par leurs équivalents de l'API moderne. Les méthodes qui utilisent `aspose.pydrawing.Graphics` sont obsolètes, et leur prise en charge sera supprimée de l'API publique.

La suppression de l'API obsolète dépendante de `aspose.pydrawing` est prévue pour la version **24.8**.

## **API moderne**

Les classes et énumérations suivantes ont été ajoutées à l'API publique :

- [`aspose.slides.IImage`](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) — représente une image raster ou vectorielle.  
- [`aspose.slides.ImageFormat`](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) — représente un format de fichier image.  
- [`aspose.slides.Images`](https://reference.aspose.com/slides/python-net/aspose.slides/images/) — fournit des méthodes pour créer et travailler avec `IImage`.

Un scénario d'utilisation typique de la nouvelle API ressemble à ceci :

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## **Remplacer l'ancien code par l'API moderne**

Pour faciliter la transition, la nouvelle interface `IImage` reflète les API séparées des classes `Image` et `Bitmap`. Dans la plupart des cas, il suffit de remplacer les appels aux méthodes qui utilisent `aspose.pydrawing` par leurs équivalents de l'API moderne.

### **Obtenir une vignette de diapositive**

**API obsolète :**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**API moderne :**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **Obtenir une vignette de forme**

**API obsolète :**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**API moderne :**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **Obtenir une vignette de présentation**

**API obsolète :**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**API moderne :**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **Ajouter une image à une présentation**

**API obsolète :**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**API moderne :**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **Méthodes et propriétés qui seront supprimées et leurs remplacements modernes**

### **Classe Presentation**

|Signature de la méthode|Signature de la méthode de remplacement|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|Sera supprimé complètement|
|save(fname, format, options, response, show_inline)|Sera supprimé complètement|
|print()|Sera supprimé complètement|
|print(printer_settings)|Sera supprimé complètement|
|print(printer_name)|Sera supprimé complètement|
|print(printer_settings, pres_name)|Sera supprimé complètement|

### **Classe Slide**

|Signature de la méthode|Signature de la méthode de remplacement|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOotions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingssize)|
|render_to_graphics(options, graphics)|Sera supprimé complètement|
|render_to_graphics(options, graphics, scale_x, scale_y)|Sera supprimé complètement|
|render_to_graphics(options, graphics, rendering_size)|Sera supprimé complètement|

### **Classe Shape**

|Signature de la méthode|Signature de la méthode de remplacement|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **Classe ImageCollection**

|Signature de la méthode|Signature de la méthode de remplacement|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **Classe PPImage**

|Signature de la méthode/propriété|Signature de la méthode/propriété de remplacement|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/image/)|

### **Classe ImageWrapperFactory**

|Signature de la méthode|Signature de la méthode de remplacement|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **Classe PatternFormat**

|Signature de la méthode|Signature de la méthode de remplacement|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **Classe IPatternFormatEffectiveData**

|Signature de la méthode|Signature de la méthode de remplacement|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Classe Output**

|Signature de la méthode|Signature de la méthode de remplacement|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **La prise en charge d'aspose.pydrawing.Graphics sera interrompue**

Les méthodes qui utilisent `aspose.pydrawing.Graphics` sont obsolètes ; leur prise en charge sera retirée de l'API publique.

Les membres de l'API qui reposent sur `aspose.pydrawing.Graphics` et qui seront supprimés incluent :
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **FAQ**

**Pourquoi `aspose.pydrawing.Graphics` a‑t‑il été abandonné ?**

La prise en charge de Graphics est supprimée de l'API publique afin d’unifier le travail de rendu et d'images, d’éliminer les dépendances spécifiques à la plateforme et de passer à une approche multiplateforme avec [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/). Toutes les méthodes de rendu vers Graphics seront supprimées.

**Quel est l’avantage pratique d’IImage comparé à Image/Bitmap ?**

[IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) unifie le travail avec les images raster et vectorielles, simplifie l’enregistrement dans divers formats via [ImageFormat](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/), réduit la dépendance à pydrawing et rend le code plus portable entre les environnements.

**L’API moderne affectera‑t‑elle les performances de génération des vignettes ?**

Le passage de `get_thumbnail` à `get_image` ne détériore pas les scénarios : les nouvelles méthodes offrent les mêmes capacités de production d’images avec options et tailles, tout en conservant la prise en charge des options de rendu. Le gain ou la perte spécifique dépend du scénario, mais fonctionnellement les remplacements sont équivalents.