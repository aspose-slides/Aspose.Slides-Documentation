---
title: Personnaliser les axes des graphiques dans les présentations en C++
linktitle: Axe du graphique
type: docs
url: /fr/cpp/chart-axis/
keywords:
- axe du graphique
- axe vertical
- axe horizontal
- personnaliser l'axe
- manipuler l'axe
- gérer l'axe
- propriétés de l'axe
- valeur maximale
- valeur minimale
- ligne d'axe
- format de date
- titre de l'axe
- position de l'axe
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Découvrez comment utiliser Aspose.Slides pour C++ afin de personnaliser les axes de graphique dans les présentations PowerPoint pour les rapports et les visualisations."
---

## **Obtenir les valeurs maximales sur l'axe vertical**
Aspose.Slides for C++ vous permet d'obtenir les valeurs minimale et maximale sur un axe vertical. Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Accédez à la première diapositive.
3. Ajoutez un graphique avec les données par défaut.
4. Obtenez la valeur maximale réelle sur l'axe.
5. Obtenez la valeur minimale réelle sur l'axe.
6. Obtenez l'unité principale réelle de l'axe.
7. Obtenez l'unité secondaire réelle de l'axe.
8. Obtenez l'échelle de l'unité principale réelle de l'axe.
9. Obtenez l'échelle de l'unité secondaire réelle de l'axe.

Ce code d'exemple — une implémentation des étapes ci‑dessus — montre comment obtenir les valeurs requises en C++ :
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// Enregistre la présentation
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```


## **Échanger les données entre les axes**
Aspose.Slides vous permet d'échanger rapidement les données entre les axes — les données représentées sur l'axe vertical (axe y) sont déplacées vers l'axe horizontal (axe x) et vice‑versa. 

Ce code C++ montre comment effectuer l'échange de données entre les axes d'un graphique :
``` cpp
// Crée une présentation vide
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Bascule les lignes et colonnes
chart->get_ChartData()->SwitchRowColumn();

// Enregistre la présentation
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```


## **Désactiver l'axe vertical pour les graphiques en ligne**

Ce code C++ montre comment masquer l'axe vertical d'un graphique en ligne :
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```


## **Désactiver l'axe horizontal pour les graphiques en ligne**

Ce code montre comment masquer l'axe horizontal d'un graphique en ligne :
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```


## **Modifier un axe de catégorie**

En utilisant la méthode **set_CategoryAxisType()**, vous pouvez spécifier le type d'axe de catégorie souhaité (**date** ou **text**). Ce code C++ démontre l'opération :
``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```


## **Définir le format de date pour les valeurs d'axe de catégorie**
Aspose.Slides for C++ vous permet de définir le format de date pour une valeur d'axe de catégorie. L’opération est démontrée dans ce code C++ :
``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```


## **Définir l'angle de rotation du titre d'axe**
Aspose.Slides for C++ vous permet de définir l'angle de rotation du titre d'un axe de graphique. Ce code C++ démontre l'opération :
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```


## **Définir la position de l'axe sur un axe de catégorie ou de valeur**
Aspose.Slides for C++ vous permet de définir la position de l'axe dans un axe de catégorie ou de valeur. Ce code C++ montre comment réaliser la tâche :
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```


## **Activer l'étiquette d'unité d'affichage sur l'axe de valeur d'un graphique**
Aspose.Slides for C++ vous permet de configurer un graphique pour afficher une étiquette d'unité sur son axe de valeur. Ce code C++ démontre l'opération :
``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Comment définir la valeur à laquelle un axe croise l'autre (croisement d'axe) ?**

Les axes offrent un [paramètre de croisement](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) : vous pouvez choisir de croiser à zéro, au maximum de la catégorie/valeur, ou à une valeur numérique spécifique. Ceci est utile pour déplacer l'axe X vers le haut ou le bas ou pour mettre en avant une ligne de base.

**Comment positionner les étiquettes de graduation par rapport à l'axe (à côté, à l'extérieur, à l'intérieur) ?**

Définissez la [position de l'étiquette](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) sur "cross", "outside" ou "inside". Cela affecte la lisibilité et aide à économiser de l'espace, en particulier sur les petits graphiques.