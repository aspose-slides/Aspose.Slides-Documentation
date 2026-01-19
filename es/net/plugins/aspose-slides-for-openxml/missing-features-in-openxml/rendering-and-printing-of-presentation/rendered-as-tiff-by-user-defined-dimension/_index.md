---
title: Renderizado como Tiff con dimensión definida por el usuario
type: docs
weight: 40
url: /es/net/rendered-as-tiff-by-user-defined-dimension/
---

El siguiente ejemplo muestra cómo convertir una presentación en un documento TIFF con un tamaño de imagen personalizado utilizando la clase **TiffOptions**.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Instantiate a Presentation object that represents a Presentation file

Presentation pres = new Presentation(srcFileName);

//Instantiate the TiffOptions class

Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Setting compression type

opts.CompressionType = TiffCompressionTypes.Default;

//Compression Types

//Default - Specifies the default compression scheme (LZW).

//None - Specifies no compression.

//CCITT3

//CCITT4

//LZW

//RLE

//Depth - depends on the compression type and cannot be set manually.

//Resolution unit - is always equal to "2" (dots per inch)

//Setting image DPI

opts.DpiX = 200;

opts.DpiY = 100;

//Set Image Size

opts.ImageSize = new Size(1728, 1078);

//Save the presentation to TIFF with specified image size

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **Descargar código de ejemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)