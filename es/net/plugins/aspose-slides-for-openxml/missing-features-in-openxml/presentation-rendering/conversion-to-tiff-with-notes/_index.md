---
title: Conversión a Tiff con notas
type: docs
weight: 10
url: /es/net/conversion-to-tiff-with-notes/
---
TIFF es uno de varios formatos de imagen ampliamente utilizados que Aspose.Slides para .NET admite para convertir una presentación con notas a imágenes. También puede generar miniaturas de diapositivas en la vista de diapositiva de notas. A continuación se muestran dos fragmentos de código que demuestran cómo generar imágenes TIFF de una presentación en la vista de diapositiva de notas.

El método **Save** expuesto por la clase **Presentation** puede usarse para convertir toda la presentación en la vista de diapositiva de notas a TIFF. También puede generar una miniatura de diapositiva en la vista de diapositiva de notas para diapositivas individuales.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//Instanciar un objeto Presentation que representa un archivo de presentación
using (Presentation pres = new Presentation(srcFileName))
{
    //Colocar las notas del ponente bajo cada diapositiva renderizada
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //Guardar la presentación en TIFF con notas
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **Descargar código de ejemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)