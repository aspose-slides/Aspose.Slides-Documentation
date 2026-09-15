---
title: Excel diagramok létrehozása és OLE objektumokként való beágyazása a prezentációkba
type: docs
weight: 30
url: /hu/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel diagram
- diagram beágyazása
- OLE objektum
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Excel diagramok létrehozása és OLE objektumként való beágyazása PowerPoint és OpenDocument prezentációkba Python segítségével. Lépésről lépésre útmutató kódrészletekkel."
---
## **Háttér**

A PowerPointban gyakori gyakorlat szerkeszthető diagramok használata az adatok grafikus megjelenítésére. Az Aspose támogatja az Excel diagramok létrehozását az Aspose.Cells for Python via Java segítségével, és ezeket a diagramokat később OLE objektumokként ágyazhatjuk be a PowerPoint diákba az Aspose.Slides for Python via Java segítségével. Ez a cikk bemutatja a szükséges lépéseket, és egy Python kódrészletet ad az Excel diagram létrehozásához és OLE objektumként való beágyazásához egy PowerPoint prezentációba az Aspose.Cells és az Aspose.Slides használatával.

## **Szükséges lépések**

A következő lépéssorozat szükséges egy Excel diagram OLE objektumként való létrehozásához és beágyazásához egy PowerPoint diára:

1. Excel diagram létrehozása Aspose.Cells segítségével.
1. Az Excel diagram OLE méretének beállítása Aspose.Cells segítségével.
1. Az Excel diagram képének lekérése Aspose.Cells segítségével.
1. Az Excel diagram beágyazása OLE objektumként PPTX prezentációba Aspose.Slides segítségével.
1. A "EMBEDDED OLE OBJECT" kép cseréje a 3. lépésben kapott képre a [objektum előnézeti probléma](/slides/hu/python-java/object-preview-issue-when-adding-oleobjectframe/) megoldásához.
1. A prezentáció mentése lemezre PPTX formátumban.

## **A szükséges lépések megvalósítása**

A fenti lépések Python megvalósítása a következő:

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
    # A cellanevek tömbje.
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # A cellák adatainak tömbje.
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # Új munkalap hozzáadása a cellák adatainak feltöltéséhez.
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # A adatlap feltöltése adatokkal.
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # Diagramlap hozzáadása.
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # Diagram hozzáadása a diagramlaphoz, az adatlap sorozataival.
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # A diagramlap beállítása aktív lapként.
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # A munkafüzet leírása beágyazott OLE adatokként.
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# Munkafüzet létrehozása.
workbook = Workbook()

# Excel diagram hozzáadása.
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# A diagram OLE méretének beállítása.
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# A diagram képének lekérése és egy adatfolyamba mentése.
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# A munkafüzet mentése egy adatfolyamba.
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# Prezentáció létrehozása.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # A munkafüzet hozzáadása egy diára.
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # A prezentáció mentése lemezre.
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A fenti módszerrel létrehozott prezentáció tartalmazni fogja az Excel diagramot OLE objektumként, amelyet a OLE objektumkeret duplakattintásával aktiválhatunk.

## **Összegzés**

Az Aspose.Cells for Python via Java és az Aspose.Slides for Python via Java együttes használatával minden, az Aspose.Cells által támogatott Excel diagram létrehozható, és a diagram OLE objektumként beágyazható egy PowerPoint diára. Az Excel diagram OLE mérete is megadható. A végfelhasználók ezután a diagramot bármely más OLE objektumként szerkeszthetik.

## **Kapcsolódó szakaszok**

- [Működő megoldás a diagram átméretezésére PPTX-ben](/slides/hu/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Objektum előnézeti probléma OleObjectFrame hozzáadásakor](/slides/hu/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **GYIK**

**Mely könyvtárak használatosak az Excel diagram létrehozásához és beágyazásához?**

Az Aspose.Cells for Python via Java hozza létre az Excel diagramot, és az Aspose.Slides for Python via Java ágyazza be azt OLE objektumként egy PowerPoint diára.

**Hogyan szerkeszthetik a felhasználók a beágyazott Excel diagramot?**

A felhasználók duplakattintással aktiválhatják az OLE objektumkeretet, majd a diagramot bármely más OLE objektumként szerkeszthetik.

**Hogyan cserélhető le az alapértelmezett OLE objektum előnézet?**

A példa az Excel diagram képét Aspose.Cells segítségével állítja elő, és ezt használja a "EMBEDDED OLE OBJECT" kép helyettesítésére.