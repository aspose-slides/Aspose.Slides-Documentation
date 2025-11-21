---
title: Извлечение изображений из фигур презентации
type: docs
weight: 90
url: /ru/net/extracting-images-from-presentation-shapes/
keywords: "Извлечение изображения, PowerPoint, PPT, PPTX, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Извлечение изображений из презентации PowerPoint на C# или .NET"
---

## **Извлечение изображений из фигур**

{{% alert color="primary" %}} 

Изображения часто добавляются в фигуры и также часто используются в качестве фона слайдов. Объекты изображений добавляются через [IImageCollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/), который представляет собой коллекцию объектов [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/). 

В этой статье объясняется, как извлечь изображения, добавленные в презентацию. 

{{% /alert %}} 

Чтобы извлечь изображение из презентации, необходимо сначала найти его, пройдя по каждому слайду, а затем по каждой фигуре. Как только изображение найдено или идентифицировано, его можно извлечь и сохранить как новый файл. XXX 
```c#
public static void Run() {

    String path = @"D:\Aspose Data\";
    // Получает презентацию
    Presentation pres = new Presentation(path + "ExtractImages.pptx");
    Aspose.Slides.IPPImage img = null;
    Aspose.Slides.IPPImage Backimg = null;

    int slideIndex = 0;
    String ImageType = "";
    bool ifImageFound = false;
    for (int i = 0; i < pres.Slides.Count; i++)
    {

        slideIndex++;
        // Получает первый слайд
        ISlide sl = pres.Slides[i];
        System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

        // Получает первый слайд Slide sl = pres.getSlideByPosition(i);
        if (sl.Background.FillFormat.FillType == FillType.Picture)
        {
            // Получает фоновое изображение  
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
                // Получает фоновое изображение  
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
            // Получает форму, содержащую изображение
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

            // Устанавливает предпочтительный формат для извлечённого изображения
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

**Могу ли я извлечь оригинальное изображение без обрезки, эффектов или трансформаций фигуры?**

Да. При доступе к изображению фигуры вы получаете объект изображения из [image collection](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/) презентации, то есть оригинальные пиксели без обрезки или стилистических эффектов. Рабочий процесс проходит через [image collection](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/) презентации и объекты [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/), которые хранят необработанные данные.

**Существует ли риск дублирования одинаковых файлов при одновременном сохранении множества изображений?**

Да, если сохранять всё без разбора. [Image collection](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/) презентации может содержать одинаковые бинарные данные, на которые ссылаются разные фигуры или слайды. Чтобы избежать дубликатов, сравнивайте хэши, размеры или содержимое извлечённых данных перед записью.

**Как определить, какие фигуры связаны с конкретным изображением из коллекции презентации?**

Aspose.Slides не хранит обратные ссылки от [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/) к фигурам. Создайте отображение вручную во время обхода: каждый раз, когда находите ссылку на [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/), фиксируйте, какие фигуры её используют.

**Могу ли я извлечь изображения, встроенные в OLE‑объекты, например вложенные документы?**

Не напрямую, поскольку OLE‑объект является контейнером. Нужно извлечь сам пакет OLE, а затем проанализировать его содержимое с помощью отдельных инструментов. Фигуры‑изображения в презентации работают через [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/); OLE — это другой тип объекта.