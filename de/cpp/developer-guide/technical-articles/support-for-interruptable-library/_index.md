---
title: Unterstützung für die Interruptable-Bibliothek
type: docs
weight: 150
url: /de/cpp/support-for-interruptable-library/
keywords:
- Interruptable-Bibliothek
- Interruptions-Token
- Abbruch-Token
- Langlaufende Aufgabe
- Aufgabe unterbrechen
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Machen Sie langlaufende Aufgaben mit Aspose.Slides für C++ abbrechbar. Unterbrechen Sie das Rendern und die Konvertierung für PowerPoint und OpenDocument sicher, mit Beispielen."
---

## **Interruptable Bibliothek**

In [Aspose.Slides 18.4](https://releases.aspose.com/slides/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/), haben wir die Klassen [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) und [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) eingeführt. Sie ermöglichen das Unterbrechen von langlaufenden Aufgaben wie Deserialisierung, Serialisierung und Rendering.

- [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) ist die Quelle der(s) Token(s), die an [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) übergeben werden.
- Wenn [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) gesetzt ist und die [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/)‑Instanz an den [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Konstruktor übergeben wird, unterbricht das Aufrufen von [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) jede langlaufende Aufgabe, die mit dieser [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) verknüpft ist.

Der folgende Codeabschnitt demonstriert das Unterbrechen einer laufenden Aufgabe:
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
    
    Run(action, tokenSource->get_Token()); // führt die Aktion in einem separaten Thread aus
    Threading::Thread::Sleep(10000);       // Zeitlimit
    tokenSource->Interrupt();              // stoppt die Konvertierung
}
```


## **FAQ**

**Was ist der Zweck der Aspose.Slides Interrupt-Bibliothek?**

Sie bietet einen Mechanismus, um langlaufende Vorgänge – wie das Laden, Speichern oder Rendern von Präsentationen – vor dem Abschluss zu unterbrechen. Dies ist nützlich, wenn die Verarbeitungszeit begrenzt werden muss oder die Aufgabe nicht mehr benötigt wird.

**Was ist der Unterschied zwischen [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) und [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` wird an die Aspose.Slides‑API übergeben und während langlaufender Vorgänge überprüft.
- `InterruptionTokenSource` wird in Ihrem Code verwendet, um Token zu erstellen und Unterbrechungen auszulösen, indem `Interrupt()` aufgerufen wird.

**Welche Aufgaben können unterbrochen werden?**

Jede Aspose.Slides‑Aufgabe, die ein [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) akzeptiert – z. B. das Laden einer Präsentation mit `Presentation(path, loadOptions)` oder das Speichern mit `Presentation::Save(...)` – kann unterbrochen werden.

**Geschieht die Unterbrechung sofort?**

Nein. Die Unterbrechung ist kooperativ: Der Vorgang prüft das Token periodisch und stoppt, sobald er erkennt, dass [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) aufgerufen wurde.

**Was passiert, wenn ich [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) aufrufe, nachdem eine Aufgabe bereits abgeschlossen ist?**

Nichts – der Aufruf hat keine Wirkung, wenn die entsprechende Aufgabe bereits abgeschlossen ist.

**Kann ich dieselbe [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) für mehrere Aufgaben wiederverwenden?**

Ja – jedoch werden nach dem Aufruf von [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) auf dieser Quelle alle Aufgaben, die deren Token verwenden, unterbrochen. Verwenden Sie separate Token‑Quellen, um Aufgaben unabhängig zu verwalten.