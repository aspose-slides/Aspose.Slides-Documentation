---
title: Personnaliser les zones de tracé des graphiques de présentation en C++
linktitle: Zone de tracé
type: docs
url: /fr/cpp/chart-plot-area/
keywords:
- graphique
- zone de tracé
- largeur de zone de tracé
- hauteur de zone de tracé
- taille de zone de tracé
- mode de mise en page
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Découvrez comment personnaliser les zones de tracé des graphiques dans les présentations PowerPoint avec Aspose.Slides pour C++. Améliorez l'aspect visuel de vos diapositives en toute simplicité."
---

## **Obtenir la largeur et la hauteur d’une zone de tracé de graphique**
Aspose.Slides for C++ fournit une API simple pour .  

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Accéder à la première diapositive.
3. Ajouter un graphique avec les données par défaut.
4. Appeler la méthode IChart::ValidateChartLayout() avant pour obtenir les valeurs réelles.
5. Obtient la position X réelle (gauche) de l'élément du graphique par rapport au coin supérieur gauche du graphique.
6. Obtient le haut réel de l'élément du graphique par rapport au coin supérieur gauche du graphique.
7. Obtient la largeur réelle de l'élément du graphique.
8. Obtient la hauteur réelle de l'élément du graphique.
``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Enregistrer la présentation avec le graphique
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```


## **Définir le mode de mise en page d’une zone de tracé de graphique**
Aspose.Slides for C++ fournit une API simple pour définir le mode de mise en page de la zone de tracé du graphique. La propriété **LayoutTargetType** a été ajoutée aux classes **ChartPlotArea** et **IChartPlotArea**. Si la mise en page de la zone de tracé est définie manuellement, cette propriété indique s’il faut mettre en page la zone de tracé à l'intérieur (sans inclure les axes et les libellés d'axes) ou à l'extérieur (en incluant les axes et les libellés d'axes). Deux valeurs possibles sont définies dans l’énumération **LayoutTargetType**.

- **LayoutTargetType.Inner** - indique que la taille de la zone de tracé détermine la taille de la zone de tracé, sans inclure les marques de repère et les libellés d'axes.
- **LayoutTargetType.Outer** - indique que la taille de la zone de tracé détermine la taille de la zone de tracé, les marques de repère et les libellés d'axes.

Un exemple de code est fourni ci-dessous.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **FAQ**

**Dans quelles unités sont renvoyés ActualX, ActualY, ActualWidth et ActualHeight ?**  
En points ; 1 pouce = 72 points. Ce sont les unités de coordonnées d'Aspose.Slides.

**En quoi la zone de tracé diffère‑t‑elle de la zone de graphique en termes de contenu ?**  
La zone de tracé est la région où sont dessinées les données (séries, lignes de grille, lignes de tendance, etc.) ; la zone de graphique comprend les éléments environnants (titre, légende, etc.). Dans les graphiques 3D, la zone de tracé comprend également les parois/plancher et les axes.

**Comment les X, Y, largeur et hauteur de la zone de tracé sont‑ils interprétés lorsque la mise en page est manuelle ?**  
Il s’agit de fractions (0–1) de la taille globale du graphique ; dans ce mode, le positionnement automatique est désactivé et les fractions que vous définissez sont utilisées.

**Pourquoi la position de la zone de tracé a‑t‑elle changé après avoir ajouté ou déplacé la légende ?**  
La légende se trouve dans la zone de graphique à l'extérieur de la zone de tracé mais influence la mise en page et l'espace disponible, de sorte que la zone de tracé peut se déplacer lorsque le positionnement automatique est actif. (C’est le comportement standard des graphiques PowerPoint.)