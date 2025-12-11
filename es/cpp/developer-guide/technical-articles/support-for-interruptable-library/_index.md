---
title: Soporte para la biblioteca interruptible
type: docs
weight: 150
url: /es/cpp/support-for-interruptable-library/
keywords:
- biblioteca interruptible
- token de interrupción
- token de cancelación
- tarea de larga duración
- interrumpir tarea
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Haz que las tareas de larga duración sean cancelables con Aspose.Slides para C++. Interrumpe de forma segura el renderizado y las conversiones para PowerPoint y OpenDocument, con ejemplos."
---

## **Biblioteca Interrumpible**

En [Aspose.Slides 18.4](https://releases.aspose.com/slides/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/), introdujimos las clases [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) y [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/). Permiten interrumpir tareas de larga duración como deserialización, serialización y renderizado.

- [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) es la fuente del/los token(s) que se pasan a [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/).
- Cuando se establece [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) y la instancia de [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) se pasa al constructor de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), invocar [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) interrumpe cualquier tarea de larga duración asociada a esa [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).

El siguiente fragmento de código muestra cómo interrumpir una tarea en ejecución:
```cpp
void Run(Action<SharedPtr<IInterruptionToken>> action, SharedPtr<IInterruptionToken> token)
{
    auto threadFunction = std::function<void()>([&action, &token]() -> void
    {
        action(token);
    });

    auto thread = System::MakeObject<Threading::Thread>(threadFunction);
    thread->Start();
}

void Run()
{
    String dataDir = GetDataPath();

    auto function = std::function<void(SharedPtr<IInterruptionToken> token)> ([&dataDir](SharedPtr<IInterruptionToken> token) -> void
    {
        auto options = System::MakeObject<LoadOptions>();
        options->set_InterruptionToken(token);

        auto presentation = System::MakeObject<Presentation>(dataDir + u"sample.pptx", options);
        presentation->Save(dataDir + u"sample.ppt", Export::SaveFormat::Ppt);
    });

    auto action = System::Action<SharedPtr<IInterruptionToken>>(function);
    auto tokenSource = System::MakeObject<InterruptionTokenSource>();
    
    Run(action, tokenSource->get_Token()); // ejecutar la acción en un hilo separado
    Threading::Thread::Sleep(10000);       // tiempo de espera
    tokenSource->Interrupt();              // detener la conversión
}
```


## **FAQ**

**¿Cuál es el propósito de la biblioteca de interrupción de Aspose.Slides?**

Proporciona un mecanismo para interrumpir operaciones de larga duración —como cargar, guardar o renderizar presentaciones— antes de que se completen. Es útil cuando se debe limitar el tiempo de procesamiento o la tarea ya no es necesaria.

**¿Cuál es la diferencia entre [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) y [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` se pasa a la API de Aspose.Slides y se verifica durante las operaciones de larga duración.
- `InterruptionTokenSource` se utiliza en tu código para crear tokens y generar interrupciones llamando a `Interrupt()`.

**¿Qué tareas pueden interrumpirse?**

Cualquier tarea de Aspose.Slides que acepte un [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) —como cargar una presentación con `Presentation(path, loadOptions)` o guardar con `Presentation::Save(...)`— puede interrumpirse.

**¿La interrupción ocurre inmediatamente?**

No. La interrupción es cooperativa: la operación verifica periódicamente el token y se detiene tan pronto como detecta que se ha llamado a [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/).

**¿Qué ocurre si llamo a [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) después de que una tarea ya se haya completado?**

Nada —la llamada no tiene efecto si la tarea correspondiente ya ha finalizado.

**¿Puedo reutilizar el mismo [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) para varias tareas?**

Sí, pero después de llamar a [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) en esa fuente, todas las tareas que usan sus tokens serán interrumpidas. Utiliza fuentes de token separadas para gestionar las tareas de forma independiente.