---
title: Diagram adat táblák testreszabása prezentációkban C++ használatával
linktitle: Adattábla
type: docs
url: /hu/cpp/chart-data-table/
keywords:
- diagram adatok
- adat tábla
- betűtípus tulajdonságok
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Testreszabja a diagram adat táblák betűtípusait, szegélyeit és jelmagyarázat kulcsait PowerPoint prezentációkban az Aspose.Slides for C++ használatával."
---
## **Áttekintés**

Az Aspose.Slides for C++ lehetővé teszi, hogy megjelenítse egy diagram adat tábláját, és testre szabja annak szövegformázását, szegélyeit és jelmagyarázat kulcsait. Ez a cikk bemutatja, hogyan engedélyezze a táblát, formázza a szöveget, irányítsa a különböző szegélytípusokat, valamint hogyan jelenítse meg vagy rejtheti el a jelmagyarázat kulcsait. A példák a beállított diagramokat PPTX fájlokba mentik.

## **Betűtípus tulajdonságok beállítása**

A diagram adat táblájának megjelenítéséhez adja át a `true` értéket a [IChart::set_HasDataTable](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/set_hasdatatable/) hívásnak. Az adat táblához való hozzáféréshez és annak szövegformázásának beállításához használja a [IChart::get_ChartDataTable](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/get_chartdatatable/) metódust.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály segítségével.  
1. Adjon hozzá egy csoportosított oszlopdiagramot az első diára.  
1. Engedélyezze a diagram adat tábláját.  
1. Félkövér szöveget engedélyezhet a [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/set_fontbold/) használatával, és a `20` értéket adja át az [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/set_fontheight/) metódusnak 20 pontos szöveghez.  
1. Mentse el a módosított prezentációt.

Az alábbi példa a munkakönyvtárban lévő `test.pptx` fájlt igényli, amelynek legalább egy diája van. Egy alapértelmezett adatokkal rendelkező diagramot ad hozzá a (50, 50) pozícióban, 600 pont szélességgel és 400 pont magassággal. A mentett `output.pptx` a diagramot tartalmazza, melynek adat táblája engedélyezve van, és a megadott betűtípus beállítások alkalmazva vannak.

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

## **Adattábla szegélyek testreszabása**

A táblát a [IChart::set_HasDataTable](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/set_hasdatatable/) segítségével engedélyezheti, és hozzáférhet a [IChart::get_ChartDataTable](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/get_chartdatatable/) metódussal. Három típusú szegélyt vezérelhet függetlenül:

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) vezérli a vízszintes cellaszegélyeket.  
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) vezérli a függőleges cellaszegélyeket.  
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) vezérli a tábla külső szegélyét.

A `true` értéket adja át minden beállítóhoz a szegélyek megjelenítéséhez, vagy a `false` értéket a rejtéshez. A következő példa egy alapértelmezett adatokkal rendelkező csoportosított oszlopdiagramot hoz létre, megjeleníti a vízszintes és a külső szegélyeket, és elrejti a függőleges szegélyeket. Nem igényel bemeneti fájlt. A diagram pozíciója és mérete pontokban van megadva.

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

Az alábbi összehasonlítás ugyanazt a diagramadatot és jelmagyarázat kulcs beállítást használja mind a négy esetben. Kezdve az összes szegéllyel engedélyezve, minden további változat csak egy szegély beállítást kapcsol ki. A bal alsó változat megfelel a példában lévő szegélybeállításoknak.

![Diagram adat táblák minden szegéllyel engedélyezve, vízszintes szegély nélkül, függőleges szegély nélkül, és külső szegély nélkül](data-table-borders.png)

## **Jelmagyarázat kulcsok megjelenítése vagy elrejtése**

A jelmagyarázat kulcsok kis színes jelölők a sorok nevei mellett az adat táblában. Segítik az olvasót, hogy a tábla sorait a diagram sorozataihoz társítsa. A `true` értéket adja át a [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) metódusnak a jelölők megjelenítéséhez vagy a `false` értéket a rejtéshez.

A diagram különálló jelmagyarázatát a [IChart::set_HasLegend](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/set_haslegend/) metódus szabályozza. Ezek a beállítások függetlenek: a különálló jelmagyarázat elrejtése nem rejti el a táblán belüli kulcsokat, és a táblán belüli kulcsok elrejtése nem rejti el a különálló jelmagyarázatot.

Az alábbi példa egy alapértelmezett adatokkal rendelkező diagramot hoz létre, engedélyezi annak adat tábláját, és megjeleníti a jelmagyarázat kulcsokat benne, miközben elrejti a különálló jelmagyarázatot. Az összes táblaszegély explicit módon engedélyezve van. Nem szükséges bemeneti prezentáció. A táblán belüli kulcsok csak elrejtéséhez adja át a `false` értéket a [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) metódusnak.

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

Az alábbi összehasonlítás ugyanazt a táblát mutatja, a jelmagyarázat kulcsok engedélyezett és letiltott állapotban. Az összes szegély továbbra is engedélyezve marad, és a különálló diagram jelmagyarázat mindkét esetben rejtve van.

![Diagram adat táblák bal oldalon megjelenített jelmagyarázat kulcsokkal és jobb oldalon rejtve](data-table-legend-keys.png)

## **GYIK**

**Megjeleníthetek jelmagyarázat kulcsokat a diagram adat táblájában?**

Igen. Adja át a `true` értéket a [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) metódusnak a jelmagyarázat kulcsok megjelenítéséhez vagy a `false` értéket a rejtésükhöz.

**Megmarad az adat tábla a prezentáció PDF, HTML vagy képek formátumba exportálásakor?**

Igen. Az Aspose.Slides a diagramot és a megjelenített adat táblát a dia részének rendereli exportáláskor [PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/hu/cpp/convert-powerpoint-to-html/) vagy [képek](/slides/hu/cpp/convert-powerpoint-to-png/) formátumba.

**Munkálhatok adat táblákkal olyan diagramokon, amelyek sablonból lettek betöltve?**

Igen. Egy meglévő prezentációból vagy sablonból betöltött diagram esetén használja a [IChart::get_HasDataTable](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/get_hasdatatable/) metódust az adat tábla megjelenítésének ellenőrzéséhez, és a [IChart::set_HasDataTable](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/set_hasdatatable/) metódust a láthatóság módosításához.

**Hogyan találhatok diagramokat, melyeknek az adat tábla engedélyezve van?**

Iteráljon a diákon lévő alakzatokon, azonosítsa a diagramokat, és ellenőrizze a [IChart::get_HasDataTable](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/get_hasdatatable/) eredményét. A `true` érték azt jelzi, hogy az adat tábla engedélyezve van.