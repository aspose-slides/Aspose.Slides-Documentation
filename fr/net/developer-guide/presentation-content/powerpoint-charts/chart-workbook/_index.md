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
- étiquette de donnée
- feuille de calcul
- source de données
- classeur externe
- données externes
- cache du graphique
- récupération de classeur
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez Aspose.Slides pour .NET : gérez facilement les classeurs de graphiques dans les formats PowerPoint et OpenDocument pour simplifier les données de votre présentation."
---
## **Aperçu**

Cet article explique comment travailler avec les classeurs de graphiques dans Aspose.Slides. Il montre comment lire et écrire des données de graphique via des flux de classeur, utiliser les cellules du classeur comme étiquettes de données de graphique, accéder aux collections de feuilles de calcul et spécifier le type de source de données pour les valeurs du graphique.

Il couvre également le travail avec des classeurs externes comme sources de données de graphique. Les exemples démontrent comment créer et attribuer un classeur externe, récupérer le chemin d’un classeur externe lié à un graphique, et modifier les données du graphique lorsque le classeur est disponible.

Pour les cellules de classeur qui représentent des données manquantes, voyez [Contrôler l’affichage des cellules vides](/slides/fr/net/chart-series/) pour la différence entre une cellule vide et zéro, et une comparaison en graphique linéaire des modes d’affichage disponibles.

## **Inclure les données des lignes et colonnes masquées**

Utilisez [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) pour contrôler si un graphique trace les données des lignes et colonnes de feuille de calcul masquées. Réglez-le sur `true` pour tracer uniquement les cellules visibles, ou sur `false` pour inclure à la fois les cellules visibles et masquées. Ce réglage contrôle le traçage du graphique ; il ne masque ni n’affiche les lignes ou colonnes de la feuille.

Téléchargez [hidden-source-data.pptx](hidden-source-data.pptx) et placez‑le dans le répertoire de travail. Sa première diapositive contient un graphique en colonnes comme première forme. La feuille de calcul intégrée, `Sheet1`, contient la plage source suivante, `A1:C4`. La ligne 3 et la colonne C sont masquées, mais leurs cellules contiennent toujours des valeurs.

| Ligne de feuille | A : Mois | B : Vente au détail | C : Vente en gros (colonne masquée) |
| --- | --- | --- | --- |
| 2 | Janvier | 10 | 30 |
| 3 (ligne masquée) | Février | 40 | 60 |
| 4 | Mars | 20 | 50 |

Accédez aux cellules sources via [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdata/chartdataworkbook/) et lisez [IChartDataCell.IsHidden](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatacell/ishidden/) pour inspecter leur statut masqué. Cette propriété est en lecture seule. Dans ce fichier, B2 est visible, B3 appartient à la ligne masquée, et C2 appartient à la colonne masquée ; l’exemple affiche `False`, `True` et `True` respectivement.

Pour cet exemple, rafraîchissez les données du graphique après avoir modifié le réglage de traçage : conservez le classeur intégré avec [ReadWorkbookStream](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdata/readworkbookstream/) et rechargez‑le avec [WriteWorkbookStream](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdata/writeworkbookstream/). Lors de l’inclusion de toutes les cellules, utilisez également [SetRange](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdata/setrange/) pour restaurer la plage complète, y compris la catégorie de février masquée. Modifier simplement le drapeau n’est pas suffisant pour rafraîchir les données du graphique en cache et les étiquettes de catégorie de cet exemple.

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

        // Rafraîchir les données du graphique à partir du classeur intégré.
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

L’exemple enregistre `hidden_cells_True.pptx` avec uniquement les valeurs de vente au détail visibles (10 et 20), et `hidden_cells_False.pptx` avec les six valeurs. Les images ci‑dessous ont été rendues à partir des présentations enregistrées après les avoir rouvertes ; les deux fichiers conservent le réglage de traçage assigné. La ligne 3 et la colonne C restent masquées dans les deux classeurs intégrés.

| Seulement les cellules visibles (`true`) | Toutes les cellules (`false`) |
| --- | --- |
| ![Seulement les cellules visibles : valeurs de vente au détail 10 et 20 pour janvier et mars.](hidden_cells_True.png) | ![Toutes les cellules : valeurs de vente au détail et de gros pour janvier, février et mars.](hidden_cells_False.png) |

Une cellule masquée contenant une valeur est différente d’une cellule vide. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichart/displayblanksas/) contrôle la façon dont les valeurs manquantes sont affichées ; il n’inclut ni n’exclut les données sources masquées. Voir [Contrôler l’affichage des cellules vides](/slides/fr/net/chart-series/#control-the-display-of-empty-cells) pour un exemple.

## **Lire et écrire des données de graphique à partir d’un classeur**

Aspose.Slides pour .NET fournit les méthodes [ReadWorkbookStream](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdata/readworkbookstream/) et [WriteWorkbookStream](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdata/writeworkbookstream/) qui vous permettent de lire et d’écrire des classeurs de données de graphique (contenant des données de graphique éditées avec Aspose.Cells). **Remarque** les données du graphique doivent être organisées de la même manière ou avoir une structure similaire à la source.

Cet exemple ouvre `chart.pptx`, qui doit contenir un graphique comme première forme de sa première diapositive. Il lit le classeur intégré dans un flux, efface les séries et catégories existantes, et réécrit le même classeur. Les modifications restent en mémoire ; l’exemple n’enregistre pas la présentation.

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

Lorsque vous remplacez un classeur intégré par un classeur modifié, le graphique conserve ses collections de séries et de catégories d’origine. Cette incohérence peut entraîner l’échec de [IChart.ValidateChartLayout](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichart/validatechartlayout/) avec une erreur d’indice hors limites. Effacez les séries et catégories existantes avant d’écrire le classeur mis à jour dans le graphique. Cet exemple nécessite `chart.pptx` avec un graphique comme première forme de sa première diapositive. Le commentaire indique où l’édition du classeur aurait lieu ; l’exemple exécutable réécrit le classeur original et valide la mise en page en mémoire.

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

Effacer les collections supprime les références de données obsolètes avant que le classeur ne soit réécrit. Reconstruisez toutes les correspondances de séries et de catégories nécessaires pour le classeur mis à jour avant d’utiliser le graphique.

## **Définir une cellule de classeur comme étiquette de données de graphique**

Vous pouvez utiliser le texte des cellules du classeur comme étiquettes de données de graphique. Les étapes suivantes montrent comment lier les étiquettes d’un graphique à bulles aux cellules de son classeur de données.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
2. Accédez à la première diapositive par son indice zéro.
3. Ajoutez un graphique à bulles avec des données par défaut.
4. Accédez aux séries du graphique.
5. Définissez la cellule du classeur comme étiquette de données.
6. Enregistrez la présentation.

Cet exemple ouvre `chart2.pptx`, qui doit contenir au moins une diapositive, et ajoute un graphique à bulles avec des données par défaut. Il utilise les cellules A10:A12 sur la feuille de calcul 0 pour les trois premières étiquettes de la première série, active les étiquettes depuis les cellules, et enregistre le résultat dans `resultchart.pptx`.

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

La propriété [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdataworkbook/worksheets/) donne accès aux feuilles de calcul d’un classeur de graphique. Cet exemple crée un graphique circulaire avec des données par défaut et imprime le nom de chaque feuille de calcul dans la console.

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

Cet exemple crée un graphique en colonnes 3D avec des données par défaut et définit deux noms de séries en utilisant différentes sources de données. Le premier nom utilise une chaîne littérale ; le second utilise la cellule C1 sur la feuille de calcul 0. L’énumération [DataSourceType](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/datasourcetype/) sélectionne la source pour chaque nom. Le résultat est enregistré dans `pres.pptx`.

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

Aspose.Slides ne prend pas en charge le format de classeur binaire Excel (.xlsb) qui peut être intégré dans certains graphiques. Vous pouvez utiliser la propriété [EmbeddedWorkbookType](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) sur [IChartData](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdata/) conjointement avec l’énumération [WorkbookType](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/workbooktype/) pour détecter les formats non pris en charge et ignorer ces graphiques. Cet exemple examine les formes de la première diapositive de `sample.pptx`, ignore les formes qui ne sont pas des graphiques, et imprime un message de diagnostic pour chaque graphique contenant un classeur .xlsb intégré.

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

    // Lire ou modifier les données de classeur de graphique prises en charge ici.
}
```

## **Classeur externe**

Aspose.Slides prend en charge l’utilisation de classeurs externes comme source de données pour les graphiques.

### **Créer un classeur externe**

Utilisez [ReadWorkbookStream](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdata/readworkbookstream/) et [SetExternalWorkbook](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdata/setexternalworkbook/) pour exporter un classeur de graphique intégré vers un fichier et lier le graphique à ce classeur externe.

Cet exemple crée un graphique circulaire avec des données par défaut, écrit son classeur dans `externalWorkbook1.xlsx`, ferme le flux de sortie avant d’attribuer le fichier comme source de données du graphique. Il enregistre la présentation liée dans `externalWorkbook.pptx`.

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

En utilisant la méthode [SetExternalWorkbook](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdata/setexternalworkbook/), vous pouvez affecter un classeur externe à un graphique comme source de données. Cette méthode peut également être utilisée pour mettre à jour le chemin du classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas modifier les données des classeurs stockés dans des emplacements ou ressources distants, vous pouvez toujours les utiliser comme source de données externe. Si un chemin relatif vers un classeur externe est fourni, il est automatiquement converti en chemin complet.

Cet exemple nécessite `externalWorkbook.xlsx` dans le répertoire de travail. Sa feuille de calcul nommée `Sheet1` doit contenir un nom de série en B1, des noms de catégories en A2:A4, et des valeurs numériques en B2:B4. L’exemple crée un graphique circulaire, lie le classeur, et utilise [SetRange](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdata/setrange/) pour mapper A1:B4 à une série et trois catégories. Il enregistre le résultat dans `Presentation_with_externalWorkbook.pptx`.

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

Le paramètre `updateChartData` de [SetExternalWorkbook](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdata/setexternalworkbook/) contrôle si le classeur est chargé.

* Lorsque `updateChartData` est `false`, seul le chemin du classeur est mis à jour. Les données du graphique ne sont pas chargées ou mises à jour à partir du classeur cible, ainsi le classeur peut être indisponible.
* Lorsque `updateChartData` est `true`, les données du graphique sont mises à jour à partir du classeur cible.

L’exemple suivant attribue une URL fictive avec `updateChartData` réglé sur `false`. Il conserve les données par défaut du graphique circulaire et enregistre la présentation sans charger le classeur indisponible.

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

### **Obtenir le chemin du classeur source de données externe d’un graphique**

Pour identifier le classeur lié à un graphique, vérifiez d’abord si le graphique utilise une source de données externe. Si c’est le cas, vous pouvez récupérer le chemin du classeur en suivant ces étapes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
2. Accédez à la première diapositive par son indice zéro.
3. Vérifiez que la première forme est un graphique.
4. Lisez le type de source de données du graphique.
5. Si la source est un classeur externe, lisez son chemin.

Cet exemple ouvre `externalWorkbook.pptx`, créé dans l’exemple précédent, et examine la première forme de la première diapositive. Si c’est un graphique lié à un classeur externe, l’exemple imprime [ExternalWorkbookPath](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdata/externalworkbookpath/) dans la console. Il enregistre ensuite une copie de la présentation dans `Result.pptx`.

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

Cet exemple nécessite `presentation.pptx` avec un graphique comme première forme de sa première diapositive et un classeur externe accessible. Il définit la valeur de la cellule du premier point de données de la première série à 100 et enregistre la présentation dans `presentation_out.pptx`. Modifier les valeurs des cellules peut mettre à jour le fichier XLSX externe lié, utilisez donc une copie si vous devez conserver le classeur original.

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

### **Récupérer un classeur à partir du cache du graphique**

Si un graphique utilise un classeur externe qui est manquant ou indisponible, Aspose.Slides peut reconstruire le classeur du graphique à partir des données mises en cache dans la présentation. Créez [LoadOptions](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/), configurez son [SpreadsheetOptions](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/spreadsheetoptions/), et définissez [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fr/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) sur `true` avant d’ouvrir la présentation.

L’exemple C# suivant ouvre `presentation.pptx`, dont la première forme de la première diapositive doit être un graphique faisant référence à un classeur externe indisponible, et accède aux données récupérées via [IChart.ChartData](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichart/chartdata/) et [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

Si le classeur externe est indisponible et que la récupération est désactivée, Aspose.Slides lève une [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Activez la récupération uniquement lorsque l’utilisation des données du graphique en cache constitue une solution de repli acceptable, car le cache peut ne pas contenir les modifications apportées au classeur externe après la dernière mise à jour de la présentation.

## **FAQ**

**Puis-je déterminer si un graphique spécifique est lié à un classeur externe ou intégré ?**

Oui. Un graphique possède un [type de source de données](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/chartdata/datasourcetype/) et un [chemin vers un classeur externe](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/chartdata/externalworkbookpath/). Si la source est un classeur externe, vous pouvez lire le chemin complet pour vous assurer qu’un fichier externe est utilisé.

**Les chemins relatifs vers les classeurs externes sont-ils pris en charge, et comment sont‑ils stockés ?**

Oui. Si vous spécifiez un chemin relatif, il est automatiquement converti en chemin absolu. La présentation stocke le chemin absolu dans le fichier PPTX, ainsi déplacer le classeur peut nécessiter la mise à jour du lien.

**Puis‑je utiliser des classeurs situés sur des ressources/partages réseau ?**

Oui, ces classeurs peuvent être utilisés comme source de données externe. Cependant, la modification directe de classeurs distants depuis Aspose.Slides n’est pas prise en charge ; ils ne peuvent être utilisés que comme source.

**Aspose.Slides écrase‑t‑il le fichier XLSX externe lors de l’enregistrement de la présentation ?**

La présentation stocke un [lien vers le fichier externe](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/chartdata/externalworkbookpath/). Modifier les données du graphique basées sur des cellules peut également mettre à jour le fichier XLSX local lié. Utilisez une copie du classeur si l’original doit rester inchangé.

**Que faire si le fichier externe est protégé par un mot de passe ?**

Aspose.Slides n’accepte pas de mot de passe lors de la liaison. Une approche courante consiste à supprimer la protection à l’avance ou à préparer une copie déchiffrée (par exemple, en utilisant [Aspose.Cells](https://reference.aspose.com/cells/net/)) et à la lier.

**Plusieurs graphiques peuvent‑ils référencer le même classeur externe ?**

Oui. Chaque graphique conserve son propre lien. S’ils pointent tous vers le même fichier, la mise à jour de ce fichier sera reflétée dans chaque graphique lors du prochain chargement des données.