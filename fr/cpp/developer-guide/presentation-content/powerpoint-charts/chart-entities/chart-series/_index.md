---
title: Séries de Graphique
type: docs
url: /fr/cpp/chart-series/
---

Une série est une rangée ou une colonne de chiffres tracés dans un graphique.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Définir le Chevauchement des Séries de Graphique**

Avec la méthode [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb), vous pouvez spécifier combien de barres et de colonnes devraient se chevaucher dans un graphique 2D (plage : -100 à 100). Cette propriété s'applique à toutes les séries du groupe de séries parent : il s'agit d'une projection de la propriété de groupe appropriée.

Utilisez la méthode `get_ParentSeriesGroup()::set_Overlap()` pour définir votre valeur préférée pour `Overlap`. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Ajoutez un graphique en colonnes regroupées sur une diapositive.
1. Accédez à la première série de graphique.
1. Accédez au `ParentSeriesGroup` de la série de graphique et définissez votre valeur de chevauchement préférée pour la série. 
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code C++ vous montre comment définir le chevauchement pour une série de graphique :

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

// Écrit le fichier de présentation sur le disque
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **Changer la Couleur de la Série**
Aspose.Slides pour C++ vous permet de changer la couleur d'une série de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Ajoutez un graphique sur la diapositive.
1. Accédez à la série dont vous souhaitez changer la couleur. 
1. Définissez votre type de remplissage préféré et la couleur de remplissage.
1. Enregistrez la présentation modifiée.

Ce code C++ vous montre comment changer la couleur d'une série :

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

## **Changer la Couleur de la Catégorie de la Série**
Aspose.Slides pour C++ vous permet de changer la couleur d'une catégorie de série de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Ajoutez un graphique sur la diapositive.
1. Accédez à la catégorie de série dont vous souhaitez changer la couleur.
1. Définissez votre type de remplissage préféré et la couleur de remplissage.
1. Enregistrez la présentation modifiée.

Ce code en C++ vous montre comment changer la couleur d'une catégorie de série :

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Changer le Nom de la Série** 

Par défaut, les noms de légende pour un graphique sont les contenus des cellules au-dessus de chaque colonne ou ligne de données. 

Dans notre exemple (image d'échantillon), 

* les colonnes sont *Série 1, Série 2,* et *Série 3*;
* les lignes sont *Catégorie 1, Catégorie 2, Catégorie 3,* et *Catégorie 4.* 

Aspose.Slides pour C++ vous permet de mettre à jour ou de changer le nom d'une série dans ses données de graphique et sa légende. 

Ce code C++ vous montre comment changer le nom d'une série dans ses données de graphique `ChartDataWorkbook` :

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"Nouveau nom"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

Ce code C++ vous montre comment changer un nom de série dans sa légende via `Series` :

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"Nouveau nom"));
```

## **Définir la Couleur de Remplissage des Séries de Graphique**

Aspose.Slides pour C++ vous permet de définir la couleur de remplissage automatique pour les séries de graphique à l'intérieur d'une zone de tracé de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenez la référence d'une diapositive par son index.
1. Ajoutez un graphique avec des données par défaut basé sur votre type préféré (dans l'exemple ci-dessous, nous avons utilisé `ChartType::ClusteredColumn`).
1. Accédez aux séries de graphique et définissez la couleur de remplissage sur automatique.
1. Enregistrez la présentation dans un fichier PPTX.

Ce code C++ vous montre comment définir la couleur de remplissage automatique pour une série de graphique :

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Crée un graphique en colonnes regroupées
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Définit le format de remplissage de la série sur automatique
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Écrit le fichier de présentation sur le disque
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **Définir les Couleurs de Remplissage Inversées des Séries de Graphique**
Aspose.Slides vous permet de définir la couleur de remplissage inversée pour les séries de graphique à l'intérieur d'une zone de tracé de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenez la référence d'une diapositive par son index.
1. Ajoutez un graphique avec des données par défaut basé sur votre type préféré (dans l'exemple ci-dessous, nous avons utilisé `ChartType::ClusteredColumn`).
1. Accédez aux séries de graphique et définissez la couleur de remplissage sur inversée.
1. Enregistrez la présentation dans un fichier PPTX.

Ce code C++ illustre l'opération :

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Ajoute de nouvelles séries et catégories
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Série 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Catégorie 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Catégorie 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Catégorie 3")));

// Récupère la première série de graphique et remplit ses données
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

## **Définir la Série à Inverser Lorsqu'elle est Négative**
Aspose.Slides vous permet de définir des inversions via les méthodes `IChartDataPoint::set_InvertIfNegative()` et `ChartDataPoint.set_InvertIfNegative()`. Lorsqu'une inversion est définie à l'aide des méthodes, le point de données inverse ses couleurs lorsqu'il obtient une valeur négative. 

Ce code C++ illustre l'opération :

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

## **Effacer les Données de Points de Données Spécifiques**
Aspose.Slides pour C++ vous permet d'effacer les données `DataPoints` pour une série de graphique spécifique de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d'une diapositive par son index.
3. Obtenez la référence d'un graphique par son index.
4. Itérez à travers tous les `DataPoints` du graphique et définissez `XValue` et `YValue` à null.
5. Effacez tous les `DataPoints` pour une série de graphique spécifique.
6. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code C++ illustre l'opération :

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

## **Définir la Largeur de Gap des Séries**
Aspose.Slides pour C++ vous permet de définir une largeur de gap pour une série via la méthode **`set_GapWidth()`** de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Accédez à n'importe quelle série de graphique.
1. Définissez la propriété `GapWidth`.
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code en C++ vous montre comment définir une largeur de gap pour une série :

```cpp
// Crée une présentation vide 
auto presentation = System::MakeObject<Presentation>();

// Accède à la première diapositive de la présentation
auto slide = presentation->get_Slides()->idx_get(0);

// Ajoute un graphique avec des données par défaut
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Définit l'index de la feuille de données du graphique
int32_t worksheetIndex = 0;

// Récupère la feuille de travail de données du graphique
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Ajoute des séries
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Série 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Série 2")), chart->get_Type());

// Ajoute des Catégories
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Catégorie 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Catégorie 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Catégorie 3")));

// Récupère la deuxième série de graphique
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