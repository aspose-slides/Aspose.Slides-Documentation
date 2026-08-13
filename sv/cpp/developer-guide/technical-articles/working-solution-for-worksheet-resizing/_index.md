---
title: Fungerande lösning för att ändra storlek på arbetsblad
type: docs
weight: 130
url: /sv/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- förhandsgranskningsbild
- bildskalning
- Excel
- arbetsblad
- PowerPoint
- presentation
- C++
- Aspose.Slides for C++
description: "Fungerande lösning för att ändra storlek på arbetsblad i PowerPoint-presentationer med C++"
---
{{% alert color="info" %}}

Det har observerats att Excel‑arbetsblad som bäddas in som OLE‑objekt i en PowerPoint‑presentation via Aspose‑komponenter ändras i storlek till en oidentifierad skala efter den första aktiveringen. Detta beteende skapar en märkbar visuell skillnad i presentationen mellan OLE‑objektets tillstånd före och efter aktivering. Vi har undersökt problemet i detalj och tillhandahåller en lösning som behandlas i den här artikeln.

{{% /alert %}}

## **Bakgrund**

I artikeln [Manage OLE](/slides/sv/cpp/manage-ole/) förklarade vi hur man lägger till en OLE‑ram i en PowerPoint‑presentation med Aspose.Slides för C++. För att lösa [object preview issue](/slides/sv/cpp/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi en bild av det valda arbetsbladsområdet till OLE‑objektramen. I den resulterande presentationen, när du dubbelklickar på OLE‑objektramen som visar arbetsbladsbilden, aktiveras Excel‑arbetsboken. Slutanvändare kan göra önskade ändringar i den faktiska Excel‑arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade Excel‑arbetsboken. Storleken på OLE‑objektramen kommer att förändras när användaren återvänder till bilden. Skaleringsfaktorn varierar beroende på OLE‑objektrammens storlek och den inbäddade Excel‑arbetsboken.

## **Orsak till skalning**

Eftersom Excel‑arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid den första aktiveringen. OLE‑objektramen har däremot sin egen storlek. Enligt Microsoft förhandlar Excel och PowerPoint om storleken när Excel‑arbetsboken aktiveras för att säkerställa att den behåller korrekta proportioner som en del av inbäddningsprocessen. Storleksändringen sker baserat på skillnaderna mellan Excel‑fönstrets storlek och OLE‑objektrammens storlek och position.

## **Fungerande lösning**

Det finns två möjliga lösningar för att undvika skalningseffekten.

- Skala OLE‑ramens storlek i PowerPoint‑presentationen så att den matchar höjden och bredden för önskat antal rader och kolumner i OLE‑ramen.
- Behåll OLE‑ramens storlek konstant och skala storleken på de delaktiga raderna och kolumnerna så att de passar inom den valda OLE‑ramens storlek.

### **Skala OLE‑ramens storlek**

I det här tillvägagångssättet kommer vi att lära oss hur man ställer in OLE‑ramens storlek för den inbäddade Excel‑arbetsboken så att den matchar den kumulativa storleken av de delaktiga raderna och kolumnerna i Excel‑arbetsbladet.

Anta att vi har ett mall‑Excel‑blad och vill lägga till det i en presentation som en OLE‑ram. I detta scenario beräknas först storleken på OLE‑objektramen baserat på de kumulativa radhöjderna och kolumnbredderna för de delaktiga raderna och kolumnerna i arbetsboken. Därefter ställer vi in OLE‑ramens storlek till detta beräknade värde. För att undvika det röda meddelandet "EMBEDDED OLE OBJECT" för OLE‑ramen i PowerPoint kommer vi också att fånga en bild av de önskade delarna av raderna och kolumnerna i arbetsboken och använda den som OLE‑ramens bild.

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

// Ange den visade storleken när arbetsboksfilen används som ett OLE‑objekt i PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Hämta bredden och höjden på OLE‑bilden i punkter.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// Vi måste använda den modifierade arbetsboken.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Lägg till OLE‑bilden i presentationens resurser.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Skapa OLE‑objektramen.
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

### **Skala cellintervallens storlek**

I detta tillvägagångssätt kommer vi att lära oss hur man skalar höjden på de delaktiga raderna och bredden på de delaktiga kolumnerna för att matcha en anpassad OLE‑ramstorlek.

Anta att vi har ett mall‑Excel‑blad och vill lägga till det i en presentation som en OLE‑ram. I detta scenario sätter vi storleken på OLE‑ramen och skalar storleken på de rader och kolumner som deltar i OLE‑ramens område. Därefter sparar vi arbetsboken till en ström för att tillämpa ändringarna och konverterar den till en byte‑array för att lägga till den i OLE‑ramen. För att undvika det röda meddelandet "EMBEDDED OLE OBJECT" för OLE‑ramen i PowerPoint kommer vi också att fånga en bild av de önskade delarna av raderna och kolumnerna i arbetsboken och använda den som OLE‑ramens bild.

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

// Ange den visade storleken när arbetsboksfilen används som ett OLE‑objekt i PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Skala cellintervallet för att passa ramens storlek.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Vi måste använda den modifierade arbetsboken.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Lägg till OLE‑bilden i presentationens resurser.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Skapa OLE‑objektramen.
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

/// <param name="width">Den förväntade bredden på cellintervallet i punkter.</param>
/// <param name="height">Den förväntade höjden på cellintervallet i punkter.</param>
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

## **Slutsats**

{{% alert color="info" %}}

Det finns två tillvägagångssätt för att lösa problemet med att arbetsbladet ändrar storlek. Valet av lämpligt tillvägagångssätt beror på de specifika kraven och användningsfallet. Båda tillvägagångssätten fungerar på samma sätt, oavsett om presentationerna skapas från en mall eller från början. Dessutom finns det ingen begränsning på OLE‑objektrammens storlek i denna lösning.

{{% /alert %}}

## **Vanliga frågor**

### Varför ändrar ett inbäddat Excel‑arbetsblad storlek när det aktiveras för första gången i PowerPoint?

Detta sker eftersom Excel försöker behålla den ursprungliga fönsterstorleken vid aktivering, medan OLE‑objektramen i PowerPoint har sina egna dimensioner. PowerPoint och Excel förhandlar om storleken för att bevara bildförhållandet, vilket kan leda till skalning.

### Är det möjligt att helt undvika detta skalningsproblem?

Ja. Genom att skala OLE‑ramen så att den passar Excel‑cellintervallens storlek eller skala cellintervallet så att det passar den önskade OLE‑ramstorleken kan du förhindra oönskad skalning.

### Vilken skalningsmetod bör jag använda, OLE‑ramskalning eller cellintervallskalning?

Välj **OLE frame scaling** om du vill behålla de ursprungliga Excel‑rad- och kolumnstorlekarna. Välj **cell range scaling** om du vill ha en fast storlek för OLE‑ramen i din presentation.

### Fungerar dessa lösningar om min presentation är baserad på en mall?

Ja. Båda lösningarna fungerar för presentationer skapade från mallar och från grunden.

### Finns det någon begränsning för OLE‑ramens storlek när man använder dessa metoder?

Nej. Du kan göra OLE‑objektramen i vilken storlek som helst så länge du anger skalan på lämpligt sätt.

### Finns det ett sätt att undvika platshållartexten "EMBEDDED OLE OBJECT" i PowerPoint?

Ja. Genom att ta en skärmdump av mål‑Excel‑cellintervallet och använda den som OLE‑ramens platshållarbild kan du visa en anpassad förhandsgranskningsbild istället för standard‑platshållaren.

## **Relaterade artiklar**

[Skapa ett Excel‑diagram och bädda in det i en presentation som ett OLE‑objekt](/slides/sv/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)