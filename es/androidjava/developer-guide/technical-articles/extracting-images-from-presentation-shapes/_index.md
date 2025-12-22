---
title: Extraer imágenes de formas de presentación
linktitle: Imagen de forma
type: docs
weight: 100
url: /es/androidjava/extracting-images-from-presentation-shapes/
keywords:
- extraer imagen
- recuperar imagen
- fondo de diapositiva
- fondo de forma
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Extrae imágenes de formas en presentaciones PowerPoint y OpenDocument con Aspose.Slides para Android mediante Java — solución rápida y fácil de usar en código."
---

## **Extraer imágenes de formas**

{{% alert color="primary" %}} 

Las imágenes se añaden a menudo a las formas y también se utilizan frecuentemente como fondos de diapositivas. Los objetos de imagen se añaden a través de [IImageCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/), que es una colección de objetos [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/).

Este artículo explica cómo puede extraer las imágenes añadidas a las presentaciones. 

{{% /alert %}} 

Para extraer una imagen de una presentación, primero debe localizar la imagen recorriendo cada diapositiva y luego cada forma. Una vez que la imagen se encuentre o identifique, puede extraerla y guardarla como un nuevo archivo. 
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
            //Accede a la primera diapositiva
            ISlide sl = pres.getSlides().get_Item(i);


            //Accede a la primera diapositiva Slide sl = pres.getSlideByPosition(i);
            if (sl.getBackground().getFillFormat().getFillType() == FillType.Picture)
            {
                //Obtiene la imagen de fondo
                backImage = sl.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                imageType = getImageTType(backImage);

                String imagePath = folderPath + "backImage_" + "Slide_" + slideIndex + "." + imageType;
                //Guarda la imagen
                backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
            } else
            {
                if (sl.getLayoutSlide().getBackground().getFillFormat().getFillType() == FillType.Picture)
                {
                    //Obtiene la imagen de fondo
                    backImage = sl.getLayoutSlide().getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                    imageType = getImageTType(backImage);

                    String imagePath = folderPath + "backImage_" + "LayoutSlide_" + slideIndex + "." + imageType;
                    //Guarda la imagen
                    backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
                }
            }

            for (int j = 0; j < sl.getShapes().size(); j++)
            {
                // Accede a la forma que contiene una imagen
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

                //Establece el formato de imagen preferido
                if (ifImageFound)
                {
                    String imagePath = folderPath + "backImage_" + "Slide_" + slideIndex + "_Shape_" + j + "." + imageType;
                    //Guarda la imagen
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

**¿Puedo extraer la imagen original sin recortes, efectos o transformaciones de forma?**

Sí. Cuando accede a la imagen de una forma, obtiene el objeto de imagen de la [image collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getImages--) de la presentación, lo que significa los píxeles originales sin recortes ni efectos de estilo. El flujo de trabajo recorre la [image collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getImages--) de la presentación y los objetos [PPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ppimage/), que almacenan los datos sin procesar.

**¿Existe el riesgo de duplicar archivos idénticos al guardar muchas imágenes a la vez?**

Sí, si guarda todo indiscriminadamente. La [image collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getImages--) de una presentación puede contener datos binarios idénticos referenciados por diferentes formas o diapositivas. Para evitar duplicados, compare hashes, tamaños o contenidos de los datos extraídos antes de escribirlos.

**¿Cómo puedo determinar qué formas están vinculadas a una imagen específica de la colección de la presentación?**

Aspose.Slides no almacena enlaces inversos de [PPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ppimage/) a formas. Construya un mapeo manualmente durante la traversa: cada vez que encuentre una referencia a un [PPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ppimage/), registre qué formas lo utilizan.

**¿Puedo extraer imágenes incrustadas dentro de objetos OLE, como documentos adjuntos?**

No directamente, porque un objeto OLE es un contenedor. Necesita extraer el paquete OLE mismo y luego analizar su contenido con herramientas separadas. Las formas de imagen de la presentación funcionan a través de [PPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ppimage/); OLE es un tipo de objeto diferente.