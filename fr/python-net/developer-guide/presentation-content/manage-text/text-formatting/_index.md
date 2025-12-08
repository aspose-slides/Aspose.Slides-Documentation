---
title: Formater le texte PowerPoint en Python
linktitle: Mise en forme du texte
type: docs
weight: 50
url: /fr/python-net/text-formatting/
keywords:
- surligner le texte
- expression régulière
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
- interligne
- propriété autofit
- ancre du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à formater et styliser le texte dans les présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour Python via .NET. Personnalisez les polices, les couleurs, l'alignement et bien plus avec des exemples de code Python puissants."
---

## **Surligner le texte**

La méthode `highlight_text` de la classe [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) vous permet de surligner une partie du texte avec une couleur d'arrière-plan en utilisant un exemple de texte, similaire à l'outil Couleur de surbrillance du texte dans PowerPoint 2019.

Le fragment de code suivant montre comment utiliser cette fonctionnalité :
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("SomePresentation.pptx") as presentation:
    presentation.slides[0].shapes[0].text_frame.highlight_text("title", draw.Color.light_blue)

    opts = slides.TextHighlightingOptions()
    opts.whole_words_only = True
    presentation.slides[0].shapes[0].text_frame.highlight_text("to", draw.Color.violet, opts)

    presentation.save("SomePresentation-out2.pptx", slides.export.SaveFormat.PPTX)
```


## **Surligner le texte à l'aide d'expressions régulières**

La méthode `highlight_regex` de la classe [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) vous permet de surligner une portion de texte avec une couleur d'arrière-plan en utilisant une expression régulière, similaire à l'outil Couleur de surbrillance du texte dans PowerPoint 2019.

Le fragment de code ci‑dessous montre comment utiliser cette fonctionnalité :
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("SomePresentation.pptx") as presentation:
    options = slides.TextHighlightingOptions()

    presentation.slides[0].shapes[0].text_frame.highlight_regex("\\b[^\\s]{5,}\\b", draw.Color.blue, options) 
    presentation.save("SomePresentation-out3.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir la couleur d'arrière-plan du texte**

Aspose.Slides vous permet de spécifier votre couleur d'arrière-plan préférée pour le texte. Le code Python ci‑dessous montre comment définir la couleur d'arrière-plan pour l'ensemble du texte :
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Black")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Red ")
    
    portion3 = slides.Portion("Black")
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


Ce code Python montre comment définir la couleur d'arrière-plan pour seulement une partie du texte :
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Black")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Red ")
    
    portion3 = slides.Portion("Black")
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

    redPortion = list(p for p in autoShape.text_frame.paragraphs[0].portions if 'Red' in p.text)[0]
    redPortion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```


## **Aligner les paragraphes de texte**

Le formatage du texte est un élément clé lors de la création de documents ou de présentations. Aspose.Slides for Python via .NET prend en charge l'ajout de texte aux diapositives ; dans cette section, nous verrons comment contrôler l'alignement des paragraphes dans une diapositive. Suivez ces étapes pour aligner les paragraphes de texte à l'aide d'Aspose.Slides for Python via .NET :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Accédez aux formes de remplacement sur la diapositive et convertissez‑les en [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. À partir du [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) exposé par l'[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), récupérez le paragraphe qui doit être aligné.
1. Alignez le paragraphe. Un paragraphe peut être aligné `LEFT`, `RIGHT`, `CENTER`, `JUSTIFY`, `JUSTIFY_LOW` ou `DISTRIBUTED`.
1. Enregistrez la présentation modifiée en tant que fichier PPTX.

L’implémentation de ces étapes est montrée ci‑dessous.
```py
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier PPTX
with slides.Presentation("ParagraphsAlignment.pptx") as presentation:
    # Accéder à la première diapositive
    slide = presentation.slides[0]

    # Accéder aux premier et deuxième espaces réservés dans la diapositive et les convertir en AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # Modifier le texte dans les deux espaces réservés
    tf1.text = "Center Align by Aspose"
    tf2.text = "Center Align by Aspose"

    # Obtenir le premier paragraphe des espaces réservés
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # Aligner le paragraphe de texte au centre
    para1.paragraph_format.alignment = slides.TextAlignment.CENTER
    para2.paragraph_format.alignment = slides.TextAlignment.CENTER

    #Écrire la présentation au format PPTX
    presentation.save("Centeralign_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir la transparence du texte**

Cette section montre comment définir la propriété de transparence pour n’importe quelle forme de texte à l’aide d’Aspose.Slides for Python via .NET. Pour définir la transparence du texte, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive.
1. Définissez la couleur de l’ombre.
1. Enregistrez la présentation en tant que fichier PPTX.

L’implémentation de ces étapes est donnée ci‑dessus.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("transparency.pptx") as pres:
    shape = pres.slides[0].shapes[0]
    effects = shape.text_frame.paragraphs[0].portions[0].portion_format.effect_format

    outerShadowEffect = effects.outer_shadow_effect

    shadowColor = outerShadowEffect.shadow_color.color
    print("{color} - transparency is: {value}".format(color = shadowColor, value = (shadowColor.a / 255) * 100))
    # définir la transparence à zéro pour cent
    outerShadowEffect.shadow_color.color = draw.Color.from_argb(255, shadowColor)

    pres.save("transparency-2.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir l'espacement des caractères du texte**

Aspose.Slides vous permet d’ajuster l’espacement entre les lettres d’une zone de texte. Cela permet de contrôler la densité visuelle d’une ligne ou d’un bloc de texte en élargissant ou en condensant l’espacement entre les caractères.

L’exemple Python ci‑dessous montre comment élargir l’espacement pour une ligne de texte et le condenser pour une autre :
```python
import aspose.slides as slides

with slides.Presentation("in.pptx") as pres:

    textBox1 = pres.slides[0].shapes[0]
    textBox2 = pres.slides[0].shapes[1]

    textBox1.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = 20 # agrandir
    textBox2.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = -2 # condenser

    pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```


## **Gérer les propriétés de police des paragraphes**

Les présentations contiennent généralement du texte et des images. Le texte peut être formaté de diverses manières — pour mettre en évidence des sections ou des mots spécifiques ou pour se conformer aux styles d’entreprise. Le formatage du texte aide les utilisateurs à modifier l’aspect du contenu de la présentation.

Cette section montre comment utiliser Aspose.Slides for Python via .NET pour configurer les propriétés de police des paragraphes dans le texte d’une diapositive. Pour gérer les propriétés de police d’un paragraphe à l’aide d’Aspose.Slides for Python via .NET :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive en utilisant son index.
1. Accédez aux formes de remplacement sur la diapositive et convertissez‑les en [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Récupérez le paragraphe du [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) exposé par l’[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Justifiez le paragraphe.
1. Accédez à la partie texte du paragraphe.
1. Définissez la police à l’aide de [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/) et appliquez‑la à la partie texte.
   1. Définissez la police en gras.
   1. Définissez la police en italique.
1. Définissez la couleur de la police à l’aide du [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) exposé par l’objet [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/).
1. Enregistrez la présentation modifiée en tant que fichier PPTX.

L’implémentation des étapes ci‑dessus est présentée ci‑dessous. Elle prend une présentation simple et applique le formatage de police à l’une des diapositives.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier un objet Presentation qui représente un fichier PPTX
with slides.Presentation("FontProperties.pptx") as pres:
    # Accéder à une diapositive en utilisant sa position
    slide = pres.slides[0]

    # Accéder aux premier et deuxième espaces réservés dans la diapositive et les convertir en AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # Accéder au premier paragraphe
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # Accéder à la première portion
    port1 = para1.portions[0]
    port2 = para2.portions[0]

    # Définir de nouvelles polices
    fd1 = slides.FontData("Elephant")
    fd2 = slides.FontData("Castellar")

    # Assigner les nouvelles polices à la portion
    port1.portion_format.latin_font = fd1
    port2.portion_format.latin_font = fd2

    # Mettre la police en gras
    port1.portion_format.font_bold = 1
    port2.portion_format.font_bold = 1

    # Mettre la police en italique
    port1.portion_format.font_italic = 1
    port2.portion_format.font_italic = 1

    # Définir la couleur de la police
    port1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port1.portion_format.fill_format.solid_fill_color.color = draw.Color.purple
    port2.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port2.portion_format.fill_format.solid_fill_color.color = draw.Color.peru

    #Écrire le PPTX sur le disque
    pres.save("WelcomeFont_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Gérer la famille de polices du texte**

Les objets [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) sont utilisés pour contenir du texte avec un style de formatage similaire au sein d’un paragraphe. Cette section montre comment utiliser Aspose.Slides for Python pour créer une zone de texte, y ajouter du texte, puis définir une police spécifique ainsi que diverses autres propriétés de la famille de polices.

Pour créer une zone de texte et définir les propriétés de police du texte qu’elle contient :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) de type `RECTANGLE` à la diapositive.
1. Supprimez le style de remplissage associé à l’[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Accédez au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de l’AutoShape.
1. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Accédez à l’objet [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) associé au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Définissez la police à utiliser pour la [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/).
1. Définissez d’autres propriétés de police telles que gras, italique, souligné, couleur et taille à l’aide des propriétés exposées par l’objet [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/).
1. Enregistrez la présentation modifiée en tant que fichier PPTX.

L’implémentation des étapes ci‑dessus est présentée ci‑dessous.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier une présentation
with slides.Presentation() as presentation:
    # Obtenir la première diapositive
    sld = presentation.slides[0]

    # Ajouter une AutoShape de type rectangle
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)

    # Supprimer tout style de remplissage associé à l'AutoShape
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Accéder au TextFrame associé à l'AutoShape
    tf = ashp.text_frame
    tf.text = "Aspose TextBox"

    # Accéder à la Portion associée au TextFrame
    port = tf.paragraphs[0].portions[0]

    # Définir la police pour la Portion
    port.portion_format.latin_font = slides.FontData("Times New Roman")

    # Définir la propriété gras de la police
    port.portion_format.font_bold = 1

    # Définir la propriété italique de la police
    port.portion_format.font_italic = 1

    # Définir la propriété soulignement de la police
    port.portion_format.font_underline = slides.TextUnderlineType.SINGLE

    # Définir la hauteur de la police
    port.portion_format.font_height = 25

    # Définir la couleur de la police
    port.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Écrire le PPTX sur le disque 
    presentation.save("SetTextFontProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir la taille de la police du texte**

Aspose.Slides vous permet de spécifier la taille de police préférée pour le texte existant dans un paragraphe, ainsi que pour tout texte qui pourrait être ajouté ultérieurement au paragraphe.

Cet exemple Python montre comment définir la taille de police du texte contenu dans un paragraphe :
```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:

    # Obtient la première forme, par exemple.
    shape = presentation.slides[0].shapes[0]

    if type(shape) is slides.AutoShape:
        # Obtient le premier paragraphe, par exemple.
        paragraph = shape.text_frame.paragraphs[0]

        # Définit la taille de police par défaut à 20 pt pour toutes les portions de texte du paragraphe.
        paragraph.paragraph_format.default_portion_format.font_height = 20

        # Définit la taille de police à 20 pt pour les portions de texte actuelles du paragraphe.
        for portion in paragraph.portions:
            portion.portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)

```


## **Définir la rotation du texte**

Aspose.Slides for Python via .NET permet aux développeurs de faire pivoter le texte. Le texte peut être affiché comme `HORIZONTAL`, `VERTICAL`, `VERTICAL270`, `WORD_ART_VERTICAL`, `EAST_ASIAN_VERTICAL`, `MONGOLIAN_VERTICAL` ou `WORD_ART_VERTICAL_RIGHT_TO_LEFT`.

Pour faire pivoter le texte dans n’importe quel [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accédez à la première diapositive.
1. Ajoutez une forme à la diapositive.
1. Accédez au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Appliquez la rotation du texte souhaitée.
1. Enregistrez le fichier sur le disque.
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

    # Créer l'objet Paragraph pour le cadre de texte
    para = txtFrame.paragraphs[0]

    # Créer l'objet Portion pour le paragraphe
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Enregistrer la présentation
    presentation.save("RotateText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir un angle de rotation personnalisé pour un TextFrame**

Aspose.Slides for Python via .NET supporte la définition d’un angle de rotation personnalisé pour un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). Dans cette section, nous démontrons comment utiliser la propriété `rotation_angle` dans Aspose.Slides.

Pour définir la propriété `rotation_angle`, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Ajoutez un graphique à la diapositive.
1. Définissez la propriété `rotation_angle`.
1. Enregistrez la présentation en tant que fichier PPTX.

Dans l’exemple ci‑dessous, nous définissons la propriété `rotation_angle`.
```py
import aspose.slides as slides

# Créer une instance de la classe Presentation
with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.text_format.text_block_format.rotation_angle = 65

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Custom title").text_frame_format.rotation_angle = -30

    # Enregistrer la présentation
    presentation.save("textframe-rotation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir l'interligne des paragraphes**

Aspose.Slides fournit les propriétés `space_after`, `space_before` et `space_within` dans la classe [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) pour contrôler l’interligne d’un paragraphe. Ces propriétés fonctionnent comme suit :

* Pour spécifier l’interligne en pourcentage, utilisez une valeur positive.
* Pour spécifier l’interligne en points, utilisez une valeur négative.

Par exemple, pour appliquer un interligne de 16 pt avant un paragraphe, définissez la propriété `space_before` à `-16`.

Voici comment définir l’interligne pour un paragraphe spécifique :

1. Chargez une présentation contenant une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) avec du texte.
1. Obtenez une référence à la diapositive par son index.
1. Accédez au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Accédez au [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Définissez les propriétés du paragraphe souhaitées.
1. Enregistrez la présentation.

L’exemple Python suivant montre comment définir l’interligne d’un paragraphe :
```py
import aspose.slides as slides

# Créer une instance de la classe Presentation
with slides.Presentation("Fonts.pptx") as presentation:

    # Obtenir une référence à une diapositive par son index
    sld = presentation.slides[0]

    # Accéder au TextFrame
    tf1 = sld.shapes[0].text_frame

    # Accéder au paragraphe
    para1 = tf1.paragraphs[0]

    # Définir les propriétés du paragraphe
    para1.paragraph_format.space_within = 80
    para1.paragraph_format.space_before = 40
    para1.paragraph_format.space_after = 40
    # Enregistrer la présentation
    presentation.save("LineSpacing_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir la propriété AutofitType pour TextFrame**

Dans cette section, nous explorerons diverses propriétés de formatage d’un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), dont la définition de son `autofit_type`, le réglage de l’ancre du texte et la rotation du texte dans une présentation.

Aspose.Slides for Python via .NET permet aux développeurs de définir la propriété `autofit_type` de n’importe quel [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). Le `autofit_type` peut être réglé sur `NORMAL` ou `SHAPE` :

* Si réglé sur `NORMAL`, la forme reste inchangée tandis que le texte est ajusté pour tenir à l’intérieur.
* Si réglé sur `SHAPE`, la forme est redimensionnée pour ne contenir que le texte requis.

Pour définir la propriété `autofit_type` d’un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accédez à la première diapositive.
1. Ajoutez une forme à la diapositive.
1. Accédez au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Définissez le `autofit_type` pour le [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Enregistrez le fichier sur le disque.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Créer une instance de la classe Presentation
with slides.Presentation() as presentation:

    # Accéder à la première diapositive 
    slide = presentation.slides[0]

    # Ajouter une AutoShape de type Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Ajouter un TextFrame au rectangle
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Accéder au cadre de texte
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # Créer l'objet Paragraph pour le cadre de texte
    para = txtFrame.paragraphs[0]

    # Créer l'objet Portion pour le paragraphe
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Enregistrer la présentation
    presentation.save("formatText_out.pptx", slides.export.SaveFormat.PPTX) 
```


## **Définir l'ancre d'un TextFrame**

Aspose.Slides for Python via .NET permet aux développeurs de définir la position d’ancrage de n’importe quel [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). La propriété [TextAnchorType](https://reference.aspose.com/slides/python-net/aspose.slides/textanchortype/) indique où le texte est placé dans la forme. Elle peut être réglée sur `TOP`, `CENTER`, `BOTTOM`, `JUSTIFIED` ou `DISTRIBUTED`.

Pour définir l’ancre d’un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accédez à la première diapositive.
1. Ajoutez une forme à la diapositive.
1. Accédez au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Définissez le [TextAnchorType](https://reference.aspose.com/slides/python-net/aspose.slides/textanchortype/) pour le [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Enregistrez le fichier sur le disque.
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
    txtFrame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    # Créer l'objet Paragraph pour le cadre de texte
    para = txtFrame.paragraphs[0]

    # Créer l'objet Portion pour le paragraphe
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Enregistrer la présentation
    presentation.save("AnchorText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir le style de texte par défaut**

Si vous devez appliquer le même formatage de texte par défaut à tous les éléments texte d’une présentation, vous pouvez utiliser la propriété `default_text_style` de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et définir le formatage souhaité.

L’exemple ci‑dessus montre comment définir la police par défaut en gras, avec une taille de 14 pt, pour tout le texte de chaque diapositive d’une nouvelle présentation.
```py
with slides.Presentation() as presentation:
    # Obtenir le format de paragraphe de niveau supérieur.
    paragraphFormat = presentation.default_text_style.get_level(0)

    if paragraphFormat is not None:
        paragraphFormat.default_portion_format.font_height = 14
        paragraphFormat.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("DefaultTextStyle.pptx", slides.export.SaveFormat.PPTX)
```


## **Extraire le texte avec l'effet Tout en majuscules**

Dans PowerPoint, l’application de l’effet **All Caps** rend le texte affiché en majuscules sur la diapositive même s’il a été saisi en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu’il a été saisi. Pour gérer cela, vérifiez [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) — si elle indique `ALL`, convertissez simplement la chaîne renvoyée en majuscules afin que votre sortie corresponde à ce que les utilisateurs voient sur la diapositive.

Supposons que nous ayons la zone de texte suivante sur la première diapositive du fichier sample2.pptx.

![L'effet Tout en majuscules](all_caps_effect.png)

L’exemple de code ci‑dessous montre comment extraire le texte avec l’effet **All Caps** appliqué :
```py
with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```


Output:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


{{% alert color="primary" %}}

Aspose fournit un service simple et [gratuit d’édition en ligne de PowerPoint](https://products.aspose.app/slides/editor).

{{% /alert %}}

## **FAQ**

**Puis-je appliquer un formatage différent à des parties spécifiques du texte au sein d’un même paragraphe (par ex., mettre en gras seulement quelques mots), et comment cela interagit‑il avec les styles hérités des dispositions et des thèmes ?**

Oui. Le formatage est appliqué au niveau de la « partie de texte » à l’intérieur d’un paragraphe et remplace le style du thème/disposition uniquement pour ces fragments sélectionnés. Lorsque le thème change, seules les zones sans formatage local explicite seront mises à jour.

**Comment les polices fonctionnent‑elles sous Linux et dans les conteneurs Docker qui n’ont pas de polices système installées ?**

La bibliothèque utilise la découverte/substitution de polices. Sur les systèmes dépourvus de polices, vous devez explicitement [indiquer les répertoires de polices](/slides/fr/python-net/custom-font/) et/ou configurer une [table de substitution](/slides/fr/python-net/font-substitution/) pour éviter le recours à des polices inappropriées et les décalages de mise en page.

**En quoi le formatage du texte dans les espaces réservés diffère‑t‑il du formatage dans les formes automatiques classiques ?**

Les espaces réservés héritent plus fortement des styles du masque de diapositive et de la disposition que les formes automatiques classiques. Les modifications locales dans les espaces réservés sont possibles, mais lorsqu’une disposition change, elles reviennent plus souvent aux styles du thème à moins que vous n’ayez remplacé explicitement le formatage au niveau de la partie de texte.