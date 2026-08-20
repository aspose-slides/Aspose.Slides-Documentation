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
description: "Converti i file PPT legacy in PPTX in Node.js con Aspose.Slides. Include esempi JavaScript per la conversione di file singoli e batch, gestione degli errori e note di fedeltà."
---
## **Panoramica**

PPT è il formato binario legacy di PowerPoint, mentre PPTX è il nuovo formato Open XML. Aspose.Slides per Node.js via Java può caricare un file PPT e salvarlo come PPTX senza Microsoft PowerPoint. Questo articolo mostra come convertire un singolo file o una cartella di file e spiega cosa verificare dopo la conversione.

## **Convertire un file PPT in PPTX**

Carica il file sorgente con la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/), quindi chiama [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveformat/). Il blocco `finally` rilascia la presentazione e le sue risorse.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Carica la presentazione PPT legacy.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Salva la presentazione nel formato PPTX.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L’estensione del file non seleziona il formato di output da sola; lo fa l’argomento [SaveFormat.Pptx](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveformat/). Mantieni percorsi di input e output diversi se devi conservare il file PPT originale.

## **Convertire più file PPT**

L’esempio seguente converte ogni file `.ppt` in una directory. Ogni file viene elaborato in modo indipendente, quindi una conversione fallita non interrompe il resto del batch.

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

Per carichi di lavoro di produzione, registra l’intero errore, decidi se un file di output esistente può essere sovrascritto e scrivi i nomi dei file falliti in una coda di ripetizione o revisione. File corrotti, file protetti da password aperti senza la password richiesta, percorsi non accessibili e contenuti non supportati possono tutti causare un fallimento della conversione. Consulta [Password-Protected Presentations](/nodejs-java/password-protected-presentation/) per caricare file crittografati.

## **Fedeltà e funzionalità legacy**

La conversione normalmente preserva diapositive, master, layout, testo, forme, immagini, tabelle e grafici. Tuttavia, PPT e PPTX non rappresentano ogni funzionalità nello stesso modo. Una funzionalità legacy che non ha un equivalente PPTX, o non è supportata dalla libreria, può essere normalizzata, omessa o visualizzata diversamente.

Controlla il file convertito quando contiene animazioni, transizioni, oggetti OLE incorporati o collegati, controlli ActiveX, media incorporati, font non comuni o macro VBA. Un file PPTX semplice non è un formato abilitato alle macro, quindi usa un flusso di lavoro appropriato per macro quando VBA deve rimanere disponibile. Verifica inoltre che i font richiesti e le risorse esterne siano presenti nell’ambiente in cui la presentazione convertita verrà aperta o renderizzata.

Per documenti importanti, riapri programmaticamente il PPTX generato e ispeziona il conteggio delle diapositive e il contenuto chiave, quindi confronta l’aspetto e il comportamento dello slideshow nel visualizzatore previsto. Non considerare una chiamata riuscita a [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save) prova che ogni funzionalità legacy abbia una rappresentazione PPTX esatta.

## **Quando usare PPTX**

Usa PPTX quando la presentazione sarà modificata nelle versioni attuali di PowerPoint, scambiata con sistemi che lavorano con pacchetti Open XML o archiviata in un formato più facile da ispezionare e recuperare rispetto al legacy binario PPT. Conserva il PPT originale come copia di archivio o di ripristino finché la presentazione convertita non supera i tuoi controlli di fedeltà.

Se ti serve PDF, HTML, immagini, XPS o un altro tipo di output, utilizza le indicazioni specifiche per formato in [Convert Presentations to Multiple Formats](/nodejs-java/convert-presentation/) anziché presumere che tutti i target preservino le funzionalità modificabili di PowerPoint.

## **Convertitore online**

Per un file occasionale o un confronto rapido, puoi usare il [online PPT to PPTX converter](https://products.aspose.app/slides/it/conversion/ppt-to-pptx). Per conversioni ripetibili, elaborazioni batch o gestione degli errori a livello di applicazione, utilizza l’API Node.js via Java.

## **Articoli correlati**

- [PPT vs PPTX](/nodejs-java/ppt-vs-pptx/)
- [Save Presentations in Node.js](/nodejs-java/save-presentation/)
- [Supported File Formats](/nodejs-java/supported-file-formats/)
- [Open Presentations in Node.js](/nodejs-java/open-presentation/)

## **FAQ**

**Posso convertire PPT in PPTX senza Microsoft PowerPoint installato?**

Sì. Aspose.Slides per Node.js via Java carica e salva i file di presentazione senza richiedere Microsoft PowerPoint.

**La conversione da PPT a PPTX preserverà tutto il contenuto esattamente?**

Preserva il contenuto di presentazione comune, ma la fedeltà esatta non è garantita per ogni funzionalità legacy o non supportata. Rivedi il file generato quando contiene macro, oggetti OLE o ActiveX, media, animazioni specializzate o font non comuni.

**Posso convertire un file PPT protetto da password?**

Sì, se fornisci la password corretta durante il caricamento del file. Una password mancante o errata provoca il fallimento dell’operazione di caricamento.

**Devo eliminare il file PPT dopo la conversione?**

Conserva l’originale finché non hai verificato il PPTX nei visualizzatori e nei flussi di lavoro che ti interessano. Questo fornisce una copia di ripristino se una funzionalità legacy viene convertita in modo diverso.