---
title: Extracción de imágenes de formas de presentación
type: docs
weight: 90
url: /es/net/extracting-images-from-presentation-shapes/
keywords: "Extraer imagen, PowerPoint, PPT, PPTX, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Extraer imágenes de una presentación de PowerPoint en C# o .NET"
---

## **Extraer imágenes de formas**

{{% alert color="primary" %}} 

Las imágenes a menudo se añaden a las formas y también se usan con frecuencia como fondos de diapositivas. Los objetos de imagen se añaden a través de [IImageCollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/), que es una colección de objetos [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/). 

Este artículo explica cómo puedes extraer las imágenes añadidas a las presentaciones. 

{{% /alert %}} 

Para extraer una imagen de una presentación, debes localizar la imagen primero recorriendo cada diapositiva y luego recorriendo cada forma. Una vez que la imagen se encuentra o identifica, puedes extraerla y guardarla como un nuevo archivo. XXX 
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

**¿Puedo extraer la imagen original sin recortes, efectos o transformaciones de la forma?**

Sí. Cuando accedes a la imagen de una forma, obtienes el objeto de imagen de la colección de imágenes de la presentación, lo que significa los píxeles originales sin recortes ni efectos de estilo. El flujo de trabajo recorre la colección de imágenes de la presentación y los objetos [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/), que almacenan los datos sin procesar.

**¿Existe el riesgo de duplicar archivos idénticos al guardar muchas imágenes a la vez?**

Sí, si guardas todo indiscriminadamente. La colección de imágenes de una presentación puede contener datos binarios idénticos referenciados por diferentes formas o diapositivas. Para evitar duplicados, compara los hash, tamaños o contenidos de los datos extraídos antes de escribir.

**¿Cómo puedo determinar qué formas están vinculadas a una imagen específica de la colección de la presentación?**

Aspose.Slides no almacena enlaces inversos de [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/) a las formas. Construye un mapeo manualmente durante el recorrido: siempre que encuentres una referencia a un [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/), registra qué formas lo utilizan.

**¿Puedo extraer imágenes incrustadas dentro de objetos OLE, como documentos adjuntos?**

No directamente, porque un objeto OLE es un contenedor. Necesitas extraer el paquete OLE en sí y luego analizar su contenido usando herramientas separadas. Las formas de imagen de la presentación funcionan a través de [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/); OLE es un tipo de objeto diferente.