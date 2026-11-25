---
title: Przerwanie długotrwałych operacji prezentacji w Javie
linktitle: Przerwij operacje prezentacji
type: docs
weight: 120
url: /pl/java/support-for-interruptable-library/
keywords:
- operacje przerwalne
- token przerwania
- token anulowania
- zadanie długotrwałe
- przerwanie zadania
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak anulować długotrwałe operacje prezentacji w Aspose.Slides for Java i zwrócić częściowy wynik podczas eksportowania slajdów w pętli."
---
## **Przegląd**

Aspose.Slides for Java może przerywać długotrwałe operacje, takie jak ładowanie, zapisywanie i renderowanie prezentacji. Twoja aplikacja może używać tego samego tokena przerwania, aby zatrzymać pętlę przed rozpoczęciem przetwarzania kolejnego slajdu.

## **Przerwanie operacji prezentacji**

Utwórz [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/), pobierz jego token za pomocą [getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--), i przekaż token do [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Przekaż opcje ładowania do [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Aby żądać anulowania, wywołaj [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) na źródle. Operacja, którą można przerwać, zatrzymuje się, gdy zauważy żądanie.

Przykład konwertuje `sample.pptx` do `sample.ppt` w wątku w tle. Wątek wywołujący czeka do 10 sekund na zakończenie konwersji. Jeśli konwersja nadal działa, żąda anulowania i czeka, aż wątek zakończy działanie.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;

InterruptionTokenSource source = new InterruptionTokenSource();
Thread worker = new Thread(() -> {
    LoadOptions options = new LoadOptions();
    options.setInterruptionToken(source.getToken());
    try {
        Presentation presentation = new Presentation("sample.pptx", options);
        try {
            presentation.save("sample.ppt", SaveFormat.Ppt);
        } finally {
            presentation.dispose();
        }
    } catch (OperationCanceledException canceled) {
        System.out.println("Conversion canceled");
    }
});

worker.start();
worker.join(10000);
if (worker.isAlive()) {
    source.interrupt();
    worker.join();
}
```

## **Połączenie limitu czasu Java z Aspose.Slides**

Aby ustawić limit czasu dla operacji prezentacji, użyj [ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html), aby wywołać [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) po upłynięciu limitu czasu. Przykład daje 20 sekund na załadowanie `sample.pptx` i wyeksportowanie go do `sample.pdf`. Jeśli eksport zakończy się wcześniej, aplikacja anuluje zaplanowane żądanie.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;

InterruptionTokenSource source = new InterruptionTokenSource();
LoadOptions options = new LoadOptions();
options.setInterruptionToken(source.getToken());

ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
try {
    Presentation presentation = new Presentation("sample.pptx", options);
    try {
        presentation.save("sample.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
    }
} catch (OperationCanceledException canceled) {
    System.out.println("Presentation processing was canceled");
} finally {
    timeout.cancel(false);
    timer.shutdown();
}
```

## **Zatrzymaj przed przetworzeniem kolejnego slajdu**

Użyj tego samego [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/) dla prezentacji i pętli eksportującej jej slajdy. Sprawdź [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) przed każdym eksportem. Jeśli wywołujący może użyć częściowego wyniku, zwróć numery slajdów dla eksportów, które zakończyły się pomyślnie.

Użyj prezentacji o nazwie `sample.pptx` zawierającej co najmniej dwa slajdy. Przeciążenie [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-) przyjmujące tablicę numerów slajdów liczy od 1. Przykład zapisuje każdy slajd do osobnego pliku PDF i żąda anulowania zaraz po zapisaniu pierwszego udanego eksportu.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;

class SlideExporter {
    List<Integer> exportSlides(String path, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        Presentation presentation = new Presentation(path, options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    presentation.save("slide-" + number + ".pdf", new int[] { number }, SaveFormat.Pdf);
                } catch (OperationCanceledException canceled) {
                    if (token.isInterruptionRequested()) {
                        break;
                    }
                    throw canceled;
                }

                completed.add(number);
                if (number == 1) {
                    source.interrupt();
                }
            }
            return completed;
        } finally {
            presentation.dispose();
        }
    }
}

InterruptionTokenSource source = new InterruptionTokenSource();
SlideExporter exporter = new SlideExporter();
List<Integer> completed = exporter.exportSlides("sample.pptx", source);
System.out.println("Completed: " + completed);
```

Przykład zapisuje `slide-1.pdf` i wypisuje `Starting slide 1`, po czym `Completed: [1]`. Pętla zauważa żądanie przed rozpoczęciem slajdu 2. Jeśli anulowanie przyjdzie w trakcie zapisu, pętla kończy się, zanim oznaczy ten slajd jako zakończony.

Jeśli wywołujący musi obsłużyć anulowanie, zastąp sprawdzenie i jego `break` na początku pętli wywołaniem `token.throwIfInterruptionRequested()`. Usuń `try`/`catch` wokół zapisu, aby anulowanie podczas eksportu również dotarło do wywołującego. Przy tym samym wejściu przykład wypisuje tylko `Starting slide 1` i zapisuje `slide-1.pdf`. Na początku drugiej iteracji [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) rzuca `com.aspose.slides.exceptions.OperationCanceledException` przed rozpoczęciem kolejnego eksportu. Metoda nie zwraca żadnej listy.

## **FAQ**

**Kiedy powinienem żądać anulowania?**

Żądaj anulowania, gdy operacja przekracza ustalony limit czasu lub gdy Twoja aplikacja nie potrzebuje już wyniku.

**Jaka jest różnica między [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

Źródło umożliwia Twojej aplikacji żądanie anulowania. Token umożliwia Aspose.Slides oraz Twojej aplikacji sprawdzanie tego żądania.

**Czy mogę anulować operację z timera w Javie?**

Tak. Zaplanuj wywołanie [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) na źródle powiązanym z prezentacją.

**Jakie operacje mogę przerwać?**

Możesz przerwać ładowanie, zapisywanie i renderowanie. Przekaż token do [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) za pomocą [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Prezentacja może wtedy zauważyć anulowanie podczas kolejnych operacji, takich jak zapisywanie do PDF.

**Czy operacja zatrzymuje się natychmiast?**

Anulowanie jest współpracujące. Operacja okresowo sprawdza token i zatrzymuje się, gdy zauważy żądanie.

**Co się stanie, jeśli wywołam [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) po zakończeniu operacji?**

Zakończona operacja zachowuje swój wynik.

**Czy wiele operacji może współdzielić [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

Tak. Wywołanie [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) żąda anulowania dla każdej operacji, która używa tokena z tego źródła. Użyj oddzielnego źródła dla każdej operacji, którą chcesz anulować niezależnie.