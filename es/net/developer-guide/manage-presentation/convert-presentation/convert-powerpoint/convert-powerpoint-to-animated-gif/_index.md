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

Este código de ejemplo en C# muestra cómo convertir una presentación a GIF animado usando la configuración estándar:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```


El GIF animado se creará con los parámetros predeterminados. 

{{%  alert  title="CONSEJO"  color="primary"  %}} 
Si prefieres personalizar los parámetros del GIF, puedes usar la clase [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions). Consulta el código de ejemplo a continuación. 
{{% /alert %}} 

## **Convertir presentaciones a GIF animado usando configuración personalizada**

Este código de ejemplo muestra cómo convertir una presentación a GIF animado usando configuración personalizada en C#:
``` csharp
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


{{% alert title="Información" color="info" %}}
Puede que quieras probar un conversor GRATUITO de [Texto a GIF](https://products.aspose.app/slides/text-to-gif) desarrollado por Aspose. 
{{% /alert %}}

## **Preguntas frecuentes**

**¿Qué pasa si las fuentes usadas en la presentación no están instaladas en el sistema?**

Instala las fuentes faltantes o [configura fuentes de respaldo](/slides/es/net/powerpoint-fonts/). Aspose.Slides las sustituirá, pero la apariencia podría variar. Para mantener la consistencia de la marca, siempre asegura que los tipos de letra requeridos estén disponibles explícitamente.

**¿Puedo superponer una marca de agua en los fotogramas del GIF?**

Sí. [Añade un objeto/logo semitransparente](/slides/es/net/watermark/) a la diapositiva maestra o a diapositivas individuales antes de exportar — la marca de agua aparecerá en cada fotograma.