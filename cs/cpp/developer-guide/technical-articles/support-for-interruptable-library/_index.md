---
title: Podpora přerušitelné knihovny
type: docs
weight: 150
url: /cs/cpp/support-for-interruptable-library/
keywords:
- přerušitelná knihovna
- token přerušení
- token zrušení
- dlouho běžící úloha
- přerušit úlohu
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Umožněte zrušení dlouho běžících úloh pomocí Aspose.Slides pro C++. Bezpečně přerušte vykreslování a konverze pro PowerPoint a OpenDocument, včetně příkladů."
---
## **Přehled**

Aspose.Slides poskytuje přerušitelné zpracování pro dlouho běžící úlohy prezentací, jako je deserializace, serializace a renderování. Tento mechanismus je založen na třídách `InterruptionToken` a `InterruptionTokenSource`.

`InterruptionToken` může být přiřazen k `LoadOptions` a předán konstruktoru `Presentation`. Když je voláno `InterruptionTokenSource::Interrupt()`, související dlouho běžící úloha je přerušena.

## **Přerušitelná knihovna**

V [Aspose.Slides 18.4](https://releases.aspose.com/slides/cs/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/) jsme představili třídy [InterruptionToken](https://reference.aspose.com/slides/cs/cpp/aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/cs/cpp/aspose.slides/interruptiontokensource/). Umožňují přerušit dlouho běžící úlohy, jako je deserializace, serializace a renderování.

- [InterruptionTokenSource](https://reference.aspose.com/slides/cs/cpp/aspose.slides/interruptiontokensource/) je zdrojem tokenu(ů) předávaných do [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_interruptiontoken/).
- Když je [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_interruptiontoken/) nastaven a instance [LoadOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/) je předána konstruktoru [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/), volání [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/interruptiontokensource/interrupt/) přeruší jakoukoli dlouho běžící úlohu spojenou s touto [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).

Následující úryvek kódu ukazuje, jak přerušit běžící úlohu:

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
    
    Run(action, tokenSource->get_Token()); // spustí akci v samostatném vlákně
    Threading::Thread::Sleep(10000);       // časový limit
    tokenSource->Interrupt();              // zastaví konverzi
}
```

## **Často kladené otázky**

**Jaký je účel přerušitelné knihovny Aspose.Slides?**

Poskytuje mechanismus k přerušení dlouho běžících operací — například načítání, ukládání nebo renderování prezentací — před jejich dokončením. To je užitečné, když je nutné omezit dobu zpracování nebo úloha již není potřeba.

**Jaký je rozdíl mezi [InterruptionToken](https://reference.aspose.com/slides/cs/cpp/aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/cs/cpp/aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` je předáván API Aspose.Slides a během dlouho běžících operací kontrolován.
- `InterruptionTokenSource` se používá ve vašem kódu k vytváření tokenů a k vyvolání přerušení voláním `Interrupt()`.

**Jaké úlohy lze přerušit?**

Jakákoli úloha Aspose.Slides, která přijímá [InterruptionToken](https://reference.aspose.com/slides/cs/cpp/aspose.slides/interruptiontoken/) — například načítání prezentace pomocí `Presentation(path, loadOptions)` nebo ukládání pomocí `Presentation::Save(...)` — může být přerušena.

**Dochází k přerušení okamžitě?**

Ne. Přerušení je kooperativní: operace periodicky kontroluje token a zastaví se, jakmile zjistí, že bylo voláno [Interrupt()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/interruptiontokensource/interrupt/).

**Co se stane, pokud zavolám [Interrupt()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/interruptiontokensource/interrupt/) po tom, co úloha již byla dokončena?**

Nič — volání nemá žádný efekt, pokud byla odpovídající úloha již dokončena.

**Mohu znovu použít stejný [InterruptionTokenSource](https://reference.aspose.com/slides/cs/cpp/aspose.slides/interruptiontokensource/) pro více úloh?**

Ano — ale po volání [Interrupt()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/interruptiontokensource/interrupt/) na tomto zdroji budou všechny úlohy používající jeho tokeny přerušeny. Pro samostatné řízení úloh používejte samostatné zdroje tokenů.