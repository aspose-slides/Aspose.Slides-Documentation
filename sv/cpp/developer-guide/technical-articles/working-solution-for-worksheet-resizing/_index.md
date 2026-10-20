---
title: Fungerande lösning för kalkylbladsstorleksändring
type: docs
weight: 130
url: /sv/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- förhandsgranskningsbild
- bildändring av storlek
- Excel
- kalkylblad
- PowerPoint
- presentation
- C++
- Aspose.Slides for C++
description: "Fungerande lösning för kalkylbladsstorleksändring i PowerPoint-presentationer med C++"
---
{{% alert color="info" title="Note" %}}

Excel- kalkylblad som är inbäddade som OLE-objekt i en PowerPoint-presentation med Aspose-komponenter kan ändra storlek oväntat efter sin första aktivering. Detta beteende skapar en märkbar visuell skillnad mellan OLE-objektet före och efter aktivering. Den här artikeln förklarar problemet och beskriver två sätt att åtgärda det.

{{% /alert %}}

## **Bakgrund**

I artikeln [Manage OLE](/slides/sv/cpp/manage-ole/) förklarade vi hur man lägger till en OLE-ram i en PowerPoint-presentation med Aspose.Slides for C++. För att lösa [object preview issue](/slides/sv/cpp/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi en bild av det markerade kalkylbladsområdet till OLE-objektramen. I den resulterande presentationen, när du dubbelklickar på OLE-objektramen som visar kalkylbladsbilden, aktiveras Excel-arbetsboken. Slutanvändare kan göra önskade ändringar i den faktiska Excel-arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade Excel-arbetsboken. Storleken på OLE-objektramen kommer att förändras när användaren återgår till bilden. Omdimensioneringsfaktorn varierar beroende på storleken på OLE-objektramen och den inbäddade Excel-arbetsboken.

## **Orsak till omdimensionering**

Eftersom Excel-arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid första aktiveringen. Å andra sidan har OLE-objektramen sin egen storlek. Enligt Microsoft, när Excel-arbetsboken aktiveras förhandlar Excel och PowerPoint om storleken för att säkerställa att den behåller korrekta proportioner som en del av inbäddningsprocessen. Omdimensioneringen sker baserat på skillnaderna mellan Excel-fönstrets storlek och OLE-objektrammans storlek och position.

## **Fungerande lösning**

Det finns två möjliga lösningar för att undvika omdimensioneringseffekten.

- Skala OLE-ramen i PowerPoint-presentationen så att den matchar den totala höjden och bredden av de valda raderna och kolumnerna.
- Håll OLE-ramens storlek konstant och skala de valda raderna och kolumnerna så att de passar inom den.

### **Skala OLE-ramens storlek**

Denna metod sätter OLE-ramens storlek så att den matchar den totala höjden och bredden av de valda raderna och kolumnerna i det inbäddade Excel-kalkylbladet.

Exemplet laddar en befintlig Excel-arbetsbok och markerar de första 10 raderna och 13 kolumnerna i dess första kalkylblad med nollbaserade index. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) definierar det visade området. Förhandsgranskningen renderas med 96 DPI, och dess pixelmått konverteras till punkter med 72 punkter per tum. [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) bäddar in den modifierade arbetsboken i en ram med dessa dimensioner. Förhandsgranskningen tilldelas via [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) för att ersätta platshållaren "EMBEDDED OLE OBJECT" i den sparade presentationen.

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

// Ställ in den visade storleken när arbetsboksfilen används som ett OLE-objekt i PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Hämta bredden och höjden på OLE-bilden i punkter.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// Vi måste använda den modifierade arbetsboken.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Lägg till OLE-bilden till presentationens resurser.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Skapa OLE-objektramen.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

Förhandsgranskningshjälpen använder [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) för att markera området och tar bort marginaler, sidhuvuden och sidfötter. Med [ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/) aktiverat renderar [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) området som en PNG-bild. Hjälpen kopierar de renderade bilddata till ett nytt minnesström placerat i början för användning i presentationen.

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

### **Skala cellområdets storlek**

Denna metod skalar höjderna på de valda raderna och breddarna på de valda kolumnerna för att matcha en anpassad OLE-ramstorlek.

Exemplet laddar en befintlig Excel-arbetsbok och markerar de första 10 raderna och 13 kolumnerna i dess första kalkylblad med nollbaserade index. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) definierar det visade området, och hjälpen nedan skalar det området för att passa in i en ram som är 400 punkter bred och 100 punkter hög. Efter att den modifierade arbetsboken sparats till en bytearray, bäddar [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) in den med den angivna storleken. En förhandsgranskning renderad med 96 DPI tilldelas via [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/), så den sparade presentationen visar de valda cellerna istället för standardplatshållaren.

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

// Ställ in den visade storleken när arbetsboksfilen används som ett OLE-objekt i PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Skala cellområdet för att passa ramens storlek.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Vi måste använda den modifierade arbetsboken.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Lägg till OLE-bilden i presentationens resurser.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Skapa OLE-objektramen.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

Skaleringshjälpen beräknar separata bredd- och höjdratioer för det valda området, vilket bevarar kolumnernas relativa bredd och radernas relativa höjd. Den konverterar de beräknade dimensionerna från punkter till tum innan de tillämpas med [Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/) och [Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/). Det valda området måste ha en bredd och höjd som inte är noll.

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">Den förväntade bredden på cellområdet i punkter.</param>
/// <param name="height">Den förväntade höjden på cellområdet i punkter.</param>
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

Denna förhandsgranskningshjälp renderar det omdimensionerade området med hjälp av [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/). Den använder [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) för att begränsa utskrift till det området, tar bort marginaler, sidhuvuden och sidfötter, och returnerar en PNG-ström placerad i början.

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

{{% alert color="info" title="Note" %}}

Det finns två tillvägagångssätt för att åtgärda problemet med kalkylbladets storleksändring. Välj det tillvägagångssätt som bäst passar dina krav och ditt användningsfall. Båda tillvägagångssätten fungerar på samma sätt, oavsett om presentationerna skapas från en mall eller från början. Dessutom finns det ingen gräns för storleken på OLE-objektramen i denna lösning.

{{% /alert %}}

## **Vanliga frågor**

**Varför ändrar ett inbäddat Excel-kalkylblad storlek när det aktiveras för första gången i PowerPoint?**

Detta händer eftersom Excel försöker behålla den ursprungliga fönsterstorleken vid aktivering, medan OLE-objektramen i PowerPoint har sina egna dimensioner. PowerPoint och Excel förhandlar om storleken för att behålla bildförhållandet, vilket kan leda till omdimensionering.

**Är det möjligt att helt förhindra detta omdimensioneringsproblem?**

Ja. Genom att skala OLE-ramen så att den passar Excel-cellområdets storlek eller skala cellområdet för att passa den önskade OLE-ramstorleken kan du förhindra oönskad omdimensionering.

**Vilken skalningsmetod bör jag använda, OLE-ramskalning eller cellområdesskalning?**

Välj **OLE-ramskalning** om du vill behålla de ursprungliga Excel-radernas och -kolumnernas storlekar. Välj **cellområdesskalning** om du vill ha en fast storlek på OLE-ramen i din presentation.

**Fungerar dessa lösningar om min presentation är baserad på en mall?**

Ja. Båda lösningarna fungerar för presentationer som skapats från mallar och från början.

**Finns det en gräns för OLE-ramens storlek när man använder dessa metoder?**

Nej. Du kan göra OLE-objektramen i vilken storlek som helst så länge du anger skalan på lämpligt sätt.

**Finns det ett sätt att undvika platshållartexten "EMBEDDED OLE OBJECT" i PowerPoint?**

Ja. Genom att ta en ögonblicksbild av det önskade Excel‑cellområdet och sätta den som OLE-ramens platshållarbild kan du visa en anpassad förhandsgranskningsbild i stället för standardplatshållaren.

## **Relaterade artiklar**

[Skapa ett Excel-diagram och bädda in det i en presentation som ett OLE-objekt](/slides/sv/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)