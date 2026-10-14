---
title: Convertir diapositivas de PowerPoint a PNG en C++
linktitle: PowerPoint a PNG
type: docs
weight: 30
url: /es/cpp/convert-powerpoint-to-png/
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
- C++
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint a imágenes PNG de alta calidad rápidamente con Aspose.Slides para C++, garantizando resultados precisos y automatizados."
---
## **Visión general**

Este artículo explica cómo convertir diapositivas de presentación a imágenes PNG usando Aspose.Slides para C++. Puede cargar presentaciones en formatos como PPT, PPTX y ODP, renderizar cada diapositiva y guardarla como una imagen PNG separada.

Los ejemplos a continuación demuestran la renderización a escala predeterminada, el aumento de la escala, la especificación de las dimensiones de salida en píxeles y la elección de un estilo de renderizado de degradado.

## **Convertir PowerPoint a PNG**

Cargue una presentación con la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) y acceda a sus diapositivas mediante el accesor [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/). El ejemplo renderiza cada diapositiva con [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) sin parámetros para crear una miniatura. Luego llama a [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) con [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) para guardar cada diapositiva renderizada como una imagen PNG.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage();
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
La sobrecarga sin parámetros de [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) renderiza a una escala de 0.2. Por ejemplo, una diapositiva que mide 720 × 540 puntos produce una miniatura de 144 × 108 píxeles. Para controlar las dimensiones de salida, utilice las sobrecargas con factores de escala o un tamaño de imagen explícito que se muestra a continuación.
{{% /alert %}}

## **Convertir PowerPoint a PNG con dimensiones personalizadas**

Pasar factores de escala horizontal y vertical a [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) para controlar las dimensiones renderizadas. En este ejemplo, ambos factores son 2, por lo que una diapositiva que mide 720 × 540 puntos produce una imagen de 1440 × 1080 píxeles. Los factores de escala iguales conservan la relación de aspecto de la diapositiva. Cada imagen se guarda en formato PNG con [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto scaleX = 2.f;
auto scaleY = scaleX;

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Convertir PowerPoint a PNG con tamaño personalizado**

Para especificar las dimensiones de salida en píxeles, pase un tamaño a [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) en lugar de factores de escala. Este ejemplo renderiza cada diapositiva a 960 × 720 píxeles y guarda el resultado con [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/). Elija dimensiones que coincidan con la relación de aspecto de la diapositiva para evitar estirar la imagen.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <drawing/size.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto imageSize = System::Drawing::Size(960, 720);

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(imageSize);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Elegir un estilo de renderizado de degradado**

Suponga que una diapositiva contiene rellenos degradados, pero las transiciones en el PNG exportado aparecen más claras o de otro modo diferentes de lo que ve en PowerPoint. Puede usar el método [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) de [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) para escoger cómo se renderizan los degradados.

Descargue [gradient-styles.pptx](gradient-styles.pptx) y colóquelo en el directorio de trabajo de la aplicación. Su primera diapositiva contiene dos degradados lineales: cian a naranja en la parte superior y azul a amarillo en la parte inferior. Cada degradado tiene dos paradas, al 0 % y al 100 %.

El siguiente ejemplo carga esta presentación y renderiza la misma primera diapositiva en ambos modos con [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <DOM/GradientStyle.h>
#include <Export/RenderingOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"gradient-styles.pptx");
auto slide = presentation->get_Slide(0);

auto gradientStyles = { GradientStyle::Default, GradientStyle::PowerPointUI };
for (auto style : gradientStyles)
{
    auto options = MakeObject<RenderingOptions>();
    options->set_GradientStyle(style);

    auto image = slide->GetImage(options, 1.f, 1.f);
    auto styleName = style == GradientStyle::Default ? u"Default" : u"PowerPointUI";
    image->Save(String::Format(u"gradient-{0}.png", styleName), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

Las imágenes a continuación muestran la salida de la misma diapositiva, con ambos degradados en cada imagen:

| Default | PowerPointUI |
| --- | --- |
| ![Degradados de cian a naranja y de azul a amarillo renderizados con Default](gradient-Default.png) | ![Los mismos degradados renderizados con PowerPointUI](gradient-PowerPointUI.png) |

En este ejemplo, `Default` produce colores intermedios más claros, mientras que `PowerPointUI` produce colores intermedios más oscuros. La diferencia depende de los colores y de las paradas en el degradado.

Elija `Default` cuando la salida estándar de Aspose.Slides se ajuste a sus necesidades. Pruebe `PowerPointUI` cuando su prioridad sea que la apariencia coincida con PowerPoint. Compare ambas salidas con el resultado deseado; ninguno de los modos es universalmente preferible.

## **Preguntas frecuentes**

**¿Cómo puedo exportar una forma específica, como un gráfico o una imagen, en lugar de toda la diapositiva?**

Aspose.Slides admite [generar miniaturas para formas individuales](/slides/es/cpp/shape-thumbnails/), lo que le permite renderizar una forma como una imagen PNG.

**¿Se admite la conversión paralela en un servidor?**

Sí. Utilice una instancia de presentación separada para cada hilo o proceso; [no comparta una única instancia entre hilos](/slides/es/cpp/multithreading/).

**¿Cuáles son las limitaciones de evaluación al exportar a PNG?**

El modo de evaluación añade una marca de agua a las imágenes de salida y aplica [otras restricciones](/slides/es/cpp/licensing/) hasta que se aplique una licencia.