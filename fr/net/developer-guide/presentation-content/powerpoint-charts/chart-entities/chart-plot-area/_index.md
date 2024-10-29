---
title: Zone de tracé de graphique
type: docs
url: /fr/net/chart-plot-area/
keywords: "Zone de tracé de graphique présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Obtenez la largeur, la hauteur de la zone de tracé de graphique. Définir le mode de disposition. Présentation PowerPoint en C# ou .NET"
---

## **Obtenir la largeur, la hauteur de la zone de tracé de graphique**
Aspose.Slides pour .NET fournit une API simple pour . 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Appelez la méthode IChart.ValidateChartLayout() avant d'obtenir les valeurs réelles.
1. Obtenez la position X réelle (gauche) de l'élément graphique par rapport au coin supérieur gauche du graphique.
1. Obtenez le haut réel de l'élément graphique par rapport au coin supérieur gauche du graphique.
1. Obtenez la largeur réelle de l'élément graphique.
1. Obtenez la hauteur réelle de l'élément graphique.

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
    
    // Sauvegarder la présentation avec le graphique
    pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```

## **Définir le mode de disposition de la zone de tracé de graphique**
Aspose.Slides pour .NET fournit une API simple pour définir le mode de disposition de la zone de tracé de graphique. La propriété **LayoutTargetType** a été ajoutée aux classes **ChartPlotArea** et **IChartPlotArea**. Si la disposition de la zone de tracé est définie manuellement, cette propriété spécifie si la disposition de la zone de tracé doit se faire par son intérieur (sans inclure les marques de graduation et les étiquettes d'axe) ou par son extérieur (en incluant les marques de graduation et les étiquettes d'axe). Il existe deux valeurs possibles définies dans l'énumération **LayoutTargetType**.

- **LayoutTargetType.Inner** - spécifie que la taille de la zone de tracé doit déterminer la taille de la zone de tracé, sans inclure les marques de graduation et les étiquettes d'axe.
- **LayoutTargetType.Outer** - spécifie que la taille de la zone de tracé doit déterminer la taille de la zone de tracé, y compris les marques de graduation et les étiquettes d'axe.

Un exemple de code est donné ci-dessous.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```