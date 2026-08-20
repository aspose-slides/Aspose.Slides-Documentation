---
title: Converti PPT in PPTX su Android
linktitle: PPT in PPTX
type: docs
weight: 20
url: /it/androidjava/convert-ppt-to-pptx/
keywords:
- convertire PowerPoint
- convertire presentazione
- convertire diapositiva
- convertire PPT
- PPT in PPTX
- salvare PPT come PPTX
- esportare PPT in PPTX
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Converti file PPT legacy in PPTX su Android con Aspose.Slides. Include esempi Java per conversione singola e batch, gestione degli errori e note sulla fedeltà."
---
## **Panoramica**

PPT è il formato binario legacy di PowerPoint, mentre PPTX è il formato Open XML più recente. Aspose.Slides for Android via Java può caricare un file PPT e salvarlo come PPTX senza Microsoft PowerPoint. Questo articolo mostra come convertire un file o una directory di file e spiega cosa verificare dopo la conversione.

## **Convertire un file PPT in PPTX**

Carica il file di origine con la classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) , poi chiama [Presentation.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) con [SaveFormat.Pptx](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/saveformat/#Pptx) . Il blocco `finally` elimina la presentazione e rilascia le sue risorse.

```java
// Carica la presentazione PPT legacy.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Salva la presentazione in formato PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L'estensione del file non seleziona il formato di output da sola; lo fa l'argomento [SaveFormat.Pptx](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/saveformat/#Pptx) . Mantieni i percorsi di input e output diversi se devi conservare il file PPT originale.

## **Convertire più file PPT**

L'esempio seguente converte tutti i file `.ppt` in una directory. Ogni file viene elaborato in modo indipendente, quindi una conversione fallita non interrompe il resto del batch.

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

Per carichi di lavoro in produzione, registra l'eccezione completa, decidi se un file di output esistente può essere sovrascritto e scrivi i nomi dei file non riusciti in una coda di ripetizione o revisione. File corrotti, file protetti da password aperti senza la password richiesta, percorsi inaccessibili e contenuti non supportati possono tutti causare un fallimento della conversione. Vedi [Password-Protected Presentations](/androidjava/password-protected-presentation/) per caricare file criptati.

## **Fedeltà e funzionalità legacy**

La conversione di solito preserva diapositive, master, layout, testo, forme, immagini, tabelle e grafici. Tuttavia, PPT e PPTX non rappresentano ogni funzionalità nello stesso modo esatto. Una funzionalità legacy che non ha un equivalente PPTX, o non è supportata dalla libreria, può essere normalizzata, omessa o visualizzata diversamente.

Controlla il file convertito quando contiene animazioni, transizioni, oggetti OLE incorporati o collegati, controlli ActiveX, media incorporati, font non comuni o macro VBA. Un file PPTX standard non è un formato abilitato alle macro, quindi utilizza un flusso di lavoro appropriato per macro quando VBA deve rimanere disponibile. Verifica inoltre che i font richiesti e le risorse esterne siano presenti nell'ambiente in cui la presentazione convertita verrà aperta o renderizzata.

Per documenti importanti, riapri il PPTX generato programmaticamente e ispeziona il numero di diapositive chiave e il contenuto, quindi confronta l'aspetto e il comportamento della presentazione nel visualizzatore previsto. Non considerare una chiamata riuscita a [Presentation.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) come prova che ogni funzionalità legacy abbia una rappresentazione PPTX esatta.

## **Quando usare PPTX**

Usa PPTX quando la presentazione verrà modificata nelle versioni attuali di PowerPoint, scambiata con sistemi che lavorano con pacchetti Open XML, o archiviata in un formato più facile da ispezionare e recuperare rispetto al legacy binario PPT. Conserva il PPT originale come copia archivistica o di ripristino finché la presentazione convertita non supera i tuoi controlli di fedeltà.

Se invece hai bisogno di PDF, HTML, immagini, XPS o un altro tipo di output, usa le indicazioni specifiche del formato in [Convert Presentations to Multiple Formats](/androidjava/convert-presentation/) invece di presumere che tutti i target preservino le funzionalità modificabili di PowerPoint.

## **Convertitore online**

Per un file occasionale o un confronto rapido, puoi utilizzare il [online PPT to PPTX converter](https://products.aspose.app/slides/it/conversion/ppt-to-pptx) . Per conversioni ripetibili, elaborazione batch o gestione degli errori a livello di applicazione, usa l'API Android via Java.

## **Articoli correlati**

- [PPT vs PPTX](/androidjava/ppt-vs-pptx/)
- [Save Presentations on Android](/androidjava/save-presentation/)
- [Supported File Formats](/androidjava/supported-file-formats/)
- [Open Presentations on Android](/androidjava/open-presentation/)

## **FAQ**

**Posso convertire PPT in PPTX senza Microsoft PowerPoint installato?**

Sì. Aspose.Slides for Android via Java carica e salva i file di presentazione senza richiedere Microsoft PowerPoint.

**La conversione da PPT a PPTX preserverà tutto il contenuto esattamente?**

Preserva il contenuto comune delle presentazioni, ma la fedeltà esatta non è garantita per ogni funzionalità legacy o non supportata. Verifica il file generato quando contiene macro, oggetti OLE o ActiveX, media, animazioni specializzate o font non comuni.

**Posso convertire un file PPT protetto da password?**

Sì, se fornisci la password corretta durante il caricamento del file. Una password mancante o errata provoca il fallimento dell'operazione di caricamento.

**Devo eliminare il file PPT dopo la conversione?**

Conserva l'originale finché non hai verificato il PPTX nei visualizzatori e nei flussi di lavoro che ti interessano. Questo fornisce una copia di ripristino se una funzionalità legacy si converte in modo diverso.