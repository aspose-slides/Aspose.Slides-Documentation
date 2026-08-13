---
title: Ocena Aspose.Slides
type: docs
weight: 120
url: /pl/net/evaluate-aspose-slides/
keywords:
- ocena Aspose.Slides
- ewaluacja Aspose.Slides
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

Możesz łatwo pobrać Aspose.Slides do oceny. Pakiet oceny jest taki sam jak zakupiony pakiet. Wersja oceny po prostu staje się licencjonowana po dodaniu kilku linii kodu, aby zastosować licencję. 

Wersja oceny Aspose.Slides (bez określonej licencji) zapewnia pełną funkcjonalność produktu, ale wstawia znak wodny oceny u góry dokumentu podczas otwierania i zapisywania. Masz także ograniczenie do jednego slajdu podczas wyodrębniania tekstu z slajdów prezentacji.


![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="info" %}} 

Jeśli chcesz testować Aspose.Slides bez ograniczeń wersji oceny, możesz poprosić o **30‑dniową tymczasową licencję**. Zapoznaj się z [Jak uzyskać tymczasową licencję?](https://purchase.aspose.com/temporary-license) po więcej informacji.

{{% /alert %}}

## **Zainstaluj pakiet oceny**

```bash
dotnet add package Aspose.Slides.NET
```

## **Zastosuj licencję**

To są „kilka linii kodu”, które przekształcają pakiet oceny w licencjonowany. Zastosuj licencję raz przy uruchamianiu aplikacji, przed utworzeniem jakiegokolwiek obiektu `Presentation` — prezentacja utworzona wcześniej zachowuje znak wodny oceny.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` akceptuje również `Stream`, co jest lepszą opcją, gdy licencja jest dostarczana jako zasób osadzony, a nie jako plik na dysku. Jeśli ścieżka jest nieprawidłowa lub plik wygasł, wywołanie rzuca wyjątek, więc błędy pojawiają się od razu przy uruchamianiu zamiast cicho przechodzić w tryb oceny.

Po zastosowaniu licencji znak wodny znika, a ograniczenie do jednego slajdu przy wyodrębnianiu tekstu zostaje zniesione.

## **FAQ**

### Czy mogę testować wiele prezentacji równolegle w różnych wątkach w trybie oceny?

Tak. Możesz przetwarzać różne dokumenty równolegle; nie powinieneś udostępniać tego samego obiektu prezentacji [między wątkami](/slides/pl/net/multithreading/). Tryb oceny nie ma na to wpływu.

### Czy muszę instalować Microsoft PowerPoint, aby ocenić bibliotekę na serwerze lub w CI?

Nie. Aspose.Slides jest samodzielnym silnikiem i nie wymaga instalacji PowerPoint zarówno w trybie oceny, jak i w produkcji.

### Czy mogę w pełni testować konwersję PPT/PPTX do PDF i obrazów w trybie oceny?

Tak. [Konwertery](/slides/pl/net/convert-presentation/) działają; wynik będzie zawierał znak wodny.

### Czy mogę używać tymczasowej licencji do testów obciążeniowych bez znaku wodnego?

Tak. 30‑dniowa tymczasowa licencja usuwa ograniczenia trybu oceny i pozwala na testy bez znaku wodnego.