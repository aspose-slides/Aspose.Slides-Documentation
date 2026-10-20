---
title: Řešení problému změny velikosti listu
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
description: "Opravte změnu velikosti OLE listu Excel v prezentacích: dva způsoby, jak udržet rámce objektů konzistentní—škálování rámce nebo listu—v PPT i PPTX formátech."
---
{{% alert color="info" title="Note" %}}

Excel listy vložené jako OLE objekty v prezentaci PowerPoint pomocí komponent Aspose se mohou po první aktivaci neočekávaně změnit velikost. Toto chování vytváří výrazný vizuální rozdíl mezi OLE objektem před a po aktivaci. Tento článek vysvětluje problém a popisuje dva způsoby, jak jej řešit.

{{% /alert %}}

## **Pozadí**

V článku [Správa OLE](/slides/cs/androidjava/manage-ole/) jsme vysvětlili, jak pomocí Aspose.Slides for Android via Java přidat OLE rámec do prezentace PowerPoint. Pro řešení [problému s náhledem objektu](/slides/cs/androidjava/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek vybrané oblasti listu k OLE objektovému rámci. V výstupní prezentaci, když dvakrát kliknete na OLE rámec zobrazující obrázek listu, aktivuje se sešit Excel. Koncový uživatel může provést libovolné úpravy skutečného sešitu Excel a poté se vrátit na snímek kliknutím mimo aktivovaný sešit Excel. Velikost OLE objektového rámce se změní, když se uživatel vrátí na snímek. Faktor změny velikosti se bude lišit v závislosti na velikosti OLE rámce a vloženého sešitu Excel.

## **Příčina změny velikosti**

Protože má sešit Excel vlastní velikost okna, snaží se po první aktivaci zachovat svou původní velikost. Na druhé straně OLE rámec má svou vlastní velikost. Podle Microsoftu, když je sešit Excel aktivován, Excel a PowerPoint vyjednávají velikost tak, aby zachovaly správné proporce jako součást procesu vkládání. Změna velikosti nastává na základě rozdílů mezi velikostí okna Excel a velikostí a umístěním OLE rámce.

## **Řešení**

Existují dva možná řešení, jak se vyhnout efektu změny velikosti.

- Změňte velikost OLE rámce v prezentaci PowerPoint tak, aby odpovídala celkové výšce a šířce vybraných řádků a sloupců.
- Uchovejte velikost OLE rámce konstantní a změňte měřítko vybraných řádků a sloupců tak, aby se vešly dovnitř.

### **Změna měřítka velikosti rámce OLE**

Tento přístup nastaví velikost OLE rámce tak, aby odpovídala celkové výšce a šířce vybraných řádků a sloupců ve vloženém listu Excel.

Příklad načte existující sešit Excel a vybere prvních 10 řádků a 13 sloupců jeho prvního listu pomocí nulových indexů. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definuje zobrazený rozsah. Náhled je vykreslen při 96 DPI a jeho rozměry v pixelech jsou převedeny na body pomocí 72 bodů na palec. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) vloží upravený sešit do rámce s těmito rozměry. Náhled je přiřazen prostřednictvím [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) pro nahrazení zástupného textu "EMBEDDED OLE OBJECT" v uložené prezentaci.

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

// Nastavte zobrazenou velikost, když je soubor sešitu použit jako OLE objekt v PowerPointu.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Získat šířku a výšku OLE obrázku v bodech.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

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

// Vytvořte rámec OLE objektu.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

Pomocník pro náhled nastaví [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) na vybraný rozsah a odstraní okraje, záhlaví i zápatí. S povoleným [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) vykreslí rozsah jako PNG obrázek. Pomocník vrátí nový vstupní stream obsahující PNG obrázek, umístěný na jeho začátku pro použití v prezentaci.

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

### **Změna měřítka velikosti buněčného rozsahu**

Tento přístup mění výšky vybraných řádků a šířky vybraných sloupců tak, aby odpovídaly vlastnímu rozměru OLE rámce.

Příklad načte existující sešit Excel a vybere prvních 10 řádků a 13 sloupců jeho prvního listu pomocí nulových indexů. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definuje zobrazený rozsah a níže uvedený pomocník mění tento rozsah, aby se vešel do rámce širokého 400 bodů a vysokého 100 bodů. Po uložení upraveného sešitu do streamu [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) jej vloží s určenou velikostí. Náhled vykreslený při 96 DPI je přiřazen přes [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--), takže uložená prezentace zobrazuje vybrané buňky místo výchozího zástupného textu.

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

// Změňte měřítko buněčného rozsahu, aby odpovídal velikosti rámce.
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

Pomocník pro měřítko vypočítá samostatné poměry šířky a výšky pro vybraný rozsah, přičemž zachovává relativní šířky jeho sloupců a relativní výšky jeho řádků. Přepočítané rozměry převádí z bodů na palce před jejich aplikací pomocí [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) a [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). Vybraný rozsah musí mít nenulovou šířku i výšku.

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

Tento pomocník pro náhled vykreslí změněný rozsah pomocí [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). Omezí [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) na tento rozsah, odstraní okraje, záhlaví i zápatí a vrátí PNG stream umístěný na jeho začátku.

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

Existují dva přístupy k vyřešení problému se změnou velikosti listu. Vyberte přístup, který nejlépe vyhovuje vašim požadavkům a scénáři použití. Oba přístupy fungují stejně, ať už jsou prezentace vytvořeny ze šablony nebo od nuly. Navíc v tomto řešení neexistuje žádný limit velikosti OLE objektového rámce.

{{% /alert %}}

## **Často kladené otázky**

**Proč se vložený list Excel změní po první aktivaci v PowerPointu?**

Stane se to, protože Excel se snaží při aktivaci zachovat původní velikost okna, zatímco OLE rámec v PowerPointu má své vlastní rozměry. PowerPoint a Excel pak vyjednávají velikost, aby zachovaly poměr stran, což může způsobit změnu velikosti.

**Je možné tento problém se změnou velikosti zcela zabránit?**

Ano. Změněním měřítka OLE rámce tak, aby odpovídal velikosti rozsahu buněk Excel, nebo změnou měřítka rozsahu buněk tak, aby odpovídal požadované velikosti OLE rámce, můžete zabránit nechtěné změně velikosti.

**Kterou metodu měřítka mám používat, měřítko OLE rámce nebo měřítko buněčného rozsahu?**

Vyberte **měřítko OLE rámce**, pokud chcete zachovat původní velikosti řádků a sloupců v Excelu. Vyberte **měřítko buněčného rozsahu**, pokud chcete mít v prezentaci pevnou velikost OLE rámce.

**Budou tato řešení fungovat, pokud je moje prezentace založena na šabloně?**

Ano. Obě řešení fungují pro prezentace vytvořené ze šablon i od začátku.

**Existuje limit velikosti OLE rámce při použití těchto metod?**

Ne. OLE objektový rámec můžete nastavit na jakoukoli velikost, pokud odpovídajícím způsobem nastavíte měřítko.

**Je možné se vyhnout textu zástupného obrazu "EMBEDDED OLE OBJECT" v PowerPointu?**

Ano. Pořízením snímku cílového rozsahu buněk Excel a nastavením tohoto snímku jako obrázku zástupného objektu OLE můžete zobrazit vlastní náhledový obrázek místo výchozího zástupného textu.

## **Související články**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/cs/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/cs/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)