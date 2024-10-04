---
title: Agregar marco de imagen a la presentación
type: docs
weight: 50
url: /net/add-picture-frame-to-presentation/
---

## **VSTO**
A continuación se muestra el código para agregar una imagen en una presentación de VSTO:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
Para agregar un marco de imagen simple a tu diapositiva, sigue los pasos a continuación:

1. Crea una instancia de la clase Presentation.
1. Obtén la referencia de una diapositiva usando su índice.
1. Crea un objeto Image añadiendo una imagen a la colección Images asociada con el objeto Presentation que se utilizará para rellenar la forma.
1. Calcula el ancho y la altura de la imagen.
1. Crea un PictureFrame de acuerdo con el ancho y la altura de la imagen utilizando el método AddPictureFrame expuesto por el objeto Shapes asociado con la diapositiva referenciada.
1. Agrega un marco de imagen (conteniendo la imagen) a la diapositiva.
1. Escribe la presentación modificada como un archivo PPTX.

Los pasos anteriores se implementan en el ejemplo dado a continuación.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Instanciar la clase Presentation que representa el PPTX

  Presentation pres = new Presentation();

  //Obtener la primera diapositiva

  ISlide sld = pres.Slides[0];

  //Instanciar la clase ImageEx

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Agregar marco de imagen con altura y ancho equivalentes a la imagen

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Descargar código en ejecución**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Descargar código de ejemplo**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Add Picture Frame/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)