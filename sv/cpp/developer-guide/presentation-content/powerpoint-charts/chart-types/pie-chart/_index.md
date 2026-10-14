---
title: Anpassa pajdiagram i presentationer med C++
linktitle: Pajdiagram
type: docs
url: /sv/cpp/pie-chart/
keywords:
- pajdiagram
- hantera diagram
- anpassa diagram
- diagramalternativ
- diagraminställningar
- plotalternativ
- segmentfärg
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Skapa och anpassa pajdiagram i C++ med Aspose.Slides. Konfigurera sekundära diagram, visa dataetiketter och tillämpa automatiska segmentfärger i PowerPoint."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med pajdiagram i Aspose.Slides. Den visar hur man konfigurerar sekundära diagramalternativ för Pie of Pie- och Bar of Pie-diagram, samt hur man aktiverar automatisk färgläggning av segment för ett standardpajdiagram.

Exemplen fokuserar på anpassningsuppgifter för diagram, såsom att lägga till ett diagram på en bild, justera serier och etikettinställningar, ersätta standarddiagramdata med anpassade kategorier och värden, samt spara den uppdaterade presentationen.

## **Alternativ för sekundärt diagram för Pie of Pie och Bar of Pie-diagram**

Aspose.Slides for C++ stöder alternativ för sekundära diagram för Pie of Pie- och Bar of Pie-diagram. Dessa alternativ styr storleken på det sekundära diagrammet och hur datapunkter delas mellan de två diagrammen.

Följande exempel skapar ett Pie of Pie-diagram i en ny presentation och visar datapunktvärden som etiketter. Metoden [set_SecondPieSize](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_secondpiesize/) sätter storleken på det sekundära diagrammet till 149% av huvuddiagrammet. [set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitby/) väljer procentbaserad delning, och [set_PieSplitPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitposition/) sätter tröskeln till 53%.

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

### **Välj kategorier för det sekundära diagrammet**

Använd anpassad delning när du vill gruppera specifika kategorier i det sekundära diagrammet oavsett deras procentvärden. Till exempel kan en försäljningsrapport visa Online och Events tillsammans så att läsarna kan jämföra dessa två kanaler, även om de utgör 35% respektive 10% av den totala försäljningen.

Anropa [set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/set_piesplitby/) med [PieSplitType::Custom](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplittype/) och välj punkterna via [get_PieSplitCustomPoints](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/get_piesplitcustompoints/). Samlingens [Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/add/)-metod accepterar ett nollbaserat index i serien. I detta exempel väljer index 1 Online och index 3 Events. Partners läggs också till tillfälligt och utesluts sedan med [Remove](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/remove/).

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

// Ersätt standarddata med försäljning per kanal.
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

// Välj Online och Events med deras nollbaserade index i serien.
seriesGroup->get_PieSplitCustomPoints()->Add(1);
seriesGroup->get_PieSplitCustomPoints()->Add(3);

// Exkludera Partners från urvalet utan att ta bort dess källdata.
seriesGroup->get_PieSplitCustomPoints()->Add(2);
seriesGroup->get_PieSplitCustomPoints()->Remove(2);

presentation->Save(u"pie_of_pie_custom.pptx", SaveFormat::Pptx);
```

Online (35) och Events (10) visas som separata segment i det sekundära diagrammet. I huvuddiagrammet representeras de av ett kombinerat segment med värdet 45, tillsammans med Retail (40) och Partners (15). Att ta bort Partners från den anpassade urvalet behåller dem i huvuddiagrammet; det tar inte bort kategorin eller dess värde från diagrammets källdata.

Följande bild visar den sparade presentationen i PowerPoint:

![Pie of Pie chart with Online and Events in the secondary plot and their combined value of 45 in the primary plot](pie_of_pie_custom.png)

## **Ställ in automatisk färgläggning av segment i pajdiagram**

Aspose.Slides for C++ kan automatiskt tilldela olika färger till segment i ett pajdiagram. Följande exempel skapar ett pajdiagram med en centrerad titel och ersätter standarddata med tre kvartalskategorier och deras värden. Metoden [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) visar värdena 20, 50 och 30 som etiketter, medan [set_IsColorVaried](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_iscolorvaried/) möjliggör en separat färg för varje segment.

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

// Lägg till en centrerad diagramtitel.
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
chart->get_ChartTitle()->set_Height(20);
chart->set_HasTitle(true);

// Ersätt standarddata med hjälp av det första kalkylbladet.
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

// Visa värden och tilldela olika färger till segmenten.
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);

presentation->Save(u"pie.pptx", SaveFormat::Pptx);
```

## **Vanliga frågor**

**Stöds variationerna Pie of Pie och Bar of Pie?**

Ja, biblioteket [stöder](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) ett sekundärt diagram för pajdiagram, inklusive typerna Pie of Pie och Bar of Pie.

**Kan jag exportera endast diagrammet som en bild (till exempel PNG)?**

Ja, du kan [exportera själva diagrammet som en bild](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) (till exempel PNG) utan att exportera hela presentationen.