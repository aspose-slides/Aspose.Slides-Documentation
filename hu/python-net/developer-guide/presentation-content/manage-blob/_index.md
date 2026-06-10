---
title: BLOB-ok kezelése prezentációkban Python segítségével a memóriahatékony használatért
linktitle: BLOB kezelése
type: docs
weight: 10
url: /hu/python-net/manage-blob/
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
- Aspose.Slides
description: "Kezelje a BLOB adatokat az Aspose.Slides for Python via .NET-ben, hogy egyszerűsítse a PowerPoint és OpenDocument fájlműveleteket a prezentációk hatékony kezelése érdekében."
---
## **Áttekintés**

Az Aspose.Slides BLOB-alapú kezelést biztosít a prezentációkban lévő nagy bináris adatokhoz, hogy csökkentse a memóriahasználatot nagy képek, hang, videó és prezentációs fájlok kezelése során.

Ez a cikk bemutatja, hogyan használható a BLOB-alapú feldolgozás nagy médiák hozzáadásához egy prezentációhoz, nagy médiaexportáláshoz a prezentációból, és nagy prezentációk hatékonyabb betöltéséhez. Emellett ismerteti, hogyan használhatók a feldolgozás során ideiglenes fájlok, valamint hogyan változtatható meg a tárolásukhoz használt mappa.

## **A BLOB-ról**

**BLOB** (**Binary Large Object**) általában egy nagy elem (fotó, prezentáció, dokumentum vagy média), amely bináris formátumban van elmentve.

Az Aspose.Slides for Python via .NET lehetővé teszi BLOB-ok használatát objektumok esetén olyan módon, hogy csökkentse a memóriahasználatot nagy fájlok esetén.

## **A BLOB használata a memóriafogyasztás csökkentésére**

### **Nagy fájl hozzáadása BLOB-on keresztül egy prezentációhoz**

[Aspose.Slides](/slides/hu/python-net/) for .NET lehetővé teszi nagy fájlok (ebben az esetben egy nagy videofájl) hozzáadását egy BLOB-okat érintő folyamaton keresztül a memóriafogyasztás csökkentése érdekében.

Ez a Python példa megmutatja, hogyan adhatunk hozzá egy nagy videofájlt a BLOB folyamaton keresztül egy prezentációhoz:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Létrehoz egy új prezentációt, amelyhez a videót hozzáadjuk
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Adjunk hozzá egy videót a prezentációhoz – a KeepLocked viselkedést választottuk, mert
        # nem szándékozunk hozzáférni a "veryLargeVideo.avi" fájlhoz.
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Mentse a prezentációt. Mialatt egy nagy prezentáció kerül kimenetre, a memóriahasználat
        # alacsony marad a pres objektum életciklusa során 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **Nagy fájl exportálása BLOB-on keresztül a prezentációból**

Az Aspose.Slides for Python via .NET lehetővé teszi nagy fájlok (ebben az esetben egy audio vagy videó fájl) exportálását BLOB-okat érintő folyamaton keresztül a prezentációkból. Például előfordulhat, hogy ki kell nyerni egy nagy médiafájlt egy prezentációból, de nem akarja, hogy a fájl betöltődjön a számítógép memóriájába. A fájl BLOB folyamaton keresztüli exportálásával a memóriahasználat alacsonyan tartása érhető el.

Ez a Python kód bemutatja a leírt műveletet:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Mentsük el minden videót egy fájlba. A magas memóriahasználat elkerülése érdekében egy puffert kell használnunk, amely
	# hogy az adatot a prezentáció videófolyamáról egy újonnan létrehozott videofájl áramlásába továbbítsuk.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Végigiterál a videókon
    index = 0
    # Szükség esetén ugyanazokat a lépéseket alkalmazhatja audiofájlokra is. 
    for video in pres.videos:
		# Megnyitja a prezentáció videófolyamát. Kérjük, vegye figyelembe, hogy szándékosan kerültünk el a tulajdonságok elérését
		# például a video.BinaryData - mivel ez a tulajdonság egy teljes videót tartalmazó byte tömböt ad vissza, ami
		# memóriába tölti a bájtokat. A video.GetStream metódust használjuk, amely egy Streamet ad vissza – és NEM
		#  igényli a teljes videó memóriába töltését.
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **Kép hozzáadása BLOB-ként a prezentációban**

Az [**ImageCollection**](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imagecollection/) osztály módszereivel nagy képet adhat hozzá adatfolyamként, hogy BLOB-ként legyen kezelve.

Ez a Python kód megmutatja, hogyan adjon hozzá egy nagy képet a BLOB folyamaton keresztül:

```py
import aspose.slides as slides

# létrehoz egy új prezentációt, amelyhez a képet hozzáadjuk.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Memória és nagy prezentációk**

Általában egy nagy prezentáció betöltéséhez a számítógépeknek sok ideiglenes memóriára van szükségük. A prezentáció teljes tartalma betöltődik a memóriába, és a fájl (amelyből a prezentáció betöltődött) már nem használatos.

Tekintsünk egy nagy PowerPoint prezentációt (large.pptx), amely 1,5 GB méretű videofájlt tartalmaz. A prezentáció betöltésének szokásos módszere ebben a Python kódban van bemutatva:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

De ez a módszer körülbelül 1,6 GB ideiglenes memóriát használ.

### **Nagy prezentáció betöltése BLOB-ként**

A BLOB-ot érintő folyamat segítségével nagy prezentációt tölthetünk be kevés memória felhasználásával. Ez a Python kód bemutatja a megvalósítást, ahol a BLOB folyamatot használjuk egy nagy prezentációs fájl (large.pptx) betöltésére:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **Az ideiglenes fájlok mappájának módosítása**

Amikor a BLOB folyamatot használják, a számítógép ideiglenes fájlokat hoz létre az alapértelmezett ideiglenes fájlok mappájában. Ha azt szeretné, hogy az ideiglenes fájlok egy másik mappában legyenek tárolva, a `temp_files_root_path` beállítással módosíthatja a tárolási beállításokat:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
Amikor a `temp_files_root_path` beállítást használja, az Aspose.Slides nem hoz létre automatikusan mappát az ideiglenes fájlok tárolására. A mappát saját kezűleg kell létrehoznia.
{{% /alert %}}

### **Prezentációs objektumok elengedése a memória felszabadításához**

Nagy prezentációk feldolgozásakor győződjön meg róla, hogy a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példány megfelelően elengedésre kerül, hogy a felhasznált memória felszabaduljon. Az ajánlott mód a kontextuskezelő (`with slides.Presentation(...) as presentation:`) használata, ahogy a fenti példákban is látható; ez automatikusan bezárja a prezentációt és felszabadítja a nem menedzselt erőforrásokat, amikor a blokk kilép.

Ha a prezentációt `with` blokk nélkül hozza létre, hívja meg kifejezetten a `presentation.dispose()` metódust a használat befejezése után, és távolítsa el az esetleges hátramaradt hivatkozásokat, hogy a Python szemétgyűjtője vissza tudja szerezni a memóriát.

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...feldolgozza a prezentációt...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# Kifejezetten felszabadítja az erőforrásokat.
presentation.dispose()
```

## **GYIK**

**Milyen adatot tekint az Aspose.Slides prezentációban BLOB-nak, és melyet szabályozzák a BLOB beállítások?**

A nagy bináris objektumok, például képek, hang és videó BLOB-ként vannak kezelve. A teljes prezentációs fájl is BLOB-kezelést igényel betöltéskor vagy mentéskor. Ezeket az objektumokat BLOB szabályzatok irányítják, amelyek lehetővé teszik a memóriahasználat kezelését és szükség esetén ideiglenes fájlokra való kiírást.

**Hol konfigurálhatom a BLOB kezelési szabályokat a prezentáció betöltése során?**

Használja a [LoadOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/) és a [BlobManagementOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/blobmanagementoptions/) párost. Itt állíthatja be a BLOB memóriahatárát, engedélyezheti vagy tiltja az ideiglenes fájlokat, kiválaszthatja az ideiglenes fájlok gyökérútvonalát, valamint meghatározhatja a forrászárolás viselkedését.

**A BLOB beállítások befolyásolják a teljesítményt, és hogyan lehet egyensúlyt találni a sebesség és a memória között?**

Igen. A BLOB memóriaban tartása a legnagyobb sebességet biztosítja, de növeli a RAM használatát; az memóriahatár csökkentése több munkát helyez át az ideiglenes fájlokra, ezzel csökkentve a RAM-ot, de többlet I/O-val jár. Állítsa be a [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/hu/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) küszöböt, hogy megtalálja a megfelelő egyensúlyt a terhelés és a környezet között.

**Segítenek a BLOB beállítások, ha rendkívül nagy prezentációkat (például gigabájt méretű) nyitunk meg?**

Igen. A [BlobManagementOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/blobmanagementoptions/) ilyen forgatókönyvekre lett tervezve: az ideiglenes fájlok engedélyezése és a forrászárolás használata jelentősen csökkentheti a csúcsmemória használatát és stabilizálhatja a feldolgozást nagyon nagy bemutatók esetén.

**Használhatok BLOB szabályzatokat, ha a betöltés stream-eken keresztül történik a lemezfájlok helyett?**

Igen. Ugyanazok a szabályok alkalmazhatók stream-ekre: a prezentáció példány birtokolhatja és zárolhatja a bemeneti stream-et (a választott zárolási mód függvényében), és az engedélyezett esetben ideiglenes fájlok kerülnek felhasználásra, így a memóriahasználat előre jelezhető a feldolgozás során.