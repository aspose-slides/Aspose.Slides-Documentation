---
title: OLE kezelése prezentációkban Python segítségével
linktitle: OLE kezelése
type: docs
weight: 40
url: /hu/python-java/manage-ole/
keywords:
- OLE objektum
- Objektum linkelés és beágyazás
- OLE hozzáadása
- OLE beágyazása
- objektum hozzáadása
- objektum beágyazása
- fájl hozzáadása
- fájl beágyazása
- linkelt objektum
- linkelt fájl
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
description: "Optimalizálja az OLE objektumkezelést PowerPoint és OpenDocument fájlokban az Aspose.Slides for Python via Java segítségével. Ágyazzon be, frissítsen és exportáljon OLE tartalmat zökkenőmentesen."
---
## **Bevezetés**

{{% alert color="info" title="Megjegyzés" %}}

Az OLE (Object Linking & Embedding) egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatokat és objektumokat egy másik alkalmazásba helyezzük linkeléssel vagy beágyazással.

{{% /alert %}}

Vegyük például egy MS Excelben létrehozott diagramot. A diagramot ezután egy PowerPoint‑diára helyezzük. Ez az Excel‑diagram OLE objektumnak tekinthető.

- Egy OLE objektum ikonként jelenhet meg. Ebben az esetben, ha duplán kattintunk az ikonra, a diagram a hozzárendelt alkalmazásban (Excel) nyílik meg, vagy felkérik, hogy válasszon egy alkalmazást az objektum megnyitásához vagy szerkesztéséhez.
- Egy OLE objektum megjelenítheti a tényleges tartalmát, például egy diagram adatait. Ebben az esetben a diagram a PowerPoint‑ban aktiválódik, a diagram felülete betöltődik, és a PowerPoint‑on belül módosíthatja a diagram adatait.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/hu/python-java/) lehetővé teszi OLE objektumok beszúrását a diákba OLE objektumkeretként ([OleObjectFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/)).

## **OLE objektumkeretek hozzáadása a diákhoz**

Feltételezve, hogy már létrehozott egy diagramot a Microsoft Excelben, és azt OLE objektumkeretként szeretné beágyazni egy diára az Aspose.Slides for Python via Java segítségével, ezt a következőképpen teheti meg:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezze meg a dia referencia‑indexét.
1. Olvassa be az Excel‑fájlt bájt‑tömbként.
1. Adja hozzá a [OleObjectFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/) elemet a diához a bájt‑tömbbel és az OLE objektum egyéb információival.
1. Írja ki a módosított prezentációt PPTX‑fájlként.

Az alábbi példában egy Excel‑fájlból származó diagramot adtunk hozzá egy diához OLE objektumkeretként az Aspose.Slides for Python via Java használatával. **Megjegyzés** hogy a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleembeddeddatainfo/) konstruktor második paraméterként egy beágyazható objektum‑kiterjesztést vár. Ez a kiterjesztés teszi lehetővé a PowerPoint számára, hogy helyesen értelmezze a fájltípust, és kiválassza a megfelelő alkalmazást az OLE objektum megnyitásához.

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

### **Linkelt OLE objektumkeretek hozzáadása**

Az Aspose.Slides for Python via Java lehetővé teszi egy [OleObjectFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/) hozzáadását anélkül, hogy beágyazná az adatokat, csak a fájlra mutató hivatkozást adva meg.

Ez a Python‑kód megmutatja, hogyan adjon egy [OleObjectFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/) elemet egy linkelt Excel‑fájllal a diára:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Adjon hozzá egy OLE objektumkeretet egy linkelt Excel fájllal.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **OLE objektumkeretek elérése**

Ha egy OLE objektum már be van ágyazva egy diára, könnyen megtalálhatja vagy elérheti a következő módon:

1. Töltsön be egy prezentációt a beágyazott OLE objektummal úgy, hogy létrehoz egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg a dia referenciáját az indexe alapján.
3. Érje el a [OleObjectFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/) alakzatot. A példánkban a korábban létrehozott PPTX‑et használtuk, amelyen az első dián csak egy alakzat van. Ezután ellenőriztük, hogy az objektum egy [OleObjectFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/). Ez volt a kívánt OLE objektumkeret, amelyhez hozzáfértünk.
4. Miután elérte az OLE objektumkeretet, bármilyen műveletet végrehajthat rajta.

Az alábbi példában egy OLE objektumkeret (egy Excel‑diagramobjektum, amely egy diára van beágyazva) és a fájladatai kerülnek elérésre.

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

### **Linkelt OLE objektumkeret tulajdonságainak elérése**

Az Aspose.Slides lehetővé teszi a linkelt OLE objektumkeret tulajdonságainak elérését.

Ez a Python‑kód megmutatja, hogyan ellenőrizze, hogy egy OLE objektum linkelt‑e, majd hogyan nyerje ki a linkelt fájl elérési útját:

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

        # Ellenőrizze, hogy az OLE objektum linkelt-e.
        if ole_frame.isObjectLink():
            # Írja ki a linkelt fájl teljes útvonalát.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Írja ki a linkelt fájl relatív útvonalát, ha létezik.
            # Csak a PPT prezentációk tartalmazhatnak relatív útvonalat.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **OLE objektum adatának módosítása**

{{% alert color="info" title="Megjegyzés" %}}

Ebben a szakaszban az alábbi kódrészlet a [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/) használatával készül.

{{% /alert %}}

Ha egy OLE objektum már be van ágyazva egy diára, könnyen hozzáférhet az objektumhoz, és a következő módon módosíthatja annak adatait:

1. Töltsön be egy prezentációt a beágyazott OLE objektummal úgy, hogy létrehoz egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg a dia referenciáját az indexe alapján.
3. Érje el az OLE objektumkeret alakzatot. A példánkban a korábban létrehozott PPTX‑et használtuk, amelyen az első dián egy alakzat van. Ezután ellenőriztük, hogy az objektum egy [OleObjectFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/). Ez volt a kívánt OLE objektumkeret, amelyhez hozzáfértünk.
4. Miután elérte az OLE objektumkeretet, bármilyen műveletet végrehajthat rajta.
5. Hozzon létre egy [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) objektumot, és érje el az OLE adatokat.
6. Érje el a kívánt [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) lapot, és módosítsa az adatokat.
7. Mentse el a frissített [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) objektumot egy adatfolyamba.
8. Cserélje le az OLE objektum adatait a adatfolyamból.

Az alábbi példában egy OLE objektumkeret (egy Excel‑diagramobjektum, amely egy diára van beágyazva) kerül elérésre, és a fájladatai módosulnak a diagramadatok frissítéséhez.

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

        # Olvassa be az OLE objektum adatait Workbook objektumként.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # Módosítsa a Workbook adatait.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # Módosítsa az OLE keret objektum adatait.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Egyéb fájltípusok beágyazása a diákba**

Az Excel‑diagramokon túl az Aspose.Slides for Python via Java lehetővé teszi más fájltípusok, például HTML, PDF és ZIP fájlok beágyazását a diákba objektumként. Amikor a felhasználó duplán kattint a beágyazott objektumra, az automatikusan megnyílik a megfelelő programban, vagy a felhasználót felkérik, hogy válasszon egy alkalmas programot a megnyitáshoz.

Ez a Python‑kód megmutatja, hogyan ágyazzon be HTML‑t és ZIP‑et egy diára:

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

Prezentációk dolgozása során előfordulhat, hogy régi OLE objektumokat újakkal kell helyettesíteni, vagy egy nem támogatott OLE objektumot támogatottal. Az Aspose.Slides for Python via Java lehetővé teszi a beágyazott objektum fájltípusának beállítását, így frissítheti az OLE keret adatait vagy annak kiterjesztését.

Ez a Python‑kód megmutatja, hogyan állítható be a beágyazott OLE objektum fájltípusa `zip`‑re:

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

    # A fájltípust ZIP-re változtatja.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ikonképek és címek beállítása a beágyazott objektumokhoz**

Miután beágyazott egy OLE objektumot, egy előnézet, amely ikonképet tartalmaz, automatikusan hozzáadódik. Ez az előnézet az, amit a felhasználók látnak, mielőtt hozzáférnének vagy megnyitnák az OLE objektumot. Ha konkrét képet és szöveget szeretne használni az előnézet elemeiként, a Aspose.Slides for Python via Java segítségével beállíthatja az ikonképet és a címet.

Ez a Python‑kód megmutatja, hogyan állítható be az ikonkép és a cím egy beágyazott objektumhoz:

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

    # Kép hozzáadása a prezentáció erőforrásaihoz.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # Állítsa be a címet és a képet az OLE előnézethez.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Az OLE objektumkeret átméretezésének és áthelyezésének megakadályozása**

Miután egy linkelt OLE objektumot hozzáadott egy prezentációs diához, a PowerPoint megnyitásakor előfordulhat, hogy egy üzenet kéri a hivatkozások frissítését. Az „Update Links” gombra kattintás megváltoztathatja az OLE objektumkeret méretét és pozícióját, mert a PowerPoint frissíti az adatokat a linkelt OLE objektumból, és újrarajzolja az előnézetet. Ahhoz, hogy a PowerPoint ne kérje az objektum adatainak frissítését, állítsa a [setUpdateAutomatic](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) metódust a [OleObjectFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/) osztályon `False`‑ra:

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

Az Aspose.Slides for Python via Java lehetővé teszi a diákban OLE objektumként beágyazott fájlok kinyerését a következő módon:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt, amely tartalmazza a kinyerni kívánt OLE objektumokat.
2. Járja be a prezentáció összes alakzatát, és érje el a [OleObjectFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/) alakzatokat.
3. Nyissa meg a beágyazott fájlok adatait az OLE objektumkeretekből, és írja ki őket a lemezre.

Ez a Python‑kód megmutatja, hogyan nyerhet ki fájlokat, amelyek OLE objektumként vannak beágyazva egy dián:

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

**Megjelenik-e az OLE tartalom a diák PDF‑/képfájlba exportálásakor?**

A dia látható része kerül renderelésre – az ikon/helyettesítő kép (előnézet). Az „élő” OLE tartalom nem kerül végrehajtásra a renderelés során. Szükség esetén állítson be saját előnézeti képet, hogy a várt megjelenés biztosítva legyen az exportált PDF‑ben.

**Hogyan zárolhatok egy OLE objektumot a dián, hogy a felhasználók ne mozgathassák/szerkeszthessék PowerPoint‑ban?**

Zárolja a formát: az Aspose.Slides biztosít [shape‑szintű zárolásokat](/slides/hu/python-java/applying-protection-to-presentation/). Ez nem titkosítás, de hatékonyan megelőzi a véletlen szerkesztéseket és áthelyezéseket.

**Miért „ugrik” vagy változik a mérete egy linkelt Excel objektumnak, amikor megnyitom a prezentációt?**

A PowerPoint frissítheti a linkelt OLE előnézetét. Stabil megjelenés érdekében kövesse a [Working Solution for Worksheet Resizing](/slides/hu/python-java/working-solution-for-worksheet-resizing/) útmutatót – vagy igazítsa a keretet a tartományhoz, vagy méretezze a tartományt egy rögzített keretre, és állítson be megfelelő helyettesítő képet.

**Megmaradnak‑e a relatív útvonalak a linkelt OLE objektumok esetén a PPTX formátumban?**

A PPTX‑ben a „relatív útvonal” információ nem érhető el – csak a teljes útvonal. A relatív útvonalak a régebbi PPT formátumban vannak. Hordozhatóság érdekében válasszon megbízható abszolút útvonalakat/hozzáférhető URI‑kat vagy ágyazzon be.