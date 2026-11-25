---
title: 在 PHP 中中斷長時間執行的簡報操作
linktitle: 中斷簡報操作
type: docs
weight: 120
url: /zh-hant/php-java/support-for-interruptable-library/
keywords:
- 中斷 token
- 取消
- 轉換逾時
- 投影片匯出
- PowerPoint
- PHP
- Aspose.Slides
description: "了解如何在計時器上取消簡報轉換，並在取消之前返回已匯出的投影片，使用 Aspose.Slides for PHP via Java。"
---
## **概觀**

Aspose.Slides for PHP via Java 可以中斷長時間執行的操作，例如載入、儲存和算繪簡報。在逐張匯出的迴圈中，同一個 token 讓您的應用程式在下一張投影片之前停止，並回傳已完成匯出的清單。

兩個 PHP 範例皆假設您的啟動程式在載入橋接程式的 `Java.inc` 之前呼叫 `define("JAVA_PREFER_VALUES", 1);`，然後載入 `aspose.slides.php`。此設定讓 PHP 在呼叫期間捕捉 Java 例外。範例會檢查被包裝例外的原因，以便其他轉換錯誤能傳遞給呼叫端。

## **中斷簡報操作**

建立一個 [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/)，使用 [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken) 取得其 token，並將其傳遞給 [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken)。在建構 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 時提供這些選項。呼叫 [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) 會請求取消。當執行中的操作偵測到請求時會停止。

### **設定轉換逾時時間**

當 PHP 透過 PHP/Java Bridge 等待同步的載入或儲存時，Java 計時器可以在另一個執行緒上請求取消。將以下輔助程式儲存為 `ConversionTimeout.java`，使用包含 Aspose.Slides JAR 的 classpath 進行編譯，並使編譯後的類別在橋接程式下以其套件名稱 `example.ConversionTimeout` 可供使用。

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

在載入橋接程式和 Aspose.Slides PHP 包裝器後，於 Java 行程的工作目錄中放入 `sample.pptx`（或使用該行程可存取的絕對路徑），執行以下範例。20 秒的限制同時涵蓋載入與 PDF 匯出。如果轉換提早完成，PHP 會取消計時器。若要以 10 秒的限制轉換為較舊的 PowerPoint 格式，請使用 `sample.ppt`、`SaveFormat::Ppt` 與 `10000` 毫秒。

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

## **在處理下一張投影片前停止**

在每次匯出前檢查 [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested)。用於選取投影片的 [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) 重載接受從 1 開始的投影片編號。傳遞只有一個元素的陣列即可為每張投影片寫入單獨的 PDF。

使用至少包含兩張投影片的 `sample.pptx`。為了示範匯出之間的取消，範例會在記錄完第一張投影片後立即發出請求。

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

範例會寫入 `slide-1.pdf` 並輸出 `Completed: [1]`。第二次迭代在開始另一個匯出之前會看到請求。如果在儲存期間發生取消，清單僅包含先前已確認的匯出。被中斷的儲存可能會在磁碟上留下不完整的檔案。

若要將取消傳遞給呼叫端，請將迴圈開始時的檢查改為 `$token->throwIfInterruptionRequested();`，並移除內部的 `try`/`catch`，保留儲存動作及其後的檢查。使用相同的輸入時，[InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) 會在第 2 張投影片之前拋出例外，呼叫端將不會收到清單。

## **常見問題**

**何時應該請求取消？**

在截止時間到期或呼叫端不再需要結果時請求取消。若在操作完成後才提出請求，結果將保持不變。

**來源與 token 有何不同？**

來源允許應用程式請求取消。 token 讓 Aspose.Slides 以及應用程式程式碼觀察此請求。

**多個操作可以共用同一個來源嗎？**

可以。請求會作用於所有使用該來源之 token 的操作。對需要獨立取消的操作，請建立不同的來源。