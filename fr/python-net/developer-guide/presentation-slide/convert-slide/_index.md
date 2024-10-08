---
title: Convertir la diapositive
type: docs
weight: 41
url: /fr/python-net/convert-slide/
keywords: 
- convertir la diapositive en image
- exporter la diapositive en tant qu'image
- enregistrer la diapositive en tant qu'image
- diapositive en image
- diapositive en PNG
- diapositive en JPEG
- diapositive en bitmap
- PHP
- Aspose.Slides pour Python via .NET
description: "Convertir la diapositive PowerPoint en image (Bitmap, PNG ou JPG) en Python"
---

Aspose.Slides pour Python via .NET vous permet de convertir des diapositives (dans des présentations) en images. Voici les formats d'image pris en charge : BMP, PNG, JPG (JPEG), GIF, et d'autres.

Pour convertir une diapositive en image, faites ceci :

1. Tout d'abord, définissez les paramètres de conversion et les objets de diapositive à convertir en utilisant :
   * l'interface [ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) ou
   * l'interface [IRenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/irenderingoptions/).

2. Deuxièmement, convertissez la diapositive en image en utilisant la méthode [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).

## **À propos du Bitmap et des autres formats d'image**

Dans .NET, un [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) est un objet qui vous permet de travailler avec des images définies par des données de pixel. Vous pouvez utiliser une instance de cette classe pour enregistrer des images dans une large gamme de formats (BMP, JPG, PNG, etc.).

{{% alert title="Info" color="info" %}}

Aspose a récemment développé un convertisseur en ligne [Texte vers GIF](https://products.aspose.app/slides/text-to-gif).

{{% /alert %}}

## **Conversion des diapositives en Bitmap et enregistrement des images en PNG**

Ce code Python vous montre comment convertir la première diapositive d'une présentation en un objet bitmap, puis comment enregistrer l'image au format PNG :

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # Convertit la première diapositive de la présentation en un objet Bitmap
    with pres.slides[0].get_image() as bmp:
        # Enregistre l'image au format PNG
        bmp.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert title="Astuce" color="primary" %}} 

Vous pouvez convertir une diapositive en un objet bitmap et ensuite utiliser l'objet directement quelque part. Ou vous pouvez convertir une diapositive en bitmap puis enregistrer l'image en JPEG ou tout autre format de votre choix.

{{% /alert %}}  

## **Conversion des diapositives en images avec des tailles personnalisées**

Vous pourriez avoir besoin d'obtenir une image d'une certaine taille. En utilisant une surcharge de la méthode [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/), vous pouvez convertir une diapositive en une image avec des dimensions spécifiques (longueur et largeur).

Ce code exemple démontre la conversion proposée en utilisant la méthode [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) en Python :

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # Convertit la première diapositive de la présentation en Bitmap avec la taille spécifiée
    with pres.slides[0].get_image(draw.Size(1820, 1040)) as bmp:
        # Enregistre l'image au format JPEG
        bmp.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Conversion des diapositives avec notes et commentaires en images**

Certaines diapositives contiennent des notes et des commentaires.

Aspose.Slides fournit deux interfaces—[ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) et [IRenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/irenderingoptions/)—qui vous permettent de contrôler le rendu des diapositives de présentation en images. Les deux interfaces contiennent l'interface [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) qui vous permet d'ajouter des notes et des commentaires sur une diapositive lorsque vous convertissez cette diapositive en une image.

{{% alert title="Info" color="info" %}} 

Avec l'interface [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/), vous pouvez spécifier votre position préférée pour les notes et les commentaires dans l'image résultante.

{{% /alert %}} 

Ce code Python démontre le processus de conversion pour une diapositive avec des notes et des commentaires :

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("AddNotesSlideWithNotesStyle_out.pptx") as pres:
    # Crée les options de rendu
    options = slides.export.RenderingOptions()
                
    # Définit la position des notes sur la page
    options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
                
    # Définit la position des commentaires sur la page 
    options.notes_comments_layouting.comments_position = slides.export.CommentsPositions.RIGHT

    # Définit la largeur de la zone de sortie des commentaires
    options.notes_comments_layouting.comments_area_width = 500
                
    # Définit la couleur de la zone des commentaires
    options.notes_comments_layouting.comments_area_color = draw.Color.antique_white
                
    # Convertit la première diapositive de la présentation en objet Bitmap
    with pres.slides[0].get_image(options, 2, 2) as bmp:
        # Enregistre l'image au format GIF
        bmp.save("Slide_Notes_Comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Note" color="warning" %}} 

Dans tout processus de conversion de diapositive en image, la propriété [NotesPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) ne peut pas être définie sur BottomFull (pour spécifier la position des notes) car le texte d'une note peut être volumineux, ce qui signifie qu'il pourrait ne pas tenir dans la taille d'image spécifiée.

{{% /alert %}} 

## **Conversion des diapositives en images en utilisant ITiffOptions**

L'interface [ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) vous donne plus de contrôle (en termes de paramètres) sur l'image résultante. En utilisant cette interface, vous pouvez spécifier la taille, la résolution, la palette de couleurs et d'autres paramètres pour l'image résultante.

Ce code Python démontre un processus de conversion où ITiffOptions est utilisé pour produire une image en noir et blanc avec une résolution de 300dpi et une taille de 2160 × 2800 :

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation(path + "Comments1.pptx") as pres:
    # Obtient une diapositive par son index
    slide = pres.slides[0]

    # Crée un objet TiffOptions
    options = slides.export.TiffOptions() 
    options.image_size = draw.Size(2160, 2880)

    # Définit la police utilisée au cas où la police source n'est pas trouvée
    options.default_regular_font = "Arial Black"

    # Définit la position des notes sur la page 
    options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    # Définit le format de pixel (noir et blanc)
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED

    # Définit la résolution
    options.dpi_x = 300
    options.dpi_y = 300

    # Convertit la diapositive en objet Bitmap
    with slide.get_image(options) as bmp:
        # Enregistre l'image au format BMP
        bmp.save("PresentationNotesComments.tiff", slides.ImageFormat.TIFF)
```

## **Conversion de toutes les diapositives en images**

Aspose.Slides vous permet de convertir toutes les diapositives d'une seule présentation en images. Essentiellement, vous pouvez convertir la présentation (dans son intégralité) en images.

Ce code exemple vous montre comment convertir toutes les diapositives d'une présentation en images en Python :

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # Rendre la présentation dans un tableau d'images diapositive par diapositive
    for i in range(len(pres.slides)):
        # Spécifie le paramètre pour les diapositives cachées (ne pas rendre les diapositives cachées)
        if pres.slides[i].hidden:
            continue

        # Convertit la diapositive en objet Bitmap
        with pres.slides[i].get_image() as bmp:
            # Enregistre l'image au format JPEG
            bmp.save("image_{0}.jpeg".format(i), slides.ImageFormat.JPEG)
```