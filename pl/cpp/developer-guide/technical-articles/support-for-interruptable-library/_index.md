---
title: Wsparcie dla biblioteki obsługującej przerwania
type: docs
weight: 150
url: /pl/cpp/support-for-interruptable-library/
keywords:
- biblioteka obsługująca przerwania
- token przerwania
- token anulowania
- zadanie długotrwałe
- przerwać zadanie
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Umożliwienie anulowania długotrwałych zadań w Aspose.Slides dla C++. Bezpieczne przerywanie renderowania i konwersji dla PowerPoint i OpenDocument, wraz z przykładami."
---
## **Przegląd**

Aspose.Slides udostępnia mechanizm przetwarzania możliwy do przerwania dla długotrwałych zadań związanych z prezentacjami, takich jak deserializacja, serializacja i renderowanie. Mechanizm ten opiera się na klasach `InterruptionToken` i `InterruptionTokenSource`.

`InterruptionToken` może być przypisany do `LoadOptions` i przekazany do konstruktora `Presentation`. Gdy wywołane zostanie `InterruptionTokenSource::Interrupt()`, powiązane długotrwałe zadanie zostaje przerwane.

## **Biblioteka obsługująca przerwania**

W [Aspose.Slides 18.4](https://releases.aspose.com/slides/pl/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/), wprowadziliśmy klasy [InterruptionToken](https://reference.aspose.com/slides/pl/cpp/aspose.slides/interruptiontoken/) oraz [InterruptionTokenSource](https://reference.aspose.com/slides/pl/cpp/aspose.slides/interruptiontokensource/). Umożliwiają one przerwanie długotrwałych zadań, takich jak deserializacja, serializacja i renderowanie.

- [InterruptionTokenSource](https://reference.aspose.com/slides/pl/cpp/aspose.slides/interruptiontokensource/) jest źródłem tokenów przekazywanych do [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_interruptiontoken/).
- Gdy [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_interruptiontoken/) jest ustawione i instancja [LoadOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/) zostaje przekazana do konstruktora [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/), wywołanie [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/interruptiontokensource/interrupt/) przerywa każde długotrwałe zadanie powiązane z tym [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).

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
    
    Run(action, tokenSource->get_Token()); // uruchom akcję w osobnym wątku
    Threading::Thread::Sleep(10000);       // limit czasu
    tokenSource->Interrupt();              // zatrzymaj konwersję
}
```

## **FAQ**

**Jaki jest cel biblioteki przerywania Aspose.Slides?**

Zapewnia mechanizm przerywania długotrwałych operacji — takich jak ładowanie, zapisywanie lub renderowanie prezentacji — przed ich zakończeniem. Jest to przydatne, gdy czas przetwarzania musi być ograniczony lub zadanie nie jest już potrzebne.

**Jaka jest różnica między [InterruptionToken](https://reference.aspose.com/slides/pl/cpp/aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/pl/cpp/aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` jest przekazywany do API Aspose.Slides i sprawdzany podczas długotrwałych operacji.
- `InterruptionTokenSource` jest używany w kodzie do tworzenia tokenów i wywoływania przerwań poprzez wywołanie `Interrupt()`.

**Jakie zadania mogą być przerywane?**

Każde zadanie Aspose.Slides, które przyjmuje [InterruptionToken](https://reference.aspose.com/slides/pl/cpp/aspose.slides/interruptiontoken/) — na przykład ładowanie prezentacji przy użyciu `Presentation(path, loadOptions)` lub zapisywanie przy użyciu `Presentation::Save(...)` — może zostać przerwane.

**Czy przerwanie następuje natychmiastowo?**

Nie. Przerwanie jest współpracy: operacja okresowo sprawdza token i zatrzymuje się, gdy wykryje, że wywołano [Interrupt()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/interruptiontokensource/interrupt/).

**Co się stanie, jeśli wywołam [Interrupt()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/interruptiontokensource/interrupt/) po tym, jak zadanie już się zakończyło?**

Nic — wywołanie nie ma żadnego skutku, jeśli odpowiednie zadanie już się zakończyło.

**Czy mogę ponownie użyć tego samego [InterruptionTokenSource](https://reference.aspose.com/slides/pl/cpp/aspose.slides/interruptiontokensource/) dla wielu zadań?**

Tak — ale po wywołaniu [Interrupt()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/interruptiontokensource/interrupt/) na tym źródle wszystkie zadania korzystające z jego tokenów zostaną przerwane. Używaj oddzielnych źródeł tokenów, aby zarządzać zadaniami niezależnie.