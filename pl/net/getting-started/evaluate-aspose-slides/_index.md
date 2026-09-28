---
title: Ewaluacja Aspose.Slides
type: docs
weight: 75
url: /pl/net/evaluate-aspose-slides/
keywords:
- testowanie Aspose.Slides
- ewaluacja Aspose.Slides
- wersja ewaluacyjna
- pełna funkcjonalność
- znak wodny ewaluacji
- zakup Aspose.Slides
- ograniczenie
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Ewaluuj Aspose.Slides dla .NET i poznaj funkcje API dla prezentacji PowerPoint (PPT, PPTX) oraz OpenDocument (ODP) — rozpocznij bezpłatny okres próbny."
---
## **Ewaluacja Aspose.Slides**

Możesz pobrać Aspose.Slides w wersji ewaluacyjnej. Pakiet ewaluacyjny jest taki sam jak zakupiony; staje się licencjonowany po dodaniu kilku wierszy kodu służących do zastosowania licencji.

Bez licencji Aspose.Slides udostępnia pełną funkcjonalność w trybie ewaluacyjnym, z dwoma ograniczeniami: dodaje pole tekstowe z napisem „evaluation watermark” do każdego slajdu każdej prezentacji, którą zapisuje, a tekst odczytywany z prezentacji przez Twój kod jest przycinany do kilku pierwszych znaków, po których pojawia się informacja o ograniczeniu ewaluacyjnym. Tekst zapisywany przez Twój kod jest zapisywany w całości.

![A slide with the evaluation watermark](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}

Jeśli chcesz przetestować Aspose.Slides bez ograniczeń wersji ewaluacyjnej, możesz zamówić **30‑dniową tymczasową licencję**. Więcej informacji znajdziesz w artykule [Jak uzyskać tymczasową licencję?](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Zainstaluj pakiet ewaluacyjny**

```bash
dotnet add package Aspose.Slides.NET
```

W systemach Linux i macOS możesz zamiast tego użyć pakietu Aspose.Slides.NET6.CrossPlatform; zobacz [Installation](/slides/pl/net/installation/).

## **Zastosuj licencję**

To są „kilka wierszy kodu”, które zamieniają pakiet ewaluacyjny w wersję licencjonowaną. Zastosuj licencję raz przy uruchamianiu aplikacji, przed utworzeniem jakiegokolwiek obiektu `Presentation` — prezentacja utworzona wcześniej nadal zachowuje znak wodny ewaluacji.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` przyjmuje także `Stream`, co jest lepszym rozwiązaniem, gdy licencja jest dostarczana jako zasób osadzony, a nie jako plik na dysku. Jeśli ścieżka jest nieprawidłowa lub plik wygasł, wywołanie zgłasza wyjątek, więc błędy są wykrywane od razu przy starcie, a nie cicho przełączają się w tryb ewaluacji.

Po zastosowaniu licencji zapisane prezentacje nie zawierają już znaku wodnego, a tekst jest odczytywany w całości.

## **FAQ**

### Czy mogę testować wiele prezentacji równolegle w różnych wątkach w trybie ewaluacyjnym?

Tak. Możesz przetwarzać różne dokumenty równolegle; nie powinieneś udostępniać tego samego obiektu prezentacji [across threads](/slides/pl/net/multithreading/). Tryb ewaluacji nie ma na to wpływu.

### Czy muszę instalować Microsoft PowerPoint, aby ocenić bibliotekę na serwerze lub w CI?

Nie. Aspose.Slides jest samodzielnym silnikiem i nie wymaga zainstalowanego PowerPointa zarówno w wersji ewaluacyjnej, jak i produkcyjnej.

### Czy mogę w pełni przetestować konwersję PPT/PPTX do PDF i obrazów w trybie ewaluacyjnym?

Tak. [Konwertery](/slides/pl/net/convert-presentation/) działają; wynik będzie zawierał znak wodny.

### Czy mogę użyć tymczasowej licencji do testów obciążeniowych bez znaku wodnego?

Tak. 30‑dniowa tymczasowa licencja usuwa ograniczenia trybu ewaluacji i pozwala testować bez znaku wodnego.