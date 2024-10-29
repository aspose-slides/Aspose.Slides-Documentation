---
title: Renderizado como Tiff
type: docs
weight: 30
url: /es/net/rendered-as-tiff/
---

El formato TIFF es conocido por su flexibilidad para acomodar imágenes y datos de múltiples páginas. Teniendo en cuenta la importancia y popularidad del formato TIFF, Aspose.Slides para .NET proporciona soporte para convertir presentaciones en documentos TIFF.
Este artículo explica cómo diferentes opciones de exportación a tiff:

- Convertir presentación a TIFF con tamaño por defecto.
- Convertir presentación a TIFF con tamaño personalizado.

El método **Save** expuesto por la clase **Presentation** puede ser llamado por los desarrolladores para convertir toda la presentación en un documento **TIFF**. Además, la clase TiffOptions expone la propiedad ImageSize que permite al desarrollador definir el tamaño de la imagen si es necesario.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversión a Tiff.tiff";

// Instanciar un objeto Presentation que representa un archivo de presentación

using (Presentation pres = new Presentation(srcFileName))

{

    // Guardar la presentación en un documento TIFF

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}

``` 
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)