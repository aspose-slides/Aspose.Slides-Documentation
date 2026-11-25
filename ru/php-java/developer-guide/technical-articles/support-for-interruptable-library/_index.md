---
title: Прерывание длительных операций с презентациями в PHP
linktitle: Прерывание операций с презентациями
type: docs
weight: 120
url: /ru/php-java/support-for-interruptable-library/
keywords:
- токен прерывания
- отмена
- тайм-аут конвертации
- экспорт слайдов
- PowerPoint
- PHP
- Aspose.Slides
description: "Узнайте, как отменить конвертацию презентации по таймеру и вернуть слайды, экспортированные до отмены, с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

Aspose.Slides for PHP via Java может прерывать длительные операции, такие как загрузка, сохранение и рендеринг презентаций. В цикле, который экспортирует один слайд за раз, один и тот же токен позволяет вашему приложению остановиться перед следующим слайдом и вернуть список завершённых экспортов.

Оба примера PHP предполагают, что ваш bootstrap вызывает `define("JAVA_PREFER_VALUES", 1);` до загрузки `Java.inc` моста, затем загружает `aspose.slides.php`. Эта настройка позволяет PHP перехватывать исключения Java во время вызова. Примеры проверяют причину обёрнутого исключения, чтобы другие ошибки конвертации доходили до вызывающего кода.

## **Прервать операцию с презентацией**

Создайте [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/), получите его токен с помощью [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken) и передайте его в [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken). Укажите эти параметры при создании [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Вызов [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) запрашивает отмену. Выполняющаяся операция останавливается, когда наблюдает запрос.

### **Установить тайм-аут конвертации**

Пока PHP ожидает синхронную загрузку или сохранение через PHP/Java Bridge, таймер Java может запросить отмену в отдельном потоке. Сохраните следующий вспомогательный файл как `ConversionTimeout.java`, скомпилируйте его с Aspose.Slides JAR в classpath и сделайте скомпилированный класс доступным мостику под именем пакета `example.ConversionTimeout`.

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

С загруженными мостом и обёрткой Aspose.Slides PHP выполните следующий пример, поместив `sample.pptx` в рабочий каталог Java‑процесса или указав абсолютные пути, доступные этому процессу. Ограничение в 20 секунд охватывает как загрузку, так и экспорт в PDF. Если конверсия завершится быстрее, PHP отменит таймер. Чтобы конвертировать в более старый формат PowerPoint с ограничением в 10 секунд, используйте `sample.ppt`, `SaveFormat::Ppt` и `10000` миллисекунд.

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

## **Остановить перед обработкой следующего слайда**

Проверьте [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested) перед каждым экспортом. Перегрузка [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) для выбранных слайдов принимает номера слайдов, начиная с 1. Передайте массив из одного элемента, чтобы записать отдельный PDF для каждого слайда.

Используйте `sample.pptx` с как минимум двумя слайдами. Чтобы продемонстрировать отмену между экспортами, пример запрашивает её сразу после фиксирования первого слайда.

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

Пример записывает `slide-1.pdf` и выводит `Completed: [1]`. На второй итерации запрос обнаруживается до начала следующего экспорта. Если отмена происходит во время сохранения, список содержит только ранее подтверждённые экспорты. Прерванное сохранение может оставить неполный файл на диске.

Чтобы передать отмену вызывающему коду, замените проверку в начале цикла на `$token->throwIfInterruptionRequested();` и удалите внутренний `try`/`catch`, оставив сохранение и проверку, следующую за ним. При том же вводе [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) генерирует исключение до слайда 2, и вызывающий код не получает списка.

## **Вопросы и ответы**

**Когда следует запрашивать отмену?**

Запрашивайте отмену, когда истекает срок выполнения или вызывающий код больше не нуждается в результате. Запрос, сделанный после завершения операции, оставляет её результат нетронутым.

**Чем отличаются источник и токен?**

Источник позволяет приложению запросить отмену. Токен позволяет Aspose.Slides и коду приложения наблюдать за этим запросом.

**Можно ли использовать один источник для нескольких операций?**

Да. Запрос применяется ко всем операциям, использующим токены из этого источника. Создавайте отдельные источники для операций, которым требуется независимая отмена.