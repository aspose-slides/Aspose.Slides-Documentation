---
title: Gestisci Tag e Dati Personalizzati nelle Presentazioni con Python
linktitle: Tag e Dati Personalizzati
type: docs
weight: 300
url: /it/python-net/managing-tags-and-custom-data/
keywords:
- proprietà del documento
- tag
- dati personalizzati
- aggiungi tag
- coppie di valori
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri come aggiungere, leggere, aggiornare e rimuovere tag e dati personalizzati in Aspose.Slides per Python via .NET, con esempi per presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Questo articolo spiega come Aspose.Slides gestisce i tag e i dati personalizzati nelle presentazioni PowerPoint. Descrive brevemente come i dati sono archiviati nei file PPTX, osserva che i dati specifici della presentazione possono esistere come tag e parti XML personalizzate, e descrive i tag come coppie di stringhe chiave‑valore.

Mostra inoltre come leggere i valori dei tag e come aggiungere tag a una presentazione, a una singola diapositiva o a una forma. Inoltre, l'articolo copre le operazioni comuni di gestione dei tag, come cancellare tutti i tag, rimuovere un tag per nome e recuperare l'elenco dei nomi dei tag.

## **Archiviazione dei dati nei file di presentazione**

I file PPTX — elementi con estensione .pptx — sono archiviati nel formato PresentationML, che fa parte della specifica Office Open XML. Il formato Office Open XML definisce la struttura per i dati contenuti nelle presentazioni. 

Con una *diapositiva* che è uno degli elementi delle presentazioni, una *parte di diapositiva* contiene il contenuto di una singola diapositiva. Una parte di diapositiva può avere relazioni esplicite con molte parti — come i Tag definiti dall'utente — definite da ISO/IEC 29500. 

Dati personalizzati (specifici a una presentazione) o dell'utente possono esistere come tag ([ITagCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/itagcollection/)) e CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/icustomxmlpartcollection/)). 

{{% alert color="primary" %}} 

I tag sono essenzialmente coppie chiave‑valore di stringa. 

{{% /alert %}} 

## **Ottenere i valori dei tag**

Nelle diapositive, un tag corrisponde alla proprietà IDocumentProperties.Keywords. Questo esempio di codice mostra come ottenere il valore di un tag con Aspose.Slides per Python via .NET per [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **Aggiungere tag alle presentazioni**

Aspose.Slides consente di aggiungere tag alle presentazioni. Un tag tipicamente consiste di due elementi:

- il nome di una proprietà personalizzata - `MyTag` 
- il valore della proprietà personalizzata - `My Tag Value`

Se è necessario classificare alcune presentazioni in base a una regola o proprietà specifica, è possibile beneficiare dell'aggiunta di tag a tali presentazioni. Ad esempio, se si desidera raggruppare tutte le presentazioni dei paesi del Nord America, è possibile creare un tag North American e quindi assegnare i paesi pertinenti (Stati Uniti, Messico e Canada) come valori. 

Questo esempio di codice mostra come aggiungere un tag a una [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) usando Aspose.Slides per Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

I tag possono anche essere impostati per [Slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

O qualsiasi [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/) individuale:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Limitazioni**

I tag aggiunti tramite la collezione `custom_data.tags` vengono archiviati solo all'interno del file PowerPoint. Non vengono **trasferiti** nella struttura dei tag PDF quando la presentazione viene esportata in PDF. Di conseguenza, un identificatore personalizzato assegnato come tag non può essere recuperato dal PDF con tag.

**Soluzione alternativa**: è possibile archiviare un identificatore personalizzato nell'**Alt Text** dell'oggetto (ad es., `shape.alternative_text = "MyId"`). Dopo l'esportazione in PDF, l'Alt Text può apparire nella struttura dei tag PDF.

## **FAQ**

**Posso rimuovere tutti i tag da una presentazione, diapositiva o forma in un'unica operazione?**

Sì. La [collezione di tag](https://reference.aspose.com/slides/it/python-net/aspose.slides/tagcollection/) supporta un'operazione [clear](https://reference.aspose.com/slides/it/python-net/aspose.slides/tagcollection/clear/) che elimina tutte le coppie chiave‑valore in una volta.

**Come posso eliminare un singolo tag per nome senza iterare sull'intera collezione?**

Utilizzare l'operazione [remove(name)](https://reference.aspose.com/slides/it/python-net/aspose.slides/tagcollection/remove/) sulla [TagCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/tagcollection/) per cancellare il tag mediante la sua chiave.

**Come posso recuperare l'elenco completo dei nomi dei tag per analisi o filtraggio?**

Utilizzare [get_names_of_tags](https://reference.aspose.com/slides/it/python-net/aspose.slides/tagcollection/get_names_of_tags/) sulla [collezione di tag](https://reference.aspose.com/slides/it/python-net/aspose.slides/tagcollection/); restituisce un array di tutti i nomi dei tag.