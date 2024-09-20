---
title: Извлечение изображений из фигур презентации
type: docs
weight: 90
url: /net/extracting-images-from-presentation-shapes/
keywords: "Извлечение изображения, PowerPoint, PPT, PPTX, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Извлечение изображений из презентации PowerPoint на C# или .NET"
---

{{% alert color="primary" %}} 

Изображения часто добавляются в фигуры и также часто используются в качестве фонов слайдов. Объекты изображений добавляются через [IImageCollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/), которая является коллекцией объектов [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/). 

В этой статье объясняется, как вы можете извлечь изображения, добавленные в презентации. 

{{% /alert %}} 

Чтобы извлечь изображение из презентации, вам сначала нужно найти изображение, пройдя по каждому слайду и затем по каждой фигуре. Как только изображение найдено или идентифицировано, вы можете извлечь его и сохранить в виде нового файла. XXX 

```c#
public static void Run() {

    String path = @"D:\Aspose Data\";
    // Доступ к презентации
    Presentation pres = new Presentation(path + "ExtractImages.pptx");
    Aspose.Slides.IPPImage img = null;
    Aspose.Slides.IPPImage Backimg = null;

    int slideIndex = 0;
    String ImageType = "";
    bool ifImageFound = false;
    for (int i = 0; i < pres.Slides.Count; i++)
    {

        slideIndex++;
        // Доступ к первому слайду
        ISlide sl = pres.Slides[i];
        System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

        // Доступ к первому слайду Slide sl = pres.getSlideByPosition(i);
        if (sl.Background.FillFormat.FillType == FillType.Picture)
        {
            // Получение фонового изображения  
            Backimg = sl.Background.FillFormat.PictureFillFormat.Picture.Image;

            // Устанавливает предпочтительный формат изображения 

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
                // Получение фонового изображения  
                Backimg = sl.LayoutSlide.Background.FillFormat.PictureFillFormat.Picture.Image;

                // Устанавливает предпочтительный формат изображения 

                ImageType = Backimg.ContentType;
                ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
                Format = GetImageFormat(ImageType);

                String ImagePath = path + "BackImage_Slide_" + i;
                Backimg.SystemImage.Save(ImagePath + "LayoutSlide_" + slideIndex.ToString() + "." + ImageType, Format);

            }
        }

        for (int j = 0; j < sl.Shapes.Count; j++)
        {
            // Доступ к фигуре, содержащей изображение
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

            // Устанавливает предпочтительный формат для извлеченного изображения
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