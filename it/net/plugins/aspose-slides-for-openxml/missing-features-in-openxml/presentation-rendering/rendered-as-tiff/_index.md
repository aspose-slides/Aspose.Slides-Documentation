---
title: Renderizzato come Tiff
type: docs
weight: 30
url: /it/net/rendered-as-tiff/
---
Il formato TIFF è noto per la sua flessibilità nel gestire immagini e dati multipagina. Tenendo presente l'importanza e la popolarità del formato TIFF, Aspose.Slides per .NET offre il supporto per la conversione delle presentazioni in documento TIFF.
Questo articolo spiega le diverse opzioni di esportazione TIFF:

- Conversione della presentazione in TIFF con dimensione predefinita.
- Conversione della presentazione in TIFF con dimensione personalizzata.

Il metodo **Save** esposto dalla classe **Presentation** può essere chiamato dagli sviluppatori per convertire l'intera presentazione in documento **TIFF**. Inoltre, la classe TiffOptions espone la proprietà ImageSize che consente allo sviluppatore di definire la dimensione dell'immagine, se necessario.

``` csharp
using Aspose.Slides;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Istanziare un oggetto Presentation che rappresenta un file di presentazione

using (Presentation pres = new Presentation(srcFileName))

{

    //Salvare la presentazione in un documento TIFF

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}
``` 
## **Scarica Codice di Esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)