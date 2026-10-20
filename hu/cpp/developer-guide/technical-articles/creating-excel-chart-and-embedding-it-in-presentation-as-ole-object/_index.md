---
title: Excel diagramok létrehozása és beágyazása előadásokba OLE objektumként
type: docs
weight: 40
url: /hu/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel diagram
- diagram beágyazása
- OLE objektum
- PowerPoint
- előadás
- C++
- Aspose.Slides
description: "Excel diagram létrehozása az Aspose.Cells for C++ segítségével, és a munkafüzet beágyazása egy PowerPoint előadásba az Aspose.Slides használatával, diagram előnézettel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhatunk létre egy Excel oszlopdiagramot az Aspose.Cells for C++ segítségével, és ágyazhatjuk be a munkafüzetet egy PowerPoint előadásba az Aspose.Slides for C++ használatával. A beágyazott munkafüzet tartalmazza a forrás adatokat és a diagramot egyaránt. Egy külön PNG előnézet jeleníti meg a diagramot a dián, mielőtt az OLE objektum aktiválódna.

Az eredmény egy beágyazott Excel objektum, nem egy natív PowerPoint diagram. A munkafüzet OLE-on keresztüli szerkesztéséhez olyan asztali alkalmazás szükséges, amely támogatja az OLE aktiválást és kompatibilis Excel telepítéssel.

## **Előkövetelmények**

Állítsa be C++ projektjét az Aspose.Cells for C++ és az Aspose.Slides for C++ fejléceivel és könyvtáraival. Helyezze a példakódot az alkalmazás belépési pontjába, a include deklarációkkal a fájl szintjén. A Microsoft Office nem szükséges a bemutató előállításához ezekkel a könyvtárakkal.

Nem szükséges bemeneti fájl: a példa memóriában hozza létre az adatokat és a diagramot, majd a `OutputChart.pptx` fájlt a jelenlegi munkakönyvtárba írja. A termékek licencét alkalmazza, ha az értékelő módon kívül futtatja.

## **Hogyan működik a beágyazás**

1. Hozzon létre egy munkafüzetet egy adat munkalappal és egy diagramlap-val.
1. Tegye aktívvá a diagramlapot, hogy a munkafüzet a diagramon nyíljon meg.
1. Állítsa be a munkafüzet OLE megjelenítési tartományát, és renderelje a diagramot PNG formátumba.
1. Mentse a munkafüzetet XLSX formátumban memóriába, és ágyazza be ezeket a bájtokat egy diára.
1. A PNG-t állítsa be az OLE objektum előnézeteként, és mentse a bemutatót PPTX formátumban.

A munkafüzet megjelenítési tartománya és a dia kerete különböző szerepet töltenek be. A [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) nulláralapú kezdő/veg sor- és oszlopindexeket vár. A [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) ehelyett a felső sort, bal oszlopot, alsó sort és jobb oszlopot veszi. A példa a 55-ös sorindexet és a 25-ös oszlopindexet használja alsó‑jobb határként; ezek az értékek elrendezési választások, nem az adat sorok vagy oszlopok száma.

A dia kerete pontokban van megadva. A példa a dia belsejébe illeszti és középre helyezi, miközben megőrzi a PNG arányát, ahelyett, hogy a előnézetet kinyújtaná a dia kitöltéséhez.

## **Diagram létrehozása és beágyazása**

Az alábbi teljes példa a `DataSheet`-et négy sor és öt oszlop értékkel tölti fel. Minden sor egy diagram sorozattá válik. A `ChartSheet` kerül kiválasztásra aktív munkalappá a munkafüzet mentése előtt.

A munkafüzet kifejezetten XLSX-ként van mentve, összhangban a `xlsx` kiterjesztéssel, amelyet az [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) kap. A PNG memóriában lévő streamből töltődik be köztes bitmap átalakítás nélkül. Az Aspose.Cells bájtvektorokat ad vissza, amelyeket a példa az Aspose.Slides által elfogadott tömb típusba másol. Az Aspose.Cells inicializálása az objektumok használata előtt, és erőforrásainak felszabadítása az objektumok megsemmisítése után kötelező. A [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) használata felülírja az alapértelmezett OLE helyőrzőt.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <Util/Images.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <algorithm>
#include <IImage.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

// Inicializálja a Cells-t, mielőtt bármelyik objektumát létrehozná.
Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"DataSheet");

    int32_t values[4][5] =
    {
        { 67, 44, 46, 43, 24 },
        { 86, 64, 97, 29, 40 },
        { 68, 89, 78, 69, 38 },
        { 91, 48, 60, 26, 25 }
    };

    for (auto row = 0; row < 4; row++)
    {
        for (auto column = 0; column < 5; column++)
        {
            dataSheet.GetCells().Get(row, column).PutValue(values[row][column]);
        }
    }

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    chartSheet.SetName(u"ChartSheet");

    auto lastChartRow = 55;
    auto lastChartColumn = 25;
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, lastChartRow, lastChartColumn);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    const char16_t* seriesRanges[] = { u"DataSheet!A1:E1", u"DataSheet!A2:E2", u"DataSheet!A3:E3", u"DataSheet!A4:E4" };
    for (auto range : seriesRanges)
    {
        chart.GetNSeries().Add(range, false);
    }

    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);
    workbook.GetWorksheets().SetOleSize(0, lastChartRow, 0, lastChartColumn);

    // Renderelje a diagram előnézetét, és külön sorosítsa a szerkeszthető munkafüzetet.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // Másolja a Cells puffereket a Slides által használt tömb típusba.
    auto toSlidesArray = [](const Aspose::Cells::Vector<uint8_t>& buffer)
    {
        auto result = System::MakeArray<uint8_t>(buffer.GetLength(), 0);
        std::copy(buffer.GetData(), buffer.GetData() + buffer.GetLength(), result->data_ptr());
        return result;
    };
    auto chartImageBytes = toSlidesArray(chartImageData);
    auto workbookBytes = toSlidesArray(workbookData);
    auto chartImageStream = System::MakeObject<System::IO::MemoryStream>(chartImageBytes);
    auto chartImage = Images::FromStream(chartImageStream);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto slideSize = presentation->get_SlideSize()->get_Size();

    // Illessze az előnézetet a diára anélkül, hogy megváltoztatná az arányát.
    auto scale = (std::min)(slideSize.get_Width() / chartImage->get_Width(), slideSize.get_Height() / chartImage->get_Height());
    auto frameWidth = chartImage->get_Width() * scale;
    auto frameHeight = chartImage->get_Height() * scale;
    auto frameX = (slideSize.get_Width() - frameWidth) / 2;
    auto frameY = (slideSize.get_Height() - frameHeight) / 2;

    auto embeddedData = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xlsx");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
    auto previewImage = presentation->get_Images()->AddImage(chartImage);
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(previewImage);

    presentation->Save(u"OutputChart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
    chartImage->Dispose();
    chartImageStream->Dispose();
}
// Szabadítsa fel a Cells erőforrásait, miután az összes Cells objektum el lett pusztítva.
Aspose::Cells::Cleanup();
```

## **Várt eredmény**

Az `OutputChart.pptx` egy diát tartalmaz, amelybe beágyazott Excel munkafüzet és egy diagram előnézet van. A munkafüzet az eredeti adatokat és egy négy sorozatos oszlopdiagramot tartalmaz. Az előnézet a dián középre van helyezve, és megtartja arányait.

![Excel oszlopdiagram megjelenítve a beágyazott munkafüzet előnézeteként](excel-chart-ole-preview.png)

Kompatibilis asztali PowerPoint környezetben, ahol elérhető az Excel, dupla kattintással aktiválhatja és szerkesztheti a beágyazott munkafüzetet. Az aktiválás és szerkesztés a gazdaalkalmazás OLE támogatásától és biztonsági beállításaitól függ.

## **GYIK**

**Miért szükséges az előnézeti kép?**

A beágyazott munkafüzet és a dia előnézete különálló tartalom. Adjon meg egy diagramképet, hogy a dia a diagramot jelenítse meg az alapértelmezett "EMBEDDED OLE OBJECT" helyőrző helyett. Lásd [Object Preview Issue when Adding OleObjectFrame](/slides/hu/cpp/object-preview-issue-when-adding-oleobjectframe/).

**Frissül automatikusan az előnézet, ha a kódban módosítom a munkafüzetet?**

Kezelje az előnézetet pillanatképként. Amikor programozottan frissíti a munkafüzet adatait, generálja újra a diagram képet, és cserélje le az előnézetet, valamint a beágyazott munkafüzet adatát.

**Használhatok XLS-et XLSX helyett?**

Igen. Mentse a munkafüzetet XLS formátumban, és használja a `xls` kiterjesztést a beágyazott adatként. A kiterjesztésnek meg kell egyeznie a tényleges munkafüzet formátummal; csak a kiterjesztés módosítása nem konvertálja az adatot.

**Miért változhat meg az objektum mérete aktiválás után?**

A gazdaalkalmazás frissítheti az OLE objektum megjelenését a munkafüzet aktiválásakor. A munkafüzet OLE megjelenítési tartománya és a dia keret méretei egyaránt számítanak. Lásd [Working Solution for Chart Resizing in PPTX](/slides/hu/cpp/working-solution-for-chart-resizing-in-pptx/).

## **Kapcsolódó szakaszok**

- [Működő megoldás a diagram átméretezésére PPTX-ben](/slides/hu/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Objektum előnézeti probléma OleObjectFrame hozzáadásakor](/slides/hu/cpp/object-preview-issue-when-adding-oleobjectframe/)