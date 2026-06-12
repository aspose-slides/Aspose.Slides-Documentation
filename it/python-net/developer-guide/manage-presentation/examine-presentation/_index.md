---
title: Recuperare e aggiornare le informazioni della presentazione in Python
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
description: "Esplora diapositive, struttura e metadati nelle presentazioni PowerPoint e OpenDocument usando Python per ottenere approfondimenti più rapidi e audit di contenuto più intelligenti."
---
## **Panoramica**

Questo articolo mostra come ispezionare le informazioni di una presentazione in Aspose.Slides. Spiega come determinare il formato corrente di una presentazione senza caricare l'intero file, leggere le sue proprietà del documento e aggiornare tali proprietà quando necessario.

Gli esempi si basano sulle API [PresentationInfo](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/) e dimostrano le operazioni tipiche per lavorare con i metadati delle presentazioni.

## **Verifica del formato di una presentazione**

Prima di lavorare su una presentazione, potresti voler scoprire in quale formato (PPT, PPTX, ODP e altri) si trovi attualmente la presentazione.

Puoi verificare il formato di una presentazione senza caricare la presentazione. Vedi questo codice Python:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Ottieni le proprietà della presentazione**

Questo codice Python mostra come ottenere le proprietà della presentazione (informazioni sulla presentazione):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Potresti voler vedere le proprietà nella classe [DocumentProperties](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/#properties).

## **Aggiorna le proprietà della presentazione**

Aspose.Slides fornisce il metodo [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) che consente di apportare modifiche alle proprietà della presentazione.

Supponiamo di avere una presentazione PowerPoint con le proprietà del documento mostrate di seguito.

![Proprietà originali del documento della presentazione PowerPoint](input_properties.png)

Questo esempio di codice mostra come modificare alcune proprietà della presentazione:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

I risultati della modifica delle proprietà del documento sono mostrati di seguito.

![Proprietà del documento modificate della presentazione PowerPoint](output_properties.png)

## **Link utili**

Per ottenere maggiori informazioni su una presentazione e sui suoi attributi di sicurezza, questi link potrebbero esserti utili:

- [Verifica se una presentazione è crittografata](https://docs.aspose.com/slides/it/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Verifica se una presentazione è protetta da scrittura (sola lettura)](https://docs.aspose.com/slides/it/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Verifica se una presentazione è protetta da password prima di caricarla](https://docs.aspose.com/slides/it/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Conferma della password usata per proteggere una presentazione](https://docs.aspose.com/slides/it/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Domande frequenti**

**Come posso verificare se i font sono incorporati e quali sono?**

Cerca le informazioni sui [embedded-font information](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) a livello di presentazione, quindi confronta queste voci con l'insieme dei [fonts actually used across content](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_fonts/) per identificare quali font sono critici per il rendering.

**Come posso capire rapidamente se il file contiene diapositive nascoste e quante?**

Itera attraverso la [slide collection](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/) e ispeziona il [visibility flag](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/hidden/) di ciascuna diapositiva.

**Posso rilevare se è stata usata una dimensione e un'orientazione della diapositiva personalizzate e se differiscono dai valori predefiniti?**

Sì. Confronta la [slide size](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/slide_size/) attuale e l'orientamento con le impostazioni standard; ciò aiuta a prevedere il comportamento per stampa ed esportazione.

**Esiste un modo rapido per verificare se i grafici fanno riferimento a sorgenti dati esterne?**

Sì. Attraversa tutti i [charts](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/), controlla la loro [data source](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/data_source_type/) e annota se i dati sono interni o basati su collegamenti, inclusi eventuali link interrotti.

**Come posso valutare le diapositive 'pesanti' che potrebbero rallentare il rendering o l'esportazione PDF?**

Per ogni diapositiva, conta gli oggetti e individua immagini di grandi dimensioni, trasparenze, ombre, animazioni e contenuti multimediali; assegna un punteggio di complessità approssimativo per segnalare potenziali colli di bottiglia.