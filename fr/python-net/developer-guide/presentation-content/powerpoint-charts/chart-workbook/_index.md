---
title: Gérer les classeurs de graphiques dans les présentations avec Python
linktitle: Classeur de graphique
type: docs
weight: 70
url: /fr/python-net/chart-workbook/
keywords:
- classeur de graphique
- données de graphique
- cellule de classeur
- libellé de données
- feuille de calcul
- source de données
- classeur externe
- données externes
- cache de graphique
- récupération de classeur
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Découvrez Aspose.Slides pour Python via .NET : gérez facilement les classeurs de graphiques dans les formats PowerPoint et OpenDocument pour rationaliser les données de votre présentation."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les classeurs de graphiques dans Aspose.Slides. Il montre comment lire et écrire les données de graphique via des flux de classeur, utiliser les cellules du classeur comme libellés de données du graphique, accéder aux collections de feuilles de calcul et spécifier le type de source de données pour les valeurs du graphique.

Il couvre également l'utilisation de classeurs externes comme sources de données pour les graphiques. Les exemples démontrent comment créer et attribuer un classeur externe, récupérer le chemin d'un classeur externe lié à un graphique et modifier les données du graphique lorsque le classeur est disponible.

Pour les cellules du classeur qui représentent des données manquantes, consultez [Contrôler l’affichage des cellules vides](/slides/fr/python-net/chart-series/) pour la différence entre une cellule vide et zéro, ainsi qu’une comparaison en graphique linéaire des modes d’affichage disponibles.

## **Inclure les données des lignes et colonnes masquées**

Utilisez [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) pour contrôler si un graphique trace les données des lignes et colonnes de feuille de calcul masquées. Définissez‑le sur `True` pour tracer uniquement les cellules visibles, ou sur `False` pour inclure les cellules visibles et masquées. Ce paramètre contrôle le traçage du graphique ; il ne masque ni n’affiche les lignes ou colonnes de la feuille de calcul.

La [présentation d’exemple](hidden-source-data.pptx) contient un graphique à colonnes comme première forme de sa première diapositive. La feuille de calcul intégrée, `Sheet1`, contient la plage source suivante, `A1:C4`. La ligne 3 et la colonne C sont masquées, mais leurs cellules contiennent toujours des valeurs.

| Ligne de feuille de calcul | A : Mois | B : Vente au détail | C : Vente en gros (colonne masquée) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (ligne masquée) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Accédez aux cellules sources via [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) et lisez [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) pour inspecter leur statut masqué. Cette propriété est en lecture seule. Dans ce fichier, B2 est visible, B3 appartient à la ligne masquée et C2 appartient à la colonne masquée ; l’exemple affiche `False`, `True` et `True`, respectivement.

Pour cet exemple, actualisez les données du graphique après avoir modifié le paramètre d’affichage : conservez le classeur intégré avec [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) et rechargez‑le avec [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Lors de l’inclusion de toutes les cellules, utilisez également [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) pour restaurer la plage complète, y compris la catégorie février masquée. Changer simplement le drapeau ne suffit pas à actualiser les données mises en cache du graphique et les libellés de catégorie de cet exemple.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # Actualiser les données du graphique à partir du classeur intégré.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Restaurer la plage source complète, y compris les catégories masquées.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

L’exemple enregistre deux versions de la présentation : l’une avec uniquement les valeurs de vente au détail visibles (10 et 20), et l’autre avec les six valeurs. Les images ci‑dessous ont été rendues à partir des présentations enregistrées après les avoir ré‑ouvertes ; les deux fichiers conservent leur paramètre de traçage attribué. La ligne 3 et la colonne C restent masquées dans les deux classeurs intégrés.

| Seules les cellules visibles (`True`) | Toutes les cellules (`False`) |
| --- | --- |
| ![Seules les cellules visibles : valeurs de vente au détail 10 et 20 pour janvier et mars.](hidden_cells_True.png) | ![Toutes les cellules : valeurs de vente au détail et de gros pour janvier, février et mars.](hidden_cells_False.png) |

Une cellule masquée contenant une valeur diffère d’une cellule vide. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) contrôle la façon dont les valeurs manquantes sont affichées ; il n’inclut ni n’exclut les données sources masquées. Consultez [Contrôler l’affichage des cellules vides](/slides/fr/python-net/chart-series/#control-the-display-of-empty-cells) pour un exemple.

## **Récupérer la plage de données d’un graphique**

Avant de mettre à jour les données du classeur dans une présentation existante, inspectez les plages sources pour identifier les cellules de feuille de calcul utilisées par chaque graphique. La méthode [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) renvoie la plage de données actuelle sous forme de formule qualifiée par la feuille, par exemple `Sheet1!$A$1:$D$5`. Ici, `Sheet1` est le nom de la feuille, `!` le sépare de la plage de cellules, et `$A$1:$D$5` identifie les cellules A1 à D5 incluses. Les signes dollar indiquent des références absolues de ligne et de colonne.

La méthode lit la plage actuelle sans modifier le graphique ni son classeur. Si le graphique n’utilise pas de classeur comme source de données, elle lève une exception. Pour plus d’informations, consultez la [Référence API ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

Cet exemple ouvre une présentation et vérifie les formes directement sur chaque diapositive pour détecter les graphiques. Il affiche le nom de chaque graphique et sa plage source. Si la plage ne peut pas être récupérée, il affiche un message de diagnostic et passe au graphique suivant.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **Lire et écrire des données de graphique à partir d’un classeur**

Aspose.Slides for Python via .NET fournit les méthodes [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) et [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) qui vous permettent de lire et d’écrire les classeurs de données de graphiques (contenant des données de graphique éditées avec Aspose.Cells). **Note** : les données du graphique doivent être organisées de la même manière ou disposer d’une structure similaire à la source.

Cet exemple utilise une présentation avec un graphique comme première forme de sa première diapositive. Il lit le classeur intégré dans un flux, supprime les séries et catégories existantes, puis écrit le même classeur à nouveau. Les modifications restent en mémoire ; l’exemple n’enregistre pas la présentation.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **Valider la disposition du graphique après modification du classeur**

Lorsque vous remplacez un classeur intégré par un classeur modifié, le graphique conserve ses collections de séries et de catégories d’origine. Cette incohérence peut provoquer l’échec de [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) avec une erreur d’indice hors limites. Supprimez les séries et catégories existantes avant d’écrire le classeur mis à jour dans le graphique. Cet exemple utilise un graphique qui est la première forme de la première diapositive. Le commentaire indique où l’édition du classeur aurait lieu ; l’exemple exécutable écrit le classeur original et valide la disposition en mémoire.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Modifier le flux du classeur ici, par exemple en utilisant Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Le vidage des collections supprime les références de données obsolètes avant que le classeur ne soit réécrit. Reconstruisez les mappages de séries et de catégories nécessaires pour le classeur mis à jour avant d’utiliser le graphique.

## **Définir des formats numériques personnalisés pour les cellules du classeur**

Utilisez [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) pour contrôler l’apparence des valeurs numériques dans le classeur intégré d’un graphique. Par exemple, un rapport peut nécessiter un taux de conversion affiché en pourcentage avec quatre décimales et un coefficient affiché avec cinq décimales. Conservez les deux valeurs sous forme numérique afin qu’elles restent disponibles pour les calculs et le traçage du graphique.

Un format numérique change l’affichage, pas la valeur stockée. Le format `0.0000%` affiche `0.125` sous la forme `12.5000%` ; il ne remplace pas le nombre stocké par `12.5`. De même, `0.00000` affiche `0.1234567` sous la forme `0.12346` sans arrondir la valeur stockée. Si le format personnalisé est une chaîne vide (`""`), [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) est utilisé à la place.

L’exemple suivant crée un graphique à colonnes et accède à ses cellules via [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/). Sur la feuille 0, B2 contient le taux de conversion et C2 le coefficient. Les deux cellules fournissent les valeurs du graphique. L’exemple active également les libellés de valeur liés aux formats sources.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 270, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 20, 620, 210)
    chart.has_title = False

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00"
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A2", "Sample")
    chart.chart_data.categories.add(category_cell)

    percentage_cell = workbook.get_cell(0, "B2", 0.125)
    percentage_cell.custom_number_format = "0.0000%"
    percentage_name = workbook.get_cell(0, "B1", "Conversion rate")
    percentage_series = chart.chart_data.series.add(percentage_name, chart.type)
    percentage_series.data_points.add_data_point_for_bar_series(percentage_cell)

    precision_cell = workbook.get_cell(0, "C2", 0.1234567)
    precision_cell.custom_number_format = "0.00000"
    precision_name = workbook.get_cell(0, "C1", "Coefficient")
    precision_series = chart.chart_data.series.add(precision_name, chart.type)
    precision_series.data_points.add_data_point_for_bar_series(precision_cell)

    for series in chart.chart_data.series:
        label_format = series.data_points[0].label.data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = True

    presentation.save("CustomCellFormats.pptx", slides.export.SaveFormat.PPTX)
```

Les formats des cellules du classeur sont distincts des formats appliqués directement aux axes du graphique ou aux libellés de données. Dans cet exemple, chaque libellé affiche la valeur de sa cellule source parce que [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) est activé, et suit le format numérique source parce que [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) est `True`. Après avoir enregistré et rouvert la présentation, les libellés affichent `12.5000%` et `0.12346`, comme indiqué ci‑dessous. L’axe vertical utilise son propre [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) de `0.00`, avec [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) défini sur `False`.

Pour formater un libellé de données de façon indépendante, réglez son indicateur de lien source sur `False` et attribuez‑lui un [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/). Cela ne modifie pas le format de la cellule du classeur. Par exemple, un format de libellé indépendant `0.00` affiche la première valeur sous la forme `0.13`, tandis que B2 continue d’afficher `12.5000%`. Consultez [Libellés de données du graphique](/slides/fr/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) pour le formatage direct des libellés.

L’image ci‑dessous a été rendue à partir de la présentation enregistrée après l’avoir ré‑ouverte :

![Graphique à colonnes avec des libellés liés à la source affichant 12.5000% et 0.12346 et un axe numérique formaté indépendamment.](custom-cell-formats.png)

## **Utiliser une cellule du classeur comme libellé de données du graphique**

Vous pouvez utiliser le texte des cellules du classeur comme libellés de données du graphique.

Cet exemple ajoute un graphique à bulles avec des données par défaut à la première diapositive d’une présentation existante. Il utilise les cellules A10 : A12 de la feuille 0 pour les trois premiers libellés de la première série, active les libellés provenant des cellules et enregistre la présentation mise à jour.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **Gérer les feuilles de calcul**

La propriété [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) fournit l’accès aux feuilles de calcul d’un classeur de graphique. Cet exemple crée un graphique circulaire avec des données par défaut et affiche chaque nom de feuille de calcul dans la console.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **Spécifier le type de source de données**

Les valeurs des points de série peuvent également être stockées directement sous forme de littéraux numériques. Consultez [Définir les valeurs de séries à l’aide de littéraux numériques](/slides/fr/python-net/chart-series/#set-series-values-using-numeric-literals) pour un exemple complet qui les enregistre et les lit. Le type de source des valeurs des points est distinct de la configuration interne ou externe du classeur du graphique ; l’utilisation de littéraux numériques ne supprime pas, à elle seule, le classeur intégré.

Cet exemple crée un graphique à colonnes 3D avec des données par défaut et définit deux noms de séries en utilisant des sources de données différentes. Le premier nom utilise un littéral de chaîne ; le second utilise la cellule C1 de la feuille 0. L’énumération [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) sélectionne la source pour chaque nom. L’exemple enregistre la présentation avec les noms de séries mis à jour.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Détecter les formats de classeur intégré non pris en charge**

Aspose.Slides ne prend pas en charge le format de classeur Excel binaire (.xlsb) qui peut être intégré à certains graphiques. Vous pouvez utiliser la propriété [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) de [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) conjointement avec l’énumération [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) pour détecter les formats non pris en charge et ignorer ces graphiques. Cet exemple inspecte les formes de la première diapositive d’une présentation existante, ignore les formes ne étant pas des graphiques et affiche un message de diagnostic pour chaque graphique contenant un classeur .xlsb intégré.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # Lire ou modifier les données de classeur de graphique prises en charge ici.
```

## **Classeur externe**

Aspose.Slides prend en charge l’utilisation de classeurs externes comme source de données pour les graphiques.

### **Créer un classeur externe**

Utilisez [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) et [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) pour exporter le classeur intégré d’un graphique vers un fichier et lier le graphique à ce classeur externe.

Cet exemple crée un graphique circulaire avec des données par défaut et exporte son classeur. Il ferme le flux de sortie avant d’attribuer le classeur externe comme source de données du graphique, puis enregistre la présentation liée.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)

    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Définir un classeur externe**

En utilisant la méthode [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/), vous pouvez attribuer un classeur externe à un graphique comme source de données. Cette méthode peut également servir à mettre à jour le chemin du classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas modifier les données des classeurs stockés dans des emplacements ou ressources distants, vous pouvez toujours les utiliser comme source de données externe. Si le chemin relatif d’un classeur externe est fourni, il est automatiquement converti en chemin complet.

Cet exemple utilise un classeur externe dont la feuille nommée `Sheet1` contient un nom de série en B1, des noms de catégorie en A2 : A4 et des valeurs numériques en B2 : B4. L’exemple crée un graphique circulaire, lie le classeur et utilise [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) pour mapper A1 : B4 à une série et trois catégories. Il enregistre la présentation avec le graphique lié.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

Le paramètre `update_chart_data` de [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) contrôle si le classeur est chargé.

* Lorsque `update_chart_data` est `False`, seul le chemin du classeur est mis à jour. Les données du graphique ne sont pas chargées ni mises à jour à partir du classeur cible, de sorte que le classeur peut être indisponible.
* Lorsque `update_chart_data` est `True`, les données du graphique sont mises à jour à partir du classeur cible.

L’exemple suivant attribue une URL factice avec `update_chart_data` défini sur `False`. Il conserve les données par défaut du graphique circulaire et enregistre la présentation sans charger le classeur indisponible.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Obtenir le chemin du classeur source de données externe d’un graphique**

Pour identifier le classeur lié à un graphique, vérifiez si le graphique utilise une source de données externe et récupérez son chemin de classeur.

Cet exemple inspecte la première forme de la première diapositive d’une présentation avec un classeur externe lié. Si c’est un graphique lié à un classeur externe, l’exemple affiche [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) dans la console. Il enregistre ensuite une copie de la présentation.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **Modifier les données du graphique**

Vous pouvez modifier les données des classeurs externes de la même manière que vous modifiez le contenu des classeurs internes. Lorsqu’un classeur externe ne peut pas être chargé, une exception est levée.

Cet exemple utilise un graphique qui est la première forme de la première diapositive et qui est lié à un classeur externe accessible. Il attribue la valeur basée sur la cellule du premier point de données de la première série à 100 et enregistre la présentation mise à jour. Modifier les valeurs des cellules peut mettre à jour le fichier XLSX externe lié, alors utilisez une copie si vous devez préserver le classeur original.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **Récupérer un classeur à partir du cache du graphique**

Si un graphique utilise un classeur externe qui manque ou est indisponible, Aspose.Slides peut reconstruire le classeur du graphique à partir des données mises en cache dans la présentation. Créez [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), configurez son [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), et définissez [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) sur `True` avant d’ouvrir la présentation.

L’exemple Python suivant récupère les données du classeur pour un graphique qui est la première forme de la première diapositive et qui référence un classeur externe indisponible. Il accède aux données récupérées via [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) et [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) :

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # Lire ou modifier les données du classeur récupéré ici.
    else:
        print("The first shape is not a chart.")
```

Si le classeur externe est indisponible et que la récupération est désactivée, Aspose.Slides lève une exception. Activez la récupération uniquement lorsque l’utilisation des données de graphique mises en cache constitue une solution de repli acceptable, car le cache peut ne pas contenir les modifications apportées au classeur externe après la dernière mise à jour de la présentation.

## **FAQ**

**Puis‑je déterminer si un graphique spécifique est lié à un classeur externe ou intégré ?**

Oui. Un graphique possède un [type de source de données](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) et un [chemin vers un classeur externe](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); si la source est un classeur externe, vous pouvez lire le chemin complet pour vous assurer qu’un fichier externe est utilisé.

**Les chemins relatifs vers les classeurs externes sont‑ils pris en charge, et comment sont‑ils stockés ?**

Oui. Si vous spécifiez un chemin relatif, il est automatiquement converti en chemin absolu. La présentation stocke le chemin absolu dans le fichier PPTX, de sorte que le déplacement du classeur peut nécessiter la mise à jour du lien.

**Puis‑je utiliser des classeurs situés sur des ressources ou partages réseau ?**

Oui, ces classeurs peuvent être utilisés comme source de données externe. Cependant, la modification directe de classeurs distants depuis Aspose.Slides n’est pas prise en charge ; ils ne peuvent être utilisés qu’en tant que source.

**Aspose.Slides écrase‑t‑il le fichier XLSX externe lors de l’enregistrement de la présentation ?**

La présentation stocke un [lien vers le fichier externe](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Modifier les données du graphique basées sur des cellules peut également mettre à jour le fichier XLSX local lié. Utilisez une copie du classeur si l’original doit rester inchangé.

**Que faire si le fichier externe est protégé par un mot de passe ?**

Aspose.Slides n’accepte pas de mot de passe lors de la création du lien. Une approche courante consiste à retirer la protection au préalable ou à préparer une copie décryptée (par exemple avec [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) et à lier cette copie.

**Plusieurs graphiques peuvent‑ils référencer le même classeur externe ?**

Oui. Chaque graphique stocke son propre lien. S’ils pointent tous vers le même fichier, la mise à jour de ce fichier sera reflétée dans chaque graphique lors du prochain chargement des données.