---
title: Поддержка библиотеки Interruptable
type: docs
weight: 120
url: /ru/java/support-for-interruptable-library/
keywords:
- прерываемая библиотека
- токен прерывания
- токен отмены
- длительная задача
- прерывание задачи
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Сделайте длительные задачи отменяемыми с Aspose.Slides для Java. Безопасно прерывайте рендеринг и конвертации для PowerPoint и OpenDocument, с примерами."
---

## **Interruptable Library**

В [Aspose.Slides 18.4](https://releases.aspose.com/slides/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/), мы представили классы [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) и [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/). Они позволяют прерывать длительные задачи, такие как десериализация, сериализация и рендеринг.

- [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) — источник токена(ов), передаваемых в [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-).
- Когда задаётся [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) и экземпляр [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) передаётся конструктору [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), вызов [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) прерывает любую длительную задачу, связанную с этой [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).

Следующий фрагмент кода демонстрирует прерывание выполняющейся задачи:
```java
final InterruptionTokenSource tokenSource = new InterruptionTokenSource();

Runnable interruption = new Runnable() {
    public void run() {
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setInterruptionToken(tokenSource.getToken());

        Presentation presentation = new Presentation("sample.pptx", loadOptions);
        try{
            presentation.save("sample.ppt", SaveFormat.Ppt);
        }
        finally {
            presentation.dispose();
        }
    }
};

Thread thread = new Thread(interruption);
thread.start();          // выполнить действие в отдельном потоке
Thread.sleep(10000);     // тайм-аут
tokenSource.interrupt(); // остановить конвертацию
```


## **FAQ**

**Какова цель библиотеки прерываний Aspose.Slides?**

Она предоставляет механизм прерывания длительных операций — например, загрузки, сохранения или рендеринга презентаций — до их завершения. Это полезно, когда нужно ограничить время обработки или задача более не требуется.

**В чём разница между [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) и [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` передаётся в API Aspose.Slides и проверяется во время длительных операций.
- `InterruptionTokenSource` используется в вашем коде для создания токенов и инициирования прерываний вызовом `Interrupt()`.

**Какие задачи можно прервать?**

Любую задачу Aspose.Slides, принимающую [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) — например, загрузку презентации через `Presentation(path, loadOptions)` или сохранение через `Presentation.save(...)` — можно прервать.

**Прерывание происходит немедленно?**

Нет. Прерывание кооперативное: операция периодически проверяет токен и останавливается, как только обнаруживает, что был вызван [Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--).

**Что произойдёт, если я вызову [Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) после завершения задачи?**

Ничего — вызов не влияет, если соответствующая задача уже завершена.

**Можно ли повторно использовать один и тот же [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) для нескольких задач?**

Да, но после вызова [Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) у этого источника все задачи, использующие его токены, будут прерваны. Используйте отдельные источники токенов для независимого управления задачами.