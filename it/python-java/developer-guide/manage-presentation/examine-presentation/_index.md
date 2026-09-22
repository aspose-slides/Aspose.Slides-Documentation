---
title: Recuperare e aggiornare le informazioni della presentazione in Python tramite Java
linktitle: Informazioni sulla presentazione
type: docs
weight: 30
url: /it/python-java/examine-presentation/
keywords:
- formato presentazione
- proprietà della presentazione
- proprietà del documento
- ottenere proprietà
- leggere proprietà
- modificare proprietà
- modificare proprietà
- aggiornare proprietà
- esaminare PPTX
- esaminare PPT
- esaminare ODP
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Esplora diapositive, struttura e metadati nelle presentazioni PowerPoint e OpenDocument utilizzando Python tramite Java per ottenere approfondimenti più rapidi e audit dei contenuti più intelligenti."
---
## **Panoramica**

Aspose.Slides può identificare il formato di una presentazione e leggere i metadati del documento senza creare un modello completo di oggetti della presentazione. Questo è utile quando è necessario classificare i file, creare un inventario o ispezionare le proprietà prima di decidere se caricare ed elaborare il contenuto della presentazione.

Gli esempi richiedono Aspose.Slides per Python tramite Java e un runtime Java compatibile. Ogni esempio avvia la JVM se non è già in esecuzione. Fornire i file di presentazione esistenti nei percorsi utilizzati negli esempi.

Questo articolo dimostra l'ispezione leggera tramite [PresentationFactory](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationfactory/) e [PresentationInfo](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/), nonché aggiornamenti mirati tramite [DocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/).

## **Verifica il formato di una presentazione**

Se hai già una presentazione caricata, vedi [Determinare il formato originale della presentazione](/slides/it/python-java/detect-presentation-source-format/) per la rilevazione dopo il caricamento e le limitazioni dei flussi legacy PPT, PPS e POT.

Usa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationfactory/#getPresentationInfo) per ispezionare un file senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/). Il metodo [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#getLoadFormat) restituisce il formato rilevato, ad esempio PPTX, PPT o ODP.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **Crea un inventario leggero di presentazioni**

Quando elabori molti file di presentazione, potresti aver bisogno di un inventario compatto per la convalida, l'indicizzazione o un sistema di gestione dei documenti. In questo scenario, usa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationfactory/#getPresentationInfo) per ottenere un oggetto [PresentationInfo](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/), quindi chiama [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#readDocumentProperties) per leggere i metadati del documento. Questo approccio non crea un'istanza di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) né richiede di attraversare l'intero modello di oggetti della presentazione.

Le proprietà estese esposte da [DocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/) forniscono i seguenti valori di inventario:

| Metodo | Valore dell'inventario |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/#getSlides) | Numero totale di diapositive. |
| [getHiddenSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/#getHiddenSlides) | Numero di diapositive nascoste. |
| [getNotes](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/#getNotes) | Numero di diapositive che contengono note. |
| [getParagraphs](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/#getParagraphs) | Numero totale di paragrafi, se disponibile. |
| [getWords](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/#getWords) | Numero totale di parole. |
| [getMultimediaClips](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Numero totale di clip audio e video. |

Il seguente esempio legge questi valori senza creare un oggetto [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e stampa un inventario compatto. Combina inoltre [getHeadingPairs](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/#getHeadingPairs) con [getTitlesOfParts](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/#getTitlesOfParts) per visualizzare gruppi di contenuto come caratteri, temi e titoli delle diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
            if part_index >= len(titles_of_parts):
                break
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

Ogni [HeadingPair](https://reference.aspose.com/slides/it/python-java/aspose.slides/headingpair/) fornisce un nome di gruppo e il numero di elementi in quel gruppo. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/#getTitlesOfParts) restituisce un array piatto e ordinato, quindi consumare il numero di titoli consecutivi specificati da ciascuna coppia di intestazioni.

### **Metadati archiviati e limitazioni del formato**

Le proprietà dell'inventario restituite da [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#readDocumentProperties) riflettono i metadati disponibili nel documento di origine. Aspose.Slides non carica e attraversa il modello di oggetti della presentazione per ricalcolare questi valori per questa chiamata. Le proprietà mancanti sono rappresentate da valori predefiniti e i valori archiviati possono essere obsoleti se l'applicazione che ha salvato per ultima il file non ha aggiornato le proprietà del documento.

- **PPTX:** Il formato fornisce proprietà di documento estese per conteggi di diapositive, note, diapositive nascoste, paragrafi, parole e multimedialità, nonché coppie di intestazioni e titoli delle parti. La disponibilità dipende dalle proprietà scritte dal produttore del documento.
- **PPT:** Il formato binario può memorizzare le corrispondenti proprietà di riepilogo del documento. Se una proprietà è assente o non è stata aggiornata dal produttore del documento, Aspose.Slides restituisce il valore archiviato o predefinito anziché calcolarlo dalle diapositive.
- **ODP:** I metadati OpenDocument forniscono statistiche generali del documento, come conteggi di pagine, paragrafi e parole, ma questi valori non corrispondono a tutte le proprietà estese specifiche di PowerPoint. I metadati di diapositive nascoste, note, multimedialità, coppie di intestazioni e titoli delle parti potrebbero non essere disponibili e le proprietà dell'inventario potrebbero restituire valori predefiniti. Non considerare un valore zero o un array vuoto come prova autorevole che il contenuto corrispondente sia assente.

Utilizza l'approccio di metadati leggeri per inventari e controlli preliminari. Carica la presentazione e ispeziona il suo modello di oggetti live quando il risultato deve riflettere le modifiche in memoria o quando è necessario verificare il contenuto reale della presentazione.

## **Aggiorna le proprietà della presentazione**

Le proprietà restituite da [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#readDocumentProperties) possono anche essere modificate senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/). Applica le modifiche con [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) e quindi scrivi la presentazione associata con [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#writeBindedPresentation).

L'immagine seguente mostra le proprietà originali del documento della presentazione PowerPoint.

![Proprietà originali del documento della presentazione PowerPoint](input_properties.png)

Il seguente esempio modifica il titolo e l'ora dell'ultimo salvataggio e scrive il risultato in un nuovo file:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

L'immagine seguente mostra le proprietà del documento aggiornate della presentazione PowerPoint.

![Proprietà del documento aggiornate della presentazione PowerPoint](output_properties.png)

## **Link utili**

Per controlli di sicurezza correlati e impostazioni di protezione, consulta i seguenti articoli:

- [Proteggi con password le presentazioni](/slides/it/python-java/password-protected-presentation/)
- [Proteggi le presentazioni in scrittura](/slides/it/python-java/write-protected-presentation/)

## **FAQ**

**Come posso verificare se i caratteri sono incorporati e quali sono?**

Carica la presentazione e usa [Presentation.getFontsManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getFontsManager). Chiama [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) per ottenere i caratteri incorporati e [FontsManager.getFonts](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#getFonts) per ottenere i caratteri utilizzati dalla presentazione. Confronta i due risultati per trovare i caratteri necessari per il rendering ma non incorporati.

**Come posso rapidamente capire se il file ha diapositive nascoste e quanti?**

Quando i metadati del documento archiviati sono sufficienti, leggi [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/#getHiddenSlides) tramite [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationfactory/#getPresentationInfo) e [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#readDocumentProperties). Questo è adatto per un inventario leggero. Se la presentazione è stata modificata in memoria, i metadati archiviati potrebbero mancare o essere obsoleti, o se devi verificare i valori live, itera attraverso [Presentation.getSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSlides) e ispeziona il metodo [Slide.getHidden](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getHidden) di ogni diapositiva.

**Posso rilevare se vengono usate dimensioni e orientamento diapositive personalizzati e se differiscono dalle impostazioni predefinite?**

Sì. Carica la presentazione e chiama [Presentation.getSlideSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSlideSize). Usa [SlideSize.getType](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidesize/#getSize) e [SlideSize.getOrientation](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidesize/#getOrientation) per confrontare le impostazioni attuali con il preset e le dimensioni attese.

**Esiste un modo rapido per verificare se i grafici fanno riferimento a fonti di dati esterne?**

Sì. Individua ogni [Chart](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/) e chiama [ChartData.getDataSourceType](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdata/#getDataSourceType). Per una cartella di lavoro esterna, chiama [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Il tipo di origine dati e il percorso identificano un riferimento esterno, ma verificare se la destinazione è disponibile richiede un controllo di risorse separato.

**Come posso valutare le diapositive 'pesanti' che potrebbero rallentare il rendering o l'esportazione PDF?**

Non esiste una singola proprietà di complessità. Attraversa [Presentation.getSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSlides) e la collezione [BaseSlide.getShapes](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/#getShapes) di ogni diapositiva. Usa il conteggio delle forme e la presenza di immagini grandi, effetti, animazioni o contenuti multimediali come segnali di screening, e misura un rendering o un'esportazione rappresentativa prima di considerare una diapositiva come un collo di bottiglia di prestazioni confermato.