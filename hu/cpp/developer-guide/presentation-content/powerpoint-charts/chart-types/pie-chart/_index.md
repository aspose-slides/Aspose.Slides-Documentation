---
title: "Tortadiagramok testreszabása prezentációkban C++ nyelven"
linktitle: "Tortadiagram"
type: docs
url: /hu/cpp/pie-chart/
keywords:
- "tortadiagram"
- "diagram kezelése"
- "diagram testreszabása"
- "diagram beállításai"
- "diagram beállítások"
- "ábrázolási beállítások"
- "szelet szín"
- "PowerPoint"
- "prezentáció"
- "C++"
- "Aspose.Slides"
description: "Hozzon létre és testreszabjon tortadiagramokat C++ nyelven az Aspose.Slides segítségével. Állítsa be a másodlagos ábrákat, jelenítse meg az adatcímkéket, és alkalmazzon automatikus szelet színeket PowerPointban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozzunk tortadiagramokkal az Aspose.Slides-ban. Megmutatja, hogyan konfiguráljuk a másodlagos ábrázolási beállításokat a Pie of Pie és Bar of Pie diagramokhoz, illetve hogyan engedélyezzük az automatikus szeletszínezést egy szabványos tortadiagramhoz.

A példák a diagram testreszabási feladatokra összpontosítanak, például diagram hozzáadására egy diára, sorozat- és címke beállítások módosítására, az alapértelmezett diagram adatok helyettesítésére egyéni kategóriákkal és értékekkel, valamint a frissített prezentáció mentésére.

## **Másodlagos ábrázolási beállítások a Pie of Pie és Bar of Pie diagramokhoz**

Az Aspose.Slides for C++ támogatja a Pie of Pie és Bar of Pie diagramok másodlagos ábrázolási beállításait. Ezek a beállítások szabályozzák a másodlagos ábra méretét és azt, hogy az adatpontok hogyan oszlanak meg a két ábra között.

A következő példa egy Pie of Pie diagramot hoz létre egy új prezentációban, és az adatpont értékeket címkeként jeleníti meg. A [set_SecondPieSize](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_secondpiesize/) metódus a másodlagos ábra méretét a fő ábra 149%-ára állítja. A [set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitby/) százalékos alapú felosztást választ, és a [set_PieSplitPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitposition/) a küszöböt 53%-ra állítja.

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

### **Válasszon kategóriákat a másodlagos ábrához**

Használjon egyéni felosztást, ha a specifikus kategóriákat a másodlagos ábrában szeretné csoportosítani a százalékos értéküktől függetlenül. Például egy értékesítési jelentésben az Online és az Events együtt jelenhet meg, hogy az olvasók össze tudják hasonlítani ezt a két csatornát, még akkor is, ha azok a teljes értékesítés 35%-át és 10%-át teszik ki.

Ezzel a [set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/set_piesplitby/) metódussal a [PieSplitType::Custom](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplittype/) segítségével, és a pontok kiválasztásával a [get_PieSplitCustomPoints](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/get_piesplitcustompoints/) révén. A gyűjtemény [Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/add/) metódusa egy nulláról induló indexet fogad a sorozatban. Ebben a példában az 1-es index az Online, a 3-as index az Events választja ki. A Partners is ideiglenesen hozzáadódik, majd a [Remove](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/remove/) használatával kizárásra kerül.

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

// Cserélje le az alapértelmezett adatokat csatornánkénti értékesítéssel.
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

// Válassza ki az Online és Events elemeket a sorozat nulla alapú indexei alapján.
seriesGroup->get_PieSplitCustomPoints()->Add(1);
seriesGroup->get_PieSplitCustomPoints()->Add(3);

// Zárja ki a Partners elemet a kiválasztásból anélkül, hogy törölné a forrásadatot.
seriesGroup->get_PieSplitCustomPoints()->Add(2);
seriesGroup->get_PieSplitCustomPoints()->Remove(2);

presentation->Save(u"pie_of_pie_custom.pptx", SaveFormat::Pptx);
```

Az Online (35) és az Events (10) külön szeletekként jelennek meg a másodlagos ábrán. Az elsődleges ábrában egy közös szeletként 45 értékkel szerepelnek, a Retail (40) és a Partners (15) mellett. A Partners eltávolítása az egyéni kiválasztásból az elsődleges ábrában marad; nem távolítja el a kategóriát vagy értékét a diagram forrásadataiból.

A következő kép a mentett prezentációt mutatja PowerPointban:

![Pie of Pie diagram Online és Events elemekkel a másodlagos ábrában és a 45-ös kombinált értékkel az elsődleges ábrában](pie_of_pie_custom.png)

## **Automatikus tortadiagram szelet színek beállítása**

Az Aspose.Slides for C++ automatikusan különböző színeket rendelhet a tortadiagram szeleteihez. A következő példa egy középre igazított címmel rendelkező tortadiagramot hoz létre, és az alapértelmezett adatokat három negyedéves kategóriával és azok értékeivel helyettesíti. A [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) metódus a 20, 50 és 30 értékeket jeleníti meg címkeként, míg a [set_IsColorVaried](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_iscolorvaried/) engedélyezi, hogy minden szeletnek eltérő színe legyen.

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

// Adjunk középre igazított diagramcímet.
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
chart->get_ChartTitle()->set_Height(20);
chart->set_HasTitle(true);

// Az alapértelmezett adatokat az első munkalappal cseréljük le.
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

// Show values and assign different colors to the slices.
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);

presentation->Save(u"pie.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Támogatottak a Pie of Pie és Bar of Pie változatok?**

Igen, a könyvtár [támogatja](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) egy másodlagos ábrát a tortadiagramokhoz, beleértve a Pie of Pie és Bar of Pie típusokat.

**Exportálhatom csak a diagramot képként (például PNG)?**

Igen, [exportálja magát a diagramot képként](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) (például PNG) anélkül, hogy a teljes prezentációt exportálná.