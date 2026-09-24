---
title: Gérer les séries de données de graphique dans les présentations en C++
linktitle: Séries de données
type: docs
url: /fr/cpp/chart-series/
keywords:
- séries de graphique
- chevauchement des séries
- couleur des séries
- couleur des catégories
- nom de la série
- point de données
- écart des séries
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à gérer les séries de graphiques, les points de données, les cellules du classeur, le formatage, le chevauchement, la largeur d’écart et les valeurs négatives dans les présentations avec C++."
---
## **Aperçu**

Un graphique stocke ses données tracées dans un classeur de données de graphique. Un [IChartSeries](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartseries/) représente un ensemble de valeurs associées, et chaque [IChartDataPoint](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatapoint/) de la série fait référence à une ou plusieurs cellules du classeur. Les objets [IChartCategory](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartcategory/) fournissent les libellés ou valeurs de regroupement partagés par les séries. Le nom de la série, les catégories et les valeurs des points sont donc reliés aux objets [IChartDataCell](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatacell/) plutôt que stockés uniquement sous forme de texte affiché.

Pour un graphique de catégorie typique, le classeur par défaut utilise la ligne 0 pour les noms de séries, la colonne 0 pour les noms de catégories, et les cellules restantes pour les valeurs des séries. Les index de feuille, de ligne et de colonne transmis à [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) sont basés sur zéro. Cette disposition est utile lorsque vous créez un graphique avec des données par défaut, mais ne supposez pas que chaque graphique existant l’utilise. Pour une présentation chargée, examinez les cellules référencées par les séries, les catégories et les points de données avant de modifier les valeurs du classeur.

Les paramètres du graphique ont trois portées différentes :

- Paramètres au niveau de la série, tels que [IChartSeries::get_Format](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartseries/get_format/), fournissent l’apparence par défaut de tous les points d’une série.
- Paramètres de point de données, tels que [IChartDataPoint::get_Format](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatapoint/get_format/), remplacent l’apparence de la série pour un point.
- Les paramètres de groupe s’appliquent aux séries compatibles qui appartiennent au même [IChartSeriesGroup](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartseriesgroup/). Accédez au groupe via [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) lorsque vous devez définir des options telles que le chevauchement ou la largeur de l’écart.

Lorsque aucun remplissage explicite de point ou de série n’est défini, le style et le thème du graphique déterminent l’apparence automatique. Lorsque les formats de série et de point sont tous deux présents, le format du point a la priorité pour ce point.

![série de graphique PowerPoint](chart-series-powerpoint.png)

## **Définir le chevauchement des séries de graphique**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartseries/get_overlap/) indique dans quelle mesure les barres ou colonnes se chevauchent dans un graphique 2D, de ‑100 à 100 pour cent. C’est une projection en lecture seule du paramètre du groupe de séries parent. Appelez [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) pour mettre à jour chaque série compatible de ce groupe. Cette option s’applique aux types de graphiques affichant des barres ou colonnes groupées ; elle n’affecte pas les groupes de séries non liés dans un graphique combiné.

L’exemple suivant définit le chevauchement pour le groupe qui contient la première série :

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int8_t overlapPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

// Le nouveau graphique contient des séries d'exemple, des catégories et des valeurs.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Le chevauchement des séries](series_overlap.png)

## **Modifier la couleur de remplissage de la série**

Utilisez [IChartSeries::get_Format](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartseries/get_format/) pour définir le remplissage par défaut d’une série entière. Si un point possède déjà un remplissage explicite, son paramètre [IChartDataPoint::get_Format](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatapoint/get_format/) remplace le remplissage de la série pour ce point.

L’exemple suivant applique un remplissage bleu uni à la première série :

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesColor = Color::get_Blue();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);

presentation->Save(u"series_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![La couleur de la série](series_color.png)

## **Modifier le nom de la série**

Le nom d’une série est stocké dans le classeur de données du graphique et est normalement affiché dans la légende. Dans le classeur par défaut créé pour un graphique à colonnes groupées, la cellule B1 est à la ligne 0, colonne 1 et contient le nom de la première série. Les constantes nommées dans l’exemple suivant rendent cette structure explicite :

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto seriesNameCell = workbook->GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Vous pouvez également mettre à jour la cellule déjà référencée par [IChartSeries::get_Name](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartseries/get_name/). Cette approche évite de supposer une ligne et une colonne particulières dans un graphique existant :

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCellCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesNameCells = series->get_Name()->get_AsCells();
auto seriesNameCell = seriesNameCells->idx_get(firstNameCellIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![Le nom de la série](series_name.png)

## **Obtenir la couleur de remplissage automatique de la série**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) renvoie la couleur calculée à partir de l’index de la série et du style du graphique. C’est la couleur utilisée lorsque le remplissage de la série n’a pas été explicitement défini. L’appel de la méthode lit la couleur calculée ; il ne définit pas un nouveau remplissage.

L’exemple suivant imprime la couleur automatique de chaque série par défaut :

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Presentation;
using System::Console;
using System::String;

const int firstSlideIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
const int seriesCount = seriesCollection->get_Count();
for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    auto series = seriesCollection->idx_get(seriesIndex);
    auto automaticColor = series->GetAutomaticSeriesColor();
    auto colorName = automaticColor.get_Name();
    auto outputLine = String::Format(u"Series {0}: {1}", seriesIndex, colorName);
    Console::WriteLine(outputLine);
}

presentation->Dispose();
```

Exemple de sortie pour le style de graphique par défaut :

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Les couleurs exactes dépendent du style et du thème du graphique.

## **Définir la couleur de remplissage inversé pour une série de graphique**

Pour les séries à barres, colonnes et bulles, [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) peut afficher les valeurs négatives avec un remplissage différent. Définissez le remplissage régulier de la série en solide, activez l’inversion et attribuez la couleur de valeur négative via [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Les nombres négatifs restent inchangés dans le classeur ; seule leur couleur d’affichage change.

L’exemple suivant remplace les données du graphique par défaut par une série. La ligne 0 de la feuille contient le nom de la série, la colonne 0 contient les noms de catégorie, et la colonne 1 contient les valeurs :

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;
const int categoryCount = 3;

const String categoryNames[] = {u"Category 1", u"Category 2", u"Category 3"};
const int seriesValues[] = {-20, 50, -30};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

auto seriesCollection = chartData->get_Series();
seriesCollection->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Series 1");
auto seriesNameCell = workbook->GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, seriesName);
auto chartType = chart->get_Type();
auto series = seriesCollection->Add(seriesNameCell, chartType);

for (int categoryIndex = 0; categoryIndex < categoryCount; categoryIndex++)
{
    const int dataRowIndex = firstDataRowIndex + categoryIndex;
    auto categoryName = categoryNames[categoryIndex];
    const int seriesValue = seriesValues[categoryIndex];

    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);

    auto boxedSeriesValue = ObjectExt::Box<int>(seriesValue);
    auto valueCell = workbook->GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, boxedSeriesValue);
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->set_InvertIfNegative(true);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);

presentation->Save(u"inverted_solid_fill_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![La couleur de remplissage solide inversée](inverted_solid_fill_color.png)

Vous pouvez activer l’inversion pour un point via [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). Dans l’exemple suivant, l’inversion est désactivée pour la série et activée uniquement pour le point sélectionné. Le point reçoit également une valeur négative afin que l’effet soit visible :

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);
series->set_InvertIfNegative(false);

auto dataPoint = series->get_DataPoint(targetDataPointIndex);
auto boxedNegativeValue = ObjectExt::Box<int>(negativeValue);
dataPoint->get_YValue()->get_AsCell()->set_Value(boxedNegativeValue);
dataPoint->set_InvertIfNegative(true);

presentation->Save(u"data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Effacer la valeur d’un point de données spécifique**

Pour rendre un point vide sans supprimer les autres points, définissez sa cellule de classeur sous‑jacente sur `nullptr`. Pour un graphique à colonnes, la valeur tracée est disponible via [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/). Le point de données reste à la même position de catégorie, mais le graphique traite sa valeur comme vide selon les paramètres de valeur vide du graphique.

L’exemple suivant efface uniquement le deuxième point de la première série :

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto dataPoint = series->get_DataPoint(targetDataPointIndex);
dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);

presentation->Save(u"clear_data_point_value.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Les graphiques de dispersion utilisent des cellules X et Y distinctes, et les graphiques à bulles utilisent également une cellule de taille. Effacez uniquement la cellule qui représente la valeur que vous souhaitez supprimer. N’appelez pas [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) lorsque vous voulez conserver les autres points, car cette méthode supprime tous les points de la collection.

## **Contrôler l’affichage des cellules vides**

Une cellule de classeur vide représente des données manquantes ; une cellule contenant `0` représente une valeur numérique connue. Appelez [IChartDataCell::set_Value](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatacell/set_value/) avec `nullptr` pour rendre une cellule vide. Un zéro numérique reste zéro quel que soit le paramètre de cellule vide.

Utilisez [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichart/set_displayblanksas/) pour choisir comment le graphique affiche les cellules vides. Ce paramètre s’applique à l’ensemble du graphique. Il modifie la façon dont les blancs sont tracés, sans remplir la cellule vide du classeur avec zéro ou une valeur interpolée.

L’exemple autonome suivant crée un graphique en ligne avec une série, efface la valeur du jour 3, et enregistre le même graphique avec chaque mode. Aucun fichier d’entrée n’est requis. Le [IChartDataWorkbook](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdataworkbook/) utilise la feuille 0, la colonne 0 pour les libellés de catégorie, et la colonne 1 pour les valeurs ; la ligne 0 contient le nom de la série. Les données finales sont `10, 20, empty, 30, 40` :

```cpp
#include <array>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DisplayBlanksAsType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using System::ObjectExt;
using System::String;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 40.0f, 40.0f, 640.0f, 400.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Measurements");
auto seriesNameCell = workbook->GetCell(0, 0, 1, seriesName);
auto series = chartData->get_Series()->Add(seriesNameCell, chart->get_Type());
auto values = std::array<int, 5>{10, 20, 25, 30, 40};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = String::Format(u"Day {0}", i + 1);
    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);
    auto boxedValue = ObjectExt::Box<int>(values[i]);
    auto valueCell = workbook->GetCell(0, i + 1, 1, boxedValue);
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// Laisser le jour 3 réellement vide, tout en conservant sa catégorie et son point de données.
workbook->GetCell(0, 3, 1)->set_Value(nullptr);

auto modes = std::array<DisplayBlanksAsType, 3>{DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span};
for (auto mode : modes)
{
    chart->set_DisplayBlanksAs(mode);
    auto outputPath = String::Format(u"empty_cells_{0}.pptx", mode);
    presentation->Save(outputPath, SaveFormat::Pptx);
}

presentation->Dispose();
```

Chaque fichier de sortie stocke le mode assigné avant l’enregistrement : `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` et `empty_cells_Span.pptx`. Pour enregistrer une seule version, attribuez le mode souhaité et enregistrez la présentation une fois au lieu d’itérer sur les modes.

La comparaison ci‑dessous montre les mêmes données dans les trois fichiers. Le jour 3 est vide dans le classeur dans chaque cas :

![Graphiques en ligne avec données identiques : Gap coupe la ligne au jour 3, Zero descend la ligne à zéro, et Span relie le jour 2 au jour 4.](display_blanks_as.png)

L’effet visible dépend du type de graphique. Un graphique en ligne rend les trois modes faciles à comparer. Les graphiques à barres et à colonnes n’ont pas de ligne à connecter à travers une catégorie manquante, ainsi `Span` ne peut pas produire le segment de connexion montré ci‑dessus ; une colonne manquante et une colonne de hauteur zéro peuvent également se ressembler. De même, un graphique de dispersion avec uniquement des marqueurs n’a pas de ligne de connexion. Ne vous attendez pas à trois résultats distincts pour chaque type de graphique ; vérifiez le résultat pour le type que vous utilisez.

## **Définir la largeur d’écart de la série**

La largeur d’écart est l’espace entre les clusters de barres ou de colonnes adjacents, exprimé en pourcentage de la largeur de la barre ou de la colonne. Comme le chevauchement, elle appartient au groupe de séries parent plutôt qu’à une seule série. Appelez [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) une fois pour le groupe. Une valeur plus grande crée plus d’espace entre les clusters ; une valeur plus petite les rend plus denses.

L’exemple suivant modifie la largeur d’écart et n’enregistre que la présentation finale :

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const uint16_t gapWidthPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_GapWidth(gapWidthPercent);

presentation->Save(u"gap_width_30.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Le résultat :

![La largeur d’écart](gap_width.png)

## **FAQ**

**Quels types de graphiques prennent en charge les séries de données ?**

Tous les types de graphiques représentés par l’énumération [ChartType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/charttype/) utilisent des données de graphique, mais leurs séries n’ont pas toutes la même structure de valeurs ou les mêmes paramètres. Par exemple, les graphiques de catégorie utilisent des catégories et des valeurs, les graphiques de dispersion utilisent des valeurs X et Y, et les graphiques à bulles ajoutent des tailles de bulle. Utilisez la méthode de création de point de données qui correspond au type de série. Des options telles que le chevauchement et la largeur d’écart s’appliquent uniquement aux groupes de barres ou de colonnes compatibles.

**Qu’est‑ce qu’un groupe de séries de graphique ?**

Un [IChartSeriesGroup](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartseriesgroup/) contient des séries compatibles qui partagent des paramètres de tracé au niveau du groupe. Un graphique combiné peut contenir plusieurs groupes, de sorte que la modification du groupe atteinte via une série ne modifie pas forcément toutes les séries du graphique.

**Un graphique nouvellement créé contient‑il des données par défaut ?**

Oui. Par défaut, [IShapeCollection::AddChart](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/addchart/) crée des séries, catégories et valeurs d’exemple. Vous pouvez modifier ces cellules ou vider les collections de séries et de catégories avant d’ajouter un ensemble de données totalement personnalisé. Une surcharge peut également créer un graphique sans données par défaut.

**Comment les objets graphiques sont‑ils reliés aux cellules du classeur ?**

Les noms de séries, les libellés de catégories et les valeurs des points de données font référence à des cellules d’un [IChartDataWorkbook](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdataworkbook/). Modifier une cellule référencée met à jour l’élément de graphique correspondant. Lorsque vous construisez des données personnalisées, maintenez les lignes de catégories et les lignes de valeurs de séries alignées de manière à ce que chaque point soit tracé sous la catégorie prévue.

**Comment effacer un point sans supprimer toute la série ?**

Définissez la cellule de valeur concernée sur `nullptr` pour conserver la position de catégorie du point en tant que point vide. Appelez [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) uniquement lorsque vous désirez supprimer tous les points de cette série. Si vous supprimez également des catégories, mettez à jour chaque série afin que leurs valeurs restent alignées avec la collection de catégories.

**Comment les points vides sont‑ils affichés ?**

Le résultat dépend du type de graphique et de [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichart/get_displayblanksas/). Les graphiques pris en charge peuvent afficher les blancs comme des écarts, comme des valeurs zéro, ou en reliant les points voisins. Choisissez le paramètre qui correspond à la signification des données manquantes dans votre présentation. Consultez la section [Contrôler l’affichage des cellules vides](#control-the-display-of-empty-cells) pour un exemple complet et une comparaison visuelle.

**Comment les valeurs négatives sont‑elles formatées ?**

Pour les séries à barres, colonnes et bulles prises en charge, appelez [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) et définissez la couleur via [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Vous pouvez remplacer le comportement pour un point individuel avec [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). Ces méthodes affectent le formatage, pas les valeurs numériques stockées.

**Quel format l’emporte lorsque la série et le point sont tous deux formatés ?**

Le formatage explicite du point de données prend le pas pour ce point. Les autres points continuent d’utiliser le format de série explicite ou, lorsque le format de série n’est pas défini, le style et le thème automatiques du graphique. Les paramètres de groupe tels que le chevauchement et la largeur d’écart contrôlent la disposition et ne sont pas des surcharges de formatage au niveau du point.

**Y a‑t‑il une limite au nombre de séries qu’un graphique peut contenir ?**

Aspose.Slides n’impose pas de limite fixe séparée au nombre de séries. En pratique, les contraintes du fichier de présentation, la mémoire disponible, le temps de rendu et la lisibilité du graphique déterminent une limite pratique.

**Que dois‑je modifier lorsque les colonnes sont trop proches ou trop éloignées ?**

Appelez [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) sur le groupe de séries parent approprié. Augmentez la valeur pour élargir l’espace entre les clusters, ou diminuez‑la pour rapprocher les clusters.