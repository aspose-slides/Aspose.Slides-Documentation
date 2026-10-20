---
title: Működő megoldás a diagram átméretezésére PPTX-ben
type: docs
weight: 60
url: /hu/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagram átméretezés
- Excel diagram
- OLE objektum
- diagram beágyazása
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Javítsa a PPTX-ben előforduló váratlan diagram átméretezést a beágyazott Excel OLE objektumok használatakor az Aspose.Slides for C++ segítségével. Állítson be rögzített diagramméreteket, hogy a diagram és az OLE keret méretei konzisztens maradjanak."
---
## **Háttér**

Az Aspose komponensekkel PowerPoint‑prezentációkba beágyazott OLE objektumként megjelenő Excel-diagramok az első aktiválásuk után módosíthatják méretüket. Ez a diagram megjelenésének jelentős különbségét okozhat aktiválás előtt és után. Ez a cikk elmagyarázza, miért fordul elő az átméretezés, és bemutatja, hogyan lehet megelőzni a diagram rögzített méretének az OLE kerethez való illesztésével.

A [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/hu/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) című cikkben bemutattuk, hogyan hozhatunk létre egy Excel-diagramot az Aspose.Cells for C++ segítségével, és ágyazhatjuk be egy PowerPoint‑prezentációba az Aspose.Slides for C++ használatával. Az [object preview issue](/slides/hu/cpp/object-preview-issue-when-adding-oleobjectframe/) kezelésére a diagram képét rendeltük a diagram OLE objektumkeretéhez. A kimeneti prezentációban, ha duplán rákattint a diagramképet megjelenítő OLE objektumkeretre, az Excel-diagram aktiválódik. A felhasználók szerkeszthetik a beágyazott Excel‑könyvtárat, majd a aktivált könyvtáron kívülre kattintva visszatérhetnek a diára. Az OLE objektumkeret mérete megváltozik, amikor a felhasználó visszatér a diára, és az átméretezési tényező az OLE objektumkeret és a beágyazott Excel‑könyvtár eredeti méreteitől függ.

## **Az átméretezés oka**

A beágyazott Excel‑könyvtár saját ablakmérettel rendelkezik, amelyet az Excel megpróbál megtartani az objektum első aktiválásakor. A dián lévő OLE‑keret önállóan definiált méretekkel bír. Amikor az Excel‑könyvtár aktiválódik, az Excel és a PowerPoint egyeztetik az objektum méretét, hogy megőrizzék az arányait a beágyazási folyamat részeként. Így a könyvtárablak és az OLE‑keret közötti eltérések okozhatják az objektum átméretezését.

## **Működő megoldás**

Illesszük a diagram méretét a dián lévő OLE‑kerethez, és tartsuk a diagram méreteit függetlenül a könyvtárablaktól. Ez a megoldás új prezentációval vagy meglévő sablonnal egyaránt működik.

A példához az Aspose.Cells for C++ és az Aspose.Slides for C++ szükséges. Egy egyszerű oszlopdiagramot hoz létre egy aktív diagramlapon, és beágyazza a könyvtárat XLS formátumban. Nem kerül diagram előnézeti kép hozzárendelésre; a diagram a PowerPointban aktivált OLE‑objektusnál válik láthatóvá.

Tegye a példakódot az alkalmazás belépési pontjába, a include deklarációkat a fájl szintjén. Az Aspose.Cells-et inicializálja a objektumok létrehozása előtt, és szabadítsa fel erőforrásait, miután az objektumok meg lettek semmisítve. A példában a Aspose.Cells által visszaadott munkafüzet bájtvektort másolják az Aspose.Slides által elfogadott tömbtípusba.

A példa új prezentációt hoz létre egy 9,5 × 4 hüvelykes OLE‑kerettel, amely 0,5 hüvelyk távolságra van a bal szélétől és 1 hüvelykre a tetejétől. A dia koordinátái és méretei pontokban vannak megadva (72 pont per hüvelyk). Meglévő prezentáció esetén tekintse meg a [Use a Template](#use-a-template) szakaszt.

## **Rögzített diagramméret beállítása**

Állítsa a [Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) értékét false-ra, hogy a diagram méretei függetlenek legyenek a munkafüzet ablakától. Állítsa be a [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) méreteit a [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) és a [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/) segítségével, pontokat pixelre konvertálva 96 pixel per hüvelyk értékkel: egy 684 × 288 pont méretű keret egy 912 × 384 pixel méretű diagramnak felel meg. Állítsa a [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) értékét a [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/) Custom értékére. A példa az [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) segítségével ágyazza be a munkafüzetet, és egy 9,5 × 4 hüvelykes OLE‑kerettel menti a prezentációt.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartShape.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/PrintSizeType.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <algorithm>
#include <cstdint>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"Data");
    dataSheet.GetCells().Get(u"A1").PutValue(10);
    dataSheet.GetCells().Get(u"A2").PutValue(20);

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, 20, 10);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(u"Data!A1:A2", true);
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // A dia koordinátái és méretei pontban vannak megadva (72 pont per hüvelyk).
    auto width = 684.f; // 9,5 hüvelyk.
    auto height = 288.f; // 4 hüvelyk.

    chart.SetSizeWithWindow(false);
    // Konvertálja a pontokat diagram pixelekre 96 pixel per hüvelyk használatával.
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // Másolja a Cells bájtvektort a Slides által elfogadott tömb típusba.
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **Sablon használata**

Az átméretezési logika ugyanaz meglévő prezentáció esetén is. A példa adaptálásához:

1. Töltse be a sablonprezentációt egy üres prezentáció létrehozása helyett.
2. Ellenőrizze, hogy az első dián legalább három alakzat szerepel, majd használja a 2. indexű alakzatot helyőrzőként.
3. Vegye a keret szélességét és magasságát ebből az alakzatból a 684 és 288 rögzített értékek helyett. Tartsa változatlanul a méretezési számításokat.
4. Adja hozzá az OLE‑keretet a helyőrző pozíciójához a 36 és 72 rögzített koordináták helyett.
5. Távolítsa el a helyőrzőt a prezentáció mentése előtt.

## **GYIK**

**Miért változik a beágyazott Excel-diagram mérete a PowerPointban történő aktiválás után?**

Ez azért történik, mert az Excel az első aktiváláskor megpróbálja visszaállítani az eredeti ablakméretet, míg a PowerPointban az OLE‑objektumkeret saját méretekkel rendelkezik. A PowerPoint és az Excel egyeztetik a méretet az arányok megtartása érdekében, ami átméretezést okozhat.

**Hogyan tarthatom konzisztensnek a diagram és az OLE‑keret méreteit?**

Állítson be rögzített diagramméreteket, amelyek megegyeznek az OLE‑keret méreteivel, és az ágyazás előtt használjon egy egyedi diagramnyomtatási méretet. A fenti példa bemutatja a szükséges beállításokat és egységkonverziókat.

**Elégséges-e a munkafüzet-ablak méretének illesztése?**

A munkafüzet-ablak méretének csak önmagában történő illesztése nem biztosítja megbízhatóan, hogy az OLE‑keret ne változtassa meg méretét aktiválás után. Használjon rögzített diagramméreteket, ahogy a példában látható.

**Működik ez a megoldás sablon‑alapú és új prezentációk esetén is?**

Igen. Sablonnál a helyőrző méreteit és pozícióját használja. Új prezentáció esetén közvetlenül adja meg a keret méreteit és pozícióját.

**Használhatom ezt a példát más táblázatkezelő programok által készített diagramokkal?**

A példa egy Aspose.Cells által létrehozott Excel‑könyvtárat használ. Nem mutat be aktiválási viselkedést más táblázatkezelő programok esetén.

## **Kapcsolódó szakaszok**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/hu/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)