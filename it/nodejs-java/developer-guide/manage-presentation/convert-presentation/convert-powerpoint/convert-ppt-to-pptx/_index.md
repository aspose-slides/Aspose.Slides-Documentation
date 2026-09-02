---
title: Converti PPT in PPTX in Node.js
linktitle: PPT in PPTX
type: docs
weight: 20
url: /it/nodejs-java/convert-ppt-to-pptx/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- PPT in PPTX
- salva PPT come PPTX
- esporta PPT in PPTX
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti i file PPT legacy in PPTX in Node.js con Aspose.Slides. Include esempi JavaScript per la conversione di un singolo file e batch, gestione degli errori e note sulla fedeltà."
---
## **Panoramica**

PPT è il formato binario legacy di PowerPoint, mentre PPTX è il formato Open XML più recente. Aspose.Slides per Node.js via Java può caricare un file PPT e salvarlo come PPTX senza Microsoft PowerPoint. Questo articolo mostra come convertire un file o una directory di file e spiega cosa verificare dopo la conversione.

## **Convertire un file PPT in PPTX**

Carica il file di origine con la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/), poi chiama [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveformat/). Il blocco `finally` elimina la presentazione e rilascia le sue risorse.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Carica la presentazione PPT legacy.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Salva la presentazione in formato PPTX.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L'estensione del file non seleziona il formato di output da sola; lo fa l'argomento [SaveFormat.Pptx](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveformat/). Mantieni percorsi di input e output diversi se hai bisogno di conservare il file PPT originale.

## **Convertire più file PPT**

L'esempio seguente converte ogni file `.ppt` in una directory. Ogni file viene elaborato in modo indipendente, quindi una conversione fallita non interrompe il resto del batch.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

Per carichi di lavoro in produzione, registra l'errore completo, decidi se un file di output esistente può essere sovrascritto e scrivi i nomi dei file falliti in una coda di riprova o revisione. File corrotti, file protetti da password aperti senza la password richiesta, percorsi inaccessibili e contenuti non supportati possono tutti causare un fallimento della conversione. Vedi [Password-Protected Presentations](/slides/it/nodejs-java/password-protected-presentation/) per caricare file crittati.

## **Fedeltà e funzionalità legacy**

La conversione normalmente preserva diapositive, master, layout, testo, forme, immagini, tabelle e grafici. Tuttavia, PPT e PPTX non rappresentano ogni funzionalità esattamente nello stesso modo. Una funzionalità legacy che non ha un equivalente PPTX, o che non è supportata dalla libreria, può essere normalizzata, omessa o visualizzata in modo diverso.

Controlla il file convertito quando contiene animazioni, transizioni, oggetti OLE incorporati o collegati, controlli ActiveX, media incorporati, font poco comuni o macro VBA. Un file PPTX normale non è un formato abilitato alle macro, quindi utilizza un flusso di lavoro adeguato per macro quando VBA deve rimanere disponibile. Verifica inoltre che i font richiesti e le risorse esterne siano presenti nell'ambiente in cui la presentazione convertita sarà aperta o renderizzata.

Per documenti importanti, riapri il PPTX generato programmaticamente e ispeziona il conteggio e il contenuto delle diapositive chiave, quindi confronta il suo aspetto e il comportamento della presentazione in modalità slideshow nel visualizzatore previsto. Non considerare una chiamata riuscita a [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save) come prova che ogni funzionalità legacy abbia una rappresentazione PPTX esatta.

## **Quando usare PPTX**

Usa PPTX quando la presentazione verrà modificata nelle versioni attuali di PowerPoint, scambiata con sistemi che lavorano con pacchetti Open XML, o archiviata in un formato più facile da ispezionare e recuperare rispetto al legacy binario PPT. Conserva il PPT originale come copia archivistica o di rollback finché la presentazione convertita non supera i tuoi controlli di fedeltà.

Se hai bisogno invece di PDF, HTML, immagini, XPS o un altro tipo di output, usa le indicazioni specifiche per formato in [Convert Presentations to Multiple Formats](/slides/it/nodejs-java/convert-presentation/) invece di presumere che tutti i target preservino le funzionalità modificabili di PowerPoint.

## **Convertitore online**

Per un file occasionale o un confronto rapido, puoi utilizzare il [online PPT to PPTX converter](https://products.aspose.app/slides/it/conversion/ppt-to-pptx). Per conversioni ripetibili, elaborazione batch o gestione degli errori a livello di applicazione, utilizza l'API Node.js via Java.

## **Articoli correlati**

- [PPT vs PPTX](/slides/it/nodejs-java/ppt-vs-pptx/)
- [Salvare le presentazioni in Node.js](/slides/it/nodejs-java/save-presentation/)
- [Formati di file supportati](/slides/it/nodejs-java/supported-file-formats/)
- [Aprire presentazioni in Node.js](/slides/it/nodejs-java/open-presentation/)

## **FAQ**

**Posso convertire PPT in PPTX senza Microsoft PowerPoint installato?**

Sì. Aspose.Slides per Node.js via Java carica e salva i file di presentazione senza richiedere Microsoft PowerPoint.

**La conversione da PPT a PPTX preserverà tutto il contenuto esattamente?**

Preserva il contenuto comune delle presentazioni, ma la fedeltà esatta non è garantita per ogni funzionalità legacy o non supportata. Revisiona il file generato quando contiene macro, oggetti OLE o ActiveX, media, animazioni specializzate o font poco comuni.

**Posso convertire un file PPT protetto da password?**

Sì, se fornisci la password corretta durante il caricamento del file. Una password mancante o errata provoca il fallimento dell'operazione di caricamento.

**Devo eliminare il file PPT dopo la conversione?**

Conserva l'originale finché non avrai verificato il PPTX nei visualizzatori e nei flussi di lavoro che ti interessano. Questo fornisce una copia di rollback se una funzionalità legacy si converte in modo diverso.