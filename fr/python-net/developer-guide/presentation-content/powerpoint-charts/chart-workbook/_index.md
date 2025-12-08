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
- étiquette de données
- feuille de calcul
- source de données
- classeur externe
- données externes
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Découvrez Aspose.Slides pour Python via .NET : gérez facilement les classeurs de graphiques dans les formats PowerPoint et OpenDocument pour rationaliser les données de votre présentation."
---

## **Définir les données du graphique à partir d'un classeur**

Aspose.Slides fournit des méthodes pour lire et écrire des classeurs de données de graphiques (qui contiennent des données de graphiques modifiées avec Aspose.Cells). **Remarque :** Les données du graphique doivent être organisées de la même manière ou posséder une structure similaire à celle de la source.

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


## **Définir une cellule de classeur comme étiquette de données de graphique**

Parfois, vous avez besoin d’étiquettes de graphique provenant directement des cellules du classeur de données sous-jacent. Aspose.Slides vous permet de lier les étiquettes de données à des cellules spécifiques du classeur afin que le texte de l’étiquette reflète toujours la valeur de la cellule. L’exemple ci‑dessous montre comment activer les étiquettes provenant de cellules et associer des étiquettes sélectionnées à des cellules personnalisées dans le classeur du graphique.

1. Créez une instance de la classe [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/).
1. Obtenez une référence à la diapositive par indice.
1. Ajoutez un graphique à bulles avec des données d’exemple.
1. Accédez aux séries du graphique.
1. Utilisez une cellule de classeur comme étiquette de données.
1. Enregistrez la présentation.

Le code Python suivant montre comment définir une cellule de classeur comme étiquette de données de graphique :
```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Instanciez la classe Presentation qui représente un fichier de présentation.
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


## **Classeurs externes**

Aspose.Slides prend en charge l’utilisation de classeurs externes comme source de données pour les graphiques.

### **Définir des classeurs externes**

En utilisant la méthode [ChartData.set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/), vous pouvez assigner un classeur externe à un graphique comme source de données. Cette méthode peut également mettre à jour le chemin d’accès d’un classeur externe s’il a été déplacé.

Bien que vous ne puissiez pas modifier les données des classeurs stockés sur des emplacements ou des ressources distants, vous pouvez toujours les utiliser comme sources de données externes. Si vous fournissez un chemin relatif pour un classeur externe, il est automatiquement converti en chemin complet.

Le code Python suivant montre comment définir un classeur externe :
```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```


Le paramètre `update_chart_data` de la méthode [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) indique si le classeur Excel sera chargé.

- Lorsque `update_chart_data` est défini sur `False`, seul le chemin du classeur est mis à jour ; les données du graphique ne sont pas chargées ou actualisées depuis le classeur cible. Utilisez ce paramètre lorsque le classeur cible n’existe pas ou est indisponible.
- Lorsque `update_chart_data` est défini sur `True`, les données du graphique sont chargées et mises à jour depuis le classeur cible.

### **Créer des classeurs externes**

En utilisant les méthodes [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) et [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/), vous pouvez soit créer un classeur externe à partir de zéro, soit convertir un classeur interne en externe.

Ce code Python démontre le processus de création d’un classeur externe :
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


### **Obtenir le chemin du classeur source de données externe pour un graphique**

Parfois, les données d’un graphique sont liées à un classeur Excel externe plutôt qu’aux données incorporées de la présentation. Avec Aspose.Slides, vous pouvez inspecter la source de données du graphique et, si c’est un classeur externe, lire le chemin complet du classeur.

1. Créez une instance de la classe [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/).
1. Obtenez une référence à la diapositive par son indice.
1. Obtenez une référence à la forme de graphique.
1. Récupérez la source ([ChartDataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/)) qui représente la source de données du graphique.
1. Vérifiez si le type de source correspond au type de source de classeur externe.

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

Vous pouvez modifier les données dans les classeurs externes de la même manière que dans les classeurs internes. Si un classeur externe ne peut pas être chargé, une exception est levée.
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Puis‑je déterminer si un graphique spécifique est lié à un classeur externe ou incorporé ?**

Oui. Un graphique possède un [type de source de données](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) et un [chemin vers un classeur externe](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ; si la source est un classeur externe, vous pouvez lire le chemin complet pour vous assurer qu’un fichier externe est utilisé.

**Les chemins relatifs vers les classeurs externes sont‑ils pris en charge et comment sont‑ils stockés ?**

Oui. Si vous spécifiez un chemin relatif, il est automatiquement converti en chemin absolu. Cela facilite la portabilité du projet ; toutefois, la présentation stockera le chemin absolu dans le fichier PPTX.

**Puis‑je utiliser des classeurs situés sur des ressources ou partages réseau ?**

Oui, ces classeurs peuvent être utilisés comme source de données externe. Cependant, la modification directe de classeurs distants depuis Aspose.Slides n’est pas prise en charge — ils ne peuvent être utilisés que comme source.

**Aspose.Slides écrase‑t‑il le fichier XLSX externe lors de l’enregistrement de la présentation ?**

Non. La présentation stocke un [lien vers le fichier externe](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) et l’utilise pour la lecture des données. Le fichier externe lui‑même n’est pas modifié lors de l’enregistrement de la présentation.

**Que faire si le fichier externe est protégé par un mot de passe ?**

Aspose.Slides n’accepte pas de mot de passe lors de la liaison. Une approche courante consiste à enlever la protection au préalable ou à préparer une copie décryptée (par exemple, en utilisant [Aspose.Cells](/cells/python-net/)) et à lier cette copie.

**Plusieurs graphiques peuvent‑ils référencer le même classeur externe ?**

Oui. Chaque graphique stocke son propre lien. S’ils pointent tous vers le même fichier, la mise à jour de ce fichier sera reflétée dans chaque graphique lors du prochain chargement des données.