---
title: Formater le texte PowerPoint en Python
linktitle: Formatage du texte
type: docs
weight: 50
url: /fr/python-net/text-formatting/
keywords:
- mettre en surbrillance le texte
- expression régulière
- aligner un paragraphe
- style de texte
- arrière‑plan du texte
- transparence du texte
- espacement des caractères
- propriétés de la police
- famille de polices
- rotation du texte
- angle de rotation
- cadre de texte
- interligne
- propriété d'ajustement automatique
- ancrage du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment formater et styliser du texte dans des présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides for Python via .NET. Personnalisez les polices, les couleurs, l'alignement et bien plus encore grâce à de puissants exemples de code Python."
---

## **Surligner le texte**
Une nouvelle méthode HighlightText a été ajoutée à l'interface ITextFrame et à la classe TextFrame.

Elle permet de surligner une partie du texte avec une couleur de fond en utilisant un exemple de texte, similaire à l'outil Couleur de surlignage de texte dans PowerPoint 2019.

Le code ci-dessous montre comment utiliser cette fonctionnalité :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "SomePresentation.pptx") as presentation:
    presentation.slides[0].shapes[0].text_frame.highlight_text("title", draw.Color.light_blue)

    opts = slides.TextHighlightingOptions()
    opts.whole_words_only = True
    presentation.slides[0].shapes[0].text_frame.highlight_text("to", draw.Color.violet, opts)

    presentation.save("SomePresentation-out2.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

Aspose fournit un service de [modification de PowerPoint en ligne gratuit](https://products.aspose.app/slides/editor).

{{% /alert %}} 


## **Surligner le texte en utilisant une expression régulière**
Une nouvelle méthode HighlightRegex a été ajoutée à l'interface ITextFrame et à la classe TextFrame.

Elle permet de surligner une partie du texte avec une couleur de fond en utilisant une regex, similaire à l'outil Couleur de surlignage de texte dans PowerPoint 2019.

Le code ci-dessous montre comment utiliser cette fonctionnalité :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "SomePresentation.pptx") as presentation:
    options = slides.TextHighlightingOptions()

    presentation.slides[0].shapes[0].text_frame.highlight_regex("\\b[^\s]{5,}\\b", draw.Color.blue, options) 
    presentation.save("SomePresentation-out3.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir la couleur de fond du texte**

Aspose.Slides vous permet de spécifier votre couleur préférée pour l'arrière-plan d'un texte.

Ce code Python vous montre comment définir la couleur d'arrière-plan pour un texte entier :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Noir")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Rouge ")
    
    portion3 = slides.Portion("Noir")
    portion3.portion_format.font_bold = 1
    
    para.portions.add(portion1)
    para.portions.add(portion2)
    para.portions.add(portion3)
    autoShape.text_frame.paragraphs.add(para)
    
    pres.save("text.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("text.pptx") as pres:
    autoShape = pres.slides[0].shapes[0]

    for portion in autoShape.text_frame.paragraphs[0].portions:
        portion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```

Ce code Python vous montre comment définir la couleur d'arrière-plan pour seulement une partie d'un texte :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Noir")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Rouge ")
    
    portion3 = slides.Portion("Noir")
    portion3.portion_format.font_bold = 1
    
    para.portions.add(portion1)
    para.portions.add(portion2)
    para.portions.add(portion3)
    autoShape.text_frame.paragraphs.add(para)
    
    pres.save("text.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("text.pptx") as pres:
    autoShape = pres.slides[0].shapes[0]

    for portion in autoShape.text_frame.paragraphs[0].portions:
        print (portion.text)

    redPortion = list(p for p in autoShape.text_frame.paragraphs[0].portions if 'Rouge' in p.text)[0]
    redPortion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```


## **Aligner les paragraphes de texte**
La mise en forme du texte est l'un des éléments clés lors de la création de tout type de document ou de présentation. Nous savons qu'Aspose.Slides pour Python via .NET prend en charge l'ajout de texte aux diapositives, mais dans ce sujet, nous verrons comment nous pouvons contrôler l'alignement des paragraphes de texte dans une diapositive. Veuillez suivre les étapes ci-dessous pour aligner les paragraphes de texte à l'aide d'Aspose.Slides pour Python via .NET :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez la référence d'une diapositive en utilisant son index.
3. Accédez aux formes de l'espace réservé présentes dans la diapositive et convertissez-les en AutoShape.
4. Obtenez le paragraphe (qui doit être aligné) du TextFrame exposé par l'AutoShape.
5. Alignez le paragraphe. Un paragraphe peut être aligné à droite, à gauche, au centre et justifié.
6. Écrivez la présentation modifiée sous forme de fichier PPTX.

L'implémentation de ces étapes est donnée ci-dessous.

```py
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier PPTX
with slides.Presentation(path + "ParagraphsAlignment.pptx") as presentation:
    # Accéder à la première diapositive
    slide = presentation.slides[0]

    # Accéder au premier et au deuxième espace réservé dans la diapositive et les convertir en AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # Modifier le texte dans les deux espaces réservés
    tf1.text = "Alignement central par Aspose"
    tf2.text = "Alignement central par Aspose"

    # Obtenir le premier paragraphe des espaces réservés
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # Aligner le paragraphe de texte au centre
    para1.paragraph_format.alignment = slides.TextAlignment.CENTER
    para2.paragraph_format.alignment = slides.TextAlignment.CENTER

    # Écrire la présentation sous forme de fichier PPTX
    presentation.save("Centeralign_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir la transparence pour le texte**
Cet article démontre comment définir la propriété de transparence pour toute forme de texte à l'aide d'Aspose.Slides pour Python via .NET. Afin de définir la transparence sur le texte. Veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez la référence d'une diapositive.
3. Définissez la couleur d'ombre.
4. Écrivez la présentation sous forme de fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "transparency.pptx") as pres:
    shape = pres.slides[0].shapes[0]
    effects = shape.text_frame.paragraphs[0].portions[0].portion_format.effect_format

    outerShadowEffect = effects.outer_shadow_effect

    shadowColor = outerShadowEffect.shadow_color.color
    print("{color} - la transparence est : {value}".format(color = shadowColor, value = (shadowColor.a / 255) * 100))
    # définir la transparence à zéro pour cent
    outerShadowEffect.shadow_color.color = draw.Color.from_argb(255, shadowColor)

    pres.save("transparency-2.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir l'espacement des caractères pour le texte**

Aspose.Slides vous permet de définir l'espace entre les lettres dans une zone de texte. De cette manière, vous pouvez ajuster la densité visuelle d'une ligne ou d'un bloc de texte en élargissant ou en condensant l'espacement entre les caractères.

Ce code Python vous montre comment élargir l'espacement pour une ligne de texte et condenser l'espacement pour une autre ligne : 

```python
import aspose.slides as slides

with slides.Presentation("in.pptx") as pres:

    textBox1 = pres.slides[0].shapes[0]
    textBox2 = pres.slides[0].shapes[1]

    textBox1.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = 20 # élargir
    textBox2.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = -2 # condenser

    pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```


## **Gérer les propriétés de police des paragraphes**
Les présentations contiennent généralement à la fois du texte et des images. Le texte peut être formaté de plusieurs manières, soit pour mettre en évidence des sections et des mots spécifiques, soit pour se conformer à des styles d'entreprise. La mise en forme du texte aide les utilisateurs à varier l'apparence et la convivialité du contenu de la présentation. Cet article montre comment utiliser Aspose.Slides pour Python via .NET pour configurer les propriétés de police des paragraphes de texte sur les diapositives. Pour gérer les propriétés de police d'un paragraphe à l'aide d'Aspose.Slides pour Python via .NET :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence de la diapositive en utilisant son index.
1. Accédez aux formes de l'espace réservé dans la diapositive et convertissez-les en AutoShape.
1. Obtenez le paragraphe du TextFrame exposé par l'AutoShape.
1. Justifiez le paragraphe.
1. Accédez à la portion de texte d'un paragraphe.
1. Définissez la police à l'aide de FontData et définissez la police de la portion de texte en conséquence.
   1. Définissez la police en gras.
   1. Définissez la police en italique.
1. Définissez la couleur de police à l'aide du FillFormat exposé par l'objet Portion.
1. Écrivez la présentation modifiée dans un fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

L'implémentation de ces étapes est donnée ci-dessous. Elle prend une présentation non décorée et formate les polices sur l'une des diapositives.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier un objet Presentation qui représente un fichier PPTX
with slides.Presentation(path + "FontProperties.pptx") as pres:
    # Accéder à une diapositive en utilisant sa position dans la diapositive
    slide = pres.slides[0]

    # Accéder au premier et au deuxième espace réservé dans la diapositive et les convertir en AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # Accéder au premier paragraphe
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # Accéder à la première portion
    port1 = para1.portions[0]
    port2 = para2.portions[0]

    # Définir de nouvelles polices
    fd1 = slides.FontData("Éléphant")
    fd2 = slides.FontData("Castellar")

    # Assigner de nouvelles polices à la portion
    port1.portion_format.latin_font = fd1
    port2.portion_format.latin_font = fd2

    # Définir la police en gras
    port1.portion_format.font_bold = 1
    port2.portion_format.font_bold = 1

    # Définir la police en italique
    port1.portion_format.font_italic = 1
    port2.portion_format.font_italic = 1

    # Définir la couleur de police
    port1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port1.portion_format.fill_format.solid_fill_color.color = draw.Color.purple
    port2.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port2.portion_format.fill_format.solid_fill_color.color = draw.Color.peru

    # Écrire le PPTX sur disque
    pres.save("WelcomeFont_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Gérer la famille de polices du texte**
Une portion est utilisée pour contenir du texte avec un style de formatage similaire dans un paragraphe. Cet article montre comment utiliser Aspose.Slides pour Python pour créer une zone de texte avec du texte, puis définir une police particulière et diverses autres propriétés de la catégorie de police. Pour créer une zone de texte et définir les propriétés de la police du texte à l'intérieur :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez la référence d'une diapositive en utilisant son index.
3. Ajoutez une AutoShape de type Rectangle à la diapositive.
4. Supprimez le style de remplissage associé à l'AutoShape.
5. Accédez au TextFrame de l'AutoShape.
6. Ajoutez du texte au TextFrame.
7. Accédez à l'objet Portion associé au TextFrame.
8. Définissez la police à utiliser pour la Portion.
9. Réglez d'autres propriétés de police telles que gras, italique, souligner, couleur et hauteur à l'aide des propriétés appropriées exposées par l'objet Portion.
10. Écrivez la présentation modifiée sous forme de fichier PPTX.

L'implémentation de ces étapes est donnée ci-dessous.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier Presentation
with slides.Presentation() as presentation:
    # Obtenir la première diapositive
    sld = presentation.slides[0]

    # Ajouter une AutoShape de type Rectangle
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)

    # Supprimer tout style de remplissage associé à l'AutoShape
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Accéder au TextFrame associé à l'AutoShape
    tf = ashp.text_frame
    tf.text = "Zone de texte Aspose"

    # Accéder à la Portion associée au TextFrame
    port = tf.paragraphs[0].portions[0]

    # Définir la police pour la Portion
    port.portion_format.latin_font = slides.FontData("Times New Roman")

    # Définir la propriété gras de la police
    port.portion_format.font_bold = 1

    # Définir la propriété italique de la police
    port.portion_format.font_italic = 1

    # Définir la propriété soulignée de la police
    port.portion_format.font_underline = slides.TextUnderlineType.SINGLE

    # Définir la hauteur de la police
    port.portion_format.font_height = 25

    # Définir la couleur de la police
    port.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Écrire le PPTX sur disque 
    presentation.save("SetTextFontProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir la taille de police pour le texte**

Aspose.Slides vous permet de choisir votre taille de police préférée pour le texte existant dans un paragraphe et tout autre texte qui peut être ajouté au paragraphe ultérieurement.

Ce code Python vous montre comment définir la taille de police pour les textes contenus dans un paragraphe : 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:

    # Obtient la première forme, par exemple.
    shape = presentation.slides[0].shapes[0]

    if type(shape) is slides.AutoShape:
        # Obtient le premier paragraphe, par exemple.
        paragraph = shape.text_frame.paragraphs[0]

        # Définit la taille de police par défaut à 20 pt pour toutes les portions de texte dans le paragraphe. 
        paragraph.paragraph_format.default_portion_format.font_height = 20

        # Définit la taille de police à 20 pt pour les portions de texte actuelles dans le paragraphe. 
        for portion in paragraph.portions:
            portion.portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)

```


## **Définir la rotation du texte**
Aspose.Slides pour Python via .NET permet aux développeurs de faire tourner le texte. Le texte peut être défini pour apparaître horizontalement, verticalement, verticalement à 270°, VerticalWordArt, VerticalEstAsiatique, VerticalMongol ou VerticalWordArtDeDroiteÀGauche. Pour faire tourner le texte de tout TextFrame, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accédez à la première diapositive.
3. Ajoutez toute forme à la diapositive.
4. Accédez au TextFrame.
5. Faites tourner le texte.
6. Enregistrez le fichier sur le disque.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Créer une instance de la classe Presentation
with slides.Presentation() as presentation:
    # Obtenir la première diapositive 
    slide = presentation.slides[0]

    # Ajouter une AutoShape de type Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Ajouter un TextFrame au rectangle
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Accéder au cadre de texte
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Créer l'objet Paragraphe pour le cadre de texte
    para = txtFrame.paragraphs[0]

    # Créer l'objet Portion pour le paragraphe
    portion = para.portions[0]
    portion.text = "Un renard brun rapide saute par-dessus le chien paresseux. Un renard brun rapide saute par-dessus le chien paresseux."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Enregistrer la présentation
    presentation.save("RotateText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir un angle de rotation personnalisé pour le TextFrame**
Aspose.Slides pour Python via .NET prend désormais en charge la définition d'un angle de rotation personnalisé pour le TextFrame. Dans ce sujet, nous verrons avec exemple comment définir la propriété RotationAngle dans Aspose.Slides. La nouvelle propriété RotationAngle a été ajoutée aux interfaces IChartTextBlockFormat et ITextFrameFormat, permettant de définir l'angle de rotation personnalisé pour le TextFrame. Pour définir la propriété RotationAngle, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Ajoutez un graphique sur la diapositive.
3. Définissez la propriété RotationAngle.
4. Écrivez la présentation sous forme de fichier PPTX.

Dans l'exemple ci-dessous, nous définissons la propriété RotationAngle.

```py
import aspose.slides as slides

# Créer une instance de la classe Presentation
with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.text_format.text_block_format.rotation_angle = 65

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Titre personnalisé").text_frame_format.rotation_angle = -30

    # Enregistrer la présentation
    presentation.save("textframe-rotation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Interligne des Paragraphes**
Aspose.Slides fournit des propriétés sous `paragraph_format`—`space_after`, `space_before` et `space_within`—qui vous permettent de gérer l'interligne d'un paragraphe. Les trois propriétés sont utilisées comme suit :

* Pour spécifier l'interligne d'un paragraphe en pourcentage, utilisez une valeur positive. 
* Pour spécifier l'interligne d'un paragraphe en points, utilisez une valeur négative.

Par exemple, vous pouvez appliquer un interligne de 16 pt pour un paragraphe en définissant la propriété `space_before` à -16.

Voici comment vous spécifiez l'interligne pour un paragraphe spécifique :

1. Chargez une présentation contenant une AutoShape avec du texte à l'intérieur.
2. Obtenez la référence d'une diapositive par son index.
3. Accédez au TextFrame.
4. Accédez au Paragraphe.
5. Définissez les propriétés du Paragraphe.
6. Enregistrez la présentation.

Ce code Python vous montre comment spécifier l'interligne pour un paragraphe :

```py
import aspose.slides as slides

# Créer une instance de la classe Presentation
with slides.Presentation(path + "Fonts.pptx") as presentation:

    # Obtenez la référence d'une diapositive par son index
    sld = presentation.slides[0]

    # Accédez au TextFrame
    tf1 = sld.shapes[0].text_frame

    # Accédez au Paragraphe
    para1 = tf1.paragraphs[0]

    # Définissez les propriétés du Paragraphe
    para1.paragraph_format.space_within = 80
    para1.paragraph_format.space_before = 40
    para1.paragraph_format.space_after = 40
    # Enregistrez la présentation
    presentation.save("LineSpacing_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir la propriété AutofitType pour le TextFrame**
Dans ce sujet, nous allons explorer les différentes propriétés de mise en forme du cadre de texte. Cet article couvre comment définir la propriété AutofitType du cadre de texte, ancrer le texte et faire pivoter le texte dans une présentation. Aspose.Slides pour Python via .NET permet aux développeurs de définir la propriété AutofitType de tout cadre de texte. L'AutofitType peut être défini sur Normal ou Shape. S'il est défini sur Normal, la forme restera la même alors que le texte sera ajusté sans que la forme ne change elle-même, tandis que si l'AutofitType est défini sur Shape, la forme sera modifiée de sorte que seul le texte requis soit contenu à l'intérieur. Pour définir la propriété AutofitType d'un cadre de texte, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accédez à la première diapositive.
3. Ajoutez toute forme à la diapositive.
4. Accédez au TextFrame.
5. Définissez l'AutofitType du TextFrame.
6. Enregistrez le fichier sur le disque.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Créer une instance de la classe Presentation
with slides.Presentation() as presentation:

    # Accédez à la première diapositive 
    slide = presentation.slides[0]

    # Ajouter une AutoShape de type Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Ajouter un TextFrame au rectangle
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Accéder au cadre de texte
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # Créer l'objet Paragraphe pour le cadre de texte
    para = txtFrame.paragraphs[0]

    # Créer l'objet Portion pour le paragraphe
    portion = para.portions[0]
    portion.text = "Un renard brun rapide saute par-dessus le chien paresseux. Un renard brun rapide saute par-dessus le chien paresseux."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Enregistrer la présentation
    presentation.save("formatText_out.pptx", slides.export.SaveFormat.PPTX) 
```


## **Définir l'ancrage du TextFrame**
Aspose.Slides pour Python via .NET permet aux développeurs d'ancrer tout TextFrame. TextAnchorType spécifie où ce texte est placé dans la forme. TextAnchorType peut être défini sur Top, Center, Bottom, Justifié ou Distribué. Pour définir l'ancrage de tout TextFrame, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accédez à la première diapositive.
3. Ajoutez toute forme à la diapositive.
4. Accédez au TextFrame.
5. Définissez le TextAnchorType du TextFrame.
6. Enregistrez le fichier sur le disque.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Créer une instance de la classe Presentation
with slides.Presentation() as presentation:
    # Obtenez la première diapositive 
    slide = presentation.slides[0]

    # Ajouter une AutoShape de type Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Ajouter un TextFrame au rectangle
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Accéder au cadre de texte
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    # Créer l'objet Paragraphe pour le cadre de texte
    para = txtFrame.paragraphs[0]

    # Créer l'objet Portion pour le paragraphe
    portion = para.portions[0]
    portion.text = "Un renard brun rapide saute par-dessus le chien paresseux. Un renard brun rapide saute par-dessus le chien paresseux."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Enregistrer la présentation
    presentation.save("AnchorText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir la tabulation du texte**
- La propriété EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égale à Tabs.Count.
- La collection EffectiveTabs comprend tous les onglets (de la collection Tabs et des onglets par défaut)
- La propriété EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égale à Tabs.Count.
- La propriété EffectiveTabs.DefaultTabSize (294) montre la distance entre les onglets par défaut (3 et 4 dans notre exemple).
- EffectiveTabs.GetTabByIndex(index) avec index = 0 renverra le premier onglet explicite (Position = 731), index = 1 - le deuxième onglet (Position = 1241). Si vous essayez d'obtenir l'onglet suivant avec index = 2, cela renverra le premier onglet par défaut (Position = 1470) et ainsi de suite.
- EffectiveTabs.GetTabAfterPosition(pos) est utilisé pour obtenir la prochaine tabulation après un certain texte. Par exemple, vous avez le texte : "Helloworld !". Pour rendre ce texte, vous devez savoir où commencer à dessiner "world !". Tout d'abord, vous devez calculer la longueur de "Hello" en pixels et appeler GetTabAfterPosition avec cette valeur. Vous obtiendrez la position de l'onglet suivante pour dessiner "world !".

## **Définir le style de texte par défaut**

Si vous avez besoin d'appliquer le même formatage de texte par défaut à tous les éléments de texte d'une présentation à la fois, vous pouvez utiliser la propriété `default_text_style` de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et définir le formatage préféré. L'exemple de code ci-dessous montre comment définir la police en gras par défaut (14 pt) pour le texte sur toutes les diapositives d'une nouvelle présentation.

```py
with slides.Presentation() as presentation:
    # Obtenir le format du paragraphe de premier niveau.
    paragraphFormat = presentation.default_text_style.get_level(0)

    if paragraphFormat is not None:
        paragraphFormat.default_portion_format.font_height = 14
        paragraphFormat.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("DefaultTextStyle.pptx", slides.export.SaveFormat.PPTX)
```