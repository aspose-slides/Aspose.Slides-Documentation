---
title: Optimiser la gestion des images dans PowerPoint avec Python
linktitle: Gestion des images
type: docs
weight: 10
url: /fr/python-net/image/
keywords:
- ajouter une image
- ajouter une image
- ajouter un bitmap
- remplacer une image
- remplacer une image
- à partir du web
- arrière-plan
- ajouter PNG
- ajouter JPG
- ajouter SVG
- ajouter EMF
- ajouter WMF
- ajouter TIFF
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Simplifiez la gestion des images dans PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET, en optimisant les performances et en automatisant votre flux de travail."
---

## **Aperçu**

Les images rendent les présentations plus attrayantes et intéressantes. Dans Microsoft PowerPoint, vous pouvez insérer des images à partir d’un fichier, d’Internet ou d’autres sources sur les diapositives. De même, Aspose.Slides vous permet d’ajouter des images aux diapositives de plusieurs manières.

{{% alert  title="Tip" color="primary" %}}
Aspose propose des convertisseurs gratuits—[JPEG vers PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—qui vous permettent de créer rapidement des présentations à partir d’images.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Si vous voulez ajouter une image sous forme d’objet cadre—surtout si vous prévoyez d’utiliser les options de mise en forme standard comme le redimensionnement ou l’application d’effets—voir [Add Picture Frames to Presentations with Python](https://docs.aspose.com/slides/python-net/picture-frame/).
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Vous pouvez utiliser les opérations d’E/S d’images et de présentations pour convertir des images entre formats. Consultez ces pages : convertir [image en JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/) ; convertir [JPG en image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/) ; convertir [JPG en PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/) ; convertir [PNG en JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/) ; convertir [PNG en SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/) ; et convertir [SVG en PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides prend en charge les images dans les formats populaires tels que JPEG, PNG, BMP, GIF et autres.

## **Ajouter des images stockées localement aux diapositives**

Vous pouvez ajouter une ou plusieurs images depuis votre ordinateur à une diapositive d’une présentation. L’exemple Python suivant montre comment ajouter une image à une diapositive :
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```


## **Ajouter des images depuis le Web aux diapositives**

Si l’image que vous souhaitez ajouter à une diapositive n’est pas disponible sur votre ordinateur, vous pouvez l’insérer directement depuis le Web.

L’exemple Python suivant montre comment ajouter une image depuis une URL à une diapositive :
```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image_data = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **Ajouter des images aux maîtres de diapositives**

Un maître de diapositive est la diapositive de niveau supérieur qui stocke et contrôle les informations—thème, mise en page, etc.—pour toutes les diapositives qui en dépendent. Lorsque vous ajoutez une image à un maître de diapositive, cette image apparaît sur chaque diapositive qui utilise ce maître.

L’exemple Python suivant montre comment ajouter une image à un maître de diapositive :
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    master_slide = slide.layout_slide.master_slide

    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir une image comme arrière‑plan d’une diapositive**

Vous pouvez vouloir utiliser une image comme arrière‑plan d’une diapositive spécifique ou de plusieurs diapositives. Pour plus de détails, voir [Set an Image as the Background for a Slide](https://docs.aspose.com/slides/python-net/presentation-background/#set-image-as-background-for-slide).

## **Ajouter du SVG aux présentations**

Vous pouvez insérer n’importe quelle image dans une présentation à l’aide de la méthode [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) de la classe [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).

Pour créer un objet image à partir d’un SVG, suivez ces étapes :

1. Créez un [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/) et ajoutez‑le à la collection d’images de la présentation.  
2. Créez un objet [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) à partir du [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/).  
3. Créez un objet [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) en utilisant le [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).

L’exemple Python suivant montre comment ajouter une image SVG à une présentation en suivant ces étapes :
```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Lire le contenu d'un fichier SVG.
    with open("sample.svg", "rt") as image_stream:
        svg_content = image_stream.read()
        # Créer un objet SvgImage.
        svg_image = slides.SvgImage(svg_content)

        # Créer un objet PPImage.
        pp_image = presentation.images.add_image(svg_image)

        # Créer un nouveau PictureFrame.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, pp_image.width, pp_image.height, pp_image)

        # Enregistrer la présentation au format PPTX.
        presentation.save("presentation_with_SVG.pptx", slides.export.SaveFormat.PPTX)
```


## **Convertir un SVG en un ensemble de formes**

Aspose.Slides convertit les SVG en un ensemble de formes de la même façon que PowerPoint gère les SVG.

![PowerPoint Popup Menu](img_01_01.png)

Cette fonctionnalité est fournie par une surcharge de la méthode [add_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_group_shape/) de la classe [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) qui prend un [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/) comme premier argument.  

Le code d’exemple ci‑dessous montre comment convertir un fichier SVG en un ensemble de formes.
```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Lire le contenu du fichier SVG.
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # Créer un objet SvgImage.
        svg_image = slides.SvgImage(svg_content)

        # Obtenir la taille de la diapositive.
        slide_size = presentation.slide_size.size

        # Convertir l'image SVG en un groupe de formes et l'adapter à la taille de la diapositive.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # Enregistrer la présentation au format PPTX.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```


## **Ajouter des images au format EMF dans les diapositives**

Aspose.Slides for Python vous permet d’insérer des images Enhanced Metafile (EMF) dans les présentations.

L’exemple Python suivant illustre cela :
```py 
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```


## **Remplacer des images dans la collection d’images**

Aspose.Slides vous permet de remplacer les images stockées dans la collection d’images d’une présentation, y compris celles utilisées par les formes de diapositives. Cette section décrit plusieurs approches pour mettre à jour les images de la collection. L’API propose des méthodes simples pour remplacer une image par des octets bruts, une instance [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/), ou une autre image déjà présente dans la collection.

Suivez ces étapes :

1. Chargez la présentation contenant les images à l’aide de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Chargez une nouvelle image depuis un fichier dans un tableau d’octets.  
3. Remplacez l’image cible par la nouvelle image en utilisant le tableau d’octets.  
4. Vous pouvez également charger l’image dans un objet [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) et remplacer l’image cible par cet objet.  
5. Ou remplacer l’image cible par une image déjà présente dans la collection d’images de la présentation.  
6. Enregistrez la présentation modifiée au format PPTX.  
```py
def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:

    # La première méthode.
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # La deuxième méthode.
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # La troisième méthode.
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # Enregistrer la présentation dans un fichier.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Info" color="info" %}}
Avec le convertisseur gratuit [Text to GIF](https://products.aspose.app/slides/text-to-gif) d’Aspose, vous pouvez facilement animer du texte et créer des GIF à partir de texte.
{{% /alert %}}

## **FAQ**

**La résolution originale de l’image reste‑t‑elle intacte après l’insertion ?**

Oui. Les pixels sources sont conservés, mais l’apparence finale dépend de la façon dont le [picture](/slides/fr/python-net/picture-frame/) est redimensionné sur la diapositive et de toute compression appliquée lors de l’enregistrement.

**Quelle est la meilleure façon de remplacer le même logo sur des dizaines de diapositives en une fois ?**

Placez le logo sur la diapositive maître ou sur une mise en page et remplacez‑le dans la collection d’images de la présentation — les mises à jour se propageront à tous les éléments qui utilisent cette ressource.

**Un SVG inséré peut‑il être converti en formes modifiables ?**

Oui. Vous pouvez convertir un SVG en un groupe de formes, après quoi chaque partie devient modifiable avec les propriétés de forme standard.

**Comment définir une image comme arrière‑plan pour plusieurs diapositives d’un coup ?**

[Attribuez l’image comme arrière‑plan](/slides/fr/python-net/presentation-background/) sur la diapositive maître ou la mise en page concernée — toutes les diapositives utilisant ce maître/mise en page hériteront de l’arrière‑plan.

**Comment empêcher la présentation de « gonfler » en taille à cause de nombreuses images ?**

Réutilisez une seule ressource d’image au lieu de duplicata, choisissez des résolutions raisonnables, appliquez la compression lors de l’enregistrement et conservez les graphiques répétés sur le maître lorsque cela est approprié.