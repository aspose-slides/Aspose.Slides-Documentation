---
title: Gérer les paragraphes de texte PowerPoint en Python
linktitle: Gérer le paragraphe
type: docs
weight: 40
url: /fr/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
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
description: "Apprenez à créer et mettre en forme des paragraphes, des portions, des puces, des listes numérotées, des retraits, du contenu HTML et des images de paragraphes avec Aspose.Slides pour Python via .NET."
---
## **Vue d'ensemble**

Aspose.Slides for Python via .NET représente le texte sous forme d'une hiérarchie de cadres de texte, de paragraphes et de portions :

* [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) représente le conteneur de texte d'une forme et fournit l'accès à sa collection de paragraphes.
* [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/) représente un paragraphe dans un cadre de texte et fournit l'accès à ses portions ainsi qu'au formatage au niveau du paragraphe.
* [Portion](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/) représente un segment de texte au sein d'un paragraphe. Chaque portion peut avoir son propre texte et un formatage au niveau des caractères.

Un paragraphe peut donc contenir du texte avec différentes polices, couleurs, tailles et autres formats en utilisant plusieurs portions.

## **Créer et mettre en forme les paragraphes**

### **Créer des paragraphes avec plusieurs portions**

Les étapes suivantes créent un cadre de texte avec trois paragraphes, chacun contenant trois portions :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
2. Accéder à la diapositive concernée par son indice.
3. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) rectangulaire à la diapositive.
4. Accéder au [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) de la forme.
5. Utiliser le paragraphe par défaut et ajouter deux objets [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/) supplémentaires au cadre de texte.
6. Ajouter suffisamment d'objets [Portion](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/) pour que chaque paragraphe contienne trois portions. Le paragraphe par défaut contient déjà une portion vide.
7. Définir le texte de chaque portion.
8. Appliquer le formatage au niveau des caractères via [Portion.portion_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/portion_format/).
9. Enregistrer la présentation modifiée.

Cet exemple Python implémente les étapes :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **Créer des listes à puces et numérotées**

### **Créer une liste à puces ou numérotée**

Les puces et la numérotation facilitent la lecture d'éléments liés. Dans Aspose.Slides, les paramètres de liste sont définis via [BulletFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bulletformat/).

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
2. Accéder à la diapositive concernée par son indice.
3. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) à la diapositive sélectionnée.
4. Accéder au [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) de la forme.
5. Supprimer le paragraphe par défaut du cadre de texte.
6. Créer un [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/) pour une puce symbolique.
7. Définir [BulletFormat.type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bulletformat/type/) sur [BulletType.SYMBOL](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bullettype/) et spécifier le caractère de la puce.
8. Définir le texte du paragraphe, le retrait, la couleur de la puce et la hauteur de la puce.
9. Ajouter le paragraphe au cadre de texte.
10. Créer un second paragraphe et définir [BulletFormat.type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bulletformat/type/) sur [BulletType.NUMBERED](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bullettype/).
11. Configurer le style de puce numérotée et ajouter le paragraphe au cadre de texte.
12. Enregistrer la présentation.

Cet exemple Python crée une puce symbole et une puce numérotée :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Utiliser des puces d'image**

Les puces d'image permettent d'utiliser une image personnalisée au lieu d'un symbole ou d'un numéro.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
2. Accéder à la diapositive concernée par son indice.
3. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) et accéder à son [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/).
4. Supprimer le paragraphe par défaut du cadre de texte.
5. Charger l'image de la puce et l'ajouter à la collection d'images de la présentation en tant que [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/).
6. Créer un [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/) et définir son texte.
7. Définir [BulletFormat.type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bulletformat/type/) sur [BulletType.PICTURE](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bullettype/).
8. Assigner l'image via [BulletFormat.picture](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bulletformat/picture/) et définir la hauteur de la puce.
9. Ajouter le paragraphe au cadre de texte.
10. Enregistrer la présentation modifiée.

Cet exemple Python crée une puce d'image :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **Créer une liste à plusieurs niveaux**

Définir [ParagraphFormat.depth](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/depth/) pour placer les paragraphes à différents niveaux d'une liste. Le niveau supérieur a une profondeur de `0`.

1. Créer une [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) et accéder à une diapositive.
2. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) et vider le paragraphe par défaut de son cadre de texte.
3. Créer quatre paragraphes et configurer leurs symboles de puce.
4. Définir leurs valeurs [ParagraphFormat.depth](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/depth/) à `0`, `1`, `2` et `3`.
5. Ajouter les paragraphes au cadre de texte et enregistrer la présentation.

Cet exemple Python crée une liste à puces à quatre niveaux :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Démarrer les éléments de liste numérotée avec des valeurs personnalisées**

Utiliser [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) pour définir le numéro initial affiché pour un paragraphe numéroté.

1. Créer une [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) et ajouter une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) à une diapositive.
2. Vider le paragraphe par défaut du cadre de texte de la forme.
3. Créer trois paragraphes numérotés.
4. Définir [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/fr/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) à `2`, `3` et `7` pour les paragraphes respectifs.
5. Ajouter les paragraphes au cadre de texte et enregistrer la présentation.

Cet exemple Python assigne un numéro de départ personnalisé à chaque paragraphe :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Contrôler la mise en forme du paragraphe et ses propriétés de fin**

### **Définir un retrait de première ligne**

Utiliser la propriété [ParagraphFormat.indent](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/indent/) pour contrôler le retrait de la première ligne d'un paragraphe. Cette propriété ne déplace que la première ligne par rapport à la marge gauche du paragraphe. Une valeur positive décale la première ligne vers la droite, tandis que les lignes restantes restent alignées avec le corps du paragraphe.

Utilisez [ParagraphFormat.margin_left](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/margin_left/) lorsque vous devez déplacer tout le paragraphe. Utilisez [ParagraphFormat.indent](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/indent/) lorsque vous ne devez déplacer que la première ligne.

L'exemple ci‑dessous crée plusieurs paragraphes et applique différentes valeurs [ParagraphFormat.indent](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/indent/) pour montrer comment le retrait de première ligne affecte la mise en page du paragraphe.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
2. Accéder à la diapositive cible.
3. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) rectangulaire à la diapositive.
4. Accéder au [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) de la forme et supprimer le paragraphe par défaut.
5. Créer plusieurs paragraphes et définir différentes valeurs [ParagraphFormat.indent](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/indent/) pour chacun d'eux.
6. Ajouter les paragraphes au cadre de texte.
7. Enregistrer la présentation modifiée.

Ce code montre comment définir un retrait de paragraphe :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Le retrait de première ligne des paragraphes](first_line_indent.png)

### **Définir un retrait suspendu**

Un retrait suspendu est une mise en page où la première ligne commence à gauche des lignes suivantes. Dans Aspose.Slides, vous créez cet effet avec la propriété [ParagraphFormat.indent](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/indent/). Définissez `indent` à une valeur négative pour déplacer la première ligne vers la gauche par rapport au corps du paragraphe.

En pratique, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/margin_left/) définit la position gauche du corps du paragraphe, et [ParagraphFormat.indent](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/indent/) définit la position de la première ligne par rapport à cette marge. Pour créer un retrait suspendu, définissez une valeur positive pour `margin_left` et une valeur négative pour `indent`.

Ce formatage est utile pour les bibliographies, références, entrées de glossaire et autres paragraphes où les lignes renvoyées doivent s'aligner sous le corps du paragraphe plutôt que sous le premier caractère de la première ligne.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
2. Accéder à la diapositive cible.
3. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) rectangulaire à la diapositive.
4. Accéder au [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) de la forme et supprimer le paragraphe par défaut.
5. Créer des paragraphes et définir pour chaque paragraphe une valeur positive [ParagraphFormat.margin_left](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/margin_left/).
6. Définir une valeur négative [ParagraphFormat.indent](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/indent/) pour créer l'effet de retrait suspendu.
7. Ajouter les paragraphes au cadre de texte.
8. Enregistrer la présentation modifiée.

Ce code montre comment définir un retrait suspendu pour un paragraphe :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Le retrait suspendu des paragraphes](hanging_indent.png)

### **Définir les propriétés de la portion de fin de paragraphe**

La propriété [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) contrôle le formatage du marqueur de fin de paragraphe. L'exemple suivant assigne une taille de police et une police latine au marqueur de fin du deuxième paragraphe :

1. Charger une [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) et accéder à une diapositive.
2. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) et vider son paragraphe par défaut.
3. Créer deux paragraphes et ajouter des portions de texte à chacun.
4. Créer un [PortionFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portionformat/) pour le marqueur de fin du deuxième paragraphe.
5. Définir [PortionFormat.font_height](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portionformat/font_height/) et [PortionFormat.latin_font](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portionformat/latin_font/).
6. Assigner le format à [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) et enregistrer la présentation.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Importer et exporter le contenu des paragraphes**

### **Importer du texte HTML dans des paragraphes**

Utiliser [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphcollection/add_from_html/) pour convertir le balisage HTML en paragraphes et portions dans un cadre de texte.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
2. Accéder à une diapositive et ajouter une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/).
3. Accéder au [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) de la forme et vider le paragraphe par défaut.
4. Lire le fichier HTML source.
5. Passer la chaîne HTML à [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphcollection/add_from_html/).
6. Enregistrer la présentation modifiée.

Cet exemple Python importe du HTML dans un cadre de texte :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **Exporter le texte du paragraphe en HTML**

Utiliser [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphcollection/export_to_html/) pour exporter une plage sélectionnée de paragraphes au format HTML.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) et charger la présentation souhaitée.
2. Accéder à la diapositive et trouver la [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) contenant le texte.
3. Accéder au [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) de la forme.
4. Appeler [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphcollection/export_to_html/) avec l'indice du paragraphe de départ et le nombre de paragraphes à exporter.
5. Écrire la chaîne HTML retournée dans un fichier.

Cet exemple Python exporte tous les paragraphes du premier objet texte :

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **Rendre un paragraphe en image**

[Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/) fournit la méthode `get_image` pour rendre directement un paragraphe individuel. La méthode renvoie un [IImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iimage/) que vous pouvez enregistrer dans un fichier ou un flux avec [IImage.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iimage/save/). Vous n'avez pas besoin de rendre la forme contenant le texte ou de recadrer manuellement un bitmap.

La méthode `get_image` peut renvoyer `None` si le paragraphe n'est pas trouvé dans sa collection parente, s'il n'a pas de limites de rendu valides ou s'il ne peut pas être rendu. Vérifiez le résultat avant de l'enregistrer et utilisez l'image retournée comme gestionnaire de contexte pour libérer ses ressources.

#### **Rendre un paragraphe à l'échelle par défaut**

Supposons que nous ayons un fichier de présentation nommé sample.pptx avec une diapositive, où la première forme est une zone de texte contenant trois paragraphes.

![La zone de texte avec trois paragraphes](paragraph_to_image_input.png)

L'exemple suivant rend le deuxième paragraphe d'une forme texte ordinaire à l'échelle par défaut et enregistre l'image retournée au format PNG :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

Le résultat :

![L'image du paragraphe](paragraph_to_image_output.png)

#### **Rendre un paragraphe dans une cellule de tableau avec mise à l'échelle**

Passez des facteurs d'échelle horizontaux et verticaux à `get_image` pour contrôler la taille du paragraphe rendu. L'exemple suivant crée un tableau, rend le paragraphe dans sa première cellule à deux fois sa largeur et hauteur par défaut, et enregistre le résultat au format PNG :

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

Un facteur d'échelle de `1` conserve cette dimension à sa taille pixel par défaut. Par exemple, `2` pour les deux facteurs produit une image dont la largeur et la hauteur sont approximativement le double des dimensions par défaut, soit quatre fois plus de pixels. Des facteurs plus grands produisent généralement un texte plus net pour le zoom ou la sortie haute résolution, mais augmentent également la consommation de mémoire et la taille du fichier. Des facteurs inférieurs à `1` produisent des images plus petites avec moins de détails. Utilisez des facteurs égaux pour conserver le ratio d'aspect du paragraphe ; des facteurs horizontaux et verticaux différents étirent la sortie indépendamment.

Rendre une forme entière avec [Shape.get_image](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/get_image/) reste utile lorsque la sortie doit inclure le remplissage, la bordure ou un autre contexte visuel de la forme. Pour une image contenant uniquement le paragraphe, utilisez `Paragraph.get_image`.

## **FAQ**

**Puis-je désactiver complètement le retour à la ligne dans un cadre de texte ?**

Oui. Définissez [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/wrap_text/) pour désactiver le retour à la ligne afin que les lignes ne se cassent pas aux bords du cadre de texte.

**Comment obtenir les limites exactes sur la diapositive d'un paragraphe spécifique ?**

Utilisez [Paragraph.get_rect](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/get_rect/) pour récupérer le rectangle délimitant le paragraphe. [Portion.get_rect](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/get_rect/) fournit les limites d'une portion individuelle.

**Où la justification du paragraphe (gauche, droite, centré ou justifié) est‑elle contrôlée ?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/alignment/) est un paramètre au niveau du paragraphe et s'applique à l'ensemble du paragraphe, quelle que soit la mise en forme des portions individuelles.

**Puis-je définir la langue de vérification pour une partie d'un paragraphe ?**

Oui. Définissez [PortionFormat.language_id](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portionformat/language_id/) pour les portions individuelles, afin qu'un paragraphe puisse contenir du texte dans plusieurs langues.