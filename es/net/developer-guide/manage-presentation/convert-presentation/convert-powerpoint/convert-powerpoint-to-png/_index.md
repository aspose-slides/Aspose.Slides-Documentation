---
title: Convertir PowerPoint a PNG en C#
linktitle: Convertir PowerPoint a PNG
type: docs
weight: 30
url: /net/convert-powerpoint-to-png/
keywords:
- PowerPoint a png
- ppt a png
- pptx a png
- odp a png
- PowerPoint a PNG
- PPT a PNG
- PPTX a PNG
- ODP a PNG
- C#
- Csharp
- Aspose.Slides para .NET
description: Convertir presentación de PowerPoint a PNG en C#. Convertir PPT a PNG en C#. Convertir PPTX a PNG en C#. Convertir ODP a PNG en C#
---

## **Resumen**

Este artículo explica cómo convertir una presentación de PowerPoint al formato PNG utilizando C#. Cubre los siguientes temas.

- [Convertir PowerPoint a PNG en C#](#convertir-powerpoint-a-png)
- [Convertir PPT a PNG en C#](#convertir-powerpoint-a-png)
- [Convertir PPTX a PNG en C#](#convertir-powerpoint-a-png)
- [Convertir ODP a PNG en C#](#convertir-powerpoint-a-png)
- [Convertir diapositiva de PowerPoint a imagen en C#](#convertir-powerpoint-a-png)

## **C# PowerPoint a PNG**

Para el código de ejemplo en C# para convertir PowerPoint a PNG, consulte la sección a continuación es decir, [Convertir PowerPoint a PNG](#convertir-powerpoint-a-png). El código puede cargar varios formatos como PPT, PPTX y ODP en el objeto de Presentación y luego guardar su miniatura de diapositiva en formato PNG. Las otras conversiones de PowerPoint a imagen que son algo similares como JPG, BMP, TIFF y SVG se discuten en estos artículos.

- [C# PowerPoint a JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint a BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint a TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint a SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **Acerca de la conversión de PowerPoint a PNG**

El formato PNG (Portable Network Graphics) no es tan popular como JPEG (Joint Photographic Experts Group), pero sigue siendo muy popular. 

**Caso de uso:** Cuando tienes una imagen compleja y el tamaño no es un problema, PNG es un mejor formato de imagen que JPEG. 

{{% alert title="Consejo" color="primary" %}} Puede que desees consultar los **Convertidores de PowerPoint a PNG** gratuitos de Aspose: [PPTX a PNG](https://products.aspose.app/slides/conversion/pptx-to-png) y [PPT a PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Son una implementación en vivo del proceso descrito en esta página. {{% /alert %}}

## **Convertir PowerPoint a PNG**

Sigue estos pasos:

1. Instancia la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtén el objeto de diapositiva de la colección [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) bajo la interfaz [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide). 
3. Usa el método [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) para obtener la miniatura de cada diapositiva. 
4. Usa el método [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) para guardar la miniatura de la diapositiva en formato PNG. 

Este código en C# te muestra cómo convertir una presentación de PowerPoint a PNG. El objeto de Presentación puede cargar PPT, PPTX, ODP, etc., luego cada diapositiva en el objeto de presentación se convierte a formato PNG u otro formato de imagen.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Convertir PowerPoint a PNG con dimensiones personalizadas**

Si deseas obtener archivos PNG alrededor de una escala determinada, puedes establecer los valores para `desiredX` y `desiredY`, que determinan las dimensiones de la miniatura resultante. 

Este código en C# demuestra la operación descrita:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Convertir PowerPoint a PNG con tamaño personalizado**

Si deseas obtener archivos PNG alrededor de un tamaño determinado, puedes pasar tus argumentos preferidos `width` y `height` para `imageSize`. 

Este código te muestra cómo convertir un PowerPoint a PNG mientras especificas el tamaño para las imágenes: 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```