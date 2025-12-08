---
title: Convertir les diapositives PowerPoint en images avec Python
linktitle: Diapositive vers Image
type: docs
weight: 41
url: /fr/python-net/convert-slide/
keywords:
- convertir diapositive
- convertir diapositive en image
- exporter diapositive en image
- enregistrer diapositive en image
- diapositive en image
- diapositive en PNG
- diapositive en JPEG
- diapositive en bitmap
- Python
- Aspose.Slides
description: "Apprenez à convertir les diapositives PowerPoint et OpenDocument en divers formats à l'aide d'Aspose.Slides pour Python via .NET. Exportez facilement les diapositives PPTX et ODP en BMP, PNG, JPEG, TIFF et plus encore avec des résultats de haute qualité."
---

## **Vue d'ensemble**

Aspose.Slides for Python via .NET vous permet de convertir facilement les diapositives de présentations PowerPoint et OpenDocument en divers formats d'image, notamment BMP, PNG, JPG (JPEG), GIF et d'autres.

Pour convertir une diapositive en image, suivez ces étapes :

1. Définissez les paramètres de conversion souhaités et sélectionnez les diapositives à exporter en utilisant :
    - La classe [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/), ou
    - La classe [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/).
2. Générez l'image de la diapositive en appelant la méthode `get_image` de la classe [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/).

Dans Aspose.Slides for Python via .NET, [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) est une classe qui vous permet de travailler avec des images définies par des données de pixels. Vous pouvez utiliser une instance de cette classe pour enregistrer des images dans un large éventail de formats (BMP, JPG, PNG, etc.).

## **Convertir des diapositives en bitmap et enregistrer les images au format PNG**

Vous pouvez convertir une diapositive en objet bitmap et l'utiliser directement dans votre application. Alternativement, vous pouvez convertir une diapositive en bitmap, puis enregistrer l'image au format JPEG ou tout autre format de votre choix.

Ce code Python montre comment convertir la première diapositive d'une présentation en objet bitmap, puis enregistrer l'image au format PNG :
```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    # Convertir la première diapositive de la présentation en bitmap.
    with presentation.slides[0].get_image() as image:
        # Enregistrer l'image au format PNG.
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```


## **Convertir des diapositives en images avec des tailles personnalisées**

Il se peut que vous ayez besoin d'obtenir une image d'une certaine taille. En utilisant une surcharge de la méthode [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize), vous pouvez convertir une diapositive en image avec des dimensions spécifiques (largeur et hauteur).

Ce code d'exemple montre comment procéder :
```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    # Convertir la première diapositive de la présentation en bitmap avec la taille spécifiée.
    with presentation.slides[0].get_image(image_size) as image:
        # Enregistrer l'image au format JPEG.
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```


## **Convertir des diapositives avec notes et commentaires en images**

Certaines diapositives peuvent contenir des notes et des commentaires.

Aspose.Slides fournit deux classes—[TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) et [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/)—qui vous permettent de contrôler le rendu des diapositives de présentation en images. Les deux classes incluent la propriété `slides_layout_options`, qui vous permet de configurer le rendu des notes et des commentaires sur une diapositive lors de sa conversion en image.

Avec la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/), vous pouvez spécifier la position souhaitée pour les notes et les commentaires dans l'image résultante.

Ce code Python montre comment convertir une diapositive avec notes et commentaires :
```py 
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    notes_comments_options = slides.export.NotesCommentsLayoutingOptions()
    notes_comments_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED  # Définir la position des notes.
    notes_comments_options.comments_position = slides.export.CommentsPositions.RIGHT       # Définir la position des commentaires.
    notes_comments_options.comments_area_width = 500                                       # Définir la largeur de la zone des commentaires.
    notes_comments_options.comments_area_color = draw.Color.antique_white                  # Définir la couleur de la zone des commentaires.

    # Créer les options de rendu.
    options = slides.export.RenderingOptions()
    options.slides_layout_options = notes_comments_options

    # Convertir la première diapositive de la présentation en image.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as image:
        # Enregistrer l'image au format GIF.
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```


{{% alert title="Note" color="warning" %}} 

Dans tout processus de conversion diapositive‑image, la propriété [notes_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) ne peut pas être définie sur `BOTTOM_FULL` (pour spécifier la position des notes) car le texte d’une note peut être trop long, ce qui empêche son ajustement à la taille d’image indiquée.

{{% /alert %}} 

## **Convertir des diapositives en images en utilisant les options TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) offre un contrôle plus fin sur l’image TIFF résultante en vous permettant de spécifier des paramètres tels que la taille, la résolution, la palette de couleurs, etc.

Ce code Python montre un processus de conversion où les options TIFF sont utilisées pour produire une image noir‑et‑blanc avec une résolution de 300 DPI et une taille de 2160 × 2800 :
```py 
import aspose.pydrawing as draw
import aspose.slides as slides

# Charger un fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:
    # Obtenir la première diapositive de la présentation.
    slide = presentation.slides[0]

    # Configurer les paramètres de l'image TIFF de sortie.
    options = slides.export.TiffOptions()
    options.image_size = draw.Size(2160, 2880)                                 # Définir la taille de l'image.
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED  # Définir le format des pixels (noir et blanc).
    options.dpi_x = 300                                                        # Définir la résolution horizontale.
    options.dpi_y = 300                                                        # Définir la résolution verticale.

    # Convertir la diapositive en image avec les options spécifiées.
    with slide.get_image(options) as image:
        # Enregistrer l'image au format TIFF.
        image.save("output.tiff", slides.ImageFormat.TIFF)
```


## **Convertir toutes les diapositives en images**

Aspose.Slides vous permet de convertir toutes les diapositives d’une présentation en images, transformant ainsi l’ensemble de la présentation en une série d’images.

Ce code d'exemple montre comment convertir toutes les diapositives d’une présentation en images en Python :
```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    # Rendre la présentation en images diapositive par diapositive.
    for i, slide in enumerate(presentation.slides):
        # Contrôler les diapositives masquées (ne pas rendre les diapositives masquées).
        if slide.hidden:
            continue

        # Convertir la diapositive en image.
        with slide.get_image(scale_x, scale_y) as image:
            # Enregistrer l'image au format JPEG.
            image.save("Slide_{0}.jpg".format(i), slides.ImageFormat.JPEG)
```


## **FAQ**

**Aspose.Slides prend‑il en charge le rendu des diapositives avec animations ?**

Non, la méthode `get_image` enregistre uniquement une image statique de la diapositive, sans animations.

**Les diapositives masquées peuvent‑elles être exportées en images ?**

Oui, les diapositives masquées peuvent être traitées comme les diapositives normales. Assurez‑vous simplement qu’elles sont incluses dans la boucle de traitement.

**Les images peuvent‑elles être enregistrées avec des ombres et des effets ?**

Oui, Aspose.Slides prend en charge le rendu des ombres, de la transparence et d’autres effets graphiques lors de l’enregistrement des diapositives en images.