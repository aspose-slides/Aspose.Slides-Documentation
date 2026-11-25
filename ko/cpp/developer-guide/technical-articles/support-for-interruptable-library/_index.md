---
title: "C++에서 장기 실행 프레젠테이션 작업 중단"
linktitle: "프레젠테이션 작업 중단"
type: docs
weight: 150
url: /ko/cpp/support-for-interruptable-library/
keywords:
- 중단 가능한 작업
- 인터럽션 토큰
- 취소 토큰
- 장기 실행 작업
- 작업 중단
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 장기 실행 프레젠테이션 작업을 취소하고, 슬라이드를 루프에서 내보낼 때 부분 결과를 반환하는 방법을 배우세요."
---
## **개요**

Aspose.Slides for C++는 로드, 저장 및 프레젠테이션 렌더링과 같은 장기 실행 작업을 중단할 수 있습니다. 애플리케이션은 동일한 인터럽션 토큰을 사용하여 다음 슬라이드 처리를 시작하기 전에 루프를 중단할 수 있습니다.

## **프레젠테이션 작업 중단**

[InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)를 만들고, [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/)으로 토큰을 가져온 다음, 해당 토큰을 [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/)에 전달하고, 로드 옵션을 [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/)에 전달합니다. 취소를 요청하려면 소스에서 [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/)를 호출합니다. 인터럽션 가능한 작업은 요청을 감지하면 중단됩니다.

예제는 백그라운드 작업에서 `sample.pptx`를 `sample.ppt`로 변환을 시작하고, 10초 후에도 작업이 실행 중이면 취소를 요청합니다. 변환이 더 일찍 완료되면 출력은 이미 완전합니다.

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

## **Aspose.Slides에 애플리케이션 취소 연결**

애플리케이션이 [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/)을 사용하는 경우, [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/)를 사용하여 취소 요청을 [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/)으로 전달합니다. 예제는 백그라운드 작업에서 `sample.pptx`를 `sample.pdf`로 내보냅니다. 내보내기가 20초 후에도 계속 실행 중이면 애플리케이션은 [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/)을 호출하여 등록된 콜백을 실행합니다.

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

## **다음 슬라이드 처리 전 중단**

프레젠테이션과 슬라이드를 내보내는 루프 모두에 대해 동일한 [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/)을 사용합니다. 각 내보내기를 시작하기 전에 [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/)를 확인합니다. 호출자가 부분 결과를 사용할 수 있는 경우, 성공적으로 완료된 내보내기의 슬라이드 번호를 반환합니다.

두 개 이상의 슬라이드가 포함된 `sample.pptx` 프레젠테이션을 사용합니다. 예제는 첫 번째 내보내기가 성공적으로 기록된 직후에 취소를 요청합니다.

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

예제는 `slide-1.pdf`를 쓰고 `Starting slide 1`을 출력한 뒤 `Completed: [1]`을 표시합니다. 루프는 슬라이드 2를 시작하기 전에 요청을 감지합니다. 취소가 대신 [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)을 내보내기 중에 중단하면, `catch` 블록이 현재 슬라이드를 완료된 것으로 기록하기 전에 루프를 종료합니다.

호출자가 취소를 처리해야 하는 경우, 루프 상단의 `if` 검사와 `break`를 토큰의 [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) 호출로 교체합니다. 내보내기 주위의 `try`/`catch`를 제거하여 저장 중 취소도 호출자에게 전달되도록 합니다. 동일한 입력으로 예제는 `Starting slide 1`만 출력하고 `slide-1.pdf`를 씁니다. 두 번째 반복 시작 시, 호출자는 내보내기가 시작되기 전에 [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/)을 받습니다. 호출자는 완료된 슬라이드 목록을 받지 못합니다.

## **FAQ**

**취소 요청은 언제 해야 합니까?**

작업이 시간 제한을 초과하거나 애플리케이션이 더 이상 결과가 필요하지 않을 때 취소를 요청합니다.

**[InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/)과 [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)의 차이점은 무엇입니까?**

소스는 애플리케이션이 취소를 요청할 수 있게 해줍니다. 토큰은 Aspose.Slides와 애플리케이션이 해당 요청을 확인하도록 합니다.

**[System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/)을 Aspose.Slides와 함께 사용할 수 있습니까?**

예. 애플리케이션 토큰이 취소를 신호하면 해당 프레젠테이션에 연결된 소스에서 [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/)을 호출합니다.

**어떤 작업을 중단할 수 있습니까?**

로드, 저장 및 렌더링을 중단할 수 있습니다. 토큰을 [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/)에 [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/)을 통해 전달합니다. 그런 다음 프레젠테이션은 [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)와 같은 후속 작업 중에 취소를 감지할 수 있습니다.

**작업이 즉시 중단됩니까?**

취소는 협력적으로 이루어집니다. 작업은 토큰을 주기적으로 확인하고 요청을 감지하면 중단됩니다.

**작업이 완료된 후에 [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/)를 호출하면 어떻게 됩니까?**

이미 완료된 작업은 결과를 유지합니다.

**여러 작업이 같은 [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)를 공유할 수 있습니까?**

예. [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/)를 호출하면 해당 소스의 토큰을 사용하는 모든 작업에 취소가 요청됩니다. 독립적으로 취소하려는 각 작업에 대해 별도의 소스를 사용하십시오.