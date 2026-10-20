---
title: Skapa Excel-diagram och bädda in dem i presentationer som OLE-objekt
type: docs
weight: 40
url: /sv/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-diagram
- bädda in diagram
- OLE-objekt
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Skapa ett Excel-diagram med Aspose.Cells för C++ och bädda in arbetsboken i en PowerPoint-presentation med Aspose.Slides, inklusive en diagramförhandsvisning."
---
## **Översikt**

Denna artikel visar hur man skapar ett Excel stapeldiagram med Aspose.Cells för C++ och bäddar in dess arbetsbok i en PowerPoint‑presentation med Aspose.Slides för C++. Den inbäddade arbetsboken innehåller både källdata och diagrammet. En separat PNG‑förhandsvisning visar diagrammet på bilden innan OLE‑objektet aktiveras.

Resultatet är ett inbäddat Excel‑objekt, inte ett inbyggt PowerPoint‑diagram. Redigering av arbetsboken via OLE kräver ett skrivbordsprogram som stöder OLE‑aktivering och en kompatibel Excel‑installation.

## **Förutsättningar**

Konfigurera ditt C++‑projekt med rubriker och bibliotek för Aspose.Cells för C++ och Aspose.Slides för C++. Placera exempel­koden i ditt programstarts­punkt, med include‑deklarationerna på filnivå. Microsoft Office krävs inte för att generera presentationen med dessa bibliotek.

Inga indatafiler krävs: exemplet skapar data och diagram i minnet och skriver sedan `OutputChart.pptx` till den aktuella arbetskatalogen. Använd licenser för båda produkterna när du kör utanför utvärderingsläge.

## **Hur inbäddning fungerar**

1. Skapa en arbetsbok med ett dataarbetsblad och ett diagramblad.  
1. Gör diagrambladet aktivt så att arbetsboken öppnas på diagrammet.  
1. Ställ in arbetsbokens OLE‑visningsområde och rendera diagrammet till PNG.  
1. Spara arbetsboken som XLSX i minnet och bädda in de byte­strömmarna i en bild.  
1. Tilldela PNG‑filen som OLE‑objektets förhandsvisning och spara presentationen som PPTX.  

Arbetsbokens visningsområde och ramen på bilden har olika roller. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) tar nollbaserade start‑/slut‑rad‑ och kolumnindex. [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) tar istället den översta raden, vänstra kolumnen, nedersta raden och högra kolumnen. Exemplet använder rad‑index 55 och kolumn‑index 25 som de nedre‑högra gränserna; dessa värden är layoutval, inte antalet datarader eller -kolumner.

Bildramen använder punkter. Exemplet anpassar den inom bilden och centrerar den samtidigt som den bevarar PNG‑filens bildförhållande, snarare än att sträcka förhandsvisningen för att fylla bilden.

## **Skapa och bädda in diagrammet**

Följande kompletta exempel fyller `DataSheet` med fyra rader och fem kolumner av värden. Varje rad blir en diagramserie. `ChartSheet` väljs som aktivt blad innan arbetsboken sparas.

Arbetsboken sparas uttryckligen som XLSX, vilket matchar `xlsx`‑extensioen som skickas till [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/). PNG‑filen läses in från en minnesström utan en mellanstegsbitar‑konvertering. Aspose.Cells returnerar byte‑vektorer, vilka exemplet kopierar till den array‑typ som accepteras av Aspose.Slides. Initiera Aspose.Cells innan du använder dess objekt, och frigör dess resurser efter att dessa objekt har förstörts. Genom att tilldela det via [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) ersätts standard‑OLE‑platshållaren.

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

// Initiera Cells innan du skapar några av dess objekt.
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

    // Rendera diagramförhandsvisningen och serialisera den redigerbara arbetsboken separat.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // Kopiera Cells-buffertar till den array-typ som Slides använder.
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

    // Anpassa förhandsvisningen inom bilden utan att ändra bildförhållandet.
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
// Frigör Cells-resurser efter att alla Cells-objekt har förstörts.
Aspose::Cells::Cleanup();
```

## **Förväntat resultat**

`OutputChart.pptx` innehåller en bild med en inbäddad Excel‑arbetsbok och en diagramförhandsvisning. Arbetsboken innehåller originaldata och ett stapeldiagram med fyra serier. Förhandsvisningen är centrerad på bilden och behåller sina proportioner.

![Excel stapeldiagram som visas som förhandsvisning av en inbäddad arbetsbok](excel-chart-ole-preview.png)

I en kompatibel PowerPoint‑miljö på skrivbordet med Excel tillgängligt, dubbelklicka på objektet för att aktivera och redigera den inbäddade arbetsboken. Aktivering och redigering beror på värdprogrammets OLE‑stöd och säkerhetsinställningar.

## **Vanliga frågor**

**Varför behövs en förhandsvisningsbild?**  
Den inbäddade arbetsboken och dess bildförhandsvisning är separata innehåll. Tillhandahåll en diagrambild så att bilden visar diagrammet i stället för standard‑"EMBEDDED OLE OBJECT"-platshållaren. Se [Problem med förhandsvisning av objekt när OleObjectFrame läggs till](/slides/sv/cpp/object-preview-issue-when-adding-oleobjectframe/).

**Uppdateras förhandsvisningen automatiskt när jag ändrar arbetsboken i kod?**  
Behandla förhandsvisningen som ett ögonblicksavtryck. När du uppdaterar arbetsbokens data programmässigt, regenerera diagrambilden och ersätt både förhandsvisningen och den inbäddade arbetsbokens data.

**Kan jag använda XLS istället för XLSX?**  
Ja. Spara arbetsboken i XLS‑format och använd `xls` som den inbäddade data‑extensioen. Extensioen måste matcha arbetsbokens faktiska format; enbart ändra extensioen konverterar inte data.

**Varför kan objektet ändra storlek efter aktivering?**  
Värdprogrammet kan uppdatera OLE‑objektets presentation när det aktiverar arbetsboken. Arbetsbokens OLE‑visningsområde och bildramens dimensioner spelar båda roll. Se [Fungerande lösning för att ändra diagramstorlek i PPTX](/slides/sv/cpp/working-solution-for-chart-resizing-in-pptx/).

## **Relaterade avsnitt**

- [Fungerande lösning för att ändra diagramstorlek i PPTX](/slides/sv/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Problem med förhandsvisning av objekt när OleObjectFrame läggs till](/slides/sv/cpp/object-preview-issue-when-adding-oleobjectframe/)