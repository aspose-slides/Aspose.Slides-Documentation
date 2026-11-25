---
title: Unterbrechen lang andauernder Präsentationsvorgänge in Node.js
linktitle: Präsentationsvorgänge unterbrechen
type: docs
weight: 120
url: /de/nodejs-java/support-for-interruptable-library/
keywords:
- unterbrechbare Vorgänge
- Unterbrechungstoken
- Abbruchtoken
- Konvertierungszeitüberschreitung
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Lang andauernde Präsentationsvorgänge in Aspose.Slides für Node.js via Java abbrechen, ein Konvertierungszeitlimit festlegen und nachverfolgen, welche Folien vor dem Abbruch exportiert wurden."
---
## **Überblick**

Aspose.Slides for Node.js via Java unterstützt das Abbrechen beim Laden, Speichern oder Rendern einer Präsentation. Sie können dasselbe Token auch in Ihrer eigenen Exportschleife prüfen, um vor der nächsten Folie zu stoppen und die Nummern der bereits gespeicherten Folien zurückzugeben.

## **Unterbrechung eines Präsentationsvorgangs**

Erstellen Sie ein [InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/), erhalten Sie dessen Token mit [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken) und übergeben Sie ihn an [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken). Verwenden Sie diese Optionen beim Erzeugen des [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Der Aufruf von [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) auf der Quelle fordert die Abbruch der aktuellen Operation an. Aspose.Slides stoppt, sobald es das Token das nächste Mal prüft.

### **Ein Konvertierungs-Timeout festlegen**

Das folgende Beispiel erlaubt 20 Sekunden, um `sample.pptx` zu öffnen und es als `sample.pdf` zu speichern. Sowohl der Konstruktor als auch das Speichern werden asynchron über die Java‑Bridge ausgeführt, sodass der Node.js‑Timer während beider Vorgänge auslösen kann. Das Beispiel prüft das Token nach dem Laden und erneut nach dem Speichern, da ein Bibliotheksaufruf nach einer Abbruchanforderung noch zurückkehren kann. Es gibt die Präsentation frei, wenn der Vorgang abgeschlossen ist, und löscht den Timer, falls die Konvertierung frühzeitig beendet wird. Wenn während des Speicherns ein Abbruch erfolgt, kann die Ausgabedatei bereits existieren und unvollständig sein.

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

Um in das ältere PowerPoint‑Format mit einem 10‑Sekunden‑Limit zu konvertieren, übergeben Sie `"sample.ppt"`, `slides.SaveFormat.Ppt` und `10000` als die letzten drei Argumente.

## **Vor der Verarbeitung der nächsten Folie stoppen**

Verwenden Sie [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) vor jedem Export, wenn der Aufrufer ein Teilergebnis nutzen kann. Der [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save)-Überladung für ausgewählte Folien erwartet ein Java `int[]` mit Foliennummern, beginnend bei 1. Protokollieren Sie jede Nummer nur, nachdem ihr PDF erfolgreich gespeichert wurde.

Führen Sie das Beispiel mit einer Präsentation namens `sample.pptx` aus, die mindestens zwei Folien enthält. Um das Abbrechen zwischen Exporten zu demonstrieren, fordert das Beispiel den Abbruch unmittelbar nach dem Speichern der ersten Folie an.

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

Das Beispiel schreibt `slide-1.pdf` und gibt `Starting slide 1` gefolgt von `Completed: [1]` aus. Die Schleife erkennt den Abbruch, bevor Folie 2 gestartet wird. Wird ein Speichervorgang selbst unterbrochen, enthält die zurückgegebene Liste nur die zuvor erfolgreich exportierten Folien.

Damit der Aufrufer den Abbruch als Fehler behandeln kann, ersetzen Sie die Prüfung und das `break` am Anfang der Schleife durch [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested), aufgerufen als `token.throwIfInterruptionRequested()`. Verwenden Sie dieselbe werfende Prüfung nach dem Speichern und entfernen Sie das `try`/`catch`‑Block darum. Mit denselben Eingaben wird das erste PDF weiterhin geschrieben, und die zweite Iteration wirft, bevor die Funktion eine Liste zurückgeben kann.

## **FAQ**

**Wann sollte ich einen Abbruch anfordern?**

Fordern Sie einen Abbruch an, wenn eine Frist abgelaufen ist oder die Anwendung das Ergebnis nicht mehr benötigt. Laden, Speichern und Rendern können alle das beim Erzeugen der Präsentation übergebene Token verwenden.

**Wie unterscheiden sich Quelle und Token?**

Die Quelle ermöglicht es der Anwendung, einen Abbruch anzufordern. Das Token ermöglicht es Aspose.Slides und Ihrem eigenen Code, diesen Antrag zu prüfen.

**Kann ein Node.js‑Timer ein synchrones Speichern unterbrechen?**

Ein synchrones Speichern blockiert JavaScript im aufrufenden Thread. Verwenden Sie die im Timeout‑Beispiel gezeigten asynchronen Java‑Bridge‑Aufrufe, sodass der Timer einen Abbruch anfordern kann, während das Speichern läuft.

**Wirkt das Abbrechen sofort?**

Der Abbruch ist kooperativ. Ein laufender Vorgang stoppt, sobald er den Antrag erkennt. Ein bereits abgeschlossener Vorgang behält sein Ergebnis bei.

**Können mehrere Vorgänge dieselbe Quelle nutzen?**

Ja. Der Aufruf von `interrupt()` fordert den Abbruch für jeden Vorgang an, der ein Token aus dieser Quelle verwendet. Verwenden Sie für jeden Vorgang, den Sie unabhängig abbrechen möchten, eine separate Quelle.