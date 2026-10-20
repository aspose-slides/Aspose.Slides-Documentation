---
title: Solution fonctionnelle pour le redimensionnement des graphiques dans PPTX
type: docs
weight: 40
url: /fr/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionnement du graphique
- graphique Excel
- objet OLE
- intégrer le graphique
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Corriger le redimensionnement inattendu des graphiques dans les fichiers PPTX lors de l'utilisation d'objets OLE Excel intégrés avec Aspose.Slides for Python via Java. Définir des dimensions fixes pour le graphique afin de conserver la cohérence des tailles du graphique et du cadre OLE."
---
## **Contexte**

Les graphiques Excel incorporés en tant qu'objets OLE dans les présentations PowerPoint à l'aide des composants Aspose peuvent changer de taille après leur première activation. Cela peut entraîner une différence notable dans l'apparence du graphique avant et après l'activation. Cet article explique pourquoi le redimensionnement se produit et montre comment l'éviter en faisant correspondre les dimensions fixes du graphique au cadre OLE.

Dans [Créer des graphiques Excel et les incorporer en tant qu'objets OLE dans les présentations](/slides/fr/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), nous avons expliqué comment créer un graphique Excel avec Aspose.Cells for Python via Java et l'incorporer dans une présentation PowerPoint à l'aide d'Aspose.Slides for Python via Java. Pour résoudre le [problème d'aperçu d'objet](/slides/fr/python-java/object-preview-issue-when-adding-oleobjectframe/), nous avons attribué l'image du graphique au cadre d'objet OLE du graphique. Dans la présentation résultante, lorsque vous double‑cliquez sur le cadre d'objet OLE affichant l'image du graphique, le graphique Excel est activé. Les utilisateurs peuvent modifier le classeur Excel intégré puis revenir à la diapositive en cliquant en dehors du classeur activé. La taille du cadre d'objet OLE change lorsque l'utilisateur revient à la diapositive, et le facteur de redimensionnement varie selon les tailles d'origine du cadre OLE et du classeur Excel intégré.

## **Cause du redimensionnement**

Le classeur Excel intégré possède ses propres dimensions de fenêtre, que Excel essaie de conserver lors de la première activation de l'objet. Le cadre OLE sur la diapositive a des dimensions définies indépendamment. Lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille de l'objet afin de maintenir ses proportions dans le cadre du processus d'intégration. Les différences entre la fenêtre du classeur et le cadre OLE peuvent donc provoquer le redimensionnement de l'objet.

## **Solution fonctionnelle**

Faites correspondre la taille du graphique au cadre OLE sur la diapositive et maintenez les dimensions du graphique indépendantes de la fenêtre du classeur. Cette solution fonctionne avec une nouvelle présentation ou un modèle existant.

L'exemple nécessite Aspose.Cells for Python via Java et Aspose.Slides for Python via Java. Il crée un simple graphique en colonnes sur une feuille de graphique active et intègre le classeur au format XLS. Aucune image d'aperçu du graphique n'est attribuée ; le graphique devient visible lorsque l'objet OLE est activé dans PowerPoint.

L'exemple crée une nouvelle présentation avec un cadre OLE de 9,5 × 4 pouces positionné à 0,5 pouce du bord gauche et à 1 pouce du haut. Les coordonnées et dimensions de la diapositive sont exprimées en points (72 points par pouce). Pour une présentation existante, voir [Utiliser un modèle](#use-a-template).

## **Définir une taille de graphique fixe**

Définissez [setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) sur false afin que les dimensions du graphique soient indépendantes de la fenêtre du classeur. Définissez les dimensions du [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) via [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) et [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height), en convertissant les points en pixels à raison de 96 pixels par pouce : un cadre mesurant 684 × 288 points correspond à un graphique mesurant 912 × 384 pixels. Définissez [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) sur la valeur CUSTOM de [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/). L'exemple intègre le classeur avec [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) et enregistre une présentation avec un cadre OLE de 9,5 × 4 pouces.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # Les coordonnées et dimensions de la diapositive sont en points (72 points par pouce).
        width = 684.0  # 9,5 pouces.
        height = 288.0  # 4 pouces.

        chart.setSizeWithWindow(False)
        # Convertir les points en pixels du graphique en utilisant 96 pixels par pouce.
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **Utiliser un modèle**

La logique de dimensionnement est la même pour une présentation existante. Pour adapter l'exemple :

1. Chargez la présentation modèle au lieu de créer une présentation vide.  
2. Vérifiez que la première diapositive contient au moins trois formes, puis utilisez la forme à l'index 2 comme espace réservé.  
3. Prenez la largeur et la hauteur du cadre à partir de cette forme au lieu d'utiliser les valeurs fixes 684 et 288. Conservez les calculs de dimension inchangés.  
4. Ajoutez le cadre OLE à la position de l'espace réservé au lieu des coordonnées fixes 36 et 72.  
5. Supprimez l'espace réservé avant d'enregistrer la présentation.

## **FAQ**

**Pourquoi mon graphique Excel incorporé change-t-il de taille après son activation dans PowerPoint ?**  
Cela se produit parce qu'Excel tente de restaurer la taille d'origine de la fenêtre lors de la première activation, tandis que le cadre d'objet OLE dans PowerPoint possède ses propres dimensions. PowerPoint et Excel négocient la taille afin de préserver le rapport d'aspect, ce qui peut entraîner le redimensionnement.

**Comment maintenir les tailles du graphique et du cadre OLE cohérentes ?**  
Définissez des dimensions fixes pour le graphique qui correspondent au cadre OLE et utilisez une taille d'impression de graphique personnalisée avant d'incorporer le classeur. L'exemple ci‑dessus montre les paramètres requis et les conversions d'unités.

**Le fait d'aligner la taille de la fenêtre du classeur suffit‑il ?**  
Aligner uniquement la taille de la fenêtre du classeur ne garantit pas que le cadre OLE restera inchangé après l'activation. Utilisez des dimensions fixes pour le graphique comme illustré dans l'exemple.

**Cette solution fonctionne‑t‑elle avec des présentations basées sur un modèle ainsi qu'avec de nouvelles présentations ?**  
Oui. Pour un modèle, utilisez les dimensions et la position de l'espace réservé. Pour une nouvelle présentation, spécifiez directement les dimensions et la position du cadre.

**Puis‑je utiliser cet exemple avec des graphiques créés dans d’autres programmes de tableur ?**  
L'exemple utilise un classeur Excel créé avec Aspose.Cells. Il ne montre pas le comportement d'activation pour d’autres programmes de tableur.

## **Sections associées**

- [Créer des graphiques Excel et les incorporer en tant qu'objets OLE dans les présentations](/slides/fr/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)