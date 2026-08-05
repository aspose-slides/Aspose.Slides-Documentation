---
title: Extracción avanzada de texto de presentaciones en C++
linktitle: Extraer texto
type: docs
weight: 90
url: /es/cpp/extract-text-from-presentation/
aliases:
  - /cpp/extracting-text-from-the-presentation/
keywords:
- extraer texto
- extraer texto de diapositiva
- extraer texto de presentación
- extraer texto de PowerPoint
- extraer texto de OpenDocument
- extraer texto de PPT
- extraer texto de PPTX
- extraer texto de ODP
- recuperar texto
- recuperar texto de diapositiva
- recuperar texto de presentación
- recuperar texto de PowerPoint
- recuperar texto de OpenDocument
- recuperar texto de PPT
- recuperar texto de PPTX
- recuperar texto de ODP
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Extrae texto rápidamente de presentaciones PowerPoint y OpenDocument usando Aspose.Slides para C++. Sigue nuestra guía sencilla, paso a paso, para ahorrar tiempo."
---
## **Visión general**

Extraer texto de presentaciones es una tarea común pero esencial para los desarrolladores que trabajan con contenido de diapositivas. Ya sea que estés manejando archivos de Microsoft PowerPoint en formato PPT o PPTX, o presentaciones OpenDocument (ODP), el acceso y la recuperación de datos de texto pueden ser críticos para el análisis, la automatización, la indexación o la migración de contenido.

Este artículo ofrece una guía completa sobre cómo extraer texto de forma eficiente de varios formatos de presentación, incluidos PPT, PPTX y ODP, usando Aspose.Slides for C++. Aprenderás a iterar sistemáticamente a través de los elementos de la presentación para recuperar con precisión el contenido de texto que necesitas.

## **Extraer texto de una diapositiva**

Aspose.Slides for C++ proporciona el espacio de nombres [Aspose.Slides.Util](https://reference.aspose.com/slides/es/cpp/aspose.slides.util/), que incluye la clase [SlideUtil](https://reference.aspose.com/slides/es/cpp/aspose.slides.util/slideutil/). Esta clase expone varios métodos estáticos sobrecargados para extraer todo el texto de una presentación o diapositiva. Para extraer texto de una diapositiva en una presentación, utiliza el método [GetAllTextBoxes](https://reference.aspose.com/slides/es/cpp/aspose.slides.util/slideutil/getalltextboxes/). Este método acepta un objeto del tipo [IBaseSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseslide/) como parámetro. Al ejecutarse, el método escanea toda la diapositiva en busca de texto y devuelve una matriz de objetos del tipo [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/), conservando cualquier formato de texto.

El siguiente fragmento de código extrae todo el texto de la primera diapositiva de la presentación:

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Extraer texto de una presentación**

Para escanear texto de la presentación completa, utiliza el método estático [GetAllTextFrames](https://reference.aspose.com/slides/es/cpp/aspose.slides.util/slideutil/getalltextframes/) expuesto por la clase [SlideUtil](https://reference.aspose.com/slides/es/cpp/aspose.slides.util/slideutil/). Acepta dos parámetros:

1. Primero, un objeto [IPresentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/) que representa una presentación de PowerPoint o OpenDocument de la cual se extraerá el texto.
1. Segundo, un valor `Boolean` que indica si se deben incluir las diapositivas maestras al escanear el texto de la presentación.

El método devuelve una matriz de objetos del tipo [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/), que incluye información de formato de texto. El código a continuación escanea el texto y los detalles de formato de una presentación, incluidas las diapositivas maestras.

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Extracción de texto categorizada y rápida**

La clase [PresentationFactory](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentationfactory/) también proporciona métodos para extraer todo el texto de presentaciones:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

El enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/es/cpp/aspose.slides/textextractionarrangingmode/) indica el modo para organizar el resultado de la extracción de texto y puede establecerse a los siguientes valores:

- `Unarranged` - El texto sin formato sin respetar su posición en la diapositiva.
- `Arranged` - El texto se organiza en el mismo orden que en la diapositiva.

El modo sin organizar puede usarse cuando la velocidad es crítica; es más rápido que el modo organizado.

[IPresentationText](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationtext/) representa el texto bruto extraído de la presentación. Su método `get_SlidesText()` devuelve una matriz de objetos del tipo [ISlideText](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidetext/). Cada objeto representa el texto de la diapositiva correspondiente. El objeto del tipo [ISlideText](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidetext/) tiene los siguientes métodos:

- `get_Text()` - El texto dentro de las formas de la diapositiva.
- `get_MasterText()` - El texto dentro de las formas de la diapositiva maestra asociada a esta diapositiva.
- `get_LayoutText()` - El texto dentro de las formas de la diapositiva de diseño asociada a esta diapositiva.
- `get_NotesText()` - El texto dentro de las formas de la diapositiva de notas asociada a esta diapositiva.
- `get_CommentsText()` - El texto dentro de los comentarios asociados a esta diapositiva.

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **Preguntas frecuentes**

**¿Qué tan rápido procesa Aspose.Slides presentaciones grandes durante la extracción de texto?**

Aspose.Slides está optimizado para alto rendimiento y puede procesar incluso [presentaciones grandes](/slides/es/cpp/open-presentation/), lo que lo hace adecuado para escenarios de procesamiento en tiempo real o por lotes.

**¿Puede Aspose.Slides extraer texto de tablas y gráficos dentro de las presentaciones?**

Sí. Aspose.Slides puede extraer texto de muchos elementos de la diapositiva, incluidas tablas y objetos relacionados con gráficos, de modo que puedas acceder y analizar el contenido textual en estructuras de presentación comunes.

**¿Necesito una licencia especial de Aspose.Slides para extraer texto de presentaciones?**

Puedes extraer texto usando la versión de prueba gratuita de Aspose.Slides, aunque tendrá [ciertas limitaciones](/slides/es/cpp/licensing/), como procesar solo un número limitado de diapositivas. Para un uso sin restricciones y para manejar presentaciones más grandes, se recomienda adquirir una licencia completa.