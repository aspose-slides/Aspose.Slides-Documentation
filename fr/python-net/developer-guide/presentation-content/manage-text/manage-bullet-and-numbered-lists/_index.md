---
title: Gérer les listes à puces et numérotées dans les présentations en Python
linktitle: Gérer les listes
type: docs
weight: 70
url: /fr/python-net/manage-bullet-and-numbered-lists/
keywords:
- puce
- liste à puces
- liste numérotée
- puce symbole
- puce image
- puce personnalisée
- liste à plusieurs niveaux
- créer une puce
- ajouter une puce
- ajouter une liste
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment gérer les listes à puces et numérotées dans les présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour Python via .NET. Guide étape par étape avec des exemples de code pour vous aider à démarrer rapidement."
---

## **Aperçu**

Gérer efficacement les listes à puces et les listes numérotées est important lors de la création de présentations percutantes. Avec Aspose.Slides for Python, vous pouvez automatiser facilement le formatage des listes dans vos diapositives de manière programmatique. Cet article vous guide à travers des exemples clairs sur la façon de créer, modifier et personnaliser les listes à puces et numérotées à l’aide de Python. Découvrez des méthodes simples mais puissantes pour contrôler l’indentation, le style, les schémas de numérotation et les puces, permettant à vos présentations d’avoir un aspect professionnel et cohérent à chaque fois.

**Pourquoi utiliser les listes à puces ?**

Les listes à puces vous aident à organiser et à présenter clairement l’information, améliorant la lisibilité et l’engagement. Typiquement, une liste à puces remplit trois fonctions clés :

- Met en évidence les informations importantes, captant immédiatement l’attention.
- Permet aux lecteurs de parcourir rapidement et d’identifier les points principaux.
- Communique efficacement les détails essentiels dans un format concis.

**Pourquoi utiliser les listes numérotées ?**

Les listes numérotées sont un autre outil précieux pour organiser et présenter clairement votre contenu. Elles sont particulièrement utiles lorsque la séquence ou la hiérarchie des éléments compte. Utilisez des listes numérotées au lieu de puces lorsque les étapes ou les éléments doivent suivre un ordre spécifique (par exemple, *Étape 1, Étape 2, Étape 3*, etc.), ou lorsque vous devez faire référence à des étapes particulières plus tard dans votre texte (comme, *se référer à l’Étape 3*). Cela rend vos instructions ou explications plus claires, plus faciles à suivre, et permet aux lecteurs de naviguer et de référencer votre contenu facilement.

## **Créer des puces de symbole**

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accéder à la diapositive (dans laquelle vous souhaitez ajouter la liste à puces) depuis la collection de diapositives en utilisant l’objet [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive sélectionnée.
1. Accéder au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forme ajoutée.
1. Supprimer le paragraphe par défaut dans le cadre de texte.
1. Créer le premier paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Définir le type de puce sur `SYMBOL` et définir le caractère de puce.
1. Définir le texte du paragraphe.
1. Définir l’indentation du paragraphe pour contrôler le placement de la puce.
1. Définir la couleur de la puce.
1. Définir la hauteur de la puce.
1. Ajouter le paragraphe créé à la collection de paragraphes du cadre de texte.
1. Ajouter un second paragraphe et répéter les étapes 7 à 12.
1. Enregistrer la présentation.

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

![Les puces de symbole](symbol_bullets.png)

## **Créer des puces d’image**

Aspose.Slides for Python via .NET vous permet de personnaliser les puces dans les listes à puces. Vous pouvez remplacer les puces standards par des symboles ou des images personnalisés. Si vous souhaitez ajouter un intérêt visuel à une liste ou attirer davantage l’attention sur des entrées spécifiques, vous pouvez utiliser votre propre image comme puce.

{{% alert color="primary" %}}
Idéalement, si vous prévoyez de remplacer le symbole de puce standard par une image, il est préférable de choisir un graphique simple avec un arrière‑plan transparent. De telles images fonctionnent bien comme symboles de puce personnalisés.

Gardez à l’esprit que l’image sera réduite à une taille très petite. Pour cette raison, nous recommandons fortement de choisir une image qui reste claire et visuellement efficace lorsqu’elle est utilisée comme puce dans une liste.
{{% /alert %}}

Pour créer une puce d’image, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accéder à la diapositive souhaitée depuis la collection de diapositives en utilisant l’objet [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive sélectionnée en utilisant la méthode `add_auto_shape`.
1. Accéder au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forme ajoutée.
1. Supprimer le paragraphe par défaut du cadre de texte.
1. Charger une image depuis le disque, l’ajouter à [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/images/) et obtenir l’instance [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) retournée par la méthode [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/#methods).
1. Créer la première instance de [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Définir le type de puce sur `PICTURE`, puis affecter l’image.
1. Définir le texte du paragraphe.
1. Définir l’indentation du paragraphe pour positionner la puce.
1. Définir la couleur de la puce.
1. Définir la hauteur de la puce.
1. Ajouter le paragraphe à la collection de paragraphes du cadre de texte.
1. Ajouter un second paragraphe et répéter les étapes 8 à 13.
1. Enregistrer la présentation.

Supposons que nous ayons un "image.png" :

![Une image pour les puces](picture_for_bullets.png)

Le code Python suivant montre comment créer des puces d’image dans une diapositive :
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

![Les puces d’image](picture_bullets.png)

## **Créer des listes à plusieurs niveaux**

Pour créer une liste à puces contenant des éléments à plusieurs niveaux (sous‑listes sous les puces principales), suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accéder à la diapositive souhaitée depuis la collection de diapositives en utilisant l’objet [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive sélectionnée en utilisant la méthode `add_auto_shape`.
1. Accéder au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forme ajoutée.
1. Supprimer le paragraphe par défaut du cadre de texte.
1. Créer la première instance de [Paragraph] et définir sa profondeur à 0 (niveau principal).
1. Créer le second paragraphe et définir sa profondeur à 1 (premier sous‑niveau).
1. Créer le troisième paragraphe et définir sa profondeur à 2 (deuxième sous‑niveau).
1. Créer le quatrième paragraphe et définir sa profondeur à 3 (troisième sous‑niveau).
1. Ajouter tous les paragraphes créés à la collection de paragraphes du cadre de texte.
1. Enregistrer la présentation.

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

## **Créer des puces numérotées**

Créer des listes numérotées claires et organisées est simple avec Aspose.Slides for Python. Les listes numérotées améliorent considérablement la lisibilité et aident à guider votre audience à travers des étapes ou des informations ordonnées de manière claire. Que vous prépariez des diapositives pédagogiques, documentiez des processus ou structuriez une présentation, les listes numérotées garantissent que votre message reste structuré et facile à suivre.

Aspose.Slides vous permet d’ajouter, de personnaliser et de mettre en forme des listes numérotées de façon programmatique. Vous pouvez spécifier différents styles de numérotation — par exemple numérique (1, 2, 3), alphabétique (A, B, C) ou chiffres romains (I, II, III) — pour correspondre au contexte ou au style souhaité de vos présentations.

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

## **FAQ**

**Les listes à puces et numérotées créées avec Aspose.Slides peuvent‑elles être exportées vers d’autres formats tels que PDF ou images ?**

Oui, Aspose.Slides conserve pleinement le formatage et la structure des listes à puces et numérotées lors de l’exportation des présentations vers des formats tels que PDF, images, et autres, garantissant des résultats cohérents.

**Est‑il possible d’importer des listes à puces ou numérotées à partir de présentations existantes ?**

Oui, Aspose.Slides permet d’importer et de modifier des listes à puces ou numérotées provenant de présentations existantes tout en préservant leur formatage et apparence d’origine.

**Aspose.Slides prend‑il en charge les listes à puces et numérotées dans des présentations créées en plusieurs langues ?**

Oui, Aspose.Slides prend pleinement en charge les présentations multilingues, vous permettant de créer des listes à puces et numérotées dans n’importe quelle langue, y compris l’utilisation de caractères spéciaux ou non latins.