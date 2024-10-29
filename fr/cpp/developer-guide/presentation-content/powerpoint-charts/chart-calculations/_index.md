---
title: Calculs de Diagrammes
type: docs
weight: 50
url: /fr/cpp/chart-calculations/
---

## **Calculer les Valeurs Réelles des Éléments du Diagramme**
Aspose.Slides pour C++ fournit une API simple pour obtenir ces propriétés. Cela vous aidera à calculer les valeurs réelles des éléments du diagramme. Les valeurs réelles incluent la position des éléments qui mettent en œuvre l'interface IActualLayout (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) et les valeurs d'axes réelles (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()).

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Enregistrement de la présentation
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```


## **Calculer la Position Réelle des Éléments Parent du Diagramme**
Aspose.Slides pour C++ fournit une API simple pour obtenir ces propriétés. Les méthodes de IActualLayout fournissent des informations sur la position réelle de l'élément parent du diagramme. Il est nécessaire d'appeler la méthode IChart::ValidateChartLayout() au préalable pour remplir les propriétés avec des valeurs réelles.

``` cpp
// Création d'une présentation vide
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **Masquer des Informations du Diagramme**
Ce sujet vous aide à comprendre comment masquer des informations du diagramme. En utilisant Aspose.Slides pour C++, vous pouvez masquer **Titre, Axe Vertical, Axe Horizontal** et **Lignes de Grille** du diagramme. L'exemple de code ci-dessous montre comment utiliser ces propriétés.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Définir la Plage de Données pour le Diagramme**
Aspose.Slides pour C++ a fourni l'API la plus simple pour définir la plage de données pour le diagramme de la manière la plus simple. Pour définir la plage de données pour le diagramme :

- Ouvrez une instance de la classe Presentation contenant le diagramme.
- Obtenez la référence d'une diapositive en utilisant son index.
- Parcourez toutes les formes pour trouver le diagramme désiré.
- Accédez aux données du diagramme et définissez la plage.
- Enregistrez la présentation modifiée en tant que fichier PPTX.

Les exemples de code suivants montrent comment mettre à jour un diagramme.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}