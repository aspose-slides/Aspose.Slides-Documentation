---
title: Multithreading en Aspose.Slides
type: docs
weight: 200
url: /es/cpp/multithreading/
keywords:
- PowerPoint
- presentación
- multithreading
- trabajo en paralelo
- convertir diapositivas
- diapositivas a imágenes
- C++
- Aspose.Slides para C++
---

## **Introducción**

Mientras que el trabajo en paralelo con presentaciones es posible (además de analizar/cargar/clonar) y todo va bien (la mayoría de las veces), hay una pequeña posibilidad de que obtengas resultados incorrectos cuando uses la biblioteca en múltiples hilos.

Recomendamos encarecidamente que **no** uses una única instancia de [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) en un entorno multihilo porque podría resultar en errores o fallos impredecibles que no se detectan fácilmente.

No es **seguro** cargar, guardar y/o clonar una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) en múltiples hilos. Tales operaciones **no** son compatibles. Si necesitas realizar tales tareas, debes paralelizar las operaciones usando varios procesos de un solo hilo, y cada uno de estos procesos debe utilizar su propia instancia de presentación.

## **Convertir Diapositivas de Presentación a Imágenes en Paralelo**

Digamos que queremos convertir todas las diapositivas de una presentación de PowerPoint a imágenes PNG en paralelo. Dado que no es seguro usar una única instancia de `Presentation` en múltiples hilos, separamos las diapositivas de la presentación en presentaciones separadas y convertimos las diapositivas a imágenes en paralelo, usando cada presentación en un hilo separado. El siguiente ejemplo de código muestra cómo hacerlo.

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Extraer la diapositiva i en una presentación separada.
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // Convertir la diapositiva a una imagen en una tarea separada.
    auto slideNumber = slideIndex + 1;
    conversionTasks.push_back(std::async(std::launch::async, [slidePresentation = std::move(slidePresentation), slideNumber, outputFilePathTemplate, imageScale]() {
        SharedPtr<IImage> image = nullptr;
        try {
            auto slide = slidePresentation->get_Slide(0);

            auto image = slide->GetImage(imageScale, imageScale);
            auto imageFilePath = String::Format(outputFilePathTemplate, slideNumber);
            image->Save(imageFilePath, ImageFormat::Png);
        }
        catch (Exception e) {
            if(image != nullptr) image->Dispose();
            slidePresentation->Dispose();
        }
    }));
}

// Esperar a que todas las tareas se completen.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```