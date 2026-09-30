---
title: Diagram jelmagyarázat testreszabása prezentációkban C++ használatával
linktitle: Diagram jelmagyarázat
type: docs
url: /hu/cpp/chart-legend/
keywords:
- diagram jelmagyarázat
- jelmagyarázat helye
- betűméret
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Testreszabja a diagram jelmagyarázatokat az Aspose.Slides for C++ használatával, hogy a PowerPoint prezentációkat az egyedi jelmagyarázat formázással optimalizálja."
---
## **Áttekintés**

Az Aspose.Slides for C++ lehetőséget biztosít a diagram jelmagyarázatának testreszabására a PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan lehet elhelyezni és méretezni a jelmagyarázatot, beállítani a teljes jelmagyarázat betűméretét, formázni egy adott jelmagyarázat bejegyzést, valamint elrejteni vagy visszaállítani a kiválasztott bejegyzéseket.

A GYIK a kapcsolódó viselkedéseket is lefedi, beleértve a jelmagyarázat számára fenntartott helyet, a több soros címkék megjelenítését és a formázás öröklődését a prezentáció témájából.

## **Jelmagyarázat elhelyezése**

Használd a jelmagyarázat [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_x/), [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_y/), [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_width/) és [set_Height](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_height/) metódusait a pozíció és a méret meghatározásához a diagram méretének törtarányaként.

Ez a példa egy prezentációt hoz létre, és egy alapértelmezett adatú összegzett oszlopdiagramot ad az első diára. A kívánt jelmagyarázat eltolásokat és méreteket a diagram szélességével és magasságával elosztva relatív értékké alakítja: a jelmagyarázat 50 ponttal eltolódik a diagram bal‑felső sarkától, és 100 × 100 pont méretű lesz.

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

// Express the legend's position and size relative to the chart.
chart->get_Legend()->set_X(50 / chart->get_Width());
chart->get_Legend()->set_Y(50 / chart->get_Height());
chart->get_Legend()->set_Width(100 / chart->get_Width());
chart->get_Legend()->set_Height(100 / chart->get_Height());

presentation->Save(u"legend_position.pptx", SaveFormat::Pptx);
```

## **Jelmagyarázat betűméretének beállítása**

Használd a jelmagyarázat [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_textformat/) metódusát a szövegformázás eléréséhez, és a [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) metódust a betűméret pontban történő beállításához.

Ez a példa egy alapértelmezett adatú diagramot hoz létre, és a jelmagyarázat szövegét 20 pontra állítja. Emellett letiltja a függőleges tengely automatikus határait, és -5‑től 10‑ig terjedő tartományt állít be.

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

## **Egyedi jelmagyarázat bejegyzés betűméretének beállítása**

Használd a jelmagyarázat [get_Entries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_entries/) metódusa által visszaadott gyűjteményt egy adott bejegyzés formázásához. A bejegyzések indexelése nullától indul, így a `1` index a második bejegyzésre vonatkozik.

Ez a példa egy alapértelmezett adatú, több sorozattal rendelkező összegzett oszlopdiagramot hoz létre. A második jelmagyarázat bejegyzést félkövér, dőlt és 20 pontos kék szöveggel formázza.

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

## **Egyéni jelmagyarázat bejegyzések elrejtése**

Egy segédsorozat kizárásához a jelmagyarázatból, miközben az adat továbbra is látható, hívd meg az [ILegendEntryProperties::set_Hide](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegendentryproperties/set_hide/) metódust `true` értékkel a [IChartSeries::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_relatedlegendentry/) segítségével. Ez csak a kiválasztott bejegyzést rejti el; a sorozatot vagy adatpontjait nem távolítja el. Ezzel szemben az [IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/) `false` értékkel való hívása az egész jelmagyarázatot elrejti.

Az alábbi példa egy több sorozatos, alapértelmezett adatú összegzett oszlopdiagramot hoz létre. A második sorozat jelmagyarázat bejegyzését (index `1`) elrejti, majd menti a prezentációt. Ezután a bejegyzést `set_Hide` `false` értékkel visszaállítja, és egy második példányt ment el. A oszlopok mindkét fájlban láthatóak maradnak.

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

// Visszaállítja ugyanazt a bejegyzést a diagram adatainak módosítása nélkül.
legendEntry->set_Hide(false);
presentation->Save(u"restored_legend_entry.pptx", SaveFormat::Pptx);
```

Az alábbi összehasonlítás ugyanazt a diagramot mutatja, egyszer az összes bejegyzéssel látható állapotban, egyszer a második bejegyzés elrejtve. A második sorozat oszlopai változatlanok maradnak.

![Diagram összehasonlítása, ahol minden jelmagyarázat bejegyzés látható, illetve a 2. sorozat bejegyzése el van rejtve; az összes oszlop látható marad.](hide-legend-entry.png)

Oszlop-, sáv- és vonaldiagramok esetén a jelmagyarázat bejegyzések a sorozatokat azonosítják. Kördiagramok esetén egyedi adatpontokat (szeleteket) azonosítanak, ezért ilyenkor a [IChartDataPoint::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_relatedlegendentry/) metódust kell a kiválasztott szeleten használni. Az API dokumentálja ezt a pont‑szintű metódust a `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` és `BarOfPie` diagramtípusokhoz. Ne feltételezd, hogy ez a módszer a gyűrűdiagramokra is vonatkozik, mivel azok nincsenek a felsoroltak között.

## **GYIK**

**Kijelenthetem, hogy a diagram helyet foglaljon a jelmagyarázatnak az átfedés helyett?**

Igen. Hívd meg a [set_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/) metódust `false` értékkel, hogy a jelmagyarázat számára helyet reserválj, ahelyett, hogy átfedné a diagramterületet.

**Létrehozhatok több soros jelmagyarázat címkéket?**

Igen. A hosszú címkék megtörnek, ha a rendelkezésre álló szélesség nem elegendő. Új sor karaktereket is használhatsz a sorozatnevekben a sortörés kérése érdekében.

**Hogyan tehetem, hogy a jelmagyarázat kövesse a prezentáció téma színsémáját?**

Hagyd a jelmagyarázat színeit, kitöltéseit és betűtípusait beállítatlanul, hogy örökölje a téma formázását. Az explicit formázás felülírja a megfelelő téma beállításokat.