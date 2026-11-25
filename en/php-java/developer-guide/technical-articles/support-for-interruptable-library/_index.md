---
title: Interrupt Long-Running Presentation Operations in PHP
linktitle: Interrupt Presentation Operations
type: docs
weight: 120
url: /php-java/support-for-interruptable-library/
keywords:
- interruption token
- cancellation
- conversion timeout
- slide export
- PowerPoint
- PHP
- Aspose.Slides
description: "Learn how to cancel a presentation conversion on a timer and return the slides exported before cancellation with Aspose.Slides for PHP via Java."
---

## **Overview**

Aspose.Slides for PHP via Java can interrupt long-running operations such as loading, saving, and rendering presentations. In a loop that exports one slide at a time, the same token lets your application stop before the next slide and return a list of completed exports.

Both PHP examples assume that your bootstrap calls `define("JAVA_PREFER_VALUES", 1);` before loading the bridge's `Java.inc`, then loads `aspose.slides.php`. This setting lets PHP catch Java exceptions during the call. The examples inspect the wrapped exception's cause so that other conversion errors reach the caller.

## **Interrupt a Presentation Operation**

Create an [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/), obtain its token with [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken), and pass it to [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken). Supply these options when constructing the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Calling [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) requests cancellation. A running operation stops when it observes the request.

### **Set a Conversion Timeout**

While PHP waits for a synchronous load or save through the PHP/Java Bridge, a Java timer can request cancellation on a separate thread. Save the following helper as `ConversionTimeout.java`, compile it with the Aspose.Slides JAR on the classpath, and make the compiled class available to the bridge under its package name, `example.ConversionTimeout`.

```java
package example;

import com.aspose.slides.InterruptionTokenSource;
import java.util.Timer;
import java.util.TimerTask;

public class ConversionTimeout {
    public static Timer start(InterruptionTokenSource source, long milliseconds) {
        Timer timer = new Timer(true);
        timer.schedule(new TimerTask() {
            @Override
            public void run() {
                source.interrupt();
            }
        }, milliseconds);
        return timer;
    }
}
```

With the bridge and Aspose.Slides PHP wrapper loaded, run the following example with `sample.pptx` in the Java process's working directory, or use absolute paths accessible to that process. The 20-second limit covers both loading and PDF export. If the conversion finishes early, PHP cancels the timer. To convert to the older PowerPoint format with a 10-second limit, use `sample.ppt`, `SaveFormat::Ppt`, and `10000` milliseconds.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new InterruptionTokenSource();
$token = $source->getToken();
$options = new LoadOptions();
$options->setInterruptionToken($token);
$timer = java("example.ConversionTimeout")->start($source, 20000);
try {
    $presentation = new Presentation("sample.pptx", $options);
    try {
        $token->throwIfInterruptionRequested();
        $presentation->save("sample.pdf", SaveFormat::Pdf);
        $token->throwIfInterruptionRequested();
        echo "Conversion completed\n";
    } finally {
        $presentation->dispose();
    }
} catch (JavaException $error) {
    if (!java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
        throw $error;
    }
    echo "Conversion canceled\n";
} finally {
    $timer->cancel();
}
```

## **Stop Before Processing the Next Slide**

Check [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested) before each export. The [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) overload for selected slides takes slide numbers starting at 1. Pass a one-element array to write a separate PDF for each slide.

Use a `sample.pptx` with at least two slides. To demonstrate cancellation between exports, the example requests it immediately after recording the first slide.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function exportSlides($path, $source) {
    $completed = [];
    $token = $source->getToken();
    $options = new LoadOptions();
    $options->setInterruptionToken($token);
    $presentation = new Presentation($path, $options);
    try {
        $count = java_values($presentation->getSlides()->size());
        for ($number = 1; $number <= $count; $number++) {
            if (java_values($token->isInterruptionRequested())) {
                break;
            }

            try {
                $presentation->save("slide-$number.pdf", [$number], SaveFormat::Pdf);
                $token->throwIfInterruptionRequested();
            } catch (JavaException $error) {
                if (java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
                    break;
                }
                throw $error;
            }

            $completed[] = $number;
            if ($number === 1) {
                $source->interrupt();
            }
        }
        return $completed;
    } finally {
        $presentation->dispose();
    }
}

$source = new InterruptionTokenSource();
$completed = exportSlides("sample.pptx", $source);
echo "Completed: " . json_encode($completed) . "\n";
```

The example writes `slide-1.pdf` and prints `Completed: [1]`. The second iteration sees the request before it begins another export. If cancellation occurs during a save, the list contains only previously confirmed exports. An interrupted save can leave an incomplete file on disk.

To propagate cancellation to the caller, replace the check at the start of the loop with `$token->throwIfInterruptionRequested();` and remove the inner `try`/`catch`, keeping the save and the check that follows it. With the same input, [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) raises an exception before slide 2 and the caller receives no list.

## **FAQ**

**When should I request cancellation?**

Request cancellation when a deadline expires or the caller no longer needs the result. A request made after an operation finishes leaves its result intact.

**How do the source and token differ?**

The source lets an application request cancellation. The token lets Aspose.Slides and application code observe that request.

**Can multiple operations share a source?**

Yes. A request applies to all operations using tokens from that source. Create separate sources for operations that need independent cancellation.
