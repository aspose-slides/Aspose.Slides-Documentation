---
title: Conversión a XPS
type: docs
weight: 40
url: /es/net/conversion-to-xps/
---

**XPS** format also se usa mucho para el intercambio de datos. Aspose.Slides para .NET se ocupa de su importancia y proporciona soporte incorporado para convertir una presentación en un documento **XPS**.

El método **Save** expuesto por la clase Presentation puede usarse para convertir toda la presentación en un documento **XPS**. Además, la clase **XpsOptions** expone la propiedad **SaveMetafileAsPng**, que puede establecerse en true o false según sea necesario.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Saving the presentation to TIFF document

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Descargar código de ejemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)