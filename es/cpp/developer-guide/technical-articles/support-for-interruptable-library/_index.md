---
title: Soporte para Biblioteca Interrumpible
type: docs
weight: 150
url: /cpp/support-for-interruptable-library/
---

## **Biblioteca Interrumpible**
Las clases [InterruptionToken](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token) y [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source) han sido añadidas a Aspose.Slides para C++. Estos tipos soportan la interrupción de tareas de larga duración, como deserialización, serialización o renderizado. El [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source) representa la fuente del token o múltiples tokens pasados al método [LoadOptions.set_InterruptionToken()](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options#a9caea79d46cd939505687fdf634530a5). Cuando se establece el token de interrupción y la instancia de [LoadOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options) se pasa al constructor de [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), cualquier tarea de larga duración relacionada con esta presentación será interrumpida cuando se invoque el método [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source#a98ba5fd8badce28a63b5d30a2cfa1e83).

El siguiente fragmento de código demuestra cómo interrumpir una tarea en ejecución.

``` cpp
void Run(Action<SharedPtr<IInterruptionToken>> action, SharedPtr<IInterruptionToken> token)
{
    auto thread_function = std::function<void()>([&action, &token]() -> void
    {
        action(token);
    });

    auto thread = System::MakeObject<Threading::Thread>(thread_function);
    thread->Start();
}

void Run()
{
    String dataDir = GetDataPath();

    auto function = std::function<void(SharedPtr<IInterruptionToken> token)> ([&dataDir](SharedPtr<IInterruptionToken> token) -> void
    {
        SharedPtr<LoadOptions> options = System::MakeObject<LoadOptions>();
        options->set_InterruptionToken(token);

        SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(dataDir + u"pres.pptx", options);
        presentation->Save(dataDir + u"pres.ppt", Export::SaveFormat::Ppt);
    });
    auto action = System::Action<SharedPtr<IInterruptionToken>>(function);

    auto tokenSource = System::MakeObject<InterruptionTokenSource>();
    // ejecutar acción en un hilo separado
    Run(action, tokenSource->get_Token());
    // tiempo de espera
    Threading::Thread::Sleep(5000);
    // detener conversión
    tokenSource->Interrupt();
}
```