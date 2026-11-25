---
title: PHP에서 장시간 실행되는 프레젠테이션 작업 중단
linktitle: 프레젠테이션 작업 중단
type: docs
weight: 120
url: /ko/php-java/support-for-interruptable-library/
keywords:
- 인터럽션 토큰
- 취소
- 변환 제한 시간
- 슬라이드 내보내기
- PowerPoint
- PHP
- Aspose.Slides
description: "타이머를 이용해 프레젠테이션 변환을 취소하고, 취소 전 내보낸 슬라이드를 Aspose.Slides for PHP via Java와 함께 반환하는 방법을 알아보세요."
---
## **개요**

Aspose.Slides for PHP via Java은 로드, 저장 및 프레젠테이션 렌더링과 같은 장시간 작업을 중단할 수 있습니다. 한 번에 하나의 슬라이드를 내보내는 루프에서 동일한 토큰을 사용하면 다음 슬라이드 전에 애플리케이션을 중지하고 완료된 내보내기의 목록을 반환할 수 있습니다.

두 PHP 예제는 부트스트랩이 브리지의 `Java.inc`를 로드하기 전에 `define("JAVA_PREFER_VALUES", 1);`를 호출하고, 그 후 `aspose.slides.php`를 로드한다고 가정합니다. 이 설정은 호출 중에 PHP가 Java 예외를 잡을 수 있게 합니다. 예제에서는 래핑된 예외의 원인을 검사하여 다른 변환 오류가 호출자에게 전달되도록 합니다.

## **프레젠테이션 작업 중단**

새로운 [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/)를 생성하고, 그 토큰을 [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken)으로 얻은 다음, 이를 [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken)에 전달합니다. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)을 구성할 때 이러한 옵션을 제공하십시오. [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt)을 호출하면 취소를 요청합니다. 실행 중인 작업은 요청을 감지하면 중지됩니다.

### **변환 제한 시간 설정**

PHP가 PHP/Java Bridge를 통해 동기식 로드 또는 저장을 기다리는 동안, Java 타이머가 별도 스레드에서 취소를 요청할 수 있습니다. 다음 헬퍼를 `ConversionTimeout.java`로 저장하고, 클래스패스에 Aspose.Slides JAR를 포함시켜 컴파일한 후, 컴파일된 클래스를 `example.ConversionTimeout` 패키지 이름으로 브리지에 제공하십시오.

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

브리지와 Aspose.Slides PHP 래퍼가 로드된 상태에서, Java 프로세스 작업 디렉터리에 `sample.pptx`가 있거나 해당 프로세스가 접근 가능한 절대 경로를 사용하여 다음 예제를 실행하십시오. 20초 제한은 로드와 PDF 내보내기를 모두 포함합니다. 변환이 빨리 완료되면 PHP가 타이머를 취소합니다. 10초 제한으로 이전 PowerPoint 형식으로 변환하려면 `sample.ppt`, `SaveFormat::Ppt`, `10000`밀리초를 사용하십시오.

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

## **다음 슬라이드 처리 전에 중지**

각 내보내기 전에 [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested)를 확인하십시오. 선택된 슬라이드용 [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) 오버로드는 1부터 시작하는 슬라이드 번호를 받습니다. 각 슬라이드마다 별도의 PDF를 작성하려면 원소 하나인 배열을 전달하십시오.

`sample.pptx`에 최소 두 개 이상의 슬라이드가 있어야 합니다. 내보내기 사이에 취소를 시연하기 위해, 예제는 첫 번째 슬라이드를 기록한 직후에 취소를 요청합니다.

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

예제는 `slide-1.pdf`를 작성하고 `Completed: [1]`을 출력합니다. 두 번째 반복에서는 또 다른 내보내기를 시작하기 전에 요청을 확인합니다. 저장 중에 취소가 발생하면 목록에는 이전에 확인된 내보내기만 포함됩니다. 중단된 저장은 디스크에 불완전한 파일을 남길 수 있습니다.

취소를 호출자에게 전달하려면 루프 시작 부분의 확인을 `$token->throwIfInterruptionRequested();`로 교체하고 내부 `try`/`catch`를 제거한 뒤 저장과 그 후의 확인을 유지하십시오. 동일한 입력으로 [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested)는 슬라이드 2 이전에 예외를 발생시키고 호출자는 목록을 받지 못합니다.

## **FAQ**

**취소 요청은 언제 해야 합니까?**

마감 시간이 지나거나 호출자가 더 이상 결과를 필요로 하지 않을 때 취소를 요청합니다. 작업이 완료된 후에 요청하면 결과는 그대로 유지됩니다.

**소스와 토큰은 어떻게 다릅니까?**

소스는 애플리케이션이 취소를 요청할 수 있게 합니다. 토큰은 Aspose.Slides와 애플리케이션 코드가 해당 요청을 관찰할 수 있게 합니다.

**여러 작업이 동일한 소스를 공유할 수 있나요?**

예. 요청은 해당 소스의 토큰을 사용하는 모든 작업에 적용됩니다. 독립적인 취소가 필요한 작업에는 별도의 소스를 생성하십시오.