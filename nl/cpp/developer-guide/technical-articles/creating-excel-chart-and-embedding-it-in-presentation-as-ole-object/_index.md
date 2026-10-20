---
title: Maak Excel-grafieken en embed ze in presentaties als OLE-objecten
type: docs
weight: 40
url: /nl/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-grafiek
- diagram insluiten
- OLE-object
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Maak een Excel-grafiek met Aspose.Cells voor C++ en embed de werkmap in een PowerPoint-presentatie met Aspose.Slides, inclusief een grafiek-preview."
---
## **Overzicht**

Dit artikel laat zien hoe u een Excel kolomdiagram maakt met Aspose.Cells voor C++ en de bijbehorende werkmap in een PowerPoint‑presentatie embed met Aspose.Slides voor C++. De ingebedde werkmap bevat zowel de brongegevens als het diagram. Een aparte PNG‑preview geeft het diagram weer op de dia voordat het OLE‑object wordt geactiveerd.

Het resultaat is een ingebed Excel‑object, geen native PowerPoint‑diagram. Het bewerken van de werkmap via OLE vereist een desktop‑applicatie die OLE‑activatie ondersteunt en een compatibele Excel‑installatie.

## **Voorvereisten**

Configureer uw C++‑project met de header‑ en bibliotheekbestanden voor Aspose.Cells voor C++ en Aspose.Slides voor C++. Plaats de voorbeeldcode in het startpunt van uw applicatie, met de include‑declaraties op bestandsniveau. Microsoft Office is niet vereist om de presentatie te genereren met deze bibliotheken.

Er zijn geen invoerbestanden nodig: het voorbeeld maakt de gegevens en het diagram in het geheugen aan en schrijft vervolgens `OutputChart.pptx` naar de huidige werkmap. Pas licenties toe voor beide producten wanneer u buiten de evaluatiemodus werkt.

## **Hoe de insluiting werkt**

1. Maak een werkmap met een gegevenswerkblad en een diagramblad.  
2. Maak het diagramblad actief zodat de werkmap opent op het diagram.  
3. Stel het OLE‑weergavebereik van de werkmap in en render het diagram naar PNG.  
4. Sla de werkmap op als XLSX in het geheugen en embed die bytes in een dia.  
5. Wijs de PNG toe als de preview van het OLE‑object en sla de presentatie op als PPTX.

De weergavebereik van de werkmap en het kader op de dia hebben verschillende rollen. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) neemt nul‑gebaseerde start‑/eind‑rij‑ en kolom‑indexen. [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) neemt daarentegen de bovenste rij, linker kolom, onderste rij en rechter kolom. Het voorbeeld gebruikt rijnummer 55 en kolomnummer 25 als de rechtsonder‑grenzen; deze waarden zijn layout‑keuzes, niet het aantal gegevensrijen of -kolommen.

Het dia‑kader gebruikt punten. Het voorbeeld past het binnen de dia en centreert het terwijl de beeldverhouding van de PNG behouden blijft, in plaats van de preview uit te rekken om de dia te vullen.

## **Maak en embed het diagram**

Het volgende volledige voorbeeld vult `DataSheet` met vier rijen en vijf kolommen waarden. Elke rij wordt een diagramreeks. `ChartSheet` wordt geselecteerd als het actieve blad voordat de werkmap wordt opgeslagen.

De werkmap wordt expliciet opgeslagen als XLSX, passend bij de `xlsx`‑extensie die wordt doorgegeven aan [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/). De PNG wordt geladen vanuit een in‑memory‑stream zonder een tussenliggende bitmap‑conversie. Aspose.Cells retourneert byte‑vectors, die het voorbeeld kopieert naar het array‑type dat door Aspose.Slides wordt geaccepteerd. Initialiseert u Aspose.Cells voordat u de objecten gebruikt, en geef hun resources vrij nadat die objecten zijn vernietigd. Toewijzing via [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) vervangt de standaard OLE‑placeholder.

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

// Initialiseert Cells voordat er een van zijn objecten wordt aangemaakt.
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

    // Render de diagrampreview en serialiseer de bewerkbare werkmap apart.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // Kopieer Cells‑buffers naar het array‑type dat door Slides wordt gebruikt.
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

    // Pas de preview aan binnen de dia zonder de beeldverhouding te wijzigen.
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
// Geef Cells‑resources vrij nadat alle Cells‑objecten zijn vernietigd.
Aspose::Cells::Cleanup();
```

## **Verwacht resultaat**

`OutputChart.pptx` bevat één dia met een ingebedde Excel‑werkmap en een diagram‑preview. De werkmap bevat de oorspronkelijke gegevens en een kolomdiagram met vier series. De preview staat gecentreerd op de dia en behoudt haar verhoudingen.

![Excel kolomdiagram weergegeven als de preview van een ingebedde werkmap](excel-chart-ole-preview.png)

In een compatibele desktop‑PowerPoint‑omgeving met Excel beschikbaar, dubbelklikt u op het object om het ingebedde werkmap te activeren en te bewerken. Activering en bewerken hangen af van de OLE‑ondersteuning en de beveiligingsinstellingen van de host‑applicatie.

## **FAQ**

**Waarom is een preview‑afbeelding nodig?**

De ingebedde werkmap en de slide‑preview zijn afzonderlijke inhoud. Lever een diagramafbeelding aan zodat de dia het diagram toont in plaats van de standaard “EMBEDDED OLE OBJECT” placeholder. Zie [Objectpreview-probleem bij het toevoegen van OleObjectFrame](/slides/nl/cpp/object-preview-issue-when-adding-oleobjectframe/).

**Wordt de preview automatisch bijgewerkt wanneer ik de werkmap in code wijzig?**

Beschouw de preview als een momentopname. Bij het programmatisch bijwerken van de werkmapgegevens, regenereert u de diagramafbeelding en vervangt u zowel de preview als de ingesloten werkmapgegevens.

**Kan ik XLS in plaats van XLSX gebruiken?**

Ja. Sla de werkmap op in XLS‑formaat en gebruik `xls` als de extensie voor de ingesloten data. De extensie moet overeenkomen met het feitelijke werkmapformaat; alleen de extensie wijzigen converteert de data niet.

**Waarom kan het object van grootte veranderen na activatie?**

De host‑applicatie kan de presentatie van het OLE‑object bijwerken wanneer het de werkmap activeert. Het OLE‑weergavebereik van de werkmap en de afmetingen van het dia‑kader zijn beide belangrijk. Zie [Werkende oplossing voor diagram‑schaling in PPTX](/slides/nl/cpp/working-solution-for-chart-resizing-in-pptx/).

## **Gerelateerde secties**

- [Werkende oplossing voor diagram‑schaling in PPTX](/slides/nl/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Objectpreview-probleem bij het toevoegen van OleObjectFrame](/slides/nl/cpp/object-preview-issue-when-adding-oleobjectframe/)