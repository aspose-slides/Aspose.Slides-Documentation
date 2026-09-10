---
title: Gérer les classeurs de graphiques dans les présentations avec Python via Java
linktitle: Classeur de graphique
type: docs
weight: 70
url: /fr/python-java/chart-workbook/
keywords:
- classeur de graphique
- données du graphique
- cellule du classeur
- étiquette de données
- feuille de calcul
- source de données
- classeur externe
- données externes
- cache du graphique
- récupération du classeur
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Découvrez Aspose.Slides pour Python via Java : gérez facilement les classeurs de graphiques dans les formats PowerPoint et OpenDocument pour rationaliser les données de votre présentation."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les classeurs de graphiques dans Aspose.Slides. Il montre comment lire et écrire les données de graphique via des flux de classeur, utiliser les cellules du classeur comme étiquettes de données de graphique, accéder aux collections de feuilles de calcul et spécifier le type de source de données pour les valeurs de graphique.

Il couvre également l'utilisation de classeurs externes comme sources de données de graphique. Les exemples démontrent comment créer et affecter un classeur externe, récupérer le chemin d'un classeur externe lié à un graphique, et modifier les données du graphique lorsque le classeur est disponible.

## **Lire et écrire des données de graphique à partir d'un classeur**
Aspose.Slides fournit les méthodes [readWorkbookStream](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdata/#readWorkbookStream) et [writeWorkbookStream](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdata/#writeWorkbookStream) qui vous permettent de lire et d’écrire les classeurs de données de graphique (contenant des données de graphique éditées avec Aspose.Cells). **Remarque** que les données du graphique doivent être organisées de la même façon ou doivent avoir une structure similaire à la source.

Ce code Python illustre une opération d'exemple :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **Valider la disposition du graphique après modification du classeur**

Lorsque vous remplacez un classeur incorporé par un classeur modifié, le graphique conserve ses collections de séries et de catégories d'origine. Cette incohérence peut entraîner [Chart.validateChartLayout](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#validateChartLayout) à lever une `ArgumentOutOfRangeException` (paramètre : index). Pour éviter l'exception, effacez les séries et catégories existantes **avant** d’écrire le classeur mis à jour dans le graphique.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# Lire le classeur après l'avoir modifié (par ex., en utilisant Aspose.Cells).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # Effacer les références de données existantes.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

Vider les collections garantit que la structure des données du graphique correspond au nouveau classeur, permettant à [validateChartLayout](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#validateChartLayout) de s’exécuter sans erreurs.

## **Définir une cellule de classeur comme étiquette de données de graphique**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) .
2. Obtenez la référence d’une diapositive via son indice.
3. Ajoutez un graphique Bulles avec certaines données.
4. Accédez aux séries du graphique.
5. Définissez la cellule du classeur comme étiquette de données.
6. Enregistrez la présentation.

Ce code Python montre comment définir une cellule de classeur comme étiquette de données de graphique :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
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

Ce code Python montre une opération où la méthode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdataworkbook/#getWorksheets) est utilisée pour accéder à une collection de feuilles de calcul :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Spécifier le type de source de données**

Ce code Python montre comment spécifier un type pour une source de données :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Détecter les formats de classeur incorporé non pris en charge**

Aspose.Slides ne prend pas en charge le format de classeur Excel binaire (.xlsb) qui peut être incorporé dans certains graphiques. Vous pouvez utiliser la méthode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) sur [ChartData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdata/) conjointement avec l’énumération [WorkbookType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/workbooktype/) pour détecter les formats non pris en charge et ignorer ces graphiques.

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
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # Le classeur incorporé est au format .xlsb, qui n'est pas pris en charge.
            continue
        # Lire ou modifier les données du classeur du graphique ici.
finally:
    presentation.dispose()
```

### **Créer un classeur externe**

En utilisant les méthodes [readWorkbookStream](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdata/#readWorkbookStream) et [setExternalWorkbook](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdata/#setExternalWorkbook), vous pouvez créer un classeur externe à partir de zéro ou rendre un classeur interne externe.

Ce code Python montre le processus de création d’un classeur externe :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Affecter un classeur externe**

En utilisant la méthode [setExternalWorkbook](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdata/#setExternalWorkbook), vous pouvez affecter un classeur externe à un graphique comme source de données. Cette méthode peut également être utilisée pour mettre à jour le chemin du classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas modifier les données dans les classeurs stockés sur des emplacements ou ressources distants, vous pouvez toujours les utiliser comme source de données externe. Si un chemin relatif pour un classeur externe est fourni, il est automatiquement converti en chemin complet.

Ce code Python montre comment affecter un classeur externe :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le deuxième paramètre (`bool`) de la méthode [setExternalWorkbook](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdata/#setExternalWorkbook) sert à spécifier si un classeur Excel sera chargé ou non. 
* Lorsque sa valeur est `False`, seul le chemin du classeur est mis à jour — les données du graphique ne seront pas chargées ou mises à jour à partir du classeur cible. Vous pouvez utiliser ce paramètre lorsqu’il n’existe pas ou que le classeur cible est indisponible. 
* Lorsque sa valeur est `True`, les données du graphique sont mises à jour à partir du classeur cible.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Obtenir le chemin du classeur source de données externe d’un graphique**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) .
2. Obtenez la référence d’une diapositive via son indice.
3. Créez un objet pour la forme du graphique.
4. Créez un objet pour le type source ([ChartDataSourceType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatasourcetype/)) qui représente la source de données du graphique.
5. Spécifiez la condition pertinente en fonction du fait que le type de source soit identique au type de source de données du classeur externe.

Ce code Python montre l’opération :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Modifier les données du graphique**

Vous pouvez modifier les données des classeurs externes de la même manière que vous modifiez le contenu des classeurs internes. Lorsqu’un classeur externe ne peut pas être chargé, une exception est levée.

Ce code Python est une implémentation du processus décrit :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Récupérer un classeur à partir du cache du graphique**

Si un graphique utilise un classeur externe manquant ou indisponible, Aspose.Slides peut reconstruire le classeur du graphique à partir des données mises en cache dans la présentation. Créez [LoadOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/), configurez-le avec [SpreadsheetOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/spreadsheetoptions/), et appelez [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fr/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) avec `True` avant d’ouvrir la présentation.

L’exemple Python suivant ouvre une présentation dont le graphique référence un classeur externe indisponible et accède aux données récupérées via [Chart.getChartData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#getChartData) et [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdata/#getChartDataWorkbook):
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # Lire ou modifier les données du classeur récupéré ici.
finally:
    presentation.dispose()
```

Si le classeur externe est indisponible et que la récupération est désactivée, Aspose.Slides lève une exception. Activez la récupération uniquement lorsque l’utilisation des données de graphique mises en cache constitue une solution de repli acceptable, car le cache peut ne pas contenir les modifications apportées au classeur externe après la dernière mise à jour de la présentation.

## **FAQ**

**Puis-je déterminer si un graphique spécifique est lié à un classeur externe ou incorporé ?**

Oui. Un graphique possède un [data source type](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdata/#getDataSourceType) et un [path to an external workbook](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); si la source est un classeur externe, vous pouvez lire le chemin complet afin de vous assurer qu’un fichier externe est utilisé.

**Les chemins relatifs vers les classeurs externes sont-ils pris en charge, et comment sont-ils stockés ?**

Oui. Si vous spécifiez un chemin relatif, il est automatiquement converti en chemin absolu. Cela est pratique pour la portabilité du projet ; toutefois, sachez que la présentation stockera le chemin absolu dans le fichier PPTX.

**Puis-je utiliser des classeurs situés sur des ressources ou partages réseau ?**

Oui, ces classeurs peuvent être utilisés comme source de données externe. Cependant, la modification directe de classeurs distants depuis Aspose.Slides n’est pas prise en charge ; ils ne peuvent être utilisés qu’en tant que source.

**Aspose.Slides écrase-t-il le XLSX externe lors de l’enregistrement de la présentation ?**

Non. La présentation stocke un [link to the external file](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) et l’utilise pour lire les données. Le fichier externe lui‑même n’est pas modifié lors de l’enregistrement de la présentation.

**Que faire si le fichier externe est protégé par un mot de passe ?**

Aspose.Slides n’accepte pas de mot de passe lors de la liaison. Une approche courante consiste à enlever la protection au préalable ou à préparer une copie décryptée (par exemple en utilisant [Aspose.Cells](/cells/python-java/)) et à établir le lien vers cette copie.

**Plusieurs graphiques peuvent-ils référencer le même classeur externe ?**

Oui. Chaque graphique stocke son propre lien. S’ils pointent tous vers le même fichier, la mise à jour de ce fichier sera reflétée dans chaque graphique lors du prochain chargement des données.