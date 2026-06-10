---
title: Prezentáció BLOB-ok kezelése PHP-ben a memóriahatékony használatért
linktitle: BLOB kezelése
type: docs
weight: 10
url: /hu/php-java/manage-blob/
keywords:
- nagy objektum
- nagy elem
- nagy fájl
- BLOB hozzáadása
- BLOB exportálása
- kép hozzáadása BLOB-ként
- memória csökkentése
- memóriahasználat
- nagy prezentáció
- ideiglenes fájl
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "BLOB adatok kezelése az Aspose.Slides PHP via Java-ban a PowerPoint és OpenDocument fájlok műveleteinek egyszerűsítéséhez a prezentációk hatékony kezelése érdekében."
---
## **Áttekintés**

Az Aspose.Slides BLOB-alapú kezelést biztosít a prezentációkban lévő nagy bináris adatokhoz, hogy csökkentse a memóriahasználatot nagy képek, hangok, videók és prezentációs fájlok kezelésekor.

Ez a cikk bemutatja, hogyan használhatja a BLOB-alapú feldolgozást nagy médiafájlok hozzáadásához egy prezentációhoz, nagy médiafájlok exportálásához a prezentációból, valamint nagy prezentációk hatékonyabb betöltéséhez. Emellett ismerteti, hogyan használhatók ideiglenes fájlok a feldolgozás során, és hogyan változtatható meg a tárolásukhoz használt mappa.

## **A BLOB-ról**

**BLOB** (**Binary Large Object**) általában nagy elemet (fénykép, prezentáció, dokumentum vagy média) jelent, amely bináris formátumban van tárolva.

Az Aspose.Slides for PHP via Java lehetővé teszi a BLOB-ok használatát objektumok esetén úgy, hogy csökkenti a memóriahasználatot nagy fájlok esetén.

{{% alert title="Info" color="info" %}}
A stream-ekkel való interakció bizonyos korlátozásainak megkerülése érdekében az Aspose.Slides a stream tartalmát másolhatja. Egy nagy prezentáció stream-en keresztüli betöltése a prezentáció tartalmának másolásához vezet, ami lassú betöltést okoz. Ezért, ha nagy prezentációt szeretne betölteni, erősen ajánljuk, hogy a prezentáció fájlútvonalát használja, ne pedig a stream-et.
{{% /alert %}}

## **BLOB használata a memóriahasználat csökkentéséhez**

### **Nagy fájl hozzáadása BLOB-on keresztül egy prezentációhoz**

[Aspose.Slides](/slides/hu/php-java/) for Java lehetővé teszi, hogy nagy fájlokat (jelen esetben egy nagy videófájlt) BLOB-okon keresztül adjon hozzá, ezáltal csökkentve a memóriahasználatot.

Ez a Java kód megmutatja, hogyan adhat hozzá egy nagy videófájlt BLOB folyamaton keresztül egy prezentációhoz:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Új prezentációt hoz létre, amelyhez a videó hozzáadódik
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Adjunk hozzá egy videót a prezentációhoz – a KeepLocked viselkedést választottuk, mert
      # nem szándékozunk hozzáférni a "veryLargeVideo.avi" fájlhoz.
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Elmenti a prezentációt. Miközben egy nagy prezentáció kerül kiírásra, a memóriahasználat
      # alacsony marad a pres objektum életciklusa során
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Nagy fájl exportálása BLOB-on keresztül egy prezentációból**
Az Aspose.Slides for PHP via Java lehetővé teszi, hogy nagy fájlokat (jelen esetben egy hang- vagy videófájlt) BLOB-okon keresztül exportáljon a prezentációkból. Például előfordulhat, hogy egy nagy médiafájlt szeretne kicsomagolni egy prezentációból, de nem akarja, hogy a fájl a számítógép memóriájába töltődjön. A BLOB folyamaton keresztüli exportálással alacsony memóriahasználatot érhet el.

Ez a kód demonstrálja a leírt műveletet:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Zárolja a forrásfájlt, és NEM tölti be a memóriába
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # Létrehozza a Presentation példányt, és zárolja a "hugePresentationWithAudiosAndVideos.pptx" fájlt.
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Mentsük el minden videót egy fájlba. A magas memóriahasználat megelőzéséhez egy puffert kell használnunk
    # az adat átviteléhez a prezentáció videóstreamjéből egy újonnan létrehozott videó fájl streamjébe.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Végig iterál a videókon
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Megnyitja a prezentáció videó streamjét. Kérjük, vegye figyelembe, hogy szándékosan elkerültük a tulajdonságok elérését
      # például a video.BinaryData - mivel ez a property egy teljes videót tartalmazó byte tömböt ad vissza, ami
      # a memóriába betölt byte-okat eredményez. A video.GetStream-et használjuk, amely Stream-et ad vissza – és NEM
      # igényli, hogy a teljes videót a memóriába töltsük.
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # A memóriahasználat alacsony marad a videó vagy a prezentáció méretétől függetlenül.
    }
    # Szükség esetén ugyanazokat a lépéseket alkalmazhatja audio fájlokra.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **Kép hozzáadása BLOB-ként egy prezentációhoz**
A [ImageCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagecollection/) osztály módszereivel egy nagy képet adhat hozzá streamként, hogy BLOB-ként kezelje.

Ez a PHP kód megmutatja, hogyan adhat hozzá egy nagy képet BLOB folyamaton keresztül:

```php
  $pathToLargeImage = "large_image.jpg";
  # új prezentációt hoz létre, amelyhez a kép hozzáadódik.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Adjunk hozzá egy képet a prezentációhoz – a KeepLocked viselkedést választjuk, mert
      # NEM szándékozunk hozzáférni a "largeImage.png" fájlhoz.
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Elmenti a prezentációt. Miközben egy nagy prezentáció kerül kiírásra, a memóriahasználat
      # alacsony marad a pres objektum életciklusa során
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Memória és nagy prezentációk**

Általában egy nagy prezentáció betöltéséhez a számítógépeknek sok ideiglenes memóriare van szükségük. A prezentáció összes tartalma betöltődik a memóriába, és a fájl (amelyből a prezentáció betöltődött) már nem használódik.

Vegyünk egy nagy PowerPoint prezentációt (large.pptx), amely egy 1,5 GB videófájlt tartalmaz. A prezentáció betöltésének szabványos módja ebben a PHP kódban van leírva:

```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ez a módszer azonban körülbelül 1,6 GB ideiglenes memóriát fogyaszt.

### **Nagy prezentáció betöltése BLOB-ként**

A BLOB-ot alkalmazó folyamat segítségével egy nagy prezentációt betölthet kevesebb memóriával. Ez a PHP kód leírja a megvalósítást, ahol a BLOB folyamatot használják a nagy prezentációs fájl (large.pptx) betöltéséhez:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Az ideiglenes fájlok mappájának módosítása**

Amikor a BLOB folyamatot használja, a számítógép ideiglenes fájlokat hoz létre az alapértelmezett ideiglenes fájlok mappájában. Ha azt szeretné, hogy az ideiglenes fájlok egy másik mappában legyenek tárolva, a `setTempFilesRootPath` metódussal módosíthatja a tárolási beállításokat:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}
Amikor a `setTempFilesRootPath` metódust használja, az Aspose.Slides nem hoz létre automatikusan mappát az ideiglenes fájlok számára. A mappát saját kezűleg kell létrehoznia.
{{% /alert %}}

### **Presentációs objektumok felszabadítása a memória felszabadításához**

Nagy prezentációk feldolgozásakor ügyeljen arra, hogy a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példány megfelelően legyen felszabadítva, így a memória, amelyet elfoglalt, felszabadul. Hívja a `dispose()` metódust, miután befejezte a prezentáció használatát, hogy felszabadítsa a nem kezelt erőforrásokat.

```php
$presentation = new Presentation("large.pptx");

# ...feldolgozza a prezentációt...
$presentation->save("large.pdf", SaveFormat::Pdf);

# Kifejezetten felszabadítja az erőforrásokat.
$presentation->dispose();
```

## **GYIK**

**Mely adatot kezel az Aspose.Slides prezentációban BLOB-ként, és melyik BLOB beállítás szabályozza?**

Nagy bináris objektumok, mint például képek, hangok és videók kezelhetők BLOB-ként. A teljes prezentációs fájl is BLOB-kezelést von maga után, amikor betöltődik vagy mentésre kerül. Ezeket az objektumokat BLOB-szabályok irányítják, amelyek lehetővé teszik a memóriafelhasználás kezelését és az ideiglenes fájlok használatát szükség esetén.

**Hol konfigurálhatom a BLOB-kezelési szabályokat a prezentáció betöltése során?**

Használja a [LoadOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/) osztályt a [BlobManagementOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/blobmanagementoptions/) segítségével. Itt állíthatja be a memóriakorlátot BLOB-okhoz, engedélyezheti vagy letilthatja az ideiglenes fájlokat, kiválaszthatja az ideiglenes fájlok gyökérútvonalát, valamint a forrászár viselkedését.

**A BLOB-beállítások befolyásolják a teljesítményt, és hogyan találhatok egyensúlyt a sebesség és a memória között?**

Igen. A BLOB memóriában tartása maximalizálja a sebességet, de növeli a RAM-igényeket; a memóriakorlát csökkentése több munkát helyez át az ideiglenes fájlokra, csökkentve a RAM-igényt, de többlet I/O-val. Használja a [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/hu/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) metódust a megfelelő egyensúly eléréséhez a terhelése és a környezete szerint.

**Segítenek a BLOB-beállítások nagyon nagy prezentációk (például gigabájtok) megnyitásakor?**

Igen. A [BlobManagementOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/blobmanagementoptions/) kifejezetten ilyen forgatókönyvekre van tervezve: az ideiglenes fájlok engedélyezése és a forrászár használata jelentősen csökkentheti a csúcs RAM-felhasználást és stabilizálhatja a feldolgozást nagyon nagy bemutatók esetén.

**Használhatok BLOB-szabályokat stream-ekből való betöltésnél a lemezfájlok helyett?**

Igen. Ugyanazok a szabályok vonatkoznak a stream-ekre is: a prezentáció példány tulajdonolhatja és zárolhatja a bemeneti streamet (a választott zárolási módtól függően), és az ideiglenes fájlok használata akkor is megtörténik, ha engedélyezve van, ezáltal a memóriahasználat kiszámítható marad a feldolgozás során.