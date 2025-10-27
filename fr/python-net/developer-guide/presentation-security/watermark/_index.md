---
title: Ajouter des filigranes aux présentations en Python
linktitle: Filigrane
type: docs
weight: 40
url: /fr/python-net/watermark/
keywords:
- filigrane
- filigrane texte
- filigrane image
- ajouter filigrane
- modifier filigrane
- supprimer filigrane
- effacer filigrane
- ajouter filigrane à PPT
- ajouter filigrane à PPTX
- ajouter filigrane à ODP
- supprimer filigrane de PPT
- supprimer filigrane de PPTX
- supprimer filigrane de ODP
- effacer filigrane de PPT
- effacer filigrane de PPTX
- effacer filigrane de ODP
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à gérer les filigranes texte et image dans les présentations PowerPoint et OpenDocument avec Python pour indiquer un brouillon, des informations confidentielles, un droit d’auteur, etc."
---

## **À propos des filigranes**

**Un filigrane** dans une présentation est un tampon texte ou image utilisé sur une diapositive ou sur l’ensemble des diapositives. En général, un filigrane sert à indiquer que la présentation est un brouillon (p. ex. « Brouillon »), qu’elle contient des informations confidentielles (« Confidentiel »), à spécifier l’appartenance à une société (« Nom de l’entreprise »), à identifier l’auteur de la présentation, etc. Un filigrane aide à prévenir les violations de droits d’auteur en indiquant que la présentation ne doit pas être copiée. Les filigranes sont employés tant dans les formats PowerPoint que OpenOffice. Avec Aspose.Slides, vous pouvez ajouter un filigrane aux fichiers PPT, PPTX et ODP.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/python-net/), il existe plusieurs façons de créer des filigranes dans des documents PowerPoint ou OpenOffice et de modifier leur conception et leur comportement. Le point commun est que, pour ajouter des filigranes texte, vous devez utiliser la classe [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), et pour ajouter des filigranes image, utilisez la classe [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) ou remplissez une forme de filigrane avec une image. `PictureFrame` implémente la classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), vous permettant d’utiliser tous les réglages flexibles de l’objet forme. Comme `TextFrame` n’est pas une forme et que ses réglages sont limités, il est encapsulé dans un objet [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Il y a deux façons d’appliquer un filigrane : à une diapositive unique ou à toutes les diapositives de la présentation. Le Masque des diapositives (Slide Master) est utilisé pour appliquer un filigrane à toutes les diapositives — le filigrane est ajouté au Masque, entièrement conçu là‑bas, puis propagé à toutes les diapositives sans empêcher la modification du filigrane sur des diapositives individuelles.

Un filigrane est généralement considéré comme non modifiable par d’autres utilisateurs. Pour empêcher le filigrane (ou plutôt la forme parent du filigrane) d’être édité, Aspose.Slides propose la fonction de verrouillage des formes. Une forme spécifique peut être verrouillée sur une diapositive normale ou sur le Masque des diapositives. Lorsque la forme du filigrane est verrouillée sur le Masque, elle l’est sur toutes les diapositives.

Vous pouvez affecter un nom au filigrane afin de le retrouver plus tard, par exemple pour le supprimer, en recherchant la forme par son nom.

Vous pouvez concevoir le filigrane comme vous le souhaitez ; toutefois, certaines caractéristiques sont courantes : alignement centré, rotation, position au premier plan, etc. Nous verrons comment les exploiter dans les exemples suivants.

## **Filigrane texte**

### **Ajouter un filigrane texte à une diapositive**

Pour ajouter un filigrane texte dans un PPT, PPTX ou ODP, ajoutez d’abord une forme à la diapositive, puis ajoutez‑y un cadre texte. Le cadre texte est représenté par la classe [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). Ce type n’hérite pas de [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), qui offre de nombreuses propriétés de positionnement flexibles. Ainsi, l’objet [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) est encapsulé dans un objet [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Pour ajouter le texte du filigrane à la forme, utilisez la méthode [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) comme indiqué ci‑dessous.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser la classe TextFrame](/slides/fr/python-net/text-formatting/)
{{% /alert %}}

### **Ajouter un filigrane texte à une présentation**

Si vous souhaitez ajouter un filigrane texte à l’ensemble de la présentation (c’est‑à‑dire à toutes les diapositives d’un coup), ajoutez‑le au [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/). Le reste de la logique est identique à celle de l’ajout à une diapositive unique — créez un objet [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) puis ajoutez le filigrane à l’aide de la méthode [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str).

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser le Masque des diapositives](/slides/fr/python-net/slide-master/)
{{% /alert %}}

### **Définir la transparence de la forme du filigrane**

Par défaut, la forme rectangle possède des couleurs de remplissage et de contour. Les lignes de code suivantes rendent la forme transparente.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Définir la police d’un filigrane texte**

Vous pouvez modifier la police du filigrane texte comme suit.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **Définir la couleur du texte du filigrane**

Pour définir la couleur du texte du filigrane, utilisez ce code :

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **Centrer un filigrane texte**

Il est possible de centrer le filigrane sur une diapositive ; pour cela, procédez ainsi :

```py
slide_size = presentation.slide_size.size

watermark_width = 400
watermark_height = 40
watermark_x = (slide_size.width - watermark_width) / 2
watermark_y = (slide_size.height - watermark_height) / 2

watermark_shape = slide.shapes.add_auto_shape(
    ShapeType.RECTANGLE, watermark_x, watermark_y, watermark_width, watermark_height)

watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

L’image ci‑dessous montre le résultat final.

![Le filigrane texte](text_watermark.png)

## **Filigrane image**

### **Ajouter un filigrane image à une présentation**

Pour ajouter un filigrane image à une diapositive de présentation, procédez comme suit :

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Verrouiller un filigrane contre l’édition**

S’il faut empêcher l’édition d’un filigrane, utilisez la propriété [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) sur la forme. Cette propriété permet de protéger la forme contre la sélection, le redimensionnement, le repositionnement, le groupement, le verrouillage du texte, etc. :

```py
# Verrouiller la forme du filigrane contre les modifications
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Mettre un filigrane au premier plan**

Dans Aspose.Slides, l’ordre Z des formes peut être défini via la méthode [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). Pour ce faire, appelez‑la depuis la liste des diapositives de la présentation en transmettant la référence de la forme et son nouveau numéro d’ordre. Ainsi, vous pouvez amener une forme au premier plan ou l’envoyer à l’arrière de la diapositive. Cette fonctionnalité est très utile lorsqu’il faut placer un filigrane devant le contenu de la présentation :

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Définir la rotation du filigrane**

Voici un exemple de code montrant comment ajuster la rotation du filigrane afin qu’il soit positionné en diagonale sur la diapositive :

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Attribuer un nom à un filigrane**

Aspose.Slides vous permet d’attribuer un nom à une forme. En utilisant ce nom, vous pourrez accéder à la forme ultérieurement pour la modifier ou la supprimer. Pour donner un nom à la forme du filigrane, affectez‑le à la propriété [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) :

```py
watermark_shape.name = "watermark"
```

## **Supprimer un filigrane**

Pour supprimer la forme du filigrane, utilisez la méthode [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) afin de la retrouver parmi les formes de la diapositive, puis passez la forme au moyen de la méthode [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape) :

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Exemple en direct**

Vous pouvez essayer les outils en ligne **Aspose.Slides free** : [Ajouter un filigrane](https://products.aspose.app/slides/watermark) et [Supprimer un filigrane](https://products.aspose.app/slides/watermark/remove-watermark).

![Outils en ligne pour ajouter et supprimer des filigranes](online_tools.png)

## **FAQ**

**Qu’est‑ce qu’un filigrane et pourquoi l’utiliser ?**

Un filigrane est une superposition texte ou image appliquée aux diapositives qui aide à protéger la propriété intellectuelle, à renforcer la reconnaissance de la marque ou à empêcher l’utilisation non autorisée des présentations.

**Puis‑je ajouter un filigrane à toutes les diapositives d’une présentation ?**

Oui, Aspose.Slides vous permet d’ajouter un filigrane à chaque diapositive d’une présentation. Vous pouvez parcourir toutes les diapositives et appliquer les paramètres du filigrane individuellement.

**Comment ajuster la transparence du filigrane ?**

Vous pouvez ajuster la transparence du filigrane en modifiant les paramètres de remplissage ([FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)) de la forme. Ainsi le filigrane reste discret et ne gêne pas le contenu de la diapositive.

**Quels formats d’image sont pris en charge pour les filigranes ?**

Aspose.Slides prend en charge divers formats d’image tels que PNG, JPEG, GIF, BMP, SVG, etc.

**Puis‑je personnaliser la police et le style d’un filigrane texte ?**

Oui, vous pouvez choisir n’importe quelle police, taille et style afin d’harmoniser le filigrane avec le design de votre présentation et de maintenir la cohérence de la marque.

**Comment modifier la position ou l’orientation d’un filigrane ?**

Vous pouvez ajuster la position et l’orientation du filigrane en modifiant les coordonnées, la taille et la propriété de rotation de la [shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).