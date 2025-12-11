---
title: Obtener el fondo completo de la diapositiva de una presentación como imagen
linktitle: Fondo completo de diapositiva
type: docs
weight: 95
url: /es/cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- fondo de diapositiva
- fondo final
- extraer fondo
- fondo completo
- fondo a imagen
- fondo PPT
- fondo PPTX
- fondo ODP
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Extrae fondos de diapositiva completos como imágenes de presentaciones PowerPoint y OpenDocument usando Aspose.Slides para C++, agilizando los flujos de trabajo visuales."
---

## **Obtener el fondo completo de la diapositiva**

En presentaciones de PowerPoint, el fondo de la diapositiva puede constar de muchos elementos. Además de la imagen establecida como el [fondo de la diapositiva](/slides/es/cpp/presentation-background/), el fondo final puede verse influenciado por el tema de la presentación, el esquema de colores y las formas colocadas en la diapositiva maestra y en la diapositiva de diseño.

Aspose.Slides for C++ no proporciona un método sencillo para extraer el fondo completo de la diapositiva de la presentación como una imagen, pero puede seguir los pasos a continuación para hacerlo:
1. Cargue la presentación usando la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenga el tamaño de la diapositiva de la presentación.
1. Seleccione una diapositiva.
1. Cree una presentación temporal.
1. Establezca el mismo tamaño de diapositiva en la presentación temporal.
1. Clone la diapositiva seleccionada en la presentación temporal.
1. Elimine las formas de la diapositiva clonada.
1. Convierta la diapositiva clonada a una imagen.

El siguiente ejemplo de código extrae el fondo completo de la diapositiva de la presentación como una imagen.
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```


## **Preguntas frecuentes**

**¿Se preservarán los degradados complejos, texturas o rellenos de imagen de una diapositiva maestra en la imagen de fondo resultante?**

Sí. Aspose.Slides renderiza los rellenos de degradado, imagen y textura definidos en la diapositiva, el diseño o la maestra. Si necesita aislar el aspecto de las maestras heredadas, [establezca un fondo propio](/slides/es/cpp/presentation-background/) en la diapositiva actual antes de exportar.

**¿Puedo añadir una marca de agua a la imagen de fondo resultante antes de guardarla?**

Sí. Puede [añadir una marca de agua](/slides/es/cpp/watermark/) como forma o imagen en una [copia de trabajo de la diapositiva](/slides/es/cpp/clone-slides/) (colocada detrás de otro contenido) y luego exportar. Esto le permite generar una imagen de fondo con la marca de agua incorporada.

**¿Puedo obtener el fondo de un diseño o maestro específico sin asociarlo a una diapositiva existente?**

Sí. Acceda al maestro o diseño deseado, aplíquelo a una [diapositiva temporal](/slides/es/cpp/clone-slides/) con el tamaño requerido y exporte esa diapositiva para obtener el fondo derivado de ese diseño o maestro.

**¿Existen limitaciones de licencia que afecten la exportación de imágenes?**

Las funciones de renderizado están totalmente disponibles con una [licencia válida](/slides/es/cpp/licensing/). En modo de evaluación, la salida puede incluir limitaciones como una marca de agua. Active la licencia una vez por proceso antes de ejecutar exportaciones por lotes.