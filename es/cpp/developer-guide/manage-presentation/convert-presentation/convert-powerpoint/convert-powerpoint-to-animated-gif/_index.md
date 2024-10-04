---
title: Convertir PowerPoint a GIF Animado
type: docs
weight: 65
url: /cpp/convert-powerpoint-to-animated-gif/
keywords: "Convertir PowerPoint a GIF animado, "
description: "Convertir PowerPoint a GIF animado: PPT a GIF, PPTX a GIF, con la API Aspose.Slides."
---

## Convertir Presentaciones a GIF Animado Usando Configuraciones Predeterminadas ##

Este código de muestra en C++ te muestra cómo convertir una presentación a GIF animado usando configuraciones estándar:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

El GIF animado se creará con parámetros predeterminados.

{{%  alert  title="CONSEJO"  color="primary"  %}} 

Si prefieres personalizar los parámetros para el GIF, puedes usar la clase [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options). Consulta el código de muestra a continuación.

{{% /alert %}} 

## Convertir Presentaciones a GIF Animado Usando Configuraciones Personalizadas ##
Este código de muestra te muestra cómo convertir una presentación a GIF animado usando configuraciones personalizadas en C++:

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// el tamaño del GIF resultante
gifOptions->set_FrameSize(Size(960, 720));
// cuánto tiempo se mostrará cada diapositiva antes de cambiar a la siguiente
gifOptions->set_DefaultDelay(2000);
// aumentar FPS para mejorar la calidad de transición de animación
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Información" color="info" %}}

Puede que desees consultar un conversor GRATUITO de [Texto a GIF](https://products.aspose.app/slides/text-to-gif) desarrollado por Aspose.

{{% /alert %}}