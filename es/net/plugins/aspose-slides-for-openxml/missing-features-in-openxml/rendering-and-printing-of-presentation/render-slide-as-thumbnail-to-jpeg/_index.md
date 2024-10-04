---
title: Renderizar Diapositiva como Miniatura a JPEG
type: docs
weight: 60
url: /net/render-slide-as-thumbnail-to-jpeg/
---

**Aspose.Slides para .NET** se utiliza para crear archivos de presentación que contienen diapositivas. Estas diapositivas se pueden ver abriendo archivos de presentación con Microsoft PowerPoint. Pero a veces, los desarrolladores pueden necesitar ver diapositivas como imágenes usando su visor de imágenes favorito. En tales casos, Aspose.Slides para .NET te ayuda a generar imágenes en miniatura de las diapositivas.

Para generar la miniatura de cualquier diapositiva deseada usando Aspose.Slides para .NET:

1. Crea una instancia de la clase **Presentation**.
1. Obtén la referencia de cualquier diapositiva deseada utilizando su ID o índice.
1. Obtén la imagen en miniatura de la diapositiva referenciada en una escala especificada.
1. Guarda la imagen en miniatura en cualquier formato de imagen deseado.

``` csharp
string filePath = @"..\..\..\Sample Files\"; 
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx"; 
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg"; 

//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation(srcFileName)) 
{ 
    //Access the first slide 
    ISlide sld = pres.Slides[0]; 

    //Create a full scale image 
    using (IImage image = sld.GetImage(1f, 1f)) 
    { 
        //Save the image to disk in JPEG format 
        image.Save(destFileName, ImageFormat.Jpeg); 
    } 
} 
```

## **Descargar Código de Ejemplo**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)