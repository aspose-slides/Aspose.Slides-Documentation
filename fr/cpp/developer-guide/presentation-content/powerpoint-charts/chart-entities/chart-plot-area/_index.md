---
title: Personnaliser les zones de tracé des graphiques de présentation en C++
linktitle: Zone de tracé
type: docs
url: /fr/cpp/chart-plot-area/
keywords:
- graphique
- zone de tracé
- largeur de la zone de tracé
- hauteur de la zone de tracé
- taille de la zone de tracé
- mode de mise en page
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Découvrez comment personnaliser les zones de tracé des graphiques dans les présentations PowerPoint avec Aspose.Slides pour C++. Améliorez facilement le rendu de vos diapositives."
---
## **Aperçu**

Cet article montre comment travailler avec la zone de tracé d’un graphique dans Aspose.Slides. Il explique comment obtenir la position et la taille réelles de la zone de tracé en validant la mise en page du graphique puis en lisant ses valeurs X, Y, largeur et hauteur.

Il montre également comment configurer le mode de mise en page de la zone de tracé lorsque la mise en page est définie manuellement, en utilisant `LayoutTargetType` pour définir si la zone de tracé est calculée à partir de sa région interne ou de sa région externe avec les axes et les étiquettes d’axes.

## **Obtenir la largeur et la hauteur d’une zone de tracé de graphique**
Aspose.Slides for C++ fournit une API simple pour . 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Appelez la méthode IChart::ValidateChartLayout() avant de récupérer les valeurs réelles.
1. Obtient la position X réelle (gauche) de l’élément du graphique par rapport au coin supérieur gauche du graphique.
1. Obtient le haut réel de l’élément du graphique par rapport au coin supérieur gauche du graphique.
1. Obtient la largeur réelle de l’élément du graphique.
1. Obtient la hauteur réelle de l’élément du graphique.

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
Aspose.Slides for C++ fournit une API simple pour définir le mode de mise en page de la zone de tracé du graphique. La propriété **LayoutTargetType** a été ajoutée aux classes **ChartPlotArea** et **IChartPlotArea**. Si la mise en page de la zone de tracé est définie manuellement, cette propriété précise si la zone de tracé doit être mise en page par son intérieur (sans les axes et les étiquettes d’axes) ou par son extérieur (y compris les axes et les étiquettes d’axes). Deux valeurs possibles sont définies dans l’énumération **LayoutTargetType**.

- **LayoutTargetType.Inner** - spécifie que la taille de la zone de tracé détermine la taille de la zone de tracé, sans inclure les marques de graduation et les étiquettes d’axes.
- **LayoutTargetType.Outer** - spécifie que la taille de la zone de tracé détermine la taille de la zone de tracé, les marques de graduation et les étiquettes d’axes.

Un exemple de code est fourni ci‑dessous.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **FAQ**

**Dans quelles unités sont renvoyés ActualX, ActualY, ActualWidth et ActualHeight ?**  
En points ; 1 pouce = 72 points. Ce sont les unités de coordonnées d’Aspose.Slides.

**En quoi la zone de tracé diffère‑t‑elle de la zone du graphique en termes de contenu ?**  
La zone de tracé est la région de dessin des données (séries, lignes de grille, tendances, etc.) ; la zone du graphique comprend les éléments environnants (titre, légende, etc.). Dans les graphiques 3D, la zone de tracé inclut également les murs/plancher et les axes.

**Comment les X, Y, Largeur et Hauteur de la zone de tracé sont‑ils interprétés lorsque la mise en page est manuelle ?**  
Ils sont exprimés en fractions (0–1) de la taille globale du graphique ; dans ce mode, le positionnement automatique est désactivé et les fractions que vous définissez sont utilisées.

**Pourquoi la position de la zone de tracé a‑t‑elle changé après l’ajout ou le déplacement de la légende ?**  
La légende se situe dans la zone du graphique à l’extérieur de la zone de tracé, mais elle influence la mise en page et l’espace disponible, de sorte que la zone de tracé peut se déplacer lorsque le positionnement automatique est actif. (C’est le comportement standard des graphiques PowerPoint.)