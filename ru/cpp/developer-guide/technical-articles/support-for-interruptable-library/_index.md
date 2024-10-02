---
title: Поддержка прерываемой библиотеки
type: docs
weight: 150
url: /ru/cpp/support-for-interruptable-library/
---

## **Прерываемая библиотека**
Класс [InterruptionToken](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token) и класс [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source) были добавлены в Aspose.Slides для C++. Эти типы поддерживают прерывание долго выполняющихся задач, таких как десериализация, сериализация или рендеринг. [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source) представляет источник токена или нескольких токенов, передаваемых в метод [LoadOptions.set_InterruptionToken()](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options#a9caea79d46cd939505687fdf634530a5). Когда токен прерывания установлен, а экземпляр [LoadOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options) передан в конструктор [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), любая долго выполняющаяся задача, связанная с этой презентацией, будет прервана, когда будет вызван метод [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source#a98ba5fd8badce28a63b5d30a2cfa1e83).

Ниже приведен фрагмент кода, демонстрирующий прерывание выполняющейся задачи.

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
    // выполнить действие в отдельном потоке
    Run(action, tokenSource->get_Token());
    // тайм-аут
    Threading::Thread::Sleep(5000);
    // остановить конвертацию
    tokenSource->Interrupt();
}
```