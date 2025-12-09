---
title: Extraer imágenes de formas de presentación en .NET
linktitle: Imagen desde forma
type: docs
weight: 90
url: /es/net/extracting-images-from-presentation-shapes/
keywords:
- extraer imagen
- recuperar imagen
- fondo de diapositiva
- fondo de forma
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Extraiga imágenes de formas en presentaciones PowerPoint y OpenDocument con Aspose.Slides para .NET — solución rápida y amigable para código."
---

## **Extraer imágenes de formas**

{{% alert color="primary" %}} 

Las imágenes se añaden a menudo a las formas y también se utilizan con frecuencia como fondos de diapositivas. Los objetos de imagen se añaden a través de [IImageCollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/), que es una colección de objetos [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/). 

Este artículo explica cómo puede extraer las imágenes añadidas a las presentaciones. 

{{% /alert %}} 

Para extraer una imagen de una presentación, debe localizarla primero recorriendo cada diapositiva y luego cada forma. Una vez que la imagen se encuentre o identifique, puede extraerla y guardarla como un nuevo archivo. XXX 
```c#
public static void Run() {

    String path = @"D:\Aspose Data\";
    // Accede a la presentación
    Presentation pres = new Presentation(path + "ExtractImages.pptx");
    Aspose.Slides.IPPImage img = null;
    Aspose.Slides.IPPImage Backimg = null;

    int slideIndex = 0;
    String ImageType = "";
    bool ifImageFound = false;
    for (int i = 0; i < pres.Slides.Count; i++)
    {

        slideIndex++;
        // Accede a la primera diapositiva
        ISlide sl = pres.Slides[i];
        System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

        // Accede a la primera diapositiva Slide sl = pres.getSlideByPosition(i);
        if (sl.Background.FillFormat.FillType == FillType.Picture)
        {
            // Obtiene la imagen de fondo  
            Backimg = sl.Background.FillFormat.PictureFillFormat.Picture.Image;

            // Establece el formato de imagen preferido 

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
                // Obtiene la imagen de fondo  
                Backimg = sl.LayoutSlide.Background.FillFormat.PictureFillFormat.Picture.Image;

                // Establece el formato de imagen preferido 

                ImageType = Backimg.ContentType;
                ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
                Format = GetImageFormat(ImageType);

                String ImagePath = path + "BackImage_Slide_" + i;
                Backimg.SystemImage.Save(ImagePath + "LayoutSlide_" + slideIndex.ToString() + "." + ImageType, Format);

            }
        }

        for (int j = 0; j < sl.Shapes.Count; j++)
        {
            // Accede a la forma que contiene una imagen
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

            // Establece el formato preferido para la imagen extraída
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

**¿Puedo extraer la imagen original sin recortes, efectos o transformaciones de forma?**

Sí. Cuando accede a la imagen de una forma, obtiene el objeto de imagen de la [image collection](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/) de la presentación, lo que significa los píxeles originales sin recortes ni efectos de estilo. El flujo de trabajo recorre la colección de imágenes de la presentación y los objetos [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/), que almacenan los datos sin procesar.

**¿Existe el riesgo de duplicar archivos idénticos al guardar muchas imágenes a la vez?**

Sí, si guarda todo indiscriminadamente. La [image collection](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/) de una presentación puede contener datos binarios idénticos referenciados por diferentes formas o diapositivas. Para evitar duplicados, compare hashes, tamaños o contenidos de los datos extraídos antes de escribirlos.

**¿Cómo puedo determinar qué formas están vinculadas a una imagen específica de la colección de la presentación?**

Aspose.Slides no almacena enlaces inversos de [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/) a las formas. Construya un mapeo manualmente durante la navegación: cada vez que encuentre una referencia a un [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/), registre qué formas lo utilizan.

**¿Puedo extraer imágenes incrustadas dentro de objetos OLE, como documentos adjuntos?**

No directamente, porque un objeto OLE es un contenedor. Necesita extraer el paquete OLE mismo y luego analizar su contenido con herramientas separadas. Las formas de imagen de la presentación funcionan a través de [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/); OLE es un tipo de objeto diferente.