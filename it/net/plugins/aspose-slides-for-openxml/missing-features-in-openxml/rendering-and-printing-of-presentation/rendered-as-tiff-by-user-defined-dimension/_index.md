---
title: Renderizzato come TIFF con dimensione definita dall'utente
type: docs
weight: 40
url: /it/net/rendered-as-tiff-by-user-defined-dimension/
---
Il seguente esempio mostra come convertire una presentazione in un documento TIFF con dimensioni immagine personalizzate utilizzando la classe **TiffOptions**.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Istanzia un oggetto Presentation che rappresenta un file di presentazione

Presentation pres = new Presentation(srcFileName);

//Istanzia la classe TiffOptions

Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Impostazione del tipo di compressione

opts.CompressionType = TiffCompressionTypes.Default;

//Tipi di compressione

//Default - Specifica lo schema di compressione predefinito (LZW).

//None - Specifica nessuna compressione.

//CCITT3

//CCITT4

//LZW

//RLE

//Depth - dipende dal tipo di compressione e non può essere impostato manualmente.

//Resolution unit - è sempre uguale a "2" (punti per pollice)

//Impostazione DPI dell'immagine

opts.DpiX = 200;

opts.DpiY = 100;

//Imposta la dimensione dell'immagine

opts.ImageSize = new Size(1728, 1078);

//Save the presentation to TIFF with specified image size

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **Scarica il Codice di Esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)