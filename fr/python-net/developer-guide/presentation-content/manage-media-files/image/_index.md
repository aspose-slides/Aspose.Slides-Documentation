---
title: Optimiser la gestion des images dans PowerPoint avec Python
linktitle: Gérer les images
type: docs
weight: 10
url: /fr/python-net/image/
keywords:
- ajouter une image
- ajouter une photo
- ajouter un bitmap
- ajouter un PNG
- ajouter un JPG
- ajouter un SVG
- ajouter un EMF
- ajouter un WMF
- ajouter un TIFF
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Rationalisez la gestion des images dans PowerPoint et OpenDocument avec Aspose.Slides for Python via .NET, en optimisant les performances et en automatisant votre flux de travail."
---

## **Images dans les Diapositives des Présentations**

Les images rendent les présentations plus engageantes et intéressantes. Dans Microsoft PowerPoint, vous pouvez insérer des images à partir d'un fichier, d'internet ou d'autres emplacements sur les diapositives. De même, Aspose.Slides vous permet d'ajouter des images aux diapositives de vos présentations par le biais de différentes procédures.

{{% alert  title="Conseil" color="primary" %}} 

Aspose propose des convertisseurs gratuits—[JPEG vers PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—qui permettent de créer rapidement des présentations à partir d'images. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Si vous souhaitez ajouter une image en tant qu'objet cadre—surtout si vous prévoyez d'utiliser des options de formatage standard pour changer sa taille, ajouter des effets, etc.—voir [Cadre d'image](https://docs.aspose.com/slides/python-net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Vous pouvez manipuler les opérations d'entrée/sortie impliquant des images et des présentations PowerPoint pour convertir une image d'un format à un autre. Voir ces pages : convertir [image en JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/) ; convertir [JPG en image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/) ; convertir [JPG en PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/) ; convertir [PNG en SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides prend en charge les opérations avec des images dans ces formats populaires : JPEG, PNG, BMP, GIF, et autres. 

## **Ajouter des Images Stockées Localement aux Diapositives**

Vous pouvez ajouter une ou plusieurs images sur votre ordinateur à une diapositive d'une présentation. Ce code exemple en Python vous montre comment ajouter une image à une diapositive :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    pres.save("pres_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter des Images depuis le Web aux Diapositives**

Si l'image que vous souhaitez ajouter à une diapositive n'est pas disponible sur votre ordinateur, vous pouvez ajouter l'image directement depuis le web. 

Ce code exemple vous montre comment ajouter une image depuis le web à une diapositive en Python :

```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as pres:
    slide = pres.slides[0]
    imageData = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = pres.images.add_image(imageData)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter des Images aux Masques de Diapositive**

Un masque de diapositive est la diapositive principale qui stocke et contrôle les informations (thème, mise en page, etc.) sur toutes les diapositives qui en dépendent. Donc, lorsque vous ajoutez une image à un masque de diapositive, cette image apparaît sur chaque diapositive sous ce masque de diapositive. 

Ce code exemple Python vous montre comment ajouter une image à un masque de diapositive :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    masterSlide = slide.layout_slide.master_slide
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
        masterSlide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
        
    pres.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter des Images comme Arrière-plan de Diapositive**

Vous pouvez décider d'utiliser une image comme arrière-plan pour une diapositive spécifique ou plusieurs diapositives. Dans ce cas, vous devez consulter *[Définir des Images comme Arrière-plans pour les Diapositives](https://docs.aspose.com/slides/python-net/presentation-background/#setting-images-as-background-for-slides)*.

## **Ajouter SVG aux Présentations**
Vous pouvez ajouter ou insérer n'importe quelle image dans une présentation en utilisant la méthode [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) qui appartient à l'interface [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

Pour créer un objet image basé sur une image SVG, vous pouvez procéder comme suit :

1. Créer un objet SvgImage pour l'insérer dans ImageShapeCollection
2. Créer un objet PPImage à partir d'ISvgImage
3. Créer un objet PictureFrame en utilisant l'interface IPPImage

Ce code exemple vous montre comment implémenter les étapes ci-dessus pour ajouter une image SVG dans une présentation :
```py 
import aspose.slides as slides

# Créer une nouvelle présentation
with slides.Presentation() as p:
    # Lire le contenu du fichier SVG
    with open("sample.svg","rt") as in_file:
        svgContent = in_file.read()
        # Créer un objet SvgImage
        svgImage = slides.SvgImage(svgContent)

        # Créer un objet PPImage
        ppImage = p.images.add_image(svgImage)

        # Créer un nouveau PictureFrame 
        p.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, ppImage.width, ppImage.height, ppImage)

        # Sauvegarder la présentation au format PPTX
        p.save("presentation_with-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **Conversion de SVG en un Ensemble de Formes**
La conversion SVG en un ensemble de formes d'Aspose.Slides est similaire à la fonctionnalité PowerPoint utilisée pour travailler avec des images SVG :

![Menu contextuel PowerPoint](img_01_01.png)

La fonctionnalité est fournie par l'une des surcharges de la méthode [add_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/addgroupshape/) de l'interface [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) qui prend un objet [ISvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/isvgimage/) comme premier argument.

Ce code exemple vous montre comment utiliser la méthode décrite pour convertir un fichier SVG en un ensemble de formes :

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Lire le contenu du fichier SVG
    with open("sample.svg","rt") as in_file:
        svgContent = in_file.read()
        # Créer un objet SvgImage
        svgImage = slides.SvgImage(svgContent)

        # Obtenir la taille de la diapositive
        slide_size = presentation.slide_size.size

        # Convertir l'image SVG en groupe de formes en l'échelonnant à la taille de la diapositive
        presentation.slides[0].shapes.add_group_shape(svgImage, 0, 0, slide_size.width, slide_size.height)

        # Sauvegarder la présentation au format PPTX
        presentation.save("presentation_with_shape_svg.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter des Images en tant qu'EMF dans les Diapositives**
Aspose.Slides pour Python via .NET vous permet d'ajouter l'image EMF. 

Ce code exemple vous montre comment effectuer la tâche décrite :

```py 
with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open("image.emf", "rb") as in_file:
        emfImage = pres.images.add_image(in_file)
        slide_size = pres.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emfImage)
    
    pres.save("pres_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}

En utilisant le convertisseur GRATUIT Aspose [Texte en GIF](https://products.aspose.app/slides/text-to-gif), vous pouvez facilement animer des textes, créer des GIFs à partir de textes, etc. 

{{% /alert %}}