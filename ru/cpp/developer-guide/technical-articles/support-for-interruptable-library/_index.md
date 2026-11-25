---
title: Прерывание длительных операций с презентациями в C++
linktitle: Прерывание операций презентации
type: docs
weight: 150
url: /ru/cpp/support-for-interruptable-library/
keywords:
- прерываемые операции
- токен прерывания
- токен отмены
- длительная задача
- прерывание задачи
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как отменять длительные операции с презентациями в Aspose.Slides для C++ и возвращать частичный результат при экспорте слайдов в цикле."
---
## **Обзор**

Aspose.Slides for C++ может прерывать длительные операции, такие как загрузка, сохранение и рендеринг презентаций. Ваше приложение может использовать тот же токен прерывания, чтобы остановить цикл до того, как он начнет обрабатывать следующий слайд.

## **Прерывание операции презентации**

Create an [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/), retrieve its token with [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/), pass the token to [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/), and pass the load options to the [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/). To request cancellation, call [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) on the source. An interruptible operation stops when it observes the request.

Пример начинает конвертировать `sample.pptx` в `sample.ppt` в фоновом задании и запрашивает отмену, если задача все еще работает после 10 секунд. Если конвертация завершается раньше, вывод уже готов.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.ppt", Export::SaveFormat::Ppt);
});

if (conversion.wait_for(std::chrono::seconds(10)) == std::future_status::timeout)
    source->Interrupt();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
```

## **Подключение отмены приложения к Aspose.Slides**

If your application uses a [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/), use [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/) to forward cancellation requests to [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/). The example exports `sample.pptx` to `sample.pdf` in a background task. If the export is still running after 20 seconds, the application calls [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/), which invokes the registered callback.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <system/threading/cancellation_token.h>
#include <system/threading/cancellation_token_source.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto cancellation = MakeObject<Threading::CancellationTokenSource>();
auto cancellationToken = cancellation->get_Token();
auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto interrupt = Action<>([source]() { source->Interrupt(); });
auto registration = cancellationToken.Register(interrupt);

auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.pdf", Export::SaveFormat::Pdf);
});

if (conversion.wait_for(std::chrono::seconds(20)) == std::future_status::timeout)
    cancellation->Cancel();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
registration.Dispose();
```

## **Остановить перед обработкой следующего слайда**

Use the same [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) for both the presentation and the loop that exports its slides. Check [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/) before starting each export. If the caller can use a partial result, return the slide numbers for the exports that completed successfully.

Use a presentation named `sample.pptx` with at least two slides. The example requests cancellation immediately after it records the first successful export.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <DOM/ISlideCollection.h>
#include <system/array.h>
#include <iostream>
#include <vector>

using namespace Aspose::Slides;
using namespace System;

auto exportSlides = [](String path, SharedPtr<InterruptionTokenSource> source)
{
    std::vector<int32_t> completed;
    auto token = source->get_Token();
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(path, options);
    auto slideCount = presentation->get_Slides()->get_Count();

    for (auto number = 1; number <= slideCount; ++number)
    {
        if (token->get_IsInterruptionRequested())
            break;

        std::cout << "Starting slide " << number << '\n';
        auto filename = String::Format(u"slide-{0}.pdf", number);
        auto slides = MakeArray<int32_t>({number});
        try
        {
            presentation->Save(filename, slides, Export::SaveFormat::Pdf);
        }
        catch (const OperationCanceledException&)
        {
            if (!token->get_IsInterruptionRequested())
                throw;
            break;
        }

        completed.push_back(number);
        if (number == 1)
            source->Interrupt();
    }
    return completed;
};

auto source = MakeObject<InterruptionTokenSource>();
auto completed = exportSlides(u"sample.pptx", source);
std::cout << "Completed: [";
for (size_t i = 0; i < completed.size(); ++i)
    std::cout << (i == 0 ? "" : ", ") << completed[i];
std::cout << "]\n";
```

The example writes `slide-1.pdf` and prints `Starting slide 1` followed by `Completed: [1]`. The loop sees the request before it starts slide 2. If cancellation instead interrupts [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) during an export, the `catch` block exits the loop before the code records the current slide as complete.

If the caller needs to handle cancellation, replace the `if` check and its `break` at the top of the loop with a call to [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) on the token. Remove the `try`/`catch` around the export so cancellation during a save also reaches the caller. With the same input, the example prints only `Starting slide 1` and writes `slide-1.pdf`. At the start of the second iteration, the caller receives an [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) before the export begins. The caller receives no list of completed slides.

## **FAQ**

**Когда следует запрашивать отмену?**

Запрашивайте отмену, когда операция превышает ваш временной лимит или когда вашему приложению больше не нужен результат.

**В чем разница между [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) и [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

Источник позволяет вашему приложению запросить отмену. Токен позволяет Aspose.Slides и вашему приложению проверять наличие такого запроса.

**Можно ли использовать [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) с Aspose.Slides?**

Да. Когда токен вашего приложения сигнализирует об отмене, вызовите [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) у источника, связанного с презентацией.

**Какие операции я могу прерывать?**

Вы можете прерывать загрузку, сохранение и рендеринг. Передайте токен в [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) через [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/). Презентация затем может наблюдать отмену во время последующих операций, таких как [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

**Останавливается ли операция немедленно?**

Отмена является кооперативной. Операция периодически проверяет токен и останавливается, когда наблюдает запрос.

**Что происходит, если я вызываю [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) после завершения операции?**

Завершённая операция сохраняет свой результат.

**Могут ли несколько операций использовать один [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

Да. Вызов [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) запрашивает отмену для каждой операции, использующей токен из этого источника. Используйте отдельный источник для каждой операции, которую хотите отменять независимо.