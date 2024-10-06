---
title: Extraction d'images des formes de présentation
type: docs
weight: 90
url: /net/extracting-images-from-presentation-shapes/
keywords: "Extraire l'image, PowerPoint, PPT, PPTX, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Extraire des images d'une présentation PowerPoint en C# ou .NET"
---

{{% alert color="primary" %}} 

Les images sont souvent ajoutées aux formes et sont également fréquemment utilisées comme arrière-plans de diapositives. Les objets image sont ajoutés via [IImageCollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/), qui est une collection d'objets [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/). 

Cet article explique comment vous pouvez extraire les images ajoutées aux présentations. 

{{% /alert %}} 

Pour extraire une image d'une présentation, vous devez d'abord localiser l'image en parcourant chaque diapositive, puis en parcourant chaque forme. Une fois l'image trouvée ou identifiée, vous pouvez l'extraire et la sauvegarder en tant que nouveau fichier. XXX 

```c#
public static void Run() {

    String path = @"D:\Aspose Data\";
    // Accède à la présentation
    Presentation pres = new Presentation(path + "ExtractImages.pptx");
    Aspose.Slides.IPPImage img = null;
    Aspose.Slides.IPPImage Backimg = null;

    int slideIndex = 0;
    String ImageType = "";
    bool ifImageFound = false;
    for (int i = 0; i < pres.Slides.Count; i++)
    {

        slideIndex++;
        // Accède à la première diapositive
        ISlide sl = pres.Slides[i];
        System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

        // Accède à la première diapositive
        if (sl.Background.FillFormat.FillType == FillType.Picture)
        {
            // Obtient l'image de fond  
            Backimg = sl.Background.FillFormat.PictureFillFormat.Picture.Image;

            // Définit le format d'image préféré 
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
                // Obtient l'image de fond  
                Backimg = sl.LayoutSlide.Background.FillFormat.PictureFillFormat.Picture.Image;

                // Définit le format d'image préféré 
                ImageType = Backimg.ContentType;
                ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
                Format = GetImageFormat(ImageType);

                String ImagePath = path + "BackImage_Slide_" + i;
                Backimg.SystemImage.Save(ImagePath + "LayoutSlide_" + slideIndex.ToString() + "." + ImageType, Format);

            }
        }

        for (int j = 0; j < sl.Shapes.Count; j++)
        {
            // Accède à la forme contenant une image
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

            // Définit le format préféré pour l'image extraite
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