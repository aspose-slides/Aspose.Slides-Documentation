---
title: Multihilos en Aspose.Slides para C++
linktitle: Multihilos
type: docs
weight: 200
url: /es/cpp/multithreading/
keywords:
- multihilos
- varios hilos
- trabajo paralelo
- convertir diapositivas
- diapositivas a imágenes
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "El multihilos de Aspose.Slides para C++ mejora el procesamiento de PowerPoint y OpenDocument. Descubra las mejores prácticas para flujos de trabajo de presentación eficientes."
---

## **Introducción**

Si bien el trabajo en paralelo con presentaciones es posible (además del análisis/carga/clonado) y todo funciona bien (la mayoría de las veces), existe una pequeña probabilidad de obtener resultados incorrectos al usar la biblioteca en varios hilos.

Recomendamos encarecidamente que **no** use una única instancia de [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) en un entorno de multiproceso porque podría generar errores o fallos impredecibles que no se detectan fácilmente.

No es seguro cargar, guardar y/o clonar una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) en varios hilos. Estas operaciones **no** están soportadas. Si necesita realizar esas tareas, debe paralelizar las operaciones usando varios procesos monohilo, y cada uno de esos procesos debe usar su propia instancia de presentación.

## **Convertir diapositivas de presentación a imágenes en paralelo**

Supongamos que queremos convertir todas las diapositivas de una presentación de PowerPoint a imágenes PNG en paralelo. Dado que no es seguro usar una única instancia de `Presentation` en varios hilos, dividimos las diapositivas de la presentación en presentaciones separadas y convertimos las diapositivas a imágenes en paralelo, usando cada presentación en un hilo distinto. El siguiente ejemplo de código muestra cómo hacerlo.
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

// Esperar a que se completen todas las tareas.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```


## **Preguntas frecuentes**

**¿Necesito llamar a la configuración de licencia en cada hilo?**

No. Basta hacerlo una vez por proceso/ dominio de aplicación antes de que los hilos se inicien. Si la [license setup](/slides/es/cpp/licensing/) pudiera invocarse simultáneamente (por ejemplo, durante una inicialización perezosa), sincronice esa llamada porque el método de configuración de licencia en sí no es seguro para hilos.

**¿Puedo pasar objetos `Presentation` o `Slide` entre hilos?**

Pasar objetos de presentación “en vivo” entre hilos no se recomienda: use instancias independientes por hilo o precree presentaciones/contendedores de diapositivas separados para cada hilo. Este enfoque sigue la recomendación general de no compartir una única instancia de presentación entre hilos.

**¿Es seguro paralelizar la exportación a diferentes formatos (PDF, HTML, imágenes) siempre que cada hilo tenga su propia instancia de `Presentation`?**

Sí. Con instancias independientes y rutas de salida separadas, esas tareas suelen paralelizarse correctamente; evite cualquier objeto de presentación compartido y corrientes de E/S compartidas.

**¿Qué debo hacer con la configuración global de fuentes (carpetas, sustituciones) en multiproceso?**

Inicialice todas las configuraciones globales de fuentes antes de iniciar los hilos y no las modifique durante el trabajo en paralelo. Esto elimina condiciones de carrera al acceder a recursos de fuentes compartidos.