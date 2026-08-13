---
title: Convertir PPT y PPTX a JPG en C++
linktitle: PowerPoint a JPG
type: docs
weight: 60
url: /es/cpp/convert-powerpoint-to-jpg/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a JPG
- presentación a JPG
- diapositiva a JPG
- PPT a JPG
- PPTX a JPG
- guardar PowerPoint como JPG
- guardar presentación como JPG
- guardar diapositiva como JPG
- guardar PPT como JPG
- guardar PPTX como JPG
- exportar PPT a JPG
- exportar PPTX a JPG
- C++
- Aspose.Slides
description: "Convierte diapositivas de PowerPoint (PPT, PPTX) a imágenes JPG de alta calidad en C++ con Aspose.Slides usando ejemplos de código rápidos y fiables."
---
## **Introducción**

Convertir presentaciones de PowerPoint y OpenDocument a imágenes JPG ayuda a compartir diapositivas, optimizar el rendimiento e incrustar contenido en sitios web o aplicaciones. Aspose.Slides para C++ le permite transformar archivos PPTX, PPT y ODP en imágenes JPEG de alta calidad. Esta guía explica los diferentes métodos de conversión.

Con estas funciones, es fácil implementar su propio visor de presentaciones y crear una miniatura para cada diapositiva. Esto puede ser útil si desea proteger las diapositivas de la copia o demostrar la presentación en modo solo lectura. Aspose.Slides permite convertir la presentación completa o una diapositiva específica a formatos de imagen.

## **Convertir diapositivas de la presentación a imágenes JPG**

A continuación se indican los pasos para convertir un archivo PPT, PPTX o ODP a JPG:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
1. Obtenga el objeto diapositiva del tipo [ISlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/) a partir de la colección de diapositivas de la presentación.
1. Cree una imagen de la diapositiva usando el método [ISlide.GetImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/getimage/).
1. Llame al método [IImage.Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/save/) del objeto imagen. Pase el nombre del archivo de salida y el formato de imagen como argumentos.

{{% alert color="info" %}} 

**Nota:** La conversión de PPT, PPTX o ODP a JPG difiere de la conversión a otros formatos en la API de Aspose.Slides para C++. Para otros formatos, normalmente utiliza el método [IPresentation.Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/save/). Sin embargo, para la conversión a JPG, debe usar el método [IImage.Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/save/).

{{% /alert %}} 

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/enumerator_adapter.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Crear una imagen de diapositiva con la escala especificada.
    auto image = slide->GetImage(scaleX, scaleY);

    // Guardar la imagen en disco en formato JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Convertir diapositivas a JPG con dimensiones personalizadas**

Para cambiar las dimensiones de las imágenes JPG resultantes, puede establecer el tamaño de la imagen pasando un valor al método [ISlide.GetImage(Size)](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method). Esto le permite generar imágenes con valores específicos de ancho y alto, garantizando que la salida cumpla con sus requisitos de resolución y relación de aspecto. Esta flexibilidad es particularmente útil al generar imágenes para aplicaciones web, informes o documentación, donde se requieren dimensiones precisas.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

System::Drawing::Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Crear una imagen de diapositiva con el tamaño especificado.
    auto image = slide->GetImage(imageSize);

    // Guardar la imagen en disco en formato JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Representar comentarios al guardar diapositivas como imágenes**

Aspose.Slides para C++ ofrece una función que permite representar los comentarios en las diapositivas de una presentación al convertirlas en imágenes JPG. Esta funcionalidad es especialmente útil para preservar anotaciones, comentarios o discusiones añadidas por colaboradores en presentaciones de PowerPoint. Al habilitar esta opción, se asegura de que los comentarios sean visibles en las imágenes generadas, facilitando la revisión y el intercambio de opiniones sin necesidad de abrir el archivo original de la presentación.

Supongamos que tenemos un archivo de presentación, "sample.pptx", con una diapositiva que contiene comentarios:

![La diapositiva con comentarios](slide_with_comments.png)

El siguiente código C++ convierte la diapositiva a una imagen JPG preservando los comentarios:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Establecer opciones para los comentarios de la diapositiva.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // Convertir la primera diapositiva a una imagen.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

El resultado:

![La imagen JPG con comentarios](image_with_comments.png)

## **Ver también**

Consulte otras opciones para convertir PPT, PPTX o ODP a imágenes, como:

- [Convertir PowerPoint a GIF](/slides/es/cpp/convert-powerpoint-to-animated-gif/)
- [Convertir PowerPoint a PNG](/slides/es/cpp/convert-powerpoint-to-png/)
- [Convertir PowerPoint a TIFF](/slides/es/cpp/convert-powerpoint-to-tiff/)
- [Convertir PowerPoint a SVG](/slides/es/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

Para ver cómo Aspose.Slides convierte PowerPoint a imágenes JPG, pruebe estos convertidores en línea gratuitos: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/es/conversion/pptx-to-jpg) y [PPT to JPG](https://products.aspose.app/slides/es/conversion/ppt-to-jpg). 

{{% /alert %}}

![Convertidor en línea gratuito de PPTX a JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose ofrece una aplicación web [GRATUITA de Collage](https://products.aspose.app/slides/es/collage). Con este servicio en línea, puede combinar imágenes [JPG a JPG](https://products.aspose.app/slides/es/collage/jpg) o PNG a PNG, crear [cuadrículas de fotos](https://products.aspose.app/slides/es/collage/photo-grid) y mucho más. 

Usando los mismos principios descritos en este artículo, puede convertir imágenes de un formato a otro. Para más información, consulte estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/es/cpp/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/es/cpp/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/es/cpp/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/es/cpp/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/es/cpp/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/es/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Preguntas frecuentes**

### ¿Este método admite la conversión por lotes?

Sí, Aspose.Slides permite la conversión por lotes de múltiples diapositivas a JPG en una única operación.

### ¿La conversión admite SmartArt, gráficos y otros objetos complejos?

Sí, Aspose.Slides representa todo el contenido, incluidos SmartArt, gráficos, tablas, formas y más. Sin embargo, la precisión del renderizado puede variar ligeramente respecto a PowerPoint, especialmente al usar fuentes personalizadas o faltantes.

### ¿Hay limitaciones en el número de diapositivas que se pueden procesar?

Aspose.Slides en sí no impone límites estrictos al número de diapositivas que puede procesar. No obstante, podría encontrar errores de falta de memoria al trabajar con presentaciones muy grandes o imágenes de alta resolución.