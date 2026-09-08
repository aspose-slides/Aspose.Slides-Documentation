---
title: Prezentáció BLOB-ok kezelése Pythonon keresztül Java-val a memóriahatékony használatért
linktitle: BLOB kezelése
type: docs
weight: 10
url: /hu/python-java/manage-blob/
keywords:
  - nagy objektum
  - nagy elem
  - nagy fájl
  - BLOB hozzáadása
  - BLOB exportálása
  - kép hozzáadása BLOB-ként
  - memória csökkentése
  - memória fogyasztás
  - nagy prezentáció
  - ideiglenes fájl
  - PowerPoint
  - OpenDocument
  - prezentáció
  - Python
  - Java
  - Aspose.Slides
description: "BLOB adatok kezelése az Aspose.Slides Pythonon keresztül Java-val, a PowerPoint és OpenDocument fájlműveletek egyszerűsítése érdekében a prezentációk hatékony kezeléséhez."
---
## **Áttekintés**

Az Aspose.Slides BLOB‑alapú kezelést biztosít nagy bináris adatokhoz a prezentációkban, ezáltal segít csökkenteni a memóriahasználatot nagy képek, hang, videó és prezentációs fájlok kezelésekor.

Ez a cikk bemutatja, hogyan használható BLOB‑alapú feldolgozás nagy médiafájlok hozzáadására egy prezentációhoz, nagy médiafájlok exportálására a prezentációból, valamint nagy prezentációk hatékonyabb betöltésére. Továbbá ismerteti, hogyan használhatók ideiglenes fájlok a feldolgozás során, és hogyan változtatható meg azok tárolására szolgáló mappa.

## **A BLOB-ról**

**BLOB** (**Nagy Bináris Objektum**) általában egy nagy elem (fotó, prezentáció, dokumentum vagy média), amely bináris formátumban van tárolva.

Az Aspose.Slides for Python via Java lehetővé teszi a BLOB‑ok használatát objektumoknál úgy, hogy csökkenti a memóriafogyasztást nagy fájlok esetén.

{{% alert color="info" title="Megjegyzés" %}}
A streams-szel való interakció bizonyos korlátainak megkerülése érdekében az Aspose.Slides a stream tartalmát másolhatja. Egy nagy prezentáció stream‑ből való betöltése a prezentáció tartalmának másolásához és lassú betöltéshez vezet. Ezért, ha nagy prezentációt szeretne betölteni, erősen javasoljuk, hogy a prezentáció fájlútvonalát használja, ne a stream‑jét.
{{% /alert %}}

## **BLOB használata a memóriafogyasztás csökkentésére**

### **Nagy fájl hozzáadása BLOB‑on keresztül a prezentációhoz**

[Aspose.Slides](/slides/hu/python-java/) for Python via Java lehetővé teszi nagy fájlok (ebben az esetben egy nagy videófájl) hozzáadását BLOB‑os folyamaton keresztül a memóriafogyasztás csökkentése érdekében.

Ez a Python kód bemutatja, hogyan adjon hozzá egy nagy videófájlt BLOB‑os folyamaton keresztül a prezentációhoz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Új prezentáció létrehozása, amelyhez a videót hozzáadjuk.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # Zárva tartjuk a stream-et, mert nem kívánjuk elérni a videó fájlt.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # A prezentáció mentése alacsony memóriahasználat mellett.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Nagy fájl exportálása BLOB‑on keresztül a prezentációból**

Az Aspose.Slides for Python via Java lehetővé teszi nagy fájlok (ebben az esetben egy hang vagy videó fájl) exportálását BLOB‑os folyamaton keresztül a prezentációkból. Például előfordulhat, hogy egy nagy médiafájlt szeretne kinyerni a prezentációból anélkül, hogy a fájlt betöltené a számítógép memóriájába. A fájl BLOB‑os exportálásával alacsony memóriafogyasztást érhet el.

Ez a Python kód demonstrálja a leírt műveletet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# Zárolja a forrásfájlt a memóriába betöltés helyett.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # Videó adatátvitel pufferen keresztül a memóriahasználat alacsonyan tartásához.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # Használja a stream-et a teljes videó bájt tömbbe betöltése helyett.
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # Szükség esetén alkalmazza ugyanazokat a lépéseket hangfájlokra.
finally:
    presentation.dispose()
```

### **Kép hozzáadása BLOB‑ként a prezentációhoz**

A [ImageCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagecollection/) osztály módszereivel egy nagy képet stream‑ként adhat hozzá, hogy azt BLOB‑ként kezelje.

Ez a Python kód bemutatja, hogyan adjon hozzá egy nagy képet BLOB‑os folyamaton keresztül:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Új prezentáció létrehozása, amelyhez a képet hozzáadjuk.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Zárva tartjuk a stream-et, mert nem kívánjuk elérni a kép fájlt.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Mentés alacsony memóriahasználat mellett.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Memória és nagy prezentációk**

Általában egy nagy prezentáció betöltéséhez a számítógépeknek sok ideiglenes memóriára van szükségük. A prezentáció teljes tartalma bebetöltődik a memóriába, és a fájl (amelyből a prezentáció betöltésre került) már nem használatos.

Vegyük például a large.pptx nevű nagy PowerPoint prezentációt, amely egy 1,5 GB méretű videófájlt tartalmaz. A prezentáció betöltésének standard módszere a következő Python kódban látható:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Ez a módszer azonban körülbelül 1,6 GB ideiglenes memóriát fogyaszt.

### **Nagy prezentáció betöltése BLOB‑ként**

BLOB‑os folyamaton keresztül kevés memória felhasználásával tölthet fel egy nagy prezentációt. Ez a Python kód mutatja be a BLOB‑os betöltés megvalósítását a large.pptx fájlra:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **Az ideiglenes fájlok mappájának módosítása**

Amikor BLOB‑os folyamatot használ, a számítógép ideiglenes fájlokat hoz létre az alapértelmezett ideiglenes fájlok mappájában. Ha szeretné, hogy az ideiglenes fájlok egy másik mappában legyenek tárolva, megváltoztathatja a beállításokat a [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/hu/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) használatával:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="Megjegyzés" %}}
Amikor a [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/hu/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) metódust használja, az Aspose.Slides nem hoz létre automatikusan mappát az ideiglenes fájlok tárolására. A mappát manuálisan kell létrehoznia.
{{% /alert %}}

### **Prezentációs objektumok eldobása a memória felszabadításához**

Nagy prezentációk feldolgozása során biztosítsa, hogy a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példány megfelelően legyen eldobva, így a felhasznált memória felszabadul. Hívja a [Presentation.dispose](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#dispose) metódust a prezentáció használatának befejezése után, hogy felszabadítsa a nem kezelt erőforrásokat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...feldolgozza a prezentációt...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # Erőforrások kifejezett felszabadítása.
    presentation.dispose()
```

## **GYIK**

**Milyen adatokat kezel BLOB‑ként egy Aspose.Slides prezentációban, és melyek a BLOB‑opciók által vezéreltek?**

Nagy bináris objektumok, például képek, hang és videó kezelése BLOB‑ként történik. A teljes prezentációs fájl is BLOB‑kezelést igényel a betöltés vagy mentés során. Ezeket az objektumokat BLOB‑szabályok szabályozzák, amelyek lehetővé teszik a memóriahasználat és az ideiglenes fájlok használatának kezelését.

**Hol konfigurálhatom a BLOB‑kezelési szabályokat a prezentáció betöltésekor?**

Használja a [LoadOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/) és a [BlobManagementOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/blobmanagementoptions/) kombinációját. Itt állíthatja be a BLOB‑memória korlátot, engedélyezheti vagy letilthatja az ideiglenes fájlokat, megadhatja az ideiglenes fájlok gyökérútvonalát, valamint kiválaszthatja a forrászárolás viselkedését.

**A BLOB‑beállítások befolyásolják a teljesítményt, és hogyan egyensúlyozhatok a sebesség és a memória között?**

Igen. A BLOB‑memóriában tartása maximalizálja a sebességet, de növeli a RAM‑használatot; a memóriahatár csökkentése több munkát helyez át ideiglenes fájlokra, csökkentve a RAM‑igényt, de többlet I/O‑val jár. Használja a [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/hu/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) metódust a megfelelő egyensúly eléréséhez a saját környezetében.

**Segítenek a BLOB‑opciók nagyon nagy prezentációk (például gigabájtok) megnyitásakor?**

Igen. A [BlobManagementOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/blobmanagementoptions/) kifejezetten ilyen helyzetekre készült: az ideiglenes fájlok engedélyezése és a forrászárolás használata jelentősen csökkentheti a csúcsmemória‑igényt és stabilizálhatja a feldolgozást nagyon nagy deckek esetén.

**Használhatok BLOB‑szabályokat stream‑ből történő betöltéskor a lemezes fájlok helyett?**

Igen. Ugyanazok a szabályok érvényesek a stream‑ekre is: a prezentáció példány birtokolhatja és zárolhatja a bemeneti stream‑et (a választott zárolási módtól függően), és ideiglenes fájlok lesznek használva, ha ez engedélyezve van, így a memóriahasználat kiszámítható marad a feldolgozás során.