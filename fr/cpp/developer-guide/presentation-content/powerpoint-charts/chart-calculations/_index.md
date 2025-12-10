---
title: Optimiser les calculs de graphiques pour les présentations en C++
linktitle: Calculs de graphiques
type: docs
weight: 50
url: /fr/cpp/chart-calculations/
keywords:
- calculs de graphiques
- éléments de graphique
- position de l'élément
- position réelle
- élément enfant
- élément parent
- valeurs de graphique
- valeur réelle
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Comprendre les calculs de graphiques, les mises à jour de données et le contrôle de la précision dans Aspose.Slides pour C++ pour PPT et PPTX, avec des exemples de code C++ pratiques."
---

## **Calculer les valeurs réelles des éléments du diagramme**
Aspose.Slides for C++ fournit une API simple pour obtenir ces propriétés. Cela vous aidera à calculer les valeurs réelles des éléments du diagramme. Les valeurs réelles comprennent la position des éléments qui implémentent l'interface IActualLayout (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) et les valeurs réelles des axes (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()).
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



## **Calculer la position réelle des éléments parents du diagramme**
Aspose.Slides for C++ fournit une API simple pour obtenir ces propriétés. Les méthodes de IActualLayout fournissent des informations sur la position réelle de l'élément parent du diagramme. Il est nécessaire d'appeler la méthode IChart::ValidateChartLayout() au préalable pour remplir les propriétés avec les valeurs réelles.
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


## **Masquer les éléments du diagramme**
Ce sujet vous aide à comprendre comment masquer des informations dans le diagramme. Avec Aspose.Slides for C++ vous pouvez masquer le **Titre, l'Axe vertical, l'Axe horizontal** et les **Lignes de quadrillage** du diagramme. L'exemple de code ci-dessous montre comment utiliser ces propriétés.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Définir une plage de données pour un diagramme**
Aspose.Slides for C++ a fourni l'API la plus simple pour définir la plage de données d'un diagramme de la manière la plus facile. Pour définir la plage de données d'un diagramme :

- Ouvrez une instance de la classe Presentation contenant le diagramme.
- Obtenez la référence d'une diapositive en utilisant son Index.
- Parcourez toutes les formes pour trouver le diagramme souhaité.
- Accédez aux données du diagramme et définissez la plage.
- Enregistrez la présentation modifiée en tant que fichier PPTX.

Les exemples de code qui suivent montrent comment mettre à jour un diagramme.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **FAQ**

**Les classeurs Excel externes peuvent-ils être utilisés comme source de données, et quel impact cela a-t-il sur le recalcul ?**

Oui. Un diagramme peut référencer un classeur externe : lorsque vous vous connectez ou actualisez la source externe, les formules et les valeurs sont récupérées à partir de ce classeur, et le diagramme reflète les mises à jour lors des opérations d'ouverture ou de modification. L'API vous permet de [spécifier le classeur externe](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) le chemin et de gérer les données liées.

**Puis-je calculer et afficher des lignes de tendance sans implémenter moi‑même la régression ?**

Oui. Les [lignes de tendance](/slides/fr/cpp/trend-line/) (linéaires, exponentielles et autres) sont ajoutées et mises à jour par Aspose.Slides ; leurs paramètres sont recalculés automatiquement à partir des données de la série, vous n'avez donc pas besoin d'implémenter vos propres calculs.

**Si une présentation contient plusieurs diagrammes avec des liens externes, puis‑je contrôler quel classeur chaque diagramme utilise pour les valeurs calculées ?**

Oui. Chaque diagramme peut pointer vers son propre [classeur externe](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setexternalworkbook/), ou vous pouvez créer/remplacer un classeur externe par diagramme, indépendamment des autres.