---
title: Gérer les séries de données de graphique dans les présentations en C++
linktitle: Séries de données
type: docs
url: /fr/cpp/chart-series/
keywords:
- séries de graphiques
- chevauchement des séries
- couleur de la série
- couleur de la catégorie
- nom de la série
- point de données
- écart de la série
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à gérer les séries de graphiques en C++ pour PowerPoint (PPT/PPTX) avec des exemples de code pratiques et les meilleures pratiques afin d'améliorer vos présentations de données."
---
## **Vue d'ensemble**

Cet article décrit le rôle de [ChartSeries](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts.chartseries/) dans Aspose.Slides, en se concentrant sur la manière dont les données sont structurées et visualisées dans les présentations. Ces objets fournissent les éléments fondamentaux qui définissent des ensembles individuels de points de données, de catégories et de paramètres d'apparence dans un graphique. En travaillant avec [ChartSeries](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts.chartseries/), les développeurs peuvent intégrer de manière fluide les sources de données sous‑jacent​es et garder le contrôle total sur la façon dont l'information est affichée, ce qui donne des présentations dynamiques et guidées par les données qui transmettent clairement les informations et l'analyse.

Une série est une ligne ou une colonne de nombres tracée dans un graphique.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Définir le chevauchement de la série de données**

Avec la méthode [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb), vous pouvez spécifier le degré de chevauchement des barres et des colonnes sur un graphique 2D (plage : -100 à 100). Cette propriété s'applique à toutes les séries du groupe de séries parent : il s'agit d'une projection de la propriété de groupe appropriée.

Utilisez la méthode `get_ParentSeriesGroup()::set_Overlap()` pour définir la valeur souhaitée pour `Overlap`.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation).
1. Ajoutez un graphique à colonnes groupées sur une diapositive.
1. Accédez à la première série du graphique.
1. Accédez au `ParentSeriesGroup` de la série du graphique et définissez la valeur de chevauchement souhaitée pour la série.
1. Enregistrez la présentation modifiée dans un fichier PPTX.

Ce code C++ montre comment définir le chevauchement d’une série de graphique :

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Ajoute un graphique
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Définit le chevauchement de la série
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Enregistre le fichier de présentation sur le disque
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **Modifier la couleur de la série de données**

Aspose.Slides for C++ vous permet de modifier la couleur d’une série de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation).
1. Ajoutez un graphique sur la diapositive.
1. Accédez à la série dont vous souhaitez modifier la couleur.
1. Définissez le type de remplissage et la couleur de remplissage souhaités.
1. Enregistrez la présentation modifiée.

Ce code C++ montre comment modifier la couleur d’une série :

```cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Pie, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(1);

point->set_Explosion(30);
point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Modifier la couleur d’une catégorie de série de données**

Aspose.Slides for C++ vous permet de modifier la couleur d’une catégorie de série de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation).
1. Ajoutez un graphique sur la diapositive.
1. Accédez à la catégorie de série dont vous souhaitez modifier la couleur.
1. Définissez le type de remplissage et la couleur de remplissage souhaités.
1. Enregistrez la présentation modifiée.

Ce code C++ montre comment modifier la couleur d’une catégorie de série :

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Modifier le nom de la série de données**

Par défaut, les noms de légende d’un graphique proviennent du contenu des cellules au-dessus de chaque colonne ou ligne de données.

Dans notre exemple (image d’exemple),

* les colonnes sont *Series 1, Series 2,* et *Series 3* ;
* les lignes sont *Category 1, Category 2, Category 3,* et *Category 4.* 

Aspose.Slides for C++ vous permet de mettre à jour ou de modifier le nom d’une série dans les données du graphique et la légende.

Ce code C++ montre comment modifier le nom d’une série dans les données du graphique `ChartDataWorkbook` :

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

Ce code C++ montre comment modifier le nom d’une série dans sa légende via `Series` :

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **Définir la couleur de remplissage de la série de données**

Aspose.Slides for C++ vous permet de définir la couleur de remplissage automatique pour les séries de graphique dans une zone de tracé de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation).
1. Obtenez la référence d’une diapositive par son index.
1. Ajoutez un graphique avec des données par défaut selon le type souhaité (dans l’exemple ci‑dessous, nous avons utilisé `ChartType::ClusteredColumn`).
1. Accédez à la série du graphique et définissez la couleur de remplissage sur Automatic.
1. Enregistrez la présentation dans un fichier PPTX.

Ce code C++ montre comment définir la couleur de remplissage automatique pour une série de graphique :

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Crée un graphique à colonnes groupées
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Définit le format de remplissage des séries sur automatique
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Enregistre le fichier de présentation sur le disque
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **Définir les couleurs de remplissage inversées d’une série de données**

Aspose.Slides vous permet de définir la couleur de remplissage inversée pour les séries de graphique dans une zone de tracé de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation).
1. Obtenez la référence d’une diapositive par son index.
1. Ajoutez un graphique avec des données par défaut selon le type souhaité (dans l’exemple ci‑dessous, nous avons utilisé `ChartType::ClusteredColumn`).
1. Accédez à la série du graphique et définissez la couleur de remplissage sur invert.
1. Enregistrez la présentation dans un fichier PPTX.

Ce code C++ illustre l’opération :

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Adds new series and categories
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Takes the first chart series and populates its series data.
auto series = chartData->get_Series()->idx_get(0);
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(-20)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-30)));
Color seriesColor = series->GetAutomaticSeriesColor();
series->set_InvertIfNegative(true);
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);
series->get_InvertedSolidFillColor()->set_Color(inverColor);
pres->Save(u"SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
```

## **Définir la couleur de remplissage inversée pour une série de graphique**

Aspose.Slides vous permet de définir l’inversion via les méthodes `IChartDataPoint::set_InvertIfNegative()` et `ChartDataPoint.set_InvertIfNegative()`. Lorsque l’inversion est appliquée à l’aide de ces méthodes, le point de données inverse ses couleurs lorsqu’il reçoit une valeur négative.

Ce code C++ illustre l’opération :

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
chart->get_ChartData()->get_Series()->Clear();

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
series->Add(workBook->GetCell(0, u"B1"), chart->get_Type());
auto dataPoints = series->idx_get(0)->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B2", ObjectExt::Box<int32_t>(-5)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B3", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B4", ObjectExt::Box<int32_t>(-2)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B5", ObjectExt::Box<int32_t>(1)));

series->idx_get(0)->set_InvertIfNegative(false);

series->idx_get(0)->get_DataPoints()->idx_get(2)->set_InvertIfNegative(true);

pres->Save(u"out.pptx", SaveFormat::Pptx);
```

## **Effacer les valeurs de points de données spécifiques**

Aspose.Slides for C++ vous permet d’effacer les données `DataPoints` d’une série de graphique spécifique de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d’une diapositive via son index.
3. Obtenez la référence d’un graphique via son index.
4. Parcourez tous les `DataPoints` du graphique et définissez `XValue` et `YValue` à null.
5. Effacez tous les `DataPoints` pour la série de graphique spécifique.
6. Enregistrez la présentation modifiée dans un fichier PPTX.

Ce code C++ illustre l’opération :

```cpp
auto pres = System::MakeObject<Presentation>(u"TestChart.pptx");
auto sl = pres->get_Slides()->idx_get(0);

auto chart = System::ExplicitCast<IChart>(sl->get_Shapes()->idx_get(0));
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

for (const auto& dataPoint : dataPoints)
{
    dataPoint->get_XValue()->get_AsCell()->set_Value(nullptr);
    dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);
}

dataPoints->Clear();

pres->Save(u"ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
```

## **Définir la largeur de l’écart de la série de données**

Aspose.Slides for C++ vous permet de définir la largeur de l’écart d’une série via la méthode **`set_GapWidth()`** de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Accédez à n’importe quelle série du graphique.
1. Définissez la propriété `GapWidth`.
1. Enregistrez la présentation modifiée dans un fichier PPTX.

Ce code C++ montre comment définir la largeur de l’écart d’une série :

```cpp
// Crée une présentation vide 
auto presentation = System::MakeObject<Presentation>();

// Accède à la première diapositive de la présentation
auto slide = presentation->get_Slides()->idx_get(0);

// Ajoute un graphique avec les données par défaut
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Définit l'index de la feuille de données du graphique
int32_t worksheetIndex = 0;

// Obtient la feuille de calcul des données du graphique
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Ajoute des séries
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Ajoute des catégories
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Récupère la deuxième série du graphique
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// Remplit les données de la série
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// Définit la valeur de GapWidth
series->get_ParentSeriesGroup()->set_GapWidth(50);

// Enregistre la présentation sur le disque
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Existe‑t‑il une limite au nombre de séries qu’un graphique unique peut contenir ?**

Aspose.Slides n’impose aucune limite fixe au nombre de séries que vous ajoutez. La contrainte pratique est déterminée par la lisibilité du graphique et par la mémoire disponible pour votre application.

**Que faire si les colonnes d’un groupe sont trop proches ou trop éloignées ?**

Ajustez le paramètre de largeur d’écart pour cette série (ou le groupe de séries parent). Augmenter la valeur élargit l’espace entre les colonnes, tandis que la diminuer les rapproche.