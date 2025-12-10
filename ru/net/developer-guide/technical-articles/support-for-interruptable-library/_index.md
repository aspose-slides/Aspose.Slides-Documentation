---
title: Поддержка библиотеки Interruptable
type: docs
weight: 150
url: /ru/net/support-for-interruptable-library/
keywords:
- прерываемая библиотека
- токен прерывания
- токен отмены
- длительная задача
- прерывание задачи
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Сделайте длительные задачи отменяемыми с помощью Aspose.Slides для .NET. Безопасно прерывайте рендеринг и конвертацию PowerPoint и OpenDocument, используя примеры."
---

## **Библиотека Interruptable**

В [Aspose.Slides 18.4](https://releases.aspose.com/slides/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/) мы представили классы [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) и [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/). Они позволяют прерывать длительные операции, такие как десериализация, сериализация и рендеринг.

- [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) — источник токена(ов), передаваемых в [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/interruptiontoken/).
- Когда [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/interruptiontoken/) установлен и экземпляр [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) передаётся в конструктор [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), вызов [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) прерывает любую длительную задачу, связанную с этой [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).

Следующий фрагмент кода демонстрирует прерывание выполняющейся задачи:
```c#
public static void Run()
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions { InterruptionToken = token };
        using (Presentation presentation = new Presentation("sample.pptx", options))
        {
            presentation.Save("sample.ppt", SaveFormat.Ppt);
        }
    };

    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Run(action, tokenSource.Token); // запустить действие в отдельном потоке
    Thread.Sleep(10000);            // тайм-аут
    tokenSource.Interrupt();        // остановить конвертацию
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```


## **CancellationToken .NET и библиотека Interruptable**

Когда необходимо использовать [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) совместно с прерываемой библиотекой Aspose.Slides, оберните обработку [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и прерывайте [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/), если [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) равно `true`.

Этот пример на C# показывает, как это работает:
```cs
public static void Main()
{
    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    ProcessPresentation("sample.pptx", "sample.pdf", tokenSource.Token);
}

static void ProcessPresentation(string path, string outPath, CancellationToken cancellationToken)
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions {InterruptionToken = token};
        using (Presentation presentation = new Presentation(path, options))
        {
            presentation.Save(outPath, SaveFormat.Pdf);
        }
    };
    
    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Task task = Run(action, tokenSource.Token); // запустить действие в отдельном потоке

    while (!task.Wait(500)) // ожидать и отслеживать, установлен ли cancellationToken.IsCancellationRequested
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // прервать обработку презентации
        }
    }
}

private static Task Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    return Task.Run(() =>
    {
        action(token);
    });
}
```


## **FAQ**

**Какова цель библиотеки прерывания Aspose.Slides?**

Она предоставляет механизм прерывания длительных операций — загрузки, сохранения или рендеринга презентаций — до их завершения. Это полезно, когда требуется ограничить время обработки или задача более не нужна.

**В чём разница между [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) и [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/)?**

- `InterruptionToken` передаётся в API Aspose.Slides и проверяется во время длительных операций.
- `InterruptionTokenSource` используется в вашем коде для создания токенов и вызова прерывания через `Interrupt()`.

**Можно ли использовать .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) с библиотекой прерывания?**

Да. Вы можете отслеживать [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) в логике приложения и вызывать [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/), когда требуется отмена. Это позволяет Aspose.Slides интегрироваться со стандартными процессами отмены в .NET.

**Какие задачи можно прерывать?**

Любая задача Aspose.Slides, принимающая [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) — например, загрузка презентации через `Presentation(path, loadOptions)` или сохранение через `Presentation.Save(...)` — может быть прервана.

**Прерывание происходит мгновенно?**

Нет. Прерывание кооперативное: операция периодически проверяет токен и останавливается, как только обнаруживает вызов [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/).

**Что произойдёт, если вызвать [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) после завершения задачи?**

Ничего — вызов не имеет эффекта, если соответствующая задача уже завершена.

**Можно ли повторно использовать один [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/) для нескольких задач?**

Да — но после вызова [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) на этом источнике все задачи, использующие его токены, будут прерваны. Для независимого управления задачами используйте отдельные источники токенов.