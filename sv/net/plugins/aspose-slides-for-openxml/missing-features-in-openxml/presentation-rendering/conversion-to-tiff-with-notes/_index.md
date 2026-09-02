---
title: Konvertering till Tiff med anteckningar
type: docs
weight: 10
url: /sv/net/conversion-to-tiff-with-notes/
---
TIFF är ett av flera allmänt använda bildformat som Aspose.Slides för .NET stöder för att konvertera en presentation med anteckningar till bilder. Du kan också skapa bildminiatyrer i Notesslidesvyn. Nedan finns två kodexempel som visar hur du genererar TIFF‑bilder av en presentation i Notesslidesvyn.

Metoden **Save** som exponeras av klassen **Presentation** kan användas för att konvertera hela presentationen i Notesslidesvyn till TIFF. Du kan också skapa en bildminiatyr i Notesslidesvyn för enskilda bilder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//Instansiera ett Presentation-objekt som representerar en presentationsfil
using (Presentation pres = new Presentation(srcFileName))
{
        //Placera talarnoterna under varje renderad bild
        TiffOptions tiffOptions = new TiffOptions();
        tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull
        };

        //Spara presentationen till TIFF med anteckningar
        pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **Ladda ner exempel på kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)