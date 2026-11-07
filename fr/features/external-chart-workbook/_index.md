---
title: Lier des graphiques à des classeurs externes
description: Lier les données du graphique à un classeur externe et les actualiser.
type: docs
url: /fr/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: charts
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **Aperçu**

Pointez un graphique sur un classeur externe au lieu de conserver toutes ses données sources intégrées à la présentation. Vous pouvez définir le chemin du classeur et choisir de mettre à jour le graphique à partir de ce fichier. Le graphique enregistré peut également contenir des données d'affichage mises en cache.

## **Exemple d'utilisation**

Cet exemple C# utilise Aspose.Slides for .NET. Créez un classeur de ventes valide avec North = 55 et South = 40 et enregistrez-le sous sales.xlsx à côté de la sortie. Réinitialisez la valeur North du graphique à 20, puis liez le graphique au chemin absolu du classeur et actualisez : North redevient 55. La plage explicite couvre l’en-tête et deux lignes de données. Conservez sales.xlsx disponible lors de la réouverture ou de la mise à jour du graphique lié ; la présentation n’intègre pas ce fichier externe. Aucun fichier d’entrée n’est nécessaire. Il enregistre *external-chart-workbook.pptx* et *external-chart-workbook.png*. Installez la bibliothèque en utilisant le [guide d’installation](/slides/fr/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.IO;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
firstValue.Value = 55;
var workbookPath = Path.GetFullPath("sales.xlsx");
using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var workbookFile = File.Create(workbookPath))
{
    workbookStream.CopyTo(workbookFile);
}
firstValue.Value = 20;
chart.ChartData.SetExternalWorkbook(workbookPath, true);
chart.ChartData.SetRange("Sheet1!$A$1:$B$3");
presentation.Save("external-chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("external-chart-workbook.png", ImageFormat.Png);
```

## **FAQ**

### **Puis‑je lire chaque valeur mise en cache lorsque le fichier lié est manquant ?**

Aspose.Slides for .NET 26.11 peut [lire directement les valeurs de graphique stockées](/slides/fr/net/chart-workbook/#read-cached-chart-values-without-a-workbook) sans ouvrir le classeur lié. Cela inclut les valeurs ordinaires, les valeurs X/Y, les tailles de bulles et les valeurs de catégorie lorsque ces caches existent. Les données mises en cache peuvent être absentes ou périmées ; ce n’est pas un classeur complet. L’actualisation depuis la source nécessite toujours un classeur compatible disponible. Pour d’autres SDK et versions, consultez le guide de graphique correspondant.

### **Que se passe‑t‑il si le classeur externe est déplacé ?**

Mettez à jour le chemin du classeur externe du graphique vers son nouvel emplacement et rendez ce fichier disponible partout où la présentation est traitée. Ne comptez pas sur les données en cache pour des opérations d’accès complet aux données lorsqu’il manque.

### **Puis‑je choisir d’actualiser les données du graphique mises en cache lors de la liaison ?**

Oui. Choisissez de mettre à jour les données du graphique lors de la définition du lien. L’actualisation nécessite un classeur compatible disponible ; ignorer l’actualisation enregistre le lien sans lire de nouvelles valeurs depuis ce fichier.

## **Guides**

- [Gérer les classeurs de graphiques dans les présentations en .NET](/slides/fr/net/chart-workbook/)

Fonctionnalité associée : [Remplir les graphiques modifiables avec des données](/slides/fr/features/chart-data-binding/).