---
title: Renderizado como Tiff con dimensiones definidas por el usuario
type: docs
weight: 40
url: /es/net/rendered-as-tiff-by-user-defined-dimension/
---
El siguiente ejemplo muestra cómo convertir una presentación en un documento TIFF con un tamaño de imagen personalizado mediante la clase **TiffOptions**.

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation(srcFileName);

//Instanciar la clase TiffOptions
Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Establecer el tipo de compresión
opts.CompressionType = TiffCompressionTypes.Default;

//Tipos de compresión
//Default - Especifica el esquema de compresión predeterminado (LZW).
//None - Especifica que no hay compresión.
//CCITT3
//CCITT4
//LZW
//RLE
//Depth - depende del tipo de compresión y no puede establecerse manualmente.
//Unidad de resolución - siempre es igual a "2" (puntos por pulgada)
//Establecer DPI de la imagen
opts.DpiX = 200;
opts.DpiY = 100;

//Establecer tamaño de la imagen
opts.ImageSize = new Size(1728, 1078);

//Guardar la presentación en TIFF con el tamaño de imagen especificado
pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);
``` 
## **Descargar código de ejemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)