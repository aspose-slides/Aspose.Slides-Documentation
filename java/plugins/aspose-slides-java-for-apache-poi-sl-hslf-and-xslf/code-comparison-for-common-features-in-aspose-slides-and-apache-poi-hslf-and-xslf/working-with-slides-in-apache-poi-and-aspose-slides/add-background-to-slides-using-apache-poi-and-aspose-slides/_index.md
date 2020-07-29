---
title: Add Background to Slides using Apache POI and Aspose.Slides
type: docs
weight: 10
url: /java/add-background-to-slides-using-apache-poi-and-aspose-slides/
---

## **Aspose.Slides - Add Background to Slides**
To use an image as the background of a slide using Aspose.Slides for Java, please follow the steps below:

- Create an instance of Presentation class
- Set the Background Type of the Slide to OwnBackground
- Set the FillType of the Slide Background FillFormat to Picture
- Set the PictureFillMode using the options provided by PictureFillMode enum
- Instantiate Image class with an image that can be used as source picture for the Slide Background using PictureFillFormat.Picture.Image
- Write the modified presentation file

**Java**

{{< highlight java >}}

 //Instantiate the Presentation class that represents the presentation file

Presentation pres = new Presentation();

//Set the background with Image

pres.getSlides().get_Item(0).getBackground().setType (BackgroundType.OwnBackground);

pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType ( FillType.Picture);

pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode( PictureFillMode.Stretch);

//Set the picture

IPPImage imgx =null;

imgx = pres.getImages().addImage(new FileInputStream(new File(dataDir + "background.jpg")));

//Image imgx = pres.getImages().addImage(image);

//Add image to presentation's images collection

pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage (imgx);

{{< /highlight >}}
## **Apache POI SL - HSLF XSLF - Add Background to Slides**
Below mentioned example shows how to add background image to slide using Apache POI SL.

**Java**

{{< highlight java >}}

 SlideMaster master = ppt.getSlidesMasters()[0];

Fill fill = master.getBackground().getFill();

int idx = ppt.addPicture(new File(dataDir + "background.jpg"), Picture.JPEG);

fill.setFillType(Fill.FILL_PICTURE);

fill.setPictureData(idx);

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/featurescomparison/slides/addbackground/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/slides/addbackground)

{{% alert color="primary" %}} 

For more details, visit [Setting the Image as Background to Slides](http://docs.aspose.com:8082/docs/display/slidesjava/Setting+the+Image+as+Background+to+Slides).

{{% /alert %}}
