---
title: Prezentáció BLOB-ok kezelése Java-ban a hatékony memóriahasználat érdekében
linktitle: BLOB kezelése
type: docs
weight: 10
url: /hu/java/manage-blob/
keywords:
- nagy objektum
- nagy elem
- nagy fájl
- BLOB hozzáadása
- BLOB exportálása
- kép hozzáadása BLOB-ként
- memória csökkentése
- memóriafogyasztás
- nagy prezentáció
- ideiglenes fájl
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Kezelje a BLOB adatokat az Aspose.Slides for Java-ban, hogy egyszerűsítse a PowerPoint és OpenDocument fájlok kezelését a hatékony prezentációfeldolgozás érdekében."
---
## **Áttekintés**

Az Aspose.Slides BLOB-alapú kezelést biztosít a bemutatók nagy bináris adataihoz, hogy csökkentse a memóriahasználatot nagy képek, hang, videó és bemutatófájlok esetén.

Ez a cikk bemutatja, hogyan használható a BLOB-alapú feldolgozás nagy médiafájlok egy bemutatóba történő hozzáadásához, nagy médiafájlok exportálásához a bemutatóból, és nagy bemutatók hatékonyabb betöltéséhez. Emellett ismerteti, hogyan lehet ideiglenes fájlokat használni a feldolgozás során, és hogyan változtatható meg az ideiglenes fájlok tárolására szolgáló mappa.

## **A BLOB-ról**

**BLOB** (**Binary Large Object**, bináris nagy objektum) általában egy nagy elem (fotó, bemutató, dokumentum vagy média), amely bináris formátumban van tárolva.  

Az Aspose.Slides for Java lehetővé teszi a BLOB-ok használatát objektumoknál úgy, hogy csökkentse a memóriahasználatot nagy fájlok esetén.  

{{% alert title="Info" color="info" %}}
A bizonyos korlátok kerülése érdekében, amikor adatfolyamokkal dolgozunk, az Aspose.Slides másolhatja az adatfolyam tartalmát. Egy nagy bemutató adatfolyamából történő betöltése a tartalom másolását eredményezi, és lassú betöltést okoz. Ezért, ha nagy bemutatót kíván betölteni, erősen javasoljuk, hogy a bemutató fájl útvonalát használja, és ne az adatfolyamát.
{{% /alert %}}

## **A BLOB használata a memóriafogyasztás csökkentésére**

### **Nagy fájl hozzáadása BLOB-on keresztül a bemutatóhoz**

[Aspose.Slides](/slides/hu/java/) for Java lehetővé teszi nagy fájlok (ebben az esetben egy nagy videofájl) hozzáadását BLOB-okon keresztül a memóriafogyasztás csökkentése érdekében.

Ez a Java-kód bemutatja, hogyan adhat hozzá egy nagy videofájlt a BLOB folyamaton keresztül egy bemutatóhoz:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Létrehoz egy új prezentációt, amelyhez a videót hozzáadja
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Adjunk hozzá egy videót a prezentációhoz – a KeepLocked viselkedést választottuk, mert
        // nem szándékozunk hozzáférni a "veryLargeVideo.avi" fájlhoz.
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Mentse a prezentációt. Miközben egy nagy prezentációt állítunk elő, a memóriafogyasztás
        // alacsony marad a pres objektum életciklusa során 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Nagy fájl exportálása BLOB-on keresztül a bemutatóból**

Az Aspose.Slides for Java lehetővé teszi nagy fájlok (például egy hang- vagy videofájl) exportálását BLOB-okat használó folyamat során a bemutatókból. Például előfordulhat, hogy egy nagy médiafájlt szeretne kinyerni egy bemutatóból, de nem akarja, hogy a fájl a számítógép memóriájába töltődjön be. A fájl BLOB folyamaton keresztüli exportálásával alacsony memóriafogyasztást érhet el.  

Ez a Java-kód szemlélteti a leírt műveletet:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Zárolja a forrásfájlt, és NEM tölti be a memóriába
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// hozza létre a Presentation példányt, és zárolja a "hugePresentationWithAudiosAndVideos.pptx" fájlt.
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Mentsük el minden videót egy fájlba. A magas memóriahasználat elkerülése érdekében egy puffert kell használnunk
    // a prezentáció video adatfolyamából egy újonnan létrehozott videofájl adatfolyamába való átvitelhez.
    byte[] buffer = new byte[8 * 1024];

    // Végigiterál a videókon
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Megnyitja a prezentáció video adatfolyamát. Kérjük, vegye figyelembe, hogy szándékosan elkerültük a tulajdonságok elérését
        // mint a video.BinaryData - mert ez a tulajdonság egy teljes videót tartalmazó bájt tömböt ad vissza, ami
        // miatt a bájtok betöltődnek a memóriába. A video.GetStream-et használjuk, amely Stream-et ad vissza - és NEM
        //  igényli, hogy a teljes videót betöltsük a memóriába.
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
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
    // Szükség esetén ugyanazokat a lépéseket alkalmazhatja hangfájlokra is.
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Kép hozzáadása BLOB-ként a bemutatóhoz**

Az [**IImageCollection**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IImageCollection) interfész és az [**ImageCollection**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ImageCollection) osztály metódusaival nagy képet adhat hozzá adatfolyamként, hogy azt BLOB-ként kezelje.  

Ez a Java-kód megmutatja, hogyan adhat hozzá egy nagy képet a BLOB folyamaton keresztül:

```java
String pathToLargeImage = "large_image.jpg";

// létrehoz egy új prezentációt, amelyhez a képet hozzáadja.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Adjunk hozzá egy képet a prezentációhoz – a KeepLocked viselkedést választjuk, mert
		// NEM szándékozunk hozzáférni a "largeImage.png" fájlhoz.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Mentse a prezentációt. Miközben egy nagy prezentációt állítunk elő, a memóriafogyasztás
		// alacsony marad a pres objektum életciklusa során
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Memória és nagy bemutatók**

Általában egy nagy bemutató betöltéséhez a számítógépeknek sok ideiglenes memóriára van szükségük. A bemutató teljes tartalma a memóriába kerül, és a betöltéshez használt fájl már nem kerül felhasználásra.  

Vegyünk egy nagy PowerPoint‑bemutatót (large.pptx), amely egy 1,5 GB méretű videófájlt tartalmaz. A bemutató betöltésének szokásos módja a következő Java-kóddal van szemléltetve:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Ez a módszer azonban körülbelül 1,6 GB ideiglenes memóriát használ.

### **Nagy bemutató betöltése BLOB-ként**

BLOB-ot használva egy nagy bemutatót betölthet kevesebb memóriával. Ez a Java-kód bemutatja, hogyan alkalmazható a BLOB folyamat egy nagy bemutató fájl (large.pptx) betöltésére:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Az ideiglenes fájlok mappájának megváltoztatása**

Amikor a BLOB folyamatot használja, a számítógép ideiglenes fájlokat hoz létre az alapértelmezett ideiglenes mappában. Ha másik mappában szeretné tárolni az ideiglenes fájlokat, a `TempFilesRootPath` beállítással módosíthatja a tárolási helyet:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Amikor a `TempFilesRootPath`‑t használja, az Aspose.Slides nem hoz létre automatikusan mappát az ideiglenes fájlok számára. A mappát saját kezűleg kell létrehoznia.
{{% /alert %}}

### **A Presentation objektumok felszabadítása a memória felszabadításához**

Nagy bemutatók feldolgozása során ügyeljen arra, hogy a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példány megfelelően legyen eldobva, így a lefoglalt memória felszabadul. Hívja meg a `dispose()`‑t a bemutató használatának befejezése után, hogy felszabadítsa a nem kezelt erőforrásokat.

```java
Presentation presentation = new Presentation("large.pptx");

// ...feldolgozza a prezentációt...
presentation.save("large.pdf", SaveFormat.Pdf);

// Kifejezetten felszabadítja az erőforrásokat.
presentation.dispose();
```

## **GYIK**

**Milyen adatot kezel az Aspose.Slides bemutatóban BLOB‑ként, és milyen BLOB beállítások szabályozzák?**  
A nagyméretű bináris objektumok, például képek, hang‑ és videófájlok BLOB‑ként kerülnek kezelve. A teljes bemutató fájl is BLOB‑kezelés alatt áll a betöltéskor vagy mentéskor. Ezeket az objektumokat BLOB‑szabályzatok szabályozzák, amelyekkel a memóriahasználatot és az ideiglenes fájlok használatát irányíthatja.

**Hol állítható be a BLOB kezelés szabálya a bemutató betöltésekor?**  
A [LoadOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/) és a [BlobManagementOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/blobmanagementoptions/) használatával állítható be a BLOB memóriahatára, az ideiglenes fájlok engedélyezése vagy letiltása, a gyökérútvonal megadása, valamint a forrászárolás viselkedése.

**A BLOB beállítások befolyásolják a teljesítményt, és hogyan lehet egyensúlyt teremteni a sebesség és a memória között?**  
Igen. A BLOB memóriában tartása maximalizálja a sebességet, de növeli a RAM‑használatot; a memóriahatár csökkentése több munkát helyez át ideiglenes fájlokra, ami kevesebb RAM-ot igényel, de több I/O‑t generál. A megfelelő egyensúly eléréséhez használja a [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/hu/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) metódust.

**Segítenek a BLOB beállítások nagyon nagy, több gigabájtos bemutatók megnyitásakor?**  
Igen. A [BlobManagementOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/blobmanagementoptions/) kifejezetten ilyen esetekre készült: az ideiglenes fájlok engedélyezése és a forrászárolás használata jelentősen csökkentheti a csúcsmemória igényt és stabilizálhatja a feldolgozást nagyon nagy prezentációk esetén.

**Használhatók-e BLOB szabályok adatfolyamokból történő betöltéskor a lemezfájlok helyett?**  
Igen. Ugyanazok a szabályok érvényesek az adatfolyamokra is: a bemutató példány birtokolhatja és zárolhatja a bemeneti adatfolyamot (a választott zárolási mód függvényében), és az engedélyezett esetekben ideiglenes fájlokat használ, ezzel kiszámíthatóvá téve a memóriahasználatot a feldolgozás során.