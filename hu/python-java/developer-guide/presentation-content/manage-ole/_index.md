---
title: OLE kezelése prezentációkban Python segítségével
linktitle: OLE kezelése
type: docs
weight: 40
url: /hu/python-java/manage-ole/
keywords:
- OLE objektum
- Objektum hivatkozás és beágyazás
- OLE hozzáadása
- OLE beágyazása
- objektum hozzáadása
- objektum beágyazása
- fájl hozzáadása
- fájl beágyazása
- hivatkozott objektum
- hivatkozott fájl
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
description: "Optimalizálja az OLE objektumok kezelését PowerPoint és OpenDocument fájlokban az Aspose.Slides for Python via Java segítségével. Beágyazás, frissítés és OLE tartalom exportálása zökkenőmentesen."
---
## **Bevezetés**

{{% alert color="info" title="Note" %}}

Az OLE (Object Linking & Embedding) egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatokat és objektumokat egy másik alkalmazásba helyezzük hivatkozás vagy beágyazás révén.

{{% /alert %}}

Vegyünk egy diagramot, amelyet a MS Excelben hoztunk létre. A diagramot ezután egy PowerPoint-diára helyezzük. Ez az Excel-diagram OLE-objektumnak tekinthető.

- Az OLE-objektum megjelenhet ikonként. Ebben az esetben, ha duplán kattintunk az ikonra, a diagram a kapcsolódó alkalmazásban (Excel) nyílik meg, vagy felkérik a felhasználót, hogy válasszon egy alkalmazást az objektum megnyitásához vagy szerkesztéséhez.
- Az OLE-objektum megjelenítheti a tényleges tartalmát, például egy diagram tartalmát. Ebben az esetben a diagram aktiválódik a PowerPointban, a diagram felület betöltődik, és a felhasználó a PowerPointon belül módosíthatja a diagram adatait.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/python-java/) lehetővé teszi OLE-objektumok beszúrását a diákba OLE-objektumkeretekként ([OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)).

## **OLE-objektumkeretek hozzáadása a diákhoz**

Tegyük fel, hogy már létrehoztunk egy diagramot a Microsoft Excelben, és be szeretnénk ágyazni egy diára OLE-objektumkeretként az Aspose.Slides for Python via Java használatával; ezt a következőképpen tehetjük meg:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy dia indexe alapján.
1. Olvassa be az Excel-fájlt bájt tömbként.
1. Adja hozzá a [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) keretet a diához, amely tartalmazza a bájt tömböt és egyéb információkat az OLE-objektumról.
1. Írja ki a módosított prezentációt PPTX fájlként.

Az alábbi példában egy Excel-fájlból származó diagramot adtunk hozzá a diához OLE-objektumkeretként az Aspose.Slides for Python via Java használatával.
**Megjegyzés** hogy a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/) konstruktor a beágyazható objektum kiterjesztését veszi a második paraméterként. Ez a kiterjesztés lehetővé teszi a PowerPoint számára, hogy helyesen értelmezze a fájltípust és a megfelelő alkalmazást válassza az OLE-objektum megnyitásához.

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

    # Készítse elő az OLE objektum adatait.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Adja hozzá az OLE objektumkeretet a diához.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Hivatkozott OLE-objektumkeretek hozzáadása**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy egy [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) keretet egy fájlra mutató hivatkozással adjunk hozzá a beágyazott adatok helyett.

Ez a Python kód megmutatja, hogyan adjon egy [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) keretet egy hivatkozott Excel-fájlhoz egy dián:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Adjon hozzá egy OLE-objektumkeretet egy hivatkozott Excel-fájllal.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **OLE-objektumkeretek elérése**

Ha egy OLE-objektum már be van ágyazva egy diára, ezt a módot követve könnyen megtalálhatja vagy elérheti:

1. Töltsön be egy prezentációt, amely a beágyazott OLE-objektumot tartalmazza, a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztály egy példányának létrehozásával.
2. Szerezzen referenciát a dia indexe alapján.
3. Hozzáférés a [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) alakzathoz.
   A példánkban a korábban létrehozott PPTX-et használtuk, amelynek az első dián csak egy alakzata van. Ezután ellenőriztük, hogy az objektum egy [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/). Ez volt a kívánt OLE-objektumkeret, amelyhez hozzáférni kívántunk.
4. Miután elérte az OLE-objektumkeretet, tetszőleges műveletet végezhet rajta.

Az alábbi példában egy OLE-objektumkeret (egy beágyazott Excel-diagram) és a fájladatai érhetők el.

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

        # A beágyazott fájl adatait kérjük le.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # A beágyazott fájl kiterjesztését kérjük le.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Hivatkozott OLE-objektumkeret tulajdonságainak elérése**

Az Aspose.Slides lehetővé teszi a hivatkozott OLE-objektumkeret tulajdonságainak elérését.

Ez a Python kód megmutatja, hogyan ellenőrizze, hogy egy OLE-objektum hivatkozott-e, majd hogyan szerezze meg a hivatkozott fájl útvonalát:

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Ellenőrizze, hogy az OLE objektum hivatkozott-e.
        if ole_frame.isObjectLink():
            # Írja ki a hivatkozott fájl teljes útvonalát.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Írja ki a hivatkozott fájl relatív útvonalát, ha létezik.
            # Csak a PPT prezentációk tartalmazhatják a relatív útvonalat.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **OLE-objektumadatok módosítása**

{{% alert color="info" title="Note" %}}

Ebben a szakaszban az alábbi példakód a [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/) használatával készült.

{{% /alert %}}

Ha egy OLE-objektum már be van ágyazva egy diára, ezt a módot követve könnyen elérheti és módosíthatja annak adatait:

1. Töltsön be egy prezentációt, amely a beágyazott OLE-objektumot tartalmazza, a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztály egy példányának létrehozásával.
2. Szerezzen referenciát a dia indexe alapján.
3. Hozzáférés az OLE-objektumkeret alakzathoz.
   Példánkban a korábban létrehozott PPTX-et használtuk, amelynek az első dián egy alakzata van. Ezután ellenőriztük, hogy az objektum egy [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/). Ez volt a kívánt OLE-objektumkeret, amelyhez hozzáférni kívántunk.
4. Miután elérte az OLE-objektumkeretet, tetszőleges műveletet végezhet rajta.
5. Hozzon létre egy [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) objektumot, és érje el az OLE-adatokat.
6. Hozzáférés a kívánt [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) munkalaphoz, és módosítsa az adatokat.
7. Mentse a frissített [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) objektumot egy adatfolyamba.
8. A folyamatról változtassa meg az OLE-objektum adatait.

Az alábbi példában egy OLE-objektumkeret (egy beágyazott Excel-diagram) elérhető, és a fájladatai módosításra kerülnek a diagram adatainak frissítéséhez.

```python
import jpype
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

        # Módosítsa a munkafüzet adatait.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # Módosítsa az OLE keret objektum adatát.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Más fájltípusok beágyazása a diákba**

Az Excel-diagramok mellett az Aspose.Slides for Python via Java lehetővé teszi más típusú fájlok beágyazását is a diákba. Például HTML, PDF és ZIP fájlokat ágyazhat be objektumként. Amikor a felhasználó duplán kattint a beillesztett objektumra, az automatikusan megnyílik a megfelelő programban, vagy felkérik a felhasználót, hogy válasszon egy megfelelő programot a megnyitáshoz.

Ez a Python kód megmutatja, hogyan ágyazzon be HTML-t és ZIP-et egy diára:

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

Prezentációk kezelésekor előfordulhat, hogy régi OLE-objektumokat újakkal kell helyettesíteni, vagy egy nem támogatott OLE-objektumot támogatottá kell alakítani. Az Aspose.Slides for Python via Java lehetővé teszi a beágyazott objektum fájltípusának beállítását, amely lehetővé teszi az OLE-keret adatainak vagy kiterjesztésének frissítését.

Ez a Python kód megmutatja, hogyan állítsa be a beágyazott OLE-objektum fájltípusát `zip`-re:

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

    # Változtassa meg a fájltípust ZIP-re.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ikonképek és címek beállítása beágyazott objektumokhoz**

Miután egy OLE-objektum be van ágyazva, automatikusan hozzáadódik egy előnézet, amely egy ikonképet tartalmaz. Ez az előnézet az, amit a felhasználók látnak, mielőtt hozzáférnének vagy megnyitnák az OLE-objektumot. Ha egy adott képet és szöveget szeretne használni az előnézet elemeiként, az Aspose.Slides for Python via Java segítségével beállíthatja az ikonképet és a címet.

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

## **Az OLE-objektumkeret átméretezésének és áthelyezésének megakadályozása**

Miután egy hivatkozott OLE-objektumot ad a diához, a PowerPoint megnyitásakor megjelenhet egy üzenet, amely a hivatkozások frissítését kéri. A "Frissítse a hivatkozásokat" gomb megnyomása megváltoztathatja az OLE-objektumkeret méretét és helyzetét, mivel a PowerPoint frissíti az adatokat a hivatkozott OLE-objektumból és újratölti az előnézetet. Annak érdekében, hogy a PowerPoint ne kérje az objektum adatainak frissítését, hívja meg a [setUpdateAutomatic](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) metódust az [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) osztályon a `False` értékkel:

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

Az Aspose.Slides for Python via Java lehetővé teszi a diákba beágyazott OLE-objektumként tárolt fájlok kinyerését a következő módon:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztály példányt, amely tartalmazza a kinyerni kívánt OLE-objektumokat.
2. Járja be a prezentáció összes alakzatát, és érje el a [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) alakzatokat.
3. Nyessa ki a beágyazott fájlok adatait az OLE-objektumkeretből, és írja le a lemezre.

Ez a Python kód megmutatja, hogyan lehet kinyerni a diára beágyazott OLE-objektumként tárolt fájlokat:

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

**Az OLE-tartalom megjelenik a diák PDF‑ vagy képformátumba exportálásakor?**

A diáron látható tartalom kerül renderelésre – az ikon/helyettesítő kép (előnézet). Az „élő” OLE‑tartalom nem kerül végrehajtásra a renderelés során. Szükség esetén állítson be saját előnézeti képet, hogy az exportált PDF‑ban a várt megjelenést biztosítsa.

A beágyazott fájl PDF‑csatolásként való megőrzéséhez hívja meg a [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) metódust a `True` értékkel. Ez a beállítás alapértelmezés szerint le van tiltva. Példáért és a csatolás ellenőrzéséhez lásd a [Preserve Embedded OLE Files as PDF Attachments](/slides/hu/python-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) oldalt.

**Hogyan zárhatom le egy OLE‑objektumot a dián, hogy a felhasználók ne mozgassák vagy szerkesszék PowerPointban?**

Zárja le az alakzatot: az Aspose.Slides a [shape‑level locks](/slides/hu/python-java/applying-protection-to-presentation/) funkciót biztosítja. Ez nem titkosítás, de hatékonyan megakadályozza a véletlen szerkesztéseket és mozgást.

**Miért „ugrást” vagy méretváltozást tapasztal egy hivatkozott Excel‑objektum, amikor megnyitja a prezentációt?**

A PowerPoint frissítheti a hivatkozott OLE előnézetét. A stabil megjelenés érdekében kövesse a [Working Solution for Worksheet Resizing](/slides/hu/python-java/working-solution-for-worksheet-resizing/) ajánlásait – vagy illessze a keretet a tartományhoz, vagy skálázza a tartományt egy fix keretre, és állítson be megfelelő helyettesítő képet.

**A hivatkozott OLE‑objektumok relatív útvonalai megmaradnak a PPTX formátumban?**

A PPTX‑ben a „relatív útvonal” információ nem érhető el – csak a teljes útvonal. A relatív útvonalak a régebbi PPT formátumban találhatók. A hordozhatóság érdekében használjon megbízható abszolút útvonalakat vagy elérhető URI‑kat, vagy ágyazza be a fájlokat.