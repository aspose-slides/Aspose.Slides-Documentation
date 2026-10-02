---
title: Formater le texte de présentation en Python
linktitle: Mise en forme du texte
type: docs
weight: 50
url: /fr/python-net/text-formatting/
keywords:
- aligner le paragraphe
- style de texte
- arrière-plan du texte
- transparence du texte
- espacement des caractères
- propriétés de police
- famille de police
- rotation du texte
- angle de rotation
- cadre de texte
- espacement des lignes
- propriete d'ajustement automatique
- ancre du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Formatez et stylisez le texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Python via .NET. Personnalisez les polices, les couleurs, l'alignement et plus encore."
---
## **Vue d'ensemble**

Cet article montre comment formater du texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides for Python via .NET. Il couvre les couleurs d’arrière‑plan, la transparence, l’espacement des caractères, les propriétés de police, la rotation, l’espacement des paragraphes, le comportement d’ajustement automatique, l’ancrage du texte, les tabulations et les paramètres de langue.

Sauf indication contraire, les exemples utilisent [sample.pptx](sample.pptx). La première forme de la première diapositive est une zone de texte, et son premier paragraphe contient le texte affiché ci-dessous. Les indices des diapositives et des formes commencent à zéro. Les exemples qui sélectionnent des parties en gras utilisent le formatage effectif, y compris le formatage gras hérité :

![Exemple de texte](sample_text.png)

Pour rechercher et mettre en surbrillance du texte littéral ou des correspondances d'expressions régulières, voir [Rechercher et remplacer du texte](/slides/fr/python-net/search-and-replace-text/).

## **Définir la couleur d'arrière-plan du texte**

Utilisez [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) pour définir la couleur de surbrillance par défaut d'un paragraphe, ou utilisez [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) pour des portions de texte individuelles.

L'exemple suivant définit une surbrillance gris clair comme valeur par défaut pour le premier paragraphe. Les couleurs de surbrillance explicites sur les portions individuelles ont la priorité sur cette valeur par défaut :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Définir la couleur de surbrillance pour le paragraphe entier.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Le paragraphe gris](gray_paragraph.png)

L'exemple de code ci-dessous montre comment définir la couleur d'arrière-plan pour **les portions de texte avec une police en gras** :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Définir la couleur de surbrillance pour la portion de texte.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Les portions de texte grises](gray_text_portions.png)

## **Aligner les paragraphes de texte**

Utilisez [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) pour définir l'alignement du paragraphe à l'intérieur d'un cadre de texte. La valeur peut être centrée, alignée à gauche, alignée à droite, justifiée, etc.

L'exemple de code suivant montre comment aligner le paragraphe au **centre** :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Définir l'alignement du paragraphe au centre.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Le paragraphe aligné](aligned_paragraph.png)

## **Aligner les polices dans une ligne**

Utilisez [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) pour aligner verticalement les portions de texte de tailles de police différentes au sein d'une ligne. Ce paramètre s'applique à l'ensemble du paragraphe et contrôle l'alignement dans chacune de ses lignes.

L'exemple autonome suivant crée quatre zones de texte libellées sur une diapositive. Chaque paragraphe contient le même texte en tailles 18, 36 et 54 points, avec un alignement de police différent. Il utilise Arial, désactive l'ajustement automatique et le retour à la ligne, et maintient les cadres de texte suffisamment grands pour une seule ligne.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Comparaison des alignements de police (baseline, haut, centre, bas) avec des tailles de police mixtes](font_alignment.png)

L'alignement de police utilise les métriques de police, de sorte que les bords visibles des lettres individuelles ne sont pas nécessairement parfaitement alignés. L'exemple comprend à la fois une lettre majuscule et un descendant pour illustrer la différence entre l'alignement de base et celui du bas. La disponibilité et la substitution des polices, les caractères utilisés et la différence de tailles de police influencent le résultat. Les dimensions du cadre, les marges, l'interligne, le retour à la ligne et l'ajustement automatique affectent également la mise en page ; utilisez les mêmes polices et paramètres de mise en page lors de la comparaison des modes.

Ce paramètre diffère de [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), qui contrôle l'alignement horizontal du paragraphe, et de [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), qui positionne le bloc de texte verticalement dans sa forme. Le formatage exposant et indice via [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) décale les portions individuelles par rapport à la ligne de base au lieu de définir l'alignement de police pour les lignes du paragraphe.

## **Définir la transparence du texte**

La transparence du texte est contrôlée via le composant alpha de la couleur assignée à [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Dans les exemples ci-dessous, `alpha = 50` est une valeur du canal alpha ARGB sur une échelle de 0 à 255, et non un pourcentage de transparence.

L'exemple de code ci-dessous montre comment appliquer la transparence au **paragraphe entier** :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Définir un remplissage noir semi-transparent pour le texte.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Le paragraphe transparent](transparent_paragraph.png)

L'exemple de code suivant montre comment appliquer la transparence aux **portions de texte avec une police en gras** :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Définir la transparence de la portion de texte.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Les portions de texte transparentes](transparent_text_portions.png)

## **Définir l'espacement des caractères pour le texte**

Utilisez [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) pour augmenter ou réduire l'espacement entre les caractères dans une zone de texte. Les exemples ajoutent 3 points d'espacement ; des valeurs négatives condensent le texte.

Le code Python suivant montre comment élargir l'espacement des caractères dans le **paragraphe entier** :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Remarque: Utilisez des valeurs negatives pour compresser l'espacement des caracteres.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Augmenter l'espacement des caracteres.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![L'espacement des caractères dans le paragraphe](character_spacing_in_paragraph.png)

L'exemple de code ci-dessous montre comment élargir l'espacement des caractères dans les **portions de texte avec une police en gras** :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Remarque: utilisez des valeurs négatives pour compresser l'espacement des caractères.
            portion.portion_format.spacing = 3  # Augmenter l'espacement des caractères.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![L'espacement des caractères dans les portions de texte](character_spacing_in_text_portions.png)

### **Désactiver le crénage pour des polices spécifiques**

Dans certains cas, le texte rendu par Aspose.Slides peut sembler légèrement plus serré que le même texte affiché dans PowerPoint. Cela peut se produire parce que PowerPoint peut ignorer les données de crénage pour certaines polices, même si la police contient des informations de crénage valides et que le crénage est activé dans les paramètres de PowerPoint.

Pour rendre la sortie rendue plus proche de PowerPoint dans ces cas, vous pouvez désactiver le crénage pour les portions de texte qui utilisent la police concernée. Définissez [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) à une valeur supérieure à la taille réelle de la police. Cet exemple nécessite « presentation.pptx » avec une zone de texte comme première forme de la première diapositive. Il vérifie les noms de police effectifs, y compris les polices héritées, et définit un seuil de 100 points pour les portions qui utilisent Roboto. Cela désactive le crénage pour les portions correspondantes dont la taille de police est inférieure à 100 points :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Pour le texte correspondant en dessous du seuil, ce paramètre empêche le crénage et peut aider à aligner le rendu d'Aspose.Slides avec la sortie visuelle de PowerPoint pour les polices affectées par ce comportement spécifique à PowerPoint.

## **Gérer les propriétés de police du texte**

Les propriétés de police peuvent être définies au niveau du paragraphe via [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) ou sur des portions individuelles via [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

L'exemple suivant définit la police par défaut du premier paragraphe à Times New Roman 12 points avec du gras, de l'italique et un soulignement pointillé. Le formatage explicite sur les portions individuelles a priorité sur ces valeurs par défaut.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Définir les propriétés de police pour le paragraphe.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Les propriétés de police du paragraphe](font_properties_for_paragraph.png)

L'exemple suivant applique Times New Roman 13 points, du formatage italique et un soulignement pointillé aux portions dont le formatage effectif est gras :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Définir les propriétés de police pour la portion de texte.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Les propriétés de police des portions de texte](font_properties_for_text_portions.png)

## **Définir la rotation du texte**

Utilisez [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) pour définir une orientation de texte prédéfinie à l'intérieur d'une forme.

L'exemple de code suivant définit l'orientation du texte dans la forme sur [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), ce qui fait pivoter le texte de **90 degrés dans le sens inverse des aiguilles d'une montre** :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![La rotation du texte](text_rotation.png)

## **Définir une rotation personnalisée pour les cadres de texte**

Utilisez [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) pour définir un angle de rotation personnalisé pour un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

L'exemple de code ci-dessous fait pivoter le cadre de texte de 3 degrés dans le sens des aiguilles d'une montre à l'intérieur de la forme :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![La rotation personnalisée du texte](custom_text_rotation.png)

## **Définir l'espacement des lignes des paragraphes**

Aspose.Slides propose [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/), et [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) pour contrôler l'espacement des paragraphes. Ces propriétés sont utilisées comme suit :

* Utilisez une valeur positive pour spécifier l'espacement des lignes en pourcentage de la hauteur de ligne.  
* Utilisez une valeur négative pour spécifier l'espacement des lignes en points.

L'exemple suivant définit l'espacement à l'intérieur du premier paragraphe à 200 % de la hauteur de ligne (double interligne) :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![L'espacement des lignes dans le paragraphe](line_spacing.png)

## **Contrôler la césure des lignes**

Les règles de césure des lignes de paragraphe sont utiles dans les blocs de texte étroits et les présentations qui mélangent du texte latin et est‑asiatique. Les propriétés suivantes appartiennent à [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), elles s'appliquent donc à un paragraphe entier :

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) contrôle les règles de césure du texte latin. Dans un texte mixte, le modifier peut également changer la façon dont le texte est‑asiatique adjacent et la ponctuation sont renvoyés à la ligne.  
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) contrôle les règles de césure du texte est‑asiatique, y compris les restrictions sur les caractères au début et à la fin d’une ligne.

Ces règles ne remplacent pas [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), qui active le retour à la ligne automatique dans un cadre de texte. Elles influencent la mise en page lorsque le retour à la ligne se produit ; elles n'insèrent pas de caractères de saut de ligne. Un saut de ligne explicite force une nouvelle ligne dans le paragraphe indépendamment de la largeur disponible.

L'exemple autonome suivant crée un bloc de texte étroit contenant du texte chinois et latin. Il définit explicitement les deux propriétés de césure et enregistre « line_breaking.pptx ». Pour expérimenter l'une ou l'autre règle, modifiez la valeur de cette propriété tout en maintenant les autres paramètres fixes. L'exemple utilise Arial 24 points et SimSun avec une largeur de cadre de 160 points et des marges horizontales du cadre à zéro. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) est réglé sur [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) afin que la taille du texte et les dimensions du cadre restent fixes.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **Contrôler la ponctuation suspendue**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) permet à la ponctuation admissible de dépasser le bord droit de la ligne de texte au lieu d'occuper la ligne suivante. Elle s'applique à l'ensemble du paragraphe et diffère d'un retrait suspendu.

L'exemple autonome suivant active la ponctuation suspendue dans un cadre de texte de 100 points de large et enregistre « hanging_punctuation.pptx ». Avec Arial 24 points et des marges horizontales du cadre à zéro, le point final reste après « sentence » et dépasse le bord droit du texte. Réglez la propriété sur [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) pour comparer : avec ces paramètres, le point occupe une ligne séparée. Le retour à la ligne est activé et l'ajustement automatique désactivé afin de maintenir la largeur disponible fixe.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

Toutes les marques de ponctuation ne peuvent pas être suspendues. Le résultat visible dépend des [conditions de police et de mise en page](#control-line-breaking) : modifier la police, la largeur disponible, les marges ou les paramètres d'ajustement automatique peut supprimer la différence visible.

## **Définir le type d'ajustement automatique pour les cadres de texte**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) détermine le comportement du texte lorsqu'il dépasse les limites de son conteneur. Utilisez-le pour contrôler si le texte se réduit, déborde ou redimensionne automatiquement la forme. L'exemple suivant configure la forme pour qu'elle redimensionne afin de s'adapter à son texte et enregistre le résultat dans « autofit_type.pptx ».

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Pour compter les lignes après le retour à la ligne automatique et voir comment la largeur du texte ou de la forme modifie le résultat, consultez [Count Rendered Lines](/slides/fr/python-net/manage-paragraph/). Le nombre de lignes seul n'indique pas si le texte dépasse son conteneur.

## **Définir l'ancre des cadres de texte**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) définit comment le texte est positionné verticalement à l'intérieur d'une forme, par exemple en haut, au milieu ou en bas. L'exemple suivant ancre le texte au bas de la première forme et enregistre le résultat dans « text_anchor.pptx ».

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la tabulation du texte**

Utilisez [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) et [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) pour configurer les tabulations dans un paragraphe. L'exemple suivant fixe l'intervalle de tabulation par défaut à 100 points et ajoute une tabulation alignée à gauche à 30 points. Ces paramètres affectent le texte contenant des caractères de tabulation.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Les tabulations du paragraphe](paragraph_tabs.png)

## **Définir la langue de vérification**

Aspose.Slides propose [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), qui vous permet de définir la langue de vérification pour une portion de texte. La langue de vérification détermine la langue utilisée pour les vérifications orthographiques et grammaticales dans PowerPoint.

L'exemple suivant nécessite « presentation.pptx » avec une zone de texte comme première forme de la première diapositive et au moins un paragraphe. Il remplace le contenu du premier paragraphe par « 1。 », définit SimSun comme police, et attribue la langue de vérification chinois simplifié (`zh-CN`). Il enregistre le résultat dans « proofing_language.pptx » :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Définir la langue de vérification sur le chinois simplifié.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la langue par défaut**

Utilisez [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) pour définir la langue par défaut du texte créé lors du chargement ou de la création d'une présentation. L'exemple suivant crée une présentation avec l'anglais des États‑Unis comme langue de texte par défaut, ajoute une zone de texte, et affiche `en-US` pour sa première portion de texte.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Ajouter une nouvelle forme rectangulaire avec du texte.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Vérifier la langue de la première portion.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Définir le style de texte par défaut**

Pour appliquer le formatage de texte par défaut au niveau de la présentation, utilisez [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

L'exemple suivant définit une police en gras de 14 points comme valeur par défaut pour les paragraphes de niveau supérieur dans une nouvelle présentation et l'enregistre sous « default_text_style.pptx ». Le texte peut hériter de ces valeurs par défaut à moins qu'un formatage plus spécifique ne les remplace.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Obtenir le format de paragraphe de niveau supérieur.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Extraire le texte avec l'effet tout en majuscules**

Dans PowerPoint, appliquer l’effet de police **All Caps** fait apparaître le texte en majuscules sur la diapositive même s'il a été tapé initialement en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu’il a été saisi. Pour faire correspondre le texte affiché, vérifiez [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) et convertissez la chaîne renvoyée en majuscules lorsque la valeur est `ALL`.

Cet exemple nécessite « sample2.pptx » avec une zone de texte comme première forme de la première diapositive. La première portion du premier paragraphe contient « Hello, Aspose! » avec l’effet All Caps appliqué, comme indiqué ci-dessous.

![L'effet All Caps](all_caps_effect.png)

L'exemple de code ci-dessous montre comment extraire le texte avec l'effet **All Caps** appliqué :

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

Sortie :

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Comment modifier le texte dans un tableau sur une diapositive ?**

Pour modifier le texte dans un tableau sur une diapositive, utilisez [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Parcourez les cellules et mettez à jour chaque cellule via [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) et le formatage de paragraphe via [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Comment appliquer une couleur dégradée au texte sur une diapositive PowerPoint ?**

Pour appliquer une couleur dégradée au texte, utilisez [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Définissez [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) sur [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) et configurez les arrêts du dégradé, la direction et la transparence.