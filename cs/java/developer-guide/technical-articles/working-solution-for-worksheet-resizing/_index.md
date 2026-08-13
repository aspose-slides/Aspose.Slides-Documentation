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
description: "Opravte změnu velikosti OLE listu Excel v prezentacích: dva způsoby, jak udržet rámce objektů konzistentní - škálováním rámce nebo listu - napříč formáty PPT a PPTX."
---
{{% alert color="info" %}}
Bylo zjištěno, že listy Excelu vložené jako OLE objekty do prezentace PowerPoint pomocí komponent Aspose jsou po první aktivaci změněny na neidentifikovatelnou měřítko. Toto chování vytváří patrný vizuální rozdíl v prezentaci mezi před‑ a po‑aktivací OLE objektu. Problém jsme podrobně prozkoumali a poskytli řešení, které je popsáno v tomto článku.
{{% /alert %}}

## **Pozadí**

V článku [Správa OLE](/slides/cs/java/manage-ole/) jsme vysvětlili, jak pomocí Aspose.Slides for Java přidat do prezentace PowerPoint OLE rámec. K řešení [problému s náhledem objektu](/slides/cs/java/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek vybrané oblasti listu OLE objektu. V výstupní prezentaci, když dvakrát kliknete na OLE rámec zobrazující obrázek listu, aktivuje se sešit Excelu. Konečný uživatel může provádět libovolné změny ve skutečném sešitu Excelu a poté se vrátit na snímek kliknutím mimo aktivovaný sešit Excelu. Velikost OLE rámce se změní, když se uživatel vrátí na snímek. Faktor změny velikosti se bude lišit v závislosti na velikosti OLE rámce a vloženém sešitu Excelu.

## **Příčina změny velikosti**

Protože má sešit Excelu vlastní velikost okna, snaží se při první aktivaci zachovat původní rozměry. Naopak OLE rámec má své vlastní rozměry. Podle Microsoftu, když je sešit Excelu aktivován, Excel a PowerPoint se dohodnou na velikosti tak, aby byly zachovány správné proporce jako součást procesu vkládání. Změna velikosti nastává na základě rozdílů mezi velikostí okna Excelu a velikostí a polohou OLE rámce.

## **Fungující řešení**

Existují dva možná řešení, jak se vyhnout efektu změny velikosti.

- Přizpůsobit velikost OLE rámce v prezentaci PowerPoint tak, aby odpovídala výšce a šířce požadovaného počtu řádků a sloupců v OLE rámci.
- Zachovat konstantní velikost OLE rámce a měřítko velikosti zapojených řádků a sloupců tak, aby se vešly do vybrané velikosti OLE rámce.

### **Přizpůsobení velikosti OLE rámce**

V tomto přístupu se naučíme, jak nastavit velikost OLE rámce vloženého sešitu Excel tak, aby odpovídala kumulativní velikosti zapojených řádků a sloupců v listu Excelu.

Předpokládejme, že máme šablonový list Excel a chceme jej přidat do prezentace jako OLE rámec. V tomto scénáři bude velikost OLE objektu nejprve vypočtena na základě kumulativních výšek řádků a šířek sloupců zapojených do sešitu. Poté nastavíme velikost OLE rámce na tuto vypočtenou hodnotu. Abychom v PowerPointu předešli červené zprávě „EMBEDDED OLE OBJECT“ pro OLE rámec, zachytíme také obrázek požadovaných částí řádků a sloupců v sešitu a použijeme jej jako obrázek OLE rámce.

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

// Přidejte OLE obrázek do prostředků prezentace.
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

### **Přizpůsobení velikosti rozsahu buněk**

V tomto přístupu se naučíme, jak přizpůsobit výšky zapojených řádků a šířky zapojených sloupců tak, aby odpovídaly vlastní velikosti OLE rámce.

Předpokládejme, že máme šablonový list Excel a chceme jej přidat do prezentace jako OLE rámec. V tomto scénáři nastavíme velikost OLE rámce a přizpůsobíme velikost řádků a sloupců, které se podílejí na oblasti OLE rámce. Poté uložíme sešit do proudu, aby se změny aplikovaly, a převedeme jej na pole bajtů pro přidání do OLE rámce. Abychom v PowerPointu předešli červené zprávě „EMBEDDED OLE OBJECT“ pro OLE rámec, zachytíme také obrázek požadovaných částí řádků a sloupců v sešitu a použijeme jej jako obrázek OLE rámce.

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

// Upravte měřítko oblasti buněk, aby odpovídalo velikosti rámce.
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

{{% alert color="info" %}} 
Existují dva přístupy k odstranění problému se změnou velikosti listu. Výběr vhodného přístupu závisí na konkrétních požadavcích a scénáři použití. Oba přístupy fungují stejně, ať už jsou prezentace vytvořeny ze šablony nebo od nuly. Navíc pro toto řešení neexistuje žádný limit velikosti OLE objektu.
{{% /alert %}}

## **Často kladené otázky**

### Proč se vložený list Excelu po první aktivaci v PowerPointu změní velikost?

Stane se to, protože Excel se snaží zachovat původní velikost okna při aktivaci, zatímco OLE rámec v PowerPointu má své vlastní rozměry. PowerPoint a Excel se dohodnou na velikosti tak, aby byl zachován poměr stran, což může způsobit změnu velikosti.

### Je možné tento problém se změnou velikosti zcela eliminovat?

Ano. Přizpůsobením OLE rámce velikosti rozsahu buněk Excelu nebo přizpůsobením rozsahu buněk požadované velikosti OLE rámce lze zabránit nechtěné změně velikosti.

### Kterou metodu přizpůsobení použít, přizpůsobení OLE rámce nebo přizpůsobení rozsahu buněk?

Zvolte **přizpůsobení OLE rámce**, pokud chcete zachovat původní výšky a šířky řádků a sloupců v Excelu. Zvolte **přizpůsobení rozsahu buněk**, pokud chcete mít v prezentaci pevnou velikost OLE rámce.

### Budou tato řešení fungovat, pokud je moje prezentace založena na šabloně?

Ano. Obě řešení fungují pro prezentace vytvořené ze šablon i od nuly.

### Existuje limit velikosti OLE rámce při použití těchto metod?

Ne. OLE objekt může mít libovolnou velikost, pokud nastavíte měřítko odpovídajícím způsobem.

### Existuje způsob, jak se vyhnout textu „EMBEDDED OLE OBJECT“ v PowerPointu?

Ano. Pořízením snímku cílového rozsahu buněk Excelu a nastavením tohoto obrázku jako zástupného obrázku OLE rámce můžete zobrazit vlastní náhled místo výchozího zástupného textu.

## **Související články**

[Vytvoření grafu Excel a jeho vložení do prezentace jako OLE objekt](/slides/cs/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Automatické aktualizování OLE objektů pomocí doplňku MS PowerPoint](/slides/cs/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)