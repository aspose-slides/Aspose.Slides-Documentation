---
title: Gérer les paragraphes de texte PowerPoint en Python
linktitle: Gérer le paragraphe
type: docs
weight: 40
url: /fr/python-net/manage-paragraph/
keywords:
- ajouter du texte
- ajouter un paragraphe
- gérer le texte
- gérer le paragraphe
- gérer les puces
- retrait de paragraphe
- retrait suspendu
- puce de paragraphe
- liste numérotée
- liste à puces
- propriétés du paragraphe
- importer HTML
- texte vers HTML
- paragraphe vers HTML
- paragraphe vers image
- texte vers image
- exporter le paragraphe
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Maîtrisez le formatage des paragraphes avec Aspose.Slides pour Python via .NET—optimisez l'alignement, l'espacement et le style dans les présentations PowerPoint et OpenDocument en Python pour captiver le public."
---

## **Vue d'ensemble**

Aspose.Slides fournit les classes dont vous avez besoin pour travailler avec le texte PowerPoint en Python.

* Aspose.Slides fournit la classe [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) pour créer des objets de zone de texte. Un objet `TextFrame` peut contenir un ou plusieurs paragraphes (chaque paragraphe est séparé par un retour chariot).
* Aspose.Slides fournit la classe [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) pour créer des objets paragraphe. Un objet `Paragraph` peut contenir un ou plusieurs morceaux de texte.
* Aspose.Slides fournit la classe [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) pour créer des objets morceau de texte et spécifier leurs propriétés de mise en forme.

Un objet `Paragraph` peut gérer du texte avec différentes propriétés de mise en forme grâce à ses objets `Portion` sous-jacents.

## **Ajouter plusieurs paragraphes contenant plusieurs portions**

Ces étapes montrent comment ajouter une zone de texte contenant trois paragraphes, chacun avec trois portions :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à la diapositive cible par son indice.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) rectangulaire à la diapositive.
1. Récupérez le [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) associé à la [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Créez deux objets [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) et ajoutez-les à la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) (avec le paragraphe par défaut, cela donne trois paragraphes).
1. Pour chaque paragraphe, créez trois objets [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) et ajoutez-les à la collection de portions de ce paragraphe.
1. Définissez le texte pour chaque portion.
1. Appliquez la mise en forme souhaitée à chaque portion de texte en utilisant les propriétés exposées par [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/).
1. Enregistrez la présentation modifiée.

Le code Python suivant implémente ces étapes :
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation pour créer un nouveau fichier PPTX.
with slides.Presentation() as presentation:

    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    # Ajouter une AutoShape rectangulaire.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Accéder au TextFrame de l'AutoShape.
    text_frame = shape.text_frame

    # Créer des paragraphes et des portions ; la mise en forme est appliquée ci-dessous.
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # Enregistrer le PPTX sur le disque.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Gérer les puces de paragraphe**

Les listes à puces vous aident à organiser et présenter les informations rapidement et efficacement. Les paragraphes à puces sont souvent plus faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accédez à la diapositive cible par son indice.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive.
1. Accédez au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forme.
1. Supprimez le paragraphe par défaut du [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Créez le premier paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Définissez le type de puce du paragraphe sur `SYMBOL` et spécifiez le caractère de puce.
1. Définissez le texte du paragraphe.
1. Définissez le retrait de puce pour le paragraphe.
1. Définissez la couleur de la puce.
1. Définissez la taille de la puce (hauteur).
1. Ajoutez le paragraphe à la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) .
1. Enregistrez la présentation.

Ce code Python montre comment ajouter des paragraphes à puces :
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Créer une instance de présentation.
with slides.Presentation() as presentation:

    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    # Ajouter et accéder à une AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accéder au cadre de texte de l'AutoShape créée.
    text_frame = shape.text_frame

    # Supprimer le paragraphe par défaut.
    text_frame.paragraphs.remove_at(0)

    # Créer un paragraphe.
    paragraph = slides.Paragraph()

    # Définir le style et le symbole de puce du paragraphe.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # Définir le texte du paragraphe.
    paragraph.text = "Welcome to Aspose.Slides"

    # Définir le retrait de la puce.
    paragraph.paragraph_format.indent = 25

    # Définir la couleur de la puce.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # Définir la hauteur de la puce.
    paragraph.paragraph_format.bullet.height = 100

    # Ajouter le paragraphe au cadre de texte.
    text_frame.paragraphs.add(paragraph)

    # Créer le deuxième paragraphe.
    paragraph2 = slides.Paragraph()

    # Définir le type et le style de puce du paragraphe.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # Définir le texte du paragraphe.
    paragraph2.text = "This is numbered bullet"

    # Définir le retrait de la puce.
    paragraph2.paragraph_format.indent = 25

    # Définir la couleur de la puce.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # Définir la hauteur de la puce.
    paragraph2.paragraph_format.bullet.height = 100

    # Ajouter le paragraphe au cadre de texte.
    text_frame.paragraphs.add(paragraph2)

    # Enregistrer la présentation en fichier PPTX.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Gérer les puces d’image**

Les listes à puces vous aident à organiser et présenter les informations rapidement et efficacement. Les puces d’image sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accédez à la diapositive cible par son indice.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive.
1. Accédez au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forme.
1. Supprimez le paragraphe par défaut du [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Créez le premier paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Chargez une image dans un [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).
1. Définissez le type de puce sur [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) et assignez l’image.
1. Définissez le texte du paragraphe.
1. Définissez le retrait du paragraphe pour la puce.
1. Définissez la couleur de la puce.
1. Définissez la hauteur de la puce.
1. Ajoutez le nouveau paragraphe à la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) .
1. Ajoutez un deuxième paragraphe et répétez les étapes 8 à 12.
1. Enregistrez la présentation.

Ce code Python montre comment ajouter et gérer les puces d’image :
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    # Charger l'image de puce.
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # Ajouter et accéder à une AutoShape.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accéder au TextFrame de l'AutoShape créée.
    text_frame = auto_shape.text_frame

    # Supprimer le paragraphe par défaut.
    text_frame.paragraphs.remove_at(0)

    # Créer un nouveau paragraphe.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # Définir le type de puce du paragraphe sur Image et assigner l'image.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # Définir la hauteur de la puce.
    paragraph.paragraph_format.bullet.height = 100

    # Ajouter le paragraphe au cadre de texte.
    text_frame.paragraphs.add(paragraph)

    # Enregistrer la présentation en fichier PPTX.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # Enregistrer la présentation en fichier PPT.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```


## **Gérer les puces multiniveaux**

Les listes à puces vous aident à organiser et présenter les informations rapidement et efficacement. Les puces multiniveaux sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accédez à la diapositive cible par son indice.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive.
1. Accédez au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de l’[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Supprimez le paragraphe par défaut du [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Créez le premier paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) et définissez sa profondeur à 0.
1. Créez le deuxième paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) et définissez sa profondeur à 1.
1. Créez le troisième paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) et définissez sa profondeur à 2.
1. Créez le quatrième paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) et définissez sa profondeur à 3.
1. Ajoutez les nouveaux paragraphes à la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) .
1. Enregistrez la présentation.

Le code Python suivant montre comment ajouter et gérer les puces multiniveaux :
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Créer une instance de présentation.
with slides.Presentation() as presentation:

    # Accéder à la première diapositive.
    slide = presentation.slides[0]
    
    # Ajouter une AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accéder au TextFrame de l'AutoShape créée.
    text_frame = auto_shape.text_frame
    
    # Supprimer le paragraphe par défaut.
    text_frame.paragraphs.clear()

    # Ajouter le premier paragraphe.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Définir le niveau de puce.
    paragraph1.paragraph_format.depth = 0

    # Ajouter le deuxième paragraphe.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Définir le niveau de puce.
    paragraph2.paragraph_format.depth = 1

    # Ajouter le troisième paragraphe.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Définir le niveau de puce.
    paragraph3.paragraph_format.depth = 2

    # Ajouter le quatrième paragraphe.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Définir le niveau de puce.
    paragraph4.paragraph_format.depth = 3

    # Ajouter les paragraphes à la collection.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # Enregistrer la présentation en fichier PPTX.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Gérer les paragraphes avec des listes numérotées personnalisées**

La classe [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) fournit la propriété `numbered_bullet_start_with` (et d’autres) pour contrôler la numérotation et la mise en forme personnalisées des paragraphes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accédez à la diapositive qui contiendra les paragraphes.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive.
1. Accédez au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forme.
1. Supprimez le paragraphe par défaut du [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Créez le premier [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) et définissez `numbered_bullet_start_with` à 2.
1. Créez le deuxième [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) et définissez `numbered_bullet_start_with` à 3.
1. Créez le troisième [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) et définissez `numbered_bullet_start_with` à 7.
1. Ajoutez les paragraphes à la collection du [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) .
1. Enregistrez la présentation.

Le code Python suivant montre comment ajouter et gérer des paragraphes avec une numérotation et une mise en forme personnalisées.
```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Ajouter et accéder à une AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accéder au TextFrame de l'AutoShape créée.
    text_frame = shape.text_frame

    # Supprimer le paragraphe existant par défaut.
    text_frame.paragraphs.remove_at(0)

    # Créer le premier élément numéroté (début à 2, niveau de profondeur 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # Créer le deuxième élément numéroté (début à 3, niveau de profondeur 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # Créer le troisième élément numéroté (début à 7, niveau de profondeur 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir le retrait de paragraphe**

Le retrait des paragraphes aide à établir une hiérarchie de lecture claire sur une diapositive et à affiner l’alignement du texte. L’exemple ci‑dessous montre comment définir à la fois le retrait global et le retrait de première ligne dans Aspose.Slides pour Python via les propriétés de [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/).

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accédez à la diapositive cible par son indice.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) rectangulaire à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) avec trois paragraphes à l’[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Masquez le contour du rectangle.
1. Définissez le retrait de chaque [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) en utilisant sa propriété `paragraph_format`.
1. Enregistrez la présentation modifiée au format PPT.

Le code Python suivant montre comment définir les retraits de paragraphes :
```python
import aspose.slides as slides

# Instancier la classe Presentation.
with slides.Presentation() as presentation:

    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    # Ajouter une forme rectangulaire.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 150)

    # Ajouter un TextFrame au rectangle.
    text_frame = shape.add_text_frame("This is first line \rThis is second line \rThis is third line")

    # Ajuster le texte pour qu'il s'adapte à la forme.
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # Définir un contour solide pour le rectangle.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    # Obtenir le premier paragraphe du TextFrame et définir sa puce et son retrait.
    paragraph1 = text_frame.paragraphs[0]
    # Définir le style de puce du paragraphe et son symbole.
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.alignment = slides.TextAlignment.LEFT

    paragraph1.paragraph_format.depth = 2
    paragraph1.paragraph_format.indent = 30

    # Obtenir le deuxième paragraphe du TextFrame et définir sa puce et son retrait.
    paragraph2 = text_frame.paragraphs[1]
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = chr(8226)
    paragraph2.paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph2.paragraph_format.depth = 2
    paragraph2.paragraph_format.indent = 40

    # Obtenir le troisième paragraphe du TextFrame et définir sa puce et son retrait.
    paragraph3 = text_frame.paragraphs[2]
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph3.paragraph_format.depth = 2
    paragraph3.paragraph_format.indent = 50

    # Écrire la présentation sur le disque.
    presentation.save("indent_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir le retrait suspendu pour les paragraphes**

Ce code Python montre comment définir un retrait suspendu pour un paragraphe :
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 550, 150)

    paragraph1 = slides.Paragraph()
    paragraph1.text = "Example"
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Set Hanging Indent for Paragraphs"
    paragraph3 = slides.Paragraph()
    paragraph3.text = "This Python code shows how to set a hanging indent for a paragraph: "

    paragraph2.paragraph_format.margin_left = 10
    paragraph3.paragraph_format.margin_left = 20

    paragraphs = auto_shape.text_frame.paragraphs
    paragraphs.add(paragraph1)
    paragraphs.add(paragraph2)
    paragraphs.add(paragraph3)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **Gérer le format de la portion de fin de paragraphe**

Lorsque vous devez contrôler le style de la « fin » d’un paragraphe (la mise en forme appliquée après la dernière portion de texte), utilisez la propriété `end_paragraph_portion_format`. L’exemple ci‑dessus applique une police Times New Roman plus grande à la fin du deuxième paragraphe.

1. Créez ou ouvrez un fichier [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez la diapositive cible par indice.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) rectangulaire à la diapositive.
1. Utilisez le [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forme et créez deux paragraphes.
1. Créez un [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) réglé sur Times New Roman 48 pt et appliquez‑le comme format de portion de fin de paragraphe du paragraphe.
1. Assignez‑le à `end_paragraph_portion_format` du paragraphe (s’applique à la fin du deuxième paragraphe).
1. Enregistrez la présentation modifiée au format PPTX.

Ce code Python vous montre comment définir le format de fin de paragraphe pour le deuxième paragraphe :
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **Importer du texte HTML dans des paragraphes**

Aspose.Slides offre une prise en charge améliorée pour l’importation de texte HTML dans des paragraphes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accédez à la diapositive cible par son indice.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive.
1. Accédez au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de l’[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Supprimez le paragraphe par défaut du [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Lisez le fichier HTML source.
1. Créez le premier paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Ajoutez le contenu HTML à la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) .
1. Enregistrez la présentation modifiée.

Le code Python suivant implémente ces étapes pour importer du texte HTML dans des paragraphes.
```python
import aspose.slides as slides

# Créer une instance vide de Presentation.
with slides.Presentation() as presentation:

    # Accéder à la première diapositive de la présentation.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # Ajouter une AutoShape pour accueillir le contenu HTML.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # Effacer tous les paragraphes du TextFrame ajouté.
    shape.text_frame.paragraphs.clear()

    # Charger le fichier HTML.
    with open("file.html", "rt") as html_stream:
        # Ajouter le texte du fichier HTML au TextFrame.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # Enregistrer la présentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Exporter le texte d’un paragraphe vers HTML**

Aspose.Slides offre une prise en charge améliorée pour l’exportation de texte vers HTML.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation cible.
1. Accédez à la diapositive souhaitée par son indice.
1. Sélectionnez la forme contenant le texte à exporter.
1. Accédez au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forme.
1. Ouvrez un flux de fichier pour écrire la sortie HTML.
1. Spécifiez l’indice de départ et exportez les paragraphes requis.

Cet exemple Python montre comment exporter le texte d’un paragraphe vers HTML.
```python
import aspose.slides as slides

# Charger le fichier de présentation.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # Accéder à la première diapositive de la présentation.
    slide = presentation.slides[0]

    # Index de la forme cible.
    index = 0

    # Accéder à la forme par son index.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Écrire les données des paragraphes en HTML en fournissant l'index du paragraphe de départ et le nombre total de paragraphes à exporter.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```


## **Enregistrer un paragraphe sous forme d’image**

Dans cette section, nous explorerons deux exemples montrant comment enregistrer un paragraphe de texte, représenté par la classe [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/), sous forme d’image. Les deux exemples comprennent l’obtention de l’image d’une forme contenant le paragraphe à l’aide des méthodes `get_image` de la classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), le calcul des limites du paragraphe au sein de la forme, et son exportation en tant qu’image bitmap. Ces approches permettent d’extraire des parties spécifiques du texte des présentations PowerPoint et de les enregistrer en images séparées, ce qui peut être utile pour diverses utilisations ultérieures.

Supposons que nous disposions d’un fichier de présentation nommé sample.pptx contenant une diapositive, où la première forme est une zone de texte contenant trois paragraphes.

![La zone de texte avec trois paragraphes](paragraph_to_image_input.png)

**Exemple 1**

Dans cet exemple, nous obtenons le deuxième paragraphe sous forme d’image. Pour ce faire, nous extrayons l’image de la forme de la première diapositive de la présentation, puis calculons les limites du deuxième paragraphe dans le texte de la forme. Le paragraphe est ensuite redessiné sur une nouvelle image bitmap, qui est enregistrée au format PNG. Cette méthode est particulièrement utile lorsque vous devez enregistrer un paragraphe spécifique en tant qu’image séparée tout en conservant les dimensions et la mise en forme exactes du texte.
```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Enregistrer la forme en mémoire sous forme de bitmap.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Créer un bitmap de forme à partir de la mémoire.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Calculer les limites du deuxième paragraphe.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # Calculer les coordonnées et la taille de l'image de sortie (taille minimale - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Rogner le bitmap de la forme pour obtenir uniquement le bitmap du paragraphe.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```


Le résultat :
![L’image du paragraphe](paragraph_to_image_output.png)

**Exemple 2**

Dans cet exemple, nous étendons l’approche précédente en ajoutant des facteurs d’échelle à l’image du paragraphe. La forme est extraite de la présentation et enregistrée en tant qu’image avec un facteur d’échelle de `2`. Cela permet d’obtenir une sortie à plus haute résolution lors de l’exportation du paragraphe. Les limites du paragraphe sont ensuite calculées en tenant compte de l’échelle. Le redimensionnement peut être particulièrement utile lorsqu’une image plus détaillée est nécessaire, par exemple pour une utilisation dans des supports imprimés de haute qualité.
```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Enregistrer la forme en mémoire sous forme de bitmap.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Créer un bitmap de forme à partir de la mémoire.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Calculer les limites du deuxième paragraphe.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # Calculer les coordonnées et la taille de l'image de sortie (taille minimale - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Rogner le bitmap de la forme pour obtenir uniquement le bitmap du paragraphe.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```


## **FAQ**

**Puis-je désactiver complètement le retour à la ligne à l’intérieur d’une zone de texte ?**

Oui. Utilisez le paramètre d’enroulement de la zone de texte ([wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)) pour désactiver l’enroulement afin que les lignes ne se coupent pas aux bords de la zone.

**Comment obtenir les limites exactes d’un paragraphe spécifique sur la diapositive ?**

Vous pouvez récupérer le rectangle englobant du paragraphe (et même d’une seule portion) pour connaître sa position et sa taille précises sur la diapositive.

**Où le alignement des paragraphes (gauche/droite/centré/justifié) est‑il contrôlé ?**

[Alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) est un paramètre au niveau du paragraphe dans [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) ; il s’applique à l’ensemble du paragraphe indépendamment de la mise en forme des portions individuelles.

**Puis-je définir une langue de vérification orthographique pour une partie seulement d’un paragraphe (par ex., un mot) ?**

Oui. La langue est définie au niveau de la portion ([PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/)), de sorte que plusieurs langues peuvent coexister au sein d’un même paragraphe.