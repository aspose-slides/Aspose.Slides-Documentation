---
title: Conversión a PDF
type: docs
weight: 30
url: /es/net/conversion-to-pdf/
---

Los documentos PDF se utilizan ampliamente como un formato estándar para intercambiar documentos entre organizaciones, sectores gubernamentales e individuos. Es un formato popular, por lo que a menudo se les pide a los desarrolladores que conviertan archivos de presentación de Microsoft PowerPoint a documentos PDF. Dándose cuenta de este posible requisito, Aspose.Slides para .NET admite la conversión de presentaciones a documentos PDF sin utilizar ningún otro componente.

**Aspose.Slides para .NET** ofrece la clase Presentation que representa un archivo de presentación. La clase **Presentation** expone el método Save que se puede llamar para convertir toda la presentación en un documento **PDF**. La clase **PdfOptions** proporciona opciones para crear el **PDF**, como JpegQuality, TextCompression, Compliance y otras. Estas opciones se pueden utilizar para obtener el estándar deseado de PDF.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Convirtiendo a PDF.pdf";

//Instanciar un objeto Presentation que representa un archivo de presentación

Presentation pres = new Presentation(srcFileName);

//Guardar la presentación en PDF con opciones predeterminadas

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Convirtiendo%20a%20PDF%20%28Aspose.Slides%29.zip)