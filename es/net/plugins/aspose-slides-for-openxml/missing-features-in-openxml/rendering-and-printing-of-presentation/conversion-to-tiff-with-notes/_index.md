---
title: Conversión a Tiff con Notas
type: docs
weight: 10
url: /net/conversion-to-tiff-with-notes/
---

TIFF es uno de varios formatos de imagen ampliamente utilizados que Aspose.Slides para .NET soporta para convertir una presentación con notas a imágenes. También puedes generar miniaturas de diapositivas en la vista de Diapositivas de Notas. A continuación se presentan dos fragmentos de código que muestran cómo generar imágenes TIFF de una presentación en la vista de Diapositivas de Notas.

El método **Save** expuesto por la clase **Presentation** se puede utilizar para convertir toda la presentación en la vista de Diapositivas de Notas a TIFF. También puedes generar una miniatura de diapositiva en la vista de Diapositivas de Notas para diapositivas individuales.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversión a Tiff con nota.pptx";

string destFileName = FilePath + "Conversión a Tiff con nota.tiff";

//Instanciar un objeto Presentation que representa un archivo de presentación

Presentation pres = new Presentation(srcFileName);

//Guardar la presentación a TIFF notas

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)