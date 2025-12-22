---
title: Extract Images from Presentation Shapes
linktitle: Image from Shape
type: docs
weight: 100
url: /androidjava/extracting-images-from-presentation-shapes/
keywords:
- extract image
- retrieve image
- slide background
- shape background
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Extract images from shapes in PowerPoint and OpenDocument presentations with Aspose.Slides for Android via Java — quick, code-friendly solution."
---

## **Extract Images from Shapes**

{{% alert color="primary" %}} 

Images are often added to shapes and also frequently used as slides' backgrounds. The image objects are added through [IImageCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/), which is a collection of [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) objects.

This article explains how you can extract the images added to presentations. 

{{% /alert %}} 

To extract an image from a presentation, you have to locate the image first by going through every slide and then going through every shape. Once the image is found or identified, you can extract it and save it as a new file. 

```java
    public void extractImages()
    {
        Presentation pres = new Presentation(folderPath + "ExtractImages.pptx");
        com.aspose.slides.IPPImage img = null;
        com.aspose.slides.IPPImage backImage = null;

        int slideIndex = 0;
        String imageType = "";
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
                backImage = sl.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                imageType = getImageTType(backImage);

                String imagePath = folderPath + "backImage_" + "Slide_" + slideIndex + "." + imageType;
                //Saves the picture
                backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
            } else
            {
                if (sl.getLayoutSlide().getBackground().getFillFormat().getFillType() == FillType.Picture)
                {
                    //Gets the back picture
                    backImage = sl.getLayoutSlide().getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                    imageType = getImageTType(backImage);

                    String imagePath = folderPath + "backImage_" + "LayoutSlide_" + slideIndex + "." + imageType;
                    //Saves the picture
                    backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
                }
            }

            for (int j = 0; j < sl.getShapes().size(); j++)
            {
                // Accesses the shape containing an image
                IShape sh = sl.getShapes().get_Item(j);

                if (sh instanceof IAutoShape)
                {
                    IAutoShape ashp = (IAutoShape) sh;
                    if (ashp.getFillFormat().getFillType() == FillType.Picture)
                    {
                        img = ashp.getFillFormat().getPictureFillFormat().getPicture().getImage();
                        imageType = getImageTType(img);
                        ifImageFound = true;
                    }
                } else if (sh instanceof IPictureFrame)
                {
                    IPictureFrame pf = (IPictureFrame) sh;
                    img = pf.getPictureFormat().getPicture().getImage();
                    imageType = getImageTType(img);
                    ifImageFound = true;
                }

                //Sets the preferred image format
                if (ifImageFound)
                {
                    String imagePath = folderPath + "backImage_" + "Slide_" + slideIndex + "_Shape_" + j + "." + imageType;
                    //Saves the picture
                    img.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
                }
                ifImageFound = false;
            }
        }
    }

    private String getImageTType(IPPImage image)
    {
        String imageContentType = image.getContentType();
        imageContentType = imageContentType.substring(imageContentType.indexOf("/") + 1);
        imageContentType = imageContentType.substring(imageContentType.indexOf("-") + 1);
        return imageContentType;
    }

    private String capitalize(String str)
    {
        if (str == null || str.length() <= 1) return str;
        return str.substring(0, 1).toUpperCase() + str.substring(1);
    }
```

## **FAQ**

**Can I extract the original image without any cropping, effects, or shape transformations?**

Yes. When you access a shape’s image, you get the image object from the presentation’s [image collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getImages--), meaning the original pixels without cropping or styling effects. The workflow goes through the presentation’s image collection and [PPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ppimage/) objects, which store the raw data.

**Is there a risk of duplicating identical files when saving many images at once?**

Yes, if you save everything indiscriminately. A presentation’s [image collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getImages--) can contain identical binary data referenced by different shapes or slides. To avoid duplicates, compare hashes, sizes, or contents of the extracted data before writing.

**How can I determine which shapes are linked to a specific image from the presentation’s collection?**

Aspose.Slides does not store reverse links from [PPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ppimage/) to shapes. Build a mapping manually during traversal: whenever you find a reference to an [PPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ppimage/), record which shapes use it.

**Can I extract images embedded inside OLE objects, such as attached documents?**

Not directly, because an OLE object is a container. You need to extract the OLE package itself and then analyze its contents using separate tools. Presentation picture shapes work via [PPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ppimage/); OLE is a different object type.
