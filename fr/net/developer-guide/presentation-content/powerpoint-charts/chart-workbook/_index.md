---
title: Classeur de graphiques
type: docs
weight: 70
url: /net/chart-workbook/
keywords: "Classeur de graphiques, données de graphique, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Classeur de graphiques dans la présentation PowerPoint en C# ou .NET"
---

## **Définir les données du graphique à partir du classeur**
Aspose.Slides fournit les méthodes [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) et [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) qui vous permettent de lire et d'écrire des classeurs de données de graphique (contenant des données de graphique éditées avec Aspose.Cells). **Remarque** que les données de graphique doivent être organisées de la même manière ou doivent avoir une structure similaire à celle de la source.

Ce code C# démontre une opération d'exemple :

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


## **Définir une cellule de classeur comme étiquette de donnée du graphique**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence de diapositive par son index.
1. Ajoutez un graphique en bulle avec des données.
1. Accédez aux séries de graphiques.
1. Définissez la cellule du classeur comme une étiquette de donnée.
1. Enregistrez la présentation.

Ce code C# vous montre comment définir une cellule de classeur comme une étiquette de donnée du graphique :

```c#
string lbl0 = "Valeur de la cellule d'étiquette 0";
string lbl1 = "Valeur de la cellule d'étiquette 1";
string lbl2 = "Valeur de la cellule d'étiquette 2";

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

## **Gérer les feuilles de calcul**

Ce code C# démontre une opération où la propriété [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) est utilisée pour accéder à une collection de feuilles de calcul :

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

Ce code C# vous montre comment spécifier un type pour une source de données :

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "LiteralString";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NouvelleCellule");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Classeur externe**

{{% alert color="primary" %}} 
Dans [Aspose.Slides 19.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-19-4-release-notes/), nous avons implémenté le support des classeurs externes comme source de données pour les graphiques.
{{% /alert %}} 

### **Créer un classeur externe**
En utilisant les méthodes **`ReadWorkbookStream`** et **`SetExternalWorkbook`**, vous pouvez soit créer un classeur externe à partir de zéro, soit rendre un classeur interne externe.

Ce code C# démontre le processus de création de classeur externe :

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
En utilisant la méthode **`SetExternalWorkbook`**, vous pouvez attribuer un classeur externe à un graphique comme source de données. Cette méthode peut également être utilisée pour mettre à jour un chemin vers le classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas modifier les données dans les classeurs stockés dans des emplacements ou des ressources distants, vous pouvez toujours utiliser de tels classeurs comme source de données externe. Si le chemin relatif pour un classeur externe est fourni, il est automatiquement converti en un chemin complet.

Ce code C# vous montre comment définir un classeur externe :

```c#
// Le chemin vers le répertoire des documents.
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

Le paramètre `ChartData` (sous la méthode `SetExternalWorkbook`) est utilisé pour spécifier si un classeur Excel sera chargé ou non. 

* Lorsque la valeur de `ChartData` est définie sur `false`, seul le chemin du classeur est mis à jour—les données du graphique ne seront pas chargées ni mises à jour à partir du classeur cible. Vous pourriez vouloir utiliser ce paramètre dans une situation où le classeur cible est inexistant ou indisponible. 
* Lorsque la valeur de `ChartData` est définie sur `true`, les données du graphique sont mises à jour à partir du classeur cible.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Obtenir le chemin du classeur source de données externe du graphique**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence de diapositive par son index.
1. Créez un objet pour la forme de graphique.
1. Créez un objet pour le type de source (`ChartDataSourceType`) qui représente la source de données du graphique.
1. Spécifiez la condition pertinente en fonction du type de source étant le même que le type de source de données du classeur externe.

Ce code C# démontre l'opération :

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
    
    // Sauvegarde la présentation
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Modifier les données du graphique**

Vous pouvez modifier les données dans des classeurs externes de la même manière que vous faites des modifications aux contenus de classeurs internes. Lorsqu'un classeur externe ne peut pas être chargé, une exception est levée.

Ce code C# est une implémentation du processus décrit :

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```