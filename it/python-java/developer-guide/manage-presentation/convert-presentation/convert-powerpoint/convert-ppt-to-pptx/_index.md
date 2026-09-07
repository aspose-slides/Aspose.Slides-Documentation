---
title: Converti PPT in PPTX in Python
linktitle: PPT in PPTX
type: docs
weight: 20
url: /it/python-java/convert-ppt-to-pptx/
keywords:
- convertire PowerPoint
- convertire presentazione
- convertire diapositiva
- convertire PPT
- PPT in PPTX
- salva PPT come PPTX
- esporta PPT in PPTX
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Converti i file PPT legacy in PPTX con Python usando Aspose.Slides. Include esempi Python per la conversione di un singolo file e batch, gestione degli errori e note sulla fedeltà."
---
## **Panoramica**

PPT è il formato binario legacy di PowerPoint, mentre PPTX è il formato Open XML più recente. Aspose.Slides per Python tramite Java può caricare un file PPT e salvarlo come PPTX senza Microsoft PowerPoint. Questo articolo mostra come convertire un file o una directory di file e spiega cosa verificare dopo la conversione.

Ogni esempio avvia la macchina virtuale Java se necessario e rilascia la presentazione al termine dell'uso. Sostituisci i percorsi di esempio con i percorsi dei tuoi file o directory.

## **Convertire un file PPT in PPTX**

Carica il file di origine con la classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/), quindi chiama [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#Pptx). Il blocco `finally` elimina la presentazione e rilascia le sue risorse.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Carica la presentazione PPT legacy.
presentation = Presentation("presentation.ppt")
try:
    # Salva la presentazione nel formato PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

L'estensione del file non seleziona il formato di output da sola; lo fa l'argomento [SaveFormat.Pptx](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#Pptx). Mantieni percorsi di input e output differenti se devi conservare il file PPT originale.

## **Convertire più file PPT**

L'esempio seguente converte tutti i file `.ppt` in una directory. Ogni file viene elaborato indipendentemente, quindi un errore di conversione non arresta il resto del batch.

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

Per carichi di lavoro in produzione, registra l'eccezione completa, decidi se un file di output esistente può essere sovrascritto e scrivi i nomi dei file non riusciti in una coda di retry o revisione. File corrotti, file protetti da password aperti senza la password necessaria, percorsi non accessibili e contenuti non supportati possono tutti causare un fallimento della conversione. Vedi [Password-Protected Presentations](/slides/it/python-java/password-protected-presentation/) per caricare file criptati.

## **Fedeltà e funzionalità legacy**

La conversione normalmente preserva diapositive, master, layout, testo, forme, immagini, tabelle e grafici. Tuttavia, PPT e PPTX non rappresentano ogni funzionalità nello stesso modo esatto. Una funzionalità legacy priva di equivalente PPTX, o non supportata dalla libreria, può essere normalizzata, omessa o visualizzata diversamente.

Verifica il file convertito quando contiene animazioni, transizioni, oggetti OLE incorporati o collegati, controlli ActiveX, media incorporati, font poco comuni o macro VBA. Un file PPTX normale non è un formato abilitato alle macro, quindi utilizza un flusso di lavoro appropriato per macro quando VBA deve rimanere disponibile. Verifica inoltre che i font richiesti e le risorse esterne siano presenti nell'ambiente in cui la presentazione convertita verrà aperta o renderizzata.

Per documenti importanti, riapri il PPTX generato programmaticamente e ispeziona il conteggio delle diapositive chiave e il contenuto, quindi confronta il suo aspetto e il comportamento della presentazione nello visualizzatore previsto. Non considerare una chiamata riuscita a [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) come prova che ogni funzionalità legacy abbia una rappresentazione PPTX esatta.

## **Quando utilizzare PPTX**

Usa PPTX quando la presentazione verrà modificata nelle versioni attuali di PowerPoint, scambiata con sistemi che lavorano con pacchetti Open XML, o archiviata in un formato più facile da ispezionare e recuperare rispetto al binary legacy PPT. Conserva il PPT originale come copia d'archivio o di ripristino finché la presentazione convertita non supera i tuoi controlli di fedeltà.

Se invece ti serve PDF, HTML, immagini, XPS o un altro tipo di output, utilizza le indicazioni specifiche per formato in [Convert Presentations to Multiple Formats](/slides/it/python-java/convert-presentation/) invece di presumere che tutte le destinazioni preservino le funzionalità modificabili di PowerPoint.

## **Convertitore online**

Per un file occasionale o un confronto rapido, puoi utilizzare il [online PPT to PPTX converter](https://products.aspose.app/slides/it/conversion/ppt-to-pptx). Per conversioni ripetibili, elaborazione batch o gestione degli errori a livello di applicazione, usa l'API Python tramite Java.

## **Articoli correlati**

- [PPT vs PPTX](/slides/it/python-java/ppt-vs-pptx/)
- [Salvare le presentazioni in Python](/slides/it/python-java/save-presentation/)
- [Formati file supportati](/slides/it/python-java/supported-file-formats/)
- [Aprire le presentazioni in Python](/slides/it/python-java/open-presentation/)

## **FAQ**

**Posso convertire PPT in PPTX senza Microsoft PowerPoint installato?**

Sì. Aspose.Slides per Python tramite Java carica e salva i file di presentazione senza richiedere Microsoft PowerPoint.

**La conversione da PPT a PPTX preserva tutto il contenuto esattamente?**

Preserva il contenuto comune delle presentazioni, ma la fedeltà esatta non è garantita per ogni funzionalità legacy o non supportata. Rivedi il file generato quando contiene macro, oggetti OLE o ActiveX, media, animazioni specializzate o font poco comuni.

**Posso convertire un file PPT protetto da password?**

Sì, se fornisci la password corretta al momento del caricamento del file. Una password mancante o errata causa il fallimento dell'operazione di caricamento.

**Devo eliminare il file PPT dopo la conversione?**

Conserva l'originale finché non hai verificato il PPTX negli visualizzatori e nei flussi di lavoro che ti interessano. Questo fornisce una copia di ripristino se una funzionalità legacy viene convertita in modo diverso.