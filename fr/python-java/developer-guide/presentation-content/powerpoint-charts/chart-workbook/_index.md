---
title: Gestion des classeurs de graphiques dans les présentations avec Python via Java
linktitle: Classeur de graphique
type: docs
weight: 70
url: /fr/python-java/chart-workbook/
keywords:
- classeur de graphique
- données de graphique
- cellule de classeur
- étiquette de donnée
- feuille de calcul
- source de données
- classeur externe
- données externes
- cache de graphique
- récupération de classeur
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Découvrez Aspose.Slides pour Python via Java : gérez facilement les classeurs de graphiques dans les formats PowerPoint et OpenDocument afin d’optimiser les données de votre présentation."
---
## **Aperçu**

Cet article explique comment travailler avec les classeurs de graphiques dans Aspose.Slides. Il montre comment lire et écrire les données d’un graphique via des flux de classeur, utiliser les cellules du classeur comme étiquettes de données, accéder aux collections de feuilles de calcul et spécifier le type de source de données pour les valeurs du graphique.

Il couvre également l’utilisation de classeurs externes comme sources de données pour les graphiques. Les exemples démontrent comment créer et affecter un classeur externe, récupérer le chemin d’un classeur externe lié à un graphique et modifier les données du graphique lorsque le classeur est disponible.

Pour les cellules du classeur représentant des données manquantes, voir [Contrôler l'affichage des cellules vides](/slides/fr/python-java/chart-series/) pour la différence entre une cellule vide et zéro, et une comparaison en diagramme en courbes des modes d’affichage disponibles.

## **Inclure les données des lignes et colonnes masquées**

Utilisez [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) pour contrôler si un graphique trace les données provenant de lignes et colonnes de feuille masquées. Réglez-le sur `True` pour tracer uniquement les cellules visibles, ou sur `False` pour inclure à la fois les cellules visibles et masquées. Ce paramètre contrôle le tracé du graphique ; il ne masque ni n’affiche les lignes ou colonnes de la feuille.

La [sample presentation](hidden-source-data.pptx) contient un graphique en colonnes comme première forme de la première diapositive. La feuille incorporée, `Sheet1`, contient la plage source suivante, `A1:C4`. La ligne 3 et la colonne C sont masquées, mais leurs cellules contiennent toujours des valeurs.

| Ligne de la feuille de calcul | A: Mois | B: Vente au détail | C: Vente en gros (colonne masquée) |
| --- | --- | --- | --- |
| 2 | Janvier | 10 | 30 |
| 3 (ligne masquée) | Février | 40 | 60 |
| 4 | Mars | 20 | 50 |

Accédez aux cellules sources via [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) et lisez [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) pour inspecter leur état masqué. Cette méthode rapporte l’état masqué sans le modifier. Dans ce fichier, B2 est visible, B3 appartient à la ligne masquée et C2 appartient à la colonne masquée ; l’exemple affiche `False`, `True` et `True`, respectivement.

Pour cet exemple, actualisez les données du graphique après avoir modifié le paramètre de traçage : conservez le classeur incorporé avec [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) et rechargez-le avec [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream). Lors de l’inclusion de toutes les cellules, utilisez également [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) pour restaurer la plage complète, y compris la catégorie février masquée. Modifier simplement le drapeau n’est pas suffisant pour actualiser les données du graphique et les étiquettes de catégorie en cache de cet échantillon.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # Rafraîchir les données du graphique à partir du classeur incorporé.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Restaurer la plage source complète, y compris les catégories masquées.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

L’exemple enregistre deux versions de la présentation : l’une avec uniquement les valeurs de vente au détail visibles (10 et 20), et l’autre avec les six valeurs. Les images ci‑dessous illustrent les deux modes de traçage. La ligne 3 et la colonne C restent masquées dans les deux classeurs incorporés.

| Cellules visibles uniquement (`True`) | Toutes les cellules (`False`) |
| --- | --- |
| ![Cellules visibles uniquement : valeurs de vente au détail 10 et 20 pour janvier et mars.](hidden_cells_True.png) | ![Toutes les cellules : valeurs de vente au détail et en gros pour janvier, février et mars.](hidden_cells_False.png) |

Une cellule masquée contenant une valeur diffère d’une cellule vide. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) contrôle la façon dont les valeurs manquantes sont affichées ; il n’inclut pas et n’exclut pas les données sources masquées. Voir [Contrôler l'affichage des cellules vides](/slides/fr/python-java/chart-series/#control-the-display-of-empty-cells) pour un exemple.

## **Récupérer la plage de données d’un graphique**

Avant de mettre à jour les données du classeur dans une présentation existante, inspectez les plages sources pour identifier quelles cellules de feuille chaque graphique utilise. La méthode [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) renvoie la plage de données actuelle sous forme de formule qualifiée par feuille, comme `Sheet1!$A$1:$D$5`. Ici, `Sheet1` est le nom de la feuille, `!` la sépare de la plage de cellules, et `$A$1:$D$5` identifie les cellules A1 à D5 incluses. Les signes dollar indiquent des références absolues de ligne et de colonne.

La méthode lit la plage actuelle sans modifier le graphique ou son classeur. Si le graphique n’utilise pas de classeur comme source de données, elle lève `InvalidOperationException`. Pour plus d’informations, voir la [Référence API ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/).

Cet exemple ouvre une présentation et examine les formes directement sur chaque diapositive à la recherche de graphiques. Il affiche le nom de chaque graphique et sa plage source. Si un graphique n’utilise pas de classeur, il affiche un message et passe au graphique suivant.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **Lire et écrire les données du graphique depuis un classeur**

Aspose.Slides for Python via Java fournit les méthodes [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) et [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) qui permettent de lire et d’écrire les classeurs de données de graphiques (contenant des données de graphique éditées avec Aspose.Cells). **Note** que les données du graphique doivent être organisées de la même manière ou posséder une structure similaire à la source.

Cet exemple utilise une présentation avec un graphique comme première forme de la première diapositive. Il lit le classeur incorporé dans un tableau d’octets, efface les séries et catégories existantes, puis réécrit le même classeur. Les modifications restent en mémoire ; l’exemple n’enregistre pas la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Valider la mise en page du graphique après modification du classeur**

Lorsque vous remplacez un classeur incorporé par un modifié, le graphique conserve ses collections de séries et de catégories d’origine. Cette incohérence peut entraîner l’échec de [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) avec une erreur d’indice hors plage. Effacez les séries et catégories existantes avant d’écrire le classeur mis à jour dans le graphique. Cet exemple utilise un graphique qui est la première forme de la première diapositive. Le commentaire indique où l’édition du classeur aurait lieu ; l’exemple exécutable réécrit le classeur original et valide la mise en page en mémoire.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # Modifiez les octets du classeur ici, par exemple en utilisant Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Effacer les collections supprime les références de données obsolètes avant que le classeur ne soit réécrit. Reconstruisez les mappages de séries et de catégories nécessaires pour le classeur mis à jour avant d’utiliser le graphique.

## **Définir des formats numériques personnalisés pour les cellules du classeur**

Utilisez [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) pour contrôler l’apparence des valeurs numériques dans le classeur incorporé d’un graphique. Par exemple, un rapport peut nécessiter qu’un taux de conversion s’affiche en pourcentage avec quatre décimales et qu’un coefficient s’affiche avec cinq décimales. Conservez les deux valeurs sous forme numérique afin qu’elles restent disponibles pour les calculs et le tracé du graphique.

Un format numérique change l’affichage, pas la valeur stockée. Le format `0.0000%` affiche `0.125` sous forme `12.5000%` ; il ne remplace pas le nombre stocké par `12.5`. De même, `0.00000` affiche `0.1234567` sous forme `0.12346` sans arrondir la valeur stockée. Si le format personnalisé est une chaîne vide (`""`), le format renvoyé par [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat) est utilisé à la place.

L’exemple suivant crée un graphique en colonnes et accède à ses cellules via [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook). Dans la feuille 0, B2 contient le taux de conversion et C2 le coefficient. Les deux cellules alimentent les valeurs du graphique. L’exemple active également les étiquettes de valeur liées aux formats source.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210)
    chart.setTitle(False)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00")
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(0)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A2", "Sample")
    chart.getChartData().getCategories().add(category_cell)

    percentage_cell = workbook.getCell(0, "B2", jpype.JDouble(0.125))
    percentage_cell.setCustomNumberFormat("0.0000%")
    percentage_name = workbook.getCell(0, "B1", "Conversion rate")
    percentage_series = chart.getChartData().getSeries().add(percentage_name, chart.getType())
    percentage_series.getDataPoints().addDataPointForBarSeries(percentage_cell)

    precision_cell = workbook.getCell(0, "C2", jpype.JDouble(0.1234567))
    precision_cell.setCustomNumberFormat("0.00000")
    precision_name = workbook.getCell(0, "C1", "Coefficient")
    precision_series = chart.getChartData().getSeries().add(precision_name, chart.getType())
    precision_series.getDataPoints().addDataPointForBarSeries(precision_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(True)

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Les formats des cellules du classeur sont distincts des formats appliqués directement aux axes du graphique ou aux étiquettes de données. Dans cet exemple, chaque étiquette affiche la valeur de sa cellule source parce que [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) est réglé sur `True`, et suit le format numérique source parce que [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) est réglé sur `True`. Après avoir enregistré et rouvert la présentation, les étiquettes affichent `12.5000%` et `0.12346`, comme indiqué ci‑dessous. L’axe vertical utilise son propre format numérique, assigné avec [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) à `0.00`, avec [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) réglé sur `False`.

Pour formater une étiquette de données de manière indépendante, définissez son indicateur de liaison à la source sur `False` et attribuez‑lui un format avec [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat). Cela ne modifie pas le format de la cellule du classeur. Par exemple, un format d’étiquette indépendant de `0.00` affiche la première valeur sous forme `0.13`, tandis que B2 continue d’afficher `12.5000%`. Voir [Étiquettes de données du graphique](/slides/fr/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) pour le formatage direct des étiquettes.

![Graphique en colonnes avec étiquettes liées à la source affichant 12.5000% et 0.12346 et un axe numérique formaté de manière indépendante.](custom-cell-formats.png)

## **Utiliser une cellule de classeur comme étiquette de données du graphique**

Vous pouvez utiliser le texte des cellules du classeur comme étiquettes de données du graphique.

Cet exemple ajoute un graphique à bulles avec des données par défaut à la première diapositive d’une présentation existante. Il utilise les cellules A10 : A12 de la feuille 0 pour les trois premières étiquettes de la première série, active les étiquettes provenant des cellules et enregistre la présentation mise à jour.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)

    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gérer les feuilles de calcul**

La méthode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) fournit l’accès aux feuilles de calcul d’un classeur de graphique. Cet exemple crée un graphique circulaire avec des données par défaut et affiche chaque nom de feuille dans la console.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Spécifier le type de source de données**

Cet exemple crée un graphique à colonnes 3D avec des données par défaut et définit deux noms de séries en utilisant des sources de données différentes. Le premier nom utilise une chaîne littérale ; le second utilise la cellule C1 de la feuille 0. L’énumération [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) sélectionne la source pour chaque nom. L’exemple enregistre la présentation avec les noms de séries mis à jour.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Détecter les formats de classeur incorporés non pris en charge**

Aspose.Slides ne prend pas en charge le format de classeur Excel binaire (.xlsb) qui peut être incorporé dans certains graphiques. Vous pouvez utiliser la méthode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) sur [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) conjointement avec l’énumération [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) pour détecter les formats non pris en charge et ignorer ces graphiques. Cet exemple examine les formes de la première diapositive d’une présentation existante, ignore les formes qui ne sont pas des graphiques et affiche un message de diagnostic pour chaque graphique avec un classeur .xlsb incorporé.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        chart_data = shape.getChartData()

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # Lire ou modifier les données du classeur de graphique prises en charge ici.
finally:
    presentation.dispose()
```

## **Classeur externe**

Aspose.Slides prend en charge l’utilisation de classeurs externes comme source de données pour les graphiques.

### **Créer un classeur externe**

Utilisez [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) et [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) pour exporter un classeur de graphique incorporé vers un fichier et lier le graphique à ce classeur externe.

Cet exemple crée un graphique circulaire avec des données par défaut et exporte son classeur. Il termine l’écriture du fichier avant d’attribuer le classeur externe comme source de données du graphique, puis enregistre la présentation liée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Définir un classeur externe**

En utilisant la méthode [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook), vous pouvez affecter un classeur externe à un graphique comme source de données. Cette méthode peut également être utilisée pour mettre à jour le chemin du classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas modifier les données des classeurs stockés à distance ou dans des ressources, vous pouvez néanmoins les utiliser comme source de données externe. Si un chemin relatif est fourni pour un classeur externe, il est automatiquement converti en chemin complet.

Cet exemple utilise un classeur externe dont la feuille nommée `Sheet1` contient un nom de série en B1, des noms de catégorie en A2 : A4 et des valeurs numériques en B2 : B4. L’exemple crée un graphique circulaire, lie le classeur et utilise [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) pour associer A1 : B4 à une série et trois catégories. Il enregistre la présentation avec le graphique lié.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le paramètre `updateChartData` de [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) contrôle si le classeur est chargé.

* Lorsque `updateChartData` est `False`, seul le chemin du classeur est mis à jour. Les données du graphique ne sont pas chargées ni mises à jour à partir du classeur cible, de sorte que le classeur peut être indisponible.
* Lorsque `updateChartData` est `True`, les données du graphique sont mises à jour à partir du classeur cible.

L’exemple suivant attribue une URL fictive avec `updateChartData` réglé sur `False`. Il conserve les données par défaut du graphique circulaire et enregistre la présentation sans charger le classeur indisponible.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Obtenir le chemin du classeur source de données externe d’un graphique**

Pour identifier le classeur lié à un graphique, vérifiez si le graphique utilise une source de données externe et récupérez son chemin.

Cet exemple examine la première forme de la première diapositive d’une présentation avec un classeur externe lié. Si c’est un graphique lié à un classeur externe, l’exemple affiche [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) dans la console. Il enregistre ensuite une copie de la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Modifier les données du graphique**

Vous pouvez modifier les données des classeurs externes de la même manière que vous modifiez le contenu des classeurs internes. Lorsqu’un classeur externe ne peut pas être chargé, une exception est levée.

Cet exemple utilise un graphique qui est la première forme de la première diapositive et est lié à un classeur externe accessible. Il définit la valeur soutenue par la cellule du premier point de données de la première série à 100 et enregistre la présentation mise à jour. Modifier les valeurs de cellule peut mettre à jour le fichier XLSX externe lié, utilisez donc une copie si vous devez conserver le classeur d’origine.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Récupérer un classeur à partir du cache du graphique**

Si un graphique utilise un classeur externe manquant ou indisponible, Aspose.Slides peut reconstruire le classeur du graphique à partir des données mises en cache dans la présentation. Créez [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/), appelez [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) et définissez [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) sur `True` avant d’ouvrir la présentation.

L’exemple Python suivant récupère les données du classeur pour un graphique qui est la première forme de la première diapositive et référence un classeur externe indisponible. Il accède aux données récupérées via [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) et [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # Lire ou modifier les données du classeur récupéré ici.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Si le classeur externe est indisponible et que la récupération est désactivée, Aspose.Slides lève une exception. Activez la récupération uniquement lorsque l’utilisation des données du graphique en cache constitue une solution de repli acceptable, car le cache peut ne pas contenir les modifications apportées au classeur externe après la dernière mise à jour de la présentation.

## **FAQ**

**Puis‑je déterminer si un graphique spécifique est lié à un classeur externe ou incorporé ?**

Oui. Un graphique possède un [type de source de données](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) et un [chemin vers un classeur externe](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) ; si la source est un classeur externe, vous pouvez lire le chemin complet pour vous assurer qu’un fichier externe est utilisé.

**Les chemins relatifs vers les classeurs externes sont‑ils pris en charge, et comment sont‑ils stockés ?**

Oui. Si vous indiquez un chemin relatif, il est automatiquement converti en chemin absolu. La présentation stocke le chemin absolu dans le fichier PPTX, de sorte que le déplacement du classeur peut nécessiter une mise à jour du lien.

**Puis‑je utiliser des classeurs situés sur des ressources ou partages réseau ?**

Oui, ces classeurs peuvent être utilisés comme source de données externe. Cependant, la modification directe de classeurs distants depuis Aspose.Slides n’est pas prise en charge ; ils ne peuvent être utilisés que comme source.

**Aspose.Slides écrase‑t‑il le fichier XLSX externe lors de l’enregistrement de la présentation ?**

La présentation stocke un [lien vers le fichier externe](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Modifier les données de graphique soutenues par une cellule peut également mettre à jour le fichier XLSX local lié. Utilisez une copie du classeur si l’original doit rester inchangé.

**Que faire si le fichier externe est protégé par un mot de passe ?**

Aspose.Slides n’accepte pas de mot de passe lors de la liaison. Une approche courante consiste à enlever la protection au préalable ou à préparer une copie décryptée (par exemple avec [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) et à la lier.

**Plusieurs graphiques peuvent‑ils référencer le même classeur externe ?**

Oui. Chaque graphique stocke son propre lien. S’ils pointent tous vers le même fichier, la mise à jour de ce fichier sera reflétée dans chaque graphique lors du prochain chargement des données.