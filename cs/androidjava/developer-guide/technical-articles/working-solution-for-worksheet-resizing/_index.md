---
title: Řešení pro změnu velikosti listu
type: docs
weight: 20
url: /cs/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- náhledový obrázek
- změna velikosti obrázku
- Excel
- list
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Opravte změnu velikosti OLE listu Excelu v prezentacích: dva způsoby, jak udržet objektové rámy konzistentní — zvětšit rám nebo list — v formátech PPT a PPTX."
---
{{% alert color="info" %}}

Bylo zaznamenáno, že listy Excelu vložené jako OLE objekty do prezentace PowerPoint prostřednictvím komponent Aspose jsou po první aktivaci přepočítány na neidentifikovanou měřítko. Toto chování vytváří výrazný vizuální rozdíl v prezentaci mezi stavem OLE objektu před a po aktivaci. Problém jsme podrobně prozkoumali a poskytli řešení, které je popsáno v tomto článku.

{{% /alert %}}

## **Pozadí**

V článku [Správa OLE](/slides/cs/androidjava/manage-ole/) jsme vysvětlili, jak pomocí Aspose.Slides pro Android via Java přidat OLE rámec do prezentace PowerPoint. Pro řešení [problému s náhledem objektu](/slides/cs/androidjava/object-preview-issue-when-adding-oleobjectframe/) jsme OLE objektu přiřadili obrázek vybrané oblasti listu. Vygenerovaná prezentace po dvojitém kliknutí na OLE rámec zobrazující obrázek listu aktivuje sešit Excelu. Uživatelé mohou provádět jakékoli změny ve skutečném sešitě Excelu a poté se vrátit na snímek kliknutím mimo aktivovaný sešit. Velikost OLE rámce se po návratu uživatele na snímek změní. Faktor změny velikosti se liší podle velikosti OLE rámce a vloženého sešitu Excelu.

## **Příčina změny velikosti**

Protože má sešit Excelu vlastní velikost okna, při první aktivaci se snaží zachovat původní rozměry. OLE rámec má také své vlastní rozměry. Podle Microsoftu při aktivaci sešitu Excel a PowerPoint vyjednávají velikost tak, aby zachovaly správné proporce během procesu vkládání. Změna velikosti nastává na základě rozdílů mezi velikostí okna Excelu a velikostí a polohou OLE rámce.

## **Řešení**

Existují dva možné přístupy, jak předejít efektu změny velikosti.

- Změnit měřítko velikosti OLE rámce v prezentaci PowerPoint tak, aby odpovídalo výšce a šířce požadovaného počtu řádků a sloupců v OLE rámci.
- Zachovat konstantní velikost OLE rámce a změnit měřítko velikosti zapojených řádků a sloupců tak, aby se vešly do zvoleného OLE rámce.

### **Změna měřítka velikosti OLE rámu**

V tomto přístupu se naučíme, jak nastavit velikost OLE rámu vloženého sešitu Excel tak, aby odpovídala součtové velikosti zapojených řádků a sloupců v listu Excelu.

Předpokládejme, že máme šablonový list Excel a chceme jej přidat do prezentace jako OLE rám. V tomto scénáři se nejprve spočítá velikost OLE objektu na základě součtu výšek řádků a šířek sloupců zapojených v sešitu. Pak nastavíme velikost OLE rámu na tuto vypočtenou hodnotu. Abychom v PowerPointu zabránili červené zprávě „EMBEDDED OLE OBJECT“ u OLE rámu, také zachytíme obrázek požadovaných částí řádků a sloupců v sešitu a nastavíme jej jako obrázek OLE rámu.

```java
import com.aspose.slides.*;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// Potřebujeme použít modifikovaný sešit.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Přidejte OLE obrázek do zdrojů prezentace.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Vytvořte OLE objektový rámec.
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

### **Změna měřítka velikosti oblasti buněk**

V tomto přístupu se naučíme, jak změnit výšky zapojených řádků a šířky zapojených sloupců tak, aby odpovídaly vlastní velikosti OLE rámu.

Předpokládejme, že máme šablonový list Excel a chceme jej přidat do prezentace jako OLE rám. V tomto scénáři nastavíme velikost OLE rámu a změníme velikost řádků a sloupců, které se podílejí na oblasti OLE rámu. Pak uložíme sešit do proudu, aby se změny aplikovaly, a převedeme jej na pole bajtů pro přidání do OLE rámu. Abychom v PowerPointu zabránili červené zprávě „EMBEDDED OLE OBJECT“ u OLE rámu, také zachytíme obrázek požadovaných částí řádků a sloupců v sešitu a nastavíme jej jako obrázek OLE rámu.

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

// Změňte měřítko oblasti buněk tak, aby odpovídala velikosti rámu.
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

// Vytvořte OLE objektový rámec.
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

Existují dva přístupy k vyřešení problému změny velikosti listu. Výběr vhodného přístupu závisí na konkrétních požadavcích a scénáři použití. Oba přístupy fungují stejně, ať už jsou prezentace vytvořeny ze šablony nebo od nuly. Navíc v tomto řešení neexistuje žádný limit velikosti OLE objektu.

{{% /alert %}}

## **Často kladené otázky**

### Proč se vložený list Excelu po první aktivaci v PowerPointu zvětší nebo zmenší?

Stane se to, protože Excel se při aktivaci snaží zachovat původní velikost okna, zatímco OLE rám v PowerPointu má vlastní rozměry. PowerPoint a Excel si dohodnou velikost tak, aby zachovaly poměr stran, což může způsobit změnu velikosti.

### Je možné tomuto problému se změnou velikosti zcela předejít?

Ano. Změnou měřítka OLE rámu tak, aby odpovídal velikosti oblasti buněk Excelu, nebo změnou měřítka oblasti buněk tak, aby odpovídala požadované velikosti OLE rámu, můžete zabránit nechtěné změně velikosti.

### Kterou metodu měřítka mám použít, změnu měřítka OLE rámu nebo změnu měřítka oblasti buněk?

Vyberte **změnu měřítka OLE rámu**, pokud chcete zachovat původní velikosti řádků a sloupců v Excelu. Vyberte **změnu měřítka oblasti buněk**, pokud chcete mít v prezentaci pevnou velikost OLE rámu.

### Budou tato řešení fungovat, i když je moje prezentace založena na šabloně?

Ano. Obě řešení fungují pro prezentace vytvořené ze šablon i od nuly.

### Existuje limit velikosti OLE rámu při použití těchto metod?

Ne. OLE objekt můžete nastavit na libovolnou velikost, pokud nastavíte vhodné měřítko.

### Je možné odstranit text zástupce „EMBEDDED OLE OBJECT“ v PowerPointu?

Ano. Pořízením snímku cílové oblasti buněk v Excelu a nastavením tohoto snímku jako obrázku zástupce OLE rámu můžete zobrazit vlastní náhled místo výchozího zástupného textu.