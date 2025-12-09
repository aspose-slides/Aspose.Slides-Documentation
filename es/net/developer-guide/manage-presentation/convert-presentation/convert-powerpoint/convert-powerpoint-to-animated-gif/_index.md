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

## **Convertir presentaciones a GIF animado usando la configuración predeterminada**

Este código de ejemplo en C# le muestra cómo convertir una presentación a GIF animado usando la configuración estándar:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```


El GIF animado se creará con parámetros predeterminados. 

{{%  alert  title="TIP"  color="primary"  %}} 
Si prefiere personalizar los parámetros del GIF, puede usar la clase [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions). Vea el código de ejemplo a continuación. 
{{% /alert %}} 

## **Convertir presentaciones a GIF animado usando configuración personalizada**

Este código de ejemplo le muestra cómo convertir una presentación a GIF animado usando configuración personalizada en C#:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // el tamaño del GIF resultante  
        DefaultDelay = 2000, // duración de cada diapositiva antes de pasar a la siguiente
        TransitionFps = 35 // aumentar FPS para mejorar la calidad de la animación de transición
    });
}
```


{{% alert title="Info" color="info" %}}
Puede que quiera probar un conversor GRATUITO de [Texto a GIF](https://products.aspose.app/slides/text-to-gif) desarrollado por Aspose. 
{{% /alert %}}

## **Preguntas frecuentes**

**¿Qué sucede si las fuentes usadas en la presentación no están instaladas en el sistema?**

Instale las fuentes faltantes o [configure fuentes de respaldo](/slides/es/net/powerpoint-fonts/). Aspose.Slides las sustituirá, pero la apariencia puede variar. Para la marca, siempre asegúrese de que los tipos de letra requeridos estén disponibles explícitamente.

**¿Puedo superponer una marca de agua en los fotogramas del GIF?**

Sí. [Agregue un objeto/logo semitransparente](/slides/es/net/watermark/) a la diapositiva maestra o a diapositivas individuales antes de la exportación — la marca de agua aparecerá en cada fotograma.