---
title: Gérer les classeurs de diagrammes dans les présentations en .NET
linktitle: Classeur de diagramme
type: docs
weight: 70
url: /fr/net/chart-workbook/
keywords:
  - classeur de diagramme
  - données de diagramme
  - cellule de classeur
  - étiquette de données
  - feuille de calcul
  - source de données
  - classeur externe
  - données externes
  - cache de diagramme
  - récupération de classeur
  - PowerPoint
  - présentation
  - .NET
  - C#
  - Aspose.Slides
description: "Découvrez Aspose.Slides pour .NET : gérez facilement les classeurs de diagrammes dans les formats PowerPoint et OpenDocument pour rationaliser les données de votre présentation."
---
## **Aperçu**

Cet article explique comment travailler avec les classeurs de diagrammes dans Aspose.Slides. Il montre comment lire et écrire les données de diagramme via des flux de classeur, utiliser les cellules du classeur comme étiquettes de données de diagramme, accéder aux collections de feuilles de calcul et spécifier le type de source de données pour les valeurs du diagramme.

Il couvre également l’utilisation de classeurs externes comme sources de données de diagrammes. Les exemples démontrent comment créer et affecter un classeur externe, récupérer le chemin d’un classeur externe lié à un diagramme et modifier les données du diagramme lorsque le classeur est disponible.

## **Lire et écrire des données de diagramme à partir d’un classeur**
Aspose.Slides fournit les méthodes [ReadWorkbookStream](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdata/readworkbookstream/) et [WriteWorkbookStream](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdata/writeworkbookstream/) qui permettent de lire et d’écrire des classeurs de données de diagramme (contenant des données de diagramme éditées avec Aspose.Cells). **Remarque** que les données du diagramme doivent être organisées de la même manière ou posséder une structure similaire à celle de la source.

```c#
using (Presentation pres = new Presentation("chart.pptx"))
{
    Chart chart = (Chart) pres.Slides[0].Shapes[0];
    IChartData data = chart.ChartData;

    MemoryStream stream = data.ReadWorkbookStream();

    data.Series.Clear();
    data.Categories.Clear();

    stream.Position = 0;
    data.WriteWorkbookStream(stream);
}
```

## **Définir une cellule de WorkBook comme étiquette de données de diagramme**
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
1. Obtenir la référence d’une diapositive via son indice.
1. Ajouter un diagramme à bulles avec des données.
1. Accéder aux séries du diagramme.
1. Définir la cellule du classeur comme étiquette de données.
1. Enregistrer la présentation.

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Instancie une classe de présentation qui représente un fichier de présentation

using (Presentation pres = new Presentation("chart2.pptx"))
{
    ISlide slide = pres.Slides[0];


    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.ChartData.Series;

    series[0].Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    series[0].Labels[0].ValueFromCell = wb.GetCell(0, "A10", lbl0);
    series[0].Labels[1].ValueFromCell = wb.GetCell(0, "A11", lbl1);
    series[0].Labels[2].ValueFromCell = wb.GetCell(0, "A12", lbl2);

    pres.Save("resultchart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Gestion des feuilles de calcul**

Ce code C# montre une opération où la propriété [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) est utilisée pour accéder à une collection de feuilles de calcul :

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Spécifier le type de source de données**

Ce code C# montre comment spécifier un type pour une source de données :

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "LiteralString";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NewCell");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Détecter les formats de classeur incorporés non pris en charge**

Aspose.Slides ne prend pas en charge le format de classeur binaire Excel (.xlsb) qui peut être incorporé dans certains diagrammes. Vous pouvez utiliser la propriété `EmbeddedWorkbookType` sur [IChartData](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdata/) conjointement avec l’énumération [WorkbookType](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/workbooktype/) pour détecter les formats non pris en charge et ignorer ces diagrammes.

```csharp
using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // Le classeur incorporé est au format .xlsb, qui n’est pas pris en charge.
            continue;
        }

        // Lire ou modifier les données du classeur du diagramme ici.
    }
}
```

## **Classeur externe**

{{% alert color="primary" %}} 
Dans [Aspose.Slides 19.4](https://docs.aspose.com/slides/fr/net/aspose-slides-for-net-19-4-release-notes/), nous avons implémenté la prise en charge des classeurs externes comme source de données pour les diagrammes.
{{% /alert %}} 

### **Créer un classeur externe**
En utilisant les méthodes **`ReadWorkbookStream`** et **`SetExternalWorkbook`**, vous pouvez créer un classeur externe à partir de zéro ou rendre un classeur interne externe.

```c#
using (Presentation pres = new Presentation())
{
    const string workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
    using (FileStream fileStream = new FileStream(workbookPath, FileMode.Create))
    {
        byte[] workbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(workbookData, 0, workbookData.Length);
    }
    
    chart.ChartData.SetExternalWorkbook(Path.GetFullPath(workbookPath));

    pres.Save("externalWorkbook.pptx", SaveFormat.Pptx);
}
```

### **Définir un classeur externe**
En utilisant la méthode **`SetExternalWorkbook`**, vous pouvez affecter un classeur externe à un diagramme comme source de données. Cette méthode peut également être utilisée pour mettre à jour le chemin du classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas modifier les données des classeurs stockés sur des emplacements distants ou des ressources, vous pouvez toujours les utiliser comme source de données externe. Si un chemin relatif pour un classeur externe est fourni, il est automatiquement converti en chemin complet.

```c#
// Le chemin du répertoire des documents.
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook(Path.GetFullPath("externalWorkbook.xlsx"));
                  

    chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1"), ChartType.Pie);
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B2"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B3"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B4"));

    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4"));
    pres.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
}
```

Le paramètre `ChartData` (dans la méthode `SetExternalWorkbook`) indique si un classeur Excel sera chargé ou non.

* Lorsque la valeur de `ChartData` est `false`, seul le chemin du classeur est mis à jour — les données du diagramme ne sont pas chargées ou mises à jour depuis le classeur cible. Utilisez ce paramètre lorsqu’il est possible que le classeur cible soit inexistant ou indisponible.  
* Lorsque la valeur de `ChartData` est `true`, les données du diagramme sont mises à jour à partir du classeur cible.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Obtenir le chemin du classeur source de données externe d’un diagramme**

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
1. Obtenir la référence d’une diapositive via son indice.
1. Créer un objet pour la forme du diagramme.
1. Créer un objet pour le type source (`ChartDataSourceType`) qui représente la source de données du diagramme.
1. Spécifier la condition pertinente en fonction du type de source correspondant au type de source de données du classeur externe.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // Enregistre la présentation
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Modifier les données du diagramme**

Vous pouvez modifier les données dans les classeurs externes de la même façon que vous modifiez le contenu des classeurs internes. Lorsqu’un classeur externe ne peut pas être chargé, une exception est levée.

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **Récupérer un classeur depuis le cache du diagramme**

Si un diagramme utilise un classeur externe manquant ou indisponible, Aspose.Slides peut reconstruire le classeur du diagramme à partir des données mises en cache dans la présentation. Créez un objet [LoadOptions](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/), configurez ses [SpreadsheetOptions](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/spreadsheetoptions/), et définissez [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fr/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) sur `true` avant d’ouvrir la présentation.

L’exemple C# suivant ouvre une présentation dont le diagramme référence un classeur externe indisponible et accède aux données récupérées via [IChart.ChartData](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichart/chartdata/) et [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdata/chartdataworkbook/) :

```csharp
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        RecoverWorkbookFromChartCache = true
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

var chart = (IChart)presentation.Slides[0].Shapes[0];
var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

// Read or modify the recovered workbook data here.
```

Si le classeur externe est indisponible et que la récupération est désactivée, Aspose.Slides lève une `InvalidOperationException`. Activez la récupération uniquement lorsque l’utilisation des données du diagramme en cache constitue une solution de secours acceptable, car le cache peut ne pas contenir les modifications apportées au classeur externe après la dernière mise à jour de la présentation.

## **FAQ**

**Puis‑je déterminer si un diagramme spécifique est lié à un classeur externe ou incorporé ?**  
Oui. Un diagramme possède un [type de source de données](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/chartdata/datasourcetype/) et un [chemin vers un classeur externe](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/chartdata/externalworkbookpath/) ; si la source est un classeur externe, vous pouvez lire le chemin complet pour confirmer qu’un fichier externe est utilisé.

**Les chemins relatifs vers les classeurs externes sont‑ils pris en charge et comment sont‑ils stockés ?**  
Oui. Si vous indiquez un chemin relatif, il est automatiquement converti en chemin absolu. Cela facilite la portabilité du projet ; cependant, la présentation stockera le chemin absolu dans le fichier PPTX.

**Puis‑je utiliser des classeurs situés sur des ressources ou partages réseau ?**  
Oui, ces classeurs peuvent être utilisés comme source de données externe. En revanche, la modification directe de classeurs distants depuis Aspose.Slides n’est pas prise en charge ; ils ne peuvent être qu’une source.

**Aspose.Slides écrase‑t‑il le fichier XLSX externe lors de l’enregistrement de la présentation ?**  
Non. La présentation enregistre un [lien vers le fichier externe](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/chartdata/externalworkbookpath/) et l’utilise uniquement pour lire les données. Le fichier externe lui‑même n’est pas modifié lors de l’enregistrement.

**Que faire si le fichier externe est protégé par un mot de passe ?**  
Aspose.Slides n’accepte pas de mot de passe lors de la création du lien. L’approche courante consiste à supprimer la protection à l’avance ou à préparer une copie décryptée (par exemple avec [Aspose.Cells](/cells/net/)) et à créer le lien vers cette copie.

**Plusieurs diagrammes peuvent‑ils référencer le même classeur externe ?**  
Oui. Chaque diagramme stocke son propre lien. S’ils pointent tous vers le même fichier, la mise à jour de ce fichier sera reflétée dans chaque diagramme lors du prochain chargement des données.