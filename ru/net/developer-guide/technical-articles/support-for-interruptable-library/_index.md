---
title: Поддержка прерываемой библиотеки
type: docs
weight: 150
url: /ru/net/support-for-interruptable-library/

---

## **Прерываемая библиотека**

В [Aspose.Slides 18.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-18-4-release-notes/) мы добавили класс [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken) и класс [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource). Они обеспечивают поддержку прерывания длительных задач, таких как десериализация, сериализация или рендеринг.

- InterruptionTokenSource представляет источник токена или нескольких токенов, переданных в **ILoadOptions.InterruptionToken**.
- Когда ILoadOptions.InterruptionToken установлен и экземпляр LoadOptions передан в конструктор Presentation, вызов метода InterruptionTokenSource.Interrupt вызывает прерывание любой длительной задачи, связанной с Presentation.

Ниже приведен фрагмент кода, демонстрирующий прерывание выполняемой задачи:

```c#
public static void Run()
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions { InterruptionToken = token };
        using (Presentation presentation = new Presentation("pres.pptx", options))
        {
            presentation.Save("pres.ppt", SaveFormat.Ppt);
        }
    };

    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Run(action, tokenSource.Token); // запускаем действие в отдельном потоке
    Thread.Sleep(10000);            // таймаут
    tokenSource.Interrupt();        // останавливаем конвертацию

}
private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}

```

## **.NET CancellationToken и прерываемая библиотека**

Когда вам необходимо использовать [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) совместно с прерываемой библиотекой Slides, вы можете обернуть обработку Presentation и прервать [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken), если [cancellationToken.IsCancellationRequested](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) установлен в true.

Этот код C# демонстрирует описанную операцию:

``` csharp
public static void Main()
{
    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    ProcessPresentation("pres.pptx", "pres.pdf", tokenSource.Token);
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
    Task task = Run(action, tokenSource.Token); // запускаем действие в отдельном потоке

    while (!task.Wait(500)) // ждем, чтобы отследить, установлен ли cancellationToken.IsCancellationRequested.
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Обработка презентации была отменена");
            tokenSource.Interrupt(); // прерываем обработку Presentation
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