---
title: Convertir PowerPoint a GIF Animado
type: docs
weight: 65
url: /net/convert-powerpoint-to-animated-gif/
keywords: "Convertir PowerPoint, PPT, PPTX, GIF animado, PPT a GIF animado, PPTX a GIF animado C#, Csharp, .NET, configuraciones predeterminadas, configuraciones personalizadas"
description: "Convertir Presentación de PowerPoint a GIF animado: PPT a GIF, PPTX a GIF en C# o .NET"
---

## Convertir Presentaciones a GIF Animado Usando Configuraciones Predeterminadas ##

Este código de muestra en C# muestra cómo convertir una presentación a GIF animado utilizando configuraciones estándar:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

El GIF animado se creará con parámetros predeterminados. 

{{% alert title="TIP" color="primary" %}} 

Si prefieres personalizar los parámetros para el GIF, puedes utilizar la clase [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions). Consulta el código de muestra a continuación. 

{{% /alert %}} 

## Convertir Presentaciones a GIF Animado Usando Configuraciones Personalizadas ##
Este código de muestra muestra cómo convertir una presentación a GIF animado utilizando configuraciones personalizadas en C#:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // el tamaño del GIF resultante  
        DefaultDelay = 2000, // cuánto tiempo se mostrará cada diapositiva antes de cambiar a la siguiente
        TransitionFps = 35 // aumentar FPS para mejorar la calidad de la animación de transición
    });
}
```

{{% alert title="Info" color="info" %}}

Es posible que desees probar un convertidor GRATUITO de [Texto a GIF](https://products.aspose.app/slides/text-to-gif) desarrollado por Aspose. 

{{% /alert %}}