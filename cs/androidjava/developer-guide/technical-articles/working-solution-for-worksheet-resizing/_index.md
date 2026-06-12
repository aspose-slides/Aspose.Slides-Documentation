---
title: Pracovní řešení pro změnu velikosti listu
type: docs
weight: 20
url: /cs/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- náhledový obrázek
- změna velikosti obrázku
- Excel
- list
- prezentace
- Android
- Java
- Aspose.Slides
description: "Opravte změnu velikosti OLE objektu listu Excel v prezentacích: dva způsoby, jak zachovat konzistentní rámečky objektů — změňte měřítko rámce nebo listu — napříč formáty PPT a PPTX."
---
{{% alert color="primary" %}}

Bylo zaznamenáno, že listy Excelu vložené jako OLE objekty v prezentaci PowerPoint pomocí komponent Aspose jsou po první aktivaci změněny na neidentifikovatelnou velikost. Toto chování vytváří výrazný vizuální rozdíl v prezentaci mezi před‑ a po‑aktivačním stavem OLE objektu. Problém jsme podrobně prozkoumali a připravili řešení, které je v tomto článku popsáno.

{{% /alert %}}

## **Pozadí**

V článku [Spravovat OLE](/slides/cs/androidjava/manage-ole/) jsme vysvětlili, jak přidat OLE rámec do prezentace PowerPoint pomocí Aspose.Slides for Android via Java. Pro řešení [problému s náhledem objektu](/slides/cs/androidjava/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek vybrané oblasti listu do OLE rámce. V výstupní prezentaci, když dvakrát kliknete na OLE rámec zobrazující obrázek listu, aktivuje se sešit Excelu. Uživatelé mohou provádět libovolné úpravy skutečného sešitu a poté se vrátit na snímek kliknutím mimo aktivovaný sešit. Velikost OLE rámce se po návratu uživatele na snímek změní. Faktor změny velikosti se liší podle velikosti OLE rámce a vloženého sešitu Excelu.

## **Příčina změny velikosti**

Protože má sešit Excelu vlastní velikost okna, při první aktivaci se snaží zachovat svou původní velikost. Naopak OLE rámec má vlastní rozměry. Podle Microsoftu, když je sešit Excelu aktivován, Excel a PowerPoint vyjednávají velikost tak, aby zachovaly správné proporce v rámci procesu vkládání. Změna velikosti nastává na základě rozdílů mezi velikostí okna Excelu a rozměry a polohou OLE rámce.

## **Fungující řešení**

Existují dva možná řešení, jak předejít efektu změny velikosti.

- Změnit měřítko velikosti OLE rámce v prezentaci PowerPoint tak, aby odpovídalo výšce a šířce požadovaného počtu řádků a sloupců v OLE rámci.
- Zachovat velikost OLE rámce konstantní a změnit měřítko velikosti zapojených řádků a sloupců tak, aby se vešly do vybrané velikosti OLE rámce.

### **Změna měřítka velikosti OLE rámce**

V tomto přístupu se naučíte, jak nastavit velikost OLE rámce vloženého sešitu Excel tak, aby odpovídala kumulativní velikosti zapojených řádků a sloupců v listu Excelu.

Předpokládejme, že máme šablonový list Excel a chceme jej přidat do prezentace jako OLE rámec. V tomto scénáři se nejprve vypočítá velikost OLE objektu na základě součtu výšek řádků a šířek sloupců zapojených do sešitu. Poté nastavíme velikost OLE rámce na tuto vypočtenou hodnotu. Abychom se vyhnuli červené zprávě „EMBEDDED OLE OBJECT“ u OLE rámce v PowerPointu, také zachytíme obrázek požadovaných částí řádků a sloupců v sešitu a nastavíme jej jako obrázek OLE rámce.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Nastavte zobrazenou velikost, když je soubor sešitu použit jako OLE objekt v PowerPointu.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Získejte šířku a výšku OLE obrázku v bodech.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Potřebujeme použít upravený sešit.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Přidejte OLE obrázek do zdrojů prezentace.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Vytvořte OLE rámec objektu.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

### **Změna měřítka velikosti oblasti buněk**

V tomto přístupu se naučíte, jak změnit měřítko výšek zapojených řádků a šířek zapojených sloupců tak, aby odpovídaly vlastnímu rozměru OLE rámce.

Předpokládejme, že máme šablonový list Excel a chceme jej přidat do prezentace jako OLE rámec. V tomto scénáři nastavíme velikost OLE rámce a upravíme měřítko velikosti řádků a sloupců, které tvoří oblast OLE rámce. Poté uložíme sešit do proudu, abychom změny aplikovali, a převedeme jej na pole bajtů pro vložení do OLE rámce. Abychom se vyhnuli červené zprávě „EMBEDDED OLE OBJECT“ u OLE rámce v PowerPointu, také zachytíme obrázek požadovaných částí řádků a sloupců v sešitu a nastavíme jej jako obrázek OLE rámce.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Nastavte zobrazenou velikost, když je soubor sešitu použit jako OLE objekt v PowerPointu.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Změňte měřítko oblasti buněk tak, aby odpovídala velikosti rámce.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Potřebujeme použít upravený sešit.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Přidejte OLE obrázek do zdrojů prezentace.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Vytvořte OLE rámec objektu.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
/**
 * @param width     Očekávaná šířka oblasti buněk v bodech.
 * @param height    Očekávaná výška oblasti buněk v bodech.
 */
static void ScaleCellRange(com.aspose.cells.Range cellRange, float width, float height) {
    double rangeWidth = cellRange.getWidth();
    double rangeHeight = cellRange.getHeight();

    for (int i = 0; i < cellRange.getColumnCount(); i++) {
        int columnIndex = cellRange.getFirstColumn() + i;
        double columnWidth = cellRange.getWorksheet()
                .getCells()
                .getColumnWidth(columnIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newColumnWidth = columnWidth * width / rangeWidth;
        double widthInInches = newColumnWidth / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.getRowCount(); i++) {
        int rowIndex = cellRange.getFirstRow() + i;
        double rowHeight = cellRange.getWorksheet()
                .getCells()
                .getRowHeight(rowIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newRowHeight = rowHeight * height / rangeHeight;
        double heightInInches = newRowHeight / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setRowHeightInch(rowIndex, heightInInches);
    }
}
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

## **Závěr**

{{% alert color="primary" %}} 

Existují dva přístupy, jak vyřešit problém se změnou velikosti listu. Výběr vhodného přístupu závisí na konkrétních požadavcích a scénáři použití. Oba přístupy fungují stejně, ať už jsou prezentace vytvořeny ze šablony nebo od nuly. Navíc v tomto řešení neexistuje žádné omezení velikosti OLE objektu.

{{% /alert %}}

## **Často kladené otázky**

**Proč se velikost vloženého listu Excel změní při první aktivaci v PowerPointu?**

Stane se to, protože Excel se snaží zachovat původní velikost okna při aktivaci, zatímco OLE rámec v PowerPointu má své vlastní rozměry. PowerPoint a Excel vyjednávají velikost tak, aby zachovaly poměr stran, což může vést ke změně velikosti.

**Je možné tomuto problému se změnou velikosti úplně předejít?**

Ano. Změnou měřítka OLE rámce tak, aby odpovídal velikosti oblasti buněk Excelu, nebo změnou měřítka oblasti buněk tak, aby odpovídala požadované velikosti OLE rámce, lze zabránit nechtěné změně velikosti.

**Kterou metodu změny měřítka mám použít, změnu měřítka OLE rámce nebo změnu měřítka oblasti buněk?**

Vyberte **změnu měřítka OLE rámce**, pokud chcete zachovat původní velikosti řádků a sloupců v Excelu. Vyberte **změnu měřítka oblasti buněk**, pokud chcete mít v prezentaci pevnou velikost OLE rámce.

**Budou tato řešení fungovat, pokud je moje prezentace založena na šabloně?**

Ano. Obě řešení fungují pro prezentace vytvořené ze šablon i od nuly.

**Existuje limit velikosti OLE rámce při použití těchto metod?**

Ne. OLE objekt můžete nastavit na libovolnou velikost, pokud nastavíte správné měřítko.

**Je možné se vyhnout textu „EMBEDDED OLE OBJECT“ jako zástupnému symbolu v PowerPointu?**

Ano. Pořízením snímku cílové oblasti buněk v Excelu a nastavením tohoto snímku jako zástupného obrázku OLE rámce můžete zobrazit vlastní náhled místo výchozího zástupného textu.