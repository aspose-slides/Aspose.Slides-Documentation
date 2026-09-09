---
title: Converti PPT in PPTX in Python
linktitle: PPT in PPTX
type: docs
weight: 20
url: /it/python-java/convert-ppt-to-pptx/
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
- Python
- Java
- Aspose.Slides
description: "Converti i file PPT legacy in PPTX in Python con Aspose.Slides. Include esempi Python per la conversione di file singoli e batch, gestione degli errori e note sulla fedeltà."
---
## **Panoramica**

PPT è il formato binario legacy di PowerPoint, mentre PPTX è il più recente formato Open XML. Aspose.Slides for Python via Java può caricare un file PPT e salvarlo come PPTX senza Microsoft PowerPoint. Questo articolo mostra come convertire un singolo file o una cartella di file e spiega cosa verificare dopo la conversione.

Ogni esempio avvia la macchina virtuale Java se necessario e rilascia la presentazione dopo l'uso. Sostituisci i percorsi di esempio con i percorsi dei tuoi file o cartelle.

## **Convertire un file PPT in PPTX**

Carica il file sorgente con la classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e poi chiama [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#Pptx). Il blocco `finally` dispone della presentazione e ne rilascia le risorse.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Carica la presentazione PPT legacy.
presentation = Presentation("presentation.ppt")
try:
    # Salva la presentazione in formato PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

L'estensione del file non seleziona il formato di output da sola; lo fa l'argomento [SaveFormat.Pptx](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#Pptx). Mantieni percorsi di input e output diversi se devi conservare il file PPT originale.

## **Convertire più file PPT**

L'esempio seguente converte ogni file `.ppt` in una cartella. Ogni file è elaborato in modo indipendente, così una conversione fallita non interrompe il resto del batch.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

Per carichi di lavoro di produzione, registra l'eccezione completa, decidi se un file di output esistente può essere sovrascritto e scrivi i nomi dei file falliti in una coda di ripetizione o revisione. File corrotti, file protetti da password aperti senza la password richiesta, percorsi non accessibili e contenuti non supportati possono tutti causare il fallimento della conversione. Consulta [Password-Protected Presentations](/slides/it/python-java/password-protected-presentation/) per caricare file crittati.

## **Fedeltà e funzionalità legacy**

La conversione normalmente preserva diapositive, master, layout, testo, forme, immagini, tabelle e grafici. Tuttavia, PPT e PPTX non rappresentano ogni funzionalità esattamente allo stesso modo. Una funzionalità legacy che non ha un equivalente PPTX, o non è supportata dalla libreria, può essere normalizzata, omessa o visualizzata diversamente.

Verifica il file convertito quando contiene animazioni, transizioni, oggetti OLE incorporati o collegati, controlli ActiveX, media incorporati, font non comuni o macro VBA. Un file PPTX semplice non è un formato abilitato alle macro, quindi usa un flusso di lavoro adeguato per le macro quando VBA deve rimanere disponibile. Verifica inoltre che i font richiesti e le risorse esterne siano presenti nell'ambiente in cui la presentazione convertita verrà aperta o renderizzata.

Per documenti importanti, riapri programmaticamente il PPTX generato e ispeziona il conteggio delle diapositive chiave e il contenuto, quindi confronta il suo aspetto e il comportamento della presentazione in modalità slideshow nel visualizzatore previsto. Non considerare una chiamata riuscita a [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) come prova che ogni funzionalità legacy abbia una rappresentazione PPTX esatta.

## **Quando utilizzare PPTX**

Usa PPTX quando la presentazione verrà modificata con le versioni attuali di PowerPoint, scambiata con sistemi che lavorano con pacchetti Open XML o archiviata in un formato più facile da ispezionare e recuperare rispetto al legacy binario PPT. Conserva il PPT originale come copia di archivio o di ripristino finché la presentazione convertita non supera i tuoi controlli di fedeltà.

Se ti occorrono PDF, HTML, immagini, XPS o un altro tipo di output, utilizza le indicazioni specifiche per formato in [Convert Presentations to Multiple Formats](/slides/it/python-java/convert-presentation/) anziché assumere che tutti i target preservino le funzionalità modificabili di PowerPoint.

## **Convertitore online**

Per un file occasionale o un confronto rapido, puoi usare il [online PPT to PPTX converter](https://products.aspose.app/slides/it/conversion/ppt-to-pptx). Per conversioni ripetibili, elaborazione batch o gestione degli errori a livello di applicazione, usa l'API Python tramite Java.

## **Articoli correlati**

- [PPT vs PPTX](/slides/it/python-java/ppt-vs-pptx/)
- [Salvare le presentazioni in Python](/slides/it/python-java/save-presentation/)
- [Formati di file supportati](/slides/it/python-java/supported-file-formats/)
- [Aprire le presentazioni in Python](/slides/it/python-java/open-presentation/)

## **FAQ**

**Posso convertire PPT in PPTX senza Microsoft PowerPoint installato?**

Sì. Aspose.Slides for Python via Java carica e salva i file di presentazione senza richiedere Microsoft PowerPoint.

**La conversione da PPT a PPTX conserverà tutti i contenuti esattamente?**

Conserva il contenuto di presentazione più comune, ma la fedeltà completa non è garantita per ogni funzionalità legacy o non supportata. Rivedi il file generato quando contiene macro, oggetti OLE o ActiveX, media, animazioni specializzate o font non comuni.

**Posso convertire un file PPT protetto da password?**

Sì, se fornisci la password corretta al momento del caricamento del file. Una password mancante o errata causa il fallimento dell'operazione di caricamento.

**Devo eliminare il file PPT dopo la conversione?**

Conserva l'originale finché non hai verificato il PPTX nei visualizzatori e nei flussi di lavoro che ti interessano. Questo fornisce una copia di ripristino nel caso in cui una funzionalità legacy venga convertita in modo diverso.