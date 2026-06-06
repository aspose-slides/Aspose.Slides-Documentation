---
title: Gérer les listes à puces et numérotées dans les présentations en Python
linktitle: Gérer les listes
type: docs
weight: 70
url: /fr/python-net/manage-lists/
keywords:
- puce
- liste à puces
- liste numérotée
- puce symbole
- puce image
- puce personnalisée
- liste à plusieurs niveaux
- créer puce
- ajouter puce
- ajouter liste
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à créer et mettre en forme des listes à puces, des listes image, des listes à plusieurs niveaux et des listes numérotées dans les présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour Python via .NET."
---
## **Aperçu**

Aspose.Slides pour Python via .NET vous permet de créer et de mettre en forme des listes à puces et numérotées dans les présentations PowerPoint et OpenDocument. Un élément de liste est un paragraphe dont les paramètres de puce sont contrôlés via son format de paragraphe.

Utilisez la propriété [Paragraph.paragraph_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/paragraph_format/) pour accéder aux paramètres de liste au niveau du paragraphe. Le point d’entrée principal est [ParagraphFormat.bullet](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/bullet/), qui renvoie un objet [BulletFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bulletformat/). Avec cet objet, vous pouvez définir le type de puce, le symbole, l’image, la couleur, la taille, le style de numérotation et le numéro de départ.

Cet article montre comment :

- créer une liste à puces avec un symbole personnalisé
- créer une puce image
- créer une liste à plusieurs niveaux en définissant la profondeur du paragraphe
- créer une liste numérotée
- examiner et modifier le formatage des listes dans une présentation existante

## **Créer une liste à puces**

Pour créer une liste à puces, ajoutez des objets [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/) à un [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) et définissez [BulletFormat.type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bulletformat/type/) sur [BulletType.SYMBOL](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bullettype/). Vous pouvez ensuite définir [BulletFormat.char](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bulletformat/color/) et [BulletFormat.height](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bulletformat/height/) pour contrôler l’apparence de la puce.

Le code Python suivant montre comment créer une liste à puces dans une diapositive :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Les puces symboliques](symbol_bullets.png)

## **Créer une liste numérotée**

Utilisez les listes numérotées lorsque l’ordre des éléments est important. Définissez [BulletFormat.type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bulletformat/type/) sur [BulletType.NUMBERED](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bullettype/). Vous pouvez également choisir un format de numérotation avec [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bulletformat/numbered_bullet_style/) ou définir [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) lorsque la liste doit commencer à une valeur différente de 1.

Le code Python suivant montre comment créer une liste numérotée dans une diapositive :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Les puces numérotées](numbered_bullets.png)

## **Créer une puce image**

Aspose.Slides vous permet de remplacer un symbole de puce standard par une image. Les puces image fonctionnent mieux avec des images simples qui restent lisibles à petite taille, comme des icônes ou de petits fichiers PNG transparents.

 {{% alert color="primary" %}}
Idéalement, si vous prévoyez de remplacer le symbole de puce standard par une image, il est préférable de choisir un graphisme simple avec un fond transparent. De telles images fonctionnent bien comme symboles de puce personnalisés.
{{% /alert %}}

Pour créer une puce image, ajoutez une image à [Presentation.images](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/images/) et affectez l’objet image retourné à [BulletFormat.picture](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bulletformat/picture/). Définissez [BulletFormat.type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bulletformat/type/) sur [BulletType.PICTURE](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bullettype/) avant d’assigner l’image.

Supposons que nous disposions d’un « image.png » :

![Une image pour les puces](picture_for_bullets.png)

Le code Python suivant montre comment créer des puces image dans une diapositive :

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Les puces image](picture_bullets.png)

## **Créer une liste à plusieurs niveaux**

Utilisez [ParagraphFormat.depth](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/depth/) pour placer les éléments de liste à différents niveaux. Le niveau 0 est le niveau supérieur, le niveau 1 est imbriqué en dessous, etc.

Le code Python suivant montre comment créer une liste à puces à plusieurs niveaux :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![La liste à plusieurs niveaux](multilevel_list.png)

## **Modifier une liste existante**

Pour modifier le formatage d’une liste dans une présentation existante, accédez au paragraphe ciblé et mettez à jour ses paramètres [ParagraphFormat.bullet](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/bullet/). Les mêmes propriétés utilisées pour créer des listes peuvent être utilisées pour inspecter ou modifier des listes chargées depuis un fichier PPT, PPTX ou ODP.

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Les listes à puces et numérotées peuvent‑elles être exportées vers PDF ou images ?**

Oui. Aspose.Slides préserve le formatage des listes lorsque le format cible prend en charge la mise en page du texte et les fonctionnalités de puces correspondantes.

**Puis‑je modifier des listes dans des présentations existantes ?**

Oui. Chargez la présentation, accédez au paragraphe ciblé, inspectez ou mettez à jour ses paramètres [ParagraphFormat.bullet](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/bullet/), puis enregistrez la présentation.

**Les listes peuvent‑elles contenir du texte non latin ?**

Oui. Le texte d’un élément de liste peut contenir des caractères Unicode, vous pouvez donc créer des listes dans des présentations multilingues. Assurez‑vous que les polices utilisées dans la présentation prennent en charge les caractères requis.