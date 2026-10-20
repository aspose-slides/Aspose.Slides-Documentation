---
title: Solution fonctionnelle pour le redimensionnement des graphiques dans PPTX
type: docs
weight: 60
url: /fr/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionnement de graphique
- graphique Excel
- objet OLE
- intégrer le graphique
- PowerPoint
- présentation
- Python via .NET
- Python
- Aspose.Slides
description: "Corrige le redimensionnement inattendu des graphiques dans les fichiers PPTX lors de l’utilisation d’objets OLE Excel intégrés avec Aspose.Slides pour Python via .NET. Définissez des dimensions de graphique fixes afin de maintenir la cohérence des tailles du graphique et du cadre OLE."
---
## **Vue d'ensemble**

Les graphiques Excel intégrés comme objets OLE dans les présentations PowerPoint à l'aide des composants Aspose peuvent changer de taille après leur première activation. Cela peut entraîner une différence perceptible de l’apparence du graphique avant et après l’activation. Cet article explique pourquoi le redimensionnement se produit et montre comment l’éviter en faisant correspondre les dimensions fixes du graphique au cadre OLE.

Dans [Créer des graphiques Excel et les intégrer comme objets OLE dans les présentations](/slides/fr/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), nous avons expliqué comment créer un graphique Excel avec Aspose.Cells for Python via .NET et l’intégrer dans une présentation PowerPoint à l’aide d’Aspose.Slides for Python via .NET. Pour résoudre le [problème d'aperçu d'objet](/slides/fr/python-net/object-preview-issue-when-adding-oleobjectframe/), nous avons attribué l’image du graphique au cadre d’objet OLE du graphique. Dans la présentation de sortie, lorsque vous double‑cliquez sur le cadre d’objet OLE affichant l’image du graphique, le graphique Excel est activé. Les utilisateurs peuvent modifier le classeur Excel intégré, puis revenir à la diapositive en cliquant en dehors du classeur activé. La taille du cadre d’objet OLE change lorsque l’utilisateur revient à la diapositive, et le facteur de redimensionnement varie en fonction des tailles d’origine à la fois du cadre OLE et du classeur Excel intégré.

## **Cause du redimensionnement**

Le classeur Excel intégré possède ses propres dimensions de fenêtre, que Excel tente de conserver lors de la première activation de l’objet. Le cadre OLE sur la diapositive a des dimensions définies indépendamment. Lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille de l’objet pour maintenir ses proportions dans le cadre du processus d’intégration. Les différences entre la fenêtre du classeur et le cadre OLE peuvent donc entraîner le redimensionnement de l’objet.

## **Solution fonctionnelle**

Faites correspondre la taille du graphique au cadre OLE de la diapositive et maintenez les dimensions du graphique indépendantes de la fenêtre du classeur. Cette solution fonctionne avec une nouvelle présentation ou un modèle existant.

L’exemple nécessite Aspose.Cells for Python via .NET et Aspose.Slides for Python via .NET. Il crée un graphique à colonnes simple sur une feuille de graphique active et intègre le classeur au format XLS. Aucune image d’aperçu du graphique n’est attribuée ; le graphique devient visible lorsque l’objet OLE est activé dans PowerPoint.

L’exemple crée une nouvelle présentation avec un cadre OLE de 9,5 × 4 pouces placé à 0,5 pouce du bord gauche et à 1 pouce du haut. Les coordonnées et dimensions de la diapositive sont exprimées en points (72 points par pouce). Pour une présentation existante, voir [Utiliser un modèle](#use-a-template).

## **Définir une taille de graphique fixe**

Définissez [size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/) sur false afin que les dimensions du graphique soient indépendantes de la fenêtre du classeur. Définissez les dimensions du [chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/) via [width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/) et [height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/), en convertissant les points en pixels à l’aide de 96 pixels par pouce : un cadre mesurant 684 × 288 points correspond à un graphique de 912 × 384 pixels. Définissez [print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/) sur la valeur CUSTOM de [PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/). L’exemple intègre le classeur avec [add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/) et enregistre une présentation avec un cadre OLE de 9,5 × 4 pouces.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Les coordonnées et dimensions de la diapositive sont exprimées en points (72 points par pouce).
    width = 684.0  # 9,5 pouces.
    height = 288.0  # 4 pouces.

    chart.size_with_window = False
    # Convertir les points en pixels du graphique en utilisant 96 pixels par pouce.
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Utiliser un modèle**

La logique de dimensionnement est la même pour une présentation existante. Pour adapter l’exemple :

1. Chargez la présentation modèle au lieu de créer une présentation vide.  
2. Vérifiez que la première diapositive contient au moins trois formes, puis utilisez la forme à l’indice 2 comme espace réservé.  
3. Prenez la largeur et la hauteur du cadre à partir de cette forme au lieu d’utiliser les valeurs fixes 684 et 288. Conservez les calculs de dimensionnement inchangés.  
4. Ajoutez le cadre OLE à la position de l’espace réservé au lieu des coordonnées fixes 36 et 72.  
5. Supprimez l’espace réservé avant d’enregistrer la présentation.

## **FAQ**

**Pourquoi mon graphique Excel intégré change-t-il de taille après son activation dans PowerPoint ?**  
Cela se produit parce qu’Excel tente de restaurer la taille de fenêtre d’origine lors de la première activation, alors que le cadre de l’objet OLE dans PowerPoint possède ses propres dimensions. PowerPoint et Excel négocient la taille pour conserver le rapport d’aspect, ce qui peut entraîner le redimensionnement.

**Comment garder les tailles du graphique et du cadre OLE cohérentes ?**  
Définissez des dimensions de graphique fixes correspondant au cadre OLE et utilisez une taille d’impression de graphique personnalisée avant d’intégrer le classeur. L’exemple ci‑dessus montre les paramètres requis et les conversions d’unités.

**Le fait d’ajuster la taille de la fenêtre du classeur suffit‑il ?**  
Ajuster uniquement la taille de la fenêtre du classeur ne garantit pas que le cadre OLE ne changera pas de taille après l’activation. Utilisez des dimensions de graphique fixes comme indiqué dans l’exemple.

**Cette solution fonctionne‑t‑elle avec des présentations basées sur un modèle et avec de nouvelles présentations ?**  
Oui. Pour un modèle, utilisez les dimensions et la position de l’espace réservé. Pour une nouvelle présentation, spécifiez directement les dimensions et la position du cadre.

**Puis‑je utiliser cet exemple avec des graphiques créés dans d’autres programmes de tableur ?**  
L’exemple utilise un classeur Excel créé avec Aspose.Cells. Il ne montre pas le comportement d’activation pour d’autres programmes de tableur.

## **Sections connexes**

- [Créer des graphiques Excel et les intégrer comme objets OLE dans les présentations](/slides/fr/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Mettre à jour les objets OLE automatiquement à l’aide d’un complément PowerPoint](/slides/fr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)