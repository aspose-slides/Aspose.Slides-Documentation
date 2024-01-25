---
title: Extracting Images from Presentation shapes
type: docs
weight: 100
url: /java/extracting-images-from-presentation-shapes/
keywords: "Extract image, PowerPoint, PPT, PPTX, PowerPoint presentation, Java, Aspose.Slides for Java"
description: "Extract images from PowerPoint presentation in Java"

---

{{% alert color="primary" %}} 

Images are often added to shapes and also frequently used as slides' backgrounds. The image objects are added through [IImageCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/), which is a collection of [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) objects. 

This article explains how you can extract the images added to presentations. 

{{% /alert %}} 

To extract an image from a presentation, you have to locate the image first by going through every slide and then going through every shape. Once the image is found or identified, you can extract it and save it as a new file. 

```java

String path = "D:\\Aspose Data\\";
//Accesses the presentation
Presentation pres = new Presentation(path + "ExtractImages.pptx");
com.aspose.slides.IPPImage img = null;
com.aspose.slides.IPPImage Backimg = null;
 
int slideIndex = 0;
String ImageType = "";
boolean ifImageFound = false;
for (int i = 0; i < pres.getSlides().size(); i++)
{
 
slideIndex++;
//Accesses the first slide
ISlide sl = pres.getSlides().get_Item(i);
 
 
//Accesses the first slide Slide sl = pres.getSlideByPosition(i);
if (sl.getBackground().getFillFormat().getFillType() == FillType.Picture)
{
    //Gets the back picture  
    Backimg = sl.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
 
    //Saves the picture 
    BufferedImage image=Backimg.getSystemImage(); 
 
    ImageType = Backimg.getContentType();
    //ImageType = ImageType.s.substring(0, ImageType.indexOf("/") + 1);
ImageType = ImageType.substring(ImageType.indexOf("/") + 1,ImageType.length());
 
      String ImagePath = path + "BackImage_";
    try {
        ImageIO.write(image,ImageType, new File(ImagePath + "Slide_" + slideIndex+ "." +ImageType.toString()));
        //Sets the preferred image format 
    } catch (IOException ex) {
        Logger.getLogger(NewAPi.class.getName()).log(Level.SEVERE, null, ex);
    }
 
}
else
{
    if (sl.getLayoutSlide().getBackground().getFillFormat().getFillType() == FillType.Picture)
    {
        //Gets the back picture  
        Backimg = sl.getLayoutSlide().getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
 
        BufferedImage image=Backimg.getSystemImage(); 
 
        ImageType = Backimg.getContentType();
        ImageType = ImageType.substring(ImageType.indexOf("/") + 1,ImageType.length());
 
          String ImagePath = path + "BackImage_";
        try {
            ImageIO.write(image,ImageType, new File(ImagePath + "LayoutSlide_" + slideIndex+ "." +ImageType.toString()));
            //Sets the preferred picture format 
        } catch (IOException ex) {
            Logger.getLogger(NewAPi.class.getName()).log(Level.SEVERE, null, ex);
        }
 
        }
    }
 
for (int j = 0; j < sl.getShapes().size(); j++)
{
    // Accesses the shape containing an image
    IShape sh = sl.getShapes().get_Item(j);
 
    if (sh instanceof IAutoShape)
    {
        IAutoShape ashp = (IAutoShape)sh;
        if (ashp.getFillFormat().getFillType() == FillType.Picture)
        {
            img = ashp.getFillFormat().getPictureFillFormat().getPicture().getImage();
            ImageType = img.getContentType();
            ImageType = ImageType.substring(0, ImageType.indexOf("/") + 1);
            ifImageFound = true;
        }
    }
 
    else if (sh instanceof IPictureFrame)
    {
        IPictureFrame pf = (IPictureFrame)sh;
       // if (pf.getFillFormat().getFillType() == FillType.Picture)
        {
            img = pf.getPictureFormat().getPicture().getImage();
            ImageType = img.getContentType();
ImageType = ImageType.substring(ImageType.indexOf("/") + 1,ImageType.length());
          ifImageFound = true;
        }
    }
 
 
    //
    //Sets the preferred image format
    if (ifImageFound)
    {
        //Format = GetImageFormat(ImageType);
        String ImagePath = path + "Slides\\Image_";
 
    try {
            ImageIO.write(img.getSystemImage(),ImageType, new File(ImagePath + "Slide_" + slideIndex + "_Shape_" + j + "." + ImageType));
        } catch (IOException ex) {
            Logger.getLogger(NewAPi.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    ifImageFound = false;
}
}
```

