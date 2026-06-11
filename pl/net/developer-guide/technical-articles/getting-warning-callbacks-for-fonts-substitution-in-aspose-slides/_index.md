---
title: Uzyskaj wywołania zwrotne ostrzeżeń o zastąpieniu czcionki w .NET
type: docs
weight: 120
url: /pl/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- wywołanie zwrotne ostrzeżeń
- zastąpienie czcionki
- proces renderowania
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak uzyskać wywołania zwrotne ostrzeżeń o zastąpieniu czcionek w Aspose.Slides dla .NET i dokładnie wyświetlać prezentacje PowerPoint oraz OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides for .NET umożliwia otrzymywanie wywołań zwrotnych ostrzeżeń o zamianie czcionek, gdy wymagana czcionka nie jest dostępna na komputerze podczas renderowania. Te wywołania pomagają diagnozować problemy z brakującymi lub niedostępnymi czcionkami.

## **Włącz wywołania zwrotne ostrzeżeń**

Aspose.Slides for .NET udostępnia proste interfejsy API do odbierania wywołań zwrotnych ostrzeżeń podczas renderowania slajdów prezentacji. Postępuj zgodnie z poniższymi krokami, aby skonfigurować wywołania zwrotne ostrzeżeń:

1. Utwórz własną klasę wywołania zwrotnego, która implementuje interfejs [IWarningCallback](https://reference.aspose.com/slides/pl/net/aspose.slides.warnings/iwarningcallback/), aby obsługiwać ostrzeżenia.
1. Ustaw wywołanie zwrotne ostrzeżeń przy użyciu klas opcji, takich jak [RenderingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/htmloptions/) i innych.
1. Załaduj prezentację, która używa czcionki niedostępnej na docelowym komputerze.
1. Wygeneruj miniaturkę slajdu lub wyeksportuj prezentację, aby zaobserwować efekt.

**Klasa własnego wywołania zwrotnego ostrzeżeń:**

```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// Przykładowe wyjście:
//
// Czcionka zostanie zastąpiona z XYZ na {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Wygeneruj miniaturkę slajdu:**

```c#
 // Skonfiguruj wywołanie zwrotne ostrzeżeń, aby obsługiwać ostrzeżenia związane z czcionkami podczas renderowania slajdów.
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

 // Wczytaj prezentację z określonej ścieżki pliku.
using var presentation = new Presentation("sample.pptx");

 // Generuj obraz miniatury dla każdego slajdu w prezentacji.
foreach (var slide in presentation.Slides)
{
    // Pobierz obraz miniatury slajdu przy użyciu określonych opcji renderowania.
    using var image = slide.GetImage(options);
    // ...
}
```

**Eksportuj do formatu PDF:**

```c#
// Skonfiguruj wywołanie zwrotne ostrzeżeń, aby obsługiwać ostrzeżenia związane z czcionkami podczas eksportu PDF.
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// Wczytaj prezentację z określonej ścieżki pliku.
using var presentation = new Presentation("sample.pptx");

// Wyeksportuj prezentację jako PDF.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```

**Eksportuj do formatu HTML:**

```c#
// Skonfiguruj wywołanie zwrotne ostrzeżeń, aby obsługiwać ostrzeżenia związane z czcionkami podczas eksportu HTML.
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// Wczytaj prezentację z określonej ścieżki pliku.
using var presentation = new Presentation("sample.pptx");

// Wyeksportuj prezentację w formacie HTML.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```