---
title: Řešení pro změnu velikosti listu
type: docs
weight: 20
url: /cs/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- náhledový obrázek
- škálování obrázku
- Excel
- list
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Opravte změnu velikosti OLE listu Excel v prezentacích: dva způsoby, jak zachovat konzistentní rámce objektů – škálováním rámce nebo listu – napříč formáty PPT a PPTX."
---
{{% alert color="info" title="Note" %}}

Bylo zjištěno, že listy aplikace Excel vložené jako OLE objekty v prezentaci PowerPoint prostřednictvím komponent Aspose jsou po první aktivaci změněny na neurčitou velikost. Toto chování vytváří znatelný vizuální rozdíl v prezentaci mezi stavem OLE objektu před a po aktivaci. Problém jsme detailně prozkoumali a poskytli řešení, které je popsáno v tomto článku.

{{% /alert %}}

## **Pozadí**

V článku [Správa OLE](/slides/cs/python-java/manage-ole/) jsme vysvětlili, jak přidat OLE rámec do prezentace PowerPoint pomocí Aspose.Slides for Python via Java. Pro řešení [problém s náhledem objektu](/slides/cs/python-java/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek vybrané oblasti listu OLE objektu. V výstupní prezentaci, když dvakrát kliknete na OLE rámec zobrazující obrázek listu, aktivuje se sešit Excelu. Koneční uživatelé mohou provést libovolné změny ve skutečném sešitu Excel a poté se vrátí na snímek kliknutím mimo aktivovaný sešit Excel. Velikost OLE rámce se změní, když se uživatel vrátí na snímek. Faktor změny velikosti se bude lišit v závislosti na velikosti OLE rámce a vloženého sešitu Excel.

## **Příčina změny velikosti**

Protože sešit Excel má vlastní velikost okna, snaží se po první aktivaci zachovat původní velikost. Na druhé straně OLE objektový rámec má svou velikost. Podle Microsoftu, když je sešit Excel aktivován, Excel a PowerPoint vyjednávají velikost, aby zachovaly správné proporce jako součást procesu vkládání. Změna velikosti nastává na základě rozdílů mezi velikostí okna Excel a velikostí a polohou OLE objektového rámce.

## **Fungující řešení**

Existují dva možné řešení, jak zabránit efektu změny velikosti.

- Změňte velikost OLE rámce v prezentaci PowerPoint tak, aby odpovídala výšce a šířce požadovaného počtu řádků a sloupců v OLE rámci.
- Udržujte velikost OLE rámce konstantní a škálujte velikost zapojených řádků a sloupců tak, aby se vešly do vybrané velikosti OLE rámce.

### **Škálování velikosti OLE rámce**

V tomto přístupu se naučíme, jak nastavit velikost OLE rámce vloženého sešitu Excel tak, aby odpovídala kumulativní velikosti zapojených řádků a sloupců v listu Excel.

Řekněme, že máme šablonu listu Excel a chceme jej přidat do prezentace jako OLE rámec. V tomto scénáři bude velikost OLE objektového rámce nejprve vypočítána na základě kumulativních výšek řádků a šířek sloupců zapojených řádků a sloupců v sešitu. Poté nastavíme velikost OLE rámce na tuto vypočtenou hodnotu. Abychom se vyhnuli červené zprávě „EMBEDDED OLE OBJECT“ pro OLE rámec v PowerPointu, také zachytíme obrázek požadovaných částí řádků a sloupců v sešitu a nastavíme jej jako obrázek OLE rámce.

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
        # Získat šířku a výšku OLE obrázku v bodech.
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

### **Škálování velikosti rozsahu buněk**

V tomto přístupu se naučíme, jak škálovat výšky zapojených řádků a šířky zapojených sloupců, aby odpovídaly vlastní velikosti OLE rámce.

Řekněme, že máme šablonu listu Excel a chceme jej přidat do prezentace jako OLE rámec. V tomto scénáři nastavíme velikost OLE rámce a škálujeme velikost řádků a sloupců, které se podílejí na oblasti OLE rámce. Pak uložíme sešit do proudu, abychom změny aplikovali, a převedeme jej na pole bajtů pro přidání do OLE rámce. Abychom se vyhnuli červené zprávě „EMBEDDED OLE OBJECT“ pro OLE rámec v PowerPointu, také zachytíme obrázek požadovaných částí řádků a sloupců v sešitu a nastavíme jej jako obrázek OLE rámce.

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
    # Škálujte rozsah buněk tak, aby odpovídal velikosti rámce.
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

Existují dva přístupy k vyřešení problému se změnou velikosti listu. Výběr vhodného přístupu závisí na konkrétních požadavcích a použití. Oba přístupy fungují stejným způsobem, ať už jsou prezentace vytvořeny ze šablony nebo od nuly. Navíc v tomto řešení neexistuje žádný limit velikosti OLE objektového rámce.

{{% /alert %}}

## **Často kladené otázky**

**Proč se vložený list Excel mění po první aktivaci v PowerPointu?**

Tento jev nastává, protože Excel se při aktivaci snaží zachovat původní velikost okna, zatímco OLE objektový rámec v PowerPointu má své vlastní rozměry. PowerPoint a Excel vyjednávají velikost, aby zachovaly poměr stran, což může způsobit změnu velikosti.

**Je možné tomuto problému se změnou velikosti zcela zabránit?**

Ano. Škálováním OLE rámce tak, aby odpovídal velikosti rozsahu buněk Excel, nebo škálováním rozsahu buněk tak, aby odpovídal požadované velikosti OLE rámce, můžete zabránit nechtěné změně velikosti.

**Kterou metodu škálování mám použít, škálování OLE rámce nebo škálování rozsahu buněk?**

Zvolte **škálování OLE rámce**, pokud chcete zachovat původní velikosti řádků a sloupců v Excelu. Zvolte **škálování rozsahu buněk**, pokud chcete v prezentaci pevnou velikost OLE rámce.

**Budou tato řešení fungovat, pokud je moje prezentace založena na šabloně?**

Ano. Obě řešení fungují pro prezentace vytvořené ze šablon i od nuly.

**Existuje limit velikosti OLE rámce při používání těchto metod?**

Ne. OLE objektový rámec můžete nastavit na libovolnou velikost, pokud nastavíte škálování správně.

**Je možné se vyhnout textu zástupce „EMBEDDED OLE OBJECT“ v PowerPointu?**

Ano. Pořízením snímku cílového rozsahu buněk v Excelu a nastavením tohoto snímku jako obrázku zástupce OLE rámce můžete zobrazit vlastní náhledový obrázek místo výchozího zástupce.

## **Související články**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/cs/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)