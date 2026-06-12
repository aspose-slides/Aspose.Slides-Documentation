---
title: Gestire tag e dati personalizzati nelle presentazioni in .NET
linktitle: Tag e dati personalizzati
type: docs
weight: 300
url: /it/net/managing-tags-and-custom-data/
keywords:
- proprietà del documento
- tag
- dati personalizzati
- aggiungere tag
- coppie di valori
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come aggiungere, leggere, aggiornare e rimuovere tag e dati personalizzati in Aspose.Slides per .NET, con esempi per presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Questo articolo spiega come Aspose.Slides gestisce i tag e i dati personalizzati nelle presentazioni PowerPoint. Descrive brevemente come i dati vengono archiviati nei file PPTX, osserva che i dati specifici della presentazione possono esistere come tag e parti XML personalizzate, e definisce i tag come coppie chiave‑valore di tipo stringa.

Mostra inoltre come leggere i valori dei tag e come aggiungere tag a una presentazione, a una singola diapositiva o a una forma. Inoltre, l’articolo tratta le operazioni comuni di gestione dei tag, come cancellare tutti i tag, rimuovere un tag per nome e recuperare l’elenco dei nomi dei tag.

## **Archiviazione dei dati nei file di presentazione**

I file PPTX—elementi con estensione .pptx—sono archiviati nel formato PresentationML, che fa parte della specifica Office Open XML. Il formato Office Open XML definisce la struttura dei dati contenuti nelle presentazioni.

Con una *diapositiva* che è uno degli elementi delle presentazioni, una *parte diapositiva* contiene il contenuto di una singola diapositiva. A una parte diapositiva è consentito avere relazioni esplicite con molte parti—come i Tag definiti dall’utente—definite da ISO/IEC 29500.

I dati personalizzati (specifici di una presentazione) o dell’utente possono esistere come tag ([ITagCollection](https://reference.aspose.com/slides/it/net/aspose.slides/itagcollection)) e parti CustomXml ([ICustomXmlPartCollection](https://reference.aspose.com/slides/it/net/aspose.slides/icustomxmlpartcollection)).

{{% alert color="primary" %}} 
I tag sono essenzialmente coppie chiave‑valore di tipo stringa. 
{{% /alert %}} 

## **Ottenere i valori dei tag**

In Slides, un tag corrisponde alla proprietà IDocumentProperties.Keywords. Questo esempio di codice mostra come ottenere il valore di un tag con Aspose.Slides per .NET per [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation):

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **Aggiungere tag alle presentazioni**

Aspose.Slides consente di aggiungere tag alle presentazioni. Un tag tipicamente è composto da due elementi:

- il nome di una proprietà personalizzata - `MyTag`  
- il valore della proprietà personalizzata - `My Tag Value`

Se è necessario classificare alcune presentazioni in base a una regola o proprietà specifica, è possibile trarre vantaggio dall’aggiungere tag a tali presentazioni. Ad esempio, se si desidera raggruppare tutte le presentazioni dei paesi del Nord America, è possibile creare un tag Nordamericano e poi assegnare i relativi paesi (Stati Uniti, Messico e Canada) come valori.

Questo esempio di codice mostra come aggiungere un tag a una [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) utilizzando Aspose.Slides per .NET:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

I tag possono anche essere impostati per una [Slide](https://reference.aspose.com/slides/it/net/aspose.slides/slide):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

O per qualsiasi singola [Shape](https://reference.aspose.com/slides/it/net/aspose.slides/shape):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **Limitazioni**

I tag aggiunti tramite la collezione `CustomData.Tags` sono memorizzati solo all’interno del file PowerPoint. **Non** vengono trasferiti nella struttura dei tag PDF quando la presentazione è esportata in PDF. Di conseguenza, un identificatore personalizzato assegnato come tag non può essere recuperato dal PDF taggato.

**Soluzione alternativa**: è possibile memorizzare un identificatore personalizzato nel **Alt Text** dell’oggetto (ad es., `shape.AlternativeText = "MyId"`). Dopo l’esportazione in PDF, l’Alt Text può comparire nella struttura dei tag PDF.

## **FAQ**

**Posso rimuovere tutti i tag da una presentazione, diapositiva o forma in un’unica operazione?**

Sì. La [tag collection](https://reference.aspose.com/slides/it/net/aspose.slides/tagcollection/) supporta un’operazione [clear](https://reference.aspose.com/slides/it/net/aspose.slides/tagcollection/clear/) che elimina tutte le coppie chiave‑valore in una sola volta.

**Come elimino un singolo tag per nome senza iterare sull’intera collezione?**

Utilizza l’operazione [Remove(name)](https://reference.aspose.com/slides/it/net/aspose.slides/tagcollection/remove/) su [TagCollection](https://reference.aspose.com/slides/it/net/aspose.slides/tagcollection/) per cancellare il tag per chiave.

**Come posso recuperare l’elenco completo dei nomi dei tag per analisi o filtraggio?**

Usa [GetNamesOfTags](https://reference.aspose.com/slides/it/net/aspose.slides/tagcollection/getnamesoftags/) sulla [tag collection](https://reference.aspose.com/slides/it/net/aspose.slides/tagcollection/); restituisce un array di tutti i nomi dei tag.