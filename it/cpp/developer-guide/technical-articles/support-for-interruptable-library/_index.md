---
title: Supporto per la libreria interrompibile
type: docs
weight: 150
url: /it/cpp/support-for-interruptable-library/
keywords:
- libreria interrompibile
- token di interruzione
- token di cancellazione
- attività a lunga durata
- interrompere attività
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Rendi annullabili le attività a lunga durata con Aspose.Slides per C++. Interrompi in modo sicuro il rendering e le conversioni per PowerPoint e OpenDocument, con esempi."
---
## **Panoramica**

Aspose.Slides fornisce un meccanismo di elaborazione interrompibile per attività di presentazione a lunga durata, come la deserializzazione, la serializzazione e il rendering. Questo meccanismo si basa sulle classi `InterruptionToken` e `InterruptionTokenSource`.

`InterruptionToken` può essere assegnato a `LoadOptions` e passato al costruttore `Presentation`. Quando viene chiamato `InterruptionTokenSource::Interrupt()`, l'attività a lunga durata associata viene interrotta.

## **Libreria Interrompibile**

In [Aspose.Slides 18.4](https://releases.aspose.com/slides/it/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/), abbiamo introdotto le classi [InterruptionToken](https://reference.aspose.com/slides/it/cpp/aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/it/cpp/aspose.slides/interruptiontokensource/). Esse consentono di interrompere attività a lunga durata come la deserializzazione, la serializzazione e il rendering.

- [InterruptionTokenSource](https://reference.aspose.com/slides/it/cpp/aspose.slides/interruptiontokensource/) è la sorgente del token(i) passato a [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_interruptiontoken/).
- Quando [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_interruptiontoken/) è impostato e l'istanza [LoadOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/) viene passata al costruttore [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/), l'invocazione di [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/it/cpp/aspose.slides/interruptiontokensource/interrupt/) interrompe qualsiasi attività a lunga durata associata a quel [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).

Il seguente frammento di codice dimostra come interrompere un'attività in esecuzione:

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
    
    Run(action, tokenSource->get_Token()); // esegui l'azione in un thread separato
    Threading::Thread::Sleep(10000);       // tempo di attesa
    tokenSource->Interrupt();              // interrompi la conversione
}
```

## **FAQ**

**Qual è lo scopo della libreria di interruzione di Aspose.Slides?**

Fornisce un meccanismo per interrompere operazioni a lunga durata—come il caricamento, il salvataggio o il rendering di presentazioni—prima che vengano completate. Questo è utile quando è necessario limitare il tempo di elaborazione o l'operazione non è più necessaria.

**Qual è la differenza tra [InterruptionToken](https://reference.aspose.com/slides/it/cpp/aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/it/cpp/aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` viene passato all'API di Aspose.Slides e controllato durante le operazioni a lunga durata.
- `InterruptionTokenSource` viene utilizzato nel tuo codice per creare token e attivare le interruzioni chiamando `Interrupt()`.

**Quali attività possono essere interrotte?**

Qualsiasi attività di Aspose.Slides che accetta un [InterruptionToken](https://reference.aspose.com/slides/it/cpp/aspose.slides/interruptiontoken/)—come il caricamento di una presentazione con `Presentation(path, loadOptions)` o il salvataggio con `Presentation::Save(...)`—può essere interrotta.

**L'interruzione avviene immediatamente?**

No. L'interruzione è cooperativa: l'operazione verifica periodicamente il token e si ferma non appena rileva che [Interrupt()](https://reference.aspose.com/slides/it/cpp/aspose.slides/interruptiontokensource/interrupt/) è stato chiamato.

**Cosa succede se chiamo [Interrupt()](https://reference.aspose.com/slides/it/cpp/aspose.slides/interruptiontokensource/interrupt/) dopo che un'attività è già terminata?**

Niente—la chiamata non ha effetto se l'attività corrispondente è già completata.

**Posso riutilizzare lo stesso [InterruptionTokenSource](https://reference.aspose.com/slides/it/cpp/aspose.slides/interruptiontokensource/) per più attività?**

Sì—but after you call [Interrupt()](https://reference.aspose.com/slides/it/cpp/aspose.slides/interruptiontokensource/interrupt/) on that source, all tasks using its tokens will be interrupted. Use separate token sources to manage tasks independently.