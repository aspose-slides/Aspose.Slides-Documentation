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
- guardar PPT como PNG
- guardar PPTX como PNG
- exportar PPT a PNG
- exportar PPTX a PNG
- .NET
- C#
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint a imágenes PNG de alta calidad rápidamente con Aspose.Slides para .NET, garantizando resultados precisos y automatizados."
---
## **Visión general**

Este artículo explica cómo convertir presentaciones de PowerPoint a imágenes PNG usando Aspose.Slides. Muestra cómo cargar archivos de presentación en formatos como PPT, PPTX y ODP, renderizar las diapositivas como imágenes y guardar los resultados en formato PNG.

El artículo también demuestra cómo personalizar las imágenes PNG generadas estableciendo valores de escala o especificando el ancho y alto deseados.

## **Convertir PowerPoint a PNG**

Siga estos pasos:

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation).
2. Obtener el objeto de diapositiva de la colección [Presentation.Slides](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/properties/slides) bajo la interfaz [ISlide](https://reference.aspose.com/slides/es/net/aspose.slides/islide).
3. Utilizar el método [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/es/net/aspose.slides/islide/getimage/) para renderizar cada diapositiva a la escala que necesite.
4. Utilizar el método [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/es/net/aspose.slides.ipresentation/save/methods/5) para guardar la miniatura de la diapositiva en formato PNG.

Este código C# muestra cómo convertir una presentación de PowerPoint a PNG. El objeto Presentation puede cargar PPT, PPTX, ODP, etc., y cada diapositiva del objeto Presentation se convierte al formato PNG o a otros formatos de imagen.

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(1f, 1f))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

{{% alert color="info" %}} 
**Nota:** Los argumentos de escala `1f, 1f` renderizan cada diapositiva a su tamaño completo, por lo que una diapositiva de 720×540 pt produce una imagen de 720×540 px. La sobrecarga sin parámetros de [GetImage()](https://reference.aspose.com/slides/es/net/aspose.slides/islide/getimage/) devuelve una miniatura de vista previa mucho más pequeña. 
{{% /alert %}} 

## **Convertir PowerPoint a PNG con dimensiones personalizadas**

Si desea obtener archivos PNG con una escala determinada, puede establecer los valores de `desiredX` y `desiredY`, que determinan las dimensiones de la miniatura resultante. 

Este código en C# demuestra la operación descrita:

```c#
using Aspose.Slides;

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

Si desea obtener archivos PNG con un tamaño concreto, puede pasar sus argumentos preferidos `width` y `height` para `imageSize`. 

Este código muestra cómo convertir un PowerPoint a PNG especificando el tamaño de las imágenes: 

```c#
using System.Drawing;
using Aspose.Slides;

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

### ¿Cómo puedo exportar solo una forma específica (p. ej., un gráfico o una imagen) en lugar de toda la diapositiva?

Aspose.Slides admite [generar miniaturas para formas individuales](/slides/es/net/create-shape-thumbnails/); puede renderizar una forma a una imagen PNG.

### ¿Se admite la conversión paralela en un servidor?

Sí, pero [no comparta](/slides/es/net/multithreading/) una única instancia de presentación entre hilos. Utilice una instancia distinta por hilo o proceso.

### ¿Cuáles son las limitaciones de la versión de prueba al exportar a PNG?

El modo de evaluación añade una marca de agua a las imágenes de salida y aplica [otras restricciones](/slides/es/net/licensing/) hasta que se aplique una licencia.