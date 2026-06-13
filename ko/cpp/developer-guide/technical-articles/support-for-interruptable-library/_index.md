---
title: 중단 가능한 라이브러리 지원
type: docs
weight: 150
url: /ko/cpp/support-for-interruptable-library/
keywords:
- 중단 가능한 라이브러리
- 중단 토큰
- 취소 토큰
- 장시간 작업
- 작업 중단
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 장시간 작업을 취소 가능하게 만듭니다. PowerPoint 및 OpenDocument의 렌더링 및 변환을 안전하게 중단할 수 있으며, 예제가 제공됩니다."
---
## **개요**

Aspose.Slides는 역직렬화, 직렬화 및 렌더링과 같은 장시간 실행 프레젠테이션 작업을 중단할 수 있는 처리 메커니즘을 제공합니다. 이 메커니즘은 `InterruptionToken` 및 `InterruptionTokenSource` 클래스에 기반합니다.

`InterruptionToken`은 `LoadOptions`에 할당하고 `Presentation` 생성자에 전달할 수 있습니다. `InterruptionTokenSource::Interrupt()`가 호출되면 연관된 장시간 작업이 중단됩니다.

## **중단 가능한 라이브러리**

[Aspose.Slides 18.4](https://releases.aspose.com/slides/ko/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/)에서 우리는 [InterruptionToken](https://reference.aspose.com/slides/ko/cpp/aspose.slides/interruptiontoken/) 및 [InterruptionTokenSource](https://reference.aspose.com/slides/ko/cpp/aspose.slides/interruptiontokensource/) 클래스를 도입했습니다. 이 클래스들은 역직렬화, 직렬화 및 렌더링과 같은 장시간 작업을 중단할 수 있게 해줍니다.

- [InterruptionTokenSource](https://reference.aspose.com/slides/ko/cpp/aspose.slides/interruptiontokensource/)은 [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_interruptiontoken/)에 전달되는 토큰의 소스입니다.
- [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_interruptiontoken/)이 설정되고 [LoadOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/) 인스턴스가 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 생성자에 전달되면, [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/interruptiontokensource/interrupt/)를 호출하여 해당 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/)과 연결된 모든 장시간 작업을 중단합니다.

다음 코드 스니펫은 실행 중인 작업을 중단하는 방법을 보여줍니다:

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
    
    Run(action, tokenSource->get_Token()); // 별도의 스레드에서 작업을 실행합니다
    Threading::Thread::Sleep(10000);       // 시간 제한
    tokenSource->Interrupt();              // 변환을 중단합니다
}
```

## **FAQ**

**Aspose.Slides 중단 라이브러리의 목적은 무엇입니까?**

이는 로드, 저장 또는 프레젠테이션 렌더링과 같은 장시간 작업을 완료되기 전에 중단할 수 있는 메커니즘을 제공합니다. 처리 시간이 제한되어야 하거나 작업이 더 이상 필요하지 않을 때 유용합니다.

**[InterruptionToken](https://reference.aspose.com/slides/ko/cpp/aspose.slides/interruptiontoken/)과 [InterruptionTokenSource](https://reference.aspose.com/slides/ko/cpp/aspose.slides/interruptiontokensource/)의 차이점은 무엇입니까?**

- `InterruptionToken`은 Aspose.Slides API에 전달되어 장시간 작업 중에 확인됩니다.
- `InterruptionTokenSource`는 코드에서 토큰을 생성하고 `Interrupt()`를 호출하여 중단을 트리거하는 데 사용됩니다.

**어떤 작업을 중단할 수 있습니까?**

[InterruptionToken](https://reference.aspose.com/slides/ko/cpp/aspose.slides/interruptiontoken/)을 받아들이는 모든 Aspose.Slides 작업—예를 들어 `Presentation(path, loadOptions)`로 프레젠테이션을 로드하거나 `Presentation::Save(...)`로 저장하는 경우—중단할 수 있습니다.

**중단이 즉시 발생합니까?**

아니오. 중단은 협력 방식으로 이루어집니다. 작업이 주기적으로 토큰을 확인하고 `Interrupt()`가 호출된 것을 감지하면 즉시 중단됩니다.

**작업이 이미 완료된 후에 [Interrupt()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/interruptiontokensource/interrupt/)를 호출하면 어떻게 됩니까?**

아무 일도 일어나지 않습니다—해당 작업이 이미 완료된 경우 호출은 효과가 없습니다.

**여러 작업에 같은 [InterruptionTokenSource](https://reference.aspose.com/slides/ko/cpp/aspose.slides/interruptiontokensource/)를 재사용할 수 있습니까?**

예—but 해당 소스에 대해 `Interrupt()`를 호출하면 해당 토큰을 사용하는 모든 작업이 중단됩니다. 작업을 독립적으로 관리하려면 별개의 토큰 소스를 사용하십시오.