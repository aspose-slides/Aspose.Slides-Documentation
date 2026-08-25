---
title: Converti PPT in PPTX in Java
linktitle: PPT in PPTX
type: docs
weight: 20
url: /it/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Converti i file PPT legacy in PPTX in Java con Aspose.Slides. Include esempi Java per la conversione di singoli file e batch, gestione degli errori e note sulla fedeltà."
---
## **Panoramica**

PPT è il formato binario legacy di PowerPoint, mentre PPTX è il nuovo formato Open XML. Aspose.Slides for Java può caricare un file PPT e salvarlo come PPTX senza Microsoft PowerPoint. Questo articolo mostra come convertire un file o una directory di file e spiega cosa verificare dopo la conversione.

## **Convertire un file PPT in PPTX**

Carica il file di origine con la classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) , quindi chiama [Presentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#save-java.lang.String-int-) con [SaveFormat.Pptx](https://reference.aspose.com/slides/it/java/com.aspose.slides/saveformat/#Pptx) . Il blocco `finally` rilascia la presentazione e le sue risorse.

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

L’estensione del file non seleziona il formato di output da sola; l’argomento [SaveFormat.Pptx](https://reference.aspose.com/slides/it/java/com.aspose.slides/saveformat/#Pptx) lo fa. Mantieni percorsi di input e output diversi se devi conservare il file PPT originale.

## **Convertire più file PPT**

L’esempio seguente converte ogni file `.ppt` in una directory. Ogni file è elaborato in modo indipendente, quindi un fallimento di conversione non interrompe il resto del batch.

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

Per carichi di lavoro di produzione, registra l’eccezione completa, decidi se un file di output esistente può essere sovrascritto e scrivi i nomi dei file non riusciti in una coda di ripetizione o revisione. File corrotti, file protetti da password aperti senza la password richiesta, percorsi non accessibili e contenuti non supportati possono tutti causare un fallimento della conversione. Vedi [Password-Protected Presentations](/slides/it/java/password-protected-presentation/) per il caricamento di file crittografati.

## **Fedeltà e funzionalità legacy**

La conversione normalmente conserva diapositive, master, layout, testo, forme, immagini, tabelle e grafici. Tuttavia, PPT e PPTX non rappresentano ogni funzionalità esattamente allo stesso modo. Una funzionalità legacy che non ha un equivalente PPTX, o non è supportata dalla libreria, può essere normalizzata, omessa o visualizzata diversamente.

Controlla il file convertito quando contiene animazioni, transizioni, oggetti OLE incorporati o collegati, controlli ActiveX, media incorporati, caratteri poco comuni o macro VBA. Un semplice file PPTX non è un formato abilitato alle macro, quindi usa un flusso di lavoro appropriato abilitato alle macro quando VBA deve rimanere disponibile. Verifica anche che i caratteri richiesti e le risorse esterne siano presenti nell’ambiente in cui la presentazione convertita verrà aperta o renderizzata.

Per documenti importanti, riapri il PPTX generato programmaticamente e ispeziona il conteggio e il contenuto delle diapositive chiave, quindi confronta l’aspetto e il comportamento della presentazione in modalità presentazione nel visualizzatore previsto. Non considerare una chiamata a [Presentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#save-java.lang.String-int-) di successo come prova che ogni funzionalità legacy abbia una rappresentazione PPTX esatta.

## **Quando usare PPTX**

Usa PPTX quando la presentazione verrà modificata nelle versioni attuali di PowerPoint, scambiata con sistemi che lavorano con pacchetti Open XML, o conservata in un formato più facile da ispezionare e recuperare rispetto al legacy binario PPT. Conserva il PPT originale come copia archivistica o di ripristino finché la presentazione convertita non supera i tuoi controlli di fedeltà.

Se hai bisogno di PDF, HTML, immagini, XPS o un altro tipo di output invece, usa le indicazioni specifiche per formato in [Convert Presentations to Multiple Formats](/slides/it/java/convert-presentation/) anziché presumere che tutti i target preservino le funzionalità modificabili di PowerPoint.

## **Convertitore online**

Per un file occasionale o un confronto rapido, puoi usare il [online PPT to PPTX converter](https://products.aspose.app/slides/it/conversion/ppt-to-pptx). Per conversioni ripetibili, elaborazione batch o gestione degli errori a livello di applicazione, usa le API Java.

## **Articoli correlati**

- [PPT vs PPTX](/slides/it/java/ppt-vs-pptx/)
- [Salvare presentazioni in Java](/slides/it/java/save-presentation/)
- [Formati di file supportati](/slides/it/java/supported-file-formats/)
- [Aprire presentazioni in Java](/slides/it/java/open-presentation/)

## **FAQ**

**Posso convertire PPT in PPTX senza Microsoft PowerPoint installato?**

Sì. Aspose.Slides for Java carica e salva i file di presentazione senza richiedere Microsoft PowerPoint.

**La conversione da PPT a PPTX preserverà tutto il contenuto esattamente?**

Preserva il contenuto di presentazione comune, ma la fedeltà esatta non è garantita per ogni funzionalità legacy o non supportata. Revisiona il file generato quando contiene macro, oggetti OLE o ActiveX, media, animazioni specializzate o caratteri poco comuni.

**Posso convertire un file PPT protetto da password?**

Sì, se fornisci la password corretta al momento del caricamento del file. Una password mancante o errata causa il fallimento dell’operazione di caricamento.

**Devo eliminare il file PPT dopo la conversione?**

Conserva l’originale finché non hai verificato il PPTX nei visualizzatori e nei flussi di lavoro che ti interessano. Questo fornisce una copia di ripristino se una funzionalità legacy viene convertita diversamente.