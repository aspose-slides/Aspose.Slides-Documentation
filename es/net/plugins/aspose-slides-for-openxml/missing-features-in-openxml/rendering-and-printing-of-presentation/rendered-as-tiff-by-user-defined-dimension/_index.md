---
title: Renderizado Como Tiff Por Dimensión Definida Por El Usuario
type: docs
weight: 40
url: /es/net/rendered-as-tiff-by-user-defined-dimension/
---

El siguiente ejemplo muestra cómo convertir una presentación en un documento TIFF con un tamaño de imagen personalizado utilizando la clase **TiffOptions**.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Instanciar un objeto Presentation que representa un archivo de Presentación

Presentation pres = new Presentation(srcFileName);

//Instanciar la clase TiffOptions

Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Establecer el tipo de compresión

opts.CompressionType = TiffCompressionTypes.Default;

//Tipos de Compresión

//Default - Especifica el esquema de compresión predeterminado (LZW).

//None - Especifica sin compresión.

//CCITT3

//CCITT4

//LZW

//RLE

//Depth - depende del tipo de compresión y no se puede establecer manualmente.

//Unidad de resolución - siempre es igual a "2" (puntos por pulgada)

//Establecer DPI de imagen

opts.DpiX = 200;

opts.DpiY = 100;

//Establecer tamaño de imagen

opts.ImageSize = new Size(1728, 1078);

//Guardar la presentación como TIFF con el tamaño de imagen especificado

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)