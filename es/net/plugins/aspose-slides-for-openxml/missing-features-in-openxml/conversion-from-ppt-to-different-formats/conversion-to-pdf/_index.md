---
title: Conversión a PDF
type: docs
weight: 30
url: /es/net/conversion-to-pdf/
---

Los documentos PDF se utilizan ampliamente como formato estándar para el intercambio de documentos entre organizaciones, sectores gubernamentales y particulares. Es un formato popular, por lo que a menudo se pide a los desarrolladores que conviertan archivos de presentaciones de Microsoft PowerPoint a documentos PDF. Conscientes de este posible requisito, Aspose.Slides for .NET admite la conversión de presentaciones a documentos PDF sin utilizar ningún otro componente.

**Aspose.Slides for .NET** ofrece la clase Presentation que representa un archivo de presentación. La clase **Presentation** expone el método Save que puede llamarse para convertir toda la presentación en un documento **PDF**. La clase **PdfOptions** proporciona opciones para crear el **PDF**, como JpegQuality, TextCompression, Compliance y otras. Estas opciones pueden usarse para obtener el estándar deseado de PDF.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Save the presentation to PDF with default options

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **Descargar código de ejemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)