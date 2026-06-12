---
title: Conversione in Tiff con Note
type: docs
weight: 10
url: /it/net/conversion-to-tiff-with-notes/
---
TIFF è uno dei diversi formati immagine ampiamente usati che Aspose.Slides per .NET supporta per convertire una presentazione con note in immagini. È inoltre possibile generare miniature delle diapositive nella visualizzazione Note diapositiva. Di seguito sono riportati due frammenti di codice che mostrano come generare immagini TIFF di una presentazione nella visualizzazione Note diapositiva.

Il metodo **Save** esposto dalla classe **Presentation** può essere usato per convertire l'intera presentazione nella visualizzazione Note diapositiva in TIFF. È anche possibile generare una miniatura di diapositiva nella visualizzazione Note diapositiva per singole diapositive.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Istanziare un oggetto Presentation che rappresenta un file di presentazione

Presentation pres = new Presentation(srcFileName);

//Salvataggio della presentazione in note TIFF

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **Scarica il codice di esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)