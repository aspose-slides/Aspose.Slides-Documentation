---
title: Prezentáció BLOB-ok kezelése .NET-ben a hatékony memóriahasználatért
linktitle: BLOB kezelése
type: docs
weight: 10
url: /hu/net/manage-blob/
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
- .NET
- C#
- Aspose.Slides
description: "Kezelje a BLOB adatokat az Aspose.Slides for .NET-ben a PowerPoint és OpenDocument fájlműveletek hatékony kezelése érdekében."
---
## **Áttekintés**

Az Aspose.Slides BLOB-alapú kezelést biztosít a prezentációkban lévő nagy bináris adatokhoz, hogy csökkentse a memóriahasználatot nagy képek, hangok, videók és prezentációs fájlok kezelésekor.

Ez a cikk bemutatja, hogyan használható a BLOB-alapú feldolgozás nagy média hozzáadásához egy prezentációhoz, nagy média exportálásához a prezentációból, és nagy prezentációk hatékonyabb betöltéséhez. Emellett ismerteti, hogyan használhatók a feldolgozás során ideiglenes fájlok, valamint hogyan lehet megváltoztatni a tárolásukhoz használt mappát.

## **A BLOB‑ról**

**BLOB** (**Binary Large Object**) általában egy nagy elem (fénykép, prezentáció, dokumentum vagy média), amely bináris formátumban van mentve.

Az Aspose.Slides for .NET lehetővé teszi a BLOB-ok használatát objektumokhoz úgy, hogy csökkenti a memóriahasználatot nagy fájlok esetén.

## **BLOB használata a memóriahasználat csökkentéséhez**

### **Nagy fájl hozzáadása BLOB‑on keresztül a prezentációhoz**

[Aspose.Slides](/slides/hu/net/) for .NET lehetővé teszi nagy fájlok (jelen esetben egy nagy videofájl) hozzáadását egy BLOB‑ot érintő folyamaton keresztül a memóriahasználat csökkentése érdekében.

Ez a C# példa bemutatja, hogyan adhatunk hozzá egy nagy videofájlt a BLOB folyamaton keresztül a prezentációhoz:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Létrehoz egy új prezentációt, amelyhez a videót hozzáadjuk
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Adjunk videót a prezentációhoz - a KeepLocked viselkedést választottuk, mert
        // nem szándékozunk hozzáférni a "veryLargeVideo.avi" fájlhoz.
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Mentse a prezentációt. Miközben egy nagy prezentációt generálunk, a memóriahasználat
        // alacsony marad a pres objektum életciklusa alatt 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **Nagy fájl exportálása BLOB‑on keresztül a prezentációból**

Az Aspose.Slides for .NET lehetővé teszi nagy fájlok (jelen esetben egy audio vagy videó fájl) exportálását a prezentációkból egy BLOB‑ot érintő folyamat segítségével. Például lehet, hogy ki szeretne nyerni egy nagy médiafájlt a prezentációból, de nem akarja, hogy a fájl a számítógép memóriájába töltődjön. A fájl BLOB folyamaton keresztüli exportálásával alacsony memóriahasználatot érhet el.

Ez a C# kód bemutatja a leírt műveletet:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Zárolja a forrásfájlt, és NEM töltődik be a memóriába
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Létrehozza a Presentation példányt, és zárolja a "hugePresentationWithAudiosAndVideos.pptx" fájlt.
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Mentsük el minden videót egy fájlba. A magas memóriahasználat elkerülése érdekében egy puffert kell használnunk, amely
	// az adatokat a prezentáció videóáramából egy új videó fájlhoz létrehozott áramba továbbítja.
	byte[] buffer = new byte[8 * 1024];

	// Iterates through the videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Megnyitja a prezentáció videóáramát. Kérjük, vegye figyelembe, hogy szándékosan elkerültük a tulajdonságok elérését
		// mint a video.BinaryData - mert ez a tulajdonság egy teljes videót tartalmazó bájt tömböt ad vissza, ami
		// memóriába tölti be a bájtokat. A video.GetStream-et használjuk, amely Stream-et ad vissza - és NEM
		//  megköveteli, hogy a teljes videót betöltsük a memóriába.
		using (Stream presVideoStream = video.GetStream())
		{
			using (FileStream outputFileStream = File.OpenWrite($"video{index}.avi"))
			{
				int bytesRead;
				while ((bytesRead = presVideoStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					outputFileStream.Write(buffer, 0, bytesRead);
				}
			}
		}

		// A memóriahasználat alacsony marad a videó vagy a prezentáció méretétől függetlenül,
	}

	// Szükség esetén ugyanazokat a lépéseket alkalmazhatja audio fájlokra. 
}
```

### **Kép hozzáadása BLOB‑ként a prezentációhoz**

Az [**IImageCollection**](https://reference.aspose.com/slides/hu/net/aspose.slides/iimagecollection) interfész és az [**ImageCollection**](https://reference.aspose.com/slides/hu/net/aspose.slides/imagecollection) osztály metódusaival nagy képet adhat hozzá adatfolyamként, hogy BLOB‑ként legyen kezelve.

Ez a C# kód megmutatja, hogyan adhatunk hozzá egy nagy képet a BLOB folyamaton keresztül:

```c#
string pathToLargeImage = "large_image.jpg";

// létrehoz egy új prezentációt, amelyhez a képet hozzáadjuk.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Adjunk képet a prezentációhoz - a KeepLocked viselkedést választjuk, mert nem
		// SZÁNDÉKOZUNK hozzáférni a "largeImage.png" fájlhoz.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Mentse a prezentációt. Miközben egy nagy prezentációt generálunk, a memóriahasználat 
		// alacsony marad a pres objektum életciklusa során
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **Memória és nagy prezentációk**

Általában egy nagy prezentáció betöltéséhez a számítógépeknek sok ideiglenes memóriára van szükségük. A prezentáció teljes tartalma a memóriába töltődik, és a fájl (amelyből a prezentáció betöltődött) már nem használatos.

Tekintsünk egy nagy PowerPoint prezentációt (large.pptx), amely egy 1.5 GB videofájlt tartalmaz. A prezentáció betöltésének szokásos módszerét ez a C# kód mutatja:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

Ez a módszer azonban körülbelül 1.6 GB ideiglenes memóriát fogyaszt.

### **Nagy prezentáció betöltése BLOB‑ként**

A BLOB‑ot érintő folyamat segítségével kis memóriamennyiség felhasználásával tölthet be egy nagy prezentációt. Ez a C# kód leírja a megvalósítást, ahol a BLOB folyamatot használják egy nagy prezentációs fájl (large.pptx) betöltéséhez:

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true
   }
};
 
using (Presentation pres = new Presentation("large.pptx", loadOptions))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

### **Ideiglenes fájlok mappájának módosítása**

Amikor a BLOB folyamatot használja, a számítógép ideiglenes fájlokat hoz létre az alapértelmezett ideiglenes fájlok mappájában. Ha azt szeretné, hogy az ideiglenes fájlok egy másik mappában legyenek tárolva, a tárolási beállításokat a `TempFilesRootPath` segítségével módosíthatja:

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true,
       TempFilesRootPath = "temp"
   }
};
```

{{% alert title="Info" color="info" %}}
Amikor a `TempFilesRootPath`‑t használja, az Aspose.Slides nem hoz létre automatikusan mappát az ideiglenes fájlok tárolásához. A mappát manuálisan kell létrehoznia. 
{{% /alert %}}

### **Presentation objektumok felszabadítása a memória felszabadításához**

Nagy prezentációk feldolgozásakor győződjön meg arról, hogy a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példány megfelelően fel van szabadítva, hogy az általa foglalt memória felszabaduljon. Az ajánlott mód a `using` utasítás vagy deklaráció használata, ahogyan a fenti példákban látható; ez automatikusan felszabadítja a prezentációt és felszabadítja a nem kezelt erőforrásokat, amikor a blokk kilép.

Ha a prezentációt `using` blokk nélkül hozza létre, a használat befejezése után hívja meg kifejezetten a `Dispose()` metódust.

```cs
Presentation presentation = new Presentation("large.pptx");

// ...feldolgozza a prezentációt...
presentation.Save("large.pdf", SaveFormat.Pdf);

// Explicit módon felszabadítja az erőforrásokat.
presentation.Dispose();
```

## **GYIK**

**Milyen adatot kezel a BLOB és szabályozza a BLOB beállítások egy Aspose.Slides prezentációban?**

A nagy bináris objektumokat, például képeket, hangot és videót BLOB‑ként kezelik. A teljes prezentációs fájl is BLOB kezelést igényel a betöltés vagy mentés során. Ezeket az objektumokat BLOB‑politikai szabályok irányítják, amelyek lehetővé teszik a memóriahasználat kezelését és az ideiglenes fájlokhoz való áthelyezést szükség esetén.

**Hol állítható be a BLOB kezelési szabályok a prezentáció betöltésekor?**

Használja a [LoadOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/) osztályt a [BlobManagementOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/blobmanagementoptions/) együtt. Itt állítható be a BLOB memóriahatára, engedélyezhető vagy letiltható az ideiglenes fájlok használata, kiválasztható az ideiglenes fájlok gyökérútvonala, valamint a forrászárolás viselkedése.

**Befolyásolják a BLOB beállítások a teljesítményt, és hogyan egyensúlyozhatom a sebességet a memóriaigénnyel?**

Igen. A BLOB memóriában tartása maximalizálja a sebességet, de növeli a RAM használatát; a memóriahatár csökkentésével több munka áttehető az ideiglenes fájlokra, ami csökkenti a RAM-ot, de további I/O költséggel jár. Állítsa be a [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/hu/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) küszöböt, hogy megfelelő egyensúlyt érjen el a terhelés és a környezet között.

**Segítenek a BLOB beállítások extrém nagy prezentációk (például gigabájtok) megnyitásakor?**

Igen. A [BlobManagementOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/blobmanagementoptions/) ilyen helyzetekre készült: az ideiglenes fájlok engedélyezése és a forrászárolás használata jelentősen csökkentheti a csúcs RAM használatot és stabilizálhatja a feldolgozást nagyon nagy prezentációk esetén.

**Használhatok BLOB szabályokat, ha a betöltés stream‑ekből, nem lemezfájlokból történik?**

Igen. Ugyanazok a szabályok vonatkoznak a streamekre is: a prezentáció példány birtokolhatja és zárolhatja a bemeneti streamet (a választott zárolási mód függvényében), és az ideiglenes fájlok használata engedélyezett esetben a memóriahasználat előre látható marad a feldolgozás során.