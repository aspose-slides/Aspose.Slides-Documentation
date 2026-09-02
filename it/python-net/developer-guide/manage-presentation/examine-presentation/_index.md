---
title: Recuperare e Aggiornare le Informazioni sulla Presentazione in Python
linktitle: Informazioni sulla Presentazione
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
description: "Esplora diapositive, struttura e metadati nelle presentazioni PowerPoint e OpenDocument usando Python per ottenere rapidamente approfondimenti e audit di contenuto più intelligenti."
---
## **Panoramica**

Questo articolo mostra come ispezionare le informazioni di presentazione in Aspose.Slides. Spiega come determinare il formato corrente di una presentazione senza caricare l’intero file, leggere le sue proprietà del documento e aggiornare tali proprietà quando necessario.

Gli esempi si basano sulle API [PresentationInfo](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/) e dimostrano operazioni tipiche per lavorare con i metadati delle presentazioni.

## **Verificare il formato di una presentazione**

Prima di lavorare su una presentazione, potresti voler scoprire in quale formato (PPT, PPTX, ODP e altri) si trovi al momento.

Puoi verificare il formato di una presentazione senza caricarla. Vedi questo codice Python:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Ottenere le proprietà della presentazione**

Questo codice Python mostra come ottenere le proprietà della presentazione (informazioni sulla presentazione):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Potresti voler vedere le [properties under the DocumentProperties](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/#properties) class.

## **Aggiornare le proprietà della presentazione**

Aspose.Slides fornisce il metodo [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) che consente di modificare le proprietà della presentazione.

Supponiamo di avere una presentazione PowerPoint con le proprietà del documento illustrate di seguito.

![Proprietà originali del documento della presentazione PowerPoint](input_properties.png)

Questo esempio di codice mostra come modificare alcune proprietà della presentazione:

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

I risultati della modifica delle proprietà del documento sono mostrati di seguito.

![Proprietà modificate del documento della presentazione PowerPoint](output_properties.png)

## **Link utili**

Per ottenere ulteriori informazioni su una presentazione e sui suoi attributi di sicurezza, potresti trovare questi collegamenti utili:

- [Password-Protect Presentations](/slides/it/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/it/python-net/write-protected-presentation/)

## **FAQ**

**Come posso verificare se i font sono incorporati e quali sono?**

Cerca le informazioni sui [embedded-font](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) a livello di presentazione, quindi confronta tali voci con l’insieme dei [fonts actually used across content](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_fonts/) per identificare quali font sono critici per il rendering.

**Come posso capire rapidamente se il file contiene diapositive nascoste e quante sono?**

Itera attraverso la [slide collection](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/) e ispeziona il [visibility flag](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/hidden/) di ogni diapositiva.

**Posso rilevare se è stato usato un formato di diapositiva personalizzato e se differisce dalle impostazioni predefinite?**

Sì. Confronta le attuali [slide size](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/slide_size/) e l’orientamento con i preset standard; questo aiuta a prevedere il comportamento per stampa ed esportazione.

**Esiste un modo rapido per vedere se i grafici fanno riferimento a fonti dati esterne?**

Sì. Scorri tutti i [charts](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/), verifica il loro [data source](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/data_source_type/) e annota se i dati sono interni o basati su collegamenti, includendo eventuali link interrotti.

**Come posso valutare le diapositive “pesanti” che potrebbero rallentare il rendering o l’esportazione PDF?**

Per ogni diapositiva, conta gli oggetti e cerca immagini di grandi dimensioni, trasparenze, ombre, animazioni e contenuti multimediali; assegna un punteggio di complessità approssimativo per segnalare potenziali colli di bottiglia delle prestazioni.