---
title: Funkční řešení pro změnu velikosti listu
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
description: "Opravte změnu velikosti listu Excel OLE v prezentacích: dva způsoby, jak udržet rámce objektů konzistentní—zvětšením rámce nebo listu—napříč formáty PPT a PPTX."
---
{{% alert color="info" title="Note" %}}

Excel listy vložené jako OLE objekty do prezentace PowerPoint pomocí komponent Aspose se mohou po první aktivaci neočekávaně změnit velikost. Toto chování vytváří patrný vizuální rozdíl mezi OLE objektem před a po aktivaci. Tento článek popisuje problém a uvádí dva způsoby, jak jej řešit.

{{% /alert %}}

## **Pozadí**

V článku [Spravovat OLE](/slides/cs/java/manage-ole/) jsme vysvětlili, jak přidat OLE rámec do prezentace PowerPoint pomocí Aspose.Slides for Java. Pro řešení [problému s náhledem objektu](/slides/cs/java/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek vybrané oblasti listu k OLE objektovému rámci. V výstupní prezentaci, když dvakrát kliknete na OLE rámec zobrazující obrázek listu, aktivuje se sešit Excelu. Koneční uživatelé mohou provádět libovolné změny ve skutečném sešitu Excelu a poté se vrátit na snímek kliknutím mimo aktivovaný sešit. Velikost OLE rámce se změní, když se uživatel vrátí na snímek. Faktor změny velikosti se liší v závislosti na velikosti OLE rámce a vloženého sešitu Excelu.

## **Příčina změny velikosti**

Protože má sešit Excelu vlastní velikost okna, snaží se po první aktivaci zachovat původní velikost. OLE rámec má naopak vlastní rozměry. Podle Microsoftu, když je sešit Excelu aktivován, Excel a PowerPoint si dohodnou velikost, aby zachovaly správné proporce v rámci procesu vložení. Změna velikosti nastává na základě rozdílů mezi velikostí okna Excelu a rozměry a polohou OLE rámce.

## **Řešení**

Existují dva možné způsoby, jak zabránit efektu změny velikosti.

- Změňte velikost OLE rámce v prezentaci PowerPoint tak, aby odpovídala celkové výšce a šířce vybraných řádků a sloupců.
- Udržujte velikost OLE rámce konstantní a přizpůsobte vybrané řádky a sloupce tak, aby se do něj vešly.

### **Změna velikosti OLE rámečku**

Tento přístup nastaví velikost OLE rámce tak, aby odpovídala celkové výšce a šířce vybraných řádků a sloupců ve vloženém listu Excelu.

Příklad načte existující sešit Excel a vybere prvních 10 řádků a 13 sloupců jeho prvního listu pomocí nulových indexů. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definuje zobrazovaný rozsah. Náhled je vykreslen při 96 DPI a jeho pixelové rozměry jsou převedeny na body pomocí 72 bodů na palec. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) vloží upravený sešit do rámce s těmito rozměry. Náhled je přiřazen přes [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) k nahrazení zástupného textu "EMBEDDED OLE OBJECT" v uložené prezentaci.

```java
import com.aspose.slides.*;
import java.awt.Image;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import javax.imageio.ImageIO;

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

// Get the width and height of the OLE image in points.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// We need to use the modified workbook.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add the OLE image to the presentation resources.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Create the OLE object frame.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

Náhledový pomocník nastaví [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) na vybraný rozsah a odstraní okraje, záhlaví a zápatí. S povoleným [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) vykreslí rozsah jako PNG obrázek. Pomocník vrátí nový vstupní proud obsahující PNG obrázek, umístěný na jeho začátku pro použití v prezentaci.

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

Tento přístup změní výšky vybraných řádků a šířky vybraných sloupců tak, aby odpovídaly vlastním rozměrům OLE rámce.

Příklad načte existující sešit Excel a vybere prvních 10 řádků a 13 sloupců jeho prvního listu pomocí nulových indexů. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definuje zobrazovaný rozsah a níže uvedený pomocník tento rozsah přizpůsobí tak, aby se vešel do rámce širokého 400 bodů a vysokého 100 bodů. Po uložení upraveného sešitu do proudu [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) jej vloží s určenou velikostí. Náhled vykreslený při 96 DPI je přiřazen přes [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--), takže uložená prezentace zobrazuje vybrané buňky místo výchozího zástupného textu.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

// Změňte měřítko rozsahu buněk tak, aby se vešel do velikosti rámce.
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

// Vytvořte rámec OLE objektu.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

Škálovací pomocník vypočítá samostatné poměry šířky a výšky pro vybraný rozsah, zachovává relativní šířky sloupců a relativní výšky řádků. Převádí vypočtené rozměry z bodů na palce a poté je aplikuje pomocí [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) a [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). Vybraný rozsah musí mít nenulovou šířku i výšku.

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

Tento náhledový pomocník vykreslí změněný rozsah pomocí [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). Omezí [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) na tento rozsah, odstraní okraje, záhlaví a zápatí a vrátí PNG proud umístěný na jeho začátku.

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

{{% alert color="info" title="Note" %}}

Existují dva přístupy k opravě problému se změnou velikosti listu. Vyberte ten, který nejlépe vyhovuje vašim požadavkům a případnému použití. Oba přístupy fungují stejným způsobem, ať už jsou prezentace vytvořeny ze šablony nebo od začátku. Navíc neexistuje žádný limit velikosti OLE rámce v tomto řešení.

{{% /alert %}}

## **Často kladené otázky**

**Proč se vložený list Excelu po první aktivaci v PowerPointu změní velikost?**

Stane se tak, protože Excel se snaží zachovat původní velikost okna při aktivaci, zatímco OLE rámec v PowerPointu má vlastní rozměry. PowerPoint a Excel pak vyjednají velikost tak, aby zachovaly poměr stran, což může způsobit změnu velikosti.

**Je možné tomuto problému se změnou velikosti zcela předejít?**

Ano. Změnou velikosti OLE rámce tak, aby odpovídala velikosti rozsahu buněk Excelu, nebo změnou velikosti rozsahu buněk tak, aby odpovídala požadované velikosti OLE rámce, můžete nechtěnou změnu velikosti zabránit.

**Kterou metodu škálování mám použít, škálování OLE rámce nebo škálování rozsahu buněk?**

Zvolte **škálování OLE rámce**, pokud chcete zachovat původní velikosti řádků a sloupců v Excelu. Zvolte **škálování rozsahu buněk**, pokud chcete mít v prezentaci pevnou velikost OLE rámce.

**Budou tyto řešení fungovat, pokud je má prezentace založena na šabloně?**

Ano. Oba řešení fungují jak pro prezentace vytvořené ze šablon, tak pro prezentace vytvořené od nuly.

**Existuje limit velikosti OLE rámce při použití těchto metod?**

Ne. OLE objektový rámec můžete nastavit na libovolnou velikost, pokud správně nastavíte měřítko.

**Je způsob, jak se vyhnout textu zástupného obrázku „EMBEDDED OLE OBJECT“ v PowerPointu?**

Ano. Pořízením snímku cílového rozsahu buněk v Excelu a nastavením tohoto snímku jako zástupného obrázku OLE rámce můžete zobrazit vlastní náhled místo výchozího zástupného textu.

## **Související články**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/cs/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/cs/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)