---
title: Přizpůsobení legend grafů v prezentacích pomocí C++
linktitle: Legenda grafu
type: docs
url: /cs/cpp/chart-legend/
keywords:
- legenda grafu
- pozice legendy
- velikost písma
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Přizpůsobte legendy grafů pomocí Aspose.Slides pro C++ a optimalizujte prezentace PowerPoint s nastaveným formátováním legend."
---
## **Přehled**

Aspose.Slides for C++ poskytuje možnosti přizpůsobení legend grafů v prezentacích PowerPoint. Tento článek ukazuje, jak nastavit pozici a velikost legendy, nastavit velikost písma pro celou legendu, formátovat jednotlivý položku legendy a skrýt nebo obnovit vybrané položky.

Často kladené otázky (FAQ) zahrnují související chování, včetně rezervace místa pro legendu, zobrazení víceřádkových popisků a dědění formátování z motivu prezentace.

## **Umístění legendy**

Použijte metody legendy [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_x/), [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_y/), [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_width/) a [set_Height](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_height/) k určení její pozice a velikosti jako zlomků rozměrů grafu.

Tento příklad vytváří prezentaci a přidává seskupený sloupcový graf s výchozími daty na první snímek. Rozdělením požadovaných posunů a rozměrů legendy šířkou a výškou grafu se převedou na relativní hodnoty: legenda je posunuta o 50 bodů od levého horního rohu grafu a má velikost 100 × 100 bodů.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

// Vyjádřete pozici a velikost legendy relativně k grafu.
chart->get_Legend()->set_X(50 / chart->get_Width());
chart->get_Legend()->set_Y(50 / chart->get_Height());
chart->get_Legend()->set_Width(100 / chart->get_Width());
chart->get_Legend()->set_Height(100 / chart->get_Height());

presentation->Save(u"legend_position.pptx", SaveFormat::Pptx);
```

## **Nastavení velikosti písma legendy**

Použijte legendu [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_textformat/) pro přístup k formátování textu a [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) pro nastavení velikosti písma v bodech.

Tento příklad vytváří graf s výchozími daty a nastavuje text legendy na 20 bodů. Také zakazuje automatické ohraničení pro svislou osu a nastavuje její rozsah od -5 do 10.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(-5);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MaxValue(10);

presentation->Save(u"legend_font_size.pptx", SaveFormat::Pptx);
```

## **Nastavení velikosti písma jednotlivé položky legendy**

Použijte kolekci vrácenou metodou legendy [get_Entries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_entries/) pro přístup k formátování konkrétní položky. Indexy položek jsou nulové, takže index `1` odkazuje na druhou položku.

Tento příklad vytváří seskupený sloupcový graf, jehož výchozí data obsahují alespoň dvě řady. Formátuje druhou položku legendy tučným, kurzívovým a modrým textem o velikosti 20 bodů.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/ILegendEntryCollection.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
auto textFormat = chart->get_Legend()->get_Entries()->idx_get(1)->get_TextFormat();

textFormat->get_PortionFormat()->set_FontBold(NullableBool::True);
textFormat->get_PortionFormat()->set_FontHeight(20);
textFormat->get_PortionFormat()->set_FontItalic(NullableBool::True);
textFormat->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
textFormat->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

presentation->Save(u"legend_entry_format.pptx", SaveFormat::Pptx);
```

## **Skrytí jednotlivých položek legendy**

Chcete-li vyloučit pomocnou řadu z legendy při zachování viditelnosti jejích dat, zavolejte [ILegendEntryProperties::set_Hide](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegendentryproperties/set_hide/) s hodnotou `true` přes [IChartSeries::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_relatedlegendentry/). Tím se skryje pouze vybraná položka legendy; řada ani její datové body nebudou odstraněny. Volání [IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/) s hodnotou `false` naproti tomu skryje celou legendu.

Níže uvedený příklad vytvoří seskupený sloupcový graf s několika řadami pomocí výchozích dat. Skryje položku legendy druhé řady (index `1`) a uloží prezentaci. Poté položku obnoví voláním `set_Hide` s `false` a uloží druhou kopii. Sloupce zůstanou viditelné v obou souborech.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
chart->set_HasLegend(true);

auto legendEntry = chart->get_ChartData()->get_Series()->idx_get(1)->get_RelatedLegendEntry();

legendEntry->set_Hide(true);
presentation->Save(u"hidden_legend_entry.pptx", SaveFormat::Pptx);

// Obnovit stejnou položku bez změny dat grafu.
legendEntry->set_Hide(false);
presentation->Save(u"restored_legend_entry.pptx", SaveFormat::Pptx);
```

Porovnání níže ukazuje stejný graf se všemi položkami legendy viditelnými a s druhou položkou skrytou. Sloupce druhé řady zůstávají nezměněny.

![Porovnání grafu se všemi položkami legendy viditelnými a s druhou položkou skrytou; všechny sloupce zůstávají viditelné.](hide-legend-entry.png)

Ve sloupcových, pruhových a čárových grafech položky legendy identifikují řady. V koláčových grafech identifikují jednotlivé datové body (výseče), takže použijte [IChartDataPoint::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_relatedlegendentry/) na vybrané výseči. API dokumentuje tuto metodu datového bodu pro typy grafů `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` a `BarOfPie`. Nepředpokládejte, že platí pro prstencové grafy, které v tom seznamu nejsou.

## **Často kladené otázky**

**Mohu nechat graf rezervovat místo pro legendu místo jejího překrytí?**

Ano. Zavolejte [set_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/) s hodnotou `false`, aby byl rezervován prostor pro legendu místo povolení překrytí vykreslovací oblasti.

**Mohu mít víceliniové popisky legendy?**

Ano. Dlouhé popisky se mohou zalomit, pokud je dostupná šířka nedostatečná. Můžete také použít znak nového řádku v názvech řad pro požadování zalomení řádku.

**Jak zajistit, aby legenda používala barevné schéma motivu prezentace?**

Nechte barvy, výplně a písma legendy nenastavené, aby mohla dědit formátování motivu. Explicitní formátování přepíše odpovídající nastavení motivu.