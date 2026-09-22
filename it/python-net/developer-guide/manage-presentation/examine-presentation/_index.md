---
title: Recupera e aggiorna le informazioni della presentazione in Python
linktitle: Informazioni sulla presentazione
type: docs
weight: 30
url: /it/python-net/examine-presentation/
keywords:
- formato della presentazione
- proprietà della presentazione
- proprietà del documento
- ottenere proprietà
- leggere proprietà
- cambiare proprietà
- modificare proprietà
- aggiornare proprietà
- esaminare PPTX
- esaminare PPT
- esaminare ODP
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Esplora diapositive, struttura e metadati in presentazioni PowerPoint e OpenDocument usando Python per approfondimenti più rapidi e audit dei contenuti più intelligenti."
---
## **Panoramica**

Aspose.Slides può identificare il formato di una presentazione e leggere i metadati del documento senza creare un modello completo di oggetti della presentazione. Questo è utile quando è necessario classificare i file, creare un inventario o ispezionare le proprietà prima di decidere se caricare ed elaborare il contenuto della presentazione.

Questo articolo dimostra l'ispezione leggera tramite [PresentationFactory](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationfactory/) e [PresentationInfo](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/), nonché aggiornamenti mirati tramite [DocumentProperties](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/).

## **Verifica il formato di una presentazione**

Se hai già una presentazione caricata, consulta [Determine the Original Presentation Format](/slides/it/python-net/detect-presentation-source-format/) per la rilevazione dopo il caricamento e le limitazioni dei flussi legacy PPT, PPS e POT.

Usa [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationfactory/get_presentation_info/) per ispezionare un file senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/). La proprietà [PresentationInfo.load_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/load_format/) restituisce il formato rilevato, ad esempio PPTX, PPT o ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Crea un inventario di presentazioni leggero**

Quando elabori molti file di presentazione, potresti aver bisogno di un inventario compatto per la validazione, l'indicizzazione o un sistema di gestione documenti. In questo scenario, usa [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationfactory/get_presentation_info/) per ottenere un oggetto [PresentationInfo](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/), quindi chiama [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/read_document_properties/) per leggere i metadati del documento. Questo approccio non crea un'istanza di [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) né richiede l'attraversamento del modello completo di oggetti della presentazione.

Le proprietà estese esposte da [DocumentProperties](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/) forniscono i seguenti valori di inventario:

| Proprietà | Valore dell'inventario |
| --- | --- |
| [slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/slides/it/) | Numero totale di diapositive. |
| [hidden_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/hidden_slides/) | Numero di diapositive nascoste. |
| [notes](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/notes/) | Numero di diapositive che contengono note. |
| [paragraphs](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/paragraphs/) | Numero totale di paragrafi, se disponibile. |
| [words](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/words/) | Numero totale di parole. |
| [multimedia_clips](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/multimedia_clips/) | Numero totale di clip audio e video. |

Il seguente esempio legge questi valori senza creare un oggetto [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e stampa un inventario compatto. Combina inoltre [heading_pairs](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/heading_pairs/) con [titles_of_parts](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/titles_of_parts/) per visualizzare gruppi di contenuto come caratteri, temi e titoli delle diapositive.

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
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

Ogni [HeadingPair](https://reference.aspose.com/slides/it/python-net/aspose.slides/headingpair/) fornisce un nome di gruppo e il numero di elementi in quel gruppo. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/titles_of_parts/) è una collezione piatta e ordinata, quindi consuma il numero di titoli consecutivi specificati da ciascuna coppia di intestazione.

### **Metadati memorizzati e limitazioni del formato**

Le proprietà dell'inventario restituite da [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/read_document_properties/) riflettono i metadati disponibili nel documento di origine. Aspose.Slides non carica e attraversa il modello di oggetti della presentazione per ricalcolare questi valori per questa chiamata. Le proprietà mancanti sono rappresentate da valori predefiniti e i valori memorizzati potrebbero essere obsoleti se l'applicazione che ha salvato per ultima il file non ha aggiornato le sue proprietà documento.

- **PPTX:** Il formato fornisce proprietà di documento estese per conteggi di slide, note, slide nascoste, paragrafi, parole e multimedia, nonché coppie di intestazioni e titoli delle parti. La disponibilità dipende dalle proprietà scritte dal produttore del documento.
- **PPT:** Il formato binario può memorizzare le corrispondenti proprietà di riepilogo del documento. Se una proprietà è assente o non è stata aggiornata dal produttore del documento, Aspose.Slides restituisce il valore memorizzato o predefinito invece di calcolarlo dalle diapositive.
- **ODP:** I metadati OpenDocument forniscono statistiche generali del documento, come conteggi di pagine, paragrafi e parole, ma questi valori non corrispondono a tutte le proprietà estese specifiche di PowerPoint. Le proprietà di metadati per slide nascoste, note, multimedia, coppie di intestazioni e titoli delle parti potrebbero non essere disponibili, e le proprietà dell'inventario possono restituire valori predefiniti. Non considerare un valore zero o una collezione vuota come prova autorevole che il contenuto corrispondente sia assente.

Usa l'approccio basato su metadati leggeri per gli inventari e i controlli preliminari. Carica la presentazione e ispeziona il suo modello di oggetti live quando il risultato deve riflettere le modifiche in memoria o quando è necessario verificare il contenuto reale della presentazione.

## **Aggiorna le proprietà della presentazione**

Le proprietà restituite da [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/read_document_properties/) possono anche essere modificate senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/). Applica le modifiche con [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/update_document_properties/), quindi scrivi la presentazione collegata con [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

L'immagine seguente mostra le proprietà del documento originale.

![Proprietà del documento originale della presentazione PowerPoint](input_properties.png)

L'esempio seguente modifica il titolo e l'ora dell'ultimo salvataggio e scrive il risultato in un nuovo file:

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

L'immagine seguente mostra le proprietà del documento modificate.

![Proprietà del documento modificate della presentazione PowerPoint](output_properties.png)

## **Link utili**

Per controlli di sicurezza correlati e impostazioni di protezione, consulta i seguenti articoli:

- [Password-Protect Presentations](/slides/it/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/it/python-net/write-protected-presentation/)

## **FAQ**

**Come posso verificare se i font sono incorporati e quali sono?**

Carica la presentazione e utilizza [Presentation.fonts_manager](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/fonts_manager/). Chiama [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) per ottenere i font incorporati e [FontsManager.get_fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_fonts/) per ottenere i font utilizzati dalla presentazione. Confronta i due risultati per individuare i font necessari per il rendering ma non incorporati.

**Come posso capire rapidamente se il file contiene diapositive nascoste e quante?**

Quando i metadati del documento memorizzati sono sufficienti, leggi [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/hidden_slides/) tramite [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationfactory/get_presentation_info/) e [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/read_document_properties/). Questo è adatto per un inventario leggero. Se la presentazione è stata modificata in memoria, i metadati memorizzati potrebbero mancare o essere obsoleti, o se devi verificare i valori live, itera attraverso [Presentation.slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/slides/it/) e controlla la proprietà [Slide.hidden](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/hidden/) di ciascuna diapositiva.

**Posso rilevare se sono usate dimensioni e orientamento personalizzati della diapositiva e se differiscono dalle impostazioni predefinite?**

Sì. Carica la presentazione e leggi [Presentation.slide_size](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/slide_size/). Ispeziona [SlideSize.type](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidesize/size/) e [SlideSize.orientation](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidesize/orientation/) per confrontare le impostazioni correnti con il preset e le dimensioni attese.

**Esiste un modo rapido per vedere se i grafici fanno riferimento a fonti dati esterne?**

Sì. Individua ogni [Chart](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/) e ispeziona [ChartData.data_source_type](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/data_source_type/). Per una cartella di lavoro esterna, leggi [ChartData.external_workbook_path](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Il tipo di fonte dati e il percorso identificano un riferimento esterno, ma verificare se il target è disponibile richiede un controllo di risorse separato.

**Come posso valutare le diapositive "pesanti" che potrebbero rallentare il rendering o l'esportazione in PDF?**

Non esiste una singola proprietà di complessità. Attraversa [Presentation.slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/slides/it/) e la collezione [BaseSlide.shapes](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslide/shapes/) di ciascuna diapositiva. Usa i conteggi delle forme e la presenza di immagini grandi, effetti, animazioni o multimedia come segnali di screening, e misura un rendering o un'esportazione rappresentativa prima di considerare una diapositiva un colpo di bottiglia confermato delle prestazioni.