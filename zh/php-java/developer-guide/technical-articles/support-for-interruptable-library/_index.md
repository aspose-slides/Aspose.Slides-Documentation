---
title: 在 PHP 中中断长时间运行的演示文稿操作
linktitle: 中断演示文稿操作
type: docs
weight: 120
url: /zh/php-java/support-for-interruptable-library/
keywords:
- 中断令牌
- 取消
- 转换超时
- 幻灯片导出
- PowerPoint
- PHP
- Aspose.Slides
description: "了解如何在计时器上取消演示文稿转换，并使用 Aspose.Slides for PHP via Java 返回在取消前已导出的幻灯片。"
---
## **概述**

Aspose.Slides for PHP via Java 可以中断诸如加载、保存和渲染演示文稿等长时间运行的操作。在逐张导出幻灯片的循环中，同一个 token 让您的应用程序在下一张幻灯片之前停止并返回已完成导出的列表。

两个 PHP 示例都假设您的引导程序在加载桥接的 `Java.inc` 之前调用 `define("JAVA_PREFER_VALUES", 1);`，随后加载 `aspose.slides.php`。此设置使 PHP 能在调用期间捕获 Java 异常。示例检查包装异常的原因，以便其他转换错误能够传递给调用方。

## **中断演示文稿操作**

创建一个 [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/)，使用 [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken) 获取其 token，并将其传递给 [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken)。在构造 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 时提供这些选项。调用 [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) 可请求取消。运行中的操作在检测到请求后会停止。

### **设置转换超时**

当 PHP 通过 PHP/Java Bridge 等待同步加载或保存时，Java 计时器可以在另一个线程上请求取消。将以下帮助类保存为 `ConversionTimeout.java`，在类路径中加入 Aspose.Slides JAR 编译它，并将编译后的类以其包名 `example.ConversionTimeout` 暴露给桥接。

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

在桥接和 Aspose.Slides PHP 包装器加载完毕后，使用 `sample.pptx` 位于 Java 进程工作目录下（或使用该进程可访问的绝对路径）运行以下示例。20 秒的限制覆盖加载和 PDF 导出两个阶段。如果转换提前完成，PHP 会取消计时器。若要以旧的 PowerPoint 格式并使用 10 秒限制进行转换，请使用 `sample.ppt`、`SaveFormat::Ppt` 和 `10000` 毫秒。

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

## **在处理下一张幻灯片前停止**

在每次导出前检查 [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested)。用于选定幻灯片的 [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) 重载接受从 1 开始的幻灯片编号。传入仅含一个元素的数组即可为每张幻灯片写入单独的 PDF。

使用至少包含两张幻灯片的 `sample.pptx`。为演示在两次导出之间的取消行为，示例在记录第一张幻灯片后立即请求取消。

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

示例会写入 `slide-1.pdf` 并打印 `Completed: [1]`。第二次迭代在开始另一导出前检测到取消请求。如果在保存过程中发生取消，列表仅包含已确认的导出。被中断的保存可能在磁盘上留下不完整的文件。

若要将取消传播给调用方，请将循环起始处的检查替换为 `$token->throwIfInterruptionRequested();` 并移除内部的 `try`/`catch`，保留保存以及随后紧随的检查。使用相同输入时，[InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) 会在第二张幻灯片之前抛出异常，调用方将不会收到任何列表。

## **常见问题**

**何时应请求取消？**  
当截止时间到达或调用方不再需要结果时请求取消。在操作完成后才发出的请求不会影响已生成的结果。

**源和令牌有什么区别？**  
源允许应用程序发出取消请求。令牌让 Aspose.Slides 与应用代码能够观察到该请求。

**多个操作可以共享同一来源吗？**  
可以。来自同一来源的请求会影响所有使用该来源生成的 token 的操作。若需要相互独立的取消控制，请为每个操作创建单独的来源。