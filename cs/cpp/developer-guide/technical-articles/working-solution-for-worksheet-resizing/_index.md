---
title: Řešení pro změnu velikosti listu
type: docs
weight: 130
url: /cs/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- náhledový obrázek
- změna velikosti obrázku
- Excel
- list
- PowerPoint
- prezentace
- C++
- Aspose.Slides for C++
description: "Pracovní řešení pro změnu velikosti listu v prezentacích PowerPoint pomocí C++"
---
{{% alert color="info" %}}

Bylo zjištěno, že listy Excelu vložené jako OLE objekty do prezentace PowerPoint prostřednictvím komponent Aspose jsou po první aktivaci přepočítány na neznámé měřítko. Toto chování vytváří patrný vizuální rozdíl v prezentaci mezi stavem OLE objektu před a po aktivaci. Problém jsme podrobně prozkoumali a poskytli řešení, které je popsáno v tomto článku.

{{% /alert %}}

## **Pozadí**

V článku [Manage OLE](/slides/cs/cpp/manage-ole/) jsme vysvětlili, jak pomocí Aspose.Slides pro C++ přidat OLE rámec do prezentace PowerPoint. Abychom vyřešili [problém s náhledem objektu](/slides/cs/cpp/object-preview-issue-when-adding-oleobjectframe/), přiřadili jsme obrázek vybrané oblasti listu Excelu k OLE rámci. V outputové prezentaci, když dvakrát kliknete na OLE rámec zobrazující obrázek listu, aktivuje se sešit Excelu. Uživatelé mohou provádět libovolné změny v skutečném sešitu Excelu a poté se vrátit na snímek kliknutím mimo aktivovaný sešit Excelu. Velikost OLE rámce se při návratu uživatele na snímek změní. Faktor změny velikosti se liší podle velikosti OLE rámce a vloženého sešitu Excelu.

## **Příčina změny velikosti**

Protože má sešit Excelu vlastní velikost okna, při první aktivaci se snaží zachovat svou původní velikost. Naopak OLE rámec má svou vlastní velikost. Podle Microsoftu, když je sešit Excelu aktivován, Excel a PowerPoint vyjednávají velikost tak, aby zachovaly správné proporce jako součást procesu vložení. Změna velikosti nastává na základě rozdílů mezi velikostí okna Excelu a velikostí a polohou OLE rámce.

## **Řešení**

Existují dva možná řešení, jak se vyhnout efektu změny velikosti.

- Změřte velikost OLE rámce v prezentaci PowerPoint tak, aby odpovídala výšce a šířce požadovaného počtu řádků a sloupců v OLE rámci.
- Udržujte velikost OLE rámce konstantní a měřte velikost zapojených řádků a sloupců tak, aby se vešly do vybrané velikosti OLE rámce.

### **Změření velikosti OLE rámce**

V tomto přístupu se naučíme, jak nastavit velikost OLE rámce vloženého sešitu Excel tak, aby odpovídala součtové velikosti zapojených řádků a sloupců v listu Excelu.

Předpokládejme, že máme šablonu listu Excel a chceme ji přidat do prezentace jako OLE rámec. V tomto scénáři bude velikost OLE objektu nejprve vypočítána na základě součtu výšek řádků a šířek sloupců zapojených do sešitu. Poté nastavíme velikost OLE rámce na tuto vypočtenou hodnotu. Abychom se vyhnuli červené zprávě „EMBEDDED OLE OBJECT“ u OLE rámce v PowerPointu, také zachytíme obrázek požadovaných částí řádků a sloupců v sešitu a nastavíme jej jako obrázek OLE rámce.

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

// Nastavte zobrazovanou velikost, když je soubor sešitu použit jako OLE objekt v PowerPointu.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Získejte šířku a výšku OLE obrázku v bodech.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// Musíme použít upravený sešit.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Přidejte OLE obrázek do zdrojů prezentace.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Vytvořte OLE objektový rámeček.
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

### **Změření velikosti rozsahu buněk**

V tomto přístupu se naučíme, jak škálovat výšky zapojených řádků a šířku zapojených sloupců tak, aby odpovídaly vlastní velikosti OLE rámce.

Předpokládejme, že máme šablonu listu Excel a chceme ji přidat do prezentace jako OLE rámec. V tomto scénáři nastavíme velikost OLE rámce a škálujeme velikost řádků a sloupců, které se podílejí na oblasti OLE rámce. Poté uložíme sešit do proudu, abychom aplikovali změny, a převedeme jej na pole bajtů pro přidání do OLE rámce. Abychom se vyhnuli červené zprávě „EMBEDDED OLE OBJECT“ u OLE rámce v PowerPointu, také zachytíme obrázek požadovaných částí řádků a sloupců v sešitu a nastavíme jej jako obrázek OLE rámce.

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

// Nastavte zobrazovanou velikost, když je soubor sešitu použit jako OLE objekt v PowerPointu.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Škálujte rozsah buněk tak, aby odpovídal velikosti rámce.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Musíme použít upravený sešit.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Přidejte OLE obrázek do zdrojů prezentace.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Vytvořte OLE objektový rámec.
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

/// <param name="width">Očekávaná šířka rozsahu buněk v bodech.</param>
/// <param name="height">Očekávaná výška rozsahu buněk v bodech.</param>
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

## **Závěr**

{{% alert color="info" %}}

Existují dva přístupy k řešení problému se změnou velikosti listu. Výběr vhodného přístupu závisí na konkrétních požadavcích a scénáři použití. Oba přístupy fungují stejně, ať už jsou prezentace vytvořeny ze šablony nebo od začátku. Navíc v tomto řešení neexistuje žádný limit velikosti OLE objektu.

{{% /alert %}}

## **Časté dotazy**

### Proč se vložený list Excelu při první aktivaci v PowerPointu změní velikost?

Stane se to, protože Excel se při aktivaci snaží zachovat původní velikost okna, zatímco OLE rámec v PowerPointu má vlastní rozměry. PowerPoint a Excel vyjednávají velikost tak, aby zachovaly poměr stran, což může vést ke změně velikosti.

### Je možné zcela zabránit tomuto problému s změnou velikosti?

Ano. Škálováním OLE rámce tak, aby odpovídal velikosti rozsahu buněk Excelu, nebo škálováním rozsahu buněk tak, aby odpovídal požadované velikosti OLE rámce, můžete zabránit nechtěné změně velikosti.

### Kterou metodu škálování mám použít, škálování OLE rámce nebo škálování rozsahu buněk?

Zvolte **OLE frame scaling**, pokud chcete zachovat původní velikosti řádků a sloupců v Excelu. Zvolte **cell range scaling**, pokud chcete v prezentaci mít OLE rámec s pevnou velikostí.

### Budou tato řešení fungovat, pokud je moje prezentace založena na šabloně?

Ano. Obě řešení fungují pro prezentace vytvořené ze šablon i od začátku.

### Existuje limit velikosti OLE rámce při použití těchto metod?

Ne. OLE objekt můžete nastavit na libovolnou velikost, pokud nastavíte škálu odpovídajícím způsobem.

### Existuje způsob, jak se vyhnout textu zástupného symbolu „EMBEDDED OLE OBJECT“ v PowerPointu?

Ano. Pořízením snímku cílového rozsahu buněk Excel a nastavením tohoto snímku jako obrázku zástupného symbolu OLE rámce můžete zobrazit vlastní náhled místo výchozího zástupného textu.

## **Související články**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/cs/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)