---
title: Řešení pro změnu velikosti listu
type: docs
weight: 40
url: /cs/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- obrázek náhledu
- změna velikosti obrázku
- Excel
- list
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Opravte změnu velikosti OLE listu Excel v prezentacích: dva způsoby, jak udržet rámečky objektů konzistentní - změňte velikost rámce nebo listu - napříč formáty PPT a PPTX."
---
{{% alert color="primary" %}} 

Bylo zaznamenáno, že listy Excelu vložené jako OLE objekty do prezentace PowerPoint pomocí komponent Aspose se po první aktivaci přepočítají na neznámé měřítko. Toto chování vytváří zřetelný vizuální rozdíl v prezentaci mezi stavy OLE objektu před a po aktivaci. Problém jsme podrobně prozkoumali a poskytli řešení, které je popsáno v tomto článku.

{{% /alert %}} 

## **Pozadí**

V článku [Manage OLE](/slides/cs/python-net/manage-ole/) jsme vysvětlili, jak přidat OLE rámeček do prezentace PowerPoint pomocí Aspose.Slides for Python via .NET. Pro řešení [object preview issue](/slides/cs/python-net/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek vybrané oblasti listu OLE objektu. V výstupní prezentaci, když dvakrát kliknete na OLE rámeček zobrazující obrázek listu, aktivuje se sešit Excelu. Uživatelé mohou provést libovolné změny v skutečném sešitu Excelu a poté se vrátit na snímek kliknutím mimo aktivovaný sešit. Velikost OLE rámečku se změní, když se uživatel vrátí na snímek. Faktor změny velikosti se bude lišit v závislosti na velikosti OLE rámečku a vloženého sešitu Excelu. 

## **Příčina změny velikosti**

Protože má sešit Excelu vlastní velikost okna, pokouší se po první aktivaci zachovat původní velikost. Na druhou stranu má OLE rámeček vlastní rozměry. Podle Microsoftu, když je sešit Excelu aktivován, Excel a PowerPoint dohodnou velikost tak, aby byly zachovány správné proporce v rámci procesu vkládání. Změna velikosti nastává na základě rozdílů mezi velikostí okna Excelu a velikostí a polohou OLE rámečku. 

## **Řešení**

Existují dva možné způsoby, jak se vyhnout efektu změny velikosti.

- Změňte velikost OLE rámečku v prezentaci PowerPoint tak, aby odpovídala výšce a šířce požadovaného počtu řádků a sloupců v OLE rámečku.
- Nechte velikost OLE rámečku konstantní a změňte velikost zapojených řádků a sloupců tak, aby se vešly do vybrané velikosti OLE rámečku.

### **Změna měřítka velikosti OLE rámečku**

V tomto přístupu se naučíme, jak nastavit velikost OLE rámečku vloženého sešitu Excel tak, aby odpovídala kumulativní velikosti zapojených řádků a sloupců v listu Excel.

Předpokládejme, že máme šablonu listu Excel a chceme ji přidat do prezentace jako OLE rámeček. V tomto scénáři bude velikost OLE objektu nejprve vypočítána na základě kumulativní výšky řádků a šířky sloupců zapojených řádků a sloupců v sešitu. Poté nastavíme velikost OLE rámečku na tuto vypočtenou hodnotu. Abychom se vyhnuli červené zprávě „EMBEDDED OLE OBJECT“ u OLE rámečku v PowerPointu, také zachytíme obrázek požadovaných částí řádků a sloupců v sešitu a nastavíme jej jako obrázek OLE rámečku.

```py
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

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Nastavte zobrazovanou velikost, když je soubor sešitu použit jako OLE objekt v PowerPointu.
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

            # Vytvořte OLE objektový rámeček.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Změna měřítka velikosti rozsahu buněk**

V tomto přístupu se naučíme, jak změnit výšku zapojených řádků a šířku zapojených sloupců tak, aby odpovídaly vlastní velikosti OLE rámečku.

Předpokládejme, že máme šablonu listu Excel a chceme ji přidat do prezentace jako OLE rámeček. V tomto scénáři nastavíme velikost OLE rámečku a změníme velikost řádků a sloupců, které se podílejí na oblasti OLE rámečku. Poté uložíme sešit do proudu, aby se změny aplikovaly, a převedeme jej na pole bajtů pro přidání do OLE rámečku. Abychom se vyhnuli červené zprávě „EMBEDDED OLE OBJECT“ u OLE rámečku v PowerPointu, také zachytíme obrázek požadovaných částí řádků a sloupců v sešitu a nastavíme jej jako obrázek OLE rámečku.

```py
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

```py
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

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Nastavte zobrazovanou velikost, když je soubor sešitu použit jako OLE objekt v PowerPointu.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Změňte měřítko rozsahu buněk tak, aby odpovídal velikosti rámce.
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

            # Vytvořte OLE objektový rámec.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Závěr**

{{% alert color="primary" %}}

Existují dva přístupy k vyřešení problému se změnou velikosti listu. Výběr vhodného přístupu závisí na konkrétních požadavcích a použití. Oba přístupy fungují stejným způsobem, ať už jsou prezentace vytvořeny ze šablony nebo od nuly. Navíc v tomto řešení neexistuje žádný limit velikosti OLE objektu.

{{% /alert %}}