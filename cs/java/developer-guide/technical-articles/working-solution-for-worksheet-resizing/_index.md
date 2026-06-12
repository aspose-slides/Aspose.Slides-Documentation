---
title: Řešení pro změnu velikosti listu
type: docs
weight: 20
url: /cs/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- náhledový obrázek
- změna velikosti obrázku
- Excel
- list
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Opravte změnu velikosti OLE listu Excel v prezentacích: dva způsoby, jak udržet rámce objektů konzistentní—škálovat rámec nebo list—pro formáty PPT a PPTX."
---
{{% alert color="primary" %}}

Bylo zaznamenáno, že listy Excelu vložené jako OLE objekty v prezentaci PowerPoint pomocí komponent Aspose jsou po první aktivaci změněny na neidentifikovatelnou měřítko. Toto chování vytváří výrazný vizuální rozdíl v prezentaci mezi stavem OLE objektu před a po aktivaci. Problém jsme podrobně prozkoumali a poskytli řešení, které je popsáno v tomto článku.

{{% /alert %}}

## **Pozadí**

V článku [Manage OLE](/slides/cs/java/manage-ole/) jsme vysvětlili, jak přidat OLE rámec do prezentace PowerPoint pomocí Aspose.Slides for Java. Abychom vyřešili [object preview issue](/slides/cs/java/object-preview-issue-when-adding-oleobjectframe/), přiřadili jsme obrázek vybrané oblasti listu k OLE objektovému rámci. V výsledné prezentaci, když dvakrát kliknete na OLE objektový rámec zobrazující obrázek listu, aktivuje se Excel sešit. Uživatelé mohou provést libovolné úpravy skutečného Excel sešitu a poté se vrátit na snímek kliknutím mimo aktivovaný Excel sešit. Velikost OLE objektového rámce se změní, když se uživatel vrátí na snímek. Faktor změny velikosti se bude lišit v závislosti na velikosti OLE objektového rámce a vloženého Excel sešitu.

## **Příčina změny velikosti**

Protože Excel sešit má vlastní velikost okna, při první aktivaci se snaží zachovat svou původní velikost. Na druhou stranu OLE objektový rámec má vlastní rozměry. Podle Microsoftu, když je Excel sešit aktivován, Excel a PowerPoint vyjednávají velikost tak, aby zachovaly správné proporce jako součást procesu vložení. Změna velikosti nastává na základě rozdílů mezi velikostí okna Excelu a velikostí a pozicí OLE objektového rámce.

## **Řešení**

Existují dva možná řešení, jak zabránit efektu změny velikosti.

- Změňte velikost OLE rámce v prezentaci PowerPoint tak, aby odpovídala výšce a šířce požadovaného počtu řádků a sloupců v OLE rámci.
- Udržujte velikost OLE rámce konstantní a upravte velikost zapojených řádků a sloupců tak, aby se vešly do zvoleného OLE rámce.

### **Změna velikosti OLE rámce**

V tomto přístupu se naučíme, jak nastavit velikost OLE rámce vloženého Excel sešitu tak, aby odpovídala součtové velikosti zapojených řádků a sloupců v listu Excelu.

Předpokládejme, že máme šablonu Excel listu a chceme ji přidat do prezentace jako OLE rámec. V tomto scénáři bude velikost OLE objektového rámce nejprve vypočítána na základě součtu výšek řádků a šířek sloupců zapojených řádků a sloupců v sešitu. Poté nastavíme velikost OLE rámce na tuto vypočítanou hodnotu. Abychom se vyhnuli červené zprávě "EMBEDDED OLE OBJECT" u OLE rámce v PowerPointu, také zachytíme obrázek požadovaných částí řádků a sloupců v sešitu a nastavíme jej jako obrázek OLE rámce.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Nastavte zobrazovanou velikost, když je soubor sešitu použit jako OLE objekt v PowerPointu.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Získejte šířku a výšku OLE obrázku v bodech.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Musíme použít upravený sešit.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Přidejte OLE obrázek do zdrojů prezentace.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Vytvořte rámec OLE objektu.
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

### **Změna velikosti rozsahu buněk**

V tomto přístupu se naučíme, jak upravit výšky zapojených řádků a šířku zapojených sloupců tak, aby odpovídaly vlastní velikosti OLE rámce.

Předpokládejme, že máme šablonu Excel listu a chceme ji přidat do prezentace jako OLE rámec. V tomto scénáři nastavíme velikost OLE rámce a upravíme velikost řádků a sloupců, které se podílejí na oblasti OLE rámce. Poté uložíme sešit do proudu, aby se změny použily, a převedeme jej na pole bytů pro přidání do OLE rámce. Abychom se vyhnuli červené zprávě "EMBEDDED OLE OBJECT" u OLE rámce v PowerPointu, také zachytíme obrázek požadovaných částí řádků a sloupců v sešitu a nastavíme jej jako obrázek OLE rámce.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Nastavte zobrazovanou velikost, když je soubor sešitu použit jako OLE objekt v PowerPointu.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Upravte velikost rozsahu buněk, aby odpovídala velikosti rámce.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Musíme použít upravený sešit.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Přidejte OLE obrázek do zdrojů prezentace.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Vytvořte rámec OLE objektu.
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
 * @param width     Očekávaná šířka rozsahu buněk v bodech.
 * @param height    Očekávaná výška rozsahu buněk v bodech.
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

Existují dva přístupy k vyřešení problému se změnou velikosti listu. Výběr vhodného přístupu závisí na konkrétních požadavcích a použití. Oba přístupy fungují stejným způsobem, ať už jsou prezentace vytvořeny ze šablony nebo od nuly. Navíc v tomto řešení neexistuje žádné omezení velikosti OLE objektového rámce.

{{% /alert %}}

## **Často kladené otázky**

**Proč se vložený Excel list při první aktivaci v PowerPointu změní velikost?**

K tomu dochází, protože Excel se při aktivaci snaží zachovat původní velikost okna, zatímco OLE objektový rámec v PowerPointu má své vlastní rozměry. PowerPoint a Excel vyjednávají velikost tak, aby zachovaly poměr stran, což může způsobit změnu velikosti.

**Je možné tento problém se změnou velikosti zcela zabránit?**

Ano. Úpravou velikosti OLE rámce tak, aby odpovídal velikosti rozsahu buněk v Excelu, nebo úpravou rozsahu buněk tak, aby odpovídal požadované velikosti OLE rámce, můžete zabránit nechtěné změně velikosti.

**Kterou metodu škálování bych měl použít, škálování OLE rámce nebo škálování rozsahu buněk?**

Zvolte **OLE frame scaling**, pokud chcete zachovat původní velikosti řádků a sloupců v Excelu. Zvolte **cell range scaling**, pokud chcete v prezentaci pevnou velikost OLE rámce.

**Bude toto řešení fungovat, pokud je moje prezentace založena na šabloně?**

Ano. Obě řešení fungují pro prezentace vytvořené ze šablon i od nuly.

**Existuje omezení velikosti OLE rámce při použití těchto metod?**

Ne. OLE objektový rámec můžete nastavit na jakoukoli velikost, pokud nastavíte škálování vhodně.

**Existuje způsob, jak se vyhnout textu zástupného obrázku "EMBEDDED OLE OBJECT" v PowerPointu?**

Ano. Pořízením snímku cílového rozsahu buněk v Excelu a nastavením tohoto snímku jako zástupného obrázku OLE rámce můžete zobrazit vlastní náhled místo výchozího zástupného obrázku.

## **Související články**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/cs/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/cs/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)