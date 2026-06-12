---
title: Přizpůsobení os grafu v prezentacích pomocí C++
linktitle: Osa grafu
type: docs
url: /cs/cpp/chart-axis/
keywords:
- osa grafu
- svislá osa
- vodorovná osa
- přizpůsobit osu
- manipulovat osou
- spravovat osu
- vlastnosti osy
- maximální hodnota
- minimální hodnota
- čára osy
- formát data
- název osy
- pozice osy
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Objevte, jak pomocí Aspose.Slides pro C++ přizpůsobit osy grafu v prezentacích PowerPointu pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu v Aspose.Slides. Ukazuje, jak získat skutečné hodnoty os, vyměnit data mezi osami, skrýt svislou nebo vodorovnou osu u čárových grafů, změnit typ osy kategorií, nastavit formát data pro hodnoty osy kategorií, otočit název osy, nastavit polohu osy a zobrazit popisek jednotky na hodnotové ose.

## **Získání maximálních hodnot na svislé ose**
Aspose.Slides pro C++ vám umožňuje získat minimální a maximální hodnoty na svislé ose. Proveďte následující kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Přistupte k prvnímu snímku.
1. Přidejte graf s výchozími daty.
1. Získejte skutečnou maximální hodnotu na ose.
1. Získejte skutečnou minimální hodnotu na ose.
1. Získejte skutečnou hlavní jednotku osy.
1. Získejte skutečnou vedlejší jednotku osy.
1. Získejte skutečnou stupnici hlavní jednotky osy.
1. Získejte skutečnou stupnici vedlejší jednotky osy.

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

// Uloží prezentaci
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```

## **Výměna dat mezi osami**
Aspose.Slides vám umožňuje rychle vyměnit data mezi osami – data zobrazená na svislé ose (y-osa) se přesunou na vodorovnou osu (x-osa) a naopak.

Tento C++ kód ukazuje, jak provést úkol výměny dat mezi osami v grafu:

``` cpp
// Vytvoří prázdnou prezentaci
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Přepíná řádky a sloupce
chart->get_ChartData()->SwitchRowColumn();

// Uloží prezentaci
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Zakázání svislé osy u čárových grafů**
Tento C++ kód ukazuje, jak skrýt svislou osu u čárového grafu:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Zakázání vodorovné osy u čárových grafů**
Tento kód ukazuje, jak skrýt vodorovnou osu u čárového grafu:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Změna osy kategorie**
Pomocí metody **set_CategoryAxisType()** můžete zadat požadovaný typ osy kategorie (**date** nebo **text**). Tento C++ kód demonstruje operaci:

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

## **Nastavení formátu data pro hodnoty osy kategorie**
Aspose.Slides pro C++ vám umožňuje nastavit formát data pro hodnotu osy kategorie. Operace je ukázána v tomto C++ kódu:

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

## **Nastavení úhlu otočení názvu osy**
Aspose.Slides pro C++ vám umožňuje nastavit úhel otočení názvu osy grafu. Tento C++ kód demonstruje operaci:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Nastavení polohy osy na ose kategorie nebo hodnotové ose**
Aspose.Slides pro C++ vám umožňuje nastavit pozici osy v ose kategorie nebo hodnotové ose. Tento C++ kód ukazuje, jak úkol provést:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **Povolení zobrazení popisku jednotky na hodnotové ose grafu**
Aspose.Slides pro C++ vám umožňuje nastavit graf tak, aby zobrazoval popisek jednotky na své hodnotové ose grafu. Tento C++ kód demonstruje operaci:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Často kladené otázky**

**Jak nastavit hodnotu, při které se jedna osa protíná s druhou (průsečík os)?**

Osy poskytují [nastavení průsečíku](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/axis/set_crosstype/): můžete zvolit průsečík na nule, na maximální kategorii/hodnotě nebo na konkrétní číselné hodnotě. To je užitečné pro posunutí osy X nahoru nebo dolů nebo pro zdůraznění základní linie.

**Jak mohu umístit popisky značek relativně k ose (vedle, vně, uvnitř)?**

Nastavte [polohu popisku](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/axis/set_majortickmark/) na "cross", "outside" nebo "inside". To ovlivňuje čitelnost a pomáhá šetřit místo, zejména u malých grafů.