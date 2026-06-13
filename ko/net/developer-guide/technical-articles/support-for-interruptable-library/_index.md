---
title: 중단 가능한 라이브러리 지원
type: docs
weight: 150
url: /ko/net/support-for-interruptable-library/
keywords:
- 중단 가능한 라이브러리
- 중단 토큰
- 취소 토큰
- 장기 실행 작업
- 작업 중단
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 장기 실행 작업을 취소 가능하게 만들 수 있습니다. PowerPoint 및 OpenDocument의 렌더링과 변환을 안전하게 중단할 수 있으며, 예제가 포함되어 있습니다."
---
## **개요**

Aspose.Slides for .NET은 역직렬화, 직렬화 및 렌더링과 같은 장기 실행 프레젠테이션 작업에 대한 중단 가능한 처리 메커니즘을 제공합니다. 이 메커니즘은 `InterruptionToken` 및 `InterruptionTokenSource` 클래스에 기반합니다.

`InterruptionToken`은 `LoadOptions`에 할당하고 `Presentation` 생성자에 전달할 수 있습니다. `InterruptionTokenSource.Interrupt()`가 호출되면 연결된 장기 실행 작업이 중단됩니다. 이 문서에서는 취소 요청을 모니터링하고 취소가 요청될 때 `Interrupt()`를 호출하여 표준 .NET `CancellationToken`과 이 메커니즘을 함께 사용하는 방법도 보여줍니다.

## **중단 가능한 라이브러리**

[Aspose.Slides 18.4](https://releases.aspose.com/slides/ko/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/)에서 우리는 [InterruptionToken](https://reference.aspose.com/slides/ko/net/aspose.slides/interruptiontoken/) 및 [InterruptionTokenSource](https://reference.aspose.com/slides/ko/net/aspose.slides/interruptiontokensource/) 클래스를 도입했습니다. 이 클래스들은 역직렬화, 직렬화 및 렌더링과 같은 장기 실행 작업을 중단할 수 있게 합니다.

- [InterruptionTokenSource](https://reference.aspose.com/slides/ko/net/aspose.slides/interruptiontokensource/)은 [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/ko/net/aspose.slides/iloadoptions/interruptiontoken/)에 전달되는 토큰(들)의 소스입니다.
- [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/ko/net/aspose.slides/iloadoptions/interruptiontoken/)이 설정되고 [LoadOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/) 인스턴스가 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 생성자에 전달될 때, [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/ko/net/aspose.slides/interruptiontokensource/interrupt/)을 호출하면 해당 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/)과 연관된 모든 장기 실행 작업이 중단됩니다.

다음 코드 스니펫은 실행 중인 작업을 중단하는 예를 보여줍니다:

```c#
public static void Run()
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions { InterruptionToken = token };
        using (Presentation presentation = new Presentation("sample.pptx", options))
        {
            presentation.Save("sample.ppt", SaveFormat.Ppt);
        }
    };

    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Run(action, tokenSource.Token); // 동작을 별도 스레드에서 실행합니다
    Thread.Sleep(10000);            // 시간 초과
    tokenSource.Interrupt();        // 변환을 중단합니다
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET CancellationToken 및 중단 가능한 라이브러리**

[CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)을 Aspose.Slides 중단 가능한 라이브러리와 함께 사용해야 할 경우, [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 처리를 래핑하고 [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested)가 `true`인 경우 [InterruptionToken](https://reference.aspose.com/slides/ko/net/aspose.slides/interruptiontoken/)을 중단합니다.

다음 C# 코드는 해당 동작을 보여줍니다:

```cs
public static void Main()
{
    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    ProcessPresentation("sample.pptx", "sample.pdf", tokenSource.Token);
}

static void ProcessPresentation(string path, string outPath, CancellationToken cancellationToken)
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions {InterruptionToken = token};
        using (Presentation presentation = new Presentation(path, options))
        {
            presentation.Save(outPath, SaveFormat.Pdf);
        }
    };
    
    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Task task = Run(action, tokenSource.Token); // 동작을 별도 스레드에서 실행합니다

    while (!task.Wait(500)) // 대기하면서 cancellationToken.IsCancellationRequested가 설정되었는지 모니터링합니다
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // Presentation 처리를 중단합니다
        }
    }
}

private static Task Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    return Task.Run(() =>
    {
        action(token);
    });
}
```

## **자주 묻는 질문**

**Aspose.Slides 중단 라이브러리의 목적은 무엇인가요?**

이는 로드, 저장 또는 프레젠테이션 렌더링과 같은 장기 실행 작업을 완료되기 전에 중단할 수 있는 메커니즘을 제공합니다. 처리 시간이 제한되어야 하거나 작업이 더 이상 필요하지 않을 때 유용합니다.

**[InterruptionToken](https://reference.aspose.com/slides/ko/net/aspose.slides/interruptiontoken/)과 [InterruptionTokenSource](https://reference.aspose.com/slides/ko/net/aspose.slides/iinterruptiontokensource/)의 차이점은 무엇인가요?**

- `InterruptionToken`은 Aspose.Slides API에 전달되어 장기 실행 작업 중에 확인됩니다.
- `InterruptionTokenSource`는 토큰을 생성하고 `Interrupt()`를 호출하여 중단을 트리거하기 위해 코드에서 사용됩니다.

**.NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)을 중단 라이브러리와 함께 사용할 수 있나요?**

네. 애플리케이션 로직에서 [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)을 모니터링하고 취소가 요청될 때 [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/ko/net/aspose.slides/iinterruptiontokensource/interrupt/)을 호출할 수 있습니다. 이를 통해 Aspose.Slides가 표준 .NET 취소 워크플로와 통합됩니다.

**어떤 작업을 중단할 수 있나요?**

[InterruptionToken](https://reference.aspose.com/slides/ko/net/aspose.slides/interruptiontoken/)을 수락하는 모든 Aspose.Slides 작업—예: `Presentation(path, loadOptions)`로 프레젠테이션을 로드하거나 `Presentation.Save(...)`로 저장—은 중단될 수 있습니다.

**중단이 즉시 발생하나요?**

아니요. 중단은 협력 방식으로 이루어집니다. 작업은 주기적으로 토큰을 확인하며, [Interrupt()](https://reference.aspose.com/slides/ko/net/aspose.slides/iinterruptiontokensource/interrupt/)이 호출된 것을 감지하면 즉시 중단됩니다.

**작업이 이미 완료된 후에 [Interrupt()](https://reference.aspose.com/slides/ko/net/aspose.slides/iinterruptiontokensource/interrupt/)를 호출하면 어떻게 되나요?**

아무 일도 일어나지 않습니다—해당 작업이 이미 완료된 경우 호출은 아무 효과도 없습니다.

**여러 작업에 동일한 [InterruptionTokenSource](https://reference.aspose.com/slides/ko/net/aspose.slides/iinterruptiontokensource/)를 재사용할 수 있나요?**

네—하지만 해당 소스에서 [Interrupt()](https://reference.aspose.com/slides/ko/net/aspose.slides/iinterruptiontokensource/interrupt/)를 호출한 후에는 그 토큰을 사용하는 모든 작업이 중단됩니다. 작업을 독립적으로 관리하려면 별도의 토큰 소스를 사용하세요.