---
title: Gérer les Paragraphes PowerPoint en Python
type: docs
weight: 40
url: /python-net/manage-paragraph/
keywords: "Ajouter un paragraphe PowerPoint, Gérer les paragraphes, Indentation de paragraphe, Propriétés de paragraphe, Texte HTML, Exporter le texte du paragraphe, Présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Créer et gérer des Paragraphes, du texte, de l'indentation et des propriétés dans des présentations PowerPoint en Python"
---

Aspose.Slides fournit toutes les interfaces et classes nécessaires pour travailler avec des textes PowerPoint, des paragraphes et des portions en Python.

* Aspose.Slides fournit l'interface [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) pour vous permettre d'ajouter des objets qui représentent un paragraphe. Un objet `ITextFame` peut contenir un ou plusieurs paragraphes (chaque paragraphe étant créé par un retour chariot).
* Aspose.Slides fournit l'interface [IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) pour vous permettre d'ajouter des objets qui représentent des portions. Un objet `IParagraph` peut avoir une ou plusieurs portions (collection d'objets iPortions).
* Aspose.Slides fournit l'interface [IPortion](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) pour vous permettre d'ajouter des objets qui représentent des textes et leurs propriétés de formatage. 

Un objet `IParagraph` est capable de gérer des textes avec différentes propriétés de formatage grâce à ses objets `IPortion` sous-jacents.

## **Ajouter Plusieurs Paragraphes Contenant Plusieurs Portions**

Ces étapes vous montrent comment ajouter un cadre de texte contenant 3 paragraphes, chacun contenant 3 portions :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée par son index.
3. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) rectangle à la diapositive.
4. Obtenez le ITextFrame associé à l'[IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).
5. Créez deux objets [IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) et ajoutez-les à la collection `IParagraphs` de l'[ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/).
6. Créez trois objets [IPortion](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) pour chaque nouveau `IParagraph` (deux objets Portion pour le paragraphe par défaut) et ajoutez chaque objet `IPortion` à la collection IPortion de chaque `IParagraph`.
7. Définissez un texte pour chaque portion.
8. Appliquez vos fonctionnalités de formatage préférées à chaque portion en utilisant les propriétés de formatage exposées par l'objet `IPortion`.
9. Enregistrez la présentation modifiée.

Ce code Python est une implémentation des étapes pour ajouter des paragraphes contenant des portions : 

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier une classe Presentation qui représente un fichier PPTX
with slides.Presentation() as pres:
    # Accéder à la première diapositive
    slide = pres.slides[0]

    # Ajouter une forme AutoShape de type Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Accéder au TextFrame de la forme AutoShape
    tf = ashp.text_frame

    # Créer des Paragraphes et des Portions avec différents formats de texte
    para0 = tf.paragraphs[0]
    port01 = slides.Portion()
    port02 = slides.Portion()
    para0.portions.add(port01)
    para0.portions.add(port02)

    para1 = slides.Paragraph()
    tf.paragraphs.add(para1)
    port10 = slides.Portion()
    port11 = slides.Portion()
    port12 = slides.Portion()
    para1.portions.add(port10)
    para1.portions.add(port11)
    para1.portions.add(port12)

    para2 = slides.Paragraph()
    tf.paragraphs.add(para2)
    port20 = slides.Portion()
    port21 = slides.Portion()
    port22 = slides.Portion()
    para2.portions.add(port20)
    para2.portions.add(port21)
    para2.portions.add(port22)

    for i in range(3):
        for j in range(3):
            tf.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                tf.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                tf.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                tf.paragraphs[i].portions[j].portion_format.font_bold = 1
                tf.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                tf.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                tf.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                tf.paragraphs[i].portions[j].portion_format.font_italic = 1
                tf.paragraphs[i].portions[j].portion_format.font_height = 18

    # Écrire le PPTX sur disque
    pres.save("multiParaPort_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Gérer les Puces de Paragraphe**

Les listes à puces vous aident à organiser et à présenter des informations rapidement et efficacement. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée par son index.
3. Ajoutez une [autoforme](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) à la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) de l'autoforme. 
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
7. Définissez le `Type` de puces pour le paragraphe sur `Symbol` et définissez le caractère de puce.
8. Définissez le `Text` du paragraphe.
9. Définissez l'`Indent` du paragraphe pour la puce.
10. Définissez une couleur pour la puce.
11. Définissez une hauteur de la puce.
12. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
13. Ajoutez le deuxième paragraphe et répétez le processus donné dans les étapes 7 à 13.
14. Enregistrez la présentation.

Ce code Python vous montre comment ajouter une puce de paragraphe : 

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Créer une instance de présentation
with slides.Presentation() as pres:
    # Accéder à la première diapositive
    slide = pres.slides[0]

    # Ajouter et accéder à l'AutoShape
    aShp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accéder au cadre de texte de l'autoforme créée
    txtFrm = aShp.text_frame

    # Supprimer le paragraphe par défaut existant
    txtFrm.paragraphs.remove_at(0)

    # Créer un paragraphe
    para = slides.Paragraph()

    # Définir le style et le symbole de puce du paragraphe
    para.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para.paragraph_format.bullet.char = chr(8226)

    # Définir le texte du paragraphe
    para.text = "Bienvenue dans Aspose.Slides"

    # Définir l'indentation de la puce
    para.paragraph_format.indent = 25

    # Définir la couleur de la puce
    para.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    para.paragraph_format.bullet.color.color = draw.Color.black
    para.paragraph_format.bullet.is_bullet_hard_color = 1 

    # Définir la hauteur de la puce
    para.paragraph_format.bullet.height = 100

    # Ajouter le paragraphe au cadre de texte
    txtFrm.paragraphs.add(para)

    # Créer le deuxième paragraphe
    para2 = slides.Paragraph()

    # Définir le type et le style de puce du paragraphe
    para2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    para2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # Ajouter le texte du paragraphe
    para2.text = "Ceci est une puce numérotée"

    # Définir l'indentation de la puce
    para2.paragraph_format.indent = 25

    para2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    para2.paragraph_format.bullet.color.color = draw.Color.black
    para2.paragraph_format.bullet.is_bullet_hard_color = 1

    # Définir la hauteur de la puce
    para2.paragraph_format.bullet.height = 100

    # Ajouter le paragraphe au cadre de texte
    txtFrm.paragraphs.add(para2)


    # Écrire la présentation sous forme de fichier PPTX
    pres.save("bullet_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Gérer les Puces Image**

Les listes à puces vous aident à organiser et à présenter des informations rapidement et efficacement. Les paragraphes d'images sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée par son index.
3. Ajoutez une [autoforme](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) de l'autoforme. 
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
7. Chargez l'image dans [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/).
8. Définissez le type de puce sur [Image](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) et définissez l'image.
9. Définissez le `Text` du paragraphe.
10. Définissez l'`Indent` du paragraphe pour la puce.
11. Définissez une couleur pour la puce.
12. Définissez une hauteur pour la puce.
13. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
14. Ajoutez le deuxième paragraphe et répétez le processus en fonction des étapes précédentes.
15. Enregistrez la présentation modifiée.

Ce code Python vous montre comment ajouter et gérer des puces image : 

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Accéder à la première diapositive
    slide = presentation.slides[0]

    # Instancier l'image pour les puces
    image = draw.Bitmap(path + "bullets.png")
    ippxImage = presentation.images.add_image(image)

    # Ajouter et accéder à l'AutoShape
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accéder au cadre de texte de l'autoforme créée
    textFrame = autoShape.text_frame

    # Supprimer le paragraphe par défaut existant
    textFrame.paragraphs.remove_at(0)

    # Créer un nouveau paragraphe
    paragraph = slides.Paragraph()
    paragraph.text = "Bienvenue dans Aspose.Slides"

    # Définir le style et l'image de la puce du paragraphe
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = ippxImage

    # Définir la hauteur de la puce
    paragraph.paragraph_format.bullet.height = 100

    # Ajouter le paragraphe au cadre de texte
    textFrame.paragraphs.add(paragraph)

    # Écrire la présentation sous forme de fichier PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", slides.export.SaveFormat.PPTX)
    # Écrire la présentation sous forme de fichier PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", slides.export.SaveFormat.PPT)
```


## **Gérer les Puces Multiniveau**

Les listes à puces vous aident à organiser et à présenter des informations rapidement et efficacement. Les puces multiniveau sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée par son index.
3. Ajoutez une [autoforme](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) dans la nouvelle diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) de l'autoforme. 
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) et définissez la profondeur à 0.
7. Créez la deuxième instance de paragraphe par la classe `Paragraph` et définissez la profondeur à 1.
8. Créez la troisième instance de paragraphe par la classe `Paragraph` et définissez la profondeur à 2.
9. Créez la quatrième instance de paragraphe par la classe `Paragraph` et définissez la profondeur à 3.
10. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
11. Enregistrez la présentation modifiée.

Ce code Python vous montre comment ajouter et gérer des puces multiniveau : 

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Créer une instance de présentation
with slides.Presentation() as pres:
    # Accéder à la première diapositive
    slide = pres.slides[0]
    
    # Ajouter et accéder à l'AutoShape
    aShp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accéder au cadre de texte de l'autoforme créée
    text = aShp.add_text_frame("")
    
    # Effacer le paragraphe par défaut
    text.paragraphs.clear()

    # Ajouter le premier paragraphe
    para1 = slides.Paragraph()
    para1.text = "Contenu"
    para1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para1.paragraph_format.bullet.char = chr(8226)
    para1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Définir le niveau de puce
    para1.paragraph_format.depth = 0

    # Ajouter le deuxième paragraphe
    para2 = slides.Paragraph()
    para2.text = "Deuxième Niveau"
    para2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para2.paragraph_format.bullet.char = '-'
    para2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Définir le niveau de puce
    para2.paragraph_format.depth = 1

    # Ajouter le troisième paragraphe
    para3 = slides.Paragraph()
    para3.text = "Troisième Niveau"
    para3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para3.paragraph_format.bullet.char = chr(8226)
    para3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Définir le niveau de puce
    para3.paragraph_format.depth = 2

    # Ajouter le quatrième paragraphe
    para4 = slides.Paragraph()
    para4.text = "Quatrième Niveau"
    para4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para4.paragraph_format.bullet.char = '-'
    para4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Définir le niveau de puce
    para4.paragraph_format.depth = 3

    # Ajouter les paragraphes à la collection
    text.paragraphs.add(para1)
    text.paragraphs.add(para2)
    text.paragraphs.add(para3)
    text.paragraphs.add(para4)

    # Écrire la présentation sous forme de fichier PPTX
    pres.save("MultilevelBullet.pptx", slides.export.SaveFormat.PPTX)
```


## **Gérer les Paragraphes avec Liste Numérotée Personnalisée**

L'interface [IBulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformat/#ibulletformat/) fournit la propriété `NumberedBulletStartWith` et d'autres qui vous permettent de gérer les paragraphes avec un numérotage ou un formatage personnalisé. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accédez à la diapositive contenant le paragraphe.
3. Ajoutez une [autoforme](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) de l'autoforme. 
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) et définissez `NumberedBulletStartWith` sur 2.
7. Créez la deuxième instance de paragraphe en utilisant la classe `Paragraph` et définissez `NumberedBulletStartWith` sur 3.
8. Créez la troisième instance de paragraphe en utilisant la classe `Paragraph` et définissez `NumberedBulletStartWith` sur 7.
9. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
10. Enregistrez la présentation modifiée.

Ce code Python vous montre comment ajouter et gérer des paragraphes avec une numérotation ou un formatage personnalisé : 

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accéder au cadre de texte de l'autoforme créée
    textFrame = shape.text_frame

    # Supprimer le paragraphe par défaut existant
    textFrame.paragraphs.remove_at(0)

    # Premier élément de liste
    paragraph1 = slides.Paragraph()
    paragraph1.text = "puce 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    textFrame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.text = "puce 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    textFrame.paragraphs.add(paragraph2)


    paragraph5 = slides.Paragraph()
    paragraph5.text = "puce 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    textFrame.paragraphs.add(paragraph5)

    presentation.save("SetCustomBulletsNumber-slides.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir l'Indentation de Paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accédez à la référence de la diapositive concernée par son index.
1. Ajoutez une [autoforme](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) rectangle à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) avec trois paragraphes à la rectangle autoforme.
1. Cachez les lignes du rectangle.
1. Définissez l'indentation pour chaque [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) à l'aide de leur propriété BulletOffset.
1. Écrivez la présentation modifiée sous forme de fichier PPT.

Ce code Python vous montre comment définir une indentation de paragraphe : 

```python
import aspose.slides as slides

# Instancier la classe Presentation
with slides.Presentation() as pres:

    # Obtenir la première diapositive
    sld = pres.slides[0]

    # Ajouter une forme de rectangle
    rect = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 150)

    # Ajouter un cadre de texte au rectangle
    tf = rect.add_text_frame("Ceci est la première ligne \rCeci est la deuxième ligne \rCeci est la troisième ligne")

    # Ajuster le texte pour qu'il s'adapte à la forme
    tf.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # Cacher les lignes du rectangle
    rect.line_format.fill_format.fill_type = slides.FillType.SOLID

    # Obtenir le premier paragraphe dans le TextFrame et définir son indentation
    para1 = tf.paragraphs[0]
    # Définir le style et le symbole de puce du paragraphe
    para1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para1.paragraph_format.bullet.char = chr(8226)
    para1.paragraph_format.alignment = slides.TextAlignment.LEFT

    para1.paragraph_format.depth = 2
    para1.paragraph_format.indent = 30

    # Obtenir le deuxième paragraphe dans le TextFrame et définir son indentation
    para2 = tf.paragraphs[1]
    para2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para2.paragraph_format.bullet.char = chr(8226)
    para2.paragraph_format.alignment = slides.TextAlignment.LEFT
    para2.paragraph_format.depth = 2
    para2.paragraph_format.indent = 40

    # Obtenir le troisième paragraphe dans le TextFrame et définir son indentation
    para3 = tf.paragraphs[2]
    para3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para3.paragraph_format.bullet.char = chr(8226)
    para3.paragraph_format.alignment = slides.TextAlignment.LEFT
    para3.paragraph_format.depth = 2
    para3.paragraph_format.indent = 50

    # Écrire la Présentation sur disque
    pres.save("InOutDent_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir l'Indentation Suspendue pour le Paragraphe**

Ce code Python vous montre comment définir l'indentation suspendue pour un paragraphe :

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    auto_shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 550, 150)

    para1 = slides.Paragraph()
    para1.text = "Exemple"
    para2 = slides.Paragraph()
    para2.text = "Définir l'indentation suspendue pour le paragraphe"
    para3 = slides.Paragraph()
    para3.text = "Ce code C# vous montre comment définir l'indentation suspendue pour un paragraphe : "

    para2.paragraph_format.margin_left = 10
    para3.paragraph_format.margin_left = 20

    paragraphs = auto_shape.text_frame.paragraphs
    paragraphs.add(para1)
    paragraphs.add(para2)
    paragraphs.add(para3)

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Gérer les Propriétés de Fin de Portion pour le Paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Obtenez la référence de la diapositive contenant le paragraphe par sa position.
1. Ajoutez une [autoforme](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) avec deux paragraphes à la forme Rectangle.
1. Définissez `FontHeight` et le type de police pour les paragraphes.
1. Définissez les propriétés de fin pour les paragraphes.
1. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Python vous montre comment définir les propriétés de fin pour les paragraphes dans PowerPoint : 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
	shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	para1 = slides.Paragraph()
	para1.portions.add(slides.Portion("Texte d'exemple"))

	para2 = slides.Paragraph()
	para2.portions.add(slides.Portion("Texte d'exemple 2"))
	endParagraphPortionFormat = slides.PortionFormat()
	endParagraphPortionFormat.font_height = 48
	endParagraphPortionFormat.latin_font = slides.FontData("Times New Roman")
	para2.end_paragraph_portion_format = endParagraphPortionFormat

	shape.text_frame.paragraphs.add(para1)
	shape.text_frame.paragraphs.add(para2)

	pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```


## **Importer du Texte HTML dans des Paragraphes**

Aspose.Slides offre un support amélioré pour importer du texte HTML dans des paragraphes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée par son index.
3. Ajoutez une [autoforme](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) à la diapositive.
4. Ajoutez et accédez à l'[ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) de l'autoforme.
5. Supprimez le paragraphe par défaut dans le `ITextFrame`.
6. Lisez le fichier HTML source dans un TextReader.
7. Créez la première instance de paragraphe à travers la classe [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
8. Ajoutez le contenu du fichier HTML dans le TextReader lu à la [ParagraphCollection](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/) du TextFrame.
9. Enregistrez la présentation modifiée.

Ce code Python est une implémentation des étapes pour importer des textes HTML dans des paragraphes : 

```python
import aspose.slides as slides

# Créer une instance de présentation vide
with slides.Presentation() as pres:
    # Accéder à la première diapositive par défaut de la présentation
    slide = pres.slides[0]

    # Ajouter l'AutoShape pour accueillir le contenu HTML
    ashape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, pres.slide_size.size.width - 20, pres.slide_size.size.height - 10)

    ashape.fill_format.fill_type = slides.FillType.NO_FILL

    # Ajouter un cadre de texte à la forme
    ashape.add_text_frame("")

    # Effacer tous les paragraphes dans le cadre de texte ajouté
    ashape.text_frame.paragraphs.clear()

    # Charger le fichier HTML à l'aide d'un lecteur de flux
    with open(path + "file.html", "rt") as tr:
        # Ajouter le texte du lecteur de flux HTML dans le cadre de texte
        ashape.text_frame.paragraphs.add_from_html(tr.read())

    # Enregistrer la présentation
    pres.save("output_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Exporter le Texte des Paragraphes vers HTML**

Aspose.Slides offre un support amélioré pour exporter les textes (contenus dans des paragraphes) vers HTML.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation souhaitée.
2. Accédez à la référence de la diapositive concernée par son index.
3. Accédez à la forme contenant le texte qui sera exporté vers HTML.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forme.
5. Créez une instance de `StreamWriter` et ajoutez le nouveau fichier HTML.
6. Fournissez un index de départ au StreamWriter et exportez vos paragraphes préférés.

Ce code Python vous montre comment exporter les textes des paragraphes PowerPoint en HTML :

```python
import aspose.slides as slides

# Charger le fichier de présentation
with slides.Presentation(path + "ExportingHTMLText.pptx") as pres:
    # Accéder à la première diapositive par défaut de la présentation
    slide = pres.slides[0]

    # Index souhaité
    index = 0

    # Accéder à la forme ajoutée
    ashape = slide.shapes[index]

    with open("output_out.html", "w") as sw:
        # Écrire les données des paragraphes en HTML en fournissant l'index de départ du paragraphe, le nombre total de paragraphes à copier
        sw.write(ashape.text_frame.paragraphs.export_to_html(0, ashape.text_frame.paragraphs.count, None))
```