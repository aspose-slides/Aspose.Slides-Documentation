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
- importer du HTML
- texte vers HTML
- paragraphe vers HTML
- paragraphe en image
- texte en image
- exporter le paragraphe
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Maîtrisez le formatage des paragraphes avec Aspose.Slides pour Python via .NET — optimisez l'alignement, l'espacement et le style dans les présentations PowerPoint et OpenDocument en Python pour captiver votre public."
---
## **Vue d'ensemble**

Aspose.Slides fournit les classes dont vous avez besoin pour travailler avec du texte PowerPoint en Python.

* Aspose.Slides fournit la classe [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) pour créer des objets de cadre de texte. Un objet `TextFrame` peut contenir un ou plusieurs paragraphes (chaque paragraphe est séparé par un retour chariot).
* Aspose.Slides fournit la classe [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/) pour créer des objets de paragraphe. Un objet `Paragraph` peut contenir un ou plusieurs fragments de texte.
* Aspose.Slides fournit la classe [Portion](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/) pour créer des objets de fragment de texte et spécifier leurs propriétés de mise en forme.

Un objet `Paragraph` peut gérer du texte avec différentes propriétés de mise en forme grâce à ses objets `Portion` sous-jacents.

## **Ajouter plusieurs paragraphes contenant plusieurs fragments**

Ces étapes montrent comment ajouter un cadre de texte contenant trois paragraphes, chacun avec trois fragments :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Obtenez une référence à la diapositive cible par son index.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) rectangulaire à la diapositive.
1. Récupérez le [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) associé à la [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/).
1. Créez deux objets [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/) et ajoutez-les à la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) (avec le paragraphe par défaut, cela donne trois paragraphes).
1. Pour chaque paragraphe, créez trois objets [Portion](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/) et ajoutez-les à la collection de fragments de ce paragraphe.
1. Définissez le texte pour chaque fragment.
1. Appliquez la mise en forme souhaitée à chaque fragment de texte en utilisant les propriétés exposées par [Portion](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/).
1. Enregistrez la présentation modifiée.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancie la classe Presentation pour créer un nouveau fichier PPTX.
with slides.Presentation() as presentation:

    # Accède à la première diapositive.
    slide = presentation.slides[0]

    # Ajoute une AutoShape rectangulaire.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Accède au TextFrame de l'AutoShape.
    text_frame = shape.text_frame

    # Crée des paragraphes et des portions ; la mise en forme est appliquée ci-dessous.
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

    # Enregistre le PPTX sur le disque.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Gérer les puces de paragraphe**

Les listes à puces vous aident à organiser et présenter les informations rapidement et efficacement. Les paragraphes à puces sont souvent plus faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Accédez à la diapositive cible par son index.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) à la diapositive.
1. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) de la forme.
1. Supprimez le paragraphe par défaut du [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/).
1. Créez le premier paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/).
1. Définissez le type de puce du paragraphe sur `SYMBOL` et spécifiez le caractère de la puce.
1. Définissez le texte du paragraphe.
1. Définissez le retrait de la puce pour le paragraphe.
1. Définissez la couleur de la puce.
1. Définissez la taille de la puce (hauteur).
1. Ajoutez le paragraphe à la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/).
1. Ajoutez un deuxième paragraphe et répétez les étapes 7 à 12.
1. Enregistrez la présentation.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

    # Créez une instance de présentation.
    with slides.Presentation() as presentation:

        # Accédez à la première diapositive.
        slide = presentation.slides[0]

        # Ajoutez et accédez à une AutoShape.
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

        # Accédez au cadre de texte de l'AutoShape créée.
        text_frame = shape.text_frame

        # Supprimez le paragraphe par défaut.
        text_frame.paragraphs.remove_at(0)

        # Créez un paragraphe.
        paragraph = slides.Paragraph()

        # Définissez le style de puce et le symbole du paragraphe.
        paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
        paragraph.paragraph_format.bullet.char = chr(8226)

        # Définissez le texte du paragraphe.
        paragraph.text = "Welcome to Aspose.Slides"

        # Définissez le retrait de la puce.
        paragraph.paragraph_format.indent = 25

        # Définissez la couleur de la puce.
        paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
        paragraph.paragraph_format.bullet.color.color = draw.Color.black
        paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

        # Définissez la hauteur de la puce.
        paragraph.paragraph_format.bullet.height = 100

        # Ajoutez le paragraphe au cadre de texte.
        text_frame.paragraphs.add(paragraph)

        # Créez le deuxième paragraphe.
        paragraph2 = slides.Paragraph()

        # Définissez le type et le style de puce du paragraphe.
        paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
        paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

        # Définissez le texte du paragraphe.
        paragraph2.text = "This is numbered bullet"

        # Définissez le retrait de la puce.
        paragraph2.paragraph_format.indent = 25

        # Définissez la couleur de la puce.
        paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
        paragraph2.paragraph_format.bullet.color.color = draw.Color.black
        paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

        # Définissez la hauteur de la puce.
        paragraph2.paragraph_format.bullet.height = 100

        # Ajoutez le paragraphe au cadre de texte.
        text_frame.paragraphs.add(paragraph2)

        # Enregistrez la présentation au format PPTX.
        presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Gérer les puces d'image**

Les listes à puces vous aident à organiser et présenter les informations rapidement et efficacement. Les puces d'image sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Accédez à la diapositive cible par son index.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) à la diapositive.
1. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) de la forme.
1. Supprimez le paragraphe par défaut du [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/).
1. Créez le premier paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/).
1. Chargez une image dans un [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/).
1. Définissez le type de puce sur [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) et attribuez l'image.
1. Définissez le texte du paragraphe.
1. Définissez le retrait du paragraphe pour la puce.
1. Définissez la couleur de la puce.
1. Définissez la hauteur de la puce.
1. Ajoutez le nouveau paragraphe à la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/).
1. Ajoutez un deuxième paragraphe et répétez les étapes 8 à 12.
1. Enregistrez la présentation.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Accédez à la première diapositive.
    slide = presentation.slides[0]

    # Chargez l'image de la puce.
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # Ajoutez et accédez à une AutoShape.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accédez au TextFrame de l'AutoShape créée.
    text_frame = auto_shape.text_frame

    # Supprimez le paragraphe par défaut.
    text_frame.paragraphs.remove_at(0)

    # Créez un nouveau paragraphe.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # Définissez le type de puce du paragraphe sur Image et attribuez l'image.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # Définissez la hauteur de la puce.
    paragraph.paragraph_format.bullet.height = 100

    # Ajoutez le paragraphe au cadre de texte.
    text_frame.paragraphs.add(paragraph)

    # Enregistrez la présentation au format PPTX.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # Enregistrez la présentation au format PPT.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **Gérer les puces à plusieurs niveaux**

Les listes à puces vous aident à organiser et présenter les informations rapidement et efficacement. Les puces à plusieurs niveaux sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Accédez à la diapositive cible par son index.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) à la diapositive.
1. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) de l'[AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/).
1. Supprimez le paragraphe par défaut du [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/).
1. Créez le premier paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/) et définissez sa profondeur à 0.
1. Créez le deuxième paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/) et définissez sa profondeur à 1.
1. Créez le troisième paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/) et définissez sa profondeur à 2.
1. Créez le quatrième paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/) et définissez sa profondeur à 3.
1. Ajoutez les nouveaux paragraphes à la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/).
1. Enregistrez la présentation.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Créez une instance de présentation.
with slides.Presentation() as presentation:

    # Accédez à la première diapositive.
    slide = presentation.slides[0]
    
    # Ajoutez une AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accédez au TextFrame de l'AutoShape créée.
    text_frame = auto_shape.text_frame
    
    # Effacez le paragraphe par défaut.
    text_frame.paragraphs.clear()

    # Ajoutez le premier paragraphe.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Définissez le niveau de la puce.
    paragraph1.paragraph_format.depth = 0

    # Ajoutez le deuxième paragraphe.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Définissez le niveau de la puce.
    paragraph2.paragraph_format.depth = 1

    # Ajoutez le troisième paragraphe.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Définissez le niveau de la puce.
    paragraph3.paragraph_format.depth = 2

    # Ajoutez le quatrième paragraphe.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Définissez le niveau de la puce.
    paragraph4.paragraph_format.depth = 3

    # Ajoutez les paragraphes à la collection.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # Enregistrez la présentation au format PPTX.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Gérer les paragraphes avec des listes numérotées personnalisées**

La classe [BulletFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bulletformat/) fournit la propriété `numbered_bullet_start_with` (et d'autres) pour contrôler la numérotation et la mise en forme personnalisées des paragraphes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Accédez à la diapositive qui contiendra les paragraphes.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) à la diapositive.
1. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) de la forme.
1. Supprimez le paragraphe par défaut du [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/).
1. Créez le premier [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/) et définissez `numbered_bullet_start_with` à 2.
1. Créez le deuxième [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/) et définissez `numbered_bullet_start_with` à 3.
1. Créez le troisième [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/) et définissez `numbered_bullet_start_with` à 7.
1. Ajoutez les paragraphes à la collection du [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/).
1. Enregistrez la présentation.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Ajoutez et accédez à une AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accédez au TextFrame de l'AutoShape créée.
    text_frame = shape.text_frame

    # Supprimez le paragraphe existant par défaut.
    text_frame.paragraphs.remove_at(0)

    # Créez le premier élément numéroté (commence à 2, niveau de profondeur 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # Créez le deuxième élément numéroté (commence à 3, niveau de profondeur 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # Créez le troisième élément numéroté (commence à 7, niveau de profondeur 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir le retrait de première ligne pour un paragraphe**

Utilisez la propriété [ParagraphFormat.indent](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/indent/) pour contrôler le retrait de première ligne d'un paragraphe. Cette propriété ne déplace que la première ligne par rapport à la marge gauche du paragraphe. Une valeur positive décale la première ligne vers la droite, tandis que les lignes restantes restent alignées avec le corps du paragraphe.

Utilisez [ParagraphFormat.margin_left](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/margin_left/) lorsque vous devez déplacer tout le paragraphe. Utilisez [ParagraphFormat.indent](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/indent/) lorsque vous devez déplacer uniquement la première ligne.

L'exemple ci-dessous crée plusieurs paragraphes et applique différentes valeurs `indent` pour démontrer comment le retrait de première ligne affecte la mise en page du paragraphe.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
2. Accédez à la diapositive cible.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) rectangulaire à la diapositive.
4. Ajoutez un [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) vide à la forme et supprimez le paragraphe par défaut.
5. Créez plusieurs paragraphes et définissez différentes valeurs [indent](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/indent/) pour ceux-ci.
6. Ajoutez les paragraphes au cadre de texte.
7. Enregistrez la présentation modifiée.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Retrait de première ligne des paragraphes](first_line_indent.png)

## **Définir le retrait suspendu pour un paragraphe**

Un retrait suspendu est une mise en page de paragraphe où la première ligne commence à gauche des lignes restantes. Dans Aspose.Slides, vous créez cet effet avec la propriété [ParagraphFormat.indent](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/indent/). Définissez `indent` à une valeur négative pour déplacer la première ligne vers la gauche par rapport au corps du paragraphe.

En pratique, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/margin_left/) définit la position gauche du corps du paragraphe, et [ParagraphFormat.indent](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/indent/) définit la position de la première ligne par rapport à cette marge. Pour créer un retrait suspendu, définissez une valeur positive pour `margin_left` et une valeur négative pour `indent`.

Cette mise en forme est utile pour les bibliographies, références, entrées de glossaire et autres paragraphes où les lignes renvoyées doivent s'aligner sous le corps du paragraphe plutôt que sous le premier caractère de la première ligne.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
2. Accédez à la diapositive cible.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) rectangulaire à la diapositive.
4. Ajoutez un [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) vide à la forme et supprimez le paragraphe par défaut.
5. Créez des paragraphes et définissez une valeur positive [margin_left](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/margin_left/) pour chaque paragraphe.
6. Définissez une valeur négative [indent](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/indent/) pour créer l'effet de retrait suspendu.
7. Ajoutez les paragraphes au cadre de texte.
8. Enregistrez la présentation modifiée.

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Le retrait suspendu des paragraphes](hanging_indent.png)

## **Gérer le format du fragment de fin de paragraphe**

Lorsque vous devez contrôler le style de la « fin » d'un paragraphe (la mise en forme appliquée après le dernier fragment de texte), utilisez la propriété `end_paragraph_portion_format`. L'exemple ci-dessous applique une police Times New Roman plus grande à la fin du deuxième paragraphe.

1. Créez ou ouvrez un fichier [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Obtenez la diapositive cible par index.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) rectangulaire à la diapositive.
1. Utilisez le [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) de la forme et créez deux paragraphes.
1. Créez un [PortionFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portionformat/) réglé sur Times New Roman 48 pt et appliquez-le comme format de fragment de fin de paragraphe du paragraphe.
1. Attribuez-le à `end_paragraph_portion_format` du paragraphe (s'applique à la fin du deuxième paragraphe).
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

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

Aspose.Slides offre un support amélioré pour l'importation de texte HTML dans des paragraphes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Accédez à la diapositive cible par son index.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) à la diapositive.
1. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) de l'[AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/).
1. Supprimez le paragraphe par défaut du [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/).
1. Lisez le fichier HTML source.
1. Créez le premier paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/).
1. Ajoutez le contenu HTML à la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/).
1. Enregistrez la présentation modifiée.

```python
import aspose.slides as slides

# Créez une instance de Presentation vide.
with slides.Presentation() as presentation:

    # Accédez à la première diapositive de la présentation.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # Ajoutez une AutoShape pour accueillir le contenu HTML.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # Effacez tous les paragraphes du cadre de texte ajouté.
    shape.text_frame.paragraphs.clear()

    # Chargez le fichier HTML.
    with open("file.html", "rt") as html_stream:
        # Ajoutez le texte du fichier HTML au cadre de texte.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # Enregistrez la présentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Exporter le texte d’un paragraphe vers HTML**

Aspose.Slides offre un support amélioré pour l'exportation de texte vers HTML.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) et chargez la présentation cible.
1. Accédez à la diapositive souhaitée par son index.
1. Sélectionnez la forme qui contient le texte à exporter.
1. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) de la forme.
1. Ouvrez un flux de fichier pour écrire la sortie HTML.
1. Spécifiez l'index de départ et exportez les paragraphes requis.

```python
import aspose.slides as slides

# Chargez le fichier de présentation.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # Accédez à la première diapositive de la présentation.
    slide = presentation.slides[0]

    # Index de la forme cible.
    index = 0

    # Accédez à la forme par son index.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Écrivez les données du paragraphe en HTML en fournissant l'index du paragraphe de départ et le nombre total de paragraphes à exporter.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **Enregistrer un paragraphe en tant qu'image**

Dans cette section, nous explorerons deux exemples montrant comment enregistrer un paragraphe de texte, représenté par la classe [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/), en tant qu'image. Les deux exemples incluent l'obtention de l'image d'une forme contenant le paragraphe à l'aide des méthodes `get_image` de la classe [Shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/), le calcul des limites du paragraphe à l'intérieur de la forme, et son exportation sous forme d'image bitmap. Ces approches vous permettent d'extraire des parties spécifiques du texte des présentations PowerPoint et de les enregistrer comme images distinctes, ce qui peut être utile dans divers scénarios.

Supposons que nous ayons un fichier de présentation nommé sample.pptx avec une diapositive, où la première forme est une zone de texte contenant trois paragraphes.

![La zone de texte avec trois paragraphes](paragraph_to_image_input.png)

**Exemple 1**

Dans cet exemple, nous obtenons le deuxième paragraphe sous forme d'image. Pour ce faire, nous extrayons l'image de la forme de la première diapositive de la présentation, puis calculons les limites du deuxième paragraphe dans le cadre de texte de la forme. Le paragraphe est ensuite redessiné sur une nouvelle image bitmap, qui est enregistrée au format PNG. Cette méthode est particulièrement utile lorsque vous devez enregistrer un paragraphe spécifique en tant qu'image séparée tout en préservant les dimensions et la mise en forme exactes du texte.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Enregistrez la forme en mémoire sous forme de bitmap.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Créez un bitmap de forme à partir de la mémoire.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Calculez les limites du deuxième paragraphe.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # Calculez les coordonnées et la taille de l'image de sortie (taille minimale - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Recadrez le bitmap de la forme pour obtenir uniquement le bitmap du paragraphe.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

Le résultat :

![L'image du paragraphe](paragraph_to_image_output.png)

**Exemple 2**

Dans cet exemple, nous étendons l'approche précédente en ajoutant des facteurs d'échelle à l'image du paragraphe. La forme est extraite de la présentation et enregistrée sous forme d'image avec un facteur d'échelle de `2`. Cela permet d'obtenir une sortie à plus haute résolution lors de l'exportation du paragraphe. Les limites du paragraphe sont ensuite calculées en tenant compte de l'échelle. L'échelle peut être particulièrement utile lorsqu'une image plus détaillée est requise, par exemple pour une utilisation dans des supports imprimés de haute qualité.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Enregistrez la forme en mémoire sous forme de bitmap.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Créez un bitmap de forme à partir de la mémoire.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Calculez les limites du deuxième paragraphe.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # Calculez les coordonnées et la taille de l'image de sortie (taille minimale - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Recadrez le bitmap de la forme pour obtenir uniquement le bitmap du paragraphe.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **FAQ**

**Puis-je désactiver complètement le retour à la ligne à l'intérieur d'un cadre de texte ?**

Oui. Utilisez le réglage d'habillage du cadre de texte ([wrap_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/wrap_text/)) pour désactiver l'habillage afin que les lignes ne se cassent pas aux bords du cadre.

**Comment puis-je obtenir les limites exactes sur la diapositive d'un paragraphe spécifique ?**

Vous pouvez récupérer le rectangle englobant du paragraphe (et même d'un seul fragment) afin de connaître sa position et sa taille précises sur la diapositive.

**Où le alignement du paragraphe (gauche/droite/centré/justifié) est-il contrôlé ?**

[Alignment](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/alignment/) est un paramètre au niveau du paragraphe dans [ParagraphFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/); il s'applique à l'ensemble du paragraphe quel que soit le format individuel des fragments.

**Puis-je définir une langue de vérification orthographique pour seulement une partie d'un paragraphe (par exemple, un mot) ?**

Oui. La langue est définie au niveau du fragment ([PortionFormat.language_id](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portionformat/language_id/)), de sorte que plusieurs langues peuvent coexister dans un même paragraphe.