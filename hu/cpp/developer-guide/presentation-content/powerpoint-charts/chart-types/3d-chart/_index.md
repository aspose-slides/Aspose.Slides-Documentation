---
title: 3D diagramok testreszabása prezentációkban C++ használatával
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
description: "Készítsen 3D diagramokat PowerPoint-prezentációkban az Aspose.Slides for C++ használatával. Állítsa be a forgatást, a magasság arányokat, a diagram mélységét és a sorozatok közti távolságot C++ példákkal."
---
## **Áttekintés**

Az Aspose.Slides for C++ lehetővé teszi, hogy testreszabja egy 3D diagram nézetét a [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/) segítségével. Ez a cikk bemutatja, hogyan állíthatja be a forgatást, a magasság arányokat, a mélységet, a derékszögű tengelyeket és a sorozatok közötti távolságot, majd hogyan mentheti a bemutatót PPTX formátumban.

## **A 3D diagram forgatásának és mélységének beállítása**

Az alábbi példa létrehoz egy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) és a [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) segítségével egy halmozott 3D oszlopdiagramot ad az első diájához. Lecseréli az alapértelmezett sorozatokat és kategóriákat két sorozatra, amelyek mindegyike három értéket tartalmaz. A `0` munkalap-index a diagram első adatmunkalapját jelöli; a `0` sor a sorozatneveket, a `0` oszlop pedig a kategóriacímkéket tartalmazza.

Az [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) és a [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) metódusok a diagram forgatását 40 illetve 270 fokra állítják. A [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) 150 %-ra állítja a mélységet a szélességhez képest, míg a [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) jobb szögű tengelyeket engedélyez a perspektíva helyett. Az eredményül kapott bemutató a kitöltött diagramot tartalmazza ezekkel a 3D nézetbeállításokkal.

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

## **Képpel kitöltés alkalmazása a 3D diagram felületére**

A 3D diagram [side wall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_sidewall/), [back wall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_backwall/) és [floor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_floor/) felületét külön-külön töltheti ki. Állítsa a felület [fill type](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) értékét `Picture`‑ra, és rendelje hozzá a képet. Ahhoz, hogy a kép egy példánya illeszkedjen a felülethez, állítsa a [picture fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) és a felület [picture type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartwall/set_picturetype/) értékét `Stretch`‑re.

Mentse el az [arrow.png](arrow.png) fájlt a munkakönyvtárba. A példa elforgatja a diagramot, és megnöveli a függőleges tengely maximális értékét, hogy a padló látható legyen az oszlopok között. Ezután kétszer klónozza a diát, és az nyilat különböző felületre alkalmazza minden dián. A három diagram ugyanazt az adatot, a nézeti szöget és a hátteret tartja meg.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartWall.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/Chart/PictureType.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/shared_ptr.h>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 20, 30, 680, 480);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(30);

auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_IsAutomaticMaxValue(false);
verticalAxis->set_MaxValue(24);

auto backSlide = presentation->get_Slides()->AddClone(slide);
auto floorSlide = presentation->get_Slides()->AddClone(slide);
auto backChart = ExplicitCast<IChart>(backSlide->get_Shape(0));
auto floorChart = ExplicitCast<IChart>(floorSlide->get_Shape(0));

auto imageBytes = IO::File::ReadAllBytes(u"arrow.png");
auto arrow = presentation->get_Images()->AddImage(imageBytes);

for (const auto& surface : { chart->get_SideWall(), backChart->get_BackWall(), floorChart->get_Floor() })
{
    auto fill = surface->get_Format()->get_Fill();
    fill->set_FillType(FillType::Picture);
    auto pictureFill = fill->get_PictureFillFormat();
    pictureFill->get_Picture()->set_Image(arrow);
    pictureFill->set_PictureFillMode(PictureFillMode::Stretch);
    surface->set_PictureType(PictureType::Stretch);
}

presentation->Save(u"chart-surfaces.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A Microsoft PowerPoint a három diát a következőképpen jeleníti meg.

| Oldalfal | Hátsó fal | Padló |
| --- | --- | --- |
| ![Nyíl, amely a diagramba mutat a oldalfal mentén](side-wall.png) | ![Nyíl, amely jobbra mutat a hátsó falon](back-wall.png) | ![Nyíl, amely jobbra mutat a padlón az oszlopok között](floor.png) |

## **A 3D diagram magasságarányainak beállítása**

A [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) segítségével beállíthatja egy 3D diagram magasságát a szélességének százalékában. Ez megváltoztatja a 3D jelenet arányait anélkül, hogy átméretezné a dián lévő diagramobjektumot.

A következő példa egy [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) diagramot hoz létre az alapértelmezett adatokkal: három sorozat és négy kategória. Három bemutatót ment 50 %, 100 % és 200 % magasságarányokkal. A diagram pozíciója, szélessége és magassága változatlan marad. Az adatok, a forgatás, a mélység, a sorozatok közti távolság és a formázás minden három fájlban azonos; csak a magasság százalékos értéke változik.

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

A következő képek az ekvivalens .NET példából Microsoft PowerPoint segítségével exportáltak, és ugyanazt a magasságbeállítást mutatják. Egy kisebb százalék laposabb jelenetet eredményez, míg egy nagyobb százalék magasabb jelenetet ugyanabban a diagramobjektumban. A PowerPoint a tengelyek jelölőinek intervallumát és a címkék elhelyezését is módosíthatja a jelenethez igazodva.

| Magasság: 50% | Magasság: 100% | Magasság: 200% |
| --- | --- | --- |
| ![3D oszlopdiagram, amelynek magassága a szélesség 50%-ára van beállítva](height_percent_50.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 100%-ára van beállítva](height_percent_100.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 200%-ára van beállítva](height_percent_200.png) |

Ezek a metódusok a diagram különböző aspektusait szabályozzák:

| Metódus | Hatás |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | A 3D jelenet magassága a szélességének százalékában. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | A diagramobjektum magassága a dián pontokban. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | A 3D jelenet mélysége a szélességének százalékában. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Sorozatok közti távolság a mélységi tengelyen, a jelölő szélességének százalékában. |

A magasság beállítás a 3D oszlop- és sávdiagramokra hat, beleértve a henger, kúp és piramis változatokat, valamint a 3D vonal, terület, kör és felület diagramokat. A fenti összehasonlítás a hitelesített `Column3D` típust használja. A beállítás nem változtatja meg egy 2D `ClusteredColumn` diagram vagy egy `BubbleWith3D` diagram megjelenését; ezek a nevek a [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) enumeráció tagjai. Más diagrammegjelenítési beállításokért tekintse meg a [Chart Formatting](/slides/hu/cpp/chart-formatting/) oldalt.

## **A sorozatok közti hézag beállítása**

[AChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) segítségével szabályozhatja az adat sorozatok közti távolságot egy 3D diagram mélységi tengelyén, a jelölő szélességének százalékában kifejezve. **0‑tól 500‑ig** terjedő értékeket használjon, beleértve a határokat: a `0` eltávolítja a hézagot, míg a nagyobb értékek növelik a távolságot. Rögzített diagrammélységnél a hézag növelése a jelölőket vékonyabbá teszi a mélységi tengelyen.

A csoportot a [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) segítségével érheti el. A beállítás a csoport minden sorozatára vonatkozik, nem csak arra a sorozatra, amelyen keresztül elérésre került. A [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) a szülőcsoport beállítását adja vissza.

Ez a beállítás a 3D oszlop- és sávdiagramokra hat, beleértve a henger, kúp és piramis változatokat, valamint a 3D vonal- és terület diagramokra. A megjelenés attól függ, hogy a sorozatok mélységben, klaszterben vagy halmozva vannak-e elrendezve. Az egyes sorozatok közti hézagok egyértelmű összehasonlításához használja a `ChartType::Column3D`‑t a [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) enumerációból.

Ezek a metódusok a diagram különböző aspektusait szabályozzák:

| Metódus | Hatás |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Sorozatok közti távolság a mélységi tengelyen, a jelölő szélességének százalékában. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | Szomszédos sáv vagy oszlop klaszterek közti távolság, a sáv vagy oszlop szélességének százalékában. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | A diagram teljes mélysége, a diagram szélességének százalékában. |

A következő önálló példa az alapértelmezett diagramadatokat használja, amelyek három sorozatot és négy kategóriát tartalmaznak. Két bemutatót mentonosít azonos adatokkal, forgatással, hézag szélességgel és diagrammélységgel; csak a hézag mélysége változik.

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

A következő képek az ekvivalens .NET példából Microsoft PowerPoint segítségével exportáltak, és ugyanazt a hézagmélység beállítást mutatják.

| Hézagmélység: 0% | Hézagmélység: 500% |
| --- | --- |
| ![3D oszlopdiagram, amelynek nincs hézagja a sorozatok között a mélységi tengelyen](gap_depth_0.png) | ![3D oszlopdiagram, amelynek 500‑%-os hézagja van a sorozatok között a mélységi tengelyen](gap_depth_500.png) |

## **A 3D sorozattípus és oszlop alakjának módosítása**

Egy klaszterezett hengerdiagram első sorozata hengeres oszlopokkal indul. A példa a [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) és a [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) értékeket olvassa minden változtatás előtt és után.

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

| Módosítás az első sorozatra | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| Diagram létrehozása | `ClusteredCylinder` | `Cylinder` |
| Hívja a [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/)‑t `ClusteredCone`‑val | `ClusteredCone` | `Cone` |
| Hívja a [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/)‑t `Box`‑al | `ClusteredColumn3D` | `Box` |

A `Box` alak beállítása szintén `ClusteredColumn3D` típusra változtatja a sorozatot. Ha a kódja a sorozattípus alapján ágazik, hívja meg a `series->get_Type()`‑t a forma módosítása után. A módosítás előtt cache‑elt érték továbbra is a `ClusteredCone` ágat választaná.

![PowerPoint összehasonlítás, amely balról jobbra mutatja az első sorozatot hengerek, kúpek és téglalap alakú oszlopok formájában](series-shapes.png)

## **GYIK**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides‑ben?**

Aspose.Slides támogatja a 3D változatokat az oszlopdiagramoknál, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és 100 % Stacked Column 3D típusokat, valamint a kapcsolódó 3D típusokat, amelyek a [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) enumerációban érhetők el. A pontos, naprakész listáért nézze meg a [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) tagjait a telepített verzió API‑referenciájában.

**Kaphatok raszter képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. A diagramot exportálhatja képre a [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) vagy a [a teljes dia renderelése](/slides/hu/cpp/convert-powerpoint-to-png/) segítségével olyan formátumokba, mint PNG vagy JPEG. Ez akkor hasznos, ha raszter előnézetre van szüksége, vagy be szeretné ágyazni a diagramot dokumentumokba, irányítópultokra vagy weboldalakra anélkül, hogy a PowerPointra lenne szükség.

**Mennyire hatékony a nagy 3D diagramok felépítése és renderelése?**

Az teljesítmény az adat mennyiségétől és a vizuális összetettségtől függ. A legjobb eredmény érdekében tartsa minimálisra a 3D effektusokat, kerülje a nehéz textúrákat a falakon és a diagramterületen, korlátozza a sorozatonkénti adatpontok számát, ha lehetséges, és rendereljen megfelelő méretű kimenetre (felbontás és méretek), amely megfelel a célkijelző vagy nyomtatási igényeknek.