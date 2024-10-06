---
title: Album de graphiques
type: docs
weight: 70
url: /python-net/chart-workbook/
keywords: "Album de graphiques, données de graphique, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Album de graphiques dans une présentation PowerPoint en Python"
---

## **Définir les données de graphique depuis le classeur**

Aspose.Slides fournit certaines méthodes qui vous permettent de lire et d'écrire des classeurs de données de graphique (contenant des données de graphique éditées avec Aspose.Cells). **Remarque** : les données de graphique doivent être organisées de la même manière ou doivent avoir une structure similaire à celle de la source.

Ce code Python démontre une opération exemple :

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instancie une classe Presentation qui représente un fichier de présentation 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series

    series[0].labels.default_data_label_format.show_label_value_from_cell = True

    wb = chart.chart_data.chart_data_workbook

    series[0].labels[0].value_from_cell = wb.get_cell(0, "A10", "Valeur de la cellule d'étiquette 0")
    series[0].labels[1].value_from_cell = wb.get_cell(0, "A11", "Valeur de la cellule d'étiquette 1")
    series[0].labels[2].value_from_cell = wb.get_cell(0, "A12", "Valeur de la cellule d'étiquette 2")

    pres.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la cellule du classeur comme étiquette de données de graphique**

1. Créez une instance de la classe [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/).
1. Obtenez une référence de diapositive par son index.
1. Ajoutez un graphique en bulle avec quelques données.
1. Accédez aux séries de graphiques.
1. Définissez la cellule du classeur comme une étiquette de données.
1. Enregistrez la présentation.

Ce code Python vous montre comment définir une cellule de classeur comme étiquette de données de graphique : xxx

```python

```

## **Gérer les feuilles de calcul**

Ce code Python démontre une opération où la propriété `worksheets` est utilisée pour accéder à une collection de feuilles de calcul :

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
   chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
   wb =  chart.chart_data.chart_data_workbook
   for i in range(len(wb.worksheets)):
      print(wb.worksheets[i].name)
```

## **Spécifier le type de source de données**

Ce code Python vous montre comment spécifier un type pour une source de données : 

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    val = chart.chart_data.series[0].name

    val.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    val.data = "LiteralString"

    val = chart.chart_data.series[0].name
    val.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NouvelleCellule")

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Classeur externe**

{{% alert color="primary" %}} 
Dans [Aspose.Slides pour .NET 19.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-19-4-release-notes/), nous avons implémenté le support des classeurs externes comme source de données pour les graphiques.
{{% /alert %}} 

### **Créer un classeur externe**

En utilisant certaines méthodes de **`IChartData`**, vous pouvez créer un classeur externe à partir de zéro ou rendre un classeur interne externe.

Ce code Python démontre le processus de création de classeur externe :

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:

    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.chart_data_workbook.clear(0)

    chart.chart_data.set_external_workbook(path + "externalWorkbook.xlsx")

    chart.chart_data.set_range("Sheet1!$A$2:$B$5")
    series = chart.chart_data.series[0]
    series.parent_series_group.is_color_varied = True
    pres.save("response2.pptx", slides.export.SaveFormat.PPTX)
```

### **Définir un classeur externe**

En utilisant la méthode **`chartData.set_external_workbook`**, vous pouvez assigner un classeur externe à un graphique comme source de données. Cette méthode peut également être utilisée pour mettre à jour un chemin vers le classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas éditer les données dans des classeurs stockés à distance ou des ressources, vous pouvez toujours utiliser de tels classeurs comme source de données externe. Si le chemin relatif d'un classeur externe est fourni, il est automatiquement converti en chemin complet.

Ce code Python vous montre comment définir un classeur externe :

```python
import aspose.slides.charts as charts
import aspose.slides as slides

# Le chemin vers le répertoire des documents.
with slides.Presentation() as pres:

    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chartData = chart.chart_data
                    
    chartData.set_external_workbook(path + "externalWorkbook.xlsx")
                  
    chartData.series.add(chartData.chart_data_workbook.get_cell(0, "B1"), charts.ChartType.PIE)
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B2"))
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B3"))
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B4"))

    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A2"))
    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A3"))
    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A4"))
    pres.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

Le paramètre `chart_data` (sous la méthode `set_external_workbook`) est utilisé pour spécifier si un classeur Excel sera chargé ou non. 

* Lorsque la valeur de `chart_data` est définie sur `false`, seul le chemin du classeur est mis à jour - les données du graphique ne seront pas chargées ni mises à jour à partir du classeur cible. Vous pouvez vouloir utiliser ce réglage lorsque vous êtes dans une situation où le classeur cible est inexistant ou indisponible. 
* Lorsque la valeur de `chart_data` est définie sur `true`, les données du graphique sont mises à jour à partir du classeur cible.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chartData = chart.chart_data

    chartData.set_external_workbook("http://path/doesnt/exists", False)

    pres.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Obtenir le chemin du classeur source de données externe du graphique**

1. Créez une instance de la classe [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/).
1. Obtenez une référence de diapositive par son index.
1. Créez un objet pour la forme du graphique.
1. Créez un objet pour le type source (`ChartDataSourceType`) qui représente la source de données du graphique.
1. Spécifiez la condition pertinente en fonction du type source étant le même que celui de la source de données de classeur externe.

Ce code Python démontre l'opération :

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("response2.pptx") as pres:
    chart = pres.slides[0].shapes[0]
    sourceType = chart.chart_data.data_source_type
    if sourceType == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Modifier les données du graphique**

Vous pouvez modifier les données dans les classeurs externes de la même manière que vous apportez des modifications aux contenus des classeurs internes. Lorsqu'un classeur externe ne peut pas être chargé, une exception est levée.

Ce code Python est une implémentation du processus décrit :

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "presentation.pptx") as pres:
    pres.slides[0].shapes[0].chart_data.series[0].data_points[0].value.as_cell.value = 100
    pres.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
```