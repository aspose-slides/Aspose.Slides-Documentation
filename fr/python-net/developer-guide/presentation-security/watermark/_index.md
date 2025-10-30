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
description: "Apprenez à gérer les filigranes texte et image dans les présentations PowerPoint et OpenDocument en Python pour indiquer un brouillon, des informations confidentielles, le droit d'auteur, etc."
---

## **À propos des filigranes**

**Un filigrane** dans une présentation est un tampon texte ou image utilisé sur une diapositive ou sur l'ensemble des diapositives. En général, un filigrane indique que la présentation est un brouillon (par ex. un filigrane « Brouillon »), qu'elle contient des informations confidentielles (par ex. un filigrane « Confidentiel »), à quelle société elle appartient (par ex. un filigrane « Nom de l'entreprise »), identifie l'auteur de la présentation, etc. Un filigrane aide à prévenir les violations de droits d’auteur en indiquant que la présentation ne doit pas être copiée. Les filigranes sont utilisés à la fois dans les formats PowerPoint et OpenOffice. Dans Aspose.Slides, vous pouvez ajouter un filigrane aux fichiers PowerPoint PPT, PPTX et aux fichiers OpenOffice ODP.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/python-net/), il existe différentes façons de créer des filigranes dans les documents PowerPoint ou OpenOffice et de modifier leur apparence et leur comportement. L’aspect commun est que pour ajouter des filigranes texte, vous devez utiliser la classe [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), et pour ajouter des filigranes image, utilisez la classe [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) ou remplissez une forme de filigrane avec une image. `PictureFrame` implémente la classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), vous permettant d’utiliser tous les paramètres flexibles de l’objet shape. Comme `TextFrame` n’est pas une shape et que ses paramètres sont limités, il est encapsulé dans un objet [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Il existe deux façons d’appliquer un filigrane : à une seule diapositive ou à toutes les diapositives de la présentation. Le Masque des diapositives (Slide Master) est utilisé pour appliquer un filigrane à toutes les diapositives — le filigrane est ajouté au Slide Master, entièrement conçu là‑bas, et appliqué à toutes les diapositives sans affecter la permission de modification du filigrane sur les diapositives individuelles.

Un filigrane est généralement considéré comme non modifiable par d’autres utilisateurs. Pour empêcher le filigrane (ou plutôt la forme parent du filigrane) d’être modifié, Aspose.Slides fournit une fonctionnalité de verrouillage de forme. Une forme spécifique peut être verrouillée sur une diapositive normale ou sur un Slide Master. Lorsque la forme du filigrane est verrouillée sur le Slide Master, elle le sera sur toutes les diapositives de la présentation.

Vous pouvez attribuer un nom au filigrane afin, à l’avenir, de pouvoir le supprimer en le recherchant parmi les formes de la diapositive par son nom.

Vous pouvez concevoir le filigrane comme vous le souhaitez ; toutefois, il existe généralement des caractéristiques communes aux filigranes, comme l’alignement centré, la rotation, la position en avant, etc. Nous verrons comment les utiliser dans les exemples ci‑dessous.

## **Filigrane texte**

### **Ajouter un filigrane texte à une diapositive**

Pour ajouter un filigrane texte dans PPT, PPTX ou ODP, vous pouvez d’abord ajouter une forme à la diapositive, puis ajouter un cadre texte à cette forme. Le cadre texte est représenté par la classe [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). Ce type n’est pas hérité de [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), qui possède un large ensemble de propriétés pour positionner le filigrane de manière flexible. Ainsi, l’objet [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) est encapsulé dans un objet [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Pour ajouter du texte de filigrane à la forme, utilisez la méthode [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) comme indiqué ci‑dessous.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{%alert color="primary" title="Voir aussi"%}} 
- [Comment utiliser la classe TextFrame](/slides/fr/python-net/text-formatting/)
{{%/alert%}}

### **Ajouter un filigrane texte à une présentation**

Si vous souhaitez ajouter un filigrane texte à toute la présentation (c’est‑à‑dire à toutes les diapositives d’un coup), ajoutez‑le au [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/). Le reste de la logique est identique à celui d’ajout d’un filigrane à une diapositive unique — créez un objet [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) puis ajoutez le filigrane avec la méthode [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str).

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{%alert color="primary" title="Voir aussi"%}} 
- [Comment utiliser le Slide Master](/slides/fr/python-net/slide-master/)
{{%/alert%}}

### **Définir la transparence de la forme du filigrane**

Par défaut, la forme rectangulaire possède des couleurs de remplissage et de bordure. Les lignes suivantes rendent la forme transparente.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Définir la police d’un filigrane texte**

Vous pouvez modifier la police du filigrane texte comme indiqué ci‑dessous.

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

Il est possible de centrer le filigrane sur une diapositive ; pour cela, vous pouvez procéder ainsi :

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

Pour ajouter un filigrane image à une diapositive de présentation, vous pouvez suivre les étapes suivantes :

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Verrouiller un filigrane contre la modification**

Si vous devez empêcher la modification d’un filigrane, utilisez la propriété [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) de la forme. Grâce à cette propriété, vous pouvez protéger la forme contre la sélection, le redimensionnement, le déplacement, le groupement avec d’autres éléments, le verrouillage du texte contre la modification, et bien plus encore :

```py
# Verrouiller la forme du filigrane contre toute modification
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Faire passer un filigrane à l’avant‑plan**

Dans Aspose.Slides, l’ordre Z des formes peut être défini via la méthode [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). Pour ce faire, il faut appeler cette méthode depuis la liste des diapositives de la présentation en passant la référence de la forme et son numéro d’ordre. Ainsi, il est possible de faire passer une forme à l’avant‑plan ou de l’envoyer à l’arrière de la diapositive. Cette fonctionnalité est particulièrement utile si vous devez placer un filigrane devant le contenu de la présentation :

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

Aspose.Slides vous permet de définir le nom d’une forme. En utilisant le nom de la forme, vous pourrez la retrouver ultérieurement pour la modifier ou la supprimer. Pour définir le nom de la forme du filigrane, affectez‑le à la propriété [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) :

```py
watermark_shape.name = "watermark"
```

## **Supprimer un filigrane**

Pour supprimer la forme du filigrane, utilisez la méthode [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) afin de la localiser parmi les formes de la diapositive. Ensuite, passez la forme du filigrane à la méthode [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape) :

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Exemple en ligne**

Vous pouvez essayer les outils en ligne gratuits d’**Aspose.Slides** : [Ajouter un filigrane](https://products.aspose.app/slides/watermark) et [Supprimer un filigrane](https://products.aspose.app/slides/watermark/remove-watermark).

![Outils en ligne pour ajouter et supprimer des filigranes](online_tools.png)

## **FAQ**

**Qu’est‑ce qu’un filigrane et pourquoi l’utiliser ?**

Un filigrane est une superposition texte ou image appliquée aux diapositives qui aide à protéger la propriété intellectuelle, renforcer la reconnaissance de la marque ou empêcher l’utilisation non autorisée des présentations.

**Puis‑je ajouter un filigrane à toutes les diapositives d’une présentation ?**

Oui, Aspose.Slides vous permet d’ajouter un filigrane à chaque diapositive d’une présentation. Vous pouvez parcourir toutes les diapositives et appliquer les paramètres du filigrane individuellement.

**Comment ajuster la transparence du filigrane ?**

Vous pouvez ajuster la transparence du filigrane en modifiant les paramètres de remplissage ([FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)) de la forme. Cela garantit que le filigrane reste subtil et n’interfère pas avec le contenu de la diapositive.

**Quels formats d’image sont pris en charge pour les filigranes ?**

Aspose.Slides prend en charge plusieurs formats d’image tels que PNG, JPEG, GIF, BMP, SVG, etc.

**Puis‑je personnaliser la police et le style d’un filigrane texte ?**

Oui, vous pouvez choisir n’importe quelle police, taille et style afin de correspondre au design de votre présentation et de maintenir la cohérence de la marque.

**Comment modifier la position ou l’orientation d’un filigrane ?**

Vous pouvez ajuster la position et l’orientation du filigrane en modifiant les coordonnées, la taille et les propriétés de rotation de la [shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).