---
title: Conversione in Tiff con Note
type: docs
weight: 10
url: /it/net/conversion-to-tiff-with-notes/
---
TIFF è uno dei diversi formati immagine ampiamente utilizzati che Aspose.Slides per .NET supporta per convertire una presentazione con note in immagini. È inoltre possibile generare miniature delle diapositive nella visualizzazione Note Slide. Di seguito sono riportati due snippet di codice che mostrano come generare immagini TIFF di una presentazione nella visualizzazione Note Slide.

Il metodo **Save** esposto dalla classe **Presentation** può essere utilizzato per convertire l'intera presentazione nella visualizzazione Note Slide in TIFF. È inoltre possibile generare una miniatura della diapositiva nella visualizzazione Note Slide per singole diapositive.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//Istanziare un oggetto Presentation che rappresenta un file di presentazione
using (Presentation pres = new Presentation(srcFileName))
{
    //Posizionare le note del relatore sotto ogni diapositiva renderizzata
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //Salvare la presentazione in TIFF con le note
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **Scarica Codice di Esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)