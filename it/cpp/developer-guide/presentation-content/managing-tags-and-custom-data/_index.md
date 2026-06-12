---
title: Gestire i tag e i dati personalizzati nelle presentazioni usando C++
linktitle: Tag e dati personalizzati
type: docs
weight: 300
url: /it/cpp/managing-tags-and-custom-data/
keywords:
- proprietà del documento
- tag
- dati personalizzati
- aggiungere tag
- coppie di valori
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come aggiungere, leggere, aggiornare e rimuovere tag e dati personalizzati in Aspose.Slides per C++, con esempi per presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Questo articolo spiega come Aspose.Slides gestisce i tag e i dati personalizzati nelle presentazioni PowerPoint. Descrive brevemente come i dati sono archiviati nei file PPTX, osserva che i dati specifici della presentazione possono esistere come tag e parti XML personalizzate, e definisce i tag come coppie stringa chiave‑valore.

Mostra inoltre come leggere i valori dei tag e come aggiungere tag a una presentazione, a una singola slide o a una shape. Inoltre, l'articolo tratta le operazioni comuni di gestione dei tag, come cancellare tutti i tag, rimuovere un tag per nome e recuperare l'elenco dei nomi dei tag.

## **Archiviazione dati nei file di presentazione**

I file PPTX—elementi con estensione .pptx—sono memorizzati nel formato PresentationML, parte della specifica Office Open XML. Il formato Office Open XML definisce la struttura dei dati contenuti nelle presentazioni.

Con una *slide* che è uno degli elementi delle presentazioni, una *slide part* contiene il contenuto di una singola slide. Una slide part può avere relazioni esplicite con molte parti—come i User Defined Tags—definite da ISO/IEC 29500.

I dati personalizzati (specifici di una presentazione) o dell'utente possono esistere come tag ([ITagCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/itagcollection/)) e CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/icustomxmlpartcollection/)).

{{% alert color="primary" %}} 
I tag sono essenzialmente coppie chiave‑valore di stringa. 
{{% /alert %}} 

## **Ottenere i valori dei tag**

In slides, un tag corrisponde alla proprietà IDocumentProperties.Keywords. Questo esempio di codice mostra come ottenere il valore di un tag con Aspose.Slides per C++ per la [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/):

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **Aggiungere tag alle presentazioni**

Aspose.Slides consente di aggiungere tag alle presentazioni. Un tag tipicamente è composto da due elementi: 

- il nome di una proprietà personalizzata - `MyTag` 
- il valore della proprietà personalizzata - `My Tag Value`

Se è necessario classificare alcune presentazioni in base a una regola o proprietà specifica, è possibile trarre vantaggio dall'aggiungere tag a quelle presentazioni. Ad esempio, se vuoi raggruppare tutte le presentazioni provenienti dai paesi del Nord America, puoi creare un tag "North American" e assegnare ai valori i paesi rilevanti (USA, Messico e Canada). 

Questo esempio di codice mostra come aggiungere un tag a una [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) usando Aspose.Slides per C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

I tag possono anche essere impostati per la [Slide](https://reference.aspose.com/slides/it/cpp/aspose.slides/slide/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

O per qualsiasi [Shape](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/) individuale:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Limitazioni**

I tag aggiunti tramite la collezione di tag dei dati personalizzati usando `get_CustomData()->get_Tags()` sono memorizzati solo all'interno del file PowerPoint. Non vengono **trasferiti** alla struttura dei tag PDF quando la presentazione viene esportata in PDF. Di conseguenza, un identificatore personalizzato assegnato come tag non può essere recuperato dal PDF taggato.

**Soluzione alternativa**: è possibile memorizzare un identificatore personalizzato nel **Alt Text** dell'oggetto (ad esempio, `shape->set_AlternativeText(u"MyId")`). Dopo l'esportazione in PDF, l'Alt Text può apparire nella struttura dei tag PDF.

## **FAQ**

**Posso rimuovere tutti i tag da una presentazione, slide o shape in un'unica operazione?**

Sì. La [tag collection](https://reference.aspose.com/slides/it/cpp/aspose.slides/tagcollection/) supporta l'operazione [clear](https://reference.aspose.com/slides/it/cpp/aspose.slides/tagcollection/clear/) che elimina tutte le coppie chiave‑valore in un solo passaggio.

**Come faccio a eliminare un singolo tag per nome senza iterare sull'intera collezione?**

Utilizza l'operazione [Remove(name)](https://reference.aspose.com/slides/it/cpp/aspose.slides/tagcollection/remove/) sulla [TagCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/tagcollection/) per eliminare il tag per la sua chiave.

**Come posso recuperare l'elenco completo dei nomi dei tag per analisi o filtraggio?**

Usa [GetNamesOfTags](https://reference.aspose.com/slides/it/cpp/aspose.slides/tagcollection/getnamesoftags/) sulla [tag collection](https://reference.aspose.com/slides/it/cpp/aspose.slides/tagcollection/); restituisce un array con tutti i nomi dei tag.