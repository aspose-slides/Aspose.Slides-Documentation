---
title: "Estrazione del testo delle diapositive: PPT, PPTX, ODP Fondamentali"
type: docs
weight: 10
url: /it/python-java/slide-text-extraction-ppt-pptx-odp-essentials/
keywords:
- piattaforme cloud
- estrazione del testo della presentazione
- estrazione del testo delle diapositive
- estrarre testo da PPT
- estrarre testo da PPTX
- estrarre testo da ODP
- Microsoft PowerPoint
- OpenDocument
- LibreOffice Impress
- Office Open XML
- indicizzazione per la ricerca
- automazione dei documenti
- analisi dei dati
- accessibilità
- Python
- Aspose.Slides
description: "Comprendere come PPT, PPTX e ODP memorizzano il testo delle diapositive e pianificare l'estrazione per la ricerca, l'automazione e la localizzazione con Aspose.Slides per Python tramite Java."
---
## **Introduzione**

L'estrazione del testo di una presentazione rende il contenuto delle diapositive disponibile per la ricerca, l'analisi, l'accessibilità e la localizzazione. In un'applicazione Python, il testo estratto può alimentare un indice, un sistema di gestione dei documenti o una pipeline di elaborazione linguistica. I worker cloud possono applicare lo stesso flusso di lavoro ai file ricevuti da upload o da storage di oggetti.

Questo articolo spiega come PPT, PPTX e ODP memorizzano il testo e come queste differenze influenzano l'estrazione. Aspose.Slides for Python via Java supporta il caricamento di tutti e tre i formati; vedere [Formati di file supportati](/slides/it/python-java/supported-file-formats/).

## **Applicazioni pratiche dell'estrazione del testo**

- **Flussi di lavoro documentali:** importare il contenuto della presentazione nei sistemi di gestione dei documenti e associarlo ai metadati del file originale.
- **Indicizzazione per la ricerca:** indicizzare il testo delle diapositive mantenendo il nome della presentazione e il numero della diapositiva per ogni risultato.
- **Analisi del contenuto:** identificare argomenti, termini e temi ricorrenti nei registri delle presentazioni.
- **Accessibilità e localizzazione:** fornire testo per strumenti assistivi o flussi di lavoro di traduzione, con una revisione aggiuntiva dell'ordine di lettura e del contesto.
- **Analisi del layout:** combinare il testo con le posizioni degli oggetti durante il controllo della struttura delle diapositive o la preparazione di un'esportazione strutturata.

## **Panoramica dei formati di presentazione**

### **PPT: Formato PowerPoint legacy**

PPT è il formato binario associato a PowerPoint 97–2003. I suoi record non possono essere elaborati come documenti XML. Un parser deve comprendere le strutture binarie e le loro relazioni per ricostruire il contenuto delle diapositive.

Il testo può comparire negli oggetti delle diapositive, nelle note e nei commenti. Un flusso di lavoro di estrazione dovrebbe definire quali di queste fonti includere, anziché trattare una presentazione come un unico flusso di testo continuo.

### **PPTX: Office Open XML**

PPTX è un pacchetto ZIP contenente parti XML e altre risorse. Il testo delle diapositive appare comunemente in `ppt/slides/it/slideX.xml` all'interno di elementi `a:t`. Le note sono archiviate in parti separate note-slide, e i commenti hanno le proprie parti collegate tramite relazioni del pacchetto.

Leggere solo gli elementi di testo dal XML della diapositiva può far perdere contenuti memorizzati altrove nel pacchetto. Inoltre non ricostruisce la formattazione o l'ordine di lettura. Un flusso di lavoro completo potrebbe dover considerare layout, forme raggruppate, tabelle, grafici e parti correlate.

### **ODP: Presentazione OpenDocument**

ODP è il formato di presentazione OpenDocument impacchettato utilizzato da applicazioni come LibreOffice Impress. Come PPTX, contiene XML all'interno di un pacchetto ZIP, ma utilizza il vocabolario e la struttura OpenDocument.

Il contenuto della presentazione è principalmente archiviato in `content.xml`. Il testo dei paragrafi utilizza elementi come `text:p`, con elementi annidati per span e altre caratteristiche del testo. Le query XML specifiche per PPTX quindi non possono essere riutilizzate direttamente per ODP.

## **Utilizzare un modello di presentazione comune in Python**

La classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) carica i file di presentazione supportati così il codice dell'applicazione può lavorare con diapositive e i loro oggetti senza implementare un parser binario o un pacchetto separato per ogni formato.

Prima di integrare l'estrazione in un worker cloud, seguire [Installazione](/slides/it/python-java/installation/). Per considerazioni su distribuzione e ciclo di vita della JVM, vedere [Slides su piattaforme cloud](/slides/it/python-java/slides-on-cloud-platforms/).

Tenere queste decisioni esplicite nella progettazione dell'estrazione:

- **Ambito del contenuto:** decidere come gestire il testo delle diapositive, le note, i commenti, le tabelle e le etichette dei grafici.
- **Ordine di lettura:** preservare i confini delle diapositive e utilizzare le informazioni di layout quando l'ordine degli oggetti è insufficiente.
- **Testo nelle immagini:** utilizzare un flusso di lavoro OCR separato quando il testo è incorporato in screenshot o diapositive scansionate.
- **Struttura dell'output:** mantenere gli identificatori di origine e scrivere il testo usando una codifica che supporti le lingue richieste, ad esempio UTF-8.

## **Conclusione**

PPT richiede la gestione di un formato binario, mentre PPTX e ODP utilizzano diverse strutture di pacchetti XML. Una libreria di presentazione fornisce un punto di partenza comune per lavorare con questi formati in Python. Definire l'ambito del contenuto e l'ordine di lettura aiuta a rendere il testo risultante utile per l'indicizzazione, l'analisi e la localizzazione.

## **FAQ**

**Posso estrarre il testo PPT decomprimendo il file?**

No. PPT utilizza una struttura binaria. L'approccio ZIP‑e‑XML si applica ai formati impacchettati come PPTX e ODP.

**Le note e i commenti sono archiviati insieme al testo principale della diapositiva in PPTX?**

Utilizzano parti del pacchetto separate. Leggere solo il XML della diapositiva non li include automaticamente.

**L'estrazione di testo semplice catturerà il testo all'interno di uno screenshot?**

No. Il testo dello screenshot è parte di un'immagine piuttosto che testo di diapositiva modificabile. Richiede OCR.