---
title: "Přizpůsobení tabulek dat grafů v prezentacích pomocí C++"
linktitle: "Datová tabulka"
type: docs
url: /cs/cpp/chart-data-table/
keywords:
- "data grafu"
- "datová tabulka"
- "vlastnosti písma"
- "PowerPoint"
- "prezentace"
- "C++"
- "Aspose.Slides"
description: "Přizpůsobte písma, okraje a legendární klíče tabulky dat grafu v prezentacích PowerPoint pomocí Aspose.Slides pro C++."
---
## **Přehled**

Aspose.Slides pro C++ umožňuje zobrazit tabulku dat grafu a přizpůsobit její formátování textu, okraje a legendární klíče. Tento článek vysvětluje, jak povolit tabulku, formátovat text, řídit jednotlivé typy okrajů a zobrazit nebo skrýt legendární klíče. Příklady ukládají nakonfigurované grafy do souborů PPTX.

## **Nastavení vlastností písma**

Chcete‑li zobrazit tabulku dat grafu, předávejte `true` metodě [IChart::set_HasDataTable](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichart/set_hasdatatable/). K přístupu k tabulce a nastavení formátování textu použijte [IChart::get_ChartDataTable](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichart/get_chartdatatable/).

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Přidejte seskupený sloupcový graf na první snímek.
1. Povolte tabulku dat grafu.
1. Povolte tučný text pomocí [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseportionformat/set_fontbold/) a předávejte `20` metodě [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseportionformat/set_fontheight/) pro text o velikosti 20 bodů.
1. Uložte upravenou prezentaci.

Následující příklad vyžaduje soubor `test.pptx` v pracovním adresáři s alespoň jedním snímkem. Přidá graf s výchozími daty na pozici (50, 50) se šířkou 600 bodů a výškou 400 bodů. Uložený soubor `output.pptx` obsahuje graf s povolenou tabulkou dat a aplikovaným nastavením písma.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto portionFormat = chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat();
portionFormat->set_FontBold(NullableBool::True);
portionFormat->set_FontHeight(20.0f);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Přizpůsobení okrajů tabulky dat**

Povolit tabulku lze pomocí [IChart::set_HasDataTable](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichart/set_hasdatatable/) a získat ji přes [IChart::get_ChartDataTable](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichart/get_chartdatatable/). Tři typy okrajů můžete řídit nezávisle:

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) řídí vodorovné okraje buněk.
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) řídí svislé okraje buněk.
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) řídí vnější okraj tabulky.

Předávejte `true` každému nastavenému metodě pro zobrazení okrajů nebo `false` pro jejich skrytí. Následující příklad vytvoří seskupený sloupcový graf s výchozími daty, zobrazí vodorovné okraje a vnější okraj a skryje svislé okraje. Nevyžaduje žádný vstupní soubor. Pozice a velikost grafu jsou zadány v bodech.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(false);
dataTable->set_HasBorderOutline(true);

presentation->Save(u"data-table-borders.pptx", SaveFormat::Pptx);
```

Porovnání níže používá stejná data grafu a nastavení legendárního klíče ve všech čtyřech případech. Začíná se se všemi okraji povolenými; každý další variant vypíná právě jeden typ okraje. Varianta vlevo dole odpovídá nastavení okrajů v příkladu.

![Grafy s tabulkami dat se všemi okraji povoleny, bez vodorovných okrajů, bez svislých okrajů a bez vnějšího okraje](data-table-borders.png)

## **Zobrazit nebo skrýt legendární klíče**

Legendární klíče jsou malé barevné značky vedle názvů řad v tabulce dat. Pomáhají čtenářům přiřadit každý řádek tabulky k odpovídající řadě grafu. Předávejte `true` metodě [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) pro zobrazení těchto značek nebo `false` pro jejich skrytí.

Samostatná legenda grafu se řídí metodou [IChart::set_HasLegend](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichart/set_haslegend/). Tato nastavení jsou nezávislá: skrytí samostatné legendy neskrývá klíče v tabulce dat a skrytí klíčů v tabulce neskrývá samostatnou legendu.

Následující příklad vytvoří graf s výchozími daty, povolí jeho tabulku dat a zobrazí legendární klíče uvnitř ní, zatímco skryje samostatnou legendu. Všechny okraje tabulky jsou výslovně povoleny. Není vyžadována žádná vstupní prezentace. Pro skrytí pouze klíčů v tabulce předávejte `false` metodě [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/idatatable/set_showlegendkey/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);
chart->set_HasLegend(false);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(true);
dataTable->set_HasBorderOutline(true);
dataTable->set_ShowLegendKey(true);

presentation->Save(u"data-table-legend-keys.pptx", SaveFormat::Pptx);
```

Porovnání níže ukazuje stejnou tabulku s povolenými a zakázanými legendárními klíči. Všechny okraje zůstávají povoleny a samostatná legenda grafu je skryta v obou případech.

![Grafy s tabulkami dat, kde jsou legendární klíče zobrazeny vlevo a skryty vpravo](data-table-legend-keys.png)

## **Často kladené otázky**

**Mohu zobrazit legendární klíče v tabulce dat grafu?**

Ano. Předávejte `true` metodě [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) pro zobrazení legendárních klíčů nebo `false` pro jejich skrytí.

**Zůstane tabulka dat zachována při exportu prezentace do PDF, HTML nebo obrázků?**

Ano. Aspose.Slides vykreslí graf a jeho zobrazenou tabulku dat jako součást snímku při exportu do [PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/cs/cpp/convert-powerpoint-to-html/) nebo [obrázků](/slides/cs/cpp/convert-powerpoint-to-png/).

**Mohu pracovat s tabulkami dat v grafech načtených ze šablony?**

Ano. Pro graf načtený z existující prezentace nebo šablony použijte [IChart::get_HasDataTable](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichart/get_hasdatatable/) ke kontrole, zda je tabulka dat zobrazena, a [IChart::set_HasDataTable](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichart/set_hasdatatable/) ke změně její viditelnosti.

**Jak mohu najít grafy, u nichž je tabulka dat povolena?**

Procházejte tvary na každém snímku, identifikujte grafy a zkontrolujte jejich výsledek metody [IChart::get_HasDataTable](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichart/get_hasdatatable/). Hodnota `true` značí, že je tabulka dat povolena.