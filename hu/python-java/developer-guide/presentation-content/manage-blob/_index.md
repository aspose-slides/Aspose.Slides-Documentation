---
title: Prezentáció BLOB-ok kezelése Pythonon keresztül Java-val a hatékony memóriahasználatért
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
- memóriahasználat
- nagy bemutató
- ideiglenes fájl
- PowerPoint
- OpenDocument
- bemutató
- Python
- Java
- Aspose.Slides
description: "Kezelje a BLOB adatokat az Aspose.Slides for Python via Java segítségével, hogy egyszerűsítse a PowerPoint és OpenDocument fájlműveleteket a hatékony bemutatókezelés érdekében."
---
## **Áttekintés**

Az Aspose.Slides BLOB-alapú kezelést biztosít a bemutatókban lévő nagy bináris adatok számára, hogy csökkentse a memóriahasználatot nagy képek, hangok, videók és bemutatófájlok kezelésekor.

Ez a cikk bemutatja, hogyan használhatja a BLOB-alapú feldolgozást nagy médiafájlok bemutatóba való hozzáadásához, nagy médiafájlok exportálásához a bemutatóból, valamint nagyméretű bemutatók hatékonyabb betöltéséhez. Emellett elmagyarázza, hogyan használhatók a feldolgozás során ideiglenes fájlok, és hogyan változtatható meg azok tárolásához használt mappa.

## **A BLOB-ról**

A **BLOB** (**Binary Large Object**) általában egy nagy elem (fotó, bemutató, dokumentum vagy média), amely bináris formátumban van mentve.

Az Aspose.Slides for Python via Java lehetővé teszi, hogy BLOB-okat használjon objektumokhoz úgy, hogy csökkentse a memóriahasználatot nagy fájlok esetén.

{{% alert color="info" title="Megjegyzés" %}}
A streamekkel való interakció bizonyos korlátozásaik megkerülése érdekében az Aspose.Slides a stream tartalmát másolhatja. Egy nagy bemutató streamen keresztüli betöltése a bemutató tartalmának másolásához vezet, és lassú betöltést okoz. Ezért, ha nagy bemutatót kíván betölteni, erősen javasoljuk, hogy a bemutató fájl útvonalát használja, ne pedig a stream-et.
{{% /alert %}}

## **BLOB-ok használata a memóriahasználat csökkentéséhez**

### **Nagy fájl hozzáadása a bemutatóhoz BLOB-ok használatával**

[Aspose.Slides](/slides/hu/python-java/) for Python via Java lehetővé teszi, hogy nagy fájlokat (ebben az esetben egy nagy videófájlt) adjunk hozzá egy BLOB-okat érintő folyamaton keresztül a memóriahasználat csökkentése érdekében.

Ez a Python kód megmutatja, hogyan adhatunk hozzá egy nagy videófájlt a BLOB folyamaton keresztül egy bemutatóhoz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Új bemutató létrehozása, amelyhez a videót hozzáadjuk.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # Zárva tartjuk a streamet, mert nem szándékozunk hozzáférni a videófájlhoz.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Mentse a bemutatót, miközben alacsonyan tartja a memóriahasználatot.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Nagy fájl exportálása a bemutatóból BLOB-ok használatával**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy nagy fájlokat (ebben az esetben egy hang- vagy videófájlt) exportáljon BLOB-okat érintő folyamaton keresztül a bemutatókból. Például szükség lehet egy nagy médiafájl kinyerésére a bemutatóból, anélkül, hogy a fájlt a számítógép memóriájába töltené. A BLOB folyamaton keresztül történő exportálással alacsony memóriahasználatot érhet el.

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
    # A videó adatot egy bufferen keresztül továbbítja a memóriahasználat alacsonyan tartása érdekében.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # A streamet használja a teljes videó bájt tömbbe betöltése helyett.
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
    # Szükség esetén alkalmazza ugyanazokat a lépéseket az audiofájlokra.
finally:
    presentation.dispose()
```

### **Kép hozzáadása BLOB-ként a bemutatóhoz**

A [ImageCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagecollection/) osztály módszereivel nagy képet adhat hozzá streamként, hogy azt BLOB-ként kezelje.

Ez a Python kód megmutatja, hogyan adhat hozzá egy nagy képet a BLOB folyamaton keresztül:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Új bemutató létrehozása, amelyhez a képet hozzáadjuk.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Zárva tartjuk a streamet, mert nem szándékozunk hozzáférni a képfájlhoz.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Mentse a bemutatót, miközben alacsonyan tartja a memóriahasználatot.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Memória és nagy bemutatók**

Általában egy nagy bemutató betöltéséhez a számítógépeknek sok ideiglenes memóriára van szükségük. A bemutató teljes tartalma betöltődik a memóriába, és a betöltéshez használt fájl (amelyből a bemutatót betöltötték) már nem használatos.

Gondoljunk egy nagy PowerPoint bemutatóra (large.pptx), amely egy 1,5 GB-os videófájlt tartalmaz. A bemutató betöltésének standard módszerét ebben a Python kódban mutatjuk be:

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

Azonban ez a módszer körülbelül 1,6 GB ideiglenes memóriát fogyaszt.

### **Nagy bemutató betöltése BLOB-ként**

A BLOB-kezelés használatával kevés memória felhasználása mellett tölthető be egy nagy bemutató. Ez a Python kód megmutatja, hogyan használja a BLOB-kezelést nagy bemutató fájl (large.pptx) betöltéséhez:

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

### **Ideiglenes fájlok mappájának módosítása**

Amikor a BLOB folyamatot használja, a számítógép ideiglenes fájlokat hoz létre az alapértelmezett ideiglenes fájlok mappájában. Ha azt szeretné, hogy az ideiglenes fájlok egy másik mappában legyenek tárolva, megváltoztathatja a tárolási beállításokat a [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/hu/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) segítségével:

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
Amikor a [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/hu/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) metódust használja, az Aspose.Slides nem hoz létre automatikusan mappát az ideiglenes fájlok tárolásához. A mappát saját kezűleg kell létrehoznia.
{{% /alert %}}

### **A bemutató objektumok felszabadítása a memória felszabadításához**

Nagy bemutatók feldolgozásakor győződjön meg arról, hogy a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példány megfelelően fel legyen szabadítva, hogy a lefoglalt memória felszabaduljon. Hívja meg a [Presentation.dispose](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#dispose) metódust a bemutató használatának befejezése után a nem kezelt erőforrások felszabadításához.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...feldolgozza a bemutatót...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # Kifejezetten felszabadítja az erőforrásokat.
    presentation.dispose()
```

## **GYIK**

**Milyen adatot tekint az Aspose.Slides bemutatóban BLOB-nak, és melyet a BLOB beállítások szabályoznak?**

A nagy bináris objektumok, például képek, hang és videó BLOB-okká válnak. A teljes bemutató fájl is BLOB-kezelést igényel a betöltésekor vagy mentésekor. Ezeket az objektumokat BLOB-szabályzatok szabályozzák, amelyek lehetővé teszik a memóriahasználat kezelését és szükség esetén az ideiglenes fájlokba való áthelyezést.

**Hol konfigurálhatom a BLOB-kezelési szabályokat a bemutató betöltésekor?**

Használja a [LoadOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/) és a [BlobManagementOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/blobmanagementoptions/) kombinációját. Itt adhatja meg a BLOB-ok memória-korlátját, engedélyezheti vagy letilthatja az ideiglenes fájlokat, kiválaszthatja az ideiglenes fájlok gyökér útvonalát, és beállíthatja a forrászárolás viselkedését.

**Befolyásolják a BLOB-beállítások a teljesítményt, és hogyan egyensúlyozhatok a sebesség és a memória között?**

Igen. A BLOB-ok memóriában tartása maximalizálja a sebességet, de növeli a RAM felhasználást; a memóriakorlát csökkentése több munkát helyez át az ideiglenes fájlokra, ezáltal csökkentve a RAM-ot, de többlet I/O költséggel jár. Használja a [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/hu/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) metódust a megfelelő egyensúly eléréséhez a terhelés és a környezet függvényében.

**Segítenek a BLOB-beállítások rendkívül nagy bemutatók (például gigabájtok) megnyitásakor?**

Igen. A [BlobManagementOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/blobmanagementoptions/) ilyen forgatókönyvekre lett tervezve: az ideiglenes fájlok engedélyezése és a forrászárolás használata jelentősen csökkentheti a csúcs RAM használatot és stabilizálhatja a feldolgozást nagyon nagy bemutatók esetén.

**Használhatok BLOB-szabályzatokat a streamekből való betöltéskor a lemezfájlok helyett?**

Igen. Ugyanazok a szabályok érvényesek a streamekre is: a bemutató példány birtokolhatja és zárolhatja a bemeneti streamet (a választott zárolási módtól függően), és az engedélyezett esetben ideiglenes fájlok kerülnek használatra, így a memóriahasználat előre kiszámítható marad a feldolgozás során.