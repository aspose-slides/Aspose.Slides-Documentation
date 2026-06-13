---
title: 중단 가능한 라이브러리 지원
type: docs
weight: 120
url: /ko/java/support-for-interruptable-library/
keywords:
- 중단 가능한 라이브러리
- 인터럽션 토큰
- 취소 토큰
- 장시간 실행 작업
- 작업 중단
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java와 함께 장시간 실행 작업을 취소 가능하게 만듭니다. PowerPoint 및 OpenDocument의 렌더링과 변환을 안전하게 중단할 수 있으며, 예제가 포함되어 있습니다."
---
## **개요**

Aspose.Slides는 역직렬화, 직렬화 및 렌더링과 같은 장시간 실행되는 프레젠테이션 작업을 중단할 수 있는 처리 메커니즘을 제공합니다. 이 메커니즘은 `InterruptionToken` 및 `InterruptionTokenSource` 클래스를 기반으로 합니다.

`InterruptionToken`은 `LoadOptions`에 할당하고 `Presentation` 생성자에 전달할 수 있습니다. `InterruptionTokenSource.interrupt()`가 호출되면 관련된 장시간 작업이 중단됩니다.

## **중단 가능한 라이브러리**

Aspose.Slides 18.4에서는 [InterruptionToken](https://reference.aspose.com/slides/ko/java/com.aspose.slides/interruptiontoken/) 및 [InterruptionTokenSource](https://reference.aspose.com/slides/ko/java/com.aspose.slides/interruptiontokensource/) 클래스를 도입했습니다. 이들은 역직렬화, 직렬화 및 렌더링과 같은 장시간 작업을 중단할 수 있게 합니다.

- [InterruptionTokenSource](https://reference.aspose.com/slides/ko/java/com.aspose.slides/interruptiontokensource/)은 [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-)에 전달되는 토큰(들)의 소스입니다.
- [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-)이 설정되고 [LoadOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/) 인스턴스가 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 생성자에 전달될 때, [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/ko/java/com.aspose.slides/interruptiontokensource/#interrupt--)를 호출하면 해당 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/)과 연관된 모든 장시간 작업이 중단됩니다.

다음 코드 스니펫은 실행 중인 작업을 중단하는 방법을 보여줍니다:

```java
final InterruptionTokenSource tokenSource = new InterruptionTokenSource();

Runnable interruption = new Runnable() {
    public void run() {
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setInterruptionToken(tokenSource.getToken());

        Presentation presentation = new Presentation("sample.pptx", loadOptions);
        try{
            presentation.save("sample.ppt", SaveFormat.Ppt);
        }
        finally {
            presentation.dispose();
        }
    }
};

Thread thread = new Thread(interruption);
thread.start();          // 작업을 별도 스레드에서 실행합니다
Thread.sleep(10000);     // 시간 초과
tokenSource.interrupt(); // 변환을 중단합니다
```

## **자주 묻는 질문**

**Aspose.Slides 인터럽트 라이브러리의 목적은 무엇입니까?**

이 라이브러리는 로드, 저장 또는 프레젠테이션 렌더링과 같은 장시간 작업을 완료되기 전에 중단할 수 있는 메커니즘을 제공합니다. 처리 시간을 제한해야 하거나 작업이 더 이상 필요하지 않을 때 유용합니다.

**[InterruptionToken]와 [InterruptionTokenSource]의 차이점은 무엇입니까?**

- `InterruptionToken`은 Aspose.Slides API에 전달되며 장시간 작업 중에 확인됩니다.
- `InterruptionTokenSource`는 코드에서 토큰을 생성하고 `Interrupt()`를 호출하여 중단을 트리거하는 데 사용됩니다.

**어떤 작업을 중단할 수 있습니까?**

[InterruptionToken]을 허용하는 모든 Aspose.Slides 작업—예를 들어 `Presentation(path, loadOptions)`로 프레젠테이션을 로드하거나 `Presentation.save(...)`로 저장하는 경우—는 중단될 수 있습니다.

**중단이 즉시 발생합니까?**

아니요. 중단은 협력 방식으로 이루어집니다. 작업은 주기적으로 토큰을 확인하고 [Interrupt()]가 호출되었음을 감지하면 즉시 중단됩니다.

**작업이 이미 완료된 후에 [Interrupt()]를 호출하면 어떻게 됩니까?**

아무 일도 일어나지 않습니다—해당 작업이 이미 완료된 경우 호출은 영향을 미치지 않습니다.

**여러 작업에 동일한 [InterruptionTokenSource]를 재사용할 수 있습니까?**

예—but 해당 소스에서 [Interrupt()]를 호출하면, 그 토큰을 사용하는 모든 작업이 중단됩니다. 작업을 독립적으로 관리하려면 별도의 토큰 소스를 사용하십시오.