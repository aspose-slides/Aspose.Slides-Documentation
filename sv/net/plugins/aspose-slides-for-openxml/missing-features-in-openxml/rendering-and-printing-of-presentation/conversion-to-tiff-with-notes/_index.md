---
title: Konvertering till Tiff med anteckningar
type: docs
weight: 10
url: /sv/net/conversion-to-tiff-with-notes/
---
TIFF är ett av flera ofta använda bildformat som Aspose.Slides för .NET stöder för att konvertera en presentation med anteckningar till bilder. Du kan också skapa miniatyrer av bilder i vyn Noteringsbild. Nedan visas två kodavsnitt som visar hur man genererar TIFF‑bilder av en presentation i Noteringsbild‑vyn.

Metoden **Save** som exponeras av klassen **Presentation** kan användas för att konvertera hela presentationen i vyn Noteringsbild till TIFF. Du kan också skapa en bildminiatyr i vyn Noteringsbild för enskilda bilder.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Instansiera ett Presentation-objekt som representerar en presentationsfil

Presentation pres = new Presentation(srcFileName);

//Sparar presentationen till TIFF-anteckningar

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **Ladda ner exempel kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)