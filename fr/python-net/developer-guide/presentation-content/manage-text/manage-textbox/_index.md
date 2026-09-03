---
title: Gérer les zones de texte dans les présentations avec Python
linktitle: Gérer la zone de texte
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
description: "Créer, identifier, formater et mettre à jour les zones de texte dans les présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour Python via .NET."
---
## **Introduction**

Dans Aspose.Slides pour Python via .NET, le texte des diapositives est stocké dans des cadres de texte qui appartiennent à des formes. La classe [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) représente la forme la plus courante contenant du texte et expose son texte via la propriété [AutoShape.text_frame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/text_frame/).

{{% alert color="info" title="Remarque" %}}

Chaque forme automatique hérite de [Shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/), mais toutes les formes ne sont pas des formes automatiques ni ne prennent en charge un cadre de texte. Lors du traitement d’une présentation existante, utilisez `isinstance(shape, slides.AutoShape)` pour vérifier le type de forme avant d’accéder à son texte.

{{% /alert %}}

## **Créer une zone de texte sur une diapositive**

Pour créer une zone de texte, ajoutez une forme automatique à une diapositive, ajoutez du texte à son cadre de texte, puis enregistrez la présentation. L’exemple suivant crée une zone de texte rectangulaire :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

Les coordonnées et dimensions passées à [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/add_auto_shape/) sont mesurées en points. [AutoShape.add_text_frame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/add_text_frame/) initialise le cadre de texte avec le texte fourni.

## **Vérifier une forme de zone de texte**

Utilisez la propriété [AutoShape.is_text_box](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/is_text_box/) pour déterminer si une forme automatique est traitée comme une zone de texte. Cela est utile lorsqu’une présentation contient à la fois des formes automatiques contenant du texte et des formes purement graphiques.

![Une zone de texte et une forme](istextbox.png)

L’exemple suivant examine chaque forme automatique d’une présentation :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

Une forme automatique nouvellement ajoutée n’est pas considérée comme une zone de texte tant qu’elle ne contient pas de texte non vide. Vous pouvez fournir ce texte via [AutoShape.add_text_frame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/add_text_frame/) ou [TextFrame.text](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/text/). Ajouter ou attribuer une chaîne vide laisse [is_text_box](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/is_text_box/) à `False` :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

Les deux premiers appels affichent `True` ; les deux derniers affichent `False`.

## **Trouver la forme qui possède un cadre de texte**

Un code générique de traitement du texte peut recevoir un [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) sans savoir quel objet de présentation le contient. Utilisez la propriété en lecture seule [TextFrame.parent_shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/parent_shape/) pour revenir à sa [Shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/) propriétaire.

Pour un cadre de texte détenu par une forme automatique ou une autre forme contenant du texte, [parent_shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/parent_shape/) contient le propriétaire et [TextFrame.parent_cell](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/parent_cell/) est `None`. Vérifiez la valeur retournée avant de l’utiliser. Pour identifier à la fois les propriétaires de forme et de cellule de tableau, y compris les formes associées aux nœuds SmartArt, consultez [Search and Replace Text](/slides/fr/python-net/search-and-replace-text/).

## **Ajouter des colonnes à une zone de texte**

La propriété [TextFrameFormat.column_count](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/column_count/) divise le cadre de texte en colonnes, tandis que [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/column_spacing/) définit l’espace entre les colonnes en points. Ces deux paramètres appartiennent à [TextFrameFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/) et peuvent être modifiés via le cadre de texte d’une zone de texte existante. Le texte se réorganise entre les colonnes à l’intérieur de la même forme ; il ne continue pas dans une autre forme.

L’exemple suivant crée une zone de texte à trois colonnes avec 10 points d’espacement, enregistre la présentation et relit les paramètres stockés à partir du fichier de sortie :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **Extraire le texte des colonnes individuelles**

Utilisez [TextFrame.split_text_by_columns](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/split_text_by_columns/) pour récupérer le texte assigné à chaque colonne visuelle d’un cadre de texte existant. La méthode renvoie une chaîne pour chaque colonne, dans l’ordre de lecture basé sur les colonnes. Un cadre de texte à une seule colonne produit une liste avec un élément, et une colonne vide est représentée par une chaîne vide. Les chaînes contiennent uniquement du texte brut ; le formatage au niveau des portions n’est pas conservé.

Cela est utile lorsque vous devez :

- Extraire le texte tout en conservant son ordre de lecture basé sur les colonnes.
- Indexer ou comparer le contenu des diapositives multi-colonnes.
- Exporter chaque colonne vers un fichier séparé, un champ de base de données ou une autre destination.
- Inspecter comment le texte est redistribué après modification de [TextFrameFormat.column_count](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/column_count/), [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/column_spacing/), de la police ou de la taille du cadre de texte.

La méthode rend compte du texte distribué dans le [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) actuel ; elle ne fait pas automatiquement couler le texte entre des formes ou zones de texte séparées. La distribution des colonnes peut dépendre des polices disponibles et d’autres paramètres de mise en page du texte, assurez‑vous donc que les polices requises sont présentes lorsque la cohérence des résultats est importante.

L’exemple suivant charge une présentation, trouve la première forme automatique à colonnes multiples avec un cadre de texte, lit le nombre de colonnes configuré et écrit le texte de chaque colonne dans un fichier séparé. Les formes qui ne fournissent pas de cadre de texte sont ignorées.

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **Mettre à jour le texte**

Pour mettre à jour le texte dans l’ensemble d’une présentation, parcourez les diapositives et les formes, sélectionnez les formes automatiques, puis modifiez leurs portions de texte. Travailler au niveau des portions vous permet de changer à la fois le texte et le formatage des caractères.

L’exemple suivant remplace chaque occurrence de `years` par `months` dans le texte des formes automatiques et rend chaque portion affectée en gras :

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

Ce parcours met à jour le texte uniquement dans les formes automatiques. Le texte stocké dans les tableaux, graphiques, SmartArt ou formes groupées nécessite le parcours des collections propres à ces objets.

## **Ajouter une zone de texte avec un lien hypertexte**

Un lien hypertexte peut être attribué à une portion de texte spécifique, de sorte que seul ce texte agit comme lien cliquable. Utilisez [HyperlinkManager.set_external_hyperlink_click](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/) pour associer la portion à une URL externe.

L’exemple suivant crée du texte lié et l’enregistre dans une présentation :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Quelle est la différence entre une zone de texte et un espace réservé de texte sur une diapositive maître ou de mise en page ?**

Un [placeholder](/slides/fr/python-net/manage-placeholder/) peut hériter de sa position et de son formatage d’une [master slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslide/) ou d’une [layout slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslide/). Une zone de texte ordinaire est une forme indépendante sur la diapositive où elle a été créée et n’acquiert pas le comportement d’espace réservé lorsque la mise en page change.

**Comment remplacer du texte sans modifier le texte dans les graphiques, tableaux ou SmartArt ?**

Limitez le parcours aux instances de [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/), comme indiqué dans l’exemple de mise à jour du texte. Les graphiques, tableaux et SmartArt stockent le texte dans leurs propres modèles d’objet, ils ne sont donc pas modifiés par cette boucle.