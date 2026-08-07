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
- remplacer une image
- remplacer une photo
- depuis le web
- arrière-plan
- ajouter PNG
- ajouter JPG
- ajouter SVG
- ajouter EMF
- ajouter WMF
- ajouter TIFF
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Simplifiez la gestion des images dans PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET, en optimisant les performances et en automatisant votre flux de travail."
---
## **Introduction**

Les images rendent les présentations plus attrayantes et intéressantes. Dans Microsoft PowerPoint, vous pouvez insérer des images depuis un fichier, Internet ou d’autres sources sur les diapositives. De même, Aspose.Slides vous permet d’ajouter des images aux diapositives de plusieurs façons.

{{% alert  title="Tip" color="primary" %}}
Aspose propose des convertisseurs gratuits—[JPEG vers PowerPoint](https://products.aspose.app/slides/fr/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/fr/import/png-to-ppt)—qui vous permettent de créer rapidement des présentations à partir d’images.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Si vous souhaitez ajouter une image en tant qu’objet cadre—en particulier si vous prévoyez d’utiliser les options de mise en forme standard telles que le redimensionnement ou l’application d’effets—voir [Ajouter des cadres d’image aux présentations avec Python](https://docs.aspose.com/slides/fr/python-net/picture-frame/).
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Vous pouvez utiliser les opérations d’E/S d’image et de présentation pour convertir les images entre formats. Voir ces pages : convertir [image en JPG](https://products.aspose.com/slides/fr/python-net/conversion/image-to-jpg/); convertir [JPG en image](https://products.aspose.com/slides/fr/python-net/conversion/jpg-to-image/); convertir [JPG en PNG](https://products.aspose.com/slides/fr/python-net/conversion/jpg-to-png/); convertir [PNG en JPG](https://products.aspose.com/slides/fr/python-net/conversion/png-to-jpg/); convertir [PNG en SVG](https://products.aspose.com/slides/fr/python-net/conversion/png-to-svg/); et convertir [SVG en PNG](https://products.aspose.com/slides/fr/python-net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides prend en charge le travail avec des images dans des formats populaires tels que JPEG, PNG, BMP, GIF et autres.

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
from urllib.request import urlopen

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Télécharger les octets bruts de l'image.
    with urlopen("[REPLACE WITH URL]") as response:
        image_data = response.read()

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter des images aux masques de diapositives**

Un masque de diapositive est la diapositive de niveau supérieur qui stocke et contrôle les informations—thème, mise en page, etc.—pour toutes les diapositives qui en dépendent. Lorsque vous ajoutez une image à un masque de diapositive, cette image apparaît sur chaque diapositive qui utilise ce masque.  
L’exemple Python suivant montre comment ajouter une image à un masque de diapositive :
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

## **Ajouter des images comme arrière-plans de diapositive**

Vous pouvez utiliser une image comme arrière-plan pour une ou plusieurs diapositives. Pour plus de détails, voir *[Définir des images comme arrière-plans pour les diapositives](/slides/fr/python-net/presentation-background/#setting-images-as-background-for-slides)*.

## **Ajouter du SVG aux présentations**

Le contenu SVG peut être ajouté à une présentation en utilisant la classe [SvgImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/svgimage/). L’image SVG résultante peut ensuite être ajoutée à la collection d’images de la présentation et utilisée pour créer un cadre d’image.  
L’exemple Python suivant importe une chaîne SVG autonome. Toutes les images, styles et autres ressources utilisés par ce SVG sont incorporés directement dans le contenu SVG.
```py
import aspose.slides as slides

svg_content = """
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>
"""

with slides.Presentation() as presentation:
    svg_image = slides.SvgImage(svg_content)
    image = presentation.images.add_image(svg_image)

    presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 20, 20, image.width, image.height, image
    )

    presentation.save("self-contained-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **Convertir le SVG en un ensemble de formes**

Aspose.Slides convertit les SVG en un ensemble de formes de manière similaire à la gestion des SVG dans PowerPoint.

![Menu contextuel PowerPoint](img_01_01.png)

Cette fonctionnalité est fournie par une surcharge de la méthode [add_group_shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/add_group_shape/) de la classe [ShapeCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/) qui prend un [SvgImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/svgimage/) comme premier argument.  

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

        # Convertir l'image SVG en un groupe de formes et la mettre à l'échelle à la taille de la diapositive.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # Enregistrer la présentation au format PPTX.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter des images au format EMF aux diapositives**

Aspose.Slides pour Python vous permet d’insérer des images Enhanced Metafile (EMF) dans les présentations.  
L’exemple Python suivant le démontre :
```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **Remplacer des images dans la collection d’images**

Aspose.Slides vous permet de remplacer les images stockées dans la collection d’images d’une présentation, y compris celles utilisées par les formes de diapositives. Cette section décrit plusieurs approches pour mettre à jour les images de la collection. L’API propose des méthodes simples pour remplacer une image par des données binaires brutes, une instance [IImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iimage/), ou une autre image déjà présente dans la collection.  

Suivez ces étapes :
1. Chargez la présentation contenant les images en utilisant la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
2. Chargez une nouvelle image depuis un fichier dans un tableau d’octets.
3. Remplacez l’image cible par la nouvelle image en utilisant le tableau d’octets.
4. Alternativement, chargez l’image dans un objet [IImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iimage/) et remplacez l’image cible par cet objet.
5. Ou remplacez l’image cible par une image déjà présente dans la collection d’images de la présentation.
6. Enregistrez la présentation modifiée au format PPTX.
```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:

    # La première façon.
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # La deuxième façon.
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # La troisième façon.
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # Enregistrer la présentation dans un fichier.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
Avec le convertisseur gratuit [Texte vers GIF](https://products.aspose.app/slides/fr/text-to-gif) d’Aspose, vous pouvez facilement animer du texte et créer des GIF à partir de texte.
{{% /alert %}}

## **FAQ**

**La résolution d’origine de l’image reste‑t‑elle intacte après l’insertion ?**  
Oui. Les pixels d’origine sont préservés, mais l’apparence finale dépend de la façon dont le [picture](/slides/fr/python-net/picture-frame/) est mis à l’échelle sur la diapositive et de toute compression appliquée lors de l’enregistrement.

**Quelle est la meilleure façon de remplacer le même logo sur des dizaines de diapositives en même temps ?**  
Placez le logo sur la diapositive maître ou sur une disposition et remplacez‑le dans la collection d’images de la présentation — les mises à jour se propageront à tous les éléments qui utilisent cette ressource.

**Une SVG insérée peut‑elle être convertie en formes modifiables ?**  
Oui. Vous pouvez convertir un SVG en un groupe de formes, après quoi chaque partie devient modifiable avec les propriétés de forme standards.

**Comment définir une image comme arrière‑plan pour plusieurs diapositives simultanément ?**  
[Attribuer l’image comme arrière‑plan](/slides/fr/python-net/presentation-background/) sur la diapositive maître ou la disposition correspondante—toutes les diapositives utilisant ce maître/disposition hériteront de l’arrière‑plan.

**Comment empêcher une présentation de devenir trop volumineuse à cause de nombreuses images ?**  
Réutilisez une ressource image unique au lieu de duplicata, choisissez des résolutions raisonnables, appliquez une compression lors de l’enregistrement, et conservez les graphiques répétés sur le maître lorsque c’est approprié.