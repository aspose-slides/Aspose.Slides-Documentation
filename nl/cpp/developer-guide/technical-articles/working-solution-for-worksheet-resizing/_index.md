---
title: Werkende oplossing voor het schalen van werkbladen
type: docs
weight: 130
url: /nl/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- voorbeeldafbeelding
- afbeelding schalen
- Excel
- werkblad
- PowerPoint
- presentatie
- C++
- Aspose.Slides for C++
description: "Werkende oplossing voor het schalen van werkbladen in PowerPoint-presentaties met behulp van C++"
---
{{% alert color="info" %}}

Er is geconstateerd dat Excel-werkbladen die als OLE‑objecten in een PowerPoint‑presentatie worden ingebed via Aspose‑componenten, na de eerste activering worden geschaald naar een onbekende factor. Dit leidt tot een opvallend visueel verschil in de presentatie tussen de toestand vóór en ná de activering van het OLE‑object. We hebben dit probleem gedetailleerd onderzocht en een oplossing geboden, die in dit artikel wordt behandeld.

{{% /alert %}}

## **Achtergrond**

In het artikel [Beheer OLE](/slides/nl/cpp/manage-ole/) legden we uit hoe je een OLE‑frame toevoegt aan een PowerPoint‑presentatie met Aspose.Slides for C++. Om het [object‑preview‑probleem](/slides/nl/cpp/object-preview-issue-when-adding-oleobjectframe/) op te lossen, hebben we een afbeelding van het geselecteerde werkbladgebied aan het OLE‑objectframe gekoppeld. In de resulterende presentatie, wanneer je dubbelklikt op het OLE‑objectframe dat de werkbladin­ afbeelding toont, wordt de Excel‑werkmap geactiveerd. Eindgebruikers kunnen de werkelijke Excel‑werkmap naar wens aanpassen en vervolgens terugkeren naar de dia door buiten de geactiveerde Excel‑werkmap te klikken. Bij terugkeer zal de grootte van het OLE‑objectframe wijzigen. De schaalfactor varieert afhankelijk van de grootte van het OLE‑objectframe en de ingebedde Excel‑werkmap.

## **Oorzaak van het schalen**

Aangezien de Excel‑werkmap haar eigen venstergrootte heeft, probeert ze bij de eerste activering haar oorspronkelijke afmeting te behouden. Het OLE‑objectframe heeft daarentegen zijn eigen afmeting. Volgens Microsoft, wanneer de Excel‑werkmap wordt geactiveerd, onderhandelen Excel en PowerPoint over de grootte om de juiste verhoudingen te behouden als onderdeel van het insluitingsproces. Het schalen ontstaat door de verschillen tussen de Excel‑venstergrootte en de afmeting en positie van het OLE‑objectframe.

## **Werkende oplossing**

Er zijn twee mogelijke oplossingen om het schaaleffect te vermijden.

- Schaal de grootte van het OLE‑frame in de PowerPoint‑presentatie zodat deze overeenkomt met de hoogte en breedte van het gewenste aantal rijen en kolommen in het OLE‑frame.
- Houd de grootte van het OLE‑frame constant en scha al de deelnemende rijen en kolommen zodat ze passen binnen de geselecteerde OLE‑frame‑grootte.

### **Schaal de OLE‑frame‑grootte**

In deze aanpak leren we hoe we de OLE‑frame‑grootte van de ingebedde Excel‑werkmap instellen zodat deze overeenkomt met de cumulatieve grootte van de deelnemende rijen en kolommen in het Excel‑werkblad.

Stel dat we een sjabloon‑Excel‑blad hebben en dit willen toevoegen aan een presentatie als OLE‑frame. In dit scenario wordt de grootte van het OLE‑objectframe eerst berekend op basis van de cumulatieve rijhoogtes en kolombreedtes van de deelnemende rijen en kolommen in de werkmap. Vervolgens stellen we de grootte van het OLE‑frame in op deze berekende waarde. Om het rode “EMBEDDED OLE OBJECT”‑bericht voor het OLE‑frame in PowerPoint te vermijden, maken we ook een afbeelding van de gewenste delen van de rijen en kolommen in de werkmap en gebruiken we deze als OLE‑frame‑afbeelding.

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

// Stel de weergegeven grootte in wanneer het werkmapbestand wordt gebruikt als OLE-object in PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Haal de breedte en hoogte van de OLE-afbeelding op in punten.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// We moeten de aangepaste werkmap gebruiken.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook Dispose();

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

### **Schaal de celbereik‑grootte**

In deze aanpak leren we hoe we de hoogtes van de deelnemende rijen en de breedtes van de deelnemende kolommen schalen zodat ze overeenkomen met een aangepaste OLE‑frame‑grootte.

Stel dat we een sjabloon‑Excel‑blad hebben en dit willen toevoegen aan een presentatie als OLE‑frame. In dit scenario stellen we de grootte van het OLE‑frame in en schalen we de grootte van de rijen en kolommen die in het OLE‑frame‑gebied deelnemen. Vervolgens slaan we de werkmap op naar een stream om de wijzigingen toe te passen en converteren we deze naar een byte‑array om toe te voegen aan het OLE‑frame. Om het rode “EMBEDDED OLE OBJECT”‑bericht voor het OLE‑frame in PowerPoint te vermijden, maken we ook een afbeelding van de gewenste delen van de rijen en kolommen in de werkmap en gebruiken we deze als OLE‑frame‑afbeelding.

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

// Scha al het celbereik zodat het past in de frame-grootte.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// We moeten de aangepaste werkmap gebruiken.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Voeg de OLE-afbeelding toe aan de presentatieresources.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Maak het OLE-objectframe.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

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

{{% alert color="info" %}}

Er zijn twee benaderingen om het probleem met het schalen van het werkblad op te lossen. De keuze voor de juiste benadering hangt af van de specifieke vereisten en het use‑case. Beide benaderingen werken hetzelfde, of de presentaties nu vanuit een sjabloon of vanaf nul worden aangemaakt. Bovendien is er geen limiet aan de grootte van het OLE‑objectframe in deze oplossing.

{{% /alert %}}

## **FAQ**

### Waarom verandert de grootte van een ingebed Excel‑werkblad bij de eerste activering in PowerPoint?

Dit gebeurt omdat Excel bij activering probeert de oorspronkelijke venstergrootte te behouden, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat kan leiden tot schalen.

### Is het mogelijk om dit schaaleffect volledig te voorkomen?

Ja. Door het OLE‑frame te schalen naar de grootte van het Excel‑celbereik of door het celbereik te schalen naar de gewenste OLE‑frame‑grootte, kun je ongewenst schalen voorkomen.

### Welke schaalmethode moet ik gebruiken, OLE‑frame‑schalen of celbereik‑schalen?

Kies **OLE‑frame‑schalen** als je de oorspronkelijke Excel‑rij‑ en kolomgroottes wilt behouden. Kies **celbereik‑schalen** als je een vaste grootte voor het OLE‑frame in je presentatie wilt.

### Werken deze oplossingen ook als mijn presentatie gebaseerd is op een sjabloon?

Ja. Beide oplossingen werken voor presentaties die zijn gemaakt vanuit sjablonen en voor presentaties die vanaf nul zijn opgezet.

### Is er een limiet aan de grootte van het OLE‑frame bij gebruik van deze methoden?

Nee. Je kunt het OLE‑objectframe zo groot maken als je wilt, zolang je de schaal correct instelt.

### Is er een manier om de “EMBEDDED OLE OBJECT”‑plaatsvervangertekst in PowerPoint te vermijden?

Ja. Door een snapshot te maken van het doel‑Excel‑celbereik en deze in te stellen als de placeholder‑afbeelding van het OLE‑frame, kun je een aangepaste preview‑afbeelding tonen in plaats van de standaard plaatsvervanger.

## **Gerelateerde artikelen**

[Een Excel‑grafiek maken en embedden in een presentatie als OLE‑object](/slides/nl/cpp/create-excel-chart-and-embedding-it-in-presentation-as-ole-object/)