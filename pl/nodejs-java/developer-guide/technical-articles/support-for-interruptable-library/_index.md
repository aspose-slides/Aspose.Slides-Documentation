---
title: Przerwanie długotrwałych operacji na prezentacji w Node.js
linktitle: Przerwij operacje na prezentacji
type: docs
weight: 120
url: /pl/nodejs-java/support-for-interruptable-library/
keywords:
- operacje możliwe do przerwania
- token przerwania
- token anulowania
- limit czasu konwersji
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Anuluj długotrwałe operacje na prezentacji w Aspose.Slides dla Node.js poprzez Java, ustaw limit czasu konwersji i śledź slajdy wyeksportowane przed anulowaniem."
---
## **Przegląd**

Aspose.Slides for Node.js via Java obsługuje anulowanie podczas ładowania, zapisywania lub renderowania prezentacji. Możesz również sprawdzić ten sam token w własnej pętli eksportu, aby zatrzymać się przed następnym slajdem i zwrócić numery już zapisanych slajdów.

## **Przerwanie operacji na prezentacji**

Utwórz [InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/), uzyskaj jego token za pomocą [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken) i przekaż go do [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken). Użyj tych opcji przy tworzeniu obiektu [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Wywołanie [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) na źródle żąda anulowania bieżącej operacji. Aspose.Slides zatrzymuje się, gdy następnym razem sprawdzi token.

### **Ustaw limit czasu konwersji**

Poniższy przykład pozwala na 20 sekund na otwarcie `sample.pptx` i zapisanie go jako `sample.pdf`. Zarówno konstruktor, jak i zapis są wykonywane asynchronicznie przez most Java, dzięki czemu timer Node.js może zostać uruchomiony podczas którejkolwiek operacji. Przykład sprawdza token po załadowaniu i ponownie po zapisaniu, ponieważ wywołanie biblioteki może zwrócić się po żądaniu anulowania. Zwalnia prezentację, gdy operacja się zakończy, i usuwa timer, jeśli konwersja zakończy się wcześniej. Jeśli anulowanie nastąpi podczas zapisu, plik wyjściowy może już istnieć i może być niekompletny.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const { promisify } = require("node:util");

async function convertWithTimeout(inputPath, outputPath, format, timeoutMs) {
    const source = new slides.InterruptionTokenSource();
    const options = new slides.LoadOptions();
    const token = source.getToken();
    options.setInterruptionToken(token);
    const createInstance = promisify(java.newInstance.bind(java));
    const timer = setTimeout(() => source.interrupt(), timeoutMs);
    let presentation = null;
    try {
        presentation = await createInstance("com.aspose.slides.Presentation", inputPath, options);
        token.throwIfInterruptionRequested();
        const save = promisify(presentation.saveAsync.bind(presentation));
        await save(outputPath, format);
        token.throwIfInterruptionRequested();
        console.log("Conversion completed");
    } catch (error) {
        if (error.cause?.getClass().getName() !== "com.aspose.slides.exceptions.OperationCanceledException") {
            throw error;
        }
        console.log("Conversion canceled");
    } finally {
        clearTimeout(timer);
        if (presentation) {
            presentation.dispose();
        }
    }
}

convertWithTimeout("sample.pptx", "sample.pdf", slides.SaveFormat.Pdf, 20000).catch(error => {
    console.error(error);
    process.exitCode = 1;
});
```

Aby skonwertować do starszego formatu PowerPoint z limitem 10 sekund, przekaż `"sample.ppt"`, `slides.SaveFormat.Ppt` i `10000` jako ostatnie trzy argumenty.

## **Zatrzymaj przed przetworzeniem kolejnego slajdu**

Użyj [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) przed każdym eksportem, gdy wywołujący może skorzystać z częściowego wyniku. Przeciążenie [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) dla wybranych slajdów przyjmuje tablicę Java `int[]` numerów slajdów zaczynając od 1. Zapisuj każdy numer dopiero po pomyślnym zapisaniu jego PDF.

Uruchom przykład z prezentacją o nazwie `sample.pptx` zawierającą co najmniej dwa slajdy. Aby zademonstrować anulowanie pomiędzy eksportami, przykład żąda go natychmiast po zapisaniu pierwszego slajdu.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function exportSlides(path, source) {
    const completed = [];
    const token = source.getToken();
    const options = new slides.LoadOptions();
    options.setInterruptionToken(token);
    const presentation = new slides.Presentation(path, options);
    try {
        const count = presentation.getSlides().size();
        for (let number = 1; number <= count; number++) {
            if (token.isInterruptionRequested()) {
                break;
            }

            console.log("Starting slide " + number);
            const selection = java.newArray("int", [number]);
            try {
                presentation.save("slide-" + number + ".pdf", selection, slides.SaveFormat.Pdf);
            } catch (error) {
                if (error.cause?.getClass().getName() === "com.aspose.slides.exceptions.OperationCanceledException") {
                    break;
                }
                throw error;
            }

            if (token.isInterruptionRequested()) {
                break;
            }
            completed.push(number);
            if (number === 1) {
                source.interrupt();
            }
        }
        return completed;
    } finally {
        presentation.dispose();
    }
}

const source = new slides.InterruptionTokenSource();
const completed = exportSlides("sample.pptx", source);
console.log("Completed: " + JSON.stringify(completed));
```

Przykład zapisuje `slide-1.pdf` i wyświetla `Starting slide 1`, po czym `Completed: [1]`. Pętla zauważa anulowanie przed rozpoczęciem slajdu 2. Jeśli sam zapis zostanie przerwany, zwrócona lista zawiera tylko wcześniejsze udane eksporty.

Aby umożliwić wywołującemu obsługę anulowania jako błędu, zamień sprawdzenie i jego `break` na początku pętli na [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested), wywołując je jako `token.throwIfInterruptionRequested()`. Użyj tego samego sprawdzenia po zapisie i usuń otaczający go `try`/`catch`. Przy tym samym wejściu pierwszy PDF nadal zostanie zapisany, a druga iteracja zgłosi wyjątek przed zwróceniem listy.

## **FAQ**

**Kiedy powinienem żądać anulowania?**

Żądaj anulowania, gdy upływa termin lub aplikacja nie potrzebuje już wyniku. Ładowanie, zapisywanie i renderowanie mogą wszystkie korzystać z tokenu przekazanego do prezentacji przy jej tworzeniu.

**Jak różnią się źródło i token?**

Źródło umożliwia aplikacji żądanie anulowania. Token pozwala Aspose.Slides oraz Twojemu własnemu kodowi sprawdzić to żądanie.

**Czy timer Node.js może przerwać synchroniczny zapis?**

Synchroniczny zapis blokuje JavaScript w wątku wywołującym. Użyj asynchronicznych wywołań mostu Java pokazanych w przykładzie z limitem czasu, aby timer mógł żądać anulowania w trakcie działania zapisu.

**Czy anulowanie działa natychmiast?**

Anulowanie jest współpracujące. Działająca operacja zatrzymuje się, gdy zauważy żądanie. Operacja, która już zakończyła się, zachowuje swój wynik.

**Czy wiele operacji może współdzielić źródło?**

Tak. Wywołanie `interrupt()` żąda anulowania dla każdej operacji korzystającej z tokenu tego źródła. Użyj oddzielnego źródła dla każdej operacji, którą chcesz anulować niezależnie.