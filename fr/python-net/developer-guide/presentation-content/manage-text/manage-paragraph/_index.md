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
- importer du HTML
- texte vers HTML
- paragraphe vers HTML
- paragraphe vers image
- texte vers image
- exporter le paragraphe
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à créer et formater des paragraphes, des portions, des puces, des listes numérotées, des retraits, du contenu HTML et des images de paragraphes avec Aspose.Slides pour Python via .NET."
---
## **Vue d'ensemble**

Aspose.Slides pour Python via .NET représente le texte sous forme d'une hiérarchie d'encadrés de texte, de paragraphes et de portions :

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) représente le conteneur de texte dans une forme et fournit l'accès à sa collection de paragraphes.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) représente un paragraphe dans un encadré de texte et fournit l'accès à ses portions et à la mise en forme au niveau du paragraphe.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) représente un fragment de texte au sein d'un paragraphe. Chaque portion peut avoir son propre texte et une mise en forme au niveau des caractères.

Un paragraphe peut donc contenir du texte avec différentes polices, couleurs, tailles et autres mises en forme en utilisant plusieurs portions.

## **Créer et formater des paragraphes**

Créez des paragraphes dans l'encadré de texte d'une forme et utilisez des portions pour formater des fragments de texte individuels. Cette section montre comment combiner plusieurs portions au sein de chaque paragraphe et appliquer différentes couleurs, tailles de police et styles.

### **Créer des paragraphes avec plusieurs portions**

L'exemple Python suivant crée trois paragraphes, chacun contenant trois fragments de texte dans sa collection [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/). Il réutilise le paragraphe par défaut et sa portion vide, puis ajoute les paragraphes et portions restants. La mise en forme est appliquée via [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/) : la première portion de chaque paragraphe est rouge, en gras, et de 15 points ; la deuxième est bleue, en italique, et de 18 points. La troisième portion conserve sa mise en forme par défaut :

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

Organisez le texte des paragraphes en listes avec des symboles, des chiffres ou des images personnalisées. Les exemples de cette section couvrent la mise en forme des puces, les listes à plusieurs niveaux et les numéros de départ personnalisés.

### **Créer une liste à puces ou numérotée**

Les puces et la numérotation facilitent la lecture des éléments connexes. Dans Aspose.Slides, les paramètres de liste sont définis via [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/).

Cet exemple Python ajoute une puce symbole et un élément numéroté au même encadré de texte. [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) sélectionne le type de puce, tandis que [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) fournit le symbole et [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) sélectionne le style de numérotation. Les deux éléments utilisent des puces noires avec une hauteur de 100 % et un retrait de paragraphe de 25 points :

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

### **Utiliser des puces image**

Les puces image vous permettent d'utiliser une image personnalisée à la place d'un symbole ou d'un numéro.

L'exemple nécessite `bullets.png` dans le répertoire de travail. Cet exemple Python ajoute une image à la collection d'images de la présentation en tant que [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) et l'utilise comme puce de paragraphe. Il définit [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) pour utiliser une puce image et associe l'image via [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/). [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) est réglé à 100 % pour dimensionner la puce par rapport au texte du paragraphe :

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

Définissez [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) pour placer les paragraphes à différents niveaux d'une liste. Le niveau supérieur a une profondeur de `0`.

Cet exemple Python attribue des valeurs [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) de 0 à 3 à quatre paragraphes, créant une hiérarchie dans un seul encadré de texte. Chaque paragraphe utilise une puce symbole, avec [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) alternant entre une puce ronde et un tiret pour distinguer les niveaux adjacents :

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

### **Démarrer les éléments de liste numérotée à des valeurs personnalisées**

Utilisez [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) pour définir le numéro initial affiché pour un paragraphe numéroté.

Cet exemple Python définit [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) pour utiliser la numérotation sur trois paragraphes et attribue des valeurs [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) de 2, 3 et 7. La valeur de départ est configurée séparément pour chaque paragraphe, permettant aux numéros affichés de sauter des valeurs :

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

## **Contrôler la disposition du paragraphe et les propriétés de fin**

Ajustez les marges et les retraits des paragraphes pour contrôler la position de la première ligne et des lignes renvoyées. Vous pouvez également formater le marqueur de fin de paragraphe séparément des portions de texte visibles.

### **Définir un retrait de première ligne**

Utilisez la propriété [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) pour contrôler le retrait de première ligne d'un paragraphe. Cette propriété ne déplace que la première ligne par rapport à la marge gauche du paragraphe. Une valeur positive décale la première ligne vers la droite, tandis que les lignes restantes restent alignées sur le corps du paragraphe.

Utilisez [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) lorsque vous devez déplacer tout le paragraphe. Utilisez [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) lorsque vous devez déplacer uniquement la première ligne.

L'exemple suivant donne à trois paragraphes la même [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) de 20 points et des valeurs [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) de 0, 20 et 40 points. Les premières lignes démarrent à des décalages progressivement plus grands, tandis que les lignes renvoyées conservent la même marge gauche :

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

![Retrait de première ligne des paragraphes](first_line_indent.png)

### **Définir un retrait suspendu**

Un retrait suspendu est une mise en page de paragraphe où la première ligne commence à gauche des lignes restantes. Dans Aspose.Slides, vous créez cet effet avec la propriété [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/). Définissez `indent` à une valeur négative pour déplacer la première ligne vers la gauche par rapport au corps du paragraphe.

En pratique, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) définit la position gauche du corps du paragraphe, et [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) définit la position de la première ligne par rapport à cette marge. Pour créer un retrait suspendu, attribuez une valeur positive à `margin_left` et une valeur négative à `indent`.

Cette mise en forme est utile pour les bibliographies, références, entrées de glossaire et autres paragraphes où les lignes renvoyées doivent s'aligner sous le corps du paragraphe plutôt que sous le premier caractère de la première ligne.

L'exemple Python suivant associe des valeurs [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) de 40 et 60 points avec des valeurs [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) de -20 et -30 points. Dans chaque paragraphe, la première ligne débute à gauche des lignes renvoyées ; le deuxième paragraphe possède un retrait suspendu plus profond :

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

![Retrait suspendu des paragraphes](hanging_indent.png)

### **Définir les propriétés d'exécution de fin de paragraphe**

La propriété [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) contrôle la mise en forme du marqueur de fin de paragraphe. L'exemple charge `Test.pptx`, qui doit contenir au moins une diapositive, et crée un [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) avec [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) fixé à 48 points et [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) défini sur Times New Roman. Il assigne ce format au marqueur de fin du deuxième paragraphe, laissant les portions de texte visibles inchangées :

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

## **Compter les lignes rendues**

Pour les règles de paragraphe qui affectent le renvoi à la ligne automatique et la ponctuation en fin de ligne, voir [Control Line Breaking](/slides/fr/python-net/text-formatting/#control-line-breaking) et [Control Hanging Punctuation](/slides/fr/python-net/text-formatting/#control-hanging-punctuation).

Utilisez [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) pour compter les lignes occupées par un paragraphe après la mise en page du texte, y compris le renvoi à la ligne automatique. Cela est utile lors de la vérification de la longueur du texte et de la mise en page dans des modèles de présentation.

Un paragraphe est un élément de [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/) et peut occuper plusieurs lignes rendues. Un retour à la ligne explicite dans un paragraphe force une nouvelle ligne sans créer un autre paragraphe. Le renvoi à la ligne automatique crée des lignes en fonction de la largeur disponible sans insérer de caractères de retour à la ligne explicites dans le texte. Compter les paragraphes ou les caractères de retour à la ligne ne donne donc pas le nombre de lignes rendues.

L'exemple suivant crée une forme de texte, compte ses lignes, réduit la forme, puis remplace le texte par une chaîne plus courte. L'exemple active [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) et désactive [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) afin que la largeur de la forme contrôle le renvoi à la ligne sans réduire automatiquement le texte ou redimensionner la forme. Chaque mesure utilise [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/). Les dimensions de la forme sont exprimées en points. Enfin, l'exemple ajoute un autre paragraphe et additionne les décomptes de lignes dans l'encadré de texte.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

Avec ce texte et ces dimensions, réduire la forme augmente le nombre de lignes, tandis que remplacer le texte par la courte chaîne le réduit. Les décomptes exacts peuvent varier selon la disponibilité et le remplacement des polices, la taille de la police, les marges, les retraits, le renvoi à la ligne et les paramètres d'ajustement automatique. Utilisez les polices et les paramètres de mise en page prévus pour l'environnement cible lors de la vérification d'un modèle.

Le simple nombre de lignes ne détermine pas si le texte dépasse son conteneur. La hauteur disponible, la hauteur des lignes, l'espacement des paragraphes et des lignes, ainsi que le comportement d'ajustement automatique sont également importants ; même une seule ligne peut dépasser la largeur disponible lorsque le renvoi à la ligne est désactivé.

## **Importer et exporter le contenu de paragraphe**

Utilisez HTML pour introduire du texte dans une présentation ou exporter des paragraphes existants pour une utilisation externe. Cette section montre également comment rendre des paragraphes individuels en images, y compris les paragraphes dans les cellules de tableau.

### **Importer du texte HTML dans les paragraphes**

Utilisez [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) pour convertir le balisage HTML en paragraphes et portions dans un encadré de texte.

Cet exemple Python lit le HTML depuis `file.html` dans le répertoire de travail et transmet le balisage à [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/). Il supprime le paragraphe par défaut de l'encadré de texte afin que le cadre ne contienne que le contenu importé. La forme rectangulaire laisse une marge de 10 points de chaque côté de la diapositive :

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

### **Exporter le texte du paragraphe vers HTML**

Utilisez [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) pour exporter une plage sélectionnée de paragraphes en HTML. Lors de la réutilisation du texte d'une présentation sur un site web, vous pouvez souhaiter conserver les emphases locales sans transporter la police, la taille ou les styles de zone de texte de la présentation. Définissez [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/) pour contrôler jusqu'où l'exportateur suit l'héritage de mise en forme.

Téléchargez [the sample presentation](text-inheritance.pptx) et placez‑le dans le répertoire de travail de l'application. Sa première diapositive contient une zone de texte avec le texte « Inherited text; explicit red 18pt ». L'entrée utilise délibérément plusieurs niveaux de mise en forme :

- Le style de texte par défaut de la présentation fournit Calibri et une taille de 28 pt.
- Le style de texte de premier niveau du cadre de texte fournit du texte bleu et italique.
- Le paragraphe définit explicitement le texte en gras.
- La deuxième portion, "explicit red 18pt", définit explicitement du texte rouge et une taille de 18 pt.

L'exemple complet suivant exporte les mêmes paragraphes trois fois. Il transmet [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) à la méthode d'exportation et écrit chaque résultat dans un fichier HTML UTF‑8 distinct :

```python
import aspose.slides as slides

with slides.Presentation("text-inheritance.pptx") as presentation:
    text_shape = presentation.slides[0].shapes[0]
    paragraphs = text_shape.text_frame.paragraphs
    
    modes = {
        "All": slides.export.TextInheritanceLimit.ALL,
        "TextBox": slides.export.TextInheritanceLimit.TEXT_BOX,
        "ParagraphOnly": slides.export.TextInheritanceLimit.PARAGRAPH_ONLY,
    }

    for name, mode in modes.items():
        options = slides.export.TextToHtmlConversionOptions()
        options.text_inheritance_limit = mode

        html = paragraphs.export_to_html(0, paragraphs.count, options)
        with open(f"{name}.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
```

Le HTML généré contient le CSS suivant pour la première portion, « Inherited text; ». Le tableau liste les déclarations pertinentes ; les autres propriétés générées sont omises pour plus de clarté.

| Sortie | CSS pertinent pour la première portion | Apparence |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Texte bleu, gras, italique à 28 pt en Calibri, si cette police est disponible. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Texte bleu, gras, italique ; la page ou le navigateur fournit la police et la taille. |
| `ParagraphOnly.html` | `font-weight:bold` | Texte gras ; la page ou le navigateur fournit la police, la taille, la couleur et le style italique. |

La deuxième portion conserve `color:#ff0000`, `font-size:18pt` et `font-weight:bold` dans les trois sorties. Elle conserve aussi l'italique avec `ALL` et `TEXT_BOX`, mais pas avec `PARAGRAPH_ONLY`. Restreindre l'héritage ne supprime donc pas la mise en forme explicitement attribuée à un paragraphe ou à une portion.

Ouvrez les fichiers dans le même navigateur pour les comparer. Dans les deux modes restreints, les propriétés CSS omises sont résolues par les styles de la page de destination ou par les valeurs par défaut du navigateur, de sorte que l'apparence résultante dépend de l'endroit où le HTML est utilisé.

### **Rendre un paragraphe en image**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) rend directement un paragraphe individuel et renvoie un [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/). Enregistrez le résultat dans un fichier ou un flux avec [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Vous n'avez pas besoin de rendre la forme contenant le paragraphe ni de recadrer un bitmap manuellement.

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) peut renvoyer `None` si le paragraphe est introuvable dans sa collection parente, s'il n'a pas de limites de rendu valides, ou s'il ne peut pas être rendu. Vérifiez le résultat avant de l'enregistrer et libérez l'image retournée après utilisation.

#### **Rendre un paragraphe à l'échelle par défaut**

L'exemple utilise `sample.pptx`, une présentation contenant une diapositive dont la première forme est une zone de texte contenant trois paragraphes.

![La zone de texte avec trois paragraphes](paragraph_to_image_input.png)

L'exemple suivant sélectionne le deuxième paragraphe à l'index 1 et appelle [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) sans paramètres d'échelle. Il vérifie que la forme contient le paragraphe requis et que le rendu renvoie une image avant d'appeler [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) pour l'enregistrer au format PNG. Le gestionnaire de contexte libère les ressources de l'image après usage.

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

Utilisez la surcharge de [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) qui accepte les paramètres `scale_x` et `scale_y` pour définir les facteurs d'échelle horizontaux et verticaux. L'exemple suivant crée un tableau, rend le paragraphe dans sa première cellule à deux fois sa largeur et hauteur par défaut, et enregistre le résultat sous forme d'image PNG.

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

Un facteur d'échelle de `1` maintient cet axe à sa taille de pixel par défaut. Par exemple, `2` pour les deux facteurs produit une image dont la largeur et la hauteur sont approximativement le double des dimensions d'origine, ce qui donne quatre fois plus de pixels. Des facteurs plus grands produisent généralement un texte plus net pour le zoom ou les sorties haute résolution, mais augmentent aussi la consommation de mémoire et la taille du fichier. Des facteurs inférieurs à `1` produisent des images plus petites avec moins de détails. Utilisez des facteurs égaux pour préserver le ratio d'aspect du paragraphe ; des facteurs différents en horizontal et vertical étirent la sortie indépendamment.

Rendre une forme entière avec [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) reste utile lorsque la sortie doit inclure le remplissage, la bordure ou tout autre contexte visuel de la forme. Pour une image contenant uniquement le paragraphe, utilisez [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/).

## **FAQ**

**Puis-je désactiver complètement le retour à la ligne dans un encadré de texte ?**

Oui. Réglez [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) pour désactiver le renvoi à la ligne afin que les lignes ne se coupent pas aux bords de l'encadré de texte.

**Comment obtenir les limites exactes sur la diapositive d'un paragraphe spécifique ?**

Utilisez [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) pour récupérer le rectangle englobant du paragraphe. [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) fournit les limites d'une portion individuelle.

**Où le réglage de l'alignement du paragraphe (gauche, droite, centre ou justifié) est-il contrôlé ?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) est un paramètre au niveau du paragraphe et s'applique à l'ensemble du paragraphe indépendamment de la mise en forme des portions individuelles.

Pour aligner verticalement des portions de tailles de police différentes au sein de chaque ligne, voir [Align Fonts Within a Line](/slides/fr/python-net/text-formatting/#align-fonts-within-a-line).

**Puis-je définir la langue de vérification pour une partie d'un paragraphe ?**

Oui. Définissez [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) pour les portions individuelles, de sorte qu'un paragraphe puisse contenir du texte en plusieurs langues.