---
title: Add Picture Frame to Presentation
type: docs
weight: 50
url: /net/add-picture-frame-to-presentation/
---

## **VSTO**
Below is the code for adding picture in VSTO presentation:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
To add a simple picture frame to your slide, please follow the steps below:

1. Create an instance of the Presentation class.
1. Obtain the reference of a slide by using its index.
1. Create an Image object by adding an image to the Images collection associated with the Presentation object that will be used to fill the Shape.
1. Calculate the width and height of the image.
1. Create a PictureFrame according to the width and height of the image by using the AddPictureFrame method exposed by the Shapes object associated with the referenced slide.
1. Add a picture frame (containing the picture) to the slide.
1. Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Instantiate Prseetation class that represents the PPTX

  Presentation pres = new Presentation();

  //Get the first slide

  ISlide sld = pres.Slides[0];

  //Instantiate the ImageEx class

  Image img = (Image)new Bitmap(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Add Picture Frame with height and width equivalent of Picture

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Download Running Code**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Add Picture Frame/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)
