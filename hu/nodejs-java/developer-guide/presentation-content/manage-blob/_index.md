---
title: Prezentáció BLOB-ok kezelése JavaScriptben a memóriahatékony használat érdekében
linktitle: BLOB kezelése
type: docs
weight: 10
url: /hu/nodejs-java/manage-blob/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Kezelje a BLOB adatokat JavaScriptben az Aspose.Slides for Node.js segítségével, hogy egyszerűsítse a PowerPoint és OpenDocument fájlműveleteket a prezentációk hatékony kezelése érdekében."
---
## **Áttekintés**

Az Aspose.Slides BLOB-alapú kezelést biztosít a prezentációkban található nagy bináris adatokhoz, hogy csökkentse a memóriahasználatot nagyméretű képek, hang, videó és prezentációs fájlok kezelésekor.

Ez a cikk bemutatja, hogyan lehet BLOB-alapú feldolgozással nagy médiát hozzáadni egy prezentációhoz, nagy médiát exportálni egy prezentációból, és nagy prezentációkat hatékonyabban betölteni. Emellett leírja, hogyan használhatók a feldolgozás során ideiglenes fájlok, és hogyan változtatható meg a tárolásukhoz használt mappa.

## **A BLOB**

**BLOB** (**Binary Large Object**) általában egy nagy elem (fénykép, prezentáció, dokumentum vagy média), amely bináris formátumban van mentve.

Az Aspose.Slides for Node.js via Java lehetővé teszi a BLOB-ok használatát objektumokhoz úgy, hogy csökkenti a memóriahasználatot nagyméretű fájlok esetén.

{{% alert title="Info" color="info" %}}
A streamekkel való interakció bizonyos korlátaiban való túllépés érdekében az Aspose.Slides másolhatja a stream tartalmát. Egy nagy prezentáció streamen keresztüli betöltése a prezentáció tartalmának másolását eredményezi, ami lassú betöltést okoz. Ezért, ha nagy prezentációt szeretne betölteni, határozottan ajánljuk, hogy a prezentáció fájlútvonalát használja, ne pedig a stream-et.
{{% /alert %}}

## **BLOB használata a memóriafogyasztás csökkentéséhez**

### **Nagy fájl hozzáadása BLOB-on keresztül egy prezentációhoz**

[Aspose.Slides](/slides/hu/nodejs-java/) for Node.js via Java lehetővé teszi nagy fájlok (ebben az esetben egy nagy videofájl) hozzáadását BLOB-ot bevonó folyamaton keresztül a memóriafogyasztás csökkentése érdekében.

Ez a JavaScript bemutatja, hogyan adhatunk hozzá egy nagy videofájlt a BLOB-proces segítségével a prezentációhoz:

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// Létrehoz egy új prezentációt, amelyhez a videót hozzáadjuk
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // Adjunk hozzá egy videót a prezentációhoz – a KeepLocked viselkedést választottuk, mert
        // nem szándékozunk hozzáférni a "veryLargeVideo.avi" fájlhoz.
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // Mentés a prezentáció. Míg egy nagy prezentáció kerül kimenetre, a memóriafogyasztás
        // alacsony marad a pres objektum életciklusa során
        pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Nagy fájl exportálása BLOB-on keresztül a prezentációból**

Az Aspose.Slides for Node.js via Java lehetővé teszi nagy fájlok (ebben az esetben egy hang- vagy videofájl) exportálását BLOB-ot bevonó folyamaton keresztül a prezentációkból. Például előfordulhat, hogy egy nagy médiafájlt szeretne kinyerni egy prezentációból, de nem akarja, hogy a fájl a számítógép memóriájába kerüljön. A fájl BLOB-procesen keresztüli exportálásával alacsony memóriafogyasztást érhet el.

Ez a JavaScript kód szemlélteti a leírt műveletet:

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Zárolja a forrásfájlt, és NEM tölti be a memóriába
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// létrehozza a Presentation példányt, és zárolja a "hugePresentationWithAudiosAndVideos.pptx" fájlt.
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
        // Mentsük el minden videót egy fájlba. A magas memóriahasználat elkerülése érdekében egy puffert kell használnunk, amely
        // az adat átvitelére a prezentáció videostreamjéből egy újonnan létrehozott videofájl streamjébe.
        var buffer = new byte[8 * 1024];
        // Iterál a videókon
        for (var index = 0; index < pres.getVideos().size(); index++) {
            var video = pres.getVideos().get_Item(index);
            // Megnyitja a prezentáció videostreamjét. Kérjük vegye figyelembe, hogy szándékosan elkerültük a tulajdonságok elérését
            // mint a video.BinaryData - mivel ez a tulajdonság egy teljes videót tartalmazó byte tömböt ad vissza, ami
            // memóriába tölti be a bájtokat. A video.GetStream-et használjuk, amely egy Stream-et ad vissza – és NEM
            // követeli, hogy a teljes videót betöltsük a memóriába.
            var presVideoStream = video.getStream();
            try {
                var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
                try {
                    var bytesRead;
                    while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                        outputFileStream.write(buffer, 0, bytesRead);
                    }
                } finally {
                    outputFileStream.close();
                }
            } finally {
                presVideoStream.close();
            }
            // A memóriafogyasztás alacsony marad a videó vagy a prezentáció méretétől függetlenül.
        }
        // Szükség esetén ugyanazokat a lépéseket alkalmazhatja audio fájlokra.
    } catch (e) {console.log(e);
    } finally {
        pres.dispose();
    }
```

### **Kép hozzáadása BLOB-ként a prezentációhoz**

Az [**ImageCollection**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ImageCollection) és [**ImageCollection**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ImageCollection) osztály metódusaival hozzáadhat egy nagy képet streamként, hogy azt BLOB-ként kezelje.

Ez a JavaScript kód megmutatja, hogyan adhat hozzá egy nagy képet a BLOB folyamaton keresztül:

```javascript
var pathToLargeImage = "large_image.jpg";
// új prezentációt hoz létre, amelyhez a képet hozzáadjuk.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // Adjunk hozzá egy képet a prezentációhoz – a KeepLocked viselkedést választjuk, mert
        // nem szándékozunk hozzáférni a "largeImage.png" fájlhoz.
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // Mentés a prezentáció. Miközben egy nagy prezentáció kerül kimenetre, a memóriafogyasztás
        // alacsony marad a pres objektum életciklusa során
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Memória és nagy prezentációk**

Általában egy nagy prezentáció betöltéséhez a számítógépeknek sok ideiglenes memóriára van szükségük. A prezentáció teljes tartalma memóriába kerül, és a fájl (amelyből a prezentációt betöltötték) már nem használatos.

Vegyük egy nagy PowerPoint prezentációt (large.pptx), amely egy 1,5 GB méretű videofájlt tartalmaz. A prezentáció betöltésének standard módszerét ez a JavaScript kód mutatja be:

```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

De ez a módszer körülbelül 1,6 GB ideiglenes memóriát használ.

### **Nagy prezentáció betöltése BLOB-ként**

A BLOB-ot bevonó folyamat segítségével kevés memória felhasználásával tölthet be egy nagy prezentációt. Ez a JavaScript kód bemutatja a megvalósítást, ahol a BLOB-proces használatával betöltünk egy nagy prezentációs fájlt (large.pptx):

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Az ideiglenes fájlok mappájának módosítása**

A BLOB-proces használata esetén a számítógép az alapértelmezett ideiglenes fájlok mappájában hoz létre ideiglenes fájlokat. Ha azt szeretné, hogy az ideiglenes fájlok egy másik mappában legyenek tárolva, a `setTempFilesRootPath` használatával módosíthatja a tárolási beállításokat:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Amikor a `setTempFilesRootPath`-t használja, az Aspose.Slides nem hoz létre automatikusan mappát az ideiglenes fájlok tárolásához. A mappát kézzel kell létrehoznia.
{{% /alert %}}

### **Prezentáció objektumok eldobása a memória felszabadításához**

Nagy prezentációk feldolgozása során győződjön meg arról, hogy a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példány megfelelően el van dobva, hogy a foglalt memória felszabaduljon. Hívja meg a `dispose()` metódust a prezentáció használatának befejezése után a nem kezelt erőforrások felszabadításához.

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...feldolgozza a prezentációt...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// Kifejezetten felszabadítja az erőforrásokat.
presentation.dispose();
```

## **Gyakran Ismételt Kérdések**

**Milyen adatot kezel az Aspose.Slides prezentációban BLOB‑ként, és melyik BLOB beállítások szabályozzák?**

A nagy bináris objektumok, mint például a képek, hang és videó BLOB‑ként vannak kezelve. A teljes prezentációs fájl is BLOB‑kezelést igényel, amikor betöltődik vagy mentésre kerül. Ezeket az objektumokat BLOB‑szabályok irányítják, amelyek lehetővé teszik a memóriahasználat kezelését és szükség esetén az ideiglenes fájlokhoz való átvitelét.

**Hol konfigurálhatom a BLOB‑kezelési szabályokat a prezentáció betöltése közben?**

Használja a [LoadOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/) és a [BlobManagementOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/blobmanagementoptions/) kombinációt. Itt állítható be a BLOB memóriában tartott maximális mérete, az ideiglenes fájlok engedélyezése vagy tiltása, a temp fájlok gyökérútvonala, valamint a forrászárolási viselkedés.

**A BLOB beállítások befolyásolják a teljesítményt, és hogyan egyensúlyozhatok a sebesség és a memória között?**

Igen. A BLOB memóriában tartása a legnagyobb sebességet biztosítja, de megnöveli a RAM‑felhasználást; a memóriakorlát csökkentése több munkát ad át az ideiglenes fájloknak, ezáltal csökkentve a RAM‑ot, de többlet I/O‑val jár. Használja a [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) metódust a megfelelő egyensúly eléréséhez a terhelés és a környezet függvényében.

**Segítenek a BLOB beállítások nagyon nagy prezentációk (pl. gigabájtok) megnyitásakor?**

Igen. A [BlobManagementOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/blobmanagementoptions/) ilyen esetekre lett tervezve: az ideiglenes fájlok engedélyezése és a forrászárolás használata jelentősen csökkentheti a csúcsterheléses RAM‑igényt és stabilizálhatja a feldolgozást nagyon nagy prezentációknál.

**Használhatok BLOB szabályokat streamekből történő betöltésnél a lemezfájlok helyett?**

Igen. Ugyanazok a szabályok érvényesek a streamekre is: a prezentáció példány birtokolhatja és zárolhatja a bemeneti streamet (a választott zárolási mód függvényében), és ha engedélyezve van, ideiglenes fájlok kerülnek felhasználásra, így a memóriahasználat a feldolgozás során kiszámítható marad.