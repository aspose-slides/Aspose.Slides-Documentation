---
title: Java에서 장기 실행 프레젠테이션 작업 중단
linktitle: 프레젠테이션 작업 중단
type: docs
weight: 120
url: /ko/java/support-for-interruptable-library/
keywords:
- 중단 가능한 작업
- 중단 토큰
- 취소 토큰
- 장기 실행 작업
- 작업 중단
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 장기 실행 프레젠테이션 작업을 취소하고 루프에서 슬라이드를 내보낼 때 부분 결과를 반환하는 방법을 알아보세요."
---
## **Overview**

Aspose.Slides for Java는 로드, 저장 및 프레젠테이션 렌더링과 같은 장기 실행 작업을 중단할 수 있습니다. 애플리케이션은 동일한 중단 토큰을 사용하여 다음 슬라이드 처리를 시작하기 전에 루프를 중지시킬 수 있습니다.

## **Interrupt a Presentation Operation**

[InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)를 생성하고, [getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--)으로 토큰을 얻은 다음, 해당 토큰을 [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-)에 전달합니다. 로드 옵션을 [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-)에 전달합니다. 취소를 요청하려면 소스에서 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--)를 호출합니다. 중단 가능한 작업은 요청을 감지하면 중지됩니다.

예제는 `sample.pptx`를 백그라운드 스레드에서 `sample.ppt`로 변환합니다. 호출 스레드는 변환이 완료될 때까지 최대 10초 동안 대기합니다. 변환이 아직 진행 중이면 취소를 요청하고 작업자가 종료될 때까지 기다립니다.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;

InterruptionTokenSource source = new InterruptionTokenSource();
Thread worker = new Thread(() -> {
    LoadOptions options = new LoadOptions();
    options.setInterruptionToken(source.getToken());
    try {
        Presentation presentation = new Presentation("sample.pptx", options);
        try {
            presentation.save("sample.ppt", SaveFormat.Ppt);
        } finally {
            presentation.dispose();
        }
    } catch (OperationCanceledException canceled) {
        System.out.println("Conversion canceled");
    }
});

worker.start();
worker.join(10000);
if (worker.isAlive()) {
    source.interrupt();
    worker.join();
}
```

## **Connect a Java Timeout to Aspose.Slides**

프레젠테이션 작업에 시간 제한을 설정하려면 [ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html)를 사용하여 제한 시간이 만료될 때 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--)을 호출합니다. 예제는 `sample.pptx`를 로드하고 `sample.pdf`로 내보내는 데 20초를 허용합니다. 내보내기가 일찍 끝나면 애플리케이션은 예약된 요청을 취소합니다.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;

InterruptionTokenSource source = new InterruptionTokenSource();
LoadOptions options = new LoadOptions();
options.setInterruptionToken(source.getToken());

ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
try {
    Presentation presentation = new Presentation("sample.pptx", options);
    try {
        presentation.save("sample.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
    }
} catch (OperationCanceledException canceled) {
    System.out.println("Presentation processing was canceled");
} finally {
    timeout.cancel(false);
    timer.shutdown();
}
```

## **Stop Before Processing the Next Slide**

프레젠테이션과 슬라이드 내보내기 루프 모두에 동일한 [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/)을 사용합니다. 각 내보내기 전에 [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--)를 확인합니다. 호출자가 부분 결과를 사용할 수 있는 경우 성공적으로 완료된 내보내기의 슬라이드 번호를 반환합니다.

두 개 이상의 슬라이드가 포함된 `sample.pptx` 프레젠테이션을 사용합니다. 슬라이드 번호 배열을 받는 [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-) 오버로드는 1부터 번호를 매깁니다. 예제는 각 슬라이드를 별도의 PDF로 저장하고 첫 번째 성공적인 내보내기를 기록한 직후 취소를 요청합니다.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;

class SlideExporter {
    List<Integer> exportSlides(String path, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        Presentation presentation = new Presentation(path, options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    presentation.save("slide-" + number + ".pdf", new int[] { number }, SaveFormat.Pdf);
                } catch (OperationCanceledException canceled) {
                    if (token.isInterruptionRequested()) {
                        break;
                    }
                    throw canceled;
                }

                completed.add(number);
                if (number == 1) {
                    source.interrupt();
                }
            }
            return completed;
        } finally {
            presentation.dispose();
        }
    }
}

InterruptionTokenSource source = new InterruptionTokenSource();
SlideExporter exporter = new SlideExporter();
List<Integer> completed = exporter.exportSlides("sample.pptx", source);
System.out.println("Completed: " + completed);
```

예제는 `slide-1.pdf`를 작성하고 `Starting slide 1`을 출력한 뒤 `Completed: [1]`을 출력합니다. 루프는 슬라이드 2를 시작하기 전에 요청을 감지합니다. 저장 중에 취소가 발생하면 해당 슬라이드를 완료된 것으로 기록하기 전에 루프가 종료됩니다.

호출자가 취소를 직접 처리해야 하는 경우, 루프 상단의 체크와 `break`를 `token.throwIfInterruptionRequested()`로 교체합니다. 저장 주위의 `try`/`catch`를 제거하여 내보내기 중에 발생한 취소도 호출자에게 전달되도록 합니다. 동일한 입력으로 예제는 `Starting slide 1`만 출력하고 `slide-1.pdf`만 작성합니다. 두 번째 반복 시작 시 [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--)가 `com.aspose.slides.exceptions.OperationCanceledException`을 발생시켜 다음 내보내기가 시작되지 않으며 메서드는 리스트를 반환하지 않습니다.

## **FAQ**

**When should I request cancellation?**

작업이 제한 시간을 초과했거나 애플리케이션이 더 이상 결과가 필요하지 않을 때 취소를 요청합니다.

**What is the difference between [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) and [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

소스는 애플리케이션이 취소를 요청할 수 있게 해줍니다. 토큰은 Aspose.Slides와 애플리케이션이 해당 요청을 확인할 수 있게 해줍니다.

**Can I cancel an operation from a Java timer?**

예. 프레젠테이션과 연결된 소스에 대해 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--)을 호출하도록 스케줄링하면 됩니다.

**Which operations can I interrupt?**

로드, 저장 및 렌더링을 중단할 수 있습니다. 토큰을 [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-)에 전달할 때 [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-)을 사용합니다. 이후 프레젠테이션은 PDF 저장과 같은 후속 작업 중에도 취소를 감지할 수 있습니다.

**Does an operation stop immediately?**

취소는 협력적으로 이루어집니다. 작업은 토큰을 주기적으로 확인하고 요청을 감지하면 중지합니다.

**What happens if I call [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) after an operation finishes?**

이미 완료된 작업은 결과를 유지합니다.

**Can multiple operations share an [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

예. [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--)을 호출하면 해당 소스에서 만든 토큰을 사용하는 모든 작업에 대한 취소가 요청됩니다. 독립적으로 취소하려면 각 작업마다 별도의 소스를 사용하십시오.