---
title: 3D diagramok testreszabása prezentációkban C++-val
linktitle: 3D diagram
type: docs
url: /hu/cpp/3d-chart/
keywords:
- 3D diagram
- forgatás
- mélység
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Készítsen 3D diagramokat PowerPoint prezentációkban az Aspose.Slides for C++ segítségével. Állítsa be a forgatást, a magasságarányokat, a diagram mélységét és a sorozatok közötti távolságot C++ példákkal."
---
## **Áttekintés**

Az Aspose.Slides for C++ lehetővé teszi, hogy testreszabja egy 3D diagram nézetét a [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/). Ez a cikk bemutatja, hogyan állíthatja be a forgatást, a magasságarányokat, a mélységet, a derékszögű tengelyeket és a sorozatok közötti távolságot, majd mentse a bemutatót PPTX formátumban.

## **Állítsa be a 3D diagram forgatását és mélységét**

Az alábbi példa létrehoz egy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) és a [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) használatával egy rétegezett 3D oszlopdiagramot ad az első diájához. Lecseréli az alapértelmezett sorozatokat és kategóriákat két sorozatra, amelyek mindegyike három értéket tartalmaz. A `0` munkalap-index a diagram első adatmunkalapját jelöli; a `0` sor a sorozatneveket, az `0` oszlop pedig a kategóriacímkéket tartalmazza.

A [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) és a [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) metódusok a diagram forgatását 40 illetve 270 fokra állítják. A [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) 150 %-ra állítja a mélységet a szélességhez képest, míg a [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) jobb szögű tengelyeket engedélyez perspektíva helyett. Az eredményül kapott bemutató a kitöltött diagramot tartalmazza ezekkel a 3D nézetbeállításokkal.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

double values[2][3] = { { 20, 50, 30 }, { 30, 10, 60 } };

for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    auto categoryName = String::Format(u"Category {0}", categoryIndex + 1);
    auto categoryCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, 0, ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

for (auto seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    auto seriesName = String::Format(u"Series {0}", seriesIndex + 1);
    auto seriesCell = workbook->GetCell(worksheetIndex, 0, seriesIndex + 1, ObjectExt::Box(seriesName));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, chart->get_Type());

    for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        auto valueCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, ObjectExt::Box(values[seriesIndex][categoryIndex]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }
}

chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(270);
chart->get_Rotation3D()->set_DepthPercents(150);

presentation->Save(u"Rotation3D_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Állítsa be a 3D diagram magasságarányait**

Használja a [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) metódust a 3D diagram magasságának a szélesség százalékában való beállításához. Ez a 3D jelenet arányait módosítja anélkül, hogy átméretezné a diagram objektumát a dián.

Az alábbi példa egy [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) diagramot hoz létre az alapértelmezett adatokkal: három sorozat és négy kategória. Három bemutatót ment 50 %, 100 % és 200 % magasságarányokkal. A diagram pozíciója, szélessége és magassága változatlan marad. Az adatok, a forgatás, a mélység, a sorozatok közötti távolság és a formázás minden három fájlban azonos; csak a magasság százalékos értéke változik.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 460);
chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_DepthPercents(100);
chart->get_ChartData()->get_Series()->idx_get(0)->get_ParentSeriesGroup()->set_GapDepth(150);

for (uint16_t heightPercent : { 50, 100, 200 })
{
    chart->get_Rotation3D()->set_HeightPercents(heightPercent);
    auto fileName = String::Format(u"chart_height_{0}.pptx", heightPercent);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

Az alábbi képek az ekvivalens .NET példából Microsoft PowerPoint használatával exportáltak, és ugyanazokat a magasságbeállításokat szemléltetik. A kisebb százalék laposabb jelenetet eredményez, míg a nagyobb százalék magasabb jelenetet a ugyanabban a diagramobjektumban. A PowerPoint a tengelyskálák intervallumait és a címkék elhelyezését is módosíthatja a jelenethez illeszkedően.

| Magasság: 50% | Magasság: 100% | Magasság: 200% |
| --- | --- | --- |
| ![3D oszlopdiagram, amelynek magassága a szélesség 50 %-a](height_percent_50.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 100 %-a](height_percent_100.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 200 %-a](height_percent_200.png) |

Ezek a metódusok a diagram különböző aspektusait szabályozzák:

| Metódus | Hatás |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | A 3D jelenet magassága a szélesség százalékában. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | A diagram objektum magassága a dián pontban. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | A 3D jelenet mélysége a szélesség százalékában. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | A sorozatok közötti távolság a mélységi tengely mentén, a jelölő szélességének százalékában. |

A magasságbeállítás a 3D oszlop- és sávdiagramokra hat, beleértve a henger-, kúp- és piramisváltozatokat, valamint a 3D vonal-, terület-, kör- és felületdiagramokat. A fenti összehasonlítás a ellenőrzött `Column3D` típust használja. A beállítás nem változtatja meg egy 2D `ClusteredColumn` vagy `BubbleWith3D` diagram megjelenését; ezek a nevek a [Diagramtípus](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) felsorolás tagjai. Más diagrammegjelenítési beállításokért lásd a [Diagramformázás](/slides/hu/cpp/chart-formatting/) oldalt.

## **Állítsa be a sorozatok közötti hézagot**

Használja a [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) metódust az adat sorozatok mélységi tengely mentén lévő távolságának szabályozásához, a jelölő szélességének százalékában kifejezve. Az értékek **0‑tól 500‑ig** terjednek, zárójelben: a `0` eltávolítja a hézagot, a nagyobb értékek pedig növelik a távolságot. Rögzített diagrammélységnél a hézag növelése vékonyabbá teszi a jelölőket a mélységi tengelyen.

A csoportot a [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) segítségével érheti el. A beállítás a csoport minden sorozatára érvényes, nem csak arra a sorozatra, amelyen keresztül eléri. A [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) visszaadja a szülőcsoport beállítását.

Ez a beállítás a 3D oszlop- és sávdiagramokra hat, beleértve a henger-, kúp- és piramisváltozatokat, valamint a 3D vonal- és területdiagramokat. A megjelenés attól függ, hogy a sorozatok mélységben, csoportosítva vagy rétegezve vannak-e. A különálló sorozatok közötti hézagok egyértelmű összehasonlításához használja a `ChartType::Column3D`-t a [Diagramtípus](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) felsorolásból.

Ezek a metódusok a diagram különböző aspektusait szabályozzák:

| Metódus | Hatás |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | A sorozatok közötti távolság a mélységi tengely mentén, a jelölő szélességének százalékában. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | A szomszédos oszlop vagy sávcsoportok közötti távolság, a sáv vagy oszlop szélességének százalékában. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | A diagram teljes mélysége, a diagram szélességének százalékában. |

Az alábbi önálló példa az alapértelmezett diagramadatokat használja, amelyek három sorozatot és négy kategóriát tartalmaznak. Két bemutatót ment azonos adatokkal, forgatással, hézag szélességgel és diagrammélységgel; csak a hézag mélysége változik.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 230);

chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_DepthPercents(100);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto group = series->get_ParentSeriesGroup();
group->set_GapWidth(150);

for (uint16_t gapDepth : { 0, 500 })
{
    group->set_GapDepth(gapDepth);

    auto fileName = String::Format(u"series_gap_depth_{0}.pptx", gapDepth);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

Az alábbi képek az ekvivalens .NET példából Microsoft PowerPoint használatával exportáltak, és ugyanazokat a hézagmélység beállításokat szemléltetik.

| Hézag mélység: 0% | Hézag mélység: 500% |
| --- | --- |
| ![3D oszlopdiagram, amelynek nincs hézag a sorozatok között a mélységi tengely mentén](gap_depth_0.png) | ![3D oszlopdiagram, amelynek 500 %-os hézagja van a sorozatok között a mélységi tengely mentén](gap_depth_500.png) |

## **Módosítsa a 3D sorozattípust és a sáv alakját**

Egy csoportosított hengeres diagram esetén az első sorozat hengeres sávokkal kezdődik. A példa a [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) és a [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) értékeket olvassa ki minden változás előtt és után.

```cpp
#include <DOM/Chart/ChartShapeType.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto printSeries = [&series]()
{
    auto type = Enum<ChartType>::GetName(series->get_Type());
    auto shape = Enum<ChartShapeType>::GetName(series->get_Bar3DShape());
    Console::WriteLine(u"{0} | {1}", type, shape);
};

printSeries();

series->set_Type(ChartType::ClusteredCone);
printSeries();

series->set_Bar3DShape(ChartShapeType::Box);
printSeries();

presentation->Save(u"series_shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

| Változtatás az első sorozaton | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Call [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) with `ClusteredCone` | `ClusteredCone` | `Cone` |
| Call [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) with `Box` | `ClusteredColumn3D` | `Box` |

A `Box` alak beállítása egyúttal megváltoztatja a sorozattípust `ClusteredColumn3D`‑re. Ha a kódja a sorozattípus alapján ágazik, hívja meg a `series->get_Type()`-ot a forma megváltoztatása után. A változás előtti gyorsítótárazott érték továbbra is a `ClusteredCone` ágat választaná.

![PowerPoint összehasonlítás, amely balról jobbra mutatja az első sorozatot hengeres, kúp alakú és téglalap alakú oszlopokként](series-shapes.png)

## **GYIK**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides-ban?**

Az Aspose.Slides a oszlopdiagramok 3D változatait támogatja, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és 100 % Stacked Column 3D típusokat, valamint a kapcsolódó 3D típusokat, amelyeket a [Diagramtípus](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) felsorolásban lehet elérni. A pontos, naprakész lista megtekintéséhez ellenőrizze a [Diagramtípus](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) tagjait az Ön által telepített verzió API referenciájában.

**Kaphatok raszteres képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. A diagramot exportálhatja képként a [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) segítségével, vagy [a teljes dia renderelése](/slides/hu/cpp/convert-powerpoint-to-png/) teljes diát PNG vagy JPEG formátumba. Ez hasznos, ha raszteres előnézetre van szüksége, vagy be szeretné ágyazni a diagramot dokumentumokba, irányítópultokra vagy weboldalakra anélkül, hogy a PowerPointra lenne szükség.

**Mennyire teljesítményorientált a nagy 3D diagramok építése és renderelése?**

A teljesítmény az adatmennyiségtől és a vizuális összetettségtől függ. A legjobb eredmény érdekében tartsák minimális szinten a 3D effektusokat, kerüljék a nehéz textúrákat a falakon és a diagramterületeken, korlátozzák az egy sorozatra jutó adatpontok számát, amennyiben ez lehetséges, és rendereljenek a célkijelzőhöz vagy nyomtatási igényekhez megfelelő méretű (felbontású és dimenziós) kimenetre.