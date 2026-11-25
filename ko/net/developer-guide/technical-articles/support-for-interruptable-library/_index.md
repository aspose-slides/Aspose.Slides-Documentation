---
title: .NET에서 장기 실행 프레젠테이션 작업 중단
linktitle: 프레젠테이션 작업 중단
type: docs
weight: 150
url: /ko/net/support-for-interruptable-library/
keywords:
- 중단 가능한 작업
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
description: "Aspose.Slides for .NET에서 장기 실행 프레젠테이션 작업을 취소하는 방법과 루프에서 슬라이드를 내보낼 때 부분 결과를 반환하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for .NET은 로드, 저장 및 프레젠테이션 렌더링과 같은 장기 실행 작업을 중단할 수 있습니다. 애플리케이션은 동일한 interruption token을 사용하여 다음 슬라이드 처리를 시작하기 전에 루프를 중단할 수 있습니다.

## **프레젠테이션 작업 중단**

새 [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)를 생성하고 해당 [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/)을 [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/)에 할당한 다음, 로드 옵션을 [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/)에 전달합니다. 취소를 요청하려면 소스에서 [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/)를 호출합니다. 인터럽트 가능한 작업은 요청을 감지하면 중지됩니다.

예제는 백그라운드 작업에서 `sample.pptx`를 `sample.ppt`로 변환을 시작하고 10초 후에 취소를 요청합니다. 변환이 더 일찍 완료되면 출력은 이미 완료됩니다.

```c#
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

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
    Run(action, tokenSource.Token); // 별도 스레드에서 작업을 실행합니다
    Thread.Sleep(10000);            // 시간 초과
    tokenSource.Interrupt();        // 변환을 중단합니다
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET 취소를 Aspose.Slides에 연결**

앱이 .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)을 사용하는 경우 해당 취소 요청을 Aspose.Slides에 전달합니다. 예제는 `sample.pptx`를 `sample.pdf`로 내보내기를 시작하고 20초 제한을 설정합니다. 내보내기가 진행되는 동안 매 500밀리초마다 [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested)를 확인합니다. 속성이 `true`가 되면 [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/)를 호출합니다.

```cs
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

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
    Task task = Run(action, tokenSource.Token); // 별도 스레드에서 작업을 실행합니다

    while (!task.Wait(500)) // 취소 토큰의 IsCancellationRequested 플래그가 설정되었는지 대기하고 모니터링합니다
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // 프레젠테이션 처리 중단
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

## **다음 슬라이드 처리 전에 중지**

프레젠테이션과 슬라이드를 내보내는 루프 모두에 동일한 [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/)을 사용합니다. 각 내보내기를 시작하기 전에 [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/)를 확인합니다. 호출자가 부분 결과를 사용할 수 있는 경우 성공적으로 완료된 내보내기의 슬라이드 번호를 반환합니다.

`sample.pptx`라는 프레젠테이션을 사용하고 슬라이드가 최소 두 개 있어야 합니다. 예제는 첫 번째 성공적인 내보내기를 기록한 직후에 취소를 요청합니다.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new InterruptionTokenSource();
var completed = ExportSlides("sample.pptx", source);
Console.WriteLine($"Completed: [{string.Join(", ", completed)}]");

static List<int> ExportSlides(string path, IInterruptionTokenSource source)
{
    var completed = new List<int>();
    IInterruptionToken token = source.Token;
    var options = new LoadOptions { InterruptionToken = token };
    using var presentation = new Presentation(path, options);

    for (var number = 1; number <= presentation.Slides.Count; number++)
    {
        if (token.IsInterruptionRequested)
            break;

        Console.WriteLine($"Starting slide {number}");
        try
        {
            presentation.Save($"slide-{number}.pdf", new[] { number }, SaveFormat.Pdf);
        }
        catch (OperationCanceledException) when (token.IsInterruptionRequested)
        {
            break;
        }

        completed.Add(number);
        if (number == 1)
            source.Interrupt();
    }

    return completed;
}
```

예제는 `slide-1.pdf`를 작성하고 `Starting slide 1`을 출력한 뒤 `Completed: [1]`을 표시합니다. 루프는 슬라이드 2를 시작하기 전에 요청을 감지합니다. 만약 취소가 내보내기 중에 [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)를 중단한다면, `catch` 블록이 현재 슬라이드를 완료로 기록하기 전에 루프를 종료합니다.

호출자가 취소를 처리해야 하는 경우 루프 상단의 `if` 검사와 `break`를 토큰에 대한 [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) 호출로 교체합니다. 내보내기 주변의 `try`/`catch`를 제거하여 저장 중 취소도 호출자에게 전달되도록 합니다. 동일한 입력으로 예제는 `Starting slide 1`만 출력하고 `slide-1.pdf`를 작성합니다. 두 번째 반복 시작 시, 호출자는 내보내기가 시작되기 전에 [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception)을 받습니다. 메서드는 목록을 반환하지 않습니다.

## **FAQ**

**언제 취소를 요청해야 하나요?**

작업이 시간 제한을 초과하거나 애플리케이션이 더 이상 결과를 필요로 하지 않을 때 취소를 요청합니다.

**[InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/)과 [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)의 차이점은 무엇인가요?**

소스는 애플리케이션이 취소를 요청하도록 해 줍니다. 토큰은 Aspose.Slides와 애플리케이션이 해당 요청을 확인할 수 있게 합니다.

**.NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)을 Aspose.Slides와 함께 사용할 수 있나요?**

예. .NET 토큰이 취소를 신호하면 프레젠테이션에 연결된 소스에서 [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/)를 호출합니다.

**어떤 작업을 중단할 수 있나요?**

로드, 저장 및 렌더링을 중단할 수 있습니다. 토큰을 [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/)을 통해 [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/)에 전달합니다. 그러면 프레젠테이션은 이후 작업(예: [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)) 중에 취소를 감지할 수 있습니다.

**작업이 즉시 중단되나요?**

취소는 협조적으로 이루어집니다. 작업은 토큰을 주기적으로 확인하고 요청을 감지하면 중단합니다.

**작업이 완료된 후 [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/)을 호출하면 어떻게 되나요?**

이미 완료된 작업은 결과를 유지합니다.

**여러 작업이 동일한 [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)를 공유할 수 있나요?**

예. [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/)을 호출하면 해당 소스의 토큰을 사용하는 모든 작업에 대해 취소가 요청됩니다. 독립적으로 취소하려는 각 작업마다 별도의 소스를 사용하십시오.