---
title: Přizpůsobení os grafu v prezentacích pomocí C++
linktitle: Osa grafu
type: docs
url: /cs/cpp/chart-axis/
keywords:
- osa grafu
- svislá osa
- vodorovná osa
- přizpůsobení osy
- manipulace s osou
- správa osy
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
description: "Objevte, jak pomocí Aspose.Slides pro C++ přizpůsobit osy grafů v PowerPoint prezentacích pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu pomocí Aspose.Slides pro C++. Popisuje vypočítané hodnoty os, přepínání řádků a sloupců grafu, viditelnost os, intervaly popisků kategorií a značek os, datumové kategorie a formátování, otočení názvu, umístění os, jednotky zobrazení a logaritmické škálování.

## **Získání maximálních hodnot na vertikální ose v grafech**

Vytvořte [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) a přidejte plošný graf s výchozími daty. Zavolejte [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) před čtením vypočítaných hodnot os, aby byl rozvržení grafu aktuální.

Načtěte [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) a [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) pro limity osy a [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) a [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) pro intervaly značek. [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) a [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) poskytují měřítka časových jednotek, což je relevantní pro datumové osy. Příklad uloží tyto hodnoty do lokálních proměnných a uloží graf.

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

## **Prohození dat mezi osami**

Použijte [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) k výměně rolí řad a kategorií v datech grafu. Každá bývalá kategorie se stane řadou a každá bývalá řada se stane kategorií. Tím se změní způsob seskupování dat; neprohodí se vodorovná a svislá osa. Příklad používá [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) pro navázání výchozích dat na `Sheet1!A1:D5`, včetně řádku záhlaví a sloupce kategorií, před výměnou řádků a sloupců. Uloží graf se čtyřmi řadami a třemi kategoriemi.

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

## **Obrácení pořadí vykreslování osy**

Použijte [set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) k obrácení pořadí řazení kategorií nebo hodnotové osy. Například vodorovný sloupcový graf může zobrazovat fáze projektu odshora dolů ve stejném pořadí jako v listu: Plánování, Vývoj, Testování. Obrácení osy mění směr vykreslování; neřadí ani nepřeskupuje data v sešitu. Naopak, [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) vymění role řad a kategorií.

Následující příklad vytvoří vodorovný pruhový graf se třemi fázemi a jednou řadou. Uloží prezentaci se třemi snímky: normální pořadí, obrácené kategorie a obrácené hodnoty. Každá kopie používá stejný datový soubor a na každé kopii je obrácena pouze jedna osa.

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

// Snímek 2: zobrazit první kategorii nahoře.
auto categorySlide = presentation->get_Slides()->AddClone(slide);
auto categoryChart = System::ExplicitCast<IChart>(categorySlide->get_Shape(0));
categoryChart->get_Axes()->get_VerticalAxis()->set_IsPlotOrderReversed(true);
// Udržet vodorovnou hodnotovou osu dole.
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// Snímek 3: obrátit pouze vodorovnou číselnou stupnici.
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

Obrácení osy může také přesunout kolmá osu na opačnou stranu grafu. [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) určuje, kde druhá osa protíná konfigurovanou osu. Ve snímku 2, nastavením na `Maximum` na obrácené ose kategorií, zůstane vodorovná hodnotová osa ve spodní části. Pro konkrétní průsečík použijte [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Zkontrolujte nastavení průsečíků při změně směru, zejména pokud má graf již vlastní průsečík. Zavolejte `set_IsPlotOrderReversed` s `false` pro obnovení normálního směru vykreslování; nastavení průsečíků jsou samostatná.

| Normální pořadí (snímek 1) | Obrácené kategorie (snímek 2) | Obrácené hodnoty (snímek 3) |
| --- | --- | --- |
| ![Vodorovný pruhový graf s normálním pořadím os kategorií a hodnot](axis-order-normal.png) | ![Vodorovný pruhový graf s kategoriemi zobrazenými shora dolů](axis-order-categories-reversed.png) | ![Vodorovný pruhový graf s obrácenou hodnotovou osou a nulou vpravo](axis-order-values-reversed.png) |
| Kategorie běží zdola nahoru; hodnoty rostou zleva doprava. | Plánování, Vývoj a Testování probíhají shora dolů. Hodnoty a pořadí řádků sešitu zůstávají stejné. | Kategorie zachovávají své normální pořadí; hodnoty rostou zprava doleva. Osa kategorií se protíná v nule vpravo. |

## **Zakázání vertikální osy pro čárové grafy**

Použijte [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) s hodnotou `false` na svislé ose, aby ji skryl. Příklad vytvoří čárový graf s výchozími daty a uloží jej se skrytou svislou osou.

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

## **Zakázání horizontální osy pro čárové grafy**

Použijte [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) s hodnotou `false` na vodorovné ose, aby ji skryl. Příklad vytvoří čárový graf s výchozími daty a uloží jej se skrytou vodorovnou osou.

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

## **Změna osy kategorií**

Použijte [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) k výběru datumové nebo textové osy kategorií. Tento příklad vyžaduje `ExistingChart.pptx`, kde je graf první tvarem na prvním snímku a buňky kategorií obsahují číselné datumové hodnoty Excelu. Změní vodorovnou osu na datumovou osu. Voláním [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) s `false`, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) s `1` a [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) s měsíci umístí hlavní značky v měsíčních intervalech.

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

## **Ovládání intervalů popisků osy kategorií**

Pokud má graf mnoho kategorií, snižte počet viditelných popisků osy, aniž byste odstraňovali kategorie nebo datové body. Použijte [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) s `false` a poté [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) s požadovaným intervalem kategorií. Pro textové kategorie v jejich normálním pořadí se číslování začíná od první kategorie:

| Interval | Popisky zobrazené v příkladu |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, ... Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, ... Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, ... Kategorie 22 |

Interval `3` zobrazí každý třetí popisek a mezi zobrazenými popisky budou dva skryté. Neodstraňuje odpovídající sloupce. Automatické rozestupy volí interval podle dostupného prostoru; nemusí zobrazovat každý popisek.

Značky mají samostatné ovládání. Použijte [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) s `false` a [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) pro nastavení jejich intervalu. Například `1` ponechá značku na každém intervalu kategorií, zatímco popisky se zobrazí jen každou třetí kategorií. Použijte [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) s viditelným stylem, abyste viděli výsledek. Nastavením kterékoliv automatické vlastnosti zpět na `true` nechá graf znovu zvolit interval.

Následující samostatný příklad vytvoří 24 kategorií a jednu řadu, poté uloží tři snímky v `CategoryAxisIntervals.pptx`: automatické rozestupy, ruční rozestupy popisků s nezávislými značkami a obnovené automatické rozestupy. Obě kopie zachovají původní data grafu. Vstupní prezentace není vyžadována. Text popisků na vodorovné ose usnadňuje rozeznání hustoty.

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

**Automatické rozestupy (snímek 1):** V tomto zobrazení je každá druhá kategorie zobrazena a zalamuje se do dvou řádků. Automatický výsledek se může lišit podle velikosti grafu, písem a rendereru.

![Automatické rozestupy popisků kategorií se všemi 24 sloupci viditelnými](category-axis-automatic.png)

**Manuální rozestupy (snímek 2):** Každý třetí popisek je zobrazen na jednom řádku, zatímco značky zůstávají na každém intervalu kategorií. Všechny 24 sloupců, včetně těch bez popisků, zůstávají viditelné se stejnými hodnotami. Snímek 3 obnovuje automatický vzhled uvedený výše.

![Manuální interval popisků kategorií tři se všemi 24 sloupci viditelnými](category-axis-manual.png)

### **Vyberte správnou osu a interval**

Použijte tento interval počtu kategorií pro textovou osu kategorií, například osu kategorií sloupcového, čárového, plošného nebo pruhového grafu. V sloupcovém grafu je to vodorovná osa. Ve vodorovném pruhovém grafu je osa kategorií svislá, takže tato nastavení aplikujte na [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Rozestupy značek se také vztahují na osu řad v grafech, které ji mají.

Nepoužívejte rozestup popisků kategorií k nastavení číselné škály hodnotové osy. Na hodnotové ose [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) určuje rozdíl hodnot: např. hlavní jednotka `10` vytvoří značky na 0, 10, 20 atd., pokud osa začíná nulou. Interval popisků kategorií `3` počítá pozice kategorií bez ohledu na jejich hodnoty. Bodové a bublinové grafy používají hodnotové osy místo textové osy kategorií. Pro datumovou osu použijte časové hlavní jednotky a měřítka popsaná v [Změna osy kategorií](#change-a-category-axis).

## **Nastavení formátu data pro hodnoty osy kategorií**

Příklad nahradí výchozí data grafu čtyřmi ročními hodnotami. Data jsou uložena jako sériová čísla OLE Automation v první tabulce (index `0`). Použijte [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) k výběru datumové osy, vypněte formátování propojené se zdrojem pomocí [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/), a přiřaďte `yyyy` pomocí [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/), aby popisky kategorií zobrazovaly čtyřciferné roky nezávisle na formátování buňky.

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

## **Nastavení úhlu otočení názvu osy grafu**

Povolte název svislé osy pomocí [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/), zadejte text názvu a použijte [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) k otočení názvu. Úhel se měří ve stupních; tento příklad uloží sloupcový graf s nímoto názvem osy hodnot otočeným o 90 stupňů.

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

## **Nastavení pozice osy na ose kategorií nebo hodnot**

Použijte [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) k určení, zda hodnotová osa protíná osu kategorií mezi kategoriemi nebo na značkách kategorií. Tato vlastnost se vztahuje na osy kategorií. Příklad nastaví hodnotu na `true` na vodorovné ose kategorií sloupcového grafu a uloží výsledek.

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

## **Nastavení zobrazovací jednotky na hodnotové ose grafu**

Použijte [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) k měřítku popisků na hodnotové ose bez změny základních dat. S [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) nastaveným na `Millions` se hodnota 60 000 000 zobrazí jako 60. Příklad vytvoří sloupcový graf a použije jednotku miliony na její svislé ose.

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

## **Konfigurace logaritmické hodnotové osy**

Logaritmická hodnotová osa je užitečná, když kladné hodnoty pokrývají několik řádů velikosti. Například služba může během pěti období obdržet 10, 100, 1 000, 10 000 a 100 000 požadavků. Na lineární stupnici jsou menší hodnoty blízko nuly. Logaritmická stupnice usnadňuje porovnání relativního růstu: stejné vzdálenosti představují stejné poměry místo stejných rozdílů.

Voláním [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) s `true` na hodnotové ose a použitím [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) vyberete základ. Tím se změní způsob zobrazení existujících hodnot; data se nemění a nepřidá se logaritmická trendová čára. Trendová čára představuje vhodný vztah v datech a je samostatná funkce.

### **Vyberte hodnotovou osu a základ**

U čárového nebo sloupcového grafu je hodnotová osa [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). U vodorovného pruhového grafu je to [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/). Bodové a bublinové grafy mají dvě hodnotové osy, takže pro X‑hodnoty vyberte vodorovnou osu, pro Y‑hodnoty svislou, nebo obě. Nepoužívejte logaritmické škálování na ose kategorií.

Výchozí logaritmický základ je `10`. Pro PPTX grafy lze použít základ od `2` do `1000` včetně; podporovány jsou i zlomkové základy jako `2.5`. Se základem `10` jsou po sobě jdoucí mocniny 10, 100, 1 000, 10 000 rovnoměrně rozmístěny.

### **Porovnání lineárního a logaritmického škálování**

Následující samostatný příklad vytvoří čárový graf s pěti počty požadavků na prvním snímku, poté klonuje tento snímek a povolí logaritmickou hodnotovou osu s bází 10 na druhém. Oba snímky zachovají stejná data.

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

// Udržte první snímek lineární a změňte pouze měřítko hodnotové osy ve zkopírovaném snímku.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**Lineární škála (snímek 1):** Rovné svislé vzdálenosti představují stejné rozdíly v počtech požadavků. Největší hodnota dominuje grafu, což ztěžuje rozlišení menších hodnot.

![Čárový graf v PowerPointu zobrazující pět počtů požadavků na lineární hodnotové ose](value-axis-linear.png)

**Logaritmická škála (snímek 2):** Rovné svislé vzdálenosti představují stejné poměry. Každé období má desetkrát více požadavků než předchozí, takže body tvoří rovnou stoupající čáru na bázi 10. Popisky osy stále ukazují původní počty požadavků.

![Stejných pět požadavků v PowerPointu na logaritmické hodnotové ose s bází 10](value-axis-logarithmic.png)

### **Zpracování nulových a záporných hodnot**

Logaritmická stupnice může zobrazovat pouze striktně kladné hodnoty. Zkontrolujte data před jejím zapnutím. Pokud jsou nula nebo záporné hodnoty důležité, zachovejte lineární stupnici nebo je zobrazte samostatně. Pokud je jejich vyloučení vhodné, vysvětlete vynechání. Neskrývejte je tiše nahrazením malými kladnými čísly, protože to mění význam dat. Jakékoli ručně nastavené minimum nebo maximum pro logaritmickou osu musí být také kladné.

## **Často kladené otázky**

**Jak nastavit hodnotu, kde se jedna osa protíná s druhou (průsečík osy)?**

Použijte [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) k výběru chování průsečíku. Pro zadání číselné hodnoty průsečíku použijte [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Tato nastavení umožňují přesunout průsečík osy na vhodnou základnu.

**Jak mohu umístit popisky značek relativně k ose?**

Použijte [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) s hodnotou z [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` nebo `None`. Pro řízení samotných značek použijte [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) nebo [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/); jsou oddělené od umístění popisků.