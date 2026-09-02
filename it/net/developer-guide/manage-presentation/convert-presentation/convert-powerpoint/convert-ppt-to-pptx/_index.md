---
title: Converti PPT in PPTX in .NET
linktitle: PPT a PPTX
type: docs
weight: 20
url: /it/net/convert-ppt-to-pptx/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- PPT a PPTX
- salva PPT come PPTX
- esporta PPT in PPTX
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Converti i file PPT legacy in PPTX in .NET con Aspose.Slides. Include esempi C# per la conversione di singoli file e batch, gestione degli errori e note sulla fedeltà."
---
## **Panoramica**

PPT è il formato binario legacy di PowerPoint, mentre PPTX è il nuovo formato Open XML. Aspose.Slides per .NET può caricare un file PPT e salvarlo come PPTX senza Microsoft PowerPoint. Questo articolo mostra come convertire un singolo file o una directory di file e spiega cosa verificare dopo la conversione.

## **Convertire un file PPT in PPTX**

Carica il file sorgente con la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/), poi chiama [IPresentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/save/) con [SaveFormat.Pptx](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveformat/). La dichiarazione `using` elimina la presentazione e rilascia le sue risorse quando il blocco termina.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

// Carica la presentazione PPT legacy.
using var presentation = new Presentation("presentation.ppt");

// Salva la presentazione nel formato PPTX.
presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

L'estensione del file non seleziona il formato di output da sola; lo fa l'argomento [SaveFormat.Pptx](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveformat/). Mantieni percorsi di input e output diversi se devi conservare il file PPT originale.

## **Convertire più file PPT**

L'esempio seguente converte ogni file `.ppt` in una directory. Ogni file viene elaborato in modo indipendente, quindi una conversione fallita non interrompe il resto del batch.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var inputDirectory = "input";
var outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory, "*.ppt", SearchOption.TopDirectoryOnly))
{
    var outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pptx";
    var outputPath = Path.Combine(outputDirectory, outputFileName);

    try
    {
        using var presentation = new Presentation(inputPath);
        presentation.Save(outputPath, SaveFormat.Pptx);
        Console.WriteLine($"Converted: {inputPath}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Failed: {inputPath} ({exception.Message})");
    }
}
```

Per carichi di lavoro in produzione, registra l'eccezione completa, decidi se un file di output esistente può essere sovrascritto e scrivi i nomi dei file non riusciti in una coda di ripetizione o revisione. File corrotti, file protetti da password aperti senza la password richiesta, percorsi non accessibili e contenuti non supportati possono tutti causare un fallimento della conversione. Vedi [Presentazioni protette da password](/slides/it/net/password-protected-presentation/) per caricare file crittografati.

## **Fedeltà e funzionalità legacy**

La conversione conserva normalmente diapositive, master, layout, testo, forme, immagini, tabelle e grafici. Tuttavia, PPT e PPTX non rappresentano ogni funzionalità nello stesso modo. Una funzionalità legacy che non ha un equivalente PPTX, o non è supportata dalla libreria, può essere normalizzata, omessa o visualizzata diversamente.

Controlla il file convertito quando contiene animazioni, transizioni, oggetti OLE incorporati o collegati, controlli ActiveX, media incorporati, caratteri non comuni o macro VBA. Un file PPTX semplice non è un formato abilitato alle macro, quindi utilizza un flusso di lavoro adeguato alle macro quando VBA deve rimanere disponibile. Verifica inoltre che i caratteri richiesti e le risorse esterne siano presenti nell'ambiente in cui la presentazione convertita verrà aperta o renderizzata.

Per i documenti importanti, riapri il PPTX generato programmaticamente e ispeziona il conteggio delle diapositive chiave e il contenuto, quindi confronta il suo aspetto e il comportamento della presentazione nello visualizzatore previsto. Non considerare una chiamata riuscita a [IPresentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/save/) come prova che ogni funzionalità legacy abbia una rappresentazione PPTX esatta.

## **Quando usare PPTX**

Usa PPTX quando la presentazione verrà modificata nelle versioni attuali di PowerPoint, scambiata con sistemi che lavorano con pacchetti Open XML, o archiviata in un formato più facile da ispezionare e recuperare rispetto al binario legacy PPT. Conserva il PPT originale come copia archivistica o di rollback finché la presentazione convertita non supera i tuoi controlli di fedeltà.

Se invece ti servono PDF, HTML, immagini, XPS o un altro tipo di output, utilizza le indicazioni specifiche per formato in [Convertire le presentazioni in più formati](/slides/it/net/convert-presentation/) piuttosto che presumere che tutti i target conservino le funzionalità modificabili di PowerPoint.

## **Convertitore online**

Per un file occasionale o un confronto rapido, puoi utilizzare il [convertitore online PPT in PPTX](https://products.aspose.app/slides/it/conversion/ppt-to-pptx). Per conversioni ripetibili, elaborazione batch o gestione degli errori a livello di applicazione, usa l'API .NET.

## **Articoli correlati**

- [PPT vs PPTX](/slides/it/net/ppt-vs-pptx/)
- [Salvare le presentazioni in .NET](/slides/it/net/save-presentation/)
- [Formati di file supportati](/slides/it/net/supported-file-formats/)
- [Aprire le presentazioni in .NET](/slides/it/net/open-presentation/)

## **FAQ**

**Posso convertire PPT in PPTX senza Microsoft PowerPoint installato?**

Sì. Aspose.Slides per .NET carica e salva i file di presentazione senza richiedere Microsoft PowerPoint.

**La conversione da PPT a PPTX preserverà tutto il contenuto esattamente?**

Preserva il contenuto comune delle presentazioni, ma la fedeltà esatta non è garantita per ogni funzionalità legacy o non supportata. Revisiona il file generato quando contiene macro, oggetti OLE o ActiveX, media, animazioni specializzate o caratteri non comuni.

**Posso convertire un file PPT protetto da password?**

Sì, se fornisci la password corretta durante il caricamento del file. Una password mancante o errata provoca il fallimento dell'operazione di caricamento.

**Devo eliminare il file PPT dopo la conversione?**

Conserva l'originale finché non hai verificato il PPTX nei visualizzatori e nei flussi di lavoro che ti interessano. Questo fornisce una copia di rollback se una funzionalità legacy si converte in modo diverso.