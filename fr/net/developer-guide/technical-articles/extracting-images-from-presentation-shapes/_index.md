---
title: Extraction d'images à partir des formes de présentation
type: docs
weight: 90
url: /fr/net/extracting-images-from-presentation-shapes/
keywords: "Extraire image, PowerPoint, PPT, PPTX, présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Extraire des images d'une présentation PowerPoint en C# ou .NET"
---

## **Extraire des images à partir des formes**

{{% alert color="primary" %}} 

Les images sont souvent ajoutées aux formes et sont également fréquemment utilisées comme arrière-plans des diapositives. Les objets image sont ajoutés via [IImageCollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/), qui est une collection d'objets [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/). 

Cet article explique comment extraire les images ajoutées aux présentations. 

{{% /alert %}} 

Pour extraire une image d'une présentation, vous devez d'abord localiser l'image en parcourant chaque diapositive puis chaque forme. Une fois l'image trouvée ou identifiée, vous pouvez l'extraire et l'enregistrer comme un nouveau fichier. XXX 
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

        // Accède à la première diapositive Slide sl = pres.getSlideByPosition(i);
        if (sl.Background.FillFormat.FillType == FillType.Picture)
        {
            // Obtient l'image d'arrière-plan  
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
                // Obtient l'image d'arrière-plan  
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


## **FAQ**

**Puis-je extraire l'image originale sans aucun recadrage, effet ou transformation de forme ?**

Oui. Lorsque vous accédez à l'image d'une forme, vous obtenez l'objet image de la présentation’s [image collection](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/), ce qui signifie les pixels originaux sans recadrage ni effets de style. Le flux de travail parcourt la collection d'images de la présentation et les objets [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/), qui stockent les données brutes.

**Existe-t-il un risque de duplication de fichiers identiques lors de l'enregistrement de nombreuses images en même temps ?**

Oui, si vous enregistrez tout sans discernement. La présentation’s [image collection](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/) peut contenir des données binaires identiques référencées par différentes formes ou diapositives. Pour éviter les doublons, comparez les hachages, les tailles ou le contenu des données extraites avant l'écriture.

**Comment déterminer quelles formes sont liées à une image spécifique de la collection de la présentation ?**

Aspose.Slides ne stocke pas de liens inversés de [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/) vers les formes. Construisez une correspondance manuellement pendant le parcours : chaque fois que vous trouvez une référence à un [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/), notez quelles formes l'utilisent.

**Puis-je extraire les images intégrées dans des objets OLE, comme des documents joints ?**

Pas directement, car un objet OLE est un conteneur. Vous devez extraire le paquet OLE lui‑même, puis analyser son contenu à l'aide d'outils séparés. Les formes d'image de la présentation fonctionnent via [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/); l'OLE étant un type d'objet différent.