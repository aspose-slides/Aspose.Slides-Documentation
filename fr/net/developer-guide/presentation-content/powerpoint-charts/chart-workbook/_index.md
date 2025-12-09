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
- étiquette de données
- feuille de calcul
- source de données
- classeur externe
- données externes
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez Aspose.Slides pour .NET : gérez facilement les classeurs de graphiques dans les formats PowerPoint et OpenDocument pour rationaliser les données de votre présentation."
---

## **Définir les données du graphique à partir du classeur**
Aspose.Slides fournit les méthodes [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) et [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) qui permettent de lire et d’écrire les classeurs de données de graphique (contenant des données de graphique modifiées avec Aspose.Cells). **Remarque** le jeu de données du graphique doit être organisé de la même manière ou avoir une structure similaire à la source.

Ce code C# montre une opération d’exemple :
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


## **Définir une cellule du classeur comme étiquette de données du graphique**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive via son indice.
1. Ajoutez un graphique à bulles avec quelques données.
1. Accédez aux séries du graphique.
1. Définissez la cellule du classeur comme étiquette de données.
1. Enregistrez la présentation.

Ce code C# vous montre comment définir une cellule du classeur comme étiquette de données du graphique :
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

Ce code C# démontre une opération où la propriété [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) est utilisée pour accéder à une collection de feuilles :
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
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NewCell");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Classeur externe**

{{% alert color="primary" %}} 
Dans [Aspose.Slides 19.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-19-4-release-notes/), nous avons implémenté la prise en charge des classeurs externes comme source de données pour les graphiques.
{{% /alert %}} 

### **Créer un classeur externe**
En utilisant les méthodes **`ReadWorkbookStream`** et **`SetExternalWorkbook`**, vous pouvez créer un classeur externe à partir de zéro ou rendre un classeur interne externe.

Ce code C# montre le processus de création d’un classeur externe :
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
En utilisant la méthode **`SetExternalWorkbook`**, vous pouvez assigner un classeur externe à un graphique comme source de données. Cette méthode peut également être utilisée pour mettre à jour le chemin du classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas modifier les données des classeurs stockés à distance ou dans des ressources, vous pouvez tout de même les utiliser comme source de données externe. Si le chemin relatif d’un classeur externe est fourni, il est automatiquement converti en chemin complet.

Ce code C# montre comment définir un classeur externe :
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


Le paramètre `ChartData` (dans la méthode `SetExternalWorkbook`) sert à indiquer si le classeur Excel doit être chargé ou non. 

* Lorsque la valeur de `ChartData` est définie sur `false`, seul le chemin du classeur est mis à jour — les données du graphique ne sont pas chargées ou mises à jour depuis le classeur cible. Vous pouvez utiliser ce réglage lorsque le classeur cible n’existe pas ou est indisponible. 
* Lorsque la valeur de `ChartData` est définie sur `true`, les données du graphique sont mises à jour depuis le classeur cible.
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
1. Obtenez une référence à une diapositive via son indice.
1. Créez un objet pour la forme du graphique.
1. Créez un objet pour le type source (`ChartDataSourceType`) qui représente la source de données du graphique.
1. Spécifiez la condition pertinente en fonction du type source identique au type de source du classeur externe.

Ce code C# montre l’opération :
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


### **Modifier les données du graphique**

Vous pouvez modifier les données des classeurs externes de la même manière que vous modifiez le contenu des classeurs internes. Lorsqu’un classeur externe ne peut pas être chargé, une exception est levée.

Ce code C# implémente le processus décrit :
```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Puis-je déterminer si un graphique spécifique est lié à un classeur externe ou intégré ?**

Oui. Un graphique possède un [type de source de données](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) et un [chemin vers un classeur externe](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) ; si la source est un classeur externe, vous pouvez lire le chemin complet pour vérifier qu’un fichier externe est utilisé.

**Les chemins relatifs vers des classeurs externes sont‑ils pris en charge, et comment sont‑ils stockés ?**

Oui. Si vous spécifiez un chemin relatif, il est automatiquement converti en chemin absolu. Cela facilite la portabilité du projet ; toutefois, la présentation stockera le chemin absolu dans le fichier PPTX.

**Puis‑je utiliser des classeurs situés sur des ressources ou partages réseau ?**

Oui, ces classeurs peuvent être utilisés comme source de données externe. En revanche, la modification directe de classeurs distants depuis Aspose.Slides n’est pas prise en charge — ils ne peuvent être qu’une source.

**Aspose.Slides écrase‑t‑il le fichier XLSX externe lors de l’enregistrement de la présentation ?**

Non. La présentation stocke un [lien vers le fichier externe](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) et l’utilise uniquement pour la lecture des données. Le fichier externe lui‑même n’est pas modifié lors de l’enregistrement.

**Que faire si le fichier externe est protégé par un mot de passe ?**

Aspose.Slides n’accepte pas de mot de passe lors de la liaison. Une approche courante consiste à supprimer la protection au préalable ou à préparer une copie déchiffrée (par exemple avec [Aspose.Cells](/cells/net/)) et à la lier.

**Plusieurs graphiques peuvent‑ils faire référence au même classeur externe ?**

Oui. Chaque graphique stocke son propre lien. S’ils pointent tous vers le même fichier, la mise à jour de ce fichier sera reflétée dans chaque graphique lors du prochain chargement des données.