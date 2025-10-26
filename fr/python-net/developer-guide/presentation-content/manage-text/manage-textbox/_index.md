---
title: Manage Text Boxes in Presentations with Python
linktitle: Manage Text Box
type: docs
weight: 20
url: /fr/python-net/developer-guide/presentation-content/manage-text/manage-textbox/
keywords:
- text box
- text frame
- add text
- update text
- create text box
- check text box
- add text column
- add hyperlink
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET makes it easy to create, edit, and clone text boxes in PowerPoint and OpenDocument files, enhancing your presentation automation."
---

## **Vue d'ensemble**

Les textes sur les diapositives se trouvent généralement dans des zones de texte ou des formes. Ainsi, pour ajouter du texte à une diapositive, vous devez d'abord ajouter une zone de texte, puis y placer du texte. Aspose.Slides for Python propose la classe [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) qui vous permet d'ajouter une forme contenant du texte.

{{% alert title="Info" color="info" %}}
Aspose.Slides fournit également la classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/). Cependant, toutes les formes ne peuvent pas contenir du texte.
{{% /alert %}}

{{% alert title="Remarque" color="warning" %}}
Par conséquent, lorsque vous travaillez avec une forme à laquelle vous souhaitez ajouter du texte, il est recommandé de vérifier et de confirmer qu'elle a été castée via la classe [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Ce n'est qu'ainsi que vous pourrez travailler avec [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), propriété de [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Voir la section [Update Text](/slides/fr/python-net/manage-textbox/#update-text) de cette page.
{{% /alert %}}

## **Créer des zones de texte sur les diapositives**

Pour créer une zone de texte sur une diapositive :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à la première diapositive.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) de type `ShapeType.RECTANGLE` à la position souhaitée sur la diapositive.
4. Définissez le texte dans le [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forme.
5. Enregistrez la présentation au format PPTX.

L'exemple Python suivant implémente ces étapes :

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Get the first slide in the presentation.
    slide = presentation.slides[0]

    # Add an AutoShape of type RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Save the presentation to disk.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Vérifier si une forme est une zone de texte**

Aspose.Slides propose la propriété [is_text_box](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/is_text_box/) sur la classe [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), qui vous permet de déterminer si une forme est une zone de texte.

![Text box and shape](istextbox.png)

Ce exemple Python montre comment vérifier si une forme a été créée en tant que zone de texte :

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Notez que si vous ajoutez une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à l'aide de la classe [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/), la propriété `is_text_box` de la forme renvoie `False`. Cependant, après avoir ajouté du texte—soit avec la méthode `add_text_frame`, soit en définissant la propriété `text`—`is_text_box` renvoie `True`.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box is false
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box is true

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box is false
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box is true

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box is false
    shape3.add_text_frame("")
    # shape3.is_text_box is false

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box is false
    shape4.text_frame.text = ""
    # shape4.is_text_box is false
```

## **Ajouter des colonnes aux zones de texte**

Aspose.Slides propose les propriétés [column_count](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_count/) et [column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_spacing/) sur la classe [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) pour ajouter des colonnes aux zones de texte. Vous pouvez spécifier le nombre de colonnes et définir l'espacement (en points) entre les colonnes.

Le code Python suivant illustre cette opération :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Get the first slide in the presentation.
	slide = presentation.slides[0]

	# Add an AutoShape of type RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Add a TextFrame to the rectangle.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Get the text format of the TextFrame.
	format = shape.text_frame.text_frame_format

	# Specify the number of columns in the TextFrame.
	format.column_count = 3

	# Specify the spacing between columns.
	format.column_spacing = 10

	# Save the presentation.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Mettre à jour le texte**

Aspose.Slides vous permet de mettre à jour le texte dans une zone de texte unique ou dans l'ensemble de la présentation.

L'exemple Python suivant montre comment mettre à jour tout le texte d'une présentation :

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # Save the modified presentation.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter des zones de texte avec des hyperliens**

Vous pouvez insérer un lien dans une zone de texte. Lorsque la zone de texte est cliquée, le lien s'ouvre.

Pour ajouter une zone de texte contenant un hyperlien, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à la première diapositive.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) de type `ShapeType.RECTANGLE` à la position souhaitée sur la diapositive.
4. Définissez le texte dans le [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forme.
5. Obtenez une référence au [HyperlinkManager](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/).
6. Utilisez la propriété `hyperlink_manager` pour définir un hyperlien de clic externe.
7. Enregistrez la présentation au format PPTX.

Cet exemple Python montre comment ajouter une zone de texte avec un hyperlien à une diapositive :

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Get the first slide in the presentation.
    slide = presentation.slides[0]

    # Add an AutoShape of type RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Add text to the frame.
    text_portion.text = "Aspose.Slides"

    # Set a hyperlink for the portion text.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Save the presentation as a PPTX file.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Quelle est la différence entre une zone de texte et un espace réservé de texte lors de l'utilisation des diapositives maîtres ?**

Un [placeholder](/slides/fr/python-net/manage-placeholder/) hérite du style/position de la [master](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) et peut être remplacé sur les [layouts](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/), tandis qu'une zone de texte ordinaire est un objet indépendant sur une diapositive donnée et ne change pas lorsque vous basculez de mise en page.

**Comment effectuer un remplacement de texte en masse dans l’ensemble de la présentation sans toucher au texte à l’intérieur des graphiques, tableaux et SmartArt ?**

Limitez votre itération aux auto‑shapes qui possèdent des cadres de texte et excluez les objets incorporés ([charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) en parcourant leurs collections séparément ou en ignorant ces types d’objets.