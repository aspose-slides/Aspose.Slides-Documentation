---
title: Interrupt Long-Running Presentation Operations on Android
linktitle: Interrupt Presentation Operations
type: docs
weight: 120
url: /androidjava/support-for-interruptable-library/
keywords:
- interruptible operations
- interruption token
- cancellation token
- long-running task
- interrupt task
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Learn how to cancel long-running presentation operations in Aspose.Slides for Android via Java and return a partial result when exporting slides in a loop."
---

## **Overview**

Aspose.Slides for Android via Java can interrupt long-running operations such as loading, saving, and rendering presentations. Your application can use the same interruption token to stop a loop before it starts processing the next slide.

## **Interrupt a Presentation Operation**

Create an [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/), obtain its token with [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--), and pass the token to [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Pass the load options to the [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). To request cancellation, call [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) on the source. An interruptible operation stops when it observes the request.

The example converts `sample.pptx` to `sample.ppt` on a background thread. The calling thread waits up to 10 seconds for the conversion to finish. If the conversion is still running, it requests cancellation and waits for the worker to exit.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
    // Call from a background thread and pass context.getFilesDir(), which contains sample.pptx.
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

## **Connect a Java Timeout to Aspose.Slides**

To set a time limit on a presentation operation, use a [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService) to call [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) when the timeout expires. The example allows 20 seconds to load `sample.pptx` and export it to `sample.pdf`. If the export finishes early, the application cancels the scheduled request.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // Call from a background thread and pass context.getFilesDir(), which contains sample.pptx.
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

## **Stop Before Processing the Next Slide**

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

    // Call from a background thread and pass context.getFilesDir(), which contains sample.pptx.
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```

The example writes `slide-1.pdf` and prints `Starting slide 1` followed by `Completed: [1]`. The loop observes the request before starting slide 2. If cancellation arrives during a save, the loop exits before it records that slide as complete.

If the caller needs to handle cancellation, replace the check and its `break` at the top of the loop with `token.throwIfInterruptionRequested()`. Remove the `try`/`catch` around the save so cancellation during an export also reaches the caller. With the same input, the example prints only `Starting slide 1` and writes `slide-1.pdf`. At the start of the second iteration, [throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) throws `com.aspose.slides.exceptions.OperationCanceledException` before the next export begins. The method returns no list.

## **FAQ**

**When should I request cancellation?**

Request cancellation when an operation exceeds your time limit or when your application no longer needs the result.

**What is the difference between [InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) and [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

The source lets your application request cancellation. The token lets Aspose.Slides and your application check for that request.

**Can I cancel an operation from a Java timer?**

Yes. Schedule a call to [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) on the source associated with the presentation.

**Which operations can I interrupt?**

You can interrupt loading, saving, and rendering. Pass the token to the [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) through [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). The presentation can then observe cancellation during subsequent operations such as saving to PDF.

**Does an operation stop immediately?**

Cancellation is cooperative. An operation checks the token periodically and stops when it observes the request.

**What happens if I call [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) after an operation finishes?**

The completed operation keeps its result.

**Can multiple operations share an [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

Yes. Calling [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) requests cancellation for every operation that uses a token from that source. Use a separate source for each operation you want to cancel independently.
