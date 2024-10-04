---
title: Obtener el Fondo Completo de la Diapositiva de Presentación como una Imagen
type: docs
weight: 95
url: /cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- diapositiva
- fondo
- fondo de diapositiva
- fondo a una imagen
- PowerPoint
- PPT
- PPTX
- presentación de PowerPoint
- C++
- Aspose.Slides para C++
---

En las presentaciones de PowerPoint, el fondo de la diapositiva puede consistir en muchos elementos. Además de la imagen establecida como el [fondo de diapositiva](/slides/cpp/presentation-background/), el fondo final puede estar influenciado por el tema de la presentación, el esquema de color y las formas colocadas en la diapositiva maestra y en la diapositiva de diseño.

Aspose.Slides para C++ no proporciona un método sencillo para extraer el fondo completo de la diapositiva de presentación como una imagen, pero puedes seguir los pasos a continuación para hacerlo:
1. Carga la presentación utilizando la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtén el tamaño de la diapositiva de la presentación.
1. Selecciona una diapositiva.
1. Crea una presentación temporal.
1. Establece el mismo tamaño de diapositiva en la presentación temporal.
1. Clona la diapositiva seleccionada en la presentación temporal.
1. Elimina las formas de la diapositiva clonada.
1. Convierte la diapositiva clonada a una imagen.

El siguiente ejemplo de código extrae el fondo completo de la diapositiva de presentación como una imagen.
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