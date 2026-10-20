---
title: Arbetslösning för diagramstorleksändring i PPTX
type: docs
weight: 60
url: /sv/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagramstorleksändring
- Excel-diagram
- OLE-objekt
- bädda in diagram
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Åtgärda oväntad diagramstorleksändring i PPTX när inbäddade Excel OLE-objekt används med Aspose.Slides för C++. Ange fasta diagramdimensioner för att hålla diagram- och OLE-ramens storlekar konsekventa."
---
## **Bakgrund**

Excel-diagram som bäddas in som OLE-objekt i PowerPoint-presentationer med Aspose-komponenter kan ändra storlek efter sin första aktivering. Detta kan leda till en märkbar skillnad i diagrammets utseende före och efter aktivering. Denna artikel förklarar varför storleksändring sker och visar hur man förhindrar den genom att matcha fasta diagramdimensioner med OLE‑ramen.

I [Skapa Excel-diagram och bädda in dem som OLE-objekt i presentationer](/slides/sv/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), förklarade vi hur man skapar ett Excel-diagram med Aspose.Cells för C++ och bäddar in det i en PowerPoint-presentation med Aspose.Slides för C++. För att lösa [problem med förhandsgranskning av objekt](/slides/sv/cpp/object-preview-issue-when-adding-oleobjectframe/), tilldelade vi diagrammets bild till diagrammets OLE-objektram. I den resulterande presentationen, när du dubbelklickar på OLE-objektramen som visar diagrambilden, aktiveras Excel-diagrammet. Användare kan redigera den inbäddade Excel-arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade arbetsboken. Storleken på OLE-objektramen ändras när användaren återvänder till bilden, och storleksändringsfaktorn varierar beroende på de ursprungliga storlekarna för både OLE-objektramen och den inbäddade Excel-arbetsboken.

## **Orsak till storleksändring**

Den inbäddade Excel-arbetsboken har egna fönsterdimensioner, som Excel försöker bevara när objektet först aktiveras. OLE-ramen på bilden har oberoende definierade dimensioner. När Excel-arbetsboken aktiveras förhandlar Excel och PowerPoint om objektets storlek för att hålla dess proportioner som en del av inbäddningsprocessen. Skillnader mellan arbetsbokens fönster och OLE-ramen kan därför leda till att objektet ändrar storlek.

## **Fungerande lösning**

Matcha diagrammets storlek med OLE-ramen på bilden och håll diagrammets dimensioner oberoende av arbetsbokens fönster. Denna lösning fungerar med en ny presentation eller en befintlig mall.

Exemplet kräver Aspose.Cells för C++ och Aspose.Slides för C++. Det skapar ett enkelt stapeldiagram på ett aktivt diagramark och bäddar in arbetsboken i XLS-format. Ingen förhandsgranskningsbild för diagrammet tilldelas; diagrammet blir synligt när OLE-objektet aktiveras i PowerPoint.

Placera exempelprogrammet i din applikations startpunkt, med include‑deklarationerna på filnivå. Initiera Aspose.Cells innan du skapar dess objekt och frigör dess resurser efter att objekten har förstörts. Exemplet kopierar arbetsbokens byte‑vektor som returneras av Aspose.Cells till den arraytyp som Aspose.Slides accepterar.

Exemplet skapar en ny presentation med en 9.5 × 4‑tum OLE-ram placerad 0.5 tum från vänster kant och 1 tum från toppen. Bildens koordinater och dimensioner anges i punkter (72 punkter per tum). För en befintlig presentation, se [Använd en mall](#use-a-template).

## **Ange en fast diagramstorlek**

Ställ in [Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) till false så att diagrammets dimensioner är oberoende av arbetsbokens fönster. Ställ in dimensionerna för [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) via [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) och [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/), omvandla punkter till pixlar med 96 pixlar per tum: en ram som mäter 684 × 288 punkter motsvarar ett diagram som mäter 912 × 384 pixlar. Ställ in [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) till det anpassade värdet för [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/). Exemplet bäddar in arbetsboken med [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) och sparar en presentation med en 9.5 × 4‑tum OLE-ram.

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

    // Bildkoordinater och dimensioner är i punkter (72 punkter per tum).
    auto width = 684.f; // 9,5 tum.
    auto height = 288.f; // 4 tum.

    chart.SetSizeWithWindow(false);
    // Konvertera punkter till diagrampixlar med 96 pixlar per tum.
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // Kopiera Cells bytevektor till den arraytyp som Slides accepterar.
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **Använd en mall**

Dimensioneringslogiken är densamma för en befintlig presentation. För att anpassa exemplet:

1. Läs in mallpresentationen istället för att skapa en tom presentation.
1. Kontrollera att den första bilden innehåller minst tre former, använd sedan formen med index 2 som platshållare.
1. Ta ramens bredd och höjd från den formen istället för att använda de fasta värdena 684 och 288. Behåll beräkningarna för dimensionering oförändrade.
1. Lägg till OLE-ramen på platshållarens position istället för de fasta koordinaterna 36 och 72.
1. Ta bort platshållaren innan presentationen sparas.

## **FAQ**

**Varför förändras mitt inbäddade Excel-diagram i storlek efter att det aktiverats i PowerPoint?**

Detta händer eftersom Excel försöker återställa den ursprungliga fönsterstorleken vid första aktiveringen, medan OLE-objektramen i PowerPoint har egna dimensioner. PowerPoint och Excel förhandlar om storleken för att behålla bildförhållandet, vilket kan leda till storleksändring.

**Hur kan jag hålla diagrammets och OLE-ramens storlekar konsekventa?**

Ange fasta diagramdimensioner som matchar OLE-ramen och använd en anpassad diagramutskriftsstorlek innan arbetsboken bäddas in. Exemplet ovan visar de nödvändiga inställningarna och enhetsomräkningarna.

**Är det tillräckligt att matcha arbetsbokens fönsterstorlek?**

Att bara matcha arbetsbokens fönsterstorlek förhindrar inte på ett pålitligt sätt att OLE-ramen ändrar storlek efter aktivering. Använd fasta diagramdimensioner som visat i exemplet.

**Fungerar denna lösning både för mallbaserade presentationer och nya presentationer?**

Ja. För en mall, använd platshållarens dimensioner och position. För en ny presentation, ange ramens dimensioner och position direkt.

**Kan jag använda detta exempel med diagram skapade i andra kalkylprogram?**

Exemplet använder en Excel-arbetsbok skapad med Aspose.Cells. Det visar inte aktiveringsbeteende för andra kalkylprogram.

## **Relaterade avsnitt**

- [Skapa Excel-diagram och bädda in dem som OLE-objekt i presentationer](/slides/sv/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)