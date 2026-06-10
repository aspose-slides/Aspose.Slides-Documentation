---
title: C++-ban a prezentáció BLOB-ok kezelése a hatékony memóriahasználatért
linktitle: BLOB kezelése
type: docs
weight: 10
url: /hu/cpp/manage-blob/
keywords:
- nagy objektum
- nagy elem
- nagy fájl
- BLOB hozzáadása
- BLOB exportálása
- kép hozzáadása BLOB-ként
- memória csökkentése
- memória felhasználás
- nagy prezentáció
- ideiglenes fájl
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Kezelje a BLOB adatokat az Aspose.Slides C++ könyvtárban, hogy hatékonyan kezelje a PowerPoint és OpenDocument fájlműveleteket a prezentációk kezelésében."
---
## **Áttekintés**

Az Aspose.Slides BLOB-alapú kezelést biztosít a prezentációkban lévő nagy bináris adatokhoz, hogy csökkentse a memóriahasználatot nagy képek, hangok, videók és prezentációs fájlok feldolgozása során.

Ez a cikk bemutatja, hogyan használható a BLOB-alapú feldolgozás nagy médiák hozzáadásához egy prezentációhoz, nagy médiák exportálásához a prezentációból, és nagy prezentációk hatékonyabb betöltéséhez. Emellett elmagyarázza, hogyan használhatók ideiglenes fájlok a feldolgbás során, és hogyan változtatható meg a tárolásukhoz használt mappa.

## **A BLOB-ról**

**BLOB** (**Binary Large Object**) általában egy nagy elem (fotó, prezentáció, dokumentum vagy média), amely bináris formátumban van tárolva.

Az Aspose.Slides for C++ lehetővé teszi, hogy BLOB-okat használjon objektumokhoz úgy, hogy csökkentse a memóriahasználatot nagy fájlok esetén.

## **BLOB használata a memóriahasználat csökkentésére**

### **Nagy fájl hozzáadása BLOB-on keresztül egy prezentációhoz**

Az Aspose.Slides for C++ lehetővé teszi, hogy nagy fájlokat (ebben az esetben egy nagy videofájlt) a BLOB-okat magában foglaló folyamaton keresztül adjunk hozzá a memóriahasználat csökkentése érdekében.

Ez a C++ kód megmutatja, hogyan lehet egy nagy videofájlt a BLOB folyamattal egy prezentációhoz hozzáadni:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Létrehozza az új prezentációt, amelyhez a videót hozzáadjuk
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Adjunk hozzá videót a prezentációhoz - a KeepLocked viselkedést választottuk, mert
// nem szándékozunk hozzáférni a "veryLargeVideo.avi" fájlhoz.
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Mentse a prezentációt. Miközben egy nagy prezentáció kerül kimenetre, a memóriahasználat
// alacsony marad a pres objektum életciklusa során 
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **Nagy fájl exportálása BLOB-on keresztül egy prezentációból**

Az Aspose.Slides for C++ lehetővé teszi, hogy nagy fájlokat (ebben az esetben egy hang- vagy videofájlt) a BLOB-okat magában foglaló folyamaton keresztül exportáljunk a prezentációkból. Például előfordulhat, hogy ki kell nyernünk egy nagy médiafájlt a prezentációból, de nem szeretnénk, hogy a fájl betöltődjön a számítógép memóriájába. A fájl BLOB folyamattal történő exportálásával alacsony memóriahasználatot érhetünk el.

Ez a C++ kód bemutatja a leírt műveletet:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Létrehoz egy Presentation példányt, és zárolja a "hugePresentationWithAudiosAndVideos.pptx" fájlt.

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Mentsük le minden videót egy fájlba. A magas memóriahasználat elkerülése érdekében egy puffert kell használnunk
// hogy az adatot a prezentáció videófolyamából egy újonnan létrehozott videofájl streamjébe továbbítsuk.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Végig iterál a videókon
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Megnyitja a prezentáció videófolyamát. Kérjük, vegye figyelembe, hogy szándékosan kerültük el a metódusok elérését
	// mint a video->get_BinaryData - mivel ez a metódus egy teljes videót tartalmazó bájt tömböt ad vissza, ami
	// memóriába tölti be a bájtokat. A video->GetStream-et használjuk, amely visszaad egy Stream-et – és NEM
	// igényli, hogy az egész videót a memóriába töltsük.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// A memóriahasználat alacsony marad a videó vagy a prezentáció méretétől függetlenül,
}

// Szükség esetén ugyanazokat a lépéseket alkalmazhatja audio fájlokra is.
```

### **Kép hozzáadása BLOB-ként egy prezentációhoz**

Az [**IImageCollection**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_image_collection) interfész és a [**ImageCollection** ](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.image_collection)class metódusaival nagy képet adhatunk hozzá adatfolyamként, így azt BLOB-ként kezelve.

Ez a C++ kód megmutatja, hogyan lehet egy nagy képet a BLOB folyamattal hozzáadni:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// létrehozza az új prezentációt, amelyhez a képet hozzáadjuk.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Adjunk hozzá képet a prezentációhoz - a KeepLocked viselkedést választjuk, mert
// nem szándékozunk hozzáférni a "largeImage.png" fájlhoz.
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Mentse a prezentációt. Miközben egy nagy prezentáció kerül kimenetre, a memóriahasználat 
// alacsony marad a pres objektum életciklusa során
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **Memória és nagy prezentációk**

Általában egy nagy prezentáció betöltéséhez a számítógépeknek sok ideiglenes memóriára van szükségük. A prezentáció teljes tartalma betöltődik a memóriába, és a fájl (amelyből a prezentáció betöltődött) már nem használatos.

Gondoljunk egy nagy PowerPoint prezentációra (large.pptx), amely egy 1,5 GB-os videofájlt tartalmaz. A prezentáció betöltésének szabványos módja ebben a C++ kódban van leírva:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

Azonban ez a módszer körülbelül 1,6 GB ideiglenes memóriát fogyaszt.

### **Nagy prezentáció betöltése BLOB-ként**

A BLOB-ot magába foglaló folyamat segítségével kevés memóriával betölthetünk egy nagy prezentációt. Ez a C++ kód leírja a megvalósítást, ahol a BLOB folyamatot használják a nagy prezentációs fájl (large.pptx) betöltésére:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **Az ideiglenes fájlok mappájának módosítása**

A BLOB folyamat használatakor a számítógép ideiglenes fájlokat hoz létre az alapértelmezett ideiglenes fájlok mappájában. Ha más mappában szeretné tárolni az ideiglenes fájlokat, a `TempFilesRootPath` használatával módosíthatja a tárolási beállításokat:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
Ha a `TempFilesRootPath`-t használja, az Aspose.Slides nem hoz létre automatikusan mappát az ideiglenes fájlok tárolásához. A mappát manuálisan kell létrehoznia.
{{% /alert %}}

### **A prezentáció objektumainak eldobása a memória felszabadításához**

Nagy prezentációk feldolgozásakor győződjön meg róla, hogy a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példány megfelelően el van dobva, hogy a foglalt memória felszabaduljon. Hívja meg a `Dispose()` metódust a prezentáció használatának befejezése után a nem kezelt erőforrások felszabadításához.

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...process the presentation...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// Explicitly release resources.
presentation->Dispose();
```

## **GYIK**

**Mely adatok egy Aspose.Slides prezentációban BLOB-ként kerülnek kezelve, és BLOB beállítások vezérlik?**

A nagy bináris objektumok, például képek, hang és videó BLOB-ként kezelhetők. A teljes prezentációs fájl is BLOB kezelést igényel a betöltés vagy mentés során. Ezeket az objektumokat BLOB szabályzatok szabályozzák, amelyek lehetővé teszik a memóriahasználat kezelését és szükség esetén az adatokat ideiglenes fájlokba helyezni.

**Hol konfigurálhatom a BLOB kezelési szabályokat a prezentáció betöltése során?**

Használja a [LoadOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/) és a [BlobManagementOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/blobmanagementoptions/) kombinációját. Itt állíthatja be a BLOB memóriahatárát, engedélyezheti vagy tiltja az ideiglenes fájlokat, kiválaszthatja az ideiglenes fájlok gyökérútvonalát, és beállíthatja a forrás zárolásának viselkedését.

**A BLOB beállítások befolyásolják a teljesítményt, és hogyan egyensúlyozhatok a sebesség és a memória között?**

Igen. A BLOB memóriában tartása maximalizálja a sebességet, de növeli a RAM használatát; a memóriahatár csökkentése több munkát helyez át az ideiglenes fájlokra, ezáltal csökkentve a RAM-ot, de több I/O-val jár. Használja a [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/hu/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) metódust a megfelelő egyensúly eléréséhez a terhelés és a környezet szerint.

**Segítenek a BLOB beállítások, ha rendkívül nagy prezentációkat (pl. gigabájtok) nyitunk meg?**

Igen. A [BlobManagementOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/blobmanagementoptions/) ezekre a helyzetekre lett tervezve: az ideiglenes fájlok engedélyezése és a forrászárolás használata jelentősen csökkentheti a csúcs RAM használatot és stabilizálhatja a feldolgozást nagyon nagy prezentációk esetén.

**Használhatok BLOB szabályzatokat, ha áramlásokból (stream) töltök be a lemezfájlok helyett?**

Igen. Ugyanazok a szabályok érvényesek az áramlásokra is: a prezentáció példány birtokolhatja és zárolhatja a bemeneti stream-et (a választott zárolási mód függvényében), és az ideiglenes fájlok használata engedélyezett esetben megtörténik, ezáltal a memóriahasználat előre meghatározható a feldolgozás során.