---
title: Använda C++ för att anpassa diagramaxlar i presentationer
linktitle: Diagramaxel
type: docs
url: /sv/cpp/chart-axis/
keywords:
- diagramaxel
- vertikal axel
- horisontell axel
- anpassa axel
- manipulera axel
- hantera axel
- axelegenskaper
- maxvärde
- minvärde
- axellinje
- datumformat
- axeltitel
- axelposition
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Upptäck hur du använder Aspose.Slides för C++ för att anpassa diagramaxlar i PowerPoint-presentationer för rapporter och visualiseringar."
---
## **Overview**

Den här artikeln förklarar hur du anpassar diagramaxi i Aspose.Slides. Den visar hur du hämtar faktiska axelvärden, byter data mellan axlar, döljer den vertikala eller horisontella axeln för linjediagram, ändrar kategoriaxelns typ, anger datumformatet för kategoriaxelvärden, roterar en axeltitel, ställer in axelns position och visar en enhetsetikett på värdeaxeln.

## **Get the Max Values on the Vertical Axis**

Aspose.Slides för C++ låter dig hämta de minsta och största värdena på en vertikal axel. Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Öppna den första bilden.
1. Lägg till ett diagram med standarddata.
1. Hämta det faktiska maximivärdet på axeln.
1. Hämta det faktiska minimivärdet på axeln.
1. Hämta den faktiska huvudenheten för axeln.
1. Hämta den faktiska delenheten för axeln.
1. Hämta den faktiska huvudenhetsskalan för axeln.
1. Hämta den faktiska delenhetsskalan för axeln.

Denna exempel­kod—en implementering av stegen ovan—visar hur du hämtar de nödvändiga värdena i C++:

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

// Sparar presentationen
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```

## **Swap the Data between Axes**

Aspose.Slides låter dig snabbt byta data mellan axlarna—data som visas på den vertikala axeln (y‑axeln) flyttas till den horisontella axeln (x‑axeln) och vice versa.

Denna C++‑kod visar hur du utför data­bytet mellan axlar i ett diagram:

``` cpp
// Skapar tom presentation
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Byter rader och kolumner
chart->get_ChartData()->SwitchRowColumn();

// Sparar presentationen
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Disable the Vertical Axis for Line Charts**

Denna C++‑kod visar hur du döljer den vertikala axeln för ett linjediagram:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Disable the Horizontal Axis for Line Charts**

Denna kod visar hur du döljer den horisontella axeln för ett linjediagram:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Change a Category Axis**

Genom att använda metoden **set_CategoryAxisType()** kan du ange önskad kategoriaxeltyp (**date** eller **text**). Denna kod i C++ demonstrerar operationen: 

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

## **Set the Date Format for Category Axis Values**

Aspose.Slides för C++ låter dig ange datumformatet för ett kategoriaxelvärde. Operationen demonstreras i denna C++‑kod:

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

## **Set the Rotation Angle for an Axis Title**

Aspose.Slides för C++ låter dig ange rotationsvinkeln för en diagramaxeltitel. Denna C++‑kod demonstrerar operationen:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Set the Axis Position on a Category or Value Axis**

Aspose.Slides för C++ låter dig ange positionsaxeln i en kategori- eller värdeaxel. Denna C++‑kod visar hur du utför uppgiften:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **Enable the Display Unit Label on a Chart Value Axis**

Aspose.Slides för C++ låter dig konfigurera ett diagram så att det visar en enhetsetikett på dess värdeaxel. Denna C++‑kod demonstrerar operationen:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Hur anger jag värdet där en axel korsar den andra (axelkorsning)?**

Axlar erbjuder en [crossing setting](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/axis/set_crosstype/): du kan välja att korsa vid noll, vid den maximala kategorin/värdet eller vid ett specifikt numeriskt värde. Detta är användbart för att flytta X‑axeln upp eller ner eller för att framhäva en referenslinje.

**Hur kan jag placera tickenetiketter i förhållande till axeln (intill, ute, inne)?**

Ställ in [label position](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/axis/set_majortickmark/) till "cross", "outside" eller "inside". Detta påverkar läsbarheten och hjälper till att spara utrymme, särskilt i små diagram.