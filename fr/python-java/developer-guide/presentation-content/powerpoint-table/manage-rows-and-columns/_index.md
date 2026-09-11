---
title: Gérer les lignes et colonnes des tableaux PowerPoint avec Python
linktitle: Lignes et colonnes
type: docs
weight: 20
url: /fr/python-java/manage-rows-and-columns/
keywords:
- ligne de tableau
- colonne de tableau
- première ligne
- en-tête de tableau
- cloner ligne
- cloner colonne
- copier ligne
- copier colonne
- supprimer ligne
- supprimer colonne
- formatage du texte de la ligne
- formatage du texte de la colonne
- style de tableau
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Gérez les lignes et colonnes des tableaux PowerPoint avec Aspose.Slides pour Python via Java et accélérez la modification des présentations et la mise à jour des données."
---
## **Introduction**

Pour vous permettre de gérer les lignes et les colonnes d'un tableau dans une présentation PowerPoint, Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/fr/python-java/aspose.slides/table/) et de nombreux autres types.

## **Définir la première ligne comme en‑tête**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et chargez la présentation.  
2. Obtenez une référence à une diapositive par son index.  
3. Créez une référence [Table](https://reference.aspose.com/slides/fr/python-java/aspose.slides/table/) et définissez‑la sur `None`.  
4. Parcourez tous les objets [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/) pour trouver le tableau correspondant.  
5. Définissez la première ligne du tableau comme son en‑tête.

Ce code Python vous montre comment définir la première ligne d'un tableau comme son en‑tête:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = None
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            table.setFirstRow(True)
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Cloner une ligne ou une colonne de tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et chargez la présentation.  
2. Obtenez une référence à une diapositive par son index.  
3. Définissez une liste de largeurs de colonnes.  
4. Définissez une liste de hauteurs de lignes.  
5. Ajoutez un objet [Table](https://reference.aspose.com/slides/fr/python-java/aspose.slides/table/) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addTable).  
6. Clonez la ligne du tableau.  
7. Clonez la colonne du tableau.  
8. Enregistrez la présentation modifiée.

Ce code Python vous montre comment cloner une ligne ou une colonne d'un tableau PowerPoint:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)
    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Supprimer une ligne ou une colonne d'un tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).  
2. Obtenez une référence à une diapositive par son index.  
3. Définissez une liste de largeurs de colonnes.  
4. Définissez une liste de hauteurs de lignes.  
5. Ajoutez un objet [Table](https://reference.aspose.com/slides/fr/python-java/aspose.slides/table/) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addTable).  
6. Supprimez la ligne du tableau.  
7. Supprimez la colonne du tableau.  
8. Enregistrez la présentation modifiée.

Ce code Python vous montre comment supprimer une ligne ou une colonne d'un tableau:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)
    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)
    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir le formatage du texte au niveau des lignes du tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et chargez la présentation.  
2. Obtenez une référence à une diapositive par son index.  
3. Accédez à l'objet [Table] pertinent depuis la diapositive.  
4. Définissez la hauteur de police des cellules de la première ligne à l’aide de [setFontHeight](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Définissez l’alignement du texte et la marge droite des cellules de la première ligne à l’aide de [setAlignment](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setAlignment) et [setMarginRight](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. Définissez le type de texte vertical des cellules de la deuxième ligne à l’aide de [setTextVerticalType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. Enregistrez la présentation modifiée.

Ce code Python démontre l'opération.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getRows().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getRows().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getRows().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Définir le formatage du texte au niveau des colonnes du tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et chargez la présentation.  
2. Obtenez une référence à une diapositive par son index.  
3. Accédez à l'objet [Table] pertinent depuis la diapositive.  
4. Définissez la hauteur de police des cellules de la première colonne à l’aide de [setFontHeight](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Définissez l’alignement du texte et la marge droite des cellules de la première colonne à l’aide de [setAlignment](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setAlignment) et [setMarginRight](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. Définissez le type de texte vertical des cellules de la deuxième colonne à l’aide de [setTextVerticalType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. Enregistrez la présentation modifiée.

Ce code Python démontre l'opération:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getColumns().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getColumns().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getColumns().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Obtenir les propriétés de style du tableau**

Aspose.Slides vous permet de récupérer les propriétés de style d'un tableau afin de pouvoir utiliser ces détails pour un autre tableau ou ailleurs. Ce code Python vous montre comment obtenir les propriétés de style à partir d'un style prédéfini de tableau:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)
    style_preset = table.getStylePreset()
    print(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Puis-je appliquer des thèmes/styles PowerPoint à un tableau déjà créé ?**  
Oui. Le tableau hérite du thème de la diapositive / mise en page / maître, et vous pouvez toujours remplacer les remplissages, les bordures et les couleurs du texte par-dessus ce thème.

**Puis-je trier les lignes d'un tableau comme dans Excel ?**  
Non, les tableaux Aspose.Slides n’ont pas de tri ou de filtres intégrés. Triez vos données en mémoire d'abord, puis remplissez de nouveau les lignes du tableau dans cet ordre.

**Puis-je avoir des colonnes à bandes (rayées) tout en conservant des couleurs personnalisées sur des cellules spécifiques ?**  
Oui. Activez les colonnes à bandes, puis surchargez les cellules spécifiques avec un formatage local ; le formatage au niveau de la cellule prime sur le style du tableau.