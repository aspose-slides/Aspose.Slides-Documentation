---
title: Werkende oplossing voor grafiekhergroting in PPTX
type: docs
weight: 60
url: /nl/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafiekhergroting
- Excel‑grafiek
- OLE‑object
- grafiek insluiten
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Los onverwachte grafiekhergroting op in PPTX bij het gebruik van ingesloten Excel OLE‑objecten met Aspose.Slides voor C++. Stel vaste grafiekafmetingen in om de grafiek‑ en OLE‑frame‑groottes consistent te houden."
---
## **Achtergrond**

Excel-grafieken die als OLE-objecten zijn ingesloten in PowerPoint‑presentaties met Aspose‑componenten kunnen van grootte veranderen na hun eerste activering. Dit kan een merkbaar verschil veroorzaken in het uiterlijk van de grafiek vóór en na activering. Dit artikel legt uit waarom het schalen gebeurt en laat zien hoe het te voorkomen door vaste grafiekafmetingen op het OLE‑frame af te stemmen.

In [Excel‑grafieken maken en insluiten als OLE‑objecten in presentaties](/slides/nl/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) hebben we uitgelegd hoe je met Aspose.Cells voor C++ een Excel‑grafiek maakt en deze met Aspose.Slides voor C++ in een PowerPoint‑presentatie insluit. Om het [object‑preview‑probleem](/slides/nl/cpp/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we de grafiekafbeelding toegewezen aan het OLE‑objectframe van de grafiek. In de gegenereerde presentatie, wanneer je dubbelklikt op het OLE‑objectframe dat de grafiekafbeelding weergeeft, wordt de Excel‑grafiek geactiveerd. Gebruikers kunnen de ingesloten Excel‑werkmap bewerken en vervolgens terugkeren naar de dia door buiten de geactiveerde werkmap te klikken. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia, en de schaalfactor varieert afhankelijk van de oorspronkelijke afmetingen van zowel het OLE‑objectframe als de ingesloten Excel‑werkmap.

## **Oorzaak van de grootteaanpassing**

De ingesloten Excel‑werkmap heeft zijn eigen venstergrootte, die Excel probeert te behouden wanneer het object voor het eerst wordt geactiveerd. Het OLE‑frame op de dia heeft onafhankelijk gedefinieerde afmetingen. Wanneer de Excel‑werkmap wordt geactiveerd, onderhandelen Excel en PowerPoint over de grootte van het object om de verhoudingen te behouden als onderdeel van het insluitingsproces. Verschillen tussen het werkmap‑venster en het OLE‑frame kunnen daarom de objectgrootte laten wijzigen.

## **Werkende oplossing**

Stem de grafiekgrootte af op het OLE‑frame op de dia en houd de grafiekafmetingen onafhankelijk van het werkmap‑venster. Deze oplossing werkt met een nieuwe presentatie of een bestaand sjabloon.

Het voorbeeld vereist Aspose.Cells voor C++ en Aspose.Slides voor C++. Het maakt een eenvoudige kolomgrafiek op een actieve grafiekblad en sluit de werkmap in XLS‑formaat in. Er wordt geen voorbeeldafbeelding voor de grafiek toegewezen; de grafiek wordt zichtbaar wanneer het OLE‑object in PowerPoint wordt geactiveerd.

Plaats de voorbeeldcode in het instappunt van je toepassing, met de include‑declaraties op bestandsniveau. Initialise er Aspose.Cells voordat je zijn objecten maakt en maak zijn bronnen vrij nadat die objecten zijn vernietigd. Het voorbeeld kopieert de byte‑vector van de werkmap die door Aspose.Cells wordt geretourneerd naar het array‑type dat door Aspose.Slides wordt geaccepteerd.

Het voorbeeld creëert een nieuwe presentatie met een OLE‑frame van 9,5 × 4 inch, gepositioneerd 0,5 inch vanaf de linkerrand en 1 inch vanaf de bovenkant. Dia‑coördinaten en afmetingen worden in punten opgegeven (72 punten per inch). Voor een bestaande presentatie, zie [Een sjabloon gebruiken](#use-a-template).

## **Stel een vaste grafiekgrootte in**

Stel [Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) in op false zodat de grafiekafmetingen onafhankelijk zijn van het werkmap‑venster. Stel de afmetingen van [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) in via [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) en [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/), waarbij punten naar pixels worden omgezet met 96 pixels per inch: een frame van 684 × 288 punten komt overeen met een grafiek van 912 × 384 pixels. Stel [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) in op de aangepaste waarde van [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/). Het voorbeeld sluit de werkmap in met [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) en slaat een presentatie op met een OLE‑frame van 9,5 × 4 inch.

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

    // Dia‑coördinaten en -afmetingen zijn in punten (72 punten per inch).
    auto width = 684.f; // 9,5 inch.
    auto height = 288.f; // 4 inch.

    chart.SetSizeWithWindow(false);
    // Converteer punten naar grafiekpixels met 96 pixels per inch.
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // Kopieer de Cells byte vector naar het array type dat door Slides wordt geaccepteerd.
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **Gebruik een sjabloon**

De logica voor het bepalen van de grootte is hetzelfde voor een bestaande presentatie. Om het voorbeeld aan te passen:

1. Laad de sjabloonpresentatie in plaats van een lege presentatie te creëren.  
1. Controleer of de eerste dia minstens drie vormen bevat, en gebruik vervolgens de vorm met index 2 als placeholder.  
1. Neem de frame‑breedte en -hoogte van die vorm in plaats van de vaste waarden 684 en 288. Houd de berekeningen voor de afmetingen ongewijzigd.  
1. Voeg het OLE‑frame toe op de positie van de placeholder in plaats van de vaste coördinaten 36 en 72.  
1. Verwijder de placeholder voordat je de presentatie opslaat.

## **Veelgestelde vragen**

**Waarom verandert de grootte van mijn ingesloten Excel‑grafiek na activering in PowerPoint?**

Dit gebeurt omdat Excel probeert de oorspronkelijke venstergrootte te herstellen bij de eerste activering, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat kan leiden tot een grootte‑aanpassing.

**Hoe kan ik de grafiek‑ en OLE‑frame‑groottes consistent houden?**

Stel vaste grafiekafmetingen in die overeenkomen met het OLE‑frame en gebruik een aangepaste grafiek‑printgrootte voordat je de werkmap insluit. Het bovenstaande voorbeeld toont de vereiste instellingen en eenhedenomzettingen.

**Is het afstemmen van de werkmap‑venstergrootte voldoende?**

Alleen het afstemmen van de werkmap‑venstergrootte voorkomt niet betrouwbaar dat het OLE‑frame van grootte verandert na activering. Gebruik vaste grafiekafmetingen zoals getoond in het voorbeeld.

**Werkt deze oplossing zowel voor sjabloon‑gebaseerde als voor nieuwe presentaties?**

Ja. Voor een sjabloon gebruik je de afmetingen en positie van de placeholder. Voor een nieuwe presentatie specificeer je de frame‑afmetingen en positie direct.

**Kan ik dit voorbeeld gebruiken met grafieken die in andere spreadsheet‑programma’s zijn gemaakt?**

Het voorbeeld maakt gebruik van een Excel‑werkmap die is aangemaakt met Aspose.Cells. Het demonstreert geen activeringsgedrag voor andere spreadsheet‑programma’s.

## **Gerelateerde secties**

- [Excel‑grafieken maken en insluiten als OLE‑objecten in presentaties](/slides/nl/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)