---
title: Прервать длительные операции с презентациями на Android
linktitle: Прервать операции с презентацией
type: docs
weight: 120
url: /ru/androidjava/support-for-interruptable-library/
keywords:
- прерываемые операции
- токен прерывания
- токен отмены
- длительная задача
- прерывание задачи
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как отменять длительные операции с презентациями в Aspose.Slides для Android через Java и возвращать частичный результат при экспорте слайдов в цикле."
---
## **Обзор**

Aspose.Slides for Android via Java может прерывать длительные операции, такие как загрузка, сохранение и рендеринг презентаций. Ваше приложение может использовать один и тот же токен прерывания, чтобы остановить цикл до того, как он начнёт обрабатывать следующий слайд.

## **Прерывание операции презентации**

Создайте [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/), получите его токен с помощью [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--), и передайте токен в [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Передайте параметры загрузки в [конструктор Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Чтобы запросить отмену, вызовите [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) у источника. Прерываемая операция останавливается, когда она фиксирует запрос.

Пример конвертирует `sample.pptx` в `sample.ppt` в фоновом потоке. Вызывающий поток ждёт до 10 секунд завершения конвертации. Если конвертация всё ещё выполняется, он запрашивает отмену и ждёт завершения рабочего потока.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
    // Вызов из фонового потока и передача context.getFilesDir(), который содержит sample.pptx.
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

## **Подключение таймаута Java к Aspose.Slides**

Чтобы задать временной лимит для операции с презентацией, используйте [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService) для вызова [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) при истечении таймаута. Пример позволяет 20 секунд на загрузку `sample.pptx` и экспорт в `sample.pdf`. Если экспорт завершается раньше, приложение отменяет запланированный запрос.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // Вызов из фонового потока и передача context.getFilesDir(), который содержит sample.pptx.
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

## **Остановить перед обработкой следующего слайда**

Используйте тот же [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/) для презентации и цикла, экспортирующего её слайды. Проверяйте [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) перед каждым экспортом. Если вызывающий может использовать частичный результат, верните номера слайдов, успешно экспортированных.

Используйте презентацию с именем `sample.pptx`, содержащую минимум два слайда. Перегрузка [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-) принимает массив номеров слайдов, где нумерация начинается с 1. Пример сохраняет каждый слайд в отдельный PDF и запрашивает отмену сразу после записи первого успешного экспорта.

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

    // Вызов из фонового потока и передача context.getFilesDir(), который содержит sample.pptx.
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```

Пример записывает `slide-1.pdf` и выводит `Starting slide 1`, за которым следует `Completed: [1]`. Цикл фиксирует запрос перед началом обработки слайда 2. Если отмена приходит во время сохранения, цикл завершается до того, как слайд будет помечен как завершённый.

Если вызывающему нужно обрабатывать отмену, замените проверку и её `break` в начале цикла на `token.throwIfInterruptionRequested()`. Уберите `try`/`catch` вокруг сохранения, чтобы отмена во время экспорта также доходила до вызывающего кода. При том же вводе пример выводит только `Starting slide 1` и записывает `slide-1.pdf`. В начале второй итерации [throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) бросает `com.aspose.slides.exceptions.OperationCanceledException` до начала следующего экспорта. Метод не возвращает список.

## **Вопросы и ответы**

**Когда следует запрашивать отмену?**

Запрашивайте отмену, когда операция превышает ваш временной лимит или когда приложению больше не нужен результат.

**В чём разница между [InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) и [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

Источник позволяет вашему приложению запросить отмену. Токен позволяет Aspose.Slides и вашему приложению проверять наличие такого запроса.

**Можно ли отменить операцию с помощью таймера Java?**

Да. Запланируйте вызов [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) у источника, связанного с презентацией.

**Какие операции можно прерывать?**

Можно прерывать загрузку, сохранение и рендеринг. Передайте токен в [конструктор Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) через [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). После этого презентация может фиксировать отмену во время последующих операций, таких как сохранение в PDF.

**Останавливается ли операция сразу?**

Отмена кооперативна. Операция периодически проверяет токен и останавливается, когда фиксирует запрос.

**Что происходит, если я вызову [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) после завершения операции?**

Завершённая операция сохраняет свой результат.

**Могут ли несколько операций использовать один [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

Да. Вызов [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) запрашивает отмену для каждой операции, использующей токен из данного источника. Используйте отдельный источник для каждой операции, которую нужно отменять независимо.