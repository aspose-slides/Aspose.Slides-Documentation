---
title: Řešení pro změnu velikosti listu
type: docs
weight: 40
url: /cs/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- náhledový obrázek
- změna velikosti obrázku
- Excel
- list
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Opravte změnu velikosti OLE pracovního listu v prezentacích: dvě možnosti, jak udržet objektové rámy konzistentní—škálovat rám nebo list—v PPT a PPTX formátech."
---
{{% alert color="info" title="Note" %}}
Excel listy vložené jako OLE objekty v prezentaci PowerPoint pomocí komponent Aspose se mohou po první aktivaci neočekávaně změnit velikost. Toto chování vytváří výrazný vizuální rozdíl mezi OLE objektem před a po aktivaci. Tento článek vysvětluje problém a popisuje dva způsoby, jak jej řešit.
{{% /alert %}} 

## **Pozadí**

V článku [Manage OLE](/slides/cs/python-net/manage-ole/), jsme vysvětlili, jak pomocí Aspose.Slides pro Python via .NET přidat OLE rámec do prezentace PowerPoint. Pro řešení [object preview issue](/slides/cs/python-net/object-preview-issue-when-adding-oleobjectframe/), jsme přiřadili obrázek vybrané oblasti listu do OLE objektového rámce. V výstupní prezentaci, když dvojkliknete na OLE rámec zobrazující obrázek listu, aktivuje se sešit Excel. Uživatelé mohou provést jakékoli požadované změny ve skutečném sešitu Excel a poté se vrátit na snímek kliknutím mimo aktivovaný sešit Excel. Velikost OLE objektového rámce se změní, když se uživatel vrátí na snímek. Faktor změny velikosti se bude lišit v závislosti na velikosti OLE objektového rámce a vloženého sešitu Excel.

## **Příčina změny velikosti**

Protože má sešit Excel vlastní velikost okna, snaží se po první aktivaci zachovat původní velikost. Na druhou stranu má OLE objektový rámec vlastní velikost. Podle Microsoftu, když je sešit Excel aktivován, Excel a PowerPoint vyjednávají velikost tak, aby zachovaly správné proporce jako součást procesu vkládání. Změna velikosti nastává na základě rozdílů mezi velikostí okna Excel a velikostí a pozicí OLE objektového rámce.

## **Fungující řešení**

Existují dva možné způsoby, jak se vyhnout efektu změny velikosti.

- Upravit velikost OLE rámce v prezentaci PowerPoint tak, aby odpovídala celkové výšce a šířce vybraných řádků a sloupců.
- Udržet velikost OLE rámce konstantní a škálovat vybrané řádky a sloupce tak, aby se vešly.

### **Škálování velikosti OLE rámce**

Tento přístup nastaví velikost OLE rámce tak, aby odpovídala celkové výšce a šířce vybraných řádků a sloupců ve vloženém listu Excel.

Příklad načte existující sešit Excel a vybere prvních 10 řádků a 13 sloupců jeho prvního listu pomocí nulových indexů. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) definuje zobrazovaný rozsah. Náhled je vykreslen při 96 DPI a jeho rozměry v pixelech jsou převedeny na body pomocí 72 bodů na palec. [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) vloží upravený sešit do rámce s těmito rozměry. Náhled je přiřazen pomocí [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) k nahrazení zástupného textu "EMBEDDED OLE OBJECT" v uložené prezentaci.

Pomocník pro náhled nastaví [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) na vybraný rozsah a odstraní okraje, záhlaví a zápatí. S povoleným [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/) [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) vykreslí rozsah jako PNG obrázek. Pomocník přetočí proud obrázku před jeho vrácením k použití v prezentaci.

```py
import io
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

Úplný příklad níže kombinuje pomocníky s vložením sešitu a uloží prezentaci jako `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Nastavte zobrazenou velikost, když je soubor sešitu použit jako OLE objekt v PowerPointu.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Získejte šířku a výšku OLE obrázku v bodech.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # Musíme použít upravený sešit.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Přidejte OLE obrázek do zdrojů prezentace.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Vytvořte rámec OLE objektu.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Škálování velikosti rozsahu buněk**

Tento přístup škáluje výšky vybraných řádků a šířky vybraných sloupců tak, aby odpovídaly vlastní velikosti OLE rámce.

Příklad načte existující sešit Excel a vybere prvních 10 řádků a 13 sloupců jeho prvního listu pomocí nulových indexů. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) definuje zobrazovaný rozsah a níže uvedený pomocník škáluje tento rozsah tak, aby se vešel do rámce širokého 400 bodů a vysokého 100 bodů. Po uložení upraveného sešitu do proudu [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) vloží jej s určenou velikostí. Náhled vykreslený při 96 DPI je přiřazen pomocí [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/), takže uložená prezentace zobrazuje vybrané buňky místo výchozího zástupného textu.

Škálovací pomocník vypočítá samostatné poměry šířky a výšky pro vybraný rozsah, přičemž zachovává relativní šířky jeho sloupců a relativní výšky jeho řádků. Převede vypočtené rozměry z bodů na palce před jejich aplikací pomocí [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) a [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/). Vybraný rozsah musí mít nenulovou šířku a výšku.

```py
import aspose.cells as cells

# <param name="width">Očekávaná šířka rozsahu buněk v bodech.</param>
# <param name="height">Očekávaná výška rozsahu buněk v bodech.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)
```

Tento pomocník pro náhled vykreslí změněný rozsah pomocí [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/). Omezí [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) na tento rozsah, odstraní okraje, záhlaví a zápatí a vrátí PNG proud nastavený na jeho začátek.

```py
import io
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

Úplný příklad níže kombinuje pomocníky s vložením sešitu a uloží prezentaci jako `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

# <param name="width">Očekávaná šířka rozsahu buněk v bodech.</param>
# <param name="height">Očekávaná výška rozsahu buněk v bodech.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Nastavte zobrazenou velikost, když je soubor sešitu použit jako OLE objekt v PowerPointu.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Škálujte rozsah buněk tak, aby odpovídal velikosti rámce.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # Musíme použít upravený sešit.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Přidejte OLE obrázek do zdrojů prezentace.
            ole_image = presentation.images.add_image(image_stream)

            # Vytvořte rámec OLE objektu.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Závěr**

{{% alert color="info" title="Note" %}}
Existují dva přístupy k opravě problému se změnou velikosti listu. Vyberte přístup, který nejlépe vyhovuje vašim požadavkům a scénáři použití. Oba přístupy fungují stejným způsobem, ať už jsou prezentace vytvořeny ze šablony nebo od nuly. Navíc v tomto řešení neexistuje žádný limit velikosti OLE objektového rámce.
{{% /alert %}}

## **Často kladené otázky**

**Proč se vložený list Excel změní ve velikosti při první aktivaci v PowerPointu?**

K tomu dochází, protože Excel se snaží při aktivaci zachovat původní velikost okna, zatímco OLE objektový rámec v PowerPointu má své vlastní rozměry. PowerPoint a Excel vyjednávají velikost tak, aby zachovaly poměr stran, což může způsobit změnu velikosti.

**Je možné tomuto problému se změnou velikosti zcela zabránit?**

Ano. Škálováním OLE rámce tak, aby odpovídal velikosti buněčného rozsahu Excel, nebo škálováním buněčného rozsahu tak, aby odpovídal požadované velikosti OLE rámce, můžete zabránit nechtěné změně velikosti.

**Kterou metodu škálování mám použít, škálování OLE rámce nebo škálování buněčného rozsahu?**

Zvolte **škálování OLE rámce**, pokud chcete zachovat původní velikosti řádků a sloupců v Excelu. Zvolte **škálování buněčného rozsahu**, pokud chcete ve své prezentaci mít OLE rámec s pevnou velikostí.

**Bude tato řešení fungovat, pokud je moje prezentace založena na šabloně?**

Ano. Obě řešení fungují pro prezentace vytvořené ze šablon i od nuly.

**Existuje limit velikosti OLE rámce při používání těchto metod?**

Ne. Můžete nastavit OLE objektový rámec na libovolnou velikost, pokud správně nastavíte měřítko.

**Existuje způsob, jak se vyhnout zástupnému textu „EMBEDDED OLE OBJECT“ v PowerPointu?**

Ano. Pořízením snímku cílového buněčného rozsahu v Excelu a nastavením tohoto snímku jako zástupného obrázku OLE rámce můžete v prezentaci zobrazit vlastní náhledový obrázek místo výchozího zástupného textu.