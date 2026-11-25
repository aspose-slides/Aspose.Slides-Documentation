---
title: Przerywanie długotrwałych operacji prezentacji w Pythonie
linktitle: Przerwij operacje prezentacji
type: docs
weight: 150
url: /pl/python-net/support-for-interruptable-library/
keywords:
- operacje podlegające przerwaniu
- token przerwania
- anulowanie eksportu PDF
- PowerPoint
- Python
- Aspose.Slides
description: "Dowiedz się, jak anulować konwersję prezentacji w Pythonie i zwrócić listę slajdów, które zakończyły eksport przed anulowaniem."
---
## **Przegląd**

Aspose.Slides for Python via .NET obsługuje współpracujące anulowanie podczas długotrwałych operacji, takich jak ładowanie, zapisywanie i renderowanie prezentacji. Podczas eksportowania slajdów pojedynczo można również sprawdzać anulowanie pomiędzy slajdami i zwrócić numery slajdów, które zakończyły eksport.

## **Anulowanie konwersji prezentacji**

Utwórz [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/), przypisz jego [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/) do [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/), i przekaż opcje do [konstruktora Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/). Token obowiązuje w całej prezentacji przez cały jej okres życia. Aby zgłosić anulowanie z aplikacji, wywołaj [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/).

Przykład konwertuje `sample.pptx` na `sample.pdf`. [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) wywołuje `source.interrupt` po 20 sekundach. Rozpoczęcie timera przed otwarciem pliku powoduje, że limit czasu obowiązuje zarówno przy ładowaniu, jak i zapisywaniu. Aplikacja z przyciskiem Cancel może wywołać tę samą metodę z obsługi zdarzenia.

```python
from threading import Timer

import aspose.slides as slides

source = slides.InterruptionTokenSource()
options = slides.LoadOptions()
options.interruption_token = source.token
timer = Timer(20, source.interrupt)

timer.start()
try:
    with slides.Presentation("sample.pptx", options) as presentation:
        options.interruption_token.throw_if_interruption_requested()
        presentation.save("sample.pdf", slides.export.SaveFormat.PDF)
finally:
    timer.cancel()
    timer.join()
```

Jawne sprawdzenie po załadowaniu pomija eksport, jeśli limit czasu już upłynął. Jeśli ładowanie lub zapisywanie zauważy żądanie, wyjątek anulowania dociera do wywołującego. Zapis może również zakończyć się przed zauważeniem żądania, w takim wypadku PDF jest kompletny.

## **Zatrzymaj przed przetworzeniem następnego slajdu**

Sprawdź [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) przed każdym eksportem. [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) przyjmuje listę numerów slajdów zaczynając od 1. Dodaj numer do listy zakończonych dopiero po pomyślnym zapisaniu jego PDF.

Użyj pliku o nazwie `sample.pptx` z co najmniej dwoma slajdami. Aby uzyskać powtarzalny wynik, przykład żąda anulowania zaraz po zakończeniu slajdu 1. W aplikacji żądanie może pochodzić z innego wątku podczas zapisywania slajdu.

```python
import aspose.slides as slides


def export_slides(path, source):
    completed = []
    token = source.token
    options = slides.LoadOptions()
    options.interruption_token = token

    with slides.Presentation(path, options) as presentation:
        for number in range(1, len(presentation.slides) + 1):
            if token.is_interruption_requested:
                break

            print(f"Starting slide {number}")
            try:
                presentation.save(f"slide-{number}.pdf", [number], slides.export.SaveFormat.PDF)
            except slides.AsposeSlidesException as error:
                if token.is_interruption_requested and "System.OperationCanceledException" in str(error):
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()

    return completed


source = slides.InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

Przykład zapisuje `slide-1.pdf` i wypisuje `Starting slide 1`, a następnie `Completed: [1]`. Następna iteracja widzi żądanie przed rozpoczęciem slajdu 2. Jeśli anulowanie przerwie zapis, obsługa wyjątku zwraca numery zarejestrowane w poprzednich iteracjach. Inne błędy eksportu docierają do wywołującego.

Jeśli wywołujący ma obsługiwać anulowanie jako wyjątek, zamień sprawdzenie i jego `break` na początku pętli na [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/). Usuń także blok `try`/`except` wokół zapisu. Przy tym samym wejściu slajd 1 zostaje zapisany, a druga iteracja zgłasza wyjątek anulowania przed rozpoczęciem slajdu 2.

## **FAQ**

**Kiedy żądanie anulowania zaczyna obowiązywać?**

Operacja podlegająca przerwaniu sprawdza swój token okresowo. Zatrzymuje się, gdy zauważy żądanie. Operacja, która już się zakończyła, zachowuje swój wynik.

**Jaka jest różnica między źródłem a tokenem?**

Źródło pozwala aplikacji żądać anulowania. Token umożliwia zarówno prezentacji, jak i własnemu kodowi sprawdzanie tego żądania.

**Czy kilka operacji może współdzielić to samo źródło?**

Tak. Wywołanie `interrupt` żąda anulowania dla każdej operacji używającej tokenu z tego źródła. Przydziel każdej operacji własne źródło, jeśli potrzebujesz anulować je niezależnie.