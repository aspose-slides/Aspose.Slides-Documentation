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
- Aspose.Slides pro C++
description: "Řešení pro změnu velikosti listu v prezentacích PowerPoint pomocí C++"
---
{{% alert color="info" title="Note" %}}

Excel listy vložené jako OLE objekty v prezentaci PowerPoint pomocí komponent Aspose se mohou po první aktivaci neočekávaně změnit velikost. Toto chování vytváří patrný vizuální rozdíl mezi OLE objektem před a po aktivaci. Tento článek vysvětluje problém a popisuje dva způsoby, jak jej vyřešit.

{{% /alert %}}

## **Pozadí**

V článku [Spravovat OLE](/slides/cs/cpp/manage-ole/) jsme vysvětlili, jak přidat OLE rámec do prezentace PowerPoint pomocí Aspose.Slides pro C++. Pro řešení [problém s náhledem objektu](/slides/cs/cpp/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek vybrané oblasti listu k OLE rámci. V výstupní prezentaci, když dvakrát kliknete na OLE rámec zobrazující obrázek listu, aktivuje se sešit Excel. Koneční uživatelé mohou provádět libovolné změny ve skutečném sešitu Excel a poté se vrátit na snímek kliknutím mimo aktivovaný sešit Excel. Velikost OLE rámce se změní, když se uživatel vrátí na snímek. Faktor změny velikosti se bude lišit v závislosti na velikosti OLE rámce a vloženého sešitu Excel.

## **Příčina změny velikosti**

Protože má sešit Excel vlastní velikost okna, při první aktivaci se snaží zachovat původní velikost. Na druhou stranu má OLE rámec vlastní rozměry. Podle Microsoftu, když je sešit Excel aktivován, Excel a PowerPoint si dohodnou velikost, aby zachovaly správné proporce jako součást procesu vkládání. Změna velikosti nastává na základě rozdílů mezi velikostí okna Excel a velikostí a polohou OLE rámce.

## **Řešení**

Existují dva možné způsoby, jak předejít efektu změny velikosti.

- Změňte měřítko OLE rámce v prezentaci PowerPoint tak, aby odpovídal celkové výšce a šířce vybraných řádků a sloupců.
- Uchovejte velikost OLE rámce konstantní a přepočítejte měřítko vybraných řádků a sloupců tak, aby se vešly.

### **Změna měřítka velikosti OLE rámce**

Tento přístup nastaví velikost OLE rámce tak, aby odpovídala celkové výšce a šířce vybraných řádků a sloupců ve vloženém listu Excel.  
Příklad načte existující sešit Excel a vybere prvních 10 řádků a 13 sloupců jeho prvního listu pomocí nulových indexů. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) definuje zobrazovaný rozsah. Náhled je vykreslen při 96 DPI a jeho rozměry v pixelech jsou převedeny na body pomocí 72 bodů na palec. [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) vloží upravený sešit do rámce s těmito rozměry. Náhled je přiřazen pomocí [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) k nahrazení zástupného textu „EMBEDDED OLE OBJECT“ v uložené prezentaci.

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

// Potřebujeme použít upravený sešit.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Přidejte OLE obrázek do zdrojů prezentace.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Vytvořte OLE objektový rámec.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

Náhledová pomocná metoda používá [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) k výběru rozsahu a odstraňuje okraje, záhlaví a zápatí. S povoleným [ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/) [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) vykreslí rozsah jako PNG obrázek. Pomocná metoda zkopíruje vykreslená data obrázku do nového paměťového proudu umístěného na jeho začátek pro použití v prezentaci.

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

### **Změna měřítka velikosti oblasti buněk**

Tento přístup přepočítá výšky vybraných řádků a šířky vybraných sloupců tak, aby odpovídaly vlastní velikosti OLE rámce.  
Příklad načte existující sešit Excel a vybere prvních 10 řádků a 13 sloupců jeho prvního listu pomocí nulových indexů. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) definuje zobrazovaný rozsah a níže uvedená pomocná metoda tento rozsah přepočítá tak, aby se vešel do rámce širokého 400 bodů a vysokého 100 bodů. Po uložení upraveného sešitu do pole bajtů [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) vloží jej do rámce se specifikovanou velikostí. Náhled vykreslený při 96 DPI je přiřazen pomocí [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/), takže uložená prezentace zobrazuje vybrané buňky místo výchozího zástupného textu.

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

// Přepočítejte měřítko oblasti buněk tak, aby odpovídala velikosti rámce.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Potřebujeme použít upravený sešit.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Přidejte OLE obrázek do zdrojů prezentace.
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

Pomocná metoda pro měřítko vypočítá samostatné poměry šířky a výšky pro vybraný rozsah, zachovává relativní šířky jeho sloupců a relativní výšky jeho řádků. Převádí vypočítané rozměry z bodů na palce před jejich aplikací pomocí [Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/) a [Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/). Vybraný rozsah musí mít nenulovou šířku a výšku.

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">Očekávaná šířka oblasti buněk v bodech.</param>
/// <param name="height">Očekávaná výška oblasti buněk v bodech.</param>
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

Tato náhledová pomocná metoda vykreslí změněný rozsah pomocí [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/). Používá [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) k omezení tisku na tento rozsah, odstraňuje okraje, záhlaví a zápatí a vrací PNG proud umístěný na jeho začátek.

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

{{% alert color="info" title="Note" %}}

Existují dva přístupy k vyřešení problému změny velikosti listu. Vyberte přístup, který nejlépe vyhovuje vašim požadavkům a scénáři použití. Oba přístupy fungují stejným způsobem, ať už jsou prezentace vytvořeny ze šablony nebo od začátku. Navíc v tomto řešení neexistuje žádný limit na velikost OLE rámce.

{{% /alert %}}

## **Často kladené otázky**

**Proč se vložený list Excel změní po první aktivaci v PowerPointu?**

Stane se tak, protože Excel se při aktivaci snaží zachovat původní velikost okna, zatímco OLE rámec v PowerPointu má vlastní rozměry. PowerPoint a Excel se dohodnou na velikosti tak, aby udržely poměr stran, což může vést ke změně velikosti.

**Je možné zcela zabránit tomuto problému se změnou velikosti?**

Ano. Přepočítáním měřítka OLE rámce tak, aby odpovídal velikosti rozsahu buněk Excel, nebo přepočítáním rozsahu buněk tak, aby odpovídal požadované velikosti OLE rámce, můžete zabránit nechtěné změně velikosti.

**Kterou metodu měřítka mám použít, měřítko OLE rámce nebo měřítko rozsahu buněk?**

Zvolte **měřítko OLE rámce**, pokud chcete zachovat původní velikosti řádků a sloupců v Excelu. Zvolte **měřítko rozsahu buněk**, pokud chcete v prezentaci pevnou velikost OLE rámce.

**Bude toto řešení fungovat, pokud je moje prezentace založena na šabloně?**

Ano. Obě řešení fungují pro prezentace vytvořené ze šablon i od začátku.

**Existuje limit velikosti OLE rámce při použití těchto metod?**

Ne. OLE rámec můžete nastavit na libovolnou velikost, pokud správně nastavíte měřítko.

**Je možné se vyhnout zástupnému textu „EMBEDDED OLE OBJECT“ v PowerPointu?**

Ano. Pořízením snímku cílového rozsahu buněk v Excel a nastavením tohoto obrázku jako zástupného obrázku OLE rámce můžete v prezentaci zobrazit vlastní náhled místo výchozího zástupného textu.

## **Související články**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/cs/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)