---
title: Gérer les classeurs de graphiques dans les présentations en .NET
linktitle: Classeur de graphique
type: docs
weight: 70
url: /fr/net/chart-workbook/
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
- .NET
- C#
- Aspose.Slides
description: "Découvrez Aspose.Slides pour .NET : gérez facilement les classeurs de graphiques dans les formats PowerPoint et OpenDocument pour rationaliser les données de votre présentation."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les classeurs de graphiques dans Aspose.Slides. Il montre comment lire et écrire des données de graphique via des flux de classeur, utiliser les cellules du classeur comme libellés de données de graphique, accéder aux collections de feuilles de calcul et spécifier le type de source de données pour les valeurs du graphique.

Il couvre également le travail avec des classeurs externes comme source de données de graphique. Les exemples démontrent comment créer et affecter un classeur externe, récupérer le chemin d’un classeur externe lié à un graphique et modifier les données du graphique lorsque le classeur est disponible.

Pour les cellules du classeur qui représentent des données manquantes, consultez [Contrôler l'affichage des cellules vides](/slides/fr/net/chart-series/) pour la différence entre une cellule vide et zéro, ainsi qu’une comparaison en graphique en courbes des modes d’affichage disponibles.

## **Inclure les données des lignes et colonnes masquées**

Utilisez [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) pour contrôler si un graphique trace les données des lignes et colonnes de feuille masquées. Définissez-le sur `true` pour tracer uniquement les cellules visibles, ou sur `false` pour inclure à la fois les cellules visibles et masquées. Ce paramètre contrôle le traçage du graphique ; il ne masque pas et ne rend pas visibles les lignes ou colonnes de la feuille.

La [présentation d’exemple](hidden-source-data.pptx) contient un graphique à colonnes comme première forme de sa première diapositive. La feuille de calcul intégrée, `Sheet1`, contient la plage source suivante, `A1:C4`. La ligne 3 et la colonne C sont masquées, mais leurs cellules contiennent toujours des valeurs.

| Ligne de feuille | A : Mois | B : Vente au détail | C : Vente en gros (colonne masquée) |
| --- | --- | --- | --- |
| 2 | janvier | 10 | 30 |
| 3 (ligne masquée) | février | 40 | 60 |
| 4 | mars | 20 | 50 |

Accédez aux cellules sources via [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) et lisez [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) pour inspecter leur état masqué. Cette propriété est en lecture seule. Dans ce fichier, B2 est visible, B3 appartient à la ligne masquée et C2 appartient à la colonne masquée ; l’exemple affiche `False`, `True` et `True` respectivement.

Pour cet exemple, actualisez les données du graphique après avoir modifié le paramètre de traçage : conservez le classeur intégré avec [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) et rechargez‑le avec [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/). Lors de l’inclusion de toutes les cellules, utilisez également [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) pour restaurer la plage complète, y compris la catégorie février masquée. Modifier simplement le drapeau ne suffit pas à actualiser les données mises en cache du graphique et les libellés de catégorie de cet exemple.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("hidden-source-data.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes[0] is IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    Console.WriteLine($"B2 hidden: {workbook.GetCell(0, "B2").IsHidden}");
    Console.WriteLine($"B3 hidden: {workbook.GetCell(0, "B3").IsHidden}");
    Console.WriteLine($"C2 hidden: {workbook.GetCell(0, "C2").IsHidden}");

    using var workbookStream = chart.ChartData.ReadWorkbookStream();
    foreach (var visibleOnly in new[] { true, false })
    {
        chart.PlotVisibleCellsOnly = visibleOnly;

        // Actualiser les données du graphique à partir du classeur intégré.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Restaurer la plage source complète, y compris les catégories masquées.
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");
        }

        presentation.Save($"hidden_cells_{visibleOnly}.pptx", SaveFormat.Pptx);
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

L’exemple enregistre deux versions de la présentation : une avec uniquement les valeurs de vente au détail visibles (10 et 20), et une autre avec les six valeurs. Les images ci‑dessous ont été rendues à partir des présentations enregistrées après les avoir rouvertes ; les deux fichiers conservent le paramètre de traçage attribué. La ligne 3 et la colonne C restent masquées dans les deux classeurs intégrés.

| Cellules uniquement visibles (`true`) | Toutes les cellules (`false`) |
| --- | --- |
| ![Cellules uniquement visibles : valeurs de vente au détail 10 et 20 pour janvier et mars.](hidden_cells_True.png) | ![Toutes les cellules : valeurs de vente au détail et de vente en gros pour janvier, février et mars.](hidden_cells_False.png) |

Une cellule masquée contenant une valeur est différente d’une cellule vide. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) contrôle comment les valeurs manquantes sont affichées ; il n’inclut pas et n’exclut pas les données sources masquées. Consultez [Contrôler l'affichage des cellules vides](/slides/fr/net/chart-series/#control-the-display-of-empty-cells) pour un exemple.

## **Récupérer la plage de données d'un graphique**

Avant de mettre à jour les données du classeur dans une présentation existante, inspectez les plages sources afin d’identifier les cellules de feuille utilisées par chaque graphique. La méthode [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) renvoie la plage de données actuelle sous forme de formule qualifiée par la feuille, telle que `Sheet1!$A$1:$D$5`. Ici, `Sheet1` est le nom de la feuille, `!` le sépare de la plage de cellules, et `$A$1:$D$5` identifie les cellules de A1 à D5 incluses. Les signes dollar indiquent des références absolues de ligne et de colonne.

La méthode lit la plage actuelle sans modifier le graphique ni son classeur. Si le graphique n’utilise pas de classeur comme source de données, elle génère une [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Pour plus d’informations, consultez la [Référence de l’API ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/).

Cet exemple ouvre une présentation et examine les formes directement sur chaque diapositive pour détecter les graphiques. Il affiche le nom de chaque graphique et sa plage source. Si un graphique n’utilise pas de classeur, il affiche un message et passe au graphique suivant.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            try
            {
                var range = chart.ChartData.GetRange();
                Console.WriteLine($"{chart.Name}: {range}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{chart.Name}: The chart does not use a workbook as its data source.");
            }
        }
    }
}
```

## **Lire et écrire des données de graphique depuis un classeur**

Aspose.Slides for .NET fournit les méthodes [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) et [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) qui permettent de lire et d’écrire les classeurs de données de graphique (contenant des données de graphique éditées avec Aspose.Cells). **Remarque** le classeur de données doit être organisé de la même manière ou posséder une structure similaire à la source.

Cet exemple utilise une présentation avec un graphique comme première forme de sa première diapositive. Il lit le classeur intégré dans un flux, vide les séries et catégories existantes, puis réécrit le même classeur. Les modifications restent en mémoire ; l’exemple n’enregistre pas la présentation.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Valider la mise en page du graphique après modification du classeur**

Lorsque vous remplacez un classeur intégré par un classeur modifié, le graphique conserve ses collections de séries et de catégories d’origine. Cette incohérence peut entraîner l’échec de [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) avec une erreur d’indice hors limites. Videz les séries et catégories existantes avant d’écrire le classeur mis à jour dans le graphique. Cet exemple utilise un graphique qui est la première forme de la première diapositive. Le commentaire indique où l’édition du classeur aurait lieu ; l’exemple exécutable réécrit le classeur original et valide la mise en page en mémoire.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    // Modifier le flux du classeur ici, par exemple en utilisant Aspose.Cells.

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
    chart.ValidateChartLayout();
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Vider les collections supprime les références d’anciennes données avant que le classeur ne soit réécrit. Reconstituez les mappages de séries et de catégories nécessaires pour le classeur mis à jour avant d’utiliser le graphique.

## **Définir des formats numériques personnalisés pour les cellules du classeur**

Utilisez [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) pour contrôler l’apparence des valeurs numériques dans le classeur intégré d’un graphique. Par exemple, un rapport peut nécessiter un taux de conversion affiché en pourcentage avec quatre décimales et un coefficient affiché avec cinq décimales. Conservez les deux valeurs sous forme numérique afin qu’elles restent disponibles pour les calculs et le traçage du graphique.

Un format numérique modifie l’affichage, pas la valeur stockée. Le format `0.0000%` affiche `0.125` comme `12.5000%` ; il ne remplace pas le nombre stocké par `12.5`. De même, `0.00000` affiche `0.1234567` comme `0.12346` sans arrondir la valeur stockée. Si le format personnalisé est une chaîne vide (`""`), [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) est utilisé à la place.

L’exemple suivant crée un graphique à colonnes et accède à ses cellules via [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/). Sur la feuille 0, B2 contient le taux de conversion et C2 le coefficient. Les deux cellules alimentent les valeurs du graphique. L’exemple active également les libellés de valeurs liés aux formats source.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 270, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
chart.HasTitle = false;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00";
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A2", "Sample");
chart.ChartData.Categories.Add(categoryCell);

var percentageCell = workbook.GetCell(0, "B2", 0.125);
percentageCell.CustomNumberFormat = "0.0000%";
var percentageName = workbook.GetCell(0, "B1", "Conversion rate");
var percentageSeries = chart.ChartData.Series.Add(percentageName, chart.Type);
percentageSeries.DataPoints.AddDataPointForBarSeries(percentageCell);

var precisionCell = workbook.GetCell(0, "C2", 0.1234567);
precisionCell.CustomNumberFormat = "0.00000";
var precisionName = workbook.GetCell(0, "C1", "Coefficient");
var precisionSeries = chart.ChartData.Series.Add(precisionName, chart.Type);
precisionSeries.DataPoints.AddDataPointForBarSeries(precisionCell);

foreach (var series in chart.ChartData.Series)
{
    var labelFormat = series.DataPoints[0].Label.DataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = true;
}

presentation.Save("CustomCellFormats.pptx", SaveFormat.Pptx);
```

Les formats des cellules du classeur sont distincts des formats appliqués directement aux axes du graphique ou aux libellés de données. Dans cet exemple, chaque libellé affiche la valeur de sa cellule source car [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) est activé, et suit le format numérique source car [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) est `true`. Après avoir enregistré et rouvert la présentation, les libellés affichent `12.5000%` et `0.12346`, comme illustré ci‑dessous. L’axe vertical utilise son propre [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) de `0.00`, avec [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) défini sur `false`.

Pour formater un libellé de données indépendamment, désactivez son indicateur de liaison à la source (`false`) et attribuez‑lui un [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/). Cela ne modifie pas le format de la cellule du classeur. Par exemple, un format de libellé indépendant `0.00` affiche la première valeur comme `0.13`, tandis que B2 continue d’afficher `12.5000%`. Consultez [Chart Data Labels](/slides/fr/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) pour le formatage direct des libellés.

L’image ci‑dessous a été rendue à partir de la présentation enregistrée après l’avoir rouvert :

![Graphique à colonnes avec libellés liés à la source affichant 12.5000% et 0.12346 et un axe numérique formaté indépendamment.](custom-cell-formats.png)

## **Définir une cellule du classeur comme libellé de données du graphique**

Vous pouvez utiliser le texte des cellules du classeur comme libellés de données du graphique.

Cet exemple ajoute un graphique à bulles avec des données par défaut à la première diapositive d’une présentation existante. Il utilise les cellules A10:A12 sur la feuille 0 pour les trois premiers libellés de la première série, active les libellés depuis les cellules et enregistre la présentation mise à jour.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart2.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
var series = chart.ChartData.Series[0];
var workbook = chart.ChartData.ChartDataWorkbook;

series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;
series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0 cell value");
series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1 cell value");
series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2 cell value");

presentation.Save("resultchart.pptx", SaveFormat.Pptx);
```

## **Gérer les feuilles de calcul**

La propriété [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) fournit l’accès aux feuilles de calcul d’un classeur de graphique. Cet exemple crée un graphique circulaire avec des données par défaut et affiche chaque nom de feuille dans la console.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
var workbook = chart.ChartData.ChartDataWorkbook;

for (var i = 0; i < workbook.Worksheets.Count; i++)
{
    Console.WriteLine(workbook.Worksheets[i].Name);
}
```

## **Spécifier le type de source de données**

Les valeurs des points de série peuvent également être stockées directement comme littéraux numériques. Consultez [Set Series Values Using Numeric Literals](/slides/fr/net/chart-series/#set-series-values-using-numeric-literals) pour un exemple complet qui les enregistre et les lit. Le type de source des valeurs de points est séparé de la configuration interne ou externe du classeur du graphique ; l’utilisation de littéraux numériques ne supprime pas, à elle seule, le classeur intégré.

Cet exemple crée un graphique à colonnes 3D avec des données par défaut et définit deux noms de séries en utilisant différentes sources de données. Le premier nom utilise un littéral de chaîne ; le second utilise la cellule C1 sur la feuille 0. L’énumération [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) sélectionne la source pour chaque nom. L’exemple enregistre la présentation avec les noms de séries mis à jour.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
var literalName = chart.ChartData.Series[0].Name;

literalName.DataSourceType = DataSourceType.StringLiterals;
literalName.Data = "LiteralString";

var cellName = chart.ChartData.Series[1].Name;
var nameCell = chart.ChartData.ChartDataWorkbook.GetCell(0, "C1", "NewCell");
cellName.DataSourceType = DataSourceType.Worksheet;
cellName.Data = nameCell;

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **Détecter les formats de classeur intégré non pris en charge**

Aspose.Slides ne prend pas en charge le format de classeur Excel binaire (.xlsb) qui peut être intégré dans certains graphiques. Vous pouvez utiliser la propriété [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) de [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) conjointement avec l’énumération [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) pour détecter les formats non pris en charge et ignorer ces graphiques. Cet exemple inspecte les formes de la première diapositive d’une présentation existante, ignore les formes qui ne sont pas des graphiques et affiche un message de diagnostic pour chaque graphique contenant un classeur .xlsb intégré.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
    {
        continue;
    }

    var chartData = chart.ChartData;
    var isInternalWorkbook = chartData.DataSourceType == ChartDataSourceType.InternalWorkbook;
    var isBinaryMacro = chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console.WriteLine("Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // Lire ou modifier les données du classeur de graphique prises en charge ici.
}
```

## **Classeur externe**

Aspose.Slides prend en charge l’utilisation de classeurs externes comme source de données pour les graphiques.

### **Créer un classeur externe**

Utilisez [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) et [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) pour exporter le classeur d’un graphique intégré vers un fichier et lier le graphique à ce classeur externe.

Cet exemple crée un graphique circulaire avec des données par défaut et exporte son classeur. Il ferme le flux de sortie avant d’attribuer le classeur externe comme source de données du graphique, puis enregistre la présentation liée.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
var workbookPath = Path.GetFullPath("externalWorkbook1.xlsx");

using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var fileStream = File.Create(workbookPath))
{
    workbookStream.CopyTo(fileStream);
}

chart.ChartData.SetExternalWorkbook(workbookPath);
presentation.Save("externalWorkbook.pptx", SaveFormat.Pptx);
```

### **Définir un classeur externe**

En utilisant la méthode [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/), vous pouvez affecter un classeur externe à un graphique comme source de données. Cette méthode peut également être utilisée pour mettre à jour le chemin du classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas modifier les données des classeurs stockés dans des emplacements ou des ressources distants, vous pouvez toujours les utiliser comme source de données externe. Si le chemin relatif d’un classeur externe est fourni, il est converti automatiquement en chemin complet.

Cet exemple utilise un classeur externe dont la feuille nommée `Sheet1` contient un nom de série en B1, des noms de catégorie en A2:A4 et des valeurs numériques en B2:B4. L’exemple crée un graphique circulaire, lie le classeur et utilise [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) pour mapper A1:B4 à une série et trois catégories. Il enregistre la présentation avec le graphique lié.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
var chartData = chart.ChartData;
var workbookPath = Path.GetFullPath("externalWorkbook.xlsx");

chartData.SetExternalWorkbook(workbookPath);
chartData.SetRange("Sheet1!$A$1:$B$4");

presentation.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
```

Le paramètre `updateChartData` de [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) contrôle si le classeur est chargé.

* Lorsque `updateChartData` est `false`, seul le chemin du classeur est mis à jour. Les données du graphique ne sont pas chargées ni mises à jour depuis le classeur cible, de sorte que le classeur peut être indisponible.
* Lorsque `updateChartData` est `true`, les données du graphique sont mises à jour depuis le classeur cible.

L’exemple suivant affecte une URL factice avec `updateChartData` réglé sur `false`. Il conserve les données par défaut du graphique circulaire et enregistre la présentation sans charger le classeur indisponible.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

chart.ChartData.SetExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);
presentation.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
```

### **Obtenir le chemin du classeur source de données externe d'un graphique**

Pour identifier le classeur lié à un graphique, vérifiez si le graphique utilise une source de données externe et récupérez son chemin de classeur.

Cet exemple examine la première forme de la première diapositive d’une présentation contenant un classeur externe lié. Si c’est un graphique lié à un classeur externe, l’exemple affiche [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) dans la console. Il enregistre ensuite une copie de la présentation.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("externalWorkbook.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    if (chartData.DataSourceType == ChartDataSourceType.ExternalWorkbook)
    {
        Console.WriteLine(chartData.ExternalWorkbookPath);
    }
    else
    {
        Console.WriteLine("The chart does not use an external workbook.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

### **Modifier les données du graphique**

Vous pouvez modifier les données des classeurs externes de la même manière que vous modifiez le contenu des classeurs internes. Lorsqu’un classeur externe ne peut pas être chargé, une exception est levée.

Cet exemple utilise un graphique qui est la première forme de la première diapositive et qui est lié à un classeur externe accessible. Il définit la valeur basée sur la cellule du premier point de données de la première série à 100 et enregistre la présentation mise à jour. La modification des valeurs des cellules peut mettre à jour le fichier XLSX externe lié, donc utilisez une copie si vous devez préserver le classeur d’origine.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var series = chart.ChartData.Series;
    if (series.Count > 0 && series[0].DataPoints.Count > 0)
    {
        var valueCell = series[0].DataPoints[0].Value.AsCell;
        if (valueCell != null)
        {
            valueCell.Value = 100;
            presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
        }
        else
        {
            Console.WriteLine("The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console.WriteLine("The chart has no data points to edit.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Récupérer un classeur depuis le cache du graphique**

Si un graphique utilise un classeur externe manquant ou indisponible, Aspose.Slides peut reconstruire le classeur du graphique à partir des données mises en cache dans la présentation. Créez un [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/), configurez son [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/), et définissez [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) sur `true` avant d’ouvrir la présentation.

L’exemple C# suivant récupère les données du classeur pour un graphique qui est la première forme de la première diapositive et qui référence un classeur externe indisponible. Il accède aux données récupérées via [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) et [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // Lire ou modifier les données du classeur récupéré ici.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Si le classeur externe est indisponible et que la récupération est désactivée, Aspose.Slides génère une [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Activez la récupération uniquement lorsque l’utilisation des données de graphique en cache est une solution de secours acceptable, car le cache peut ne pas contenir les modifications apportées au classeur externe après la dernière mise à jour de la présentation.

## **FAQ**

**Puis-je déterminer si un graphique spécifique est lié à un classeur externe ou intégré ?**

Oui. Un graphique possède un [type de source de données](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) et un [chemin vers un classeur externe](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) ; si la source est un classeur externe, vous pouvez lire le chemin complet pour vous assurer qu’un fichier externe est utilisé.

**Les chemins relatifs vers les classeurs externes sont‑ils pris en charge, et comment sont‑ils stockés ?**

Oui. Si vous spécifiez un chemin relatif, il est automatiquement converti en chemin absolu. La présentation stocke le chemin absolu dans le fichier PPTX, de sorte que le déplacement du classeur peut nécessiter la mise à jour du lien.

**Puis‑je utiliser des classeurs situés sur des ressources ou partages réseau ?**

Oui, ces classeurs peuvent être utilisés comme source de données externe. Cependant, la modification directe de classeurs distants depuis Aspose.Slides n’est pas prise en charge — ils ne peuvent être utilisés que comme source.

**Aspose.Slides écrase‑t‑il le fichier XLSX externe lors de l’enregistrement de la présentation ?**

La présentation stocke un [lien vers le fichier externe](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/). La modification des données du graphique basées sur des cellules peut également mettre à jour le fichier XLSX local lié. Utilisez une copie du classeur si l’original doit rester inchangé.

**Que faire si le fichier externe est protégé par mot de passe ?**

Aspose.Slides n’accepte pas de mot de passe lors de la création du lien. Une approche courante consiste à supprimer la protection au préalable ou à préparer une copie déchiffrée (par exemple avec [Aspose.Cells](https://reference.aspose.com/cells/net/)) et à créer le lien vers cette copie.

**Plusieurs graphiques peuvent‑ils référencer le même classeur externe ?**

Oui. Chaque graphique stocke son propre lien. S’ils pointent tous vers le même fichier, la mise à jour de ce fichier sera reflétée dans chaque graphique lors du chargement suivant des données.