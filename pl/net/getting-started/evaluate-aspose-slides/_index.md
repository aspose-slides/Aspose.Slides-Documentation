---
title: Ocena Aspose.Slides
type: docs
weight: 120
url: /pl/net/evaluate-aspose-slides/
keywords:
- ocena Aspose.Slides
- ocena Aspose.Slides
- wersja oceny
- pełna funkcjonalność
- znak wodny oceny
- zakup Aspose.Slides
- ograniczenie
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Oceń Aspose.Slides dla .NET i odkryj funkcje API dla prezentacji PowerPoint (PPT, PPTX) oraz OpenDocument (ODP) — rozpocznij bezpłatny okres próbny."
---
## **Ocena Aspose.Slides**

Możesz pobrać Aspose.Slides do oceny. Pakiet oceny jest identyczny z pakietem zakupionym; po dodaniu kilku linii kodu do zastosowania licencji staje się licencjonowany.

Bez licencji Aspose.Slides udostępnia pełną funkcjonalność w trybie oceny, z dwoma ograniczeniami: dodaje pole tekstowe z wodnym znakiem oceny do każdego slajdu każdej prezentacji, którą zapisuje, oraz tekst odczytywany z prezentacji jest przycinany do kilku pierwszych znaków, po których pojawia się informacja o ograniczeniu oceny. Tekst zapisywany przez kod jest zachowywany w całości.

![Slajd z wodnym znakiem oceny](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Uwaga" %}}
Jeśli chcesz przetestować Aspose.Slides bez ograniczeń wersji oceny, możesz poprosić o **30‑dniową Licencję Tymczasową**. Szczegóły znajdziesz w artykule [Jak uzyskać tymczasową licencję?](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Zainstaluj pakiet oceny**

```bash
dotnet add package Aspose.Slides.NET
```

W systemach Linux i macOS możesz zamiast tego użyć pakietu Aspose.Slides.NET6.CrossPlatform; zobacz [Instalacja](/slides/pl/net/installation/).

## **Zastosuj licencję**

To są „kilka linii kodu”, które zamieniają pakiet oceny w licencjonowany. Zastosuj licencję raz przy starcie aplikacji, przed utworzeniem jakiegokolwiek obiektu `Presentation` — prezentacja utworzona wcześniej zachowuje wodny znak oceny.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` przyjmuje także `Stream`, co jest lepszą opcją, gdy licencja jest dostarczana jako zasób osadzony, a nie jako plik na dysku. Jeśli ścieżka jest nieprawidłowa lub plik wygasł, wywołanie zgłasza wyjątek, więc problemy pojawiają się od razu przy starcie, a nie cicho przełączają się w tryb oceny.

Po zastosowaniu licencji zapisane prezentacje nie zawierają już wodnego znaku, a tekst jest odczytywany w pełni.

## **FAQ**

### Czy mogę testować wiele prezentacji równolegle w różnych wątkach w trybie oceny?

Tak. Możesz przetwarzać różne dokumenty równolegle; nie należy udostępniać tego samego obiektu prezentacji [między wątkami](/slides/pl/net/multithreading/). Tryb oceny nie ma wpływu na to.

### Czy muszę instalować Microsoft PowerPoint, aby ocenić bibliotekę na serwerze lub w CI?

Nie. Aspose.Slides jest samodzielnym silnikiem i nie wymaga zainstalowanego PowerPointa, zarówno w trybie oceny, jak i produkcji.

### Czy mogę w pełni przetestować konwersję PPT/PPTX do PDF i obrazów w trybie oceny?

Tak. [Konwertery](/slides/pl/net/convert-presentation/) działają; wynik będzie zawierał wodny znak.

### Czy mogę używać licencji tymczasowej do testów obciążeniowych bez wodnego znaku?

Tak. 30‑dniowa licencja tymczasowa usuwa ograniczenia trybu oceny i pozwala na testy bez wodnego znaku.