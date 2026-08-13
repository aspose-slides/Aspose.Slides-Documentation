---
title: Convertir presentaciones de PowerPoint a GIF animados en .NET
linktitle: PowerPoint a GIF
type: docs
weight: 65
url: /es/net/convert-powerpoint-to-animated-gif/
keywords:
- GIF animado
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a GIF
- presentación a GIF
- diapositiva a GIF
- PPT a GIF
- PPTX a GIF
- guardar PPT como GIF
- guardar PPTX como GIF
- exportar PPT como GIF
- exportar PPTX como GIF
- configuración predeterminada
- configuración personalizada
- .NET
- C#
- Aspose.Slides
description: "Convierta fácilmente presentaciones de PowerPoint (PPT, PPTX) a GIF animados con Aspose.Slides para .NET. Resultados rápidos y de alta calidad."
---
## **Descripción general**

Aspose.Slides le permite convertir presentaciones de PowerPoint a archivos GIF animados con solo unas pocas líneas de código. Esto es útil cuando necesita compartir el contenido de las diapositivas en un formato animado ligero y ampliamente compatible que puede incrustarse en páginas web, mensajeros o documentación. Este artículo explica cómo exportar una presentación a GIF con la configuración predeterminada y cómo personalizar la salida configurando opciones como el tamaño del fotograma, el retraso entre diapositivas y la frecuencia de fotogramas de transición mediante [GifOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/gifoptions/).

## **Convertir presentaciones a GIF animado usando la configuración predeterminada**

Este código de ejemplo en C# muestra cómo convertir una presentación a GIF animado usando la configuración estándar:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

El GIF animado se creará con los parámetros predeterminados. 

{{%  alert  title="TIP"  color="info"  %}} 

Si prefiere personalizar los parámetros del GIF, puede utilizar la clase [GifOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/gifoptions). Vea el código de ejemplo a continuación. 

{{% /alert %}} 

## **Convertir presentaciones a GIF animado usando configuración personalizada**

Este código de ejemplo muestra cómo convertir una presentación a GIF animado usando ajustes personalizados en C#:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // el tamaño del GIF resultante  
        DefaultDelay = 2000, // cuánto tiempo se mostrará cada diapositiva hasta que se cambie a la siguiente
        TransitionFps = 35 // incrementar FPS para mejorar la calidad de la animación de transición
    });
}
```

{{% alert title="Info" color="info" %}}

Puede que quiera probar un conversor GRATUITO [Text to GIF](https://products.aspose.app/slides/es/text-to-gif) desarrollado por Aspose. 

{{% /alert %}}

## **Preguntas frecuentes**

### ¿Qué ocurre si las fuentes usadas en la presentación no están instaladas en el sistema?

Instale las fuentes que faltan o [configure fuentes de respaldo](/slides/es/net/powerpoint-fonts/). Aspose.Slides las sustituirá, pero la apariencia puede variar. Para la identidad corporativa, asegúrese siempre de que las tipografías requeridas estén disponibles explícitamente.

### ¿Puedo superponer una marca de agua sobre los fotogramas del GIF?

Sí. [Añada un objeto/logo semitransparente](/slides/es/net/watermark/) a la diapositiva maestra o a diapositivas individuales antes de la exportación — la marca de agua aparecerá en cada fotograma.