---
title: Pracovní řešení pro změnu velikosti listu
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
{{% alert color="primary" %}}

Bylo zaznamenáno, že listy Excelu vložené jako OLE objekty v prezentaci PowerPoint prostřednictvím komponent Aspose jsou po první aktivaci přepočítány na neidentifikovanou míru. Toto chování vytváří patrný vizuální rozdíl v prezentaci mezi stavem OLE objektu před a po aktivaci. Problém jsme podrobně prozkoumali a poskytli řešení, které je popsáno v tomto článku.

{{% /alert %}}

## **Pozadí**

V článku [Spravovat OLE](/slides/cs/cpp/manage-ole/) jsme vysvětlili, jak pomocí Aspose.Slides for C++ přidat OLE rámec do prezentace PowerPoint. Pro řešení [object preview issue](/slides/cs/cpp/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek vybrané oblasti listu OLE objektu. V výstupní prezentaci, když dvakrát kliknete na OLE rámec zobrazující obrázek listu, aktivuje se sešit Excelu. Uživatelé mohou provést libovolné změny v reálném sešitu Excelu a poté se vrátit na snímek kliknutím mimo aktivovaný sešit Excelu. Velikost OLE rámce se po návratu uživatele na snímek změní. Faktor změny velikosti se bude lišit v závislosti na velikosti OLE rámce a vloženého sešitu Excelu.

## **Příčina změny velikosti**

Vzhledem k tomu, že sešit Excel má svou vlastní velikost okna, snaží se po první aktivaci zachovat původní velikost. OLE rámec má naopak vlastní rozměry. Podle Microsoftu, když je sešit Excel aktivován, Excel a PowerPoint vyjednávají velikost tak, aby zachovaly správné proporce v rámci procesu vkládání. Změna velikosti nastává na základě rozdílů mezi velikostí okna Excel a velikostí a polohou OLE rámce.

## **Funkční řešení**

Existují dva možné způsoby, jak se vyhnout efektu změny velikosti.

- Změnit měřítko velikosti OLE rámce v prezentaci PowerPoint tak, aby odpovídala výšce a šířce požadovaného počtu řádků a sloupců v OLE rámci.
- Udržet velikost OLE rámce konstantní a změnit měřítko velikosti zapojených řádků a sloupců tak, aby se vešly do zvoleného rozměru OLE rámce.

### **Změna měřítka velikosti OLE rámce**

V tomto přístupu se naučíme, jak nastavit velikost OLE rámce vloženého sešitu Excel tak, aby odpovídala kumulativní velikosti zapojených řádků a sloupců v listu Excel.

Předpokládejme, že máme šablonu listu Excel a chceme ji přidat do prezentace jako OLE rámec. V tomto scénáři bude nejprve velikost OLE objektu vypočítána na základě kumulativní výšky řádků a šířky sloupců zapojených v sešitu. Poté nastavíme velikost OLE rámce na tuto vypočtenou hodnotu. Abychom zabránili červené zprávě „EMBEDDED OLE OBJECT“ u OLE rámce v PowerPointu, také zachytíme obrázek požadovaných částí řádků a sloupců v sešitu a nastavíme jej jako obrázek OLE rámce.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Nastavit zobrazovanou velikost, když je soubor sešitu použit jako OLE objekt v PowerPointu.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Získat šířku a výšku OLE obrázku v bodech.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// Musíme použít upravený sešit.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Přidat OLE obrázek do prostředků prezentace.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Vytvořit rámec OLE objektu.
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

### **Změna měřítka velikosti oblasti buněk**

V tomto přístupu se naučíme, jak změnit měřítko výšek zapojených řádků a šířek zapojených sloupců tak, aby odpovídaly vlastním rozměrům OLE rámce.

Předpokládejme, že máme šablonu listu Excel a chceme ji přidat do prezentace jako OLE rámec. V tomto scénáři nastavíme velikost OLE rámce a změníme měřítko velikosti řádků a sloupců, které se podílejí na oblasti OLE rámce. Poté uložíme sešit do proudu, aby se změny použily, a převedeme jej na pole bajtů pro přidání do OLE rámce. Abychom zabránili červené zprávě „EMBEDDED OLE OBJECT“ u OLE rámce v PowerPointu, také zachytíme obrázek požadovaných částí řádků a sloupců v sešitu a nastavíme jej jako obrázek OLE rámce.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Nastavit zobrazovanou velikost, když je soubor sešitu použit jako OLE objekt v PowerPointu.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Změnit měřítko oblasti buněk tak, aby odpovídala velikosti rámce.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Musíme použít upravený sešit.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Přidat OLE obrázek do prostředků prezentace.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Vytvořit rámec OLE objektu.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
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

## **Závěr**

{{% alert color="primary" %}}

Existují dva přístupy k vyřešení problému se změnou velikosti listu. Výběr vhodného přístupu závisí na konkrétních požadavcích a použití. Oba přístupy fungují stejným způsobem, ať už jsou prezentace vytvořeny ze šablony nebo od nuly. Navíc neexistuje žádné omezení velikosti OLE objektu v tomto řešení.

{{% /alert %}}

## **Často kladené otázky**

**Proč se vložený list Excelu po první aktivaci v PowerPointu změní velikost?**

K tomu dochází, protože Excel se při aktivaci snaží zachovat původní velikost okna, zatímco OLE rámec v PowerPointu má vlastní rozměry. PowerPoint a Excel vyjednávají velikost, aby zachovaly poměr stran, což může způsobit změnu velikosti.

**Je možné tomuto problému se změnou velikosti zcela zabránit?**

Ano. Změnou měřítka OLE rámce tak, aby odpovídal velikosti oblasti buněk v Excelu, nebo změnou měřítka oblasti buněk tak, aby odpovídala požadovanému rozměru OLE rámce, lze zabránit nechtěné změně velikosti.

**Kterou metodu změny měřítka mám použít, změnu měřítka OLE rámce nebo změnu měřítka oblasti buněk?**

Zvolte **OLE frame scaling**, pokud chcete zachovat původní velikosti řádků a sloupců v Excelu. Zvolte **cell range scaling**, pokud chcete pevnou velikost OLE rámce ve své prezentaci.

**Budou tato řešení fungovat, i když je moje prezentace založena na šabloně?**

Ano. Obě řešení fungují jak pro prezentace vytvořené ze šablon, tak i od nuly.

**Existuje omezení velikosti OLE rámce při použití těchto metod?**

Ne. OLE objekt můžete nastavit na libovolnou velikost, pokud správně nastavíte měřítko.

**Existuje způsob, jak se vyhnout zástupnému textu „EMBEDDED OLE OBJECT“ v PowerPointu?**

Ano. Zachycením snímku cílové oblasti buněk v Excelu a nastavením tohoto snímku jako zástupného obrázku OLE rámce můžete zobrazit vlastní náhled místo výchozího zástupného textu.

## **Související články**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/cs/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)