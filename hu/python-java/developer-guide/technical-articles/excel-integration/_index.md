---
title: Excel adatok integrálása PowerPoint prezentációkba
linktitle: Excel integráció
type: docs
weight: 330
url: /hu/python-java/excel-integration/
keywords:
- Excel
- munkafüzet
- Excel beolvasása
- Excel integrálása
- adatforrás
- levélkör
- tábla importálása
- Excel a PowerPointba
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Olvassa be az Excel munkafüzetek adatait az Aspose.Slides for Python via Java segítségével az ExcelDataWorkbook API-val. Töltsön be munkalapokat és cellákat, és használja az értékeket adatvezérelt PowerPoint prezentációk létrehozásához."
---
## **Bevezetés**

A PowerPoint‑prezentációk hatékony módot nyújtanak az információk megjelenítésére és közvetítésére. Gyakran használják őket Excel munkafüzetekkel együtt, ahol az Excel kiváló forrása a strukturált adatoknak, a PowerPoint pedig kiemelkedő a közönség számára történő adatmegjelenítésben.

Számos gyakorlati helyzetben elengedhetetlen az Excel és a PowerPoint egyesítése: levélkörök (mail merge), adatok táblázatba való feltöltése, egy diát egy adatrekordhoz generálása (kötegelt dia létrehozás), képzési anyagok készítése, valamint több Excel‑jelentés összevonása egyetlen prezentációba, csak néhány példa.

Eddig az ilyen funkciók megvalósítása az Aspose.Slides API-val harmadik fél megoldásaira, például az Aspose.Cells‑ra támaszkodott. Bár ezek az eszközök robusztusak, túl komplexek és költségesek lehetnek azok számára, akiknek csak az alapvető adatintegrációs funkcióra van szükségük.

## **Hogyan működik**

Az Excel adatokkal való munka egyszerűbbé és hatékonyabbá tétele érdekében az Aspose.Slides új osztályokat vezetett be az Excel munkafüzetek adatainak olvasásához és a tartalom prezentációba importálásához. Ez a funkció új, erőteljes lehetőségeket nyit meg az API‑felhasználók számára, akik az Excelt adatforrásként kívánják használni a prezentációs munkafolyamatokban.

Az új funkció általános célú adatlekérésre készült, és nincs integrálva a Presentation Document Object Model (DOM)‑ba. Ez azt jelenti, hogy *nem engedélyezi az Excel‑fájlok szerkesztését vagy mentését* — kizárólag a munkafüzetek megnyitására és tartalmukban való navigálásra, valamint a cellaadatok lekérdezésére szolgál.

A funkció középpontjában az új [ExcelDataWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/exceldataworkbook/) osztály áll. Ez az osztály lehetővé teszi egy Excel munkafüzet betöltését helyi fájlból vagy streame‑ből. Betöltés után több overloadot biztosít a [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/hu/python-java/aspose.slides/exceldataworkbook/#getCell) metódushoz, amelyet a cellák pozíciója (pl. sor‑ és oszlopindexek vagy név szerint definiált tartományok) alapján történő lekérdezésére használhat.

A [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/hu/python-java/aspose.slides/exceldataworkbook/#getCell) minden hívása egy [ExcelDataCell](https://reference.aspose.com/slides/hu/python-java/aspose.slides/exceldatacell/) objektumot ad vissza. Ez az objektum egyetlen cellát képvisel az Excel munkafüzetben, és egyszerű, intuitív módon biztosítja a cella értékének elérését.

#### **Excel-diagram importálása**

A funkcionalitás bővítésének következő lépése a [ExcelWorkbookImporter](https://reference.aspose.com/slides/hu/python-java/aspose.slides/excelworkbookimporter/) osztály. Ez a segédosztály lehetővé teszi tartalom importálását egy Excel munkafüzetről a prezentációba. Több overloadot tartalmaz a [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) metódus, amely segít a kiválasztott diagram lekérésében a megadott Excel munkafüzetről, és annak a megadott koordinátákon a megadott alakzatgyűjtemény végére történő hozzáadásában.

#### **Excel-tábla importálása**

Az [ExcelWorkbookImporter](https://reference.aspose.com/slides/hu/python-java/aspose.slides/excelworkbookimporter/) osztály emellett több overloadot tartalmaz a [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook) metódushoz. Ezek a metódusok lehetővé teszik egy megadott cellatartomány importálását egy megadott munkalapról, és táblaként való hozzáadását a megadott alakzatgyűjtemény végére a megadott koordinátákon.

Röviden, ez egy könnyű és egyszerű API az Excel adatok olvasásához — pontosan azt, amire sok fejlesztőnek szüksége van anélkül, hogy egy komplett táblázatkezelő könyvtár súlya alatt kellene dolgozni.

## **Kódoljunk**

### **Levélkör forgatókönyv példa**

A következő példában egyszerű levélkör forgatókönyvet valósítunk meg, több prezentáció generálásával egy Excel munkafüzetben tárolt adatok alapján.

A kezdéshez két dologra van szükségünk:

1. Egy adatokat tartalmazó Excel munkafüzet

![Excel data example](example1_image0.png)

2. Egy PowerPoint prezentációs sablon

![PowerPoint template example](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Töltsd be az Excel munkafüzetet alkalmazotti adatokkal.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Töltsd be a prezentáció sablont.
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # Iterálj végig az Excel sorokon (kivéve a 0. sor fejléce).
    for row_index in range(1, 5):

        # Készíts egy prezentációt minden egyes alkalmazotti rekordhoz.
        employee_presentation = Presentation()

        try:
            # Távolítsd el az alapértelmezett üres diát.
            employee_presentation.getSlides().removeAt(0)

            # Klónozd a sablon diát a prezentációba.
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # Szerezz be bekezdéseket a cél alakzatról (feltételezve, hogy az 1-es indexű alakzatot használják).
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # Cseréld le a helyőrzőket Excel adataival.
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # Mentsd el a személyre szabott prezentációt egy külön fájlba.
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![Result](example1_image2.png)

### **Excel tábla példa**

A második példában egyszerűen másoljuk az adatokat egy Excel táblából, és egy vizuálisan vonzóbb formában jelenítjük meg egy PowerPoint dián.

Ebben a példában újra felhasználjuk az első példában szereplő ugyanazt az Excel munkafüzetet, amely egy egyszerű alkalmazotti táblát tartalmaz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Töltsd be az Excel munkafüzetet, amely az alkalmazotti adatokat tartalmazza.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Hozz létre egy PowerPoint prezentációt.
presentation = Presentation()

try:
    # Adj hozzá egy táblázat alakzatot az első diára.
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # Töltsd fel a PowerPoint táblázatot az Excel munkafüzet adataival.
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # Mentsd el a kapott prezentációt egy fájlba.
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example2_image0.png)

### **Excel-diagram importálása példa**

Ebben a példában a korábbi példában használt Excel munkafüzet első munkalapjáról importálunk egy diagramot. A diagram a végső prezentációban külső munkafüzethez lesz linkelve.

Először egy kördiagramot adunk hozzá az Excel munkafüzethez az alkalmazotti tábla alapján.

![Excel Chart example](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Hozz létre egy PowerPoint prezentációt.
presentation = Presentation()
try:
    # Szerezd meg az első dia alakzatgyűjteményét.
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # Importáld a "Chart 1" nevű diagramot a munkafüzet első lapjáról, és add hozzá az alakzatgyűjteményhez.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Mentsd el a kapott prezentációt egy fájlba.
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example3_image1.png)

### **Minden Excel-diagram importálása példa**

Képzeljük el, hogy van egy diagramokkal teli Excel munkafüzet, és mindet importálni kell egy prezentációba. Minden diagramot egy új diára kell helyezni.

A következő kód végigiterál az összes munkalapon a forrás Excel fájlban, kinyeri a diagramokat minden munkalapról, és egy üres diaelrendezés használatával minden diagramot egy külön diára helyez. A végső prezentációban csak a diagram adatai lesznek beágyazva, nem az egész munkafüzet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# Töltsd be az Excel munkafüzetet, amely az alkalmazotti adatokat tartalmazza.
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Hozz létre egy PowerPoint prezentációt.
presentation = Presentation()
try:
    # Szerezd meg az üres diaelrendezést.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # Távolítsd el az alapértelmezett diát, hogy az eredmény minden diagramhoz egy diát tartalmazzon.
    presentation.getSlides().removeAt(0)

    # Szerezd meg az Excel munkafüzetben található összes munkalap nevét.
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # Szerezz be egy leképezést, amely a diagram indexeket a munkalap diagram neveire képezi le.
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # Adj hozzá egy diát az üres elrendezés használatával.
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # Importáld a megadott diagramot az Excel munkafüzetről a dia alakzatgyűjteményébe.
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # Mentsd el a kapott prezentációt egy fájlba.
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Excel-tábla importálása példa**

Ebben a példában egy formázott táblát importálunk egy Excel munkalapról közvetlenül egy PowerPoint prezentációba.

A forrás Excel munkalap egy formázott táblát tartalmaz alkalmazotti adatokkal:

![Excel Table example](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Hozz létre egy PowerPoint prezentációt.
presentation = Presentation()
try:
    # Szerezd meg az első diát és annak alakzatgyűjteményét.
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # Importáld a táblázatot a munkafüzet első lapjáról, és add hozzá az alakzatgyűjteményhez.
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # Mentsd el a kapott prezentációt egy fájlba.
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example4_image1.png)

## **Összegzés**

Ez a mechanizmus, amely közvetlenül az Aspose.Slides‑ben érhető el, egy helyen egyesíti az Excel adatokkal és prezentációkkal való munkát. Lehetővé teszi, hogy vizuális diagramokkal és Excel táblákban bemutatott adatokkal ellátott diákat hozzunk létre – minden további könyvtár vagy bonyolult integráció nélkül.