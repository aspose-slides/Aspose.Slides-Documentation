---
title: Extracting Images from Presentation shapes
type: docs
weight: 90
url: /net/extracting-images-from-presentation-shapes/
keywords: "Extract image, PowerPoint, PPT, PPTX, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Extract images from PowerPoint presentation in C# or .NET"
---

## **Extract Images from Shapes**

{{% alert color="primary" %}} 

Images are often added to shapes and also frequently used as slides' backgrounds. The image objects are added through [IImageCollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/), which is a collection of [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) objects. 

This article explains how you can extract the images added to presentations. 

{{% /alert %}} 

To extract an image from a presentation, you have to locate the image first by going through every slide and then going through every shape. Once the image is found or identified, you can extract it and save it as a new file. XXX 

```c#
public static void Run() {

    String path = @"D:\Aspose Data\";
    // Accesses the presentation
    Presentation pres = new Presentation(path + "ExtractImages.pptx");
    Aspose.Slides.IPPImage img = null;
    Aspose.Slides.IPPImage Backimg = null;

    int slideIndex = 0;
    String ImageType = "";
    bool ifImageFound = false;
    for (int i = 0; i < pres.Slides.Count; i++)
    {

        slideIndex++;
        // Accesses the first slide
        ISlide sl = pres.Slides[i];
        System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

        // Accesses the first slide Slide sl = pres.getSlideByPosition(i);
        if (sl.Background.FillFormat.FillType == FillType.Picture)
        {
            // Gets the back image  
            Backimg = sl.Background.FillFormat.PictureFillFormat.Picture.Image;

            // Sets the preferred image format 

            ImageType = Backimg.ContentType;
            ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
            Format = GetImageFormat(ImageType);

            String ImagePath = path + "BackImage_";
            Backimg.SystemImage.Save(ImagePath + "Slide_" + slideIndex.ToString() + "." + ImageType, Format);

        }
        else
        {
            if (sl.LayoutSlide.Background.FillFormat.FillType == FillType.Picture)
            {
                // Gets the back image  
                Backimg = sl.LayoutSlide.Background.FillFormat.PictureFillFormat.Picture.Image;

                // Sets the preferred image format 

                ImageType = Backimg.ContentType;
                ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
                Format = GetImageFormat(ImageType);

                String ImagePath = path + "BackImage_Slide_" + i;
                Backimg.SystemImage.Save(ImagePath + "LayoutSlide_" + slideIndex.ToString() + "." + ImageType, Format);

            }
        }

        for (int j = 0; j < sl.Shapes.Count; j++)
        {
            // Accesses the shape containing an image
            IShape sh = sl.Shapes[j];

            if (sh is AutoShape)
            {
                AutoShape ashp = (AutoShape)sh;
                if (ashp.FillFormat.FillType == FillType.Picture)
                {
                    img = ashp.FillFormat.PictureFillFormat.Picture.Image;
                    ImageType = img.ContentType;
                    ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
                    ifImageFound = true;

                }
            }

            else if (sh is PictureFrame)
            {
                IPictureFrame pf = (IPictureFrame)sh;
                if (pf.FillFormat.FillType == FillType.Picture)
                {
                    img = pf.PictureFormat.Picture.Image;
                    ImageType = img.ContentType;
                    ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
                    ifImageFound = true;
                }
            }

            // Sets the preferred format for extracted image
            if (ifImageFound)
            {
                Format = GetImageFormat(ImageType);
                String ImagePath = path + "Slides\\Image_";
                img.SystemImage.Save(ImagePath + "Slide_" + slideIndex.ToString() + "_Shape_" + j.ToString() + "." + ImageType, Format);
            }
            ifImageFound = false;
        }
    }
}

public static System.Drawing.Imaging.ImageFormat GetImageFormat(String ImageType)
{
    System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;
    switch (ImageType)
    {
        case "jpeg":
            Format = System.Drawing.Imaging.ImageFormat.Jpeg;
            break;

        case "emf":
            Format = System.Drawing.Imaging.ImageFormat.Emf;
            break;

        case "bmp":
            Format = System.Drawing.Imaging.ImageFormat.Bmp;
            break;

        case "png":
            Format = System.Drawing.Imaging.ImageFormat.Png;
            break;

        case "wmf":
            Format = System.Drawing.Imaging.ImageFormat.Wmf;
            break;

        case "gif":
            Format = System.Drawing.Imaging.ImageFormat.Gif;
            break;

    }
    return Format;
}
```

## **FAQ**

**Can I extract the original image without any cropping, effects, or shape transformations?**

Yes. When you access a shape’s image, you get the image object from the presentation’s [image collection](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/), meaning the original pixels without cropping or styling effects. The workflow goes through the presentation’s image collection and [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/) objects, which store the raw data.

**Is there a risk of duplicating identical files when saving many images at once?**

Yes, if you save everything indiscriminately. A presentation’s [image collection](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/) can contain identical binary data referenced by different shapes or slides. To avoid duplicates, compare hashes, sizes, or contents of the extracted data before writing.

**How can I determine which shapes are linked to a specific image from the presentation’s collection?**

Aspose.Slides does not store reverse links from [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/) to shapes. Build a mapping manually during traversal: whenever you find a reference to an [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/), record which shapes use it.

**Can I extract images embedded inside OLE objects, such as attached documents?**

Not directly, because an OLE object is a container. You need to extract the OLE package itself and then analyze its contents using separate tools. Presentation picture shapes work via [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/); OLE is a different object type.
