---
title: Řešení pro změnu velikosti listu
type: docs
weight: 20
url: /cs/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- náhledový obrázek
- změna velikosti obrázku
- Excel
- list
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Opravte změnu velikosti OLE listu Excel v prezentacích: dva způsoby, jak udržet rámce objektů konzistentní — škálovat rámec nebo list — v formátech PPT a PPTX."
---
{{% alert color="info" title="Note" %}}

Tabulky Excel vložené jako OLE objekty v prezentaci PowerPoint pomocí komponent Aspose se mohou po první aktivaci neočekávaně změnit velikost. Toto chování vytváří znatelný vizuální rozdíl mezi OLE objektem před a po aktivaci. Tento článek vysvětluje problém a popisuje dva způsoby, jak jej řešit.

{{% /alert %}}

## **Pozadí**

V článku [Spravovat OLE](/slides/cs/python-java/manage-ole/) jsme vysvětlili, jak přidat OLE rámec do prezentace PowerPoint pomocí Aspose.Slides pro Python přes Java. Pro řešení [problému s náhledem objektu](/slides/cs/python-java/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek vybrané oblasti listu do OLE rámce. Ve výstupní prezentaci, když dvakrát kliknete na OLE rámec zobrazující obrázek listu, aktivuje se sešit Excel. Uživatelé mohou provádět libovolné změny v reálném sešitu Excel a poté se vrátit na snímek kliknutím mimo aktivovaný sešit Excel. Velikost OLE rámce se změní, když se uživatel vrátí na snímek. Faktor změny velikosti se bude lišit v závislosti na velikosti OLE rámce a vloženého sešitu Excel.

## **Příčina změny velikosti**

Protože má sešit Excel vlastní velikost okna, snaží se při první aktivaci zachovat svou původní velikost. Naopak OLE objektový rámec má vlastní rozměry. Podle Microsoftu, když je sešit Excel aktivován, Excel a PowerPoint vyjednávají velikost tak, aby zachovaly správné proporce jako součást procesu vložení. Změna velikosti nastává na základě rozdílů mezi velikostí okna Excel a velikostí a polohou OLE objektového rámce.

## **Řešení**

Existují dvě možná řešení, jak se vyhnout efektu změny velikosti.

- Změřte OLE rámec v prezentaci PowerPoint tak, aby odpovídal celkové výšce a šířce vybraných řádků a sloupců.
- Udržujte velikost OLE rámce konstantní a přizpůsobte vybrané řádky a sloupce tak, aby do něj pasovaly.

### **Změna velikosti OLE rámce**

Tento přístup nastaví velikost OLE rámce tak, aby odpovídala celkové výšce a šířce vybraných řádků a sloupců v vloženém listu Excel.

Příklad načte existující sešit Excel a vybere prvních 10 řádků a 13 sloupců jeho prvního listu pomocí nulových indexů. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) určuje zobrazovaný rozsah. Náhled je vykreslen při 96 DPI a jeho rozměry v pixelech jsou převedeny na body pomocí 72 bodů na palec. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) vloží upravený sešit do rámce s těmito rozměry. Náhled je přiřazen pomocí [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) k nahrazení zástupného textu „EMBEDDED OLE OBJECT“ v uložené prezentaci.

Pomocník pro náhled nastaví [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) na vybraný rozsah a odstraní okraje, záhlaví a zápatí. S povoleným [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea) [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) vykreslí rozsah jako PNG obrázek. Pomocník vrátí nový vstupní stream obsahující PNG obrázek, umístěný na jeho začátku pro použití v prezentaci.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96

workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Nastavte zobrazovanou velikost, když je sešit používán jako OLE objekt v PowerPointu.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # Získejte šířku a výšku OLE obrázku v bodech.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # Použijte upravený sešit.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Přidejte OLE obrázek do zdrojů prezentace.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Vytvořte OLE objektový rámec.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

### **Změna velikosti rozsahu buněk**

Tento přístup mění výšky vybraných řádků a šířky vybraných sloupců tak, aby odpovídaly vlastní velikosti OLE rámce.

Příklad načte existující sešit Excel a vybere prvních 10 řádků a 13 sloupců jeho prvního listu pomocí nulových indexů. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) určuje zobrazovaný rozsah a pomocník scale_cell_range přizpůsobí tento rozsah tak, aby pasoval do rámce širokého 400 bodů a vysokého 100 bodů. Po uložení upraveného sešitu do proudu [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) jej vloží s určenou velikostí. Náhled vykreslený při 96 DPI je přiřazen pomocí [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), takže uložená prezentace zobrazí vybrané buňky místo výchozího zástupného textu.

Pomocník pro měřítko vypočítá samostatné poměry šířky a výšky pro vybraný rozsah, zachovává relativní šířky jeho sloupců a relativní výšky jeho řádků. Převádí vypočtené rozměry z bodů na palce před jejich použitím pomocí [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) a [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch). Vybraný rozsah musí mít nenulovou šířku i výšku.

Tento pomocník pro náhled vykresluje změněný rozsah pomocí [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage). Omezí [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) na tento rozsah, odstraní okraje, záhlaví a zápatí a vrátí PNG stream umístěný na jeho začátku.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


def scale_cell_range(cell_range, width, height):
    # Očekávaná šířka a výška rozsahu buněk jsou v bodech.
    range_width = cell_range.getWidth()
    range_height = cell_range.getHeight()
    cells = cell_range.getWorksheet().getCells()

    for i in range(cell_range.getColumnCount()):
        column_index = cell_range.getFirstColumn() + i
        column_width = cells.getColumnWidth(column_index, False, CellsUnitType.POINT)
        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72.0
        cells.setColumnWidthInch(column_index, width_in_inches)

    for i in range(cell_range.getRowCount()):
        row_index = cell_range.getFirstRow() + i
        row_height = cells.getRowHeight(row_index, False, CellsUnitType.POINT)
        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72.0
        cells.setRowHeightInch(row_index, height_in_inches)


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96
frame_width, frame_height = 400.0, 100.0
workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Nastavte zobrazovanou velikost, když je sešit používán jako OLE objekt v PowerPointu.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Změňte velikost rozsahu buněk tak, aby odpovídal velikosti rámce.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # Použijte upravený sešit.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Přidejte OLE obrázek do zdrojů prezentace.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Vytvořte OLE objektový rámec.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

## **Závěr**

{{% alert color="info" title="Note" %}} 

Existují dva přístupy k opravě problému se změnou velikosti listu. Vyberte přístup, který nejlépe vyhovuje vašim požadavkům a použití. Oba přístupy fungují stejně, ať už jsou prezentace vytvořeny ze šablony nebo od nuly. Navíc neexistuje žádný limit velikosti OLE objektového rámce v tomto řešení.

{{% /alert %}}

## **Často kladené otázky**

**Proč se vložený list Excel změní ve velikosti při první aktivaci v PowerPointu?**

Stane se to, protože Excel se při aktivaci snaží zachovat původní velikost okna, zatímco OLE objektový rámec v PowerPointu má vlastní rozměry. PowerPoint a Excel vyjednávají velikost, aby udržely poměr stran, což může způsobit změnu velikosti.

**Je možné tomuto problému se změnou velikosti zcela zabránit?**

Ano. Škálováním OLE rámce tak, aby odpovídal velikosti Excelového rozsahu buněk, nebo škálováním rozsahu buněk tak, aby odpovídal požadované velikosti OLE rámce, můžete zabránit nechtěné změně velikosti.

**Kterou metodu škálování mám použít, škálování OLE rámce nebo škálování rozsahu buněk?**

Vyberte **škálování OLE rámce**, pokud chcete zachovat původní velikosti řádků a sloupců v Excelu. Vyberte **škálování rozsahu buněk**, pokud chcete mít v prezentaci pevnou velikost OLE rámce.

**Budou tato řešení fungovat, pokud je moje prezentace založena na šabloně?**

Ano. Obě řešení fungují pro prezentace vytvořené ze šablon i od začátku.

**Existuje limit velikosti OLE rámce při použití těchto metod?**

Ne. OLE objektový rámec může mít libovolnou velikost, pokud nastavíte škálování odpovídajícím způsobem.

**Existuje způsob, jak se vyhnout textu „EMBEDDED OLE OBJECT“ jako zástupnému textu v PowerPointu?**

Ano. Pořízením snímku cílového Excelového rozsahu buněk a nastavením tohoto snímku jako zástupného obrázku OLE rámce můžete v prezentaci zobrazit vlastní náhled místo výchozího zástupného textu.

## **Related Articles**

[Vytvoření grafu Excel a vložení do prezentace jako OLE objekt](/slides/cs/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Automatická aktualizace OLE objektů pomocí doplňku MS PowerPoint](/slides/cs/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)