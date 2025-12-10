---
title: Personnaliser les zones de tracé des graphiques de présentation dans .NET
linktitle: Zone de tracé
type: docs
url: /fr/net/chart-plot-area/
keywords:
- graphique
- zone de tracé
- largeur de la zone de tracé
- hauteur de la zone de tracé
- taille de la zone de tracé
- mode de mise en page
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez comment personnaliser les zones de tracé des graphiques dans les présentations PowerPoint avec Aspose.Slides pour .NET. Améliorez l'aspect visuel de vos diapositives facilement."
---

## **Obtenir la largeur et la hauteur d'une zone de tracé de graphique**
Aspose.Slides for .NET fournit une API simple pour .

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Accéder à la première diapositive.
1. Ajouter un graphique avec les données par défaut.
1. Appeler la méthode IChart.ValidateChartLayout() avant pour obtenir les valeurs réelles.
1. Obtient la position X réelle (gauche) de l'élément du graphique relative au coin supérieur gauche du graphique.
1. Obtient le haut réel de l'élément du graphique relatif au coin supérieur gauche du graphique.
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





## **Définir le mode de mise en page d'une zone de tracé de graphique**
Aspose.Slides for .NET fournit une API simple pour définir le mode de mise en page de la zone de tracé du graphique. La propriété **LayoutTargetType** a été ajoutée aux classes **ChartPlotArea** et **IChartPlotArea**. Si la mise en page de la zone de tracé est définie manuellement, cette propriété indique si la zone de tracé doit être disposée par son intérieur (sans les axes et les libellés d'axes) ou par son extérieur (en incluant les axes et les libellés d'axes). Deux valeurs possibles sont définies dans l'énumération **LayoutTargetType**.

- **LayoutTargetType.Inner** - spécifie que la taille de la zone de tracé détermine la taille de la zone de tracé, sans inclure les marques de graduation et les libellés d'axes.
- **LayoutTargetType.Outer** - spécifie que la taille de la zone de tracé détermine la taille de la zone de tracé, les marques de graduation et les libellés d'axes.

Le code d'exemple est donné ci-dessous.
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

**Dans quelles unités sont retournés ActualX, ActualY, ActualWidth et ActualHeight ?**

En points ; 1 pouce = 72 points. Il s'agit des unités de coordonnées d'Aspose.Slides.

**En quoi la zone de tracé diffère-t-elle de la zone du graphique en termes de contenu ?**

La zone de tracé est la région de dessin des données (séries, quadrillages, lignes de tendance, etc.) ; la zone du graphique inclut les éléments entourant (titre, légende, etc.). Dans les graphiques 3D, la zone de tracé comprend également les murs/plancher et les axes.

**Comment les X, Y, largeur et hauteur de la zone de tracé sont-ils interprétés lorsque la mise en page est manuelle ?**

Ils sont exprimés en fractions (0‑1) de la taille globale du graphique ; dans ce mode, le positionnement automatique est désactivé et les fractions que vous définissez sont utilisées.

**Pourquoi la position de la zone de tracé a-t-elle changé après l'ajout/le déplacement de la légende ?**

La légende se trouve dans la zone du graphique, en dehors de la zone de tracé, mais elle influence la mise en page et l'espace disponible, ainsi la zone de tracé peut se déplacer lorsque le positionnement automatique est actif. (Ceci est le comportement standard des graphiques PowerPoint.)