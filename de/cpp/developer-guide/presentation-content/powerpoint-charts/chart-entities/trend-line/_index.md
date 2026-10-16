---
title: Trendlinien zu Präsentationsdiagrammen in C++ hinzufügen
linktitle: Trendlinie
type: docs
url: /de/cpp/trend-line/
keywords:
- Diagramm
- Trendlinie
- Exponentielle Trendlinie
- Lineare Trendlinie
- Logarithmische Trendlinie
- Gleitender Mittelwert Trendlinie
- Polynomial​e Trendlinie
- Potenz Trendlinie
- Benutzerdefinierte Trendlinie
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Fügen Sie Trendlinien in PowerPoint-Diagrammen mit Aspose.Slides für C++ schnell hinzu und passen Sie sie an – ein praxisnaher Leitfaden, um Ihr Publikum zu begeistern."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Trendlinien zu Präsentationsdiagrammen mit Aspose.Slides hinzufügt. Er zeigt, wie man ein Diagramm erstellt, Trendlinien zu Diagrammserien hinzufügt und mit mehreren Trendlinientypen arbeitet, einschließlich exponentiell, linear, logarithmisch, gleitender Mittelwert, polynomial und potenz.

Außerdem wird beschrieben, wie man eine benutzerdefinierte Linie zu einem Diagramm hinzufügt, indem man eine Linienform einfügt, und enthält ein kurzes FAQ zu Vorwärts‑ und Rückwärtsprojektion von Trendlinien sowie dazu, ob Trendlinien beim Export nach PDF oder SVG und beim Rendern von Diagrammen als Bilder erhalten bleiben.

## **Trendlinie hinzufügen**

Verwenden Sie [ITrendlineCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendlinecollection/add/) um eine Trendlinie zu einer Diagrammserie hinzuzufügen und wählen Sie deren Typ mit [TrendlineType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/trendlinetype/). Das Beispiel erstellt ein gruppiertes Säulendiagramm mit Standarddaten und fügt jeder seiner drei Serien zwei Trendlinien hinzu.

Die exponentielle Trendlinie blendet ihre Gleichung und den R‑Quadrat‑Wert über [ITrendline::set_DisplayEquation](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayequation/) bzw. [ITrendline::set_DisplayRSquaredValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayrsquaredvalue/) aus, während die lineare Trendlinie rot ist. Die logarithmische Trendlinie verwendet [IOverridableText::AddTextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/addtextframeforoverriding/) für ein benutzerdefiniertes Label. Der gleitende Mittelwert nutzt [ITrendline::set_Period](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_period/) um drei Datenpunkte zu mitteln und [ITrendline::set_TrendlineName](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_trendlinename/) für einen eigenen Namen.

Die polynomialen Trendlinie setzt über [ITrendline::set_Order](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_order/) den Grad auf drei und erstreckt eine Kategorie nach vorne mittels [ITrendline::set_Forward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_forward/). Die Potenz‑Trendlinie erstreckt eine Kategorie nach hinten über [ITrendline::set_Backward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_backward/).

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

## **Trendlinien‑Achsenabschnitt festlegen**

Verwenden Sie [ITrendline::set_Intercept](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_intercept/) um den Y‑Wert einer Trendlinie bei X = 0 festzulegen. Diese Einstellung wird für lineare, exponentielle und polynomialen Trendlinien unterstützt.

Beispielsweise muss ein Produktionskostenmodell bei bekannten Fixkosten von 100 beginnen, selbst wenn Messungen bei nicht‑null Produktionsmengen eine andere Basislinie nahelegen. Bei einer linearen Trendlinie zwingt das Fixieren des Achsenabschnitts die Gleichung `y = ax + b` zu `b = 100`; die Steigung wird unter dieser Nebenbedingung an die Daten angepasst. Es wird nicht einfach eine bereits angepasste Linie verschoben. Achsen‑Kreuzungs‑Einstellungen bestimmen, wo die Diagrammachsen sich schneiden, nicht die Koeffizienten der angepassten Trendlinie.

Das folgende Beispiel erstellt ein Scatter‑(XY‑)Diagramm mit Produktionsvolumina von 1 bis 4 und Kosten von 170, 200, 230 und 260. Es speichert das Diagramm mit dem standardmäßigen automatischen Achsenabschnitt, setzt den Achsenabschnitt auf 100 und speichert ein zweites PPTX. Die beiden Dateien unterscheiden sich nur in der Achsenabschnitt‑Einstellung. Die Trendlinie zeigt ihre Gleichung und erstreckt sich zurück zu X = 0.

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

Bei automatischer Berechnung ergeben diese Daten `y = 30x + 140`. Das Setzen des Achsenabschnitts auf 100 ergibt stattdessen ungefähr `y = 43.33x + 100`: Der angepasste Wert bei Null stimmt mit der bekannten Basislinie überein, während die Linie nicht mehr durch jeden Datenpunkt verläuft.

| Automatischer Achsenabschnitt | Fester Achsenabschnitt von 100 |
| --- | --- |
| ![Lineare Trendlinie mit automatisch berechnetem Achsenabschnitt von 140](intercept-automatic.png) | ![Lineare Trendlinie mit festem Achsenabschnitt von 100](intercept-fixed.png) |

Beide Bilder verwenden dieselben Daten und Achsenskalierungen. Die Trendlinien wurden zurück zu X = 0 erweitert, um ihre Achsenabschnitte zu zeigen.

Standardmäßig enthält die Eigenschaft `std::numeric_limits<double>::quiet_NaN()`, was einen nicht spezifizierten Achsenabschnitt statt null darstellt. Der Achsenabschnitt wird dann automatisch aus den Daten berechnet.

## **Benutzerdefinierte Linie hinzufügen**

Eine benutzerdefinierte Linie ist eine Form, die über dem Diagramm gezeichnet wird, anstatt eine aus den Seriendaten berechnete Trendlinie zu sein. Dieses Beispiel verwendet [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) um eine horizontale Linie zur Folie über dem Diagramm hinzuzufügen. Die Position der Linie wird in Folienkoordinaten (Punkte) angegeben, sodass sie am linken Rand des Diagramms beginnt und halbwegs in der Höhe des Diagramms liegt. Ihre Breite entspricht der Diagrammbreite. Das über [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) zurückgegebene Linienformat verleiht der Linie eine einheitliche rote Farbe.

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

**Was bedeuten „forward“ und „backward“ bei einer Trendlinie?**

Sie geben die Längen der Trendlinie an, die nach vorne bzw. nach hinten projiziert werden: für Scatter‑(XY‑)Diagramme in Achsen‑Einheiten; für Nicht‑Scatter‑Diagramme in der Anzahl der Kategorien. Es sind nur nicht‑negative Werte zulässig.

**Wird die Trendlinie beim Export der Präsentation nach PDF oder SVG bzw. beim Rendern einer Folie zu einem Bild erhalten bleiben?**

Ja. Aspose.Slides konvertiert Präsentationen zu [PDF](/slides/de/cpp/convert-powerpoint-to-pdf/) oder [SVG](/slides/de/cpp/render-a-slide-as-an-svg-image/) und rendert Diagramme zu Bildern; Trendlinien, als Teil des Diagramms, bleiben bei diesen Vorgängen erhalten. Eine Methode steht ebenfalls zur Verfügung, um ein Bild des Diagramms selbst zu [exportieren](/slides/de/cpp/shape-thumbnails/).