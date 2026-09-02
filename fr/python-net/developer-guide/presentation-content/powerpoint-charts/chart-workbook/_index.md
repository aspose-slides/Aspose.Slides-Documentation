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
- cache du graphique
- récupération du classeur
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Découvrez Aspose.Slides pour Python via .NET : gérez facilement les classeurs de graphiques dans les formats PowerPoint et OpenDocument pour simplifier les données de votre présentation."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les classeurs de graphiques dans Aspose.Slides. Il montre comment lire et écrire des données de graphique via des flux de classeur, utiliser les cellules du classeur comme libellés de données de graphique, accéder aux collections de feuilles de calcul et spécifier le type de source de données pour les valeurs du graphique.

Il couvre également le travail avec des classeurs externes comme sources de données de graphiques. Les exemples montrent comment créer et affecter un classeur externe, récupérer le chemin d’un classeur externe lié à un graphique et modifier les données du graphique lorsque le classeur est disponible.

## **Lire et écrire des données de graphique à partir d’un classeur**

Aspose.Slides fournit des méthodes pour lire et écrire des classeurs de données de graphique (qui contiennent des données de graphique modifiées avec Aspose.Cells). **Note :** Les données du graphique doivent être organisées de la même façon ou avoir une structure similaire à la source.

Le code Python suivant montre une opération d’exemple :

```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```

### **Valider la disposition du graphique après modification du classeur**

Lorsque vous remplacez un classeur intégré par un classeur modifié, le graphique conserve ses collections de séries et de catégories d’origine. Cette inadéquation peut entraîner l’échec de [IChart.validate_chart_layout](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/ichart/validate_chart_layout/) avec une erreur d’index hors limites. Effacez les séries et catégories existantes avant d’écrire le classeur mis à jour dans le graphique.

```python
# Après avoir modifié le flux du classeur (p. ex., en utilisant Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Effacer les références de données existantes.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Effacer les collections garantit que la structure des données du graphique est cohérente avec le nouveau classeur, permettant à `validate_chart_layout` de s’exécuter sans erreur.

## **Définir une cellule de classeur comme libellé de données de graphique**

Parfois, vous avez besoin que les libellés du graphique proviennent directement des cellules du classeur de données sous‑jacent. Aspose.Slides vous permet de lier des libellés de données à des cellules de classeur spécifiques afin que le texte du libellé reflète toujours la valeur de la cellule. L’exemple ci‑dessous montre comment activer les libellés « valeur‑provenant‑cellule » et orienter les libellés sélectionnés vers des cellules personnalisées dans le classeur du graphique.

1. Créez une instance de la classe [Presentation](https://docs.aspose.com/slides/fr/python-net/api-reference/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son index.
3. Ajoutez un graphique à bulles avec des données d’exemple.
4. Accédez aux séries du graphique.
5. Utilisez une cellule de classeur comme libellé de données.
6. Enregistrez la présentation.

Le code Python suivant montre comment définir une cellule de classeur comme libellé de données de graphique :

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Gérer les feuilles de calcul**

Le code Python suivant montre comment utiliser la propriété `worksheets` pour accéder à la collection de feuilles de calcul :

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```

## **Spécifier le type de source de données**

Le code Python suivant montre comment spécifier un type de source de données :

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Détecter les formats de classeur intégré non pris en charge**

Aspose.Slides ne prend pas en charge le format de classeur binaire Excel (.xlsb) pouvant être intégré à certains graphiques. Vous pouvez utiliser la propriété `embedded_workbook_type` sur [ChartData](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/) avec l’énumération [WorkbookType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/workbooktype/) pour détecter les formats non pris en charge et ignorer ces graphiques.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
            # Le classeur intégré est au format .xlsb, qui n'est pas pris en charge.
            continue

        # Lire ou modifier les données du classeur du graphique ici.
```

## **Classeurs externes**

Aspose.Slides prend en charge l’utilisation de classeurs externes comme source de données pour les graphiques.

### **Définir des classeurs externes**

En utilisant la méthode [ChartData.set_external_workbook](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/set_external_workbook/), vous pouvez affecter un classeur externe à un graphique comme source de données. Cette méthode peut également mettre à jour le chemin d’un classeur externe s’il a été déplacé.

Bien que vous ne puissiez pas modifier les données des classeurs stockés sur des emplacements ou des ressources distants, vous pouvez toujours les utiliser comme sources de données externes. Si vous fournissez un chemin relatif pour un classeur externe, il est automatiquement converti en chemin complet.

Le code Python suivant montre comment définir un classeur externe :

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Passer False afin que seul le chemin soit stocké : le classeur cible n'a pas encore besoin d'exister.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Le paramètre `update_chart_data` de la méthode [set_external_workbook](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/set_external_workbook/) indique si le classeur Excel sera chargé.

- Lorsque `update_chart_data` est défini sur `False`, seul le chemin du classeur est mis à jour ; les données du graphique ne sont pas chargées ni rafraîchies à partir du classeur cible. Utilisez ce réglage lorsque le classeur cible n’existe pas ou est indisponible.
- Lorsque `update_chart_data` est défini sur `True` (valeur par défaut), les données du graphique sont chargées et mises à jour à partir du classeur cible. Si ce classeur ne peut pas être ouvert, une exception avec le message « External workbook is not available » est levée.

### **Créer des classeurs externes**

En utilisant les méthodes [read_workbook_stream](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) et [set_external_workbook](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/set_external_workbook/), vous pouvez soit créer un classeur externe à partir de zéro, soit convertir un classeur interne en classeur externe.

Ce code Python illustre le processus de création d’un classeur externe :

```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Obtenir le chemin du classeur source de données externe d’un graphique**

Parfois, les données d’un graphique sont liées à un classeur Excel externe plutôt qu’aux données intégrées de la présentation. Avec Aspose.Slides, vous pouvez inspecter la source de données du graphique et, si c’est un classeur externe, lire le chemin complet du classeur.

1. Créez une instance de la classe [Presentation](https://docs.aspose.com/slides/fr/python-net/api-reference/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son index.
3. Obtenez une référence à la forme du graphique.
4. Récupérez la source ([ChartDataSourceType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdatasourcetype/)) qui représente la source de données du graphique.
5. Vérifiez si le type de source correspond au type de source de classeur externe.

Le code Python suivant montre l’opération :

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Modifier les données du graphique**

Vous pouvez modifier les données dans les classeurs externes de la même manière que vous modifiez les données dans les classeurs internes. Si un classeur externe ne peut pas être chargé, une exception est levée.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Récupérer un classeur à partir du cache du graphique**

Si un graphique utilise un classeur externe manquant ou indisponible, Aspose.Slides peut reconstruire le classeur du graphique à partir des données mises en cache dans la présentation. Créez [LoadOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/), puis activez [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/fr/python-net/aspose.slides.spreadsheetoptions/recover_workbook_from_chart_cache/) via [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/spreadsheet_options/) avant d’ouvrir la présentation.

L’exemple Python suivant ouvre une présentation dont le graphique fait référence à un classeur externe indisponible et accède aux données récupérées via [Chart.chart_data](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chart/chart_data/) et [ChartData.chart_data_workbook](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) :

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Lire ou modifier les données du classeur récupéré ici.
```

Si le classeur externe est indisponible et que la récupération est désactivée, Aspose.Slides lève une exception. Activez la récupération uniquement lorsque l’utilisation des données de graphique mises en cache constitue une solution de repli acceptable, car le cache peut ne pas contenir les modifications apportées au classeur externe après la dernière mise à jour de la présentation.

## **FAQ**

**Puis‑je déterminer si un graphique spécifique est lié à un classeur externe ou intégré ?**

Oui. Un graphique possède un [data source type](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/data_source_type/) et un [path to an external workbook](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ; si la source est un classeur externe, vous pouvez lire le chemin complet pour vous assurer qu’un fichier externe est utilisé.

**Les chemins relatifs vers des classeurs externes sont‑ils pris en charge et comment sont‑ils stockés ?**

Oui. Si vous indiquez un chemin relatif, il est automatiquement converti en chemin absolu. Cela facilite la portabilité du projet ; toutefois, la présentation stockera le chemin absolu dans le fichier PPTX.

**Puis‑je utiliser des classeurs situés sur des ressources ou partages réseau ?**

Oui, ces classeurs peuvent être utilisés comme source de données externe. Toutefois, la modification directe de classeurs distants depuis Aspose.Slides n’est pas prise en charge — ils ne peuvent être qu’une source.

**Aspose.Slides remplace‑t‑il le fichier XLSX externe lors de l’enregistrement de la présentation ?**

Uniquement si vous avez modifié les données du graphique. La présentation stocke un [link to the external file](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/external_workbook_path/) et l’utilise pour lire les données, de sorte qu’ouvrir et enregistrer une présentation laisse le classeur intact. Cependant, les valeurs que vous modifiez via les données du graphique (voir [Edit Chart Data](#edit-chart-data) ci‑dessus) sont écrites dans le classeur externe lors de l’enregistrement de la présentation — travaillez sur une copie si l’original doit rester inchangé.

**Que faire si le fichier externe est protégé par mot de passe ?**

Aspose.Slides n’accepte pas de mot de passe lors de la liaison. Une approche courante consiste à supprimer la protection au préalable ou à préparer une copie décryptée (par exemple en utilisant [Aspose.Cells](/cells/python-net/)) et à la lier.

**Plusieurs graphiques peuvent‑ils référencer le même classeur externe ?**

Oui. Chaque graphique stocke son propre lien. S’ils pointent tous vers le même fichier, la mise à jour de ce fichier sera reflétée dans chaque graphique lors du prochain chargement des données.