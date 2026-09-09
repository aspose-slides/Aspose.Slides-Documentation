---
title: Gérer les zones de texte dans les présentations avec Python via Java
linktitle: Gérer la zone de texte
type: docs
weight: 20
url: /fr/python-java/manage-textbox/
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
- Java
- Aspose.Slides
description: "Créer, identifier, formater et mettre à jour des zones de texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Python via Java."
---
## **Introduction**

Dans Aspose.Slides pour Python via Java, le texte des diapositives est stocké dans des cadres de texte qui appartiennent aux formes. La classe [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) représente la forme la plus courante contenant du texte et expose son texte via la méthode [AutoShape.getTextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}

Chaque AutoShape hérite de [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/), mais toutes les formes ne sont pas des AutoShape ou ne prennent pas en charge un cadre de texte. Lors du traitement d’une présentation existante, vérifiez qu’une forme est une instance de [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) avant d’accéder à son texte.

{{% /alert %}}

## **Créer une zone de texte sur une diapositive**

Pour créer une zone de texte, ajoutez une AutoShape à une diapositive, ajoutez du texte à son cadre de texte, puis enregistrez la présentation. L’exemple suivant crée une zone de texte rectangulaire :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50)
    text_box.addTextFrame("Aspose TextBox")

    presentation.save("TextBox.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Les coordonnées et dimensions passées à [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addAutoShape) sont mesurées en points. [AutoShape.addTextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/#addTextFrame) initialise le cadre de texte avec le texte fourni.

## **Vérifier la présence d’une forme de zone de texte**

Utilisez la méthode [AutoShape.isTextBox](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/#isTextBox) pour déterminer si une AutoShape est considérée comme une zone de texte. Cela est utile lorsqu’une présentation contient à la fois des AutoShape contenant du texte et des AutoShape purement graphiques.

![Une zone de texte et une forme](istextbox.png)

Le code suivant examine chaque AutoShape d’une présentation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40)
    text_box.addTextFrame("Text box")
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40)

    for current_slide in presentation.getSlides():
        for shape in current_slide.getShapes():
            if isinstance(shape, AutoShape):
                print("The shape is a text box." if shape.isTextBox() else "The shape is not a text box.")
finally:
    presentation.dispose()
```

Une AutoShape nouvellement ajoutée n’est pas considérée comme une zone de texte tant qu’elle ne contient pas de texte non vide. Vous pouvez fournir ce texte via [AutoShape.addTextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/#addTextFrame) ou [TextFrame.setText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/#setText). Ajouter ou assigner une chaîne vide fait que [AutoShape.isTextBox](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/#isTextBox) renvoie `False` :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    added_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40)
    added_text_shape.addTextFrame("Shape 1")
    print(added_text_shape.isTextBox())

    assigned_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40)
    assigned_text_shape.getTextFrame().setText("Shape 2")
    print(assigned_text_shape.isTextBox())

    added_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40)
    added_empty_text_shape.addTextFrame("")
    print(added_empty_text_shape.isTextBox())

    assigned_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40)
    assigned_empty_text_shape.getTextFrame().setText("")
    print(assigned_empty_text_shape.isTextBox())
finally:
    presentation.dispose()
```

Les deux premiers appels affichent `True` ; les deux derniers affichent `False`.

## **Trouver la forme qui possède un cadre de texte**

Un code générique de traitement de texte peut recevoir un [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) sans savoir quel objet de la présentation le contient. Utilisez la méthode en lecture seule [TextFrame.getParentShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/#getParentShape) pour revenir à la [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/) qui le possède.

Pour un cadre de texte appartenant à une AutoShape ou à une autre forme contenant du texte, [TextFrame.getParentShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/#getParentShape) renvoie le propriétaire et [TextFrame.getParentCell](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/#getParentCell) renvoie `None`. Vérifiez la valeur retournée avant de l’utiliser. Pour identifier à la fois les propriétaires de forme et de cellule de tableau, y compris les formes associées aux nœuds SmartArt, consultez [Search and Replace Text](/slides/fr/python-java/search-and-replace-text/).

## **Ajouter des colonnes à une zone de texte**

La méthode [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setColumnCount) divise le cadre de texte en colonnes, tandis que [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setColumnSpacing) définit l’écart entre les colonnes en points. Les deux paramètres appartiennent à [TextFrameFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/) et peuvent être modifiés via le cadre de texte d’une zone de texte existante. Le texte se réorganise entre les colonnes au sein de la même forme ; il ne continue pas dans une autre forme.

L’exemple suivant crée une zone de texte à trois colonnes avec 10 points d’écart entre les colonnes, enregistre la présentation et lit les paramètres stockés depuis le fichier de sortie :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200)
    text_box.addTextFrame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.getTextFrame().getTextFrameFormat()
    text_frame_format.setColumnCount(3)
    text_frame_format.setColumnSpacing(10)

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx)

    saved_presentation = Presentation("TextBoxColumns.pptx")
    try:
        saved_text_box = saved_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_format = saved_text_box.getTextFrame().getTextFrameFormat()
        print(f"Columns: {saved_format.getColumnCount()}; spacing: {saved_format.getColumnSpacing()} points")
    finally:
        saved_presentation.dispose()
finally:
    presentation.dispose()
```

## **Extraire le texte de chaque colonne**

Utilisez [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/#splitTextByColumns) pour récupérer le texte attribué à chaque colonne visuelle d’un cadre de texte existant. La méthode renvoie une chaîne pour chaque colonne, dans l’ordre de lecture basé sur les colonnes. Un cadre de texte à une seule colonne produit un tableau avec un élément, et une colonne vide est représentée par une chaîne vide. Les chaînes contiennent uniquement du texte brut ; le formatage au niveau des portions n’est pas conservé.

Ceci est utile lorsque vous devez :

- Extraire le texte tout en conservant son ordre de lecture basé sur les colonnes.
- Indexer ou comparer le contenu des diapositives à colonnes multiples.
- Exporter chaque colonne vers un fichier séparé, un champ de base de données ou une autre destination.
- Inspecter comment le texte est redistribué après avoir modifié le nombre de colonnes avec [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setColumnCount), l’espacement avec [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setColumnSpacing), la police ou la taille du cadre de texte.

La méthode indique le texte distribué à l’intérieur du [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) actuel ; elle ne fait pas couler automatiquement le texte entre des formes ou zones de texte séparées. La répartition des colonnes peut dépendre des polices disponibles et d’autres paramètres de mise en page du texte, assurez‑vous donc que les polices requises sont présentes lorsque la cohérence des résultats est importante.

L’exemple suivant charge une présentation, trouve la première AutoShape à colonnes multiples contenant un cadre de texte, lit son nombre de colonnes configuré, et écrit le texte de chaque colonne dans un fichier séparé. Les formes ne possédant pas de cadre de texte sont ignorées.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import AutoShape, Presentation

presentation = Presentation("MultiColumnText.pptx")
try:
    text_box = None
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, AutoShape):
            if shape.getTextFrame() is not None:
                column_count = shape.getTextFrame().getTextFrameFormat().getColumnCount()
                if column_count > 1:
                    text_box = shape
                    break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.getTextFrame()
        configured_column_count = text_frame.getTextFrameFormat().getColumnCount()
        column_texts = text_frame.splitTextByColumns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            output_path = Path(f"Column-{column_number}.txt")
            try:
                output_path.write_text(str(column_text), encoding="utf-8")
            except OSError as exception:
                print(f"Could not write column {column_number}: {exception}")
finally:
    presentation.dispose()
```

## **Mettre à jour le texte**

Pour mettre à jour le texte dans toute une présentation, parcourez les diapositives et les formes, sélectionnez les AutoShape, puis éditez leurs portions de texte. Travailler au niveau des portions vous permet de modifier à la fois le texte et le formatage des caractères.

L’exemple suivant remplace chaque occurrence de `years` par `months` dans le texte des AutoShape et rend chaque portion concernée en gras :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, NullableBool, Presentation, SaveFormat

presentation = Presentation("Text.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            text_frame = shape.getTextFrame()
            if text_frame is None:
                continue

            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    text = portion.getText()
                    if text is not None and "years" in str(text):
                        portion.setText(str(text).replace("years", "months"))
                        portion.getPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("TextChanged.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ce parcours met à jour le texte uniquement dans les AutoShape. Le texte stocké dans les tableaux, graphiques, SmartArt ou formes groupées nécessite un parcours des collections propres à ces objets.

## **Ajouter une zone de texte avec un hyperlien**

Un hyperlien peut être assigné à une portion de texte spécifique, de sorte que seul ce texte agit comme lien cliquable. Utilisez [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) pour associer la portion à une URL externe.

L’exemple suivant crée du texte lié et l’enregistre dans une présentation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50)
    text_box.addTextFrame("Aspose.Slides")

    text_portion = text_box.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Quelle est la différence entre une zone de texte et un espace réservé de texte sur une diapositive maître ou de mise en page ?**

Un [placeholder](/slides/fr/python-java/manage-placeholder/) peut hériter de sa position et de son formatage d’une [diapositive maître](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslide/) ou d’une [diapositive de mise en page](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutslide/). Une zone de texte ordinaire est une forme indépendante sur la diapositive où elle a été créée et n’acquiert pas le comportement d’espace réservé lorsque la mise en page change.

**Comment remplacer du texte sans modifier le texte dans les graphiques, tableaux ou SmartArt ?**

Limitez le parcours aux formes qui sont des instances de [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/), comme illustré dans l’exemple Mettre à jour le texte. Les graphiques, tableaux et SmartArt stockent le texte dans leurs propres modèles d’objets, ils ne sont donc pas modifiés par cette boucle.