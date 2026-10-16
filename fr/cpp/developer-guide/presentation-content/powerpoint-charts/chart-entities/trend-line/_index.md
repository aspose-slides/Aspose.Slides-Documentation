---
title: Ajouter des lignes de tendance aux graphiques de présentation en C++
linktitle: Ligne de tendance
type: docs
url: /fr/cpp/trend-line/
keywords:
- graphique
- ligne de tendance
- ligne de tendance exponentielle
- ligne de tendance linéaire
- ligne de tendance logarithmique
- ligne de tendance moyenne mobile
- ligne de tendance polynomiale
- ligne de tendance de puissance
- ligne de tendance personnalisée
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Ajoutez et personnalisez rapidement des lignes de tendance dans les graphiques PowerPoint avec Aspose.Slides pour C++ — un guide pratique pour captiver votre audience."
---
## **Vue d'ensemble**

Cet article explique comment ajouter des lignes de tendance aux graphiques de présentation en utilisant Aspose.Slides. Il montre comment créer un graphique, ajouter des lignes de tendance aux séries du graphique et travailler avec plusieurs types de lignes de tendance, notamment exponentielle, linéaire, logarithmique, moyenne mobile, polynomiale et puissance.

Il décrit également comment ajouter une ligne personnalisée à un graphique en insérant une forme de ligne, et inclut une courte FAQ sur les valeurs de projection en avant et en arrière d'une ligne de tendance ainsi que sur la préservation des lignes de tendance lors de l'exportation en PDF ou SVG et lors du rendu des graphiques sous forme d'images.

## **Ajouter une ligne de tendance**

Utilisez [ITrendlineCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendlinecollection/add/) pour ajouter une ligne de tendance à une série de graphique, en sélectionnant son type avec [TrendlineType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/trendlinetype/). L'exemple crée un graphique à colonnes groupées avec des données par défaut et ajoute deux lignes de tendance à chacune de ses trois séries.

La ligne de tendance exponentielle masque son équation et sa valeur R² via [ITrendline::set_DisplayEquation](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayequation/) et [ITrendline::set_DisplayRSquaredValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayrsquaredvalue/), tandis que la ligne de tendance linéaire est rouge. La ligne de tendance logarithmique utilise [IOverridableText::AddTextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/addtextframeforoverriding/) pour une étiquette personnalisée. La moyenne mobile utilise [ITrendline::set_Period](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_period/) pour moyenner trois points de données et [ITrendline::set_TrendlineName](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_trendlinename/) pour un nom personnalisé.

La ligne de tendance polynomiale utilise [ITrendline::set_Order](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_order/) pour définir son degré à trois et s'étend d'une catégorie en avant via [ITrendline::set_Forward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_forward/). La ligne de tendance puissance s'étend d'une catégorie en arrière via [ITrendline::set_Backward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_backward/).

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <DOM/Chart/IFormat.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

auto firstSeries = chart->get_ChartData()->get_Series()->idx_get(0);

auto exponentialTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Exponential);
exponentialTrendline->set_DisplayEquation(false);
exponentialTrendline->set_DisplayRSquaredValue(false);

auto linearTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Linear);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto secondSeries = chart->get_ChartData()->get_Series()->idx_get(1);

auto logarithmicTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::Logarithmic);
logarithmicTrendline->AddTextFrameForOverriding(u"New log trend line");

auto movingAverageTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::MovingAverage);
movingAverageTrendline->set_Period(3);
movingAverageTrendline->set_TrendlineName(u"New TrendLine Name");

auto thirdSeries = chart->get_ChartData()->get_Series()->idx_get(2);

auto polynomialTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Polynomial);
polynomialTrendline->set_Forward(1);
polynomialTrendline->set_Order(3);

auto powerTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Power);
powerTrendline->set_Backward(1);

presentation->Save(u"ChartTrendLines.pptx", SaveFormat::Pptx);
```

## **Définir l'interception d'une ligne de tendance**

Utilisez [ITrendline::set_Intercept](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_intercept/) pour fixer la valeur Y d'une ligne de tendance à X = 0. Ce paramètre est pris en charge pour les lignes de tendance linéaires, exponentielles et polynomiales.

Par exemple, un modèle de coût de production peut devoir commencer à des coûts fixes connus de 100, même lorsque des mesures à des volumes de production non nuls suggèrent une base différente. Pour une ligne de tendance linéaire, fixer l'interception contraint l'équation `y = ax + b` à `b = 100` ; la pente est ajustée aux données sous cette contrainte. Cela ne déplace pas simplement une ligne déjà ajustée. Les paramètres de croisement des axes contrôlent où les axes du graphique se rencontrent, pas les coefficients de la ligne de tendance ajustée.

L'exemple suivant crée un graphique en nuage de points (XY) avec des volumes de production de 1 à 4 et des coûts de 170, 200, 230 et 260. Il enregistre le graphique avec l'interception automatique par défaut, fixe l'interception à 100 et enregistre un second PPTX. Les deux fichiers ne diffèrent que par le paramètre d'interception. La ligne de tendance affiche son équation et s'étend jusqu'à X = 0.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto nameCell = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Production cost"));
auto series = chart->get_ChartData()->get_Series()->Add(nameCell, ChartType::ScatterWithMarkers);
const double costs[] = { 170, 200, 230, 260 };

for (auto i = 0; i < 4; i++)
{
    auto xCell = workbook->GetCell(0, i + 1, 0, ObjectExt::Box<int32_t>(i + 1));
    auto yCell = workbook->GetCell(0, i + 1, 1, ObjectExt::Box<double>(costs[i]));
    series->get_DataPoints()->AddDataPointForScatterSeries(xCell, yCell);
}

auto trendline = series->get_TrendLines()->Add(TrendlineType::Linear);
trendline->set_DisplayEquation(true);
trendline->set_Backward(1);

presentation->Save(u"AutomaticIntercept.pptx", SaveFormat::Pptx);

trendline->set_Intercept(100);
presentation->Save(u"FixedIntercept.pptx", SaveFormat::Pptx);
```

Avec le calcul automatique, ces données produisent `y = 30x + 140`. Fixer l'interception à 100 produit environ `y = 43.33x + 100` : la valeur ajustée à zéro correspond à la base connue, tandis que la ligne ne passe plus par chaque point de données.

| Intercept automatique | Intercept fixe de 100 |
| --- | --- |
| ![Ligne de tendance linéaire avec un intercept calculé automatiquement de 140](intercept-automatic.png) | ![Ligne de tendance linéaire avec un intercept fixe de 100](intercept-fixed.png) |

Les deux images utilisent les mêmes données et les mêmes échelles d'axes. Les lignes de tendance sont étendues jusqu'à X = 0 pour montrer leurs interceptions.

Par défaut, la propriété contient `std::numeric_limits<double>::quiet_NaN()`, qui représente un intercept non spécifié plutôt que zéro. L'intercept est alors calculé automatiquement à partir des données.

## **Ajouter une ligne personnalisée**

Une ligne personnalisée est une forme dessinée au-dessus du graphique plutôt qu'une ligne de tendance calculée à partir des données de séries. Cet exemple utilise [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) pour ajouter une ligne horizontale à la diapositive au-dessus du graphique. La position de la ligne est spécifiée en coordonnées de diapositive, mesurées en points, de sorte qu'elle commence au bord gauche du graphique et se situe à mi-hauteur du graphique. Sa largeur correspond à la largeur du graphique. Le format de ligne retourné par [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) donne à la ligne une couleur rouge unie.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, chart->get_X(), chart->get_Y() + chart->get_Height() / 2, chart->get_Width(), 0);
line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"AddCustomLines.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Que signifient « avant » et « arrière » pour une ligne de tendance ?**

Il s'agit des longueurs de la ligne de tendance projetées en avant ou en arrière : pour les graphiques en nuage de points (XY) — en unités d'axe ; pour les graphiques qui ne sont pas en nuage de points — en nombre de catégories. Seules les valeurs non négatives sont autorisées.

**La ligne de tendance sera-t-elle préservée lors de l'exportation de la présentation au format PDF ou SVG, ou lors du rendu d'une diapositive en image ?**

Oui. Aspose.Slides convertit les présentations en [PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/) ou en [SVG](/slides/fr/cpp/render-a-slide-as-an-svg-image/) et rend les graphiques en images ; les lignes de tendance, en tant que partie du graphique, sont préservées pendant ces opérations. Une méthode est également disponible pour [exporter une image du graphique](/slides/fr/cpp/shape-thumbnails/) elle‑même.