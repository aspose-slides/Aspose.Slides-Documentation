---
title: Converti PPT in PPTX con Python
linktitle: PPT in PPTX
type: docs
weight: 20
url: /it/python-net/convert-ppt-to-pptx/
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
- Aspose.Slides
description: "Converti i file PPT legacy in PPTX con Python e Aspose.Slides. Include esempi per la conversione singola e batch, gestione degli errori e note sulla fedeltà."
---
## **Panoramica**

PPT è il formato binario legacy di PowerPoint, mentre PPTX è il nuovo formato Open XML. Aspose.Slides per Python tramite .NET può caricare un file PPT e salvarlo come PPTX senza Microsoft PowerPoint. Questo articolo mostra come convertire un file o una directory di file e spiega cosa verificare dopo la conversione.

## **Convertire un file PPT in PPTX**

Carica il file di origine con la classe [Presentazione](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) . Quindi chiama [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/) con [SaveFormat.PPTX](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/saveformat/). L'istruzione `with` elimina la presentazione e rilascia le sue risorse al termine del blocco.

```python
import aspose.slides as slides

# Carica la presentazione PPT legacy.
with slides.Presentation("presentation.ppt") as presentation:
    # Salva la presentazione in formato PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

L'estensione del file non seleziona il formato di output da sola; lo fa l'argomento [SaveFormat.PPTX](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/saveformat/). Mantieni percorsi di ingresso e uscita diversi se devi conservare il file PPT originale.

## **Convertire più file PPT**

L'esempio seguente converte ogni file `.ppt` in una directory. Ogni file è elaborato in modo indipendente, quindi una conversione non riuscita non interrompe il resto del batch.

```python
from pathlib import Path

import aspose.slides as slides

input_directory = Path("input")
output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

for input_path in input_directory.glob("*.ppt"):
    output_path = output_directory / f"{input_path.stem}.pptx"

    try:
        with slides.Presentation(str(input_path)) as presentation:
            presentation.save(str(output_path), slides.export.SaveFormat.PPTX)
        print(f"Converted: {input_path}")
    except Exception as exception:
        print(f"Failed: {input_path} ({exception})")
```

Per carichi di lavoro di produzione, registra l'eccezione completa, decidi se un file di output esistente può essere sovrascritto e scrivi i nomi dei file non riusciti in una coda di retry o revisione. File corrotti, file protetti da password aperti senza la password richiesta, percorsi inaccessibili e contenuti non supportati possono tutti causare il fallimento di una conversione. Consulta [Presentazioni protette da password](/slides/it/python-net/password-protected-presentation/) per caricare file crittografati.

## **Fedeltà e funzionalità legacy**

La conversione normalmente preserva diapositive, master, layout, testo, forme, immagini, tabelle e grafici. Tuttavia, PPT e PPTX non rappresentano ogni funzionalità esattamente allo stesso modo. Una funzionalità legacy priva di equivalente PPTX o non supportata dalla libreria può essere normalizzata, omessa o visualizzata diversamente.

Verifica il file convertito quando contiene animazioni, transizioni, oggetti OLE incorporati o collegati, controlli ActiveX, media incorporati, font poco comuni o macro VBA. Un file PPTX semplice non è un formato abilitato alle macro, quindi utilizza un flusso di lavoro appropriato per le macro quando VBA deve rimanere disponibile. Verifica inoltre che i font necessari e le risorse esterne siano presenti nell'ambiente in cui la presentazione convertita verrà aperta o renderizzata.

Per documenti importanti, riapri il PPTX generato programmaticamente e ispeziona il conteggio delle diapositive e il contenuto chiave, quindi confronta il suo aspetto e il comportamento della presentazione nello visualizzatore previsto. Non considerare una chiamata riuscita a [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/) come prova che ogni funzionalità legacy abbia una rappresentazione PPTX esatta.

## **Quando utilizzare PPTX**

Utilizza PPTX quando la presentazione sarà modificata nelle versioni attuali di PowerPoint, scambiata con sistemi che lavorano con pacchetti Open XML o memorizzata in un formato più facile da ispezionare e recuperare rispetto al binario legacy PPT. Conserva il PPT originale come copia archivistica o di ripristino finché la presentazione convertita non supera i tuoi controlli di fedeltà.

Se hai bisogno invece di PDF, HTML, immagini, XPS o un altro tipo di output, utilizza le indicazioni specifiche per il formato in [Convertire presentazioni in più formati](/slides/it/python-net/convert-presentation/) invece di presumere che tutte le destinazioni preservino le funzionalità modificabili di PowerPoint.

## **Convertitore online**

Per un file occasionale o un confronto rapido, è possibile utilizzare il [convertitore online da PPT a PPTX](https://products.aspose.app/slides/it/conversion/ppt-to-pptx). Per conversioni ripetibili, elaborazione batch o gestione degli errori a livello di applicazione, usa l'API Python.

## **Articoli correlati**

- [PPT vs PPTX](/slides/it/python-net/ppt-vs-pptx/)
- [Salva presentazioni in Python](/slides/it/python-net/save-presentation/)
- [Formati di file supportati](/slides/it/python-net/supported-file-formats/)
- [Apri presentazioni in Python](/slides/it/python-net/open-presentation/)

## **FAQ**

**Posso convertire PPT in PPTX senza Microsoft PowerPoint installato?**

Sì. Aspose.Slides per Python tramite .NET carica e salva i file di presentazione senza richiedere Microsoft PowerPoint.

**La conversione da PPT a PPTX preserva tutti i contenuti esattamente?**

Preserva i contenuti comuni di una presentazione, ma la fedeltà esatta non è garantita per ogni funzionalità legacy o non supportata. Controlla il file generato quando contiene macro, oggetti OLE o ActiveX, media, animazioni specializzate o font poco comuni.

**Posso convertire un file PPT protetto da password?**

Sì, se fornisci la password corretta durante il caricamento del file. Una password mancante o errata provoca il fallimento dell'operazione di caricamento.

**Devo eliminare il file PPT dopo la conversione?**

Conserva l'originale finché non hai verificato il PPTX nei visualizzatori e nei flussi di lavoro che ti interessano. Questo fornisce una copia di ripristino se una funzionalità legacy viene convertita in modo differente.