---
title: Vytvoření grafů Excel a jejich vložení do prezentací jako OLE objekty
type: docs
weight: 30
url: /cs/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Graf Excel
- vložit graf
- OLE objekt
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Vytvořte grafy Excel a vložte je jako OLE objekty do prezentací PowerPoint a OpenDocument pomocí Pythonu. Průvodce krok za krokem s ukázkami kódu."
---
## **Pozadí**

V PowerPointu je běžnou praxí používat editovatelné grafy k vizuálnímu zobrazení dat. Aspose podporuje vytváření grafů Excel pomocí Aspose.Cells for Python via Java a tyto grafy lze poté vložit jako OLE objekty do snímků PowerPointu prostřednictvím Aspose.Slides for Python via Java. Tento článek popisuje potřebné kroky a poskytuje ukázkový kód v Pythonu pro vytvoření grafu Excel a jeho vložení jako OLE objektu do prezentace PowerPoint pomocí Aspose.Cells a Aspose.Slides.

## **Požadované kroky**

Následující sekvence kroků je nutná k vytvoření a vložení grafu Excel jako OLE objektu do snímku PowerPoint:

1. Vytvořte graf Excel pomocí Aspose.Cells.
2. Nastavte velikost OLE grafu Excel pomocí Aspose.Cells.
3. Získejte obrázek grafu Excel pomocí Aspose.Cells.
4. Vložte graf Excel jako OLE objekt do PPTX prezentace pomocí Aspose.Slides.
5. Nahraďte obrázek „EMBEDDED OLE OBJECT“ obrázkem získaným ve kroku 3, aby se vyřešil [object preview issue](/slides/cs/python-java/object-preview-issue-when-adding-oleobjectframe/).
6. Uložte prezentaci na disk ve formátu PPTX.

## **Implementace požadovaných kroků**

Python implementace výše uvedených kroků vypadá následovně:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def add_excel_chart_in_workbook(workbook, chart_rows, chart_columns):
    # Pole názvů buněk.
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # Pole dat buněk.
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # Přidejte nový pracovní list pro naplnění buněk daty.
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # Naplněte datový list daty.
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # Přidejte list s grafem.
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # Přidejte graf do listu s grafem pomocí datových řad z datového listu.
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # Nastavte list s grafem jako aktivní list.
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # Popište sešit jako vložená OLE data.
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# Vytvořte sešit.
workbook = Workbook()

# Přidejte graf Excel.
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# Nastavte velikost OLE grafu.
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# Získejte obrázek grafu a uložte jej do proudu.
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# Uložte sešit do proudu.
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# Vytvořte prezentaci.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Přidejte sešit do snímku.
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # Uložte prezentaci na disk.
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Prezentace vytvořená výše uvedenou metodou bude obsahovat graf Excel jako OLE objekt, který lze aktivovat dvojitým klepnutím na rámec OLE objektu.

## **Závěr**

Používáním Aspose.Cells for Python via Java spolu s Aspose.Slides for Python via Java můžeme vytvořit libovolný graf Excel podporovaný Aspose.Cells a vložit jej jako OLE objekt do snímku PowerPointu. Velikost OLE grafu Excel lze také definovat. Koneční uživatelé pak mohou graf Excel upravovat jako jakýkoli jiný OLE objekt.

## **Související sekce**

- [Working Solution for Chart Resizing in PPTX](/slides/cs/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/cs/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **Často kladené otázky**

**Které knihovny se používají k vytvoření a vložení grafu Excel?**

Aspose.Cells for Python via Java vytváří graf Excel a Aspose.Slides for Python via Java jej vkládá jako OLE objekt do snímku PowerPoint.

**Jak mohou uživatelé upravit vložený graf Excel?**

Uživatelé mohou dvojitým klepnutím na rámec OLE objektu aktivovat graf a upravit jej jako jakýkoli jiný OLE objekt.

**Jak je nahrazen výchozí náhled OLE objektu?**

Příklad získá obrázek grafu Excel pomocí Aspose.Cells a použije jej k nahrazení obrázku „EMBEDDED OLE OBJECT“.