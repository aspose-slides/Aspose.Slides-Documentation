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
- mode de disposition
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez comment personnaliser les zones de tracé des graphiques dans les présentations PowerPoint avec Aspose.Slides pour .NET. Améliorez facilement l'aspect visuel de vos diapositives."
---

## **Obtenir la largeur et la hauteur de la zone de tracé du graphique**
Aspose.Slides for .NET fournit une API simple pour .

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accédez à la première diapositive.
3. Ajoutez un graphique avec les données par défaut.
4. Appelez la méthode IChart.ValidateChartLayout() avant pour obtenir les valeurs réelles.
5. Obtient la position X réelle (gauche) de l'element du graphique relative au coin superieur gauche du graphique.
6. Obtient le haut réel de l'element du graphique relatif au coin superieur gauche du graphique.
7. Obtient la largeur réelle de l'element du graphique.
8. Obtient la hauteur réelle de l'element du graphique.
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


## **Définir le mode de disposition de la zone de tracé du graphique**
Aspose.Slides for .NET fournit une API simple pour definir le mode de disposition de la zone de tracé du graphique. La propriete **LayoutTargetType** a ete ajoutee aux classes **ChartPlotArea** et **IChartPlotArea**. Si la disposition de la zone de tracé est définie manuellement, cette propriete indique s'il faut disposer la zone de tracé par son interieur (sans inclure les axes et les etiquettes d'axe) ou par son exterieur (en incluant les axes et les etiquettes d'axe). Deux valeurs possibles sont définies dans l'enumeration **LayoutTargetType**.

- **LayoutTargetType.Inner** - indique que la taille de la zone de tracé determine la taille de la zone de tracé, sans inclure les marques de graduation et les etiquettes d'axe.
- **LayoutTargetType.Outer** - indique que la taille de la zone de tracé determine la taille de la zone de tracé, les marques de graduation et les etiquettes d'axe.

Un exemple de code est fourni ci-dessous.
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

En points; 1 pouce = 72 points. Ce sont les unités de coordonnees d'Aspose.Slides.

**En quoi la zone de tracé diffère-t-elle de la zone du graphique en termes de contenu ?**

La zone de tracé est la region de dessin des donnees (series, quadrillages, lignes de tendance, etc.); la zone du graphique comprend les elements environnants (titre, legende, etc.). Dans les graphiques 3D, la zone de tracé inclut également les parois/plancher et les axes.

**Comment les X, Y, Width et Height de la zone de tracé sont-ils interprétés lorsque la disposition est manuelle ?**

Ils sont des fractions (0-1) de la taille globale du graphique; dans ce mode, le positionnement automatique est desactive et les fractions que vous définissez sont utilisees.

**Pourquoi la position de la zone de tracé a-t-elle changé après l'ajout/le déplacement de la legende ?**

La legende se trouve dans la zone du graphique a l'exterieur de la zone de tracé mais influence la disposition et l'espace disponible, de sorte que la zone de tracé peut se deplacer lorsque le positionnement automatique est actif. (Ceci est le comportement standard des graphiques PowerPoint.)