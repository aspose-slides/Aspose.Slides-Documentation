---
title: "Hantera diagramdataserier i presentationer med C++"
linktitle: "Dataserier"
type: docs
url: /sv/cpp/chart-series/
keywords:
- diagramserier
- serieöverlappning
- seriefärg
- kategorifärg
- serienamn
- datapunkt
- seriegap
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du hanterar diagramserier i C++ för PowerPoint (PPT/PPTX) med praktiska kodexempel och bästa praxis för att förbättra dina datapresentationer."
---
## **Översikt**

Denna artikel beskriver rollen för [ChartSeries](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/chartseries/) i Aspose.Slides, med fokus på hur data struktureras och visualiseras i presentationer. Dessa objekt tillhandahåller de grundläggande elementen som definierar individuella uppsättningar av datapunkter, kategorier och utseendeparametrar i ett diagram. Genom att arbeta med [ChartSeries](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/chartseries/), kan utvecklare sömlöst integrera underliggande datakällor och upprätthålla full kontroll över hur information visas, vilket resulterar i dynamiska, datadrivna presentationer som tydligt förmedlar insikter och analyser.

En serie är en rad eller kolumn med siffror som plottas i ett diagram.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ange överlappning för dataserier**

Med metoden [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) kan du ange hur mycket staplar och kolumner ska överlappa i ett 2D-diagram (intervallet: -100 till 100). Denna egenskap gäller för alla serier i den överordnade seriegruppen: det är en projektion av den motsvarande gruppens egenskap.

Använd metoden `get_ParentSeriesGroup()::set_Overlap()` för att ange ditt föredragna värde för `Overlap`.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Lägg till ett grupperat kolumndiagram på en bild.
1. Få åtkomst till den första diagramserien.
1. Hämta diagramseriens `ParentSeriesGroup` och ange ditt föredragna överlappningsvärde för serien.
1. Skriv den modifierade presentationen till en PPTX-fil.

Denna C++-kod visar hur du ställer in överlappning för en diagramserie:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Lägger till diagram
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Ställer in seriernas överlappning
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Skriver presentationsfilen till disk
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **Ändra färg på dataserie**

Aspose.Slides för C++ låter dig ändra en seriefärg på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Lägg till ett diagram på bilden.
1. Hämta den serie vars färg du vill ändra.
1. Ange önskad fyllningstyp och fyllningsfärg.
1. Spara den modifierade presentationen.

Denna C++-kod visar hur du ändrar en seriefärg:

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

## **Ändra färg på en kategori i dataserie**

Aspose.Slides för C++ låter dig ändra en seriekategori vars färg på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Lägg till ett diagram på bilden.
1. Hämta den seriekategori vars färg du vill ändra.
1. Ange önskad fyllningstyp och fyllningsfärg.
1. Spara den modifierade presentationen.

Denna C++-kod visar hur du ändrar färg på en seriekategori:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Ändra namn på dataserie** 

Som standard är legendnamnen för ett diagram innehållet i cellerna ovanför varje kolumn eller rad med data. 

I vårt exempel (exempelbild), 

* kolumnerna är *Series 1, Series 2,* och *Series 3*;
* raderna är *Category 1, Category 2, Category 3,* och *Category 4.* 

Aspose.Slides för C++ låter dig uppdatera eller ändra ett serienamn i dess diagramdata och legend. 

Denna C++-kod visar hur du ändrar ett serienamn i dess diagramdata `ChartDataWorkbook`:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

Denna C++-kod visar hur du ändrar ett serienamn i dess legend via `Series`:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **Ange fyllningsfärg för dataserie**

Aspose.Slides för C++ låter dig ange den automatiska fyllningsfärgen för diagramserier i ett plotområde på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata baserat på din föredragna typ (i exemplet nedan använde vi `ChartType::ClusteredColumn`).
1. Hämta diagramserien och sätt fyllningsfärgen till Automatic.
1. Spara presentationen till en PPTX-fil.

Denna C++-kod visar hur du sätter den automatiska fyllningsfärgen för en diagramserie:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Skapar ett grupperat kolumndiagram
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Ställer in seriernas fyllningsformat till automatiskt
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Skriver presentationsfilen till disk
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **Ställ in inverterade fyllningsfärger för dataserier**

Aspose.Slides låter dig ange inverterad fyllningsfärg för diagramserier i ett plotområde på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata baserat på din föredragna typ (i exemplet nedan använde vi `ChartType::ClusteredColumn`).
1. Hämta diagramserien och sätt fyllningsfärgen till invert.
1. Spara presentationen till en PPTX-fil.

Denna C++-kod demonstrerar operationen:

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

## **Ställ in inverterad fyllningsfärg för en diagramserie**

Aspose.Slides låter dig ställa in inversioner via metoderna `IChartDataPoint::set_InvertIfNegative()` och `ChartDataPoint.set_InvertIfNegative()`. När en inversion är inställd med metoderna ändrar datapunkten sina färger när den får ett negativt värde. 

Denna C++-kod demonstrerar operationen:

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

## **Rensa specifika datapunktsvärden**

Aspose.Slides för C++ låter dig rensa `DataPoints`‑data för en specifik diagramserie på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
2. Hämta referensen till en bild via dess index.
3. Hämta referensen till ett diagram via dess index.
4. Iterera genom alla diagrammets `DataPoints` och sätt `XValue` och `YValue` till null.
5. Rensa alla `DataPoints` för specifik diagramserie.
6. Skriv den modifierade presentationen till en PPTX-fil.

Denna C++-kod demonstrerar operationen:

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

## **Ange gapbredd för dataserie**

Aspose.Slides för C++ låter dig ange en seriers Gap Width via metoden **`set_GapWidth()`** på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Få åtkomst till den första bilden.
1. Lägg till ett diagram med standarddata.
1. Hämta någon diagramserie.
1. Ange egenskapen `GapWidth`.
1. Skriv den modifierade presentationen till en PPTX-fil.

Denna C++-kod visar hur du anger en seriers Gap Width:

```cpp
// Skapar tom presentation 
auto presentation = System::MakeObject<Presentation>();

// Hämtar presentationens första bild
auto slide = presentation->get_Slides()->idx_get(0);

// Lägger till ett diagram med standarddata
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Ställer in index för diagramdatasheet
int32_t worksheetIndex = 0;

// Hämtar diagramdatas arbetsblad
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Lägger till serier
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Lägger till kategorier
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Hämtar den andra diagramserien
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// Fyller seriedata
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// Ställer in GapWidth‑värde
series->get_ParentSeriesGroup()->set_GapWidth(50);

// Sparar presentation till disk
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Finns det någon gräns för hur många serier ett enskilt diagram kan innehålla?**

Aspose.Slides har ingen fast takgräns för antalet serier du lägger till. Den praktiska takgränsen bestäms av diagrammets läsbarhet och av det minne som finns tillgängligt för din applikation.

**Vad händer om kolumnerna inom en grupp är för nära varandra eller för långt ifrån varandra?**

Justera gapbreddsinställningen för den serien (eller dess överordnade seriegrupp). Att öka värdet breddar avståndet mellan kolumnerna, medan ett lägre värde för minskar avståndet.