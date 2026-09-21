---
title: Edytuj dokumenty PDF w .NET
linktitle: Edytuj PDF
type: docs
weight: 65
url: /pl/net/edit-pdf/
keywords:
- edytuj PDF
- zastąp tekst PDF
- PDF do PPTX
- PPTX do PDF
- .NET
- C#
- Aspose.Slides
description: "Edytuj dokumenty PDF w C# poprzez importowanie ich do Aspose.Slides, zastępowanie tekstu i zapisywanie zmodyfikowanej prezentacji z powrotem do PDF."
---
## **Przegląd**

Aspose.Slides for .NET umożliwia edytowanie treści PDF poprzez importowanie jego stron jako slajdów, modyfikowanie prezentacji i eksportowanie jej z powrotem do PDF. Ten artykuł pokazuje proste zastąpienie tekstu. Prezentacja pozostaje w pamięci, więc zapisanie pośredniego pliku PPTX jest opcjonalne.

## **Zastąpienie tekstu w PDF**

Użyj [AddFromPdf](https://reference.aspose.com/slides/pl/net/aspose.slides/slidecollection/addfrompdf/) do zaimportowania stron, [ReplaceText](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/replacetext/) do zaktualizowania tekstu oraz [Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/) do wyeksportowania wyniku.

Poniższy przykład zakłada, że `input.pdf` zawiera słowo „Draft” jako edytowalny tekst po imporcie. Zastępuje to słowo na „Final” i zapisuje `edited.pdf`. Usunięcie początkowego slajdu przed importem zapobiega dodatkowej pustej stronie w wyniku. Wyszukiwanie dopasowuje całe wyrazy z uwzględnieniem wielkości liter; `null` oznacza, że nie jest potrzebna funkcja zwrotna wyniku.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

Aby uzyskać więcej opcji, zobacz [Wyszukiwanie i zamiana tekstu](/slides/pl/net/search-and-replace-text/) oraz [Konwertowanie PowerPoint do PDF](/slides/pl/net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Zastąpienie tekstu działa na zaimportowanym tekście, a nie na tekście znajdującym się w zeskanowanych obrazach. Konwersja może wpływać na układ i formatowanie, dlatego warto sprawdzić wynik, szczególnie gdy tekst zastępczy jest dłuższy niż oryginalny.
{{% /alert %}}

## **FAQ**

**Czy muszę zapisać plik PPTX przed eksportowaniem do PDF?**

Nie. Możesz edytować i wyeksportować tę samą prezentację w pamięci. Zapisz kopię PPTX tylko wtedy, gdy chcesz kontynuować jej edycję w PowerPoint; zobacz [Save Presentations](/slides/pl/net/save-presentation/).

**Dlaczego niektóre fragmenty tekstu mogą pozostać niezmienione?**

Przykład dopasowuje całe słowo „Draft” z dokładnym uwzględnieniem wielkości liter. Tekst zaimportowany jako obraz lub podzielony na oddzielne ramki tekstowe niekoniecznie zostanie dopasowany. Sprawdź zaimportowaną zawartość i dostosuj wyszukiwanie do swojego dokumentu.