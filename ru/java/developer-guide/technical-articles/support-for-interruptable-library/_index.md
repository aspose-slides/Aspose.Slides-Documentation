---
title: Прерывание длительно выполняющихся операций с презентациями в Java
linktitle: Прерывание операций с презентацией
type: docs
weight: 120
url: /ru/java/support-for-interruptable-library/
keywords:
- прерываемые операции
- токен прерывания
- токен отмены
- длительная задача
- прерывание задачи
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как отменять длительные операции с презентациями в Aspose.Slides для Java и возвращать частичный результат при экспорте слайдов в цикле."
---
## **Обзор**

Aspose.Slides for Java может прерывать длительные операции, такие как загрузка, сохранение и рендеринг презентаций. Ваше приложение может использовать один и тот же токен прерывания, чтобы остановить цикл до начала обработки следующего слайда.

## **Прерывание операции с презентацией**

Создайте [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/), получите его токен с помощью [getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--), и передайте токен в [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Передайте параметры загрузки в [конструктор Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Чтобы запросить отмену, вызовите [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) у источника. Прерываемая операция останавливается, когда она замечает запрос.

Пример конвертирует `sample.pptx` в `sample.ppt` в фоновом потоке. Вызывающий поток ждёт до 10 секунд завершения конвертации. Если конвертация всё ещё работает, он запрашивает отмену и ждёт завершения рабочего потока.

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

## **Привязка тайм‑аута Java к Aspose.Slides**

Чтобы задать ограничение по времени для операции с презентацией, используйте [ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html) для вызова [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) при истечении тайм‑аута. В примере выделяется 20 секунд для загрузки `sample.pptx` и экспорта его в `sample.pdf`. Если экспорт завершается раньше, приложение отменяет запланированный запрос.

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

## **Остановка перед обработкой следующего слайда**

Используйте тот же [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/) для презентации и цикла, экспортирующего её слайды. Проверяйте [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) перед каждым экспортом. Если вызывающий может использовать частичный результат, верните номера слайдов, успешно экспортированных.

Используйте презентацию `sample.pptx` минимум с двумя слайдами. Перегрузка [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-) принимает массив номеров слайдов, считающихся с 1. Пример сохраняет каждый слайд в отдельный PDF и запрашивает отмену сразу после записи первого успешного экспорта.

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

Пример записывает `slide-1.pdf` и выводит `Starting slide 1`, а затем `Completed: [1]`. Цикл замечает запрос перед началом слайда 2. Если отмена происходит во время сохранения, цикл выходит до того, как отметит слайд как завершённый.

Если вызывающему необходимо обработать отмену, замените проверку и `break` в начале цикла на `token.throwIfInterruptionRequested()`. Удалите `try`/`catch` вокруг сохранения, чтобы отмена во время экспорта также передавалась вызывающему. При тех же входных данных пример выводит только `Starting slide 1` и записывает `slide-1.pdf`. В начале второй итерации [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) бросает `com.aspose.slides.exceptions.OperationCanceledException` до начала следующего экспорта. Метод не возвращает список.

## **FAQ**

**Когда следует запрашивать отмену?**

Запрашивайте отмену, когда операция превышает установленный лимит времени или когда приложению больше не нужен результат.

**В чём разница между [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) и [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

Источник позволяет приложению запросить отмену. Токен позволяет Aspose.Slides и вашему приложению проверять наличие такого запроса.

**Можно ли отменить операцию из таймера Java?**

Да. Запланируйте вызов [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) у источника, связанного с презентацией.

**Какие операции можно прервать?**

Можно прерывать загрузку, сохранение и рендеринг. Передайте токен в [конструктор Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) через [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Затем презентация может наблюдать отмену во время последующих операций, таких как сохранение в PDF.

**Останавливается ли операция сразу?**

Отмена кооперативна. Операция периодически проверяет токен и останавливается, когда замечает запрос.

**Что происходит, если вызвать [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) после завершения операции?**

Завершённая операция сохраняет свой результат.

**Можно ли использовать один [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) для нескольких операций?**

Да. Вызов [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) запрашивает отмену для каждой операции, использующей токен этого источника. Используйте отдельный источник для каждой операции, которую нужно отменять независимо.