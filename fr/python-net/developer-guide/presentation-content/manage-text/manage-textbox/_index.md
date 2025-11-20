---
title: Gérer les zones de texte dans les présentations avec Python
linktitle: Gestion de la zone de texte
type: docs
weight: 20
url: /fr/python-net/manage-textbox/
keywords:
- zone de texte
- cadre de texte
- ajouter du texte
- mettre à jour le texte
- créer une zone de texte
- vérifier la zone de texte
- ajouter une colonne de texte
- ajouter un hyperlien
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Aspose.Slides pour Python via .NET facilite la création, la modification et le clonage des zones de texte dans les fichiers PowerPoint et OpenDocument, améliorant ainsi votre automatisation de présentations."
---

## **Vue d'ensemble**

Les textes sur les diapositives se trouvent généralement dans des zones de texte ou des formes. Ainsi, pour ajouter du texte à une diapositive, vous devez ajouter une zone de texte puis placer du texte à l'intérieur de celle-ci. Aspose.Slides for Python fournit la classe [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) qui permet d'ajouter une forme contenant du texte.

{{% alert title="Info" color="info" %}}
Aspose.Slides fournit également la classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/). Cependant, toutes les formes ne peuvent pas contenir du texte.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Par conséquent, lorsque vous traitez une forme à laquelle vous souhaitez ajouter du texte, vous devez vérifier et confirmer qu'elle a été convertie via la classe [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Ce n'est qu'alors que vous pourrez travailler avec [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), qui est une propriété de [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Voir la section [Update Text](/slides/fr/python-net/manage-textbox/#update-text) sur cette page.
{{% /alert %}}

## **Créer des zones de texte sur les diapositives**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à la première diapositive.
3. Ajoutez un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) avec `ShapeType.RECTANGLE` à la position souhaitée sur la diapositive.
4. Définissez le texte dans le [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forme.
5. Enregistrez la présentation sous forme de fichier PPTX.

L'exemple Python suivant implémente ces étapes:
```py
import aspose.slides as slides

# Instancier la classe Presentation.
with slides.Presentation() as presentation:

    # Obtenir la première diapositive de la présentation.
    slide = presentation.slides[0]

    # Ajouter une AutoShape de type RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Enregistrer la présentation sur le disque.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```


## **Vérifier si une forme est une zone de texte**

Aspose.Slides fournit la propriété [is_text_box](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/is_text_box/) sur la classe [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), qui vous permet de déterminer si une forme est une zone de texte.

![Zone de texte et forme](istextbox.png)

Cet exemple Python montre comment vérifier si une forme a été créée en tant que zone de texte:
```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```


Notez que si vous ajoutez un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à l'aide de la classe [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/), la propriété `is_text_box` de la forme renvoie `False`. Cependant, après avoir ajouté du texte—soit avec la méthode `add_text_frame`, soit en définissant la propriété `text`—`is_text_box` renvoie `True`.
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box est faux
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box est vrai

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box est faux
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box est vrai

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box est faux
    shape3.add_text_frame("")
    # shape3.is_text_box est faux

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box est faux
    shape4.text_frame.text = ""
    # shape4.is_text_box est faux
```


## **Ajouter des colonnes aux zones de texte**

Aspose.Slides fournit les propriétés [column_count](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_count/) et [column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_spacing/) sur la classe [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) pour ajouter des colonnes aux zones de texte. Vous pouvez spécifier le nombre de colonnes et définir l'espacement (en points) entre les colonnes.

Le code Python suivant montre cette opération:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Obtenir la première diapositive de la présentation.
	slide = presentation.slides[0]

	# Ajouter une AutoShape de type RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Ajouter un TextFrame au rectangle.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Obtenir le format du texte du TextFrame.
	format = shape.text_frame.text_frame_format

	# Spécifier le nombre de colonnes dans le TextFrame.
	format.column_count = 3

	# Spécifier l'espacement entre les colonnes.
	format.column_spacing = 10

	# Enregistrer la présentation.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```


## **Mettre à jour le texte**

Aspose.Slides vous permet de mettre à jour le texte dans une zone de texte unique ou dans l'ensemble d'une présentation.

L'exemple Python suivant montre comment mettre à jour tout le texte d'une présentation:
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
  
    # Enregistrer la présentation modifiée.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```


## **Ajouter des zones de texte avec des hyperliens**

Vous pouvez insérer un lien dans une zone de texte. Lorsque la zone de texte est cliquée, le lien s'ouvre.

Pour ajouter une zone de texte contenant un hyperlien, suivez ces étapes:

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à la première diapositive.
3. Ajoutez un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) avec `ShapeType.RECTANGLE` à la position souhaitée sur la diapositive.
4. Définissez le texte dans le [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forme.
5. Obtenez une référence au [HyperlinkManager](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/).
6. Utilisez la propriété `hyperlink_manager` pour définir un hyperlien de clic externe.
7. Enregistrez la présentation sous forme de fichier PPTX.

Cet exemple Python montre comment ajouter une zone de texte avec un hyperlien à une diapositive:
```py
import aspose.slides as slides

# Instancier la classe Presentation.
with slides.Presentation() as presentation:

    # Obtenir la première diapositive de la présentation.
    slide = presentation.slides[0]

    # Ajouter une AutoShape de type RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Ajouter du texte au cadre.
    text_portion.text = "Aspose.Slides"

    # Définir un hyperlien pour le texte de la portion.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Enregistrer la présentation au format PPTX.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Quelle est la différence entre une zone de texte et un espace réservé de texte lors de l'utilisation des diapositives maîtres ?**

Un [placeholder](/slides/fr/python-net/manage-placeholder/) hérite du style/position du [master](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) et peut être remplacé sur les [layouts](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/), tandis qu'une zone de texte ordinaire est un objet indépendant sur une diapositive spécifique et ne change pas lorsque vous changez de mise en page.

**Comment effectuer un remplacement de texte en masse dans l'ensemble de la présentation sans toucher le texte à l'intérieur des graphiques, tableaux et SmartArt ?**

Limitez votre itération aux auto‑formes qui possèdent des cadres de texte et excluez les objets intégrés ([charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) en parcourant leurs collections séparément ou en ignorant ces types d'objets.