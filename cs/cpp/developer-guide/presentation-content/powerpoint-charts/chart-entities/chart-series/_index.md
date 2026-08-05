---
title: Správa datových sérií grafu v prezentacích pomocí C++
linktitle: Datové řady
type: docs
url: /cs/cpp/chart-series/
keywords:
- série grafu
- překrytí řady
- barva řady
- barva kategorie
- název řady
- datový bod
- mezera řady
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Zjistěte, jak spravovat řady grafu v C++ pro PowerPoint (PPT/PPTX) pomocí praktických ukázek kódu a osvědčených postupů pro vylepšení vašich datových prezentací."
---
## **Přehled**

Tento článek popisuje roli [ChartSeries](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts.chartseries/) v Aspose.Slides, zaměřuje se na to, jak jsou data strukturována a vizualizována v prezentacích. Tyto objekty poskytují základní prvky, které definují jednotlivé sady datových bodů, kategorie a parametry vzhledu v grafu. Prací s [ChartSeries](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts.chartseries/) mohou vývojáři snadno integrovat podkladové datové zdroje a mít plnou kontrolu nad tím, jak jsou informace zobrazeny, což vede k dynamickým, daty řízeným prezentacím, které jasně předávají postřehy a analýzy.

Řada je řádek nebo sloupec čísel vykreslených v grafu.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí datové řady**

S metodou [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) můžete určit, jak moc mají pruhy a sloupce překrývat v 2D grafu (rozsah: -100 až 100). Tato vlastnost se vztahuje na všechny řady v nadřazené skupině řad: jedná se o projekci odpovídající vlastnosti skupiny.

Použijte metodu `get_ParentSeriesGroup()::set_Overlap()` k nastavení preferované hodnoty pro `Overlap`.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Přidejte na snímek seskupený sloupcový graf.
1. Získejte první řadu grafu.
1. Získejte `ParentSeriesGroup` řady grafu a nastavte preferovanou hodnotu překrytí pro řadu.
1. Zapište upravenou prezentaci do souboru PPTX.

Tento kód v C++ ukazuje, jak nastavit překrytí pro řadu grafu:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Přidá graf
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Nastaví překrytí řady
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Zapíše soubor prezentace na disk
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **Změna barvy datové řady**

Aspose.Slides pro C++ vám umožňuje změnit barvu řady tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Přidejte graf na snímek.
1. Získejte řadu, jejíž barvu chcete změnit.
1. Nastavte požadovaný typ výplně a barvu výplně.
1. Uložte upravenou prezentaci.

Tento kód v C++ ukazuje, jak změnit barvu řady:

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

## **Změna barvy kategorie datové řady**

Aspose.Slides pro C++ vám umožňuje změnit barvu kategorie řady tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Přidejte graf na snímek.
1. Získejte kategorii řady, jejíž barvu chcete změnit.
1. Nastavte požadovaný typ výplně a barvu výplně.
1. Uložte upravenou prezentaci.

Tento kód v C++ ukazuje, jak změnit barvu kategorie řady:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Změna názvu datové řady**

Ve výchozím nastavení jsou názvy legendy pro graf obsahem buněk nad každým sloupcem nebo řádkem dat.

V našem příkladu (ukázkový obrázek),

* sloupce jsou *Series 1, Series 2,* a *Series 3*;
* řádky jsou *Category 1, Category 2, Category 3,* a *Category 4.*

Aspose.Slides pro C++ vám umožňuje aktualizovat nebo změnit název řady v datech grafu a v legendě.

Tento kód v C++ ukazuje, jak změnit název řady v datech grafu `ChartDataWorkbook`:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

Tento kód v C++ ukazuje, jak změnit název řady v legendě pomocí`Series`:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **Nastavení barvy výplně datové řady**

Aspose.Slides pro C++ umožňuje nastavit automatickou barvu výplně pro řady grafu v oblasti vykreslování tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty podle požadovaného typu (v níže uvedeném příkladu jsme použili `ChartType::ClusteredColumn`).
1. Získejte řadu grafu a nastavte barvu výplně na Automatic.
1. Uložte prezentaci do souboru PPTX.

Tento kód v C++ ukazuje, jak nastavit automatickou barvu výplně pro řadu grafu:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Vytvoří seskupený sloupcový graf
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Nastaví formát výplně řady na automatický
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Zapíše soubor prezentace na disk
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **Nastavení invertované barvy výplně datové řady**

Aspose.Slides umožňuje nastavit invertovanou barvu výplně pro řady grafu v oblasti vykreslování tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty podle požadovaného typu (v níže uvedeném příkladu jsme použili `ChartType::ClusteredColumn`).
1. Získejte řadu grafu a nastavte barvu výplně na invert.
1. Uložte prezentaci do souboru PPTX.

Tento kód v C++ demonstruje operaci:

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Přidá nové řady a kategorie
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Vezme první řadu grafu a naplní její data.
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

## **Nastavení invertované barvy výplně pro řadu grafu**

Aspose.Slides vám umožňuje nastavit invertování pomocí metod `IChartDataPoint::set_InvertIfNegative()` a `ChartDataPoint.set_InvertIfNegative()`. Když je invertování nastaveno pomocí těchto metod, datový bod invertuje své barvy, pokud získá zápornou hodnotu.

Tento kód v C++ demonstruje operaci:

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

## **Vymazání konkrétních hodnot datových bodů**

Aspose.Slides pro C++ vám umožňuje vymazat data `DataPoints` pro konkrétní řadu grafu tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Získejte referenci na graf pomocí jeho indexu.
4. Projděte všechny `DataPoints` grafu a nastavte `XValue` a `YValue` na null.
5. Vymažte všechny `DataPoints` pro konkrétní řadu grafu.
6. Zapište upravenou prezentaci do souboru PPTX.

Tento kód v C++ demonstruje operaci:

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

## **Nastavení šířky mezery datové řady**

Aspose.Slides pro C++ umožňuje nastavit šířku mezery řady pomocí metody **`set_GapWidth()`** následujícím způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Získejte první snímek.
1. Přidejte graf s výchozími daty.
1. Získejte libovolnou řadu grafu.
1. Nastavte vlastnost `GapWidth`.
1. Zapište upravenou prezentaci do souboru PPTX.

Tento kód v C++ ukazuje, jak nastavit šířku mezery řady:

```cpp
// Vytvoří prázdnou prezentaci
auto presentation = System::MakeObject<Presentation>();

// Získá první snímek prezentace
auto slide = presentation->get_Slides()->idx_get(0);

// Přidá graf s výchozími daty
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Nastaví index listu s daty grafu
int32_t worksheetIndex = 0;

// Získá list s daty grafu
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Přidá řady
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Přidá kategorie
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Vybere druhou řadu grafu
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// Naplní data řady
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// Nastaví hodnotu GapWidth
series->get_ParentSeriesGroup()->set_GapWidth(50);

// Uloží prezentaci na disk
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **Často kladené otázky**

**Existuje limit na počet řad, které může jeden graf obsahovat?**

Aspose.Slides neukládá žádný pevný limit na počet řad, které můžete přidat. Praktický limit je dán čitelností grafu a množstvím paměti dostupné vaší aplikaci.

**Co když jsou sloupce v rámci clustera příliš blízko u sebe nebo naopak příliš daleko?**

Upravte nastavení šířky mezery pro tuto řadu (nebo její nadřazenou skupinu řad). Zvýšením hodnoty zvětšíte vzdálenost mezi sloupci, snížením ji přiblížíte.