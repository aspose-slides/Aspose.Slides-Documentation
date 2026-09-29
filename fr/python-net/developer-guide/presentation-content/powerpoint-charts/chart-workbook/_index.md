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
- récupération du classeur
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Découvrez Aspose.Slides pour Python via .NET : gérez facilement les classeurs de graphiques dans les formats PowerPoint et OpenDocument pour optimiser les données de votre présentation."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les classeurs de graphiques dans Aspose.Slides. Il montre comment lire et écrire les données d’un graphique via des flux de classeur, utiliser les cellules du classeur comme libellés de données, accéder aux collections de feuilles de calcul et spécifier le type de source de données pour les valeurs du graphique.

Il couvre également l’utilisation de classeurs externes comme sources de données de graphiques. Les exemples démontrent comment créer et associer un classeur externe, récupérer le chemin d’un classeur externe lié à un graphique, et modifier les données du graphique lorsque le classeur est disponible.

Pour les cellules du classeur représentant des données manquantes, voir [Contrôler l'affichage des cellules vides](/slides/fr/python-net/chart-series/) pour la différence entre une cellule vide et zéro, et une comparaison en graphique en courbes des modes d’affichage disponibles.

## **Inclure les données des lignes et colonnes masquées**

Utilisez [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) pour contrôler si un graphique trace les données provenant de lignes et colonnes de feuille masquées. Réglez-le sur `True` pour tracer uniquement les cellules visibles, ou sur `False` pour inclure à la fois les cellules visibles et masquées. Ce paramètre contrôle le traçage du graphique ; il ne masque ni n’affiche les lignes ou colonnes de la feuille.

Téléchargez [hidden-source-data.pptx](hidden-source-data.pptx) et placez‑le dans le répertoire de travail. Sa première diapositive contient un graphique en colonnes comme première forme. La feuille de calcul intégrée, `Sheet1`, contient la plage source suivante, `A1:C4`. La ligne 3 et la colonne C sont masquées, mais leurs cellules contiennent toujours des valeurs.

| Ligne de la feuille | A : Mois | B : Détail | C : Grossiste (colonne masquée) |
| --- | --- | --- | --- |
| 2 | Janvier | 10 | 30 |
| 3 (ligne masquée) | Février | 40 | 60 |
| 4 | Mars | 20 | 50 |

Accédez aux cellules sources via [ChartData.chart_data_workbook](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) et lisez [ChartDataCell.is_hidden](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdatacell/is_hidden/) pour inspecter leur statut masqué. Cette propriété est en lecture seule. Dans ce fichier, B2 est visible, B3 appartient à la ligne masquée, et C2 appartient à la colonne masquée ; l’exemple affiche `False`, `True` et `True` respectivement.

Pour cet exemple, rafraîchissez les données du graphique après avoir modifié le paramètre de traçage : conservez le classeur intégré avec [read_workbook_stream](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) et rechargez‑le avec [write_workbook_stream](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Lors de l’inclusion de toutes les cellules, utilisez également [set_range](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/set_range/) pour restaurer la plage complète, y compris la catégorie de février masquée. Simplement changer le drapeau ne suffit pas à rafraîchir les données mises en cache de cet exemple.

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

            # Rafraîchir les données du graphique à partir du classeur intégré.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Restaurer la plage source complète, y compris les catégories masquées.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

L’exemple enregistre `hidden_cells_True.pptx` avec uniquement les valeurs détaillées visibles (10 et 20), et `hidden_cells_False.pptx` avec les six valeurs. Les images ci‑dessous proviennent des présentations enregistrées après les avoir rouvertes ; les deux fichiers conservent leur paramètre de traçage assigné. La ligne 3 et la colonne C restent masquées dans les deux classeurs intégrés.

| Seulement les cellules visibles (`True`) | Toutes les cellules (`False`) |
| --- | --- |
| ![Seulement les cellules visibles : valeurs détaillées 10 et 20 pour janvier et mars.](hidden_cells_True.png) | ![Toutes les cellules : valeurs détaillées et grossistes pour janvier, février et mars.](hidden_cells_False.png) |

Une cellule masquée contenant une valeur diffère d’une cellule vide. [Chart.display_blanks_as](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chart/display_blanks_as/) contrôle la façon dont les valeurs manquantes sont affichées ; il n’inclut ni n’exclut les données sources masquées. Voir [Contrôler l'affichage des cellules vides](/slides/fr/python-net/chart-series/#control-the-display-of-empty-cells) pour un exemple.

## **Lire et écrire des données de graphique depuis un classeur**

Aspose.Slides for Python via .NET fournit les méthodes [read_workbook_stream](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) et [write_workbook_stream](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) qui permettent de lire et d’écrire les classeurs de données de graphiques (contenant des données modifiées avec Aspose.Cells). **Remarque** : les données du graphique doivent être organisées de la même façon ou disposer d’une structure similaire à la source.

Cet exemple ouvre `chart.pptx`, qui doit contenir un graphique comme première forme de sa première diapositive. Il lit le classeur intégré dans un flux, efface les séries et catégories existantes, puis réécrit le même classeur. Les modifications restent en mémoire ; l’exemple n’enregistre pas la présentation.

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

Lorsque vous remplacez un classeur intégré par un classeur modifié, le graphique conserve ses collections de séries et de catégories d’origine. Cette incohérence peut entraîner l’échec de [Chart.validate_chart_layout](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chart/validate_chart_layout/) avec une erreur d’indice hors limites. Effacez les séries et catégories existantes avant d’écrire le classeur mis à jour dans le graphique. Cet exemple nécessite `chart.pptx` avec un graphique comme première forme de sa première diapositive. Le commentaire indique où l’édition du classeur aurait lieu ; l’exemple exécutable réécrit le classeur original et valide la disposition en mémoire.

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

Effacer les collections supprime les références de données périmées avant que le classeur ne soit réécrit. Reconstruisez les mappages de séries et de catégories nécessaires pour le classeur mis à jour avant d’utiliser le graphique.

## **Définir une cellule de classeur comme libellé de données du graphique**

Vous pouvez utiliser le texte des cellules du classeur comme libellés de données du graphique. Les étapes suivantes montrent comment lier les libellés d’un graphique à bulles aux cellules de son classeur de données.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Accédez à la première diapositive par son indice zéro.
1. Ajoutez un graphique à bulles avec des données par défaut.
1. Accédez à la série du graphique.
1. Définissez la cellule du classeur comme libellé de données.
1. Enregistrez la présentation.

Cet exemple ouvre `chart2.pptx`, qui doit contenir au moins une diapositive, et ajoute un graphique à bulles avec des données par défaut. Il utilise les cellules A10 : A12 de la feuille 0 pour les trois premiers libellés de la première série, active les libellés provenant des cellules, et enregistre le résultat dans `resultchart.pptx`.

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

La propriété [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) offre l’accès aux feuilles de calcul d’un classeur de graphique. Cet exemple crée un graphique circulaire avec des données par défaut et affiche chaque nom de feuille dans la console.

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

Cet exemple crée un graphique en colonnes 3D avec des données par défaut et définit deux noms de séries en utilisant des sources de données différentes. Le premier nom utilise une chaîne littérale ; le second utilise la cellule C1 de la feuille 0. L’énumération [DataSourceType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/datasourcetype/) sélectionne la source pour chaque nom. Le résultat est enregistré dans `pres.pptx`.

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

Aspose.Slides ne prend pas en charge le format de classeur Excel binaire (.xlsb) pouvant être intégré dans certains graphiques. Vous pouvez utiliser la propriété [embedded_workbook_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) de [ChartData](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/) avec l’énumération [WorkbookType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/workbooktype/) pour détecter les formats non pris en charge et ignorer ces graphiques. Cet exemple parcourt les formes de la première diapositive de `sample.pptx`, ignore les formes qui ne sont pas des graphiques, et affiche un message de diagnostic pour chaque graphique contenant un classeur .xlsb intégré.

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

        # Lire ou modifier les données du classeur de graphique prises en charge ici.
```

## **Classeur externe**

Aspose.Slides prend en charge l’utilisation de classeurs externes comme source de données pour les graphiques.

### **Créer un classeur externe**

Utilisez [read_workbook_stream](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) et [set_external_workbook](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/set_external_workbook/) pour exporter un classeur de graphique intégré vers un fichier et lier le graphique à ce classeur externe.

Cet exemple crée un graphique circulaire avec des données par défaut, écrit son classeur dans `externalWorkbook1.xlsx`, puis ferme le flux de sortie avant d’attribuer le fichier comme source de données du graphique. Il enregistre la présentation liée dans `externalWorkbook.pptx`.

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

En utilisant la méthode [set_external_workbook](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/set_external_workbook/), vous pouvez assigner un classeur externe à un graphique comme source de données. Cette méthode peut également être utilisée pour mettre à jour le chemin du classeur externe (si celui‑ci a été déplacé).

Bien que vous ne puissiez pas modifier les données dans les classeurs stockés à distance ou dans des ressources, vous pouvez toujours les utiliser comme source de données externe. Si un chemin relatif est fourni, il est automatiquement converti en chemin absolu.

Cet exemple nécessite `externalWorkbook.xlsx` dans le répertoire de travail. Sa feuille nommée `Sheet1` doit contenir un nom de série en B1, des noms de catégorie en A2 : A4, et des valeurs numériques en B2 : B4. L’exemple crée un graphique circulaire, lie le classeur, et utilise [set_range](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/set_range/) pour mapper A1 : B4 à une série et trois catégories. Il enregistre le résultat dans `Presentation_with_externalWorkbook.pptx`.

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

Le paramètre `update_chart_data` de [set_external_workbook](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/set_external_workbook/) contrôle si le classeur est chargé.

* Lorsque `update_chart_data` est `False`, seul le chemin du classeur est mis à jour. Les données du graphique ne sont pas chargées ni mises à jour à partir du classeur cible, de sorte que le classeur peut être indisponible.
* Lorsque `update_chart_data` est `True`, les données du graphique sont mises à jour à partir du classeur cible.

L’exemple suivant affecte une URL factice avec `update_chart_data` mis sur `False`. Il conserve les données par défaut du graphique circulaire et enregistre la présentation sans charger le classeur indisponible.

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

Pour identifier le classeur lié à un graphique, vérifiez d’abord si le graphique utilise une source de données externe. Si c’est le cas, vous pouvez récupérer le chemin du classeur en suivant ces étapes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Accédez à la première diapositive par son indice zéro.
1. Vérifiez que la première forme est un graphique.
1. Lisez le type de source de données du graphique.
1. Si la source est un classeur externe, lisez son chemin.

Cet exemple ouvre `externalWorkbook.pptx`, créé dans l’exemple précédent, et inspecte la première forme de la première diapositive. Si c’est un graphique lié à un classeur externe, l’exemple affiche [external_workbook_path](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/external_workbook_path/) dans la console. Il enregistre ensuite une copie de la présentation dans `Result.pptx`.

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

Vous pouvez modifier les données des classeurs externes de la même façon que vous modifiez le contenu des classeurs internes. Lorsqu’un classeur externe ne peut pas être chargé, une exception est levée.

Cet exemple nécessite `presentation.pptx` contenant un graphique comme première forme de la première diapositive et un classeur externe accessible. Il définit la valeur basée sur la cellule du premier point de données de la première série à 100 et enregistre la présentation dans `presentation_out.pptx`. Modifier les valeurs des cellules peut mettre à jour le fichier XLSX externe lié, donc utilisez une copie si vous devez conserver le classeur original.

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

### **Récupérer un classeur depuis le cache du graphique**

Si un graphique utilise un classeur externe manquant ou indisponible, Aspose.Slides peut reconstruire le classeur du graphique à partir des données en cache dans la présentation. Créez un [LoadOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/), configurez son [spreadsheet_options](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/spreadsheet_options/), et définissez [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/fr/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) sur `True` avant d’ouvrir la présentation.

L’exemple Python suivant ouvre `presentation.pptx`, dont la première forme de la première diapositive doit être un graphique faisant référence à un classeur externe indisponible, et accède aux données récupérées via [Chart.chart_data](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chart/chart_data/) et [ChartData.chart_data_workbook](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

Si le classeur externe est indisponible et que la récupération est désactivée, Aspose.Slides lève une exception. Activez la récupération uniquement lorsque l’utilisation des données du graphique en cache constitue un plan de secours acceptable, car le cache peut ne pas contenir les modifications apportées au classeur externe après la dernière mise à jour de la présentation.

## **FAQ**

**Puis‑je déterminer si un graphique précis est lié à un classeur externe ou intégré ?**

Oui. Un graphique possède un [type de source de données](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/data_source_type/) et un [chemin vers un classeur externe](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ; si la source est un classeur externe, vous pouvez lire le chemin complet pour vous assurer qu’un fichier externe est utilisé.

**Les chemins relatifs vers les classeurs externes sont‑ils pris en charge, et comment sont‑ils stockés ?**

Oui. Si vous spécifiez un chemin relatif, il est automatiquement converti en chemin absolu. La présentation stocke le chemin absolu dans le fichier PPTX, de sorte que le déplacement du classeur puisse nécessiter la mise à jour du lien.

**Puis‑je utiliser des classeurs situés sur des ressources ou partages réseau ?**

Oui, ces classeurs peuvent être utilisés comme source de données externe. Cependant, la modification directe de classeurs distants depuis Aspose.Slides n’est pas prise en charge ; ils ne peuvent être utilisés que comme source.

**Aspose.Slides écrase‑t‑il le fichier XLSX externe lors de l’enregistrement de la présentation ?**

La présentation stocke un [lien vers le fichier externe](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Modifier les données du graphique provenant de cellules peut également mettre à jour le fichier XLSX local lié. Utilisez une copie du classeur si l’original doit rester inchangé.

**Que faire si le fichier externe est protégé par mot de passe ?**

Aspose.Slides n’accepte pas de mot de passe lors de la liaison. Une approche courante consiste à supprimer la protection au préalable ou à préparer une copie décryptée (par exemple avec [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) et à la lier.

**Plusieurs graphiques peuvent‑ils référencer le même classeur externe ?**

Oui. Chaque graphique stocke son propre lien. S’ils pointent tous vers le même fichier, la mise à jour de ce fichier sera reflétée dans chaque graphique lors du prochain chargement des données.