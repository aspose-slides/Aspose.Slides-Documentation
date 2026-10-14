---
title: Personnaliser les graphiques circulaires dans les présentations avec C++
linktitle: Graphique circulaire
type: docs
url: /fr/cpp/pie-chart/
keywords:
- graphique circulaire
- gérer le graphique
- personnaliser le graphique
- options de graphique
- paramètres du graphique
- options de tracé
- couleur de tranche
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Créer et personnaliser des graphiques circulaires en C++ avec Aspose.Slides. Configurer les tracés secondaires, afficher les étiquettes de données et appliquer des couleurs de tranche automatiques dans PowerPoint."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les graphiques circulaires dans Aspose.Slides. Il montre comment configurer les options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie, et comment activer la coloration automatique des tranches pour un graphique circulaire standard.

Les exemples se concentrent sur des tâches de personnalisation de graphique telles que l’ajout d’un graphique à une diapositive, le réglage des séries et des paramètres d’étiquette, le remplacement des données de graphique par défaut par des catégories et des valeurs personnalisées, et l’enregistrement de la présentation mise à jour.

## **Options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie**

Aspose.Slides for C++ prend en charge les options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie. Ces options contrôlent la taille du tracé secondaire et la façon dont les points de données sont répartis entre les deux tracés.

L’exemple suivant crée un graphique Pie of Pie dans une nouvelle présentation et affiche les valeurs des points de données sous forme d’étiquettes. La méthode [set_SecondPieSize](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_secondpiesize/) définit la taille du tracé secondaire à 149 % du tracé principal. [set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitby/) sélectionne une répartition basée sur le pourcentage, et [set_PieSplitPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitposition/) fixe le seuil à 53 %.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/PieSplitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PieOfPie, 50, 50, 500, 400);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

// Display values and configure the secondary plot.
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
auto seriesGroup = series->get_ParentSeriesGroup();
seriesGroup->set_SecondPieSize(149);
seriesGroup->set_PieSplitBy(PieSplitType::ByPercentage);
seriesGroup->set_PieSplitPosition(53);

presentation->Save(u"pie_of_pie.pptx", SaveFormat::Pptx);
```

### **Sélectionner les catégories pour le tracé secondaire**

Utilisez le fractionnement personnalisé lorsque vous souhaitez regrouper des catégories spécifiques dans le tracé secondaire, quelles que soient leurs valeurs en pourcentage. Par exemple, un rapport de ventes pourrait afficher Online et Events ensemble afin que les lecteurs puissent comparer ces deux canaux, même s’ils représentent 35 % et 10 % du total des ventes.

Appelez [set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/set_piesplitby/) avec [PieSplitType::Custom](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplittype/) et sélectionnez les points via [get_PieSplitCustomPoints](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/get_piesplitcustompoints/). La méthode [Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/add/) de la collection accepte un indice basé sur zéro dans la série. Dans cet exemple, l’indice 1 sélectionne Online, et l’indice 3 sélectionne Events. Partners est également ajouté temporairement, puis exclu à l’aide de [Remove](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/remove/).

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/PieSplitType.h>
#include <vector>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IPieSplitCustomPointCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PieOfPie, 50, 50, 600, 200);

// Remplacez les données par défaut par les ventes par canal.
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();
auto categoryNames = std::vector<System::String>{ u"Retail", u"Online", u"Partners", u"Events" };
auto values = std::vector<int>{ 40, 35, 15, 10 };
auto seriesNameCell = workbook->GetCell(0, 0, 1, System::ObjectExt::Box(System::String(u"Sales")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

for (auto i = 0; i < static_cast<int>(categoryNames.size()); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryNames[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForPieSeries(valueCell);
}

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
auto seriesGroup = series->get_ParentSeriesGroup();
seriesGroup->set_PieSplitBy(PieSplitType::Custom);
seriesGroup->set_IsColorVaried(true);

// Sélectionnez Online et Events par leurs index basés sur zéro dans la série.
seriesGroup->get_PieSplitCustomPoints()->Add(1);
seriesGroup->get_PieSplitCustomPoints()->Add(3);

// Excluez Partners de la sélection sans supprimer ses données source.
seriesGroup->get_PieSplitCustomPoints()->Add(2);
seriesGroup->get_PieSplitCustomPoints()->Remove(2);

presentation->Save(u"pie_of_pie_custom.pptx", SaveFormat::Pptx);
```

Online (35) et Events (10) apparaissent comme des tranches séparées dans le tracé secondaire. Dans le tracé principal, ils sont représentés par une seule tranche combinée d’une valeur de 45, aux côtés de Retail (40) et Partners (15). La suppression de Partners de la sélection personnalisée le maintient dans le tracé principal ; cela ne supprime pas la catégorie ni sa valeur des données sources du graphique.

L’image suivante montre la présentation enregistrée dans PowerPoint :

![Graphique Pie of Pie avec Online et Events dans le tracé secondaire et leur valeur combinée de 45 dans le tracé principal](pie_of_pie_custom.png)

## **Définir les couleurs automatiques des tranches du graphique circulaire**

Aspose.Slides for C++ peut attribuer automatiquement des couleurs différentes aux tranches d’un graphique circulaire. L’exemple suivant crée un graphique circulaire avec un titre centré et remplace les données par défaut par trois catégories trimestrielles et leurs valeurs. La méthode [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) affiche les valeurs 20, 50 et 30 sous forme d’étiquettes, tandis que [set_IsColorVaried](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_iscolorvaried/) active une couleur distincte pour chaque tranche.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <vector>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 100, 100, 400, 400);

// Ajouter un titre de graphique centré.
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
chart->get_ChartTitle()->set_Height(20);
chart->set_HasTitle(true);

// Remplacer les données par défaut en utilisant la première feuille de calcul.
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;
chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();
auto categoryNames = std::vector<System::String>{ u"First Qtr", u"2nd Qtr", u"3rd Qtr" };
auto values = std::vector<int>{ 20, 50, 30 };
auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 1, System::ObjectExt::Box(System::String(u"Series 1")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

for (auto i = 0; i < static_cast<int>(categoryNames.size()); i++)
{
    auto categoryCell = workbook->GetCell(worksheetIndex, i + 1, 0, System::ObjectExt::Box(categoryNames[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(worksheetIndex, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForPieSeries(valueCell);
}

// Afficher les valeurs et attribuer des couleurs différentes aux tranches.
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);

presentation->Save(u"pie.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Les variantes Pie of Pie et Bar of Pie sont‑elles prises en charge ?**

Oui, la bibliothèque [supports](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) un tracé secondaire pour les graphiques circulaires, y compris les types Pie of Pie et Bar of Pie.

**Puis‑je exporter uniquement le graphique sous forme d'image (par exemple, PNG) ?**

Oui, vous pouvez [export the chart itself as an image](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) (such as PNG) without exporting the entire presentation.