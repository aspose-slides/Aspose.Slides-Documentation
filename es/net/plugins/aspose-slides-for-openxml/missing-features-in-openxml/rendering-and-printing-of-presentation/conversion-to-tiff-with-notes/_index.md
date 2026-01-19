---
title: Conversión a Tiff con notas
type: docs
weight: 10
url: /es/net/conversion-to-tiff-with-notes/
---

TIFF es uno de varios formatos de imagen ampliamente utilizados que Aspose.Slides para .NET admite para convertir una presentación con notas a imágenes. También puede generar miniaturas de diapositivas en la vista de diapositiva de notas. A continuación se muestran dos fragmentos de código que demuestran cómo generar imágenes TIFF de una presentación en la vista de diapositiva de notas.

El método **Save** expuesto por la clase **Presentation** se puede utilizar para convertir toda la presentación en la vista de diapositiva de notas a TIFF. También puede generar una miniatura de diapositiva en la vista de diapositiva de notas para diapositivas individuales.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Saving the presentation to TIFF notes

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **Descargar código de ejemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)