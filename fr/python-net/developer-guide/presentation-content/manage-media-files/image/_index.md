---
title: "Optimiser la gestion des images dans les présentations avec Python"
linktitle: "Gérer les images"
type: docs
weight: 10
url: /fr/python-net/image/
keywords:
- ajouter une image
- ajouter une image
- remplacer une image
- collection d'images
- cadre d'image
- image liée
- arrière-plan
- ajouter PNG
- ajouter JPG
- ajouter SVG
- SVG en formes
- ressources SVG externes
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment ajouter, réutiliser, lier, remplacer et gérer les images raster et SVG dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET."
---
## **Introduction**

Aspose.Slides for Python via .NET fournit plusieurs méthodes pour travailler avec des images, et chacune sert un but différent. Vous pouvez stocker une image dans une présentation, l'afficher dans un cadre d'image, l'utiliser comme arrière‑plan de diapositive, créer un lien vers une image externe, remplacer une ressource d'image partagée ou convertir du contenu SVG en formes éditables.

Cet article porte sur les ressources d'image et leur utilisation dans une présentation. Pour le recadrage, la transparence, les effets, l'étirement et d'autres formatages appliqués à un cadre d'image individuel, consultez [Cadre d'image](/slides/fr/python-net/picture-frame/).

## **Comprendre le modèle d'image**

Les concepts d'API suivants sont étroitement liés mais pas interchangeables :

- La [collection d'images de présentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imagecollection/) stocke les ressources d'image utilisées par la présentation. Utilisez [ImageCollection.add_image](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imagecollection/add_image/) pour ajouter des données d'image et obtenir une ressource [IPPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ippimage/).
- Un [cadre d'image](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ipictureframe/) est une forme qui affiche une image sur une diapositive, une mise en page ou un masque. Utilisez [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/add_picture_frame/) pour placer une ressource d'image sur une diapositive.
- Un arrière‑plan de diapositive utilise une image comme partie du remplissage de la diapositive plutôt que comme forme. Il ne se comporte donc pas comme un cadre d'image.
- [IPPImage.replace_image](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ippimage/replace_image/) remplace une ressource d'image. Si plusieurs éléments de la présentation utilisent cette ressource, ils utilisent tous le remplacement.
- La conversion d'un SVG en formes crée des formes de diapositive éditables. Après conversion, le contenu n'est plus géré comme une seule ressource d'image.

Un flux de travail typique est donc : ajouter les données d'image à la collection d'images, recevoir un [IPPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ippimage/), puis utiliser cette ressource dans un ou plusieurs cadres d'image ou remplissages.

## **Ajouter une image incorporée**

Pour insérer une image locale, lisez le fichier, ajoutez ses données à la collection d'images et créez un cadre d'image qui utilise le `IPPImage` retourné.

```python
import aspose.slides as slides

with open("photo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

L'image ajoutée de cette manière est incorporée dans la présentation, de sorte que le fichier résultant ne dépend pas de la disponibilité continue du fichier image original.

### **Ajouter une image depuis le Web**

Lorsqu'une image est disponible via HTTP ou HTTPS, téléchargez ses octets, ajoutez‑les à la collection d'images de la présentation et utilisez la ressource d'image retournée de la même manière qu'une image locale.

```python
from urllib.request import urlopen

import aspose.slides as slides

image_url = "https://example.com/image.png"
with urlopen(image_url) as response:
    image_data = response.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", slides.export.SaveFormat.PPTX)
```

Dans les applications de longue durée, réutilisez un client HTTP ou un pool de connexions lorsque cela est approprié plutôt que de créer une nouvelle connexion pour chaque requête. Validez également les URL distantes, les tailles de réponse et les types de contenu lorsque la source n'est pas fiable.

## **Réutiliser des images sur plusieurs diapositives**

Si la même image est nécessaire plusieurs fois, ajoutez‑la à la présentation une seule fois et réutilisez le [IPPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ippimage/) retourné lors de la création de cadres d'image supplémentaires. Cela évite de charger à plusieurs reprises les mêmes données sources et rend explicite la relation entre la ressource d'image partagée et ses utilisations.

Pour les graphiques qui doivent apparaître automatiquement sur de nombreuses diapositives, comme le logo d'une entreprise, envisagez de placer le cadre d'image sur un [masque de diapositive](/slides/fr/python-net/slide-master/) ou une mise en page plutôt que d'ajouter une forme équivalente à chaque diapositive.

## **Utiliser une image comme arrière‑plan de diapositive**

Une image d'arrière‑plan est affectée au remplissage de la diapositive ; elle n'est pas ajoutée comme forme de cadre d'image. Cela est utile lorsque l'image doit couvrir l'arrière‑plan de la diapositive et ne doit pas être manipulée comme un objet de diapositive normal.

```python
import aspose.slides as slides

with open("background.jpg", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image = presentation.images.add_image(image_data)
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    slide.background.fill_format.picture_fill_format.picture.image = image

    presentation.save("background-image.pptx", slides.export.SaveFormat.PPTX)
```

Pour des options d'arrière‑plan supplémentaires, y compris les arrière‑plans de masques et de mises en page, consultez [Arrière‑plan de présentation](/slides/fr/python-net/presentation-background/).

## **Images incorporées et images liées**

Les images incorporées et les images liées présentent des compromis différents en termes de portabilité et de taille de fichier :

- **Image incorporée :** les données de l'image sont stockées dans la présentation. La présentation est autonome, mais la taille du fichier inclut les données de l'image.
- **Image liée :** la présentation stocke un chemin ou une URL vers une image externe. Cela peut réduire la taille de la présentation, mais la ressource externe doit rester accessible lors de l'ouverture ou du rendu de la présentation.

Une image liée peut être créée en affectant le chemin ou l'URL externes via [ISlidesPicture.link_path_long](https://reference.aspose.com/slides/fr/python-net/aspose.slides/islidespicture/link_path_long/) plutôt qu'en incorporant les données de l'image.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, None)
    picture_frame.picture_format.picture.link_path_long = "https://example.com/image.png"

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Utilisez les images liées uniquement lorsque l'environnement de déploiement peut accéder de façon fiable à la ressource externe. Pour les présentations devant fonctionner hors ligne ou être déplacées entre systèmes, les images incorporées sont généralement plus sûres.

## **Travailler avec des images SVG**

SVG est un format vectoriel, il peut donc être utile pour les icônes, les diagrammes et autres graphiques qui doivent être mis à l'échelle sans la même perte de détail que les images raster. Aspose.Slides prend en charge le SVG à la fois comme ressource d'image et comme source de formes de diapositive éditables.

### **Ajouter un SVG en tant qu'image**

Créez un [SvgImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/svgimage/), ajoutez‑le à la collection d'images et placez la ressource d'image résultante dans un cadre d'image.

```python
import aspose.slides as slides

with open("icon.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    image = presentation.images.add_image(svg_image)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", slides.export.SaveFormat.PPTX)
```

### **Convertir un SVG en formes éditables**

Aspose.Slides peut convertir un SVG en un groupe de formes de diapositive éditables, similaire à la commande correspondante de PowerPoint.

![Menu contextuel PowerPoint](img_01_01.png)

Utilisez la surcharge [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/add_group_shape/) qui accepte un [ISvgImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/isvgimage/) pour effectuer la conversion.

```python
import aspose.slides as slides

with open("diagram.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]
    slide.shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

    presentation.save("editable-svg-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Utilisez la conversion SVG‑vers‑formes lorsque des éléments vectoriels individuels doivent être édités comme des formes PowerPoint. Si le SVG doit uniquement être affiché, le conserver en tant qu'image est plus simple et évite de créer de nombreuses formes distinctes.

## **Remplacer une ressource d'image existante**

Utilisez [IPPImage.replace_image](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ippimage/replace_image/) lorsque vous souhaitez remplacer une ressource d'image existante. Cela est particulièrement utile pour les graphiques partagés tels que les logos.

```python
import aspose.slides as slides

with open("new-logo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation("input.pptx") as presentation:
    image_to_replace = presentation.images[0]
    image_to_replace.replace_image(image_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Si plusieurs cadres d'image, arrière‑plans, masques ou mises en page utilisent la même ressource d'image, le remplacement de cette ressource met à jour toutes ces utilisations. Si un seul cadre d'image doit changer, attribuez une image différente à ce cadre plutôt que de remplacer la ressource partagée.

`replace_image` propose également des surcharges qui acceptent un [IImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iimage/) ou un autre [IPPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ippimage/).

## **Conseils pratiques pour la gestion des images**

### **Contrôler la taille de la présentation**

Les grandes images raster peuvent rendre une présentation inutilement volumineuse. Utilisez des images sources dont les dimensions sont adaptées à la taille d'affichage prévue, réutilisez les ressources d'image partagées lorsque cela est possible et évitez d'incorporer des copies répétées du même graphique en pleine résolution.

Pour les images raster déjà placées dans des cadres d'image, [PictureFillFormat.compress_image](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picturefillformat/compress_image/) peut réduire les données d'image selon la résolution sélectionnée et les paramètres de recadrage. Il s'agit d'un traitement de cadre d'image plutôt que d'une gestion de collection d'images, consultez donc [Cadre d'image](/slides/fr/python-net/picture-frame/) pour les opérations de formatage associées.

### **Choisir entre contenu incorporé et lié**

L'incorporation rend la présentation portable car toutes les données d'image requises voyagent avec le fichier. Le lien peut réduire la taille du fichier, mais il introduit une dépendance externe. Utilisez les liens uniquement lorsque cette dépendance est acceptable et stable.

### **Réutiliser l'image de marque partagée**

Pour les logos, filigranes ou graphiques décoratifs répétés, utilisez une seule ressource d'image et réutilisez‑la. Si le graphique fait partie de la conception de la présentation plutôt que du contenu des diapositives, placez‑le sur un masque ou une mise en page afin qu'il soit hérité par les diapositives appropriées.

### **Maintenir la portabilité des ressources SVG**

Un SVG autonome est plus facile à déplacer et à rendre de manière cohérente qu'un SVG dépendant de fichiers ou de ressources réseau externes. Lorsque possible, incorporez les ressources requises avant d'importer le SVG. Convertissez le SVG en formes uniquement lorsque les éléments vectoriels individuels doivent être édités.

### **Utiliser l'API d'image moderne multiplateforme**

Pour le nouveau code Python via .NET, utilisez les API Aspose.Slides [IImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iimage/) et [Images](https://reference.aspose.com/slides/fr/python-net/aspose.slides/images/) plutôt que les API d'image obsolètes `aspose.pydrawing.Image` ou `aspose.pydrawing.Bitmap`. Consultez [API moderne](/slides/fr/python-net/modern-api/) pour les directives de migration.

Les formats WMF et EMF nécessitent une attention particulière. Lorsque ces formats sont transmis via un [IImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iimage/), [ImageCollection.add_image](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imagecollection/add_image/) convertit le métafichier en une représentation PNG raster avant l'insertion. Si la préservation des données du métafichier est importante, utilisez une surcharge basée sur un flux de [ImageCollection.add_image](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imagecollection/add_image/) à la place. La génération de contenu EMF à partir de feuilles de calcul ou d'autres produits constitue un flux d'intégration distinct et dépasse le cadre de cet article.

## **FAQ**

**Quelle est la différence entre la collection d'images et un cadre d'image ?**

La collection d'images stocke des ressources d'image réutilisables. Un cadre d'image est une forme de diapositive qui affiche l'une de ces ressources et offre des formatages spécifiques à l'image tels que le recadrage et les effets.

**Quelle est la meilleure façon de remplacer le même logo partout ?**

Si le logo est déjà partagé comme une ressource d'image unique, remplacez cette ressource avec [IPPImage.replace_image](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ippimage/replace_image/). Pour une image de marque sur l'ensemble de la présentation, placer le logo sur un masque ou une mise en page peut également réduire le contenu de diapositive dupliqué.

**Pourquoi une image liée disparaît‑elle sur un autre ordinateur ?**

Une image liée dépend de son fichier ou URL externe. Si cette ressource n'est pas accessible depuis l'autre ordinateur, l'image liée peut être indisponible. Incorporez l'image lorsque la présentation doit être autonome.

**Une SVG insérée peut‑elle être éditée comme des formes PowerPoint ?**

Oui. Convertissez le SVG avec [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/add_group_shape/) ; le groupe résultant contient des formes de diapositive éditables plutôt qu'une seule image SVG.

**Comment garder les présentations contenant de nombreuses images plus petites ?**

Réutilisez les ressources d'image partagées, évitez les sources raster inutilement volumineuses, compressez les images raster appropriées lorsque cela est pertinent, conservez les éléments de marque répétés sur les masques ou les mises en page, et utilisez les images liées uniquement lorsqu'une dépendance externe est acceptable.