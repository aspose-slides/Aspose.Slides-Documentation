---
title: Androidon a prezentáció BLOB-ok kezelése a hatékony memóriahasználatért
linktitle: BLOB kezelése
type: docs
weight: 10
url: /hu/androidjava/manage-blob/
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
- Android
- Java
- Aspose.Slides
description: "Kezelje a BLOB adatokat az Aspose.Slides Android Java verziójában, hogy egyszerűsítse a PowerPoint és OpenDocument fájlműveleteket a hatékony prezentációkezelés érdekében."
---
## **Áttekintés**

Az Aspose.Slides BLOB-alapú kezelést biztosít nagy bináris adatokhoz a prezentációkban, hogy csökkentse a memóriahasználatot nagy képek, hangok, videók és prezentációs fájlok esetén.

Ez a cikk bemutatja, hogyan használható a BLOB-alapú feldolgozás nagy médiák hozzáadásához egy prezentációhoz, nagy média exportálásához a prezentációból, és hogyan tölthető be hatékonyabban nagy prezentáció. Emellett elmagyarázza, hogyan használhatók ideiglenes fájlok a feldolgozás során, és hogyan módosítható az ezek tárolására használt mappa.

## **A BLOB-ról**

**BLOB** (**Binary Large Object**) általában egy nagy elem (fotó, prezentáció, dokumentum vagy média), amely bináris formátumban van mentve.

Az Aspose.Slides for Android via Java lehetővé teszi a BLOB-ok használatát objektumokhoz úgy, hogy csökkenti a memóriahasználatot nagy fájlok esetén.

{{% alert title="Info" color="info" %}}
Annak érdekében, hogy bizonyos korlátozásoktól elkerüljük a streamekkel való interakciót, az Aspose.Slides másolhatja a stream tartalmát. Egy nagy prezentáció betöltése a stream‑jéből a prezentáció tartalmának másolásához és lassú betöltéshez vezet. Ezért, ha nagy prezentációt szeretne betölteni, erősen javasoljuk, hogy a prezentáció fájlútvonalát használja, ne a stream‑et.
{{% /alert %}}

## **BLOB használata a memóriafogyasztás csökkentésére**

### **Nagy fájl hozzáadása BLOB segítségével a prezentációhoz**

[Aspose.Slides](/slides/hu/androidjava/) Java számára lehetővé teszi nagy fájlok (ebben az esetben egy nagy videofájl) hozzáadását BLOB-alapú folyamaton keresztül a memóriafogyasztás csökkentése érdekében.

Ez a Java példa megmutatja, hogyan adhatunk hozzá egy nagy videofájlt a BLOB folyamaton keresztül egy prezentációhoz:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Létrehoz egy új prezentációt, amelyhez a videó hozzá lesz adva
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Adjunk hozzá egy videót a prezentációhoz – a KeepLocked viselkedést választottuk, mert
        // nem szándékozunk hozzáférni a "veryLargeVideo.avi" fájlhoz.
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Mentés a prezentáció. Míg egy nagy prezentáció kerül kimenetre, a memóriafelhasználás
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

### **Nagy fájl exportálása BLOB segítségével a prezentációból**
Az Aspose.Slides for Android via Java lehetővé teszi nagy fájlok (ebben az esetben egy hang vagy videó fájl) exportálását BLOB-alapú folyamaton keresztül a prezentációkból. Például előfordulhat, hogy ki szeretne nyerni egy nagy médiafájlt a prezentációból, de nem akarja, hogy a fájl a számítógép memóriájába töltődjön be. A BLOB folyamaton keresztül exportálva alacsony memóriafogyasztást ér el.

Ez a Java kód demonstrálja a leírt műveletet:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Zárolja a forrásfájlt, és NEM tölti be a memóriába
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// Létrehozza a Presentation példányt, és zárolja a "hugePresentationWithAudiosAndVideos.pptx" fájlt.
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Mentsük el minden videót egy fájlba. A magas memóriahasználat elkerülése érdekében egy puffert kell használnunk, amelyet
    // az adat átadására a prezentáció videó streamjéből egy újonnan létrehozott videófájl streamjébe.
    byte[] buffer = new byte[8 * 1024];

    // Végigiterál a videókon
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Megnyitja a prezentáció videó streamjét. Kérjük vegye figyelembe, hogy szándékosan elkerültük a tulajdonságok elérését
        // például a video.BinaryData - mert ez a tulajdonság egy byte tömböt ad vissza, amely egy teljes videót tartalmaz, ami ezután
        // byte-okat tölti be a memóriába. A video.GetStream-et használjuk, amely egy Stream-et ad vissza – és NEM
        //  igényli, hogy a teljes videót a memóriába töltsük.
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
        // Memory consumption will remain low regardless of the size of the video or presentation.
    }
    // If necessary, you can apply the same steps for audio files. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Kép hozzáadása BLOB-ként egy prezentációhoz**
Az [**IImageCollection**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IImageCollection) interfész és a [**ImageCollection**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ImageCollection) osztály metódusaival nagy képet adhatunk hozzá streamként, hogy BLOB‑ként legyen kezelve.

Ez a Java kód megmutatja, hogyan adható hozzá egy nagy kép a BLOB folyamaton keresztül:

```java
String pathToLargeImage = "large_image.jpg";

// létrehoz egy új prezentációt, amelyhez a kép hozzá lesz adva.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Adjunk hozzá egy képet a prezentációhoz – a KeepLocked viselkedést választjuk, mert
		// NEM szándékozunk hozzáférni a "largeImage.png" fájlhoz.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Mentés a prezentáció. Míg egy nagy prezentáció kerül kimenetre, a memóriafelhasználás
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

## **Memória és nagy prezentációk**

Általában egy nagy prezentáció betöltéséhez a számítógépeknek sok ideiglenes memóriára van szükségük. A prezentáció teljes tartalma a memóriába kerül, és a fájl (amelyből a prezentáció betöltésre került) már nem használatos.

Vegyünk egy nagy PowerPoint prezentációt (large.pptx), amely egy 1,5 GB-os videofájlt tartalmaz. A prezentáció betöltésének standard módszere ebben a Java kódban van leírva:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

De ez a módszer körülbelül 1,6 GB ideiglenes memóriát fogyaszt.

### **Nagy prezentáció betöltése BLOB-ként**

BLOB‑alapú folyamat segítségével kevés memóriával tölthet fel egy nagy prezentációt. Ez a Java kód leírja a megvalósítást, ahol a BLOB folyamatot használják egy nagy prezentációs fájl (large.pptx) betöltésére:

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

### **Az ideiglenes fájlok mappájának módosítása**

Amikor a BLOB folyamatot használja, a számítógép ideiglenes fájlokat hoz létre az alapértelmezett ideiglenes fájlok mappájában. Ha másik mappában szeretné tárolni az ideiglenes fájlokat, a `TempFilesRootPath` beállítással módosíthatja a tárolási beállításokat:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Amikor a `TempFilesRootPath`‑t használja, az Aspose.Slides nem hoz létre automatikusan egy mappát az ideiglenes fájlok tárolására. A mappát saját kezűleg kell létrehoznia.
{{% /alert %}}

### **Prezentációs objektumok eldobása a memória felszabadításához**

Nagy prezentációk feldolgozásakor ügyeljen arra, hogy a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példány megfelelően legyen eldobva, így a foglalt memória felszabadul. Hívja a `dispose()` metódust, miután befejezte a prezentáció használatát, hogy felszabadítsa a nem kezelt erőforrásokat.

```java
Presentation presentation = new Presentation("large.pptx");

// ...dolgozza fel a prezentációt...
presentation.save("large.pdf", SaveFormat.Pdf);

// Kifejezetten szabadítsa fel az erőforrásokat.
presentation.dispose();
```

## **GYIK**

**Milyen adatokat kezel BLOB‑ként egy Aspose.Slides prezentációban, és mely beállítások irányítják?**

Nagy bináris objektumok, például képek, hangok és videók kezelődnek BLOB‑ként. A teljes prezentációs fájl is BLOB kezelést igényel betöltéskor vagy mentéskor. Ezeket az objektumokat BLOB szabályok szabályozzák, amelyek lehetővé teszik a memóriahasználat kezelését és az ideiglenes fájlok használatát szükség esetén.

**Hol konfigurálhatom a BLOB‑kezelési szabályokat a prezentáció betöltésekor?**

Használja a [LoadOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/)‑t a [BlobManagementOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/blobmanagementoptions/)‑val. Itt adhatja meg a BLOB memóriában tartható méretkorlátját, engedélyezheti vagy letilthatja az ideiglenes fájlokat, kiválaszthatja a gyökér útvonalat az ideiglenes fájloknak, valamint beállíthatja a forrászár viselkedését.

**Hatnak a BLOB beállítások a teljesítményre, és hogyan egyensúlyozhatok a sebesség és a memória között?**

Igen. A BLOB memóriában tartása maximalizálja a sebességet, de növeli a RAM fogyasztást; a memóriakorlát csökkentése több munkát helyez az ideiglenes fájlokra, így csökkentve a RAM-ot, de további I/O költséggel. Használja a [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) metódust a megfelelő egyensúly megtalálásához a terhelés és a környezet alapján.

**Segítenek a BLOB beállítások extrém nagy prezentációk (pl. gigabájtos) megnyitásakor?**

Igen. A [BlobManagementOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/blobmanagementoptions/) kifejezetten ilyen forgatókönyvekre készült: az ideiglenes fájlok engedélyezése és a forrászár használata jelentősen csökkentheti a csúcs RAM használatot és stabilizálhatja a feldolgozást nagyon nagy deckek esetén.

**Használhatok BLOB szabályokat stream‑ekből történő betöltéskor a lemezfájlok helyett?**

Igen. Ugyanazok a szabályok vonatkoznak a streamekre: a prezentációpéldány birtokolhatja és zárolhatja a bemeneti streamet (a választott zárási módtól függően), és az ideiglenes fájlok használata megengedett, így a memóriahasználat kiszámítható marad a feldolgozás során.