---
title: Android에서 장시간 실행 프레젠테이션 작업 중단
linktitle: 프레젠테이션 작업 중단
type: docs
weight: 120
url: /ko/androidjava/support-for-interruptable-library/
keywords:
- 중단 가능한 작업
- 인터럽션 토큰
- 취소 토큰
- 장시간 실행 작업
- 작업 중단
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Java를 통해 Android용 Aspose.Slides에서 장시간 실행되는 프레젠테이션 작업을 취소하는 방법과 슬라이드를 반복적으로 내보낼 때 부분 결과를 반환하는 방법을 알아봅니다."
---
## **개요**

Java를 통해 Android용 Aspose.Slides는 로드, 저장 및 프레젠테이션 렌더링과 같은 장시간 실행 작업을 중단할 수 있습니다. 애플리케이션은 동일한 인터럽션 토큰을 사용하여 다음 슬라이드를 처리하기 전에 루프를 중지할 수 있습니다.

## **프레젠테이션 작업 중단**

Create an [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/), obtain its token with [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--), and pass the token to [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Pass the load options to the [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). To request cancellation, call [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) on the source. An interruptible operation stops when it observes the request.

The example converts `sample.pptx` to `sample.ppt` on a background thread. The calling thread waits up to 10 seconds for the conversion to finish. If the conversion is still running, it requests cancellation and waits for the worker to exit.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
        // 백그라운드 스레드에서 호출하고 sample.pptx가 들어 있는 context.getFilesDir()를 전달합니다.
        public static void run(File directory) throws InterruptedException {
            File input = new File(directory, "sample.pptx");
            File output = new File(directory, "sample.ppt");
            InterruptionTokenSource source = new InterruptionTokenSource();
            Thread worker = new Thread(() -> {
                LoadOptions options = new LoadOptions();
                options.setInterruptionToken(source.getToken());
                try {
                    Presentation presentation = new Presentation(input.getAbsolutePath(), options);
                    try {
                        presentation.save(output.getAbsolutePath(), SaveFormat.Ppt);
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
        }
}
```
## **Java 타임아웃을 Aspose.Slides에 연결**

To set a time limit on a presentation operation, use a [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService) to call [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) when the timeout expires. The example allows 20 seconds to load `sample.pptx` and export it to `sample.pdf`. If the export finishes early, the application cancels the scheduled request.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // 백그라운드 스레드에서 호출하고 sample.pptx가 들어 있는 context.getFilesDir()를 전달합니다.
    public static void run(File directory) {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.pdf");
        InterruptionTokenSource source = new InterruptionTokenSource();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(source.getToken());

        ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
        ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
        try {
            Presentation presentation = new Presentation(input.getAbsolutePath(), options);
            try {
                presentation.save(output.getAbsolutePath(), SaveFormat.Pdf);
            } finally {
                presentation.dispose();
            }
        } catch (OperationCanceledException canceled) {
            System.out.println("Presentation processing was canceled");
        } finally {
            timeout.cancel(false);
            timer.shutdown();
        }
    }
}
```
## **다음 슬라이드 처리 전 중단**

Use the same [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/) for the presentation and the loop that exports its slides. Check [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) before each export. If the caller can use a partial result, return the slide numbers for the exports that completed successfully.

Use a presentation named `sample.pptx` with at least two slides. The [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-) overload that takes an array of slide numbers counts from 1. The example saves each slide to a separate PDF and requests cancellation immediately after it records the first successful export.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;
import java.io.File;

public class SlideExporter {
    private static List<Integer> exportSlides(File directory, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        File input = new File(directory, "sample.pptx");
        Presentation presentation = new Presentation(input.getAbsolutePath(), options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    File output = new File(directory, "slide-" + number + ".pdf");
                    presentation.save(output.getAbsolutePath(), new int[] { number }, SaveFormat.Pdf);
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

    // 백그라운드 스레드에서 호출하고 sample.pptx가 들어 있는 context.getFilesDir()를 전달합니다.
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```
The example writes `slide-1.pdf` and prints `Starting slide 1` followed by `Completed: [1]`. The loop observes the request before starting slide 2. If cancellation arrives during a save, the loop exits before it records that slide as complete.

If the caller needs to handle cancellation, replace the check and its `break` at the top of the loop with `token.throwIfInterruptionRequested()`. Remove the `try`/`catch` around the save so cancellation during an export also reaches the caller. With the same input, the example prints only `Starting slide 1` and writes `slide-1.pdf`. At the start of the second iteration, [throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) throws `com.aspose.slides.exceptions.OperationCanceledException` before the next export begins. The method returns no list.

## **자주 묻는 질문**

**언제 취소를 요청해야 합니까?**  
작업이 시간 제한을 초과하거나 애플리케이션이 더 이상 결과를 필요로 하지 않을 때 취소를 요청합니다.

**[InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/)와 [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)의 차이는 무엇인가요?**  
InterruptionTokenSource는 애플리케이션이 취소를 요청할 수 있게 해줍니다. InterruptionToken은 Aspose.Slides와 애플리케이션이 해당 요청을 확인할 수 있도록 합니다.

**Java 타이머에서 작업을 취소할 수 있습니까?**  
예. 프레젠테이션에 연결된 소스에서 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--)를 호출하도록 예약합니다.

**어떤 작업을 중단할 수 있습니까?**  
로드, 저장 및 렌더링 작업을 중단할 수 있습니다. 토큰을 [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-)를 통해 [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-)에 전달합니다. 이렇게 하면 프레젠테이션은 PDF 저장과 같은 이후 작업 중에 취소를 감지할 수 있습니다.

**작업이 즉시 중단됩니까?**  
취소는 협력 방식으로 이루어집니다. 작업은 토큰을 주기적으로 확인하고 요청을 감지하면 중단됩니다.

**작업이 완료된 후 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--)를 호출하면 어떻게 됩니까?**  
이미 완료된 작업은 결과를 유지합니다.

**여러 작업이 하나의 [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)를 공유할 수 있습니까?**  
예. [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--)를 호출하면 해당 소스의 토큰을 사용하는 모든 작업에 대한 취소가 요청됩니다. 독립적으로 취소하려는 각 작업마다 별도의 소스를 사용하십시오.