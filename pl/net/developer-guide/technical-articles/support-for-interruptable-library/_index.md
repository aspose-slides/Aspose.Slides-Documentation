---
title: Wsparcie dla Biblioteki Przerywalnej
type: docs
weight: 150
url: /pl/net/support-for-interruptable-library/
keywords:
- biblioteka przerywalna
- token przerywania
- token anulowania
- zadanie długotrwałe
- przerwanie zadania
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Umożliwienie anulowania długotrwałych zadań w Aspose.Slides dla .NET. Bezpiecznie przerywaj renderowanie i konwersje plików PowerPoint i OpenDocument, wraz z przykładami."
---
## **Przegląd**

Aspose.Slides dla .NET udostępnia mechanizm przetwarzania z możliwością przerwania dla długotrwałych zadań prezentacji, takich jak deserializacja, serializacja i renderowanie. Mechanizm ten opiera się na klasach `InterruptionToken` i `InterruptionTokenSource`.

`InterruptionToken` może być przypisany do `LoadOptions` i przekazany do konstruktora `Presentation`. Gdy wywołane zostanie `InterruptionTokenSource.Interrupt()`, powiązane długotrwałe zadanie zostaje przerwane. Artykuł pokazuje również, jak używać tego mechanizmu razem ze standardowym tokenem .NET `CancellationToken`, monitorując żądania anulowania i wywołując `Interrupt()`, gdy anulowanie zostanie zgłoszone.

## **Biblioteka przerywalna**

W [Aspose.Slides 18.4](https://releases.aspose.com/slides/pl/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/) wprowadziliśmy klasy [InterruptionToken](https://reference.aspose.com/slides/pl/net/aspose.slides/interruptiontoken/) i [InterruptionTokenSource](https://reference.aspose.com/slides/pl/net/aspose.slides/interruptiontokensource/). Pozwalają one przerywać długotrwałe zadania, takie jak deserializacja, serializacja i renderowanie.

- [InterruptionTokenSource](https://reference.aspose.com/slides/pl/net/aspose.slides/interruptiontokensource/) jest źródłem tokenu(ów) przekazywanych do [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/pl/net/aspose.slides/iloadoptions/interruptiontoken/).
- Gdy [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/pl/net/aspose.slides/iloadoptions/interruptiontoken/) jest ustawiony i instancja [LoadOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/) zostanie przekazana do konstruktora [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/), wywołanie [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/pl/net/aspose.slides/interruptiontokensource/interrupt/) przerywa każde długotrwałe zadanie powiązane z tą [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).

Poniższy fragment kodu demonstruje przerywanie uruchomionego zadania:

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
    Run(action, tokenSource.Token); // uruchom akcję w osobnym wątku
    Thread.Sleep(10000);            // limit czasu
    tokenSource.Interrupt();        // zatrzymaj konwersję
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **CancellationToken .NET i biblioteka przerywalna**

Gdy potrzebujesz używać [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) razem z biblioteką przerywalną Aspose.Slides, opakuj przetwarzanie [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) i przerywaj [InterruptionToken](https://reference.aspose.com/slides/pl/net/aspose.slides/interruptiontoken/), gdy [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) jest `true`.

Ten kod C# demonstruje działanie:

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
    Task task = Run(action, tokenSource.Token); // uruchom akcję w osobnym wątku

    while (!task.Wait(500)) // czekaj i monitoruj, czy cancellationToken.IsCancellationRequested jest ustawiony
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // przerwij przetwarzanie prezentacji
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

**Jaki jest cel biblioteki przerywalnej Aspose.Slides?**

Zapewnia mechanizm umożliwiający przerwanie długotrwałych operacji — takich jak ładowanie, zapisywanie lub renderowanie prezentacji — przed ich zakończeniem. Jest to przydatne, gdy czas przetwarzania musi być ograniczony lub zadanie nie jest już potrzebne.

**Jaka jest różnica między [InterruptionToken](https://reference.aspose.com/slides/pl/net/aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/pl/net/aspose.slides/iinterruptiontokensource/)?**

- `InterruptionToken` jest przekazywany do interfejsu API Aspose.Slides i sprawdzany podczas długotrwałych operacji.
- `InterruptionTokenSource` jest używany w Twoim kodzie do tworzenia tokenów i wywoływania przerwań poprzez wywołanie `Interrupt()`.

**Czy mogę używać .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) z biblioteką przerywalną?**

Tak. Możesz monitorować [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) w logice aplikacji i wywoływać [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/pl/net/aspose.slides/iinterruptiontokensource/interrupt/), gdy zostanie zgłoszone anulowanie. Umożliwia to integrację Aspose.Slides ze standardowymi przepływami anulowania w .NET.

**Jakie zadania można przerwać?**

Każde zadanie Aspose.Slides, które akceptuje [InterruptionToken](https://reference.aspose.com/slides/pl/net/aspose.slides/interruptiontoken/) — na przykład ładowanie prezentacji przy użyciu `Presentation(path, loadOptions)` lub zapisywanie przy użyciu `Presentation.Save(...)` — może być przerwane.

**Czy przerwanie następuje natychmiast?**

Nie. Przerwanie jest współpracujące: operacja okresowo sprawdza token i zatrzymuje się, gdy wykryje, że wywołano [Interrupt()](https://reference.aspose.com/slides/pl/net/aspose.slides/iinterruptiontokensource/interrupt/).

**Co się stanie, jeśli wywołam [Interrupt()](https://reference.aspose.com/slides/pl/net/aspose.slides/iinterruptiontokensource/interrupt/) po tym, jak zadanie już się zakończyło?**

Nic — wywołanie nie ma efektu, jeśli odpowiadające mu zadanie już zostało zakończone.

**Czy mogę ponownie użyć tego samego [InterruptionTokenSource](https://reference.aspose.com/slides/pl/net/aspose.slides/iinterruptiontokensource/) dla wielu zadań?**

Tak — ale po wywołaniu [Interrupt()](https://reference.aspose.com/slides/pl/net/aspose.slides/iinterruptiontokensource/interrupt/) na tym źródle wszystkie zadania używające jego tokenów zostaną przerwane. Używaj oddzielnych źródeł tokenów, aby zarządzać zadaniami niezależnie.