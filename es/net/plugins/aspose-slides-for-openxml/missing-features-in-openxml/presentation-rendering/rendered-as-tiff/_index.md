---
title: Renderizado como Tiff
type: docs
weight: 30
url: /es/net/rendered-as-tiff/
---
El formato TIFF es conocido por su flexibilidad para admitir imágenes y datos multipágina. Teniendo en cuenta la importancia y popularidad del formato TIFF, Aspose.Slides for .NET ofrece soporte para convertir presentaciones en documentos TIFF.
Este artículo explica las diferentes opciones de exportación a TIFF:

- Convertir la presentación a TIFF con tamaño predeterminado.
- Convertir la presentación a TIFF con tamaño personalizado.

El método **Save** expuesto por la clase **Presentation** puede ser llamado por los desarrolladores para convertir toda la presentación en un documento **TIFF**. Además, la clase TiffOptions expone la propiedad ImageSize que permite al desarrollador definir el tamaño de la imagen si es necesario.

``` csharp
using Aspose.Slides;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Instanciar un objeto Presentation que representa un archivo de presentación

using (Presentation pres = new Presentation(srcFileName))

{
    //Guardando la presentación en documento TIFF
    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);
}
``` 
## **Descargar código de ejemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)