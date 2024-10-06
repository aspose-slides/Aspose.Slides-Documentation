---
title: Visionneuse de Présentation
type: docs
weight: 50
url: /python-net/presentation-viewer/
keywords: "Voir la présentation PowerPoint, voir ppt, voir PPTX, Python, Aspose.Slides pour Python via .NET"
description: "Voir la présentation PowerPoint en Python "
---



Aspose.Slides pour Python via .NET est utilisé pour créer des fichiers de présentation, complets avec des diapositives. Ces diapositives peuvent être visualisées en ouvrant des présentations avec Microsoft PowerPoint. Mais parfois, les développeurs peuvent également avoir besoin de voir des diapositives sous forme d'images dans leur visionneuse d'images préférée ou de créer leur propre visionneuse de présentation. Dans de tels cas, Aspose.Slides pour Python via .NET vous permet d'exporter une diapositive individuelle vers une image. Cet article décrit comment procéder. 
## **Exemple en Direct**
Vous pouvez essayer l'application gratuite [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) pour voir ce que vous pouvez implémenter avec l'API Aspose.Slides :

![powerpoint-in-aspose-viewer](powerpoint-in-aspose-viewer.png)

## **Générer une Image SVG à partir d'une Diapositive**
Pour générer une image SVG à partir de n'importe quelle diapositive souhaitée avec Aspose.Slides pour Python, veuillez suivre les étapes ci-dessous :

- Créez une instance de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) classe.
- Obtenez la référence de la diapositive souhaitée en utilisant son ID ou son index.
- Obtenez l'image SVG dans un flux mémoire.
- Enregistrez le flux mémoire dans un fichier.

```py
import aspose.slides as slides

# Instancier une classe de présentation qui représente le fichier de présentation
with slides.Presentation(path + "CreateSlidesSVGImage.pptx") as pres:
    # Accéder à la première diapositive
    sld = pres.slides[0]

    # Créer un objet de flux mémoire
    with open("Aspose_out-1.svg", "wb") as svg_stream:
        # Générer l'image SVG de la diapositive et l'enregistrer dans le flux mémoire
        sld.write_as_svg(svg_stream)
```


## **Générer un SVG avec des ID de Forme Personnalisés**
Aspose.Slides pour Python via .NET peut être utilisé pour générer [SVG ](https://docs.fileformat.com/page-description-language/svg/)à partir d'une diapositive avec un ID de forme personnalisé. Pour cela, utilisez la propriété ID de [ISvgShape](https://reference.aspose.com/slides/python-net/aspose.slides.export/isvgshape/), qui représente l'ID personnalisé des formes dans le SVG généré. CustomSvgShapeFormattingController peut être utilisé pour définir l'ID de la forme.

```py
import aspose.slides as slides

with slides.Presentation(path + "CreateSlidesSVGImage.pptx") as pres:
    with open("Aspose_out-2.svg", "wb") as svg_stream:
        svgOptions = slides.export.SVGOptions()
        pres.slides[0].write_as_svg(svg_stream, svgOptions)
```


## **Créer une Image Miniature des DIAPOSITIVES**
Aspose.Slides pour Python via .NET vous aide à générer des images miniatures des diapositives. Pour générer la miniature de n'importe quelle diapositive souhaitée en utilisant Aspose.Slides pour Python via .NET :

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) classe.
1. Obtenez la référence de n'importe quelle diapositive souhaitée en utilisant son ID ou son index.
1. Obtenez l'image miniature de la diapositive référencée à une échelle spécifiée.
1. Enregistrez l'image miniature dans n'importe quel format d'image souhaité.

```py
import aspose.slides as slides

# Instancier une classe de présentation qui représente le fichier de présentation
with slides.Presentation("pres.pptx") as pres:
    # Accéder à la première diapositive
    sld = pres.slides[0]

    # Créer une image à pleine échelle
    with sld.get_image(1, 1) as bmp:
        # enregistrer l'image sur le disque au format JPEG
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```


## **Créer une Miniature avec des Dimensions Définies par l'Utilisateur**
1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) classe.
1. Obtenez la référence de n'importe quelle diapositive souhaitée en utilisant son ID ou son index.
1. Obtenez l'image miniature de la diapositive référencée à une échelle spécifiée.
1. Enregistrez l'image miniature dans n'importe quel format d'image souhaité.

```py
import aspose.slides as slides

# Instancier une classe de présentation qui représente le fichier de présentation
with slides.Presentation("pres.pptx") as pres:
    # Accéder à la première diapositive
    sld = pres.slides[0]

    # Dimensions définies par l'utilisateur
    desiredX = 1200
    desiredY = 800

    # Obtention de la valeur mise à l'échelle de X et Y
    ScaleX = (1.0 / pres.slide_size.size.width) * desiredX
    ScaleY = (1.0 / pres.slide_size.size.height) * desiredY


    # Créer une image à pleine échelle
    with sld.get_image(ScaleX, ScaleY) as bmp:
        # enregistrer l'image sur le disque au format JPEG
        bmp.save("Thumbnail2_out.jpg", slides.ImageFormat.JPEG)
```


## **Créer une Miniature à partir d'une Diapositive en Vue de Notes**
Pour générer la miniature de n'importe quelle diapositive souhaitée dans la vue de notes en utilisant Aspose.Slides pour Python via .NET :

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) classe.
1. Obtenez la référence de n'importe quelle diapositive souhaitée en utilisant son ID ou son index.
1. Obtenez l'image miniature de la diapositive référencée à une échelle spécifiée dans la vue de notes.
1. Enregistrez l'image miniature dans n'importe quel format d'image souhaité.

L'extrait de code ci-dessous produit une miniature de la première diapositive d'une présentation dans la vue de notes.

```py
import aspose.slides as slides

# Instancier une classe de présentation qui représente le fichier de présentation
with slides.Presentation("pres.pptx") as pres:
    # Accéder à la première diapositive
    sld = pres.slides[0]

    # Dimensions définies par l'utilisateur
    desiredX = 1200
    desiredY = 800

    # Obtention de la valeur mise à l'échelle de X et Y
    ScaleX = (1.0 / pres.slide_size.size.width) * desiredX
    ScaleY = (1.0 / pres.slide_size.size.height) * desiredY

   
    # Créer une image à pleine échelle                
    with sld.get_image(ScaleX, ScaleY) as bmp:
        # enregistrer l'image sur le disque au format JPEG
        bmp.save("Notes_tnail_out.jpg", slides.ImageFormat.JPEG)
```