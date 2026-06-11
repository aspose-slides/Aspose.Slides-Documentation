---
title: Fungerande lösning för storleksändring av arbetsblad
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
description: "Fungerande lösning för storleksändring av arbetsblad i PowerPoint-presentationer med C++"
---
{{% alert color="primary" %}}
Det har observerats att Excel‑arbetsblad som bäddas in som OLE‑objekt i en PowerPoint‑presentation via Aspose‑komponenter ändras till en okänd skala efter den första aktiveringen. Detta beteende skapar en märkbar visuell skillnad i presentationen mellan för‑ och efteraktiveringslägena för OLE‑objektet. Vi har undersökt problemet i detalj och tillhandahållit en lösning, som behandlas i den här artikeln.
{{% /alert %}}

## **Bakgrund**

I artikeln [Manage OLE](/slides/sv/cpp/manage-ole/) förklarade vi hur man lägger till en OLE‑ram i en PowerPoint‑presentation med Aspose.Slides för C++. För att åtgärda [object preview issue](/slides/sv/cpp/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi en bild av det markerade arbetsbladsområdet till OLE‑ramen. I den resulterande presentationen, när du dubbelklickar på OLE‑ramen som visar arbetsbladsbilden, aktiveras Excel‑arbetsboken. Slutanvändare kan göra önskade ändringar i den faktiska Excel‑arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade Excel‑arbetsboken. Storleken på OLE‑ramen kommer att ändras när användaren återvänder till bilden. Omfångsfaktorn varierar beroende på storleken på OLE‑ramen och det inbäddade Excel‑arbetsbladet.

## **Orsak till storleksändring**

Eftersom Excel‑arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid första aktiveringen. Å andra sidan har OLE‑ramen sin egen storlek. Enligt Microsoft förhandlar Excel och PowerPoint om storleken när Excel‑arbetsboken aktiveras, för att säkerställa att den behåller rätt proportioner som en del av inbäddningsprocessen. Storleksändringen sker baserat på skillnaderna mellan Excel‑fönstrets storlek och OLE‑ramens storlek och position.

## **Fungerande lösning**

Det finns två möjliga lösningar för att undvika storleksändringseffekten.

- Skala OLE‑ramens storlek i PowerPoint‑presentationen så att den matchar höjd och bredd för det önskade antalet rader och kolumner i OLE‑ramen.
- Håll OLE‑ramens storlek konstant och skala storleken på de medverkande raderna och kolumnerna så att de får plats inom den valda OLE‑ramstorleken.

### **Skala OLE‑ramens storlek**

I detta tillvägagångssätt lär vi oss hur man ställer in OLE‑ramens storlek för det inbäddade Excel‑arbetsbladet så att den matchar den kumulativa storleken på de medverkande raderna och kolumnerna i Excel‑arbetsbladet.

Anta att vi har ett mall‑Excel‑ark och vill lägga till det i en presentation som en OLE‑ram. I detta scenario beräknas först OLE‑ramens storlek baserat på den kumulativa radhöjden och kolumnbredden för de medverkande raderna och kolumnerna i arbetsboken. Därefter sätter vi OLE‑ramens storlek till detta beräknade värde. För att undvika den röda “EMBEDDED OLE OBJECT”-meddelandet för OLE‑ramen i PowerPoint kommer vi också att fånga en bild av de önskade delarna av raderna och kolumnerna i arbetsboken och använda den som OLE‑ramens bild.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Ställ in den visade storleken när arbetsboksfilen används som ett OLE‑objekt i PowerPoint.
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

### **Skala cellområde‑storlek**

I detta tillvägagångssätt lär vi oss hur man skalar höjden på de medverkande raderna och bredden på de medverkande kolumnerna för att matcha en anpassad OLE‑ramstorlek.

Anta att vi har ett mall‑Excel‑ark och vill lägga till det i en presentation som en OLE‑ram. I detta scenario sätter vi OLE‑ramens storlek och skalar storleken på de rader och kolumner som deltar i OLE‑ramens område. Därefter sparar vi arbetsboken till en ström för att tillämpa ändringarna och konverterar den till en byte‑array för att lägga till den i OLE‑ramen. För att undvika den röda “EMBEDDED OLE OBJECT”-meddelandet för OLE‑ramen i PowerPoint kommer vi också att fånga en bild av de önskade delarna av raderna och kolumnerna i arbetsboken och använda den som OLE‑ramens bild.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Ställ in den visade storleken när arbetsboksfilen används som ett OLE‑objekt i PowerPoint.
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

```cpp
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

{{% alert color="primary" %}}
Det finns två tillvägagångssätt för att lösa problemet med att arbetsbladet ändrar storlek. Valet av lämpligt tillvägagångssätt beror på specifika krav och användningsfall. Båda metoderna fungerar på samma sätt, oavsett om presentationerna skapas från en mall eller från grunden. Dessutom finns det ingen begränsning för OLE‑ramens storlek i denna lösning.
{{% /alert %}}

## **FAQ**

**Varför förändras storleken på ett inbäddat Excel‑arbetsblad vid första aktiveringen i PowerPoint?**

Det händer eftersom Excel försöker behålla det ursprungliga fönstermåttet vid aktivering, medan OLE‑ramen i PowerPoint har egna dimensioner. PowerPoint och Excel förhandlar storleken för att behålla bildförhållandet, vilket kan leda till storleksändring.

**Kan man helt undvika detta storleksändringsproblem?**

Ja. Genom att skala OLE‑ramen så att den passar Excel‑cellområdets storlek eller genom att skala cellområdet så att det passar den önskade OLE‑ramens storlek kan oönskad storleksändring förhindras.

**Vilken skalningsmetod bör jag använda, OLE‑ram‑skalning eller cellområdes‑skalning?**

Välj **OLE‑ram‑skalning** om du vill behålla de ursprungliga Excel‑rad- och kolumnstorlekarna. Välj **cellområdes‑skalning** om du vill ha en fast storlek för OLE‑ramen i din presentation.

**Fungerar dessa lösningar om min presentation är baserad på en mall?**

Ja. Båda lösningarna fungerar för presentationer som skapats från mallar och från grunden.

**Finns det någon gräns för OLE‑ramens storlek när man använder dessa metoder?**

Nej. Du kan göra OLE‑objektram så stor du vill så länge du anger rätt skala.

**Finns det ett sätt att undvika platshållartexten “EMBEDDED OLE OBJECT” i PowerPoint?**

Ja. Genom att ta ett ögonblicksavbild av det önskade Excel‑cellområdet och använda det som OLE‑ramens platshållarbild kan du visa en egen förhandsgranskningsbild i stället för standardplatshållaren.

## **Relaterade artiklar**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/sv/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)