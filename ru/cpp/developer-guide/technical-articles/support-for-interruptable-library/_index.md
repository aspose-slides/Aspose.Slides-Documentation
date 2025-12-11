---
title: Поддержка библиотеки Interruptable
type: docs
weight: 150
url: /ru/cpp/support-for-interruptable-library/
keywords:
- библиотека interruptable
- токен прерывания
- токен отмены
- длительная задача
- прерывание задачи
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Сделайте длительные задачи отменяемыми с помощью Aspose.Slides для C++. Безопасно прерывайте рендеринг и конвертации для PowerPoint и OpenDocument, с примерами."
---

## **Библиотека Interruptable**

В [Aspose.Slides 18.4](https://releases.aspose.com/slides/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/) мы представили классы [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) и [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/). Они позволяют прерывать длительные задачи, такие как десериализация, сериализация и рендеринг.

- [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) является источником токенов, передаваемых в [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/).
- Когда [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) установлен и экземпляр [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) передаётся конструктору [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), вызов [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) прерывает любую длительную задачу, связанную с этим [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).

Следующий фрагмент кода демонстрирует прерывание запущенной задачи:
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
    
    Run(action, tokenSource->get_Token()); // выполнить действие в отдельном потоке
    Threading::Thread::Sleep(10000);       // тайм-аут
    tokenSource->Interrupt();              // остановить конвертацию
}
```


## **Вопросы и ответы**

**Какова цель библиотеки прерывания Aspose.Slides?**

Она предоставляет механизм для прерывания длительных операций — таких как загрузка, сохранение или рендеринг презентаций — до их завершения. Это полезно, когда время обработки должно быть ограничено или задача более не требуется.

**В чем разница между [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) и [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` передаётся в API Aspose.Slides и проверяется во время длительных операций.
- `InterruptionTokenSource` используется в вашем коде для создания токенов и инициирует прерывания вызовом `Interrupt()`.

**Какие задачи можно прерывать?**

Любая задача Aspose.Slides, принимающая [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) — например загрузка презентации с помощью `Presentation(path, loadOptions)` или сохранение с помощью `Presentation::Save(...)` — может быть прервана.

**Прерывание происходит мгновенно?**

Нет. Прерывание является кооперативным: операция периодически проверяет токен и останавливается, как только обнаруживает, что вызвано [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/).

**Что происходит, если я вызываю [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) после того, как задача уже завершена?**

Ничего — вызов не имеет эффекта, если соответствующая задача уже завершена.

**Могу ли я повторно использовать один и тот же [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) для нескольких задач?**

Да — но после вызова [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) на этом источнике все задачи, использующие его токены, будут прерваны. Используйте отдельные источники токенов для независимого управления задачами.