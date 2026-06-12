---
title: Beheer BLOBs van presentaties in .NET voor efficiënt geheugengebruik
linktitle: Beheer BLOB
type: docs
weight: 10
url: /nl/net/manage-blob/
keywords:
- groot object
- groot item
- groot bestand
- BLOB toevoegen
- BLOB exporteren
- afbeelding toevoegen als BLOB
- geheugen verminderen
- geheugenverbruik
- grote presentatie
- tijdelijk bestand
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer BLOB-gegevens in Aspose.Slides voor .NET om PowerPoint- en OpenDocument-bestanden efficiënter te verwerken."
---
## **Overzicht**

Aspose.Slides biedt BLOB‑gebaseerde verwerking voor grote binaire gegevens in presentaties om het geheugenverbruik te verminderen bij het werken met grote afbeeldingen, audio, video en presentatie‑bestanden.

Dit artikel laat zien hoe u BLOB‑gebaseerde verwerking gebruikt om grote media toe te voegen aan een presentatie, grote media uit een presentatie te exporteren en grote presentaties efficiënter te laden. Het legt ook uit hoe tijdelijke bestanden kunnen worden gebruikt tijdens de verwerking en hoe u de map kunt wijzigen waarin ze worden opgeslagen.

## **Over BLOB**

**BLOB** (**Binary Large Object**) is meestal een groot element (foto, presentatie, document of media) dat in binair formaat is opgeslagen.

Aspose.Slides for .NET stelt u in staat BLOB’s te gebruiken voor objecten op een manier die het geheugenverbruik verlaagt wanneer er grote bestanden betrokken zijn.

## **BLOB gebruiken om geheugenverbruik te verminderen**

### **Een groot bestand via BLOB toevoegen aan een presentatie**

[Aspose.Slides](/slides/nl/net/) for .NET stelt u in staat grote bestanden (in dit geval een groot videobestand) toe te voegen via een proces dat BLOB’s gebruikt om het geheugenverbruik te verminderen.

Deze C#‑code laat zien hoe u een groot videobestand via het BLOB‑proces toevoegt aan een presentatie:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Maakt een nieuwe presentatie waaraan de video wordt toegevoegd
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Laten we de video aan de presentatie toevoegen - we kozen het KeepLocked-gedrag omdat we
        //niet van plan zijn het bestand "veryLargeVideo.avi" te openen.
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Slaat de presentatie op. Terwijl een grote presentatie wordt weggeschreven, het geheugenverbruik
        // blijft laag gedurende de levensduur van het pres-object 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **Een groot bestand via BLOB exporteren uit een presentatie**

Aspose.Slides for .NET stelt u in staat grote bestanden (bijvoorbeeld een audio‑ of videobestand) via een BLOB‑proces te exporteren uit presentaties.  
U wilt bijvoorbeeld een groot mediabestand uit een presentatie halen zonder dat het bestand in het geheugen van uw computer wordt geladen. Door het bestand via het BLOB‑proces te exporteren houdt u het geheugenverbruik laag.

Deze C#‑code demonstreert de beschreven bewerking:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Vergrendelt het bronbestand en laadt het NIET in het geheugen
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Maakt een instantie van Presentation, vergrendelt het bestand "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Laten we elke video naar een bestand opslaan. Om hoog geheugenverbruik te voorkomen, hebben we een buffer nodig die zal worden gebruikt
	// om de gegevens van de videostream van de presentatie over te dragen naar een stream voor een nieuw aangemaakt videobestand.
	byte[] buffer = new byte[8 * 1024];

	// Iterates through the videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Opent de video‑stream van de presentatie. Merk op dat we opzettelijk vermijden eigenschappen te benaderen
		// zoals video.BinaryData - omdat deze eigenschap een byte‑array retourneert die de volledige video bevat, wat dan
		// bytes in het geheugen laadt. We gebruiken video.GetStream, dat een Stream retourneert - en LAADT NIET
		//  ons vereist om de volledige video in het geheugen te laden.
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

		// Geheugenverbruik blijft laag ongeacht de grootte van de video of presentatie,
	}

	// Indien nodig kun je dezelfde stappen toepassen voor audiobestanden. 
}
```

### **Een afbeelding als BLOB toevoegen aan een presentatie**

Met methoden van de [**IImageCollection**](https://reference.aspose.com/slides/nl/net/aspose.slides/iimagecollection) interface en de [**ImageCollection**](https://reference.aspose.com/slides/nl/net/aspose.slides/imagecollection)‑klasse kunt u een grote afbeelding als stream toevoegen zodat deze als BLOB wordt behandeld.

Deze C#‑code laat zien hoe u een grote afbeelding via het BLOB‑proces toevoegt:

```c#
string pathToLargeImage = "large_image.jpg";

// maakt een nieuwe presentatie waaraan de afbeelding wordt toegevoegd.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Laten we de afbeelding aan de presentatie toevoegen - we kiezen het KeepLocked-gedrag omdat we
		// NIET van plan zijn het "largeImage.png" bestand te openen.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Slaat de presentatie op. Terwijl een grote presentatie wordt weggeschreven, het geheugenverbruik 
		// blijft laag gedurende de levensduur van het pres-object
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **Geheugen en grote presentaties**

Doorgaans hebben computers veel tijdelijk geheugen nodig om een grote presentatie te laden. De volledige inhoud van de presentatie wordt in het geheugen geladen en het bestand (waaruit de presentatie is geladen) wordt niet meer gebruikt.

Beschouw een grote PowerPoint‑presentatie (large.pptx) die een video‑bestand van 1,5 GB bevat. De standaardmethode om de presentatie te laden wordt getoond in deze C#‑code:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

Maar deze methode verbruikt ongeveer 1,6 GB tijdelijk geheugen.

### **Een grote presentatie laden als BLOB**

Via een proces dat een BLOB gebruikt, kunt u een grote presentatie laden terwijl u weinig geheugen gebruikt. Deze C#‑code beschrijft de implementatie waarbij het BLOB‑proces wordt gebruikt om een groot presentatie‑bestand (large.pptx) te laden:

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

### **De map voor tijdelijke bestanden wijzigen**

Wanneer het BLOB‑proces wordt gebruikt, maakt uw computer tijdelijke bestanden aan in de standaardmap voor tijdelijke bestanden. Als u de tijdelijke bestanden in een andere map wilt opslaan, kunt u de opslaginstelling aanpassen met `TempFilesRootPath`:

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

Wanneer u `TempFilesRootPath` gebruikt, maakt Aspose.Slides niet automatisch een map aan om tijdelijke bestanden op te slaan. U moet de map handmatig aanmaken.

{{% /alert %}}

### **Presentatie‑objecten vrijgeven om geheugen te herstellen**

Bij het verwerken van grote presentaties moet u ervoor zorgen dat de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑instance correct wordt vrijgegeven zodat het gebruikte geheugen wordt vrijgemaakt. De aanbevolen manier is een `using`‑statement of –declaratie te gebruiken, zoals in de voorbeelden hierboven; dit zet de presentatie automatisch op de juiste manier vrij en maakt onbeheerde bronnen vrij wanneer het blok wordt verlaten.

Als u een presentatie maakt zonder een `using`‑blok, roep dan expliciet `Dispose()` aan nadat u klaar bent met het gebruik ervan.

```cs
Presentation presentation = new Presentation("large.pptx");

// ...verwerk de presentatie...
presentation.Save("large.pdf", SaveFormat.Pdf);

// Expliciet resources vrijgeven.
presentation.Dispose();
```

## **FAQ**

**Welke gegevens in een Aspose.Slides‑presentatie worden behandeld als BLOB en beheerd door BLOB‑opties?**

Grote binaire objecten zoals afbeeldingen, audio en video worden behandeld als BLOB. Het volledige presentatiedocument zelf maakt ook gebruik van BLOB‑verwerking bij het laden of opslaan. Deze objecten vallen onder BLOB‑beleid dat u in staat stelt het geheugenverbruik te beheren en, indien nodig, te spillen naar tijdelijke bestanden.

**Waar kan ik BLOB‑verwerkingsregels configureren tijdens het laden van een presentatie?**

Gebruik [LoadOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/) met [BlobManagementOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/blobmanagementoptions/). Daar stelt u de limiet voor het geheugen dat BLOB‑objecten mogen gebruiken, schakelt u tijdelijke bestanden in of uit, kiest u de hoofdmap voor tijdelijke bestanden en bepaalt u het gedrag van bron‑vergrendeling.

**Beïnvloeden BLOB‑instellingen de prestaties, en hoe vind ik de juiste balans tussen snelheid en geheugen?**

Ja. BLOB‑objecten volledig in het geheugen houden maximaliseert de snelheid maar verhoogt het RAM‑verbruik; een lagere geheugenlimiet verplaatst meer werk naar tijdelijke bestanden, waardoor RAM wordt bespaard ten koste van extra I/O. Pas de drempelwaarde van [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/nl/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) aan om de juiste balans voor uw workload en omgeving te bereiken.

**Helpen BLOB‑opties bij het openen van extreem grote presentaties (bijv. gigabytes)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/blobmanagementoptions/) zijn ontworpen voor zulke scenario’s: het inschakelen van tijdelijke bestanden en het gebruiken van bron‑vergrendeling kan het piek‑RAM‑verbruik aanzienlijk verminderen en de verwerking stabiliseren voor zeer grote decks.

**Kan ik BLOB‑beleid gebruiken bij het laden vanuit streams in plaats van bestandssystemen?**

Ja. Dezelfde regels gelden voor streams: de presentatie‑instance kan de invoer‑stream bezitten en vergrendelen (afhankelijk van de gekozen vergrendelingsmodus), en tijdelijke bestanden worden gebruikt wanneer dit is toegestaan, waardoor het geheugenverbruik voorspelbaar blijft tijdens de verwerking.