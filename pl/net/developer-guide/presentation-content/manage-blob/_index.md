---
title: Zarządzanie BLOB-ami prezentacji w .NET dla efektywnego wykorzystania pamięci
linktitle: Zarządzaj BLOB
type: docs
weight: 10
url: /pl/net/manage-blob/
keywords:
- duży obiekt
- duży element
- duży plik
- dodaj BLOB
- eksportuj BLOB
- dodaj obraz jako BLOB
- zmniejsz pamięć
- zużycie pamięci
- duża prezentacja
- plik tymczasowy
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zarządzaj danymi BLOB w Aspose.Slides for .NET, aby usprawnić operacje na plikach PowerPoint i OpenDocument dla efektywnego obsługiwania prezentacji."
---
## **Przegląd**

Aspose.Slides zapewnia obsługę opartą na BLOB dla dużych danych binarnych w prezentacjach, aby pomóc zmniejszyć zużycie pamięci podczas pracy z dużymi obrazami, dźwiękiem, wideo i plikami prezentacji.

Ten artykuł pokazuje, jak używać przetwarzania opartego na BLOB do dodawania dużych mediów do prezentacji, eksportowania dużych mediów z prezentacji oraz ładowania dużych prezentacji bardziej efektywnie. Wyjaśnia również, jak pliki tymczasowe mogą być używane podczas przetwarzania oraz jak zmienić folder używany do ich przechowywania.

## **O BLOB**

**BLOB** (**Binary Large Object**) to zazwyczaj duży element (zdjęcie, prezentacja, dokument lub media) zapisywany w formacie binarnym.  

Aspose.Slides for .NET pozwala używać BLOB-ów dla obiektów w sposób, który zmniejsza zużycie pamięci, gdy zaangażowane są duże pliki.

## **Użyj BLOB, aby zmniejszyć zużycie pamięci**

### **Dodaj duży plik przy użyciu BLOB do prezentacji**

[Aspose.Slides](/slides/pl/net/) for .NET pozwala dodawać duże pliki (w tym przypadku duży plik wideo) przy użyciu procesu opartego na BLOB, aby zmniejszyć zużycie pamięci.

Ten kod C# pokazuje, jak dodać duży plik wideo przy użyciu procesu BLOB do prezentacji:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Tworzy nową prezentację, do której zostanie dodane wideo
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Dodajmy wideo do prezentacji - wybraliśmy zachowanie KeepLocked, ponieważ nie zamierzamy
        // uzyskać dostępu do pliku "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Zapisuje prezentację. Podczas tworzenia dużej prezentacji zużycie pamięci
        // pozostaje niskie przez cały cykl życia obiektu pres
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **Eksportuj duży plik przy użyciu BLOB z prezentacji**

Aspose.Slides for .NET pozwala eksportować duże pliki (w tym przypadku plik audio lub wideo) przy użyciu procesu opartego na BLOB z prezentacji. Na przykład możesz potrzebować wyodrębnić duży plik multimedialny z prezentacji, ale nie chcesz, aby plik był ładowany do pamięci komputera. Eksportując plik przy użyciu procesu BLOB, utrzymujesz niskie zużycie pamięci.  

Ten kod w C# demonstruje opisane działanie:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Blokuje plik źródłowy i NIE ładuje go do pamięci
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Tworzy instancję Presentation, blokując plik "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Zapiszmy każde wideo do pliku. Aby zapobiec dużemu zużyciu pamięci, potrzebny jest bufor, który będzie używany
	// do przeniesienia danych ze strumienia wideo prezentacji do strumienia nowo utworzonego pliku wideo.
	byte[] buffer = new byte[8 * 1024];

	// Iteruje po wideo
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Otwiera strumień wideo prezentacji. Proszę zauważyć, że celowo unikaliśmy dostępu do właściwości
		// takich jak video.BinaryData - ponieważ ta właściwość zwraca tablicę bajtów zawierającą pełne wideo, co
		// powoduje załadowanie bajtów do pamięci. Używamy video.GetStream, który zwróci Stream - i NIE
		//  nie wymaga od nas ładowania całego wideo do pamięci.
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

		// Zużycie pamięci pozostanie niskie niezależnie od rozmiaru wideo lub prezentacji,
	}

	// W razie potrzeby możesz zastosować te same kroki dla plików audio. 
}
```

### **Dodaj obraz jako BLOB do prezentacji**

Za pomocą metod z interfejsu [**IImageCollection**](https://reference.aspose.com/slides/pl/net/aspose.slides/iimagecollection) oraz klasy [**ImageCollection**](https://reference.aspose.com/slides/pl/net/aspose.slides/imagecollection) możesz dodać duży obraz jako strumień, aby został potraktowany jako BLOB.  

Ten kod C# pokazuje, jak dodać duży obraz przy użyciu procesu BLOB:

```c#
string pathToLargeImage = "large_image.jpg";

// tworzy nową prezentację, do której zostanie dodany obraz.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Dodajmy obraz do prezentacji - wybieramy zachowanie KeepLocked, ponieważ
		// NIE zamierzamy uzyskać dostępu do pliku "largeImage.png" file.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Zapisuje prezentację. Podczas tworzenia dużej prezentacji zużycie pamięci 
		// pozostaje niskie przez cały cykl życia obiektu pres
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **Pamięć i duże prezentacje**

Typowo, aby załadować dużą prezentację, komputery wymagają dużo pamięci tymczasowej. Cała zawartość prezentacji jest ładowana do pamięci, a plik (z którego prezentacja została załadowana) przestaje być używany.  

Rozważ dużą prezentację PowerPoint (large.pptx), która zawiera plik wideo o rozmiarze 1,5 GB. Standardowa metoda ładowania prezentacji jest opisana w tym kodzie C#:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

Jednak metoda ta zużywa około 1,6 GB pamięci tymczasowej.  

### **Załaduj dużą prezentację jako BLOB**

Poprzez proces wykorzystujący BLOB możesz załadować dużą prezentację przy minimalnym zużyciu pamięci. Ten kod C# opisuje implementację, w której proces BLOB jest używany do ładowania dużego pliku prezentacji (large.pptx):

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

### **Zmień folder plików tymczasowych**

Gdy proces BLOB jest używany, komputer tworzy pliki tymczasowe w domyślnym folderze plików tymczasowych. Jeśli chcesz, aby pliki tymczasowe były przechowywane w innym folderze, możesz zmienić ustawienia przechowywania za pomocą `TempFilesRootPath`:

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
Gdy używasz `TempFilesRootPath`, Aspose.Slides nie tworzy automatycznie folderu do przechowywania plików tymczasowych. Musisz utworzyć folder ręcznie. 
{{% /alert %}}

### **Zwolnij obiekty Presentation, aby zwolnić pamięć**

Podczas przetwarzania dużych prezentacji upewnij się, że instancja [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) jest prawidłowo zwalniana, aby uwolnić zajętą pamięć. Zalecanym sposobem jest użycie instrukcji `using` lub deklaracji, jak pokazano w powyższych przykładach; automatycznie zwalnia prezentację i zwalnia zasoby niezarządzane po wyjściu z bloku.  

Jeśli utworzysz prezentację bez bloku `using`, wywołaj explicite `Dispose()` po zakończeniu jej używania.

```cs
Presentation presentation = new Presentation("large.pptx");

// ...przetwarzaj prezentację...
presentation.Save("large.pdf", SaveFormat.Pdf);

// Jawnie zwolnij zasoby.
presentation.Dispose();
```

## **FAQ**

**Jakie dane w prezentacji Aspose.Slides są traktowane jako BLOB i kontrolowane przez opcje BLOB?**  
Duże obiekty binarne, takie jak obrazy, audio i wideo, są traktowane jako BLOB. Cały plik prezentacji również podlega obsłudze BLOB podczas ładowania lub zapisywania. Obiekty te są zarządzane przez polityki BLOB, które pozwalają kontrolować użycie pamięci i przenoszenie danych do plików tymczasowych w razie potrzeby.  

**Gdzie konfigurować reguły obsługi BLOB podczas ładowania prezentacji?**  
Użyj [LoadOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/) z [BlobManagementOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/blobmanagementoptions/). Tam ustawiasz limit pamięci w RAM dla BLOB, zezwalasz lub blokujesz pliki tymczasowe, wybierasz ścieżkę główną dla plików tymczasowych oraz określasz zachowanie blokowania źródła.  

**Czy ustawienia BLOB wpływają na wydajność i jak zbalansować szybkość względem pamięci?**  
Tak. Trzymanie BLOB w pamięci maksymalizuje szybkość, ale zwiększa zużycie RAM; obniżenie limitu pamięci przenosi więcej pracy do plików tymczasowych, zmniejszając RAM kosztem dodatkowego I/O. Dostosuj próg [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/pl/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/), aby uzyskać właściwą równowagę dla swojego obciążenia i środowiska.  

**Czy opcje BLOB pomagają przy otwieraniu niezwykle dużych prezentacji (np. gigabajtowych)?**  
Tak. [BlobManagementOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/blobmanagementoptions/) są zaprojektowane dla takich scenariuszy: włączenie plików tymczasowych i użycie blokowania źródła może znacząco zmniejszyć szczytowe zużycie RAM i ustabilizować przetwarzanie bardzo dużych prezentacji.  

**Czy mogę używać polityk BLOB przy ładowaniu ze strumieni zamiast z plików dyskowych?**  
Tak. Te same reguły dotyczą strumieni: instancja prezentacji może posiadać i blokować strumień wejściowy (w zależności od wybranego trybu blokowania), a pliki tymczasowe są używane, gdy są dozwolone, utrzymując przewidywalne użycie pamięci podczas przetwarzania.