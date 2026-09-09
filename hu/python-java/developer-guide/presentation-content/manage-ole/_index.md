---
title: OLE kezelése prezentációkban Python használatával
linktitle: OLE kezelése
type: docs
weight: 40
url: /hu/python-java/manage-ole/
keywords:
- OLE objektum
- Objektumhivatkozás és beágyazás
- OLE hozzáadása
- OLE beágyazása
- objektum hozzáadása
- objektum beágyazása
- fájl hozzáadása
- fájl beágyazása
- kapcsolt objektum
- kapcsolt fájl
- OLE módosítása
- OLE ikon
- OLE cím
- OLE kinyerése
- objektum kinyerése
- fájl kinyerése
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Optimalizálja az OLE objektumok kezelését PowerPoint és OpenDocument fájlokban az Aspose.Slides for Python via Java segítségével. OLE tartalmak beágyazása, frissítése és exportálása zökkenőmentesen."
---
## **Bevezetés**

{{% alert color="info" title="Note" %}}
Az OLE (Object Linking & Embedding) egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatokat és objektumokat egy másik alkalmazásban helyezzük el hivatkozással vagy beágyazással.
{{% /alert %}}

Tekintsen meg egy a MS Excelben létrehozott diagramot. A diagram ezután egy PowerPoint-diára kerül. Ez az Excel-diagram OLE objektumnak tekinthető.

- Egy OLE objektum ikonként jelenhet meg. Ebben az esetben, ha duplán kattint az ikonra, a diagram a társított alkalmazásban (Excel) nyílik meg, vagy felkérik egy alkalmazás kiválasztására az objektum megnyitásához vagy szerkesztéséhez.
- Egy OLE objektum megjelenítheti saját tartalmát, például egy diagram adatait. Ebben az esetben a diagram aktiválódik a PowerPointben, betöltődik a diagram felülete, és a diagram adatait a PowerPointen belül módosíthatja.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/hu/python-java/) lehetővé teszi OLE objektumok beillesztését a diákba OLE objektum keretként ([OleObjectFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/)).

## **OLE objektum keretek hozzáadása a diákhoz**

Feltételezve, hogy már létrehozott egy diagramot a Microsoft Excelben, és azt egy OLE objektum keretként szeretné beágyazni egy diára az Aspose.Slides for Python via Java használatával, ezt az alábbi módon teheti meg:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára a sorszáma alapján.
3. Olvassa be az Excel-fájlt bájt tömbként.
4. Adja hozzá a [OleObjectFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/) keretet a diához, amely tartalmazza a bájt tömböt és az OLE objektum egyéb adatait.
5. Írja ki a módosított prezentációt PPTX fájlként.

Az alábbi példában egy Excel-fájlból származó diagramot adtunk hozzá egy diára OLE objektum keretként az Aspose.Slides for Python via Java használatával. **Megjegyzés** hogy a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleembeddeddatainfo/) konstruktor a második paraméterként egy beágyazható objektum kiterjesztést vár. Ez a kiterjesztés lehetővé teszi, hogy a PowerPoint helyesen értelmezze a fájltípust, és a megfelelő alkalmazást válassza az OLE objektum megnyitásához.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # Az OLE objektum adatainak előkészítése.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Az OLE objektum keret hozzáadása a diára.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kapcsolt OLE objektum keretek hozzáadása**

Az Aspose.Slides for Python via Java lehetővé teszi egy [OleObjectFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/) hozzáadását a fájlra mutató hivatkozással a beágyazott adatok helyett.

Ez a Python kód megmutatja, hogyan adjon hozzá egy [OleObjectFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/) keretet egy kapcsolt Excel-fájllal egy diához:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Egy OLE objektum keret hozzáadása kapcsolt Excel fájllal.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **OLE objektum keretek elérése**

Ha egy OLE objektum már be van ágyazva egy diára, ezt a módot követve könnyedén megtalálhatja vagy elérheti:

1. Töltsön be egy prezentációt a beágyazott OLE objektummal egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példány létrehozásával.
2. Szerezzen referenciát a diára a sorszáma alapján.
3. Hozzáférés a [OleObjectFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/) alakzathoz. A példánkban a korábban létrehozott PPTX‑et használtuk, amelyen az első dián csak egy alakzat található. Ezután ellenőriztük, hogy az objektum egy [OleObjectFrame] volt. Ez volt a kívánt OLE objektum keret, amelyet el akarunk érni.
4. Miután az OLE objektum keret elérve, tetszőleges műveletet végezhet rajta.

Az alábbi példában egy OLE objektum keret (egy beágyazott Excel-diagram) és a fájladatai kerülnek elérésre.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Szerezze meg a beágyazott fájl adatait.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Szerezze meg a beágyazott fájl kiterjesztését.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Kapcsolt OLE objektum keret tulajdonságainak elérése**

Az Aspose.Slides lehetővé teszi a kapcsolt OLE objektum keret tulajdonságainak elérését.

Ez a Python kód megmutatja, hogyan ellenőrizze, hogy egy OLE objektum kapcsolt-e, majd hogyan szerezze meg a kapcsolt fájl elérési útját:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Ellenőrizze, hogy az OLE objektum kapcsolt-e.
        if ole_frame.isObjectLink():
            # Írja ki a kapcsolt fájl teljes elérési útját.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Írja ki a kapcsolt fájl relatív útvonalát, ha van.
            # Csak a PPT prezentációk tartalmazhatják a relatív útvonalat.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **OLE objektum adatainak módosítása**

{{% alert color="info" title="Note" %}}
Ebben a szakaszban az alábbi kódrészlet a [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/) használatát mutatja be.
{{% /alert %}}

Ha egy OLE objektum már be van ágyazva egy diára, ezt a módot követve könnyedén hozzáférhet az objektumhoz és módosíthatja annak adatait:

1. Töltsön be egy prezentációt a beágyazott OLE objektummal egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példány létrehozásával.
2. Szerezzen referenciát a diára a sorszáma alapján.
3. Hozzáférés az OLE objektum keret alakzathoz. A példánkban a korábban létrehozott PPTX‑et használtuk, amelyen az első dián egy alakzat található. Ezután ellenőriztük, hogy az objektum egy [OleObjectFrame] volt. Ez volt a kívánt OLE objektum keret, amelyet el akarunk érni.
4. Miután az OLE objektum keret elérve, tetszőleges műveletet végezhet rajta.
5. Hozzon létre egy [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) objektumot, és érje el az OLE adatokat.
6. Nyissa meg a kívánt [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) lapot, és módosítsa az adatokat.
7. Mentse a frissített [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) objektumot egy adatfolyamba.
8. Módosítsa az OLE objektum adatát az adatfolyamból.

Az alábbi példában egy OLE objektum keret (egy beágyazott Excel-diagram) kerül elérésre, és a fájladatai módosulnak a diagram adatainak frissítése érdekében.

```python
import jpade
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # Olvassa be az OLE objektum adatát Workbook objektumként.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # A munkafüzet adatok módosítása.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # Az OLE keret objektum adatainak módosítása.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Egyéb fájltípusok beágyazása a diákba**

Az Excel-diagramokon felül az Aspose.Slides for Python via Java lehetővé teszi más fájltípusok beágyazását a diákba. Például HTML, PDF és ZIP fájlokat is beilleszthet objektumként. Ha a felhasználó duplán kattint a beillesztett objektumra, az automatikusan megnyílik a megfelelő programban, vagy a felhasználót felszólítják a megfelelő program kiválasztására.

Ez a Python kód megmutatja, hogyan ágyazzon be HTML‑t és ZIP‑et egy diába:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Beágyazott objektumok fájltípusának beállítása**

Prezentációk kezelésekor előfordulhat, hogy régi OLE objektumokat kell újakkal helyettesíteni, vagy egy nem támogatott OLE objektumot kell támogatottá változtatni. Az Aspose.Slides for Python via Java lehetővé teszi a beágyazott objektum fájltípusának beállítását, ami segít frissíteni az OLE keret adatait vagy annak kiterjesztését.

Ez a Python kód megmutatja, hogyan állítsa be egy beágyazott OLE objektum fájltípusát `zip` értékre:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # A fájltípus módosítása ZIP-re.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ikonképek és címek beállítása a beágyazott objektumokhoz**

Miután egy OLE objektum be van ágyazva, automatikusan hozzáadódik egy előnézet, amely egy ikonképből áll. Ez az előnézet az, amit a felhasználók látnak, mielőtt elérnék vagy megnyitnák az OLE objektumot. Ha egy konkrét képet és szöveget szeretne használni az előnézet elemeiként, beállíthatja az ikonképet és a címet az Aspose.Slides for Python via Java segítségével.

Ez a Python kód megmutatja, hogyan állítsa be az ikonképet és a címet egy beágyazott objektumhoz:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Adjon hozzá egy képet a prezentáció erőforrásaihoz.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # Állítson be címet és képet az OLE előnézethez.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Az OLE objektum keret átméretezésének és áthelyezésének megakadályozása**

Miután egy kapcsolt OLE objektumot hozzáadott egy prezentációs diához, a PowerPointben való megnyitáskor megjelenhet egy üzenet, amely a hivatkozások frissítését kéri. Az „Update Links” (Hivatkozások frissítése) gombra kattintva a OLE objektum keret mérete és pozíciója megváltozhat, mivel a PowerPoint frissíti a kapcsolt OLE objektum adatait és az előnézetet. Ahhoz, hogy a PowerPoint ne kérje az objektum adatainak frissítését, állítsa a [setUpdateAutomatic](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) metódust a [OleObjectFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/) osztályon `False` értékre:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Beágyazott fájlok kinyerése**

Az Aspose.Slides for Python via Java lehetővé teszi a diákkba beágyazott OLE objektumként tárolt fájlok kinyerését a következő módon:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt, amely tartalmazza a kinyerni kívánt OLE objektumokat.
2. Járja végig a prezentáció összes alakzatát, és érje el a [OleObjectFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/) alakzatokat.
3. Olvassa ki a beágyazott fájlok adatait az OLE objektum keretekből, és írja őket lemezre.

Ez a Python kód megmutatja, hogyan nyerjen ki egy diára beágyazott fájlokat OLE objektumként:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **GYIK**

**Megjelenik-e az OLE tartalom a diák PDF‑re vagy képre exportálásakor?**  
A dián látható elem kerül renderelésre – az ikon/helyettesítő kép (előnézet). Az „élő” OLE tartalom nem hajtódik végre a renderelés során. Szükség esetén állítson be saját előnézeti képet a kívánt megjelenés biztosításához az exportált PDF‑ben.

**Hogyan zárolhatok egy OLE objektumot a dián, hogy a felhasználók ne mozgathassák vagy szerkeszthessék PowerPointban?**  
Zárolja az alakzatot: az Aspose.Slides [alakzat‑szintű zárolásokat]( /slides/hu/python-java/applying-protection-to-presentation/) biztosít. Ez nem titkosítás, de hatékonyan megakadályozza a véletlen szerkesztéseket és áthelyezéseket.

**Miért „ugrik” vagy változik mérete egy kapcsolt Excel objektum, amikor megnyitom a prezentációt?**  
A PowerPoint frissítheti a kapcsolt OLE előnézetét. A stabil megjelenés érdekében kövesse a [Működő megoldást a munkalap átméretezésére](/slides/hu/python-java/working-solution-for-worksheet-resizing/) útmutatót – vagy illessze a keretet a tartományra, vagy méretezze a tartományt egy rögzített kerethez, és állítson be megfelelő helyettesítő képet.

**Megmaradnak-e a kapcsolt OLE objektumok relatív útvonalai a PPTX formátumban?**  
A PPTX formátumban a „relatív útvonal” információ nem érhető el – csak a teljes útvonal tárolódik. Relatív útvonalak a régebbi PPT formátumban találhatók. A hordozhatóság érdekében használjon megbízható abszolút útvonalakat, elérhető URI‑kat vagy beágyazást.