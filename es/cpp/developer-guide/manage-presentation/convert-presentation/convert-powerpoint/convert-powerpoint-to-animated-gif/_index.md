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
## **Visión general**

Aspose.Slides le permite convertir presentaciones de PowerPoint a archivos GIF animados con solo unas pocas líneas de código. Esto es útil cuando necesita compartir el contenido de las diapositivas en un formato animado ligero y ampliamente compatible que puede incrustarse en páginas web, mensajeros o documentación. Este artículo explica cómo exportar una presentación a GIF usando la configuración predeterminada y cómo personalizar la salida configurando opciones como el tamaño del fotograma, el retraso entre diapositivas y la velocidad de fotogramas de transición mediante [GifOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/gifoptions/).

## **Convertir presentaciones a GIF animado usando la configuración predeterminada**

Este fragmento de código en C++ le muestra cómo convertir una presentación a GIF animado usando la configuración estándar:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

El GIF animado se creará con los parámetros predeterminados. 

{{%  alert  title="TIP"  color="info"  %}} 

Si prefiere personalizar los parámetros del GIF, puede utilizar la clase [GifOptions](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.export.gif_options). Vea el código de ejemplo a continuación. 

{{% /alert %}} 

## **Convertir presentaciones a GIF animado usando configuración personalizada**

Este fragmento de código le muestra cómo convertir una presentación a GIF animado usando configuración personalizada en C++:

``` cpp
#include <DOM/Presentation.h>
#include <Export/GifOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto gifOptions = System::MakeObject<GifOptions>();
// el tamaño del GIF resultante
gifOptions->set_FrameSize(System::Drawing::Size(960, 720));
// cuánto tiempo se mostrará cada diapositiva antes de cambiar a la siguiente
gifOptions->set_DefaultDelay(2000);
// aumentar FPS para mejorar la calidad de la animación de transición
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}

Puede probar un conversor GRATUITO de [Text to GIF](https://products.aspose.app/slides/es/text-to-gif) desarrollado por Aspose. 

{{% /alert %}}

## **FAQ**

### ¿Qué ocurre si las fuentes utilizadas en la presentación no están instaladas en el sistema?

Instale las fuentes faltantes o [configure fuentes de respaldo](/slides/es/cpp/powerpoint-fonts/). Aspose.Slides realizará una sustitución, pero la apariencia puede variar. Para la identidad corporativa, siempre asegúrese de que los tipos de letra requeridos estén disponibles explícitamente.

### ¿Puedo superponer una marca de agua en los fotogramas del GIF?

Sí. [Añada un objeto/logo semitransparente](/slides/es/cpp/watermark/) a la diapositiva maestra o a diapositivas individuales antes de la exportación; la marca de agua aparecerá en cada fotograma.