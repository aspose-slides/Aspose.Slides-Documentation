---
title: Optimiser la gestion des images dans les présentations avec Python
linktitle: Gérer les images
type: docs
weight: 10
url: /fr/python-java/image/
keywords:
- ajouter image
- ajouter illustration
- remplacer image
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
- Java
- Aspose.Slides
description: "Apprenez comment ajouter, réutiliser, lier, remplacer et gérer les images raster et SVG dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via Java."
---
## **Introduction**

Aspose.Slides for Python via Java propose plusieurs manières de travailler avec les images, chacune ayant un objectif différent. Vous pouvez stocker une image dans une présentation, l’afficher dans un cadre d’image, l’utiliser comme arrière‑plan de diapositive, créer un lien vers une image externe, remplacer une ressource d’image partagée ou convertir du contenu SVG en formes éditables.

Cet article porte sur les ressources d’image et sur la façon dont elles sont utilisées dans une présentation. Pour le recadrage, la transparence, les effets, l’étirement et d’autres formats appliqués à un cadre d’image individuel, voir [Cadre d'image](/slides/fr/python-java/picture-frame/).

## **Comprendre le modèle d'image**

Les concepts d’API suivants sont étroitement liés mais non interchangeables :

- La [collection d'images de présentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagecollection/) stocke les ressources d'image utilisées par la présentation. Utilisez [ImageCollection.addImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagecollection/#addImage) pour ajouter les données d'image et obtenir une ressource [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/).
- Un [cadre d'image](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframe/) est une forme qui affiche une image sur une diapositive, une disposition ou un masque. Utilisez [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addPictureFrame) pour placer une ressource d'image sur une diapositive.
- Un arrière‑plan de diapositive utilise une image comme partie du remplissage de la diapositive plutôt que comme forme. Il ne se comporte donc pas comme un cadre d'image.
- [PPImage.replaceImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/#replaceImage) remplace une ressource d'image. Si plusieurs éléments de la présentation utilisent cette ressource, ils utilisent tous le remplacement.
- La conversion d’un SVG en formes crée des formes de diapositive éditables. Après conversion, le contenu n’est plus géré comme une seule ressource d'image.

Un flux de travail typique est donc : ajouter des données d’image à la collection d’images, recevoir un [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/), puis utiliser cette ressource dans un ou plusieurs cadres d’image ou remplissages.

## **Ajouter une image intégrée**

Pour insérer une image locale, chargez le fichier, ajoutez‑le à la collection d’images et créez un cadre d’image qui utilise le [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/) retourné.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

L’image ajoutée de cette façon est incorporée dans la présentation, de sorte que le fichier résultant ne dépend pas de la disponibilité du fichier image d’origine.

### **Ajouter une image depuis le Web**

Lorsque une image est disponible via HTTP ou HTTPS, téléchargez ses octets, ajoutez‑les à la collection d’images de la présentation et utilisez la ressource d’image retournée de la même manière qu’une image locale.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from urllib.request import urlopen
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    with urlopen("https://example.com/image.png", timeout=10) as response:
        image_data = response.read()

    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dans les applications de longue durée, réutilisez un client HTTP ou une stratégie de gestion des connexions adaptée à l’application plutôt que de créer à plusieurs reprises une infrastructure réseau inutile. Validez également les URL distantes, les tailles de réponse et les types de contenu lorsque la source n’est pas fiable.

## **Réutiliser les images sur plusieurs diapositives**

Si la même image est nécessaire plusieurs fois, ajoutez‑la une seule fois à la présentation et réutilisez le [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/) retourné lors de la création de cadres d’image supplémentaires. Cela évite de charger à plusieurs reprises les mêmes données sources et rend explicite la relation entre la ressource d’image partagée et ses utilisations.

Pour les graphiques qui doivent apparaître automatiquement sur de nombreuses diapositives, comme le logo d’une entreprise, envisagez de placer le cadre d’image sur un [masque de diapositive](/slides/fr/python-java/slide-master/) ou une disposition au lieu d’ajouter une forme équivalente à chaque diapositive.

## **Utiliser une image comme arrière‑plan de diapositive**

Une image d’arrière‑plan est attribuée au remplissage de la diapositive ; elle n’est pas ajoutée comme forme de cadre d’image. Cette méthode est utile lorsque l’image doit couvrir l’arrière‑plan de la diapositive et ne doit pas être manipulée comme un objet de diapositive normal.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("background.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image)

    presentation.save("background-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pour des options d’arrière‑plan supplémentaires, y compris les arrière‑plans de masques et de dispositions, voir [Arrière‑plan de présentation](/slides/fr/python-java/presentation-background/).

## **Images incorporées et images liées**

Les images incorporées et les images liées présentent des compromis différents en termes de portabilité et de taille de fichier :

- **Image incorporée :** les données de l'image sont stockées à l'intérieur de la présentation. La présentation est autonome, mais la taille du fichier inclut les données de l'image.
- **Image liée :** la présentation stocke un chemin ou une URL vers une image externe. Cela peut réduire la taille de la présentation, mais la ressource externe doit rester accessible lorsque la présentation est ouverte ou rendue.

Une image liée peut être créée en affectant le chemin ou l'URL externe via [Picture.setLinkPathLong](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picture/#setLinkPathLong) plutôt qu’en incorporant les données d’image.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, None)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png")

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Utilisez les images liées uniquement lorsque l’environnement de déploiement peut accéder de manière fiable à la ressource externe. Pour les présentations qui doivent fonctionner hors ligne ou être déplacées entre systèmes, les images incorporées sont généralement plus sûres.

## **Travailler avec des images SVG**

SVG est un format vectoriel, il peut donc être utile pour les icônes, diagrammes et autres graphiques qui doivent évoluer sans perte de détail comme les images matricielles. Aspose.Slides prend en charge le SVG à la fois comme ressource d’image et comme source de formes de diapositive éditables.

### **Ajouter un SVG comme image**

Créez un [SvgImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgimage/), ajoutez‑le à la collection d’images et placez la ressource d’image résultante dans un cadre d’image.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage

presentation = Presentation()
try:
    svg_content = Path("icon.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    image = presentation.getImages().addImage(svg_image)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Fichiers SVG avec ressources externes**

Un SVG peut référencer des images externes, des feuilles de style ou des polices. Dans ces cas, [SvgImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgimage/) propose des constructeurs qui acceptent un [ExternalResourceResolver](https://reference.aspose.com/slides/fr/python-java/aspose.slides/externalresourceresolver/) et une URI de base. Le résolveur peut mapper une URI relative vers une URI absolue autorisée et retourner un flux pour la ressource demandée.

Le résolveur rend les ressources externes disponibles pendant que Aspose.Slides traite le SVG, mais il ne réécrit pas le SVG en un document autonome. Si le SVG doit rester portable, intégrez les ressources nécessaires directement dans le SVG, par exemple en utilisant des URI `data:` pour les images liées.

Lorsque les fichiers SVG proviennent de sources non fiables, restreignez les schémas, emplacements de fichiers et hôtes auxquels le résolveur peut accéder. Les résolveurs réseau doivent également appliquer des délais d’attente, des limites de taille de réponse et une validation du contenu.

### **Convertir le SVG en formes éditables**

Aspose.Slides peut convertir un SVG en un groupe de formes de diapositive éditables, similaire à la commande PowerPoint correspondante.

![PowerPoint Popup Menu](img_01_01.png)

Utilisez la surcharge [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addGroupShape) qui accepte un [SvgImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgimage/) pour effectuer la conversion.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, SvgImage

presentation = Presentation()
try:
    svg_content = Path("diagram.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addGroupShape(svg_image, 0, 0, slide_width, slide_height)

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Utilisez la conversion SVG‑vers‑formes lorsque les éléments vectoriels individuels doivent être édités comme des formes PowerPoint. Si le SVG doit seulement être affiché, le garder comme image est plus simple et évite de créer de nombreuses formes séparées.

## **Remplacer une ressource d'image existante**

Utilisez [PPImage.replaceImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/#replaceImage) lorsque vous souhaitez remplacer une ressource d'image existante. Cela est particulièrement utile pour les graphiques partagés tels que les logos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    image_to_replace = presentation.getImages().get_Item(0)

    replacement_image = Images.fromFile("new-logo.png")
    try:
        image_to_replace.replaceImage(replacement_image)
    finally:
        replacement_image.dispose()

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Si plusieurs cadres d’image, arrière‑plans, masques ou dispositions utilisent la même ressource d'image, le remplacement de cette ressource met à jour toutes ces utilisations. Si seul un cadre d’image doit être modifié, attribuez une autre image à ce cadre au lieu de remplacer la ressource partagée.

[PPImage.replaceImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/#replaceImage) propose également des surcharges qui acceptent un tableau d’octets ou un autre [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/).

## **Guide pratique de gestion d'images**

### **Contrôler la taille de la présentation**

Les grandes images matricielles peuvent rendre une présentation inutilement volumineuse. Utilisez des images sources dont les dimensions sont appropriées à la taille d’affichage prévue, réutilisez les ressources d’image partagées lorsque cela est possible et évitez d’incorporer des copies multiples du même graphique haute résolution.

Pour les images matricielles déjà placées dans des cadres d’image, [PictureFillFormat.compressImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillformat/#compressImage) peut réduire les données d’image selon la résolution sélectionnée et les paramètres de recadrage. Il s’agit d’un traitement de cadre d’image plutôt que d’une gestion de collection d’images, consultez donc [Cadre d'image](/slides/fr/python-java/picture-frame/) pour les opérations de formatage associées.

### **Choisir entre le contenu incorporé et le contenu lié**

L’incorporation rend la présentation portable car toutes les données d’image nécessaires voyagent avec le fichier. Le lien peut réduire la taille du fichier, mais il introduit une dépendance externe. N’utilisez les liens que lorsque cette dépendance est acceptable et stable.

### **Réutiliser la marque partagée**

Pour les logos, filigranes ou graphiques décoratifs répétés, utilisez une seule ressource d’image et réutilisez‑la. Si le graphique fait partie du design de la présentation plutôt que du contenu de la diapositive, placez‑le sur un masque ou une disposition afin qu’il soit hérité par les diapositives appropriées.

### **Conserver les ressources SVG portables**

Un SVG autonome est plus facile à déplacer et à rendre de façon cohérente qu’un SVG dépendant de fichiers ou de ressources réseau externes. Dans la mesure du possible, intégrez les ressources requises avant d’importer le SVG. Convertissez le SVG en formes uniquement lorsque les éléments vectoriels individuels doivent être édités.

### **Utiliser l'API d'image multiplateforme moderne**

Pour le nouveau code Python via Java, utilisez les objets d’image multiplateforme Aspose.Slides et les API [Images](https://reference.aspose.com/slides/fr/python-java/aspose.slides/images/) plutôt que l’API publique héritée basée sur `java.awt.image.BufferedImage`. Consultez [Modern API](/slides/fr/python-java/modern-api/) pour les directives de migration.

WMF et EMF nécessitent une prise en compte particulière. Lorsque ces formats sont transmis via un objet d’image multiplateforme, [ImageCollection.addImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagecollection/#addImage) convertit le métafichier en une représentation PNG matricielle avant l’insertion. Si la préservation des données du métafichier est importante, utilisez la surcharge basée sur un flux de [ImageCollection.addImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagecollection/#addImage) à la place. La génération de contenu EMF à partir de feuilles de calcul ou d’autres produits constitue un flux d’intégration distinct et ne relève pas du cadre de cet article.

## **FAQ**

**Quelle est la différence entre la collection d'images et un cadre d'image ?**

La collection d'images stocke des ressources d'image réutilisables. Un cadre d'image est une forme de diapositive qui affiche l'une de ces ressources et fournit des formats spécifiques à l'image tels que le recadrage et les effets.

**Quelle est la meilleure façon de remplacer le même logo partout ?**

Si le logo est déjà partagé comme une ressource d'image unique, remplacez cette ressource avec [PPImage.replaceImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/#replaceImage). Pour une marque à l’échelle de la présentation, placer le logo sur un masque ou une disposition peut également réduire le contenu dupliqué des diapositives.

**Pourquoi une image liée disparaît‑elle sur un autre ordinateur ?**

Une image liée dépend de son fichier ou de son URL externe. Si cette ressource n’est pas accessible depuis l’autre ordinateur, l’image liée peut être indisponible. Incorporez l'image lorsque la présentation doit être autonome.

**Une SVG insérée peut‑elle être éditée comme des formes PowerPoint ?**

Oui. Convertissez le SVG avec [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addGroupShape) ; le groupe résultant contient des formes de diapositive éditables plutôt qu’une seule image SVG.

**Comment garder les présentations contenant de nombreuses images plus petites ?**

Réutilisez les ressources d'image partagées, évitez les sources matricielles inutilement volumineuses, compressez les images matricielles appropriées lorsqu’il est pertinent, placez la marque répétée sur des masques ou des dispositions, et utilisez les images liées uniquement lorsque la dépendance externe est acceptable.