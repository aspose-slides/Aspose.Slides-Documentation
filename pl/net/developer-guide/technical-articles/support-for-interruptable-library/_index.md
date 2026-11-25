---
title: Przerwanie długotrwałych operacji prezentacji w .NET
linktitle: Przerwanie operacji prezentacji
type: docs
weight: 150
url: /pl/net/support-for-interruptable-library/
keywords:
- operacje przerywalne
- token przerwania
- token anulowania
- zadanie długotrwałe
- przerwać zadanie
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak anulować długotrwałe operacje prezentacji w Aspose.Slides dla .NET i zwrócić częściowy wynik podczas eksportowania slajdów w pętli."
---
## **Przegląd**

Aspose.Slides for .NET może przerywać długotrwałe operacje, takie jak ładowanie, zapisywanie i renderowanie prezentacji. Twoja aplikacja może używać tego samego tokenu przerwania, aby zatrzymać pętlę przed rozpoczęciem przetwarzania kolejnego slajdu.

## **Przerwanie operacji prezentacji**

Utwórz [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/), przypisz jego [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) do [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/), i przekaż opcje ładowania do [konstruktor Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Aby zażądać anulowania, wywołaj [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) na źródle. Przerwana operacja zatrzymuje się, gdy zauważy żądanie.

Przykład rozpoczyna konwersję `sample.pptx` do `sample.ppt` w zadaniu w tle i żąda anulowania po 10 sekundach. Jeśli konwersja zakończy się wcześniej, wynik jest już gotowy.

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
    Run(action, tokenSource.Token); // uruchom akcję w osobnym wątku
    Thread.Sleep(10000);            // limit czasu
    tokenSource.Interrupt();        // zatrzymaj konwersję
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **Połączenie anulowania .NET z Aspose.Slides**

Jeśli Twoja aplikacja używa .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken), przekaż jej żądanie anulowania do Aspose.Slides. Przykład rozpoczyna eksport `sample.pptx` do `sample.pdf` i ustawia limit czasu 20 sekund. Podczas eksportu co 500 milisekund sprawdza [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested), a gdy właściwość przyjmuje wartość `true`, wywołuje [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/).

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

## **Zatrzymaj przed przetworzeniem kolejnego slajdu**

Użyj tego samego [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/) zarówno dla prezentacji, jak i dla pętli eksportującej jej slajdy. Sprawdź [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/) przed rozpoczęciem każdego eksportu. Jeśli wywołujący może użyć częściowego wyniku, zwróć numery slajdów dla eksportów, które zakończyły się pomyślnie.

Użyj prezentacji o nazwie `sample.pptx` zawierającej co najmniej dwa slajdy. Przykład żąda anulowania natychmiast po zapisaniu pierwszego udanego eksportu.

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

Przykład zapisuje `slide-1.pdf` i wypisuje `Starting slide 1`, po czym `Completed: [1]`. Pętla widzi żądanie przed rozpoczęciem slajdu 2. Jeśli anulowanie zamiast tego przerwie [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) podczas eksportu, blok `catch` wychodzi z pętli przed zapisaniem bieżącego slajdu jako zakończonego.

Jeśli wywołujący musi obsłużyć anulowanie, zamień sprawdzenie `if` i jego `break` na początku pętli na wywołanie [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) na tokenie. Usuń `try`/`catch` wokół eksportu, aby anulowanie podczas zapisu również dotarło do wywołującego. Przy tym samym wejściu przykład wypisuje tylko `Starting slide 1` i zapisuje `slide-1.pdf`. Na początku drugiej iteracji wywołujący otrzymuje [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception), zanim rozpocznie się eksport. Metoda nie zwraca żadnej listy.

## **FAQ**

**Kiedy powinienem żądać anulowania?**

Zażądaj anulowania, gdy operacja przekracza Twój limit czasu lub gdy aplikacja nie potrzebuje już wyniku.

**Jaka jest różnica między [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

Źródło umożliwia Twojej aplikacji żądanie anulowania. Token pozwala Aspose.Slides i Twojej aplikacji sprawdzać to żądanie.

**Czy mogę używać .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) z Aspose.Slides?**

Tak. Gdy Twój token .NET sygnalizuje anulowanie, wywołaj [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) na źródle powiązanym z prezentacją.

**Jakie operacje mogę przerwać?**

Możesz przerwać ładowanie, zapisywanie i renderowanie. Przekaż token do [konstruktor Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) przez [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/). Prezentacja może wtedy obserwować anulowanie podczas kolejnych operacji, takich jak [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/).

**Czy operacja zatrzymuje się natychmiast?**

Anulowanie jest współpracujące. Operacja sprawdza token okresowo i zatrzymuje się, gdy zauważy żądanie.

**Co się stanie, jeśli wywołam [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) po zakończeniu operacji?**

Zakończona operacja zachowuje swój wynik.

**Czy wiele operacji może współdzielić [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

Tak. Wywołanie [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) żąda anulowania dla każdej operacji używającej tokenu z tego źródła. Użyj oddzielnego źródła dla każdej operacji, którą chcesz anulować niezależnie.