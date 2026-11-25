---
title: Interrompere operazioni di presentazione a lungo termine in Node.js
linktitle: Interrompere operazioni di presentazione
type: docs
weight: 120
url: /it/nodejs-java/support-for-interruptable-library/
keywords:
- operazioni interruttibili
- token di interruzione
- token di cancellazione
- timeout di conversione
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Annulla operazioni di presentazione a lunga esecuzione in Aspose.Slides per Node.js tramite Java, imposta un timeout di conversione e tieni traccia delle diapositive esportate prima della cancellazione."
---
## **Panoramica**

Aspose.Slides per Node.js tramite Java supporta la cancellazione durante il caricamento, il salvataggio o il rendering di una presentazione. È inoltre possibile verificare lo stesso token nel proprio ciclo di esportazione per interrompere prima della diapositiva successiva e restituire i numeri delle diapositive già salvate.

## **Interrompere un'operazione di presentazione**

Creare un [InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/), ottenere il suo token con [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken) e passarlo a [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken). Utilizzare queste opzioni durante la costruzione della [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Chiamare [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) sulla fonte richiede la cancellazione dell'operazione corrente. Aspose.Slides si interrompe quando controlla nuovamente il token.

### **Impostare un timeout di conversione**

Il seguente esempio consente 20 secondi per aprire `sample.pptx` e salvarlo come `sample.pdf`. Sia il costruttore sia il salvataggio vengono eseguiti in modo asincrono tramite il bridge Java, così il timer di Node.js può attivarsi durante una delle due operazioni. L'esempio verifica il token dopo il caricamento e nuovamente dopo il salvataggio, poiché una chiamata della libreria può restituire dopo una richiesta di cancellazione. Rilascia la presentazione quando l'operazione si stabilizza e cancella il timer se la conversione termina in anticipo. Se la cancellazione avviene durante un salvataggio, il file di output potrebbe già esistere e potrebbe essere incompleto.

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

Per convertire al formato PowerPoint più vecchio con un limite di 10 secondi, passare `"sample.ppt"`, `slides.SaveFormat.Ppt` e `10000` come ultimi tre argomenti.

## **Interrompere prima di elaborare la diapositiva successiva**

Utilizzare [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) prima di ogni esportazione quando il chiamante può usare un risultato parziale. La sovraccarico [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) per le diapositive selezionate accetta un `int[]` Java con i numeri delle diapositive a partire da 1. Registrare ogni numero solo dopo che il relativo PDF è stato salvato con successo.

Eseguire l'esempio con una presentazione denominata `sample.pptx` contenente almeno due diapositive. Per dimostrare la cancellazione tra le esportazioni, l'esempio la richiede immediatamente dopo il salvataggio della prima diapositiva.

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

L'esempio scrive `slide-1.pdf` e stampa `Starting slide 1` seguito da `Completed: [1]`. Il ciclo osserva la cancellazione prima di avviare la diapositiva 2. Se un salvataggio stesso viene interrotto, l'elenco restituito contiene solo le esportazioni precedenti riuscite.

Per consentire al chiamante di gestire la cancellazione come un errore, sostituire il controllo e il relativo `break` all'inizio del ciclo con [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested), chiamato come `token.throwIfInterruptionRequested()`. Utilizzare lo stesso controllo di eccezione dopo il salvataggio e rimuovere il `try`/`catch` intorno ad esso. Con lo stesso input, il primo PDF viene comunque scritto e la seconda iterazione genera un'eccezione prima che la funzione possa restituire un elenco.

## **FAQ**

**Quando dovrei richiedere la cancellazione?**

Richiedere la cancellazione quando una scadenza scade o l'applicazione non ha più bisogno del risultato. Caricamento, salvataggio e rendering possono tutti utilizzare il token passato alla presentazione al momento della costruzione.

**In che modo la fonte e il token differiscono?**

La fonte consente all'applicazione di richiedere la cancellazione. Il token consente ad Aspose.Slides e al proprio codice di verificare tale richiesta.

**Un timer Node.js può interrompere un salvataggio sincrono?**

Un salvataggio sincrono blocca JavaScript sul thread chiamante. Utilizzare le chiamate asincrone del bridge Java mostrate nell'esempio del timeout in modo che il timer possa richiedere la cancellazione mentre il salvataggio è in esecuzione.

**La cancellazione ha effetto immediato?**

La cancellazione è cooperativa. Un'operazione in esecuzione si interrompe quando rileva la richiesta. Un'operazione già terminata conserva il suo risultato.

**Possono più operazioni condividere una fonte?**

Sì. Chiamare `interrupt()` richiede la cancellazione per ogni operazione che utilizza un token di quella fonte. Utilizzare una fonte separata per ciascuna operazione che si desidera annullare in modo indipendente.