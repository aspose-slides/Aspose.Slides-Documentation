---
title: Solution fonctionnelle pour le redimensionnement des graphiques dans PPTX
type: docs
weight: 40
url: /fr/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionnement de graphique
- graphique Excel
- objet OLE
- intégrer le graphique
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Corrige le redimensionnement inattendu des graphiques dans PPTX lors de l'utilisation d'objets OLE Excel intégrés avec Aspose.Slides pour Python via Java. Découvrez deux méthodes avec code pour maintenir les tailles cohérentes."
---
## **Contexte**

Il a été observé que les graphiques Excel intégrés en tant qu'objets OLE dans une présentation PowerPoint via les composants Aspose sont redimensionnés à une échelle non spécifiée après leur première activation. Ce comportement provoque une différence visuelle notable dans la présentation entre les états avant et après l'activation du graphique. L'équipe Aspose a étudié le problème en détail et a trouvé une solution. Cet article décrit les causes du problème et la correction correspondante.

Dans l'[article précédent](/slides/fr/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), nous avons expliqué comment créer un graphique Excel avec Aspose.Cells pour Python via Java et l’intégrer dans une présentation PowerPoint à l’aide d’Aspose.Slides pour Python via Java. Pour résoudre le [problème d’aperçu d’objet](/slides/fr/python-java/object-preview-issue-when-adding-oleobjectframe/), nous avons attribué l’image du graphique au cadre d’objet OLE du graphique. Dans la présentation générée, lorsque vous double-cliquez sur le cadre d’objet OLE affichant l’image du graphique, le graphique Excel est activé. Les utilisateurs peuvent effectuer les modifications souhaitées dans le classeur Excel sous‑jacent, puis revenir à la diapositive correspondante en cliquant en dehors du classeur activé. La taille du cadre d’objet OLE change lorsque l'utilisateur revient à la diapositive, et le facteur de redimensionnement varie en fonction des tailles d'origine du cadre d’objet OLE et du classeur Excel intégré.

## **Cause du redimensionnement**

Comme le classeur Excel possède sa propre taille de fenêtre, il tente de conserver sa taille d'origine lors de sa première activation. Le cadre d’objet OLE, en revanche, a sa propre taille. Selon Microsoft, lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille et conservent les bonnes proportions dans le cadre du processus d’intégration. En fonction des différences entre la taille de la fenêtre Excel et la taille ou la position du cadre d’objet OLE, un redimensionnement se produit.

## **Solution fonctionnelle**

Il existe deux scénarios possibles pour créer des présentations PowerPoint à l’aide d’Aspose.Slides pour Python via Java.

**Scenario 1:** Créer une présentation à partir d’un modèle existant.

**Scenario 2:** Créer une présentation à partir de zéro.

La solution que nous présentons ici s’applique aux deux scénarios. Le principe de toutes les approches de solution est le même : **la taille de la fenêtre de l’objet OLE intégré doit correspondre au cadre d’objet OLE dans la diapositive PowerPoint**. Nous allons maintenant examiner les deux approches de cette solution.

## **Première approche**

Dans cette approche, nous allons apprendre à définir la taille de la fenêtre du classeur Excel intégré afin qu’elle corresponde à la taille du cadre d’objet OLE dans la diapositive PowerPoint.

**Scenario 1**

Supposons que nous ayons défini un modèle et que nous voulions créer des présentations à partir de celui‑ci. Supposons qu’il y ait une forme à l’index 2 du modèle où nous voulons placer un cadre OLE contenant un classeur Excel intégré. Dans ce scénario, la taille du cadre d’objet OLE est prédéfinie — elle correspond à la taille de la forme à l’index 2 du modèle. Tout ce que nous devons faire est de régler la taille de la fenêtre du classeur sur la taille de cette forme. Le fragment de code suivant remplit cet objectif :

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Charger le classeur Excel contenant le graphique.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Définir la taille de la fenêtre du classeur en pouces (PowerPoint utilise 72 points par pouce).
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # Enregistrer le classeur dans un flux mémoire.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Créer un cadre d'objet OLE avec les données Excel intégrées.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**

Disons que nous voulons créer une présentation à partir de zéro et inclure un cadre d’objet OLE de n’importe quelle taille contenant un classeur Excel intégré. Dans le fragment de code suivant, nous créons un cadre d’objet OLE de 4 pouces de haut et 9,5 pouces de large, positionné à x = 0,5 pouce et y = 1 pouce sur la diapositive. Nous réglons ensuite la fenêtre du classeur Excel à la même taille — 4 pouces de haut et 9,5 pouces de large.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Charger le classeur Excel contenant le graphique.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 pouces (4 * 72).
    desired_width = 684  # 9,5 pouces (9,5 * 72).

    # Définir la taille du graphique avec une fenêtre.
    chart.setSizeWithWindow(True)

    # Définir la taille de la fenêtre du classeur en pouces (PowerPoint utilise 72 points par pouce).
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # Enregistrer le classeur dans un flux mémoire.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Créer un cadre d'objet OLE avec les données Excel intégrées.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Deuxième approche**

Dans cette approche, nous allons apprendre à définir la taille du graphique dans le classeur Excel intégré afin qu’elle corresponde à la taille du cadre d’objet OLE dans la diapositive PowerPoint. Cette approche est utile lorsque la taille du graphique est connue à l’avance et ne changera jamais.

**Scenario 1**

Supposons que nous ayons défini un modèle et que nous voulions créer des présentations à partir de celui‑ci. Supposons qu’il y ait une forme à l’index 2 du modèle où nous prévoyons de placer un cadre OLE contenant un classeur Excel intégré. Dans ce scénario, la taille du cadre OLE est prédéfinie—elle correspond à la taille de la forme à l’index 2 du modèle. Tout ce que nous devons faire est de régler la taille du graphique dans le classeur sur la taille de cette forme. Le fragment de code suivant remplit cet objectif :

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Charger le classeur Excel contenant le graphique.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Définir la taille du graphique sans fenêtre.
    chart.setSizeWithWindow(False)

    # Définir la taille du graphique en pixels (Excel utilise 96 pixels par pouce).
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # Définir la taille d’impression du graphique.
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # Enregistrer le classeur dans un flux mémoire.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Créer un cadre d’objet OLE avec les données Excel intégrées.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**:

Supposons que nous voulions créer une présentation à partir de zéro et inclure un cadre d’objet OLE de n’importe quelle taille contenant un classeur Excel intégré. Dans le fragment de code suivant, nous créons un cadre d’objet OLE d’une hauteur de 4 pouces et d’une largeur de 9,5 pouces sur la diapositive, à x = 0,5 pouce et y = 1 pouce. Nous définissons également la taille du graphique correspondant aux mêmes dimensions : une hauteur de 4 pouces et une largeur de 9,5 pouces.

```python
import jpage
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Charger le classeur Excel contenant le graphique.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 pouces (4 * 72).
    desired_width = 684  # 9,5 pouces (9,5 * 72).

    # Définir la taille du graphique sans fenêtre.
    chart.setSizeWithWindow(False)

    # Définir la taille du graphique en pixels (Excel utilise 96 pixels par pouce).
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # Enregistrer le classeur dans un flux mémoire.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Créer un cadre d'objet OLE avec les données Excel intégrées.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Conclusion**

Il existe deux approches pour résoudre le problème de redimensionnement du graphique. Le choix de l’approche dépend des exigences et du cas d’utilisation. Les deux approches fonctionnent de la même manière, que les présentations soient créées à partir d’un modèle ou à partir de zéro. De plus, il n’y a aucune limitation à la taille du cadre d’objet OLE dans cette solution.

## **FAQ**

**Pourquoi mon graphique Excel intégré change-t-il de taille après son activation dans PowerPoint ?**

Cela se produit parce qu’Excel tente de restaurer sa taille de fenêtre d’origine lors de la première activation, tandis que le cadre d’objet OLE dans PowerPoint a ses propres dimensions. PowerPoint et Excel négocient la taille pour conserver le ratio d’aspect, ce qui peut entraîner le redimensionnement.

**Est‑il possible de prévenir entièrement ce problème de redimensionnement ?**

Oui. En faisant correspondre la taille de la fenêtre du classeur Excel ou la taille du graphique à la taille du cadre d’objet OLE avant l’intégration, vous pouvez maintenir des tailles de graphique cohérentes.

**Quelle approche dois‑je choisir, définir la taille de la fenêtre du classeur ou définir la taille du graphique ?**

Utilisez **Approche 1 (taille de la fenêtre)** si vous souhaitez conserver le ratio d’aspect du classeur et éventuellement permettre un redimensionnement ultérieur.  
Utilisez **Approche 2 (taille du graphique)** si les dimensions du graphique sont fixes et ne changeront pas après l’intégration.

**Ces méthodes fonctionneront‑elles avec les présentations basées sur un modèle ainsi qu’avec les nouvelles présentations ?**

Oui. Les deux approches fonctionnent de la même manière pour les présentations créées à partir de modèles et à partir de zéro.

**Y a‑t‑il une limite à la taille du cadre d’objet OLE ?**

Non. Vous pouvez définir le cadre OLE à n’importe quelle taille tant qu’il s’ajuste correctement à la taille du classeur ou du graphique.

**Puis‑je utiliser ces méthodes avec des graphiques créés dans d’autres programmes tableur ?**

Les exemples sont conçus pour les graphiques Excel créés avec Aspose.Cells, mais les principes s’appliquent à d’autres programmes tableur compatibles OLE tant qu’ils prennent en charge des options de dimensionnement similaires.

## **Sections connexes**

- [Créer des graphiques Excel et les intégrer en tant qu’objets OLE dans les présentations](/slides/fr/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)