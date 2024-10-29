---
title: Zone de Tracé de Graphique
type: docs
url: /fr/cpp/chart-plot-area/
---

## **Obtenir Largeur, Hauteur de la Zone de Tracé de Graphique**
Aspose.Slides pour C++ fournit une API simple pour. 

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) classe.
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Appelez la méthode IChart::ValidateChartLayout() avant d'obtenir les valeurs actuelles.
1. Obtient la position X actuelle (à gauche) de l'élément graphique par rapport au coin supérieur gauche du graphique.
1. Obtient le haut actuel de l'élément graphique par rapport au coin supérieur gauche du graphique.
1. Obtient la largeur actuelle de l'élément graphique.
1. Obtient la hauteur actuelle de l'élément graphique.

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


## **Définir le Mode de Mise en Page de la Zone de Tracé de Graphique**
Aspose.Slides pour C++ fournit une API simple pour définir le mode de mise en page de la zone de tracé du graphique. La propriété **LayoutTargetType** a été ajoutée aux classes **ChartPlotArea** et **IChartPlotArea**. Si la mise en page de la zone de tracé est définie manuellement, cette propriété spécifie si la zone de tracé doit être agencée par son intérieur (sans inclure les marques d'axe et les étiquettes d'axe) ou par l'extérieur (incluant les marques d'axe et les étiquettes d'axe). Il y a deux valeurs possibles qui sont définies dans l'énumération **LayoutTargetType**.

- **LayoutTargetType.Inner** - spécifie que la taille de la zone de tracé doit déterminer la taille de la zone de tracé, sans inclure les marques de graduation et les étiquettes d'axe.
- **LayoutTargetType.Outer** - spécifie que la taille de la zone de tracé doit déterminer la taille de la zone de tracé, les marques de graduation et les étiquettes d'axe.

Le code d'exemple est donné ci-dessous.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}