---
title: Convertir diapositivas de PowerPoint a PNG en .NET
linktitle: PowerPoint a PNG
type: docs
weight: 30
url: /es/net/convert-powerpoint-to-png/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a PNG
- presentación a PNG
- diapositiva a PNG
- PPT a PNG
- PPTX a PNG
- .NET
- C#
- Aspose.Slides
description: "Convierta presentaciones de PowerPoint a imágenes PNG de alta calidad rápidamente con Aspose.Slides para .NET, garantizando resultados precisos y automatizados."
---

## **Descripción general**

Este artículo explica cómo convertir una presentación de PowerPoint al formato PNG usando C#. Cubre los siguientes temas.

- [Convertir PowerPoint a PNG en C#](#convert-powerpoint-to-png)
- [Convertir PPT a PNG en C#](#convert-powerpoint-to-png)
- [Convertir PPTX a PNG en C#](#convert-powerpoint-to-png)
- [Convertir ODP a PNG en C#](#convert-powerpoint-to-png)
- [Convertir diapositiva de PowerPoint a imagen en C#](#convert-powerpoint-to-png)

## **PowerPoint a PNG con C#**

Para obtener código de ejemplo en C# que convierta PowerPoint a PNG, consulte la sección a continuación, es decir, [Convertir PowerPoint a PNG](#convert-powerpoint-to-png). El código puede cargar varios formatos como PPT, PPTX y ODP en el objeto Presentation y luego guardar la miniatura de sus diapositivas en formato PNG. Las demás conversiones de PowerPoint a imagen que son similares, como JPG, BMP, TIFF y SVG, se tratan en estos artículos.

- [PowerPoint a JPG con C#](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [PowerPoint a BMP con C#](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [PowerPoint a TIFF con C#](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [PowerPoint a SVG con C#](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **Acerca de la conversión de PowerPoint a PNG**

El formato PNG (Portable Network Graphics) no es tan popular como JPEG (Joint Photographic Experts Group), pero sigue siendo muy usado.

**Caso de uso:** Cuando tienes una imagen compleja y el tamaño no es un problema, PNG es un formato de imagen mejor que JPEG.

{{% alert title="Tip" color="primary" %}} Puede que desees consultar los **convertidores gratuitos de PowerPoint a PNG** de Aspose: [PPTX a PNG](https://products.aspose.app/slides/conversion/pptx-to-png) y [PPT a PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Son una implementación en vivo del proceso descrito en esta página. {{% /alert %}}

## **Convertir PowerPoint a PNG**

Sigue estos pasos:

1. Instancia la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtén el objeto diapositiva de la colección [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) bajo la interfaz [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. Usa el método [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) para obtener la miniatura de cada diapositiva.
4. Usa el método [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) para guardar la miniatura de la diapositiva en formato PNG.

Este código C# muestra cómo convertir una presentación de PowerPoint a PNG. El objeto Presentation puede cargar PPT, PPTX, ODP, etc., y cada diapositiva del objeto Presentation se convierte al formato PNG u otros formatos de imagen.
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

Si deseas obtener archivos PNG con una escala determinada, puedes establecer los valores de `desiredX` y `desiredY`, que determinan las dimensiones de la miniatura resultante.

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

Si deseas obtener archivos PNG con un tamaño determinado, puedes pasar los argumentos `width` y `height` que prefieras para `imageSize`.

Este código muestra cómo convertir un PowerPoint a PNG especificando el tamaño de las imágenes:
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


## **Preguntas frecuentes**

**¿Cómo puedo exportar solo una forma específica (p. ej., gráfico o imagen) en lugar de toda la diapositiva?**  
Aspose.Slides admite [la generación de miniaturas para formas individuales](/slides/es/net/create-shape-thumbnails/); puedes renderizar una forma a una imagen PNG.

**¿Se admite la conversión paralela en un servidor?**  
Sí, pero [no compartas](/slides/es/net/multithreading/) una única instancia de presentación entre hilos. Utiliza una instancia separada por hilo o proceso.

**¿Cuáles son las limitaciones de la versión de prueba al exportar a PNG?**  
El modo de evaluación añade una marca de agua a las imágenes de salida y aplica [otras restricciones](/slides/es/net/licensing/) hasta que se aplique una licencia.