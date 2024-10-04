---
title: Conversión a XPS
type: docs
weight: 40
url: /net/conversion-to-xps/
---

El formato **XPS** también se utiliza ampliamente para el intercambio de datos. Aspose.Slides para .NET reconoce su importancia y proporciona soporte incorporado para convertir una presentación en un documento XPS.

El método **Save** expuesto por la clase Presentation se puede utilizar para convertir toda la presentación en un documento **XPS**. Además, la clase **XpsOptions** expone la propiedad **SaveMetafileAsPng** que se puede establecer en verdadero o falso según sea necesario.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Convirtiendo a XPS.xps";

//Instanciar un objeto Presentation que representa un archivo de presentación

Presentation pres = new Presentation(srcFileName);

//Guardar la presentación en un documento TIFF

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Convirtiendo%20a%20XPS%20%28Aspose.Slides%29.zip)