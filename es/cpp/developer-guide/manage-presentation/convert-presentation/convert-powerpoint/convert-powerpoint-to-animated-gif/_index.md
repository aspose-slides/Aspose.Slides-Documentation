---
title: Convertir presentaciones de PowerPoint a GIF animados en C++
linktitle: PowerPoint a GIF
type: docs
weight: 65
url: /es/cpp/convert-powerpoint-to-animated-gif/
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
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Convierta fácilmente presentaciones de PowerPoint (PPT, PPTX) a GIF animados con Aspose.Slides para C++. Resultados rápidos y de alta calidad."
---

## **Convertir presentaciones a GIF animado usando la configuración predeterminada**

Este código de ejemplo en C++ muestra cómo convertir una presentación a GIF animado usando la configuración estándar:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```


El GIF animado se creará con los parámetros predeterminados. 

{{%  alert  title="TIP"  color="primary"  %}} 

Si prefiere personalizar los parámetros del GIF, puede usar la clase [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options). Vea el código de ejemplo a continuación. 

{{% /alert %}} 

## **Convertir presentaciones a GIF animado usando configuraciones personalizadas**

Este código de ejemplo muestra cómo convertir una presentación a GIF animado usando configuraciones personalizadas en C++:
``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// el tamaño del GIF resultante 
gifOptions->set_FrameSize(Size(960, 720));
// cuánto tiempo se mostrará cada diapositiva antes de cambiar a la siguiente
gifOptions->set_DefaultDelay(2000);
// aumentar FPS para mejorar la calidad de la animación de transición
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```


{{% alert title="Info" color="info" %}}

Es posible que desee probar el conversor GRATUITO [Text to GIF](https://products.aspose.app/slides/text-to-gif) desarrollado por Aspose. 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Qué pasa si las fuentes usadas en la presentación no están instaladas en el sistema?**

Instale las fuentes faltantes o [configure fuentes de respaldo](/slides/es/cpp/powerpoint-fonts/). Aspose.Slides las sustituirá, pero la apariencia puede variar. Para la marca, siempre asegúrese de que los tipos de letra requeridos estén disponibles explícitamente.

**¿Puedo superponer una marca de agua en los fotogramas del GIF?**

Sí. [Agregue un objeto/logo semitransparente](/slides/es/cpp/watermark/) a la diapositiva maestra o a diapositivas individuales antes de exportar — la marca de agua aparecerá en cada fotograma.