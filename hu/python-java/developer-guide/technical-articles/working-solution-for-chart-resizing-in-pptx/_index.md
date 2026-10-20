---
title: Működő megoldás a diagram átméretezésére PPTX-ben
type: docs
weight: 40
url: /hu/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagram átméretezés
- Excel diagram
- OLE objektum
- diagram beágyazása
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Javítsa ki a váratlan diagram átméretezést PPTX-ben, amikor beágyazott Excel OLE objektumokat használ az Aspose.Slides for Python via Java segítségével. Állítson be rögzített diagramméreteket, hogy a diagram és az OLE keret méretei konzisztens maradjanak."
---
## **Háttér**

Az Aspose komponensekkel PowerPoint prezentációkba beágyazott OLE objektumként megjelenő Excel-diagramok az első aktiválás után megváltoztathatják méretüket. Ez észrevehető különbséget eredményezhet a diagram megjelenésében az aktiválás előtti és utáni állapot között. Ebben a cikkben magyarázzuk, miért fordul elő az átméretezés, és bemutatjuk, hogyan lehet megakadályozni azt a diagram rögzített méretének az OLE kerethez való illesztésével.

Az [Excel-diagramok létrehozása és OLE objektumként való beágyazása a prezentációkba](/slides/hu/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) cikkben bemutattuk, hogyan hozhatunk létre Excel-diagramot az Aspose.Cells for Python via Java segítségével, és hogyan ágyazzuk be egy PowerPoint-prezentációba az Aspose.Slides for Python via Java használatával. Az [objektum előnézeti probléma](/slides/hu/python-java/object-preview-issue-when-adding-oleobjectframe/) megoldásához a diagramképét a diagram OLE objektumkeretéhez rendeltük. A kimeneti prezentációban, ha duplán kattintunk a diagramképet megjelenítő OLE objektumkeretre, aktiválódik az Excel-diagram. A felhasználók szerkeszthetik a beágyazott Excel-munkafüzetet, majd a diára visszatérhetnek a munkafüzeten kívül kattintva. Az OLE objektumkeret mérete megváltozik, amikor a felhasználó visszatér a diára, és az átméretezési arány a OLE objektumkeret és a beágyazott Excel-munkafüzet eredeti méreteitől függ.

## **Az átméretezés oka**

A beágyazott Excel-munkafüzet saját ablakmérettel rendelkezik, amelyet az Excel megpróbál megtartani az objektum első aktiválásakor. A dián lévő OLE keret függetlenül definiált méretekkel bír. Amikor az Excel-munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik az objektum méretét, hogy a beágyazási folyamat részeként megtartsák az arányokat. A munkafüzetablak és az OLE keret közötti különbségek ezért az objektum átméreteződését okozhatják.

## **Működő megoldás**

A példa az Aspose.Cells for Python via Java és az Aspose.Slides for Python via Java komponenseket igényli. Egy egyszerű oszlopdiagramot hoz létre egy aktív diagramlapon, és beágyazza a munkafüzetet XLS formátumban. Nem kerül diagram előnézeti kép hozzárendelésre; a diagram akkor válik láthatóvá, amikor a OLE objektum aktiválódik PowerPointban.

A példa egy új prezentációt hoz létre egy 9,5 × 4 hüvelykes OLE kerettel, amely 0,5 hüvelyk távolságra van a bal széltől és 1 hüvelyk távolságra a tetejétől. A dia koordinátái és méretei pontokban (72 pont hüvelykenként) vannak megadva. Létező prezentáció esetén lásd a [Sablon használata](#use-a-template) részt.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # A dia koordinátái és méretei pontokban vannak megadva (72 pont hüvelykenként).
        width = 684.0  # 9,5 hüvelyk.
        height = 288.0  # 4 hüvelyk.

        chart.setSizeWithWindow(False)
        # Konvertálja a pontokat diagrampixelekre 96 pixel hüvelykenként.
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **Rögzített diagramméret beállítása**

Állítsuk a [setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) értékét false-ra, hogy a diagram méretei függetlenek legyenek a munkafüzet ablakától. A [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) méreteit állítsuk be a [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) és a [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height) segítségével, a pontok átváltásával pixelekre 96 pixel hüvelykenként: a 684 × 288 pontot mérő keret 912 × 384 pixelnek felel meg. A [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) értékét állítsuk a [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/) CUSTOM értékére. A példa a munkafüzetet a [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) segítségével ágyazza be, és egy 9,5 × 4 hüvelykes OLE kerettel menti a prezentációt.

## **Sablon használata**

A méretlogika ugyanaz egy meglévő prezentáció esetén is. A példa adaptálásához:

1. Töltsük be a sablonprezentációt az üres prezentáció létrehozása helyett.
2. Ellenőrizzük, hogy az első dia legalább három alakzatot tartalmaz-e, majd a 2-es indexű alakzatot használjuk helykitöltőként.
3. Vessük át a keret szélességét és magasságát erről az alakzatról a 684 és 288 rögzített értékek helyett. Tartsuk változatlanul a méret számításokat.
4. Adjunk hozzá OLE keretet a helykitöltő pozíciójában a 36 és 72 rögzített koordináták helyett.
5. Távolítsuk el a helykitöltőt a prezentáció mentése előtt.

## **GYIK**

**Miért változik meg a beágyazott Excel-diagram mérete a PowerPointban történő aktiválás után?**

Ez azért történik, mert az Excel az első aktiváláskor megpróbálja visszaállítani az eredeti ablakméretet, míg a PowerPointban lévő OLE objektumkeretnek saját méretei vannak. A PowerPoint és az Excel egyeztetik a méretet, hogy megtartsák a képarányt, ami az átméretezést eredményezheti.

**Hogyan tarthatom konzisztensnek a diagram és az OLE keret méreteit?**

Állítsunk be rögzített diagramméreteket, amelyek megegyeznek az OLE kerettel, és használjunk egyedi diagramnyomtatási méretet a munkafüzet beágyazása előtt. A fenti példa bemutatja a szükséges beállításokat és egységátváltásokat.

**Elégséges a munkafüzetablak méretének illesztése?**

A munkafüzetablak méretének puszta illesztése nem biztos, hogy megbízhatóan megakadályozza az OLE keret méretének változását aktiválás után. Használjunk rögzített diagramméreteket, ahogy a példában látható.

**Működik ez a megoldás sablonalapú és új prezentációk esetén is?**

Igen. Sablon esetén használjuk a helykitöltő méreteit és pozícióját. Új prezentáció esetén közvetlenül adjuk meg a keret méreteit és pozícióját.

**Használhatom ezt a példát más táblázatkezelő programokkal készített diagramokkal?**

A példa egy Aspose.Cells által létrehozott Excel-munkafüzetet használ. Nem mutatja be más táblázatkezelő programok esetén a aktiválási viselkedést.

## **Kapcsolódó szakaszok**

- [Excel-diagramok létrehozása és OLE objektumként való beágyazása a prezentációkba](/slides/hu/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)