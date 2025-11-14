---
title: Filigrane
type: docs
weight: 40
url: /fr/python-net/watermark/
keywords:
- filigrane
- ajouter filigrane
- filigrane de texte
- filigrane d'image
- PowerPoint
- présentation
- Python
- Aspose.Slides pour Python via .NET
description: "Ajouter des filigranes de texte et d'image aux présentations PowerPoint en Python"
---

## **À propos des Filigranes**

**Un filigrane** dans une présentation est un texte ou une image utilisé sur une diapositive ou sur toutes les diapositives de la présentation. En général, un filigrane est utilisé pour indiquer que la présentation est un brouillon (par exemple, un filigrane "Brouillon"), qu'elle contient des informations confidentielles (par exemple, un filigrane "Confidentiel"), pour spécifier à quelle entreprise elle appartient (par exemple, un filigrane "Nom de l'entreprise"), pour identifier l'auteur de la présentation, etc. Un filigrane aide à prévenir les violations de droits d'auteur en indiquant que la présentation ne doit pas être copiée. Les filigranes sont utilisés dans les formats de présentation PowerPoint et OpenOffice. Dans Aspose.Slides, vous pouvez ajouter un filigrane aux formats de fichiers PowerPoint PPT, PPTX et OpenOffice ODP.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/python-net/), il existe plusieurs façons de créer des filigranes dans les documents PowerPoint ou OpenOffice et de modifier leur design et leur comportement. L'aspect commun est que pour ajouter des filigranes de texte, vous devez utiliser la classe [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), et pour ajouter des filigranes d'image, utilisez la classe [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) ou remplissez une forme de filigrane avec une image. `PictureFrame` implémente la classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), vous permettant d'utiliser tous les paramètres flexibles de l'objet de forme. Puisque `TextFrame` n'est pas une forme et que ses paramètres sont limités, il est encapsulé dans un objet [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Il existe deux façons d'appliquer un filigrane : à une seule diapositive ou à toutes les diapositives de la présentation. Le Slide Master est utilisé pour appliquer un filigrane à toutes les diapositives de la présentation — le filigrane est ajouté au Slide Master, entièrement conçu là, et appliqué à toutes les diapositives sans affecter la permission de modifier le filigrane sur les diapositives individuelles.

Un filigrane est généralement considéré comme indisponible pour l'édition par d'autres utilisateurs. Pour empêcher que le filigrane (ou plutôt la forme parent du filigrane) soit modifié, Aspose.Slides propose une fonctionnalité de verrouillage des formes. Une forme spécifique peut être verrouillée sur une diapositive normale ou sur un Slide Master. Lorsque la forme du filigrane est verrouillée sur le Slide Master, elle sera verrouillée sur toutes les diapositives de la présentation.

Vous pouvez définir un nom pour le filigrane afin qu'à l'avenir, si vous souhaitez le supprimer, vous puissiez le trouver dans les formes de la diapositive par son nom.

Vous pouvez concevoir le filigrane de n'importe quelle manière ; cependant, il existe généralement des caractéristiques communes dans les filigranes, telles que l'alignement centré, la rotation, la position avant, etc. Nous allons examiner comment utiliser ces éléments dans les exemples ci-dessous.

## **Filigrane de Texte**

### **Ajouter un Filigrane de Texte à une Diapositive**

Pour ajouter un filigrane de texte dans PPT, PPTX ou ODP, vous pouvez d'abord ajouter une forme à la diapositive, puis ajouter un cadre de texte à cette forme. Le cadre de texte est représenté par la classe [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). Ce type n'est pas hérité de [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), qui possède un large éventail de propriétés pour positionner le filigrane de manière flexible. Par conséquent, l'objet [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) est encapsulé dans un objet [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Pour ajouter un texte de filigrane à la forme, utilisez la méthode [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) comme montré ci-dessous.

```py
watermark_text = "CONFIDENTIEL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser la classe TextFrame](/slides/fr/python-net/text-formatting/)
{{% /alert %}}

### **Ajouter un Filigrane de Texte à une Présentation**

Si vous souhaitez ajouter un filigrane de texte à l'ensemble de la présentation (c'est-à-dire à toutes les diapositives en même temps), ajoutez-le au [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/). Le reste de la logique est le même que pour ajouter un filigrane à une seule diapositive — créez un objet [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) puis ajoutez le filigrane en utilisant la méthode [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str).

```py
watermark_text = "CONFIDENTIEL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser le Slide Master](/slides/fr/python-net/slide-master/)
{{% /alert %}}

### **Définir la Transparence de la Forme du Filigrane**

Par défaut, la forme rectangulaire est stylisée avec des couleurs de remplissage et de ligne. Les lignes de code suivantes rendent la forme transparente.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Définir la Police pour un Filigrane de Texte**

Vous pouvez changer la police du filigrane de texte comme montré ci-dessous.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **Définir la Couleur du Texte du Filigrane**

Pour définir la couleur du texte du filigrane, utilisez ce code :

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **Centrer un Filigrane de Texte**

Il est possible de centrer le filigrane sur une diapositive, et pour cela, vous pouvez faire ce qui suit :

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

L'image ci-dessous montre le résultat final.

![Le filigrane de texte](text_watermark.png)

## **Filigrane d'Image**

### **Ajouter un Filigrane d'Image à une Présentation**

Pour ajouter un filigrane d'image à une diapositive de présentation, vous pouvez faire ce qui suit :

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Verrouiller un Filigrane pour Éviter son Édition**

S'il est nécessaire d'empêcher un filigrane d'être modifié, utilisez la propriété [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) sur la forme. Avec cette propriété, vous pouvez protéger la forme contre la sélection, le redimensionnement, le repositionnement, le regroupement avec d'autres éléments, verrouiller son texte contre l'édition, et bien plus encore :

```py
# Verrouiller la forme du filigrane pour modification
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Amener un Filigrane au Premier Plan**

Dans Aspose.Slides, l'ordre Z des formes peut être défini via la méthode [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). Pour cela, vous devez appeler cette méthode à partir de la liste des diapositives de la présentation et passer la référence de la forme et son numéro d'ordre dans la méthode. De cette manière, il est possible d'amener une forme au premier plan ou de l'envoyer à l'arrière de la diapositive. Cette fonctionnalité est particulièrement utile si vous devez placer un filigrane devant la présentation :

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Définir la Rotation du Filigrane**

Voici un exemple de code sur la façon d'ajuster la rotation du filigrane afin qu'il soit positionné en diagonale sur la diapositive :

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Définir un Nom pour un Filigrane**

Aspose.Slides vous permet de définir le nom d'une forme. En utilisant le nom de la forme, vous pouvez y accéder à l'avenir pour la modifier ou la supprimer. Pour définir le nom de la forme du filigrane, attribuez-le à la propriété [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) :

```py
watermark_shape.name = "watermark"
```

## **Supprimer un Filigrane**

Pour supprimer la forme du filigrane, utilisez la méthode [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) pour la trouver dans les formes de la diapositive. Ensuite, passez la forme de filigrane dans la méthode [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape) :

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Un Exemple en Direct**

Vous pouvez consulter les outils en ligne **gratuits d'Aspose.Slides** [Ajouter un Filigrane](https://products.aspose.app/slides/watermark) et [Supprimer un Filigrane](https://products.aspose.app/slides/watermark/remove-watermark).

![Outils en ligne pour ajouter et supprimer des filigranes](online_tools.png)