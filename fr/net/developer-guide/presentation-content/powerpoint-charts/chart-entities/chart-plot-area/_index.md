---
title: Zone de tracé du graphique
type: docs
url: /fr/net/chart-plot-area/
keywords: "Zone de tracé du graphique présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Obtenez la largeur et la hauteur de la zone de tracé du graphique. Définissez le mode de mise en page. Présentation PowerPoint en C# ou .NET"
---

## **Obtenir la largeur, la hauteur de la zone de tracé du graphique**
Aspose.Slides for .NET fournit une API simple pour .

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Accéder à la première diapositive.
1. Ajouter un graphique avec les données par défaut.
1. Appeler la méthode IChart.ValidateChartLayout() au préalable pour obtenir les valeurs réelles.
1. Obtient la position X réelle (gauche) de l'élément du graphique par rapport au coin supérieur gauche du graphique.
1. Obtient la position verticale réelle de l'élément du graphique par rapport au coin supérieur gauche du graphique.
1. Obtient la largeur réelle de l'élément du graphique.
1. Obtient la hauteur réelle de l'élément du graphique.
```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Enregistrer la présentation avec le graphique
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```



## **Définir le mode de mise en page de la zone de tracé du graphique**
Aspose.Slides for .NET fournit une API simple pour définir le mode de mise en page de la zone de tracé du graphique. La propriété **LayoutTargetType** a été ajoutée aux classes **ChartPlotArea** et **IChartPlotArea**. Si la mise en page de la zone de tracé est définie manuellement, cette propriété indique s'il faut disposer la zone de tracé par son intérieur (sans les axes et les libellés d'axe) ou par son extérieur (en incluant les axes et les libellés d'axe). Il existe deux valeurs possibles qui sont définies dans l'énumération **LayoutTargetType**.

- **LayoutTargetType.Inner** - indique que la taille de la zone de tracé détermine la taille de la zone de tracé, sans inclure les marques de repère et les libellés d'axe.
- **LayoutTargetType.Outer** - indique que la taille de la zone de tracé détermine la taille de la zone de tracé, les marques de repère et les libellés d'axe.

Un exemple de code est fourni ci‑dessous.
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


## **FAQ**

**Dans quelles unités sont renvoyés ActualX, ActualY, ActualWidth et ActualHeight ?**

En points ; 1 pouce = 72 points. Ce sont les unités de coordonnées d’Aspose.Slides.

**En quoi la zone de tracé diffère-t-elle de la zone du graphique en termes de contenu ?**

La zone de tracé est la région de dessin des données (séries, quadrillages, lignes de tendance, etc.) ; la zone du graphique comprend les éléments environnants (titre, légende, etc.). Dans les graphiques 3D, la zone de tracé comprend également les murs/plancher et les axes.

**Comment les X, Y, largeur et hauteur de la zone de tracé sont‑ils interprétés lorsque la mise en page est manuelle ?**

Ce sont des fractions (0–1) de la taille globale du graphique ; dans ce mode, le positionnement automatique est désactivé et les fractions que vous définissez sont utilisées.

**Pourquoi la position de la zone de tracé a‑t‑elle changé après l’ajout ou le déplacement de la légende ?**

La légende se trouve dans la zone du graphique, à l’extérieur de la zone de tracé, mais elle influence la mise en page et l’espace disponible, de sorte que la zone de tracé peut se déplacer lorsque le positionnement automatique est actif. (C’est le comportement standard des graphiques PowerPoint.)