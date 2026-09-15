---
title: Működő megoldás a diagram átméretezésre PPTX-ben
type: docs
weight: 40
url: /hu/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagram átméretezés
- Excel diagram
- OLE objektum
- diagram beágyazása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Javítsa a váratlan diagram átméretezést PPTX-ben, amikor beágyazott Excel OLE objektumokat használ az Aspose.Slides for Python via Java segítségével. Ismerjen meg két módszert kóddal, amelyekkel a méreteket konzisztens módon tartja."
---
## **Háttér**

Megfigyelték, hogy az Aspose komponenseken keresztül PowerPoint‑prezentációba OLE objektumként beágyazott Excel‑diagramok az első aktiválásuk után egy meghatározatlan méretarányra vannak átméretezve. Ez a viselkedés észrevehető vizuális különbséget eredményez a prezentációban a diagram aktiválás előtti és utáni állapota között. Az Aspose csapata részletesen vizsgálta a problémát, és megtalálta a megoldást. Ez a cikk leírja a probléma okait és a megfelelő javítást.

Az [előző cikk](/slides/hu/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)‑ben bemutattuk, hogyan hozhatunk létre egy Excel‑diagramot az Aspose.Cells for Python via Java segítségével, és ágyazzuk be egy PowerPoint‑prezentációba az Aspose.Slides for Python via Java‑val. A [objektum előnézeti probléma](/slides/hu/python-java/object-preview-issue-when-adding-oleobjectframe/) megoldásaként a diagram képét rendeltük a diagram OLE objektumkeretéhez. A kimeneti prezentációban, ha duplán kattintunk a diagram képét megjelenítő OLE objektumkeretre, az Excel‑diagram aktiválódik. A végfelhasználó a mögöttes Excel‑munka könyvben tetszőleges módosítást végezhet, majd a aktivált munkafüzeten kívülre kattintva visszatér a megfelelő diára. Az OLE objektumkeret mérete megváltozik, amikor a felhasználó visszatér a diára, és az átméretezés mértéke a OLE objektumkeret és a beágyazott Excel‑munka könyv eredeti méreteitől függ.

## **Méretezés oka**

Mivel a Excel‑munka könyvnek saját ablakmérete van, az első aktiválásakor igyekszik megtartani eredeti méretét. Az OLE objektumkeret azonban saját mérettel rendelkezik. A Microsoft szerint, amikor a Excel‑munka könyv aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, és a beágyazási folyamat részeként a helyes arányokat tartják fenn. Az Excel‑ablakméret és az OLE objektumkeret mérete vagy pozíciója közötti különbségek miatt történik az átméretezés.

## **Működő megoldás**

Két lehetséges forgatókönyv van a PowerPoint‑prezentációk létrehozására az Aspose.Slides for Python via Java‑val.

**Forgatókönyv 1:** Prezentáció létrehozása egy meglévő sablon alapján.

**Forgatókönyv 2:** Prezentáció létrehozása alapjából.

Az itt bemutatott megoldás mindkét forgatókönyvre alkalmazható. Minden megoldási megközelítés alapja ugyanaz: **a beágyazott OLE objektum ablakméretének meg kell egyeznie a PowerPoint‑dia OLE objektumkeretével**. Most a két megközelítést ismertetjük.

## **Első megközelítés**

Ebben a megközelítésben megtanuljuk, hogyan állítható be a beágyazott Excel‑munka könyv ablakmérete úgy, hogy az egyezzen a PowerPoint‑dia OLE objektumkeretének méretével.

**Forgatókönyv 1**

Tegyük fel, hogy definiáltunk egy sablont, és annak alapján szeretnénk prezentációkat létrehozni. Feltételezzük, hogy a sablon 2. indexű alakzatában szeretnénk egy OLE‑keretet elhelyezni, amely beágyazott Excel‑munka könyvet tartalmaz. Ebben a forgatókönyvben az OLE objektumkeret mérete előre meghatározott – megegyezik a sablon 2. indexű alakzatának méretével. Csak annyit kell tennünk, hogy a munka könyv ablakméretét egyenlővé tesszük az alakzat méretével. Az alábbi kódrészlet ezt a célt szolgálja:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Töltsük be a diagramot tartalmazó Excel munkafüzetet.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Állítsuk be a munkafüzet ablakméretét hüvelykben (a PowerPoint 72 pontot használ hüvelykenként).
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # Mentsük a munkafüzetet egy memóriastream-be.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Hozzunk létre egy OLE objektumkeretet a beágyazott Excel adatával.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Forgatókönyv 2**

Tegyük fel, hogy alapjavól szeretnénk egy prezentációt létrehozni, és tetszőleges méretű OLE objektumkeretet szeretnénk egy beágyazott Excel‑munka könyvvel. Az alábbi kódrészletben egy 4 hüvelykes magasságú és 9,5 hüvelykes szélességű OLE objektumkeretet hozunk létre a diáron x = 0,5 hüvelyk és y = 1 hüvelyk pozícióban. Ezután beállítjuk az Excel‑munka könyv ablakát ugyanolyan méretűre – 4 hüvelyk magasságra és 9,5 hüvelyk szélességre.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Töltsük be a diagramot tartalmazó Excel munkafüzetet.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 hüvelyk (4 * 72).
    desired_width = 684  # 9,5 hüvelyk (9,5 * 72).

    # Határozzuk meg a diagram méretét egy ablakban.
    chart.setSizeWithWindow(True)

    # Állítsuk be a munkafüzet ablakméretét hüvelykben (a PowerPoint 72 pontot használ hüvelykenként).
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # Mentsük a munkafüzetet egy memóriastream-be.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Hozzunk létre egy OLE objektumkeretet a beágyazott Excel adatokkal.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Második megközelítés**

Ebben a megközelítésben megtanuljuk, hogyan állítható be a diagram mérete a beágyazott Excel‑munka könyvben úgy, hogy az egyezzen a PowerPoint‑dia OLE objektumkeretének méretével. Ez a megközelítés akkor hasznos, ha a diagram mérete előre ismert, és soha nem változik.

**Forgatókönyv 1**

Tegyük fel, hogy definiáltunk egy sablont, és annak alapján szeretnénk prezentációkat létrehozni. Feltételezzük, hogy a sablon 2. indexű alakzatában egy OLE keretet szeretnénk elhelyezni, amely beágyazott Excel‑munka könyvet tartalmaz. Ebben a forgatókönyvben az OLE keret mérete előre meghatározott – megegyezik a sablon 2. indexű alakzatának méretével. Csak annyit kell tennünk, hogy a diagram méretét a munka könyvben egyenlővé tesszük az alakzat méretével. Az alábbi kódrészlet ezt a célt szolgálja:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Töltsük be a diagramot tartalmazó Excel munkafüzetet.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Határozzuk meg a diagram méretét ablak nélkül.
    chart.setSizeWithWindow(False)

    # Állítsuk be a diagram méretét pixelekben (az Excel 96 pixelt használ hüvelykenként).
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # Határozzuk meg a diagram nyomtatási méretét.
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # Mentsük a munkafüzetet egy memóriastream-be.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Hozzunk létre egy OLE objektumkeretet a beágyazott Excel adatokkal.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Forgatókönyv 2**:

Tegyük fel, hogy alapjavól szeretnénk egy prezentációt létrehozni, és tetszőleges méretű OLE objektumkeretet szeretnénk egy beágyazott Excel‑munka könyvvel. Az alábbi kódrészletben egy 4 hüvelykes magasságú és 9,5 hüvelykes szélességű OLE objektumkeretet hozunk létre a diáron x = 0,5 hüvelyk és y = 1 hüvelyk pozícióban. Emellett a diagram méretét is ugyanolyanra állítjuk: 4 hüvelyk magasságra és 9,5 hüvelyk szélességre.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Töltsük be a diagramot tartalmazó Excel munkafüzetet.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 hüvelyk (4 * 72).
    desired_width = 684  # 9,5 hüvelyk (9,5 * 72).

    # Határozzuk meg a diagram méretét ablak nélkül.
    chart.setSizeWithWindow(False)

    # Állítsuk be a diagram méretét pixelekben (az Excel 96 pixelt használ hüvelykenként).
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # Mentsük a munkafüzetet egy memóriastream-be.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Hozzunk létre egy OLE objektumkeretet a beágyazott Excel adatokkal.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Következtetés**

Két megközelítés létezik a diagram‑á tméretezési probléma megoldására. A választás a követelményektől és az adott felhasználási esettől függ. Mindkét megközelítés ugyanúgy működik, függetlenül attól, hogy a prezentáció sablonból vagy alapjavól készült. Emellett nincs korlátozás az OLE objektumkeret méretére ebben a megoldásban.

## **GYIK**

**Miért változik a beágyazott Excel‑diagram mérete, miután aktiváltam PowerPoint‑ban?**  
Ez azért történik, mert az Excel az első aktiváláskor megpróbálja visszaállítani az eredeti ablakméretét, míg a PowerPoint‑ban az OLE objektumkeretnek saját mérete van. A PowerPoint és az Excel egyeztetik a méretet az arányok megtartása érdekében, ami átméretezést okozhat.

**Lehetséges-e teljesen megakadályozni ezt az átméretezési problémát?**  
Igen. Ha a beágyazás előtt a Excel‑munka könyv ablakméretét vagy a diagram méretét megegyeztetjük az OLE objektumkeret méretével, a diagram mérete állandó marad.

**Melyik megközelítést válasszam, az ablakméret beállítását vagy a diagramméret beállítását?**  
Használja a **Megközelítés 1 (ablakméret)**‑et, ha szeretné megőrizni a munka könyv arányait, és esetleg később engedélyezni a méretezést.  
Használja a **Megközelítés 2 (diagramméret)**‑et, ha a diagram méretei rögzítettek és a beágyazás után nem változnak.

**Működnek-e ezek a módszerek sablon‑alapú és új prezentációk esetén egyaránt?**  
Igen. Mindkét megközelítés ugyanúgy működik sablonból és alapjavól létrehozott prezentációk esetén.

**Van korlátozás az OLE objektumkeret méretére?**  
Nincs. Az OLE keretet bármilyen méretre beállíthatja, amíg az arányosan skálázódik a munka könyv vagy a diagram méretéhez.

**Használhatók-e ezek a módszerek más táblázatkezelő programokban készült diagramokkal?**  
A példák az Aspose.Cells‑tel létrehozott Excel‑diagramokra vonatkoznak, de az elv ugyanúgy alkalmazható más OLE‑kompatibilis táblázatkezelő programokra, ha azok támogatják a hasonló méretezési beállításokat.

## **Kapcsolódó szakaszok**

- [Excel‑diagramok létrehozása és OLE objektumként beágyazása prezentációkba](/slides/hu/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)