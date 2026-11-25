---
title: Прерывание длительных операций с презентациями в .NET
linktitle: Прерывание операций с презентацией
type: docs
weight: 150
url: /ru/net/support-for-interruptable-library/
keywords:
- прерываемые операции
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
description: "Узнайте, как отменять длительные операции с презентациями в Aspose.Slides для .NET и получать частичный результат при экспорте слайдов в цикле."
---
## **Обзор**

Aspose.Slides для .NET может прерывать длительные операции, такие как загрузка, сохранение и рендеринг презентаций. Ваше приложение может использовать тот же токен прерывания, чтобы остановить цикл до того, как он начнёт обрабатывать следующий слайд.

## **Прерывание операции с презентацией**

Создайте [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/), назначьте его [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) в [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/), и передайте параметры загрузки в [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Чтобы запросить отмену, вызовите [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) у источника. Прерываемая операция останавливается, когда она обнаруживает запрос.

В примере начинается конвертация `sample.pptx` в `sample.ppt` в фоновой задаче, и через 10 секунд запрашивается отмена. Если конвертация завершится раньше, вывод уже будет готов.

```c#
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

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
    Run(action, tokenSource.Token); // выполнить действие в отдельном потоке
    Thread.Sleep(10000);            // тайм-аут
    tokenSource.Interrupt();        // остановить конвертацию
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **Подключить отмену .NET к Aspose.Slides**

Если ваше приложение использует .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken), перенаправьте его запрос на отмену в Aspose.Slides. В примере начинается экспорт `sample.pptx` в `sample.pdf` с тайм‑аутом 20 секунд. Пока экспорт выполняется, каждые 500 миллисекунд проверяется [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested). Когда свойство становится `true`, вызывается [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/).

```cs
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

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
    Task task = Run(action, tokenSource.Token); // выполнить действие в отдельном потоке
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

## **Остановить перед обработкой следующего слайда**

Используйте один и тот же [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/) как для презентации, так и для цикла, экспортирующего её слайды. Перед началом каждого экспорта проверяйте [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/) . Если вызывающая сторона может работать с частичным результатом, возвращайте номера слайдов, успешно экспортированных.

Возьмите презентацию с именем `sample.pptx`, содержащую как минимум два слайда. В примере запрос отмены делается сразу после записи первого успешного экспорта.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new InterruptionTokenSource();
var completed = ExportSlides("sample.pptx", source);
Console.WriteLine($"Completed: [{string.Join(", ", completed)}]");

static List<int> ExportSlides(string path, IInterruptionTokenSource source)
{
    var completed = new List<int>();
    IInterruptionToken token = source.Token;
    var options = new LoadOptions { InterruptionToken = token };
    using var presentation = new Presentation(path, options);

    for (var number = 1; number <= presentation.Slides.Count; number++)
    {
        if (token.IsInterruptionRequested)
            break;

        Console.WriteLine($"Starting slide {number}");
        try
        {
            presentation.Save($"slide-{number}.pdf", new[] { number }, SaveFormat.Pdf);
        }
        catch (OperationCanceledException) when (token.IsInterruptionRequested)
        {
            break;
        }

        completed.Add(number);
        if (number == 1)
            source.Interrupt();
    }

    return completed;
}
```

В примере создаётся `slide-1.pdf` и выводятся сообщения `Starting slide 1`, а затем `Completed: [1]`. Цикл видит запрос перед началом обработки слайда 2. Если отмена вместо этого прерывает [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) во время экспорта, блок `catch` выходит из цикла до того, как код отметит текущий слайд как завершённый.

Если вызывающей стороне необходимо обрабатывать отмену, замените проверку `if` и её `break` в начале цикла вызовом [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) на токене. Уберите `try`/`catch` вокруг экспорта, чтобы отмена во время сохранения также передавалась вызывающей стороне. При тех же входных данных пример выводит только `Starting slide 1` и сохраняет `slide-1.pdf`. В начале второй итерации вызывающая сторона получает [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception) до начала экспорта. Метод не возвращает список.

## **FAQ**

**Когда следует запрашивать отмену?**

Запрашивайте отмену, когда операция превышает установленный вами предел времени или когда вашему приложению больше не нужен результат.

**В чём разница между [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) и [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

Источник позволяет вашему приложению запросить отмену. Токен позволяет Aspose.Slides и вашему приложению проверять наличие такого запроса.

**Можно ли использовать .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) с Aspose.Slides?**

Да. Когда ваш .NET‑токен сигнализирует об отмене, вызовите [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) у источника, связанного с презентацией.

**Какие операции можно прервать?**

Можно прерывать загрузку, сохранение и рендеринг. Передайте токен в [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) через [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/). Презентация тогда сможет обнаруживать отмену во время последующих операций, таких как [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/).

**Останавливается ли операция немедленно?**

Отмена является кооперативной. Операция периодически проверяет токен и останавливается, когда обнаруживает запрос.

**Что происходит, если вызвать [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) после завершения операции?**

Завершённая операция сохраняет свой результат.

**Могут ли несколько операций использовать один [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

Да. Вызов [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) запрашивает отмену для каждой операции, использующей токен из этого источника. Используйте отдельный источник для каждой операции, которую требуется отменять независимо.