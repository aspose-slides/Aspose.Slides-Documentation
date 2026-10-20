---
title: Werkende oplossing voor het verkleinen van werkbladen
type: docs
weight: 130
url: /nl/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- voorbeeldafbeelding
- afbeeldingsgrootte aanpassen
- Excel
- werkblad
- PowerPoint
- presentatie
- C++
- Aspose.Slides for C++
description: "Werkende oplossing voor werkbladverkleining in PowerPoint-presentaties met C++"
---
{{% alert color="info" title="Opmerking" %}}

Excel‑werkbladen die als OLE‑objecten in een PowerPoint‑presentatie zijn ingesloten met behulp van Aspose‑componenten, kunnen onverwachts van grootte veranderen na hun eerste activering. Dit gedrag veroorzaakt een merkbaar visueel verschil tussen het OLE‑object vóór en na de activering. Dit artikel legt het probleem uit en beschrijft twee manieren om het op te lossen.

{{% /alert %}}

## **Achtergrond**

In het artikel [Beheer OLE](/slides/nl/cpp/manage-ole/) legden we uit hoe je een OLE‑frame aan een PowerPoint‑presentatie kunt toevoegen met Aspose.Slides for C++. Om het [probleem met voorbeeldweergave van object](/slides/nl/cpp/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, koppelden we een afbeelding van het geselecteerde werkbladgebied aan het OLE‑objectframe. In de gegenereerde presentatie, wanneer je dubbelklikt op het OLE‑objectframe dat de werkbladafbeelding weergeeft, wordt de Excel‑werkmap geactiveerd. Eindgebruikers kunnen gewenste wijzigingen aanbrengen in de feitelijke Excel‑werkmap en vervolgens terugkeren naar de dia door buiten de geactiveerde Excel‑werkmap te klikken. De grootte van het OLE‑objectframe zal veranderen wanneer de gebruiker terugkeert naar de dia. De resize‑factor varieert afhankelijk van de grootte van het OLE‑objectframe en de ingebedde Excel‑werkmap.

## **Oorzaak van verkleining**

Aangezien de Excel‑werkmap zijn eigen venstergrootte heeft, probeert hij bij de eerste activering zijn oorspronkelijke grootte te behouden. Het OLE‑objectframe heeft echter zijn eigen afmetingen. Volgens Microsoft onderhandelen Excel en PowerPoint over de grootte wanneer de Excel‑werkmap wordt geactiveerd, zodat de juiste verhoudingen behouden blijven als onderdeel van het ingebed‑proces. De verkleining ontstaat op basis van de verschillen tussen de Excel‑venstergrootte en de grootte en positie van het OLE‑objectframe.

## **Werkende oplossing**

Er zijn twee mogelijke oplossingen om het verkleinings‑effect te vermijden.

- Schaal het OLE‑frame in de PowerPoint‑presentatie zodat het overeenkomt met de totale hoogte en breedte van de geselecteerde rijen en kolommen.  
- Houd de grootte van het OLE‑frame constant en schaal de geselecteerde rijen en kolommen zodat ze erin passen.

### **Schaal de OLE‑framegrootte**

Deze benadering stelt de OLE‑framegrootte in zodat deze overeenkomt met de totale hoogte en breedte van de geselecteerde rijen en kolommen in het ingebedde Excel‑werkblad.

Het voorbeeld laadt een bestaande Excel‑werkmap en selecteert de eerste 10 rijen en 13 kolommen van het eerste werkblad met nul‑gebaseerde indexen. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) bepaalt het weergegeven bereik. De voorbeeldweergave wordt gerenderd op 96 DPI en de pixelafmetingen worden omgezet naar punten met 72 punten per inch. [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) embedde de gewijzigde werkmap in een frame met die afmetingen. De voorbeeldweergave wordt toegewezen via [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) om de “EMBEDDED OLE OBJECT”‑placeholder in de opgeslagen presentatie te vervangen.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/image.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// We need to use the modified workbook.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Add the OLE image to the presentation resources.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

De preview‑helper gebruikt [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) om het bereik te selecteren en verwijdert marges, kop‑ en voetteksten. Met [ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/) ingeschakeld, rendert [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) het bereik als een PNG‑afbeelding. De helper kopieert de gerenderde afbeeldingsdata naar een nieuwe geheugen‑stream die op het begin is gepositioneerd voor gebruik in de presentatie.

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

### **Schaal de celbereikgrootte**

Deze benadering schaalt de hoogtes van de geselecteerde rijen en de breedtes van de geselecteerde kolommen zodat ze passen bij een aangepaste OLE‑framegrootte.

Het voorbeeld laadt een bestaande Excel‑werkmap en selecteert de eerste 10 rijen en 13 kolommen van het eerste werkblad met nul‑gebaseerde indexen. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) bepaalt het weergegeven bereik, en de helper hieronder schaalt dat bereik zodat het past in een frame van 400 punten breed en 100 punten hoog. Na het opslaan van de gewijzigde werkmap naar een byte‑array embedt [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) deze op de opgegeven grootte. Een voorbeeldweergave gerenderd op 96 DPI wordt toegewezen via [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/), zodat de opgeslagen presentatie de geselecteerde cellen toont in plaats van de standaard placeholder.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Stel de weergegeven grootte in wanneer het werkmapbestand wordt gebruikt als OLE-object in PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Schaal het celbereik zodat het in de frame-grootte past.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// We moeten de aangepaste werkmap gebruiken.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Voeg de OLE-afbeelding toe aan de bronnen van de presentatie.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

De schaal‑helper berekent afzonderlijke breedte‑ en hoogteratio’s voor het geselecteerde bereik, waarbij de relatieve breedtes van de kolommen en de relatieve hoogtes van de rijen behouden blijven. De berekende afmetingen worden omgezet van punten naar inches voordat ze worden toegepast met [Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/) en [Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/). Het geselecteerde bereik moet een niet‑nul breedte en hoogte hebben.

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">De verwachte breedte van het celbereik in punten.</param>
/// <param name="height">De verwachte hoogte van het celbereik in punten.</param>
void ScaleCellRange(Aspose::Cells::Range cellRange, float width, float height)
{
    auto rangeWidth = cellRange.GetWidth();
    auto rangeHeight = cellRange.GetHeight();

    for (int i = 0; i < cellRange.GetColumnCount(); i++)
    {
        auto columnIndex = cellRange.GetFirstColumn() + i;
        auto columnWidth = cellRange.GetWorksheet().GetCells().GetColumnWidth(columnIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newColumnWidth = columnWidth * width / rangeWidth;
        auto widthInInches = newColumnWidth / 72;
        cellRange.GetWorksheet().GetCells().SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.GetRowCount(); i++)
    {
        auto rowIndex = cellRange.GetFirstRow() + i;
        auto rowHeight = cellRange.GetWorksheet().GetCells().GetRowHeight(rowIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newRowHeight = rowHeight * height / rangeHeight;
        auto heightInInches = newRowHeight / 72;
        cellRange.GetWorksheet().GetCells().SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

Deze preview‑helper rendert het vergrote bereik met [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/). Ze gebruikt [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) om het afdrukken te beperken tot dat bereik, verwijdert marges, kop‑ en voetteksten, en retourneert een PNG‑stream die zich aan het begin bevindt.

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

## **Conclusie**

{{% alert color="info" title="Opmerking" %}}

Er zijn twee benaderingen om het verkleiningsprobleem van het werkblad op te lossen. Kies de benadering die het beste bij uw eisen en use‑case past. Beide benaderingen werken op dezelfde manier, of de presentaties nu vanuit een sjabloon of vanaf nul worden aangemaakt. Bovendien is er geen limiet aan de grootte van het OLE‑objectframe in deze oplossing.

{{% /alert %}}

## **FAQ**

**Waarom verandert een ingebed Excel‑werkblad van grootte bij de eerste activering in PowerPoint?**

Dit gebeurt omdat Excel bij activering probeert de oorspronkelijke venstergrootte te behouden, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat kan leiden tot verkleining.

**Is het mogelijk om dit verkleiningsprobleem volledig te voorkomen?**

Ja. Door het OLE‑frame te schalen zodat het past bij de grootte van het Excel‑celbereik, of door het celbereik te schalen zodat het past bij de gewenste OLE‑framegrootte, kun je ongewenste verkleining voorkomen.

**Welke schaalmethode moet ik gebruiken, OLE‑frame schalen of celbereik schalen?**

Kies **OLE‑frame schalen** als je de originele Excel‑rij‑ en kolomgroottes wilt behouden. Kies **celbereik schalen** als je een vaste grootte voor het OLE‑frame in je presentatie wilt.

**Werken deze oplossingen als mijn presentatie gebaseerd is op een sjabloon?**

Ja. Beide oplossingen werken zowel voor presentaties die vanuit sjablonen als vanuit een lege presentatie zijn gemaakt.

**Is er een limiet aan de grootte van het OLE‑frame bij het gebruik van deze methoden?**

Nee. Je kunt het OLE‑objectframe elke gewenste grootte geven, zolang je de schaal correct instelt.

**Is er een manier om de “EMBEDDED OLE OBJECT”‑placeholdertekst in PowerPoint te vermijden?**

Ja. Door een snapshot van het doel‑Excel‑celbereik te maken en deze als placeholder‑afbeelding voor het OLE‑frame in te stellen, kun je een aangepaste voorbeeldafbeelding weergeven in plaats van de standaard placeholder.

## **Gerelateerde artikelen**

[Een Excel‑grafiek maken en insluiten in een presentatie als OLE‑object](/slides/nl/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)