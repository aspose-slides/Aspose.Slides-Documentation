---
title: Añadir marco de imagen a la presentación
type: docs
weight: 50
url: /es/net/add-picture-frame-to-presentation/
---

## **VSTO**
A continuación se muestra el código para añadir una imagen en una presentación VSTO:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
Para añadir un marco de imagen simple a su diapositiva, siga los pasos siguientes:

1. Cree una instancia de la clase Presentation.
1. Obtenga la referencia de una diapositiva usando su índice.
1. Cree un objeto Image añadiendo una imagen a la colección Images asociada al objeto Presentation que se utilizará para rellenar el Shape.
1. Calcule el ancho y la altura de la imagen.
1. Cree un PictureFrame según el ancho y la altura de la imagen usando el método AddPictureFrame expuesto por el objeto Shapes asociado a la diapositiva referenciada.
1. Añada un marco de imagen (que contiene la imagen) a la diapositiva.
1. Guarde la presentación modificada como un archivo PPTX.

Los pasos anteriores se implementan en el ejemplo que se muestra a continuación.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Instantiate Prseetation class that represents the PPTX

  Presentation pres = new Presentation();

  //Get the first slide

  ISlide sld = pres.Slides[0];

  //Instantiate the ImageEx class

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Add Picture Frame with height and width equivalent of Picture

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)