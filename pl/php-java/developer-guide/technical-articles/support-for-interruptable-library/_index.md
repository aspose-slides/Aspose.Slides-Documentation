---
title: Przerwanie długotrwałych operacji prezentacji w PHP
linktitle: Przerwanie operacji prezentacji
type: docs
weight: 120
url: /pl/php-java/support-for-interruptable-library/
keywords:
- token przerwania
- anulowanie
- limit czasu konwersji
- eksport slajdów
- PowerPoint
- PHP
- Aspose.Slides
description: "Dowiedz się, jak anulować konwersję prezentacji przy użyciu timera i zwrócić slajdy wyeksportowane przed anulowaniem przy pomocy Aspose.Slides dla PHP przez Java."
---
## **Przegląd**

Aspose.Slides dla PHP przez Java może przerywać długotrwałe operacje, takie jak ładowanie, zapisywanie i renderowanie prezentacji. W pętli, która eksportuje jeden slajd na raz, ten sam token pozwala aplikacji zatrzymać się przed następnym slajdem i zwrócić listę zakończonych eksportów.

Oba przykłady PHP zakładają, że Twój plik rozruchowy wywołuje `define("JAVA_PREFER_VALUES", 1);` przed załadowaniem `Java.inc` mostu, a następnie ładuje `aspose.slides.php`. To ustawienie pozwala PHP przechwycić wyjątki Java podczas wywołania. Przykłady sprawdzają przyczynę opakowanego wyjątku, aby inne błędy konwersji dotarły do wywołującego.

## **Przerwanie operacji prezentacji**

Utwórz [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/), uzyskaj jego token za pomocą [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken) i przekaż go do [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken). Przekaż te opcje przy tworzeniu [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Wywołanie [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) żąda anulowania. Działająca operacja zatrzyma się, gdy zauważy to żądanie.

### **Ustaw limit czasu konwersji**

Podczas gdy PHP czeka na synchroniczne wczytanie lub zapis przez most PHP/Java, timer w Javie może żądać anulowania w osobnym wątku. Zapisz poniższego pomocnika jako `ConversionTimeout.java`, skompiluj go z biblioteką Aspose.Slides JAR w classpath i udostępnij skompilowaną klasę mostowi pod jej nazwą pakietu, `example.ConversionTimeout`.

```java
package example;

import com.aspose.slides.InterruptionTokenSource;
import java.util.Timer;
import java.util.TimerTask;

public class ConversionTimeout {
    public static Timer start(InterruptionTokenSource source, long milliseconds) {
        Timer timer = new Timer(true);
        timer.schedule(new TimerTask() {
            @Override
            public void run() {
                source.interrupt();
            }
        }, milliseconds);
        return timer;
    }
}
```

Po załadowaniu mostu i opakowania Aspose.Slides PHP, uruchom poniższy przykład z plikiem `sample.pptx` w katalogu roboczym procesu Java lub użyj ścieżek bezwzględnych dostępnych dla tego procesu. Limit 20 sekund obejmuje zarówno wczytywanie, jak i eksport do PDF. Jeśli konwersja zakończy się wcześniej, PHP anuluje timer. Aby przekonwertować do starszego formatu PowerPoint z limitem 10 sekund, użyj `sample.ppt`, `SaveFormat::Ppt` i `10000` milisekund.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new InterruptionTokenSource();
$token = $source->getToken();
$options = new LoadOptions();
$options->setInterruptionToken($token);
$timer = java("example.ConversionTimeout")->start($source, 20000);
try {
    $presentation = new Presentation("sample.pptx", $options);
    try {
        $token->throwIfInterruptionRequested();
        $presentation->save("sample.pdf", SaveFormat::Pdf);
        $token->throwIfInterruptionRequested();
        echo "Conversion completed\n";
    } finally {
        $presentation->dispose();
    }
} catch (JavaException $error) {
    if (!java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
        throw $error;
    }
    echo "Conversion canceled\n";
} finally {
    $timer->cancel();
}
```

## **Zatrzymaj przed przetwarzaniem następnego slajdu**

Sprawdzaj [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested) przed każdym eksportem. Przeciążenie [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) dla wybranych slajdów przyjmuje numery slajdów zaczynające się od 1. Przekaż jednowymiarową tablicę, aby zapisać osobny PDF dla każdego slajdu.

Użyj pliku `sample.pptx` zawierającego co najmniej dwa slajdy. Aby zademonstrować anulowanie między eksportami, przykład żąda go natychmiast po zapisaniu pierwszego slajdu.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function exportSlides($path, $source) {
    $completed = [];
    $token = $source->getToken();
    $options = new LoadOptions();
    $options->setInterruptionToken($token);
    $presentation = new Presentation($path, $options);
    try {
        $count = java_values($presentation->getSlides()->size());
        for ($number = 1; $number <= $count; $number++) {
            if (java_values($token->isInterruptionRequested())) {
                break;
            }

            try {
                $presentation->save("slide-$number.pdf", [$number], SaveFormat::Pdf);
                $token->throwIfInterruptionRequested();
            } catch (JavaException $error) {
                if (java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
                    break;
                }
                throw $error;
            }

            $completed[] = $number;
            if ($number === 1) {
                $source->interrupt();
            }
        }
        return $completed;
    } finally {
        $presentation->dispose();
    }
}

$source = new InterruptionTokenSource();
$completed = exportSlides("sample.pptx", $source);
echo "Completed: " . json_encode($completed) . "\n";
```

Przykład zapisuje `slide-1.pdf` i wypisuje `Completed: [1]`. Druga iteracja zauważa żądanie przed rozpoczęciem kolejnego eksportu. Jeśli anulowanie nastąpi podczas zapisu, lista zawiera tylko wcześniej potwierdzone eksporty. Przerwany zapis może pozostawić niekompletny plik na dysku.

Aby przekazać anulowanie wywołującemu, zastąp sprawdzenie na początku pętli wywołaniem `$token->throwIfInterruptionRequested();` i usuń wewnętrzny `try`/`catch`, pozostawiając zapis i sprawdzenie po nim. Przy tym samym wejściu, [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) podnosi wyjątek przed slajdem 2 i wywołujący nie otrzymuje listy.

## **FAQ**

**Kiedy powinienem żądać anulowania?**

Żądaj anulowania, gdy upłynie termin lub wywołujący nie potrzebuje już wyniku. Żądanie złożone po zakończeniu operacji pozostawia jej rezultat nienaruszony.

**Jak różnią się źródło i token?**

Źródło pozwala aplikacji żądać anulowania. Token pozwala Aspose.Slides i kodowi aplikacji obserwować to żądanie.

**Czy wiele operacji może współdzielić źródło?**

Tak. Żądanie dotyczy wszystkich operacji używających tokenów z tego źródła. Twórz oddzielne źródła dla operacji, które wymagają niezależnego anulowania.