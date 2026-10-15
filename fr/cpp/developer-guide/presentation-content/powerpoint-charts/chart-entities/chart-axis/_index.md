---
title: Personnaliser les axes de graphique dans les présentations avec C++
linktitle: Axe de graphique
type: docs
url: /fr/cpp/chart-axis/
keywords:
- axe de graphique
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
description: "Découvrez comment utiliser Aspose.Slides for C++ pour personnaliser les axes de graphiques dans les présentations PowerPoint pour les rapports et les visualisations."
---
## **Vue d'ensemble**

Cet article explique comment personnaliser les axes de graphique avec Aspose.Slides for C++. Il couvre les valeurs d'axe calculées, le changement de lignes et de colonnes du graphique, la visibilité des axes, les intervalles d'étiquettes de catégories et de marques de graduation, les catégories de dates et leur formatage, la rotation du titre, le positionnement des axes, les unités d'affichage et le dimensionnement logarithmique.

## **Obtenir les valeurs maximales sur l'axe vertical des graphiques**

Créez une [Présentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) et ajoutez un graphique en aires avec des données par défaut. Appelez [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) avant de lire les valeurs d'axe calculées afin que la disposition du graphique soit à jour.

Lisez [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) et [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) pour les limites de l'axe, et [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) et [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) pour les intervalles de graduation. [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) et [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) fournissent des échelles d'unités de temps, pertinentes pour les axes de date. L'exemple stocke ces valeurs dans des variables locales et enregistre le graphique.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 100, 100, 500, 350);
chart->ValidateChartLayout();

auto maxValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMaxValue();
auto minValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMinValue();

auto majorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnit();
auto minorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnit();

auto majorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnitScale();
auto minorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnitScale();

presentation->Save(u"AxisValues_out.pptx", SaveFormat::Pptx);
```

## **Échanger les données entre les axes**

Utilisez [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) pour échanger les rôles des séries et des catégories dans les données du graphique. Chaque ancienne catégorie devient une série, et chaque ancienne série devient une catégorie. Cela modifie la façon dont les données sont groupées ; cela n'échange pas les axes horizontal et vertical. L'exemple utilise [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) pour lier les données par défaut à `Sheet1!A1:D5`, y compris la ligne d’en-tête et la colonne de catégorie, avant d’échanger les lignes et les colonnes. Il enregistre un graphique avec quatre séries et trois catégories.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 400, 300);

chart->get_ChartData()->SetRange(u"Sheet1!A1:D5");
chart->get_ChartData()->SwitchRowColumn();

presentation->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Inverser l'ordre de tracé d'un axe**

Utilisez [set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) pour inverser un axe de catégorie ou de valeur. Par exemple, un graphique à barres horizontal peut afficher les étapes du projet de haut en bas dans le même ordre que la feuille de calcul : Planning, Development, Testing. Inverser un axe modifie la direction du tracé ; cela ne trie pas et ne réarrange pas les données du classeur. En comparaison, [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) échange les rôles des séries et des catégories.

L'exemple suivant crée un graphique à barres horizontal avec trois étapes et une série. Il enregistre une présentation avec trois diapositives : ordre normal, catégories inversées et valeurs inversées. Chaque copie utilise le même jeu de données, et un seul axe est inversé dans chaque copie.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/CrossesType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredBar, 50, 40, 620, 320);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredBar);
auto stages = std::array<System::String, 3>{u"Planning", u"Development", u"Testing"};
auto values = std::array<int, 3>{10, 30, 20};
for (auto i = 0; i < stages.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(stages[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

// Diapositive 2: afficher la première catégorie en haut.
auto categorySlide = presentation->get_Slides()->AddClone(slide);
auto categoryChart = System::ExplicitCast<IChart>(categorySlide->get_Shape(0));
categoryChart->get_Axes()->get_VerticalAxis()->set_IsPlotOrderReversed(true);
// Conserver l'axe de valeur horizontal en bas.
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// Diapositive 3: inverser uniquement l'échelle numérique horizontale.
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

Inverser un axe peut également déplacer l'axe perpendiculaire du côté opposé du tracé. [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) contrôle où l'autre axe croise l'axe configuré. Dans la diapositive 2, le définir sur `Maximum` sur l'axe de catégorie inversé maintient l'axe de valeur horizontal en bas. Pour un point de croisement précis, utilisez [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Vérifiez les paramètres de croisement lors du changement de direction, surtout si le graphique possède déjà un point de croisement personnalisé. Appelez `set_IsPlotOrderReversed` avec `false` pour restaurer la direction normale de tracé ; les paramètres de croisement sont séparés.

| Ordre normal (diapositive 1) | Catégories inversées (diapositive 2) | Valeurs inversées (diapositive 3) |
| --- | --- | --- |
| ![Graphique à barres horizontal avec ordre normal des axes de catégorie et de valeur](axis-order-normal.png) | ![Graphique à barres horizontal avec les catégories affichées de haut en bas](axis-order-categories-reversed.png) | ![Graphique à barres horizontal avec un axe de valeur inversé et zéro à droite](axis-order-values-reversed.png) |
| Les catégories s'étendent du bas vers le haut ; les valeurs augmentent de gauche à droite. | Planning, Development et Testing s'étendent de haut en bas. Les valeurs et l'ordre des lignes du classeur restent inchangés. | Les catégories conservent leur ordre normal ; les valeurs augmentent de droite à gauche. L'axe de catégorie croise à zéro à droite. |

## **Désactiver l'axe vertical pour les graphiques en courbes**

Utilisez [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) avec `false` sur l'axe vertical pour le masquer. L'exemple crée un graphique en courbes avec des données par défaut et l'enregistre avec l'axe vertical masqué.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenVerticalAxis.pptx", SaveFormat::Pptx);
```

## **Désactiver l'axe horizontal pour les graphiques en courbes**

Utilisez [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) avec `false` sur l'axe horizontal pour le masquer. L'exemple crée un graphique en courbes avec des données par défaut et l'enregistre avec l'axe horizontal masqué.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
```

## **Modifier un axe de catégorie**

Utilisez [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) pour choisir un axe de catégorie de date ou de texte. Cet exemple nécessite `ExistingChart.pptx`, avec un graphique comme première forme de la première diapositive et des cellules de catégorie contenant des valeurs de date Excel numériques. Il change l'axe horizontal en axe de date. Appeler [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) avec `false`, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) avec `1` et [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) avec des mois place les graduations majeures à des intervalles d'un mois.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TimeUnitType.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = System::ExplicitCast<IChart>(slide->get_Shape(0));
chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnit(1);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **Contrôler les intervalles d'étiquettes d'axe de catégorie**

Lorsqu'un graphique possède de nombreuses catégories, réduisez le nombre d'étiquettes d'axe visibles sans supprimer les catégories ou les points de données. Utilisez [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) avec `false`, puis [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) avec l'intervalle de catégorie souhaité. Pour les catégories de texte dans leur ordre normal, le comptage commence à la première catégorie :

| Intervalle | Étiquettes affichées dans l'exemple |
| --- | --- |
| `1` | Catégorie 1, Catégorie 2, Catégorie 3, ... Catégorie 24 |
| `2` | Catégorie 1, Catégorie 3, Catégorie 5, ... Catégorie 23 |
| `3` | Catégorie 1, Catégorie 4, Catégorie 7, ... Catégorie 22 |

Un intervalle de `3` affiche chaque troisième étiquette, laissant deux étiquettes masquées entre les étiquettes affichées. Cela ne supprime pas les colonnes correspondantes. L'espacement automatique choisit un intervalle en fonction de l'espace disponible ; il n'affiche pas nécessairement chaque étiquette.

Les marques de graduation ont des contrôles séparés. Utilisez [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) avec `false` et [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) pour définir leur intervalle. Par exemple, `1` maintient une marque de graduation à chaque intervalle de catégorie tandis que les étiquettes apparaissent uniquement toutes les trois catégories. Utilisez [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) avec un style visible pour voir le résultat. Revenir à `true` pour l'une ou l'autre propriété d'espacement automatique laisse le graphique choisir à nouveau cet intervalle.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TickMarkType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <DOM/ISlideCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->set_HasLegend(false);
chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredColumn);
for (auto i = 0; i < 24; i++)
{
    auto categoryName = System::String::Format(u"Category {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(10 + i % 6 * 5));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->set_CategoryAxisType(CategoryAxisType::Text);
axis->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(0);
axis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);
axis->set_MajorTickMark(TickMarkType::Outside);
axis->set_IsAutomaticTickLabelSpacing(true);
axis->set_IsAutomaticTickMarksSpacing(true);

// Slide 2: show every third label, but keep a tick mark for every category.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// Slide 3: let the chart choose both intervals again.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**Espacement automatique (diapositive 1) :** Dans ce rendu, chaque deuxième étiquette de catégorie est affichée et se renvoie sur deux lignes. Le résultat automatique peut varier selon la taille du graphique, les polices et le moteur de rendu.

![Espacement automatique des étiquettes de catégorie avec les 24 colonnes visibles](category-axis-automatic.png)

**Espacement manuel (diapositive 2) :** Chaque troisième étiquette est affichée sur une ligne, tandis que les marques de graduation restent à chaque intervalle de catégorie. Les 24 colonnes, y compris celles sans étiquette, restent visibles avec les mêmes valeurs. La diapositive 3 restaure l'apparence automatique montrée ci‑dessus.

![Intervalle d'étiquettes de catégorie manuel de trois avec les 24 colonnes visibles](category-axis-manual.png)

### **Choisir l'axe et l'intervalle corrects**

Utilisez cet intervalle de comptage de catégories pour un axe de catégorie texte, tel que l'axe de catégorie d'un graphique à colonnes, en courbes, en aires ou à barres. Dans un graphique à colonnes, il s'agit de l'axe horizontal. Dans un graphique à barres horizontal, l'axe de catégorie est vertical, donc appliquez ces paramètres à [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). L'espacement des marques de graduation s'applique également à un axe de série dans les graphiques qui en possèdent un.

Ne pas utiliser l'espacement des étiquettes de catégorie pour définir l'échelle numérique d'un axe de valeur. Sur un axe de valeur, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) spécifie une différence de valeurs : par exemple, une unité majeure de `10` produit des graduations à 0, 10, 20, etc. lorsqu'un axe commence à zéro. Un intervalle d'étiquette de catégorie de `3` compte quant à lui les positions de catégorie, indépendamment de leurs valeurs. Les graphiques en nuage de points et en bulles utilisent des axes de valeur plutôt qu'un axe de catégorie texte. Pour un axe de date, utilisez des unités majeures et des échelles basées sur le temps comme décrit dans [Modifier un axe de catégorie](#modifier-un-axe-de-catégorie).

## **Définir le format de date pour les valeurs d'axe de catégorie**

L'exemple remplace les données de graphique par défaut par quatre valeurs annuelles. Les dates sont stockées comme nombres de série OLE Automation dans la première feuille de calcul (index `0`). Utilisez [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) pour sélectionner un axe de date, désactivez le formatage lié à la source avec [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/), et attribuez `yyyy` avec [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) afin que les étiquettes de catégorie affichent les années à quatre chiffres indépendamment du formatage des cellules.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 450, 300);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
for (auto i = 0; i < 4; i++)
{
    auto date = System::DateTime(2015 + i, 1, 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(date.ToOADate()));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(i + 1));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_HorizontalAxis()->set_NumberFormat(u"yyyy");

presentation->Save(u"DateAxisFormat.pptx", SaveFormat::Pptx);
```

## **Définir un angle de rotation pour le titre d'un axe de graphique**

Activez le titre de l'axe vertical avec [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/), fournissez le texte du titre et utilisez [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) pour le faire pivoter. L'angle est mesuré en degrés ; cet exemple enregistre un graphique à colonnes avec le titre de l'axe de valeur tourné de 90 degrés.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartTitle.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_HasTitle(true);
chart->get_Axes()->get_VerticalAxis()->get_Title()->AddTextFrameForOverriding(u"Value");
chart->get_Axes()->get_VerticalAxis()->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90);

presentation->Save(u"RotatedAxisTitle.pptx", SaveFormat::Pptx);
```

## **Définir la position de l'axe sur un axe de catégorie ou de valeur**

Utilisez [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) pour contrôler si l'axe de valeur croise l'axe de catégorie entre les catégories ou aux marques de catégorie. Cette propriété s'applique aux axes de catégorie. L'exemple la définit sur `true` sur l'axe de catégorie horizontal d'un graphique à colonnes et enregistre le résultat.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

presentation->Save(u"AxisBetweenCategories.pptx", SaveFormat::Pptx);
```

## **Définir l'unité d'affichage sur un axe de valeur du graphique**

Utilisez [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) pour mettre à l'échelle les étiquettes d'un axe de valeur sans modifier les données sous‑jacentes. Avec [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) défini sur `Millions`, une valeur de 60 000 000 est affichée comme 60. L'exemple crée un graphique à colonnes et applique l'unité d'affichage millions à son axe vertical.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/DisplayUnitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

presentation->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Configurer un axe de valeur logarithmique**

Un axe de valeur logarithmique est utile lorsque des valeurs positives s'étendent sur plusieurs ordres de grandeur. Par exemple, un service peut recevoir 10, 100, 1 000, 10 000 et 100 000 requêtes sur cinq périodes. Sur une échelle linéaire, les petites valeurs apparaissent proches les unes des autres près de zéro. Une échelle logarithmique rend leur croissance relative plus facile à comparer : des distances égales représentent des rapports égaux plutôt que des différences égales.

Appelez [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) avec `true` sur l'axe de valeur et utilisez [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) pour choisir la base. Cela modifie la façon dont les valeurs existantes sont affichées ; cela ne change pas les données ni n'ajoute une courbe de tendance logarithmique. Une courbe de tendance représente une relation ajustée aux données et constitue une fonctionnalité distincte.

### **Choisir l'axe de valeur et la base**

Pour un graphique en courbes ou à colonnes, l'axe de valeur est [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Pour un graphique à barres horizontal, il s'agit de [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/). Les graphiques en nuage de points et en bulles possèdent deux axes de valeur, choisissez donc l'axe horizontal pour les valeurs X, l'axe vertical pour les valeurs Y, ou les deux. N’appliquez pas le dimensionnement logarithmique à un axe de catégorie.

La base logarithmique par défaut est `10`. Pour les graphiques PPTX, utilisez une base comprise entre `2` et `1000`, inclusive ; les bases fractionnaires telles que `2.5` sont également prises en charge. Avec la base `10`, les puissances successives comme 10, 100, 1 000 et 10 000 sont espacées uniformément.

### **Comparer le dimensionnement linéaire et logarithmique**

L'exemple suivant crée un graphique en courbes avec les cinq décomptes de requêtes sur la première diapositive, puis duplique cette diapositive et active un axe de valeur logarithmique base 10 sur la seconde. Les deux diapositives conservent les mêmes données.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 30, 40, 660, 200);

chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto values = std::array<double, 5>{10, 100, 1000, 10000, 100000};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = System::String::Format(u"Period {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// Conserver la première diapositive linéaire et ne modifier que l'échelle de l'axe de valeur de la copie.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**Échelle linéaire (diapositive 1) :** Des distances verticales égales représentent des différences égales dans le nombre de requêtes. La valeur la plus élevée domine le graphique, rendant les valeurs plus petites difficiles à distinguer.

![Graphique en courbes PowerPoint montrant cinq décomptes de requêtes sur un axe de valeur linéaire](value-axis-linear.png)

**Échelle logarithmique (diapositive 2) :** Des distances verticales égales représentent des rapports égaux. Chaque période a dix fois plus de requêtes que la précédente, de sorte que les points forment une ligne droite ascendante sur l’échelle logarithmique base 10. Les étiquettes d'axe affichent toujours les décomptes de requêtes d'origine.

![Les mêmes cinq décomptes de requêtes dans PowerPoint sur un axe de valeur logarithmique base 10](value-axis-logarithmic.png)

### **Gérer les valeurs zéro et négatives**

Une échelle logarithmique ne peut afficher que des valeurs strictement positives. Vérifiez les données avant de l'activer. Si les valeurs zéro ou négatives sont pertinentes, conservez une échelle linéaire ou affichez‑les séparément. Si leur exclusion est appropriée pour l'analyse, expliquez‑l\'effacement. Ne les remplacez pas silencieusement par de petits nombres positifs, car cela changerait le sens des données. Toute valeur minimale ou maximale configurée manuellement pour un axe logarithmique doit également être positive.

## **FAQ**

**Comment définir la valeur à laquelle un axe croise l'autre (croisement d'axe) ?**

Utilisez [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) pour sélectionner le comportement de croisement. Pour spécifier une valeur de croisement numérique, utilisez [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Ces paramètres vous permettent de déplacer le croisement de l'axe vers une ligne de base appropriée.

**Comment positionner les étiquettes de graduation par rapport à l'axe ?**

Utilisez [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) avec une valeur provenant de [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/) : `Low`, `High`, `NextTo` ou `None`. Pour contrôler les marques de graduation elles‑mêmes, utilisez [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) ou [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/) ; ils sont distincts du positionnement des étiquettes.