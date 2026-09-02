---
title: Converti PPT in PPTX in Python
linktitle: PPT in PPTX
type: docs
weight: 20
url: /it/python-net/convert-ppt-to-pptx/
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
- Aspose.Slides
description: "Converti i file PPT legacy in PPTX in Python con Aspose.Slides. Include esempi per conversione singola e batch, gestione degli errori e note sulla fedeltà."
---
## **Panoramica**

PPT è il formato binario legacy di PowerPoint, mentre PPTX è il formato Open XML più recente. Aspose.Slides for Python via .NET può caricare un file PPT e salvarlo come PPTX senza Microsoft PowerPoint. Questo articolo mostra come convertire un file o una directory di file e spiega cosa verificare dopo la conversione.

## **Convertire un file PPT in PPTX**

Carica il file di origine con la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/), quindi chiama [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/) con [SaveFormat.PPTX](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/saveformat/). L'istruzione `with` elimina la presentazione e rilascia le sue risorse al termine del blocco.

```python
import aspose.slides as slides

# Carica la presentazione PPT legacy.
with slides.Presentation("presentation.ppt") as presentation:
    # Salva la presentazione in formato PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

L'estensione del file non seleziona il formato di output da sola; lo fa l'argomento [SaveFormat.PPTX](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/saveformat/). Mantieni percorsi di input e output diversi se devi conservare il file PPT originale.

## **Convertire più file PPT**

L'esempio seguente converte ogni file `.ppt` in una directory. Ogni file è elaborato in modo indipendente, quindi una conversione fallita non interrompe il resto del batch.

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

Per carichi di lavoro di produzione, registra l'eccezione completa, decidi se un file di output esistente può essere sovrascritto e scrivi i nomi dei file non riusciti in una coda di ripetizione o revisione. File corrotti, file protetti da password aperti senza la password richiesta, percorsi inaccessibili e contenuti non supportati possono tutti causare un fallimento della conversione. Vedi [Presentazioni protette da password](/python-net/password-protected-presentation/) per caricare file crittografati.

## **Fedeltà e funzionalità legacy**

La conversione normalmente preserva diapositive, master, layout, testo, forme, immagini, tabelle e grafici. Tuttavia, PPT e PPTX non rappresentano ogni funzionalità esattamente allo stesso modo. Una funzionalità legacy che non ha un equivalente PPTX, o non è supportata dalla libreria, può essere normalizzata, omessa o visualizzata diversamente.

Verifica il file convertito quando contiene animazioni, transizioni, oggetti OLE incorporati o collegati, controlli ActiveX, media incorporati, caratteri insoliti o macro VBA. Un file PPTX semplice non è un formato abilitato alle macro, quindi utilizza un flusso di lavoro appropriato abilitato alle macro quando VBA deve rimanere disponibile. Verifica inoltre che i caratteri richiesti e le risorse esterne siano presenti nell'ambiente in cui la presentazione convertita verrà aperta o renderizzata.

Per documenti importanti, riapri il PPTX generato programmaticamente e ispeziona il numero chiave di diapositive e il contenuto, quindi confronta l'aspetto e il comportamento della presentazione nello spettatore previsto. Non considerare una chiamata riuscita a [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/) come prova che ogni funzionalità legacy abbia una rappresentazione PPTX esatta.

## **Quando utilizzare PPTX**

Utilizza PPTX quando la presentazione verrà modificata nelle versioni attuali di PowerPoint, scambiata con sistemi che lavorano con pacchetti Open XML, o archiviata in un formato più facile da ispezionare e recuperare rispetto al legacy binario PPT. Conserva il PPT originale come copia di archivio o di ripristino finché la presentazione convertita non supera i tuoi controlli di fedeltà.

Se invece hai bisogno di PDF, HTML, immagini, XPS o un altro tipo di output, utilizza le indicazioni specifiche per formato in [Convertire le presentazioni in più formati](/python-net/convert-presentation/) invece di presumere che tutti i target conservino le funzionalità modificabili di PowerPoint.

## **Convertitore online**

Per un file occasionale o un confronto rapido, puoi utilizzare il [convertitore online da PPT a PPTX](https://products.aspose.app/slides/it/conversion/ppt-to-pptx). Per conversioni ripetibili, elaborazione batch o gestione degli errori a livello di applicazione, usa l'API Python.

## **Articoli correlati**

- [PPT vs PPTX](/python-net/ppt-vs-pptx/)
- [Salva presentazioni in Python](/python-net/save-presentation/)
- [Formati di file supportati](/python-net/supported-file-formats/)
- [Apri presentazioni in Python](/python-net/open-presentation/)

## **FAQ**

**Posso convertire PPT in PPTX senza Microsoft PowerPoint installato?**

Sì. Aspose.Slides for Python via .NET carica e salva i file di presentazione senza richiedere Microsoft PowerPoint.

**La conversione da PPT a PPTX preserva esattamente tutti i contenuti?**

Preserva il contenuto comune delle presentazioni, ma la fedeltà esatta non è garantita per ogni funzionalità legacy o non supportata. Rivedi il file generato quando contiene macro, oggetti OLE o ActiveX, media, animazioni specializzate o caratteri poco comuni.

**Posso convertire un file PPT protetto da password?**

Sì, se fornisci la password corretta al momento del caricamento del file. Una password mancante o errata provoca il fallimento dell'operazione di caricamento.

**Devo eliminare il file PPT dopo la conversione?**

Conserva l'originale finché non hai verificato il PPTX negli visualizzatori e nei flussi di lavoro che ti interessano. Questo fornisce una copia di ripristino se una funzionalità legacy viene convertita in modo diverso.