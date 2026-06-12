---
title: Werkende oplossing voor werkbladschaling
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
- Aspose.Slides voor C++
description: "Werkende oplossing voor werkbladschaling in PowerPoint-presentaties met C++"
---
{{% alert color="primary" %}}
Er is waargenomen dat Excel-werkbladen die als OLE-objecten in een PowerPoint-presentatie via Aspose-componenten zijn ingebed, na de eerste activering worden geschaald naar een onbekende schaal. Dit gedrag veroorzaakt een duidelijk visueel verschil in de presentatie tussen de voor- en na-activatiestatus van het OLE-object. We hebben dit probleem grondig onderzocht en een oplossing geboden, die in dit artikel wordt beschreven.
{{% /alert %}}

## **Achtergrond**

In het artikel [Manage OLE](/slides/nl/cpp/manage-ole/) legden we uit hoe je met Aspose.Slides voor C++ een OLE-frame kunt toevoegen aan een PowerPoint-presentatie. Om het [object preview issue](/slides/nl/cpp/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we een afbeelding van het geselecteerde werkbladgebied toegewezen aan het OLE-objectframe. In de gegenereerde presentatie, wanneer je dubbelklikt op het OLE-objectframe dat de werkbladafbeelding toont, wordt de Excel-werkmap geactiveerd. Eindgebruikers kunnen de gewenste wijzigingen aanbrengen in de daadwerkelijke Excel-werkmap en vervolgens terugkeren naar de dia door buiten de geactiveerde Excel-werkmap te klikken. De grootte van het OLE-objectframe verandert wanneer de gebruiker terugkeert naar de dia. De schaalfactor varieert afhankelijk van de grootte van het OLE-objectframe en de ingebedde Excel-werkmap.

## **Oorzaak van het schalen**

Aangezien de Excel-werkmap een eigen venstergrootte heeft, probeert deze bij de eerste activering de oorspronkelijke grootte te behouden. Het OLE-objectframe daarentegen heeft een eigen afmeting. Volgens Microsoft onderhandelen Excel en PowerPoint over de grootte zodra de Excel-werkmap wordt geactiveerd, om ervoor te zorgen dat de juiste verhoudingen behouden blijven tijdens het inbedden. Het schalen vindt plaats op basis van de verschillen tussen de Excel-venstergrootte en de afmetingen en positie van het OLE-objectframe.

## **Werkende oplossing**

Er zijn twee mogelijke oplossingen om het schalings-effect te voorkomen.

- Schaal de OLE-framegrootte in de PowerPoint-presentatie zodat deze overeenkomt met de hoogte en breedte van het gewenste aantal rijen en kolommen in het OLE-frame.
- Houd de OLE-framegrootte constant en schaald de grootte van de deelnemende rijen en kolommen zodat ze binnen de geselecteerde OLE-framegrootte passen.

### **Schaal de OLE-framegrootte**

In deze aanpak leren we hoe we de OLE-framegrootte van de ingebedde Excel-werkmap kunnen instellen zodat deze overeenkomt met de cumulatieve grootte van de deelnemende rijen en kolommen in het Excel-werkblad.

Stel dat we een sjabloon-Excelblad hebben en dit als OLE-frame aan een presentatie willen toevoegen. In dit scenario wordt de grootte van het OLE-objectframe eerst berekend op basis van de cumulatieve rijhoogtes en kolombreedtes van de deelnemende rijen en kolommen in de werkmap. Vervolgens stellen we de grootte van het OLE-frame in op deze berekende waarde. Om het rode "EMBEDDED OLE OBJECT"-bericht voor het OLE-frame in PowerPoint te vermijden, maken we ook een afbeelding van de gewenste delen van de rijen en kolommen in de werkmap en stellen we deze in als het OLE-framebeeld.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Stel de weergegeven grootte in wanneer het werkboekbestand wordt gebruikt als OLE-object in PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// We moeten het aangepaste werkboek gebruiken.
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

### **Schaal de celbereikgrootte**

In deze aanpak leren we hoe we de hoogtes van de deelnemende rijen en de breedtes van de deelnemende kolommen kunnen schalen zodat ze passen bij een aangepaste OLE-framegrootte.

Stel dat we een sjabloon-Excelblad hebben en dit als OLE-frame aan een presentatie willen toevoegen. In dit scenario stellen we de grootte van het OLE-frame in en schalen we de grootte van de rijen en kolommen die deelnemen aan het OLE-framegebied. Vervolgens slaan we de werkmap op in een stream om de wijzigingen toe te passen en zetten we deze om naar een byte-array om deze aan het OLE-frame toe te voegen. Om het rode "EMBEDDED OLE OBJECT"-bericht voor het OLE-frame in PowerPoint te vermijden, maken we ook een afbeelding van de gewenste delen van de rijen en kolommen in de werkmap en stellen we deze in als het OLE-framebeeld.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Stel de weergegeven grootte in wanneer het werkboekbestand wordt gebruikt als OLE-object in PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Scha al het celbereik zodat het past bij de framegrootte.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// We moeten het gewijzigde werkboek gebruiken.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Voeg de OLE-afbeelding toe aan de presentatieresources.
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

```cpp
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

{{% alert color="primary" %}}
Er zijn twee benaderingen om het probleem met het schalen van het werkblad op te lossen. De keuze voor de juiste benadering hangt af van de specifieke eisen en het use-case. Beide benaderingen werken op dezelfde manier, of de presentaties nu vanuit een sjabloon of vanaf nul worden gemaakt. Bovendien is er geen limiet aan de grootte van het OLE-objectframe in deze oplossing.
{{% /alert %}}

## **FAQ**

**Waarom verandert de grootte van een ingebed Excel-werkblad bij de eerste activering in PowerPoint?**

Dit gebeurt omdat Excel bij activering probeert de oorspronkelijke venstergrootte te behouden, terwijl het OLE-objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat kan leiden tot schalen.

**Is het mogelijk om dit schalingsprobleem volledig te voorkomen?**

Ja. Door het OLE-frame te schalen zodat het past bij de grootte van het Excel-celbereik, of door het celbereik te schalen zodat het past bij de gewenste OLE-framegrootte, kun je ongewenste schaling voorkomen.

**Welke schalmethode moet ik gebruiken, OLE-frame-schaling of celbereik-schaling?**

Kies **OLE frame scaling** als je de oorspronkelijke Excel-rij- en kolomgroottes wilt behouden. Kies **cell range scaling** als je een vaste grootte voor het OLE-frame in je presentatie wilt.

**Werken deze oplossingen als mijn presentatie is gebaseerd op een sjabloon?**

Ja. Beide oplossingen werken voor presentaties die vanuit sjablonen of vanaf nul zijn gemaakt.

**Is er een limiet aan de grootte van het OLE-frame bij het gebruik van deze methoden?**

Nee. Je kunt het OLE-objectframe naar elke gewenste grootte maken, zolang je de schaal correct instelt.

**Is er een manier om de tekst "EMBEDDED OLE OBJECT" als tijdelijke aanduiding in PowerPoint te vermijden?**

Ja. Door een snapshot van het gewenste Excel-celbereik te maken en deze in te stellen als de tijdelijke plaatafbeelding van het OLE-frame, kun je een aangepaste voorbeeldafbeelding weergeven in plaats van de standaard tijdelijke aanduiding.

## **Gerelateerde artikelen**

[Een Excel-grafiek maken en deze in een presentatie als OLE-object insluiten](/slides/nl/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)