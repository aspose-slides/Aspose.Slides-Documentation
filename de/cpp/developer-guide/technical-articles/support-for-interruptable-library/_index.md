---
title: Unterstützung für störbare Bibliothek
type: docs
weight: 150
url: /de/cpp/support-for-interruptable-library/
---

## **Störbare Bibliothek**
Die [InterruptionToken](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token) und [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source) Klassen wurden zu Aspose.Slides für C++ hinzugefügt. Diese Typen unterstützen die Unterbrechung von langlaufenden Aufgaben, wie Deserialisierung, Serialisierung oder Rendering. Die [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source) repräsentiert die Quelle des Tokens oder mehrere Tokens, die an die [LoadOptions.set_InterruptionToken()](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options#a9caea79d46cd939505687fdf634530a5) Methode übergeben werden. Wenn das Unterbrechungs-Token gesetzt ist und die [LoadOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options) Instanz an den [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Konstruktor übergeben wird, wird jede langlaufende Aufgabe, die mit dieser Präsentation verbunden ist, unterbrochen, wenn die Methode [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source#a98ba5fd8badce28a63b5d30a2cfa1e83) aufgerufen wird.

Der folgende Code-Ausschnitt zeigt, wie eine laufende Aufgabe unterbrochen wird.

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
    // Aktion in einem separaten Thread ausführen
    Run(action, tokenSource->get_Token());
    // Timeout
    Threading::Thread::Sleep(5000);
    // Konvertierung stoppen
    tokenSource->Interrupt();
}
```