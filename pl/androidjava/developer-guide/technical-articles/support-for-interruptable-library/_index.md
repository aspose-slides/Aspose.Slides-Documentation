---
title: Przerywanie długotrwałych operacji prezentacji na Androidzie
linktitle: Przerwij operacje prezentacji
type: docs
weight: 120
url: /pl/androidjava/support-for-interruptable-library/
keywords:
- przerwalne operacje
- token przerwania
- token anulowania
- zadanie długotrwałe
- przerwanie zadania
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak anulować długotrwałe operacje prezentacji w Aspose.Slides dla Androida za pomocą Javy oraz zwrócić częściowy wynik podczas eksportowania slajdów w pętli."
---
## **Przegląd**

Aspose.Slides for Android za pośrednictwem Javy może przerywać długotrwałe operacje, takie jak ładowanie, zapisywanie i renderowanie prezentacji. Twoja aplikacja może używać tego samego tokena przerwania, aby zatrzymać pętlę przed rozpoczęciem przetwarzania kolejnego slajdu.

## **Przerwanie operacji prezentacji**

Utwórz [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/), uzyskaj jego token za pomocą [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--), i przekaż token do [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Przekaż opcje ładowania do [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Aby zażądać anulowania, wywołaj [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) na źródle. Przerwana operacja zatrzymuje się, gdy zauważy żądanie.

Przykład konwertuje `sample.pptx` na `sample.ppt` w tle. Wątek wywołujący czeka do 10 sekund na zakończenie konwersji. Jeśli konwersja nadal trwa, żąda anulowania i czeka na zakończenie wątku roboczego.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
    // Wywołaj z wątku w tle i przekaż context.getFilesDir(), który zawiera sample.pptx.
    public static void run(File directory) throws InterruptedException {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.ppt");
        InterruptionTokenSource source = new InterruptionTokenSource();
        Thread worker = new Thread(() -> {
            LoadOptions options = new LoadOptions();
            options.setInterruptionToken(source.getToken());
            try {
                Presentation presentation = new Presentation(input.getAbsolutePath(), options);
                try {
                    presentation.save(output.getAbsolutePath(), SaveFormat.Ppt);
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
    }
}
```

## **Połącz limit czasu w Javie z Aspose.Slides**

Aby ustawić limit czasu dla operacji na prezentacji, użyj [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService) aby wywołać [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) po upływie limitu czasu. Przykład pozwala na 20 sekund na załadowanie `sample.pptx` i wyeksportowanie go do `sample.pdf`. Jeśli eksport zakończy się wcześniej, aplikacja anuluje zaplanowane żądanie.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // Wywołaj z wątku w tle i przekaż context.getFilesDir(), który zawiera sample.pptx.
    public static void run(File directory) {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.pdf");
        InterruptionTokenSource source = new InterruptionTokenSource();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(source.getToken());

        ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
        ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
        try {
            Presentation presentation = new Presentation(input.getAbsolutePath(), options);
            try {
                presentation.save(output.getAbsolutePath(), SaveFormat.Pdf);
            } finally {
                presentation.dispose();
            }
        } catch (OperationCanceledException canceled) {
            System.out.println("Presentation processing was canceled");
        } finally {
            timeout.cancel(false);
            timer.shutdown();
        }
    }
}
```

## **Zatrzymaj przed przetworzeniem następnego slajdu**

Użyj tego samego [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/) dla prezentacji i pętli eksportującej jej slajdy. Sprawdzaj [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) przed każdym eksportem. Jeśli wywołujący może używać częściowego wyniku, zwróć numery slajdów dla eksportów zakończonych pomyślnie.

Użyj prezentacji o nazwie `sample.pptx` zawierającej co najmniej dwa slajdy. Przeciążenie [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-) przyjmujące tablicę numerów slajdów liczy od 1. Przykład zapisuje każdy slajd do osobnego pliku PDF i żąda anulowania natychmiast po zapisaniu pierwszego udanego eksportu.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;
import java.io.File;

public class SlideExporter {
    private static List<Integer> exportSlides(File directory, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        File input = new File(directory, "sample.pptx");
        Presentation presentation = new Presentation(input.getAbsolutePath(), options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    File output = new File(directory, "slide-" + number + ".pdf");
                    presentation.save(output.getAbsolutePath(), new int[] { number }, SaveFormat.Pdf);
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

    // Wywołaj z wątku w tle i przekaż context.getFilesDir(), który zawiera sample.pptx.
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```

Przykład zapisuje `slide-1.pdf` i wypisuje `Starting slide 1`, a następnie `Completed: [1]`. Pętla zauważa żądanie przed rozpoczęciem slajdu 2. Jeśli anulowanie nastąpi w trakcie zapisu, pętla kończy się przed oznaczeniem tego slajdu jako ukończonego.

Jeśli wywołujący musi obsłużyć anulowanie, zastąp kontrolę i jej `break` na początku pętli wywołaniem `token.throwIfInterruptionRequested()`. Usuń blok `try`/`catch` wokół zapisu, aby anulowanie podczas eksportu również dotarło do wywołującego. Przy tych samych danych wejściowych przykład wypisuje tylko `Starting slide 1` i zapisuje `slide-1.pdf`. Na początku drugiej iteracji, [throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) rzuca `com.aspose.slides.exceptions.OperationCanceledException` przed rozpoczęciem kolejnego eksportu. Metoda nie zwraca żadnej listy.

## **FAQ**

**Kiedy powinienem zażądać anulowania?**

Zażądaj anulowania, gdy operacja przekracza Twój limit czasu lub gdy aplikacja nie potrzebuje już wyniku.

**Jaka jest różnica między [InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

Źródło pozwala aplikacji zażądać anulowania. Token umożliwia Aspose.Slides oraz Twojej aplikacji sprawdzanie tego żądania.

**Czy mogę anulować operację z timera w Javie?**

Tak. Zaplanuj wywołanie [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) na źródle powiązanym z prezentacją.

**Jakie operacje mogę przerwać?**

Możesz przerwać ładowanie, zapisywanie i renderowanie. Przekaż token do [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) przez [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Prezentacja może wtedy wykrywać anulowanie podczas kolejnych operacji, takich jak zapisywanie do PDF.

**Czy operacja zatrzymuje się natychmiast?**

Anulowanie jest współpracujące. Operacja okresowo sprawdza token i zatrzymuje się, gdy wykryje żądanie.

**Co się stanie, jeśli wywołam [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) po zakończeniu operacji?**

Zakończona operacja zachowuje swój wynik.

**Czy wiele operacji może współdzielić [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

Tak. Wywołanie [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) żąda anulowania dla każdej operacji używającej tokenu z tego źródła. Użyj osobnego źródła dla każdej operacji, którą chcesz anulować niezależnie.